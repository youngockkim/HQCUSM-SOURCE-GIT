
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
//   File Name   : frmQCMTranCreateBatch.vb
//   Description : Create QCM Batch Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - In_Store() : Inventory In Store transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-12-28 : Created by WKIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _QCM = True Then

namespace Miracom.QCMCore
{
    public class frmQCMTranCreateBatch : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMTranCreateBatch()
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
        private System.Windows.Forms.Panel pnlMainMiddle;
        protected System.Windows.Forms.Panel pnlTranInfo;
        protected System.Windows.Forms.TabControl tabTran;
        protected System.Windows.Forms.TabPage tbpGeneral;
        protected System.Windows.Forms.Panel pnlComment;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label lblComment;
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
        private System.Windows.Forms.TabPage tbpItem;
        private System.Windows.Forms.Panel pnlitem;
        private System.Windows.Forms.GroupBox grpItem;
        private Miracom.UI.Controls.MCListView.MCListView lisItem;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        protected System.Windows.Forms.Label Label7;
        private System.Windows.Forms.TextBox txtItem;
        protected System.Windows.Forms.Panel pnlTran;
        private System.Windows.Forms.GroupBox grpTranInfo;
        protected System.Windows.Forms.Label Label6;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvVendor;
        private System.Windows.Forms.TextBox txtBOXID;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.GroupBox grpBatchID;
        protected System.Windows.Forms.TextBox txtDesc;
        protected System.Windows.Forms.TextBox txtBatchID;
        protected System.Windows.Forms.Label lblBatchID;
        protected System.Windows.Forms.Panel pnlTranTime;
        protected System.Windows.Forms.TextBox txtTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranTime;
        protected System.Windows.Forms.CheckBox chkTranDateTime;
        protected System.Windows.Forms.DateTimePicker dtpTranDate;
        private System.Windows.Forms.TextBox txtPOItem;
        private System.Windows.Forms.TextBox txtQty;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspType;
        protected System.Windows.Forms.Label lblInspType;
        protected System.Windows.Forms.Label lblInspSetID;
        private System.Windows.Forms.TextBox txtMaxBatchQty;
        private System.Windows.Forms.TextBox txtMaxSetQty;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.TextBox txtItemQty;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        protected System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        protected System.Windows.Forms.Label Label8;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        protected System.Windows.Forms.Label Label9;
        private System.Windows.Forms.TextBox txtItemDesc;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCustomer;
        protected System.Windows.Forms.Label lblCustomer;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvOrderID;
        protected System.Windows.Forms.Label lblOrderID;
        protected System.Windows.Forms.Label lblVendor;
        protected System.Windows.Forms.Label lblBoxID;
        protected System.Windows.Forms.Label lblInvoice;
        protected System.Windows.Forms.Label lblPO;
        protected System.Windows.Forms.Label lblRetDlvID;
        private Miracom.MESCore.Controls.udcMaterial cdvMatID;
        protected TextBox txtInspSetId;
        private System.Windows.Forms.TextBox txtRetDlvId;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQCMTranCreateBatch));
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
            this.pnlTranInfo = new System.Windows.Forms.Panel();
            this.tabTran = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlTran = new System.Windows.Forms.Panel();
            this.grpTranInfo = new System.Windows.Forms.GroupBox();
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
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtInspSetId = new System.Windows.Forms.TextBox();
            this.cdvMatID = new Miracom.MESCore.Controls.udcMaterial();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtMaxSetQty = new System.Windows.Forms.TextBox();
            this.txtMaxBatchQty = new System.Windows.Forms.TextBox();
            this.lblInspSetID = new System.Windows.Forms.Label();
            this.cdvInspType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInspType = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbpItem = new System.Windows.Forms.TabPage();
            this.lisItem = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlitem = new System.Windows.Forms.Panel();
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtItemQty = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
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
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMainTop.SuspendLayout();
            this.grpBatchID.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            this.pnlMainMiddle.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlTran.SuspendLayout();
            this.grpTranInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrderID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvVendor)).BeginInit();
            this.pnlGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspType)).BeginInit();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.tbpItem.SuspendLayout();
            this.pnlitem.SuspendLayout();
            this.grpItem.SuspendLayout();
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
            this.lblFormTitle.Text = "Create QC Batch";
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
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTranDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTranDateTime.Location = new System.Drawing.Point(13, 3);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(114, 18);
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
            // 
            // lblBatchID
            // 
            this.lblBatchID.AutoSize = true;
            this.lblBatchID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBatchID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatchID.Location = new System.Drawing.Point(16, 18);
            this.lblBatchID.Name = "lblBatchID";
            this.lblBatchID.Size = new System.Drawing.Size(57, 13);
            this.lblBatchID.TabIndex = 0;
            this.lblBatchID.Text = "Batch ID";
            this.lblBatchID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMainMiddle
            // 
            this.pnlMainMiddle.Controls.Add(this.pnlTranInfo);
            this.pnlMainMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMiddle.Location = new System.Drawing.Point(0, 44);
            this.pnlMainMiddle.Name = "pnlMainMiddle";
            this.pnlMainMiddle.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlMainMiddle.Size = new System.Drawing.Size(742, 462);
            this.pnlMainMiddle.TabIndex = 2;
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.tabTran);
            this.pnlTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranInfo.Location = new System.Drawing.Point(3, 3);
            this.pnlTranInfo.Name = "pnlTranInfo";
            this.pnlTranInfo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pnlTranInfo.Size = new System.Drawing.Size(736, 459);
            this.pnlTranInfo.TabIndex = 0;
            // 
            // tabTran
            // 
            this.tabTran.Controls.Add(this.tbpGeneral);
            this.tabTran.Controls.Add(this.tbpItem);
            this.tabTran.Controls.Add(this.tbpCMF);
            this.tabTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTran.ItemSize = new System.Drawing.Size(60, 18);
            this.tabTran.Location = new System.Drawing.Point(0, 3);
            this.tabTran.Name = "tabTran";
            this.tabTran.SelectedIndex = 0;
            this.tabTran.Size = new System.Drawing.Size(736, 453);
            this.tabTran.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlTran);
            this.tbpGeneral.Controls.Add(this.pnlGeneral);
            this.tbpGeneral.Controls.Add(this.pnlComment);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(728, 427);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlTran
            // 
            this.pnlTran.Controls.Add(this.grpTranInfo);
            this.pnlTran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTran.Location = new System.Drawing.Point(0, 100);
            this.pnlTran.Name = "pnlTran";
            this.pnlTran.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlTran.Size = new System.Drawing.Size(728, 287);
            this.pnlTran.TabIndex = 1;
            // 
            // grpTranInfo
            // 
            this.grpTranInfo.Controls.Add(this.lblRetDlvID);
            this.grpTranInfo.Controls.Add(this.txtRetDlvId);
            this.grpTranInfo.Controls.Add(this.cdvOrderID);
            this.grpTranInfo.Controls.Add(this.lblOrderID);
            this.grpTranInfo.Controls.Add(this.cdvCustomer);
            this.grpTranInfo.Controls.Add(this.lblCustomer);
            this.grpTranInfo.Controls.Add(this.txtPOItem);
            this.grpTranInfo.Controls.Add(this.Label6);
            this.grpTranInfo.Controls.Add(this.txtQty);
            this.grpTranInfo.Controls.Add(this.cdvVendor);
            this.grpTranInfo.Controls.Add(this.lblVendor);
            this.grpTranInfo.Controls.Add(this.lblBoxID);
            this.grpTranInfo.Controls.Add(this.lblInvoice);
            this.grpTranInfo.Controls.Add(this.lblPO);
            this.grpTranInfo.Controls.Add(this.txtBOXID);
            this.grpTranInfo.Controls.Add(this.txtInvoice);
            this.grpTranInfo.Controls.Add(this.txtPO);
            this.grpTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTranInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTranInfo.Location = new System.Drawing.Point(3, 3);
            this.grpTranInfo.Name = "grpTranInfo";
            this.grpTranInfo.Size = new System.Drawing.Size(722, 284);
            this.grpTranInfo.TabIndex = 0;
            this.grpTranInfo.TabStop = false;
            this.grpTranInfo.Text = "Transaction Information";
            // 
            // lblRetDlvID
            // 
            this.lblRetDlvID.AutoSize = true;
            this.lblRetDlvID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRetDlvID.Location = new System.Drawing.Point(434, 94);
            this.lblRetDlvID.Name = "lblRetDlvID";
            this.lblRetDlvID.Size = new System.Drawing.Size(60, 13);
            this.lblRetDlvID.TabIndex = 15;
            this.lblRetDlvID.Text = "Ret Dlv. ID";
            this.lblRetDlvID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRetDlvId
            // 
            this.txtRetDlvId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetDlvId.Location = new System.Drawing.Point(556, 91);
            this.txtRetDlvId.MaxLength = 30;
            this.txtRetDlvId.Name = "txtRetDlvId";
            this.txtRetDlvId.Size = new System.Drawing.Size(157, 20);
            this.txtRetDlvId.TabIndex = 16;
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
            this.cdvOrderID.Location = new System.Drawing.Point(556, 66);
            this.cdvOrderID.MaxLength = 25;
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
            this.cdvOrderID.TabIndex = 14;
            this.cdvOrderID.TextBoxToolTipText = "";
            this.cdvOrderID.TextBoxWidth = 157;
            this.cdvOrderID.VisibleButton = true;
            this.cdvOrderID.VisibleColumnHeader = false;
            this.cdvOrderID.VisibleDescription = false;
            this.cdvOrderID.ButtonPress += new System.EventHandler(this.cdvOrderID_ButtonPress);
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOrderID.Location = new System.Drawing.Point(434, 69);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(47, 13);
            this.lblOrderID.TabIndex = 13;
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
            this.cdvCustomer.Location = new System.Drawing.Point(556, 42);
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
            this.cdvCustomer.TabIndex = 12;
            this.cdvCustomer.TextBoxToolTipText = "";
            this.cdvCustomer.TextBoxWidth = 157;
            this.cdvCustomer.VisibleButton = true;
            this.cdvCustomer.VisibleColumnHeader = false;
            this.cdvCustomer.VisibleDescription = false;
            this.cdvCustomer.ButtonPress += new System.EventHandler(this.cdvCustomer_ButtonPress);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCustomer.Location = new System.Drawing.Point(434, 45);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 11;
            this.lblCustomer.Text = "Customer";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPOItem
            // 
            this.txtPOItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPOItem.Location = new System.Drawing.Point(300, 18);
            this.txtPOItem.MaxLength = 30;
            this.txtPOItem.Name = "txtPOItem";
            this.txtPOItem.Size = new System.Drawing.Size(48, 20);
            this.txtPOItem.TabIndex = 2;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(434, 21);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(26, 13);
            this.Label6.TabIndex = 9;
            this.Label6.Text = "Qty";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(556, 18);
            this.txtQty.MaxLength = 11;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(157, 20);
            this.txtQty.TabIndex = 10;
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
            this.cdvVendor.Location = new System.Drawing.Point(136, 91);
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
            this.cdvVendor.TabIndex = 8;
            this.cdvVendor.TextBoxToolTipText = "";
            this.cdvVendor.TextBoxWidth = 157;
            this.cdvVendor.VisibleButton = true;
            this.cdvVendor.VisibleColumnHeader = false;
            this.cdvVendor.VisibleDescription = false;
            this.cdvVendor.ButtonPress += new System.EventHandler(this.cdvVendor_ButtonPress);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVendor.Location = new System.Drawing.Point(14, 94);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(41, 13);
            this.lblVendor.TabIndex = 7;
            this.lblVendor.Text = "Vendor";
            this.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBoxID
            // 
            this.lblBoxID.AutoSize = true;
            this.lblBoxID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBoxID.Location = new System.Drawing.Point(14, 69);
            this.lblBoxID.Name = "lblBoxID";
            this.lblBoxID.Size = new System.Drawing.Size(43, 13);
            this.lblBoxID.TabIndex = 5;
            this.lblBoxID.Text = "BOX ID";
            this.lblBoxID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInvoice.Location = new System.Drawing.Point(14, 45);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(42, 13);
            this.lblInvoice.TabIndex = 3;
            this.lblInvoice.Text = "Invoice";
            this.lblInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPO.Location = new System.Drawing.Point(14, 21);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(81, 13);
            this.lblPO.TabIndex = 0;
            this.lblPO.Text = "Purchase Order";
            this.lblPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBOXID
            // 
            this.txtBOXID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBOXID.Location = new System.Drawing.Point(136, 66);
            this.txtBOXID.MaxLength = 30;
            this.txtBOXID.Name = "txtBOXID";
            this.txtBOXID.Size = new System.Drawing.Size(157, 20);
            this.txtBOXID.TabIndex = 6;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoice.Location = new System.Drawing.Point(136, 42);
            this.txtInvoice.MaxLength = 30;
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(157, 20);
            this.txtInvoice.TabIndex = 4;
            // 
            // txtPO
            // 
            this.txtPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPO.Location = new System.Drawing.Point(136, 18);
            this.txtPO.MaxLength = 30;
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(157, 20);
            this.txtPO.TabIndex = 1;
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.grpGeneral);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.pnlGeneral.Size = new System.Drawing.Size(728, 100);
            this.pnlGeneral.TabIndex = 0;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.txtInspSetId);
            this.grpGeneral.Controls.Add(this.cdvMatID);
            this.grpGeneral.Controls.Add(this.Label8);
            this.grpGeneral.Controls.Add(this.txtMaxSetQty);
            this.grpGeneral.Controls.Add(this.txtMaxBatchQty);
            this.grpGeneral.Controls.Add(this.lblInspSetID);
            this.grpGeneral.Controls.Add(this.cdvInspType);
            this.grpGeneral.Controls.Add(this.lblInspType);
            this.grpGeneral.Controls.Add(this.txtDesc);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 3);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(722, 94);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // txtInspSetId
            // 
            this.txtInspSetId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInspSetId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInspSetId.Location = new System.Drawing.Point(120, 65);
            this.txtInspSetId.MaxLength = 25;
            this.txtInspSetId.Name = "txtInspSetId";
            this.txtInspSetId.ReadOnly = true;
            this.txtInspSetId.Size = new System.Drawing.Size(200, 20);
            this.txtInspSetId.TabIndex = 5;
            // 
            // cdvMatID
            // 
            this.cdvMatID.AddEmptyRowToLast = false;
            this.cdvMatID.AddEmptyRowToTop = false;
            this.cdvMatID.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMatID.DisplaySubItemIndex = 0;
            this.cdvMatID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMatID.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMatID.LabelText = "Material";
            this.cdvMatID.ListCond_ExtFactory = "";
            this.cdvMatID.ListCond_StepMaterial = '1';
            this.cdvMatID.ListCond_StepVersion = '1';
            this.cdvMatID.Location = new System.Drawing.Point(15, 40);
            this.cdvMatID.MaterialEnabled = true;
            this.cdvMatID.MaterialReadOnly = false;
            this.cdvMatID.Name = "cdvMatID";
            this.cdvMatID.SearchSubItemIndex = 0;
            this.cdvMatID.SelectedDescIndex = -1;
            this.cdvMatID.SelectedSubItemIndex = 0;
            this.cdvMatID.Size = new System.Drawing.Size(305, 20);
            this.cdvMatID.TabIndex = 2;
            this.cdvMatID.VersionEnabled = true;
            this.cdvMatID.VersionReadOnly = false;
            this.cdvMatID.VisibleColumnHeader = false;
            this.cdvMatID.VisibleDescription = false;
            this.cdvMatID.VisibleMaterialButton = true;
            this.cdvMatID.VisibleVersionButton = true;
            this.cdvMatID.WidthButton = 20;
            this.cdvMatID.WidthLabel = 105;
            this.cdvMatID.WidthMaterialAndVersion = 200;
            this.cdvMatID.WidthVersion = 50;
            this.cdvMatID.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_MaterialSelectedItemChanged);
            this.cdvMatID.VersionSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMatID_VersionSelectedItemChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label8.Location = new System.Drawing.Point(366, 68);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(172, 13);
            this.Label8.TabIndex = 6;
            this.Label8.Text = "Max Batch Qty / Max Insp. Set Qty";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label8.Visible = false;
            // 
            // txtMaxSetQty
            // 
            this.txtMaxSetQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxSetQty.Location = new System.Drawing.Point(640, 65);
            this.txtMaxSetQty.MaxLength = 11;
            this.txtMaxSetQty.Name = "txtMaxSetQty";
            this.txtMaxSetQty.ReadOnly = true;
            this.txtMaxSetQty.Size = new System.Drawing.Size(72, 20);
            this.txtMaxSetQty.TabIndex = 8;
            this.txtMaxSetQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxSetQty.Visible = false;
            // 
            // txtMaxBatchQty
            // 
            this.txtMaxBatchQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxBatchQty.Location = new System.Drawing.Point(558, 65);
            this.txtMaxBatchQty.MaxLength = 11;
            this.txtMaxBatchQty.Name = "txtMaxBatchQty";
            this.txtMaxBatchQty.ReadOnly = true;
            this.txtMaxBatchQty.Size = new System.Drawing.Size(76, 20);
            this.txtMaxBatchQty.TabIndex = 7;
            this.txtMaxBatchQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxBatchQty.Visible = false;
            // 
            // lblInspSetID
            // 
            this.lblInspSetID.AutoSize = true;
            this.lblInspSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspSetID.Location = new System.Drawing.Point(15, 68);
            this.lblInspSetID.Name = "lblInspSetID";
            this.lblInspSetID.Size = new System.Drawing.Size(89, 13);
            this.lblInspSetID.TabIndex = 4;
            this.lblInspSetID.Text = "Inspection Set ID";
            this.lblInspSetID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvInspType
            // 
            this.cdvInspType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspType.BtnToolTipText = "";
            this.cdvInspType.DescText = "";
            this.cdvInspType.DisplaySubItemIndex = -1;
            this.cdvInspType.DisplayText = "";
            this.cdvInspType.Focusing = null;
            this.cdvInspType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspType.Index = 0;
            this.cdvInspType.IsViewBtnImage = false;
            this.cdvInspType.Location = new System.Drawing.Point(120, 15);
            this.cdvInspType.MaxLength = 10;
            this.cdvInspType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspType.Name = "cdvInspType";
            this.cdvInspType.ReadOnly = false;
            this.cdvInspType.SearchSubItemIndex = 0;
            this.cdvInspType.SelectedDescIndex = -1;
            this.cdvInspType.SelectedSubItemIndex = -1;
            this.cdvInspType.SelectionStart = 0;
            this.cdvInspType.Size = new System.Drawing.Size(200, 20);
            this.cdvInspType.SmallImageList = null;
            this.cdvInspType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspType.TabIndex = 1;
            this.cdvInspType.TextBoxToolTipText = "";
            this.cdvInspType.TextBoxWidth = 200;
            this.cdvInspType.VisibleButton = true;
            this.cdvInspType.VisibleColumnHeader = false;
            this.cdvInspType.VisibleDescription = false;
            this.cdvInspType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInspType_SelectedItemChanged);
            this.cdvInspType.ButtonPress += new System.EventHandler(this.cdvInspType_ButtonPress);
            // 
            // lblInspType
            // 
            this.lblInspType.AutoSize = true;
            this.lblInspType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspType.Location = new System.Drawing.Point(15, 18);
            this.lblInspType.Name = "lblInspType";
            this.lblInspType.Size = new System.Drawing.Size(67, 13);
            this.lblInspType.TabIndex = 0;
            this.lblInspType.Text = "Insp. Type";
            this.lblInspType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(326, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(386, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.grpComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(0, 387);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlComment.Size = new System.Drawing.Size(728, 40);
            this.pnlComment.TabIndex = 2;
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
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 14);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpItem
            // 
            this.tbpItem.Controls.Add(this.lisItem);
            this.tbpItem.Controls.Add(this.pnlitem);
            this.tbpItem.Location = new System.Drawing.Point(4, 22);
            this.tbpItem.Name = "tbpItem";
            this.tbpItem.Padding = new System.Windows.Forms.Padding(3);
            this.tbpItem.Size = new System.Drawing.Size(728, 427);
            this.tbpItem.TabIndex = 2;
            this.tbpItem.Text = "Item Information";
            // 
            // lisItem
            // 
            this.lisItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4});
            this.lisItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisItem.EnableSort = true;
            this.lisItem.EnableSortIcon = true;
            this.lisItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisItem.FullRowSelect = true;
            this.lisItem.GridLines = true;
            this.lisItem.Location = new System.Drawing.Point(3, 47);
            this.lisItem.Name = "lisItem";
            this.lisItem.Size = new System.Drawing.Size(722, 377);
            this.lisItem.TabIndex = 1;
            this.lisItem.UseCompatibleStateImageBehavior = false;
            this.lisItem.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Seq.";
            this.ColumnHeader1.Width = 40;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Item Serial ID";
            this.ColumnHeader2.Width = 150;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Qty";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Desc";
            this.ColumnHeader4.Width = 300;
            // 
            // pnlitem
            // 
            this.pnlitem.Controls.Add(this.grpItem);
            this.pnlitem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlitem.Location = new System.Drawing.Point(3, 3);
            this.pnlitem.Name = "pnlitem";
            this.pnlitem.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlitem.Size = new System.Drawing.Size(722, 44);
            this.pnlitem.TabIndex = 0;
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.Label9);
            this.grpItem.Controls.Add(this.txtItemDesc);
            this.grpItem.Controls.Add(this.Label4);
            this.grpItem.Controls.Add(this.btnDelete);
            this.grpItem.Controls.Add(this.btnInsert);
            this.grpItem.Controls.Add(this.txtItemQty);
            this.grpItem.Controls.Add(this.Label7);
            this.grpItem.Controls.Add(this.txtItem);
            this.grpItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItem.Location = new System.Drawing.Point(0, 0);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(722, 41);
            this.grpItem.TabIndex = 0;
            this.grpItem.TabStop = false;
            // 
            // Label9
            // 
            this.Label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label9.Location = new System.Drawing.Point(16, 42);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(100, 14);
            this.Label9.TabIndex = 37;
            this.Label9.Text = "Item Desc";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label9.Visible = false;
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemDesc.Location = new System.Drawing.Point(138, 40);
            this.txtItemDesc.MaxLength = 200;
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(157, 20);
            this.txtItemDesc.TabIndex = 36;
            this.txtItemDesc.TabStop = false;
            this.txtItemDesc.Visible = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Location = new System.Drawing.Point(332, 18);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 13);
            this.Label4.TabIndex = 33;
            this.Label4.Text = "Item Qty";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(654, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 24);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.Image")));
            this.btnInsert.Location = new System.Drawing.Point(630, 14);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(22, 24);
            this.btnInsert.TabIndex = 32;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtItemQty
            // 
            this.txtItemQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemQty.Location = new System.Drawing.Point(440, 15);
            this.txtItemQty.MaxLength = 30;
            this.txtItemQty.Name = "txtItemQty";
            this.txtItemQty.Size = new System.Drawing.Size(58, 20);
            this.txtItemQty.TabIndex = 30;
            this.txtItemQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemQty_KeyPress);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label7.Location = new System.Drawing.Point(16, 18);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(41, 13);
            this.Label7.TabIndex = 29;
            this.Label7.Text = "Item ID";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItem.Location = new System.Drawing.Point(138, 15);
            this.txtItem.MaxLength = 30;
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(157, 20);
            this.txtItem.TabIndex = 28;
            this.txtItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItem_KeyPress);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.pnlCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Size = new System.Drawing.Size(728, 427);
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
            this.pnlCMF.Size = new System.Drawing.Size(728, 427);
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
            this.grpCMF.Size = new System.Drawing.Size(722, 421);
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
            this.cdvCMF9.Location = new System.Drawing.Point(172, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 200;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF8.Location = new System.Drawing.Point(172, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 200;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF7.Location = new System.Drawing.Point(172, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 200;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF6.Location = new System.Drawing.Point(172, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 200;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF5.Location = new System.Drawing.Point(172, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 200;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF4.Location = new System.Drawing.Point(172, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 200;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF3.Location = new System.Drawing.Point(172, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 200;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF2.Location = new System.Drawing.Point(172, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 200;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF10.Location = new System.Drawing.Point(172, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 200;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF1.Location = new System.Drawing.Point(172, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 200;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(16, 235);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(150, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(16, 211);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(150, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(16, 187);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(150, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(16, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(150, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(16, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(150, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(16, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(150, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(16, 91);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(150, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(16, 67);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(150, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(16, 43);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(150, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(16, 19);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(150, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmQCMTranCreateBatch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmQCMTranCreateBatch";
            this.Tag = "QCM2001";
            this.Text = "Create QCM Batch";
            this.Activated += new System.EventHandler(this.frmQCMTranCreateBatch_Activated);
            this.Load += new System.EventHandler(this.frmQCMTranCreateBatch_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMainTop.ResumeLayout(false);
            this.grpBatchID.ResumeLayout(false);
            this.grpBatchID.PerformLayout();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            this.pnlMainMiddle.ResumeLayout(false);
            this.pnlTranInfo.ResumeLayout(false);
            this.tabTran.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlTran.ResumeLayout(false);
            this.grpTranInfo.ResumeLayout(false);
            this.grpTranInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOrderID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvVendor)).EndInit();
            this.pnlGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspType)).EndInit();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.tbpItem.ResumeLayout(false);
            this.pnlitem.ResumeLayout(false);
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
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
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool bLoadFlag;
        private bool bItemCheck;
        private int iToTItemCount;
        private double dToTQty;
        
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
                        MPCF.InitListView(lisItem);
                        break;
                    case '2':
                        
                        //Lot ?ÖÎ†• ??Enter ??Lot ?ïÎ≥¥ Ï∂úÎ†•
                        //FieldClear(grpTranInfo)
                        MPCF.FieldClear(tbpItem, null, null, null, null, null, false);
                        MPCF.FieldClear(tbpCMF, null, null, null, null, null, false);
                        MPCF.InitListView(lisItem);
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
                case "CREATE":

                    if (MPCF.CheckValue(txtBatchID, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (cdvMatID.CheckValue() == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtInspSetId, 1, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtQty, 2, false, false, "", "", "") == false)
                    {
                        return false;
                    }
                    
                    if (bItemCheck)
                    {
                        if (MPCF.ToDbl(txtQty.Text) != dToTQty)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(202)); //?òÎüâ???ºÏπò?òÏ? ?äÏäµ?àÎã§.
                            txtQty.Focus();
                            return false;
                        }
                    }
                    
                    //Qty Validation 
                    if ((MPCF.ToInt(txtMaxBatchQty.Text) != 0) ? (MPCF.ToDbl(txtMaxBatchQty.Text) < MPCF.ToDbl(txtQty.Text)) : false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(200)); //Item ?òÎüâ??Batch??ÏµúÎ? ?òÎüâ??Ï¥àÍ≥º?¥ÏÑú???àÎê©?àÎã§.
                        txtQty.Focus();
                        return false;
                    }
                    
                    //Qty Validation
                    if ((MPCF.ToInt(txtMaxSetQty.Text) != 0) ? (MPCF.ToDbl(txtMaxSetQty.Text) < MPCF.ToDbl(txtQty.Text)) : false)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(201)); //Item ?òÎüâ??Inspection Set??ÏµúÎ? ?òÎüâ??Ï¥àÍ≥º?¥ÏÑú???àÎê©?àÎã§.
                        txtQty.Focus();
                        return false;
                    }
                    
                    //CMF Validation
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        tabTran.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }

        //
        // View_Inspection_Material_Info()
        //       - View Inspection Material Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sMatID As String : Material
        //
        private bool View_Inspection_Material_Info(string sMatID, int iMatVer)
        {            
            TRSNode in_node = new TRSNode("VIEW_INSPECTION_MATERIAL_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_MATERIAL_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", sMatID);
            in_node.AddInt("MAT_VER", iMatVer);

            if (MPCR.CallService("QCM", "QCM_View_Inspection_Material", in_node, ref out_node) == false)
            {
                return false;
            }

            txtDesc.Text = out_node.GetString("MAT_DESC");
            //chkTotalInspection.Checked = (out_node.GetChar("TOTAL_INSP)") == 'Y') ? true : false;
            //chkAutoFinal.Checked = (out_node.GetChar("AUTO_FINAL)") == 'Y') ? true : false;
            //chkSkipResult.Checked = (out_node.GetChar("SKIP_RESULT_RECORD)") == 'Y') ? true : false;
            //Modify by J.S. 2009.04.09
            txtMaxBatchQty.Text = out_node.GetDouble("MAX_QTY").ToString();

            //chkIQC.Checked = (out_node.GetChar("IQC_FLAG)") == 'Y') ? true : false;
            //txtIQCInspSetID.Text = RTrim(View_Inspection_Material_Out.iqc_insp_set_id)
            //chkPQC.Checked = (out_node.GetChar("PQC_FLAG)") == 'Y') ? true : false;
            //txtPQCInspSetID.Text = RTrim(View_Inspection_Material_Out.pqc_insp_set_id)
            //chkOQC.Checked = (out_node.GetChar("PQC_FLAG)") == 'Y') ? true : false;
            //txtOQCInspSetID.Text = RTrim(View_Inspection_Material_Out.oqc_insp_set_id)
            //chkRMA.Checked = (out_node.GetChar("RMA_FLAG)") == 'Y') ? true : false;
            //txtRMAInspSetID.Text = RTrim(View_Inspection_Material_Out.rma_insp_set_id)

            if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_IQC)
            {
                txtInspSetId.Text = out_node.GetString("IQC_INSP_SET_ID");
            }
            else if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_OQC)
            {
                txtInspSetId.Text = out_node.GetString("OQC_INSP_SET_ID");
            }
            else if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_PQC)
            {
                txtInspSetId.Text = out_node.GetString("PQC_INSP_SET_ID");
            }
            else if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_RMA)
            {
                txtInspSetId.Text = out_node.GetString("RMA_INSP_SET_ID");
            }
            
            return true;
            
        }
        
        //'
        // Create_Batch()
        //       - Convert Lot To Inventory
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Create_Batch(char ProcStep)
        {
            
            int i = 0;
            TRSNode in_node = new TRSNode("CREATE_BATCH_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMatID.Text));
                in_node.AddInt("MAT_VER", cdvMatID.Version);

                in_node.AddString("INSP_SET_ID", MPCF.Trim(txtInspSetId.Text));
                in_node.AddString("INSP_TYPE", MPCF.Trim(cdvInspType.Text));

                if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_IQC)
                {
                    in_node.AddString("PO", MPCF.Trim(txtPO.Text));
                    in_node.AddString("PO_ITEM", MPCF.Trim(txtPOItem.Text));
                    in_node.AddString("INVOICE", MPCF.Trim(txtInvoice.Text));
                    in_node.AddString("BOX_ID", MPCF.Trim(txtBOXID.Text));
                    in_node.AddString("VENDOR", MPCF.Trim(cdvVendor.Text));

                }
                else if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_OQC)
                {
                    in_node.AddString("CUSTOMER", MPCF.Trim(cdvCustomer.Text));
                    in_node.AddString("ORDER_ID", MPCF.Trim(cdvOrderID.Text));
                }
                else if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_PQC)
                {
                }
                else if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_RMA)
                {
                    in_node.AddString("CUSTOMER", MPCF.Trim(cdvCustomer.Text));
                    in_node.AddString("RET_DLV_ID", MPCF.Trim(txtRetDlvId.Text));
                }

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

                in_node.AddDouble("QTY_1", MPCF.ToDbl(txtQty.Text));
            
                if (lisItem.Items.Count != 0)
                {
                    for (i = 0; i < lisItem.Items.Count; i++)
                    {
                        node = in_node.AddNode("ITEM_LIST");

                        node.AddString("ITEM_ID", lisItem.Items[i].SubItems[1].Text);
                        node.AddDouble("ITEM_QTY_1", MPCF.ToDbl(lisItem.Items[i].SubItems[2].Text));
                    }
                }

                in_node.AddInt("ITEM_COUNT", lisItem.Items.Count);

                
                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("QCM", "QCM_Create_Batch", in_node, ref out_node) == false)
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

                if (MPCR.CallService("QCM", "QCM_View_Inspection_Set", in_node, ref out_node) == false)
                {
                    return false;
                }
                //Modify by J.S. 2009.04.09
                txtMaxSetQty.Text = out_node.GetDouble("MAX_QTY").ToString();
                bItemCheck = (out_node.GetChar("ITEM_CHECK_FLAG") == 'Y') ? true : false;
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        // View_Lot()
        //       -  View Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Lot_Info(char c_step, string sLot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("LOT_ID", MPCF.Trim(sLot_id));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                //MPCF.ShowMsgBox(MPMH.StatusMessage);
                return false;
            }
            //if (out_node.StatusValue != MPGC.MP_SUCCESS_STATUS)
            //{
            //    MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, out_node.FieldMsg));
            //    return false;
            //}
            
            // Lot??Status Check
            // OQC : ?ùÏÇ∞???ÑÎ£å?êÎäîÏßÄ
            if (MPCF.Trim(cdvMatID.Text) != out_node.GetString("MAT_ID"))
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(271));
                return false;
            }

            txtItemDesc.Text = out_node.GetString("LOT_DESC");
            txtItemQty.Text = out_node.GetDouble("QTY_1").ToString();

            
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
        
        private void frmQCMTranCreateBatch_Load(object sender, System.EventArgs e)
        {
            
            pnlTranTime.Visible = MPGO.UseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
        }
        
        private void frmQCMTranCreateBatch_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (bLoadFlag == false)
                {
                    ClearData('1');
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_QCM_BATCH, "lblCMF", "cdvCMF", grpCMF);
                    
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
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("CREATE") == true)
                {
                    if (Create_Batch('1') == false)
                    {
                        return;
                    }
                    iToTItemCount = 0;
                    dToTQty = 0;

                    ClearData('2');
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        } 
        
        private void cdvInspType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            if (cdvInspType.Text == "")
            {
                return;
            }
            
            txtInspSetId.Text=""; 
            
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
            if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_OQC)
            {
                lblCustomer.Visible = true;
                cdvCustomer.Visible = true;
                lblOrderID.Visible = true;
                cdvOrderID.Visible = true;
            }
            else if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_IQC)
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
            else if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_PQC)
            {
                
            }
            else if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_RMA)
            {
                lblCustomer.Visible = true;
                cdvCustomer.Visible = true;
                lblRetDlvID.Visible = true;
                txtRetDlvId.Visible = true;
            }
            
        }
        
        private void txtInspSetId_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (txtInspSetId.Text == "")
            {
                return;
            }
            View_Inspection_Set(txtInspSetId.Text);
        }
        
        private void btnInsert_Click(System.Object sender, System.EventArgs e)
        {
            int i;
            ListViewItem itmX;
            int iSeqNum;
            try
            {
                i = 0;
                if (txtItem.Text == "")
                {
                    return;
                }
                
                
                //OQC ??Í≤ΩÏö∞ Lot ?ïÎ≥¥ Check
                if (cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_OQC || cdvInspType.Text == MPGC.MP_QCM_INSP_TYPE_PQC)
                {
                    if (View_Lot_Info('1', txtItem.Text) == false)
                    {
                        return;
                    }
                }
                else
                {
                    if (MPCF.ToDbl(txtItemQty.Text) <= 0)
                    {
                        txtItemQty.Focus();
                        return;
                    }
                }
                
                if (MPCF.FindListItemIndex(lisItem, txtItem.Text, 1, false) < 0)
                {
                    
                    if (lisItem.SelectedItems.Count > 0)
                    {
                        iSeqNum = lisItem.SelectedItems[0].Index + 1;
                    }
                    else
                    {
                        iSeqNum = lisItem.Items.Count + 1;
                    }
                    
                    itmX = new ListViewItem(iSeqNum.ToString());
                    itmX.SubItems.Add(txtItem.Text);
                    itmX.SubItems.Add(txtItemQty.Text);
                    itmX.SubItems.Add(txtItemDesc.Text);
                    lisItem.Items.Insert(iSeqNum - 1, itmX);
                    
                    iToTItemCount++;
                    dToTQty += MPCF.ToDbl(txtItemQty.Text);
                    
                }
                
                for (i = 0; i <= lisItem.Items.Count - 1; i++)
                {
                    lisItem.Items[i].Text = MPCF.Trim(i + 1);
                }

                if (MPCF.Trim(txtQty.Text) == "")
                {
                    txtQty.Text="0";
                }
                else
                {
                    txtQty.Text = MPCF.Trim(dToTQty);
                }

                txtItem.Text = "";
                txtItemQty.Text = "";

                txtItem.Focus();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            int i= 0;
            double dQty = 0;
            
            try
            {
                while (i < lisItem.Items.Count)
                {
                    if (lisItem.Items[i].Selected == true)
                    {
                        iToTItemCount--;
                        dToTQty -= MPCF.ToDbl(lisItem.Items[i].SubItems[2].Text);
                        lisItem.Items[i].Remove();
                        
                    }
                    else
                    {
                        dQty += MPCF.ToDbl(lisItem.Items[i].SubItems[2].Text);
                        i++;
                    }
                }
                
                for (i = 0; i <= lisItem.Items.Count - 1; i++)
                {
                    lisItem.Items[i].Text = MPCF.Trim(i + 1);
                }

                txtQty.Text = MPCF.Trim(dQty);

                txtItem.Text = "";
                txtItemQty.Text = "";
                txtItem.Focus();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
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
        
        private void txtInspSetId_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            if (txtInspSetId.Text == "")
            {
                return;
            }
            View_Inspection_Set(txtInspSetId.Text);
        }
        
        private void txtItem_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnInsert.PerformClick();
            }
        }
        
        private void txtItemQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnInsert.PerformClick();
            }
        } 
        
        private void cdvInspType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInspType.Init();
            MPCF.InitListView(cdvInspType.GetListView);
            cdvInspType.Columns.Add("Insp. Type", 100, HorizontalAlignment.Left);
            cdvInspType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvInspType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvInspType.GetListView, '1', MPGC.MP_QCM_INSP_TYPE);
        }

        private void cdvMatID_MaterialSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (View_Inspection_Material_Info(cdvMatID.Text, cdvMatID.Version) == false)
            {
                return;
            }
        }

        private void cdvMatID_VersionSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvMatID.Text == "")
            {
                return;
            }
            if (View_Inspection_Material_Info(cdvMatID.Text, cdvMatID.Version) == false)
            {
                return;
            }
        } 
    }
    //#End If
}
