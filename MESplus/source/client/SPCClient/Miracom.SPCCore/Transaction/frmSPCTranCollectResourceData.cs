
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
using FarPoint.Win.Spread;
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCTranCollectResourceData.vb
//   Description : Collect Resource Data
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition : Check the conditions before transaction
//       - View_Resource : View Resource Information
//       - SetCollectData : Set Collection Information
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
    public class frmSPCTranCollectResourceData : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranCollectResourceData()
        {
            
            
            InitializeComponent();
            
            
            //Me.spdChartInfo.Tag = "Change Cell"
            
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
        



        protected System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.GroupBox grpChart;
        internal System.Windows.Forms.Label lblGraphType;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        internal System.Windows.Forms.Label lblChartID;
        internal System.Windows.Forms.GroupBox grpLot;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCharID;
        internal System.Windows.Forms.Label lblChar;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        internal System.Windows.Forms.Label lblResID;
        protected System.Windows.Forms.GroupBox grpLotID;
        protected System.Windows.Forms.Panel pnlTranTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTranTime;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtTranTime;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccTranDate;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkTranDateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDesc;
        protected System.Windows.Forms.Label lblLotDesc;
        internal System.Windows.Forms.Label lblEventID;
        internal System.Windows.Forms.Label lblLastEventTime;
        internal System.Windows.Forms.Label lblLastEvent;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLastEvent;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLastEventTime;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvEvent;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnGraph;
        internal System.Windows.Forms.Button btnRawData;
        internal System.Windows.Forms.Button btnClose;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Button btnHistogram;
        internal Miracom.SPCCore.udcChartInfo ctrlChartInfo;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvUserID;
        internal System.Windows.Forms.Label lblUserID;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewChart;
        internal System.Windows.Forms.Button btnFiltering;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranCollectResourceData));
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.chkViewChart = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnGraph = new System.Windows.Forms.Button();
            this.btnRawData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.ctrlChartInfo = new Miracom.SPCCore.udcChartInfo();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.lblGraphType = new System.Windows.Forms.Label();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.cdvUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUserID = new System.Windows.Forms.Label();
            this.cdvCharID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChar = new System.Windows.Forms.Label();
            this.cdvEvent = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEventID = new System.Windows.Forms.Label();
            this.txtLastEvent = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtLastEventTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLastEventTime = new System.Windows.Forms.Label();
            this.lblLastEvent = new System.Windows.Forms.Label();
            this.grpLotID = new System.Windows.Forms.GroupBox();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.udtTranTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccTranDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.chkTranDateTime = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewChart)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            this.grpLot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastEventTime)).BeginInit();
            this.grpLotID.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTranTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTranDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTranDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.chkViewChart);
            this.pnlBottom.Controls.Add(this.btnHistogram);
            this.pnlBottom.Controls.Add(this.btnReset);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnGraph);
            this.pnlBottom.Controls.Add(this.btnRawData);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 596);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlBottom.Size = new System.Drawing.Size(792, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // chkViewChart
            // 
            this.chkViewChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkViewChart.AutoSize = true;
            this.chkViewChart.Location = new System.Drawing.Point(47, 13);
            this.chkViewChart.Name = "chkViewChart";
            this.chkViewChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkViewChart.Size = new System.Drawing.Size(148, 17);
            this.chkViewChart.TabIndex = 8;
            this.chkViewChart.Text = "View Monitoring Chart";
            this.chkViewChart.CheckedChanged += new System.EventHandler(this.chkViewChart_CheckedChanged);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistogram.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHistogram.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHistogram.Location = new System.Drawing.Point(516, 8);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(88, 26);
            this.btnHistogram.TabIndex = 3;
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(330, 8);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 26);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(8, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(237, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraph.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGraph.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGraph.Location = new System.Drawing.Point(423, 8);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(88, 26);
            this.btnGraph.TabIndex = 2;
            this.btnGraph.Text = "Control Chart";
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // btnRawData
            // 
            this.btnRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRawData.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRawData.Location = new System.Drawing.Point(608, 8);
            this.btnRawData.Name = "btnRawData";
            this.btnRawData.Size = new System.Drawing.Size(88, 26);
            this.btnRawData.TabIndex = 4;
            this.btnRawData.Text = "Raw Data";
            this.btnRawData.Click += new System.EventHandler(this.btnRawData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(700, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.ctrlChartInfo);
            this.pnlCenter.Controls.Add(this.grpChart);
            this.pnlCenter.Controls.Add(this.grpLot);
            this.pnlCenter.Controls.Add(this.grpLotID);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(792, 596);
            this.pnlCenter.TabIndex = 0;
            // 
            // ctrlChartInfo
            // 
            this.ctrlChartInfo.AutoScroll = true;
            this.ctrlChartInfo.CharID = "";
            this.ctrlChartInfo.ChartID = "";
            this.ctrlChartInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlChartInfo.EventID = "";
            this.ctrlChartInfo.Flow = "";
            this.ctrlChartInfo.FlowSeq = 0;
            this.ctrlChartInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlChartInfo.GraphTypeIndex = 0;
            this.ctrlChartInfo.GroupIndex = -1;
            this.ctrlChartInfo.IsBackTime = false;
            this.ctrlChartInfo.Location = new System.Drawing.Point(3, 219);
            this.ctrlChartInfo.LotID = "";
            this.ctrlChartInfo.LotIndex = -1;
            this.ctrlChartInfo.LotResFlag = ' ';
            this.ctrlChartInfo.MatID = "";
            this.ctrlChartInfo.MatVer = 0;
            this.ctrlChartInfo.Name = "ctrlChartInfo";
            this.ctrlChartInfo.Oper = "";
            this.ctrlChartInfo.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ctrlChartInfo.ProcOper = "";
            this.ctrlChartInfo.ProcResID = "";
            this.ctrlChartInfo.ResID = "";
            this.ctrlChartInfo.SelectMFOFlag = ' ';
            this.ctrlChartInfo.Size = new System.Drawing.Size(786, 377);
            this.ctrlChartInfo.TabIndex = 3;
            this.ctrlChartInfo.TranTime = "";
            this.ctrlChartInfo.UserID = "";
            this.ctrlChartInfo.ViewChart = "";
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.btnFiltering);
            this.grpChart.Controls.Add(this.lblGraphType);
            this.grpChart.Controls.Add(this.cdvChartID);
            this.grpChart.Controls.Add(this.lblChartID);
            this.grpChart.Controls.Add(this.cboGraphType);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(3, 171);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(786, 48);
            this.grpChart.TabIndex = 2;
            this.grpChart.TabStop = false;
            // 
            // btnFiltering
            // 
            this.btnFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering.Image")));
            this.btnFiltering.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering.Location = new System.Drawing.Point(328, 14);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 2;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // lblGraphType
            // 
            this.lblGraphType.AutoSize = true;
            this.lblGraphType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGraphType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGraphType.Location = new System.Drawing.Point(411, 19);
            this.lblGraphType.Name = "lblGraphType";
            this.lblGraphType.Size = new System.Drawing.Size(63, 13);
            this.lblGraphType.TabIndex = 3;
            this.lblGraphType.Text = "Graph Type";
            // 
            // cdvChartID
            // 
            this.cdvChartID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartID.BtnToolTipText = "";
            this.cdvChartID.DescText = "";
            this.cdvChartID.DisplaySubItemIndex = -1;
            this.cdvChartID.DisplayText = "";
            this.cdvChartID.Focusing = null;
            this.cdvChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartID.Index = 0;
            this.cdvChartID.IsViewBtnImage = false;
            this.cdvChartID.Location = new System.Drawing.Point(124, 16);
            this.cdvChartID.MaxLength = 30;
            this.cdvChartID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.Name = "cdvChartID";
            this.cdvChartID.ReadOnly = false;
            this.cdvChartID.SearchSubItemIndex = 0;
            this.cdvChartID.SelectedDescIndex = -1;
            this.cdvChartID.SelectedSubItemIndex = -1;
            this.cdvChartID.SelectionStart = 0;
            this.cdvChartID.Size = new System.Drawing.Size(200, 20);
            this.cdvChartID.SmallImageList = null;
            this.cdvChartID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartID.TabIndex = 1;
            this.cdvChartID.TextBoxToolTipText = "";
            this.cdvChartID.TextBoxWidth = 200;
            this.cdvChartID.VisibleButton = true;
            this.cdvChartID.VisibleColumnHeader = false;
            this.cdvChartID.VisibleDescription = false;
            this.cdvChartID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartID_SelectedItemChanged);
            this.cdvChartID.ButtonPress += new System.EventHandler(this.cdvChartID_ButtonPress);
            this.cdvChartID.TextBoxTextChanged += new System.EventHandler(this.cdvChartID_TextBoxTextChanged);
            // 
            // lblChartID
            // 
            this.lblChartID.AutoSize = true;
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 19);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(54, 13);
            this.lblChartID.TabIndex = 0;
            this.lblChartID.Text = "Chart ID";
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cboGraphType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboGraphType.Location = new System.Drawing.Point(520, 17);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.ReadOnly = true;
            this.cboGraphType.Size = new System.Drawing.Size(200, 19);
            this.cboGraphType.TabIndex = 4;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.cdvUserID);
            this.grpLot.Controls.Add(this.lblUserID);
            this.grpLot.Controls.Add(this.cdvCharID);
            this.grpLot.Controls.Add(this.lblChar);
            this.grpLot.Controls.Add(this.cdvEvent);
            this.grpLot.Controls.Add(this.lblEventID);
            this.grpLot.Controls.Add(this.txtLastEvent);
            this.grpLot.Controls.Add(this.txtLastEventTime);
            this.grpLot.Controls.Add(this.lblLastEventTime);
            this.grpLot.Controls.Add(this.lblLastEvent);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLot.Location = new System.Drawing.Point(3, 72);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(786, 99);
            this.grpLot.TabIndex = 1;
            this.grpLot.TabStop = false;
            // 
            // cdvUserID
            // 
            this.cdvUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUserID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUserID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUserID.BtnToolTipText = "";
            this.cdvUserID.DescText = "";
            this.cdvUserID.DisplaySubItemIndex = -1;
            this.cdvUserID.DisplayText = "";
            this.cdvUserID.Focusing = null;
            this.cdvUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUserID.Index = 0;
            this.cdvUserID.IsViewBtnImage = false;
            this.cdvUserID.Location = new System.Drawing.Point(520, 65);
            this.cdvUserID.MaxLength = 20;
            this.cdvUserID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.Name = "cdvUserID";
            this.cdvUserID.ReadOnly = false;
            this.cdvUserID.SearchSubItemIndex = 0;
            this.cdvUserID.SelectedDescIndex = -1;
            this.cdvUserID.SelectedSubItemIndex = -1;
            this.cdvUserID.SelectionStart = 0;
            this.cdvUserID.Size = new System.Drawing.Size(200, 20);
            this.cdvUserID.SmallImageList = null;
            this.cdvUserID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUserID.TabIndex = 9;
            this.cdvUserID.TextBoxToolTipText = "";
            this.cdvUserID.TextBoxWidth = 200;
            this.cdvUserID.VisibleButton = true;
            this.cdvUserID.VisibleColumnHeader = false;
            this.cdvUserID.VisibleDescription = false;
            this.cdvUserID.ButtonPress += new System.EventHandler(this.cdvUserID_ButtonPress);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(411, 68);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(50, 13);
            this.lblUserID.TabIndex = 8;
            this.lblUserID.Text = "User ID";
            this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCharID
            // 
            this.cdvCharID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCharID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCharID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCharID.BtnToolTipText = "";
            this.cdvCharID.DescText = "";
            this.cdvCharID.DisplaySubItemIndex = -1;
            this.cdvCharID.DisplayText = "";
            this.cdvCharID.Focusing = null;
            this.cdvCharID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCharID.Index = 0;
            this.cdvCharID.IsViewBtnImage = false;
            this.cdvCharID.Location = new System.Drawing.Point(124, 41);
            this.cdvCharID.MaxLength = 25;
            this.cdvCharID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCharID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCharID.Name = "cdvCharID";
            this.cdvCharID.ReadOnly = false;
            this.cdvCharID.SearchSubItemIndex = 0;
            this.cdvCharID.SelectedDescIndex = -1;
            this.cdvCharID.SelectedSubItemIndex = -1;
            this.cdvCharID.SelectionStart = 0;
            this.cdvCharID.Size = new System.Drawing.Size(200, 20);
            this.cdvCharID.SmallImageList = null;
            this.cdvCharID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCharID.TabIndex = 5;
            this.cdvCharID.TextBoxToolTipText = "";
            this.cdvCharID.TextBoxWidth = 200;
            this.cdvCharID.VisibleButton = true;
            this.cdvCharID.VisibleColumnHeader = false;
            this.cdvCharID.VisibleDescription = false;
            this.cdvCharID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCharID_SelectedItemChanged);
            this.cdvCharID.ButtonPress += new System.EventHandler(this.cdvCharID_ButtonPress);
            // 
            // lblChar
            // 
            this.lblChar.AutoSize = true;
            this.lblChar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChar.Location = new System.Drawing.Point(15, 44);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(67, 13);
            this.lblChar.TabIndex = 4;
            this.lblChar.Text = "Character ID";
            // 
            // cdvEvent
            // 
            this.cdvEvent.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEvent.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEvent.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEvent.BtnToolTipText = "";
            this.cdvEvent.DescText = "";
            this.cdvEvent.DisplaySubItemIndex = -1;
            this.cdvEvent.DisplayText = "";
            this.cdvEvent.Focusing = null;
            this.cdvEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEvent.Index = 0;
            this.cdvEvent.IsViewBtnImage = false;
            this.cdvEvent.Location = new System.Drawing.Point(520, 41);
            this.cdvEvent.MaxLength = 12;
            this.cdvEvent.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEvent.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEvent.Name = "cdvEvent";
            this.cdvEvent.ReadOnly = false;
            this.cdvEvent.SearchSubItemIndex = 0;
            this.cdvEvent.SelectedDescIndex = -1;
            this.cdvEvent.SelectedSubItemIndex = -1;
            this.cdvEvent.SelectionStart = 0;
            this.cdvEvent.Size = new System.Drawing.Size(200, 20);
            this.cdvEvent.SmallImageList = null;
            this.cdvEvent.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEvent.TabIndex = 7;
            this.cdvEvent.TextBoxToolTipText = "";
            this.cdvEvent.TextBoxWidth = 200;
            this.cdvEvent.VisibleButton = true;
            this.cdvEvent.VisibleColumnHeader = false;
            this.cdvEvent.VisibleDescription = false;
            this.cdvEvent.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvEvent_SelectedItemChanged);
            this.cdvEvent.ButtonPress += new System.EventHandler(this.cdvEvent_ButtonPress);
            this.cdvEvent.TextBoxTextChanged += new System.EventHandler(this.cdvEvent_TextBoxTextChanged);
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEventID.Location = new System.Drawing.Point(411, 44);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(35, 13);
            this.lblEventID.TabIndex = 6;
            this.lblEventID.Text = "Event";
            // 
            // txtLastEvent
            // 
            this.txtLastEvent.Location = new System.Drawing.Point(124, 16);
            this.txtLastEvent.MaxLength = 12;
            this.txtLastEvent.Name = "txtLastEvent";
            this.txtLastEvent.ReadOnly = true;
            this.txtLastEvent.Size = new System.Drawing.Size(200, 20);
            this.txtLastEvent.TabIndex = 1;
            // 
            // txtLastEventTime
            // 
            this.txtLastEventTime.Location = new System.Drawing.Point(520, 16);
            this.txtLastEventTime.MaxLength = 20;
            this.txtLastEventTime.Name = "txtLastEventTime";
            this.txtLastEventTime.ReadOnly = true;
            this.txtLastEventTime.Size = new System.Drawing.Size(200, 20);
            this.txtLastEventTime.TabIndex = 3;
            // 
            // lblLastEventTime
            // 
            this.lblLastEventTime.AutoSize = true;
            this.lblLastEventTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEventTime.Location = new System.Drawing.Point(411, 19);
            this.lblLastEventTime.Name = "lblLastEventTime";
            this.lblLastEventTime.Size = new System.Drawing.Size(84, 13);
            this.lblLastEventTime.TabIndex = 2;
            this.lblLastEventTime.Text = "Last Event Time";
            // 
            // lblLastEvent
            // 
            this.lblLastEvent.AutoSize = true;
            this.lblLastEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastEvent.Location = new System.Drawing.Point(15, 19);
            this.lblLastEvent.Name = "lblLastEvent";
            this.lblLastEvent.Size = new System.Drawing.Size(58, 13);
            this.lblLastEvent.TabIndex = 0;
            this.lblLastEvent.Text = "Last Event";
            // 
            // grpLotID
            // 
            this.grpLotID.Controls.Add(this.pnlTranTime);
            this.grpLotID.Controls.Add(this.txtDesc);
            this.grpLotID.Controls.Add(this.lblLotDesc);
            this.grpLotID.Controls.Add(this.lblResID);
            this.grpLotID.Controls.Add(this.cdvResID);
            this.grpLotID.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotID.Location = new System.Drawing.Point(3, 0);
            this.grpLotID.Name = "grpLotID";
            this.grpLotID.Size = new System.Drawing.Size(786, 72);
            this.grpLotID.TabIndex = 0;
            this.grpLotID.TabStop = false;
            // 
            // pnlTranTime
            // 
            this.pnlTranTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTranTime.Controls.Add(this.txtTranTime);
            this.pnlTranTime.Controls.Add(this.udtTranTime);
            this.pnlTranTime.Controls.Add(this.uccTranDate);
            this.pnlTranTime.Controls.Add(this.chkTranDateTime);
            this.pnlTranTime.Location = new System.Drawing.Point(478, 14);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 23);
            this.pnlTranTime.TabIndex = 2;
            // 
            // txtTranTime
            // 
            this.txtTranTime.Location = new System.Drawing.Point(128, 1);
            this.txtTranTime.MaxLength = 30;
            this.txtTranTime.Name = "txtTranTime";
            this.txtTranTime.ReadOnly = true;
            this.txtTranTime.Size = new System.Drawing.Size(168, 20);
            this.txtTranTime.TabIndex = 1;
            // 
            // udtTranTime
            // 
            this.udtTranTime.DateTime = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            this.udtTranTime.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtTranTime.FormatString = "";
            this.udtTranTime.Location = new System.Drawing.Point(220, 1);
            this.udtTranTime.MaskInput = "hh:mm:ss";
            this.udtTranTime.Name = "udtTranTime";
            this.udtTranTime.Size = new System.Drawing.Size(72, 21);
            this.udtTranTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtTranTime.SpinWrap = true;
            this.udtTranTime.TabIndex = 2;
            this.udtTranTime.Value = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            // 
            // uccTranDate
            // 
            this.uccTranDate.DateButtons.Add(dateButton1);
            this.uccTranDate.Location = new System.Drawing.Point(128, 1);
            this.uccTranDate.Name = "uccTranDate";
            this.uccTranDate.NonAutoSizeHeight = 21;
            this.uccTranDate.Size = new System.Drawing.Size(88, 21);
            this.uccTranDate.TabIndex = 2;
            this.uccTranDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // chkTranDateTime
            // 
            this.chkTranDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTranDateTime.AutoSize = true;
            this.chkTranDateTime.Location = new System.Drawing.Point(3, 3);
            this.chkTranDateTime.Name = "chkTranDateTime";
            this.chkTranDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTranDateTime.Size = new System.Drawing.Size(121, 17);
            this.chkTranDateTime.TabIndex = 0;
            this.chkTranDateTime.Text = "Transaction Time";
            this.chkTranDateTime.CheckedChanged += new System.EventHandler(this.chkTranDateTime_CheckedChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(124, 41);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(650, 20);
            this.txtDesc.TabIndex = 4;
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotDesc.Location = new System.Drawing.Point(15, 44);
            this.lblLotDesc.Name = "lblLotDesc";
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            this.lblLotDesc.TabIndex = 3;
            this.lblLotDesc.Text = "Description";
            this.lblLotDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvResID.Location = new System.Drawing.Point(124, 16);
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
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // frmSPCTranCollectResourceData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 636);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 670);
            this.Name = "frmSPCTranCollectResourceData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Collect Resource Data";
            this.Activated += new System.EventHandler(this.frmSPCTranCollectResourceData_Activated);
            this.Load += new System.EventHandler(this.frmSPCTranCollectResourceData_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewChart)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            this.grpLot.ResumeLayout(false);
            this.grpLot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastEventTime)).EndInit();
            this.grpLotID.ResumeLayout(false);
            this.grpLotID.PerformLayout();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTranTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTranDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTranDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag = false;
        
        #endregion
        
        #region " Constant Definition"
        
        #endregion
        
        #region " Funcion Definition"
        
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
                if (cdvResID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvResID.Focus();
                    return false;
                }
                if (cdvChartID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvChartID.Focus();
                    return false;
                }
                if (ctrlChartInfo.ctrlChartData.ValueType == "N")
                {
                    if (cboGraphType.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cboGraphType.Focus();
                        return false;
                    }
                }
                if (MPCF.CheckValue(cdvUserID, 1) == false)
                {
                    return false;
                }
                if (ctrlChartInfo.CheckCondition() == false)
                {
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Resource()
        //       - View Resource Information
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //       -
        //
        private bool View_Resource()
        {
            TRSNode in_node = new TRSNode("View_Resource_In");
            TRSNode out_node = new TRSNode("View_Resource_Out");
            
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", cdvResID.Text);

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = out_node.GetString("RES_DESC");
                txtLastEvent.Text = out_node.GetString("LAST_EVENT");
                txtLastEventTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_EVENT_TIME"));
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.View_Resource()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetCollectData()
        //       - Set Collection Data
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void SetCollectData()
        {
            
            try
            {
                ctrlChartInfo.ChartID = MPCF.Trim(cdvChartID.Text);
                ctrlChartInfo.LotResFlag = 'R';
                ctrlChartInfo.ResID = MPCF.Trim(cdvResID.Text);
                ctrlChartInfo.EventID = MPCF.Trim(cdvEvent.Text);
                ctrlChartInfo.CharID = MPCF.Trim(cdvCharID.Text);
                ctrlChartInfo.TranTime = ((DateTime)uccTranDate.Value).ToString("yyyyMMdd") + ((DateTime)udtTranTime.Value).ToString("HHmmss");
                ctrlChartInfo.UserID = MPCF.Trim(cdvUserID.Text);
                
                if (chkTranDateTime.Checked == true)
                {
                    ctrlChartInfo.IsBackTime = true;
                }
                else
                {
                    ctrlChartInfo.IsBackTime = false;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.SetCollectData()\n" + ex.Message);
            }
            
        }
        
        
        private bool View_Event()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Event_In");
                TRSNode out_node = new TRSNode("View_Event_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("EVENT_ID", cdvEvent.Text);

                if (MPCR.CallService("RAS", "RAS_View_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
                if (MPCF.Trim(out_node.GetChar("CHART_FLAG")) == "C" && MPCF.Trim(out_node.GetString("CHART_ID")) != "")
                {
                    
                   cdvChartID.Text = out_node.GetString("CHART_ID");
                   cdvChartID_SelectedItemChanged(cdvChartID, null);
                }
                else
                {
                    cdvChartID.Text = "";
                }
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.View_Event()\n" + ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvResID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        private void ChartInfo()
        {
            
            try
            {
                cdvChartID_SelectedItemChanged(null, null);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.ChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void cdvResID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
                if (RASLIST.ViewResourceList(cdvResID.GetListView, false) == false)
                {
                    return;
                }
                cdvResID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvResID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvCharID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvCharID.Init();
                MPCF.InitListView(cdvCharID.GetListView);
                cdvCharID.Columns.Add("CharID", 50, HorizontalAlignment.Left);
                cdvCharID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvCharID.SelectedSubItemIndex = 0;
                if (EDCLIST.ViewEDCCharacterList(cdvCharID.GetListView, '1', 'E') == false)
                {
                    return;
                }
                cdvCharID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvCharID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvResID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                ctrlChartInfo.ClearControl();
                MPCF.FieldClear(this.pnlCenter, cdvResID, null, null, null, null, false);
                if (cdvResID.Text == "")
                {
                    return;
                }
                View_Resource();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvResID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvEvent_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvEvent.Init();
                MPCF.InitListView(cdvEvent.GetListView);
                cdvEvent.Columns.Add("EventID", 50, HorizontalAlignment.Left);
                cdvEvent.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvEvent.SelectedSubItemIndex = 0;
                if (RASLIST.ViewResEventList(cdvEvent.GetListView, '1', cdvResID.Text, null, "") == false)
                {
                    return;
                }
                cdvEvent.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvEvent_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartID.Init();
                MPCF.InitListView(cdvChartID.GetListView);
                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartID.SelectedSubItemIndex = 0;
                if (SPCLIST.ViewChartList(cdvChartID.GetListView, '2', "", 0, "", cdvResID.Text, cdvCharID.Text, 'R', ' ', "", "", 'Y', -1, -1, null, "") == false)
                {
                    return;
                }
                cdvChartID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvChartID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                ctrlChartInfo.ChartID = MPCF.Trim(cdvChartID.Text);
                ctrlChartInfo.ViewChartInfo(true);
                if (ctrlChartInfo.ViewChart == "Y")
                {
                    ctrlChartInfo.InitChart();
                    ctrlChartInfo.ViewControlChart(true);
                }
                
                cboGraphType.SelectedIndex = ctrlChartInfo.GraphTypeIndex;
                cdvCharID.Text = ctrlChartInfo.ctrlChartData.Character;
                btnOK.Enabled = true;
                cdvUserID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvChartID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranCollectResourceData_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                MPCF.SetTextboxStyle(this.Controls);
                uccTranDate.Value = DateTime.Now;
                udtTranTime.Value = DateTime.Now;
                modSPCFunctions.SetGraphList(cboGraphType);
                pnlTranTime.Visible = MPGO.UseBackDate();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.frmSPCTranCollectResourceData_Load()\n" + ex.Message);
            }
            
        }
        
        private void cdvCharID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                ctrlChartInfo.ClearControl();
                MPCF.FieldClear(this.grpChart);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvCharID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                ctrlChartInfo.ClearBackColor();
                SetCollectData();
                if (ctrlChartInfo.CollectEDCData(MPGC.MP_STEP_TRAN) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.btnOK_Click()\n" + ex.Message);
            }
            
        }
        
        private void chkTranDateTime_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                txtTranTime.Visible = ! chkTranDateTime.Checked;
                
                uccTranDate.Enabled = chkTranDateTime.Checked;
                udtTranTime.Enabled = chkTranDateTime.Checked;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.chkTranDateTime_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranCollectResourceData_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    if (MPCF.Trim(MPGV.gsCurrentRes_ID) != "")
                    {
                        cdvResID.Text = MPGV.gsCurrentRes_ID;
                        if (View_Resource() == false)
                        {
                            return;
                        }
                    }
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.frmSPCTranCollectResourceData_Activated()\n" + ex.Message);
            }
            
        }
        
        private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                ctrlChartInfo.ClearControl();
                MPCF.FieldClear(this.pnlCenter, cdvResID, null, null, null, null, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvResID_TextBoxTextChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvUserID.Text = "";
                if (ctrlChartInfo.ViewChart == "Y")
                {
                    ctrlChartInfo.ViewControlChart(false);
                }
                ctrlChartInfo.ViewChartInfo(true);
                btnOK.Enabled = true;
                if (ctrlChartInfo.ViewChart == "Y")
                {
                    ctrlChartInfo.InitChart();
                    ctrlChartInfo.ViewControlChart(true);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnReset_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvUserID.Text = "";
                ctrlChartInfo.GetSpreadData.Sheets[0].ClearRange(0, 0, ctrlChartInfo.GetSpreadData.Sheets[0].RowCount, ctrlChartInfo.GetSpreadData.Sheets[0].ColumnCount, true);
                ctrlChartInfo.SetLockSpread(false);
                ctrlChartInfo.ClearBackColor();
                btnOK.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.btnReset_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnGraph_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvChartID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvChartID.Focus();
                    return;
                }
                
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranControlChart");
                    if (form == null)
                    {
                        form = new frmSPCTranControlChart();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                
                ((frmSPCTranControlChart) form).uccStart.Value = DateTime.Now;
                ((frmSPCTranControlChart) form).udtStart.Value = "000000";
                ((frmSPCTranControlChart) form).uccEnd.Value = DateTime.Now;
                ((frmSPCTranControlChart) form).udtEnd.Value = "235959";
                ((frmSPCTranControlChart) form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCTranControlChart) form).cdvChartID.Text != "")
                {
                    ((frmSPCTranControlChart) form).ChartIDSelected();
                    ((frmSPCTranControlChart) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.btnGraph_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRawData_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvChartID.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvChartID.Focus();
                    return;
                }
                
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCViewEDCData");
                    if (form == null)
                    {
                        form = new frmSPCViewEDCData();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                
                ((frmSPCViewEDCData) form).uccStart.Value = DateTime.Now;
                ((frmSPCViewEDCData) form).udtStart.Value = "000000";
                ((frmSPCViewEDCData) form).uccEnd.Value = DateTime.Now;
                ((frmSPCViewEDCData) form).udtEnd.Value = "235959";
                ((frmSPCViewEDCData) form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCViewEDCData) form).cdvChartID.Text != "")
                {
                    ((frmSPCViewEDCData) form).Set_Data();
                    ((frmSPCViewEDCData) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.btnRawData_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnHistogram_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                System.Windows.Forms.Form form;

                try
                {
                    form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranCapability");
                    if (form == null)
                    {
                        form = new frmSPCTranCapability();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }

                ((frmSPCTranCapability) form).uccStart.Value = DateTime.Now;
                ((frmSPCTranCapability) form).udtStart.Value = "000000";
                ((frmSPCTranCapability) form).uccEnd.Value = DateTime.Now;
                ((frmSPCTranCapability) form).udtEnd.Value = "235959";
                ((frmSPCTranCapability) form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCTranCapability) form).cdvChartID.Text != "")
                {
                    ((frmSPCTranCapability) form).ChartIDSelected();
                    ((frmSPCTranCapability) form).btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.btnHistogram_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                ctrlChartInfo.ClearControl();
                MPCF.FieldClear(this.grpChart, cdvChartID, null, null, null, null, false);
                cdvUserID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvChartID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvEvent_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (MPCF.Trim(cdvEvent.Text) != "" && MPGV.gsSPCType == "2")
                {
                    View_Event();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvEvent_SelectedItemChanged()\n" + ex.Message);
            }
        }
        
        private void cdvEvent_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                ctrlChartInfo.ClearControl();
                MPCF.FieldClear(this.grpChart, cdvChartID, null, null, null, null, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvEvent_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvUserID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvUserID.Init();
                if (MPCF.CheckValue(cdvChartID, 1) == false)
                {
                    return;
                }
                MPCF.InitListView(cdvUserID.GetListView);
                cdvUserID.Columns.Add("UserID", 50, HorizontalAlignment.Left);
                cdvUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvUserID.SelectedSubItemIndex = 0;
                SPCLIST.ViewSPCAttachUserList(cdvUserID.GetListView, '1', cdvChartID.Text, "");
                cdvUserID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectResourceData.cdvUserID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.cboLotorRes.ReadOnly = true;
                form.cboLotorRes.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
                form.cboLotorRes.SelectedIndex = 2;
                form.cdvResID.Text = cdvResID.Text;
                form.cdvResID.Enabled = false;
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.lisChart.SelectedItems.Count > 0)
                    {
                        cdvChartID.Text = form.lisChart.SelectedItems[0].SubItems[1].Text;
                        ChartInfo();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnFiltering_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion

        private void chkViewChart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewChart.Checked == true)
            {
                if (MPCF.Trim(ctrlChartInfo.ChartGraphType) == "")
                    return;

                ctrlChartInfo.ViewChart = "Y";

                ctrlChartInfo.InitChart();
                ctrlChartInfo.ViewControlChart(true);
            }
            else
            {
                ctrlChartInfo.ViewChart = "";
            }
        }
        
    }
    
    
    //#End If
    
}
