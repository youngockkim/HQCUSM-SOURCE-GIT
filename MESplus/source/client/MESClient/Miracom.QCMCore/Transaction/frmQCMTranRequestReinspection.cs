
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
//   File Name   : frmQCMTranRequestReinspection.vb
//   Description : Final Decision Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - Request_Reinspection() : Result Record transaction
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
//#If _QCM = True Then

namespace Miracom.QCMCore
{
    public class frmQCMTranRequestReinspection : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMTranRequestReinspection()
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
        private System.Windows.Forms.Panel pnlInspItem;
        private System.Windows.Forms.GroupBox grpInspItem;
        private FarPoint.Win.Spread.FpSpread spdInspItem;
        private System.Windows.Forms.GroupBox grpDefect;
        private System.Windows.Forms.Panel pnlDefect;
        private FarPoint.Win.Spread.FpSpread spdDefect;
        private System.Windows.Forms.Panel pnlDefectInspItem;
        private System.Windows.Forms.Button btnHideDefect;
        protected System.Windows.Forms.TextBox txtDefectInspItem;
        protected System.Windows.Forms.Panel pnlComment;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Panel pnlGeneralTop;
        private System.Windows.Forms.GroupBox grpBatInfo;
        private System.Windows.Forms.Panel pnlBatchInfoMain;
        private System.Windows.Forms.TabPage tbpItem;
        private Miracom.UI.Controls.MCListView.MCListView lisItem;
        private System.Windows.Forms.Panel pnlSelectedInspItem;
        private System.Windows.Forms.GroupBox grpSelectedInspItem;
        protected System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtDefectQty;
        protected System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtTestQty;
        protected System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtItemCount;
        protected System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtResult;
        protected System.Windows.Forms.Label Label1;
        protected System.Windows.Forms.Label Label8;
        private System.Windows.Forms.TextBox txtSeq;
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
        private FarPoint.Win.Spread.SheetView spdInspItem_Sheet1;
        private FarPoint.Win.Spread.SheetView spdDefect_Sheet1;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.ColumnHeader ColumnHeader14;
        private System.Windows.Forms.ColumnHeader ColumnHeader15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspItem;
        private Miracom.QCMCore.udcQCMBatchInfo ctrlBatchInfo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
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
            this.pnlInspItem = new System.Windows.Forms.Panel();
            this.grpInspItem = new System.Windows.Forms.GroupBox();
            this.spdInspItem = new FarPoint.Win.Spread.FpSpread();
            this.spdInspItem_Sheet1 = new FarPoint.Win.Spread.SheetView();
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
            this.tbpItem = new System.Windows.Forms.TabPage();
            this.lisItem = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSelectedInspItem = new System.Windows.Forms.Panel();
            this.grpSelectedInspItem = new System.Windows.Forms.GroupBox();
            this.cdvInspItem = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtDefectQty = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtTestQty = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtItemCount = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtSeq = new System.Windows.Forms.TextBox();
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
            this.tabTran.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGeneralMiddle.SuspendLayout();
            this.pnlTranInfo.SuspendLayout();
            this.pnlInspItem.SuspendLayout();
            this.grpInspItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem_Sheet1)).BeginInit();
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
            this.tbpItem.SuspendLayout();
            this.pnlSelectedInspItem.SuspendLayout();
            this.grpSelectedInspItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspItem)).BeginInit();
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
            this.btnProcess.Text = "Request";
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
            this.lblFormTitle.Text = "Final Decision";
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
            this.txtBatchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchID_KeyPress);
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
            this.tabTran.Controls.Add(this.tbpItem);
            this.tabTran.Controls.Add(this.tbpCMF);
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
            this.pnlTranInfo.Controls.Add(this.pnlInspItem);
            this.pnlTranInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTranInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlTranInfo.Name = "pnlTranInfo";
            this.pnlTranInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 242);
            this.pnlTranInfo.TabIndex = 0;
            // 
            // pnlInspItem
            // 
            this.pnlInspItem.Controls.Add(this.grpInspItem);
            this.pnlInspItem.Controls.Add(this.grpDefect);
            this.pnlInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlInspItem.Location = new System.Drawing.Point(3, 0);
            this.pnlInspItem.Name = "pnlInspItem";
            this.pnlInspItem.Size = new System.Drawing.Size(722, 242);
            this.pnlInspItem.TabIndex = 7;
            // 
            // grpInspItem
            // 
            this.grpInspItem.Controls.Add(this.spdInspItem);
            this.grpInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInspItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInspItem.Location = new System.Drawing.Point(0, 0);
            this.grpInspItem.Name = "grpInspItem";
            this.grpInspItem.Size = new System.Drawing.Size(722, 242);
            this.grpInspItem.TabIndex = 0;
            this.grpInspItem.TabStop = false;
            this.grpInspItem.Text = "Inspection Item";
            // 
            // spdInspItem
            // 
            this.spdInspItem.AccessibleDescription = "spdInspItem, Sheet1, Row 0, Column 0, ";
            this.spdInspItem.BackColor = System.Drawing.SystemColors.Control;
            this.spdInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdInspItem.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdInspItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInspItem.HorizontalScrollBar.Name = "";
            this.spdInspItem.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdInspItem.HorizontalScrollBar.TabIndex = 2;
            this.spdInspItem.Location = new System.Drawing.Point(3, 16);
            this.spdInspItem.Name = "spdInspItem";
            this.spdInspItem.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdInspItem.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdInspItem.SelectionBlockOptions = ((FarPoint.Win.Spread.SelectionBlockOptions)((FarPoint.Win.Spread.SelectionBlockOptions.Cells | FarPoint.Win.Spread.SelectionBlockOptions.Rows)));
            this.spdInspItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdInspItem_Sheet1});
            this.spdInspItem.Size = new System.Drawing.Size(716, 223);
            this.spdInspItem.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdInspItem.TabIndex = 0;
            this.spdInspItem.TabStop = false;
            this.spdInspItem.TextTipDelay = 200;
            this.spdInspItem.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdInspItem.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInspItem.VerticalScrollBar.Name = "";
            this.spdInspItem.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdInspItem.VerticalScrollBar.TabIndex = 3;
            this.spdInspItem.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdInspItem_CellClick);
            this.spdInspItem.SetViewportLeftColumn(0, 0, 3);
            this.spdInspItem.SetActiveViewport(0, 0, -1);
            // 
            // spdInspItem_Sheet1
            // 
            this.spdInspItem_Sheet1.Reset();
            spdInspItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdInspItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdInspItem_Sheet1.ColumnCount = 20;
            spdInspItem_Sheet1.RowCount = 3;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Insp. Item";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Inspection Method";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Sampling Proc.";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Samp. Proc. Type";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Samp. Proc. Rate";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Fix Samp Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Samp. Proc. Unit";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Determine Value";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Determine Unit";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Check Determine Flag";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Samp. Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Test Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Defect Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Defect Code";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Result";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Comment";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Tran Time";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "User";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Defect Group";
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdInspItem_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(0).Label = "Insp. Item";
            this.spdInspItem_Sheet1.Columns.Get(0).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(0).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(1).Label = "Description";
            this.spdInspItem_Sheet1.Columns.Get(1).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(1).Width = 100F;
            this.spdInspItem_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(2).Label = "Inspection Method";
            this.spdInspItem_Sheet1.Columns.Get(2).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(2).Width = 121F;
            this.spdInspItem_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(3).Label = "Sampling Proc.";
            this.spdInspItem_Sheet1.Columns.Get(3).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(3).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(3).Width = 130F;
            this.spdInspItem_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(4).Label = "Samp. Proc. Type";
            this.spdInspItem_Sheet1.Columns.Get(4).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(4).Width = 97F;
            this.spdInspItem_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(5).Label = "Samp. Proc. Rate";
            this.spdInspItem_Sheet1.Columns.Get(5).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(5).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(5).Width = 97F;
            this.spdInspItem_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(6).CellType = numberCellType1;
            this.spdInspItem_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(6).Label = "Fix Samp Qty";
            this.spdInspItem_Sheet1.Columns.Get(6).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(6).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(6).Width = 107F;
            this.spdInspItem_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(7).Label = "Samp. Proc. Unit";
            this.spdInspItem_Sheet1.Columns.Get(7).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(7).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(7).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(8).Label = "Determine Value";
            this.spdInspItem_Sheet1.Columns.Get(8).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(8).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(8).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(9).Label = "Determine Unit";
            this.spdInspItem_Sheet1.Columns.Get(9).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(9).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(9).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(10).Label = "Check Determine Flag";
            this.spdInspItem_Sheet1.Columns.Get(10).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(10).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(10).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(11).CellType = numberCellType2;
            this.spdInspItem_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(11).Label = "Samp. Qty";
            this.spdInspItem_Sheet1.Columns.Get(11).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(11).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.WhiteSmoke;
            numberCellType3.MinimumValue = 0D;
            this.spdInspItem_Sheet1.Columns.Get(12).CellType = numberCellType3;
            this.spdInspItem_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(12).Label = "Test Qty";
            this.spdInspItem_Sheet1.Columns.Get(12).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(12).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(13).BackColor = System.Drawing.Color.WhiteSmoke;
            numberCellType4.MinimumValue = 0D;
            this.spdInspItem_Sheet1.Columns.Get(13).CellType = numberCellType4;
            this.spdInspItem_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(13).Label = "Defect Qty";
            this.spdInspItem_Sheet1.Columns.Get(13).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(13).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(14).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(14).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(14).Label = "Defect Code";
            this.spdInspItem_Sheet1.Columns.Get(14).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(14).Width = 82F;
            this.spdInspItem_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(15).Label = "Result";
            this.spdInspItem_Sheet1.Columns.Get(15).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(16).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(16).Label = "Comment";
            this.spdInspItem_Sheet1.Columns.Get(16).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(16).Width = 213F;
            this.spdInspItem_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(17).Label = "Tran Time";
            this.spdInspItem_Sheet1.Columns.Get(17).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(17).Width = 131F;
            this.spdInspItem_Sheet1.Columns.Get(18).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(18).Label = "User";
            this.spdInspItem_Sheet1.Columns.Get(18).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(18).Width = 122F;
            this.spdInspItem_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(19).Label = "Defect Group";
            this.spdInspItem_Sheet1.Columns.Get(19).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(19).Resizable = false;
            this.spdInspItem_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(19).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(19).Width = 80F;
            this.spdInspItem_Sheet1.FrozenColumnCount = 3;
            this.spdInspItem_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdInspItem_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdInspItem_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdInspItem_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdInspItem_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdInspItem_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdInspItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpDefect
            // 
            this.grpDefect.Controls.Add(this.pnlDefect);
            this.grpDefect.Controls.Add(this.pnlDefectInspItem);
            this.grpDefect.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpDefect.FlatStyle = System.Windows.Forms.FlatStyle.System;
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
            this.spdDefect.AccessibleDescription = "spdDefect";
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
            this.spdDefect.SetViewportLeftColumn(0, 0, 3);
            this.spdDefect.SetActiveViewport(0, 0, -1);
            // 
            // spdDefect_Sheet1
            // 
            this.spdDefect_Sheet1.Reset();
            spdDefect_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDefect_Sheet1.ColumnCount = 2;
            spdDefect_Sheet1.RowCount = 10;
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Defect Code";
            this.spdDefect_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Qty";
            this.spdDefect_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdDefect_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdDefect_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdDefect_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdDefect_Sheet1.Columns.Get(0).Label = "Defect Code";
            this.spdDefect_Sheet1.Columns.Get(0).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(0).Width = 100F;
            this.spdDefect_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.MinimumValue = 0D;
            this.spdDefect_Sheet1.Columns.Get(1).CellType = numberCellType5;
            this.spdDefect_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdDefect_Sheet1.Columns.Get(1).Label = "Qty";
            this.spdDefect_Sheet1.Columns.Get(1).Locked = true;
            this.spdDefect_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdDefect_Sheet1.Columns.Get(1).Width = 50F;
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
            this.btnHideDefect.Text = "<<";
            this.btnHideDefect.Click += new System.EventHandler(this.btnHideDefect_Click);
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
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 14);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
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
            // tbpItem
            // 
            this.tbpItem.Controls.Add(this.lisItem);
            this.tbpItem.Controls.Add(this.pnlSelectedInspItem);
            this.tbpItem.Location = new System.Drawing.Point(4, 22);
            this.tbpItem.Name = "tbpItem";
            this.tbpItem.Padding = new System.Windows.Forms.Padding(3);
            this.tbpItem.Size = new System.Drawing.Size(728, 428);
            this.tbpItem.TabIndex = 2;
            this.tbpItem.Text = "Item Information";
            this.tbpItem.Visible = false;
            // 
            // lisItem
            // 
            this.lisItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader12,
            this.ColumnHeader11,
            this.ColumnHeader1,
            this.ColumnHeader13,
            this.ColumnHeader14,
            this.ColumnHeader15});
            this.lisItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisItem.EnableSort = true;
            this.lisItem.EnableSortIcon = true;
            this.lisItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisItem.FullRowSelect = true;
            this.lisItem.GridLines = true;
            this.lisItem.Location = new System.Drawing.Point(3, 78);
            this.lisItem.Name = "lisItem";
            this.lisItem.Size = new System.Drawing.Size(722, 347);
            this.lisItem.TabIndex = 3;
            this.lisItem.UseCompatibleStateImageBehavior = false;
            this.lisItem.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Seq.";
            this.ColumnHeader6.Width = 40;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Item Serial ID";
            this.ColumnHeader7.Width = 150;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Qty";
            this.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Result";
            this.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Defect Code";
            this.ColumnHeader11.Width = 79;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Comment";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Status";
            this.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Tran Time";
            this.ColumnHeader14.Width = 120;
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "User";
            // 
            // pnlSelectedInspItem
            // 
            this.pnlSelectedInspItem.Controls.Add(this.grpSelectedInspItem);
            this.pnlSelectedInspItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectedInspItem.Location = new System.Drawing.Point(3, 3);
            this.pnlSelectedInspItem.Name = "pnlSelectedInspItem";
            this.pnlSelectedInspItem.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlSelectedInspItem.Size = new System.Drawing.Size(722, 75);
            this.pnlSelectedInspItem.TabIndex = 0;
            // 
            // grpSelectedInspItem
            // 
            this.grpSelectedInspItem.Controls.Add(this.cdvInspItem);
            this.grpSelectedInspItem.Controls.Add(this.Label3);
            this.grpSelectedInspItem.Controls.Add(this.txtDefectQty);
            this.grpSelectedInspItem.Controls.Add(this.Label4);
            this.grpSelectedInspItem.Controls.Add(this.txtTestQty);
            this.grpSelectedInspItem.Controls.Add(this.Label5);
            this.grpSelectedInspItem.Controls.Add(this.txtItemCount);
            this.grpSelectedInspItem.Controls.Add(this.Label2);
            this.grpSelectedInspItem.Controls.Add(this.txtResult);
            this.grpSelectedInspItem.Controls.Add(this.Label1);
            this.grpSelectedInspItem.Controls.Add(this.Label8);
            this.grpSelectedInspItem.Controls.Add(this.txtSeq);
            this.grpSelectedInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSelectedInspItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSelectedInspItem.Location = new System.Drawing.Point(0, 0);
            this.grpSelectedInspItem.Name = "grpSelectedInspItem";
            this.grpSelectedInspItem.Size = new System.Drawing.Size(722, 72);
            this.grpSelectedInspItem.TabIndex = 0;
            this.grpSelectedInspItem.TabStop = false;
            this.grpSelectedInspItem.Text = "Selected Insp. Item";
            // 
            // cdvInspItem
            // 
            this.cdvInspItem.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspItem.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspItem.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspItem.BtnToolTipText = "";
            this.cdvInspItem.DescText = "";
            this.cdvInspItem.DisplaySubItemIndex = -1;
            this.cdvInspItem.DisplayText = "";
            this.cdvInspItem.Focusing = null;
            this.cdvInspItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspItem.Index = 0;
            this.cdvInspItem.IsViewBtnImage = false;
            this.cdvInspItem.Location = new System.Drawing.Point(120, 19);
            this.cdvInspItem.MaxLength = 30;
            this.cdvInspItem.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspItem.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspItem.Name = "cdvInspItem";
            this.cdvInspItem.ReadOnly = false;
            this.cdvInspItem.SearchSubItemIndex = 0;
            this.cdvInspItem.SelectedDescIndex = -1;
            this.cdvInspItem.SelectedSubItemIndex = -1;
            this.cdvInspItem.SelectionStart = 0;
            this.cdvInspItem.Size = new System.Drawing.Size(100, 20);
            this.cdvInspItem.SmallImageList = null;
            this.cdvInspItem.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspItem.TabIndex = 44;
            this.cdvInspItem.TextBoxToolTipText = "";
            this.cdvInspItem.TextBoxWidth = 100;
            this.cdvInspItem.VisibleButton = true;
            this.cdvInspItem.VisibleColumnHeader = false;
            this.cdvInspItem.VisibleDescription = false;
            this.cdvInspItem.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInspItem_SelectedItemChanged);
            this.cdvInspItem.ButtonPress += new System.EventHandler(this.cdvInspItem_ButtonPress);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Location = new System.Drawing.Point(510, 47);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(58, 13);
            this.Label3.TabIndex = 53;
            this.Label3.Text = "Defect Qty";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDefectQty
            // 
            this.txtDefectQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefectQty.Location = new System.Drawing.Point(614, 44);
            this.txtDefectQty.MaxLength = 11;
            this.txtDefectQty.Name = "txtDefectQty";
            this.txtDefectQty.ReadOnly = true;
            this.txtDefectQty.Size = new System.Drawing.Size(100, 20);
            this.txtDefectQty.TabIndex = 54;
            this.txtDefectQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Location = new System.Drawing.Point(268, 47);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(47, 13);
            this.Label4.TabIndex = 51;
            this.Label4.Text = "Test Qty";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTestQty
            // 
            this.txtTestQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestQty.Location = new System.Drawing.Point(372, 44);
            this.txtTestQty.MaxLength = 11;
            this.txtTestQty.Name = "txtTestQty";
            this.txtTestQty.ReadOnly = true;
            this.txtTestQty.Size = new System.Drawing.Size(104, 20);
            this.txtTestQty.TabIndex = 52;
            this.txtTestQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Location = new System.Drawing.Point(16, 47);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(58, 13);
            this.Label5.TabIndex = 49;
            this.Label5.Text = "Item Count";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemCount
            // 
            this.txtItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCount.Location = new System.Drawing.Point(120, 44);
            this.txtItemCount.MaxLength = 30;
            this.txtItemCount.Name = "txtItemCount";
            this.txtItemCount.ReadOnly = true;
            this.txtItemCount.Size = new System.Drawing.Size(100, 20);
            this.txtItemCount.TabIndex = 50;
            this.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Location = new System.Drawing.Point(510, 22);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(37, 13);
            this.Label2.TabIndex = 47;
            this.Label2.Text = "Result";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(614, 19);
            this.txtResult.MaxLength = 30;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(100, 20);
            this.txtResult.TabIndex = 48;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Location = new System.Drawing.Point(16, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 13);
            this.Label1.TabIndex = 43;
            this.Label1.Text = "Insp. Item";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label8.Location = new System.Drawing.Point(268, 22);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(29, 13);
            this.Label8.TabIndex = 45;
            this.Label8.Text = "Seq.";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSeq
            // 
            this.txtSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeq.Location = new System.Drawing.Point(372, 19);
            this.txtSeq.MaxLength = 6;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.ReadOnly = true;
            this.txtSeq.Size = new System.Drawing.Size(104, 20);
            this.txtSeq.TabIndex = 46;
            this.txtSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvCMF_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            // frmQCMTranRequestReinspection
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmQCMTranRequestReinspection";
            this.Tag = "QCM2006";
            this.Text = "Request Reinspection";
            this.Activated += new System.EventHandler(this.frmQCMTranRequestReinspection_Activated);
            this.Load += new System.EventHandler(this.frmQCMTranRequestReinspection_Load);
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
            this.pnlInspItem.ResumeLayout(false);
            this.grpInspItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem_Sheet1)).EndInit();
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
            this.tbpItem.ResumeLayout(false);
            this.pnlSelectedInspItem.ResumeLayout(false);
            this.grpSelectedInspItem.ResumeLayout(false);
            this.grpSelectedInspItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspItem)).EndInit();
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
        
        #region " Constant Definition"
        
        private const int COL_INSP_ITEM = 0;
        private const int COL_INSP_ITEM_DESC = 1;
        private const int COL_INSP_METHOD = 2;
        private const int COL_SMP_PROC = 3;
        private const int COL_SMP_PROC_TYPE = 4;
        private const int COL_SMP_PROC_RATE = 5;
        private const int COL_FIX_SMP_QTY = 6;
        private const int COL_SMP_PROC_UNIT = 7;
        private const int COL_DET_VALUE = 8;
        private const int COL_DET_UNIT = 9;
        private const int COL_CHK_DET_FLAG = 10;
        private const int COL_SAMP_QTY = 11;
        private const int COL_TEST_QTY = 12;
        private const int COL_DEFECT_QTY = 13;
        private const int COL_DEFECT_CODE = 14;
        private const int COL_RESULT = 15;
        private const int COL_COMMENT = 16;
        private const int COL_TRAN_TIME = 17;
        private const int COL_USER = 18;
        private const int COL_DEFECT_GROUP = 19;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool bLoadFlag;
        private int iCurRow = - 1;
        private int iPreRow = - 1;
        
        public struct Defect
        {
            public string DefectCode;
            public double Qty;
        }
        
        public struct Defect_Tag
        {
            public double DefectQty;
            public Defect[] Defect;
        }
        
        private Defect_Tag[] DefectList;
        
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
        private void ClearData(char ProcStep)
        {
            
            try
            {
                switch (ProcStep)
                {
                    case '1':
                        
                        MPCF.FieldClear(this);
                        ctrlBatchInfo.ClearBatchInfo();
                        MPCF.ClearList(spdInspItem, true);
                        MPCF.ClearList(spdDefect, true);
                        spdDefect.Sheets[0].Rows.Count = 20;
                        break;
                    case '2':
                        
                        MPCF.FieldClear(this, txtBatchID, null, null, null, null, false);
                        ctrlBatchInfo.ClearBatchInfo();
                        MPCF.ClearList(spdInspItem, true);
                        MPCF.ClearList(spdDefect, true);
                        spdDefect.Sheets[0].Rows.Count = 20;
                        MPCF.InitListView(lisItem);
                        if (ctrlBatchInfo.ViewBatchInformation(txtBatchID.Text, "") == false)
                        {
                            return;
                        }
                        if (MPCF.Trim(ctrlBatchInfo.InspSet) != "" && MPCF.ToInt(ctrlBatchInfo.InspSetVersion) > 0)
                        {
                            View_Attach_Insp_Item_List_Detail(txtBatchID.Text, ctrlBatchInfo.InspSet, MPCF.ToInt(ctrlBatchInfo.InspSetVersion));
                        }
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
            try
            {
                
                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];

                switch (MPCF.Trim(FuncName))
                {
                    case "REQUEST_REINSPECTION":

                        if (MPCF.CheckValue(txtBatchID, 1) == false)
                        {
                            return false;
                        }

                        //Modify by J.S. 2009.04.10 finnal dicision reject¿Ã æ∆¥“ ∞ÊøÏ¥¬ ∏¯«œ∞‘ µ«æÓ ¿÷¿Ω.
                        //ªË¡¶ º≠πˆø°º≠ √º≈©
                        //if (ctrlBatchInfo.FinalDecision != MPGC.MP_QCM_DECISION_REJECT)
                        //{
                        //    MPCF.ShowMsgBox(MPCF.GetMessage(217));
                        //    txtBatchID.Focus();
                        //    return false;
                        //}
                        
                        //CMF Validation
                        if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                        {
                            tabTran.SelectedTab = tbpCMF;
                            return false;
                        }
                        break;
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        //Private Function GetBatchItemCount() As String
        
        //    Dim sItemCount As String = ""
        
        //    Try
        //        sItemCount = RTrim(spdBatchInfo.Sheets(0).Cells(6, 5).Text)
        //    Catch ex As Exception
        //        ShowMsgBox(ex.Message)
        //    End Try
        
        //    Return sItemCount
        
        //End Function
        
        //Private Function GetBatchInspMethod() As String
        
        //    Dim sInspMethod As String = ""
        
        //    Try
        //        sInspMethod = RTrim(spdBatchInfo.Sheets(0).Cells(1, 5).Text)
        //    Catch ex As Exception
        //        ShowMsgBox(ex.Message)
        //    End Try
        
        //    Return sInspMethod
        
        //End Function
        
        //Private Function GetBatchHistSeq() As String
        
        //    Dim sHistSeq As String = ""
        
        //    Try
        //        sHistSeq = RTrim(spdBatchInfo.Sheets(0).Cells(0, 3).Text)
        //    Catch ex As Exception
        //        ShowMsgBox(ex.Message)
        //    End Try
        
        //    Return sHistSeq
        
        //End Function
        
        //Private Function GetBatchInspSet() As String
        
        //    Dim sInspSet As String = ""
        
        //    Try
        //        sInspSet = RTrim(spdBatchInfo.Sheets(0).Cells(2, 1).Text)
        //    Catch ex As Exception
        //        ShowMsgBox(ex.Message)
        //    End Try
        
        //    Return sInspSet
        
        //End Function
        
        //Private Function GetBatchInspSetVersion() As String
        
        //    Dim sInspSetVersion As String = ""
        
        //    Try
        //        sInspSetVersion = RTrim(spdBatchInfo.Sheets(0).Cells(2, 3).Text)
        //    Catch ex As Exception
        //        ShowMsgBox(ex.Message)
        //    End Try
        
        //    Return sInspSetVersion
        
        //End Function
        
        //Protected Function GetBatchQty1() As String
        
        //    Dim sQty1 As String = ""
        
        //    Try
        //        sQty1 = RTrim(spdBatchInfo.Sheets(0).Cells(2, 5).Text)
        //        If sQty1 <> "" Then
        //            sQty1 = sQty1.Substring(0, sQty1.IndexOf("/"))
        //        End If
        //    Catch ex As Exception
        //        ShowMsgBox(ex.Message)
        //    End Try
        
        //    Return sQty1
        
        //End Function
        
        //Private Sub ctrlbatchinfo.ClearBatchInfo
        
        //    'Initilize spdBatchinfo
        //    spdBatchInfo.Sheets(0).Cells(0, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(0, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(0, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(1, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(1, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(1, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(2, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(2, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(2, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(3, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(3, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(3, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(4, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(4, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(4, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(5, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(5, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(5, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(6, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(6, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(6, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(7, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(7, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(7, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(8, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(8, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(8, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(9, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(9, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(9, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(10, 1).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(10, 3).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(10, 5).Text = ""
        //    spdBatchInfo.Sheets(0).Cells(11, 1).Text = ""
        
        //End Sub
        //'
        //' View_Batch_Info()
        //'       - View Batch Information
        //' Return Value
        //'       - Boolean : True or False
        //' Arguments
        //'       -
        //'
        //Private Function View_Batch_Info() As Boolean
        
        //    Dim View_Batch_Info_In As QCM_View_Batch_Info_In_Tag
        //    Dim View_Batch_Info_Out As QCM_View_Batch_Info_Out_Tag
        //    Dim i As Integer
        
        //    Try
        
        //        'Init Spread
        //        ctrlbatchinfo.ClearBatchInfo
        
        //        InitListView(lisItem)
        
        //        View_Batch_Info_In.h_passport = gsPassport
        //        View_Batch_Info_In.h_language = gcLanguage
        //        View_Batch_Info_In.h_factory = gsFactory
        //        View_Batch_Info_In.h_user_id = gsUserID
        //        View_Batch_Info_In.h_password = gsPassword
        //        View_Batch_Info_In.h_proc_step = '1'
        //        View_Batch_Info_In.batch_id = RTrim(txtBatchID.Text)
        
        //        If QCMCaster.QCM_View_Batch_Info(View_Batch_Info_In, View_Batch_Info_Out) <> H101_SUCCESS Then
        //            ShowMsgBox(getH101Result().message)
        //            Return False
        //        End If
        //        If (View_Batch_Info_Out.h_status_value <> MP_SUCCESS_STATUS) Then
        //            ShowMsgBox(MakeErrorMsg(View_Batch_Info_Out.h_msg_code, View_Batch_Info_Out.h_msg, View_Batch_Info_Out.h_db_err_msg, View_Batch_Info_Out.h_field_msg))
        //            Return False
        //        End If
        
        //        If RTrim(View_Batch_Info_Out.skip_result_record) = "Y" Then
        //            ShowMsgBox("This Batch must skip the result recording")
        //            Return False
        //        End If
        
        //        With spdBatchInfo.Sheets(0)
        
        //            .SetValue(0, 1, Trim(txtBatchID.Text))
        //            .SetValue(0, 3, RTrim(View_Batch_Info_Out.last_hist_seq))
        //            .SetValue(0, 5, RTrim(View_Batch_Info_Out.mat_id) & " : " & RTrim(View_Batch_Info_Out.mat_desc))
        
        //            .SetValue(1, 1, RTrim(View_Batch_Info_Out.insp_step))
        //            .SetValue(1, 3, RTrim(View_Batch_Info_Out.insp_type))
        //            .SetValue(1, 5, RTrim(View_Batch_Info_Out.insp_method))
        
        //            .SetValue(2, 1, RTrim(View_Batch_Info_Out.insp_set_id))
        //            .SetValue(2, 3, RTrim(View_Batch_Info_Out.insp_set_version))
        //            .SetValue(2, 5, RTrim(View_Batch_Info_Out.qty_1) & "/" & RTrim(View_Batch_Info_Out.qty_2) & "/" & RTrim(View_Batch_Info_Out.qty_3))
        
        //            .SetValue(3, 1, RTrim(View_Batch_Info_Out.batch_status))
        //            .SetValue(3, 3, RTrim(View_Batch_Info_Out.total_insp))
        //            .SetValue(3, 5, RTrim(View_Batch_Info_Out.skip_result_record))
        
        //            .SetValue(4, 1, RTrim(View_Batch_Info_Out.po))
        //            .SetValue(4, 3, RTrim(View_Batch_Info_Out.po_item))
        //            .SetValue(4, 5, RTrim(View_Batch_Info_Out.invoice))
        
        //            .SetValue(5, 1, RTrim(View_Batch_Info_Out.box_id))
        //            .SetValue(5, 3, RTrim(View_Batch_Info_Out.vendor))
        //            .SetValue(5, 5, RTrim(View_Batch_Info_Out.ret_dlv_id))
        
        //            .SetValue(6, 1, RTrim(View_Batch_Info_Out.order_id))
        //            .SetValue(6, 3, RTrim(View_Batch_Info_Out.customer))
        //            .SetValue(6, 5, RTrim(View_Batch_Info_Out.item_count))
        
        //            .SetValue(7, 1, RTrim(View_Batch_Info_Out.auto_final))
        //            .SetValue(7, 3, RTrim(View_Batch_Info_Out.Request_Reinspection))
        //            .SetValue(7, 5, RTrim(View_Batch_Info_Out.bat_cmf_1))
        
        //            .SetValue(8, 1, RTrim(View_Batch_Info_Out.bat_cmf_2))
        //            .SetValue(8, 3, RTrim(View_Batch_Info_Out.bat_cmf_3))
        //            .SetValue(8, 5, RTrim(View_Batch_Info_Out.bat_cmf_4))
        
        //            .SetValue(9, 1, RTrim(View_Batch_Info_Out.bat_cmf_5))
        //            .SetValue(9, 3, RTrim(View_Batch_Info_Out.bat_cmf_6))
        //            .SetValue(9, 5, RTrim(View_Batch_Info_Out.bat_cmf_7))
        
        //            .SetValue(10, 1, RTrim(View_Batch_Info_Out.bat_cmf_8))
        //            .SetValue(10, 3, RTrim(View_Batch_Info_Out.bat_cmf_9))
        //            .SetValue(10, 5, RTrim(View_Batch_Info_Out.bat_cmf_10))
        
        //            .SetValue(11, 1, RTrim(View_Batch_Info_Out.comment))
        
        //        End With
        
        //        Return True
        //    Catch ex As Exception
        //        ShowMsgBox(ex.Message)
        //        Return False
        //    End Try
        
        //    Return True
        
        //End Function
        
        private bool View_Batch_Item_List(string sInspItem)
        {
            TRSNode in_node = new TRSNode("VIEW_BATCH_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_ITEM_LIST_OUT");

            ListViewItem itmX;
            int i;
            
            try
            {
                
                MPCF.InitListView(lisItem);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddString("INSP_SET_ID", ctrlBatchInfo.InspSet);
                in_node.AddInt("INSP_SET_VERSION", MPCF.ToInt(ctrlBatchInfo.InspSetVersion));
                in_node.AddString("INSP_ITEM", sInspItem);
                in_node.AddString("NEXT_ITEM_ID", "");

                //Add by J.S. 2011.12.16 missing?
                in_node.AddInt("BATCH_HIST_SEQ", MPCF.ToInt(ctrlBatchInfo.HistSeq));
                
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
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetChar("RESULT_FLAG").ToString());
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("DEFECT_CODE"));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ISP_COMMENT"));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ITEM_STATUS"));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetString("USER_ID"));
                        
                        lisItem.Items.Add(itmX);
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
        
        
        private bool View_Attach_Insp_Item_List_Detail(string sBatchId, string sInsptSet, int iInspSetVer)
        {
            TRSNode in_node = new TRSNode("VIEW_ATTACH_INSP_ITEM_LIST_DETAIL_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_INSP_ITEM_LIST_DETAIL_OUT");

            int i;
            int j;
            int iCount;
            int iDefectCount;
            int LastRow = 0;
            
            try
            {
                //InitListView(lisInspItem)
                spdInspItem.Sheets[0].Rows.Count = 0;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("BATCH_ID", MPCF.Trim(sBatchId));
                in_node.AddString("INSP_SET_ID", MPCF.Trim(sInsptSet));
                in_node.AddInt("INSP_SET_VERSION", iInspSetVer);
                in_node.AddInt("NEXT_SEQ_NUM", 0);
                
                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Attach_Insp_Item_List_Detail", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    iCount = out_node.GetList(0).Count;
                    DefectList = new Defect_Tag[iCount-1 + 1];
                    spdInspItem.Sheets[0].Rows.Count = iCount;
                    
                    for (i = 0; i <= iCount - 1; i++)
                    {
                        FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];
                        
                        with_1.SetValue(LastRow, COL_INSP_ITEM, out_node.GetList(0)[i].GetString("INSP_ITEM"));
                        with_1.SetValue(LastRow, COL_INSP_ITEM_DESC, out_node.GetList(0)[i].GetString("INSP_ITEM_DESC"));
                        with_1.SetValue(LastRow, COL_INSP_METHOD, out_node.GetList(0)[i].GetString("INSP_METHOD"));
                        with_1.SetValue(LastRow, COL_SMP_PROC, out_node.GetList(0)[i].GetString("SAMPLE_PROC"));
                        with_1.SetValue(LastRow, COL_SMP_PROC_TYPE, out_node.GetList(0)[i].GetString("SAMPLE_PROC_TYPE"));
                        with_1.SetValue(LastRow, COL_SMP_PROC_RATE, (out_node.GetList(0)[i].GetInt("SAMPLE_RATE") + "%"));
                        with_1.SetValue(LastRow, COL_FIX_SMP_QTY, (out_node.GetList(0)[i].GetDouble("FIX_SAMPLE_QTY")));
                        with_1.SetValue(LastRow, COL_SMP_PROC_UNIT, out_node.GetList(0)[i].GetString("SAMPLE_UNIT"));
                        with_1.SetValue(LastRow, COL_DET_VALUE, (out_node.GetList(0)[i].GetDouble("DETERMINE_VALUE")));
                        with_1.SetValue(LastRow, COL_DET_UNIT, out_node.GetList(0)[i].GetString("DETERMINE_UNIT"));
                        with_1.SetValue(LastRow, COL_CHK_DET_FLAG, out_node.GetList(0)[i].GetString("CHECK_DETERMINE_FLAG"));
                        with_1.SetValue(LastRow, COL_SAMP_QTY, (out_node.GetList(0)[i].GetDouble("SAMPLE_QTY")));
                        with_1.SetValue(LastRow, COL_TEST_QTY, (out_node.GetList(0)[i].GetDouble("TEST_QTY")));
                        with_1.SetValue(LastRow, COL_DEFECT_QTY, (out_node.GetList(0)[i].GetDouble("DEFECT_QTY")));

                        if (out_node.GetList(0)[i].GetChar("RESULT_FLAG") == 'P')
                        {
                            with_1.SetValue(LastRow, COL_RESULT, "PASS");
                        }
                        else if (out_node.GetList(0)[i].GetChar("RESULT_FLAG") == 'F')
                        {
                            with_1.SetValue(LastRow, COL_RESULT, "FAIL");
                        }
                        else
                        {
                            with_1.SetValue(LastRow, COL_RESULT, " ");
                        }

                        with_1.SetValue(LastRow, COL_COMMENT, (out_node.GetList(0)[i].GetString("ISP_COMMENT")));
                        with_1.SetValue(LastRow, COL_TRAN_TIME, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        with_1.SetValue(LastRow, COL_USER, out_node.GetList(0)[i].GetString("USER_ID"));
                        with_1.SetValue(LastRow, COL_DEFECT_GROUP, out_node.GetList(0)[i].GetString("DEFECT_GRP"));
                        
                        DefectList[i].DefectQty = out_node.GetList(0)[i].GetDouble("DEFECT_QTY");
                        iDefectCount = out_node.GetList(0)[i].GetList(0).Count;
                        
                        if (iDefectCount > 0)
                        {
                            with_1.SetValue(LastRow, COL_DEFECT_CODE, "V");

                            DefectList[i].Defect = new Defect[iDefectCount];
                            
                            for (j = 0; j <= iDefectCount - 1; j++)
                            {
                                DefectList[i].Defect[j] = new Defect();
                                DefectList[i].Defect[j].DefectCode = out_node.GetList(0)[i].GetList(0)[j].GetString("DEFECT_CODE");
                                DefectList[i].Defect[j].Qty = out_node.GetList(0)[i].GetList(0)[j].GetDouble("QTY_1");
                            }
                        }
                        
                        LastRow++;
                    }
                    
                    MPCF.FitColumnHeader(spdInspItem);
                    
                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

                } while (in_node.GetInt("NEXT_SEQ_NUM") > 0);
                
                Get_Defect_Code();
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        private void Get_Defect_Code()
        {
            
            int i;
            //            int j;
            //            int k;
            
            try
            {
                
                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];
                
                //Clear spdDefect
                for (i = 0; i <= spdDefect.Sheets[0].Rows.Count - 1; i++)
                {
                    spdDefect.Sheets[0].Cells[i, 0].Text = "";
                    spdDefect.Sheets[0].Cells[i, 1].Text = "";
                }
                
                //Get Current Defect Code List
                if (DefectList[iCurRow].DefectQty > 0)
                {
                    for (i = 0; i <= DefectList[iCurRow].Defect.Length - 1; i++)
                    {
                        spdDefect.Sheets[0].SetValue(i, 0, DefectList[iCurRow].Defect[i].DefectCode);
                        spdDefect.Sheets[0].SetValue(i, 1, DefectList[iCurRow].Defect[i].Qty);
                    }
                }
                
                
            }
            catch (Exception)
            {
            }
        }
        
        //
        // Request_Reinspection()
        //       - Result Record
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Request_Reinspection(char ProcStep)
        { 
            TRSNode in_node = new TRSNode("REQUEST_REINSPECTION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(ctrlBatchInfo.HistSeq));
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));

                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
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

                if (MPCR.CallService("QCM", "QCM_Request_Reinspection", in_node, ref out_node) == false)
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
        
        private void frmQCMTranRequestReinspection_Load(object sender, System.EventArgs e)
        {
            
            pnlTranTime.Visible = MPGO.UseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
        }
        
        private void frmQCMTranRequestReinspection_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (bLoadFlag == false)
                {
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_QCM_FINAL, "lblCMF", "cdvCMF", grpCMF);
                    ClearData('1');
                    
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
            
            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (txtBatchID.Text != "")
                    {
                        MPCF.InitListView(lisItem);
                        if (ctrlBatchInfo.ViewBatchInformation(txtBatchID.Text, "") == false)
                        {
                            return;
                        }
                        if (MPCF.Trim(ctrlBatchInfo.InspSet) != "" && MPCF.Trim(ctrlBatchInfo.InspSetVersion) != "")
                        {
                            View_Attach_Insp_Item_List_Detail(txtBatchID.Text, ctrlBatchInfo.InspSet, MPCF.ToInt(ctrlBatchInfo.InspSetVersion));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnHideDefect_Click(System.Object sender, System.EventArgs e)
        {
            
            //            int i;
            //            int j;
            //            int iSumDefect;
            
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];
                
                grpDefect.Size = new System.Drawing.Size(0, grpInspItem.Size.Height); //Width in Show : 250
                grpDefect.Visible = false;
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdInspItem_CellClick(System.Object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //int i;
            
            try
            {
                
                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];
                if (with_1.Rows.Count <= 0)
                {
                    return;
                }
                
                if (e.Row < 0)
                {
                    return;
                }
                
                iCurRow = e.Row;

                txtDefectInspItem.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_INSP_ITEM));
                
                if (e.Column == COL_DEFECT_CODE)
                {
                    grpDefect.Size = new System.Drawing.Size(250, grpInspItem.Size.Height);
                    grpDefect.Visible = true;
                }
                
                if (iPreRow == iCurRow)
                {
                    return;
                }
                
                if (MPCF.Trim(ctrlBatchInfo.InspMethod) != MPGC.MP_QCM_INSP_METHOD_Q)
                {
                    
                    MPCF.InitListView(lisItem);

                    txtSeq.Text = (iCurRow + 1).ToString();
                    cdvInspItem.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_INSP_ITEM));
                    txtResult.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_RESULT));
                    txtItemCount.Text = ctrlBatchInfo.ItemCount;
                    txtTestQty.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_TEST_QTY));
                    txtDefectQty.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_DEFECT_QTY));
                    if (cdvInspItem.Text != "")
                    {
                        View_Batch_Item_List(cdvInspItem.Text);
                    }
                }
                
                Get_Defect_Code();
                
                iPreRow = iCurRow;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvInspItem_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            int i;
            
            try
            {
                
                if (cdvInspItem.Text != "")
                {
                    for (i = 0; i <= spdInspItem.Sheets[0].Rows.Count - 1; i++)
                    {
                        if (cdvInspItem.Text == MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_INSP_ITEM)))
                        {
                            txtSeq.Text = (i + 1).ToString();
                            cdvInspItem.Text = MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_INSP_ITEM));
                            txtResult.Text = MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_RESULT));
                            txtItemCount.Text = ctrlBatchInfo.ItemCount;
                            txtTestQty.Text = MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_TEST_QTY));
                            txtDefectQty.Text = MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, COL_DEFECT_QTY));
                            break;
                        }
                    }
                    View_Batch_Item_List(cdvInspItem.Text);
                }
                
            }
            catch (Exception)
            {
                
            }
        }
        
        private void cdvInspItem_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInspItem.Init();
            MPCF.InitListView(cdvInspItem.GetListView);
            cdvInspItem.Columns.Add("Insp. Item", 50, HorizontalAlignment.Left);
            cdvInspItem.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvInspItem.SelectedSubItemIndex = 0;
            QCMLIST.ViewAttachInspectionItemList(cdvInspItem.GetListView, '1', ctrlBatchInfo.InspSet, MPCF.ToInt(ctrlBatchInfo.InspSetVersion), null, "");
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("REQUEST_REINSPECTION") == false)
                {
                    return;
                }
                
                if (Request_Reinspection('1') == false)
                {
                    return;
                }

                ClearData('2');
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        } 
    }
    //#End If
}
