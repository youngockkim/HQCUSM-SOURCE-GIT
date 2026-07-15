
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
//   File Name   : frmSPCTranOOCHistory.vb
//   Description : Update OOC History
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - Update_OOC_History : Update OOC History
//       - View_OOC_History : View OOC History
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
namespace Miracom.SPCCore
{
    public class frmSPCTranUpdateOOCHistory : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranUpdateOOCHistory()
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
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.GroupBox grpChart;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtGraphType;
        internal System.Windows.Forms.Label lblGraphType;
        internal System.Windows.Forms.Label lblChartID;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtChart;
        internal System.Windows.Forms.Panel pnlMid;
        internal System.Windows.Forms.GroupBox grpOOC;
        internal System.Windows.Forms.GroupBox grpAction;
        internal System.Windows.Forms.Label lblActTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtActComment;
        internal System.Windows.Forms.Label lblActComment;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvActUser;
        internal System.Windows.Forms.Label lblActUser;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvActCode;
        internal System.Windows.Forms.Label lblActCode;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtActTime;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccActDate;
        internal System.Windows.Forms.GroupBox grpTrouble;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspector;
        internal System.Windows.Forms.Label lblInspector;
        internal System.Windows.Forms.Label lblTrbTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTrbComment;
        internal System.Windows.Forms.Label lblTrbComment;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvTrbUser;
        internal System.Windows.Forms.Label lblTroubleUser;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvTrbCode;
        internal System.Windows.Forms.Label lblTroubleCode;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtTrbTime;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccTrbDate;
        internal System.Windows.Forms.Label lblHistSeq;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtHistSeq;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTranTime;
        internal System.Windows.Forms.Label lblTranTime;
        internal System.Windows.Forms.Label lblLotorRes;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLotorRes;
        internal System.Windows.Forms.Label lblOOCType;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtOOCDesc;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtOOCDesc2;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtOOCType2;
        internal System.Windows.Forms.Label lblOOCType2;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtOOCType;
        internal System.Windows.Forms.GroupBox grpChartInfo;
        internal System.Windows.Forms.Button btnRefresh;
        internal udcChart ctrlChartData;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranUpdateOOCHistory));
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpChartInfo = new System.Windows.Forms.GroupBox();
            this.ctrlChartData = new Miracom.SPCCore.udcChart();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.txtGraphType = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblGraphType = new System.Windows.Forms.Label();
            this.lblChartID = new System.Windows.Forms.Label();
            this.txtChart = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.lblActTime = new System.Windows.Forms.Label();
            this.txtActComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblActComment = new System.Windows.Forms.Label();
            this.cdvActUser = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblActUser = new System.Windows.Forms.Label();
            this.cdvActCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblActCode = new System.Windows.Forms.Label();
            this.udtActTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccActDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.grpTrouble = new System.Windows.Forms.GroupBox();
            this.cdvInspector = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInspector = new System.Windows.Forms.Label();
            this.lblTrbTime = new System.Windows.Forms.Label();
            this.txtTrbComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblTrbComment = new System.Windows.Forms.Label();
            this.cdvTrbUser = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTroubleUser = new System.Windows.Forms.Label();
            this.cdvTrbCode = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTroubleCode = new System.Windows.Forms.Label();
            this.udtTrbTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccTrbDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.grpOOC = new System.Windows.Forms.GroupBox();
            this.txtOOCDesc2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtOOCType2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblOOCType2 = new System.Windows.Forms.Label();
            this.txtOOCDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtOOCType = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblOOCType = new System.Windows.Forms.Label();
            this.lblLotorRes = new System.Windows.Forms.Label();
            this.txtLotorRes = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtTranTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblTranTime = new System.Windows.Forms.Label();
            this.lblHistSeq = new System.Windows.Forms.Label();
            this.txtHistSeq = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpChartInfo.SuspendLayout();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).BeginInit();
            this.pnlMid.SuspendLayout();
            this.grpAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtActComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtActTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccActDate)).BeginInit();
            this.grpTrouble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrbComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrbCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTrbTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTrbDate)).BeginInit();
            this.grpOOC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOOCDesc2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOOCType2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOOCDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOOCType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotorRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHistSeq)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(558, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpChartInfo);
            this.pnlTop.Controls.Add(this.grpChart);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTop.Size = new System.Drawing.Size(742, 146);
            this.pnlTop.TabIndex = 0;
            // 
            // grpChartInfo
            // 
            this.grpChartInfo.Controls.Add(this.ctrlChartData);
            this.grpChartInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChartInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartInfo.Location = new System.Drawing.Point(3, 48);
            this.grpChartInfo.Name = "grpChartInfo";
            this.grpChartInfo.Size = new System.Drawing.Size(736, 98);
            this.grpChartInfo.TabIndex = 1;
            this.grpChartInfo.TabStop = false;
            // 
            // ctrlChartData
            // 
            this.ctrlChartData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChartData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlChartData.Location = new System.Drawing.Point(3, 16);
            this.ctrlChartData.Name = "ctrlChartData";
            this.ctrlChartData.Size = new System.Drawing.Size(730, 79);
            this.ctrlChartData.SyncEDCFlag = ' ';
            this.ctrlChartData.TabIndex = 0;
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.txtGraphType);
            this.grpChart.Controls.Add(this.lblGraphType);
            this.grpChart.Controls.Add(this.lblChartID);
            this.grpChart.Controls.Add(this.txtChart);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(3, 0);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(736, 48);
            this.grpChart.TabIndex = 0;
            this.grpChart.TabStop = false;
            // 
            // txtGraphType
            // 
            this.txtGraphType.Location = new System.Drawing.Point(524, 16);
            this.txtGraphType.MaxLength = 30;
            this.txtGraphType.Name = "txtGraphType";
            this.txtGraphType.ReadOnly = true;
            this.txtGraphType.Size = new System.Drawing.Size(200, 20);
            this.txtGraphType.TabIndex = 3;
            // 
            // lblGraphType
            // 
            this.lblGraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGraphType.Location = new System.Drawing.Point(411, 19);
            this.lblGraphType.Name = "lblGraphType";
            this.lblGraphType.Size = new System.Drawing.Size(104, 14);
            this.lblGraphType.TabIndex = 2;
            this.lblGraphType.Text = "Graph Type";
            // 
            // lblChartID
            // 
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 19);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(97, 14);
            this.lblChartID.TabIndex = 0;
            this.lblChartID.Text = "Chart ID";
            // 
            // txtChart
            // 
            this.txtChart.Location = new System.Drawing.Point(120, 16);
            this.txtChart.MaxLength = 30;
            this.txtChart.Name = "txtChart";
            this.txtChart.ReadOnly = true;
            this.txtChart.Size = new System.Drawing.Size(200, 20);
            this.txtChart.TabIndex = 1;
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.grpAction);
            this.pnlMid.Controls.Add(this.grpTrouble);
            this.pnlMid.Controls.Add(this.grpOOC);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 146);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlMid.Size = new System.Drawing.Size(742, 360);
            this.pnlMid.TabIndex = 1;
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.lblActTime);
            this.grpAction.Controls.Add(this.txtActComment);
            this.grpAction.Controls.Add(this.lblActComment);
            this.grpAction.Controls.Add(this.cdvActUser);
            this.grpAction.Controls.Add(this.lblActUser);
            this.grpAction.Controls.Add(this.cdvActCode);
            this.grpAction.Controls.Add(this.lblActCode);
            this.grpAction.Controls.Add(this.udtActTime);
            this.grpAction.Controls.Add(this.uccActDate);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAction.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAction.Location = new System.Drawing.Point(3, 216);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(736, 144);
            this.grpAction.TabIndex = 2;
            this.grpAction.TabStop = false;
            // 
            // lblActTime
            // 
            this.lblActTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActTime.Location = new System.Drawing.Point(15, 43);
            this.lblActTime.Name = "lblActTime";
            this.lblActTime.Size = new System.Drawing.Size(97, 14);
            this.lblActTime.TabIndex = 4;
            this.lblActTime.Text = "Action Time";
            this.lblActTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtActComment
            // 
            this.txtActComment.Location = new System.Drawing.Point(120, 64);
            this.txtActComment.MaxLength = 200;
            this.txtActComment.Multiline = true;
            this.txtActComment.Name = "txtActComment";
            this.txtActComment.Size = new System.Drawing.Size(604, 43);
            this.txtActComment.TabIndex = 4;
            // 
            // lblActComment
            // 
            this.lblActComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActComment.Location = new System.Drawing.Point(15, 64);
            this.lblActComment.Name = "lblActComment";
            this.lblActComment.Size = new System.Drawing.Size(97, 14);
            this.lblActComment.TabIndex = 7;
            this.lblActComment.Text = "Action Comment";
            this.lblActComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvActUser
            // 
            this.cdvActUser.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActUser.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActUser.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActUser.BtnToolTipText = "";
            this.cdvActUser.DescText = "";
            this.cdvActUser.DisplaySubItemIndex = -1;
            this.cdvActUser.DisplayText = "";
            this.cdvActUser.Focusing = null;
            this.cdvActUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActUser.Index = 0;
            this.cdvActUser.IsViewBtnImage = false;
            this.cdvActUser.Location = new System.Drawing.Point(524, 16);
            this.cdvActUser.MaxLength = 20;
            this.cdvActUser.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActUser.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActUser.Name = "cdvActUser";
            this.cdvActUser.ReadOnly = false;
            this.cdvActUser.SearchSubItemIndex = 0;
            this.cdvActUser.SelectedDescIndex = -1;
            this.cdvActUser.SelectedSubItemIndex = -1;
            this.cdvActUser.SelectionStart = 0;
            this.cdvActUser.Size = new System.Drawing.Size(200, 20);
            this.cdvActUser.SmallImageList = null;
            this.cdvActUser.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActUser.TabIndex = 1;
            this.cdvActUser.TextBoxToolTipText = "";
            this.cdvActUser.TextBoxWidth = 200;
            this.cdvActUser.VisibleButton = true;
            this.cdvActUser.VisibleColumnHeader = false;
            this.cdvActUser.VisibleDescription = false;
            this.cdvActUser.ButtonPress += new System.EventHandler(this.cdvActUser_ButtonPress);
            // 
            // lblActUser
            // 
            this.lblActUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActUser.Location = new System.Drawing.Point(411, 19);
            this.lblActUser.Name = "lblActUser";
            this.lblActUser.Size = new System.Drawing.Size(97, 14);
            this.lblActUser.TabIndex = 2;
            this.lblActUser.Text = "Action User";
            this.lblActUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvActCode
            // 
            this.cdvActCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvActCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvActCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvActCode.BtnToolTipText = "";
            this.cdvActCode.DescText = "";
            this.cdvActCode.DisplaySubItemIndex = -1;
            this.cdvActCode.DisplayText = "";
            this.cdvActCode.Focusing = null;
            this.cdvActCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvActCode.Index = 0;
            this.cdvActCode.IsViewBtnImage = false;
            this.cdvActCode.Location = new System.Drawing.Point(120, 16);
            this.cdvActCode.MaxLength = 30;
            this.cdvActCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvActCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvActCode.Name = "cdvActCode";
            this.cdvActCode.ReadOnly = false;
            this.cdvActCode.SearchSubItemIndex = 0;
            this.cdvActCode.SelectedDescIndex = -1;
            this.cdvActCode.SelectedSubItemIndex = -1;
            this.cdvActCode.SelectionStart = 0;
            this.cdvActCode.Size = new System.Drawing.Size(200, 20);
            this.cdvActCode.SmallImageList = null;
            this.cdvActCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvActCode.TabIndex = 0;
            this.cdvActCode.TextBoxToolTipText = "";
            this.cdvActCode.TextBoxWidth = 200;
            this.cdvActCode.VisibleButton = true;
            this.cdvActCode.VisibleColumnHeader = false;
            this.cdvActCode.VisibleDescription = false;
            this.cdvActCode.ButtonPress += new System.EventHandler(this.cdvActCode_ButtonPress);
            // 
            // lblActCode
            // 
            this.lblActCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblActCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActCode.Location = new System.Drawing.Point(15, 19);
            this.lblActCode.Name = "lblActCode";
            this.lblActCode.Size = new System.Drawing.Size(97, 14);
            this.lblActCode.TabIndex = 0;
            this.lblActCode.Text = "Action Code";
            this.lblActCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udtActTime
            // 
            this.udtActTime.DateTime = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            this.udtActTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtActTime.FormatString = "";
            this.udtActTime.Location = new System.Drawing.Point(211, 40);
            this.udtActTime.MaskInput = "hh:mm:ss";
            this.udtActTime.Name = "udtActTime";
            this.udtActTime.Size = new System.Drawing.Size(72, 21);
            this.udtActTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtActTime.SpinWrap = true;
            this.udtActTime.TabIndex = 3;
            this.udtActTime.Value = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            // 
            // uccActDate
            // 
            this.uccActDate.DateButtons.Add(dateButton1);
            this.uccActDate.Location = new System.Drawing.Point(120, 40);
            this.uccActDate.Name = "uccActDate";
            this.uccActDate.NonAutoSizeHeight = 21;
            this.uccActDate.Size = new System.Drawing.Size(88, 21);
            this.uccActDate.TabIndex = 2;
            this.uccActDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // grpTrouble
            // 
            this.grpTrouble.Controls.Add(this.cdvInspector);
            this.grpTrouble.Controls.Add(this.lblInspector);
            this.grpTrouble.Controls.Add(this.lblTrbTime);
            this.grpTrouble.Controls.Add(this.txtTrbComment);
            this.grpTrouble.Controls.Add(this.lblTrbComment);
            this.grpTrouble.Controls.Add(this.cdvTrbUser);
            this.grpTrouble.Controls.Add(this.lblTroubleUser);
            this.grpTrouble.Controls.Add(this.cdvTrbCode);
            this.grpTrouble.Controls.Add(this.lblTroubleCode);
            this.grpTrouble.Controls.Add(this.udtTrbTime);
            this.grpTrouble.Controls.Add(this.uccTrbDate);
            this.grpTrouble.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTrouble.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTrouble.Location = new System.Drawing.Point(3, 96);
            this.grpTrouble.Name = "grpTrouble";
            this.grpTrouble.Size = new System.Drawing.Size(736, 120);
            this.grpTrouble.TabIndex = 1;
            this.grpTrouble.TabStop = false;
            // 
            // cdvInspector
            // 
            this.cdvInspector.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspector.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspector.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspector.BtnToolTipText = "";
            this.cdvInspector.DescText = "";
            this.cdvInspector.DisplaySubItemIndex = -1;
            this.cdvInspector.DisplayText = "";
            this.cdvInspector.Focusing = null;
            this.cdvInspector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspector.Index = 0;
            this.cdvInspector.IsViewBtnImage = false;
            this.cdvInspector.Location = new System.Drawing.Point(524, 16);
            this.cdvInspector.MaxLength = 20;
            this.cdvInspector.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspector.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspector.Name = "cdvInspector";
            this.cdvInspector.ReadOnly = false;
            this.cdvInspector.SearchSubItemIndex = 0;
            this.cdvInspector.SelectedDescIndex = -1;
            this.cdvInspector.SelectedSubItemIndex = -1;
            this.cdvInspector.SelectionStart = 0;
            this.cdvInspector.Size = new System.Drawing.Size(200, 20);
            this.cdvInspector.SmallImageList = null;
            this.cdvInspector.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspector.TabIndex = 1;
            this.cdvInspector.TextBoxToolTipText = "";
            this.cdvInspector.TextBoxWidth = 200;
            this.cdvInspector.VisibleButton = true;
            this.cdvInspector.VisibleColumnHeader = false;
            this.cdvInspector.VisibleDescription = false;
            this.cdvInspector.ButtonPress += new System.EventHandler(this.cdvInspector_ButtonPress);
            // 
            // lblInspector
            // 
            this.lblInspector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspector.Location = new System.Drawing.Point(411, 19);
            this.lblInspector.Name = "lblInspector";
            this.lblInspector.Size = new System.Drawing.Size(97, 14);
            this.lblInspector.TabIndex = 2;
            this.lblInspector.Text = "Inspector";
            this.lblInspector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrbTime
            // 
            this.lblTrbTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTrbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrbTime.Location = new System.Drawing.Point(15, 43);
            this.lblTrbTime.Name = "lblTrbTime";
            this.lblTrbTime.Size = new System.Drawing.Size(97, 14);
            this.lblTrbTime.TabIndex = 4;
            this.lblTrbTime.Text = "Trouble Time";
            this.lblTrbTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrbComment
            // 
            this.txtTrbComment.Location = new System.Drawing.Point(120, 64);
            this.txtTrbComment.MaxLength = 200;
            this.txtTrbComment.Multiline = true;
            this.txtTrbComment.Name = "txtTrbComment";
            this.txtTrbComment.Size = new System.Drawing.Size(604, 43);
            this.txtTrbComment.TabIndex = 5;
            // 
            // lblTrbComment
            // 
            this.lblTrbComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTrbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrbComment.Location = new System.Drawing.Point(15, 64);
            this.lblTrbComment.Name = "lblTrbComment";
            this.lblTrbComment.Size = new System.Drawing.Size(101, 14);
            this.lblTrbComment.TabIndex = 9;
            this.lblTrbComment.Text = "Trouble Comment";
            this.lblTrbComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvTrbUser
            // 
            this.cdvTrbUser.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTrbUser.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTrbUser.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTrbUser.BtnToolTipText = "";
            this.cdvTrbUser.DescText = "";
            this.cdvTrbUser.DisplaySubItemIndex = -1;
            this.cdvTrbUser.DisplayText = "";
            this.cdvTrbUser.Focusing = null;
            this.cdvTrbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTrbUser.Index = 0;
            this.cdvTrbUser.IsViewBtnImage = false;
            this.cdvTrbUser.Location = new System.Drawing.Point(524, 40);
            this.cdvTrbUser.MaxLength = 20;
            this.cdvTrbUser.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTrbUser.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTrbUser.Name = "cdvTrbUser";
            this.cdvTrbUser.ReadOnly = false;
            this.cdvTrbUser.SearchSubItemIndex = 0;
            this.cdvTrbUser.SelectedDescIndex = -1;
            this.cdvTrbUser.SelectedSubItemIndex = -1;
            this.cdvTrbUser.SelectionStart = 0;
            this.cdvTrbUser.Size = new System.Drawing.Size(200, 20);
            this.cdvTrbUser.SmallImageList = null;
            this.cdvTrbUser.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTrbUser.TabIndex = 4;
            this.cdvTrbUser.TextBoxToolTipText = "";
            this.cdvTrbUser.TextBoxWidth = 200;
            this.cdvTrbUser.VisibleButton = true;
            this.cdvTrbUser.VisibleColumnHeader = false;
            this.cdvTrbUser.VisibleDescription = false;
            this.cdvTrbUser.ButtonPress += new System.EventHandler(this.cdvTrbUser_ButtonPress);
            // 
            // lblTroubleUser
            // 
            this.lblTroubleUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTroubleUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroubleUser.Location = new System.Drawing.Point(411, 43);
            this.lblTroubleUser.Name = "lblTroubleUser";
            this.lblTroubleUser.Size = new System.Drawing.Size(97, 14);
            this.lblTroubleUser.TabIndex = 7;
            this.lblTroubleUser.Text = "Trouble User";
            this.lblTroubleUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvTrbCode
            // 
            this.cdvTrbCode.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTrbCode.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTrbCode.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTrbCode.BtnToolTipText = "";
            this.cdvTrbCode.DescText = "";
            this.cdvTrbCode.DisplaySubItemIndex = -1;
            this.cdvTrbCode.DisplayText = "";
            this.cdvTrbCode.Focusing = null;
            this.cdvTrbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTrbCode.Index = 0;
            this.cdvTrbCode.IsViewBtnImage = false;
            this.cdvTrbCode.Location = new System.Drawing.Point(120, 16);
            this.cdvTrbCode.MaxLength = 30;
            this.cdvTrbCode.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTrbCode.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTrbCode.Name = "cdvTrbCode";
            this.cdvTrbCode.ReadOnly = false;
            this.cdvTrbCode.SearchSubItemIndex = 0;
            this.cdvTrbCode.SelectedDescIndex = -1;
            this.cdvTrbCode.SelectedSubItemIndex = -1;
            this.cdvTrbCode.SelectionStart = 0;
            this.cdvTrbCode.Size = new System.Drawing.Size(200, 20);
            this.cdvTrbCode.SmallImageList = null;
            this.cdvTrbCode.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTrbCode.TabIndex = 0;
            this.cdvTrbCode.TextBoxToolTipText = "";
            this.cdvTrbCode.TextBoxWidth = 200;
            this.cdvTrbCode.VisibleButton = true;
            this.cdvTrbCode.VisibleColumnHeader = false;
            this.cdvTrbCode.VisibleDescription = false;
            this.cdvTrbCode.ButtonPress += new System.EventHandler(this.cdvTrbCode_ButtonPress);
            // 
            // lblTroubleCode
            // 
            this.lblTroubleCode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTroubleCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroubleCode.Location = new System.Drawing.Point(15, 19);
            this.lblTroubleCode.Name = "lblTroubleCode";
            this.lblTroubleCode.Size = new System.Drawing.Size(97, 14);
            this.lblTroubleCode.TabIndex = 0;
            this.lblTroubleCode.Text = "Trouble Code";
            this.lblTroubleCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udtTrbTime
            // 
            this.udtTrbTime.DateTime = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            this.udtTrbTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtTrbTime.FormatString = "";
            this.udtTrbTime.Location = new System.Drawing.Point(211, 40);
            this.udtTrbTime.MaskInput = "hh:mm:ss";
            this.udtTrbTime.Name = "udtTrbTime";
            this.udtTrbTime.Size = new System.Drawing.Size(72, 21);
            this.udtTrbTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtTrbTime.SpinWrap = true;
            this.udtTrbTime.TabIndex = 3;
            this.udtTrbTime.Value = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            // 
            // uccTrbDate
            // 
            this.uccTrbDate.DateButtons.Add(dateButton2);
            this.uccTrbDate.Location = new System.Drawing.Point(120, 40);
            this.uccTrbDate.Name = "uccTrbDate";
            this.uccTrbDate.NonAutoSizeHeight = 21;
            this.uccTrbDate.Size = new System.Drawing.Size(88, 21);
            this.uccTrbDate.TabIndex = 2;
            this.uccTrbDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // grpOOC
            // 
            this.grpOOC.Controls.Add(this.txtOOCDesc2);
            this.grpOOC.Controls.Add(this.txtOOCType2);
            this.grpOOC.Controls.Add(this.lblOOCType2);
            this.grpOOC.Controls.Add(this.txtOOCDesc);
            this.grpOOC.Controls.Add(this.txtOOCType);
            this.grpOOC.Controls.Add(this.lblOOCType);
            this.grpOOC.Controls.Add(this.lblLotorRes);
            this.grpOOC.Controls.Add(this.txtLotorRes);
            this.grpOOC.Controls.Add(this.txtTranTime);
            this.grpOOC.Controls.Add(this.lblTranTime);
            this.grpOOC.Controls.Add(this.lblHistSeq);
            this.grpOOC.Controls.Add(this.txtHistSeq);
            this.grpOOC.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOOC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOOC.Location = new System.Drawing.Point(3, 0);
            this.grpOOC.Name = "grpOOC";
            this.grpOOC.Size = new System.Drawing.Size(736, 96);
            this.grpOOC.TabIndex = 0;
            this.grpOOC.TabStop = false;
            // 
            // txtOOCDesc2
            // 
            this.txtOOCDesc2.Location = new System.Drawing.Point(214, 66);
            this.txtOOCDesc2.MaxLength = 200;
            this.txtOOCDesc2.Name = "txtOOCDesc2";
            this.txtOOCDesc2.ReadOnly = true;
            this.txtOOCDesc2.Size = new System.Drawing.Size(510, 20);
            this.txtOOCDesc2.TabIndex = 6;
            // 
            // txtOOCType2
            // 
            this.txtOOCType2.Location = new System.Drawing.Point(120, 66);
            this.txtOOCType2.MaxLength = 2;
            this.txtOOCType2.Name = "txtOOCType2";
            this.txtOOCType2.ReadOnly = true;
            this.txtOOCType2.Size = new System.Drawing.Size(80, 20);
            this.txtOOCType2.TabIndex = 5;
            // 
            // lblOOCType2
            // 
            this.lblOOCType2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOOCType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOOCType2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOOCType2.Location = new System.Drawing.Point(15, 69);
            this.lblOOCType2.Name = "lblOOCType2";
            this.lblOOCType2.Size = new System.Drawing.Size(97, 14);
            this.lblOOCType2.TabIndex = 9;
            this.lblOOCType2.Text = "OOC Type2";
            // 
            // txtOOCDesc
            // 
            this.txtOOCDesc.Location = new System.Drawing.Point(214, 41);
            this.txtOOCDesc.MaxLength = 200;
            this.txtOOCDesc.Name = "txtOOCDesc";
            this.txtOOCDesc.ReadOnly = true;
            this.txtOOCDesc.Size = new System.Drawing.Size(510, 20);
            this.txtOOCDesc.TabIndex = 4;
            // 
            // txtOOCType
            // 
            this.txtOOCType.Location = new System.Drawing.Point(120, 41);
            this.txtOOCType.MaxLength = 2;
            this.txtOOCType.Name = "txtOOCType";
            this.txtOOCType.ReadOnly = true;
            this.txtOOCType.Size = new System.Drawing.Size(80, 20);
            this.txtOOCType.TabIndex = 3;
            // 
            // lblOOCType
            // 
            this.lblOOCType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOOCType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOOCType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOOCType.Location = new System.Drawing.Point(15, 44);
            this.lblOOCType.Name = "lblOOCType";
            this.lblOOCType.Size = new System.Drawing.Size(97, 14);
            this.lblOOCType.TabIndex = 6;
            this.lblOOCType.Text = "OOC Type";
            // 
            // lblLotorRes
            // 
            this.lblLotorRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotorRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotorRes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotorRes.Location = new System.Drawing.Point(214, 19);
            this.lblLotorRes.Name = "lblLotorRes";
            this.lblLotorRes.Size = new System.Drawing.Size(97, 14);
            this.lblLotorRes.TabIndex = 2;
            this.lblLotorRes.Text = "Lot / Resource";
            // 
            // txtLotorRes
            // 
            this.txtLotorRes.Location = new System.Drawing.Point(318, 16);
            this.txtLotorRes.MaxLength = 10;
            this.txtLotorRes.Name = "txtLotorRes";
            this.txtLotorRes.ReadOnly = true;
            this.txtLotorRes.Size = new System.Drawing.Size(80, 20);
            this.txtLotorRes.TabIndex = 1;
            // 
            // txtTranTime
            // 
            this.txtTranTime.Location = new System.Drawing.Point(524, 16);
            this.txtTranTime.MaxLength = 30;
            this.txtTranTime.Name = "txtTranTime";
            this.txtTranTime.ReadOnly = true;
            this.txtTranTime.Size = new System.Drawing.Size(200, 20);
            this.txtTranTime.TabIndex = 2;
            // 
            // lblTranTime
            // 
            this.lblTranTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTranTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTranTime.Location = new System.Drawing.Point(411, 19);
            this.lblTranTime.Name = "lblTranTime";
            this.lblTranTime.Size = new System.Drawing.Size(104, 14);
            this.lblTranTime.TabIndex = 4;
            this.lblTranTime.Text = "Transaction Time";
            // 
            // lblHistSeq
            // 
            this.lblHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblHistSeq.Location = new System.Drawing.Point(15, 20);
            this.lblHistSeq.Name = "lblHistSeq";
            this.lblHistSeq.Size = new System.Drawing.Size(97, 14);
            this.lblHistSeq.TabIndex = 0;
            this.lblHistSeq.Text = "Hist Seq";
            // 
            // txtHistSeq
            // 
            this.txtHistSeq.Location = new System.Drawing.Point(120, 16);
            this.txtHistSeq.MaxLength = 2;
            this.txtHistSeq.Name = "txtHistSeq";
            this.txtHistSeq.ReadOnly = true;
            this.txtHistSeq.Size = new System.Drawing.Size(80, 20);
            this.txtHistSeq.TabIndex = 0;
            // 
            // frmSPCTranUpdateOOCHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCTranUpdateOOCHistory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update OOC History";
            this.Load += new System.EventHandler(this.frmSPCTranUpdateOOCHistory_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpChartInfo.ResumeLayout(false);
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).EndInit();
            this.pnlMid.ResumeLayout(false);
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtActComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvActCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtActTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccActDate)).EndInit();
            this.grpTrouble.ResumeLayout(false);
            this.grpTrouble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrbComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTrbCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTrbTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTrbDate)).EndInit();
            this.grpOOC.ResumeLayout(false);
            this.grpOOC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOOCDesc2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOOCType2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOOCDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOOCType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotorRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHistSeq)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Properties Definition"
        
        public char gcStep = '1';
        public int giEDCHistSeq = - 1;
        public int giUnitSeq = - 1;
        
        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CheckCondition()
        {
            
            try
            {
                if (this.uccTrbDate.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccTrbDate.Focus();
                    return false;
                }
                
                if (this.udtTrbTime.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udtTrbTime.Focus();
                    return false;
                }
                
                if (this.uccActDate.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccActDate.Focus();
                    return false;
                }
                
                if (this.udtActTime.Value == System.DBNull.Value)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    udtActTime.Focus();
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_OOC_History()
        //       - View OOC History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_OOC_History()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_OOC_History_In");
                TRSNode out_node = new TRSNode("View_OOC_History_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = gcStep;
                in_node.AddString("CHART_ID", txtChart.Text);
                in_node.AddInt("HIST_SEQ", MPCF.ToInt(txtHistSeq.Text));
        
                if (gcStep == 2 &&(giEDCHistSeq == - 1 || giUnitSeq == - 1))
                {
                    return false;
                }
                
                if (giEDCHistSeq != - 1)
                {
                    in_node.AddInt("EDC_HIST_SEQ", giEDCHistSeq);
                }
                
                if (giUnitSeq != - 1)
                {
                    in_node.AddInt("EDC_UNIT_SEQ", giUnitSeq);
                }

                if (MPCR.CallService("SPC", "SPC_View_OOC_History", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtHistSeq.Text = out_node.GetInt("HIST_SEQ").ToString();
                txtTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("TRAN_TIME"));
                txtLotorRes.Text = out_node.GetChar("LOT_RES_FLAG").ToString();
                txtOOCType.Text = out_node.GetChar("OOC_TYPE").ToString();
                txtOOCDesc.Text = MPCF.SetRuleDescription(out_node.GetChar("OOC_TYPE"), out_node, 'X');
                txtOOCDesc2.Text = MPCF.SetRuleDescription(out_node.GetChar("OOC_TYPE2"), out_node, 'R');
                txtOOCType2.Text = out_node.GetChar("OOC_TYPE2").ToString();
                cdvTrbCode.Text = out_node.GetString("TRB_CODE");
                cdvTrbUser.Text = out_node.GetString("TRB_USER");


                if (out_node.GetString("TRB_TIME") == "")
                {
                    uccTrbDate.Value = DateTime.Now;
                    udtTrbTime.Value = DateTime.Now;
                }
                else
                {
                    if (out_node.GetString("TRB_TIME") != null)
                    {
                        uccTrbDate.Value = MPCF.ToDate(out_node.GetString("TRB_TIME"));
                        udtTrbTime.Value = MPCF.ToDate(out_node.GetString("TRB_TIME"));
                    }
                }

                txtTrbComment.Text = out_node.GetString("TRB_COMMENT");
                cdvActCode.Text = out_node.GetString("ACT_CODE");
                cdvActUser.Text = out_node.GetString("ACT_USER");

                if (out_node.GetString("ACT_TIME") == "")
                {
                    uccActDate.Value = DateTime.Now;
                    udtActTime.Value = DateTime.Now;
                }
                else
                {
                    if (out_node.GetString("ACT_TIME") != null)
                    {
                        uccActDate.Value = MPCF.ToDate(out_node.GetString("ACT_TIME"));
                        udtActTime.Value = MPCF.ToDate(out_node.GetString("ACT_TIME"));
                    }
                   
                   

                }
                txtActComment.Text = out_node.GetString("ACT_COMMENT");
                cdvInspector.Text = out_node.GetString("INSPECTOR");
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.View_OOC_History()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Update_OOC_History()
        //       - Update OOC History
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Update_OOC_History()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("OOC_History_In");
                TRSNode out_node = new TRSNode("Cmn_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(txtChart.Text));
                in_node.AddInt("HIST_SEQ", MPCF.ToInt(txtHistSeq.Text));

                in_node.AddString("TRB_CODE", MPCF.Trim(cdvTrbCode.Text));
                in_node.AddString("TRB_USER", MPCF.Trim(cdvTrbUser.Text), true);
                in_node.AddString("TRB_COMMENT", MPCF.Trim(txtTrbComment.Text));
                in_node.AddString("TRB_TIME", ((DateTime)uccTrbDate.Value).ToString("yyyyMMdd") + ((DateTime)udtTrbTime.Value).ToString("HHmmss"));
                in_node.AddString("ACT_CODE", MPCF.Trim(cdvActCode.Text));
                in_node.AddString("ACT_USER", MPCF.Trim(cdvActUser.Text), true);
                in_node.AddString("ACT_COMMENT", MPCF.Trim(txtActComment.Text));
                in_node.AddString("ACT_TIME", ((DateTime)uccActDate.Value).ToString("yyyyMMdd") + ((DateTime)udtActTime.Value).ToString("HHmmss"));
                in_node.AddString("INSPECTOR", MPCF.Trim(cdvInspector.Text));

                if (MPCR.CallService("SPC", "SPC_OOC_History", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.Update_OOC_History()\n" + ex.Message);
                return false;
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCTranUpdateOOCHistory_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                if (txtChart.Text == "")
                {
                    return;
                }
                if (ctrlChartData.ViewChartInformation(txtChart.Text, true) == false)
                {
                    return;
                }
                txtGraphType.Text = MPCF.GetGraphType((eGraphType)Enum.Parse(typeof(eGraphType), ctrlChartData.ChartGraphType), true);
                if (View_OOC_History() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.frmSPCTranUpdateOOCHistory_Load()\n" + ex.Message);
            }
            
        }
        
        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                if (CheckCondition() == false)
                {
                    return;
                }
                if (Update_OOC_History() == false)
                {
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.btnOK_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvActCode_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvActCode.Init();
                MPCF.InitListView(cdvActCode.GetListView);
                cdvActCode.Columns.Add("Action Code", 50, HorizontalAlignment.Left);
                cdvActCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvActCode.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvActCode.GetListView, '1', modSPCConstants.MP_SPC_ACTION_CODE);
                if (cdvActCode.AddEmptyRow(1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.cdvActCode_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvActUser_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvActUser.Init();
                MPCF.InitListView(cdvActUser.GetListView);
                cdvActUser.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvActUser.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvActUser.SelectedSubItemIndex = 0;
                SECLIST.ViewSECUserList(cdvActUser.GetListView, '1', -1, null, "", "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.cdvActUser_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvInspector_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvInspector.Init();
                MPCF.InitListView(cdvInspector.GetListView);
                cdvInspector.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvInspector.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvInspector.SelectedSubItemIndex = 0;
                SECLIST.ViewSECUserList(cdvInspector.GetListView, '1', -1, null, "", "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.cdvInspector_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvTrbCode_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvTrbCode.Init();
                MPCF.InitListView(cdvTrbCode.GetListView);
                cdvTrbCode.Columns.Add("Trouble Code", 50, HorizontalAlignment.Left);
                cdvTrbCode.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTrbCode.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvTrbCode.GetListView, '1', modSPCConstants.MP_SPC_TROUBLE_CODE);
                if (cdvTrbCode.AddEmptyRow(1) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.cdvTrbCode_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvTrbUser_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvTrbUser.Init();
                MPCF.InitListView(cdvTrbUser.GetListView);
                cdvTrbUser.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvTrbUser.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTrbUser.SelectedSubItemIndex = 0;
                SECLIST.ViewSECUserList(cdvTrbUser.GetListView, '1', -1, null, "", "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.cdvTrbUser_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                if (txtChart.Text == "")
                {
                    return;
                }
                if (ctrlChartData.ViewChartInformation(txtChart.Text, true) == false)
                {
                    return;
                }
                txtGraphType.Text = MPCF.GetGraphType((eGraphType)Enum.Parse(typeof(eGraphType), ctrlChartData.ChartGraphType), true);
                if (View_OOC_History() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranUpdateOOCHistory.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
