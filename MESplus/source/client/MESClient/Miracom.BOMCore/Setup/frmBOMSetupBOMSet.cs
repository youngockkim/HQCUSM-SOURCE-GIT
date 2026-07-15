
//'#If _BOM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBOMSetupBOMSet.vb
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
//       - View_BOMSet() : View BOM Set Definition
//       - Update_BOMSet() : Create/Update/Delete BOM Set definition
//       - View_BOMSet_Version() : View BOM Set Version
//       - Update_BOMSet_Version() : Create/Update/Delete BOM Set Version
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-21 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.BOMCore
{
    public class frmBOMSetupBOMSet : Miracom.MESCore.SetupForm02
    {
        #region " Windows Form auto generated code "

        public frmBOMSetupBOMSet()
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
        private Miracom.UI.Controls.MCListView.MCListView lisBOMSet;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.CheckBox chkDeleteFlag;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtBOMSet;
        private System.Windows.Forms.Label lblBOMSet;
        private System.Windows.Forms.Panel panRightBottom;
        private System.Windows.Forms.TabControl tabBOMSet;
        private System.Windows.Forms.CheckBox chkAppRequireFlag;
        private System.Windows.Forms.Label lblAppUser;
        private System.Windows.Forms.ComboBox cboMatOrd;
        private System.Windows.Forms.Label lblMatOrd;
        private System.Windows.Forms.TextBox txtDeleteTime;
        private System.Windows.Forms.TextBox txtDeleteUser;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.TextBox txtBOMSetVersion;
        private System.Windows.Forms.Label lblBOMSetVersion;
        private Miracom.UI.Controls.MCListView.MCListView lisBOMSetVersion;
        private System.Windows.Forms.GroupBox grpBOMSetVersion;
        public System.Windows.Forms.Button btnUndelete;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.GroupBox grpBOMSet;
        private System.Windows.Forms.Panel pnlBOMSetVersion2;
        private System.Windows.Forms.Panel pnlBOMSetVersion;
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
        private System.Windows.Forms.Label lblCMF3;
        private System.Windows.Forms.Label lblCMF2;
        private System.Windows.Forms.Label lblCMF1;
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
        private System.Windows.Forms.TabControl tabVersion;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Panel pnlUpdateInfo;
        private System.Windows.Forms.TextBox txtBOMSetVerUpdateTime;
        private System.Windows.Forms.Label lblBOMSetVerUpdateTime;
        private System.Windows.Forms.TextBox txtBOMSetVerUpdateUser;
        private System.Windows.Forms.Label lblBOMSetVerUpdateUser;
        private System.Windows.Forms.TextBox txtBOMSetVerCreateTime;
        private System.Windows.Forms.Label lblBOMSetVerCreateTime;
        private System.Windows.Forms.TextBox txtBOMSetVerCreateUser;
        private System.Windows.Forms.Label lblBOMSetVerCreateUser;
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
        private System.Windows.Forms.GroupBox grpUpdateInfo;
        public System.Windows.Forms.Button btnVerCreate;
        public System.Windows.Forms.Button btnVerDelete;
        public System.Windows.Forms.Button btnVerUpdate;
        private System.Windows.Forms.Panel pnlBOMSetVerTab;
        private System.Windows.Forms.Panel pnlBOMSetVerBtn;
        private System.Windows.Forms.GroupBox grpBOMSetVerBtn;
        private System.Windows.Forms.TabPage tbpBOMGeneral;
        private System.Windows.Forms.TabPage tbpBOMCMF;
        private System.Windows.Forms.TabPage tbpBOMGroup;
        private System.Windows.Forms.TabPage tbpBOMVersion;
        private TabPage tbpBOMCopy;
        private GroupBox groupBox1;
        private Button btnToBomSet;
        private Label lblToBomSet;
        private TextBox txtToBomSet;
        private TextBox txtToBomSetDesc;
        private Label lblToBomSetDesc;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAppUserID;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.lisBOMSet = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpBOMSet = new System.Windows.Forms.GroupBox();
            this.chkDeleteFlag = new System.Windows.Forms.CheckBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtBOMSet = new System.Windows.Forms.TextBox();
            this.lblBOMSet = new System.Windows.Forms.Label();
            this.panRightBottom = new System.Windows.Forms.Panel();
            this.tabBOMSet = new System.Windows.Forms.TabControl();
            this.tbpBOMGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cdvAppUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkAppRequireFlag = new System.Windows.Forms.CheckBox();
            this.lblAppUser = new System.Windows.Forms.Label();
            this.cboMatOrd = new System.Windows.Forms.ComboBox();
            this.lblMatOrd = new System.Windows.Forms.Label();
            this.txtDeleteTime = new System.Windows.Forms.TextBox();
            this.txtDeleteUser = new System.Windows.Forms.TextBox();
            this.lblDelete = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.tbpBOMCMF = new System.Windows.Forms.TabPage();
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
            this.tbpBOMVersion = new System.Windows.Forms.TabPage();
            this.pnlBOMSetVersion2 = new System.Windows.Forms.Panel();
            this.pnlBOMSetVerTab = new System.Windows.Forms.Panel();
            this.tabVersion = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlUpdateInfo = new System.Windows.Forms.Panel();
            this.grpUpdateInfo = new System.Windows.Forms.GroupBox();
            this.txtBOMSetVerUpdateTime = new System.Windows.Forms.TextBox();
            this.lblBOMSetVerUpdateTime = new System.Windows.Forms.Label();
            this.txtBOMSetVerUpdateUser = new System.Windows.Forms.TextBox();
            this.lblBOMSetVerUpdateUser = new System.Windows.Forms.Label();
            this.txtBOMSetVerCreateTime = new System.Windows.Forms.TextBox();
            this.lblBOMSetVerCreateTime = new System.Windows.Forms.Label();
            this.txtBOMSetVerCreateUser = new System.Windows.Forms.TextBox();
            this.lblBOMSetVerCreateUser = new System.Windows.Forms.Label();
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
            this.tbpBOMCopy = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtToBomSetDesc = new System.Windows.Forms.TextBox();
            this.lblToBomSetDesc = new System.Windows.Forms.Label();
            this.btnToBomSet = new System.Windows.Forms.Button();
            this.lblToBomSet = new System.Windows.Forms.Label();
            this.txtToBomSet = new System.Windows.Forms.TextBox();
            this.pnlBOMSetVerBtn = new System.Windows.Forms.Panel();
            this.grpBOMSetVerBtn = new System.Windows.Forms.GroupBox();
            this.btnVerCreate = new System.Windows.Forms.Button();
            this.btnVerDelete = new System.Windows.Forms.Button();
            this.btnVerUpdate = new System.Windows.Forms.Button();
            this.pnlBOMSetVersion = new System.Windows.Forms.Panel();
            this.grpBOMSetVersion = new System.Windows.Forms.GroupBox();
            this.txtBOMSetVersion = new System.Windows.Forms.TextBox();
            this.lblBOMSetVersion = new System.Windows.Forms.Label();
            this.lisBOMSetVersion = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUndelete = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpBOMSet.SuspendLayout();
            this.panRightBottom.SuspendLayout();
            this.tabBOMSet.SuspendLayout();
            this.tbpBOMGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAppUserID)).BeginInit();
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
            this.tbpBOMVersion.SuspendLayout();
            this.pnlBOMSetVersion2.SuspendLayout();
            this.pnlBOMSetVerTab.SuspendLayout();
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
            this.tbpBOMCopy.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlBOMSetVerBtn.SuspendLayout();
            this.grpBOMSetVerBtn.SuspendLayout();
            this.pnlBOMSetVersion.SuspendLayout();
            this.grpBOMSetVersion.SuspendLayout();
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
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 2;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.panRightBottom);
            this.pnlRight.Controls.Add(this.grpBOMSet);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisBOMSet);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(282, 8);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(466, 8);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(374, 8);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnUndelete);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUndelete, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "BOM Set Setup";
            // 
            // lisBOMSet
            // 
            this.lisBOMSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisBOMSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisBOMSet.EnableSort = true;
            this.lisBOMSet.EnableSortIcon = true;
            this.lisBOMSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisBOMSet.FullRowSelect = true;
            this.lisBOMSet.HideSelection = false;
            this.lisBOMSet.Location = new System.Drawing.Point(3, 3);
            this.lisBOMSet.MultiSelect = false;
            this.lisBOMSet.Name = "lisBOMSet";
            this.lisBOMSet.Size = new System.Drawing.Size(229, 507);
            this.lisBOMSet.TabIndex = 0;
            this.lisBOMSet.UseCompatibleStateImageBehavior = false;
            this.lisBOMSet.View = System.Windows.Forms.View.Details;
            this.lisBOMSet.SelectedIndexChanged += new System.EventHandler(this.lisBOMSet_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "BOM Set ID";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // grpBOMSet
            // 
            this.grpBOMSet.Controls.Add(this.chkDeleteFlag);
            this.grpBOMSet.Controls.Add(this.txtDesc);
            this.grpBOMSet.Controls.Add(this.lblDesc);
            this.grpBOMSet.Controls.Add(this.txtBOMSet);
            this.grpBOMSet.Controls.Add(this.lblBOMSet);
            this.grpBOMSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBOMSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBOMSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBOMSet.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpBOMSet.Location = new System.Drawing.Point(3, 0);
            this.grpBOMSet.Name = "grpBOMSet";
            this.grpBOMSet.Size = new System.Drawing.Size(500, 71);
            this.grpBOMSet.TabIndex = 0;
            this.grpBOMSet.TabStop = false;
            // 
            // chkDeleteFlag
            // 
            this.chkDeleteFlag.AutoSize = true;
            this.chkDeleteFlag.Enabled = false;
            this.chkDeleteFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDeleteFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleteFlag.Location = new System.Drawing.Point(402, 19);
            this.chkDeleteFlag.Name = "chkDeleteFlag";
            this.chkDeleteFlag.Size = new System.Drawing.Size(86, 18);
            this.chkDeleteFlag.TabIndex = 1;
            this.chkDeleteFlag.Text = "Delete Flag";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(126, 41);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(365, 20);
            this.txtDesc.TabIndex = 2;
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
            // txtBOMSet
            // 
            this.txtBOMSet.Location = new System.Drawing.Point(127, 16);
            this.txtBOMSet.MaxLength = 25;
            this.txtBOMSet.Name = "txtBOMSet";
            this.txtBOMSet.Size = new System.Drawing.Size(177, 20);
            this.txtBOMSet.TabIndex = 0;
            this.txtBOMSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBOMSet_KeyPress);
            // 
            // lblBOMSet
            // 
            this.lblBOMSet.AutoSize = true;
            this.lblBOMSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMSet.Location = new System.Drawing.Point(15, 19);
            this.lblBOMSet.Name = "lblBOMSet";
            this.lblBOMSet.Size = new System.Drawing.Size(74, 13);
            this.lblBOMSet.TabIndex = 0;
            this.lblBOMSet.Text = "BOM Set ID";
            this.lblBOMSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panRightBottom
            // 
            this.panRightBottom.Controls.Add(this.tabBOMSet);
            this.panRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRightBottom.Location = new System.Drawing.Point(3, 71);
            this.panRightBottom.Name = "panRightBottom";
            this.panRightBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panRightBottom.Size = new System.Drawing.Size(500, 439);
            this.panRightBottom.TabIndex = 1;
            // 
            // tabBOMSet
            // 
            this.tabBOMSet.Controls.Add(this.tbpBOMGeneral);
            this.tabBOMSet.Controls.Add(this.tbpBOMCMF);
            this.tabBOMSet.Controls.Add(this.tbpBOMGroup);
            this.tabBOMSet.Controls.Add(this.tbpBOMVersion);
            this.tabBOMSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabBOMSet.ItemSize = new System.Drawing.Size(60, 18);
            this.tabBOMSet.Location = new System.Drawing.Point(0, 5);
            this.tabBOMSet.Name = "tabBOMSet";
            this.tabBOMSet.SelectedIndex = 0;
            this.tabBOMSet.Size = new System.Drawing.Size(500, 434);
            this.tabBOMSet.TabIndex = 0;
            this.tabBOMSet.SelectedIndexChanged += new System.EventHandler(this.tabBOMSet_SelectedIndexChanged);
            // 
            // tbpBOMGeneral
            // 
            this.tbpBOMGeneral.Controls.Add(this.grpGeneral);
            this.tbpBOMGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpBOMGeneral.Name = "tbpBOMGeneral";
            this.tbpBOMGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpBOMGeneral.Size = new System.Drawing.Size(492, 408);
            this.tbpBOMGeneral.TabIndex = 0;
            this.tbpBOMGeneral.Text = "General";
            // 
            // grpGeneral
            // 
            this.grpGeneral.AutoSize = true;
            this.grpGeneral.Controls.Add(this.cdvAppUserID);
            this.grpGeneral.Controls.Add(this.chkAppRequireFlag);
            this.grpGeneral.Controls.Add(this.lblAppUser);
            this.grpGeneral.Controls.Add(this.cboMatOrd);
            this.grpGeneral.Controls.Add(this.lblMatOrd);
            this.grpGeneral.Controls.Add(this.txtDeleteTime);
            this.grpGeneral.Controls.Add(this.txtDeleteUser);
            this.grpGeneral.Controls.Add(this.lblDelete);
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
            this.grpGeneral.Size = new System.Drawing.Size(486, 405);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
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
            this.cdvAppUserID.Location = new System.Drawing.Point(120, 64);
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
            this.cdvAppUserID.TabIndex = 2;
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
            this.chkAppRequireFlag.Location = new System.Drawing.Point(15, 43);
            this.chkAppRequireFlag.Name = "chkAppRequireFlag";
            this.chkAppRequireFlag.Size = new System.Drawing.Size(137, 18);
            this.chkAppRequireFlag.TabIndex = 1;
            this.chkAppRequireFlag.Text = "Approval Require Flag";
            // 
            // lblAppUser
            // 
            this.lblAppUser.AutoSize = true;
            this.lblAppUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAppUser.Location = new System.Drawing.Point(15, 67);
            this.lblAppUser.Name = "lblAppUser";
            this.lblAppUser.Size = new System.Drawing.Size(74, 13);
            this.lblAppUser.TabIndex = 3;
            this.lblAppUser.Text = "Approval User";
            this.lblAppUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMatOrd
            // 
            this.cboMatOrd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMatOrd.Items.AddRange(new object[] {
            "Material",
            "Order"});
            this.cboMatOrd.Location = new System.Drawing.Point(120, 16);
            this.cboMatOrd.Name = "cboMatOrd";
            this.cboMatOrd.Size = new System.Drawing.Size(176, 21);
            this.cboMatOrd.TabIndex = 0;
            // 
            // lblMatOrd
            // 
            this.lblMatOrd.AutoSize = true;
            this.lblMatOrd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMatOrd.Location = new System.Drawing.Point(15, 19);
            this.lblMatOrd.Name = "lblMatOrd";
            this.lblMatOrd.Size = new System.Drawing.Size(85, 13);
            this.lblMatOrd.TabIndex = 0;
            this.lblMatOrd.Text = "Material or Order";
            this.lblMatOrd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDeleteTime
            // 
            this.txtDeleteTime.Location = new System.Drawing.Point(304, 136);
            this.txtDeleteTime.MaxLength = 30;
            this.txtDeleteTime.Name = "txtDeleteTime";
            this.txtDeleteTime.ReadOnly = true;
            this.txtDeleteTime.Size = new System.Drawing.Size(174, 20);
            this.txtDeleteTime.TabIndex = 8;
            this.txtDeleteTime.TabStop = false;
            // 
            // txtDeleteUser
            // 
            this.txtDeleteUser.Location = new System.Drawing.Point(120, 136);
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
            this.lblDelete.Location = new System.Drawing.Point(15, 139);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(91, 13);
            this.lblDelete.TabIndex = 11;
            this.lblDelete.Text = "Delete User/Time";
            this.lblDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(304, 112);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 6;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(304, 88);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 4;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 112);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 5;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(15, 115);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 8;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 88);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 3;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(15, 91);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 5;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpBOMCMF
            // 
            this.tbpBOMCMF.Controls.Add(this.grpCMF);
            this.tbpBOMCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpBOMCMF.Name = "tbpBOMCMF";
            this.tbpBOMCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpBOMCMF.Size = new System.Drawing.Size(492, 408);
            this.tbpBOMCMF.TabIndex = 2;
            this.tbpBOMCMF.Text = "Customized Field";
            this.tbpBOMCMF.Visible = false;
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
            this.grpCMF.Size = new System.Drawing.Size(486, 405);
            this.grpCMF.TabIndex = 1;
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
            // tbpBOMGroup
            // 
            this.tbpBOMGroup.Controls.Add(this.grpGroup);
            this.tbpBOMGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpBOMGroup.Name = "tbpBOMGroup";
            this.tbpBOMGroup.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpBOMGroup.Size = new System.Drawing.Size(492, 408);
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
            this.grpGroup.Size = new System.Drawing.Size(486, 405);
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
            // tbpBOMVersion
            // 
            this.tbpBOMVersion.Controls.Add(this.pnlBOMSetVersion2);
            this.tbpBOMVersion.Controls.Add(this.pnlBOMSetVersion);
            this.tbpBOMVersion.Controls.Add(this.lisBOMSetVersion);
            this.tbpBOMVersion.Location = new System.Drawing.Point(4, 22);
            this.tbpBOMVersion.Name = "tbpBOMVersion";
            this.tbpBOMVersion.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpBOMVersion.Size = new System.Drawing.Size(492, 408);
            this.tbpBOMVersion.TabIndex = 3;
            this.tbpBOMVersion.Text = "Version Setup";
            this.tbpBOMVersion.Visible = false;
            // 
            // pnlBOMSetVersion2
            // 
            this.pnlBOMSetVersion2.Controls.Add(this.pnlBOMSetVerTab);
            this.pnlBOMSetVersion2.Controls.Add(this.pnlBOMSetVerBtn);
            this.pnlBOMSetVersion2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBOMSetVersion2.Location = new System.Drawing.Point(120, 47);
            this.pnlBOMSetVersion2.Name = "pnlBOMSetVersion2";
            this.pnlBOMSetVersion2.Size = new System.Drawing.Size(369, 358);
            this.pnlBOMSetVersion2.TabIndex = 2;
            // 
            // pnlBOMSetVerTab
            // 
            this.pnlBOMSetVerTab.Controls.Add(this.tabVersion);
            this.pnlBOMSetVerTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBOMSetVerTab.Location = new System.Drawing.Point(0, 0);
            this.pnlBOMSetVerTab.Name = "pnlBOMSetVerTab";
            this.pnlBOMSetVerTab.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlBOMSetVerTab.Size = new System.Drawing.Size(369, 312);
            this.pnlBOMSetVerTab.TabIndex = 2;
            // 
            // tabVersion
            // 
            this.tabVersion.Controls.Add(this.tbpGeneral);
            this.tabVersion.Controls.Add(this.tbpAppNRel);
            this.tabVersion.Controls.Add(this.tbpCopy);
            this.tabVersion.Controls.Add(this.tbpBOMCopy);
            this.tabVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVersion.ItemSize = new System.Drawing.Size(60, 18);
            this.tabVersion.Location = new System.Drawing.Point(3, 0);
            this.tabVersion.Name = "tabVersion";
            this.tabVersion.SelectedIndex = 0;
            this.tabVersion.Size = new System.Drawing.Size(363, 312);
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
            this.tbpGeneral.Size = new System.Drawing.Size(355, 286);
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
            this.pnlUpdateInfo.Size = new System.Drawing.Size(349, 210);
            this.pnlUpdateInfo.TabIndex = 1;
            // 
            // grpUpdateInfo
            // 
            this.grpUpdateInfo.AutoSize = true;
            this.grpUpdateInfo.Controls.Add(this.txtBOMSetVerUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.lblBOMSetVerUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.txtBOMSetVerUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.lblBOMSetVerUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.txtBOMSetVerCreateTime);
            this.grpUpdateInfo.Controls.Add(this.lblBOMSetVerCreateTime);
            this.grpUpdateInfo.Controls.Add(this.txtBOMSetVerCreateUser);
            this.grpUpdateInfo.Controls.Add(this.lblBOMSetVerCreateUser);
            this.grpUpdateInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpUpdateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUpdateInfo.Location = new System.Drawing.Point(0, 5);
            this.grpUpdateInfo.Name = "grpUpdateInfo";
            this.grpUpdateInfo.Size = new System.Drawing.Size(349, 127);
            this.grpUpdateInfo.TabIndex = 2;
            this.grpUpdateInfo.TabStop = false;
            this.grpUpdateInfo.Text = "Update Information";
            // 
            // txtBOMSetVerUpdateTime
            // 
            this.txtBOMSetVerUpdateTime.Location = new System.Drawing.Point(104, 88);
            this.txtBOMSetVerUpdateTime.MaxLength = 30;
            this.txtBOMSetVerUpdateTime.Name = "txtBOMSetVerUpdateTime";
            this.txtBOMSetVerUpdateTime.ReadOnly = true;
            this.txtBOMSetVerUpdateTime.Size = new System.Drawing.Size(168, 20);
            this.txtBOMSetVerUpdateTime.TabIndex = 3;
            this.txtBOMSetVerUpdateTime.TabStop = false;
            // 
            // lblBOMSetVerUpdateTime
            // 
            this.lblBOMSetVerUpdateTime.AutoSize = true;
            this.lblBOMSetVerUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetVerUpdateTime.Location = new System.Drawing.Point(8, 91);
            this.lblBOMSetVerUpdateTime.Name = "lblBOMSetVerUpdateTime";
            this.lblBOMSetVerUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblBOMSetVerUpdateTime.TabIndex = 6;
            this.lblBOMSetVerUpdateTime.Text = "Update Time";
            this.lblBOMSetVerUpdateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBOMSetVerUpdateUser
            // 
            this.txtBOMSetVerUpdateUser.Location = new System.Drawing.Point(104, 64);
            this.txtBOMSetVerUpdateUser.MaxLength = 20;
            this.txtBOMSetVerUpdateUser.Name = "txtBOMSetVerUpdateUser";
            this.txtBOMSetVerUpdateUser.ReadOnly = true;
            this.txtBOMSetVerUpdateUser.Size = new System.Drawing.Size(168, 20);
            this.txtBOMSetVerUpdateUser.TabIndex = 2;
            this.txtBOMSetVerUpdateUser.TabStop = false;
            // 
            // lblBOMSetVerUpdateUser
            // 
            this.lblBOMSetVerUpdateUser.AutoSize = true;
            this.lblBOMSetVerUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetVerUpdateUser.Location = new System.Drawing.Point(8, 67);
            this.lblBOMSetVerUpdateUser.Name = "lblBOMSetVerUpdateUser";
            this.lblBOMSetVerUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblBOMSetVerUpdateUser.TabIndex = 4;
            this.lblBOMSetVerUpdateUser.Text = "Update User";
            this.lblBOMSetVerUpdateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBOMSetVerCreateTime
            // 
            this.txtBOMSetVerCreateTime.Location = new System.Drawing.Point(104, 40);
            this.txtBOMSetVerCreateTime.MaxLength = 30;
            this.txtBOMSetVerCreateTime.Name = "txtBOMSetVerCreateTime";
            this.txtBOMSetVerCreateTime.ReadOnly = true;
            this.txtBOMSetVerCreateTime.Size = new System.Drawing.Size(168, 20);
            this.txtBOMSetVerCreateTime.TabIndex = 1;
            this.txtBOMSetVerCreateTime.TabStop = false;
            // 
            // lblBOMSetVerCreateTime
            // 
            this.lblBOMSetVerCreateTime.AutoSize = true;
            this.lblBOMSetVerCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetVerCreateTime.Location = new System.Drawing.Point(8, 43);
            this.lblBOMSetVerCreateTime.Name = "lblBOMSetVerCreateTime";
            this.lblBOMSetVerCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblBOMSetVerCreateTime.TabIndex = 2;
            this.lblBOMSetVerCreateTime.Text = "Create Time";
            this.lblBOMSetVerCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBOMSetVerCreateUser
            // 
            this.txtBOMSetVerCreateUser.Location = new System.Drawing.Point(104, 16);
            this.txtBOMSetVerCreateUser.MaxLength = 20;
            this.txtBOMSetVerCreateUser.Name = "txtBOMSetVerCreateUser";
            this.txtBOMSetVerCreateUser.ReadOnly = true;
            this.txtBOMSetVerCreateUser.Size = new System.Drawing.Size(168, 20);
            this.txtBOMSetVerCreateUser.TabIndex = 0;
            this.txtBOMSetVerCreateUser.TabStop = false;
            // 
            // lblBOMSetVerCreateUser
            // 
            this.lblBOMSetVerCreateUser.AutoSize = true;
            this.lblBOMSetVerCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetVerCreateUser.Location = new System.Drawing.Point(8, 19);
            this.lblBOMSetVerCreateUser.Name = "lblBOMSetVerCreateUser";
            this.lblBOMSetVerCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblBOMSetVerCreateUser.TabIndex = 0;
            this.lblBOMSetVerCreateUser.Text = "Create User";
            this.lblBOMSetVerCreateUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.grpApplyTime.Size = new System.Drawing.Size(349, 71);
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
            this.chkEnd.TabIndex = 2;
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
            this.lblFromTo.Location = new System.Drawing.Point(242, 22);
            this.lblFromTo.Name = "lblFromTo";
            this.lblFromTo.Size = new System.Drawing.Size(11, 10);
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
            this.dtpEndTime.Size = new System.Drawing.Size(90, 20);
            this.dtpEndTime.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(54, 40);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(90, 20);
            this.dtpEndDate.TabIndex = 5;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(146, 16);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(90, 20);
            this.dtpStartTime.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(54, 16);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(90, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // tbpAppNRel
            // 
            this.tbpAppNRel.Controls.Add(this.pnlReleaseInfo);
            this.tbpAppNRel.Controls.Add(this.grpApproval);
            this.tbpAppNRel.Location = new System.Drawing.Point(4, 22);
            this.tbpAppNRel.Name = "tbpAppNRel";
            this.tbpAppNRel.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.tbpAppNRel.Size = new System.Drawing.Size(355, 286);
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
            this.pnlReleaseInfo.Size = new System.Drawing.Size(349, 190);
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
            this.grpRelease.Size = new System.Drawing.Size(349, 185);
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
            this.txtReleaseTime.MaxLength = 14;
            this.txtReleaseTime.Name = "txtReleaseTime";
            this.txtReleaseTime.ReadOnly = true;
            this.txtReleaseTime.Size = new System.Drawing.Size(168, 20);
            this.txtReleaseTime.TabIndex = 2;
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
            this.txtReleaseUser.TabIndex = 1;
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
            this.grpApproval.Size = new System.Drawing.Size(349, 91);
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
            this.txtApprovalTime.MaxLength = 14;
            this.txtApprovalTime.Name = "txtApprovalTime";
            this.txtApprovalTime.ReadOnly = true;
            this.txtApprovalTime.Size = new System.Drawing.Size(168, 20);
            this.txtApprovalTime.TabIndex = 2;
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
            this.txtApprovalUser.TabIndex = 1;
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
            this.tbpCopy.Size = new System.Drawing.Size(355, 286);
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
            this.grpCopyTable.Location = new System.Drawing.Point(3, 5);
            this.grpCopyTable.Name = "grpCopyTable";
            this.grpCopyTable.Size = new System.Drawing.Size(349, 49);
            this.grpCopyTable.TabIndex = 0;
            this.grpCopyTable.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(208, 15);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(84, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblToVersion
            // 
            this.lblToVersion.AutoSize = true;
            this.lblToVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToVersion.Location = new System.Drawing.Point(8, 19);
            this.lblToVersion.Name = "lblToVersion";
            this.lblToVersion.Size = new System.Drawing.Size(58, 13);
            this.lblToVersion.TabIndex = 0;
            this.lblToVersion.Text = "To Version";
            this.lblToVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToVersion
            // 
            this.txtToVersion.Location = new System.Drawing.Point(83, 16);
            this.txtToVersion.MaxLength = 3;
            this.txtToVersion.Name = "txtToVersion";
            this.txtToVersion.Size = new System.Drawing.Size(123, 20);
            this.txtToVersion.TabIndex = 0;
            // 
            // tbpBOMCopy
            // 
            this.tbpBOMCopy.BackColor = System.Drawing.SystemColors.Control;
            this.tbpBOMCopy.Controls.Add(this.groupBox1);
            this.tbpBOMCopy.Location = new System.Drawing.Point(4, 22);
            this.tbpBOMCopy.Name = "tbpBOMCopy";
            this.tbpBOMCopy.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBOMCopy.Size = new System.Drawing.Size(355, 286);
            this.tbpBOMCopy.TabIndex = 3;
            this.tbpBOMCopy.Text = "Copy BOM Set";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtToBomSetDesc);
            this.groupBox1.Controls.Add(this.lblToBomSetDesc);
            this.groupBox1.Controls.Add(this.btnToBomSet);
            this.groupBox1.Controls.Add(this.lblToBomSet);
            this.groupBox1.Controls.Add(this.txtToBomSet);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 103);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtToBomSetDesc
            // 
            this.txtToBomSetDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToBomSetDesc.Location = new System.Drawing.Point(83, 43);
            this.txtToBomSetDesc.MaxLength = 200;
            this.txtToBomSetDesc.Name = "txtToBomSetDesc";
            this.txtToBomSetDesc.Size = new System.Drawing.Size(260, 20);
            this.txtToBomSetDesc.TabIndex = 1;
            // 
            // lblToBomSetDesc
            // 
            this.lblToBomSetDesc.AutoSize = true;
            this.lblToBomSetDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToBomSetDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToBomSetDesc.Location = new System.Drawing.Point(9, 43);
            this.lblToBomSetDesc.Name = "lblToBomSetDesc";
            this.lblToBomSetDesc.Size = new System.Drawing.Size(60, 13);
            this.lblToBomSetDesc.TabIndex = 4;
            this.lblToBomSetDesc.Text = "Description";
            this.lblToBomSetDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnToBomSet
            // 
            this.btnToBomSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToBomSet.Location = new System.Drawing.Point(259, 71);
            this.btnToBomSet.Name = "btnToBomSet";
            this.btnToBomSet.Size = new System.Drawing.Size(84, 23);
            this.btnToBomSet.TabIndex = 2;
            this.btnToBomSet.Text = "Copy";
            this.btnToBomSet.Click += new System.EventHandler(this.btnToBomSet_Click);
            // 
            // lblToBomSet
            // 
            this.lblToBomSet.AutoSize = true;
            this.lblToBomSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToBomSet.Location = new System.Drawing.Point(8, 19);
            this.lblToBomSet.Name = "lblToBomSet";
            this.lblToBomSet.Size = new System.Drawing.Size(71, 13);
            this.lblToBomSet.TabIndex = 0;
            this.lblToBomSet.Text = "To BomSetID";
            this.lblToBomSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToBomSet
            // 
            this.txtToBomSet.Location = new System.Drawing.Point(83, 16);
            this.txtToBomSet.MaxLength = 25;
            this.txtToBomSet.Name = "txtToBomSet";
            this.txtToBomSet.Size = new System.Drawing.Size(260, 20);
            this.txtToBomSet.TabIndex = 0;
            // 
            // pnlBOMSetVerBtn
            // 
            this.pnlBOMSetVerBtn.Controls.Add(this.grpBOMSetVerBtn);
            this.pnlBOMSetVerBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBOMSetVerBtn.Location = new System.Drawing.Point(0, 312);
            this.pnlBOMSetVerBtn.Name = "pnlBOMSetVerBtn";
            this.pnlBOMSetVerBtn.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlBOMSetVerBtn.Size = new System.Drawing.Size(369, 46);
            this.pnlBOMSetVerBtn.TabIndex = 3;
            // 
            // grpBOMSetVerBtn
            // 
            this.grpBOMSetVerBtn.Controls.Add(this.btnVerCreate);
            this.grpBOMSetVerBtn.Controls.Add(this.btnVerDelete);
            this.grpBOMSetVerBtn.Controls.Add(this.btnVerUpdate);
            this.grpBOMSetVerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBOMSetVerBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBOMSetVerBtn.Location = new System.Drawing.Point(3, 0);
            this.grpBOMSetVerBtn.Name = "grpBOMSetVerBtn";
            this.grpBOMSetVerBtn.Size = new System.Drawing.Size(363, 46);
            this.grpBOMSetVerBtn.TabIndex = 4;
            this.grpBOMSetVerBtn.TabStop = false;
            // 
            // btnVerCreate
            // 
            this.btnVerCreate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVerCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVerCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerCreate.Location = new System.Drawing.Point(82, 13);
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
            this.btnVerDelete.Location = new System.Drawing.Point(266, 13);
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
            this.btnVerUpdate.Location = new System.Drawing.Point(174, 13);
            this.btnVerUpdate.Name = "btnVerUpdate";
            this.btnVerUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnVerUpdate.TabIndex = 1;
            this.btnVerUpdate.Text = "Update";
            this.btnVerUpdate.Click += new System.EventHandler(this.btnVerUpdate_Click);
            // 
            // pnlBOMSetVersion
            // 
            this.pnlBOMSetVersion.Controls.Add(this.grpBOMSetVersion);
            this.pnlBOMSetVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBOMSetVersion.Location = new System.Drawing.Point(120, 0);
            this.pnlBOMSetVersion.Name = "pnlBOMSetVersion";
            this.pnlBOMSetVersion.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlBOMSetVersion.Size = new System.Drawing.Size(369, 47);
            this.pnlBOMSetVersion.TabIndex = 1;
            // 
            // grpBOMSetVersion
            // 
            this.grpBOMSetVersion.Controls.Add(this.txtBOMSetVersion);
            this.grpBOMSetVersion.Controls.Add(this.lblBOMSetVersion);
            this.grpBOMSetVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBOMSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBOMSetVersion.Location = new System.Drawing.Point(3, 0);
            this.grpBOMSetVersion.Name = "grpBOMSetVersion";
            this.grpBOMSetVersion.Size = new System.Drawing.Size(363, 47);
            this.grpBOMSetVersion.TabIndex = 0;
            this.grpBOMSetVersion.TabStop = false;
            // 
            // txtBOMSetVersion
            // 
            this.txtBOMSetVersion.Location = new System.Drawing.Point(163, 16);
            this.txtBOMSetVersion.MaxLength = 3;
            this.txtBOMSetVersion.Name = "txtBOMSetVersion";
            this.txtBOMSetVersion.Size = new System.Drawing.Size(125, 20);
            this.txtBOMSetVersion.TabIndex = 0;
            this.txtBOMSetVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBOMSetVersion_KeyPress);
            // 
            // lblBOMSetVersion
            // 
            this.lblBOMSetVersion.AutoSize = true;
            this.lblBOMSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMSetVersion.Location = new System.Drawing.Point(16, 19);
            this.lblBOMSetVersion.Name = "lblBOMSetVersion";
            this.lblBOMSetVersion.Size = new System.Drawing.Size(103, 13);
            this.lblBOMSetVersion.TabIndex = 0;
            this.lblBOMSetVersion.Text = "BOM Set Version";
            this.lblBOMSetVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisBOMSetVersion
            // 
            this.lisBOMSetVersion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader4});
            this.lisBOMSetVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.lisBOMSetVersion.EnableSort = true;
            this.lisBOMSetVersion.EnableSortIcon = true;
            this.lisBOMSetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisBOMSetVersion.FullRowSelect = true;
            this.lisBOMSetVersion.Location = new System.Drawing.Point(3, 0);
            this.lisBOMSetVersion.MultiSelect = false;
            this.lisBOMSetVersion.Name = "lisBOMSetVersion";
            this.lisBOMSetVersion.Size = new System.Drawing.Size(117, 405);
            this.lisBOMSetVersion.TabIndex = 0;
            this.lisBOMSetVersion.UseCompatibleStateImageBehavior = false;
            this.lisBOMSetVersion.View = System.Windows.Forms.View.Details;
            this.lisBOMSetVersion.SelectedIndexChanged += new System.EventHandler(this.lisBOMSetVersion_SelectedIndexChanged);
            this.lisBOMSetVersion.Click += new System.EventHandler(this.lisBOMSetVersion_Click);
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "BOM Set Version";
            this.ColumnHeader4.Width = 94;
            // 
            // btnUndelete
            // 
            this.btnUndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUndelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUndelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUndelete.Location = new System.Drawing.Point(558, 8);
            this.btnUndelete.Name = "btnUndelete";
            this.btnUndelete.Size = new System.Drawing.Size(88, 26);
            this.btnUndelete.TabIndex = 3;
            this.btnUndelete.Text = "Undelete";
            this.btnUndelete.Click += new System.EventHandler(this.btnUndelete_Click);
            // 
            // frmBOMSetupBOMSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBOMSetupBOMSet";
            this.Text = "BOM Set Setup";
            this.Activated += new System.EventHandler(this.frmBOMSetupBOMSet_Activated);
            this.Load += new System.EventHandler(this.frmBOMSetupBOMSet_Load);
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
            this.grpBOMSet.ResumeLayout(false);
            this.grpBOMSet.PerformLayout();
            this.panRightBottom.ResumeLayout(false);
            this.tabBOMSet.ResumeLayout(false);
            this.tbpBOMGeneral.ResumeLayout(false);
            this.tbpBOMGeneral.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAppUserID)).EndInit();
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
            this.tbpBOMVersion.ResumeLayout(false);
            this.pnlBOMSetVersion2.ResumeLayout(false);
            this.pnlBOMSetVerTab.ResumeLayout(false);
            this.tabVersion.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlUpdateInfo.ResumeLayout(false);
            this.pnlUpdateInfo.PerformLayout();
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
            this.tbpBOMCopy.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlBOMSetVerBtn.ResumeLayout(false);
            this.grpBOMSetVerBtn.ResumeLayout(false);
            this.pnlBOMSetVersion.ResumeLayout(false);
            this.grpBOMSetVersion.ResumeLayout(false);
            this.grpBOMSetVersion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Variable Definition "

        bool b_load_flag;
        private bool bIndexChangeFlag2 = false;
        private bool bIgnoreSelectFlag = false;

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
                    MPCF.ClearList(lisBOMSetVersion, true);
                }
                else if (ProcStep == '2')
                {
                    txtBOMSetVersion.Text = "";
                    chkApprovalFlag.Checked = false;
                    txtApprovalUser.Text = "";
                    txtApprovalTime.Text = "";
                    chkReleaseFlag.Checked = false;
                    txtReleaseUser.Text = "";
                    txtReleaseTime.Text = "";
                    txtBOMSetVerCreateUser.Text = "";
                    txtBOMSetVerCreateTime.Text = "";
                    txtBOMSetVerUpdateUser.Text = "";
                    txtBOMSetVerUpdateTime.Text = "";
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
            switch (MPCF.Trim(FuncName))
            {
                case "Update_BOMSet":

                    if (MPCF.CheckValue(txtBOMSet, 1) == false)
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

                            if (cboMatOrd.SelectedIndex == -1)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                cboMatOrd.Focus();
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

                            if (cboMatOrd.SelectedIndex == -1)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                cboMatOrd.Focus();
                                return false;
                            }
                            break;
                        case MPGC.MP_STEP_DELETE:

                            break;

                        case MPGC.MP_STEP_UNDELETE:

                            break;

                    }
                    break;

                case "Update_BOMSet_Version":

                    if (MPCF.CheckValue(txtBOMSet, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtBOMSetVersion, 1) == false)
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
                case "Copy_BOMSet_Version":

                    if (MPCF.CheckValue(txtBOMSet, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtBOMSetVersion, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtToVersion, 1) == false)
                    {
                        return false;
                    }
                    break;

                /* 2013.06.12. Aiden. BOM Set 을 복사하는 기능 추가 */
                case "Copy_BOMSet":

                    if (MPCF.CheckValue(txtBOMSet, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtBOMSetVersion, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtToBomSet, 1) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(txtToBomSetDesc, 1) == false)
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
                sBOMSetGrpTableName[0] = MPGC.MP_GCM_BOM_GRP_1;
                sBOMSetGrpTableName[1] = MPGC.MP_GCM_BOM_GRP_2;
                sBOMSetGrpTableName[2] = MPGC.MP_GCM_BOM_GRP_3;
                sBOMSetGrpTableName[3] = MPGC.MP_GCM_BOM_GRP_4;
                sBOMSetGrpTableName[4] = MPGC.MP_GCM_BOM_GRP_5;
                sBOMSetGrpTableName[5] = MPGC.MP_GCM_BOM_GRP_6;
                sBOMSetGrpTableName[6] = MPGC.MP_GCM_BOM_GRP_7;
                sBOMSetGrpTableName[7] = MPGC.MP_GCM_BOM_GRP_8;
                sBOMSetGrpTableName[8] = MPGC.MP_GCM_BOM_GRP_9;
                sBOMSetGrpTableName[9] = MPGC.MP_GCM_BOM_GRP_10;

                MPCR.SetGRPItem(MPGC.MP_GRP_BOM_SET, "lblGroup", "cdvGroup", grpGroup, sBOMSetGrpTableName);
                MPCR.SetCMFItem(MPGC.MP_CMF_BOM_SET, "lblCMF", "cdvCMF", grpCMF);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // View_BOMSet()
        //       - View BOMlection Set Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_BOMSet()
        {
            TRSNode in_node = new TRSNode("VIEW_BOMSET_IN");
            TRSNode out_node = new TRSNode("VIEW_BOMSET_OUT");

            try
            {
                MPCF.ClearList(lisBOMSetVersion, true);
                MPCF.FieldClear(pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BOM_SET_ID", lisBOMSet.SelectedItems[0].Text);

                if (MPCR.CallService("BOM", "BOM_View_BOMSet", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtBOMSet.Text = out_node.GetString("BOM_SET_ID");
                txtDesc.Text = out_node.GetString("BOM_SET_DESC");
                cdvGroup1.Text = out_node.GetString("BOM_GRP_1");
                cdvGroup2.Text = out_node.GetString("BOM_GRP_2");
                cdvGroup3.Text = out_node.GetString("BOM_GRP_3");
                cdvGroup4.Text = out_node.GetString("BOM_GRP_4");
                cdvGroup5.Text = out_node.GetString("BOM_GRP_5");
                cdvGroup6.Text = out_node.GetString("BOM_GRP_6");
                cdvGroup7.Text = out_node.GetString("BOM_GRP_7");
                cdvGroup8.Text = out_node.GetString("BOM_GRP_8");
                cdvGroup9.Text = out_node.GetString("BOM_GRP_9");
                cdvGroup10.Text = out_node.GetString("BOM_GRP_10");
                cdvCMF1.Text = out_node.GetString("BOM_CMF_1");
                cdvCMF2.Text = out_node.GetString("BOM_CMF_2");
                cdvCMF3.Text = out_node.GetString("BOM_CMF_3");
                cdvCMF4.Text = out_node.GetString("BOM_CMF_4");
                cdvCMF5.Text = out_node.GetString("BOM_CMF_5");
                cdvCMF6.Text = out_node.GetString("BOM_CMF_6");
                cdvCMF7.Text = out_node.GetString("BOM_CMF_7");
                cdvCMF8.Text = out_node.GetString("BOM_CMF_8");
                cdvCMF9.Text = out_node.GetString("BOM_CMF_9");
                cdvCMF10.Text = out_node.GetString("BOM_CMF_10");
                if (out_node.GetChar("MAT_OR_ORD_FLAG") == 'M')
                {
                    cboMatOrd.SelectedIndex = 0;
                }
                else if (out_node.GetChar("MAT_OR_ORD_FLAG") == 'O')
                {
                    cboMatOrd.SelectedIndex = 1;
                }
                else
                {
                    cboMatOrd.SelectedIndex = -1;
                }
                chkAppRequireFlag.Checked = (out_node.GetChar("APPROVAL_REQUIRE_FLAG") == 'Y') ? true : false;
                cdvAppUserID.Text = out_node.GetString("APPROVAL_USER_ID");
                if (out_node.GetChar("DELETE_FLAG") == 'Y')
                {
                    chkDeleteFlag.Checked = true;
                    //DisableField(Me)
                }
                else
                {
                    chkDeleteFlag.Checked = false;
                    //EnableField(Me)
                }

                txtDeleteUser.Text = out_node.GetString("DELETE_USER_ID");
                txtDeleteTime.Text = MPCF.MakeDateFormat(out_node.GetString("DELETE_TIME"));
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
        // Update_BOMSet()
        //       - Create/Update/Delete BOMlection Set Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete, "R" - Undelete)
        //
        private bool Update_BOMSet(char ProcStep)
        {
            ListViewItem itm;

            TRSNode in_node = new TRSNode("UPDATE_BOMSET_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BOM_SET_ID", txtBOMSet.Text);
                in_node.AddString("BOM_SET_DESC", txtDesc.Text);
                in_node.AddString("BOM_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("BOM_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("BOM_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("BOM_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("BOM_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("BOM_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("BOM_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("BOM_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("BOM_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("BOM_GRP_10", MPCF.Trim(cdvGroup10.Text));
                in_node.AddString("BOM_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("BOM_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("BOM_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("BOM_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("BOM_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("BOM_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("BOM_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("BOM_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("BOM_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("BOM_CMF_10", MPCF.Trim(cdvCMF10.Text));

                if (MPCF.Trim(cboMatOrd.Text) != "")
                {
                    in_node.AddChar("MAT_OR_ORD_FLAG", (MPCF.Trim(cboMatOrd.Text).Length > 0 ? MPCF.ToChar(cboMatOrd.Text) : ' '));
                }
                else
                {
                    in_node.AddChar("MAT_OR_ORD_FLAG", ' ');
                }
                in_node.AddChar("APPROVAL_REQUIRE_FLAG", chkAppRequireFlag.Checked == true ? 'Y' : ' ');
                in_node.AddString("APPROVAL_USER_ID", MPCF.Trim(cdvAppUserID.Text), true);

                if (MPCR.CallService("BOM", "BOM_Update_BOMSet", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        chkDeleteFlag.Checked = false;
                        itm = lisBOMSet.Items.Add(MPCF.Trim(txtBOMSet.Text), (int)SMALLICON_INDEX.IDX_BOM);
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        itm.Selected = true;
                        lisBOMSet.Sorting = SortOrder.Ascending;
                        lisBOMSet.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisBOMSet, MPCF.Trim(txtBOMSet.Text), false) == true)
                        {
                            lisBOMSet.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        chkDeleteFlag.Checked = true;
                        if (MPCF.FindListItem(lisBOMSet, MPCF.Trim(txtBOMSet.Text), false) == true)
                        {
                            lisBOMSet.SelectedItems[0].ForeColor = Color.Magenta;
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_UNDELETE)
                    {
                        chkDeleteFlag.Checked = false;
                        if (MPCF.FindListItem(lisBOMSet, MPCF.Trim(txtBOMSet.Text), false) == true)
                        {
                            lisBOMSet.SelectedItems[0].ForeColor = Color.Black;
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisBOMSet.Items.Count);
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
        // View_BOMSet_Version()
        //       - View BOMlection Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_BOMSet_Version()
        {
            TRSNode in_node = new TRSNode("VIEW_BOMSET_VERSION_IN");
            TRSNode out_node = new TRSNode("VIEW_BOMSET_VERSION_OUT");

            try
            {
                ClearData('2');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("BOM_SET_ID", lisBOMSet.SelectedItems[0].Text);
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(lisBOMSetVersion.SelectedItems[0].Text));

                if (MPCR.CallService("BOM", "BOM_View_BOMSet_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtBOMSetVersion.Text = out_node.GetInt("BOM_SET_VERSION").ToString();
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

                chkApprovalFlag.Checked = (out_node.GetChar("APPROVAL_FLAG") == 'Y') ? true : false;
                txtApprovalUser.Text = out_node.GetString("APPROVAL_USER_ID");
                txtApprovalTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPROVAL_TIME"));
                chkReleaseFlag.Checked = (out_node.GetChar("RELEASE_FLAG") == 'Y') ? true : false;
                txtReleaseUser.Text = out_node.GetString("RELEASE_USER_ID");
                txtReleaseTime.Text = MPCF.MakeDateFormat(out_node.GetString("RELEASE_TIME"));
                txtBOMSetVerCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtBOMSetVerCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtBOMSetVerUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtBOMSetVerUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // Update_BOMSet_Version()
        //       - Create/Update/Delete BOMlection Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_BOMSet_Version(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_BOMSET_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BOM_SET_ID", lisBOMSet.SelectedItems[0].Text);
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(txtBOMSetVersion.Text));
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

                if (MPCR.CallService("BOM", "BOM_Update_BOMSet_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisBOMSetVersion.Items.Add(MPCF.Trim(txtBOMSetVersion.Text), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
                        itm.Selected = true;
                        lisBOMSetVersion.Sorting = SortOrder.Ascending;
                        lisBOMSetVersion.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        //Do Nothing
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisBOMSetVersion, MPCF.Trim(txtBOMSetVersion.Text), false);
                        if (idx != -1)
                        {
                            lisBOMSetVersion.Items[idx].Remove();
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
        // Copy_BOMSet_Version()
        //       - Copy BOMlection Set Version and it's attached character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Copy_BOMSet_Version(char ProcStep)
        {
            ListViewItem itm;

            TRSNode in_node = new TRSNode("COPY_BOMSET_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BOM_SET_ID", lisBOMSet.SelectedItems[0].Text);
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(txtToVersion.Text));
                in_node.AddInt("FROM_BOM_SET_VERSION", MPCF.ToInt(txtBOMSetVersion.Text));

                if (MPCR.CallService("BOM", "BOM_Copy_BOMSet_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_COPY)
                    {
                        itm = lisBOMSetVersion.Items.Add(MPCF.Trim(txtToVersion.Text), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
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
        // Copy_BOMSet()
        //       - Copy BOMlection Set Version and it's attached character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        /* 2013.06.12. Aiden. BOM Set 을 복사하는 기능 추가 */
        private bool CopyBOMSet(char ProcStep)
        {
            TRSNode in_node = new TRSNode("COPY_BOMSET_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BOM_SET_ID", MPCF.Trim(txtToBomSet.Text));
                in_node.AddString("BOM_SET_DESC", MPCF.Trim(txtToBomSetDesc.Text));

                in_node.AddString("FROM_BOM_SET_ID", MPCF.Trim(txtBOMSet.Text));
                in_node.AddInt("FROM_BOM_SET_VERSION", MPCF.ToInt(txtBOMSetVersion.Text));

                if (MPCR.CallService("BOM", "BOM_Copy_BOMSet", in_node, ref out_node) == false)
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
                return this.lisBOMSet;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmBOMSetupBOMSet_Activated(object sender, System.EventArgs e)
        {

            try
            {
                if (b_load_flag == false)
                {
                    if (SetGroupCmfItem() == false)
                    {
                        return;
                    }
                    lblDataCount.Text = "";

                    if (BOMLIST.ViewBOMSetList(lisBOMSet, '1', null, "", -1, -1, ' ', true) == true)
                    {
                        lblDataCount.Text = lisBOMSet.Items.Count.ToString();
                    }
                    else
                    {
                        return;
                    }
                    if (lisBOMSet.Items.Count > 0)
                    {
                        lisBOMSet.Items[0].Selected = true;
                    }

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void frmBOMSetupBOMSet_Load(object sender, System.EventArgs e)
        {

            try
            {
                MPCF.InitListView(lisBOMSet);
                MPCF.InitListView(lisBOMSetVersion);
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
                if (tabBOMSet.SelectedTab.TabIndex > 2)
                {
                    return;
                }
                if (CheckCondition("Update_BOMSet", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_BOMSet(MPGC.MP_STEP_CREATE) == false)
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
                if (CheckCondition("Update_BOMSet_Version", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_BOMSet_Version(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (BOMLIST.ViewBOMSetVersionList(lisBOMSetVersion, '1', txtBOMSet.Text, -1, null, "") == false)
                        {
                            return;
                        }
                        if (lisBOMSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisBOMSetVersion, txtBOMSetVersion.Text, false);
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
                if (tabBOMSet.SelectedTab.TabIndex > 2)
                {
                    return;
                }
                if (CheckCondition("Update_BOMSet", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_BOMSet(MPGC.MP_STEP_UPDATE) == false)
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
                if (CheckCondition("Update_BOMSet_Version", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_BOMSet_Version(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (BOMLIST.ViewBOMSetVersionList(lisBOMSetVersion, '1', txtBOMSet.Text, -1, null, "") == false)
                        {
                            return;
                        }
                        if (lisBOMSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisBOMSetVersion, txtBOMSetVersion.Text, false);
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
                if (tabBOMSet.SelectedTab.TabIndex > 2)
                {
                    return;
                }
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_BOMSet", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_BOMSet(MPGC.MP_STEP_DELETE) == false)
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
                if (CheckCondition("Update_BOMSet_Version", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_BOMSet_Version(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    ClearData('2');
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        BOMLIST.ViewBOMSetVersionList(lisBOMSetVersion, '1', txtBOMSet.Text, -1, null, "");
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
                if (tabBOMSet.SelectedTab.TabIndex > 2)
                {
                    return;
                }
                if (CheckCondition("Update_BOMSet", MPGC.MP_STEP_UNDELETE) == true)
                {
                    if (Update_BOMSet(MPGC.MP_STEP_UNDELETE) == false)
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

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                lblDataCount.Text = "";
                if (BOMLIST.ViewBOMSetList(lisBOMSet, '1', null, "", -1, -1, ' ', true) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisBOMSet.Items.Count);
                    if (lisBOMSet.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisBOMSet, txtBOMSet.Text, false);
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

            MPCF.ExportToExcel(lisBOMSet, this.Text, "");

        }

        private void lisBOMSet_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            try
            {
                if (lisBOMSet.SelectedIndices.Count > 0)
                {
                    if (View_BOMSet() == false)
                    {
                        return;
                    }
                    if (BOMLIST.ViewBOMSetVersionList(lisBOMSetVersion, '1', lisBOMSet.SelectedItems[0].Text, -1, null, "") == false)
                    {
                        return;
                    }
                    if (lisBOMSetVersion.Items.Count > 0)
                    {
                        lisBOMSetVersion.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void lisBOMSetVersion_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            try
            {
                if (bIgnoreSelectFlag == false)
                {
                    bIndexChangeFlag2 = true;
                    if (lisBOMSetVersion.SelectedIndices.Count > 0)
                    {
                        View_BOMSet_Version();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void lisBOMSetVersion_Click(object sender, System.EventArgs e)
        {

            if (lisBOMSet.SelectedIndices.Count == 0)
            {
                return;
            }
            if (lisBOMSetVersion.SelectedIndices.Count > 0 && bIndexChangeFlag2 == false && bIgnoreSelectFlag == false)
            {
                View_BOMSet_Version();
            }
            bIndexChangeFlag2 = false;

        }

        private void txtBOMSet_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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

        private void cdvGroupCmf_ButtonPress(object sender, System.EventArgs e)
        {

            MPCR.ProcGRPCMFButtonPress(sender);

        }

        private void txtBOMSetVersion_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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

        private void tabBOMSet_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            if (!(tabBOMSet.SelectedTab == tbpBOMVersion))
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

        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("Copy_BOMSet_Version", MPGC.MP_STEP_COPY) == true)
                {
                    if (Copy_BOMSet_Version(MPGC.MP_STEP_COPY) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (BOMLIST.ViewBOMSetVersionList(lisBOMSetVersion, '1', txtBOMSet.Text, -1, null, "") == false)
                        {
                            return;
                        }
                        if (lisBOMSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisBOMSetVersion, txtToVersion.Text, false);
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

            MPCF.FindListItemNextPartial(lisBOMSet, txtFind.Text, true, false);

        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisBOMSet, txtFind.Text, 0, true, false);

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

        private void cdvAppUserID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAppUserID.Init();
            MPCF.InitListView(cdvAppUserID.GetListView);
            cdvAppUserID.Columns.Add("UserID", 100, HorizontalAlignment.Left);
            cdvAppUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAppUserID.SelectedSubItemIndex = 0;

            SECLIST.ViewSECUserList(cdvAppUserID.GetListView, '1', -1, null, "", "");
        }

        /* 2013.06.12. Aiden. BOM Set 을 복사하는 기능 추가 */
        private void btnToBomSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("Copy_BOMSet", MPGC.MP_STEP_COPY) == true)
                {
                    if (CopyBOMSet(MPGC.MP_STEP_COPY) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (BOMLIST.ViewBOMSetList(lisBOMSet, '1', null, "", -1, -1, ' ', true) == true)
                        {
                            lblDataCount.Text = lisBOMSet.Items.Count.ToString();
                        }

                        if (BOMLIST.ViewBOMSetVersionList(lisBOMSetVersion, '1', txtToBomSet.Text, -1, null, "") == false)
                        {
                            return;
                        }

                        if (lisBOMSetVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisBOMSet, txtToBomSet.Text, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }
    //#End If ' _BOM
}
