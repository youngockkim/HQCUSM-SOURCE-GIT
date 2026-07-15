
using Miracom.CliFrx;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
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
//   File Name   : frmQCMTranResultRecording.vb
//   Description : Result Record Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Clear Form Control Data
//       - CheckCondition() : Check the conditions before transaction
//       - GetResourceIDList() :Get ResourceID List
//       - Result_Recording() : Result Record transaction
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
    public class frmQCMTranResultRecording : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMTranResultRecording()
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
        protected System.Windows.Forms.Panel pnlComment;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Panel pnlGeneralTop;
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
        private System.Windows.Forms.GroupBox grpBatInfo;
        private System.Windows.Forms.Panel pnlBatchInfoMain;
        private System.Windows.Forms.TabPage tbpItem;
        private System.Windows.Forms.Panel pnlInspItem;
        private System.Windows.Forms.GroupBox grpInspItem;
        private FarPoint.Win.Spread.FpSpread spdInspItem;
        private FarPoint.Win.Spread.SheetView spdInspItem_Sheet1;
        private System.Windows.Forms.GroupBox grpDefect;
        protected System.Windows.Forms.Panel pnlTranInfo;
        private System.Windows.Forms.Panel pnlDefectInspItem;
        private System.Windows.Forms.Panel pnlDefect;
        protected System.Windows.Forms.TextBox txtDefectInspItem;
        private System.Windows.Forms.Button btnHideDefect;
        private FarPoint.Win.Spread.FpSpread spdDefect;
        private FarPoint.Win.Spread.SheetView spdDefect_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDefect;
        private System.Windows.Forms.Panel pnlSelectedInspItem;
        private System.Windows.Forms.GroupBox grpSelectedInspItem;
        protected System.Windows.Forms.Label Label8;
        private System.Windows.Forms.TextBox txtSeq;
        protected System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtInspitem;
        protected System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtResult;
        protected System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TextBox txtDefectQty;
        protected System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtTestQty;
        protected System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtItemCount;
        protected System.Windows.Forms.TextBox txtItemID;
        protected System.Windows.Forms.Label Label6;
        protected System.Windows.Forms.Label Label7;
        protected System.Windows.Forms.Label Label9;
        private System.Windows.Forms.ComboBox cboResult;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        protected System.Windows.Forms.TextBox txtItemComment;
        protected System.Windows.Forms.Label Label10;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvItemDefect;
        private GroupBox grpItemList;
        private Miracom.UI.Controls.MCListView.MCListView lisItem;
        private ColumnHeader ColumnHeader6;
        private ColumnHeader ColumnHeader7;
        private ColumnHeader ColumnHeader8;
        private ColumnHeader ColumnHeader12;
        private ColumnHeader columnHeader2;
        private ColumnHeader ColumnHeader1;
        private ColumnHeader ColumnHeader13;
        private ColumnHeader ColumnHeader14;
        private ColumnHeader ColumnHeader15;
        private Miracom.UI.Controls.MCListView.MCListView lisItemDefect;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
        private Miracom.QCMCore.udcQCMBatchInfo ctrlBatchInfo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
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
            this.grpItemList = new System.Windows.Forms.GroupBox();
            this.lisItem = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisItemDefect = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSelectedInspItem = new System.Windows.Forms.Panel();
            this.grpSelectedInspItem = new System.Windows.Forms.GroupBox();
            this.cdvItemDefect = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtItemComment = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.cboResult = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtDefectQty = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtTestQty = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtItemCount = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtInspitem = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
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
            this.cdvDefect = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
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
            this.grpItemList.SuspendLayout();
            this.pnlSelectedInspItem.SuspendLayout();
            this.grpSelectedInspItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvItemDefect)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefect)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMainMiddle);
            this.pnlCenter.Controls.Add(this.pnlMainTop);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Result Recording";
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
            this.pnlMainMiddle.Size = new System.Drawing.Size(742, 469);
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
            this.tabTran.Size = new System.Drawing.Size(736, 461);
            this.tabTran.TabIndex = 0;
            this.tabTran.TabIndexChanged += new System.EventHandler(this.tabTran_TabIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGeneralMiddle);
            this.tbpGeneral.Controls.Add(this.pnlGeneralTop);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Size = new System.Drawing.Size(728, 435);
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
            this.pnlGeneralMiddle.Size = new System.Drawing.Size(728, 289);
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
            this.pnlTranInfo.Size = new System.Drawing.Size(728, 249);
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
            this.pnlInspItem.Size = new System.Drawing.Size(722, 249);
            this.pnlInspItem.TabIndex = 7;
            // 
            // grpInspItem
            // 
            this.grpInspItem.Controls.Add(this.spdInspItem);
            this.grpInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInspItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInspItem.Location = new System.Drawing.Point(0, 0);
            this.grpInspItem.Name = "grpInspItem";
            this.grpInspItem.Size = new System.Drawing.Size(722, 249);
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
            this.spdInspItem.HorizontalScrollBar.TabIndex = 0;
            this.spdInspItem.Location = new System.Drawing.Point(3, 16);
            this.spdInspItem.Name = "spdInspItem";
            this.spdInspItem.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdInspItem.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdInspItem.SelectionBlockOptions = ((FarPoint.Win.Spread.SelectionBlockOptions)((FarPoint.Win.Spread.SelectionBlockOptions.Cells | FarPoint.Win.Spread.SelectionBlockOptions.Rows)));
            this.spdInspItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdInspItem_Sheet1});
            this.spdInspItem.Size = new System.Drawing.Size(716, 230);
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
            this.spdInspItem.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdInspItem_EditChange);
            this.spdInspItem.SetViewportLeftColumn(0, 0, 3);
            this.spdInspItem.SetActiveViewport(0, 0, -1);
            // 
            // spdInspItem_Sheet1
            // 
            this.spdInspItem_Sheet1.Reset();
            spdInspItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdInspItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdInspItem_Sheet1.ColumnCount = 23;
            spdInspItem_Sheet1.RowCount = 3;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Insp. Item";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Inspection Method";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Sampling Proc.";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Samp. Proc. Type";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Samp. Proc. Rate";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Fix Samp. Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Samp. Proc. Unit";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Determine Value";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Determine Unit";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Check Determine Flag";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Samp. Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Test Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Defect Qty";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 15).ColumnSpan = 2;
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Defect Code";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Result";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Comment";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Tran Time";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "User";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Defect Group";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Value Flag";
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdInspItem_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdInspItem_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdInspItem_Sheet1.Columns.Get(0).Resizable = false;
            this.spdInspItem_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(0).Width = 23F;
            this.spdInspItem_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(1).Label = "Insp. Item";
            this.spdInspItem_Sheet1.Columns.Get(1).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(1).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(2).Label = "Description";
            this.spdInspItem_Sheet1.Columns.Get(2).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(2).Width = 100F;
            this.spdInspItem_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(3).Label = "Inspection Method";
            this.spdInspItem_Sheet1.Columns.Get(3).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(3).Width = 121F;
            this.spdInspItem_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(4).Label = "Sampling Proc.";
            this.spdInspItem_Sheet1.Columns.Get(4).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(4).Width = 130F;
            this.spdInspItem_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(5).Label = "Samp. Proc. Type";
            this.spdInspItem_Sheet1.Columns.Get(5).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(5).Width = 97F;
            this.spdInspItem_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(6).Label = "Samp. Proc. Rate";
            this.spdInspItem_Sheet1.Columns.Get(6).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(6).Width = 97F;
            this.spdInspItem_Sheet1.Columns.Get(7).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(7).CellType = numberCellType1;
            this.spdInspItem_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(7).Label = "Fix Samp. Qty";
            this.spdInspItem_Sheet1.Columns.Get(7).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(7).Width = 107F;
            this.spdInspItem_Sheet1.Columns.Get(8).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(8).Label = "Samp. Proc. Unit";
            this.spdInspItem_Sheet1.Columns.Get(8).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(8).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(8).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(9).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(9).Label = "Determine Value";
            this.spdInspItem_Sheet1.Columns.Get(9).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(9).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(9).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(10).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(10).Label = "Determine Unit";
            this.spdInspItem_Sheet1.Columns.Get(10).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(10).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(10).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(11).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(11).Label = "Check Determine Flag";
            this.spdInspItem_Sheet1.Columns.Get(11).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(11).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(11).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(12).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(12).CellType = numberCellType2;
            this.spdInspItem_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(12).Label = "Samp. Qty";
            this.spdInspItem_Sheet1.Columns.Get(12).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(12).Width = 80F;
            numberCellType3.MinimumValue = 0D;
            this.spdInspItem_Sheet1.Columns.Get(13).CellType = numberCellType3;
            this.spdInspItem_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(13).Label = "Test Qty";
            this.spdInspItem_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(13).Width = 80F;
            numberCellType4.MinimumValue = 0D;
            this.spdInspItem_Sheet1.Columns.Get(14).CellType = numberCellType4;
            this.spdInspItem_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdInspItem_Sheet1.Columns.Get(14).Label = "Defect Qty";
            this.spdInspItem_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(14).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(15).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(15).Label = "Defect Code";
            this.spdInspItem_Sheet1.Columns.Get(15).Locked = false;
            this.spdInspItem_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdInspItem_Sheet1.Columns.Get(16).CellType = buttonCellType1;
            this.spdInspItem_Sheet1.Columns.Get(16).Locked = false;
            this.spdInspItem_Sheet1.Columns.Get(16).Width = 20F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.Items = new string[] {
        "FAIL",
        "PASS"};
            this.spdInspItem_Sheet1.Columns.Get(17).CellType = comboBoxCellType1;
            this.spdInspItem_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(17).Label = "Result";
            this.spdInspItem_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(18).Label = "Comment";
            this.spdInspItem_Sheet1.Columns.Get(18).Width = 213F;
            this.spdInspItem_Sheet1.Columns.Get(19).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(19).Label = "Tran Time";
            this.spdInspItem_Sheet1.Columns.Get(19).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(19).Width = 131F;
            this.spdInspItem_Sheet1.Columns.Get(20).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(20).Label = "User";
            this.spdInspItem_Sheet1.Columns.Get(20).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(20).Width = 122F;
            this.spdInspItem_Sheet1.Columns.Get(21).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdInspItem_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(21).Label = "Defect Group";
            this.spdInspItem_Sheet1.Columns.Get(21).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(21).Resizable = false;
            this.spdInspItem_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(21).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(21).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(22).Label = "Value Flag";
            this.spdInspItem_Sheet1.Columns.Get(22).Visible = false;
            this.spdInspItem_Sheet1.FrozenColumnCount = 3;
            this.spdInspItem_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdInspItem_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdInspItem_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdInspItem_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdInspItem_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
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
            this.grpDefect.Size = new System.Drawing.Size(0, 249);
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
            this.pnlDefect.Size = new System.Drawing.Size(0, 186);
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
            this.spdDefect.Size = new System.Drawing.Size(0, 180);
            this.spdDefect.TabIndex = 7;
            this.spdDefect.TabStop = false;
            this.spdDefect.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdDefect_ButtonClicked);
            this.spdDefect.SetViewportLeftColumn(0, 0, 3);
            this.spdDefect.SetActiveViewport(0, 0, -1);
            // 
            // spdDefect_Sheet1
            // 
            this.spdDefect_Sheet1.Reset();
            spdDefect_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdDefect_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdDefect_Sheet1.ColumnCount = 3;
            spdDefect_Sheet1.RowCount = 10;
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
            numberCellType5.DecimalPlaces = 0;
            numberCellType5.MinimumValue = 0D;
            this.spdDefect_Sheet1.Columns.Get(2).CellType = numberCellType5;
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
            this.pnlComment.Location = new System.Drawing.Point(0, 249);
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
            this.tbpItem.Controls.Add(this.grpItemList);
            this.tbpItem.Controls.Add(this.pnlSelectedInspItem);
            this.tbpItem.Location = new System.Drawing.Point(4, 22);
            this.tbpItem.Name = "tbpItem";
            this.tbpItem.Padding = new System.Windows.Forms.Padding(3);
            this.tbpItem.Size = new System.Drawing.Size(728, 435);
            this.tbpItem.TabIndex = 2;
            this.tbpItem.Text = "Item Information";
            // 
            // grpItemList
            // 
            this.grpItemList.Controls.Add(this.lisItem);
            this.grpItemList.Controls.Add(this.lisItemDefect);
            this.grpItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItemList.Location = new System.Drawing.Point(3, 132);
            this.grpItemList.Name = "grpItemList";
            this.grpItemList.Size = new System.Drawing.Size(722, 300);
            this.grpItemList.TabIndex = 1;
            this.grpItemList.TabStop = false;
            // 
            // lisItem
            // 
            this.lisItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader12,
            this.columnHeader2,
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
            this.lisItem.Location = new System.Drawing.Point(3, 16);
            this.lisItem.Name = "lisItem";
            this.lisItem.Size = new System.Drawing.Size(545, 281);
            this.lisItem.TabIndex = 6;
            this.lisItem.UseCompatibleStateImageBehavior = false;
            this.lisItem.View = System.Windows.Forms.View.Details;
            this.lisItem.SelectedIndexChanged += new System.EventHandler(this.lisItem_SelectedIndexChanged);
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
            // columnHeader2
            // 
            this.columnHeader2.Text = "Defect Qty";
            this.columnHeader2.Width = 69;
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
            // lisItemDefect
            // 
            this.lisItemDefect.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader21,
            this.columnHeader22});
            this.lisItemDefect.Dock = System.Windows.Forms.DockStyle.Right;
            this.lisItemDefect.EnableSort = true;
            this.lisItemDefect.EnableSortIcon = true;
            this.lisItemDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisItemDefect.FullRowSelect = true;
            this.lisItemDefect.GridLines = true;
            this.lisItemDefect.Location = new System.Drawing.Point(548, 16);
            this.lisItemDefect.Name = "lisItemDefect";
            this.lisItemDefect.Size = new System.Drawing.Size(171, 281);
            this.lisItemDefect.TabIndex = 5;
            this.lisItemDefect.UseCompatibleStateImageBehavior = false;
            this.lisItemDefect.View = System.Windows.Forms.View.Details;
            this.lisItemDefect.SelectedIndexChanged += new System.EventHandler(this.lisItemDefect_SelectedIndexChanged);
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Defect";
            this.columnHeader21.Width = 111;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Qty";
            this.columnHeader22.Width = 55;
            // 
            // pnlSelectedInspItem
            // 
            this.pnlSelectedInspItem.Controls.Add(this.grpSelectedInspItem);
            this.pnlSelectedInspItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectedInspItem.Location = new System.Drawing.Point(3, 3);
            this.pnlSelectedInspItem.Name = "pnlSelectedInspItem";
            this.pnlSelectedInspItem.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlSelectedInspItem.Size = new System.Drawing.Size(722, 129);
            this.pnlSelectedInspItem.TabIndex = 0;
            // 
            // grpSelectedInspItem
            // 
            this.grpSelectedInspItem.Controls.Add(this.cdvItemDefect);
            this.grpSelectedInspItem.Controls.Add(this.txtItemComment);
            this.grpSelectedInspItem.Controls.Add(this.Label10);
            this.grpSelectedInspItem.Controls.Add(this.btnInsert);
            this.grpSelectedInspItem.Controls.Add(this.cboResult);
            this.grpSelectedInspItem.Controls.Add(this.Label9);
            this.grpSelectedInspItem.Controls.Add(this.Label7);
            this.grpSelectedInspItem.Controls.Add(this.txtItemID);
            this.grpSelectedInspItem.Controls.Add(this.Label6);
            this.grpSelectedInspItem.Controls.Add(this.Label3);
            this.grpSelectedInspItem.Controls.Add(this.txtDefectQty);
            this.grpSelectedInspItem.Controls.Add(this.Label4);
            this.grpSelectedInspItem.Controls.Add(this.txtTestQty);
            this.grpSelectedInspItem.Controls.Add(this.Label5);
            this.grpSelectedInspItem.Controls.Add(this.txtItemCount);
            this.grpSelectedInspItem.Controls.Add(this.Label2);
            this.grpSelectedInspItem.Controls.Add(this.txtResult);
            this.grpSelectedInspItem.Controls.Add(this.Label1);
            this.grpSelectedInspItem.Controls.Add(this.txtInspitem);
            this.grpSelectedInspItem.Controls.Add(this.Label8);
            this.grpSelectedInspItem.Controls.Add(this.txtSeq);
            this.grpSelectedInspItem.Controls.Add(this.btnDelete);
            this.grpSelectedInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSelectedInspItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSelectedInspItem.Location = new System.Drawing.Point(0, 0);
            this.grpSelectedInspItem.Name = "grpSelectedInspItem";
            this.grpSelectedInspItem.Size = new System.Drawing.Size(722, 126);
            this.grpSelectedInspItem.TabIndex = 0;
            this.grpSelectedInspItem.TabStop = false;
            this.grpSelectedInspItem.Text = "Selected Insp. Item";
            // 
            // cdvItemDefect
            // 
            this.cdvItemDefect.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvItemDefect.BorderHotColor = System.Drawing.Color.Black;
            this.cdvItemDefect.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvItemDefect.BtnToolTipText = "";
            this.cdvItemDefect.DescText = "";
            this.cdvItemDefect.DisplaySubItemIndex = -1;
            this.cdvItemDefect.DisplayText = "";
            this.cdvItemDefect.Enabled = false;
            this.cdvItemDefect.Focusing = null;
            this.cdvItemDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvItemDefect.Index = 0;
            this.cdvItemDefect.IsViewBtnImage = false;
            this.cdvItemDefect.Location = new System.Drawing.Point(614, 69);
            this.cdvItemDefect.MaxLength = 30;
            this.cdvItemDefect.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvItemDefect.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvItemDefect.Name = "cdvItemDefect";
            this.cdvItemDefect.ReadOnly = false;
            this.cdvItemDefect.SearchSubItemIndex = 0;
            this.cdvItemDefect.SelectedDescIndex = -1;
            this.cdvItemDefect.SelectedSubItemIndex = -1;
            this.cdvItemDefect.SelectionStart = 0;
            this.cdvItemDefect.Size = new System.Drawing.Size(100, 20);
            this.cdvItemDefect.SmallImageList = null;
            this.cdvItemDefect.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvItemDefect.TabIndex = 60;
            this.cdvItemDefect.TextBoxToolTipText = "";
            this.cdvItemDefect.TextBoxWidth = 100;
            this.cdvItemDefect.VisibleButton = true;
            this.cdvItemDefect.VisibleColumnHeader = false;
            this.cdvItemDefect.VisibleDescription = false;
            this.cdvItemDefect.ButtonPress += new System.EventHandler(this.cdvItemDefect_ButtonPress);
            // 
            // txtItemComment
            // 
            this.txtItemComment.Location = new System.Drawing.Point(120, 94);
            this.txtItemComment.MaxLength = 400;
            this.txtItemComment.Name = "txtItemComment";
            this.txtItemComment.Size = new System.Drawing.Size(352, 20);
            this.txtItemComment.TabIndex = 62;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.Location = new System.Drawing.Point(16, 96);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(51, 13);
            this.Label10.TabIndex = 61;
            this.Label10.Text = "Comment";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnInsert
            // 
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnInsert.Location = new System.Drawing.Point(510, 94);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 26);
            this.btnInsert.TabIndex = 63;
            this.btnInsert.Text = "Insert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // cboResult
            // 
            this.cboResult.Items.AddRange(new object[] {
            "PASS",
            "FAIL"});
            this.cboResult.Location = new System.Drawing.Point(372, 69);
            this.cboResult.Name = "cboResult";
            this.cboResult.Size = new System.Drawing.Size(100, 21);
            this.cboResult.TabIndex = 58;
            this.cboResult.SelectedValueChanged += new System.EventHandler(this.cboResult_SelectedValueChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(510, 72);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(67, 13);
            this.Label9.TabIndex = 59;
            this.Label9.Text = "Defect Code";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(268, 72);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(43, 13);
            this.Label7.TabIndex = 57;
            this.Label7.Text = "Result";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemID
            // 
            this.txtItemID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtItemID.Location = new System.Drawing.Point(120, 69);
            this.txtItemID.MaxLength = 30;
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(100, 20);
            this.txtItemID.TabIndex = 56;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(16, 72);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 13);
            this.Label6.TabIndex = 55;
            this.Label6.Text = "Item ID";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.txtDefectQty.MaxLength = 30;
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
            this.txtTestQty.MaxLength = 30;
            this.txtTestQty.Name = "txtTestQty";
            this.txtTestQty.ReadOnly = true;
            this.txtTestQty.Size = new System.Drawing.Size(100, 20);
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
            this.Label1.Location = new System.Drawing.Point(268, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(53, 13);
            this.Label1.TabIndex = 45;
            this.Label1.Text = "Insp. Item";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInspitem
            // 
            this.txtInspitem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInspitem.Location = new System.Drawing.Point(372, 19);
            this.txtInspitem.MaxLength = 25;
            this.txtInspitem.Name = "txtInspitem";
            this.txtInspitem.ReadOnly = true;
            this.txtInspitem.Size = new System.Drawing.Size(100, 20);
            this.txtInspitem.TabIndex = 46;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label8.Location = new System.Drawing.Point(16, 22);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(29, 13);
            this.Label8.TabIndex = 43;
            this.Label8.Text = "Seq.";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSeq
            // 
            this.txtSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeq.Location = new System.Drawing.Point(120, 19);
            this.txtSeq.MaxLength = 6;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.ReadOnly = true;
            this.txtSeq.Size = new System.Drawing.Size(100, 20);
            this.txtSeq.TabIndex = 44;
            this.txtSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Location = new System.Drawing.Point(614, 94);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 26);
            this.btnDelete.TabIndex = 64;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.pnlCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Size = new System.Drawing.Size(728, 435);
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
            this.pnlCMF.Size = new System.Drawing.Size(728, 435);
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
            this.grpCMF.Size = new System.Drawing.Size(722, 429);
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
            // cdvDefect
            // 
            this.cdvDefect.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvDefect.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefect.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvDefect.Location = new System.Drawing.Point(342, 17);
            this.cdvDefect.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefect.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefect.Name = "cdvDefect";
            this.cdvDefect.Size = new System.Drawing.Size(20, 20);
            this.cdvDefect.SmallImageList = null;
            this.cdvDefect.TabIndex = 0;
            this.cdvDefect.TabStop = false;
            this.cdvDefect.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDefect.Visible = false;
            this.cdvDefect.VisibleColumnHeader = false;
            this.cdvDefect.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvDefect_SelectedItemChanged);
            // 
            // frmQCMTranResultRecording
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmQCMTranResultRecording";
            this.Tag = "QCM2002";
            this.Text = "Result Recording";
            this.Activated += new System.EventHandler(this.frmQCMTranResultRecording_Activated);
            this.Load += new System.EventHandler(this.frmQCMTranResultRecording_Load);
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
            this.grpItemList.ResumeLayout(false);
            this.pnlSelectedInspItem.ResumeLayout(false);
            this.grpSelectedInspItem.ResumeLayout(false);
            this.grpSelectedInspItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvItemDefect)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefect)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition"
        
        private const int COL_SEL = 0;
        private const int COL_INSP_ITEM = 1;
        private const int COL_INSP_ITEM_DESC = 2;
        private const int COL_INSP_METHOD = 3;
        private const int COL_SMP_PROC = 4;
        private const int COL_SMP_PROC_TYPE = 5;
        private const int COL_SMP_PROC_RATE = 6;
        private const int COL_FIX_SMP_QTY = 7;
        private const int COL_SMP_PROC_UNIT = 8;
        private const int COL_DET_VALUE = 9;
        private const int COL_DET_UNIT = 10;
        private const int COL_CHK_DET_FLAG = 11;
        private const int COL_SMP_QTY = 12;
        private const int COL_TEST_QTY = 13;
        private const int COL_DEFECT_QTY = 14;
        private const int COL_DEFECT_CODE = 15;
        private const int COL_DEFECT_CMD = 16;
        private const int COL_RESULT = 17;
        private const int COL_COMMENT = 18;
        private const int COL_TRAN_TIME = 19;
        private const int COL_USER = 20;
        private const int COL_DEFECT_GROUP = 21;
        private const int COL_VALUE_FLAG = 22;
        
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
                        MPCF.InitListView(lisItemDefect);
                        if (ctrlBatchInfo.ViewBatchInformation(txtBatchID.Text, "RESULT") == false)
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
            
            int i;
            int iCount = 0;
            
            try
            {
                
                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];

                switch (MPCF.Trim(FuncName))
                {
                    case "RESULT_RECORDING":

                        if (MPCF.CheckValue(txtBatchID, 1) == false)
                        {
                            return false;
                        }
                        
                        for (i = 0; i <= with_1.Rows.Count - 1; i++)
                        {
                            
                            if (System.Convert.ToBoolean(with_1.GetValue(i, COL_SEL)) == true)
                            {
                                
                                iCount++;

                                if (MPCF.Trim(with_1.GetValue(i, COL_VALUE_FLAG)) == "Y")
                                {

                                    //Check Test Qty
                                    if (MPCF.ToDbl(with_1.GetValue(i, COL_TEST_QTY)) <= 0)
                                    {
                                        with_1.SetActiveCell(i, COL_TEST_QTY);
                                        MPCF.ShowMsgBox(MPCF.GetMessage(154));
                                        spdInspItem.Focus();
                                        return false;
                                    }

                                    //Check Defect Qty
                                    if (MPCF.ToDbl(with_1.GetValue(i, COL_DEFECT_QTY)) < 0)
                                    {
                                        with_1.SetActiveCell(i, COL_DEFECT_QTY);
                                        MPCF.ShowMsgBox(MPCF.GetMessage(154));
                                        spdInspItem.Focus();
                                        return false;
                                    }

                                    //Check Test, Defect Qty
                                    if (MPCF.ToDbl(with_1.GetValue(i, COL_TEST_QTY)) < MPCF.ToDbl(with_1.GetValue(i, COL_DEFECT_QTY)))
                                    {
                                        with_1.SetActiveCell(i, COL_DEFECT_QTY);
                                        MPCF.ShowMsgBox(MPCF.GetMessage(154));
                                        spdInspItem.Focus();
                                        return false;
                                    }

                                    //In Case Manual Type
                                    if (MPCF.Trim(with_1.GetValue(i, COL_SMP_PROC_TYPE)) == MPGC.MP_QCM_SMP_TYPE_MANUAL)
                                    {

                                        //Check Batch Qty, Test Qty
                                        if (MPCF.ToDbl(ctrlBatchInfo.Qty1) < MPCF.ToDbl(with_1.GetValue(i, COL_TEST_QTY)))
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(154));
                                            spdInspItem.Focus();
                                            return false;
                                        }
                                    }
                                }
                                
                                //Check Result Field
                                if (MPCF.Trim(with_1.GetValue(i, COL_RESULT)) == "")
                                {
                                    with_1.SetActiveCell(i, COL_RESULT);
                                    MPCF.ShowMsgBox(MPCF.GetMessage(154));
                                    spdInspItem.Focus();
                                    return false;
                                }                                
                                
                            }
                        }
                        
                        //CMF Validation
                        if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                        {
                            tabTran.SelectedTab = tbpCMF;
                            return false;
                        }
                        
                        if (iCount < 1)
                        {
                            return false;
                        }
                        break;
                        
                    case "RESULT_RECORDING_INDIVIDUAL":
                        
                        //Check Seq
                        if (MPCF.ToDbl(txtSeq.Text) <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(154));
                            txtSeq.Focus();
                            return false;
                        }
                        
                        //Check Insp Item
                        if (MPCF.CheckValue(txtInspitem, 1) == false)
                        {
                            return false;
                        }
                        
                        //Check Batch Item Id
                        if (MPCF.CheckValue(txtItemID, 1) == false)
                        {
                            return false;
                        }
                        
                        //Check Batch Item Result
                        if (MPCF.CheckValue(cboResult, 1) == false)
                        {
                            return false;
                        }
                        
                        if (cboResult.Text == "FAIL")
                        {
                            //Check Defect Code
                            if (MPCF.CheckValue(cdvItemDefect, 1) == false)
                            {
                                return false;
                            }

                            //Defect Qty
                            if (MPCF.ToDbl(txtDefectQty.Text) <= 0)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(154));
                                txtDefectQty.Focus();
                                return false;
                            }
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
        
        //
        // Result_Recording()
        //       - Result Record
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Result_Recording(char ProcStep)
        {
            
            int i;
            int j;
            int k;
            
            TRSNode in_node = new TRSNode("RESULT_RECORDING_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(ctrlBatchInfo.HistSeq));
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));

                if (chkTranDateTime.Checked == true)
                {
                    in_node.AddString("BACK_TIME", MPCF.ToStandardTime(dtpTranDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) + MPCF.ToStandardTime(dtpTranTime.Value, MPGC.MP_CONVERT_TIME_FORMAT));
                }

                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];

                k = 0;

                for (i = 0; i <= with_1.Rows.Count - 1; i++)
                {
                    if (System.Convert.ToBoolean(with_1.GetValue(i, 0)) == true)
                    {
                        TRSNode item_list = in_node.AddNode("ITEM_LIST");

                        item_list.AddInt("SEQ_NUM", i + 1);
                        item_list.AddString("INSP_ITEM", MPCF.Trim(with_1.GetValue(i, COL_INSP_ITEM)));
                        item_list.AddDouble("SAMPLE_QTY", MPCF.ToDbl(with_1.GetValue(i, COL_SMP_QTY)));
                        item_list.AddDouble("TEST_QTY", MPCF.ToDbl(with_1.GetValue(i, COL_TEST_QTY)));
                        item_list.AddChar("RESULT_FLAG", MPCF.ToChar(with_1.GetValue(i, COL_RESULT)));
                        item_list.AddDouble("DEFECT_QTY", MPCF.ToDbl(with_1.GetValue(i, COL_DEFECT_QTY)));
                        item_list.AddString("COMMENT", MPCF.Trim(with_1.GetValue(i, COL_COMMENT)));
                        if (MPCF.Trim(with_1.GetValue(i, COL_DEFECT_CODE)) == "V")
                        {
                            for (j = 0; j <= DefectList[i].Defect.Length - 1; j++)
                            {
                                if (MPCF.Trim(DefectList[i].Defect[j].DefectCode) != "")
                                {
                                    TRSNode defect_list = item_list.AddNode("DEFECT_LIST");
                                    defect_list.AddString("DEFECT_CODE", DefectList[i].Defect[j].DefectCode);
                                    defect_list.AddDouble("QTY", DefectList[i].Defect[j].Qty);
                                }
                                else
                                {
                                    break;
                                }
                            }           
                        }

                        k += 1;
                    }
                }

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


                if (MPCR.CallService("QCM", "QCM_Result_Recording", in_node, ref out_node) == false)
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
        
        //
        // Result_Recording_Individual()
        //       - Result Record Individual
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Result_Recording_Individual(char ProcStep)
        {
            TRSNode in_node = new TRSNode("RESULT_RECORDING_INDIVIDUAL_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(ctrlBatchInfo.HistSeq));
                in_node.AddString("ITEM_ID", MPCF.Trim(txtItemID.Text));
                in_node.AddInt("SEQ_NUM", MPCF.ToInt(MPCF.Trim(txtSeq.Text)));
                in_node.AddString("INSP_ITEM", MPCF.Trim(txtInspitem.Text));
                in_node.AddDouble("TEST_QTY", MPCF.Trim(txtTestQty.Text));

                if (cboResult.Text.Length > 0)
                    in_node.AddChar("RESULT_FLAG", MPCF.ToChar(cboResult.Text.Substring(0, 1)));
                if (cboResult.Text.Substring(0, 1) != "P")
                {
                    in_node.AddString("DEFECT_CODE", MPCF.Trim(cdvItemDefect.Text));
                    in_node.AddDouble("DEFECT_QTY", MPCF.Trim(txtDefectQty.Text));
                }
                in_node.AddString("COMMENT", MPCF.Trim(txtItemComment.Text));

                if (MPCR.CallService("QCM", "QCM_Result_Recording_Individual", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                
                View_Batch_Item_List(txtInspitem.Text);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        } 
        
        private bool View_Batch_Item_List(string sInspItem)
        {
            TRSNode in_node = new TRSNode("VIEW_BATCH_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BATCH_ITEM_LIST_OUT");

            ListViewItem itmX;
            int i;
            
            try
            {
                
                MPCF.InitListView(lisItem);
                MPCF.InitListView(lisItemDefect);

                MPCR.SetInMsg(in_node);
                //Modify by J.S. 2009.04.14 ¡¯«‡µ» ∞·∞˙ ∫∏ø© ¡÷±‚ step 2 -> 3
                in_node.ProcStep = '3';
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddInt("BATCH_HIST_SEQ", MPCF.ToInt(ctrlBatchInfo.HistSeq));
                in_node.AddString("INSP_ITEM", sInspItem);
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
                        if (out_node.GetList(0)[i].GetChar("RESULT_FLAG") == 'P')
                        {
                            itmX.SubItems.Add("PASS");
                        }
                        else if (out_node.GetList(0)[i].GetChar("RESULT_FLAG") == 'F')
                        {
                            itmX.SubItems.Add("FAIL");
                        }
                        else
                        {
                            itmX.SubItems.Add(" ");
                        }

                        itmX.SubItems.Add(out_node.GetList(0)[i].GetDouble("DEFECT_QTY").ToString());
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
            List<TRSNode> defect_list;
            
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
                        with_1.SetValue(LastRow, COL_SMP_PROC_RATE, (out_node.GetList(0)[i].GetInt("SAMPLE_RATE")));
                        with_1.SetValue(LastRow, COL_FIX_SMP_QTY, (out_node.GetList(0)[i].GetDouble("FIX_SAMPLE_QTY")));
                        with_1.SetValue(LastRow, COL_SMP_PROC_UNIT, out_node.GetList(0)[i].GetString("SAMPLE_UNIT"));
                        with_1.SetValue(LastRow, COL_DET_VALUE, (out_node.GetList(0)[i].GetDouble("DETERMINE_VALUE")));
                        with_1.SetValue(LastRow, COL_DET_UNIT, out_node.GetList(0)[i].GetString("DETERMINE_UNIT"));
                        with_1.SetValue(LastRow, COL_CHK_DET_FLAG, out_node.GetList(0)[i].GetString("CHECK_DETERMINE_FLAG"));
                        with_1.SetValue(LastRow, COL_SMP_QTY, (out_node.GetList(0)[i].GetDouble("SAMPLE_QTY")));
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
                        with_1.SetValue(LastRow, COL_DEFECT_GROUP, out_node.GetList(0)[i].GetString("DEFECT_GROUP"));
                        with_1.SetValue(LastRow, COL_VALUE_FLAG, out_node.GetList(0)[i].GetChar("VALUE_FLAG"));
                        
                        DefectList[i].DefectQty = out_node.GetList(0)[i].GetDouble("DEFECT_QTY");

                        //Modify by J.S. 2009.04.09 ¡ª ≥ π´«œ¥Ÿ.
                        defect_list = out_node.GetList(0)[i].GetList("DEFECT_LIST");
                        iDefectCount = defect_list.Count;
                        
                        if (iDefectCount > 0)
                        {
                            with_1.SetValue(LastRow, COL_DEFECT_CODE, "V");

                            DefectList[i].Defect = new Defect[iDefectCount];
                            
                            for (j = 0; j <= iDefectCount - 1; j++)
                            {
                                DefectList[i].Defect[j].DefectCode = defect_list[j].GetString("DEFECT_CODE");
                                DefectList[i].Defect[j].Qty = defect_list[j].GetDouble("QTY_1");
                            }
                        }
                        
                        if (out_node.GetList(0)[i].GetChar("RESULT_FLAG") != ' ')
                        {
                            with_1.Rows[LastRow].Locked = true;
                            with_1.Rows[LastRow].BackColor = Color.WhiteSmoke;
                        }
                        else
                        {
                            if (out_node.GetList(0)[i].GetString("INSP_METHOD") == MPGC.MP_QCM_INSP_METHOD_I || MPCF.Trim(ctrlBatchInfo.InspMethod) == MPGC.MP_QCM_INSP_METHOD_I)
                            {
                                with_1.Rows[LastRow].Locked = true;
                                with_1.Rows[LastRow].BackColor = Color.WhiteSmoke;
                                with_1.Cells[LastRow, COL_SEL].Locked = false;
                                with_1.Cells[LastRow, COL_RESULT].Locked = false;
                                with_1.Cells[LastRow, COL_COMMENT].Locked = false;
                                with_1.Cells[LastRow, COL_SEL].BackColor = Color.White;
                                with_1.Cells[LastRow, COL_RESULT].BackColor = Color.White;
                                with_1.Cells[LastRow, COL_COMMENT].BackColor = Color.White;
                            }

                            if (out_node.GetList(0)[i].GetString("SAMPLE_PROC_TYPE") == MPGC.MP_QCM_SMP_TYPE_MANUAL)
                            {
                                with_1.Cells[LastRow, COL_SMP_QTY].Locked = false;
                                with_1.Cells[LastRow, COL_SMP_QTY].BackColor = Color.White;
                            }
                        }
                        
                        with_1.Cells[LastRow, COL_DEFECT_CMD].Locked = false;
                        
                        LastRow++;
                    }
                    
                    MPCF.FitColumnHeader(spdInspItem); 
                    
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
        
        private void Get_Save_Defect_Code()
        {
            
            int i;
            int j;
            int k;
            bool bSameDefect = false;
            double dSumDefect = 0.0D;
            
            try
            {
                
                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];

                if (MPCF.Trim(with_1.GetValue(iCurRow, COL_USER)) == "")
                {
                    
                    for (i = COL_TEST_QTY; i <= COL_DEFECT_QTY; i++)
                    {
                        if (MPCF.Trim(with_1.GetValue(iCurRow, COL_INSP_METHOD)) == MPGC.MP_QCM_INSP_METHOD_I)
                        {
                            with_1.Cells[iCurRow, i].Locked = true;
                            with_1.Cells[iCurRow, i].BackColor = Color.WhiteSmoke;
                        }
                        else
                        {
                            with_1.Cells[iCurRow, i].Locked = false;
                            with_1.Cells[iCurRow, i].BackColor = Color.White;
                        }
                        
                        if (MPCF.Trim(ctrlBatchInfo.InspMethod) == MPGC.MP_QCM_INSP_METHOD_I)
                        {
                            with_1.Cells[iCurRow, i].Locked = true;
                            with_1.Cells[iCurRow, i].BackColor = Color.WhiteSmoke;
                        }
                        else
                        {
                            with_1.Cells[iCurRow, i].Locked = false;
                            with_1.Cells[iCurRow, i].BackColor = Color.White;
                        }
                    }
                    j = 0;
                    if (iPreRow >= 0)
                    {                        
                        //Save Old Defect Code List
                        DefectList[iPreRow].Defect = new Defect[spdDefect.Sheets[0].Rows.Count];

                        for (i = 0; i <= spdDefect.Sheets[0].Rows.Count - 1; i++)
                        {
                            if (MPCF.Trim(spdDefect.Sheets[0].GetValue(i, 0)) != "" && MPCF.ToDbl(spdDefect.Sheets[0].GetValue(i, 2)) > 0)
                            {
                                //Find Same Defect Code in Array
                                for (k = 0; k <= DefectList[iPreRow].Defect.Length - 1; k++)
                                {
                                    if (DefectList[iPreRow].Defect[k].DefectCode == MPCF.Trim(spdDefect.Sheets[0].GetValue(i, 0)))
                                    {
                                        bSameDefect = true;
                                        break;
                                    }
                                }
                                
                                if (bSameDefect == true)
                                {
                                    DefectList[iPreRow].Defect[k].Qty += MPCF.ToDbl(spdDefect.Sheets[0].GetValue(i, 2));
                                    dSumDefect += MPCF.ToDbl(spdDefect.Sheets[0].GetValue(i, 2));
                                }
                                else
                                {                                    
                                    DefectList[iPreRow].Defect[j].DefectCode =  MPCF.Trim(spdDefect.Sheets[0].GetValue(i, 0));
                                    DefectList[iPreRow].Defect[j].Qty = MPCF.ToDbl(spdDefect.Sheets[0].GetValue(i, 2));
                                    dSumDefect += MPCF.ToDbl(spdDefect.Sheets[0].GetValue(i, 2));                                
                                }
                                j++;
                            }
                        }
                        
                        DefectList[iPreRow].DefectQty = dSumDefect;
                        with_1.SetValue(iPreRow, COL_DEFECT_QTY, dSumDefect);
                        
                        if (dSumDefect > 0)
                        {
                            with_1.SetValue(iPreRow, COL_DEFECT_CODE, "V");
                        }
                        else
                        {
                            with_1.SetValue(iPreRow, COL_DEFECT_CODE, " ");
                        }
                    }
                    
                }
                
                //Clear spdDefect
                for (i = 0; i <= spdDefect.Sheets[0].Rows.Count - 1; i++)
                {
                    spdDefect.Sheets[0].Cells[i, 0].Text = "";
                    spdDefect.Sheets[0].Cells[i, 2].Text = "";
                }
                
                //Get Current Defect Code List
                if (DefectList[iCurRow].DefectQty > 0)
                {
                    for (i = 0; i <= DefectList[iCurRow].Defect.Length - 1; i++)
                    {
                        spdDefect.Sheets[0].SetValue(i, 0, DefectList[iCurRow].Defect[i].DefectCode);
                        spdDefect.Sheets[0].SetValue(i, 2, DefectList[iCurRow].Defect[i].Qty);
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void Get_Defect_Code()
        {

            int i; 

            try
            {

                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];

                //Clear spdDefect
                for (i = 0; i <= spdDefect.Sheets[0].Rows.Count - 1; i++)
                {
                    spdDefect.Sheets[0].Cells[i, 0].Text = "";
                    spdDefect.Sheets[0].Cells[i, 2].Text = "";
                }

                //Get Current Defect Code List
                if (DefectList[iCurRow].DefectQty > 0)
                {
                    for (i = 0; i <= DefectList[iCurRow].Defect.Length - 1; i++)
                    {
                        spdDefect.Sheets[0].SetValue(i, 0, DefectList[iCurRow].Defect[i].DefectCode);
                        spdDefect.Sheets[0].SetValue(i, 2, DefectList[iCurRow].Defect[i].Qty);
                    }
                }


            }
            catch (Exception)
            {
            }
        }


        private bool View_Defect_List(string sInspItem)
        {
            TRSNode in_node = new TRSNode("VIEW_DEFECT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DEFECT_LIST_OUT");

            ListViewItem itmX;
            int i;

            try
            {
                MPCF.InitListView(lisItemDefect);

                MPCR.SetInMsg(in_node);

                in_node.ProcStep = '1';
                in_node.AddString("BATCH_ID", MPCF.Trim(txtBatchID.Text));
                in_node.AddInt("BATCH_HIST_SEQ", MPCF.ToInt(ctrlBatchInfo.HistSeq));
                in_node.AddString("ITEM_ID", MPCF.Trim(txtItemID.Text));
                in_node.AddString("INSP_ITEM", sInspItem);

                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Defect_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        itmX = new ListViewItem(out_node.GetList(0)[i].GetString("DEFECT_CODE"));
                        itmX.SubItems.Add(out_node.GetList(0)[i].GetDouble("DEFECT_QTY").ToString());

                        lisItemDefect.Items.Add(itmX);
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
        
        private void frmQCMTranResultRecording_Load(object sender, System.EventArgs e)
        {
            
            pnlTranTime.Visible = MPGO.UseBackDate();
            dtpTranDate.Enabled = chkTranDateTime.Checked;
            dtpTranTime.Enabled = chkTranDateTime.Checked;
            
        }
        
        private void frmQCMTranResultRecording_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (bLoadFlag == false)
                {
                    MPCR.SetCMFItem(MPGC.MP_CMF_TRN_QCM_RESULT, "lblCMF", "cdvCMF", grpCMF);
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
                        MPCF.InitListView(lisItemDefect);
                        
                        if (ctrlBatchInfo.ViewBatchInformation(txtBatchID.Text, "RESULT") == false)
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
        
        private void spdInspItem_EditChange(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            spdInspItem.Sheets[0].SetValue(e.Row, 0, true);
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("RESULT_RECORDING") == false)
                {
                    return;
                }
                
                if (Result_Recording('1') == false)
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
        
        private void btnHideDefect_Click(System.Object sender, System.EventArgs e)
        {
            
            int i;
            int j;
            double dSumDefect = 0.0D;
            
            try
            {
                FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];
                
                grpDefect.Size = new System.Drawing.Size(0, grpInspItem.Size.Height); //Width in Show : 250
                grpDefect.Visible = false;
                MPCR.ChangeControlEnabled(this, btnProcess, true);
                
                j = 0;

                DefectList[iCurRow].Defect = new Defect[spdDefect.Sheets[0].Rows.Count - 1];
                
                for (i = 0; i <= spdDefect.Sheets[0].Rows.Count - 1; i++)
                {
                    if (MPCF.Trim(spdDefect.Sheets[0].GetValue(i, 0)) != "" && MPCF.ToDbl(spdDefect.Sheets[0].GetValue(i, 2)) > 0)
                    {
                        DefectList[iCurRow].Defect[j].DefectCode = MPCF.Trim(spdDefect.Sheets[0].Cells[i, 0].Text);
                        DefectList[iCurRow].Defect[j].Qty = MPCF.ToDbl(spdDefect.Sheets[0].Cells[i, 2].Text);
                        dSumDefect += MPCF.ToDbl(spdDefect.Sheets[0].GetValue(i, 2));
                        j++;
                    }
                }
                
                DefectList[iCurRow].DefectQty = dSumDefect;
                with_1.SetValue(iCurRow, COL_DEFECT_QTY, dSumDefect);
                
                if (dSumDefect > 0)
                {
                    with_1.SetValue(iCurRow, COL_DEFECT_CODE, "V");
                }
                
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdDefect_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {

            string sDefectGrp;
            
            if (txtDefectInspItem.Text == "")
            {
                return;
            }
            
            if (spdInspItem.Sheets[0].Rows[iCurRow].Locked == true)
            {
                return;
            }
            
            //'Fill Defect Code
            sDefectGrp = MPCF.Trim(spdInspItem.Sheets[0].GetValue(iCurRow, COL_DEFECT_GROUP));

            if (sDefectGrp == "")
            {
                return;
            }
            
            cdvDefect.Init();
            cdvDefect.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvDefect.GetListView);
            cdvDefect.Columns.Add("Defect Code", 50, HorizontalAlignment.Left);
            cdvDefect.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            BASLIST.ViewGCMDataList(cdvDefect.GetListView, '1', sDefectGrp);
            
            if (e.Column == 1)
            {
                if (cdvDefect.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            
        }
        
        private void cdvDefect_SelectedItemChanged(System.Object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            spdDefect.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            
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
                
                if (e.Column == COL_DEFECT_CMD)
                {
                    grpDefect.Size = new System.Drawing.Size(250, grpInspItem.Size.Height);
                    grpDefect.Visible = true;
                    btnProcess.Enabled = false;
                }

                if (e.Column == COL_RESULT || (e.Column == COL_SMP_QTY && with_1.Cells[e.Row, COL_SMP_QTY].Locked == false))
                {
                    return;
                }
                
                if (MPCF.Trim(ctrlBatchInfo.InspMethod) != MPGC.MP_QCM_INSP_METHOD_Q)
                {

                    if (MPCF.Trim(with_1.GetValue(e.Row, COL_INSP_METHOD)) == MPGC.MP_QCM_INSP_METHOD_I && 
                        e.Column != COL_SEL && 
                        e.Column != COL_DEFECT_CMD && 
                        e.Column != COL_COMMENT && 
                        e.Column != COL_RESULT)
                    {
                        
                        tabTran.SelectedTab = tbpItem;
                        
                    }
                    
                }
                
                //if (iPreRow == iCurRow)
                //{
                //    return;
                //}
                MPCF.FieldClear(grpSelectedInspItem);
                MPCF.InitListView(lisItem);
                MPCF.InitListView(lisItemDefect);
                btnInsert.Enabled = false;
                btnDelete.Enabled = false;

                txtSeq.Text = (iCurRow + 1).ToString();
                txtInspitem.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_INSP_ITEM));
                txtResult.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_RESULT));
                txtItemCount.Text = ctrlBatchInfo.ItemCount;
                txtTestQty.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_TEST_QTY));
                txtDefectQty.Text = MPCF.Trim(with_1.GetValue(e.Row, COL_DEFECT_QTY));
                
                if (txtInspitem.Text != "")
                {
                    View_Batch_Item_List(txtInspitem.Text);

                    if (MPCF.Trim(txtResult.Text) == "")
                    {
                        MPCR.ChangeControlEnabled(this, btnInsert, true);
                        MPCR.ChangeControlEnabled(this, btnDelete, true);
                    }
                }
                
                Get_Save_Defect_Code();
                
                iPreRow = iCurRow;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvItemDefect_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            string sDefectGrp;
            
            if (txtInspitem.Text == "")
            {
                return;
            }
            
            //Fill Defect Code
            sDefectGrp = MPCF.Trim(spdInspItem.Sheets[0].GetValue(iCurRow, COL_DEFECT_GROUP));
            
            if (sDefectGrp == "")
            {
                return;
            }
            
            cdvItemDefect.Init();
            MPCF.InitListView(cdvItemDefect.GetListView);
            cdvItemDefect.Columns.Add("Defect Code", 50, HorizontalAlignment.Left);
            cdvItemDefect.Columns.Add("Desc", 50, HorizontalAlignment.Left);
            cdvItemDefect.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvItemDefect.GetListView, '1', sDefectGrp);
            
        }
        
        private void lisItem_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            int iSelectedIndex;
            
            try
            {
                if (lisItem.Items.Count < 1)
                {
                    return;
                }
                
                if (lisItem.SelectedItems.Count < 1)
                {
                    return;
                }
                
                iSelectedIndex = lisItem.SelectedItems[0].Index;
                
                txtItemID.Text = lisItem.Items[iSelectedIndex].SubItems[1].Text;
                txtTestQty.Text = lisItem.Items[iSelectedIndex].SubItems[2].Text;

                if (MPCF.Trim(lisItem.Items[iSelectedIndex].SubItems[3].Text) == "PASS")
                {
                    cboResult.SelectedIndex = 0;
                }
                else if (MPCF.Trim(lisItem.Items[iSelectedIndex].SubItems[3].Text) == "FAIL")
                {
                    cboResult.SelectedIndex = 1;
                }
                else
                {
                    cboResult.SelectedIndex = - 1;
                }

                //cdvItemDefect.Text = lisItem.Items[iSelectedIndex].SubItems[4].Text;
                //txtDefectQty.Text = lisItem.Items[iSelectedIndex].SubItems[5].Text;
                txtItemComment.Text = lisItem.Items[iSelectedIndex].SubItems[5].Text;

                View_Defect_List(txtInspitem.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        } 
        
        private void tabTran_TabIndexChanged(object sender, System.EventArgs e)
        {
            if (tabTran.SelectedTab == tbpGeneral)
            {
                MPCR.ChangeControlEnabled(this, btnProcess, true);
            }
            else
            {
                btnProcess.Enabled = false;
            }
        }
        
        private void cboResult_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (cboResult.SelectedIndex == 1)
            {
                cdvItemDefect.Enabled = true;
                txtDefectQty.ReadOnly = false;
            }
            else
            {
                cdvItemDefect.Text = "";
                txtDefectQty.Text = "";
                txtDefectQty.ReadOnly = true;
                cdvItemDefect.Enabled = false;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            double dTestQty;
            double dDefectQty;
            double dItemQty;
            double dCDefectQty;
            int i;

            try
            {
                if (lisItem.SelectedItems.Count < 1)
                {
                    return;
                }

                dTestQty = MPCF.ToDbl(spdInspItem.Sheets[0].GetValue(iCurRow, COL_TEST_QTY));
                dDefectQty = MPCF.ToDbl(spdInspItem.Sheets[0].GetValue(iCurRow, COL_DEFECT_QTY));
                dItemQty = MPCF.ToDbl(lisItem.Items[lisItem.SelectedItems[0].Index].SubItems[2].Text);
                dCDefectQty = MPCF.ToDbl(txtDefectQty.Text);

                if (CheckCondition("RESULT_RECORDING_INDIVIDUAL") == false)
                {
                    return;
                }

                if (Result_Recording_Individual('1') == true)
                {
                    spdInspItem.Sheets[0].SetValue(iCurRow, COL_TEST_QTY, dItemQty);
                    //spdInspItem.Sheets[0].SetValue(iCurRow, COL_TEST_QTY, dTestQty + dItemQty);
                    txtTestQty.Text = MPCF.Trim(dItemQty);
                    //txtTestQty.Text = MPCF.Trim(dTestQty + dItemQty);

                    if (cboResult.Text == "FAIL")
                    {
                        spdInspItem.Sheets[0].SetValue(iCurRow, COL_DEFECT_QTY, dDefectQty + dCDefectQty);
                        spdInspItem.Sheets[0].SetValue(iCurRow, COL_DEFECT_CODE, "V");
                        txtDefectQty.Text = Convert.ToString(dDefectQty + dItemQty);

                        for (i = 0; i <= spdDefect.Sheets[0].Rows.Count - 1; i++)
                        {

                            if (MPCF.Trim(spdDefect.Sheets[0].GetValue(i, 0)) == "")
                            {
                                spdDefect.Sheets[0].Cells[i, 2].Text = null;
                                break;
                            }

                            if (cdvItemDefect.Text == MPCF.Trim(spdDefect.Sheets[0].GetValue(i, 0)))
                            {
                                break;
                            }

                        }

                        spdDefect.Sheets[0].SetValue(i, 0, cdvItemDefect.Text);
                        spdDefect.Sheets[0].SetValue(i, 2, MPCF.Trim(MPCF.ToDbl(spdDefect.Sheets[0].Cells[i, 2].Text) + dCDefectQty));
                    }

                    View_Batch_Item_List(txtInspitem.Text);

                }

                Get_Save_Defect_Code();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            double dTestQty;
            double dDefectQty;
            double dItemQty;
            double dCDefectQty;
            int i;

            try
            {
                if (lisItem.SelectedItems.Count < 1)
                {
                    return;
                }

                dTestQty = MPCF.ToDbl(spdInspItem.Sheets[0].GetValue(iCurRow, COL_TEST_QTY));
                dDefectQty = MPCF.ToDbl(spdInspItem.Sheets[0].GetValue(iCurRow, COL_DEFECT_QTY));
                dItemQty = MPCF.ToDbl(lisItem.Items[lisItem.SelectedItems[0].Index].SubItems[2].Text);
                dCDefectQty = MPCF.ToDbl(txtDefectQty.Text);

                if (CheckCondition("RESULT_RECORDING_INDIVIDUAL") == false)
                {
                    return;
                }

                if (Result_Recording_Individual('2') == true)
                {

                    //spdInspItem.Sheets[0].SetValue(iCurRow, COL_TEST_QTY, dTestQty - dItemQty);
                    spdInspItem.Sheets[0].SetValue(iCurRow, COL_TEST_QTY, dItemQty);
                    txtTestQty.Text = Convert.ToString(dItemQty);
                    //txtTestQty.Text = Convert.ToString(dTestQty - dItemQty);

                    if (cboResult.Text == "FAIL")
                    {

                        if (dDefectQty > 0)
                        {
                            spdInspItem.Sheets[0].SetValue(iCurRow, COL_DEFECT_QTY, dDefectQty - dCDefectQty);
                            if (dDefectQty - dCDefectQty <= 0)
                            {
                                spdInspItem.Sheets[0].SetValue(iCurRow, COL_DEFECT_CODE, " ");
                            }
                        }
                        //txtDefectQty.Text = Convert.ToString(dDefectQty - dItemQty);

                        for (i = 0; i <= spdDefect.Sheets[0].Rows.Count - 1; i++)
                        {

                            if (MPCF.Trim(spdDefect.Sheets[0].GetValue(i, 0)) == "")
                            {
                                spdDefect.Sheets[0].Cells[i, 2].Text = null;
                                break;
                            }

                            if (cdvItemDefect.Text == MPCF.Trim(spdDefect.Sheets[0].GetValue(i, 0)))
                            {
                                if (MPCF.ToDbl(spdDefect.Sheets[0].Cells[i, 2].Text) - dCDefectQty != 0)
                                {
                                    spdDefect.Sheets[0].SetValue(i, 0, cdvItemDefect.Text);
                                    spdDefect.Sheets[0].SetValue(i, 2, Convert.ToString(MPCF.ToDbl(spdDefect.Sheets[0].Cells[i, 2].Text) - dCDefectQty));
                                }
                                else
                                {
                                    spdDefect.Sheets[0].SetValue(i, 0, "");
                                    spdDefect.Sheets[0].SetValue(i, 2, "");
                                }
                                break;
                            }
                        } 
                    }

                    View_Batch_Item_List(txtInspitem.Text);

                }

                Get_Save_Defect_Code();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisItemDefect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex;

            try
            {
                if (lisItemDefect.Items.Count < 1)
                {
                    return;
                }

                if (lisItemDefect.SelectedItems.Count < 1)
                {
                    return;
                }

                iSelectedIndex = lisItemDefect.SelectedItems[0].Index;

                cdvItemDefect.Text = lisItemDefect.Items[iSelectedIndex].SubItems[0].Text;
                txtDefectQty.Text = lisItemDefect.Items[iSelectedIndex].SubItems[1].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
    //#End If
    
}
