
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
using Infragistics.Win.UltraWinEditors;
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCSpecManagement.vb
//   Description :
//
//   MES Version : 1.0.0
//
//   Function List
//       - CheckCondition() : Check the Conditions before Transaction
//       - View_Spec() : View Spec Information
//       - Update_Spec() : Create/Update/Delete Spec
//       - View_Chart() : View Chart Information
//       - AutoCalculationControlLimit() : Autometic Control Limit Calculation
//
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-05-04 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.SPCCore
{
    public class frmSPCSpecManagement : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCSpecManagement()
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
        



        public System.Windows.Forms.Panel pnlBottom;
        public System.Windows.Forms.Panel pnlFind;
        public System.Windows.Forms.Button btnExcel;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnNext;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtFind;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Panel pnlLeft;
        internal Miracom.UI.Controls.MCListView.MCListView lisChart;
        internal System.Windows.Forms.Panel pnlTop;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkIncludeDeleteChart;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        public System.Windows.Forms.Button btnRelease;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnCreate;
        public System.Windows.Forms.Panel pnlRight;
        internal System.Windows.Forms.Panel pnlTab;
        internal System.Windows.Forms.TabControl tabVersion;
        internal System.Windows.Forms.TabPage tbpGeneral;
        internal System.Windows.Forms.GroupBox grpChart;
        internal System.Windows.Forms.Label lblDesc;
        internal System.Windows.Forms.Label lblChart;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtDesc;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtChart;
        internal System.Windows.Forms.Panel pnlMidTop;
        internal System.Windows.Forms.Panel pnlMidLeft;
        internal Miracom.UI.Controls.MCListView.MCListView lisVersion;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.Panel pnlMidRight;
        internal System.Windows.Forms.GroupBox grpVersion;
        internal System.Windows.Forms.Label lblVersion;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtVersion;
        internal System.Windows.Forms.Label lblFromTo;
        internal System.Windows.Forms.GroupBox grpSpec;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLSL;
        internal System.Windows.Forms.Label lblLSL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUSL;
        internal System.Windows.Forms.Label lblUSL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUCL2;
        internal System.Windows.Forms.Label lblUCL2;
        internal System.Windows.Forms.Label lblUCL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCL;
        internal System.Windows.Forms.Label lblCL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLCL;
        internal System.Windows.Forms.Label lblLCL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCL2;
        internal System.Windows.Forms.Label lblCL2;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtLCL2;
        internal System.Windows.Forms.Label lblLCL2;
        internal System.Windows.Forms.GroupBox grpComment;
        internal System.Windows.Forms.Label lblComment;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtComment;
        internal System.Windows.Forms.GroupBox grpDateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUpdateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCreateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUpdateUser;
        internal System.Windows.Forms.Label lblUpdate;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCreateUser;
        internal System.Windows.Forms.Label lblCreate;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtReleaseTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtReleaseUser;
        internal System.Windows.Forms.Label lblRelease;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAutoCalFlag;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkReleased;
        internal System.Windows.Forms.Label lblAuto;
        internal System.Windows.Forms.Label lblReleased;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccStart;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccEnd;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtEnd;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtStart;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUCL;
        internal Infragistics.Win.UltraWinEditors.UltraComboEditor cboGraphType;
        internal System.Windows.Forms.Label lblStart;
        internal System.Windows.Forms.Label lblEnd;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtStartTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtEndTime;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkStart;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkEnd;
        internal System.Windows.Forms.Splitter splMain;
        internal System.Windows.Forms.TabPage tbpAutoCalculation;
        internal System.Windows.Forms.GroupBox grpSelChart;
        internal System.Windows.Forms.RadioButton rbnAllChart;
        internal System.Windows.Forms.RadioButton rbnCurrentChart;
        internal System.Windows.Forms.GroupBox grpSelPeriod;
        internal System.Windows.Forms.RadioButton rbnCurrentPeriod;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTo;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtFrom;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtFrom;
        internal Infragistics.Win.UltraWinEditors.UltraDateTimeEditor udtTo;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccTo;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccFrom;
        internal System.Windows.Forms.Label lblPeriod;
        public System.Windows.Forms.Button btnCalculation;
        internal System.Windows.Forms.RadioButton rbnUserSelectPeriod;
        internal System.Windows.Forms.GroupBox grbOptions;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAutoRelease;
        public System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Panel pnlVersion;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtTARGET;
        internal System.Windows.Forms.Label lblTARGET;
        public System.Windows.Forms.Label lblDataCount;
        public System.Windows.Forms.Label lblDataCountBack;
        internal System.Windows.Forms.Panel pnlCalculation;
        internal System.Windows.Forms.Panel pnlSpecInfo;
        internal System.Windows.Forms.GroupBox grpAutoSpec;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtAutoTarget;
        internal System.Windows.Forms.Label lblAutoTarget;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtAutoLCL2;
        internal System.Windows.Forms.Label lblAutoLCL2;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtAutoCL2;
        internal System.Windows.Forms.Label lblAutoCL2;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtAutoLCL;
        internal System.Windows.Forms.Label lblAutoLCL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtAutoCL;
        internal System.Windows.Forms.Label lblAutoCL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtAutoUCL;
        internal System.Windows.Forms.Label lblAutoUCL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtAutoUCL2;
        internal System.Windows.Forms.Label lblAutoUCL2;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtAutoLSL;
        internal System.Windows.Forms.Label lblAutoLSL;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtAutoUSL;
        internal System.Windows.Forms.Label lblAutoUSL;
        internal System.Windows.Forms.Panel pnlFilter;
        internal System.Windows.Forms.GroupBox grpFilter;
        public System.Windows.Forms.Button btnView;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtFilter;
        internal System.Windows.Forms.RadioButton rbnAll;
        internal System.Windows.Forms.RadioButton rbnFilter;
        internal UltraTextEditor txtAutoSigma;
        internal Label label1;
        internal System.Windows.Forms.Button btnFiltering;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCSpecManagement));
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton3 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton4 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.lblDataCountBack = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtFind = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btnRelease = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lisChart = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.txtFilter = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.rbnAll = new System.Windows.Forms.RadioButton();
            this.rbnFilter = new System.Windows.Forms.RadioButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.chkIncludeDeleteChart = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabVersion = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpDateTime = new System.Windows.Forms.GroupBox();
            this.txtReleaseTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtReleaseUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblRelease = new System.Windows.Forms.Label();
            this.txtUpdateTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtCreateTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtUpdateUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblCreate = new System.Windows.Forms.Label();
            this.pnlMidTop = new System.Windows.Forms.Panel();
            this.pnlMidRight = new System.Windows.Forms.Panel();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.grpSpec = new System.Windows.Forms.GroupBox();
            this.txtTARGET = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblTARGET = new System.Windows.Forms.Label();
            this.txtLCL2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLCL2 = new System.Windows.Forms.Label();
            this.txtCL2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblCL2 = new System.Windows.Forms.Label();
            this.txtLCL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLCL = new System.Windows.Forms.Label();
            this.txtCL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblCL = new System.Windows.Forms.Label();
            this.txtUCL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblUCL = new System.Windows.Forms.Label();
            this.txtUCL2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblUCL2 = new System.Windows.Forms.Label();
            this.txtLSL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblLSL = new System.Windows.Forms.Label();
            this.txtUSL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblUSL = new System.Windows.Forms.Label();
            this.grpVersion = new System.Windows.Forms.GroupBox();
            this.txtAutoSigma = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReleased = new System.Windows.Forms.Label();
            this.chkReleased = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkEnd = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtEndTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtStartTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.udtStart = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udtEnd = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccEnd = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.uccStart = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblAuto = new System.Windows.Forms.Label();
            this.chkAutoCalFlag = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblFromTo = new System.Windows.Forms.Label();
            this.chkStart = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.pnlMidLeft = new System.Windows.Forms.Panel();
            this.lisVersion = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtVersion = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.tbpAutoCalculation = new System.Windows.Forms.TabPage();
            this.pnlSpecInfo = new System.Windows.Forms.Panel();
            this.grpAutoSpec = new System.Windows.Forms.GroupBox();
            this.txtAutoTarget = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblAutoTarget = new System.Windows.Forms.Label();
            this.txtAutoLCL2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblAutoLCL2 = new System.Windows.Forms.Label();
            this.txtAutoCL2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblAutoCL2 = new System.Windows.Forms.Label();
            this.txtAutoLCL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblAutoLCL = new System.Windows.Forms.Label();
            this.txtAutoCL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblAutoCL = new System.Windows.Forms.Label();
            this.txtAutoUCL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblAutoUCL = new System.Windows.Forms.Label();
            this.txtAutoUCL2 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblAutoUCL2 = new System.Windows.Forms.Label();
            this.txtAutoLSL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblAutoLSL = new System.Windows.Forms.Label();
            this.txtAutoUSL = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblAutoUSL = new System.Windows.Forms.Label();
            this.pnlCalculation = new System.Windows.Forms.Panel();
            this.btnCalculation = new System.Windows.Forms.Button();
            this.grbOptions = new System.Windows.Forms.GroupBox();
            this.chkAutoRelease = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.grpSelPeriod = new System.Windows.Forms.GroupBox();
            this.txtTo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtFrom = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.udtFrom = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.udtTo = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.uccTo = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.uccFrom = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.rbnCurrentPeriod = new System.Windows.Forms.RadioButton();
            this.rbnUserSelectPeriod = new System.Windows.Forms.RadioButton();
            this.grpSelChart = new System.Windows.Forms.GroupBox();
            this.rbnCurrentChart = new System.Windows.Forms.RadioButton();
            this.rbnAllChart = new System.Windows.Forms.RadioButton();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.cboGraphType = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblChart = new System.Windows.Forms.Label();
            this.txtDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtChart = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.splMain = new System.Windows.Forms.Splitter();
            this.pnlBottom.SuspendLayout();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFind)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeDeleteChart)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabVersion.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpDateTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateUser)).BeginInit();
            this.pnlMidTop.SuspendLayout();
            this.pnlMidRight.SuspendLayout();
            this.grpComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.grpSpec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTARGET)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLCL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLCL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUCL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUCL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSL)).BeginInit();
            this.grpVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoSigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReleased)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCalFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStart)).BeginInit();
            this.pnlMidLeft.SuspendLayout();
            this.pnlVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersion)).BeginInit();
            this.tbpAutoCalculation.SuspendLayout();
            this.pnlSpecInfo.SuspendLayout();
            this.grpAutoSpec.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoLCL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoCL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoLCL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoCL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoUCL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoUCL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoLSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoUSL)).BeginInit();
            this.pnlCalculation.SuspendLayout();
            this.grbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRelease)).BeginInit();
            this.grpSelPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFrom)).BeginInit();
            this.grpSelChart.SuspendLayout();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.pnlFind);
            this.pnlBottom.Controls.Add(this.btnRelease);
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Controls.Add(this.btnCreate);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(557, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 26);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlFind
            // 
            this.pnlFind.Controls.Add(this.lblDataCount);
            this.pnlFind.Controls.Add(this.lblDataCountBack);
            this.pnlFind.Controls.Add(this.btnExcel);
            this.pnlFind.Controls.Add(this.btnRefresh);
            this.pnlFind.Controls.Add(this.btnNext);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFind.Location = new System.Drawing.Point(0, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(232, 40);
            this.pnlFind.TabIndex = 5;
            // 
            // lblDataCount
            // 
            this.lblDataCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCount.Location = new System.Drawing.Point(7, 13);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(36, 16);
            this.lblDataCount.TabIndex = 7;
            this.lblDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataCountBack
            // 
            this.lblDataCountBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDataCountBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCountBack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCountBack.Location = new System.Drawing.Point(4, 8);
            this.lblDataCountBack.Name = "lblDataCountBack";
            this.lblDataCountBack.Size = new System.Drawing.Size(42, 24);
            this.lblDataCountBack.TabIndex = 6;
            this.lblDataCountBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(200, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(174, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(148, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.AutoSize = false;
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFind.Location = new System.Drawing.Point(48, 8);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(96, 24);
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // btnRelease
            // 
            this.btnRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRelease.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRelease.Location = new System.Drawing.Point(281, 5);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(88, 26);
            this.btnRelease.TabIndex = 0;
            this.btnRelease.Text = "Release";
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(465, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreate.Location = new System.Drawing.Point(373, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(88, 26);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(650, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisChart);
            this.pnlLeft.Controls.Add(this.pnlFilter);
            this.pnlLeft.Controls.Add(this.pnlTop);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            this.pnlLeft.TabIndex = 0;
            // 
            // lisChart
            // 
            this.lisChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisChart.EnableSort = true;
            this.lisChart.EnableSortIcon = true;
            this.lisChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisChart.FullRowSelect = true;
            this.lisChart.Location = new System.Drawing.Point(3, 62);
            this.lisChart.MultiSelect = false;
            this.lisChart.Name = "lisChart";
            this.lisChart.Size = new System.Drawing.Size(229, 441);
            this.lisChart.TabIndex = 2;
            this.lisChart.UseCompatibleStateImageBehavior = false;
            this.lisChart.View = System.Windows.Forms.View.Details;
            this.lisChart.SelectedIndexChanged += new System.EventHandler(this.lisChart_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Chart";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(3, 22);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.pnlFilter.Size = new System.Drawing.Size(229, 40);
            this.pnlFilter.TabIndex = 1;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnView);
            this.grpFilter.Controls.Add(this.txtFilter);
            this.grpFilter.Controls.Add(this.rbnAll);
            this.grpFilter.Controls.Add(this.rbnFilter);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(229, 38);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(184, 13);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(36, 20);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(26, 13);
            this.txtFilter.MaxLength = 30;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(98, 21);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // rbnAll
            // 
            this.rbnAll.Location = new System.Drawing.Point(131, 16);
            this.rbnAll.Name = "rbnAll";
            this.rbnAll.Size = new System.Drawing.Size(49, 15);
            this.rbnAll.TabIndex = 2;
            this.rbnAll.Text = "All";
            // 
            // rbnFilter
            // 
            this.rbnFilter.Location = new System.Drawing.Point(8, 16);
            this.rbnFilter.Name = "rbnFilter";
            this.rbnFilter.Size = new System.Drawing.Size(16, 14);
            this.rbnFilter.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.chkIncludeDeleteChart);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(229, 19);
            this.pnlTop.TabIndex = 0;
            // 
            // chkIncludeDeleteChart
            // 
            this.chkIncludeDeleteChart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIncludeDeleteChart.Location = new System.Drawing.Point(8, 4);
            this.chkIncludeDeleteChart.Name = "chkIncludeDeleteChart";
            this.chkIncludeDeleteChart.Size = new System.Drawing.Size(196, 14);
            this.chkIncludeDeleteChart.TabIndex = 0;
            this.chkIncludeDeleteChart.Text = "Include Deleted Chart";
            this.chkIncludeDeleteChart.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.grpChart);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(232, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlRight.Size = new System.Drawing.Size(510, 506);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabVersion);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(3, 74);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(507, 429);
            this.pnlTab.TabIndex = 1;
            // 
            // tabVersion
            // 
            this.tabVersion.Controls.Add(this.tbpGeneral);
            this.tabVersion.Controls.Add(this.tbpAutoCalculation);
            this.tabVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVersion.ItemSize = new System.Drawing.Size(60, 18);
            this.tabVersion.Location = new System.Drawing.Point(0, 5);
            this.tabVersion.Name = "tabVersion";
            this.tabVersion.SelectedIndex = 0;
            this.tabVersion.Size = new System.Drawing.Size(507, 424);
            this.tabVersion.TabIndex = 0;
            this.tabVersion.SelectedIndexChanged += new System.EventHandler(this.tabVersion_SelectedIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpDateTime);
            this.tbpGeneral.Controls.Add(this.pnlMidTop);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(499, 398);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpDateTime
            // 
            this.grpDateTime.Controls.Add(this.txtReleaseTime);
            this.grpDateTime.Controls.Add(this.txtReleaseUser);
            this.grpDateTime.Controls.Add(this.lblRelease);
            this.grpDateTime.Controls.Add(this.txtUpdateTime);
            this.grpDateTime.Controls.Add(this.txtCreateTime);
            this.grpDateTime.Controls.Add(this.txtUpdateUser);
            this.grpDateTime.Controls.Add(this.lblUpdate);
            this.grpDateTime.Controls.Add(this.txtCreateUser);
            this.grpDateTime.Controls.Add(this.lblCreate);
            this.grpDateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDateTime.Location = new System.Drawing.Point(3, 304);
            this.grpDateTime.Name = "grpDateTime";
            this.grpDateTime.Size = new System.Drawing.Size(493, 92);
            this.grpDateTime.TabIndex = 1;
            this.grpDateTime.TabStop = false;
            // 
            // txtReleaseTime
            // 
            this.txtReleaseTime.Location = new System.Drawing.Point(306, 65);
            this.txtReleaseTime.MaxLength = 20;
            this.txtReleaseTime.Name = "txtReleaseTime";
            this.txtReleaseTime.ReadOnly = true;
            this.txtReleaseTime.Size = new System.Drawing.Size(174, 21);
            this.txtReleaseTime.TabIndex = 8;
            // 
            // txtReleaseUser
            // 
            this.txtReleaseUser.Location = new System.Drawing.Point(126, 65);
            this.txtReleaseUser.MaxLength = 20;
            this.txtReleaseUser.Name = "txtReleaseUser";
            this.txtReleaseUser.ReadOnly = true;
            this.txtReleaseUser.Size = new System.Drawing.Size(177, 21);
            this.txtReleaseUser.TabIndex = 7;
            // 
            // lblRelease
            // 
            this.lblRelease.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRelease.Location = new System.Drawing.Point(10, 68);
            this.lblRelease.Name = "lblRelease";
            this.lblRelease.Size = new System.Drawing.Size(100, 14);
            this.lblRelease.TabIndex = 6;
            this.lblRelease.Text = "Release User/Time";
            this.lblRelease.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(306, 40);
            this.txtUpdateTime.MaxLength = 20;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 21);
            this.txtUpdateTime.TabIndex = 5;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(306, 16);
            this.txtCreateTime.MaxLength = 20;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 21);
            this.txtCreateTime.TabIndex = 2;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(126, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 21);
            this.txtUpdateUser.TabIndex = 4;
            // 
            // lblUpdate
            // 
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(10, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(100, 14);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(126, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 21);
            this.txtCreateUser.TabIndex = 1;
            // 
            // lblCreate
            // 
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(10, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(100, 14);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMidTop
            // 
            this.pnlMidTop.Controls.Add(this.pnlMidRight);
            this.pnlMidTop.Controls.Add(this.pnlMidLeft);
            this.pnlMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidTop.Location = new System.Drawing.Point(3, 0);
            this.pnlMidTop.Name = "pnlMidTop";
            this.pnlMidTop.Size = new System.Drawing.Size(493, 304);
            this.pnlMidTop.TabIndex = 0;
            // 
            // pnlMidRight
            // 
            this.pnlMidRight.Controls.Add(this.grpComment);
            this.pnlMidRight.Controls.Add(this.grpSpec);
            this.pnlMidRight.Controls.Add(this.grpVersion);
            this.pnlMidRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMidRight.Location = new System.Drawing.Point(152, 0);
            this.pnlMidRight.Name = "pnlMidRight";
            this.pnlMidRight.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlMidRight.Size = new System.Drawing.Size(341, 304);
            this.pnlMidRight.TabIndex = 0;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(3, 262);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(338, 42);
            this.grpComment.TabIndex = 2;
            this.grpComment.TabStop = false;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Location = new System.Drawing.Point(8, 18);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(66, 12);
            this.txtComment.MaxLength = 200;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(266, 24);
            this.txtComment.TabIndex = 1;
            // 
            // grpSpec
            // 
            this.grpSpec.Controls.Add(this.txtTARGET);
            this.grpSpec.Controls.Add(this.lblTARGET);
            this.grpSpec.Controls.Add(this.txtLCL2);
            this.grpSpec.Controls.Add(this.lblLCL2);
            this.grpSpec.Controls.Add(this.txtCL2);
            this.grpSpec.Controls.Add(this.lblCL2);
            this.grpSpec.Controls.Add(this.txtLCL);
            this.grpSpec.Controls.Add(this.lblLCL);
            this.grpSpec.Controls.Add(this.txtCL);
            this.grpSpec.Controls.Add(this.lblCL);
            this.grpSpec.Controls.Add(this.txtUCL);
            this.grpSpec.Controls.Add(this.lblUCL);
            this.grpSpec.Controls.Add(this.txtUCL2);
            this.grpSpec.Controls.Add(this.lblUCL2);
            this.grpSpec.Controls.Add(this.txtLSL);
            this.grpSpec.Controls.Add(this.lblLSL);
            this.grpSpec.Controls.Add(this.txtUSL);
            this.grpSpec.Controls.Add(this.lblUSL);
            this.grpSpec.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSpec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSpec.Location = new System.Drawing.Point(3, 112);
            this.grpSpec.Name = "grpSpec";
            this.grpSpec.Size = new System.Drawing.Size(338, 150);
            this.grpSpec.TabIndex = 1;
            this.grpSpec.TabStop = false;
            // 
            // txtTARGET
            // 
            appearance20.TextHAlignAsString = "Right";
            appearance20.TextVAlignAsString = "Middle";
            this.txtTARGET.Appearance = appearance20;
            this.txtTARGET.Location = new System.Drawing.Point(224, 16);
            this.txtTARGET.MaxLength = 20;
            this.txtTARGET.Name = "txtTARGET";
            this.txtTARGET.Size = new System.Drawing.Size(109, 21);
            this.txtTARGET.TabIndex = 11;
            this.txtTARGET.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblTARGET
            // 
            this.lblTARGET.AutoSize = true;
            this.lblTARGET.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTARGET.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTARGET.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTARGET.Location = new System.Drawing.Point(171, 20);
            this.lblTARGET.Name = "lblTARGET";
            this.lblTARGET.Size = new System.Drawing.Size(57, 13);
            this.lblTARGET.TabIndex = 10;
            this.lblTARGET.Tag = "";
            this.lblTARGET.Text = "TARGET";
            // 
            // txtLCL2
            // 
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.txtLCL2.Appearance = appearance2;
            this.txtLCL2.Location = new System.Drawing.Point(224, 120);
            this.txtLCL2.MaxLength = 20;
            this.txtLCL2.Name = "txtLCL2";
            this.txtLCL2.Size = new System.Drawing.Size(109, 21);
            this.txtLCL2.TabIndex = 17;
            this.txtLCL2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblLCL2
            // 
            this.lblLCL2.AutoSize = true;
            this.lblLCL2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLCL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCL2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLCL2.Location = new System.Drawing.Point(171, 124);
            this.lblLCL2.Name = "lblLCL2";
            this.lblLCL2.Size = new System.Drawing.Size(36, 13);
            this.lblLCL2.TabIndex = 16;
            this.lblLCL2.Text = "LCL2";
            // 
            // txtCL2
            // 
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.txtCL2.Appearance = appearance3;
            this.txtCL2.Location = new System.Drawing.Point(224, 94);
            this.txtCL2.MaxLength = 20;
            this.txtCL2.Name = "txtCL2";
            this.txtCL2.Size = new System.Drawing.Size(109, 21);
            this.txtCL2.TabIndex = 15;
            this.txtCL2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblCL2
            // 
            this.lblCL2.AutoSize = true;
            this.lblCL2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCL2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCL2.Location = new System.Drawing.Point(171, 98);
            this.lblCL2.Name = "lblCL2";
            this.lblCL2.Size = new System.Drawing.Size(29, 13);
            this.lblCL2.TabIndex = 14;
            this.lblCL2.Text = "CL2";
            // 
            // txtLCL
            // 
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.txtLCL.Appearance = appearance4;
            this.txtLCL.Location = new System.Drawing.Point(52, 94);
            this.txtLCL.MaxLength = 20;
            this.txtLCL.Name = "txtLCL";
            this.txtLCL.Size = new System.Drawing.Size(109, 21);
            this.txtLCL.TabIndex = 7;
            this.txtLCL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblLCL
            // 
            this.lblLCL.AutoSize = true;
            this.lblLCL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLCL.Location = new System.Drawing.Point(10, 98);
            this.lblLCL.Name = "lblLCL";
            this.lblLCL.Size = new System.Drawing.Size(29, 13);
            this.lblLCL.TabIndex = 6;
            this.lblLCL.Text = "LCL";
            // 
            // txtCL
            // 
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.txtCL.Appearance = appearance5;
            this.txtCL.Location = new System.Drawing.Point(52, 68);
            this.txtCL.MaxLength = 20;
            this.txtCL.Name = "txtCL";
            this.txtCL.Size = new System.Drawing.Size(109, 21);
            this.txtCL.TabIndex = 5;
            this.txtCL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblCL
            // 
            this.lblCL.AutoSize = true;
            this.lblCL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCL.Location = new System.Drawing.Point(10, 72);
            this.lblCL.Name = "lblCL";
            this.lblCL.Size = new System.Drawing.Size(22, 13);
            this.lblCL.TabIndex = 4;
            this.lblCL.Text = "CL";
            // 
            // txtUCL
            // 
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.txtUCL.Appearance = appearance6;
            this.txtUCL.Location = new System.Drawing.Point(52, 42);
            this.txtUCL.MaxLength = 20;
            this.txtUCL.Name = "txtUCL";
            this.txtUCL.Size = new System.Drawing.Size(109, 21);
            this.txtUCL.TabIndex = 3;
            this.txtUCL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblUCL
            // 
            this.lblUCL.AutoSize = true;
            this.lblUCL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUCL.Location = new System.Drawing.Point(10, 46);
            this.lblUCL.Name = "lblUCL";
            this.lblUCL.Size = new System.Drawing.Size(31, 13);
            this.lblUCL.TabIndex = 2;
            this.lblUCL.Text = "UCL";
            // 
            // txtUCL2
            // 
            appearance7.TextHAlignAsString = "Right";
            appearance7.TextVAlignAsString = "Middle";
            this.txtUCL2.Appearance = appearance7;
            this.txtUCL2.Location = new System.Drawing.Point(224, 68);
            this.txtUCL2.MaxLength = 20;
            this.txtUCL2.Name = "txtUCL2";
            this.txtUCL2.Size = new System.Drawing.Size(110, 21);
            this.txtUCL2.TabIndex = 13;
            this.txtUCL2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblUCL2
            // 
            this.lblUCL2.AutoSize = true;
            this.lblUCL2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUCL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCL2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUCL2.Location = new System.Drawing.Point(171, 72);
            this.lblUCL2.Name = "lblUCL2";
            this.lblUCL2.Size = new System.Drawing.Size(38, 13);
            this.lblUCL2.TabIndex = 12;
            this.lblUCL2.Text = "UCL2";
            // 
            // txtLSL
            // 
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.txtLSL.Appearance = appearance8;
            this.txtLSL.Location = new System.Drawing.Point(52, 120);
            this.txtLSL.MaxLength = 20;
            this.txtLSL.Name = "txtLSL";
            this.txtLSL.Size = new System.Drawing.Size(109, 21);
            this.txtLSL.TabIndex = 9;
            this.txtLSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblLSL
            // 
            this.lblLSL.AutoSize = true;
            this.lblLSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLSL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLSL.Location = new System.Drawing.Point(10, 124);
            this.lblLSL.Name = "lblLSL";
            this.lblLSL.Size = new System.Drawing.Size(29, 13);
            this.lblLSL.TabIndex = 8;
            this.lblLSL.Text = "LSL";
            // 
            // txtUSL
            // 
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.txtUSL.Appearance = appearance9;
            this.txtUSL.Location = new System.Drawing.Point(52, 16);
            this.txtUSL.MaxLength = 20;
            this.txtUSL.Name = "txtUSL";
            this.txtUSL.Size = new System.Drawing.Size(109, 21);
            this.txtUSL.TabIndex = 1;
            this.txtUSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblUSL
            // 
            this.lblUSL.AutoSize = true;
            this.lblUSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUSL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUSL.Location = new System.Drawing.Point(10, 20);
            this.lblUSL.Name = "lblUSL";
            this.lblUSL.Size = new System.Drawing.Size(31, 13);
            this.lblUSL.TabIndex = 0;
            this.lblUSL.Text = "USL";
            // 
            // grpVersion
            // 
            this.grpVersion.Controls.Add(this.txtAutoSigma);
            this.grpVersion.Controls.Add(this.label1);
            this.grpVersion.Controls.Add(this.lblReleased);
            this.grpVersion.Controls.Add(this.chkReleased);
            this.grpVersion.Controls.Add(this.chkEnd);
            this.grpVersion.Controls.Add(this.txtEndTime);
            this.grpVersion.Controls.Add(this.txtStartTime);
            this.grpVersion.Controls.Add(this.lblEnd);
            this.grpVersion.Controls.Add(this.lblStart);
            this.grpVersion.Controls.Add(this.udtStart);
            this.grpVersion.Controls.Add(this.udtEnd);
            this.grpVersion.Controls.Add(this.uccEnd);
            this.grpVersion.Controls.Add(this.uccStart);
            this.grpVersion.Controls.Add(this.lblAuto);
            this.grpVersion.Controls.Add(this.chkAutoCalFlag);
            this.grpVersion.Controls.Add(this.lblFromTo);
            this.grpVersion.Controls.Add(this.chkStart);
            this.grpVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpVersion.Location = new System.Drawing.Point(3, 0);
            this.grpVersion.Name = "grpVersion";
            this.grpVersion.Size = new System.Drawing.Size(338, 112);
            this.grpVersion.TabIndex = 0;
            this.grpVersion.TabStop = false;
            // 
            // txtAutoSigma
            // 
            this.txtAutoSigma.Location = new System.Drawing.Point(124, 85);
            this.txtAutoSigma.MaxLength = 30;
            this.txtAutoSigma.Name = "txtAutoSigma";
            this.txtAutoSigma.ReadOnly = true;
            this.txtAutoSigma.Size = new System.Drawing.Size(168, 21);
            this.txtAutoSigma.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(29, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Auto Sigma W/B";
            // 
            // lblReleased
            // 
            this.lblReleased.AutoSize = true;
            this.lblReleased.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReleased.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleased.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReleased.Location = new System.Drawing.Point(225, 68);
            this.lblReleased.Name = "lblReleased";
            this.lblReleased.Size = new System.Drawing.Size(52, 13);
            this.lblReleased.TabIndex = 12;
            this.lblReleased.Text = "Released";
            // 
            // chkReleased
            // 
            this.chkReleased.Enabled = false;
            this.chkReleased.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkReleased.Location = new System.Drawing.Point(207, 68);
            this.chkReleased.Name = "chkReleased";
            this.chkReleased.Size = new System.Drawing.Size(16, 14);
            this.chkReleased.TabIndex = 11;
            this.chkReleased.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkEnd
            // 
            this.chkEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkEnd.Location = new System.Drawing.Point(12, 44);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(16, 14);
            this.chkEnd.TabIndex = 5;
            this.chkEnd.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(124, 40);
            this.txtEndTime.MaxLength = 30;
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.ReadOnly = true;
            this.txtEndTime.Size = new System.Drawing.Size(168, 21);
            this.txtEndTime.TabIndex = 7;
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(124, 16);
            this.txtStartTime.MaxLength = 30;
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(168, 21);
            this.txtStartTime.TabIndex = 2;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEnd.Location = new System.Drawing.Point(29, 44);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(81, 13);
            this.lblEnd.TabIndex = 6;
            this.lblEnd.Text = "Apply End Time";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblStart.Location = new System.Drawing.Point(29, 19);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(84, 13);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "Apply Start Time";
            // 
            // udtStart
            // 
            this.udtStart.DateTime = new System.DateTime(2005, 6, 17, 0, 0, 0, 0);
            this.udtStart.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtStart.FormatString = "";
            this.udtStart.Location = new System.Drawing.Point(217, 16);
            this.udtStart.MaskInput = "hh:mm:ss";
            this.udtStart.Name = "udtStart";
            this.udtStart.Size = new System.Drawing.Size(72, 21);
            this.udtStart.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtStart.SpinWrap = true;
            this.udtStart.TabIndex = 3;
            this.udtStart.Value = new System.DateTime(2005, 6, 17, 0, 0, 0, 0);
            // 
            // udtEnd
            // 
            this.udtEnd.DateTime = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            this.udtEnd.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtEnd.FormatString = "";
            this.udtEnd.Location = new System.Drawing.Point(217, 40);
            this.udtEnd.MaskInput = "hh:mm:ss";
            this.udtEnd.Name = "udtEnd";
            this.udtEnd.Size = new System.Drawing.Size(72, 21);
            this.udtEnd.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtEnd.SpinWrap = true;
            this.udtEnd.TabIndex = 8;
            this.udtEnd.Value = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            // 
            // uccEnd
            // 
            this.uccEnd.DateButtons.Add(dateButton1);
            this.uccEnd.Location = new System.Drawing.Point(124, 40);
            this.uccEnd.Name = "uccEnd";
            this.uccEnd.NonAutoSizeHeight = 21;
            this.uccEnd.Size = new System.Drawing.Size(88, 21);
            this.uccEnd.TabIndex = 8;
            this.uccEnd.Value = new System.DateTime(2005, 5, 23, 0, 0, 0, 0);
            // 
            // uccStart
            // 
            this.uccStart.DateButtons.Add(dateButton2);
            this.uccStart.Location = new System.Drawing.Point(124, 16);
            this.uccStart.Name = "uccStart";
            this.uccStart.NonAutoSizeHeight = 21;
            this.uccStart.Size = new System.Drawing.Size(88, 21);
            this.uccStart.TabIndex = 3;
            this.uccStart.Value = new System.DateTime(2005, 5, 23, 0, 0, 0, 0);
            // 
            // lblAuto
            // 
            this.lblAuto.AutoSize = true;
            this.lblAuto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAuto.Location = new System.Drawing.Point(29, 68);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(167, 13);
            this.lblAuto.TabIndex = 10;
            this.lblAuto.Text = "Auto Control Limit Calculation Flag";
            // 
            // chkAutoCalFlag
            // 
            this.chkAutoCalFlag.Enabled = false;
            this.chkAutoCalFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoCalFlag.Location = new System.Drawing.Point(12, 68);
            this.chkAutoCalFlag.Name = "chkAutoCalFlag";
            this.chkAutoCalFlag.Size = new System.Drawing.Size(16, 14);
            this.chkAutoCalFlag.TabIndex = 9;
            this.chkAutoCalFlag.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblFromTo
            // 
            this.lblFromTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromTo.Location = new System.Drawing.Point(298, 20);
            this.lblFromTo.Name = "lblFromTo";
            this.lblFromTo.Size = new System.Drawing.Size(11, 10);
            this.lblFromTo.TabIndex = 4;
            this.lblFromTo.Text = "~";
            this.lblFromTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkStart
            // 
            this.chkStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkStart.Location = new System.Drawing.Point(12, 19);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(16, 14);
            this.chkStart.TabIndex = 0;
            this.chkStart.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // pnlMidLeft
            // 
            this.pnlMidLeft.Controls.Add(this.lisVersion);
            this.pnlMidLeft.Controls.Add(this.pnlVersion);
            this.pnlMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlMidLeft.Name = "pnlMidLeft";
            this.pnlMidLeft.Size = new System.Drawing.Size(152, 304);
            this.pnlMidLeft.TabIndex = 0;
            // 
            // lisVersion
            // 
            this.lisVersion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader4});
            this.lisVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisVersion.EnableSort = true;
            this.lisVersion.EnableSortIcon = true;
            this.lisVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisVersion.FullRowSelect = true;
            this.lisVersion.Location = new System.Drawing.Point(0, 36);
            this.lisVersion.MultiSelect = false;
            this.lisVersion.Name = "lisVersion";
            this.lisVersion.Size = new System.Drawing.Size(152, 268);
            this.lisVersion.TabIndex = 1;
            this.lisVersion.UseCompatibleStateImageBehavior = false;
            this.lisVersion.View = System.Windows.Forms.View.Details;
            this.lisVersion.SelectedIndexChanged += new System.EventHandler(this.lisVersion_SelectedIndexChanged);
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Version";
            this.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Release";
            this.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlVersion
            // 
            this.pnlVersion.Controls.Add(this.lblVersion);
            this.pnlVersion.Controls.Add(this.txtVersion);
            this.pnlVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVersion.Location = new System.Drawing.Point(0, 0);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Size = new System.Drawing.Size(152, 36);
            this.pnlVersion.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(8, 11);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(56, 14);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(72, 8);
            this.txtVersion.MaxLength = 6;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(72, 21);
            this.txtVersion.TabIndex = 1;
            this.txtVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // tbpAutoCalculation
            // 
            this.tbpAutoCalculation.Controls.Add(this.pnlSpecInfo);
            this.tbpAutoCalculation.Controls.Add(this.pnlCalculation);
            this.tbpAutoCalculation.Controls.Add(this.grbOptions);
            this.tbpAutoCalculation.Controls.Add(this.grpSelPeriod);
            this.tbpAutoCalculation.Controls.Add(this.grpSelChart);
            this.tbpAutoCalculation.Location = new System.Drawing.Point(4, 22);
            this.tbpAutoCalculation.Name = "tbpAutoCalculation";
            this.tbpAutoCalculation.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAutoCalculation.Size = new System.Drawing.Size(499, 398);
            this.tbpAutoCalculation.TabIndex = 1;
            this.tbpAutoCalculation.Text = "Auto Calculation";
            // 
            // pnlSpecInfo
            // 
            this.pnlSpecInfo.Controls.Add(this.grpAutoSpec);
            this.pnlSpecInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSpecInfo.Location = new System.Drawing.Point(3, 250);
            this.pnlSpecInfo.Name = "pnlSpecInfo";
            this.pnlSpecInfo.Size = new System.Drawing.Size(493, 145);
            this.pnlSpecInfo.TabIndex = 4;
            // 
            // grpAutoSpec
            // 
            this.grpAutoSpec.Controls.Add(this.txtAutoTarget);
            this.grpAutoSpec.Controls.Add(this.lblAutoTarget);
            this.grpAutoSpec.Controls.Add(this.txtAutoLCL2);
            this.grpAutoSpec.Controls.Add(this.lblAutoLCL2);
            this.grpAutoSpec.Controls.Add(this.txtAutoCL2);
            this.grpAutoSpec.Controls.Add(this.lblAutoCL2);
            this.grpAutoSpec.Controls.Add(this.txtAutoLCL);
            this.grpAutoSpec.Controls.Add(this.lblAutoLCL);
            this.grpAutoSpec.Controls.Add(this.txtAutoCL);
            this.grpAutoSpec.Controls.Add(this.lblAutoCL);
            this.grpAutoSpec.Controls.Add(this.txtAutoUCL);
            this.grpAutoSpec.Controls.Add(this.lblAutoUCL);
            this.grpAutoSpec.Controls.Add(this.txtAutoUCL2);
            this.grpAutoSpec.Controls.Add(this.lblAutoUCL2);
            this.grpAutoSpec.Controls.Add(this.txtAutoLSL);
            this.grpAutoSpec.Controls.Add(this.lblAutoLSL);
            this.grpAutoSpec.Controls.Add(this.txtAutoUSL);
            this.grpAutoSpec.Controls.Add(this.lblAutoUSL);
            this.grpAutoSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAutoSpec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAutoSpec.Location = new System.Drawing.Point(0, 0);
            this.grpAutoSpec.Name = "grpAutoSpec";
            this.grpAutoSpec.Size = new System.Drawing.Size(493, 145);
            this.grpAutoSpec.TabIndex = 0;
            this.grpAutoSpec.TabStop = false;
            // 
            // txtAutoTarget
            // 
            appearance10.TextHAlignAsString = "Right";
            appearance10.TextVAlignAsString = "Middle";
            this.txtAutoTarget.Appearance = appearance10;
            this.txtAutoTarget.Location = new System.Drawing.Point(262, 16);
            this.txtAutoTarget.MaxLength = 20;
            this.txtAutoTarget.Name = "txtAutoTarget";
            this.txtAutoTarget.ReadOnly = true;
            this.txtAutoTarget.Size = new System.Drawing.Size(102, 21);
            this.txtAutoTarget.TabIndex = 11;
            // 
            // lblAutoTarget
            // 
            this.lblAutoTarget.AutoSize = true;
            this.lblAutoTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoTarget.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoTarget.Location = new System.Drawing.Point(214, 20);
            this.lblAutoTarget.Name = "lblAutoTarget";
            this.lblAutoTarget.Size = new System.Drawing.Size(38, 13);
            this.lblAutoTarget.TabIndex = 10;
            this.lblAutoTarget.Text = "Target";
            // 
            // txtAutoLCL2
            // 
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.txtAutoLCL2.Appearance = appearance11;
            this.txtAutoLCL2.Location = new System.Drawing.Point(262, 116);
            this.txtAutoLCL2.MaxLength = 20;
            this.txtAutoLCL2.Name = "txtAutoLCL2";
            this.txtAutoLCL2.ReadOnly = true;
            this.txtAutoLCL2.Size = new System.Drawing.Size(102, 21);
            this.txtAutoLCL2.TabIndex = 17;
            // 
            // lblAutoLCL2
            // 
            this.lblAutoLCL2.AutoSize = true;
            this.lblAutoLCL2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoLCL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoLCL2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoLCL2.Location = new System.Drawing.Point(214, 120);
            this.lblAutoLCL2.Name = "lblAutoLCL2";
            this.lblAutoLCL2.Size = new System.Drawing.Size(32, 13);
            this.lblAutoLCL2.TabIndex = 16;
            this.lblAutoLCL2.Text = "LCL2";
            // 
            // txtAutoCL2
            // 
            appearance12.TextHAlignAsString = "Right";
            appearance12.TextVAlignAsString = "Middle";
            this.txtAutoCL2.Appearance = appearance12;
            this.txtAutoCL2.Location = new System.Drawing.Point(262, 91);
            this.txtAutoCL2.MaxLength = 20;
            this.txtAutoCL2.Name = "txtAutoCL2";
            this.txtAutoCL2.ReadOnly = true;
            this.txtAutoCL2.Size = new System.Drawing.Size(102, 21);
            this.txtAutoCL2.TabIndex = 15;
            // 
            // lblAutoCL2
            // 
            this.lblAutoCL2.AutoSize = true;
            this.lblAutoCL2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoCL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoCL2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoCL2.Location = new System.Drawing.Point(214, 95);
            this.lblAutoCL2.Name = "lblAutoCL2";
            this.lblAutoCL2.Size = new System.Drawing.Size(26, 13);
            this.lblAutoCL2.TabIndex = 14;
            this.lblAutoCL2.Text = "CL2";
            // 
            // txtAutoLCL
            // 
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.txtAutoLCL.Appearance = appearance13;
            this.txtAutoLCL.Location = new System.Drawing.Point(58, 91);
            this.txtAutoLCL.MaxLength = 20;
            this.txtAutoLCL.Name = "txtAutoLCL";
            this.txtAutoLCL.ReadOnly = true;
            this.txtAutoLCL.Size = new System.Drawing.Size(102, 21);
            this.txtAutoLCL.TabIndex = 7;
            // 
            // lblAutoLCL
            // 
            this.lblAutoLCL.AutoSize = true;
            this.lblAutoLCL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoLCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoLCL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoLCL.Location = new System.Drawing.Point(10, 95);
            this.lblAutoLCL.Name = "lblAutoLCL";
            this.lblAutoLCL.Size = new System.Drawing.Size(26, 13);
            this.lblAutoLCL.TabIndex = 6;
            this.lblAutoLCL.Text = "LCL";
            // 
            // txtAutoCL
            // 
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.txtAutoCL.Appearance = appearance14;
            this.txtAutoCL.Location = new System.Drawing.Point(58, 66);
            this.txtAutoCL.MaxLength = 20;
            this.txtAutoCL.Name = "txtAutoCL";
            this.txtAutoCL.ReadOnly = true;
            this.txtAutoCL.Size = new System.Drawing.Size(102, 21);
            this.txtAutoCL.TabIndex = 5;
            // 
            // lblAutoCL
            // 
            this.lblAutoCL.AutoSize = true;
            this.lblAutoCL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoCL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoCL.Location = new System.Drawing.Point(10, 70);
            this.lblAutoCL.Name = "lblAutoCL";
            this.lblAutoCL.Size = new System.Drawing.Size(20, 13);
            this.lblAutoCL.TabIndex = 4;
            this.lblAutoCL.Text = "CL";
            // 
            // txtAutoUCL
            // 
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.txtAutoUCL.Appearance = appearance15;
            this.txtAutoUCL.Location = new System.Drawing.Point(58, 41);
            this.txtAutoUCL.MaxLength = 20;
            this.txtAutoUCL.Name = "txtAutoUCL";
            this.txtAutoUCL.ReadOnly = true;
            this.txtAutoUCL.Size = new System.Drawing.Size(102, 21);
            this.txtAutoUCL.TabIndex = 3;
            // 
            // lblAutoUCL
            // 
            this.lblAutoUCL.AutoSize = true;
            this.lblAutoUCL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoUCL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoUCL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoUCL.Location = new System.Drawing.Point(10, 45);
            this.lblAutoUCL.Name = "lblAutoUCL";
            this.lblAutoUCL.Size = new System.Drawing.Size(28, 13);
            this.lblAutoUCL.TabIndex = 2;
            this.lblAutoUCL.Text = "UCL";
            // 
            // txtAutoUCL2
            // 
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.txtAutoUCL2.Appearance = appearance16;
            this.txtAutoUCL2.Location = new System.Drawing.Point(262, 66);
            this.txtAutoUCL2.MaxLength = 20;
            this.txtAutoUCL2.Name = "txtAutoUCL2";
            this.txtAutoUCL2.ReadOnly = true;
            this.txtAutoUCL2.Size = new System.Drawing.Size(102, 21);
            this.txtAutoUCL2.TabIndex = 13;
            // 
            // lblAutoUCL2
            // 
            this.lblAutoUCL2.AutoSize = true;
            this.lblAutoUCL2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoUCL2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoUCL2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoUCL2.Location = new System.Drawing.Point(214, 70);
            this.lblAutoUCL2.Name = "lblAutoUCL2";
            this.lblAutoUCL2.Size = new System.Drawing.Size(34, 13);
            this.lblAutoUCL2.TabIndex = 12;
            this.lblAutoUCL2.Text = "UCL2";
            // 
            // txtAutoLSL
            // 
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.txtAutoLSL.Appearance = appearance17;
            this.txtAutoLSL.Location = new System.Drawing.Point(58, 116);
            this.txtAutoLSL.MaxLength = 20;
            this.txtAutoLSL.Name = "txtAutoLSL";
            this.txtAutoLSL.ReadOnly = true;
            this.txtAutoLSL.Size = new System.Drawing.Size(102, 21);
            this.txtAutoLSL.TabIndex = 9;
            // 
            // lblAutoLSL
            // 
            this.lblAutoLSL.AutoSize = true;
            this.lblAutoLSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoLSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoLSL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoLSL.Location = new System.Drawing.Point(10, 120);
            this.lblAutoLSL.Name = "lblAutoLSL";
            this.lblAutoLSL.Size = new System.Drawing.Size(26, 13);
            this.lblAutoLSL.TabIndex = 8;
            this.lblAutoLSL.Text = "LSL";
            // 
            // txtAutoUSL
            // 
            appearance18.TextHAlignAsString = "Right";
            appearance18.TextVAlignAsString = "Middle";
            this.txtAutoUSL.Appearance = appearance18;
            this.txtAutoUSL.Location = new System.Drawing.Point(58, 16);
            this.txtAutoUSL.MaxLength = 20;
            this.txtAutoUSL.Name = "txtAutoUSL";
            this.txtAutoUSL.ReadOnly = true;
            this.txtAutoUSL.Size = new System.Drawing.Size(102, 21);
            this.txtAutoUSL.TabIndex = 1;
            // 
            // lblAutoUSL
            // 
            this.lblAutoUSL.AutoSize = true;
            this.lblAutoUSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAutoUSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoUSL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoUSL.Location = new System.Drawing.Point(10, 20);
            this.lblAutoUSL.Name = "lblAutoUSL";
            this.lblAutoUSL.Size = new System.Drawing.Size(28, 13);
            this.lblAutoUSL.TabIndex = 0;
            this.lblAutoUSL.Text = "USL";
            // 
            // pnlCalculation
            // 
            this.pnlCalculation.Controls.Add(this.btnCalculation);
            this.pnlCalculation.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCalculation.Location = new System.Drawing.Point(3, 216);
            this.pnlCalculation.Name = "pnlCalculation";
            this.pnlCalculation.Size = new System.Drawing.Size(493, 34);
            this.pnlCalculation.TabIndex = 3;
            // 
            // btnCalculation
            // 
            this.btnCalculation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculation.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCalculation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCalculation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCalculation.Location = new System.Drawing.Point(400, 4);
            this.btnCalculation.Name = "btnCalculation";
            this.btnCalculation.Size = new System.Drawing.Size(88, 26);
            this.btnCalculation.TabIndex = 0;
            this.btnCalculation.Text = "Calculation";
            this.btnCalculation.Click += new System.EventHandler(this.btnCalculation_Click);
            // 
            // grbOptions
            // 
            this.grbOptions.Controls.Add(this.chkAutoRelease);
            this.grbOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbOptions.Location = new System.Drawing.Point(3, 167);
            this.grbOptions.Name = "grbOptions";
            this.grbOptions.Size = new System.Drawing.Size(493, 49);
            this.grbOptions.TabIndex = 2;
            this.grbOptions.TabStop = false;
            this.grbOptions.Text = "Options";
            // 
            // chkAutoRelease
            // 
            this.chkAutoRelease.AutoSize = true;
            this.chkAutoRelease.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoRelease.Location = new System.Drawing.Point(19, 23);
            this.chkAutoRelease.Name = "chkAutoRelease";
            this.chkAutoRelease.Size = new System.Drawing.Size(89, 17);
            this.chkAutoRelease.TabIndex = 0;
            this.chkAutoRelease.Text = "Auto Release";
            this.chkAutoRelease.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // grpSelPeriod
            // 
            this.grpSelPeriod.Controls.Add(this.txtTo);
            this.grpSelPeriod.Controls.Add(this.txtFrom);
            this.grpSelPeriod.Controls.Add(this.udtFrom);
            this.grpSelPeriod.Controls.Add(this.udtTo);
            this.grpSelPeriod.Controls.Add(this.uccTo);
            this.grpSelPeriod.Controls.Add(this.uccFrom);
            this.grpSelPeriod.Controls.Add(this.lblPeriod);
            this.grpSelPeriod.Controls.Add(this.rbnCurrentPeriod);
            this.grpSelPeriod.Controls.Add(this.rbnUserSelectPeriod);
            this.grpSelPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSelPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSelPeriod.Location = new System.Drawing.Point(3, 69);
            this.grpSelPeriod.Name = "grpSelPeriod";
            this.grpSelPeriod.Size = new System.Drawing.Size(493, 98);
            this.grpSelPeriod.TabIndex = 1;
            this.grpSelPeriod.TabStop = false;
            this.grpSelPeriod.Text = "Select Period";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(227, 65);
            this.txtTo.MaxLength = 30;
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.ReadOnly = true;
            this.txtTo.Size = new System.Drawing.Size(168, 22);
            this.txtTo.TabIndex = 6;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(35, 65);
            this.txtFrom.MaxLength = 30;
            this.txtFrom.Multiline = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(168, 22);
            this.txtFrom.TabIndex = 2;
            // 
            // udtFrom
            // 
            this.udtFrom.DateTime = new System.DateTime(2005, 6, 17, 0, 0, 0, 0);
            this.udtFrom.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtFrom.FormatString = "";
            this.udtFrom.Location = new System.Drawing.Point(127, 65);
            this.udtFrom.MaskInput = "hh:mm:ss";
            this.udtFrom.Name = "udtFrom";
            this.udtFrom.Size = new System.Drawing.Size(72, 21);
            this.udtFrom.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtFrom.SpinWrap = true;
            this.udtFrom.TabIndex = 4;
            this.udtFrom.Value = new System.DateTime(2005, 6, 17, 0, 0, 0, 0);
            // 
            // udtTo
            // 
            this.udtTo.DateTime = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            this.udtTo.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.udtTo.FormatString = "";
            this.udtTo.Location = new System.Drawing.Point(319, 65);
            this.udtTo.MaskInput = "hh:mm:ss";
            this.udtTo.Name = "udtTo";
            this.udtTo.Size = new System.Drawing.Size(72, 21);
            this.udtTo.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtTo.SpinWrap = true;
            this.udtTo.TabIndex = 8;
            this.udtTo.Value = new System.DateTime(2005, 5, 4, 23, 59, 59, 0);
            // 
            // uccTo
            // 
            this.uccTo.DateButtons.Add(dateButton3);
            this.uccTo.Location = new System.Drawing.Point(227, 65);
            this.uccTo.Name = "uccTo";
            this.uccTo.NonAutoSizeHeight = 21;
            this.uccTo.Size = new System.Drawing.Size(88, 21);
            this.uccTo.TabIndex = 7;
            this.uccTo.Value = new System.DateTime(2005, 5, 23, 0, 0, 0, 0);
            // 
            // uccFrom
            // 
            this.uccFrom.DateButtons.Add(dateButton4);
            this.uccFrom.Location = new System.Drawing.Point(35, 65);
            this.uccFrom.Name = "uccFrom";
            this.uccFrom.NonAutoSizeHeight = 21;
            this.uccFrom.Size = new System.Drawing.Size(88, 21);
            this.uccFrom.TabIndex = 3;
            this.uccFrom.Value = new System.DateTime(2005, 5, 23, 0, 0, 0, 0);
            // 
            // lblPeriod
            // 
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Location = new System.Drawing.Point(210, 73);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(11, 10);
            this.lblPeriod.TabIndex = 5;
            this.lblPeriod.Text = "~";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbnCurrentPeriod
            // 
            this.rbnCurrentPeriod.AutoSize = true;
            this.rbnCurrentPeriod.Checked = true;
            this.rbnCurrentPeriod.Location = new System.Drawing.Point(19, 24);
            this.rbnCurrentPeriod.Name = "rbnCurrentPeriod";
            this.rbnCurrentPeriod.Size = new System.Drawing.Size(149, 17);
            this.rbnCurrentPeriod.TabIndex = 0;
            this.rbnCurrentPeriod.TabStop = true;
            this.rbnCurrentPeriod.Text = "Apply Current Chart Period";
            // 
            // rbnUserSelectPeriod
            // 
            this.rbnUserSelectPeriod.AutoSize = true;
            this.rbnUserSelectPeriod.Location = new System.Drawing.Point(19, 44);
            this.rbnUserSelectPeriod.Name = "rbnUserSelectPeriod";
            this.rbnUserSelectPeriod.Size = new System.Drawing.Size(113, 17);
            this.rbnUserSelectPeriod.TabIndex = 1;
            this.rbnUserSelectPeriod.Text = "User Select Period";
            this.rbnUserSelectPeriod.CheckedChanged += new System.EventHandler(this.rbnUserSelectPeriod_CheckedChanged);
            // 
            // grpSelChart
            // 
            this.grpSelChart.Controls.Add(this.rbnCurrentChart);
            this.grpSelChart.Controls.Add(this.rbnAllChart);
            this.grpSelChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSelChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSelChart.Location = new System.Drawing.Point(3, 3);
            this.grpSelChart.Name = "grpSelChart";
            this.grpSelChart.Size = new System.Drawing.Size(493, 66);
            this.grpSelChart.TabIndex = 0;
            this.grpSelChart.TabStop = false;
            this.grpSelChart.Text = "Select Chart";
            // 
            // rbnCurrentChart
            // 
            this.rbnCurrentChart.AutoSize = true;
            this.rbnCurrentChart.Checked = true;
            this.rbnCurrentChart.Location = new System.Drawing.Point(19, 20);
            this.rbnCurrentChart.Name = "rbnCurrentChart";
            this.rbnCurrentChart.Size = new System.Drawing.Size(142, 17);
            this.rbnCurrentChart.TabIndex = 0;
            this.rbnCurrentChart.TabStop = true;
            this.rbnCurrentChart.Text = "Current Chart Calculation";
            // 
            // rbnAllChart
            // 
            this.rbnAllChart.AutoSize = true;
            this.rbnAllChart.Location = new System.Drawing.Point(19, 40);
            this.rbnAllChart.Name = "rbnAllChart";
            this.rbnAllChart.Size = new System.Drawing.Size(119, 17);
            this.rbnAllChart.TabIndex = 1;
            this.rbnAllChart.Text = "All Chart Calculation";
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.btnFiltering);
            this.grpChart.Controls.Add(this.cboGraphType);
            this.grpChart.Controls.Add(this.lblDesc);
            this.grpChart.Controls.Add(this.lblChart);
            this.grpChart.Controls.Add(this.txtDesc);
            this.grpChart.Controls.Add(this.txtChart);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(3, 3);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(507, 71);
            this.grpChart.TabIndex = 0;
            this.grpChart.TabStop = false;
            // 
            // btnFiltering
            // 
            this.btnFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering.Image")));
            this.btnFiltering.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering.Location = new System.Drawing.Point(324, 14);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 2;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cboGraphType
            // 
            this.cboGraphType.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
            this.cboGraphType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cboGraphType.Location = new System.Drawing.Point(352, 17);
            this.cboGraphType.Name = "cboGraphType";
            this.cboGraphType.ReadOnly = true;
            this.cboGraphType.Size = new System.Drawing.Size(128, 19);
            this.cboGraphType.TabIndex = 3;
            this.cboGraphType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // lblChart
            // 
            this.lblChart.AutoSize = true;
            this.lblChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart.Location = new System.Drawing.Point(15, 19);
            this.lblChart.Name = "lblChart";
            this.lblChart.Size = new System.Drawing.Size(54, 13);
            this.lblChart.TabIndex = 0;
            this.lblChart.Text = "Chart ID";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(360, 21);
            this.txtDesc.TabIndex = 5;
            // 
            // txtChart
            // 
            this.txtChart.Location = new System.Drawing.Point(120, 16);
            this.txtChart.MaxLength = 30;
            this.txtChart.Name = "txtChart";
            this.txtChart.ReadOnly = true;
            this.txtChart.Size = new System.Drawing.Size(200, 21);
            this.txtChart.TabIndex = 1;
            // 
            // splMain
            // 
            this.splMain.Location = new System.Drawing.Point(232, 0);
            this.splMain.Name = "splMain";
            this.splMain.Size = new System.Drawing.Size(3, 506);
            this.splMain.TabIndex = 1;
            this.splMain.TabStop = false;
            // 
            // frmSPCSpecManagement
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCSpecManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Spec Management";
            this.Activated += new System.EventHandler(this.frmSPCSpecManagement_Activated);
            this.Load += new System.EventHandler(this.frmSPCSpecManagement_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFind)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeDeleteChart)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabVersion.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpDateTime.ResumeLayout(false);
            this.grpDateTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpdateUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateUser)).EndInit();
            this.pnlMidTop.ResumeLayout(false);
            this.pnlMidRight.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.grpSpec.ResumeLayout(false);
            this.grpSpec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTARGET)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLCL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLCL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUCL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUCL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUSL)).EndInit();
            this.grpVersion.ResumeLayout(false);
            this.grpVersion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoSigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkReleased)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoCalFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStart)).EndInit();
            this.pnlMidLeft.ResumeLayout(false);
            this.pnlVersion.ResumeLayout(false);
            this.pnlVersion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersion)).EndInit();
            this.tbpAutoCalculation.ResumeLayout(false);
            this.pnlSpecInfo.ResumeLayout(false);
            this.grpAutoSpec.ResumeLayout(false);
            this.grpAutoSpec.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoLCL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoCL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoLCL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoCL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoUCL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoUCL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoLSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutoUSL)).EndInit();
            this.pnlCalculation.ResumeLayout(false);
            this.grbOptions.ResumeLayout(false);
            this.grbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRelease)).EndInit();
            this.grpSelPeriod.ResumeLayout(false);
            this.grpSelPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFrom)).EndInit();
            this.grpSelChart.ResumeLayout(false);
            this.grpSelChart.PerformLayout();
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGraphType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChart)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Constants Definition"
        
        private const int COL_VERSION = 0;
        private const int COL_RELEASED = 0;
        
        #endregion
        
        #region " Variable Definition"
        
        private bool b_load_flag = false;
        private int giPrecision = 1;
        private string gsConstant1 = "";
        private string gsConstant2 = "";
        private ArrayList DisabledFormControls = new ArrayList();

        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(char FuncName)
        {
            
            try
            {
                if (txtChart.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtChart.Focus();
                    return false;
                }
                if (txtVersion.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    txtVersion.Focus();
                    return false;
                }

                switch (FuncName)
                {
                    case MPGC.MP_STEP_CREATE:
                        
                        if (txtUSL.Text != "")
                        {
                            if (MPCF.CheckNumeric(txtUSL.Text) == false)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                txtUSL.Focus();
                                return false;
                            }
                            if (MPCF.ToDbl(txtUSL.Text) < modSPCConstants.MIN_VALUE)
                            {
                                if (MPGV.gcLanguage == '2')
                                {
                                    MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(234, modSPCConstants.MIN_VALUE + " ") + MPCF.GetMessage(234));
                                }
                                else
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(234) + " " + modSPCConstants.MIN_VALUE);
                                }
                                txtUSL.Focus();
                                return false;
                            }
                            if (MPCF.ToDbl(txtUSL.Text) > modSPCConstants.MAX_VALUE)
                            {
                                if (MPGV.gcLanguage == '2')
                                {
                                    MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(235, modSPCConstants.MAX_VALUE + " ") + MPCF.GetMessage(235));
                                }
                                else
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(235) + " " + modSPCConstants.MAX_VALUE);
                                }
                                txtUSL.Focus();
                                return false;
                            }
                        }
                        if (txtTARGET.Text != "")
                        {
                            if (MPCF.CheckNumeric(txtTARGET.Text) == false)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                txtTARGET.Focus();
                                return false;
                            }
                            if (MPCF.ToDbl(txtTARGET.Text) < modSPCConstants.MIN_VALUE)
                            {
                                if (MPGV.gcLanguage == '2')
                                {
                                    MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(234, modSPCConstants.MIN_VALUE + " ") + MPCF.GetMessage(234));
                                }
                                else
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(234) + " " + modSPCConstants.MIN_VALUE);
                                }
                                txtTARGET.Focus();
                                return false;
                            }
                            if (MPCF.ToDbl(txtTARGET.Text) > modSPCConstants.MAX_VALUE)
                            {
                                if (MPGV.gcLanguage == '2')
                                {
                                    MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(235, modSPCConstants.MAX_VALUE + " ") + MPCF.GetMessage(235));
                                }
                                else
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(235) + " " + modSPCConstants.MAX_VALUE);
                                }
                                txtTARGET.Focus();
                                return false;
                            }
                        }
                        if (txtLSL.Text != "")
                        {
                            if (MPCF.CheckNumeric(txtLSL.Text) == false)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                txtLSL.Focus();
                                return false;
                            }
                            if (MPCF.ToDbl(txtLSL.Text) < modSPCConstants.MIN_VALUE)
                            {
                                if (MPGV.gcLanguage == '2')
                                {
                                    MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(234, modSPCConstants.MIN_VALUE + " ") + MPCF.GetMessage(234));
                                }
                                else
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(234) + " " + modSPCConstants.MIN_VALUE);
                                }
                                txtLSL.Focus();
                                return false;
                            }
                            if (MPCF.ToDbl(txtLSL.Text) > modSPCConstants.MAX_VALUE)
                            {
                                if (MPGV.gcLanguage == '2')
                                {
                                    MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(235, modSPCConstants.MAX_VALUE + " ") + MPCF.GetMessage(235));
                                }
                                else
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(235) + " " + modSPCConstants.MAX_VALUE);
                                }
                                txtLSL.Focus();
                                return false;
                            }
                        }
                        if (txtUCL.Visible == true)
                        {
                            if (txtUCL.Text != "")
                            {
                                if (MPCF.CheckNumeric(txtUCL.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    txtUCL.Focus();
                                    return false;
                                }
                            }
                        }
                        if (txtCL.Visible == true)
                        {
                            if (txtCL.Text != "")
                            {
                                if (MPCF.CheckNumeric(txtCL.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    txtCL.Focus();
                                    return false;
                                }
                            }
                        }
                        if (txtLCL.Visible == true)
                        {
                            if (txtLCL.Text != "")
                            {
                                if (MPCF.CheckNumeric(txtLCL.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    txtLCL.Focus();
                                    return false;
                                }
                            }
                        }
                        if (txtUCL2.Visible == true)
                        {
                            if (txtUCL2.Text != "")
                            {
                                if (MPCF.CheckNumeric(txtUCL2.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    txtUCL2.Focus();
                                    return false;
                                }
                            }
                            
                        }
                        if (txtCL2.Visible == true)
                        {
                            if (txtCL2.Text != "")
                            {
                                if (MPCF.CheckNumeric(txtCL2.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    txtCL2.Focus();
                                    return false;
                                }
                            }
                        }
                        if (txtLCL2.Visible == true)
                        {
                            if (txtLCL2.Text != "")
                            {
                                if (MPCF.CheckNumeric(txtLCL2.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    txtLCL2.Focus();
                                    return false;
                                }
                            }
                        }
                        
                        if (txtUSL.Text != "" && txtLSL.Text != "")
                        {
                            if (MPCF.ToDbl(txtUSL.Text) <= MPCF.ToDbl(txtLSL.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(145));
                                txtLSL.Focus();
                                return false;
                            }
                        }
                        if (txtUSL.Text != "" && txtTARGET.Text != "")
                        {
                            if (MPCF.ToDbl(txtUSL.Text) <= MPCF.ToDbl(txtTARGET.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(218));
                                txtTARGET.Focus();
                                return false;
                            }
                        }
                        if (txtTARGET.Text != "" && txtLSL.Text != "")
                        {
                            if (MPCF.ToDbl(txtTARGET.Text) <= MPCF.ToDbl(txtLSL.Text))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(219));
                                txtLSL.Focus();
                                return false;
                            }
                        }
                        
                        if (cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.P) || 
                            cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.PN) || 
                            cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.C) ||
                            cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.U))
                        {
                            // Control Limit 1
                            if (txtUSL.Text != "" && txtUCL.Text != "")
                            {
                                if (MPCF.ToDbl(txtUSL.Text) <= MPCF.ToDbl(txtUCL.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(143));
                                    txtUCL.Focus();
                                    return false;
                                }
                            }
                            if (txtUCL.Text != "" && txtCL.Text != "")
                            {
                                if (MPCF.ToDbl(txtUCL.Text) <= MPCF.ToDbl(txtCL.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(206));
                                    txtCL.Focus();
                                    return false;
                                }
                            }
                            if (txtCL.Text != "" && txtLCL.Text != "")
                            {
                                if (MPCF.ToDbl(txtCL.Text) <= MPCF.ToDbl(txtLCL.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(207));
                                    txtLCL.Focus();
                                    return false;
                                }
                            }
                            if (txtLSL.Text != "" && txtLCL.Text != "")
                            {
                                if (MPCF.ToDbl(txtLSL.Text) >= MPCF.ToDbl(txtLCL.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(144));
                                    txtLCL.Focus();
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            if (cboGraphType.SelectedIndex != MPCF.ToInt(eGraphType.DELTAS))
                            {
                                if (txtUSL.Text != "" && txtUCL.Text != "")
                                {
                                    if (MPCF.ToDbl(txtUSL.Text) <= MPCF.ToDbl(txtUCL.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(143));
                                        txtUCL.Focus();
                                        return false;
                                    }
                                }
                                if (txtLSL.Text != "" && txtLCL.Text != "")
                                {
                                    if (MPCF.ToDbl(txtLSL.Text) >= MPCF.ToDbl(txtLCL.Text))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(144));
                                        txtLCL.Focus();
                                        return false;
                                    }
                                }
                            }
                            // Control Limit 1
                            
                            if (txtUCL.Text != "" && txtCL.Text != "")
                            {
                                if (MPCF.ToDbl(txtUCL.Text) <= MPCF.ToDbl(txtCL.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(206));
                                    txtCL.Focus();
                                    return false;
                                }
                            }
                            if (txtCL.Text != "" && txtLCL.Text != "")
                            {
                                if (MPCF.ToDbl(txtCL.Text) <= MPCF.ToDbl(txtLCL.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(207));
                                    txtLCL.Focus();
                                    return false;
                                }
                            }
                            
                            // Control Limit 2
                            if (txtUCL2.Text != "" && txtCL2.Text != "")
                            {
                                if (MPCF.ToDbl(txtUCL2.Text) <= MPCF.ToDbl(txtCL2.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(206));
                                    txtCL2.Focus();
                                    return false;
                                }
                            }
                            if (txtCL2.Text != "" && txtLCL2.Text != "")
                            {
                                if (MPCF.ToDbl(txtCL2.Text) <= MPCF.ToDbl(txtLCL2.Text))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(207));
                                    txtLCL2.Focus();
                                    return false;
                                }
                            }
                        }
                        
                        if (chkStart.Checked == true)
                        {
                            if (this.uccStart.Value == System.DBNull.Value)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                uccStart.Focus();
                                return false;
                            }
                            if (this.udtStart.Value == System.DBNull.Value)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                udtStart.Focus();
                                return false;
                            }
                            if (((DateTime)uccStart.Value) < DateTime.Now && ((DateTime)udtStart.Value) < DateTime.Now)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(212));
                                return false;
                            }
                        }
                        if (chkStart.Checked == true && chkEnd.Checked == true)
                        {
                            if (this.uccEnd.Value == System.DBNull.Value)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                uccEnd.Focus();
                                return false;
                            }
                            if (this.udtEnd.Value == System.DBNull.Value)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                udtEnd.Focus();
                                return false;
                            }
                            if (MPCF.ToDate((((DateTime)uccStart.Value).ToString("yyyyMMdd")) + (((DateTime)udtStart.Value).ToString("HHmmss"))) >=
                                MPCF.ToDate((((DateTime)uccEnd.Value).ToString("yyyyMMdd")) + (((DateTime)udtEnd.Value).ToString("HHmmss"))))
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(213));
                                return false;
                            }
                        }
                        break;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Spec()
        //       - View Spec
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Spec()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Spec_In");
                TRSNode out_node = new TRSNode("View_Spec_Out");

                DateTime dtTranTime;
                string sTranTime;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", txtChart.Text);
                in_node.AddInt("VERSION", MPCF.ToInt(lisVersion.SelectedItems[0].Text));

                if (MPCR.CallService("SPC", "SPC_View_Spec", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtVersion.Text = out_node.GetInt("VERSION").ToString();

                if (MPCF.Trim(out_node.GetString("APPLY_START_TIME")) != "")
                {
                    chkStart.Checked = true;
                    sTranTime = "";
                    sTranTime = out_node.GetString("APPLY_START_TIME");
                    dtTranTime = new DateTime(MPCF.ToInt(MPCF.Mid(sTranTime, 0, 4)), MPCF.ToInt(MPCF.Mid(sTranTime, 4, 2)), MPCF.ToInt(MPCF.Mid(sTranTime, 6, 2))
                    , MPCF.ToInt(MPCF.Mid(sTranTime, 8, 2)), MPCF.ToInt(MPCF.Mid(sTranTime, 10, 2)), MPCF.ToInt(MPCF.Mid(sTranTime, 12, 2)));

                    uccStart.Value = dtTranTime;
                    udtStart.Value = dtTranTime;
                }
                if (MPCF.Trim(out_node.GetString("APPLY_END_TIME")) != "")
                {
                    chkEnd.Checked = true;
                    sTranTime = "";
                    sTranTime = out_node.GetString("APPLY_END_TIME");
                    dtTranTime = new DateTime(MPCF.ToInt(MPCF.Mid(sTranTime, 0, 4)), MPCF.ToInt(MPCF.Mid(sTranTime, 4, 2)), MPCF.ToInt(MPCF.Mid(sTranTime, 6, 2))
                    , MPCF.ToInt(MPCF.Mid(sTranTime, 8, 2)), MPCF.ToInt(MPCF.Mid(sTranTime, 10, 2)), MPCF.ToInt(MPCF.Mid(sTranTime, 12, 2)));

                    uccEnd.Value = dtTranTime;
                    udtEnd.Value = dtTranTime;
                }
                if (MPCF.Trim(out_node.GetChar("AUTO_MANUAL_FLAG")) == "A")
                {
                    chkAutoCalFlag.Checked = true;
                    if (MPCF.Trim(out_node.GetChar("WB_SIGMA_FLAG")) == "B")
                    {
                        txtAutoSigma.Text = "Between";
                    }
                    else
                    {
                        txtAutoSigma.Text = "Within";
                    }
                }
                else
                {
                    txtAutoSigma.Text = "Manual";
                    chkAutoCalFlag.Checked = false;
                }
                if (MPCF.Trim(out_node.GetChar("RELEASE_FLAG")) == "Y")
                {
                    chkReleased.Checked = true;
                }
                else
                {
                    chkReleased.Checked = false;
                }
               
                txtUSL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("USL")), giPrecision);
                txtTARGET.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("TARGET")), giPrecision);
                txtLSL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LSL")), giPrecision);

                txtUCL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL")), giPrecision);
                txtCL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL")), giPrecision);
                txtLCL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL")), giPrecision);
                txtUCL2.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL2")), giPrecision);
                txtCL2.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL2")), giPrecision);
                txtLCL2.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL2")), giPrecision);
                
                if (pnlSpecInfo.Visible == true)
                {
                    txtAutoUSL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("USL")), giPrecision);
                    txtAutoTarget.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("TARGET")), giPrecision);
                    txtAutoLSL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LSL")), giPrecision);

                    txtAutoUCL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL")), giPrecision);
                    txtAutoCL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL")), giPrecision);
                    txtAutoLCL.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL")), giPrecision);
                    txtAutoUCL2.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("UCL2")), giPrecision);
                    txtAutoCL2.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("CL2")), giPrecision);
                    txtAutoLCL2.Text = MPCF.SetPrecision(MPCF.Trim(out_node.GetString("LCL2")), giPrecision);
                }

                txtComment.Text = out_node.GetString("SPEC_COMMENT");

                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                txtReleaseUser.Text = out_node.GetString("RELEASE_USER_ID");
                txtReleaseTime.Text = MPCF.MakeDateFormat(out_node.GetString("RELEASE_TIME"));

                
                if (chkReleased.Checked == true)
                {
                    btnRelease.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnRelease, true);
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.View_Spec()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Update_Spec()
        //       - Create/Update/Delete Spec
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String : step
        //
        private bool Update_Spec(char c_step)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Update_Spec_In");
                TRSNode out_node = new TRSNode("Cmn_Out");
                int idx;
                ListViewItem itm;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_ID", MPCF.Trim(txtChart.Text));
                in_node.AddInt("VERSION", MPCF.ToInt(txtVersion.Text));

                if (chkStart.Checked == true)
                {
                    in_node.AddString("APPLY_START_TIME", ((DateTime)uccStart.Value).ToString("yyyyMMdd") + ((DateTime)udtStart.Value).ToString("HHmmss"));
                }
                if (chkEnd.Checked == true)
                {
                    in_node.AddString("APPLY_END_TIME", ((DateTime)uccEnd.Value).ToString("yyyyMMdd") + ((DateTime)udtEnd.Value).ToString("HHmmss"));
                }
                in_node.AddString("USL", txtUSL.Text);
                in_node.AddString("TARGET", txtTARGET.Text);
                in_node.AddString("LSL", txtLSL.Text);
                in_node.AddString("UCL", txtUCL.Text);
                in_node.AddString("CL", txtCL.Text);
                in_node.AddString("LCL", txtLCL.Text);
                in_node.AddString("UCL2", txtUCL2.Text);
                in_node.AddString("CL2", txtCL2.Text);
                in_node.AddString("LCL2", txtLCL2.Text);

                in_node.AddString("SPEC_COMMENT", txtComment.Text);


                if (MPCR.CallService("SPC", "SPC_Update_Spec", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisVersion.Items.Add(MPCF.Trim(txtVersion.Text), (int)SMALLICON_INDEX.IDX_CHART_LINE);
                        itm.Selected = true;
                        //lisVersion.Sorting = SortOrder.Descending
                        //lisVersion.Sort()
                        lisVersion.ListViewItemSorter = new ListViewItemComparer(COL_VERSION, System.Windows.Forms.SortOrder.Ascending, ListViewItemComparer.SORTING_OPTION.NUMBER_TYPE);
                        lisVersion.Sort();
                        itm.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        //Do Nothing
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisVersion, MPCF.Trim(txtVersion.Text), false);
                        if (idx != - 1)
                        {
                            lisVersion.Items[idx].Remove();
                        }
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.Update_Spec()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Chart(string sChartID)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPCF.Trim(out_node.GetString("GRAPH_TYPE")) == "")
                {
                    cboGraphType.SelectedIndex = - 1;
                }
                else
                {
                    cboGraphType.SelectedIndex = (int)Enum.Parse(typeof(eGraphType), MPCF.Trim(out_node.GetString("GRAPH_TYPE")));
                }

                txtDesc.Text = out_node.GetString("CHART_DESC");
                giPrecision = out_node.GetInt("PRECISION_LIMIT");
                gsConstant1 = out_node.GetString("CONSTANT_3");
                gsConstant2 = out_node.GetString("CONSTANT_2");
                
                if (cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.XBARR) || 
                    cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.XBARS) || 
                    cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.XRS) || 
                    cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.DELTAS) || 
                    cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.ZBARS))
                {
                    
                    lblUCL2.Visible = true;
                    lblCL2.Visible = true;
                    lblLCL2.Visible = true;
                    txtUCL2.Visible = true;
                    txtCL2.Visible = true;
                    txtLCL2.Visible = true;
                    
                    lblAutoUCL2.Visible = true;
                    lblAutoCL2.Visible = true;
                    lblAutoLCL2.Visible = true;
                    txtAutoUCL2.Visible = true;
                    txtAutoCL2.Visible = true;
                    txtAutoLCL2.Visible = true;
                    
                    if (cboGraphType.SelectedIndex == MPCF.ToInt(eGraphType.ZBARS))
                    {
                        txtUCL.Text = "3.0";
                        txtCL.Text = "0";
                        txtLCL.Text = "-3.0";
                        txtUCL2.Text = out_node.GetString("CONSTANT_3");
                        txtCL2.Text = "1";
                        txtLCL2.Text = out_node.GetString("CONSTANT_2");
                    }
                }
                else
                {
                    
                    lblUCL2.Visible = false;
                    lblCL2.Visible = false;
                    lblLCL2.Visible = false;
                    txtUCL2.Visible = false;
                    txtCL2.Visible = false;
                    txtLCL2.Visible = false;
                    
                    lblAutoUCL2.Visible = false;
                    lblAutoCL2.Visible = false;
                    lblAutoLCL2.Visible = false;
                    txtAutoUCL2.Visible = false;
                    txtAutoCL2.Visible = false;
                    txtAutoLCL2.Visible = false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.View_Chart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // AutoCalculationControlLimit()
        //       - Autometic Control Limit Calculation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool AutoCalculationControlLimit()
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Auto_Calculation_Control_Limit_In");
                TRSNode out_node = new TRSNode("Cmn_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                if (rbnCurrentChart.Checked == true)
                {
                    in_node.AddString("CHART_ID", txtChart.Text);
                }
                else
                {
                    in_node.AddChar("ALL_CHART_CALCULATION_FLAG", 'Y');
                }
                if (this.rbnUserSelectPeriod.Checked == true)
                {
                    if (this.uccFrom == null)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        uccFrom.Focus();
                        return false;
                    }
                    if (this.udtFrom == null)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        udtFrom.Focus();
                        return false;
                    }
                    if (this.uccTo == null)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        uccTo.Focus();
                        return false;
                    }
                    if (this.udtTo == null)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        udtTo.Focus();
                        return false;
                    }
                    if (MPCF.ToDate((((DateTime)uccFrom.Value).ToString("yyyyMMdd")) + (((DateTime)udtFrom.Value).ToString("HHmmss"))) >=
                        MPCF.ToDate((((DateTime)uccTo.Value).ToString("yyyyMMdd")) + (((DateTime)udtTo.Value).ToString("HHmmss"))))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(214));
                        return false;
                    }
                    in_node.AddChar("USER_SELECT_PERIOD_FLAG", 'Y');
                    in_node.AddString("FROM_TIME", ((DateTime)uccFrom.Value).ToString("yyyyMMdd") + ((DateTime)udtFrom.Value).ToString("HHmmss"));
                    in_node.AddString("TO_TIME", ((DateTime)uccTo.Value).ToString("yyyyMMdd") + ((DateTime)udtTo.Value).ToString("HHmmss"));
                }
                if (this.chkAutoRelease.Checked == true)
                {
                    in_node.AddChar("AUTO_RELEASE_FLAG", 'Y');

                }
                if (MPCR.CallService("SPC", "SPC_Auto_Calculation_Control_Limit", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
                                
                View_Chart(lisChart.SelectedItems[0].Text);
                if (SPCLIST.ViewSPCSpecList(lisVersion, '1', txtChart.Text, null, "") == false)
                {
                    return false;
                }
                if (lisVersion.Items.Count > 0)
                {
                    if (rbnCurrentChart.Checked == true)
                    {
                        pnlSpecInfo.Visible = true;
                    }
                    else
                    {
                        pnlSpecInfo.Visible = false;
                    }
                    lisVersion.Items[0].Selected = true;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.AutoCalculationControlLimit()\n" + ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisChart;
                
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
                if (lisChart.Items.Count > 0)
                {
                    if (MPCF.FindListItem(lisChart, txtChart.Text, false) == false)
                    {
                        View_Chart(txtChart.Text);
                        if (SPCLIST.ViewSPCSpecList(lisVersion, '1', txtChart.Text, null, "") == false)
                        {
                            return;
                        }
                        if (lisVersion.Items.Count > 0)
                        {
                            lisVersion.Items[0].Selected = true;
                        }
                    }
                }
                else
                {
                    View_Chart(txtChart.Text);
                    if (SPCLIST.ViewSPCSpecList(lisVersion, '1', txtChart.Text, null, "") == false)
                    {
                        return;
                    }
                    if (lisVersion.Items.Count > 0)
                    {
                        lisVersion.Items[0].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.ChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCSpecManagement_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    if (MPCF.Trim(MPGV.gsChartID) != "")
                    {
                        this.txtChart.Text = MPGV.gsChartID;
                        ChartInfo();
                    }

                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.frmSPCSpecManagement_Activated()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void lisChart_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight);

                MPCR.ChangeControlEnabled(this, btnRelease, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
                uccStart.Value = DateTime.Now;
                udtStart.Value = DateTime.Now;
                uccEnd.Value = DateTime.Now.AddMonths(1);
                udtEnd.Value = DateTime.Now;
                
                // Auto Calculation Tab
                uccFrom.Value = DateTime.Now.AddMonths(- 1);
                udtFrom.Value = DateTime.Now;
                uccTo.Value = DateTime.Now;
                udtTo.Value = DateTime.Now;
                rbnCurrentChart.Checked = true;
                rbnCurrentPeriod.Checked = true;
                chkAutoRelease.Checked = false;
                
                if (lisChart.SelectedItems.Count > 0)
                {
                    txtChart.Text = lisChart.SelectedItems[0].Text;
                    View_Chart(lisChart.SelectedItems[0].Text);
                    if (SPCLIST.ViewSPCSpecList(lisVersion, '1', txtChart.Text, null, "") == false)
                    {
                        return;
                    }
                    if (lisVersion.Items.Count > 0)
                    {
                        lisVersion.Items[0].Selected = true;
                    }
                }
                
                pnlSpecInfo.Visible = false;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.lisChart_SelectedIndexChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (rbnAll.Checked == false && rbnFilter.Checked == false)
                {
                    rbnAll.Checked = true;
                }
                if (rbnFilter.Checked == true && MPCF.Trim(txtFilter.Text) == "")
                {
                    lisChart.Items.Clear();
                    lblDataCount.Text = lisChart.Items.Count.ToString();
                    return;
                }
                if (SPCLIST.ViewChartList(lisChart, '1', "", 0,"", "", "", ' ', (chkIncludeDeleteChart.Checked ? 'Y' : ' '), (rbnAll.Checked == true ? "" : (MPCF.Trim(txtFilter.Text))), "", -1, -1, null, "") == true)
                {
                    lblDataCount.Text = lisChart.Items.Count.ToString();
                    if (lisChart.Items.Count > 0)
                    {
                        lisChart.Items[0].Selected = true;
                    }
                }
                
                if (lisChart.Items.Count > 0)
                {
                    MPCF.FindListItem(lisChart, txtChart.Text, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnRefresh_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ExportToExcel(lisVersion, this.Text, "");
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnExcel_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemNextPartial(lisChart, txtFind.Text, true, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnNext_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemPartial(lisChart, txtFind.Text, 0, true, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.txtFind_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCSpecManagement_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                MPCF.InitListView(lisChart);
                MPCF.InitListView(lisVersion);
                modSPCFunctions.SetGraphList(cboGraphType);
                uccStart.Value = DateTime.Now;
                udtStart.Value = DateTime.Now;
                uccEnd.Value = DateTime.Now.AddMonths(1);
                udtEnd.Value = DateTime.Now;
                
                rbnFilter.Checked = true;
                txtFilter.Text = modSPCFunctions.GetFilterKey();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.frmSPCSpecManagement_Load()\n" + ex.Message);
            }
            
        }
        
        private void lisVersion_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (cboGraphType.SelectedIndex != MPCF.ToInt(eGraphType.ZBARS))
                {
                    MPCF.FieldClear(this.pnlMidRight);
                }
                uccStart.Value = DateTime.Now;
                udtStart.Value = DateTime.Now;
                uccEnd.Value = DateTime.Now.AddMonths(1);
                udtEnd.Value = DateTime.Now;
                if (lisVersion.SelectedItems.Count > 0)
                {
                    txtVersion.Text = lisVersion.SelectedItems[0].Text;
                    View_Spec();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.lisVersion_SelectedIndexChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (Update_Spec(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    if (SPCLIST.ViewSPCSpecList(lisVersion, '1', txtChart.Text, null, "") == false)
                    {
                        return;
                    }
                    if (lisVersion.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisVersion, txtVersion.Text, false);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnCreate_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRelease_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition(MPGC.MP_STEP_RELEASE) == false)
                {
                    return;
                }
                if (Update_Spec(MPGC.MP_STEP_RELEASE) == false)
                {
                    return;
                }
                if (SPCLIST.ViewSPCSpecList(lisVersion, '1', txtChart.Text, null, "") == false)
                {
                    return;
                }
                if (lisVersion.Items.Count > 0)
                {
                    MPCF.FindListItem(lisVersion, txtVersion.Text, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnRelease_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (Update_Spec(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    if (SPCLIST.ViewSPCSpecList(lisVersion, '1', txtChart.Text, null, "") == false)
                    {
                        return;
                    }
                    if (lisVersion.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisVersion, txtVersion.Text, false);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnUpdate_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtNumber_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        if (e.KeyChar == (char)46)
                        {
                            if (((UltraTextEditor) sender).Text == "" || ((UltraTextEditor)sender).Text.Contains(".") == true)
                            {
                                e.Handled = true;
                            }
                        }
                        else if (e.KeyChar == (char)45)
                        {
                            if ((((UltraTextEditor)sender).SelectedText == "" && ((UltraTextEditor)sender).Text != "") || ((UltraTextEditor)sender).Text.Contains("-") == true)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.txtNumber_KeyPress()\n" + ex.Message);
            }
            
        }
        
        private void chkStart_CheckedChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                txtStartTime.Visible = ! chkStart.Checked;
                txtEndTime.Visible = ! chkEnd.Checked;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.chkStart_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnCalculation_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (AutoCalculationControlLimit() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnCalculation_Click()\n" + ex.Message);
            }
            
        }
        
        private void rbnUserSelectPeriod_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                txtFrom.Visible = ! rbnUserSelectPeriod.Checked;
                txtTo.Visible = ! rbnUserSelectPeriod.Checked;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.rbnUserSelectPeriod_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 1) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (Update_Spec(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                MPCF.FieldClear(tbpGeneral);
                if (MPGV.gbListAutoRefresh == true)
                {
                    if (SPCLIST.ViewSPCSpecList(lisVersion, '1', txtChart.Text, null, "") == false)
                    {
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnDelete_Click()\n" + ex.Message);
            }
            
        }
        
        
        private void tabVersion_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if ( tabVersion.SelectedTab != this.tbpAutoCalculation)
                {
                    pnlSpecInfo.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.tabVersion_SelectedIndexChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                
                modSPCFunctions.SaveFilterKey(MPCF.Trim(txtFilter.Text));
                
                if (rbnFilter.Checked == true && MPCF.Trim(txtFilter.Text) == "")
                {
                    lisChart.Items.Clear();
                    lblDataCount.Text = lisChart.Items.Count.ToString();
                    return;
                }
                if (SPCLIST.ViewChartList(lisChart, '1', "", 0,"", "", "", ' ', (chkIncludeDeleteChart.Checked ? 'Y' : ' '), (rbnAll.Checked == true ? "" : (MPCF.Trim(txtFilter.Text))), "", -1, -1, null, "") == true)
                {
                    lblDataCount.Text = lisChart.Items.Count.ToString();
                    if (lisChart.Items.Count > 0)
                    {
                        lisChart.Items[0].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtFilter_TextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                rbnFilter.Checked = true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.txtFilter_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.lisChart.SelectedItems.Count > 0)
                    {
                        txtChart.Text = form.lisChart.SelectedItems[0].SubItems[1].Text;
                        ChartInfo();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSpecManagement.btnFiltering_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
