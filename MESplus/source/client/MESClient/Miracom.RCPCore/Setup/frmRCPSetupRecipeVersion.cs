
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

//#If _RCP = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRCPSetupRecipeVersion.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Recipe_Version() : View Recipe Version Definition
//       - Update_Recipe_Version() : Create/Update/Delete Recipe Version
//       - Copy_Recipe_Version() : Copy Recipe Version
//       - View_Para_Version_List() : View Para Version List
//       - Update_Para_Version() : Create/Update/Delete Parameter Version
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-06-28 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RCPCore
{
    public class frmRCPSetupRecipeVersion : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRCPSetupRecipeVersion()
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
        



        private Miracom.UI.Controls.MCListView.MCListView lisResource;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Panel pnlRecipeList;
        private Miracom.UI.Controls.MCListView.MCListView lisRecipe;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.TextBox txtRecipe;
        private System.Windows.Forms.TextBox txtResId;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.Panel pnlRecipeVersion;
        private Miracom.UI.Controls.MCListView.MCListView lisRecipeVersion;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.GroupBox grpBOMSetVersion;
        private System.Windows.Forms.TextBox txtRecipeVersion;
        private System.Windows.Forms.Label lblRecipe;
        private System.Windows.Forms.TabControl tabVersion;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Panel pnlUpdateInfo;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.NumericUpDown nudSecond;
        private System.Windows.Forms.NumericUpDown nudMinute;
        private System.Windows.Forms.NumericUpDown nudHour;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvColSetID;
        private System.Windows.Forms.Label lblProcTime;
        private System.Windows.Forms.CheckBox chkModify;
        private System.Windows.Forms.TextBox txtReticleID;
        private System.Windows.Forms.TextBox txtCoatPPID;
        private System.Windows.Forms.TextBox txtPPId;
        private System.Windows.Forms.Label lblColSetID;
        private System.Windows.Forms.Label lblReticleID;
        private System.Windows.Forms.Label lblCoatPPId;
        private System.Windows.Forms.Label lblPPId;
        private System.Windows.Forms.GroupBox grpApplyTime;
        private System.Windows.Forms.CheckBox chkEnd;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.Label lblFromTo;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.GroupBox grpUpdateInfo;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
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
        private System.Windows.Forms.TabPage tbpParameter;
        private System.Windows.Forms.GroupBox grpParameter;
        private System.Windows.Forms.CheckBox chkParaModifyFlag;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtParameterID;
        private System.Windows.Forms.TextBox txtSeqNum;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblParameterID;
        private System.Windows.Forms.Label lblSeqNum;
        private System.Windows.Forms.GroupBox grpBOMSetVerBtn;
        public System.Windows.Forms.Button btnVerCreate;
        public System.Windows.Forms.Button btnVerDelete;
        public System.Windows.Forms.Button btnVerUpdate;
        private Miracom.UI.Controls.MCListView.MCListView lisParameter;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private TextBox txtMinValue;
        private Label lblMinValue;
        private TextBox txtMaxValue;
        private Label lblMaxValue;
        private TextBox txtUnit;
        private Label lblUnit;
        private Button btnLoad;
        private Button btnView;
        private Button btnVerLoad;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisResource = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlRecipeList = new System.Windows.Forms.Panel();
            this.lisRecipe = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtRecipe = new System.Windows.Forms.TextBox();
            this.txtResId = new System.Windows.Forms.TextBox();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabVersion = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlUpdateInfo = new System.Windows.Forms.Panel();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblMinute = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.nudSecond = new System.Windows.Forms.NumericUpDown();
            this.nudMinute = new System.Windows.Forms.NumericUpDown();
            this.nudHour = new System.Windows.Forms.NumericUpDown();
            this.cdvColSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblProcTime = new System.Windows.Forms.Label();
            this.chkModify = new System.Windows.Forms.CheckBox();
            this.txtReticleID = new System.Windows.Forms.TextBox();
            this.txtCoatPPID = new System.Windows.Forms.TextBox();
            this.txtPPId = new System.Windows.Forms.TextBox();
            this.lblColSetID = new System.Windows.Forms.Label();
            this.lblReticleID = new System.Windows.Forms.Label();
            this.lblCoatPPId = new System.Windows.Forms.Label();
            this.lblPPId = new System.Windows.Forms.Label();
            this.grpApplyTime = new System.Windows.Forms.GroupBox();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.lblFromTo = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.grpUpdateInfo = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
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
            this.tbpParameter = new System.Windows.Forms.TabPage();
            this.lisParameter = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpParameter = new System.Windows.Forms.GroupBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtMaxValue = new System.Windows.Forms.TextBox();
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.txtMinValue = new System.Windows.Forms.TextBox();
            this.lblMinValue = new System.Windows.Forms.Label();
            this.chkParaModifyFlag = new System.Windows.Forms.CheckBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtParameterID = new System.Windows.Forms.TextBox();
            this.txtSeqNum = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblParameterID = new System.Windows.Forms.Label();
            this.lblSeqNum = new System.Windows.Forms.Label();
            this.grpBOMSetVerBtn = new System.Windows.Forms.GroupBox();
            this.btnVerLoad = new System.Windows.Forms.Button();
            this.btnVerCreate = new System.Windows.Forms.Button();
            this.btnVerDelete = new System.Windows.Forms.Button();
            this.btnVerUpdate = new System.Windows.Forms.Button();
            this.grpBOMSetVersion = new System.Windows.Forms.GroupBox();
            this.txtRecipeVersion = new System.Windows.Forms.TextBox();
            this.lblRecipe = new System.Windows.Forms.Label();
            this.pnlRecipeVersion = new System.Windows.Forms.Panel();
            this.lisRecipeVersion = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlRecipeList.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabVersion.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlUpdateInfo.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvColSetID)).BeginInit();
            this.grpApplyTime.SuspendLayout();
            this.grpUpdateInfo.SuspendLayout();
            this.tbpAppNRel.SuspendLayout();
            this.pnlReleaseInfo.SuspendLayout();
            this.grpRelease.SuspendLayout();
            this.grpApproval.SuspendLayout();
            this.tbpCopy.SuspendLayout();
            this.grpCopyTable.SuspendLayout();
            this.tbpParameter.SuspendLayout();
            this.grpParameter.SuspendLayout();
            this.grpBOMSetVerBtn.SuspendLayout();
            this.grpBOMSetVersion.SuspendLayout();
            this.pnlRecipeVersion.SuspendLayout();
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
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.pnlRecipeList);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisResource);
            this.pnlLeft.Controls.Add(this.txtResId);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
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
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnLoad);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnLoad, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Recipe Version Setup";
            // 
            // lisResource
            // 
            this.lisResource.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisResource.EnableSort = true;
            this.lisResource.EnableSortIcon = true;
            this.lisResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisResource.FullRowSelect = true;
            this.lisResource.Location = new System.Drawing.Point(3, 3);
            this.lisResource.MultiSelect = false;
            this.lisResource.Name = "lisResource";
            this.lisResource.Size = new System.Drawing.Size(229, 507);
            this.lisResource.TabIndex = 0;
            this.lisResource.UseCompatibleStateImageBehavior = false;
            this.lisResource.View = System.Windows.Forms.View.Details;
            this.lisResource.SelectedIndexChanged += new System.EventHandler(this.lisResource_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Resource";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // pnlRecipeList
            // 
            this.pnlRecipeList.Controls.Add(this.lisRecipe);
            this.pnlRecipeList.Controls.Add(this.txtRecipe);
            this.pnlRecipeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRecipeList.Location = new System.Drawing.Point(3, 3);
            this.pnlRecipeList.Name = "pnlRecipeList";
            this.pnlRecipeList.Size = new System.Drawing.Size(500, 125);
            this.pnlRecipeList.TabIndex = 1;
            // 
            // lisRecipe
            // 
            this.lisRecipe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader3,
            this.ColumnHeader4});
            this.lisRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRecipe.EnableSort = true;
            this.lisRecipe.EnableSortIcon = true;
            this.lisRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRecipe.FullRowSelect = true;
            this.lisRecipe.Location = new System.Drawing.Point(0, 0);
            this.lisRecipe.MultiSelect = false;
            this.lisRecipe.Name = "lisRecipe";
            this.lisRecipe.Size = new System.Drawing.Size(500, 125);
            this.lisRecipe.TabIndex = 0;
            this.lisRecipe.UseCompatibleStateImageBehavior = false;
            this.lisRecipe.View = System.Windows.Forms.View.Details;
            this.lisRecipe.SelectedIndexChanged += new System.EventHandler(this.lisRecipe_SelectedIndexChanged);
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Recipe";
            this.ColumnHeader3.Width = 100;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Description";
            this.ColumnHeader4.Width = 390;
            // 
            // txtRecipe
            // 
            this.txtRecipe.Location = new System.Drawing.Point(188, 40);
            this.txtRecipe.MaxLength = 4;
            this.txtRecipe.Name = "txtRecipe";
            this.txtRecipe.Size = new System.Drawing.Size(125, 20);
            this.txtRecipe.TabIndex = 0;
            this.txtRecipe.TabStop = false;
            this.txtRecipe.Visible = false;
            // 
            // txtResId
            // 
            this.txtResId.Location = new System.Drawing.Point(54, 243);
            this.txtResId.MaxLength = 4;
            this.txtResId.Name = "txtResId";
            this.txtResId.Size = new System.Drawing.Size(125, 20);
            this.txtResId.TabIndex = 4;
            this.txtResId.TabStop = false;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabVersion);
            this.pnlTab.Controls.Add(this.grpBOMSetVersion);
            this.pnlTab.Controls.Add(this.pnlRecipeVersion);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(3, 128);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(500, 382);
            this.pnlTab.TabIndex = 2;
            // 
            // tabVersion
            // 
            this.tabVersion.Controls.Add(this.tbpGeneral);
            this.tabVersion.Controls.Add(this.tbpAppNRel);
            this.tabVersion.Controls.Add(this.tbpCopy);
            this.tabVersion.Controls.Add(this.tbpParameter);
            this.tabVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVersion.ItemSize = new System.Drawing.Size(60, 18);
            this.tabVersion.Location = new System.Drawing.Point(98, 45);
            this.tabVersion.Name = "tabVersion";
            this.tabVersion.SelectedIndex = 0;
            this.tabVersion.Size = new System.Drawing.Size(402, 337);
            this.tabVersion.TabIndex = 1;
            this.tabVersion.TabStop = false;
            this.tabVersion.SelectedIndexChanged += new System.EventHandler(this.tabVersion_SelectedIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlUpdateInfo);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.tbpGeneral.Size = new System.Drawing.Size(394, 311);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlUpdateInfo
            // 
            this.pnlUpdateInfo.Controls.Add(this.grpInfo);
            this.pnlUpdateInfo.Controls.Add(this.grpApplyTime);
            this.pnlUpdateInfo.Controls.Add(this.grpUpdateInfo);
            this.pnlUpdateInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpdateInfo.Location = new System.Drawing.Point(3, 5);
            this.pnlUpdateInfo.Name = "pnlUpdateInfo";
            this.pnlUpdateInfo.Size = new System.Drawing.Size(388, 306);
            this.pnlUpdateInfo.TabIndex = 1;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblSecond);
            this.grpInfo.Controls.Add(this.lblMinute);
            this.grpInfo.Controls.Add(this.lblHour);
            this.grpInfo.Controls.Add(this.nudSecond);
            this.grpInfo.Controls.Add(this.nudMinute);
            this.grpInfo.Controls.Add(this.nudHour);
            this.grpInfo.Controls.Add(this.cdvColSetID);
            this.grpInfo.Controls.Add(this.lblProcTime);
            this.grpInfo.Controls.Add(this.chkModify);
            this.grpInfo.Controls.Add(this.txtReticleID);
            this.grpInfo.Controls.Add(this.txtCoatPPID);
            this.grpInfo.Controls.Add(this.txtPPId);
            this.grpInfo.Controls.Add(this.lblColSetID);
            this.grpInfo.Controls.Add(this.lblReticleID);
            this.grpInfo.Controls.Add(this.lblCoatPPId);
            this.grpInfo.Controls.Add(this.lblPPId);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInfo.Location = new System.Drawing.Point(0, 0);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(388, 170);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSecond.Location = new System.Drawing.Point(302, 112);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(29, 13);
            this.lblSecond.TabIndex = 14;
            this.lblSecond.Text = "Sec.";
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMinute.Location = new System.Drawing.Point(232, 112);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(27, 13);
            this.lblMinute.TabIndex = 12;
            this.lblMinute.Text = "Min.";
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHour.Location = new System.Drawing.Point(160, 112);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(30, 13);
            this.lblHour.TabIndex = 10;
            this.lblHour.Text = "Hour";
            // 
            // nudSecond
            // 
            this.nudSecond.Location = new System.Drawing.Point(263, 110);
            this.nudSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudSecond.Name = "nudSecond";
            this.nudSecond.Size = new System.Drawing.Size(36, 20);
            this.nudSecond.TabIndex = 13;
            this.nudSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudMinute
            // 
            this.nudMinute.Location = new System.Drawing.Point(193, 110);
            this.nudMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMinute.Name = "nudMinute";
            this.nudMinute.Size = new System.Drawing.Size(36, 20);
            this.nudMinute.TabIndex = 11;
            this.nudMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudHour
            // 
            this.nudHour.Location = new System.Drawing.Point(121, 110);
            this.nudHour.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudHour.Name = "nudHour";
            this.nudHour.Size = new System.Drawing.Size(36, 20);
            this.nudHour.TabIndex = 9;
            this.nudHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cdvColSetID
            // 
            this.cdvColSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvColSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvColSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvColSetID.BtnToolTipText = "";
            this.cdvColSetID.ButtonWidth = 20;
            this.cdvColSetID.DescText = "";
            this.cdvColSetID.DisplaySubItemIndex = -1;
            this.cdvColSetID.DisplayText = "";
            this.cdvColSetID.Focusing = null;
            this.cdvColSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvColSetID.Index = 0;
            this.cdvColSetID.IsViewBtnImage = false;
            this.cdvColSetID.Location = new System.Drawing.Point(121, 85);
            this.cdvColSetID.MaxLength = 25;
            this.cdvColSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvColSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvColSetID.MultiSelect = false;
            this.cdvColSetID.Name = "cdvColSetID";
            this.cdvColSetID.ReadOnly = false;
            this.cdvColSetID.SameWidthHeightOfButton = false;
            this.cdvColSetID.SearchSubItemIndex = 0;
            this.cdvColSetID.SelectedDescIndex = -1;
            this.cdvColSetID.SelectedDescToQueryText = "";
            this.cdvColSetID.SelectedSubItemIndex = -1;
            this.cdvColSetID.SelectedValueToQueryText = "";
            this.cdvColSetID.SelectionStart = 0;
            this.cdvColSetID.Size = new System.Drawing.Size(175, 20);
            this.cdvColSetID.SmallImageList = null;
            this.cdvColSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvColSetID.TabIndex = 7;
            this.cdvColSetID.TextBoxToolTipText = "";
            this.cdvColSetID.TextBoxWidth = 175;
            this.cdvColSetID.VisibleButton = true;
            this.cdvColSetID.VisibleColumnHeader = false;
            this.cdvColSetID.VisibleDescription = false;
            this.cdvColSetID.ButtonPress += new System.EventHandler(this.cdvColSetID_ButtonPress);
            // 
            // lblProcTime
            // 
            this.lblProcTime.AutoSize = true;
            this.lblProcTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcTime.Location = new System.Drawing.Point(15, 113);
            this.lblProcTime.Name = "lblProcTime";
            this.lblProcTime.Size = new System.Drawing.Size(55, 13);
            this.lblProcTime.TabIndex = 8;
            this.lblProcTime.Text = "Proc Time";
            // 
            // chkModify
            // 
            this.chkModify.AutoSize = true;
            this.chkModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkModify.Location = new System.Drawing.Point(15, 136);
            this.chkModify.Name = "chkModify";
            this.chkModify.Size = new System.Drawing.Size(86, 18);
            this.chkModify.TabIndex = 15;
            this.chkModify.Text = "Modify Flag";
            // 
            // txtReticleID
            // 
            this.txtReticleID.Location = new System.Drawing.Point(121, 61);
            this.txtReticleID.MaxLength = 50;
            this.txtReticleID.Name = "txtReticleID";
            this.txtReticleID.Size = new System.Drawing.Size(175, 20);
            this.txtReticleID.TabIndex = 5;
            // 
            // txtCoatPPID
            // 
            this.txtCoatPPID.Location = new System.Drawing.Point(121, 37);
            this.txtCoatPPID.MaxLength = 25;
            this.txtCoatPPID.Name = "txtCoatPPID";
            this.txtCoatPPID.Size = new System.Drawing.Size(175, 20);
            this.txtCoatPPID.TabIndex = 3;
            // 
            // txtPPId
            // 
            this.txtPPId.Location = new System.Drawing.Point(121, 13);
            this.txtPPId.MaxLength = 25;
            this.txtPPId.Name = "txtPPId";
            this.txtPPId.Size = new System.Drawing.Size(175, 20);
            this.txtPPId.TabIndex = 1;
            // 
            // lblColSetID
            // 
            this.lblColSetID.AutoSize = true;
            this.lblColSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSetID.Location = new System.Drawing.Point(15, 89);
            this.lblColSetID.Name = "lblColSetID";
            this.lblColSetID.Size = new System.Drawing.Size(55, 13);
            this.lblColSetID.TabIndex = 6;
            this.lblColSetID.Text = "Col Set ID";
            // 
            // lblReticleID
            // 
            this.lblReticleID.AutoSize = true;
            this.lblReticleID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReticleID.Location = new System.Drawing.Point(15, 65);
            this.lblReticleID.Name = "lblReticleID";
            this.lblReticleID.Size = new System.Drawing.Size(54, 13);
            this.lblReticleID.TabIndex = 4;
            this.lblReticleID.Text = "Reticle ID";
            // 
            // lblCoatPPId
            // 
            this.lblCoatPPId.AutoSize = true;
            this.lblCoatPPId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCoatPPId.Location = new System.Drawing.Point(15, 41);
            this.lblCoatPPId.Name = "lblCoatPPId";
            this.lblCoatPPId.Size = new System.Drawing.Size(60, 13);
            this.lblCoatPPId.TabIndex = 2;
            this.lblCoatPPId.Text = "Coat PP ID";
            // 
            // lblPPId
            // 
            this.lblPPId.AutoSize = true;
            this.lblPPId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPPId.Location = new System.Drawing.Point(15, 17);
            this.lblPPId.Name = "lblPPId";
            this.lblPPId.Size = new System.Drawing.Size(35, 13);
            this.lblPPId.TabIndex = 0;
            this.lblPPId.Text = "PP ID";
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
            this.grpApplyTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpApplyTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpApplyTime.Location = new System.Drawing.Point(0, 170);
            this.grpApplyTime.Name = "grpApplyTime";
            this.grpApplyTime.Size = new System.Drawing.Size(388, 66);
            this.grpApplyTime.TabIndex = 1;
            this.grpApplyTime.TabStop = false;
            this.grpApplyTime.Text = "Apply Time";
            // 
            // chkEnd
            // 
            this.chkEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEnd.Location = new System.Drawing.Point(15, 42);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(12, 16);
            this.chkEnd.TabIndex = 4;
            this.chkEnd.Text = "CheckBox1";
            this.chkEnd.CheckedChanged += new System.EventHandler(this.chkEnd_CheckedChanged);
            // 
            // chkStart
            // 
            this.chkStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStart.Location = new System.Drawing.Point(15, 18);
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
            this.lblFromTo.Location = new System.Drawing.Point(223, 22);
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
            this.dtpEndTime.Location = new System.Drawing.Point(127, 40);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(90, 20);
            this.dtpEndTime.TabIndex = 6;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(35, 40);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(90, 20);
            this.dtpEndDate.TabIndex = 5;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(127, 16);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(90, 20);
            this.dtpStartTime.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(35, 16);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(90, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // grpUpdateInfo
            // 
            this.grpUpdateInfo.Controls.Add(this.txtUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.txtCreateTime);
            this.grpUpdateInfo.Controls.Add(this.txtUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.lblUpdate);
            this.grpUpdateInfo.Controls.Add(this.txtCreateUser);
            this.grpUpdateInfo.Controls.Add(this.lblCreate);
            this.grpUpdateInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpUpdateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUpdateInfo.Location = new System.Drawing.Point(0, 236);
            this.grpUpdateInfo.Name = "grpUpdateInfo";
            this.grpUpdateInfo.Size = new System.Drawing.Size(388, 70);
            this.grpUpdateInfo.TabIndex = 2;
            this.grpUpdateInfo.TabStop = false;
            this.grpUpdateInfo.Text = "Update Information";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(264, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(115, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(264, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(115, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(140, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
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
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(140, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
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
            // tbpAppNRel
            // 
            this.tbpAppNRel.Controls.Add(this.pnlReleaseInfo);
            this.tbpAppNRel.Controls.Add(this.grpApproval);
            this.tbpAppNRel.Location = new System.Drawing.Point(4, 22);
            this.tbpAppNRel.Name = "tbpAppNRel";
            this.tbpAppNRel.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.tbpAppNRel.Size = new System.Drawing.Size(394, 304);
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
            this.pnlReleaseInfo.Size = new System.Drawing.Size(388, 208);
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
            this.grpRelease.Size = new System.Drawing.Size(388, 203);
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
            this.grpApproval.Size = new System.Drawing.Size(388, 91);
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
            this.tbpCopy.Size = new System.Drawing.Size(394, 304);
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
            this.grpCopyTable.Size = new System.Drawing.Size(388, 49);
            this.grpCopyTable.TabIndex = 0;
            this.grpCopyTable.TabStop = false;
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
            this.txtToVersion.TabIndex = 1;
            // 
            // tbpParameter
            // 
            this.tbpParameter.Controls.Add(this.lisParameter);
            this.tbpParameter.Controls.Add(this.grpParameter);
            this.tbpParameter.Controls.Add(this.grpBOMSetVerBtn);
            this.tbpParameter.Location = new System.Drawing.Point(4, 22);
            this.tbpParameter.Name = "tbpParameter";
            this.tbpParameter.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.tbpParameter.Size = new System.Drawing.Size(394, 311);
            this.tbpParameter.TabIndex = 3;
            this.tbpParameter.Text = "Parameter";
            this.tbpParameter.Visible = false;
            // 
            // lisParameter
            // 
            this.lisParameter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader9,
            this.ColumnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lisParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisParameter.EnableSort = true;
            this.lisParameter.EnableSortIcon = true;
            this.lisParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisParameter.FullRowSelect = true;
            this.lisParameter.Location = new System.Drawing.Point(3, 5);
            this.lisParameter.MultiSelect = false;
            this.lisParameter.Name = "lisParameter";
            this.lisParameter.Size = new System.Drawing.Size(388, 52);
            this.lisParameter.TabIndex = 0;
            this.lisParameter.UseCompatibleStateImageBehavior = false;
            this.lisParameter.View = System.Windows.Forms.View.Details;
            this.lisParameter.SelectedIndexChanged += new System.EventHandler(this.lisParameter_SelectedIndexChanged);
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Seq";
            this.ColumnHeader6.Width = 70;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Parameter ID";
            this.ColumnHeader7.Width = 250;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Value";
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Description";
            this.ColumnHeader9.Width = 180;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Modify Flag";
            this.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader10.Width = 77;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Min Value";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader11.Width = 90;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Max Value";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader12.Width = 90;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Unit";
            // 
            // grpParameter
            // 
            this.grpParameter.Controls.Add(this.txtUnit);
            this.grpParameter.Controls.Add(this.lblUnit);
            this.grpParameter.Controls.Add(this.txtMaxValue);
            this.grpParameter.Controls.Add(this.lblMaxValue);
            this.grpParameter.Controls.Add(this.txtMinValue);
            this.grpParameter.Controls.Add(this.lblMinValue);
            this.grpParameter.Controls.Add(this.chkParaModifyFlag);
            this.grpParameter.Controls.Add(this.txtDesc);
            this.grpParameter.Controls.Add(this.txtValue);
            this.grpParameter.Controls.Add(this.txtParameterID);
            this.grpParameter.Controls.Add(this.txtSeqNum);
            this.grpParameter.Controls.Add(this.lblDesc);
            this.grpParameter.Controls.Add(this.lblValue);
            this.grpParameter.Controls.Add(this.lblParameterID);
            this.grpParameter.Controls.Add(this.lblSeqNum);
            this.grpParameter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpParameter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpParameter.Location = new System.Drawing.Point(3, 57);
            this.grpParameter.Name = "grpParameter";
            this.grpParameter.Size = new System.Drawing.Size(388, 210);
            this.grpParameter.TabIndex = 1;
            this.grpParameter.TabStop = false;
            this.grpParameter.Text = "Parameter";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(121, 183);
            this.txtUnit.MaxLength = 10;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(162, 20);
            this.txtUnit.TabIndex = 14;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit.Location = new System.Drawing.Point(15, 187);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 13;
            this.lblUnit.Text = "Unit";
            // 
            // txtMaxValue
            // 
            this.txtMaxValue.Location = new System.Drawing.Point(121, 159);
            this.txtMaxValue.MaxLength = 12;
            this.txtMaxValue.Name = "txtMaxValue";
            this.txtMaxValue.Size = new System.Drawing.Size(162, 20);
            this.txtMaxValue.TabIndex = 13;
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxValue.Location = new System.Drawing.Point(15, 163);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(57, 13);
            this.lblMaxValue.TabIndex = 11;
            this.lblMaxValue.Text = "Max Value";
            // 
            // txtMinValue
            // 
            this.txtMinValue.Location = new System.Drawing.Point(121, 135);
            this.txtMinValue.MaxLength = 12;
            this.txtMinValue.Name = "txtMinValue";
            this.txtMinValue.Size = new System.Drawing.Size(162, 20);
            this.txtMinValue.TabIndex = 13;
            // 
            // lblMinValue
            // 
            this.lblMinValue.AutoSize = true;
            this.lblMinValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMinValue.Location = new System.Drawing.Point(15, 139);
            this.lblMinValue.Name = "lblMinValue";
            this.lblMinValue.Size = new System.Drawing.Size(54, 13);
            this.lblMinValue.TabIndex = 9;
            this.lblMinValue.Text = "Min Value";
            // 
            // chkParaModifyFlag
            // 
            this.chkParaModifyFlag.AutoSize = true;
            this.chkParaModifyFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkParaModifyFlag.Location = new System.Drawing.Point(15, 114);
            this.chkParaModifyFlag.Name = "chkParaModifyFlag";
            this.chkParaModifyFlag.Size = new System.Drawing.Size(86, 18);
            this.chkParaModifyFlag.TabIndex = 8;
            this.chkParaModifyFlag.Text = "Modify Flag";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(121, 87);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(162, 20);
            this.txtDesc.TabIndex = 7;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(121, 63);
            this.txtValue.MaxLength = 20;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(162, 20);
            this.txtValue.TabIndex = 5;
            // 
            // txtParameterID
            // 
            this.txtParameterID.Location = new System.Drawing.Point(121, 39);
            this.txtParameterID.MaxLength = 30;
            this.txtParameterID.Name = "txtParameterID";
            this.txtParameterID.Size = new System.Drawing.Size(162, 20);
            this.txtParameterID.TabIndex = 3;
            // 
            // txtSeqNum
            // 
            this.txtSeqNum.Location = new System.Drawing.Point(121, 15);
            this.txtSeqNum.MaxLength = 6;
            this.txtSeqNum.Name = "txtSeqNum";
            this.txtSeqNum.Size = new System.Drawing.Size(162, 20);
            this.txtSeqNum.TabIndex = 1;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 91);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Description";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue.Location = new System.Drawing.Point(15, 67);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(34, 13);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "Value";
            // 
            // lblParameterID
            // 
            this.lblParameterID.AutoSize = true;
            this.lblParameterID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblParameterID.Location = new System.Drawing.Point(15, 43);
            this.lblParameterID.Name = "lblParameterID";
            this.lblParameterID.Size = new System.Drawing.Size(69, 13);
            this.lblParameterID.TabIndex = 2;
            this.lblParameterID.Text = "Parameter ID";
            // 
            // lblSeqNum
            // 
            this.lblSeqNum.AutoSize = true;
            this.lblSeqNum.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSeqNum.Location = new System.Drawing.Point(15, 19);
            this.lblSeqNum.Name = "lblSeqNum";
            this.lblSeqNum.Size = new System.Drawing.Size(51, 13);
            this.lblSeqNum.TabIndex = 0;
            this.lblSeqNum.Text = "Seq Num";
            // 
            // grpBOMSetVerBtn
            // 
            this.grpBOMSetVerBtn.Controls.Add(this.btnVerLoad);
            this.grpBOMSetVerBtn.Controls.Add(this.btnVerCreate);
            this.grpBOMSetVerBtn.Controls.Add(this.btnVerDelete);
            this.grpBOMSetVerBtn.Controls.Add(this.btnVerUpdate);
            this.grpBOMSetVerBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBOMSetVerBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBOMSetVerBtn.Location = new System.Drawing.Point(3, 267);
            this.grpBOMSetVerBtn.Name = "grpBOMSetVerBtn";
            this.grpBOMSetVerBtn.Size = new System.Drawing.Size(388, 44);
            this.grpBOMSetVerBtn.TabIndex = 2;
            this.grpBOMSetVerBtn.TabStop = false;
            // 
            // btnVerLoad
            // 
            this.btnVerLoad.Location = new System.Drawing.Point(19, 13);
            this.btnVerLoad.Name = "btnVerLoad";
            this.btnVerLoad.Size = new System.Drawing.Size(88, 26);
            this.btnVerLoad.TabIndex = 6;
            this.btnVerLoad.Text = "Load";
            this.btnVerLoad.UseVisualStyleBackColor = true;
            this.btnVerLoad.Click += new System.EventHandler(this.btnVerLoad_Click);
            // 
            // btnVerCreate
            // 
            this.btnVerCreate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVerCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVerCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVerCreate.Location = new System.Drawing.Point(111, 13);
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
            this.btnVerDelete.Location = new System.Drawing.Point(295, 13);
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
            this.btnVerUpdate.Location = new System.Drawing.Point(203, 13);
            this.btnVerUpdate.Name = "btnVerUpdate";
            this.btnVerUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnVerUpdate.TabIndex = 1;
            this.btnVerUpdate.Text = "Update";
            this.btnVerUpdate.Click += new System.EventHandler(this.btnVerUpdate_Click);
            // 
            // grpBOMSetVersion
            // 
            this.grpBOMSetVersion.Controls.Add(this.txtRecipeVersion);
            this.grpBOMSetVersion.Controls.Add(this.lblRecipe);
            this.grpBOMSetVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBOMSetVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBOMSetVersion.Location = new System.Drawing.Point(98, 3);
            this.grpBOMSetVersion.Name = "grpBOMSetVersion";
            this.grpBOMSetVersion.Size = new System.Drawing.Size(402, 42);
            this.grpBOMSetVersion.TabIndex = 0;
            this.grpBOMSetVersion.TabStop = false;
            // 
            // txtRecipeVersion
            // 
            this.txtRecipeVersion.Location = new System.Drawing.Point(163, 16);
            this.txtRecipeVersion.MaxLength = 3;
            this.txtRecipeVersion.Name = "txtRecipeVersion";
            this.txtRecipeVersion.Size = new System.Drawing.Size(140, 20);
            this.txtRecipeVersion.TabIndex = 1;
            // 
            // lblRecipe
            // 
            this.lblRecipe.AutoSize = true;
            this.lblRecipe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipe.Location = new System.Drawing.Point(16, 19);
            this.lblRecipe.Name = "lblRecipe";
            this.lblRecipe.Size = new System.Drawing.Size(93, 13);
            this.lblRecipe.TabIndex = 0;
            this.lblRecipe.Text = "Recipe Version";
            this.lblRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRecipeVersion
            // 
            this.pnlRecipeVersion.Controls.Add(this.lisRecipeVersion);
            this.pnlRecipeVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRecipeVersion.Location = new System.Drawing.Point(0, 3);
            this.pnlRecipeVersion.Name = "pnlRecipeVersion";
            this.pnlRecipeVersion.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlRecipeVersion.Size = new System.Drawing.Size(98, 379);
            this.pnlRecipeVersion.TabIndex = 0;
            // 
            // lisRecipeVersion
            // 
            this.lisRecipeVersion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5});
            this.lisRecipeVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRecipeVersion.EnableSort = true;
            this.lisRecipeVersion.EnableSortIcon = true;
            this.lisRecipeVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRecipeVersion.FullRowSelect = true;
            this.lisRecipeVersion.Location = new System.Drawing.Point(0, 0);
            this.lisRecipeVersion.MultiSelect = false;
            this.lisRecipeVersion.Name = "lisRecipeVersion";
            this.lisRecipeVersion.Size = new System.Drawing.Size(95, 379);
            this.lisRecipeVersion.TabIndex = 0;
            this.lisRecipeVersion.UseCompatibleStateImageBehavior = false;
            this.lisRecipeVersion.View = System.Windows.Forms.View.Details;
            this.lisRecipeVersion.SelectedIndexChanged += new System.EventHandler(this.lisRecipeversion_SelectedIndexChanged);
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Recipe Version";
            this.ColumnHeader5.Width = 90;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(330, 7);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(88, 26);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(236, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmRCPSetupRecipeVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRCPSetupRecipeVersion";
            this.Text = "Recipe Version Setup";
            this.Activated += new System.EventHandler(this.frmRCPSetupRecipeVersion_Activated);
            this.Load += new System.EventHandler(this.frmRCPSetupRecipeVersion_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlRecipeList.ResumeLayout(false);
            this.pnlRecipeList.PerformLayout();
            this.pnlTab.ResumeLayout(false);
            this.tabVersion.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlUpdateInfo.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvColSetID)).EndInit();
            this.grpApplyTime.ResumeLayout(false);
            this.grpApplyTime.PerformLayout();
            this.grpUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.PerformLayout();
            this.tbpAppNRel.ResumeLayout(false);
            this.pnlReleaseInfo.ResumeLayout(false);
            this.grpRelease.ResumeLayout(false);
            this.grpRelease.PerformLayout();
            this.grpApproval.ResumeLayout(false);
            this.grpApproval.PerformLayout();
            this.tbpCopy.ResumeLayout(false);
            this.grpCopyTable.ResumeLayout(false);
            this.grpCopyTable.PerformLayout();
            this.tbpParameter.ResumeLayout(false);
            this.grpParameter.ResumeLayout(false);
            this.grpParameter.PerformLayout();
            this.grpBOMSetVerBtn.ResumeLayout(false);
            this.grpBOMSetVersion.ResumeLayout(false);
            this.grpBOMSetVersion.PerformLayout();
            this.pnlRecipeVersion.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        
        bool b_load_flag;
        
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
                
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this, txtResId, txtRecipe, null, null, null, false);
                    MPCF.ClearList(lisRecipe, true);
                    
                }
                else if (ProcStep == '2')
                {
                    MPCF.FieldClear(this, txtResId, txtRecipe, null, null, null, false);
                    MPCF.ClearList(lisRecipeVersion, true);
                    
                }
                else if (ProcStep == '3')
                {
                    MPCF.ClearList(lisParameter, true);
                    MPCF.FieldClear(grpParameter);
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
            if (lisResource.SelectedIndices.Count == 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                lisResource.Focus();
                return false;
            }
            if (lisRecipe.SelectedIndices.Count == 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(350));
                lisRecipe.Focus();
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "Update_Recipe_Version":

                    if (MPCF.CheckValue(txtRecipeVersion, 1, false, false,"", "", "") == false)
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
                case "Copy_Recipe_Version":

                    if (MPCF.CheckValue(txtRecipeVersion, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(txtToVersion, 1) == false)
                    {
                        return false;
                    }
                    break;
                case "Update_Para_Version":

                    if (MPCF.CheckValue(txtRecipeVersion, 1) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(txtSeqNum, 2) == false)
                    {
                        return false;
                    }

                    if (MPCF.CheckValue(txtParameterID, 1) == false)
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

                default:
                    
                    MPCF.ShowMsgBox("Invalid Case");
                    return false;
            }
            
            return true;
            
        }

        private bool CheckCondition(string FuncName)
        {
            if (lisResource.SelectedIndices.Count == 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                lisResource.Focus();
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "Load_Recipe_Version":

                    break;

                case "Load_Para_Version":
                    if (lisRecipe.SelectedIndices.Count == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(350));
                        lisRecipe.Focus();
                        return false;
                    }

                    if (MPCF.CheckValue(txtRecipeVersion, 1) == false)
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
        // View_Recipe_Version()
        //       - View Recipe Version Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Recipe_Version()
        {
            TRSNode in_node = new TRSNode("VIEW_RECIPE_VERSION_IN");
            TRSNode out_node = new TRSNode("VIEW_RECIPE_VERSION_OUT");

            try
            {
                MPCF.FieldClear(pnlRight);
                
                nudHour.Value = 0.0M;
                nudMinute.Value = 0.0M;
                nudSecond.Value = 0.0M;

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", lisResource.SelectedItems[0].Text);
                in_node.AddString("RECIPE", lisRecipe.SelectedItems[0].Text);
                in_node.AddInt("RECIPE_VERSION", MPCF.ToInt(lisRecipeVersion.SelectedItems[0].Text));

                if (MPCR.CallService("RCP", "RCP_View_Recipe_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtRecipeVersion.Text = MPCF.Trim(out_node.GetInt("RECIPE_VERSION"));

                txtPPId.Text = out_node.GetString("PP_ID");
                txtCoatPPID.Text = out_node.GetString("COAT_PP_ID");
                txtReticleID.Text = out_node.GetString("RETICLE_ID");
                cdvColSetID.Text = out_node.GetString("COL_SET_ID");
                if (out_node.GetString("PROC_TIME") != "")
                {
                    nudHour.Value = MPCF.ToInt(out_node.GetString("PROC_TIME").Substring(0, 2));
                    nudMinute.Value = MPCF.ToInt(out_node.GetString("PROC_TIME").Substring(2, 2));
                    nudSecond.Value = MPCF.ToInt(out_node.GetString("PROC_TIME").Substring(4, 2));
                }

                if (MPCF.Trim(out_node.GetChar("MODIFY_FLAG")) == "Y")
                {
                    chkModify.Checked = true;
                }
                else
                {
                    chkModify.Checked = false;
                }

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

                chkApprovalFlag.Checked = (MPCF.Trim(out_node.GetChar("APPROVAL_FLAG")) == "Y") ? true : false; ;
                txtApprovalUser.Text = MPCF.Trim(out_node.GetString("APPROVAL_USER_ID"));
                txtApprovalTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPROVAL_TIME"));
                chkReleaseFlag.Checked = (MPCF.Trim(out_node.GetChar("RELEASE_FLAG")) == "Y") ? true : false;
                txtReleaseUser.Text = MPCF.Trim(out_node.GetString("RELEASE_USER_ID"));
                txtReleaseTime.Text = MPCF.MakeDateFormat(out_node.GetString("RELEASE_TIME"));
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
        // Update_Recipe_Version()
        //       - Create/Update/Delete Recipe Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Recipe_Version(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_RECIPE_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("RES_ID", lisResource.SelectedItems[0].Text);
                in_node.AddString("RECIPE", lisRecipe.SelectedItems[0].Text);
                in_node.AddInt("RECIPE_VERSION", MPCF.ToInt(MPCF.Trim(txtRecipeVersion.Text)));

                in_node.AddString("PP_ID", MPCF.Trim(txtPPId.Text));
                in_node.AddString("COAT_PP_ID", MPCF.Trim(txtCoatPPID.Text));
                in_node.AddString("RETICLE_ID", MPCF.Trim(txtReticleID.Text));
                in_node.AddString("COL_SET_ID", MPCF.Trim(cdvColSetID.Text));
                in_node.AddChar("MODIFY_FLAG", (chkModify.Checked == true ? 'Y' : ' '));
                in_node.AddString("PROC_TIME", MPCF.Format("00", nudHour.Value) + MPCF.Format("00", nudMinute.Value) + MPCF.Format("00", nudSecond.Value));
                
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

                if (MPCR.CallService("RCP", "RCP_Update_Recipe_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisRecipeVersion.Items.Add(MPCF.Trim(txtRecipeVersion.Text), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
                        itm.Selected = true;
                        lisRecipeVersion.Sorting = SortOrder.Ascending;
                        lisRecipeVersion.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        //Do Nothing
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisRecipeVersion, MPCF.Trim(txtRecipeVersion.Text), false);
                        if (idx != - 1)
                        {
                            lisRecipeVersion.Items[idx].Remove();
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
        // Copy_Recipe_Version()
        //       - Copy Recipe Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Copy_Recipe_Version(char ProcStep)
        {
            ListViewItem itm;

            TRSNode in_node = new TRSNode("COPY_RECIPE_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("RES_ID", lisResource.SelectedItems[0].Text);
                in_node.AddString("RECIPE", lisRecipe.SelectedItems[0].Text);
                in_node.AddInt("RECIPE_VERSION", MPCF.ToInt(MPCF.Trim(txtRecipeVersion.Text)));
                in_node.AddInt("NEW_RECIPE_VERSION", MPCF.ToInt(MPCF.Trim(txtToVersion.Text)));

                if (MPCR.CallService("RCP", "RCP_Copy_Recipe_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_COPY)
                    {
                        itm = lisRecipeVersion.Items.Add(MPCF.Trim(txtToVersion.Text), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
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
        // View_Para_Version_List()
        //       - View Para Version List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Para_Version_List()
        {
            int i;
            int iDataCnt;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("VIEW_PARA_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_PARA_VERSION_LIST_OUT");

            try
            {
                
                MPCF.InitListView(lisParameter);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", lisResource.SelectedItems[0].Text);
                in_node.AddString("RECIPE", lisRecipe.SelectedItems[0].Text);
                in_node.AddInt("RECIPE_VERSION", MPCF.ToInt(lisRecipeVersion.SelectedItems[0].Text));

                if (MPCR.CallService("RCP", "RCP_View_Para_Version_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                //iDataCnt = out_node.GetList(0).Count;
                iDataCnt = out_node.GetList("URCP_PARA_LIST").Count;
                //for (i = 0; i <= iDataCnt - 1; i++)
                for (i = 0; i < iDataCnt ; i++)
                {

                    itmX = new ListViewItem(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetInt("PARA_SEQ")), (int)SMALLICON_INDEX.IDX_EVENT);

                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("PARA_ID")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("PARA_VALUE")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("PARA_DESC")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetChar("MODIFY_FLAG")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetDouble("CUS_MIN_VAL")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetDouble("CUS_MAX_VAL")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("CUS_UNIT")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("CREATE_USER_ID")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("CREATE_TIME")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("UPDATE_USER_ID")));
                    itmX.SubItems.Add(MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("UPDATE_TIME")));
                    
                    lisParameter.Items.Add(itmX);
                    
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        //
        // Update_Para_Version()
        //       - Create/Update/Delete Parameter Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Para_Version(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_PARA_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("RES_ID", lisResource.SelectedItems[0].Text);
                in_node.AddString("RECIPE", lisRecipe.SelectedItems[0].Text);
                in_node.AddInt("RECIPE_VERSION", MPCF.ToInt(MPCF.Trim(txtRecipeVersion.Text)));

                in_node.AddInt("PARA_SEQ", MPCF.ToInt(MPCF.Trim(txtSeqNum.Text)));
                in_node.AddString("PARA_ID", MPCF.Trim(txtParameterID.Text));
                in_node.AddString("PARA_VALUE", MPCF.Trim(txtValue.Text));
                in_node.AddString("PARA_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddChar("MODIFY_FLAG", (chkParaModifyFlag.Checked ? 'Y' : ' '));

                in_node.AddDouble("CUS_MIN_VAL", MPCF.ToDbl(MPCF.Trim(txtMinValue.Text)));
                in_node.AddDouble("CUS_MAX_VAL", MPCF.ToDbl(MPCF.Trim(txtMaxValue.Text)));
                in_node.AddString("CUS_UNIT", MPCF.Trim(txtUnit.Text));

                if (MPCR.CallService("CRCP", "CRCP_Update_Para_Version", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = new ListViewItem(MPCF.Trim(txtSeqNum.Text), (int)SMALLICON_INDEX.IDX_COL_SET_VERSION);
                        itm.SubItems.Add(MPCF.Trim(in_node.GetString("PARA_ID")));
                        itm.SubItems.Add(MPCF.Trim(in_node.GetString("PARA_VALUE")));
                        itm.SubItems.Add(MPCF.Trim(in_node.GetString("PARA_DESC")));
                        itm.SubItems.Add(MPCF.Trim(in_node.GetChar("MODIFY_FLAG")));
                        //itm.SubItems.Add(RTrim(Update_Para_Version_In._C.create_user_id))
                        //itm.SubItems.Add(RTrim(Update_Para_Version_In._C.create_time))
                        //itm.SubItems.Add(RTrim(Update_Para_Version_In._C.update_user_id))
                        //itm.SubItems.Add(RTrim(Update_Para_Version_In._C.update_time))
                        lisParameter.Items.Add(itm);
                        itm.Selected = true;
                        lisRecipeVersion.Sorting = SortOrder.Ascending;
                        lisRecipeVersion.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisParameter, MPCF.Trim(txtSeqNum.Text), false);
                        if (idx != - 1)
                        {
                            lisParameter.Items[idx].Remove();
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
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisResource;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }

        private bool Load_Recipe_Version()
        {
            TRSNode in_node = new TRSNode("LOAD_RECIPE_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", lisResource.SelectedItems[0].Text);
                in_node.AddString("ACTION_TYPE", 'L');

                if (MPCR.CallService("CEIS", "MESEAP_Remote_Request_MesToEap", in_node, ref out_node) == false)
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

        private bool Load_Para_Version()
        {
            TRSNode in_node = new TRSNode("LOAD_PARA_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", lisResource.SelectedItems[0].Text);
                in_node.AddString("ACTION_TYPE", 'P');
                in_node.AddString("RECIPE_ID", lisRecipe.SelectedItems[0].Text);
                in_node.AddString("RECIPE_VERSION", MPCF.Trim(txtRecipeVersion.Text));
                in_node.AddInt("MES_RECIPE_VERSION", MPCF.ToInt(MPCF.Trim(txtRecipeVersion.Text)));
                in_node.AddString("RECIPE_ID", lisRecipe.SelectedItems[0].Text);

                in_node.AddString("PP_ID", MPCF.Trim(txtPPId.Text));

                if (MPCR.CallService("CEIS", "MESEAP_Remote_Request_MesToEap", in_node, ref out_node) == false)
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

        #endregion
        
        private void frmRCPSetupRecipeVersion_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    lblDataCount.Text = "";
                    #if _RAS
                    //if (RASLIST.ViewResourceList(lisResource, false) == true)
                    if (RASLIST.ViewResourceListForRecipe(lisResource, '7') == true)
                    {
                        lblDataCount.Text = lisResource.Items.Count.ToString();
                    }
                    else
                    {
                        return;
                    }
                    #endif
                    if (lisResource.Items.Count > 0)
                    {
                        lisResource.Items[0].Selected = true;
                    }

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmRCPSetupRecipeVersion_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this);
                MPCF.InitListView(lisResource);
                MPCF.InitListView(lisRecipe);
                
                //Initialize ListView
                
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
                if (CheckCondition("Update_Recipe_Version", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Recipe_Version(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (RCPLIST.ViewRecipeVersionList(lisRecipeVersion, '1', lisResource.SelectedItems[0].Text, lisRecipe.SelectedItems[0].Text, null, "") == false)
                        {
                            return;
                        }
                        if (lisRecipeVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisRecipeVersion, txtRecipeVersion.Text, false);
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
                if (CheckCondition("Update_Recipe_Version", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Recipe_Version(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (RCPLIST.ViewRecipeVersionList(lisRecipeVersion, '1', lisResource.SelectedItems[0].Text, lisRecipe.SelectedItems[0].Text, null, "") == false)
                        {
                            return;
                        }
                        if (lisRecipeVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisRecipeVersion, txtRecipeVersion.Text, false);
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
                if (CheckCondition("Update_Recipe_Version", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Recipe_Version(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    ClearData('2');
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (RCPLIST.ViewRecipeVersionList(lisRecipeVersion, '1', lisResource.SelectedItems[0].Text, lisRecipe.SelectedItems[0].Text, null, "") == false)
                        {
                            return;
                        }
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
                #if _RAS
                //if (RASLIST.ViewResourceList(lisResource, false) == true)
                if (RASLIST.ViewResourceListForRecipe(lisResource, '7') == true)
                {
                    if (lisResource.Items.Count > 0)
                    {
                        MPCF.FindListItem(lisResource, txtResId.Text, false);
                    }
                }
                #endif
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.ExportToExcel(lisResource, this.Text, "");
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("Load_Recipe_Version") == true)
                {
                    if (Load_Recipe_Version() == false)
                    {
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void lisResource_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisResource.SelectedIndices.Count > 0)
                {
                    MPCF.FieldClear(this);
                    ClearData('3');

                    txtResId.Text = lisResource.SelectedItems[0].Text;
                    if (RCPLIST.ViewRecipeList(lisRecipe, '1', lisResource.SelectedItems[0].Text, "", null, "", -1, -1) == false)
                    {
                        return;
                    }
                    MPCF.InitListView(lisRecipeVersion);
                    if (lisRecipe.Items.Count > 0)
                    {
                        lisRecipe.Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisRecipe_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisResource.SelectedIndices.Count > 0)
                {
                    if (lisRecipe.SelectedIndices.Count > 0)
                    {
                        txtRecipe.Text = lisRecipe.SelectedItems[0].Text;
                        ClearData('2');
                        ClearData('3');
                        if (RCPLIST.ViewRecipeVersionList(lisRecipeVersion, '1', txtResId.Text, txtRecipe.Text, null, "") == false)
                        {
                            return;
                        }
                        if (lisRecipeVersion.Items.Count > 0)
                        {
                            lisRecipeVersion.Items[0].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisRecipeversion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (lisRecipeVersion.SelectedIndices.Count > 0)
                {
                    
                    View_Recipe_Version();
                    
                    View_Para_Version_List();
                    
                    if (lisParameter.Items.Count > 0)
                    {
                        lisParameter.Items[0].Selected = true;
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

            MPCF.FindListItemNextPartial(lisResource, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemPartial(lisResource, txtFind.Text, 0, true, false);
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("Copy_Recipe_Version", MPGC.MP_STEP_COPY) == true)
                {
                    if (Copy_Recipe_Version(MPGC.MP_STEP_COPY) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (RCPLIST.ViewRecipeVersionList(lisRecipeVersion, '1', lisResource.SelectedItems[0].Text, lisRecipe.SelectedItems[0].Text, null, "") == false)
                        {
                            return;
                        }
                        if (lisRecipeVersion.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisRecipeVersion, txtToVersion.Text, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void lisParameter_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (lisParameter.SelectedIndices.Count > 0)
                {
                    txtSeqNum.Text = lisParameter.SelectedItems[0].SubItems[0].Text;
                    txtParameterID.Text = lisParameter.SelectedItems[0].SubItems[1].Text;
                    txtValue.Text = lisParameter.SelectedItems[0].SubItems[2].Text;
                    txtDesc.Text = lisParameter.SelectedItems[0].SubItems[3].Text;
                    chkParaModifyFlag.Checked = (MPCF.Trim(lisParameter.SelectedItems[0].SubItems[4].Text) == "Y") ? true : false;

                    txtMinValue.Text = lisParameter.SelectedItems[0].SubItems[5].Text;
                    txtMaxValue.Text = lisParameter.SelectedItems[0].SubItems[6].Text;
                    txtUnit.Text = lisParameter.SelectedItems[0].SubItems[7].Text;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void tabVersion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            if (!(tabVersion.SelectedTab == tbpParameter))
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
        
        private void btnVerCreate_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("Update_Para_Version", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Para_Version(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (View_Para_Version_List() == false)
                        {
                            return;
                        }
                        if (lisParameter.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisParameter, txtSeqNum.Text, false);
                        }
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
                if (CheckCondition("Update_Para_Version", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Para_Version(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (View_Para_Version_List() == false)
                        {
                            return;
                        }
                        if (lisParameter.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisParameter, txtSeqNum.Text, false);
                        }
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
                if (CheckCondition("Update_Para_Version", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Para_Version(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    ClearData('3');
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (View_Para_Version_List() == false)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnVerLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("Load_Para_Version") == true)
                {
                    if (Load_Para_Version() == false)
                    {
                        return;
                    }

                    /*
                    ClearData('3');
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (View_Para_Version_List() == false)
                        {
                            return;
                        }
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
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
        
        private void cdvColSetID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvColSetID.Init();
            MPCF.InitListView(cdvColSetID.GetListView);
            cdvColSetID.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
            cdvColSetID.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvColSetID.SelectedSubItemIndex = 0;
            #if _EDC
            if (EDCLIST.ViewEDCColSetList(cdvColSetID.GetListView, '1', null, "", -1, -1, ' ', false) == false)
            {
                return;
            }
            #endif
        }






        
    }
    //#End If
}
