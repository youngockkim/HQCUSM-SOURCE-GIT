
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
//   File Name   : frmSPCTranCollectLotData.vb
//   Description : Collect Lot Data
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition : Check the conditions before transaction
//       - View_Lot : View Lot Information
//       - SetCollectData : Set Collection Data
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
    public class frmSPCTranCollectLotData : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranCollectLotData()
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
        internal System.Windows.Forms.GroupBox grpChart;
        internal System.Windows.Forms.Label lblGraphType;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        internal System.Windows.Forms.Label lblChartID;
        internal System.Windows.Forms.GroupBox grpLot;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCharID;
        internal System.Windows.Forms.Label lblChar;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvProcResID;
        internal System.Windows.Forms.Label lblProcResID;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvProcOper;
        internal System.Windows.Forms.Label lblProcOper;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        internal System.Windows.Forms.Label lblResID;
        internal System.Windows.Forms.Label lblOper;
        protected System.Windows.Forms.GroupBox grpLotID;
        protected System.Windows.Forms.Panel pnlTranTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTranTime;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtTranTime;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccTranDate;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkTranDateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLot;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDesc;
        protected System.Windows.Forms.Label lblLotDesc;
        protected System.Windows.Forms.Label lblLotID;
        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnRawData;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnGraph;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Button btnHistogram;
        internal Miracom.SPCCore.udcChartInfo ctrlChartInfo;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvUserID;
        internal System.Windows.Forms.Label lblUserID;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkSelectMFO;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvOper;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        protected Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewChart;
        internal System.Windows.Forms.Button btnFiltering;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranCollectLotData));
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
            this.lblChartID = new System.Windows.Forms.Label();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.grpLot = new System.Windows.Forms.GroupBox();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.chkSelectMFO = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.cdvUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUserID = new System.Windows.Forms.Label();
            this.cdvCharID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChar = new System.Windows.Forms.Label();
            this.cdvProcResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcResID = new System.Windows.Forms.Label();
            this.cdvProcOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcOper = new System.Windows.Forms.Label();
            this.cdvOper = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.grpLotID = new System.Windows.Forms.GroupBox();
            this.pnlTranTime = new System.Windows.Forms.Panel();
            this.txtTranTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.udtTranTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccTranDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.chkTranDateTime = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtLot = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLotDesc = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewChart)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            this.grpLot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectMFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.grpLotID.SuspendLayout();
            this.pnlTranTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTranTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTranDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTranDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
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
            this.chkViewChart.TabIndex = 7;
            this.chkViewChart.Text = "View Monitoring Chart";
            this.chkViewChart.CheckedChanged += new System.EventHandler(this.chkViewChart_CheckedChanged);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistogram.FlatStyle = System.Windows.Forms.FlatStyle.System;
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
            this.ctrlChartInfo.Location = new System.Drawing.Point(3, 264);
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
            this.ctrlChartInfo.Size = new System.Drawing.Size(786, 332);
            this.ctrlChartInfo.TabIndex = 3;
            this.ctrlChartInfo.TranTime = "";
            this.ctrlChartInfo.UserID = "";
            this.ctrlChartInfo.ViewChart = "";
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.btnFiltering);
            this.grpChart.Controls.Add(this.lblGraphType);
            this.grpChart.Controls.Add(this.lblChartID);
            this.grpChart.Controls.Add(this.cboGraphType);
            this.grpChart.Controls.Add(this.cdvChartID);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(3, 216);
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
            this.btnFiltering.TabIndex = 1;
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
            this.lblGraphType.TabIndex = 2;
            this.lblGraphType.Text = "Graph Type";
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
            this.cboGraphType.Location = new System.Drawing.Point(524, 17);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.ReadOnly = true;
            this.cboGraphType.Size = new System.Drawing.Size(200, 19);
            this.cboGraphType.TabIndex = 2;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
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
            this.cdvChartID.TabIndex = 0;
            this.cdvChartID.TextBoxToolTipText = "";
            this.cdvChartID.TextBoxWidth = 200;
            this.cdvChartID.VisibleButton = true;
            this.cdvChartID.VisibleColumnHeader = false;
            this.cdvChartID.VisibleDescription = false;
            this.cdvChartID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartID_SelectedItemChanged);
            this.cdvChartID.ButtonPress += new System.EventHandler(this.cdvChartID_ButtonPress);
            this.cdvChartID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvChartID_TextBoxKeyPress);
            this.cdvChartID.TextBoxTextChanged += new System.EventHandler(this.cdvChartID_TextBoxTextChanged);
            // 
            // grpLot
            // 
            this.grpLot.Controls.Add(this.cdvFlow);
            this.grpLot.Controls.Add(this.cdvMaterial);
            this.grpLot.Controls.Add(this.chkSelectMFO);
            this.grpLot.Controls.Add(this.cdvUserID);
            this.grpLot.Controls.Add(this.lblUserID);
            this.grpLot.Controls.Add(this.cdvCharID);
            this.grpLot.Controls.Add(this.lblChar);
            this.grpLot.Controls.Add(this.cdvProcResID);
            this.grpLot.Controls.Add(this.lblProcResID);
            this.grpLot.Controls.Add(this.cdvProcOper);
            this.grpLot.Controls.Add(this.lblProcOper);
            this.grpLot.Controls.Add(this.cdvOper);
            this.grpLot.Controls.Add(this.cdvResID);
            this.grpLot.Controls.Add(this.lblResID);
            this.grpLot.Controls.Add(this.lblOper);
            this.grpLot.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLot.Location = new System.Drawing.Point(3, 73);
            this.grpLot.Name = "grpLot";
            this.grpLot.Size = new System.Drawing.Size(786, 143);
            this.grpLot.TabIndex = 1;
            this.grpLot.TabStop = false;
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
            this.cdvFlow.LabelWidth = 111;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = ' ';
            this.cdvFlow.Location = new System.Drawing.Point(409, 39);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(310, 20);
            this.cdvFlow.TabIndex = 2;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 199;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_FlowSelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
            this.cdvFlow.FlowTextChanged += new System.EventHandler(this.cdvFlow_FlowTextChanged);
            this.cdvFlow.SeqButtonPress += new System.EventHandler(this.cdvFlow_SeqButtonPress);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.DisplaySubItemIndex = -1;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(14, 39);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = true;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = -1;
            this.cdvMaterial.Size = new System.Drawing.Size(310, 20);
            this.cdvMaterial.TabIndex = 1;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = false;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 110;
            this.cdvMaterial.WidthMaterialAndVersion = 200;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // chkSelectMFO
            // 
            this.chkSelectMFO.AutoSize = true;
            this.chkSelectMFO.Location = new System.Drawing.Point(15, 16);
            this.chkSelectMFO.Name = "chkSelectMFO";
            this.chkSelectMFO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSelectMFO.Size = new System.Drawing.Size(110, 17);
            this.chkSelectMFO.TabIndex = 0;
            this.chkSelectMFO.Text = "Select Lot MFO";
            this.chkSelectMFO.CheckedChanged += new System.EventHandler(this.chkSelectMFO_CheckedChanged);
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
            this.cdvUserID.Location = new System.Drawing.Point(520, 111);
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
            this.cdvUserID.TabIndex = 8;
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
            this.lblUserID.Location = new System.Drawing.Point(411, 115);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(50, 13);
            this.lblUserID.TabIndex = 14;
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
            this.cdvCharID.Location = new System.Drawing.Point(124, 111);
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
            this.cdvCharID.TabIndex = 7;
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
            this.lblChar.Location = new System.Drawing.Point(15, 115);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(67, 13);
            this.lblChar.TabIndex = 12;
            this.lblChar.Text = "Character ID";
            // 
            // cdvProcResID
            // 
            this.cdvProcResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcResID.BtnToolTipText = "";
            this.cdvProcResID.DescText = "";
            this.cdvProcResID.DisplaySubItemIndex = -1;
            this.cdvProcResID.DisplayText = "";
            this.cdvProcResID.Focusing = null;
            this.cdvProcResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcResID.Index = 0;
            this.cdvProcResID.IsViewBtnImage = false;
            this.cdvProcResID.Location = new System.Drawing.Point(520, 87);
            this.cdvProcResID.MaxLength = 20;
            this.cdvProcResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvProcResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvProcResID.Name = "cdvProcResID";
            this.cdvProcResID.ReadOnly = false;
            this.cdvProcResID.SearchSubItemIndex = 0;
            this.cdvProcResID.SelectedDescIndex = -1;
            this.cdvProcResID.SelectedSubItemIndex = -1;
            this.cdvProcResID.SelectionStart = 0;
            this.cdvProcResID.Size = new System.Drawing.Size(200, 20);
            this.cdvProcResID.SmallImageList = null;
            this.cdvProcResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcResID.TabIndex = 6;
            this.cdvProcResID.TextBoxToolTipText = "";
            this.cdvProcResID.TextBoxWidth = 200;
            this.cdvProcResID.VisibleButton = true;
            this.cdvProcResID.VisibleColumnHeader = false;
            this.cdvProcResID.VisibleDescription = false;
            this.cdvProcResID.ButtonPress += new System.EventHandler(this.cdvProcResID_ButtonPress);
            // 
            // lblProcResID
            // 
            this.lblProcResID.AutoSize = true;
            this.lblProcResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcResID.Location = new System.Drawing.Point(411, 91);
            this.lblProcResID.Name = "lblProcResID";
            this.lblProcResID.Size = new System.Drawing.Size(108, 13);
            this.lblProcResID.TabIndex = 10;
            this.lblProcResID.Text = "Process Resource ID";
            this.lblProcResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvProcOper
            // 
            this.cdvProcOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvProcOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvProcOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvProcOper.BtnToolTipText = "";
            this.cdvProcOper.DescText = "";
            this.cdvProcOper.DisplaySubItemIndex = -1;
            this.cdvProcOper.DisplayText = "";
            this.cdvProcOper.Focusing = null;
            this.cdvProcOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvProcOper.Index = 0;
            this.cdvProcOper.IsViewBtnImage = false;
            this.cdvProcOper.Location = new System.Drawing.Point(520, 63);
            this.cdvProcOper.MaxLength = 10;
            this.cdvProcOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvProcOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvProcOper.Name = "cdvProcOper";
            this.cdvProcOper.ReadOnly = false;
            this.cdvProcOper.SearchSubItemIndex = 0;
            this.cdvProcOper.SelectedDescIndex = -1;
            this.cdvProcOper.SelectedSubItemIndex = -1;
            this.cdvProcOper.SelectionStart = 0;
            this.cdvProcOper.Size = new System.Drawing.Size(200, 20);
            this.cdvProcOper.SmallImageList = null;
            this.cdvProcOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvProcOper.TabIndex = 4;
            this.cdvProcOper.TextBoxToolTipText = "";
            this.cdvProcOper.TextBoxWidth = 200;
            this.cdvProcOper.VisibleButton = true;
            this.cdvProcOper.VisibleColumnHeader = false;
            this.cdvProcOper.VisibleDescription = false;
            this.cdvProcOper.ButtonPress += new System.EventHandler(this.cdvProcOper_ButtonPress);
            // 
            // lblProcOper
            // 
            this.lblProcOper.AutoSize = true;
            this.lblProcOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcOper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcOper.Location = new System.Drawing.Point(411, 67);
            this.lblProcOper.Name = "lblProcOper";
            this.lblProcOper.Size = new System.Drawing.Size(94, 13);
            this.lblProcOper.TabIndex = 6;
            this.lblProcOper.Text = "Process Operation";
            // 
            // cdvOper
            // 
            this.cdvOper.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOper.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOper.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOper.BtnToolTipText = "";
            this.cdvOper.DescText = "";
            this.cdvOper.DisplaySubItemIndex = -1;
            this.cdvOper.DisplayText = "";
            this.cdvOper.Focusing = null;
            this.cdvOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOper.Index = 0;
            this.cdvOper.IsViewBtnImage = false;
            this.cdvOper.Location = new System.Drawing.Point(124, 63);
            this.cdvOper.MaxLength = 10;
            this.cdvOper.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOper.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOper.Name = "cdvOper";
            this.cdvOper.ReadOnly = false;
            this.cdvOper.SearchSubItemIndex = 0;
            this.cdvOper.SelectedDescIndex = -1;
            this.cdvOper.SelectedSubItemIndex = -1;
            this.cdvOper.SelectionStart = 0;
            this.cdvOper.Size = new System.Drawing.Size(200, 20);
            this.cdvOper.SmallImageList = null;
            this.cdvOper.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOper.TabIndex = 3;
            this.cdvOper.TextBoxToolTipText = "";
            this.cdvOper.TextBoxWidth = 200;
            this.cdvOper.VisibleButton = true;
            this.cdvOper.VisibleColumnHeader = false;
            this.cdvOper.VisibleDescription = false;
            this.cdvOper.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvOper_SelectedItemChanged);
            this.cdvOper.ButtonPress += new System.EventHandler(this.cdvOper_ButtonPress);
            this.cdvOper.TextBoxTextChanged += new System.EventHandler(this.cdvOper_TextBoxTextChanged);
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
            this.cdvResID.Location = new System.Drawing.Point(124, 87);
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
            this.cdvResID.TabIndex = 5;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 91);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 8;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Location = new System.Drawing.Point(15, 67);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 4;
            this.lblOper.Text = "Operation";
            // 
            // grpLotID
            // 
            this.grpLotID.Controls.Add(this.pnlTranTime);
            this.grpLotID.Controls.Add(this.txtLot);
            this.grpLotID.Controls.Add(this.txtDesc);
            this.grpLotID.Controls.Add(this.lblLotDesc);
            this.grpLotID.Controls.Add(this.lblLotID);
            this.grpLotID.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotID.Location = new System.Drawing.Point(3, 0);
            this.grpLotID.Name = "grpLotID";
            this.grpLotID.Size = new System.Drawing.Size(786, 73);
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
            this.pnlTranTime.Location = new System.Drawing.Point(478, 15);
            this.pnlTranTime.Name = "pnlTranTime";
            this.pnlTranTime.Size = new System.Drawing.Size(296, 23);
            this.pnlTranTime.TabIndex = 1;
            // 
            // txtTranTime
            // 
            this.txtTranTime.Location = new System.Drawing.Point(128, 1);
            this.txtTranTime.MaxLength = 30;
            this.txtTranTime.Name = "txtTranTime";
            this.txtTranTime.ReadOnly = true;
            this.txtTranTime.Size = new System.Drawing.Size(168, 20);
            this.txtTranTime.TabIndex = 2;
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
            this.udtTranTime.TabIndex = 3;
            this.udtTranTime.Value = new System.DateTime(2005, 5, 11, 0, 0, 0, 0);
            // 
            // uccTranDate
            // 
            this.uccTranDate.DateButtons.Add(dateButton1);
            this.uccTranDate.Location = new System.Drawing.Point(128, 1);
            this.uccTranDate.Name = "uccTranDate";
            this.uccTranDate.NonAutoSizeHeight = 21;
            this.uccTranDate.Size = new System.Drawing.Size(88, 21);
            this.uccTranDate.TabIndex = 3;
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
            // txtLot
            // 
            this.txtLot.Location = new System.Drawing.Point(124, 16);
            this.txtLot.MaxLength = 25;
            this.txtLot.Name = "txtLot";
            this.txtLot.Size = new System.Drawing.Size(200, 20);
            this.txtLot.TabIndex = 0;
            this.txtLot.TextChanged += new System.EventHandler(this.txtLot_TextChanged);
            this.txtLot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLot_KeyPress);
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
            this.txtDesc.TabIndex = 2;
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
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmSPCTranCollectLotData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 636);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 670);
            this.Name = "frmSPCTranCollectLotData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Collect Lot Data";
            this.Activated += new System.EventHandler(this.frmSPCTranCollectLotData_Activated);
            this.Closed += new System.EventHandler(this.frmSPCTranCollectLotData_Closed);
            this.Load += new System.EventHandler(this.frmSPCTranCollectLotData_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewChart)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            this.grpLot.ResumeLayout(false);
            this.grpLot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectMFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCharID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvProcOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.grpLotID.ResumeLayout(false);
            this.grpLotID.PerformLayout();
            this.pnlTranTime.ResumeLayout(false);
            this.pnlTranTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTranTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTranTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTranDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTranDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion

        #region " Variable Definition"
        private bool b_load_flag = false;
        #endregion

        #region " Constant Definition"

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
                if (txtLot.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtLot.Focus();
                    return false;
                }
                if (MPCF.CheckValue(cdvChartID, 1) == false)
                {
                    return false;
                }
                if (MPCF.CheckValue(cdvUserID, 1) == false)
                {
                    return false;
                }
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return false;
                }
                if (cdvFlow.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvFlow.Focus();
                    return false;
                }
                if (cdvOper.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvOper.Focus();
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
                if (ctrlChartInfo.CheckCondition() == false)
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.CheckCondition()\n" + ex.Message);
                return false;
            }

        }

        // View_Lot()
        //       - View Lot
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Lot()
        {

            try
            {
                TRSNode in_node = new TRSNode("View_Lot_In");
                TRSNode out_node = new TRSNode("View_Lot_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", txtLot.Text);

                if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = out_node.GetString("LOT_DESC");
                cdvMaterial.Text = out_node.GetString("MAT_ID");
                cdvMaterial.Version = out_node.GetInt("MAT_VER");
                cdvFlow.Text = out_node.GetString("FLOW");
                cdvFlow.Sequence = out_node.GetInt("FLOW_SEQ_NUM");
                cdvOper.Text = out_node.GetString("OPER");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.View_Lot()\n" + ex.Message);
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
                ctrlChartInfo.LotResFlag = 'L';
                ctrlChartInfo.LotID = MPCF.Trim(txtLot.Text);
                ctrlChartInfo.MatID = MPCF.Trim(cdvMaterial.Text);
                ctrlChartInfo.MatVer = cdvMaterial.Version;
                ctrlChartInfo.Flow = MPCF.Trim(cdvFlow.Text);
                ctrlChartInfo.FlowSeq = cdvFlow.Sequence;
                ctrlChartInfo.Oper = MPCF.Trim(cdvOper.Text);
                ctrlChartInfo.ProcOper = MPCF.Trim(cdvProcOper.Text);
                ctrlChartInfo.ResID = MPCF.Trim(cdvResID.Text);
                ctrlChartInfo.ProcResID = MPCF.Trim(cdvProcResID.Text);
                ctrlChartInfo.CharID = MPCF.Trim(cdvCharID.Text);
                //ctrlChartInfo.TranTime = ((DateTime)uccTranDate.Value).ToString("yyyyMMddHHmmss");
                /* Updated By YJJuyng 161024 SPC Collect Lot Data 시 시분초 적용 안되는 버그 수정 */
                ctrlChartInfo.TranTime = ((DateTime)uccTranDate.Value).ToString("yyyyMMdd") + ((DateTime)udtTranTime.Value).ToString("HHmmss");
                ctrlChartInfo.UserID = MPCF.Trim(cdvUserID.Text);
                ctrlChartInfo.SelectMFOFlag = chkSelectMFO.Checked ? 'Y' : ' ';

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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.SetCollectData()\n" + ex.Message);
            }

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.txtLot;

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

        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {

            try
            {
                cdvChartID.Init();

                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(154));
                    cdvMaterial.MaterialFocus();
                    return;
                }

                MPCF.InitListView(cdvChartID.GetListView);
                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartID.SelectedSubItemIndex = 0;
                SPCLIST.ViewChartList(cdvChartID.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, cdvOper.Text, cdvResID.Text, cdvCharID.Text, 'L', ' ', "", cdvFlow.Text, 'Y', -1, -1, null, "");

                cdvChartID.AddEmptyRow(1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvChartID_ButtonPress()\n" + ex.Message);
            }

        }

        private void cdvProcOper_ButtonPress(System.Object sender, System.EventArgs e)
        {

            try
            {
                cdvProcOper.Init();
                MPCF.InitListView(cdvProcOper.GetListView);
                cdvProcOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvProcOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvProcOper.SelectedSubItemIndex = 0;
                if (WIPLIST.ViewOperationList(cdvProcOper.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }
                cdvProcOper.AddEmptyRow(1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvProcOper_ButtonPress()\n" + ex.Message);
            }

        }

        private void cdvResID_ButtonPress(System.Object sender, System.EventArgs e)
        {

            try
            {
                cdvResID.Init();
                MPCF.InitListView(cdvResID.GetListView);
                cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvResID.SelectedSubItemIndex = 0;
                if (RASLIST.ViewResourceList(cdvResID.GetListView, MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOper.Text), false) == false)
                {
                    return;
                }
                cdvResID.AddEmptyRow(1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvResID_ButtonPress()\n" + ex.Message);
            }

        }

        private void cdvProcResID_ButtonPress(System.Object sender, System.EventArgs e)
        {

            try
            {
                cdvProcResID.Init();
                MPCF.InitListView(cdvProcResID.GetListView);
                cdvProcResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
                cdvProcResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvProcResID.SelectedSubItemIndex = 0;
                if (RASLIST.ViewResourceList(cdvProcResID.GetListView, MPCF.Trim(cdvMaterial.Text), cdvMaterial.Version, MPCF.Trim(cdvFlow.Text), MPCF.Trim(cdvOper.Text), false) == false)
                {
                    return;
                }
                cdvProcResID.AddEmptyRow(1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvProcResID_ButtonPress()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvCharID_ButtonPress()\n" + ex.Message);
            }

        }

        private void txtLot_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            try
            {
                char sChartFlag = ' ';
                string sChartID = string.Empty;
                char sOvrFlag = ' ';
                if (e.KeyChar == (char)13)
                {
                    if (txtLot.Text != "")
                    {
                        ctrlChartInfo.ClearControl();
                        MPCF.FieldClear(this.pnlCenter, txtLot, null, null, null, null, false);
                        if (View_Lot() == false)
                        {
                            cdvChartID.BackColor = System.Drawing.Color.White;
                            cdvChartID.ReadOnly = false;
                            cdvChartID.VisibleButton = true;
                            return;
                        }
                        if (MPCR.ViewMFOChart('2', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOper.Text, ref sChartFlag, ref sChartID, ref sOvrFlag, true) == false)
                        {
                            cdvChartID.BackColor = System.Drawing.Color.White;
                            cdvChartID.ReadOnly = false;
                            cdvChartID.VisibleButton = true;
                            return;
                        }
                        if (sChartFlag == 'C' && sChartID != "")
                        {
                            if (sOvrFlag == 'Y')
                            {
                                cdvChartID.BackColor = System.Drawing.Color.White;
                                cdvChartID.ReadOnly = false;
                                cdvChartID.VisibleButton = true;
                                cdvChartID.Text = sChartID;
                            }
                            else
                            {
                                cdvChartID.BackColor = SystemColors.Control;
                                cdvChartID.ReadOnly = true;
                                cdvChartID.VisibleButton = false;
                                cdvChartID.Text = sChartID;
                            }
                            cdvChartID_SelectedItemChanged(sender, null);
                        }
                        else
                        {
                            cdvChartID.BackColor = System.Drawing.Color.White;
                            cdvChartID.ReadOnly = false;
                            cdvChartID.VisibleButton = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.txtLot_KeyPress()\n" + ex.Message);
            }

        }

        private void cdvChartID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {

                if (MPCF.Trim(cdvChartID.Text) != "")
                {
                    ctrlChartInfo.ChartID = MPCF.Trim(cdvChartID.Text);
                    ctrlChartInfo.ViewChartInfo(true);
                                      
                    cboGraphType.SelectedIndex = ctrlChartInfo.GraphTypeIndex;
                    cdvResID.Text = ctrlChartInfo.ctrlChartData.Resource;
                    cdvCharID.Text = ctrlChartInfo.ctrlChartData.Character;
                    btnOK.Enabled = true;
                    if (ctrlChartInfo.ViewChart == "Y")
                    {
                        ctrlChartInfo.InitChart();
                        ctrlChartInfo.ViewControlChart(true);
                    }
                }
                cdvUserID.Text = "";

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvChartID_SelectedItemChanged()\n" + ex.Message);
            }

        }

        private void chkTranDateTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                txtTranTime.Visible = !chkTranDateTime.Checked;
                uccTranDate.Enabled = chkTranDateTime.Checked;
                udtTranTime.Enabled = chkTranDateTime.Checked;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.chkTranDateTime_CheckedChanged()\n" + ex.Message);
            }

        }

        private void frmSPCTranCollectLotData_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
                    if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                    {
                        txtLot.Text = MPGV.gsCurrentLot_ID;
                        if (View_Lot() == false)
                        {
                            return;
                        }
                    }
                    b_load_flag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.frmSPCTranCollectLotData_Activated()\n" + ex.Message);
            }

        }

        private void frmSPCTranCollectLotData_Load(object sender, System.EventArgs e)
        {

            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);

                MPCF.SetTextboxStyle(this.Controls);
                uccTranDate.Value = DateTime.Now;
                udtTranTime.Value = DateTime.Now;
                modSPCFunctions.SetGraphList(cboGraphType);
                pnlTranTime.Visible = MPGO.UseBackDate();

                cdvMaterial.BackColor = SystemColors.Control;

                cdvFlow.VisibleFlowButton = false;
                cdvFlow.FlowReadOnly = true;
                cdvFlow.BackColor = SystemColors.Control;

                cdvFlow.VisibleSequenceButton = false;
                cdvFlow.SequenceReadOnly = true;
                cdvFlow.BackColor = SystemColors.Control;

                cdvOper.VisibleButton = false;
                cdvOper.ReadOnly = true;
                cdvOper.BackColor = SystemColors.Control;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.frmSPCTranCollectLotData_Load()\n" + ex.Message);
            }

        }

        private void cdvCharID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {

            try
            {
                MPCF.FieldClear(this.grpChart);
                ctrlChartInfo.ClearControl();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvCharID_SelectedItemChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnOK_Click()\n" + ex.Message);
            }

        }

        private void txtLot_TextChanged(object sender, System.EventArgs e)
        {

            try
            {
                MPCF.FieldClear(this.pnlCenter, txtLot, null, null, null, null, false);
                ctrlChartInfo.ClearControl();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.txtLot_TextChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnClose_Click()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnRefresh_Click()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnReset_Click()\n" + ex.Message);
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

                ((frmSPCTranControlChart)form).uccStart.Value = DateTime.Now;
                ((frmSPCTranControlChart)form).udtStart.Value = "000000";
                ((frmSPCTranControlChart)form).uccEnd.Value = DateTime.Now;
                ((frmSPCTranControlChart)form).udtEnd.Value = "235959";
                ((frmSPCTranControlChart)form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCTranControlChart)form).cdvChartID.Text != "")
                {
                    ((frmSPCTranControlChart)form).ChartIDSelected();
                    ((frmSPCTranControlChart)form).btnView.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnGraph_Click()\n" + ex.Message);
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

                ((frmSPCViewEDCData)form).uccStart.Value = DateTime.Now;
                ((frmSPCViewEDCData)form).udtStart.Value = "000000";
                ((frmSPCViewEDCData)form).uccEnd.Value = DateTime.Now;
                ((frmSPCViewEDCData)form).udtEnd.Value = "235959";
                ((frmSPCViewEDCData)form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCViewEDCData)form).cdvChartID.Text != "")
                {
                    ((frmSPCViewEDCData)form).Set_Data();
                    ((frmSPCViewEDCData)form).btnView.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnRawData_Click()\n" + ex.Message);
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

                ((frmSPCTranCapability)form).uccStart.Value = DateTime.Now;
                ((frmSPCTranCapability)form).udtStart.Value = "000000";
                ((frmSPCTranCapability)form).uccEnd.Value = DateTime.Now;
                ((frmSPCTranCapability)form).udtEnd.Value = "235959";
                ((frmSPCTranCapability)form).cdvChartID.Text = this.cdvChartID.Text;
                if (((frmSPCTranCapability)form).cdvChartID.Text != "")
                {
                    ((frmSPCTranCapability)form).ChartIDSelected();
                    ((frmSPCTranCapability)form).btnView.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.btnHistogram_Click()\n" + ex.Message);
            }

        }

        private void frmSPCTranCollectLotData_Closed(object sender, System.EventArgs e)
        {

            try
            {
                ctrlChartInfo.ViewControlChart(false);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.frmSPCTranCollectLotData_Closed()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvChartID_TextBoxTextChanged()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvUserID_ButtonPress()\n" + ex.Message);
            }

        }

        private void chkSelectMFO_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                char sChartFlag = ' ';
                string sChartID = string.Empty;
                char sOvrFlag = ' ';

                if (chkSelectMFO.Checked == true)
                {
                    cdvFlow.VisibleFlowButton = true;
                    cdvFlow.FlowReadOnly = false;
                    cdvFlow.VisibleSequenceButton = true;
                    cdvFlow.SequenceReadOnly = false;
                    cdvFlow.BackColor = Color.White;
                    cdvOper.VisibleButton = true;
                    cdvOper.ReadOnly = false;
                    cdvOper.BackColor = Color.White;
                }
                else
                {
                    cdvFlow.VisibleFlowButton = false;
                    cdvFlow.FlowReadOnly = true;
                    cdvFlow.VisibleSequenceButton = false;
                    cdvFlow.SequenceReadOnly = true;
                    cdvFlow.BackColor = SystemColors.Control;
                    cdvOper.VisibleButton = false;
                    cdvOper.ReadOnly = true;
                    cdvOper.BackColor = SystemColors.Control;
                    if (txtLot.Text != "")
                    {
                        ctrlChartInfo.ClearControl();
                        MPCF.FieldClear(this.pnlCenter, txtLot, null, null, null, null, false);
                        if (View_Lot() == false)
                        {
                            cdvChartID.BackColor = System.Drawing.Color.White;
                            cdvChartID.ReadOnly = false;
                            cdvChartID.VisibleButton = true;
                            return;
                        }
                        if (MPCR.ViewMFOChart('2', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOper.Text, ref sChartFlag, ref sChartID, ref sOvrFlag, true) == false)
                        {
                            cdvChartID.BackColor = System.Drawing.Color.White;
                            cdvChartID.ReadOnly = false;
                            cdvChartID.VisibleButton = true;
                            return;
                        }
                        if (sChartFlag == 'C' && sChartID != "")
                        {
                            if (sOvrFlag == 'Y')
                            {
                                cdvChartID.BackColor = System.Drawing.Color.White;
                                cdvChartID.ReadOnly = false;
                                cdvChartID.VisibleButton = true;
                                cdvChartID.Text = sChartID;
                            }
                            else
                            {
                                cdvChartID.BackColor = SystemColors.Control;
                                cdvChartID.ReadOnly = true;
                                cdvChartID.VisibleButton = false;
                                cdvChartID.Text = sChartID;
                            }
                            cdvChartID_SelectedItemChanged(sender, null);
                        }
                        else
                        {
                            cdvChartID.BackColor = System.Drawing.Color.White;
                            cdvChartID.ReadOnly = false;
                            cdvChartID.VisibleButton = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.chkSelectMFO_CheckedChanged()\n" + ex.Message);
            }
        }

        private void cdvOper_ButtonPress(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                if (cdvFlow.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvFlow.Focus();
                    return;
                }

                cdvOper.Init();
                MPCF.InitListView(cdvOper.GetListView);
                cdvOper.Columns.Add("Operation", 50, HorizontalAlignment.Left);
                cdvOper.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvOper.SelectedSubItemIndex = 0;
                if (WIPLIST.ViewOperationList(cdvOper.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "") == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvOper_ButtonPress()\n" + ex.Message);
            }

        }

      
        private void cdvOper_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                char sChartFlag = ' ';
                string sChartID = string.Empty;
                char sOvrFlag = ' ';

                ctrlChartInfo.ClearControl();
                cdvResID.Text = "";
                cdvCharID.Text = "";
                cdvChartID.Text = "";
                cdvChartID.Init();
                if (MPCF.Trim(cdvOper.Text) != "")
                {
                    if (MPCR.ViewMFOChart('2', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, cdvOper.Text, ref sChartFlag, ref sChartID, ref sOvrFlag, true) == false)
                    {
                        cdvChartID.BackColor = System.Drawing.Color.White;
                        cdvChartID.ReadOnly = false;
                        cdvChartID.VisibleButton = true;
                        return;
                    }
                    if (sChartFlag == 'C' && sChartID != "")
                    {
                        if (sOvrFlag == 'Y')
                        {
                            cdvChartID.BackColor = System.Drawing.Color.White;
                            cdvChartID.ReadOnly = false;
                            cdvChartID.VisibleButton = true;
                            cdvChartID.Text = sChartID;
                        }
                        else
                        {
                            cdvChartID.BackColor = SystemColors.Control;
                            cdvChartID.ReadOnly = true;
                            cdvChartID.VisibleButton = false;
                            cdvChartID.Text = sChartID;
                        }
                        cdvChartID_SelectedItemChanged(sender, null);
                    }
                    else
                    {
                        cdvChartID.BackColor = System.Drawing.Color.White;
                        cdvChartID.ReadOnly = false;
                        cdvChartID.VisibleButton = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvOper_SelectedItemChanged()\n" + ex.Message);
            }
        }

      
        private void cdvOper_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            try
            {
                ctrlChartInfo.ClearControl();
                cdvResID.Text = "";
                cdvCharID.Text = "";
                cdvChartID.Text = "";
                cdvChartID.Init();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvOper_TextBoxTextChanged()\n" + ex.Message);
            }

        }

        private void cdvChartID_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (MPCF.Trim(cdvChartID.Text) != "")
                    {
                        ctrlChartInfo.ClearControl();
                        ctrlChartInfo.ChartID = MPCF.Trim(cdvChartID.Text);
                        ctrlChartInfo.ViewChartInfo(true);
                        if (ctrlChartInfo.ViewChart == "Y")
                        {
                            ctrlChartInfo.InitChart();
                            ctrlChartInfo.ViewControlChart(true);
                        }
                        
                        cboGraphType.SelectedIndex = ctrlChartInfo.GraphTypeIndex;
                        cdvResID.Text = ctrlChartInfo.ctrlChartData.Resource;
                        cdvCharID.Text = ctrlChartInfo.ctrlChartData.Character;
                        btnOK.Enabled = true;
                    }
                    cdvUserID.Text = "";
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvChartID_KeyPress()\n" + ex.Message);
            }

        }

        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.cboLotorRes.ReadOnly = true;
                form.cboLotorRes.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
                form.cboLotorRes.SelectedIndex = 1;
                form.cdvMaterial.Text = this.cdvMaterial.Text;
                form.cdvMaterial.Version = this.cdvMaterial.Version;
                form.cdvMaterial.Enabled = false;
                form.cdvFlow.Text = this.cdvFlow.Text;
                form.cdvFlow.Enabled = false;
                form.cdvOper.Text = this.cdvOper.Text;
                form.cdvOper.Enabled = false;
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

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
        {
            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;
          
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvFlow_FlowButtonPress()\n" + ex.Message);
            }
        }

        private void cdvFlow_FlowSelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                ctrlChartInfo.ClearControl();
                cdvOper.Text = "";
                cdvOper.Init();
                cdvResID.Text = "";
                cdvCharID.Text = "";
                cdvChartID.Text = "";
                cdvChartID.Init();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvFlow_FlowSelectedItemChanged()\n" + ex.Message);
            }
        }

        private void cdvFlow_FlowTextChanged(object sender, EventArgs e)
        {
            try
            {
                ctrlChartInfo.ClearControl();
                cdvOper.Text = "";
                cdvOper.Init();
                cdvResID.Text = "";
                cdvCharID.Text = "";
                cdvChartID.Text = "";
                cdvChartID.Init();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvFlow_FlowTextChanged()\n" + ex.Message);
            }
        }

        private void cdvFlow_SeqButtonPress(object sender, EventArgs e)
        {
            try
            {
                if (cdvMaterial.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvMaterial.MaterialFocus();
                    return;
                }
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranCollectLotData.cdvFlow_SeqButtonPress()\n" + ex.Message);
            }
        }

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
