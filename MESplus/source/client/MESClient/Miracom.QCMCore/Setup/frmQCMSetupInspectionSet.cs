
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
//   File Name   : frmQCMSetupInspectionSet.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - DisableField : Disable All Fields
//       - EnableField : Enable All Fields
//       - SetGroupCmfItem : Initialize Group/CMF Item Controls according to Factory CMF Configuration
//       - View_Inspection_Set() : View Inspection Set Definition
//       - Update_Inspection_Set() : Create/Update/Delete Inspection Set definition
//       - View_Inspection_Version() : View Inspection Set Version
//       - Update_Inspection_Version() : Create/Update/Delete Inspection Set Version
//       - Copy_Inspection_Version() : Copy Inspection Set Version and it's attached Inspection Item
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-12-21 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _QCM = True Then

namespace Miracom.QCMCore
{
    public class frmQCMSetupInspectionSet : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMSetupInspectionSet()
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
        private Miracom.UI.Controls.MCListView.MCListView lisInspSet;
        private System.Windows.Forms.ColumnHeader colInspSet;
        private System.Windows.Forms.ColumnHeader colInspSetDesc;
        private System.Windows.Forms.GroupBox grpLabel;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label Label6;
        //private System.Windows.Forms.GroupBox grpUpdateInfo ;
        private System.Windows.Forms.TextBox txtInspSetVerUpdateTime;
        private System.Windows.Forms.Label lblInspSetVerUpdateTime;
        private System.Windows.Forms.TextBox txtInspSetVerUpdateUser;
        private System.Windows.Forms.Label lblInspSetVerUpdateUser;
        private System.Windows.Forms.TextBox txtInspSetVerCreateTime;
        private System.Windows.Forms.Label lblInspSetVerCreateTime;
        private System.Windows.Forms.TextBox txtInspSetVerCreateUser;
        private System.Windows.Forms.Label lblInspSetVerCreateUser;
        private System.Windows.Forms.TextBox txtInspSet;
        private System.Windows.Forms.Label lblInspSet;
        private System.Windows.Forms.Panel pnlInspSettab;
        private System.Windows.Forms.TabControl tabInspSet;
        private System.Windows.Forms.TabPage tbpBOMGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtMaxBatchQty;
        private System.Windows.Forms.Label lblMaxQty;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspType;
        private System.Windows.Forms.Label lblInspType;
        private System.Windows.Forms.CheckBox chkInactive;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAppUserID;
        private System.Windows.Forms.CheckBox chkAppRequireFlag;
        private System.Windows.Forms.Label lblAppUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TabPage tbpBOMGroup;
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
        private System.Windows.Forms.TabPage tbpBOMCMF;
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
        private System.Windows.Forms.Label lblCMF3;
        private System.Windows.Forms.Label lblCMF2;
        private System.Windows.Forms.Label lblCMF1;
        private System.Windows.Forms.Label lblCMF10;
        private System.Windows.Forms.Label lblCMF9;
        private System.Windows.Forms.Label lblCMF8;
        private System.Windows.Forms.Label lblCMF7;
        private System.Windows.Forms.Label lblCMF6;
        private System.Windows.Forms.Label lblCMF5;
        private System.Windows.Forms.Label lblCMF4;
        private System.Windows.Forms.TabPage tbpInspVersion;
        private System.Windows.Forms.Panel pnlInspSetVersion2;
        private System.Windows.Forms.Panel pnlInspSetVerTab;
        private System.Windows.Forms.TabControl tabVersion;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Panel pnlUpdateInfo;
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
        private System.Windows.Forms.Label lblToVersion;
        private System.Windows.Forms.TextBox txtToVersion;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Panel pnlInspSetVerBtn;
        private System.Windows.Forms.GroupBox grpInspSetVerBtn;
        public System.Windows.Forms.Button btnVerCreate;
        public System.Windows.Forms.Button btnVerDelete;
        public System.Windows.Forms.Button btnVerUpdate;
        private System.Windows.Forms.Panel pnlInspSetVersion;
        private System.Windows.Forms.GroupBox grpInspSetVersion;
        private System.Windows.Forms.TextBox txtInspSetVersion;
        private System.Windows.Forms.Label lblInspSetVersion;
        private Miracom.UI.Controls.MCListView.MCListView lisInspSetVersion;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspMethod;
        private System.Windows.Forms.Label lblInspMethod;
        private System.Windows.Forms.CheckBox chkQtyCheck;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisInspSet = new Miracom.UI.Controls.MCListView.MCListView();
            this.colInspSet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInspSetDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpLabel = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtInspSet = new System.Windows.Forms.TextBox();
            this.lblInspSet = new System.Windows.Forms.Label();
            this.txtInspSetVerUpdateTime = new System.Windows.Forms.TextBox();
            this.lblInspSetVerUpdateTime = new System.Windows.Forms.Label();
            this.txtInspSetVerUpdateUser = new System.Windows.Forms.TextBox();
            this.lblInspSetVerUpdateUser = new System.Windows.Forms.Label();
            this.txtInspSetVerCreateTime = new System.Windows.Forms.TextBox();
            this.lblInspSetVerCreateTime = new System.Windows.Forms.Label();
            this.txtInspSetVerCreateUser = new System.Windows.Forms.TextBox();
            this.lblInspSetVerCreateUser = new System.Windows.Forms.Label();
            this.pnlInspSettab = new System.Windows.Forms.Panel();
            this.tabInspSet = new System.Windows.Forms.TabControl();
            this.tbpBOMGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cdvInspMethod = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInspMethod = new System.Windows.Forms.Label();
            this.chkQtyCheck = new System.Windows.Forms.CheckBox();
            this.txtMaxBatchQty = new System.Windows.Forms.TextBox();
            this.lblMaxQty = new System.Windows.Forms.Label();
            this.cdvInspType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInspType = new System.Windows.Forms.Label();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.cdvAppUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkAppRequireFlag = new System.Windows.Forms.CheckBox();
            this.lblAppUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.tbpBOMGroup = new System.Windows.Forms.TabPage();
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
            this.tbpBOMCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
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
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.tbpInspVersion = new System.Windows.Forms.TabPage();
            this.pnlInspSetVersion2 = new System.Windows.Forms.Panel();
            this.pnlInspSetVerTab = new System.Windows.Forms.Panel();
            this.tabVersion = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlUpdateInfo = new System.Windows.Forms.Panel();
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
            this.lblToVersion = new System.Windows.Forms.Label();
            this.txtToVersion = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.pnlInspSetVerBtn = new System.Windows.Forms.Panel();
            this.grpInspSetVerBtn = new System.Windows.Forms.GroupBox();
            this.btnVerCreate = new System.Windows.Forms.Button();
            this.btnVerDelete = new System.Windows.Forms.Button();
            this.btnVerUpdate = new System.Windows.Forms.Button();
            this.pnlInspSetVersion = new System.Windows.Forms.Panel();
            this.grpInspSetVersion = new System.Windows.Forms.GroupBox();
            this.txtInspSetVersion = new System.Windows.Forms.TextBox();
            this.lblInspSetVersion = new System.Windows.Forms.Label();
            this.lisInspSetVersion = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpLabel.SuspendLayout();
            this.pnlInspSettab.SuspendLayout();
            this.tabInspSet.SuspendLayout();
            this.tbpBOMGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAppUserID)).BeginInit();
            this.tbpBOMGroup.SuspendLayout();
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
            this.tbpBOMCMF.SuspendLayout();
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
            this.tbpInspVersion.SuspendLayout();
            this.pnlInspSetVersion2.SuspendLayout();
            this.pnlInspSetVerTab.SuspendLayout();
            this.tabVersion.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpApplyTime.SuspendLayout();
            this.tbpAppNRel.SuspendLayout();
            this.pnlReleaseInfo.SuspendLayout();
            this.grpRelease.SuspendLayout();
            this.grpApproval.SuspendLayout();
            this.tbpCopy.SuspendLayout();
            this.grpCopyTable.SuspendLayout();
            this.pnlInspSetVerBtn.SuspendLayout();
            this.grpInspSetVerBtn.SuspendLayout();
            this.pnlInspSetVersion.SuspendLayout();
            this.grpInspSetVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
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
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlInspSettab);
            this.pnlRight.Controls.Add(this.grpLabel);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisInspSet);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Inspection Set Setup";
            // 
            // lisInspSet
            // 
            this.lisInspSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInspSet,
            this.colInspSetDesc});
            this.lisInspSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisInspSet.EnableSort = true;
            this.lisInspSet.EnableSortIcon = true;
            this.lisInspSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisInspSet.FullRowSelect = true;
            this.lisInspSet.Location = new System.Drawing.Point(3, 3);
            this.lisInspSet.MultiSelect = false;
            this.lisInspSet.Name = "lisInspSet";
            this.lisInspSet.Size = new System.Drawing.Size(229, 500);
            this.lisInspSet.TabIndex = 0;
            this.lisInspSet.UseCompatibleStateImageBehavior = false;
            this.lisInspSet.View = System.Windows.Forms.View.Details;
            this.lisInspSet.SelectedIndexChanged += new System.EventHandler(this.lisInspSet_SelectedIndexChanged);
            // 
            // colInspSet
            // 
            this.colInspSet.Text = "Inspection Set";
            this.colInspSet.Width = 100;
            // 
            // colInspSetDesc
            // 
            this.colInspSetDesc.Text = "Description";
            this.colInspSetDesc.Width = 300;
            // 
            // grpLabel
            // 
            this.grpLabel.Controls.Add(this.txtDesc);
            this.grpLabel.Controls.Add(this.Label6);
            this.grpLabel.Controls.Add(this.txtInspSet);
            this.grpLabel.Controls.Add(this.lblInspSet);
            this.grpLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLabel.Location = new System.Drawing.Point(3, 0);
            this.grpLabel.Name = "grpLabel";
            this.grpLabel.Size = new System.Drawing.Size(500, 71);
            this.grpLabel.TabIndex = 0;
            this.grpLabel.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(131, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(356, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // Label6
            // 
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(16, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(116, 14);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Description";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInspSet
            // 
            this.txtInspSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInspSet.Location = new System.Drawing.Point(131, 16);
            this.txtInspSet.MaxLength = 25;
            this.txtInspSet.Name = "txtInspSet";
            this.txtInspSet.Size = new System.Drawing.Size(177, 20);
            this.txtInspSet.TabIndex = 1;
            this.txtInspSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInspSet_KeyPress);
            // 
            // lblInspSet
            // 
            this.lblInspSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspSet.Location = new System.Drawing.Point(15, 19);
            this.lblInspSet.Name = "lblInspSet";
            this.lblInspSet.Size = new System.Drawing.Size(115, 14);
            this.lblInspSet.TabIndex = 0;
            this.lblInspSet.Text = "Inspection Set";
            this.lblInspSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInspSetVerUpdateTime
            // 
            this.txtInspSetVerUpdateTime.Location = new System.Drawing.Point(104, 88);
            this.txtInspSetVerUpdateTime.MaxLength = 20;
            this.txtInspSetVerUpdateTime.Name = "txtInspSetVerUpdateTime";
            this.txtInspSetVerUpdateTime.ReadOnly = true;
            this.txtInspSetVerUpdateTime.Size = new System.Drawing.Size(168, 20);
            this.txtInspSetVerUpdateTime.TabIndex = 7;
            this.txtInspSetVerUpdateTime.TabStop = false;
            // 
            // lblInspSetVerUpdateTime
            // 
            this.lblInspSetVerUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspSetVerUpdateTime.Location = new System.Drawing.Point(8, 91);
            this.lblInspSetVerUpdateTime.Name = "lblInspSetVerUpdateTime";
            this.lblInspSetVerUpdateTime.Size = new System.Drawing.Size(92, 14);
            this.lblInspSetVerUpdateTime.TabIndex = 6;
            this.lblInspSetVerUpdateTime.Text = "Update Time";
            this.lblInspSetVerUpdateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInspSetVerUpdateUser
            // 
            this.txtInspSetVerUpdateUser.Location = new System.Drawing.Point(104, 64);
            this.txtInspSetVerUpdateUser.MaxLength = 20;
            this.txtInspSetVerUpdateUser.Name = "txtInspSetVerUpdateUser";
            this.txtInspSetVerUpdateUser.ReadOnly = true;
            this.txtInspSetVerUpdateUser.Size = new System.Drawing.Size(168, 20);
            this.txtInspSetVerUpdateUser.TabIndex = 5;
            this.txtInspSetVerUpdateUser.TabStop = false;
            // 
            // lblInspSetVerUpdateUser
            // 
            this.lblInspSetVerUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspSetVerUpdateUser.Location = new System.Drawing.Point(8, 67);
            this.lblInspSetVerUpdateUser.Name = "lblInspSetVerUpdateUser";
            this.lblInspSetVerUpdateUser.Size = new System.Drawing.Size(92, 14);
            this.lblInspSetVerUpdateUser.TabIndex = 4;
            this.lblInspSetVerUpdateUser.Text = "Update User";
            this.lblInspSetVerUpdateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInspSetVerCreateTime
            // 
            this.txtInspSetVerCreateTime.Location = new System.Drawing.Point(104, 40);
            this.txtInspSetVerCreateTime.MaxLength = 20;
            this.txtInspSetVerCreateTime.Name = "txtInspSetVerCreateTime";
            this.txtInspSetVerCreateTime.ReadOnly = true;
            this.txtInspSetVerCreateTime.Size = new System.Drawing.Size(168, 20);
            this.txtInspSetVerCreateTime.TabIndex = 3;
            this.txtInspSetVerCreateTime.TabStop = false;
            // 
            // lblInspSetVerCreateTime
            // 
            this.lblInspSetVerCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspSetVerCreateTime.Location = new System.Drawing.Point(8, 43);
            this.lblInspSetVerCreateTime.Name = "lblInspSetVerCreateTime";
            this.lblInspSetVerCreateTime.Size = new System.Drawing.Size(92, 14);
            this.lblInspSetVerCreateTime.TabIndex = 2;
            this.lblInspSetVerCreateTime.Text = "Create Time";
            this.lblInspSetVerCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInspSetVerCreateUser
            // 
            this.txtInspSetVerCreateUser.Location = new System.Drawing.Point(104, 16);
            this.txtInspSetVerCreateUser.MaxLength = 20;
            this.txtInspSetVerCreateUser.Name = "txtInspSetVerCreateUser";
            this.txtInspSetVerCreateUser.ReadOnly = true;
            this.txtInspSetVerCreateUser.Size = new System.Drawing.Size(168, 20);
            this.txtInspSetVerCreateUser.TabIndex = 1;
            this.txtInspSetVerCreateUser.TabStop = false;
            // 
            // lblInspSetVerCreateUser
            // 
            this.lblInspSetVerCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspSetVerCreateUser.Location = new System.Drawing.Point(8, 19);
            this.lblInspSetVerCreateUser.Name = "lblInspSetVerCreateUser";
            this.lblInspSetVerCreateUser.Size = new System.Drawing.Size(92, 14);
            this.lblInspSetVerCreateUser.TabIndex = 0;
            this.lblInspSetVerCreateUser.Text = "Create User";
            this.lblInspSetVerCreateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInspSettab
            // 
            this.pnlInspSettab.Controls.Add(this.tabInspSet);
            this.pnlInspSettab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspSettab.Location = new System.Drawing.Point(3, 71);
            this.pnlInspSettab.Name = "pnlInspSettab";
            this.pnlInspSettab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlInspSettab.Size = new System.Drawing.Size(500, 432);
            this.pnlInspSettab.TabIndex = 1;
            // 
            // tabInspSet
            // 
            this.tabInspSet.Controls.Add(this.tbpBOMGeneral);
            this.tabInspSet.Controls.Add(this.tbpBOMGroup);
            this.tabInspSet.Controls.Add(this.tbpBOMCMF);
            this.tabInspSet.Controls.Add(this.tbpInspVersion);
            this.tabInspSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInspSet.ItemSize = new System.Drawing.Size(60, 18);
            this.tabInspSet.Location = new System.Drawing.Point(0, 5);
            this.tabInspSet.Name = "tabInspSet";
            this.tabInspSet.SelectedIndex = 0;
            this.tabInspSet.Size = new System.Drawing.Size(500, 427);
            this.tabInspSet.TabIndex = 0;
            this.tabInspSet.SelectedIndexChanged += new System.EventHandler(this.tabInspSet_SelectedIndexChanged);
            // 
            // tbpBOMGeneral
            // 
            this.tbpBOMGeneral.Controls.Add(this.grpGeneral);
            this.tbpBOMGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpBOMGeneral.Name = "tbpBOMGeneral";
            this.tbpBOMGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpBOMGeneral.Size = new System.Drawing.Size(492, 401);
            this.tbpBOMGeneral.TabIndex = 0;
            this.tbpBOMGeneral.Text = "General";
            // 
            // grpGeneral
            // 
            this.grpGeneral.AutoSize = true;
            this.grpGeneral.Controls.Add(this.cdvInspMethod);
            this.grpGeneral.Controls.Add(this.lblInspMethod);
            this.grpGeneral.Controls.Add(this.chkQtyCheck);
            this.grpGeneral.Controls.Add(this.txtMaxBatchQty);
            this.grpGeneral.Controls.Add(this.lblMaxQty);
            this.grpGeneral.Controls.Add(this.cdvInspType);
            this.grpGeneral.Controls.Add(this.lblInspType);
            this.grpGeneral.Controls.Add(this.chkInactive);
            this.grpGeneral.Controls.Add(this.cdvAppUserID);
            this.grpGeneral.Controls.Add(this.chkAppRequireFlag);
            this.grpGeneral.Controls.Add(this.lblAppUser);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.txtCreateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.lblUpdate);
            this.grpGeneral.Controls.Add(this.txtCreateUser);
            this.grpGeneral.Controls.Add(this.lblCreate);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(486, 398);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // cdvInspMethod
            // 
            this.cdvInspMethod.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspMethod.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspMethod.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspMethod.BtnToolTipText = "";
            this.cdvInspMethod.DescText = "";
            this.cdvInspMethod.DisplaySubItemIndex = -1;
            this.cdvInspMethod.DisplayText = "";
            this.cdvInspMethod.Focusing = null;
            this.cdvInspMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspMethod.Index = 0;
            this.cdvInspMethod.IsViewBtnImage = false;
            this.cdvInspMethod.Location = new System.Drawing.Point(124, 88);
            this.cdvInspMethod.MaxLength = 10;
            this.cdvInspMethod.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspMethod.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspMethod.Name = "cdvInspMethod";
            this.cdvInspMethod.ReadOnly = false;
            this.cdvInspMethod.SearchSubItemIndex = 0;
            this.cdvInspMethod.SelectedDescIndex = -1;
            this.cdvInspMethod.SelectedSubItemIndex = -1;
            this.cdvInspMethod.SelectionStart = 0;
            this.cdvInspMethod.Size = new System.Drawing.Size(177, 20);
            this.cdvInspMethod.SmallImageList = null;
            this.cdvInspMethod.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspMethod.TabIndex = 6;
            this.cdvInspMethod.TextBoxToolTipText = "";
            this.cdvInspMethod.TextBoxWidth = 177;
            this.cdvInspMethod.VisibleButton = true;
            this.cdvInspMethod.VisibleColumnHeader = false;
            this.cdvInspMethod.VisibleDescription = false;
            this.cdvInspMethod.ButtonPress += new System.EventHandler(this.cdvInspMethod_ButtonPress);
            // 
            // lblInspMethod
            // 
            this.lblInspMethod.AutoSize = true;
            this.lblInspMethod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspMethod.Location = new System.Drawing.Point(15, 90);
            this.lblInspMethod.Name = "lblInspMethod";
            this.lblInspMethod.Size = new System.Drawing.Size(69, 13);
            this.lblInspMethod.TabIndex = 5;
            this.lblInspMethod.Text = "Insp. Method";
            this.lblInspMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkQtyCheck
            // 
            this.chkQtyCheck.AutoSize = true;
            this.chkQtyCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkQtyCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkQtyCheck.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkQtyCheck.Location = new System.Drawing.Point(15, 113);
            this.chkQtyCheck.Name = "chkQtyCheck";
            this.chkQtyCheck.Size = new System.Drawing.Size(82, 18);
            this.chkQtyCheck.TabIndex = 7;
            this.chkQtyCheck.Text = "Check Qty";
            // 
            // txtMaxBatchQty
            // 
            this.txtMaxBatchQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxBatchQty.Location = new System.Drawing.Point(124, 64);
            this.txtMaxBatchQty.MaxLength = 11;
            this.txtMaxBatchQty.Name = "txtMaxBatchQty";
            this.txtMaxBatchQty.Size = new System.Drawing.Size(177, 20);
            this.txtMaxBatchQty.TabIndex = 4;
            this.txtMaxBatchQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMaxQty
            // 
            this.lblMaxQty.AutoSize = true;
            this.lblMaxQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxQty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMaxQty.Location = new System.Drawing.Point(15, 68);
            this.lblMaxQty.Name = "lblMaxQty";
            this.lblMaxQty.Size = new System.Drawing.Size(90, 13);
            this.lblMaxQty.TabIndex = 3;
            this.lblMaxQty.Text = "Max Batch Qty";
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
            this.cdvInspType.Location = new System.Drawing.Point(124, 40);
            this.cdvInspType.MaxLength = 20;
            this.cdvInspType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspType.Name = "cdvInspType";
            this.cdvInspType.ReadOnly = false;
            this.cdvInspType.SearchSubItemIndex = 0;
            this.cdvInspType.SelectedDescIndex = -1;
            this.cdvInspType.SelectedSubItemIndex = -1;
            this.cdvInspType.SelectionStart = 0;
            this.cdvInspType.Size = new System.Drawing.Size(177, 20);
            this.cdvInspType.SmallImageList = null;
            this.cdvInspType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspType.TabIndex = 2;
            this.cdvInspType.TextBoxToolTipText = "";
            this.cdvInspType.TextBoxWidth = 177;
            this.cdvInspType.VisibleButton = true;
            this.cdvInspType.VisibleColumnHeader = false;
            this.cdvInspType.VisibleDescription = false;
            this.cdvInspType.ButtonPress += new System.EventHandler(this.cdvInspType_ButtonPress);
            // 
            // lblInspType
            // 
            this.lblInspType.AutoSize = true;
            this.lblInspType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspType.Location = new System.Drawing.Point(15, 42);
            this.lblInspType.Name = "lblInspType";
            this.lblInspType.Size = new System.Drawing.Size(67, 13);
            this.lblInspType.TabIndex = 1;
            this.lblInspType.Text = "Insp. Type";
            this.lblInspType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkInactive
            // 
            this.chkInactive.AutoSize = true;
            this.chkInactive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInactive.Location = new System.Drawing.Point(15, 20);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.Size = new System.Drawing.Size(70, 18);
            this.chkInactive.TabIndex = 0;
            this.chkInactive.Text = "Inactive";
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
            this.cdvAppUserID.Location = new System.Drawing.Point(124, 155);
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
            this.cdvAppUserID.TabIndex = 10;
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
            this.chkAppRequireFlag.Location = new System.Drawing.Point(15, 135);
            this.chkAppRequireFlag.Name = "chkAppRequireFlag";
            this.chkAppRequireFlag.Size = new System.Drawing.Size(137, 18);
            this.chkAppRequireFlag.TabIndex = 8;
            this.chkAppRequireFlag.Text = "Approval Require Flag";
            // 
            // lblAppUser
            // 
            this.lblAppUser.AutoSize = true;
            this.lblAppUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAppUser.Location = new System.Drawing.Point(15, 157);
            this.lblAppUser.Name = "lblAppUser";
            this.lblAppUser.Size = new System.Drawing.Size(74, 13);
            this.lblAppUser.TabIndex = 9;
            this.lblAppUser.Text = "Approval User";
            this.lblAppUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateTime.Location = new System.Drawing.Point(306, 372);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 16;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreateTime.Location = new System.Drawing.Point(306, 348);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 13;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateUser.Location = new System.Drawing.Point(124, 372);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 15;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.Location = new System.Drawing.Point(14, 376);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 14;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreateUser.Location = new System.Drawing.Point(124, 348);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 12;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreate.Location = new System.Drawing.Point(14, 352);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 11;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpBOMGroup
            // 
            this.tbpBOMGroup.Controls.Add(this.grpGroup);
            this.tbpBOMGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpBOMGroup.Name = "tbpBOMGroup";
            this.tbpBOMGroup.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpBOMGroup.Size = new System.Drawing.Size(492, 401);
            this.tbpBOMGroup.TabIndex = 1;
            this.tbpBOMGroup.Text = "Group Setup";
            this.tbpBOMGroup.Visible = false;
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
            this.grpGroup.Size = new System.Drawing.Size(486, 398);
            this.grpGroup.TabIndex = 1;
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
            this.cdvGroup10.TabIndex = 19;
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
            this.cdvGroup9.TabIndex = 17;
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
            this.cdvGroup8.TabIndex = 15;
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
            this.cdvGroup7.TabIndex = 13;
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
            this.cdvGroup6.TabIndex = 11;
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
            this.cdvGroup5.TabIndex = 9;
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
            this.cdvGroup4.TabIndex = 7;
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
            this.cdvGroup3.TabIndex = 5;
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
            this.cdvGroup2.TabIndex = 3;
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
            this.cdvGroup1.TabIndex = 1;
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
            // tbpBOMCMF
            // 
            this.tbpBOMCMF.Controls.Add(this.grpCMF);
            this.tbpBOMCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpBOMCMF.Name = "tbpBOMCMF";
            this.tbpBOMCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpBOMCMF.Size = new System.Drawing.Size(492, 401);
            this.tbpBOMCMF.TabIndex = 2;
            this.tbpBOMCMF.Text = "Customized Field";
            this.tbpBOMCMF.Visible = false;
            // 
            // grpCMF
            // 
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
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
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
            this.grpCMF.Size = new System.Drawing.Size(486, 398);
            this.grpCMF.TabIndex = 1;
            this.grpCMF.TabStop = false;
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
            this.cdvCMF5.TabIndex = 24;
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
            this.cdvCMF10.TabIndex = 29;
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
            this.cdvCMF9.TabIndex = 28;
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
            this.cdvCMF8.TabIndex = 27;
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
            this.cdvCMF7.TabIndex = 26;
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
            this.cdvCMF6.TabIndex = 25;
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
            this.cdvCMF4.TabIndex = 23;
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
            this.cdvCMF3.TabIndex = 22;
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
            this.cdvCMF2.TabIndex = 21;
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
            this.cdvCMF1.TabIndex = 20;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 200;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGroupCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            // tbpInspVersion
            // 
            this.tbpInspVersion.Controls.Add(this.pnlInspSetVersion2);
            this.tbpInspVersion.Controls.Add(this.pnlInspSetVersion);
            this.tbpInspVersion.Controls.Add(this.lisInspSetVersion);
            this.tbpInspVersion.Location = new System.Drawing.Point(4, 22);
            this.tbpInspVersion.Name = "tbpInspVersion";
            this.tbpInspVersion.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInspVersion.Size = new System.Drawing.Size(492, 401);
            this.tbpInspVersion.TabIndex = 3;
            this.tbpInspVersion.Text = "Version Setup";
            this.tbpInspVersion.Visible = false;
            // 
            // pnlInspSetVersion2
            // 
            this.pnlInspSetVersion2.Controls.Add(this.pnlInspSetVerTab);
            this.pnlInspSetVersion2.Controls.Add(this.pnlInspSetVerBtn);
            this.pnlInspSetVersion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspSetVersion2.Location = new System.Drawing.Point(120, 50);
            this.pnlInspSetVersion2.Name = "pnlInspSetVersion2";
            this.pnlInspSetVersion2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlInspSetVersion2.Size = new System.Drawing.Size(369, 348);
            this.pnlInspSetVersion2.TabIndex = 2;
            // 
            // pnlInspSetVerTab
            // 
            this.pnlInspSetVerTab.Controls.Add(this.tabVersion);
            this.pnlInspSetVerTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspSetVerTab.Location = new System.Drawing.Point(0, 5);
            this.pnlInspSetVerTab.Name = "pnlInspSetVerTab";
            this.pnlInspSetVerTab.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlInspSetVerTab.Size = new System.Drawing.Size(369, 297);
            this.pnlInspSetVerTab.TabIndex = 2;
            // 
            // tabVersion
            // 
            this.tabVersion.Controls.Add(this.tbpGeneral);
            this.tabVersion.Controls.Add(this.tbpAppNRel);
            this.tabVersion.Controls.Add(this.tbpCopy);
            this.tabVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVersion.ItemSize = new System.Drawing.Size(60, 18);
            this.tabVersion.Location = new System.Drawing.Point(3, 0);
            this.tabVersion.Name = "tabVersion";
            this.tabVersion.SelectedIndex = 0;
            this.tabVersion.Size = new System.Drawing.Size(366, 297);
            this.tabVersion.TabIndex = 1;
            this.tabVersion.SelectedIndexChanged += new System.EventHandler(this.tabVersion_SelectedIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlUpdateInfo);
            this.tbpGeneral.Controls.Add(this.grpApplyTime);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.tbpGeneral.Size = new System.Drawing.Size(358, 271);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlUpdateInfo
            // 
            this.pnlUpdateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpdateInfo.Location = new System.Drawing.Point(3, 76);
            this.pnlUpdateInfo.Name = "pnlUpdateInfo";
            this.pnlUpdateInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlUpdateInfo.Size = new System.Drawing.Size(352, 195);
            this.pnlUpdateInfo.TabIndex = 1;
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
            this.grpApplyTime.Size = new System.Drawing.Size(352, 71);
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
            this.chkEnd.TabIndex = 4;
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
            this.lblFromTo.AutoSize = true;
            this.lblFromTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromTo.Location = new System.Drawing.Point(227, 22);
            this.lblFromTo.Name = "lblFromTo";
            this.lblFromTo.Size = new System.Drawing.Size(14, 13);
            this.lblFromTo.TabIndex = 3;
            this.lblFromTo.Text = "~";
            this.lblFromTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(146, 40);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(76, 20);
            this.dtpEndTime.TabIndex = 6;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(56, 40);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(88, 20);
            this.dtpEndDate.TabIndex = 5;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(146, 16);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(76, 20);
            this.dtpStartTime.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(56, 16);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(88, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // tbpAppNRel
            // 
            this.tbpAppNRel.Controls.Add(this.pnlReleaseInfo);
            this.tbpAppNRel.Controls.Add(this.grpApproval);
            this.tbpAppNRel.Location = new System.Drawing.Point(4, 22);
            this.tbpAppNRel.Name = "tbpAppNRel";
            this.tbpAppNRel.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.tbpAppNRel.Size = new System.Drawing.Size(358, 271);
            this.tbpAppNRel.TabIndex = 2;
            this.tbpAppNRel.Text = "Approval and Release";
            this.tbpAppNRel.Visible = false;
            // 
            // pnlReleaseInfo
            // 
            this.pnlReleaseInfo.Controls.Add(this.grpRelease);
            this.pnlReleaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReleaseInfo.Location = new System.Drawing.Point(3, 96);
            this.pnlReleaseInfo.Name = "pnlReleaseInfo";
            this.pnlReleaseInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlReleaseInfo.Size = new System.Drawing.Size(352, 175);
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
            this.grpRelease.Size = new System.Drawing.Size(352, 170);
            this.grpRelease.TabIndex = 2;
            this.grpRelease.TabStop = false;
            this.grpRelease.Text = "Release Information";
            // 
            // chkReleaseFlag
            // 
            this.chkReleaseFlag.AutoSize = true;
            this.chkReleaseFlag.Enabled = false;
            this.chkReleaseFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkReleaseFlag.Location = new System.Drawing.Point(8, 18);
            this.chkReleaseFlag.Name = "chkReleaseFlag";
            this.chkReleaseFlag.Size = new System.Drawing.Size(94, 18);
            this.chkReleaseFlag.TabIndex = 0;
            this.chkReleaseFlag.Text = "Release Flag";
            // 
            // txtReleaseTime
            // 
            this.txtReleaseTime.Location = new System.Drawing.Point(106, 60);
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
            this.lblReleaseTime.Location = new System.Drawing.Point(10, 63);
            this.lblReleaseTime.Name = "lblReleaseTime";
            this.lblReleaseTime.Size = new System.Drawing.Size(72, 13);
            this.lblReleaseTime.TabIndex = 3;
            this.lblReleaseTime.Text = "Release Time";
            this.lblReleaseTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtReleaseUser
            // 
            this.txtReleaseUser.Location = new System.Drawing.Point(106, 36);
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
            this.lblReleaseUser.Location = new System.Drawing.Point(10, 39);
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
            this.grpApproval.Size = new System.Drawing.Size(352, 91);
            this.grpApproval.TabIndex = 0;
            this.grpApproval.TabStop = false;
            this.grpApproval.Text = "Approval Information";
            // 
            // chkApprovalFlag
            // 
            this.chkApprovalFlag.AutoSize = true;
            this.chkApprovalFlag.Enabled = false;
            this.chkApprovalFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkApprovalFlag.Location = new System.Drawing.Point(8, 18);
            this.chkApprovalFlag.Name = "chkApprovalFlag";
            this.chkApprovalFlag.Size = new System.Drawing.Size(97, 18);
            this.chkApprovalFlag.TabIndex = 0;
            this.chkApprovalFlag.Text = "Approval Flag";
            // 
            // txtApprovalTime
            // 
            this.txtApprovalTime.Location = new System.Drawing.Point(106, 60);
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
            this.lblApprovalTime.Location = new System.Drawing.Point(10, 64);
            this.lblApprovalTime.Name = "lblApprovalTime";
            this.lblApprovalTime.Size = new System.Drawing.Size(75, 13);
            this.lblApprovalTime.TabIndex = 3;
            this.lblApprovalTime.Text = "Approval Time";
            this.lblApprovalTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtApprovalUser
            // 
            this.txtApprovalUser.Location = new System.Drawing.Point(106, 36);
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
            this.lblApprovalUser.Location = new System.Drawing.Point(10, 40);
            this.lblApprovalUser.Name = "lblApprovalUser";
            this.lblApprovalUser.Size = new System.Drawing.Size(74, 13);
            this.lblApprovalUser.TabIndex = 1;
            this.lblApprovalUser.Text = "Approval User";
            this.lblApprovalUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCopy
            // 
            this.tbpCopy.Controls.Add(this.grpCopyTable);
            this.tbpCopy.Location = new System.Drawing.Point(4, 22);
            this.tbpCopy.Name = "tbpCopy";
            this.tbpCopy.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.tbpCopy.Size = new System.Drawing.Size(358, 271);
            this.tbpCopy.TabIndex = 1;
            this.tbpCopy.Text = "Copy Version";
            this.tbpCopy.Visible = false;
            // 
            // grpCopyTable
            // 
            this.grpCopyTable.Controls.Add(this.lblToVersion);
            this.grpCopyTable.Controls.Add(this.txtToVersion);
            this.grpCopyTable.Controls.Add(this.btnCopy);
            this.grpCopyTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyTable.Location = new System.Drawing.Point(3, 5);
            this.grpCopyTable.Name = "grpCopyTable";
            this.grpCopyTable.Size = new System.Drawing.Size(352, 49);
            this.grpCopyTable.TabIndex = 0;
            this.grpCopyTable.TabStop = false;
            // 
            // lblToVersion
            // 
            this.lblToVersion.AutoSize = true;
            this.lblToVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToVersion.Location = new System.Drawing.Point(6, 19);
            this.lblToVersion.Name = "lblToVersion";
            this.lblToVersion.Size = new System.Drawing.Size(58, 13);
            this.lblToVersion.TabIndex = 0;
            this.lblToVersion.Text = "To Version";
            this.lblToVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToVersion
            // 
            this.txtToVersion.Location = new System.Drawing.Point(80, 16);
            this.txtToVersion.MaxLength = 6;
            this.txtToVersion.Name = "txtToVersion";
            this.txtToVersion.Size = new System.Drawing.Size(123, 20);
            this.txtToVersion.TabIndex = 1;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(208, 15);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(84, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // pnlInspSetVerBtn
            // 
            this.pnlInspSetVerBtn.Controls.Add(this.grpInspSetVerBtn);
            this.pnlInspSetVerBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInspSetVerBtn.Location = new System.Drawing.Point(0, 302);
            this.pnlInspSetVerBtn.Name = "pnlInspSetVerBtn";
            this.pnlInspSetVerBtn.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlInspSetVerBtn.Size = new System.Drawing.Size(369, 46);
            this.pnlInspSetVerBtn.TabIndex = 3;
            // 
            // grpInspSetVerBtn
            // 
            this.grpInspSetVerBtn.Controls.Add(this.btnVerCreate);
            this.grpInspSetVerBtn.Controls.Add(this.btnVerDelete);
            this.grpInspSetVerBtn.Controls.Add(this.btnVerUpdate);
            this.grpInspSetVerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInspSetVerBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInspSetVerBtn.Location = new System.Drawing.Point(3, 0);
            this.grpInspSetVerBtn.Name = "grpInspSetVerBtn";
            this.grpInspSetVerBtn.Size = new System.Drawing.Size(366, 46);
            this.grpInspSetVerBtn.TabIndex = 4;
            this.grpInspSetVerBtn.TabStop = false;
            // 
            // btnVerCreate
            // 
            this.btnVerCreate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVerCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVerCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerCreate.Location = new System.Drawing.Point(87, 14);
            this.btnVerCreate.Name = "btnVerCreate";
            this.btnVerCreate.Size = new System.Drawing.Size(88, 26);
            this.btnVerCreate.TabIndex = 3;
            this.btnVerCreate.Text = "Create";
            this.btnVerCreate.Click += new System.EventHandler(this.btnVerCreate_Click);
            // 
            // btnVerDelete
            // 
            this.btnVerDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVerDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVerDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerDelete.Location = new System.Drawing.Point(271, 14);
            this.btnVerDelete.Name = "btnVerDelete";
            this.btnVerDelete.Size = new System.Drawing.Size(88, 26);
            this.btnVerDelete.TabIndex = 5;
            this.btnVerDelete.Text = "Delete";
            this.btnVerDelete.Click += new System.EventHandler(this.btnVerDelete_Click);
            // 
            // btnVerUpdate
            // 
            this.btnVerUpdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVerUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVerUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerUpdate.Location = new System.Drawing.Point(179, 14);
            this.btnVerUpdate.Name = "btnVerUpdate";
            this.btnVerUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnVerUpdate.TabIndex = 4;
            this.btnVerUpdate.Text = "Update";
            this.btnVerUpdate.Click += new System.EventHandler(this.btnVerUpdate_Click);
            // 
            // pnlInspSetVersion
            // 
            this.pnlInspSetVersion.Controls.Add(this.grpInspSetVersion);
            this.pnlInspSetVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInspSetVersion.Location = new System.Drawing.Point(120, 3);
            this.pnlInspSetVersion.Name = "pnlInspSetVersion";
            this.pnlInspSetVersion.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnlInspSetVersion.Size = new System.Drawing.Size(369, 47);
            this.pnlInspSetVersion.TabIndex = 1;
            // 
            // grpInspSetVersion
            // 
            this.grpInspSetVersion.Controls.Add(this.txtInspSetVersion);
            this.grpInspSetVersion.Controls.Add(this.lblInspSetVersion);
            this.grpInspSetVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInspSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInspSetVersion.Location = new System.Drawing.Point(3, 0);
            this.grpInspSetVersion.Name = "grpInspSetVersion";
            this.grpInspSetVersion.Size = new System.Drawing.Size(366, 47);
            this.grpInspSetVersion.TabIndex = 0;
            this.grpInspSetVersion.TabStop = false;
            // 
            // txtInspSetVersion
            // 
            this.txtInspSetVersion.Location = new System.Drawing.Point(163, 16);
            this.txtInspSetVersion.MaxLength = 6;
            this.txtInspSetVersion.Name = "txtInspSetVersion";
            this.txtInspSetVersion.Size = new System.Drawing.Size(125, 20);
            this.txtInspSetVersion.TabIndex = 1;
            this.txtInspSetVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInspSetVersion_KeyPress);
            // 
            // lblInspSetVersion
            // 
            this.lblInspSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspSetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspSetVersion.Location = new System.Drawing.Point(16, 19);
            this.lblInspSetVersion.Name = "lblInspSetVersion";
            this.lblInspSetVersion.Size = new System.Drawing.Size(144, 14);
            this.lblInspSetVersion.TabIndex = 0;
            this.lblInspSetVersion.Text = "Insp. Set Version";
            this.lblInspSetVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisInspSetVersion
            // 
            this.lisInspSetVersion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader4});
            this.lisInspSetVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisInspSetVersion.EnableSort = true;
            this.lisInspSetVersion.EnableSortIcon = true;
            this.lisInspSetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisInspSetVersion.FullRowSelect = true;
            this.lisInspSetVersion.Location = new System.Drawing.Point(3, 3);
            this.lisInspSetVersion.MultiSelect = false;
            this.lisInspSetVersion.Name = "lisInspSetVersion";
            this.lisInspSetVersion.Size = new System.Drawing.Size(117, 395);
            this.lisInspSetVersion.TabIndex = 0;
            this.lisInspSetVersion.UseCompatibleStateImageBehavior = false;
            this.lisInspSetVersion.View = System.Windows.Forms.View.Details;
            this.lisInspSetVersion.SelectedIndexChanged += new System.EventHandler(this.lisInspSetVersion_SelectedIndexChanged);
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Insp. Set Version";
            this.ColumnHeader4.Width = 94;
            // 
            // frmQCMSetupInspectionSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmQCMSetupInspectionSet";
            this.Tag = "QCM1003";
            this.Text = "Inspection Set Setup";
            this.Activated += new System.EventHandler(this.frmQCMSetupInspectionSet_Activated);
            this.Load += new System.EventHandler(this.frmQCMSetupInspectionSet_Load);
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
            this.grpLabel.ResumeLayout(false);
            this.grpLabel.PerformLayout();
            this.pnlInspSettab.ResumeLayout(false);
            this.tabInspSet.ResumeLayout(false);
            this.tbpBOMGeneral.ResumeLayout(false);
            this.tbpBOMGeneral.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAppUserID)).EndInit();
            this.tbpBOMGroup.ResumeLayout(false);
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
            this.tbpBOMCMF.ResumeLayout(false);
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
            this.tbpInspVersion.ResumeLayout(false);
            this.pnlInspSetVersion2.ResumeLayout(false);
            this.pnlInspSetVerTab.ResumeLayout(false);
            this.tabVersion.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpApplyTime.ResumeLayout(false);
            this.grpApplyTime.PerformLayout();
            this.tbpAppNRel.ResumeLayout(false);
            this.pnlReleaseInfo.ResumeLayout(false);
            this.grpRelease.ResumeLayout(false);
            this.grpRelease.PerformLayout();
            this.grpApproval.ResumeLayout(false);
            this.grpApproval.PerformLayout();
            this.tbpCopy.ResumeLayout(false);
            this.grpCopyTable.ResumeLayout(false);
            this.grpCopyTable.PerformLayout();
            this.pnlInspSetVerBtn.ResumeLayout(false);
            this.grpInspSetVerBtn.ResumeLayout(false);
            this.pnlInspSetVersion.ResumeLayout(false);
            this.grpInspSetVersion.ResumeLayout(false);
            this.grpInspSetVersion.PerformLayout();
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
        //       - Optional ByVal ProcStep As String ("1", "2")
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
                    MPCF.FieldClear(this);
                    MPCF.ClearList(lisInspSetVersion, true);
                }
                else if (ProcStep == '2')
                {
                    txtInspSetVersion.Text = "";
                    chkApprovalFlag.Checked = false;
                    txtApprovalUser.Text = "";
                    txtApprovalTime.Text = "";
                    chkReleaseFlag.Checked = false;
                    txtReleaseUser.Text = "";
                    txtReleaseTime.Text = "";
                    txtInspSetVerCreateUser.Text = "";
                    txtInspSetVerCreateTime.Text = "";
                    txtInspSetVerUpdateUser.Text = "";
                    txtInspSetVerUpdateTime.Text = "";
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
            //bool returnValue;
            
            //int i = 0;
            
            //returnValue = false;
            
            switch (MPCF.Trim(FuncName))
            {
                case "Update_Inspection_Set":
                    
                    if (MPCF.CheckValue(txtInspSet, 1, false,false, "", "", "") == false)
                    {
                        return false;
                    }
                    
                    switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                    {
                        case MPGC.MP_STEP_CREATE:

                            if (MPCF.CheckValue(cdvInspType, 1) == false)
                            {
                                return false;
                            }

                            if (MPCF.CheckValue(txtMaxBatchQty, 2) == false)
                            {
                                return false;
                            }
                            
                            if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                            {
                                return false;
                            }
                            
                            //CMF Validation Check
                            if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                            {
                                return false;
                            }
                            break;
                            
                            
                        case MPGC.MP_STEP_UPDATE:


                            if (MPCF.CheckValue(cdvInspType, 1) == false)
                            {
                                return false;
                            }

                            if (MPCF.CheckValue(txtMaxBatchQty, 2) == false)
                            {
                                return false;
                            }
                            
                            if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                            {
                                return false;
                            }
                            
                            //CMF Validation Check
                            if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                            {
                                return false;
                            }
                            break;
                            
                        case MPGC.MP_STEP_DELETE:
                            
                            break;
                            
                        case MPGC.MP_STEP_UNDELETE:
                            
                            break;
                            
                    }
                    break;
                    
                case "Update_Inspection_Version":

                    if (MPCF.CheckValue(txtInspSet, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtInspSetVersion, 1) == false)
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
                case "Copy_Inspection_Version":

                    if (MPCF.CheckValue(txtInspSet, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtInspSetVersion, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtToVersion, 1) == false)
                    {
                        return false;
                    }
                    break;
                default:
                    
                    MPCF.ShowMsgBox("Invalid Case");
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
            string[] sBOMSetGrpTableName = new string[10];
            
            try
            {
                sBOMSetGrpTableName[0] = MPGC.MP_GCM_INSP_SET_GRP_1;
                sBOMSetGrpTableName[1] = MPGC.MP_GCM_INSP_SET_GRP_2;
                sBOMSetGrpTableName[2] = MPGC.MP_GCM_INSP_SET_GRP_3;
                sBOMSetGrpTableName[3] = MPGC.MP_GCM_INSP_SET_GRP_4;
                sBOMSetGrpTableName[4] = MPGC.MP_GCM_INSP_SET_GRP_5;
                sBOMSetGrpTableName[5] = MPGC.MP_GCM_INSP_SET_GRP_6;
                sBOMSetGrpTableName[6] = MPGC.MP_GCM_INSP_SET_GRP_7;
                sBOMSetGrpTableName[7] = MPGC.MP_GCM_INSP_SET_GRP_8;
                sBOMSetGrpTableName[8] = MPGC.MP_GCM_INSP_SET_GRP_9;
                sBOMSetGrpTableName[9] = MPGC.MP_GCM_INSP_SET_GRP_10;
                
                MPCR.SetGRPItem(MPGC.MP_GRP_INSP_SET, "lblGroup", "cdvGroup", grpGroup, sBOMSetGrpTableName);
                MPCR.SetCMFItem(MPGC.MP_CMF_INSP_SET, "lblCMF", "cdvCMF", grpCMF);
                
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
        private bool View_Inspection_Set()
        {
            TRSNode in_node = new TRSNode("VIEW_INSPECTION_SET_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_SET_OUT");
            
            try
            {
                MPCF.ClearList(lisInspSetVersion, true);
                MPCF.FieldClear(pnlRight, null, null, null, null, null, false);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INSP_SET_ID", lisInspSet.SelectedItems[0].Text);

                if (MPCR.CallService("QCM", "QCM_View_Inspection_Set", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtInspSet.Text = out_node.GetString("INSP_SET_ID");
                txtDesc.Text = out_node.GetString("INSP_SET_DESC");
                chkInactive.Checked = (out_node.GetChar("ACTIVE_FLAG") == 'Y') ? false : true;
                cdvInspType.Text = out_node.GetString("INSP_TYPE");
                cdvInspMethod.Text = out_node.GetString("INSP_METHOD");
                txtMaxBatchQty.Text = MPCF.Trim(out_node.GetDouble("MAX_QTY"));
                chkQtyCheck.Checked = (out_node.GetChar("ITEM_CHECK_FLAG") == 'Y') ? true : false;
                chkAppRequireFlag.Checked = (out_node.GetChar("APPROVAL_REQUIRE_FLAG") == 'Y') ? true : false;
                cdvAppUserID.Text = out_node.GetString("APPROVAL_USER_ID");
                cdvGroup1.Text = out_node.GetString("SET_GRP_1");
                cdvGroup2.Text = out_node.GetString("SET_GRP_2");
                cdvGroup3.Text = out_node.GetString("SET_GRP_3");
                cdvGroup4.Text = out_node.GetString("SET_GRP_4");
                cdvGroup5.Text = out_node.GetString("SET_GRP_5");
                cdvGroup6.Text = out_node.GetString("SET_GRP_6");
                cdvGroup7.Text = out_node.GetString("SET_GRP_7");
                cdvGroup8.Text = out_node.GetString("SET_GRP_8");
                cdvGroup9.Text = out_node.GetString("SET_GRP_9");
                cdvGroup10.Text = out_node.GetString("SET_GRP_10");
                cdvCMF1.Text = out_node.GetString("SET_CMF_1");
                cdvCMF2.Text = out_node.GetString("SET_CMF_2");
                cdvCMF3.Text = out_node.GetString("SET_CMF_3");
                cdvCMF4.Text = out_node.GetString("SET_CMF_4");
                cdvCMF5.Text = out_node.GetString("SET_CMF_5");
                cdvCMF6.Text = out_node.GetString("SET_CMF_6");
                cdvCMF7.Text = out_node.GetString("SET_CMF_7");
                cdvCMF8.Text = out_node.GetString("SET_CMF_8");
                cdvCMF9.Text = out_node.GetString("SET_CMF_9");
                cdvCMF10.Text = out_node.GetString("SET_CMF_10");

                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
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
        // Update_Inspection_Set()
        //       - Create/Update/Delete Inspection Set Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete, "R" - Undelete)
        //
        private bool Update_Inspection_Set(char ProcStep)
        {
            ListViewItem itm;

            TRSNode in_node = new TRSNode("UPDATE_INSPECTION_SET_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("INSP_SET_ID", txtInspSet.Text);
                in_node.AddString("INSP_SET_DESC", txtDesc.Text);

                in_node.AddChar("ACTIVE_FLAG", (chkInactive.Checked ? 'N' : 'Y'));
                in_node.AddString("INSP_TYPE", MPCF.Trim(cdvInspType.Text));
                in_node.AddString("INSP_METHOD", MPCF.Trim(cdvInspMethod.Text));

                if (cdvInspMethod.Text == MPGC.MP_QCM_INSP_METHOD_I)
                {
                    in_node.AddChar("ITEM_CHECK_FLAG", (chkQtyCheck.Checked ? 'Y' : 'N'));
                }

                in_node.AddDouble("MAX_QTY", MPCF.ToDbl(txtMaxBatchQty.Text));

                in_node.AddString("SET_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("SET_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("SET_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("SET_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("SET_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("SET_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("SET_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("SET_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("SET_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("SET_GRP_10", MPCF.Trim(cdvGroup10.Text));

                in_node.AddString("SET_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("SET_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("SET_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("SET_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("SET_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("SET_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("SET_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("SET_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("SET_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("SET_CMF_10", MPCF.Trim(cdvCMF10.Text));

                in_node.AddChar("APPROVAL_REQUIRE_FLAG", (chkAppRequireFlag.Checked ? 'Y' : ' '));
                in_node.AddString("APPROVAL_USER_ID", MPCF.Trim(cdvAppUserID.Text), true);

                if (MPCR.CallService("QCM", "QCM_Update_Inspection_Set", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisInspSet.Items.Add(MPCF.Trim(txtInspSet.Text), MPCF.ToInt( SMALLICON_INDEX.IDX_BOM));
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisInspSet.Sorting = SortOrder.Ascending;
                        lisInspSet.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisInspSet, MPCF.Trim(txtInspSet.Text), false) == true)
                        {
                            lisInspSet.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        if (MPCF.FindListItem(lisInspSet, MPCF.Trim(txtInspSet.Text), false) == true)
                        {
                            lisInspSet.SelectedItems[0].ForeColor = Color.Magenta;
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_UNDELETE)
                    {
                        if (MPCF.FindListItem(lisInspSet, MPCF.Trim(txtInspSet.Text), false) == true)
                        {
                            lisInspSet.SelectedItems[0].ForeColor = Color.Black;
                        }
                    }
                    lblDataCount.Text = lisInspSet.Items.Count.ToString();
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
        // View_Inspection_Set_Version()
        //       - View Inspection Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Inspection_Set_Version()
        {
            TRSNode in_node = new TRSNode("VIEW_INSPECTION_SET_VERSION_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_SET_VERSION_OUT");

            try
            {
                ClearData('2');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INSP_SET_ID", lisInspSet.SelectedItems[0].Text);
                in_node.AddInt("INSP_SET_VERSION", MPCF.ToInt(lisInspSetVersion.SelectedItems[0].Text));

                if (MPCR.CallService("QCM", "QCM_View_Inspection_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtInspSetVersion.Text = MPCF.Trim(out_node.GetInt("INSP_SET_VERSION"));

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
                
                chkApprovalFlag.Checked = (out_node.GetString("VIEW_INSPECTION_SET_VERSION_OUT") == "Y") ? true : false;
                txtApprovalUser.Text = out_node.GetString("APPROVAL_USER_ID");
                txtApprovalTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPROVAL_TIME"));
                chkReleaseFlag.Checked = (out_node.GetString("VIEW_INSPECTION_SET_VERSION_OUT") == "Y") ? true : false;
                txtReleaseUser.Text = out_node.GetString("RELEASE_USER_ID");
                txtReleaseTime.Text = MPCF.MakeDateFormat(out_node.GetString("RELEASE_TIME"));
                txtInspSetVerCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtInspSetVerCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtInspSetVerUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtInspSetVerUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        //
        // Update_Inspection_Version()
        //       - Create/Update/Delete Inspection Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Inspection_Version(char ProcStep)
        {
            ListViewItem itm;
            //int iIndex = 0;
            int idx;
            
            TRSNode in_node = new TRSNode("UPDATE_INSPECTION_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("INSP_SET_ID", lisInspSet.SelectedItems[0].Text);
                in_node.AddInt("INSP_SET_VERSION", MPCF.ToInt(MPCF.Trim(txtInspSetVersion.Text)));

                if (chkStart.Checked == true)
                {
                    in_node.AddString("APPLY_START_TIME", dtpStartDate.Value.ToString("yyyyMMddHHmmss"));
                }
                
                if (chkEnd.Checked == true)
                {
                    in_node.AddString("APPLY_END_TIME", dtpEndDate.Value.ToString("yyyyMMddHHmmss"));
                }

                if (MPCR.CallService("QCM", "QCM_Update_Inspection_Version", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisInspSetVersion.Items.Add(MPCF.Trim(txtInspSetVersion.Text), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
                        itm.Selected = true;
                        lisInspSetVersion.Sorting = SortOrder.Ascending;
                        lisInspSetVersion.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        //Do Nothing
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisInspSetVersion, MPCF.Trim(txtInspSetVersion.Text), false);
                        if (idx != - 1)
                        {
                            lisInspSetVersion.Items[idx].Remove();
                        }
                    }
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
        // Copy_Inspection_Version()
        //       - Copy Inspection Set Version and it's attached Inspection Item
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Copy_Inspection_Version(char ProcStep)
        {
            ListViewItem itm;

            TRSNode in_node = new TRSNode("COPY_INSPECTION_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("INSP_SET_ID", lisInspSet.SelectedItems[0].Text);
                in_node.AddInt("INSP_SET_VERSION", MPCF.ToInt(MPCF.Trim(txtToVersion.Text)));
                in_node.AddInt("FROM_INSP_SET_VERSION", MPCF.ToInt(MPCF.Trim(txtInspSetVersion.Text)));

                if (MPCR.CallService("QCM", "QCM_Copy_Inspection_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_COPY)
                    {
                        itm = lisInspSetVersion.Items.Add(MPCF.Trim(txtToVersion.Text), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
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
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisInspSet;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmQCMSetupInspectionSet_Activated(object sender, System.EventArgs e)
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
                    if (QCMLIST.ViewInspectionSetList(lisInspSet, '1', "", "", null, "") == true)
                    {
                        lblDataCount.Text =  lisInspSet.Items.Count.ToString();
                    }
                    else
                    {
                        return;
                    }
                    if (lisInspSet.Items.Count > 0)
                    {
                        lisInspSet.Items[0].Selected = true;
                    }

                    bLoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmQCMSetupInspectionSet_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(lisInspSet);
                MPCF.InitListView(lisInspSetVersion);
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
                if (tabInspSet.SelectedTab.TabIndex > 2)
                {
                    return;
                }
                if (CheckCondition("Update_Inspection_Set", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Inspection_Set(MPGC.MP_STEP_CREATE) == false)
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
                if (CheckCondition("Update_Inspection_Version", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Inspection_Version(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (QCMLIST.ViewInspectionSetVersionList(lisInspSetVersion, '1', txtInspSet.Text, null, "") == false)
                        {
                            return;
                        }
                        if (lisInspSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisInspSetVersion, txtInspSetVersion.Text, false);
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
                if (tabInspSet.SelectedTab.TabIndex > 2)
                {
                    return;
                }
                if (CheckCondition("Update_Inspection_Set", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Inspection_Set(MPGC.MP_STEP_UPDATE) == false)
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
                if (CheckCondition("Update_Inspection_Version", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Inspection_Version(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (QCMLIST.ViewInspectionSetVersionList(lisInspSetVersion, '1', txtInspSet.Text, null, "") == false)
                        {
                            return;
                        }
                        if (lisInspSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisInspSetVersion, txtInspSetVersion.Text, false);
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
                if (tabInspSet.SelectedTab.TabIndex > 2)
                {
                    return;
                }
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Inspection_Set", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Inspection_Set(MPGC.MP_STEP_DELETE) == false)
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
                if (CheckCondition("Update_Inspection_Version", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Inspection_Version(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    ClearData('2');
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        QCMLIST.ViewInspectionSetVersionList(lisInspSetVersion, '1', txtInspSet.Text, null, "");
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
                if (QCMLIST.ViewInspectionSetList(lisInspSet, '1', "", "", null, "") == true)
                {
                    lblDataCount.Text = lisInspSet.Items.Count.ToString();
                    if (lisInspSet.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisInspSet, txtInspSet.Text, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.ExportToExcel(lisInspSet, this.Text, "");
            
        }
        
        private void lisInspSet_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisInspSet.SelectedIndices.Count > 0)
                {
                    if (View_Inspection_Set() == false)
                    {
                        return;
                    }
                    if (QCMLIST.ViewInspectionSetVersionList(lisInspSetVersion, '1', lisInspSet.SelectedItems[0].Text, null, "") == false)
                    {
                        return;
                    }
                    if (lisInspSetVersion.Items.Count > 0)
                    {
                        lisInspSetVersion.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisInspSetVersion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisInspSetVersion.SelectedIndices.Count > 0)
                {
                    View_Inspection_Set_Version();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtInspSet_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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
        
        private void cdvGroupCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        
        private void txtInspSetVersion_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar == (char)13 | e.KeyChar == (char)8)
                {
                    return;
                }
                else if (e.KeyChar < (char)48 | e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            MPCR.CheckCMFKeyPress(sender, e);
            
        }
        
        private void chkStart_CheckedChanged(System.Object sender, System.EventArgs e)
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
        
        private void chkEnd_CheckedChanged(System.Object sender, System.EventArgs e)
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
        
        private void tabInspSet_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            if (!(tabInspSet.SelectedTab == tbpInspVersion))
            {
                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
            }
            else
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("Copy_Inspection_Version", MPGC.MP_STEP_COPY) == true)
                {
                    if (Copy_Inspection_Version(MPGC.MP_STEP_COPY) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (QCMLIST.ViewInspectionSetVersionList(lisInspSetVersion, '1', txtInspSet.Text, null, "") == false)
                        {
                            return;
                        }
                        if (lisInspSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisInspSetVersion, txtToVersion.Text, false);
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
            
            MPCF.FindListItemNextPartial(lisInspSet, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemPartial(lisInspSet, txtFind.Text, 0, true, false);
            
        }
        
        private void tabVersion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
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
        
        private void cdvInspType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInspType.Init();
            MPCF.InitListView(cdvInspType.GetListView);
            cdvInspType.Columns.Add("Insp. Type", 100, HorizontalAlignment.Left);
            cdvInspType.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvInspType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvInspType.GetListView, '1', MPGC.MP_QCM_INSP_TYPE);
        }
        
        private void cdvInspMethod_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInspMethod.Init();
            MPCF.InitListView(cdvInspMethod.GetListView);
            cdvInspMethod.Columns.Add("Insp. Method", 100, HorizontalAlignment.Left);
            cdvInspMethod.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvInspMethod.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvInspMethod.GetListView, '1', MPGC.MP_QCM_INSP_METHOD);
        }
        
        private void cdvAppUserID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAppUserID.Init();
            MPCF.InitListView(cdvAppUserID.GetListView);
            cdvAppUserID.Columns.Add("UserID", 100, HorizontalAlignment.Left);
            cdvAppUserID.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvAppUserID.SelectedSubItemIndex = 0;
            SECLIST.ViewSECUserList(cdvAppUserID.GetListView, '1', -1, null, "", "");
        }
        
    }
    //#End If
}
