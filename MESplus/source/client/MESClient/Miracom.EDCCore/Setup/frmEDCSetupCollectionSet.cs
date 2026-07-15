
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCSetupGeneralCodeTable.vb
//   Description : General Code Table Definition Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - SetGroupCmfItem : Initialize Group/CMF Item Controls according to Factory CMF Configuration
//       - View_Col_Set() : View Collection Set Definition
//       - Update_Col_Set() : Create/Update/Delete Collection Set definition
//       - View_Col_Set_Version() : View Collection Set Version
//       - Update_Col_Set_Version() : Create/Update/Delete Collection Set Version
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-15 : Created by SKJIN
//       - 2008-01-14 : Modified by LAVERWON : Default Collection Mode (e.g. Auto, Manual) Added
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.EDCCore
{
    public class frmEDCSetupCollectionSet : Miracom.MESCore.SetupForm02
    {

#if _EDC
        
#region " Windows Form auto generated code "
        
        public frmEDCSetupCollectionSet()
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
        



        private Miracom.UI.Controls.MCListView.MCListView lisColSet;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox grbColSet;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtColSet;
        private System.Windows.Forms.Label lblColSet;
        private System.Windows.Forms.Panel panRightBottom;
        private System.Windows.Forms.TabControl tabColSet;
        private System.Windows.Forms.GroupBox grpGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup1;
        private System.Windows.Forms.Label lblGroup10;
        private System.Windows.Forms.Label lblGroup9;
        private System.Windows.Forms.Label lblGroup8;
        private System.Windows.Forms.Label lblGroup7;
        private System.Windows.Forms.Label lblGroup6;
        private System.Windows.Forms.Label lblGroup5;
        private System.Windows.Forms.Label lblGroup4;
        private System.Windows.Forms.Label lblGroup3;
        private System.Windows.Forms.Label lblGroup2;
        private System.Windows.Forms.Label lblGroup1;
        private System.Windows.Forms.GroupBox grpCMF;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        private System.Windows.Forms.Label lblCMF10;
        private System.Windows.Forms.Label lblCMF9;
        private System.Windows.Forms.Label lblCMF8;
        private System.Windows.Forms.Label lblCMF7;
        private System.Windows.Forms.Label lblCMF6;
        private System.Windows.Forms.Label lblCMF5;
        private System.Windows.Forms.Label lblCMF4;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private Miracom.UI.Controls.MCListView.MCListView lisColSetVersion;
        private System.Windows.Forms.CheckBox chkDeleteFlag;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.TextBox txtDeleteTime;
        private System.Windows.Forms.TextBox txtDeleteUser;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.ComboBox cboLotRes;
        private System.Windows.Forms.Label lblLotRes;
        private System.Windows.Forms.CheckBox chkAppRequireFlag;
        private System.Windows.Forms.Label lblAppUser;
        public System.Windows.Forms.Button btnUndelete;
        private System.Windows.Forms.Panel pnlColSetVersion;
        private System.Windows.Forms.GroupBox grpCoSetVersion;
        private System.Windows.Forms.TextBox txtColSetVersion;
        private System.Windows.Forms.Label lblColSetVersion;
        private System.Windows.Forms.Panel pnlColSetVersion2;
        private System.Windows.Forms.Label lblCMF3;
        private System.Windows.Forms.Label lblCMF2;
        private System.Windows.Forms.Label lblCMF1;
        private System.Windows.Forms.GroupBox grpColSetGeneral;
        private System.Windows.Forms.Panel pnlColSetVerBtn;
        private System.Windows.Forms.GroupBox grpColSetVerBtn;
        public System.Windows.Forms.Button btnVerCreate;
        public System.Windows.Forms.Button btnVerDelete;
        public System.Windows.Forms.Button btnVerUpdate;
        private System.Windows.Forms.Panel pnlColSetVerTab;
        private System.Windows.Forms.TabControl tabVersion;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Panel pnlUpdateInfo;
        private System.Windows.Forms.GroupBox grpUpdateInfo;
        private System.Windows.Forms.TextBox txtColSetVerUpdateTime;
        private System.Windows.Forms.Label lblColSetVerUpdateTime;
        private System.Windows.Forms.TextBox txtColSetVerUpdateUser;
        private System.Windows.Forms.Label lblColSetVerUpdateUser;
        private System.Windows.Forms.TextBox txtColSetVerCreateTime;
        private System.Windows.Forms.Label lblColSetVerCreateTime;
        private System.Windows.Forms.TextBox txtColSetVerCreateUser;
        private System.Windows.Forms.Label lblColSetVerCreateUser;
        private System.Windows.Forms.GroupBox grpApplyTime;
        private System.Windows.Forms.CheckBox chkEnd;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.Label lblFromTo;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TabPage tbpAppNRel;
        private System.Windows.Forms.Panel pnlReleaseInfo;
        private System.Windows.Forms.GroupBox grpRelease;
        private System.Windows.Forms.CheckBox chkReleaseFlag;
        private System.Windows.Forms.TextBox txtReleaseTime;
        private System.Windows.Forms.Label lblReleaseTime;
        private System.Windows.Forms.TextBox txtReleaseUser;
        private System.Windows.Forms.Label lblReleaseUser;
        private System.Windows.Forms.GroupBox grpApproval;
        private System.Windows.Forms.CheckBox chkApprovalFlag;
        private System.Windows.Forms.TextBox txtApprovalTime;
        private System.Windows.Forms.Label lblApprovalTime;
        private System.Windows.Forms.TextBox txtApprovalUser;
        private System.Windows.Forms.Label lblApprovalUser;
        private System.Windows.Forms.TabPage tbpCopy;
        private System.Windows.Forms.GroupBox grpCopyTable;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblToVersion;
        private System.Windows.Forms.TextBox txtToVersion;
        private System.Windows.Forms.TabPage tbpEDCGeneral;
        private System.Windows.Forms.TabPage tbpEDCCMF;
        private System.Windows.Forms.TabPage tbpEDCGroup;
        private System.Windows.Forms.TabPage tbpEDCVersion;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAppUserID;
        private System.Windows.Forms.TabPage tbpCopyColSet;
        private System.Windows.Forms.GroupBox grpColSet;
        private System.Windows.Forms.Button btnColSetCopy;
        private System.Windows.Forms.Label lblFromVersion;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvVersion;
        private System.Windows.Forms.Label lblToColSet;
        private GroupBox grpDateTime;
        private RadioButton rbnAuto;
        private RadioButton rbnManual;
        private Label lblCollectionMode;
        internal Panel pnlLeftTop;
        private CheckBox chkIncludeDeleteColSet;
        private System.Windows.Forms.TextBox txtToColSet;
        
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisColSet = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbColSet = new System.Windows.Forms.GroupBox();
            this.chkDeleteFlag = new System.Windows.Forms.CheckBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtColSet = new System.Windows.Forms.TextBox();
            this.lblColSet = new System.Windows.Forms.Label();
            this.panRightBottom = new System.Windows.Forms.Panel();
            this.tabColSet = new System.Windows.Forms.TabControl();
            this.tbpEDCGeneral = new System.Windows.Forms.TabPage();
            this.grpColSetGeneral = new System.Windows.Forms.GroupBox();
            this.rbnAuto = new System.Windows.Forms.RadioButton();
            this.rbnManual = new System.Windows.Forms.RadioButton();
            this.lblCollectionMode = new System.Windows.Forms.Label();
            this.cdvAppUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkAppRequireFlag = new System.Windows.Forms.CheckBox();
            this.lblAppUser = new System.Windows.Forms.Label();
            this.cboLotRes = new System.Windows.Forms.ComboBox();
            this.lblLotRes = new System.Windows.Forms.Label();
            this.grpDateTime = new System.Windows.Forms.GroupBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtDeleteTime = new System.Windows.Forms.TextBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtDeleteUser = new System.Windows.Forms.TextBox();
            this.lblDelete = new System.Windows.Forms.Label();
            this.tbpEDCGroup = new System.Windows.Forms.TabPage();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup10 = new System.Windows.Forms.Label();
            this.lblGroup9 = new System.Windows.Forms.Label();
            this.lblGroup8 = new System.Windows.Forms.Label();
            this.lblGroup7 = new System.Windows.Forms.Label();
            this.lblGroup6 = new System.Windows.Forms.Label();
            this.lblGroup5 = new System.Windows.Forms.Label();
            this.lblGroup4 = new System.Windows.Forms.Label();
            this.lblGroup3 = new System.Windows.Forms.Label();
            this.lblGroup2 = new System.Windows.Forms.Label();
            this.lblGroup1 = new System.Windows.Forms.Label();
            this.tbpEDCCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.tbpEDCVersion = new System.Windows.Forms.TabPage();
            this.pnlColSetVersion2 = new System.Windows.Forms.Panel();
            this.pnlColSetVerTab = new System.Windows.Forms.Panel();
            this.tabVersion = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlUpdateInfo = new System.Windows.Forms.Panel();
            this.grpUpdateInfo = new System.Windows.Forms.GroupBox();
            this.txtColSetVerUpdateTime = new System.Windows.Forms.TextBox();
            this.lblColSetVerUpdateTime = new System.Windows.Forms.Label();
            this.txtColSetVerUpdateUser = new System.Windows.Forms.TextBox();
            this.lblColSetVerUpdateUser = new System.Windows.Forms.Label();
            this.txtColSetVerCreateTime = new System.Windows.Forms.TextBox();
            this.lblColSetVerCreateTime = new System.Windows.Forms.Label();
            this.txtColSetVerCreateUser = new System.Windows.Forms.TextBox();
            this.lblColSetVerCreateUser = new System.Windows.Forms.Label();
            this.grpApplyTime = new System.Windows.Forms.GroupBox();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.lblFromTo = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.tbpAppNRel = new System.Windows.Forms.TabPage();
            this.pnlReleaseInfo = new System.Windows.Forms.Panel();
            this.grpRelease = new System.Windows.Forms.GroupBox();
            this.chkReleaseFlag = new System.Windows.Forms.CheckBox();
            this.txtReleaseTime = new System.Windows.Forms.TextBox();
            this.lblReleaseTime = new System.Windows.Forms.Label();
            this.txtReleaseUser = new System.Windows.Forms.TextBox();
            this.lblReleaseUser = new System.Windows.Forms.Label();
            this.grpApproval = new System.Windows.Forms.GroupBox();
            this.chkApprovalFlag = new System.Windows.Forms.CheckBox();
            this.txtApprovalTime = new System.Windows.Forms.TextBox();
            this.lblApprovalTime = new System.Windows.Forms.Label();
            this.txtApprovalUser = new System.Windows.Forms.TextBox();
            this.lblApprovalUser = new System.Windows.Forms.Label();
            this.tbpCopy = new System.Windows.Forms.TabPage();
            this.grpCopyTable = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblToVersion = new System.Windows.Forms.Label();
            this.txtToVersion = new System.Windows.Forms.TextBox();
            this.pnlColSetVerBtn = new System.Windows.Forms.Panel();
            this.grpColSetVerBtn = new System.Windows.Forms.GroupBox();
            this.btnVerCreate = new System.Windows.Forms.Button();
            this.btnVerDelete = new System.Windows.Forms.Button();
            this.btnVerUpdate = new System.Windows.Forms.Button();
            this.pnlColSetVersion = new System.Windows.Forms.Panel();
            this.grpCoSetVersion = new System.Windows.Forms.GroupBox();
            this.txtColSetVersion = new System.Windows.Forms.TextBox();
            this.lblColSetVersion = new System.Windows.Forms.Label();
            this.lisColSetVersion = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpCopyColSet = new System.Windows.Forms.TabPage();
            this.grpColSet = new System.Windows.Forms.GroupBox();
            this.lblToColSet = new System.Windows.Forms.Label();
            this.cdvVersion = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtToColSet = new System.Windows.Forms.TextBox();
            this.lblFromVersion = new System.Windows.Forms.Label();
            this.btnColSetCopy = new System.Windows.Forms.Button();
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUndelete = new System.Windows.Forms.Button();
            this.pnlLeftTop = new System.Windows.Forms.Panel();
            this.chkIncludeDeleteColSet = new System.Windows.Forms.CheckBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grbColSet.SuspendLayout();
            this.panRightBottom.SuspendLayout();
            this.tabColSet.SuspendLayout();
            this.tbpEDCGeneral.SuspendLayout();
            this.grpColSetGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAppUserID)).BeginInit();
            this.grpDateTime.SuspendLayout();
            this.tbpEDCGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            this.tbpEDCCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.tbpEDCVersion.SuspendLayout();
            this.pnlColSetVersion2.SuspendLayout();
            this.pnlColSetVerTab.SuspendLayout();
            this.tabVersion.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlUpdateInfo.SuspendLayout();
            this.grpUpdateInfo.SuspendLayout();
            this.grpApplyTime.SuspendLayout();
            this.tbpAppNRel.SuspendLayout();
            this.pnlReleaseInfo.SuspendLayout();
            this.grpRelease.SuspendLayout();
            this.grpApproval.SuspendLayout();
            this.tbpCopy.SuspendLayout();
            this.grpCopyTable.SuspendLayout();
            this.pnlColSetVerBtn.SuspendLayout();
            this.grpColSetVerBtn.SuspendLayout();
            this.pnlColSetVersion.SuspendLayout();
            this.grpCoSetVersion.SuspendLayout();
            this.tbpCopyColSet.SuspendLayout();
            this.grpColSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvVersion)).BeginInit();
            this.pnlLeftTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 5;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 1;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 502);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.panRightBottom);
            this.pnlRight.Controls.Add(this.grbColSet);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(498, 502);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisColSet);
            this.pnlLeft.Controls.Add(this.pnlLeftTop);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 502);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(276, 8);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(458, 8);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(367, 8);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(640, 8);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnUndelete);
            this.pnlBottom.Location = new System.Drawing.Point(0, 502);
            this.pnlBottom.Size = new System.Drawing.Size(734, 40);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUndelete, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(734, 502);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Collection Set Setup";
            // 
            // lisColSet
            // 
            this.lisColSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisColSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisColSet.EnableSort = true;
            this.lisColSet.EnableSortIcon = true;
            this.lisColSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisColSet.FullRowSelect = true;
            this.lisColSet.HideSelection = false;
            this.lisColSet.Location = new System.Drawing.Point(3, 28);
            this.lisColSet.MultiSelect = false;
            this.lisColSet.Name = "lisColSet";
            this.lisColSet.Size = new System.Drawing.Size(229, 471);
            this.lisColSet.TabIndex = 0;
            this.lisColSet.UseCompatibleStateImageBehavior = false;
            this.lisColSet.View = System.Windows.Forms.View.Details;
            this.lisColSet.SelectedIndexChanged += new System.EventHandler(this.lisColSet_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Collection Set";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // grbColSet
            // 
            this.grbColSet.Controls.Add(this.chkDeleteFlag);
            this.grbColSet.Controls.Add(this.txtDesc);
            this.grbColSet.Controls.Add(this.lblDesc);
            this.grbColSet.Controls.Add(this.txtColSet);
            this.grbColSet.Controls.Add(this.lblColSet);
            this.grbColSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbColSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbColSet.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbColSet.Location = new System.Drawing.Point(3, 0);
            this.grbColSet.Name = "grbColSet";
            this.grbColSet.Size = new System.Drawing.Size(492, 71);
            this.grbColSet.TabIndex = 0;
            this.grbColSet.TabStop = false;
            // 
            // chkDeleteFlag
            // 
            this.chkDeleteFlag.AutoSize = true;
            this.chkDeleteFlag.Enabled = false;
            this.chkDeleteFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDeleteFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleteFlag.Location = new System.Drawing.Point(400, 19);
            this.chkDeleteFlag.Name = "chkDeleteFlag";
            this.chkDeleteFlag.Size = new System.Drawing.Size(86, 18);
            this.chkDeleteFlag.TabIndex = 2;
            this.chkDeleteFlag.Text = "Delete Flag";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(127, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(349, 20);
            this.txtDesc.TabIndex = 4;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtColSet
            // 
            this.txtColSet.Location = new System.Drawing.Point(127, 16);
            this.txtColSet.MaxLength = 25;
            this.txtColSet.Name = "txtColSet";
            this.txtColSet.Size = new System.Drawing.Size(177, 20);
            this.txtColSet.TabIndex = 1;
            this.txtColSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColSet_KeyPress);
            // 
            // lblColSet
            // 
            this.lblColSet.AutoSize = true;
            this.lblColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColSet.Location = new System.Drawing.Point(15, 19);
            this.lblColSet.Name = "lblColSet";
            this.lblColSet.Size = new System.Drawing.Size(86, 13);
            this.lblColSet.TabIndex = 0;
            this.lblColSet.Text = "Collection Set";
            this.lblColSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panRightBottom
            // 
            this.panRightBottom.Controls.Add(this.tabColSet);
            this.panRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRightBottom.Location = new System.Drawing.Point(3, 71);
            this.panRightBottom.Name = "panRightBottom";
            this.panRightBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panRightBottom.Size = new System.Drawing.Size(492, 428);
            this.panRightBottom.TabIndex = 1;
            // 
            // tabColSet
            // 
            this.tabColSet.Controls.Add(this.tbpEDCGeneral);
            this.tabColSet.Controls.Add(this.tbpEDCGroup);
            this.tabColSet.Controls.Add(this.tbpEDCCMF);
            this.tabColSet.Controls.Add(this.tbpEDCVersion);
            this.tabColSet.Controls.Add(this.tbpCopyColSet);
            this.tabColSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabColSet.ItemSize = new System.Drawing.Size(60, 18);
            this.tabColSet.Location = new System.Drawing.Point(0, 5);
            this.tabColSet.Name = "tabColSet";
            this.tabColSet.SelectedIndex = 0;
            this.tabColSet.Size = new System.Drawing.Size(492, 423);
            this.tabColSet.TabIndex = 0;
            this.tabColSet.SelectedIndexChanged += new System.EventHandler(this.tabColSet_SelectedIndexChanged);
            // 
            // tbpEDCGeneral
            // 
            this.tbpEDCGeneral.Controls.Add(this.grpColSetGeneral);
            this.tbpEDCGeneral.Controls.Add(this.grpDateTime);
            this.tbpEDCGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpEDCGeneral.Name = "tbpEDCGeneral";
            this.tbpEDCGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpEDCGeneral.Size = new System.Drawing.Size(484, 397);
            this.tbpEDCGeneral.TabIndex = 0;
            this.tbpEDCGeneral.Text = "General";
            // 
            // grpColSetGeneral
            // 
            this.grpColSetGeneral.Controls.Add(this.rbnAuto);
            this.grpColSetGeneral.Controls.Add(this.rbnManual);
            this.grpColSetGeneral.Controls.Add(this.lblCollectionMode);
            this.grpColSetGeneral.Controls.Add(this.cdvAppUserID);
            this.grpColSetGeneral.Controls.Add(this.chkAppRequireFlag);
            this.grpColSetGeneral.Controls.Add(this.lblAppUser);
            this.grpColSetGeneral.Controls.Add(this.cboLotRes);
            this.grpColSetGeneral.Controls.Add(this.lblLotRes);
            this.grpColSetGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpColSetGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpColSetGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpColSetGeneral.Name = "grpColSetGeneral";
            this.grpColSetGeneral.Size = new System.Drawing.Size(478, 300);
            this.grpColSetGeneral.TabIndex = 0;
            this.grpColSetGeneral.TabStop = false;
            // 
            // rbnAuto
            // 
            this.rbnAuto.AutoSize = true;
            this.rbnAuto.Checked = true;
            this.rbnAuto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnAuto.Location = new System.Drawing.Point(14, 37);
            this.rbnAuto.Name = "rbnAuto";
            this.rbnAuto.Size = new System.Drawing.Size(83, 18);
            this.rbnAuto.TabIndex = 1;
            this.rbnAuto.TabStop = true;
            this.rbnAuto.Text = "Auto Mode";
            // 
            // rbnManual
            // 
            this.rbnManual.AutoSize = true;
            this.rbnManual.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnManual.Location = new System.Drawing.Point(112, 37);
            this.rbnManual.Name = "rbnManual";
            this.rbnManual.Size = new System.Drawing.Size(96, 18);
            this.rbnManual.TabIndex = 2;
            this.rbnManual.Text = "Manual Mode";
            // 
            // lblCollectionMode
            // 
            this.lblCollectionMode.AutoSize = true;
            this.lblCollectionMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCollectionMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectionMode.Location = new System.Drawing.Point(14, 17);
            this.lblCollectionMode.Name = "lblCollectionMode";
            this.lblCollectionMode.Size = new System.Drawing.Size(143, 13);
            this.lblCollectionMode.TabIndex = 0;
            this.lblCollectionMode.Text = "Default Collection Mode";
            // 
            // cdvAppUserID
            // 
            this.cdvAppUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAppUserID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAppUserID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAppUserID.BtnToolTipText = "";
            this.cdvAppUserID.DescText = "";
            this.cdvAppUserID.DisplaySubItemIndex = -1;
            this.cdvAppUserID.DisplayText = "";
            this.cdvAppUserID.Focusing = null;
            this.cdvAppUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAppUserID.Index = 0;
            this.cdvAppUserID.IsViewBtnImage = false;
            this.cdvAppUserID.Location = new System.Drawing.Point(120, 117);
            this.cdvAppUserID.MaxLength = 20;
            this.cdvAppUserID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAppUserID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAppUserID.Name = "cdvAppUserID";
            this.cdvAppUserID.ReadOnly = false;
            this.cdvAppUserID.SearchSubItemIndex = 0;
            this.cdvAppUserID.SelectedDescIndex = -1;
            this.cdvAppUserID.SelectedSubItemIndex = -1;
            this.cdvAppUserID.SelectionStart = 0;
            this.cdvAppUserID.Size = new System.Drawing.Size(177, 20);
            this.cdvAppUserID.SmallImageList = null;
            this.cdvAppUserID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAppUserID.TabIndex = 7;
            this.cdvAppUserID.TextBoxToolTipText = "";
            this.cdvAppUserID.TextBoxWidth = 177;
            this.cdvAppUserID.VisibleButton = true;
            this.cdvAppUserID.VisibleColumnHeader = false;
            this.cdvAppUserID.VisibleDescription = false;
            this.cdvAppUserID.ButtonPress += new System.EventHandler(this.cdvAppUserID_ButtonPress);
            // 
            // chkAppRequireFlag
            // 
            this.chkAppRequireFlag.AutoSize = true;
            this.chkAppRequireFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAppRequireFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAppRequireFlag.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkAppRequireFlag.Location = new System.Drawing.Point(15, 96);
            this.chkAppRequireFlag.Name = "chkAppRequireFlag";
            this.chkAppRequireFlag.Size = new System.Drawing.Size(137, 18);
            this.chkAppRequireFlag.TabIndex = 5;
            this.chkAppRequireFlag.Text = "Approval Require Flag";
            this.chkAppRequireFlag.CheckedChanged += new System.EventHandler(this.chkAppRequireFlag_CheckedChanged);
            // 
            // lblAppUser
            // 
            this.lblAppUser.AutoSize = true;
            this.lblAppUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAppUser.Location = new System.Drawing.Point(15, 120);
            this.lblAppUser.Name = "lblAppUser";
            this.lblAppUser.Size = new System.Drawing.Size(74, 13);
            this.lblAppUser.TabIndex = 6;
            this.lblAppUser.Text = "Approval User";
            this.lblAppUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLotRes
            // 
            this.cboLotRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLotRes.Items.AddRange(new object[] {
            "Lot",
            "Resource",
            "Both"});
            this.cboLotRes.Location = new System.Drawing.Point(120, 61);
            this.cboLotRes.Name = "cboLotRes";
            this.cboLotRes.Size = new System.Drawing.Size(176, 21);
            this.cboLotRes.TabIndex = 4;
            // 
            // lblLotRes
            // 
            this.lblLotRes.AutoSize = true;
            this.lblLotRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotRes.Location = new System.Drawing.Point(15, 64);
            this.lblLotRes.Name = "lblLotRes";
            this.lblLotRes.Size = new System.Drawing.Size(83, 13);
            this.lblLotRes.TabIndex = 3;
            this.lblLotRes.Text = "Lot or Resource";
            this.lblLotRes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpDateTime
            // 
            this.grpDateTime.Controls.Add(this.txtUpdateUser);
            this.grpDateTime.Controls.Add(this.lblCreate);
            this.grpDateTime.Controls.Add(this.txtCreateUser);
            this.grpDateTime.Controls.Add(this.lblUpdate);
            this.grpDateTime.Controls.Add(this.txtCreateTime);
            this.grpDateTime.Controls.Add(this.txtDeleteTime);
            this.grpDateTime.Controls.Add(this.txtUpdateTime);
            this.grpDateTime.Controls.Add(this.txtDeleteUser);
            this.grpDateTime.Controls.Add(this.lblDelete);
            this.grpDateTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDateTime.Location = new System.Drawing.Point(3, 300);
            this.grpDateTime.Name = "grpDateTime";
            this.grpDateTime.Size = new System.Drawing.Size(478, 94);
            this.grpDateTime.TabIndex = 1;
            this.grpDateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(15, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(15, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(303, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtDeleteTime
            // 
            this.txtDeleteTime.Location = new System.Drawing.Point(303, 64);
            this.txtDeleteTime.MaxLength = 30;
            this.txtDeleteTime.Name = "txtDeleteTime";
            this.txtDeleteTime.ReadOnly = true;
            this.txtDeleteTime.Size = new System.Drawing.Size(174, 20);
            this.txtDeleteTime.TabIndex = 8;
            this.txtDeleteTime.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(303, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtDeleteUser
            // 
            this.txtDeleteUser.Location = new System.Drawing.Point(120, 64);
            this.txtDeleteUser.MaxLength = 20;
            this.txtDeleteUser.Name = "txtDeleteUser";
            this.txtDeleteUser.ReadOnly = true;
            this.txtDeleteUser.Size = new System.Drawing.Size(177, 20);
            this.txtDeleteUser.TabIndex = 7;
            this.txtDeleteUser.TabStop = false;
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDelete.Location = new System.Drawing.Point(15, 67);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(91, 13);
            this.lblDelete.TabIndex = 6;
            this.lblDelete.Text = "Delete User/Time";
            this.lblDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpEDCGroup
            // 
            this.tbpEDCGroup.Controls.Add(this.grpGroup);
            this.tbpEDCGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpEDCGroup.Name = "tbpEDCGroup";
            this.tbpEDCGroup.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpEDCGroup.Size = new System.Drawing.Size(484, 397);
            this.tbpEDCGroup.TabIndex = 1;
            this.tbpEDCGroup.Text = "Group Setup";
            this.tbpEDCGroup.Visible = false;
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.cdvGroup10);
            this.grpGroup.Controls.Add(this.cdvGroup9);
            this.grpGroup.Controls.Add(this.cdvGroup8);
            this.grpGroup.Controls.Add(this.cdvGroup7);
            this.grpGroup.Controls.Add(this.cdvGroup6);
            this.grpGroup.Controls.Add(this.cdvGroup5);
            this.grpGroup.Controls.Add(this.cdvGroup4);
            this.grpGroup.Controls.Add(this.cdvGroup3);
            this.grpGroup.Controls.Add(this.cdvGroup2);
            this.grpGroup.Controls.Add(this.cdvGroup1);
            this.grpGroup.Controls.Add(this.lblGroup10);
            this.grpGroup.Controls.Add(this.lblGroup9);
            this.grpGroup.Controls.Add(this.lblGroup8);
            this.grpGroup.Controls.Add(this.lblGroup7);
            this.grpGroup.Controls.Add(this.lblGroup6);
            this.grpGroup.Controls.Add(this.lblGroup5);
            this.grpGroup.Controls.Add(this.lblGroup4);
            this.grpGroup.Controls.Add(this.lblGroup3);
            this.grpGroup.Controls.Add(this.lblGroup2);
            this.grpGroup.Controls.Add(this.lblGroup1);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpGroup.Location = new System.Drawing.Point(3, 0);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(478, 394);
            this.grpGroup.TabIndex = 0;
            this.grpGroup.TabStop = false;
            // 
            // cdvGroup10
            // 
            this.cdvGroup10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup10.BtnToolTipText = "";
            this.cdvGroup10.DescText = "";
            this.cdvGroup10.DisplaySubItemIndex = -1;
            this.cdvGroup10.DisplayText = "";
            this.cdvGroup10.Focusing = null;
            this.cdvGroup10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup10.Index = 9;
            this.cdvGroup10.IsViewBtnImage = false;
            this.cdvGroup10.Location = new System.Drawing.Point(172, 232);
            this.cdvGroup10.MaxLength = 30;
            this.cdvGroup10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.Name = "cdvGroup10";
            this.cdvGroup10.ReadOnly = false;
            this.cdvGroup10.SearchSubItemIndex = 0;
            this.cdvGroup10.SelectedDescIndex = -1;
            this.cdvGroup10.SelectedSubItemIndex = -1;
            this.cdvGroup10.SelectionStart = 0;
            this.cdvGroup10.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup10.SmallImageList = null;
            this.cdvGroup10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup10.TabIndex = 9;
            this.cdvGroup10.TextBoxToolTipText = "";
            this.cdvGroup10.TextBoxWidth = 200;
            this.cdvGroup10.VisibleButton = true;
            this.cdvGroup10.VisibleColumnHeader = false;
            this.cdvGroup10.VisibleDescription = false;
            this.cdvGroup10.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // cdvGroup9
            // 
            this.cdvGroup9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup9.BtnToolTipText = "";
            this.cdvGroup9.DescText = "";
            this.cdvGroup9.DisplaySubItemIndex = -1;
            this.cdvGroup9.DisplayText = "";
            this.cdvGroup9.Focusing = null;
            this.cdvGroup9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup9.Index = 8;
            this.cdvGroup9.IsViewBtnImage = false;
            this.cdvGroup9.Location = new System.Drawing.Point(172, 208);
            this.cdvGroup9.MaxLength = 30;
            this.cdvGroup9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.Name = "cdvGroup9";
            this.cdvGroup9.ReadOnly = false;
            this.cdvGroup9.SearchSubItemIndex = 0;
            this.cdvGroup9.SelectedDescIndex = -1;
            this.cdvGroup9.SelectedSubItemIndex = -1;
            this.cdvGroup9.SelectionStart = 0;
            this.cdvGroup9.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup9.SmallImageList = null;
            this.cdvGroup9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup9.TabIndex = 8;
            this.cdvGroup9.TextBoxToolTipText = "";
            this.cdvGroup9.TextBoxWidth = 200;
            this.cdvGroup9.VisibleButton = true;
            this.cdvGroup9.VisibleColumnHeader = false;
            this.cdvGroup9.VisibleDescription = false;
            this.cdvGroup9.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // cdvGroup8
            // 
            this.cdvGroup8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup8.BtnToolTipText = "";
            this.cdvGroup8.DescText = "";
            this.cdvGroup8.DisplaySubItemIndex = -1;
            this.cdvGroup8.DisplayText = "";
            this.cdvGroup8.Focusing = null;
            this.cdvGroup8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup8.Index = 7;
            this.cdvGroup8.IsViewBtnImage = false;
            this.cdvGroup8.Location = new System.Drawing.Point(172, 184);
            this.cdvGroup8.MaxLength = 30;
            this.cdvGroup8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.Name = "cdvGroup8";
            this.cdvGroup8.ReadOnly = false;
            this.cdvGroup8.SearchSubItemIndex = 0;
            this.cdvGroup8.SelectedDescIndex = -1;
            this.cdvGroup8.SelectedSubItemIndex = -1;
            this.cdvGroup8.SelectionStart = 0;
            this.cdvGroup8.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup8.SmallImageList = null;
            this.cdvGroup8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup8.TabIndex = 7;
            this.cdvGroup8.TextBoxToolTipText = "";
            this.cdvGroup8.TextBoxWidth = 200;
            this.cdvGroup8.VisibleButton = true;
            this.cdvGroup8.VisibleColumnHeader = false;
            this.cdvGroup8.VisibleDescription = false;
            this.cdvGroup8.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // cdvGroup7
            // 
            this.cdvGroup7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup7.BtnToolTipText = "";
            this.cdvGroup7.DescText = "";
            this.cdvGroup7.DisplaySubItemIndex = -1;
            this.cdvGroup7.DisplayText = "";
            this.cdvGroup7.Focusing = null;
            this.cdvGroup7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup7.Index = 6;
            this.cdvGroup7.IsViewBtnImage = false;
            this.cdvGroup7.Location = new System.Drawing.Point(172, 160);
            this.cdvGroup7.MaxLength = 30;
            this.cdvGroup7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.Name = "cdvGroup7";
            this.cdvGroup7.ReadOnly = false;
            this.cdvGroup7.SearchSubItemIndex = 0;
            this.cdvGroup7.SelectedDescIndex = -1;
            this.cdvGroup7.SelectedSubItemIndex = -1;
            this.cdvGroup7.SelectionStart = 0;
            this.cdvGroup7.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup7.SmallImageList = null;
            this.cdvGroup7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup7.TabIndex = 6;
            this.cdvGroup7.TextBoxToolTipText = "";
            this.cdvGroup7.TextBoxWidth = 200;
            this.cdvGroup7.VisibleButton = true;
            this.cdvGroup7.VisibleColumnHeader = false;
            this.cdvGroup7.VisibleDescription = false;
            this.cdvGroup7.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // cdvGroup6
            // 
            this.cdvGroup6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup6.BtnToolTipText = "";
            this.cdvGroup6.DescText = "";
            this.cdvGroup6.DisplaySubItemIndex = -1;
            this.cdvGroup6.DisplayText = "";
            this.cdvGroup6.Focusing = null;
            this.cdvGroup6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup6.Index = 5;
            this.cdvGroup6.IsViewBtnImage = false;
            this.cdvGroup6.Location = new System.Drawing.Point(172, 136);
            this.cdvGroup6.MaxLength = 30;
            this.cdvGroup6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.Name = "cdvGroup6";
            this.cdvGroup6.ReadOnly = false;
            this.cdvGroup6.SearchSubItemIndex = 0;
            this.cdvGroup6.SelectedDescIndex = -1;
            this.cdvGroup6.SelectedSubItemIndex = -1;
            this.cdvGroup6.SelectionStart = 0;
            this.cdvGroup6.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup6.SmallImageList = null;
            this.cdvGroup6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup6.TabIndex = 5;
            this.cdvGroup6.TextBoxToolTipText = "";
            this.cdvGroup6.TextBoxWidth = 200;
            this.cdvGroup6.VisibleButton = true;
            this.cdvGroup6.VisibleColumnHeader = false;
            this.cdvGroup6.VisibleDescription = false;
            this.cdvGroup6.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // cdvGroup5
            // 
            this.cdvGroup5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup5.BtnToolTipText = "";
            this.cdvGroup5.DescText = "";
            this.cdvGroup5.DisplaySubItemIndex = -1;
            this.cdvGroup5.DisplayText = "";
            this.cdvGroup5.Focusing = null;
            this.cdvGroup5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup5.Index = 4;
            this.cdvGroup5.IsViewBtnImage = false;
            this.cdvGroup5.Location = new System.Drawing.Point(172, 112);
            this.cdvGroup5.MaxLength = 30;
            this.cdvGroup5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.Name = "cdvGroup5";
            this.cdvGroup5.ReadOnly = false;
            this.cdvGroup5.SearchSubItemIndex = 0;
            this.cdvGroup5.SelectedDescIndex = -1;
            this.cdvGroup5.SelectedSubItemIndex = -1;
            this.cdvGroup5.SelectionStart = 0;
            this.cdvGroup5.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup5.SmallImageList = null;
            this.cdvGroup5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup5.TabIndex = 4;
            this.cdvGroup5.TextBoxToolTipText = "";
            this.cdvGroup5.TextBoxWidth = 200;
            this.cdvGroup5.VisibleButton = true;
            this.cdvGroup5.VisibleColumnHeader = false;
            this.cdvGroup5.VisibleDescription = false;
            this.cdvGroup5.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // cdvGroup4
            // 
            this.cdvGroup4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup4.BtnToolTipText = "";
            this.cdvGroup4.DescText = "";
            this.cdvGroup4.DisplaySubItemIndex = -1;
            this.cdvGroup4.DisplayText = "";
            this.cdvGroup4.Focusing = null;
            this.cdvGroup4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup4.Index = 3;
            this.cdvGroup4.IsViewBtnImage = false;
            this.cdvGroup4.Location = new System.Drawing.Point(172, 88);
            this.cdvGroup4.MaxLength = 30;
            this.cdvGroup4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.Name = "cdvGroup4";
            this.cdvGroup4.ReadOnly = false;
            this.cdvGroup4.SearchSubItemIndex = 0;
            this.cdvGroup4.SelectedDescIndex = -1;
            this.cdvGroup4.SelectedSubItemIndex = -1;
            this.cdvGroup4.SelectionStart = 0;
            this.cdvGroup4.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup4.SmallImageList = null;
            this.cdvGroup4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup4.TabIndex = 3;
            this.cdvGroup4.TextBoxToolTipText = "";
            this.cdvGroup4.TextBoxWidth = 200;
            this.cdvGroup4.VisibleButton = true;
            this.cdvGroup4.VisibleColumnHeader = false;
            this.cdvGroup4.VisibleDescription = false;
            this.cdvGroup4.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // cdvGroup3
            // 
            this.cdvGroup3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup3.BtnToolTipText = "";
            this.cdvGroup3.DescText = "";
            this.cdvGroup3.DisplaySubItemIndex = -1;
            this.cdvGroup3.DisplayText = "";
            this.cdvGroup3.Focusing = null;
            this.cdvGroup3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup3.Index = 2;
            this.cdvGroup3.IsViewBtnImage = false;
            this.cdvGroup3.Location = new System.Drawing.Point(172, 64);
            this.cdvGroup3.MaxLength = 30;
            this.cdvGroup3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.Name = "cdvGroup3";
            this.cdvGroup3.ReadOnly = false;
            this.cdvGroup3.SearchSubItemIndex = 0;
            this.cdvGroup3.SelectedDescIndex = -1;
            this.cdvGroup3.SelectedSubItemIndex = -1;
            this.cdvGroup3.SelectionStart = 0;
            this.cdvGroup3.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup3.SmallImageList = null;
            this.cdvGroup3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup3.TabIndex = 2;
            this.cdvGroup3.TextBoxToolTipText = "";
            this.cdvGroup3.TextBoxWidth = 200;
            this.cdvGroup3.VisibleButton = true;
            this.cdvGroup3.VisibleColumnHeader = false;
            this.cdvGroup3.VisibleDescription = false;
            this.cdvGroup3.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // cdvGroup2
            // 
            this.cdvGroup2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup2.BtnToolTipText = "";
            this.cdvGroup2.DescText = "";
            this.cdvGroup2.DisplaySubItemIndex = -1;
            this.cdvGroup2.DisplayText = "";
            this.cdvGroup2.Focusing = null;
            this.cdvGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup2.Index = 1;
            this.cdvGroup2.IsViewBtnImage = false;
            this.cdvGroup2.Location = new System.Drawing.Point(172, 40);
            this.cdvGroup2.MaxLength = 30;
            this.cdvGroup2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.Name = "cdvGroup2";
            this.cdvGroup2.ReadOnly = false;
            this.cdvGroup2.SearchSubItemIndex = 0;
            this.cdvGroup2.SelectedDescIndex = -1;
            this.cdvGroup2.SelectedSubItemIndex = -1;
            this.cdvGroup2.SelectionStart = 0;
            this.cdvGroup2.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup2.SmallImageList = null;
            this.cdvGroup2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup2.TabIndex = 1;
            this.cdvGroup2.TextBoxToolTipText = "";
            this.cdvGroup2.TextBoxWidth = 200;
            this.cdvGroup2.VisibleButton = true;
            this.cdvGroup2.VisibleColumnHeader = false;
            this.cdvGroup2.VisibleDescription = false;
            this.cdvGroup2.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // cdvGroup1
            // 
            this.cdvGroup1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup1.BtnToolTipText = "";
            this.cdvGroup1.DescText = "";
            this.cdvGroup1.DisplaySubItemIndex = -1;
            this.cdvGroup1.DisplayText = "";
            this.cdvGroup1.Focusing = null;
            this.cdvGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup1.Index = 0;
            this.cdvGroup1.IsViewBtnImage = false;
            this.cdvGroup1.Location = new System.Drawing.Point(172, 16);
            this.cdvGroup1.MaxLength = 30;
            this.cdvGroup1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = false;
            this.cdvGroup1.SearchSubItemIndex = 0;
            this.cdvGroup1.SelectedDescIndex = -1;
            this.cdvGroup1.SelectedSubItemIndex = -1;
            this.cdvGroup1.SelectionStart = 0;
            this.cdvGroup1.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup1.SmallImageList = null;
            this.cdvGroup1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup1.TabIndex = 0;
            this.cdvGroup1.TextBoxToolTipText = "";
            this.cdvGroup1.TextBoxWidth = 200;
            this.cdvGroup1.VisibleButton = true;
            this.cdvGroup1.VisibleColumnHeader = false;
            this.cdvGroup1.VisibleDescription = false;
            this.cdvGroup1.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            // 
            // lblGroup10
            // 
            this.lblGroup10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup10.Location = new System.Drawing.Point(15, 235);
            this.lblGroup10.Name = "lblGroup10";
            this.lblGroup10.Size = new System.Drawing.Size(150, 14);
            this.lblGroup10.TabIndex = 18;
            // 
            // lblGroup9
            // 
            this.lblGroup9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup9.Location = new System.Drawing.Point(15, 211);
            this.lblGroup9.Name = "lblGroup9";
            this.lblGroup9.Size = new System.Drawing.Size(150, 14);
            this.lblGroup9.TabIndex = 16;
            // 
            // lblGroup8
            // 
            this.lblGroup8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup8.Location = new System.Drawing.Point(15, 187);
            this.lblGroup8.Name = "lblGroup8";
            this.lblGroup8.Size = new System.Drawing.Size(150, 14);
            this.lblGroup8.TabIndex = 14;
            // 
            // lblGroup7
            // 
            this.lblGroup7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup7.Location = new System.Drawing.Point(15, 163);
            this.lblGroup7.Name = "lblGroup7";
            this.lblGroup7.Size = new System.Drawing.Size(150, 14);
            this.lblGroup7.TabIndex = 12;
            // 
            // lblGroup6
            // 
            this.lblGroup6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup6.Location = new System.Drawing.Point(15, 139);
            this.lblGroup6.Name = "lblGroup6";
            this.lblGroup6.Size = new System.Drawing.Size(150, 14);
            this.lblGroup6.TabIndex = 10;
            // 
            // lblGroup5
            // 
            this.lblGroup5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup5.Location = new System.Drawing.Point(15, 115);
            this.lblGroup5.Name = "lblGroup5";
            this.lblGroup5.Size = new System.Drawing.Size(150, 14);
            this.lblGroup5.TabIndex = 8;
            // 
            // lblGroup4
            // 
            this.lblGroup4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup4.Location = new System.Drawing.Point(15, 91);
            this.lblGroup4.Name = "lblGroup4";
            this.lblGroup4.Size = new System.Drawing.Size(150, 14);
            this.lblGroup4.TabIndex = 6;
            // 
            // lblGroup3
            // 
            this.lblGroup3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup3.Location = new System.Drawing.Point(15, 67);
            this.lblGroup3.Name = "lblGroup3";
            this.lblGroup3.Size = new System.Drawing.Size(150, 14);
            this.lblGroup3.TabIndex = 4;
            // 
            // lblGroup2
            // 
            this.lblGroup2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup2.Location = new System.Drawing.Point(15, 43);
            this.lblGroup2.Name = "lblGroup2";
            this.lblGroup2.Size = new System.Drawing.Size(150, 14);
            this.lblGroup2.TabIndex = 2;
            // 
            // lblGroup1
            // 
            this.lblGroup1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup1.Location = new System.Drawing.Point(15, 19);
            this.lblGroup1.Name = "lblGroup1";
            this.lblGroup1.Size = new System.Drawing.Size(150, 14);
            this.lblGroup1.TabIndex = 0;
            // 
            // tbpEDCCMF
            // 
            this.tbpEDCCMF.Controls.Add(this.grpCMF);
            this.tbpEDCCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpEDCCMF.Name = "tbpEDCCMF";
            this.tbpEDCCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpEDCCMF.Size = new System.Drawing.Size(484, 397);
            this.tbpEDCCMF.TabIndex = 2;
            this.tbpEDCCMF.Text = "Customized Field";
            this.tbpEDCCMF.Visible = false;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpCMF.Location = new System.Drawing.Point(3, 0);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(478, 394);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF3.Location = new System.Drawing.Point(15, 67);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(150, 14);
            this.lblCMF3.TabIndex = 4;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF2.Location = new System.Drawing.Point(15, 43);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(150, 14);
            this.lblCMF2.TabIndex = 2;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF1.Location = new System.Drawing.Point(15, 19);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(150, 14);
            this.lblCMF1.TabIndex = 0;
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
            this.cdvCMF5.Index = 4;
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
            this.cdvCMF5.TabIndex = 4;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 200;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF10.Index = 9;
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
            this.cdvCMF10.TabIndex = 9;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 200;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF9.Index = 8;
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
            this.cdvCMF9.TabIndex = 8;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 200;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
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
            this.cdvCMF8.Index = 7;
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
            this.cdvCMF8.TabIndex = 7;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 200;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
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
            this.cdvCMF7.Index = 6;
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
            this.cdvCMF7.TabIndex = 6;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 200;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
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
            this.cdvCMF6.Index = 5;
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
            this.cdvCMF6.TabIndex = 5;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 200;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF4.Index = 3;
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
            this.cdvCMF4.TabIndex = 3;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 200;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
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
            this.cdvCMF3.Index = 2;
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
            this.cdvCMF3.TabIndex = 2;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 200;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
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
            this.cdvCMF2.Index = 1;
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
            this.cdvCMF2.TabIndex = 1;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 200;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF1.TabIndex = 0;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 200;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF10.Location = new System.Drawing.Point(15, 235);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(150, 14);
            this.lblCMF10.TabIndex = 18;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF9.Location = new System.Drawing.Point(15, 211);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(150, 14);
            this.lblCMF9.TabIndex = 16;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF8.Location = new System.Drawing.Point(15, 187);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(150, 14);
            this.lblCMF8.TabIndex = 14;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF7.Location = new System.Drawing.Point(15, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(150, 14);
            this.lblCMF7.TabIndex = 12;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF6.Location = new System.Drawing.Point(15, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(150, 14);
            this.lblCMF6.TabIndex = 10;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF5.Location = new System.Drawing.Point(15, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(150, 14);
            this.lblCMF5.TabIndex = 8;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF4.Location = new System.Drawing.Point(15, 91);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(150, 14);
            this.lblCMF4.TabIndex = 6;
            // 
            // tbpEDCVersion
            // 
            this.tbpEDCVersion.Controls.Add(this.pnlColSetVersion2);
            this.tbpEDCVersion.Controls.Add(this.pnlColSetVersion);
            this.tbpEDCVersion.Controls.Add(this.lisColSetVersion);
            this.tbpEDCVersion.Location = new System.Drawing.Point(4, 22);
            this.tbpEDCVersion.Name = "tbpEDCVersion";
            this.tbpEDCVersion.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpEDCVersion.Size = new System.Drawing.Size(484, 397);
            this.tbpEDCVersion.TabIndex = 3;
            this.tbpEDCVersion.Text = "Version Setup";
            this.tbpEDCVersion.Visible = false;
            // 
            // pnlColSetVersion2
            // 
            this.pnlColSetVersion2.Controls.Add(this.pnlColSetVerTab);
            this.pnlColSetVersion2.Controls.Add(this.pnlColSetVerBtn);
            this.pnlColSetVersion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColSetVersion2.Location = new System.Drawing.Point(144, 47);
            this.pnlColSetVersion2.Name = "pnlColSetVersion2";
            this.pnlColSetVersion2.Size = new System.Drawing.Size(337, 347);
            this.pnlColSetVersion2.TabIndex = 3;
            // 
            // pnlColSetVerTab
            // 
            this.pnlColSetVerTab.Controls.Add(this.tabVersion);
            this.pnlColSetVerTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlColSetVerTab.Location = new System.Drawing.Point(0, 0);
            this.pnlColSetVerTab.Name = "pnlColSetVerTab";
            this.pnlColSetVerTab.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlColSetVerTab.Size = new System.Drawing.Size(337, 301);
            this.pnlColSetVerTab.TabIndex = 2;
            // 
            // tabVersion
            // 
            this.tabVersion.Controls.Add(this.tbpGeneral);
            this.tabVersion.Controls.Add(this.tbpAppNRel);
            this.tabVersion.Controls.Add(this.tbpCopy);
            this.tabVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVersion.Location = new System.Drawing.Point(3, 0);
            this.tabVersion.Name = "tabVersion";
            this.tabVersion.SelectedIndex = 0;
            this.tabVersion.Size = new System.Drawing.Size(331, 301);
            this.tabVersion.TabIndex = 4;
            this.tabVersion.SelectedIndexChanged += new System.EventHandler(this.tabVersion_SelectedIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlUpdateInfo);
            this.tbpGeneral.Controls.Add(this.grpApplyTime);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(323, 275);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlUpdateInfo
            // 
            this.pnlUpdateInfo.Controls.Add(this.grpUpdateInfo);
            this.pnlUpdateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpdateInfo.Location = new System.Drawing.Point(3, 76);
            this.pnlUpdateInfo.Name = "pnlUpdateInfo";
            this.pnlUpdateInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlUpdateInfo.Size = new System.Drawing.Size(317, 196);
            this.pnlUpdateInfo.TabIndex = 3;
            // 
            // grpUpdateInfo
            // 
            this.grpUpdateInfo.Controls.Add(this.txtColSetVerUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.lblColSetVerUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.txtColSetVerUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.lblColSetVerUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.txtColSetVerCreateTime);
            this.grpUpdateInfo.Controls.Add(this.lblColSetVerCreateTime);
            this.grpUpdateInfo.Controls.Add(this.txtColSetVerCreateUser);
            this.grpUpdateInfo.Controls.Add(this.lblColSetVerCreateUser);
            this.grpUpdateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpUpdateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUpdateInfo.Location = new System.Drawing.Point(0, 5);
            this.grpUpdateInfo.Name = "grpUpdateInfo";
            this.grpUpdateInfo.Size = new System.Drawing.Size(317, 191);
            this.grpUpdateInfo.TabIndex = 2;
            this.grpUpdateInfo.TabStop = false;
            this.grpUpdateInfo.Text = "Update Information";
            // 
            // txtColSetVerUpdateTime
            // 
            this.txtColSetVerUpdateTime.Location = new System.Drawing.Point(104, 88);
            this.txtColSetVerUpdateTime.MaxLength = 30;
            this.txtColSetVerUpdateTime.Name = "txtColSetVerUpdateTime";
            this.txtColSetVerUpdateTime.ReadOnly = true;
            this.txtColSetVerUpdateTime.Size = new System.Drawing.Size(168, 20);
            this.txtColSetVerUpdateTime.TabIndex = 3;
            this.txtColSetVerUpdateTime.TabStop = false;
            // 
            // lblColSetVerUpdateTime
            // 
            this.lblColSetVerUpdateTime.AutoSize = true;
            this.lblColSetVerUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSetVerUpdateTime.Location = new System.Drawing.Point(8, 91);
            this.lblColSetVerUpdateTime.Name = "lblColSetVerUpdateTime";
            this.lblColSetVerUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblColSetVerUpdateTime.TabIndex = 6;
            this.lblColSetVerUpdateTime.Text = "Update Time";
            this.lblColSetVerUpdateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtColSetVerUpdateUser
            // 
            this.txtColSetVerUpdateUser.Location = new System.Drawing.Point(104, 64);
            this.txtColSetVerUpdateUser.MaxLength = 20;
            this.txtColSetVerUpdateUser.Name = "txtColSetVerUpdateUser";
            this.txtColSetVerUpdateUser.ReadOnly = true;
            this.txtColSetVerUpdateUser.Size = new System.Drawing.Size(168, 20);
            this.txtColSetVerUpdateUser.TabIndex = 2;
            this.txtColSetVerUpdateUser.TabStop = false;
            // 
            // lblColSetVerUpdateUser
            // 
            this.lblColSetVerUpdateUser.AutoSize = true;
            this.lblColSetVerUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSetVerUpdateUser.Location = new System.Drawing.Point(8, 67);
            this.lblColSetVerUpdateUser.Name = "lblColSetVerUpdateUser";
            this.lblColSetVerUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblColSetVerUpdateUser.TabIndex = 4;
            this.lblColSetVerUpdateUser.Text = "Update User";
            this.lblColSetVerUpdateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtColSetVerCreateTime
            // 
            this.txtColSetVerCreateTime.Location = new System.Drawing.Point(104, 40);
            this.txtColSetVerCreateTime.MaxLength = 30;
            this.txtColSetVerCreateTime.Name = "txtColSetVerCreateTime";
            this.txtColSetVerCreateTime.ReadOnly = true;
            this.txtColSetVerCreateTime.Size = new System.Drawing.Size(168, 20);
            this.txtColSetVerCreateTime.TabIndex = 1;
            this.txtColSetVerCreateTime.TabStop = false;
            // 
            // lblColSetVerCreateTime
            // 
            this.lblColSetVerCreateTime.AutoSize = true;
            this.lblColSetVerCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSetVerCreateTime.Location = new System.Drawing.Point(8, 43);
            this.lblColSetVerCreateTime.Name = "lblColSetVerCreateTime";
            this.lblColSetVerCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblColSetVerCreateTime.TabIndex = 2;
            this.lblColSetVerCreateTime.Text = "Create Time";
            this.lblColSetVerCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtColSetVerCreateUser
            // 
            this.txtColSetVerCreateUser.Location = new System.Drawing.Point(104, 16);
            this.txtColSetVerCreateUser.MaxLength = 20;
            this.txtColSetVerCreateUser.Name = "txtColSetVerCreateUser";
            this.txtColSetVerCreateUser.ReadOnly = true;
            this.txtColSetVerCreateUser.Size = new System.Drawing.Size(168, 20);
            this.txtColSetVerCreateUser.TabIndex = 0;
            this.txtColSetVerCreateUser.TabStop = false;
            // 
            // lblColSetVerCreateUser
            // 
            this.lblColSetVerCreateUser.AutoSize = true;
            this.lblColSetVerCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSetVerCreateUser.Location = new System.Drawing.Point(8, 19);
            this.lblColSetVerCreateUser.Name = "lblColSetVerCreateUser";
            this.lblColSetVerCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblColSetVerCreateUser.TabIndex = 0;
            this.lblColSetVerCreateUser.Text = "Create User";
            this.lblColSetVerCreateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpApplyTime
            // 
            this.grpApplyTime.Controls.Add(this.chkEnd);
            this.grpApplyTime.Controls.Add(this.chkStart);
            this.grpApplyTime.Controls.Add(this.lblFromTo);
            this.grpApplyTime.Controls.Add(this.dtpEndTime);
            this.grpApplyTime.Controls.Add(this.dtpEndDate);
            this.grpApplyTime.Controls.Add(this.dtpStartTime);
            this.grpApplyTime.Controls.Add(this.dtpStartDate);
            this.grpApplyTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpApplyTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpApplyTime.Location = new System.Drawing.Point(3, 5);
            this.grpApplyTime.Name = "grpApplyTime";
            this.grpApplyTime.Size = new System.Drawing.Size(317, 71);
            this.grpApplyTime.TabIndex = 0;
            this.grpApplyTime.TabStop = false;
            this.grpApplyTime.Text = "Apply Time";
            // 
            // chkEnd
            // 
            this.chkEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEnd.Location = new System.Drawing.Point(34, 42);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(12, 16);
            this.chkEnd.TabIndex = 3;
            this.chkEnd.Text = "CheckBox1";
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkEnd_CheckedChanged);
            // 
            // chkStart
            // 
            this.chkStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStart.Location = new System.Drawing.Point(34, 18);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(12, 16);
            this.chkStart.TabIndex = 0;
            this.chkStart.Text = "CheckBox1";
            this.chkStart.CheckedChanged += new System.EventHandler(this.chkStart_CheckedChanged);
            // 
            // lblFromTo
            // 
            this.lblFromTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromTo.Location = new System.Drawing.Point(233, 22);
            this.lblFromTo.Name = "lblFromTo";
            this.lblFromTo.Size = new System.Drawing.Size(11, 10);
            this.lblFromTo.TabIndex = 2;
            this.lblFromTo.Text = "~";
            this.lblFromTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(148, 40);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(80, 20);
            this.dtpEndTime.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(56, 40);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(90, 20);
            this.dtpEndDate.TabIndex = 2;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(148, 16);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(80, 20);
            this.dtpStartTime.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(56, 16);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(90, 20);
            this.dtpStartDate.TabIndex = 0;
            // 
            // tbpAppNRel
            // 
            this.tbpAppNRel.Controls.Add(this.pnlReleaseInfo);
            this.tbpAppNRel.Controls.Add(this.grpApproval);
            this.tbpAppNRel.Location = new System.Drawing.Point(4, 22);
            this.tbpAppNRel.Name = "tbpAppNRel";
            this.tbpAppNRel.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.tbpAppNRel.Size = new System.Drawing.Size(323, 275);
            this.tbpAppNRel.TabIndex = 2;
            this.tbpAppNRel.Text = "Approval and Release";
            this.tbpAppNRel.Visible = false;
            // 
            // pnlReleaseInfo
            // 
            this.pnlReleaseInfo.Controls.Add(this.grpRelease);
            this.pnlReleaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReleaseInfo.Location = new System.Drawing.Point(3, 98);
            this.pnlReleaseInfo.Name = "pnlReleaseInfo";
            this.pnlReleaseInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlReleaseInfo.Size = new System.Drawing.Size(317, 177);
            this.pnlReleaseInfo.TabIndex = 1;
            // 
            // grpRelease
            // 
            this.grpRelease.Controls.Add(this.chkReleaseFlag);
            this.grpRelease.Controls.Add(this.txtReleaseTime);
            this.grpRelease.Controls.Add(this.lblReleaseTime);
            this.grpRelease.Controls.Add(this.txtReleaseUser);
            this.grpRelease.Controls.Add(this.lblReleaseUser);
            this.grpRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRelease.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRelease.Location = new System.Drawing.Point(0, 5);
            this.grpRelease.Name = "grpRelease";
            this.grpRelease.Size = new System.Drawing.Size(317, 172);
            this.grpRelease.TabIndex = 2;
            this.grpRelease.TabStop = false;
            this.grpRelease.Text = "Release Information";
            // 
            // chkReleaseFlag
            // 
            this.chkReleaseFlag.AutoSize = true;
            this.chkReleaseFlag.Enabled = false;
            this.chkReleaseFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkReleaseFlag.Location = new System.Drawing.Point(9, 18);
            this.chkReleaseFlag.Name = "chkReleaseFlag";
            this.chkReleaseFlag.Size = new System.Drawing.Size(94, 18);
            this.chkReleaseFlag.TabIndex = 0;
            this.chkReleaseFlag.Text = "Release Flag";
            // 
            // txtReleaseTime
            // 
            this.txtReleaseTime.Location = new System.Drawing.Point(106, 62);
            this.txtReleaseTime.MaxLength = 30;
            this.txtReleaseTime.Name = "txtReleaseTime";
            this.txtReleaseTime.ReadOnly = true;
            this.txtReleaseTime.Size = new System.Drawing.Size(168, 20);
            this.txtReleaseTime.TabIndex = 4;
            this.txtReleaseTime.TabStop = false;
            // 
            // lblReleaseTime
            // 
            this.lblReleaseTime.AutoSize = true;
            this.lblReleaseTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReleaseTime.Location = new System.Drawing.Point(9, 65);
            this.lblReleaseTime.Name = "lblReleaseTime";
            this.lblReleaseTime.Size = new System.Drawing.Size(72, 13);
            this.lblReleaseTime.TabIndex = 3;
            this.lblReleaseTime.Text = "Release Time";
            this.lblReleaseTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReleaseUser
            // 
            this.txtReleaseUser.Location = new System.Drawing.Point(106, 38);
            this.txtReleaseUser.MaxLength = 20;
            this.txtReleaseUser.Name = "txtReleaseUser";
            this.txtReleaseUser.ReadOnly = true;
            this.txtReleaseUser.Size = new System.Drawing.Size(168, 20);
            this.txtReleaseUser.TabIndex = 2;
            this.txtReleaseUser.TabStop = false;
            // 
            // lblReleaseUser
            // 
            this.lblReleaseUser.AutoSize = true;
            this.lblReleaseUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReleaseUser.Location = new System.Drawing.Point(9, 41);
            this.lblReleaseUser.Name = "lblReleaseUser";
            this.lblReleaseUser.Size = new System.Drawing.Size(71, 13);
            this.lblReleaseUser.TabIndex = 1;
            this.lblReleaseUser.Text = "Release User";
            this.lblReleaseUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpApproval
            // 
            this.grpApproval.Controls.Add(this.chkApprovalFlag);
            this.grpApproval.Controls.Add(this.txtApprovalTime);
            this.grpApproval.Controls.Add(this.lblApprovalTime);
            this.grpApproval.Controls.Add(this.txtApprovalUser);
            this.grpApproval.Controls.Add(this.lblApprovalUser);
            this.grpApproval.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpApproval.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpApproval.Location = new System.Drawing.Point(3, 5);
            this.grpApproval.Name = "grpApproval";
            this.grpApproval.Size = new System.Drawing.Size(317, 93);
            this.grpApproval.TabIndex = 0;
            this.grpApproval.TabStop = false;
            this.grpApproval.Text = "Approval Information";
            // 
            // chkApprovalFlag
            // 
            this.chkApprovalFlag.AutoSize = true;
            this.chkApprovalFlag.Enabled = false;
            this.chkApprovalFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkApprovalFlag.Location = new System.Drawing.Point(9, 18);
            this.chkApprovalFlag.Name = "chkApprovalFlag";
            this.chkApprovalFlag.Size = new System.Drawing.Size(97, 18);
            this.chkApprovalFlag.TabIndex = 0;
            this.chkApprovalFlag.Text = "Approval Flag";
            // 
            // txtApprovalTime
            // 
            this.txtApprovalTime.Location = new System.Drawing.Point(106, 62);
            this.txtApprovalTime.MaxLength = 30;
            this.txtApprovalTime.Name = "txtApprovalTime";
            this.txtApprovalTime.ReadOnly = true;
            this.txtApprovalTime.Size = new System.Drawing.Size(168, 20);
            this.txtApprovalTime.TabIndex = 4;
            this.txtApprovalTime.TabStop = false;
            // 
            // lblApprovalTime
            // 
            this.lblApprovalTime.AutoSize = true;
            this.lblApprovalTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApprovalTime.Location = new System.Drawing.Point(9, 65);
            this.lblApprovalTime.Name = "lblApprovalTime";
            this.lblApprovalTime.Size = new System.Drawing.Size(75, 13);
            this.lblApprovalTime.TabIndex = 3;
            this.lblApprovalTime.Text = "Approval Time";
            this.lblApprovalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtApprovalUser
            // 
            this.txtApprovalUser.Location = new System.Drawing.Point(106, 38);
            this.txtApprovalUser.MaxLength = 20;
            this.txtApprovalUser.Name = "txtApprovalUser";
            this.txtApprovalUser.ReadOnly = true;
            this.txtApprovalUser.Size = new System.Drawing.Size(168, 20);
            this.txtApprovalUser.TabIndex = 2;
            this.txtApprovalUser.TabStop = false;
            // 
            // lblApprovalUser
            // 
            this.lblApprovalUser.AutoSize = true;
            this.lblApprovalUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApprovalUser.Location = new System.Drawing.Point(9, 41);
            this.lblApprovalUser.Name = "lblApprovalUser";
            this.lblApprovalUser.Size = new System.Drawing.Size(74, 13);
            this.lblApprovalUser.TabIndex = 1;
            this.lblApprovalUser.Text = "Approval User";
            this.lblApprovalUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCopy
            // 
            this.tbpCopy.Controls.Add(this.grpCopyTable);
            this.tbpCopy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbpCopy.Location = new System.Drawing.Point(4, 22);
            this.tbpCopy.Name = "tbpCopy";
            this.tbpCopy.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tbpCopy.Size = new System.Drawing.Size(323, 275);
            this.tbpCopy.TabIndex = 1;
            this.tbpCopy.Text = "Copy Version";
            this.tbpCopy.Visible = false;
            // 
            // grpCopyTable
            // 
            this.grpCopyTable.Controls.Add(this.btnCopy);
            this.grpCopyTable.Controls.Add(this.lblToVersion);
            this.grpCopyTable.Controls.Add(this.txtToVersion);
            this.grpCopyTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grpCopyTable.Location = new System.Drawing.Point(3, 0);
            this.grpCopyTable.Name = "grpCopyTable";
            this.grpCopyTable.Size = new System.Drawing.Size(317, 47);
            this.grpCopyTable.TabIndex = 0;
            this.grpCopyTable.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(184, 15);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblToVersion
            // 
            this.lblToVersion.AutoSize = true;
            this.lblToVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToVersion.Location = new System.Drawing.Point(4, 19);
            this.lblToVersion.Name = "lblToVersion";
            this.lblToVersion.Size = new System.Drawing.Size(68, 13);
            this.lblToVersion.TabIndex = 0;
            this.lblToVersion.Text = "To Version";
            this.lblToVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToVersion
            // 
            this.txtToVersion.Location = new System.Drawing.Point(76, 16);
            this.txtToVersion.MaxLength = 3;
            this.txtToVersion.Name = "txtToVersion";
            this.txtToVersion.Size = new System.Drawing.Size(100, 20);
            this.txtToVersion.TabIndex = 1;
            this.txtToVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColSetVersion_KeyPress);
            // 
            // pnlColSetVerBtn
            // 
            this.pnlColSetVerBtn.Controls.Add(this.grpColSetVerBtn);
            this.pnlColSetVerBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlColSetVerBtn.Location = new System.Drawing.Point(0, 301);
            this.pnlColSetVerBtn.Name = "pnlColSetVerBtn";
            this.pnlColSetVerBtn.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlColSetVerBtn.Size = new System.Drawing.Size(337, 46);
            this.pnlColSetVerBtn.TabIndex = 3;
            // 
            // grpColSetVerBtn
            // 
            this.grpColSetVerBtn.Controls.Add(this.btnVerCreate);
            this.grpColSetVerBtn.Controls.Add(this.btnVerDelete);
            this.grpColSetVerBtn.Controls.Add(this.btnVerUpdate);
            this.grpColSetVerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpColSetVerBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpColSetVerBtn.Location = new System.Drawing.Point(3, 0);
            this.grpColSetVerBtn.Name = "grpColSetVerBtn";
            this.grpColSetVerBtn.Size = new System.Drawing.Size(331, 46);
            this.grpColSetVerBtn.TabIndex = 3;
            this.grpColSetVerBtn.TabStop = false;
            // 
            // btnVerCreate
            // 
            this.btnVerCreate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVerCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVerCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerCreate.Location = new System.Drawing.Point(50, 13);
            this.btnVerCreate.Name = "btnVerCreate";
            this.btnVerCreate.Size = new System.Drawing.Size(88, 26);
            this.btnVerCreate.TabIndex = 0;
            this.btnVerCreate.Text = "Create";
            this.btnVerCreate.Click += new System.EventHandler(this.btnVerCreate_Click);
            // 
            // btnVerDelete
            // 
            this.btnVerDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVerDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVerDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerDelete.Location = new System.Drawing.Point(234, 13);
            this.btnVerDelete.Name = "btnVerDelete";
            this.btnVerDelete.Size = new System.Drawing.Size(88, 26);
            this.btnVerDelete.TabIndex = 2;
            this.btnVerDelete.Text = "Delete";
            this.btnVerDelete.Click += new System.EventHandler(this.btnVerDelete_Click);
            // 
            // btnVerUpdate
            // 
            this.btnVerUpdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVerUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVerUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerUpdate.Location = new System.Drawing.Point(142, 13);
            this.btnVerUpdate.Name = "btnVerUpdate";
            this.btnVerUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnVerUpdate.TabIndex = 1;
            this.btnVerUpdate.Text = "Update";
            this.btnVerUpdate.Click += new System.EventHandler(this.btnVerUpdate_Click);
            // 
            // pnlColSetVersion
            // 
            this.pnlColSetVersion.Controls.Add(this.grpCoSetVersion);
            this.pnlColSetVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlColSetVersion.Location = new System.Drawing.Point(144, 0);
            this.pnlColSetVersion.Name = "pnlColSetVersion";
            this.pnlColSetVersion.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlColSetVersion.Size = new System.Drawing.Size(337, 47);
            this.pnlColSetVersion.TabIndex = 1;
            // 
            // grpCoSetVersion
            // 
            this.grpCoSetVersion.Controls.Add(this.txtColSetVersion);
            this.grpCoSetVersion.Controls.Add(this.lblColSetVersion);
            this.grpCoSetVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCoSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCoSetVersion.Location = new System.Drawing.Point(3, 0);
            this.grpCoSetVersion.Name = "grpCoSetVersion";
            this.grpCoSetVersion.Size = new System.Drawing.Size(331, 47);
            this.grpCoSetVersion.TabIndex = 0;
            this.grpCoSetVersion.TabStop = false;
            // 
            // txtColSetVersion
            // 
            this.txtColSetVersion.Location = new System.Drawing.Point(163, 16);
            this.txtColSetVersion.MaxLength = 3;
            this.txtColSetVersion.Name = "txtColSetVersion";
            this.txtColSetVersion.Size = new System.Drawing.Size(125, 20);
            this.txtColSetVersion.TabIndex = 1;
            this.txtColSetVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColSetVersion_KeyPress);
            // 
            // lblColSetVersion
            // 
            this.lblColSetVersion.AutoSize = true;
            this.lblColSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColSetVersion.Location = new System.Drawing.Point(8, 19);
            this.lblColSetVersion.Name = "lblColSetVersion";
            this.lblColSetVersion.Size = new System.Drawing.Size(132, 13);
            this.lblColSetVersion.TabIndex = 0;
            this.lblColSetVersion.Text = "Collection Set Version";
            this.lblColSetVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisColSetVersion
            // 
            this.lisColSetVersion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader4});
            this.lisColSetVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisColSetVersion.EnableSort = true;
            this.lisColSetVersion.EnableSortIcon = true;
            this.lisColSetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisColSetVersion.FullRowSelect = true;
            this.lisColSetVersion.Location = new System.Drawing.Point(3, 0);
            this.lisColSetVersion.MultiSelect = false;
            this.lisColSetVersion.Name = "lisColSetVersion";
            this.lisColSetVersion.Size = new System.Drawing.Size(141, 394);
            this.lisColSetVersion.TabIndex = 0;
            this.lisColSetVersion.UseCompatibleStateImageBehavior = false;
            this.lisColSetVersion.View = System.Windows.Forms.View.Details;
            this.lisColSetVersion.SelectedIndexChanged += new System.EventHandler(this.lisColSetVersion_SelectedIndexChanged);
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Collection Set Version";
            this.ColumnHeader4.Width = 118;
            // 
            // tbpCopyColSet
            // 
            this.tbpCopyColSet.Controls.Add(this.grpColSet);
            this.tbpCopyColSet.Location = new System.Drawing.Point(4, 22);
            this.tbpCopyColSet.Name = "tbpCopyColSet";
            this.tbpCopyColSet.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCopyColSet.Size = new System.Drawing.Size(484, 397);
            this.tbpCopyColSet.TabIndex = 4;
            this.tbpCopyColSet.Text = "Copy Collection Set";
            // 
            // grpColSet
            // 
            this.grpColSet.Controls.Add(this.lblToColSet);
            this.grpColSet.Controls.Add(this.cdvVersion);
            this.grpColSet.Controls.Add(this.txtToColSet);
            this.grpColSet.Controls.Add(this.lblFromVersion);
            this.grpColSet.Controls.Add(this.btnColSetCopy);
            this.grpColSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpColSet.Location = new System.Drawing.Point(3, 0);
            this.grpColSet.Name = "grpColSet";
            this.grpColSet.Size = new System.Drawing.Size(478, 72);
            this.grpColSet.TabIndex = 0;
            this.grpColSet.TabStop = false;
            // 
            // lblToColSet
            // 
            this.lblToColSet.AutoSize = true;
            this.lblToColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToColSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToColSet.Location = new System.Drawing.Point(15, 43);
            this.lblToColSet.Name = "lblToColSet";
            this.lblToColSet.Size = new System.Drawing.Size(105, 13);
            this.lblToColSet.TabIndex = 10;
            this.lblToColSet.Text = "To Collection Set";
            this.lblToColSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvVersion
            // 
            this.cdvVersion.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvVersion.BorderHotColor = System.Drawing.Color.Black;
            this.cdvVersion.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvVersion.BtnToolTipText = "";
            this.cdvVersion.DescText = "";
            this.cdvVersion.DisplaySubItemIndex = -1;
            this.cdvVersion.DisplayText = "";
            this.cdvVersion.Focusing = null;
            this.cdvVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvVersion.Index = 0;
            this.cdvVersion.IsViewBtnImage = false;
            this.cdvVersion.Location = new System.Drawing.Point(120, 16);
            this.cdvVersion.MaxLength = 3;
            this.cdvVersion.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvVersion.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvVersion.Name = "cdvVersion";
            this.cdvVersion.ReadOnly = false;
            this.cdvVersion.SearchSubItemIndex = 0;
            this.cdvVersion.SelectedDescIndex = -1;
            this.cdvVersion.SelectedSubItemIndex = -1;
            this.cdvVersion.SelectionStart = 0;
            this.cdvVersion.Size = new System.Drawing.Size(96, 20);
            this.cdvVersion.SmallImageList = null;
            this.cdvVersion.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvVersion.TabIndex = 0;
            this.cdvVersion.TextBoxToolTipText = "";
            this.cdvVersion.TextBoxWidth = 96;
            this.cdvVersion.VisibleButton = true;
            this.cdvVersion.VisibleColumnHeader = false;
            this.cdvVersion.VisibleDescription = false;
            this.cdvVersion.ButtonPress += new System.EventHandler(this.cdvVersion_ButtonPress);
            // 
            // txtToColSet
            // 
            this.txtToColSet.Location = new System.Drawing.Point(120, 40);
            this.txtToColSet.MaxLength = 25;
            this.txtToColSet.Name = "txtToColSet";
            this.txtToColSet.Size = new System.Drawing.Size(177, 20);
            this.txtToColSet.TabIndex = 1;
            // 
            // lblFromVersion
            // 
            this.lblFromVersion.AutoSize = true;
            this.lblFromVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromVersion.Location = new System.Drawing.Point(15, 19);
            this.lblFromVersion.Name = "lblFromVersion";
            this.lblFromVersion.Size = new System.Drawing.Size(80, 13);
            this.lblFromVersion.TabIndex = 6;
            this.lblFromVersion.Text = "From Version";
            this.lblFromVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnColSetCopy
            // 
            this.btnColSetCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnColSetCopy.Location = new System.Drawing.Point(312, 39);
            this.btnColSetCopy.Name = "btnColSetCopy";
            this.btnColSetCopy.Size = new System.Drawing.Size(88, 23);
            this.btnColSetCopy.TabIndex = 2;
            this.btnColSetCopy.Text = "Copy";
            this.btnColSetCopy.Click += new System.EventHandler(this.btnColSetCopy_Click);
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Collection Set Version";
            this.ColumnHeader3.Width = 183;
            // 
            // btnUndelete
            // 
            this.btnUndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUndelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUndelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUndelete.Location = new System.Drawing.Point(549, 8);
            this.btnUndelete.Name = "btnUndelete";
            this.btnUndelete.Size = new System.Drawing.Size(88, 26);
            this.btnUndelete.TabIndex = 3;
            this.btnUndelete.Text = "Undelete";
            this.btnUndelete.Click += new System.EventHandler(this.btnUndelete_Click);
            // 
            // pnlLeftTop
            // 
            this.pnlLeftTop.Controls.Add(this.chkIncludeDeleteColSet);
            this.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftTop.Location = new System.Drawing.Point(3, 3);
            this.pnlLeftTop.Name = "pnlLeftTop";
            this.pnlLeftTop.Size = new System.Drawing.Size(229, 25);
            this.pnlLeftTop.TabIndex = 1;
            // 
            // chkIncludeDeleteColSet
            // 
            this.chkIncludeDeleteColSet.AutoSize = true;
            this.chkIncludeDeleteColSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDeleteColSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludeDeleteColSet.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkIncludeDeleteColSet.Location = new System.Drawing.Point(5, 5);
            this.chkIncludeDeleteColSet.Name = "chkIncludeDeleteColSet";
            this.chkIncludeDeleteColSet.Size = new System.Drawing.Size(175, 18);
            this.chkIncludeDeleteColSet.TabIndex = 8;
            this.chkIncludeDeleteColSet.Text = "Include Deleted Collection Set";
            // 
            // frmEDCSetupCollectionSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(734, 542);
            this.Name = "frmEDCSetupCollectionSet";
            this.Text = "Collection Set Setup";
            this.Activated += new System.EventHandler(this.frmEDCTBLDEF00_Activated);
            this.Load += new System.EventHandler(this.frmEDCTBLDEF00_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grbColSet.ResumeLayout(false);
            this.grbColSet.PerformLayout();
            this.panRightBottom.ResumeLayout(false);
            this.tabColSet.ResumeLayout(false);
            this.tbpEDCGeneral.ResumeLayout(false);
            this.grpColSetGeneral.ResumeLayout(false);
            this.grpColSetGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAppUserID)).EndInit();
            this.grpDateTime.ResumeLayout(false);
            this.grpDateTime.PerformLayout();
            this.tbpEDCGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            this.tbpEDCCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.tbpEDCVersion.ResumeLayout(false);
            this.pnlColSetVersion2.ResumeLayout(false);
            this.pnlColSetVerTab.ResumeLayout(false);
            this.tabVersion.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.PerformLayout();
            this.grpApplyTime.ResumeLayout(false);
            this.tbpAppNRel.ResumeLayout(false);
            this.pnlReleaseInfo.ResumeLayout(false);
            this.grpRelease.ResumeLayout(false);
            this.grpRelease.PerformLayout();
            this.grpApproval.ResumeLayout(false);
            this.grpApproval.PerformLayout();
            this.tbpCopy.ResumeLayout(false);
            this.grpCopyTable.ResumeLayout(false);
            this.grpCopyTable.PerformLayout();
            this.pnlColSetVerBtn.ResumeLayout(false);
            this.grpColSetVerBtn.ResumeLayout(false);
            this.pnlColSetVersion.ResumeLayout(false);
            this.grpCoSetVersion.ResumeLayout(false);
            this.grpCoSetVersion.PerformLayout();
            this.tbpCopyColSet.ResumeLayout(false);
            this.grpColSet.ResumeLayout(false);
            this.grpColSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvVersion)).EndInit();
            this.pnlLeftTop.ResumeLayout(false);
            this.pnlLeftTop.PerformLayout();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Variable Definition "
        
        bool bLoadFlag;
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
                dtpStartDate.Enabled = false;
                dtpStartTime.Enabled = false;
                dtpEndDate.Enabled = false;
                dtpEndTime.Enabled = false;
                
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this.pnlRight);
                    MPCF.ClearList(lisColSetVersion, true);
                }
                else if (ProcStep == '2')
                {
                    txtColSetVersion.Text = "";
                    chkApprovalFlag.Checked = false;
                    txtApprovalUser.Text = "";
                    txtApprovalTime.Text = "";
                    chkReleaseFlag.Checked = false;
                    txtReleaseUser.Text = "";
                    txtReleaseTime.Text = "";
                    txtColSetVerCreateUser.Text = "";
                    txtColSetVerCreateTime.Text = "";
                    txtColSetVerUpdateUser.Text = "";
                    txtColSetVerUpdateTime.Text = "";
                    chkStart.Checked = false;
                    chkEnd.Checked = false;
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
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {

            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_Col_Set":

                        if (MPCF.CheckValue(txtColSet, 1) == false)
                        {
                            return false;
                        }

                        switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                        {
                            case MPGC.MP_STEP_CREATE:
                                if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                                {
                                    return false;
                                }

                                //CMF Validation Check
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                                {
                                    return false;
                                }
                                if (cboLotRes.SelectedIndex == -1)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    cboLotRes.Focus();
                                    return false;
                                }
                                break;

                            case MPGC.MP_STEP_UPDATE:

                                if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                                {
                                    return false;
                                }

                                //CMF Validation Check
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                                {
                                    return false;
                                }
                                if (cboLotRes.SelectedIndex == -1)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    cboLotRes.Focus();
                                    return false;
                                }
                                break;
                            case MPGC.MP_STEP_DELETE:

                                break;

                            case MPGC.MP_STEP_UNDELETE:

                                break;

                        }
                        break;

                    case "Update_Col_Set_Version":

                        if (MPCF.CheckValue(txtColSet, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtColSetVersion, 1) == false)
                        {
                            return false;
                        }

                        switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                        {
                            case MPGC.MP_STEP_CREATE:
                                break;


                            case MPGC.MP_STEP_UPDATE:

                                break;

                            case MPGC.MP_STEP_DELETE:

                                break;

                        }
                        break;
                    case "Copy_Col_Set_Version":

                        if (MPCF.CheckValue(txtColSet, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtColSetVersion, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtToVersion, 1) == false)
                        {
                            return false;
                        }
                        break;
                    case "Copy_ColSet":

                        if (MPCF.CheckValue(txtColSet, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cdvVersion, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtToColSet, 1) == false)
                        {
                            return false;
                        }
                        break;
                    default:

                        MPCF.ShowMsgBox("Invalid Case");
                        return false;
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
        // SetGroupCmfItem()
        //       - Set Group & CMF according to Factory GRP/CMF Item
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool SetGroupCmfItem()
        {
            string[] sColSetGrpTableName = new string[10];
            
            try
            {
                sColSetGrpTableName[0] = MPGC.MP_GCM_COL_GRP_1;
                sColSetGrpTableName[1] = MPGC.MP_GCM_COL_GRP_2;
                sColSetGrpTableName[2] = MPGC.MP_GCM_COL_GRP_3;
                sColSetGrpTableName[3] = MPGC.MP_GCM_COL_GRP_4;
                sColSetGrpTableName[4] = MPGC.MP_GCM_COL_GRP_5;
                sColSetGrpTableName[5] = MPGC.MP_GCM_COL_GRP_6;
                sColSetGrpTableName[6] = MPGC.MP_GCM_COL_GRP_7;
                sColSetGrpTableName[7] = MPGC.MP_GCM_COL_GRP_8;
                sColSetGrpTableName[8] = MPGC.MP_GCM_COL_GRP_9;
                sColSetGrpTableName[9] = MPGC.MP_GCM_COL_GRP_10;
                
                MPCR.SetGRPItem(MPGC.MP_GRP_COL_SET, "lblGroup", "cdvGroup", grpGroup, sColSetGrpTableName);
                MPCR.SetCMFItem(MPGC.MP_CMF_COL_SET, "lblCMF", "cdvCMF", grpCMF);
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //
        // View_Col_Set()
        //       - View Collection Set Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Col_Set()
        {
            TRSNode in_node = new TRSNode("VIEW_COL_SET_IN");
            TRSNode out_node = new TRSNode("VIEW_COL_SET_OUT");
            
            try
            {
                ClearData('1');
                MPCF.ClearList(lisColSetVersion, true);
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("COL_SET_ID", lisColSet.SelectedItems[0].Text);

                if (MPCR.CallService("EDC", "EDC_View_Col_Set", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtColSet.Text = MPCF.Trim(out_node.GetString("COL_SET_ID"));
                txtDesc.Text = MPCF.Trim(out_node.GetString("COL_SET_DESC"));
                cdvGroup1.Text = MPCF.Trim(out_node.GetString("COL_GRP_1"));
                cdvGroup2.Text = MPCF.Trim(out_node.GetString("COL_GRP_2"));
                cdvGroup3.Text = MPCF.Trim(out_node.GetString("COL_GRP_3"));
                cdvGroup4.Text = MPCF.Trim(out_node.GetString("COL_GRP_4"));
                cdvGroup5.Text = MPCF.Trim(out_node.GetString("COL_GRP_5"));
                cdvGroup6.Text = MPCF.Trim(out_node.GetString("COL_GRP_6"));
                cdvGroup7.Text = MPCF.Trim(out_node.GetString("COL_GRP_7"));
                cdvGroup8.Text = MPCF.Trim(out_node.GetString("COL_GRP_8"));
                cdvGroup9.Text = MPCF.Trim(out_node.GetString("COL_GRP_9"));
                cdvGroup10.Text = MPCF.Trim(out_node.GetString("COL_GRP_10"));
                cdvCMF1.Text = MPCF.Trim(out_node.GetString("COL_CMF_1"));
                cdvCMF2.Text = MPCF.Trim(out_node.GetString("COL_CMF_2"));
                cdvCMF3.Text = MPCF.Trim(out_node.GetString("COL_CMF_3"));
                cdvCMF4.Text = MPCF.Trim(out_node.GetString("COL_CMF_4"));
                cdvCMF5.Text = MPCF.Trim(out_node.GetString("COL_CMF_5"));
                cdvCMF6.Text = MPCF.Trim(out_node.GetString("COL_CMF_6"));
                cdvCMF7.Text = MPCF.Trim(out_node.GetString("COL_CMF_7"));
                cdvCMF8.Text = MPCF.Trim(out_node.GetString("COL_CMF_8"));
                cdvCMF9.Text = MPCF.Trim(out_node.GetString("COL_CMF_9"));
                cdvCMF10.Text = MPCF.Trim(out_node.GetString("COL_CMF_10"));

                //Default Collection Mode (e.g. Auto, Manual) - Added by LAVERWON (08/01/14)
                // A : Auto, M : Manual
                if (MPCF.Trim(out_node.GetChar("DEFAULT_COL_MODE_FLAG")) == "A")
                {
                    this.rbnAuto.Checked = true;
                }
                else
                {
                    this.rbnManual.Checked = true;
                }
                
                if ( MPCF.Trim(out_node.GetChar("LOT_OR_RES_FLAG")) == "L")
                {
                    cboLotRes.SelectedIndex = 0;
                }
                else if ( MPCF.Trim(out_node.GetChar("LOT_OR_RES_FLAG")) == "R")
                {
                    cboLotRes.SelectedIndex = 1;
                }
                else if (MPCF.Trim(out_node.GetChar("LOT_OR_RES_FLAG")) == "B")
                {
                    cboLotRes.SelectedIndex = 2;
                }
                else
                {
                    cboLotRes.SelectedIndex = - 1;
                }
                chkAppRequireFlag.Checked = ( MPCF.Trim(out_node.GetChar("APPROVAL_REQUIRE_FLAG")) == "Y") ? true : false;
                if (chkAppRequireFlag.Checked == true)
                {
                    this.cdvAppUserID.Enabled = true;
                }
                else
                {
                    this.cdvAppUserID.Text = "";
                    this.cdvAppUserID.Enabled = false;
                }
                cdvAppUserID.Text = MPCF.Trim(out_node.GetString("APPROVAL_USER_ID"));
                if ( MPCF.Trim(out_node.GetChar("DELETE_FLAG")) == "Y")
                {
                    chkDeleteFlag.Checked = true;
                }
                else
                {
                    chkDeleteFlag.Checked = false;
                }
                
                txtDeleteUser.Text =  MPCF.Trim(out_node.GetString("DELETE_USER_ID"));
                txtDeleteTime.Text = MPCF.MakeDateFormat(out_node.GetString("DELETE_TIME"), DATE_TIME_FORMAT.NONE);
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //
        // Update_Col_Set()
        //       - Create/Update/Delete Collection Set Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete, "R" - Undelete)
        //
        private bool Update_Col_Set(char ProcStep)
        {
            ListViewItem itm;

            TRSNode in_node = new TRSNode("UPDATE_COL_SET_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("COL_SET_ID", txtColSet.Text);
                in_node.AddString("COL_SET_DESC", txtDesc.Text);

                in_node.AddString("COL_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("COL_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("COL_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("COL_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("COL_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("COL_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("COL_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("COL_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("COL_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("COL_GRP_10", MPCF.Trim(cdvGroup10.Text));

                in_node.AddString("COL_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("COL_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("COL_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("COL_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("COL_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("COL_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("COL_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("COL_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("COL_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("COL_CMF_10", MPCF.Trim(cdvCMF10.Text));

                //Default Collection Mode (e.g. Auto, Manual) - Added by LAVERWON (08/01/14)
                // A : Auto, M : Manual
                if (this.rbnAuto.Checked == true)
                {
                    in_node.AddChar("DEFAULT_COL_MODE_FLAG", 'A');
                }
                else
                {
                    in_node.AddChar("DEFAULT_COL_MODE_FLAG", 'M');
                }
                
                if ( MPCF.Trim(cboLotRes.Text) != "")
                {
                    in_node.AddChar("LOT_OR_RES_FLAG",  MPCF.ToChar(MPCF.Trim(cboLotRes.Text).Substring(0, 1)));
                }
                else
                {
                    in_node.AddChar("LOT_OR_RES_FLAG", ' ');
                }
                in_node.AddChar("APPROVAL_REQUIRE_FLAG", chkAppRequireFlag.Checked == true ? 'Y' : ' ');
                in_node.AddString("APPROVAL_USER_ID", MPCF.Trim(cdvAppUserID.Text), true);

                if (MPCR.CallService("EDC", "EDC_Update_Col_Set", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        chkDeleteFlag.Checked = false;
                        itm = lisColSet.Items.Add(MPCF.Trim(txtColSet.Text), (int)(SMALLICON_INDEX.IDX_COL_SET));
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisColSet.Sorting = SortOrder.Ascending;
                        lisColSet.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisColSet, MPCF.Trim(txtColSet.Text), false) == true)
                        {
                            lisColSet.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        chkDeleteFlag.Checked = true;
                        if (MPCF.FindListItem(lisColSet, MPCF.Trim(txtColSet.Text), false) == true)
                        {
                            lisColSet.SelectedItems[0].ImageIndex =  MPCF.ToInt( SMALLICON_INDEX.IDX_COL_SET_DELETE);
                            lisColSet.SelectedItems[0].ForeColor = Color.Magenta;
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_UNDELETE)
                    {
                        chkDeleteFlag.Checked = false;
                        if (MPCF.FindListItem(lisColSet, MPCF.Trim(txtColSet.Text), false) == true)
                        {
                            lisColSet.SelectedItems[0].ImageIndex =  MPCF.ToInt( SMALLICON_INDEX.IDX_COL_SET);
                            lisColSet.SelectedItems[0].ForeColor = Color.Black;
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisColSet.Items.Count);
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
        // View_Col_Set_Version()
        //       - View Collection Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Col_Set_Version()
        {
            TRSNode in_node = new TRSNode("VIEW_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("VIEW_COL_SET_VERSION_OUT");

            try
            {
                ClearData('2');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                // Modified by DM KIM 2014.02.13 ColSet 선택이 안되어 있으면 상단부 Col Set으로 조회
                in_node.AddString("COL_SET_ID", MPCF.Trim(txtColSet.Text));
                in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(lisColSetVersion.SelectedItems[0].Text));

                if (MPCR.CallService("EDC", "EDC_View_Col_Set_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtColSetVersion.Text = out_node.GetInt("COL_SET_VERSION").ToString();
                if (out_node.GetString("APPLY_START_TIME") == "")
                {
                    chkStart.Checked = false;
                    dtpStartDate.Enabled = false;
                    dtpStartTime.Enabled = false;
                }
                else
                {
                    chkStart.Checked = true;
                    dtpStartDate.Enabled = true;
                    dtpStartTime.Enabled = true;
                    if (out_node.GetString("APPLY_START_TIME") != null)
                    {
                        dtpStartDate.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                        dtpStartTime.Value = MPCF.ToDate(out_node.GetString("APPLY_START_TIME"));
                    }
                }
                if (out_node.GetString("APPLY_END_TIME") == "")
                {
                    chkEnd.Checked = false;
                    dtpEndDate.Enabled = false;
                    dtpEndTime.Enabled = false;
                }
                else
                {
                    chkEnd.Checked = true;
                    dtpEndDate.Enabled = true;
                    dtpEndTime.Enabled = true;
                    if (out_node.GetString("APPLY_END_TIME") != null)
                    {
                        dtpEndDate.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                        dtpEndTime.Value = MPCF.ToDate(out_node.GetString("APPLY_END_TIME"));
                    }
                }
                
                chkApprovalFlag.Checked = ( MPCF.Trim(out_node.GetChar("APPROVAL_FLAG")) == "Y") ? true : false;
                txtApprovalUser.Text =  MPCF.Trim(out_node.GetString("APPROVAL_USER_ID"));
                txtApprovalTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPROVAL_TIME"));
                chkReleaseFlag.Checked = ( MPCF.Trim(out_node.GetChar("RELEASE_FLAG")) == "Y") ? true : false;
                txtReleaseUser.Text =  MPCF.Trim(out_node.GetString("RELEASE_USER_ID"));
                txtReleaseTime.Text = MPCF.MakeDateFormat(out_node.GetString("RELEASE_TIME"));
                txtColSetVerCreateUser.Text =  MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtColSetVerCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtColSetVerUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtColSetVerUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        //
        // Update_Col_Set_Version()
        //       - Create/Update/Delete Collection Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Col_Set_Version(char ProcStep)
        {
            
            ListViewItem itm = null;
            int idx = 0;

            TRSNode in_node = new TRSNode("UPDATE_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                //in_node.AddString("COL_SET_ID", lisColSet.SelectedItems[0].Text);     
                in_node.AddString("COL_SET_ID", MPCF.Trim(txtColSet.Text));     // Modified by DM KIM 2014.01.16 List의 Col Set이 아니라 Text Box의 Col Set 사용
                in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(txtColSetVersion.Text));

                if (chkStart.Checked == true)
                {
                    String s_datetime = MPCF.ToStandardTime(dtpStartDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                        MPCF.ToStandardTime(dtpStartTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                    in_node.AddString("APPLY_START_TIME", s_datetime);
                }
                
                if (chkEnd.Checked == true)
                {
                    String s_datetime = MPCF.ToStandardTime(dtpEndDate.Value, MPGC.MP_CONVERT_DATE_FORMAT) +
                        MPCF.ToStandardTime(dtpEndTime.Value, MPGC.MP_CONVERT_TIME_FORMAT);
                    in_node.AddString("APPLY_END_TIME", s_datetime);
                }

                if (MPCR.CallService("EDC", "EDC_Update_Col_Set_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisColSetVersion.Items.Add(MPCF.Trim(txtColSetVersion.Text), (int)(SMALLICON_INDEX.IDX_COL_SET_VERSION));
                        itm.Selected = true;
                        lisColSetVersion.Sorting = SortOrder.Ascending;
                        lisColSetVersion.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        //Do Nothing
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisColSetVersion, MPCF.Trim(txtColSetVersion.Text), false);
                        if (idx != - 1)
                        {
                            lisColSetVersion.Items[idx].Remove();
                        }
                    }
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
        // Copy_Col_Set_Version()
        //       - Copy Collection Set Version and it's attached character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Copy_Col_Set_Version(char ProcStep)
        {
            
            ListViewItem itm;

            TRSNode in_node = new TRSNode("COPY_COL_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("COL_SET_ID", MPCF.Trim(txtColSet.Text));
                in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(MPCF.Trim(txtToVersion.Text)));
                in_node.AddInt("FROM_COL_SET_VERSION", MPCF.ToInt(MPCF.Trim(txtColSetVersion.Text)));

                if (MPCR.CallService("EDC", "EDC_Copy_Col_Set_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_COPY)
                    {
                        itm = lisColSetVersion.Items.Add(MPCF.Trim(txtToVersion.Text), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
                        itm.Selected = true;
                        itm.EnsureVisible();
                    }
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
        // Copy_Col_Set()
        //       - Copy Collection Set and it's attached character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Copy_Col_Set()
        {
            ListViewItem itm;

            TRSNode in_node = new TRSNode("COPY_COL_SET_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = MPGC.MP_STEP_COPY;
                in_node.AddString("FROM_COL_SET_ID", MPCF.Trim(txtColSet.Text));
                in_node.AddInt("FROM_COL_SET_VERSION", MPCF.ToInt(MPCF.Trim(cdvVersion.Text)));
                in_node.AddString("TO_COL_SET_ID", MPCF.Trim(txtToColSet.Text));

                if (MPCR.CallService("EDC", "EDC_Copy_Col_Set", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (lisColSet.Items.Count > 0)
                    {
                        if (MPCF.FindListItem(lisColSet, txtToColSet.Text, false) == false)
                        {
                            itm = lisColSet.Items.Add(MPCF.Trim(txtToColSet.Text), (int)SMALLICON_INDEX.IDX_COL_SET);
                            itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                            itm.Selected = true;
                            lisColSet.Sorting = SortOrder.Ascending;
                            lisColSet.Sort();
                            itm.EnsureVisible();
                        }
                    }
                    else
                    {
                        itm = lisColSet.Items.Add(MPCF.Trim(txtToColSet.Text), (int)SMALLICON_INDEX.IDX_COL_SET);
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisColSet.Sorting = SortOrder.Ascending;
                        lisColSet.Sort();
                        itm.EnsureVisible();
                    }
                }
                
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
                return this.lisColSet;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
#endregion
        
        private void frmEDCTBLDEF00_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (bLoadFlag == false)
                {
                    if (SetGroupCmfItem() == false)
                    {
                        return;
                    }
                    lblDataCount.Text = "";
                    
                    if (cdvAppUserID.DisplaySubItemIndex != cdvAppUserID.SelectedSubItemIndex)
                    {
                        cdvAppUserID_ButtonPress(null, null);
                    }

                    if (EDCLIST.ViewEDCColSetList(lisColSet, '1', null, "", -1, -1, ' ', (chkIncludeDeleteColSet.Checked ? true : false)) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(lisColSet.Items.Count);
                    }
                    else
                    {
                        return;
                    }
                    if (lisColSet.Items.Count > 0)
                    {
                        lisColSet.Items[0].Selected = true;
                    }

                    bLoadFlag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmEDCTBLDEF00_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisColSet);
                MPCF.InitListView(lisColSetVersion);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Col_Set", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Col_Set(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnVerCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Col_Set_Version", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Col_Set_Version(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (EDCLIST.ViewEDCColSetVersionList(lisColSetVersion, '2', txtColSet.Text, -1, null, "") == false)
                        {
                            return;
                        }
                        if (lisColSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisColSetVersion, txtColSetVersion.Text, false);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Col_Set", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Col_Set(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnVerUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Col_Set_Version", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Col_Set_Version(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (EDCLIST.ViewEDCColSetVersionList(lisColSetVersion, '2', txtColSet.Text, -1, null, "") == false)
                        {
                            return;
                        }
                        if (lisColSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisColSetVersion, txtColSetVersion.Text, false);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Col_Set", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Col_Set(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnVerDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Col_Set_Version", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Col_Set_Version(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    ClearData('2');
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        EDCLIST.ViewEDCColSetVersionList(lisColSetVersion, '2', txtColSet.Text, -1, null, "");
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnUndelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (tabColSet.SelectedTab.TabIndex > 3)
                {
                    return;
                }
                if (CheckCondition("Update_Col_Set", MPGC.MP_STEP_UNDELETE) == true)
                {
                    if (Update_Col_Set(MPGC.MP_STEP_UNDELETE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisColSet_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (lisColSet.SelectedIndices.Count > 0)
                {
                    if (View_Col_Set() == false)
                    {
                        return;
                    }
                    if (EDCLIST.ViewEDCColSetVersionList(lisColSetVersion, '2', lisColSet.SelectedItems[0].Text, -1, null, "") == false)
                    {
                        return;
                    }
                    if (lisColSetVersion.Items.Count > 0)
                    {
                        lisColSetVersion.Items[0].Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (EDCLIST.ViewEDCColSetList(lisColSet, '1', null, "", -1, -1, ' ', (chkIncludeDeleteColSet.Checked ? true : false)) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisColSet.Items.Count);
                    if (lisColSet.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisColSet, txtColSet.Text, false);
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtColSet_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar == (char)13)
                {
                    return;
                }
                else if (e.KeyChar == (char)58)
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (lisColSet.Items.Count > 0)
                {
                    MPCF.ExportToExcel(lisColSet, this.Text, "");
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisColSetVersion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisColSetVersion.SelectedIndices.Count > 0)
                {
                    View_Col_Set_Version();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cdvGroupCmf_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                MPCR.ProcGRPCMFButtonPress(sender);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }        
                        
        }
        
        private void txtColSetVersion_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar == (char)13 || e.KeyChar == (char)8)
                {
                    return;
                }
                else if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        
        private void cdvCMF_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            try
            {
                MPCR.CheckCMFKeyPress(sender, e);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
                        
        }
        
        private void chkStart_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (chkStart.Checked == true)
                {
                    dtpStartDate.Enabled = true;
                    dtpStartTime.Enabled = true;
                }
                else
                {
                    dtpStartDate.Enabled = false;
                    dtpStartTime.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void chkEnd_CheckedChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (chkEnd.Checked == true)
                {
                    dtpEndDate.Enabled = true;
                    dtpEndTime.Enabled = true;
                }
                else
                {
                    dtpEndDate.Enabled = false;
                    dtpEndTime.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }            
                    
        }
        
        private void tabColSet_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            try
            {
                if (!(tabColSet.SelectedTab == tbpEDCVersion))
                {
                    MPCR.ChangeControlEnabled(this, btnCreate, true);
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                    MPCR.ChangeControlEnabled(this, btnUndelete, true);
                }
                else
                {
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnUndelete.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Copy_Col_Set_Version", MPGC.MP_STEP_COPY) == true)
                {
                    if (Copy_Col_Set_Version(MPGC.MP_STEP_COPY) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (EDCLIST.ViewEDCColSetVersionList(lisColSetVersion, '2', txtColSet.Text, -1, null, "") == false)
                        {
                            return;
                        }
                        if (lisColSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisColSetVersion, txtToVersion.Text, false);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                MPCF.FindListItemNextPartial(lisColSet, txtFind.Text, true, false);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                MPCF.FindListItemPartial(lisColSet, txtFind.Text, 0, true, false);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void tabVersion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (!(tabVersion.SelectedTab == tbpCopy))
                {
                    MPCR.ChangeControlEnabled(this, btnVerCreate, true);
                    MPCR.ChangeControlEnabled(this, btnVerUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnVerDelete, true);
                }
                else
                {
                    btnVerCreate.Enabled = false;
                    btnVerUpdate.Enabled = false;
                    btnVerDelete.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvAppUserID_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                cdvAppUserID.Init();
                MPCF.InitListView(cdvAppUserID.GetListView);
                cdvAppUserID.Columns.Add("UserID", 100, HorizontalAlignment.Left);
                cdvAppUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvAppUserID.SelectedSubItemIndex = 0;

                if (SECLIST.ViewSECUserList(cdvAppUserID.GetListView, '1', -1, null, "", "") == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvVersion_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                int iVer = 0;
                cdvVersion.Init();
                MPCF.InitListView(cdvVersion.GetListView);
                cdvVersion.Columns.Add("Version", 50, HorizontalAlignment.Left);
                cdvVersion.SelectedSubItemIndex = 0;
                cdvVersion.DisplaySubItemIndex = 0;
                if (MPCR.FindColSetVersion('1', txtColSet.Text, ref iVer, "", "", 0, "", "", "", MPCF.ToChar(MPCF.Trim(cboLotRes.Text).Substring(0, 1)), null, true, 'N') == true)
                {
                    cdvVersion.Text = iVer.ToString ();
                }
                if (EDCLIST.ViewEDCColSetVersionList(cdvVersion.GetListView, '2', txtColSet.Text, -1, null, "") == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnColSetCopy_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                string sColSet;
                sColSet = txtToColSet.Text;
                if (CheckCondition("Copy_ColSet", MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (Copy_Col_Set() == false)
                {
                    return;
                }
                if (MPGV.gbListAutoRefresh == true)
                {
                    if (EDCLIST.ViewEDCColSetList(lisColSet, '1', null, "", -1, -1, ' ', (chkIncludeDeleteColSet.Checked ? true : false)) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(lisColSet.Items.Count);
                        if (lisColSet.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisColSet, MPCF.Trim(sColSet), false);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void chkAppRequireFlag_CheckedChanged(object sender, EventArgs e)
        {
           
            try
            {
                if (chkAppRequireFlag.Checked == true)
                {
                    this.cdvAppUserID.Enabled = true;
                }
                else
                {
                    this.cdvAppUserID.Text = "";
                    this.cdvAppUserID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

#endif // _EDC

    }

}
