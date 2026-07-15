
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
//   File Name   : frmRASSetupResource.vb
//   Description : Resource Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetGroupCmfItem() : Set Group/Cmf property to control
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - Update_Resource() : Create/Update/Delete Resource
//       - View_Resource() : Find Resource and View Resource
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-09 : Created by H.K. Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASSetupResource : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupResource()
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
        



        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblResource;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtResource;
        private System.Windows.Forms.GroupBox grpResource;
        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.TabControl tabResource;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.ComboBox cboProcMode;
        private System.Windows.Forms.Label lblProcMode;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.CheckBox chkSecChkFlag;
        private System.Windows.Forms.CheckBox chkUnitBaseStFlag;
        private System.Windows.Forms.CheckBox chkPMSchEnableFlag;
        private System.Windows.Forms.TextBox txtMaxProcCount;
        private System.Windows.Forms.Label lblMaxProcCount;
        private System.Windows.Forms.ComboBox cboProcRule;
        private System.Windows.Forms.Label lblProcRule;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubAreaID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAreaID;
        private System.Windows.Forms.Label lblSubAreaID;
        private System.Windows.Forms.Label lblAreaID;
        private System.Windows.Forms.Label lblResType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResGrp1;
        private System.Windows.Forms.Label lblResGrp10;
        private System.Windows.Forms.Label lblResGrp9;
        private System.Windows.Forms.Label lblResGrp8;
        private System.Windows.Forms.Label lblResGrp7;
        private System.Windows.Forms.Label lblResGrp6;
        private System.Windows.Forms.Label lblResGrp5;
        private System.Windows.Forms.Label lblResGrp4;
        private System.Windows.Forms.Label lblResGrp3;
        private System.Windows.Forms.Label lblResGrp2;
        private System.Windows.Forms.Label lblResGrp1;
        private System.Windows.Forms.TabPage tbpResStatus;
        private System.Windows.Forms.GroupBox grpResPrompt;
        private System.Windows.Forms.CheckBox chkUseFacPrtFlag;
        private System.Windows.Forms.Label lblResPrompt10;
        private System.Windows.Forms.Label lblResPrompt9;
        private System.Windows.Forms.Label lblResPrompt8;
        private System.Windows.Forms.Label lblResPrompt7;
        private System.Windows.Forms.Label lblResPrompt6;
        private System.Windows.Forms.Label lblResPrompt5;
        private System.Windows.Forms.Label lblResPrompt4;
        private System.Windows.Forms.Label lblResPrompt3;
        private System.Windows.Forms.Label lblResPrompt2;
        private System.Windows.Forms.Label lblResPrompt1;
        private System.Windows.Forms.TextBox txtResPrompt10;
        private System.Windows.Forms.TextBox txtResPrompt9;
        private System.Windows.Forms.TextBox txtResPrompt8;
        private System.Windows.Forms.TextBox txtResPrompt7;
        private System.Windows.Forms.TextBox txtResPrompt6;
        private System.Windows.Forms.TextBox txtResPrompt5;
        private System.Windows.Forms.TextBox txtResPrompt4;
        private System.Windows.Forms.TextBox txtResPrompt3;
        private System.Windows.Forms.TextBox txtResPrompt2;
        private System.Windows.Forms.TextBox txtResPrompt1;
        private System.Windows.Forms.TabPage tbpCMF;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResType;
        private System.Windows.Forms.TabPage tbpGroup;
        private System.Windows.Forms.GroupBox grpGroup;
        private System.Windows.Forms.CheckBox chkDeleteRes;
        private System.Windows.Forms.ComboBox cboCtrlMode;
        private System.Windows.Forms.Label lblCtrlMode;
        private System.Windows.Forms.CheckBox chkChamberFlag;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChamberGroup;
        private System.Windows.Forms.Label lblChamberGroup;
        private Miracom.UI.Controls.MCListView.MCListView lisResource;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private GroupBox grpCMF;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF19;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF18;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF17;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF16;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF15;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF14;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF13;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF12;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF20;
        protected Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF11;
        protected Label lblCMF20;
        protected Label lblCMF19;
        protected Label lblCMF18;
        protected Label lblCMF17;
        protected Label lblCMF16;
        protected Label lblCMF15;
        protected Label lblCMF14;
        protected Label lblCMF13;
        protected Label lblCMF12;
        protected Label lblCMF11;
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
        protected Label lblCMF10;
        protected Label lblCMF9;
        protected Label lblCMF8;
        protected Label lblCMF7;
        protected Label lblCMF6;
        protected Label lblCMF5;
        protected Label lblCMF4;
        protected Label lblCMF3;
        protected Label lblCMF2;
        protected Label lblCMF1;
        private TabPage tabAttribute;
        private Miracom.BASCore.udcAttributeStatus udcAttributeStatus;
        private Label lblShortDesc;
        private TextBox txtShortDesc;
        private CheckBox chkRegisterAlarm;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpResource = new System.Windows.Forms.GroupBox();
            this.lblShortDesc = new System.Windows.Forms.Label();
            this.txtShortDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtResource = new System.Windows.Forms.TextBox();
            this.pnlType = new System.Windows.Forms.Panel();
            this.chkDeleteRes = new System.Windows.Forms.CheckBox();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.tabResource = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.chkRegisterAlarm = new System.Windows.Forms.CheckBox();
            this.cboCtrlMode = new System.Windows.Forms.ComboBox();
            this.lblCtrlMode = new System.Windows.Forms.Label();
            this.cdvResType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cboProcMode = new System.Windows.Forms.ComboBox();
            this.lblProcMode = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.chkSecChkFlag = new System.Windows.Forms.CheckBox();
            this.chkUnitBaseStFlag = new System.Windows.Forms.CheckBox();
            this.chkPMSchEnableFlag = new System.Windows.Forms.CheckBox();
            this.txtMaxProcCount = new System.Windows.Forms.TextBox();
            this.lblMaxProcCount = new System.Windows.Forms.Label();
            this.cboProcRule = new System.Windows.Forms.ComboBox();
            this.lblProcRule = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cdvSubAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubAreaID = new System.Windows.Forms.Label();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.lblResType = new System.Windows.Forms.Label();
            this.chkChamberFlag = new System.Windows.Forms.CheckBox();
            this.cdvChamberGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChamberGroup = new System.Windows.Forms.Label();
            this.tbpResStatus = new System.Windows.Forms.TabPage();
            this.grpResPrompt = new System.Windows.Forms.GroupBox();
            this.chkUseFacPrtFlag = new System.Windows.Forms.CheckBox();
            this.lblResPrompt10 = new System.Windows.Forms.Label();
            this.lblResPrompt9 = new System.Windows.Forms.Label();
            this.lblResPrompt8 = new System.Windows.Forms.Label();
            this.lblResPrompt7 = new System.Windows.Forms.Label();
            this.lblResPrompt6 = new System.Windows.Forms.Label();
            this.lblResPrompt5 = new System.Windows.Forms.Label();
            this.lblResPrompt4 = new System.Windows.Forms.Label();
            this.lblResPrompt3 = new System.Windows.Forms.Label();
            this.lblResPrompt2 = new System.Windows.Forms.Label();
            this.lblResPrompt1 = new System.Windows.Forms.Label();
            this.txtResPrompt10 = new System.Windows.Forms.TextBox();
            this.txtResPrompt9 = new System.Windows.Forms.TextBox();
            this.txtResPrompt8 = new System.Windows.Forms.TextBox();
            this.txtResPrompt7 = new System.Windows.Forms.TextBox();
            this.txtResPrompt6 = new System.Windows.Forms.TextBox();
            this.txtResPrompt5 = new System.Windows.Forms.TextBox();
            this.txtResPrompt4 = new System.Windows.Forms.TextBox();
            this.txtResPrompt3 = new System.Windows.Forms.TextBox();
            this.txtResPrompt2 = new System.Windows.Forms.TextBox();
            this.txtResPrompt1 = new System.Windows.Forms.TextBox();
            this.tbpGroup = new System.Windows.Forms.TabPage();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cdvResGrp10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGrp9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGrp8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGrp7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGrp6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGrp5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGrp4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGrp3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGrp2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvResGrp1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResGrp10 = new System.Windows.Forms.Label();
            this.lblResGrp9 = new System.Windows.Forms.Label();
            this.lblResGrp8 = new System.Windows.Forms.Label();
            this.lblResGrp7 = new System.Windows.Forms.Label();
            this.lblResGrp6 = new System.Windows.Forms.Label();
            this.lblResGrp5 = new System.Windows.Forms.Label();
            this.lblResGrp4 = new System.Windows.Forms.Label();
            this.lblResGrp3 = new System.Windows.Forms.Label();
            this.lblResGrp2 = new System.Windows.Forms.Label();
            this.lblResGrp1 = new System.Windows.Forms.Label();
            this.tabAttribute = new System.Windows.Forms.TabPage();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.cdvCMF19 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF18 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF17 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF16 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF15 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF14 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF13 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF12 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF20 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF11 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF20 = new System.Windows.Forms.Label();
            this.lblCMF19 = new System.Windows.Forms.Label();
            this.lblCMF18 = new System.Windows.Forms.Label();
            this.lblCMF17 = new System.Windows.Forms.Label();
            this.lblCMF16 = new System.Windows.Forms.Label();
            this.lblCMF15 = new System.Windows.Forms.Label();
            this.lblCMF14 = new System.Windows.Forms.Label();
            this.lblCMF13 = new System.Windows.Forms.Label();
            this.lblCMF12 = new System.Windows.Forms.Label();
            this.lblCMF11 = new System.Windows.Forms.Label();
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
            this.lisResource = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpResource.SuspendLayout();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.pnlGeneral.SuspendLayout();
            this.tabResource.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChamberGroup)).BeginInit();
            this.tbpResStatus.SuspendLayout();
            this.grpResPrompt.SuspendLayout();
            this.tbpGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp1)).BeginInit();
            this.tabAttribute.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).BeginInit();
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
            this.pnlRight.Controls.Add(this.pnlGeneral);
            this.pnlRight.Controls.Add(this.grpResource);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisResource);
            this.pnlLeft.Controls.Add(this.pnlType);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Resource Setup";
            // 
            // grpResource
            // 
            this.grpResource.Controls.Add(this.lblShortDesc);
            this.grpResource.Controls.Add(this.txtShortDesc);
            this.grpResource.Controls.Add(this.lblDesc);
            this.grpResource.Controls.Add(this.lblResource);
            this.grpResource.Controls.Add(this.txtDesc);
            this.grpResource.Controls.Add(this.txtResource);
            this.grpResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResource.Location = new System.Drawing.Point(3, 0);
            this.grpResource.Name = "grpResource";
            this.grpResource.Size = new System.Drawing.Size(500, 91);
            this.grpResource.TabIndex = 0;
            this.grpResource.TabStop = false;
            // 
            // lblShortDesc
            // 
            this.lblShortDesc.AutoSize = true;
            this.lblShortDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShortDesc.Location = new System.Drawing.Point(15, 43);
            this.lblShortDesc.Name = "lblShortDesc";
            this.lblShortDesc.Size = new System.Drawing.Size(88, 13);
            this.lblShortDesc.TabIndex = 2;
            this.lblShortDesc.Text = "Short Description";
            // 
            // txtShortDesc
            // 
            this.txtShortDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortDesc.Location = new System.Drawing.Point(142, 40);
            this.txtShortDesc.MaxLength = 50;
            this.txtShortDesc.Name = "txtShortDesc";
            this.txtShortDesc.Size = new System.Drawing.Size(348, 20);
            this.txtShortDesc.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 67);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResource.Location = new System.Drawing.Point(15, 19);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(61, 13);
            this.lblResource.TabIndex = 0;
            this.lblResource.Text = "Resource";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(142, 64);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(348, 20);
            this.txtDesc.TabIndex = 5;
            // 
            // txtResource
            // 
            this.txtResource.Location = new System.Drawing.Point(142, 16);
            this.txtResource.MaxLength = 20;
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(200, 20);
            this.txtResource.TabIndex = 1;
            this.txtResource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResource_KeyPress);
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.chkDeleteRes);
            this.pnlType.Controls.Add(this.cdvType);
            this.pnlType.Controls.Add(this.lblType);
            this.pnlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlType.Location = new System.Drawing.Point(3, 0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(229, 47);
            this.pnlType.TabIndex = 0;
            // 
            // chkDeleteRes
            // 
            this.chkDeleteRes.AutoSize = true;
            this.chkDeleteRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDeleteRes.Location = new System.Drawing.Point(6, 29);
            this.chkDeleteRes.Name = "chkDeleteRes";
            this.chkDeleteRes.Size = new System.Drawing.Size(150, 18);
            this.chkDeleteRes.TabIndex = 2;
            this.chkDeleteRes.Text = "Include Delete Resource";
            this.chkDeleteRes.CheckedChanged += new System.EventHandler(this.chkDeleteRes_CheckedChanged);
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.ButtonWidth = 20;
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(92, 6);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.MultiSelect = false;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SameWidthHeightOfButton = false;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedDescToQueryText = "";
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectedValueToQueryText = "";
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(132, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 132;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvType_SelectedItemChanged);
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Location = new System.Drawing.Point(6, 9);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Resource Type";
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.tabResource);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(3, 91);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlGeneral.Size = new System.Drawing.Size(500, 419);
            this.pnlGeneral.TabIndex = 1;
            // 
            // tabResource
            // 
            this.tabResource.Controls.Add(this.tbpGeneral);
            this.tabResource.Controls.Add(this.tbpResStatus);
            this.tabResource.Controls.Add(this.tbpGroup);
            this.tabResource.Controls.Add(this.tabAttribute);
            this.tabResource.Controls.Add(this.tbpCMF);
            this.tabResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResource.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResource.Location = new System.Drawing.Point(0, 5);
            this.tabResource.Name = "tabResource";
            this.tabResource.SelectedIndex = 0;
            this.tabResource.Size = new System.Drawing.Size(500, 414);
            this.tabResource.TabIndex = 0;
            this.tabResource.TabStop = false;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 388);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.chkRegisterAlarm);
            this.grpGeneral.Controls.Add(this.cboCtrlMode);
            this.grpGeneral.Controls.Add(this.lblCtrlMode);
            this.grpGeneral.Controls.Add(this.cdvResType);
            this.grpGeneral.Controls.Add(this.cboProcMode);
            this.grpGeneral.Controls.Add(this.lblProcMode);
            this.grpGeneral.Controls.Add(this.lblUpdateTime);
            this.grpGeneral.Controls.Add(this.lblUpdateUser);
            this.grpGeneral.Controls.Add(this.lblCreateTime);
            this.grpGeneral.Controls.Add(this.lblCreateUser);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.txtCreateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.txtCreateUser);
            this.grpGeneral.Controls.Add(this.chkSecChkFlag);
            this.grpGeneral.Controls.Add(this.chkUnitBaseStFlag);
            this.grpGeneral.Controls.Add(this.chkPMSchEnableFlag);
            this.grpGeneral.Controls.Add(this.txtMaxProcCount);
            this.grpGeneral.Controls.Add(this.lblMaxProcCount);
            this.grpGeneral.Controls.Add(this.cboProcRule);
            this.grpGeneral.Controls.Add(this.lblProcRule);
            this.grpGeneral.Controls.Add(this.txtLocation);
            this.grpGeneral.Controls.Add(this.lblLocation);
            this.grpGeneral.Controls.Add(this.cdvSubAreaID);
            this.grpGeneral.Controls.Add(this.cdvAreaID);
            this.grpGeneral.Controls.Add(this.lblSubAreaID);
            this.grpGeneral.Controls.Add(this.lblAreaID);
            this.grpGeneral.Controls.Add(this.lblResType);
            this.grpGeneral.Controls.Add(this.chkChamberFlag);
            this.grpGeneral.Controls.Add(this.cdvChamberGroup);
            this.grpGeneral.Controls.Add(this.lblChamberGroup);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(486, 385);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Enter += new System.EventHandler(this.grpGeneral_Enter);
            // 
            // chkRegisterAlarm
            // 
            this.chkRegisterAlarm.AutoSize = true;
            this.chkRegisterAlarm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRegisterAlarm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkRegisterAlarm.Location = new System.Drawing.Point(290, 216);
            this.chkRegisterAlarm.Name = "chkRegisterAlarm";
            this.chkRegisterAlarm.Size = new System.Drawing.Size(164, 18);
            this.chkRegisterAlarm.TabIndex = 17;
            this.chkRegisterAlarm.Text = "Register Alarm automatically";
            // 
            // cboCtrlMode
            // 
            this.cboCtrlMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCtrlMode.Items.AddRange(new object[] {
            "ONLINE LOCAL",
            "ONLINE REMOTE",
            "OFFLINE"});
            this.cboCtrlMode.Location = new System.Drawing.Point(136, 188);
            this.cboCtrlMode.Name = "cboCtrlMode";
            this.cboCtrlMode.Size = new System.Drawing.Size(133, 21);
            this.cboCtrlMode.TabIndex = 15;
            // 
            // lblCtrlMode
            // 
            this.lblCtrlMode.AutoSize = true;
            this.lblCtrlMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCtrlMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCtrlMode.Location = new System.Drawing.Point(14, 192);
            this.lblCtrlMode.Name = "lblCtrlMode";
            this.lblCtrlMode.Size = new System.Drawing.Size(70, 13);
            this.lblCtrlMode.TabIndex = 14;
            this.lblCtrlMode.Text = "Control Mode";
            // 
            // cdvResType
            // 
            this.cdvResType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResType.BtnToolTipText = "";
            this.cdvResType.ButtonWidth = 20;
            this.cdvResType.DescText = "";
            this.cdvResType.DisplaySubItemIndex = -1;
            this.cdvResType.DisplayText = "";
            this.cdvResType.Focusing = null;
            this.cdvResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResType.Index = 0;
            this.cdvResType.IsViewBtnImage = false;
            this.cdvResType.Location = new System.Drawing.Point(136, 16);
            this.cdvResType.MaxLength = 20;
            this.cdvResType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResType.MultiSelect = false;
            this.cdvResType.Name = "cdvResType";
            this.cdvResType.ReadOnly = false;
            this.cdvResType.SameWidthHeightOfButton = false;
            this.cdvResType.SearchSubItemIndex = 0;
            this.cdvResType.SelectedDescIndex = -1;
            this.cdvResType.SelectedDescToQueryText = "";
            this.cdvResType.SelectedSubItemIndex = -1;
            this.cdvResType.SelectedValueToQueryText = "";
            this.cdvResType.SelectionStart = 0;
            this.cdvResType.Size = new System.Drawing.Size(133, 20);
            this.cdvResType.SmallImageList = null;
            this.cdvResType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResType.TabIndex = 1;
            this.cdvResType.TextBoxToolTipText = "";
            this.cdvResType.TextBoxWidth = 133;
            this.cdvResType.VisibleButton = true;
            this.cdvResType.VisibleColumnHeader = false;
            this.cdvResType.VisibleDescription = false;
            this.cdvResType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // cboProcMode
            // 
            this.cboProcMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcMode.Items.AddRange(new object[] {
            "MANUAL",
            "SEMI AUTO",
            "FULL AUTO"});
            this.cboProcMode.Location = new System.Drawing.Point(136, 162);
            this.cboProcMode.Name = "cboProcMode";
            this.cboProcMode.Size = new System.Drawing.Size(133, 21);
            this.cboProcMode.TabIndex = 13;
            // 
            // lblProcMode
            // 
            this.lblProcMode.AutoSize = true;
            this.lblProcMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcMode.Location = new System.Drawing.Point(13, 166);
            this.lblProcMode.Name = "lblProcMode";
            this.lblProcMode.Size = new System.Drawing.Size(75, 13);
            this.lblProcMode.TabIndex = 12;
            this.lblProcMode.Text = "Process Mode";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(13, 348);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 26;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(13, 324);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 24;
            this.lblUpdateUser.Text = "Update User";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(13, 300);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 22;
            this.lblCreateTime.Text = "Create Time";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(13, 276);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 20;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(136, 346);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateTime.TabIndex = 27;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(136, 298);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(133, 20);
            this.txtCreateTime.TabIndex = 23;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(136, 322);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateUser.TabIndex = 25;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(136, 274);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(133, 20);
            this.txtCreateUser.TabIndex = 21;
            this.txtCreateUser.TabStop = false;
            // 
            // chkSecChkFlag
            // 
            this.chkSecChkFlag.AutoSize = true;
            this.chkSecChkFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSecChkFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSecChkFlag.Location = new System.Drawing.Point(14, 256);
            this.chkSecChkFlag.Name = "chkSecChkFlag";
            this.chkSecChkFlag.Size = new System.Drawing.Size(127, 18);
            this.chkSecChkFlag.TabIndex = 19;
            this.chkSecChkFlag.Text = "Security Check Flag";
            // 
            // chkUnitBaseStFlag
            // 
            this.chkUnitBaseStFlag.AutoSize = true;
            this.chkUnitBaseStFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUnitBaseStFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUnitBaseStFlag.Location = new System.Drawing.Point(14, 236);
            this.chkUnitBaseStFlag.Name = "chkUnitBaseStFlag";
            this.chkUnitBaseStFlag.Size = new System.Drawing.Size(147, 18);
            this.chkUnitBaseStFlag.TabIndex = 18;
            this.chkUnitBaseStFlag.Text = "Unit Base Standard Flag";
            // 
            // chkPMSchEnableFlag
            // 
            this.chkPMSchEnableFlag.AutoSize = true;
            this.chkPMSchEnableFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkPMSchEnableFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPMSchEnableFlag.Location = new System.Drawing.Point(14, 216);
            this.chkPMSchEnableFlag.Name = "chkPMSchEnableFlag";
            this.chkPMSchEnableFlag.Size = new System.Drawing.Size(155, 18);
            this.chkPMSchEnableFlag.TabIndex = 16;
            this.chkPMSchEnableFlag.Text = "PM Schedule Enable Flag";
            // 
            // txtMaxProcCount
            // 
            this.txtMaxProcCount.Location = new System.Drawing.Point(136, 112);
            this.txtMaxProcCount.MaxLength = 3;
            this.txtMaxProcCount.Name = "txtMaxProcCount";
            this.txtMaxProcCount.Size = new System.Drawing.Size(133, 20);
            this.txtMaxProcCount.TabIndex = 9;
            this.txtMaxProcCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxProcCount_KeyPress);
            // 
            // lblMaxProcCount
            // 
            this.lblMaxProcCount.AutoSize = true;
            this.lblMaxProcCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxProcCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxProcCount.Location = new System.Drawing.Point(13, 114);
            this.lblMaxProcCount.Name = "lblMaxProcCount";
            this.lblMaxProcCount.Size = new System.Drawing.Size(83, 13);
            this.lblMaxProcCount.TabIndex = 8;
            this.lblMaxProcCount.Text = "Max Proc Count";
            // 
            // cboProcRule
            // 
            this.cboProcRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcRule.Items.AddRange(new object[] {
            "NORMAL",
            "SERIAL",
            "BATCH"});
            this.cboProcRule.Location = new System.Drawing.Point(136, 136);
            this.cboProcRule.Name = "cboProcRule";
            this.cboProcRule.Size = new System.Drawing.Size(133, 21);
            this.cboProcRule.TabIndex = 11;
            // 
            // lblProcRule
            // 
            this.lblProcRule.AutoSize = true;
            this.lblProcRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcRule.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcRule.Location = new System.Drawing.Point(13, 140);
            this.lblProcRule.Name = "lblProcRule";
            this.lblProcRule.Size = new System.Drawing.Size(70, 13);
            this.lblProcRule.TabIndex = 10;
            this.lblProcRule.Text = "Process Rule";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(136, 88);
            this.txtLocation.MaxLength = 20;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(133, 20);
            this.txtLocation.TabIndex = 7;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation.Location = new System.Drawing.Point(13, 92);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 6;
            this.lblLocation.Text = "Location";
            // 
            // cdvSubAreaID
            // 
            this.cdvSubAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubAreaID.BtnToolTipText = "";
            this.cdvSubAreaID.ButtonWidth = 20;
            this.cdvSubAreaID.DescText = "";
            this.cdvSubAreaID.DisplaySubItemIndex = -1;
            this.cdvSubAreaID.DisplayText = "";
            this.cdvSubAreaID.Focusing = null;
            this.cdvSubAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubAreaID.Index = 0;
            this.cdvSubAreaID.IsViewBtnImage = false;
            this.cdvSubAreaID.Location = new System.Drawing.Point(136, 64);
            this.cdvSubAreaID.MaxLength = 20;
            this.cdvSubAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.MultiSelect = false;
            this.cdvSubAreaID.Name = "cdvSubAreaID";
            this.cdvSubAreaID.ReadOnly = false;
            this.cdvSubAreaID.SameWidthHeightOfButton = false;
            this.cdvSubAreaID.SearchSubItemIndex = 0;
            this.cdvSubAreaID.SelectedDescIndex = -1;
            this.cdvSubAreaID.SelectedDescToQueryText = "";
            this.cdvSubAreaID.SelectedSubItemIndex = -1;
            this.cdvSubAreaID.SelectedValueToQueryText = "";
            this.cdvSubAreaID.SelectionStart = 0;
            this.cdvSubAreaID.Size = new System.Drawing.Size(133, 20);
            this.cdvSubAreaID.SmallImageList = null;
            this.cdvSubAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubAreaID.TabIndex = 5;
            this.cdvSubAreaID.TextBoxToolTipText = "";
            this.cdvSubAreaID.TextBoxWidth = 133;
            this.cdvSubAreaID.VisibleButton = true;
            this.cdvSubAreaID.VisibleColumnHeader = false;
            this.cdvSubAreaID.VisibleDescription = false;
            this.cdvSubAreaID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSubAreaID_SelectedItemChanged);
            this.cdvSubAreaID.ButtonPress += new System.EventHandler(this.cdvSubAreaID_ButtonPress);
            // 
            // cdvAreaID
            // 
            this.cdvAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAreaID.BtnToolTipText = "";
            this.cdvAreaID.ButtonWidth = 20;
            this.cdvAreaID.DescText = "";
            this.cdvAreaID.DisplaySubItemIndex = -1;
            this.cdvAreaID.DisplayText = "";
            this.cdvAreaID.Focusing = null;
            this.cdvAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAreaID.Index = 0;
            this.cdvAreaID.IsViewBtnImage = false;
            this.cdvAreaID.Location = new System.Drawing.Point(136, 40);
            this.cdvAreaID.MaxLength = 20;
            this.cdvAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.MultiSelect = false;
            this.cdvAreaID.Name = "cdvAreaID";
            this.cdvAreaID.ReadOnly = false;
            this.cdvAreaID.SameWidthHeightOfButton = false;
            this.cdvAreaID.SearchSubItemIndex = 0;
            this.cdvAreaID.SelectedDescIndex = -1;
            this.cdvAreaID.SelectedDescToQueryText = "";
            this.cdvAreaID.SelectedSubItemIndex = -1;
            this.cdvAreaID.SelectedValueToQueryText = "";
            this.cdvAreaID.SelectionStart = 0;
            this.cdvAreaID.Size = new System.Drawing.Size(133, 20);
            this.cdvAreaID.SmallImageList = null;
            this.cdvAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAreaID.TabIndex = 3;
            this.cdvAreaID.TextBoxToolTipText = "";
            this.cdvAreaID.TextBoxWidth = 133;
            this.cdvAreaID.VisibleButton = true;
            this.cdvAreaID.VisibleColumnHeader = false;
            this.cdvAreaID.VisibleDescription = false;
            this.cdvAreaID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAreaID_SelectedItemChanged);
            this.cdvAreaID.ButtonPress += new System.EventHandler(this.cdvAreaID_ButtonPress);
            // 
            // lblSubAreaID
            // 
            this.lblSubAreaID.AutoSize = true;
            this.lblSubAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubAreaID.Location = new System.Drawing.Point(13, 67);
            this.lblSubAreaID.Name = "lblSubAreaID";
            this.lblSubAreaID.Size = new System.Drawing.Size(76, 13);
            this.lblSubAreaID.TabIndex = 4;
            this.lblSubAreaID.Text = "Sub Area ID";
            // 
            // lblAreaID
            // 
            this.lblAreaID.AutoSize = true;
            this.lblAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAreaID.Location = new System.Drawing.Point(13, 43);
            this.lblAreaID.Name = "lblAreaID";
            this.lblAreaID.Size = new System.Drawing.Size(50, 13);
            this.lblAreaID.TabIndex = 2;
            this.lblAreaID.Text = "Area ID";
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResType.Location = new System.Drawing.Point(13, 19);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(93, 13);
            this.lblResType.TabIndex = 0;
            this.lblResType.Text = "Resource Type";
            // 
            // chkChamberFlag
            // 
            this.chkChamberFlag.AutoSize = true;
            this.chkChamberFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkChamberFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkChamberFlag.Location = new System.Drawing.Point(290, 372);
            this.chkChamberFlag.Name = "chkChamberFlag";
            this.chkChamberFlag.Size = new System.Drawing.Size(153, 18);
            this.chkChamberFlag.TabIndex = 46;
            this.chkChamberFlag.Text = "Chamber Dependent Flag";
            this.chkChamberFlag.Visible = false;
            // 
            // cdvChamberGroup
            // 
            this.cdvChamberGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChamberGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChamberGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChamberGroup.BtnToolTipText = "";
            this.cdvChamberGroup.ButtonWidth = 20;
            this.cdvChamberGroup.DescText = "";
            this.cdvChamberGroup.DisplaySubItemIndex = -1;
            this.cdvChamberGroup.DisplayText = "";
            this.cdvChamberGroup.Focusing = null;
            this.cdvChamberGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChamberGroup.Index = 0;
            this.cdvChamberGroup.IsViewBtnImage = false;
            this.cdvChamberGroup.Location = new System.Drawing.Point(138, 370);
            this.cdvChamberGroup.MaxLength = 20;
            this.cdvChamberGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChamberGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChamberGroup.MultiSelect = false;
            this.cdvChamberGroup.Name = "cdvChamberGroup";
            this.cdvChamberGroup.ReadOnly = false;
            this.cdvChamberGroup.SameWidthHeightOfButton = false;
            this.cdvChamberGroup.SearchSubItemIndex = 0;
            this.cdvChamberGroup.SelectedDescIndex = -1;
            this.cdvChamberGroup.SelectedDescToQueryText = "";
            this.cdvChamberGroup.SelectedSubItemIndex = -1;
            this.cdvChamberGroup.SelectedValueToQueryText = "";
            this.cdvChamberGroup.SelectionStart = 0;
            this.cdvChamberGroup.Size = new System.Drawing.Size(133, 20);
            this.cdvChamberGroup.SmallImageList = null;
            this.cdvChamberGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChamberGroup.TabIndex = 29;
            this.cdvChamberGroup.TextBoxToolTipText = "";
            this.cdvChamberGroup.TextBoxWidth = 133;
            this.cdvChamberGroup.Visible = false;
            this.cdvChamberGroup.VisibleButton = true;
            this.cdvChamberGroup.VisibleColumnHeader = false;
            this.cdvChamberGroup.VisibleDescription = false;
            this.cdvChamberGroup.ButtonPress += new System.EventHandler(this.cdvChamberGroup_ButtonPress);
            // 
            // lblChamberGroup
            // 
            this.lblChamberGroup.AutoSize = true;
            this.lblChamberGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChamberGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChamberGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChamberGroup.Location = new System.Drawing.Point(14, 374);
            this.lblChamberGroup.Name = "lblChamberGroup";
            this.lblChamberGroup.Size = new System.Drawing.Size(94, 13);
            this.lblChamberGroup.TabIndex = 28;
            this.lblChamberGroup.Text = "Chamber Group";
            this.lblChamberGroup.Visible = false;
            // 
            // tbpResStatus
            // 
            this.tbpResStatus.Controls.Add(this.grpResPrompt);
            this.tbpResStatus.Location = new System.Drawing.Point(4, 22);
            this.tbpResStatus.Name = "tbpResStatus";
            this.tbpResStatus.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpResStatus.Size = new System.Drawing.Size(492, 388);
            this.tbpResStatus.TabIndex = 5;
            this.tbpResStatus.Text = "Status Prompt";
            this.tbpResStatus.UseVisualStyleBackColor = true;
            this.tbpResStatus.Visible = false;
            // 
            // grpResPrompt
            // 
            this.grpResPrompt.Controls.Add(this.chkUseFacPrtFlag);
            this.grpResPrompt.Controls.Add(this.lblResPrompt10);
            this.grpResPrompt.Controls.Add(this.lblResPrompt9);
            this.grpResPrompt.Controls.Add(this.lblResPrompt8);
            this.grpResPrompt.Controls.Add(this.lblResPrompt7);
            this.grpResPrompt.Controls.Add(this.lblResPrompt6);
            this.grpResPrompt.Controls.Add(this.lblResPrompt5);
            this.grpResPrompt.Controls.Add(this.lblResPrompt4);
            this.grpResPrompt.Controls.Add(this.lblResPrompt3);
            this.grpResPrompt.Controls.Add(this.lblResPrompt2);
            this.grpResPrompt.Controls.Add(this.lblResPrompt1);
            this.grpResPrompt.Controls.Add(this.txtResPrompt10);
            this.grpResPrompt.Controls.Add(this.txtResPrompt9);
            this.grpResPrompt.Controls.Add(this.txtResPrompt8);
            this.grpResPrompt.Controls.Add(this.txtResPrompt7);
            this.grpResPrompt.Controls.Add(this.txtResPrompt6);
            this.grpResPrompt.Controls.Add(this.txtResPrompt5);
            this.grpResPrompt.Controls.Add(this.txtResPrompt4);
            this.grpResPrompt.Controls.Add(this.txtResPrompt3);
            this.grpResPrompt.Controls.Add(this.txtResPrompt2);
            this.grpResPrompt.Controls.Add(this.txtResPrompt1);
            this.grpResPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResPrompt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResPrompt.Location = new System.Drawing.Point(3, 0);
            this.grpResPrompt.Name = "grpResPrompt";
            this.grpResPrompt.Size = new System.Drawing.Size(486, 385);
            this.grpResPrompt.TabIndex = 0;
            this.grpResPrompt.TabStop = false;
            // 
            // chkUseFacPrtFlag
            // 
            this.chkUseFacPrtFlag.AutoSize = true;
            this.chkUseFacPrtFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUseFacPrtFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUseFacPrtFlag.Location = new System.Drawing.Point(172, 19);
            this.chkUseFacPrtFlag.Name = "chkUseFacPrtFlag";
            this.chkUseFacPrtFlag.Size = new System.Drawing.Size(148, 18);
            this.chkUseFacPrtFlag.TabIndex = 0;
            this.chkUseFacPrtFlag.Text = "Use Factory Prompt Flag";
            this.chkUseFacPrtFlag.CheckedChanged += new System.EventHandler(this.chkUseFacPrtFlag_CheckedChanged);
            // 
            // lblResPrompt10
            // 
            this.lblResPrompt10.AutoSize = true;
            this.lblResPrompt10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt10.Location = new System.Drawing.Point(145, 259);
            this.lblResPrompt10.Name = "lblResPrompt10";
            this.lblResPrompt10.Size = new System.Drawing.Size(19, 13);
            this.lblResPrompt10.TabIndex = 19;
            this.lblResPrompt10.Text = "10";
            // 
            // lblResPrompt9
            // 
            this.lblResPrompt9.AutoSize = true;
            this.lblResPrompt9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt9.Location = new System.Drawing.Point(145, 235);
            this.lblResPrompt9.Name = "lblResPrompt9";
            this.lblResPrompt9.Size = new System.Drawing.Size(13, 13);
            this.lblResPrompt9.TabIndex = 17;
            this.lblResPrompt9.Text = "9";
            // 
            // lblResPrompt8
            // 
            this.lblResPrompt8.AutoSize = true;
            this.lblResPrompt8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt8.Location = new System.Drawing.Point(145, 211);
            this.lblResPrompt8.Name = "lblResPrompt8";
            this.lblResPrompt8.Size = new System.Drawing.Size(13, 13);
            this.lblResPrompt8.TabIndex = 15;
            this.lblResPrompt8.Text = "8";
            // 
            // lblResPrompt7
            // 
            this.lblResPrompt7.AutoSize = true;
            this.lblResPrompt7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt7.Location = new System.Drawing.Point(145, 187);
            this.lblResPrompt7.Name = "lblResPrompt7";
            this.lblResPrompt7.Size = new System.Drawing.Size(13, 13);
            this.lblResPrompt7.TabIndex = 13;
            this.lblResPrompt7.Text = "7";
            // 
            // lblResPrompt6
            // 
            this.lblResPrompt6.AutoSize = true;
            this.lblResPrompt6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt6.Location = new System.Drawing.Point(145, 163);
            this.lblResPrompt6.Name = "lblResPrompt6";
            this.lblResPrompt6.Size = new System.Drawing.Size(13, 13);
            this.lblResPrompt6.TabIndex = 11;
            this.lblResPrompt6.Text = "6";
            // 
            // lblResPrompt5
            // 
            this.lblResPrompt5.AutoSize = true;
            this.lblResPrompt5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt5.Location = new System.Drawing.Point(145, 139);
            this.lblResPrompt5.Name = "lblResPrompt5";
            this.lblResPrompt5.Size = new System.Drawing.Size(13, 13);
            this.lblResPrompt5.TabIndex = 9;
            this.lblResPrompt5.Text = "5";
            // 
            // lblResPrompt4
            // 
            this.lblResPrompt4.AutoSize = true;
            this.lblResPrompt4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt4.Location = new System.Drawing.Point(145, 115);
            this.lblResPrompt4.Name = "lblResPrompt4";
            this.lblResPrompt4.Size = new System.Drawing.Size(13, 13);
            this.lblResPrompt4.TabIndex = 7;
            this.lblResPrompt4.Text = "4";
            // 
            // lblResPrompt3
            // 
            this.lblResPrompt3.AutoSize = true;
            this.lblResPrompt3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt3.Location = new System.Drawing.Point(145, 91);
            this.lblResPrompt3.Name = "lblResPrompt3";
            this.lblResPrompt3.Size = new System.Drawing.Size(13, 13);
            this.lblResPrompt3.TabIndex = 5;
            this.lblResPrompt3.Text = "3";
            // 
            // lblResPrompt2
            // 
            this.lblResPrompt2.AutoSize = true;
            this.lblResPrompt2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt2.Location = new System.Drawing.Point(145, 67);
            this.lblResPrompt2.Name = "lblResPrompt2";
            this.lblResPrompt2.Size = new System.Drawing.Size(13, 13);
            this.lblResPrompt2.TabIndex = 3;
            this.lblResPrompt2.Text = "2";
            // 
            // lblResPrompt1
            // 
            this.lblResPrompt1.AutoSize = true;
            this.lblResPrompt1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResPrompt1.Location = new System.Drawing.Point(145, 43);
            this.lblResPrompt1.Name = "lblResPrompt1";
            this.lblResPrompt1.Size = new System.Drawing.Size(13, 13);
            this.lblResPrompt1.TabIndex = 1;
            this.lblResPrompt1.Text = "1";
            // 
            // txtResPrompt10
            // 
            this.txtResPrompt10.Location = new System.Drawing.Point(172, 256);
            this.txtResPrompt10.MaxLength = 30;
            this.txtResPrompt10.Name = "txtResPrompt10";
            this.txtResPrompt10.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt10.TabIndex = 20;
            // 
            // txtResPrompt9
            // 
            this.txtResPrompt9.Location = new System.Drawing.Point(172, 232);
            this.txtResPrompt9.MaxLength = 30;
            this.txtResPrompt9.Name = "txtResPrompt9";
            this.txtResPrompt9.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt9.TabIndex = 18;
            // 
            // txtResPrompt8
            // 
            this.txtResPrompt8.Location = new System.Drawing.Point(172, 208);
            this.txtResPrompt8.MaxLength = 30;
            this.txtResPrompt8.Name = "txtResPrompt8";
            this.txtResPrompt8.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt8.TabIndex = 16;
            // 
            // txtResPrompt7
            // 
            this.txtResPrompt7.Location = new System.Drawing.Point(172, 184);
            this.txtResPrompt7.MaxLength = 30;
            this.txtResPrompt7.Name = "txtResPrompt7";
            this.txtResPrompt7.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt7.TabIndex = 14;
            // 
            // txtResPrompt6
            // 
            this.txtResPrompt6.Location = new System.Drawing.Point(172, 160);
            this.txtResPrompt6.MaxLength = 30;
            this.txtResPrompt6.Name = "txtResPrompt6";
            this.txtResPrompt6.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt6.TabIndex = 12;
            // 
            // txtResPrompt5
            // 
            this.txtResPrompt5.Location = new System.Drawing.Point(172, 136);
            this.txtResPrompt5.MaxLength = 30;
            this.txtResPrompt5.Name = "txtResPrompt5";
            this.txtResPrompt5.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt5.TabIndex = 10;
            // 
            // txtResPrompt4
            // 
            this.txtResPrompt4.Location = new System.Drawing.Point(172, 112);
            this.txtResPrompt4.MaxLength = 30;
            this.txtResPrompt4.Name = "txtResPrompt4";
            this.txtResPrompt4.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt4.TabIndex = 8;
            // 
            // txtResPrompt3
            // 
            this.txtResPrompt3.Location = new System.Drawing.Point(172, 88);
            this.txtResPrompt3.MaxLength = 30;
            this.txtResPrompt3.Name = "txtResPrompt3";
            this.txtResPrompt3.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt3.TabIndex = 6;
            // 
            // txtResPrompt2
            // 
            this.txtResPrompt2.Location = new System.Drawing.Point(172, 64);
            this.txtResPrompt2.MaxLength = 30;
            this.txtResPrompt2.Name = "txtResPrompt2";
            this.txtResPrompt2.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt2.TabIndex = 4;
            // 
            // txtResPrompt1
            // 
            this.txtResPrompt1.Location = new System.Drawing.Point(172, 40);
            this.txtResPrompt1.MaxLength = 30;
            this.txtResPrompt1.Name = "txtResPrompt1";
            this.txtResPrompt1.Size = new System.Drawing.Size(195, 20);
            this.txtResPrompt1.TabIndex = 2;
            // 
            // tbpGroup
            // 
            this.tbpGroup.Controls.Add(this.grpGroup);
            this.tbpGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpGroup.Name = "tbpGroup";
            this.tbpGroup.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGroup.Size = new System.Drawing.Size(492, 388);
            this.tbpGroup.TabIndex = 4;
            this.tbpGroup.Text = "Group Setup";
            this.tbpGroup.UseVisualStyleBackColor = true;
            this.tbpGroup.Visible = false;
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.cdvResGrp10);
            this.grpGroup.Controls.Add(this.cdvResGrp9);
            this.grpGroup.Controls.Add(this.cdvResGrp8);
            this.grpGroup.Controls.Add(this.cdvResGrp7);
            this.grpGroup.Controls.Add(this.cdvResGrp6);
            this.grpGroup.Controls.Add(this.cdvResGrp5);
            this.grpGroup.Controls.Add(this.cdvResGrp4);
            this.grpGroup.Controls.Add(this.cdvResGrp3);
            this.grpGroup.Controls.Add(this.cdvResGrp2);
            this.grpGroup.Controls.Add(this.cdvResGrp1);
            this.grpGroup.Controls.Add(this.lblResGrp10);
            this.grpGroup.Controls.Add(this.lblResGrp9);
            this.grpGroup.Controls.Add(this.lblResGrp8);
            this.grpGroup.Controls.Add(this.lblResGrp7);
            this.grpGroup.Controls.Add(this.lblResGrp6);
            this.grpGroup.Controls.Add(this.lblResGrp5);
            this.grpGroup.Controls.Add(this.lblResGrp4);
            this.grpGroup.Controls.Add(this.lblResGrp3);
            this.grpGroup.Controls.Add(this.lblResGrp2);
            this.grpGroup.Controls.Add(this.lblResGrp1);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGroup.Location = new System.Drawing.Point(3, 0);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(486, 385);
            this.grpGroup.TabIndex = 0;
            this.grpGroup.TabStop = false;
            // 
            // cdvResGrp10
            // 
            this.cdvResGrp10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp10.BtnToolTipText = "";
            this.cdvResGrp10.ButtonWidth = 20;
            this.cdvResGrp10.DescText = "";
            this.cdvResGrp10.DisplaySubItemIndex = -1;
            this.cdvResGrp10.DisplayText = "";
            this.cdvResGrp10.Focusing = null;
            this.cdvResGrp10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp10.Index = 0;
            this.cdvResGrp10.IsViewBtnImage = false;
            this.cdvResGrp10.Location = new System.Drawing.Point(172, 232);
            this.cdvResGrp10.MaxLength = 30;
            this.cdvResGrp10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp10.MultiSelect = false;
            this.cdvResGrp10.Name = "cdvResGrp10";
            this.cdvResGrp10.ReadOnly = false;
            this.cdvResGrp10.SameWidthHeightOfButton = false;
            this.cdvResGrp10.SearchSubItemIndex = 0;
            this.cdvResGrp10.SelectedDescIndex = -1;
            this.cdvResGrp10.SelectedDescToQueryText = "";
            this.cdvResGrp10.SelectedSubItemIndex = -1;
            this.cdvResGrp10.SelectedValueToQueryText = "";
            this.cdvResGrp10.SelectionStart = 0;
            this.cdvResGrp10.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp10.SmallImageList = null;
            this.cdvResGrp10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp10.TabIndex = 19;
            this.cdvResGrp10.TextBoxToolTipText = "";
            this.cdvResGrp10.TextBoxWidth = 200;
            this.cdvResGrp10.VisibleButton = true;
            this.cdvResGrp10.VisibleColumnHeader = false;
            this.cdvResGrp10.VisibleDescription = false;
            this.cdvResGrp10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvResGrp9
            // 
            this.cdvResGrp9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp9.BtnToolTipText = "";
            this.cdvResGrp9.ButtonWidth = 20;
            this.cdvResGrp9.DescText = "";
            this.cdvResGrp9.DisplaySubItemIndex = -1;
            this.cdvResGrp9.DisplayText = "";
            this.cdvResGrp9.Focusing = null;
            this.cdvResGrp9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp9.Index = 0;
            this.cdvResGrp9.IsViewBtnImage = false;
            this.cdvResGrp9.Location = new System.Drawing.Point(172, 208);
            this.cdvResGrp9.MaxLength = 30;
            this.cdvResGrp9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp9.MultiSelect = false;
            this.cdvResGrp9.Name = "cdvResGrp9";
            this.cdvResGrp9.ReadOnly = false;
            this.cdvResGrp9.SameWidthHeightOfButton = false;
            this.cdvResGrp9.SearchSubItemIndex = 0;
            this.cdvResGrp9.SelectedDescIndex = -1;
            this.cdvResGrp9.SelectedDescToQueryText = "";
            this.cdvResGrp9.SelectedSubItemIndex = -1;
            this.cdvResGrp9.SelectedValueToQueryText = "";
            this.cdvResGrp9.SelectionStart = 0;
            this.cdvResGrp9.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp9.SmallImageList = null;
            this.cdvResGrp9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp9.TabIndex = 17;
            this.cdvResGrp9.TextBoxToolTipText = "";
            this.cdvResGrp9.TextBoxWidth = 200;
            this.cdvResGrp9.VisibleButton = true;
            this.cdvResGrp9.VisibleColumnHeader = false;
            this.cdvResGrp9.VisibleDescription = false;
            this.cdvResGrp9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvResGrp8
            // 
            this.cdvResGrp8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp8.BtnToolTipText = "";
            this.cdvResGrp8.ButtonWidth = 20;
            this.cdvResGrp8.DescText = "";
            this.cdvResGrp8.DisplaySubItemIndex = -1;
            this.cdvResGrp8.DisplayText = "";
            this.cdvResGrp8.Focusing = null;
            this.cdvResGrp8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp8.Index = 0;
            this.cdvResGrp8.IsViewBtnImage = false;
            this.cdvResGrp8.Location = new System.Drawing.Point(172, 184);
            this.cdvResGrp8.MaxLength = 30;
            this.cdvResGrp8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp8.MultiSelect = false;
            this.cdvResGrp8.Name = "cdvResGrp8";
            this.cdvResGrp8.ReadOnly = false;
            this.cdvResGrp8.SameWidthHeightOfButton = false;
            this.cdvResGrp8.SearchSubItemIndex = 0;
            this.cdvResGrp8.SelectedDescIndex = -1;
            this.cdvResGrp8.SelectedDescToQueryText = "";
            this.cdvResGrp8.SelectedSubItemIndex = -1;
            this.cdvResGrp8.SelectedValueToQueryText = "";
            this.cdvResGrp8.SelectionStart = 0;
            this.cdvResGrp8.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp8.SmallImageList = null;
            this.cdvResGrp8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp8.TabIndex = 15;
            this.cdvResGrp8.TextBoxToolTipText = "";
            this.cdvResGrp8.TextBoxWidth = 200;
            this.cdvResGrp8.VisibleButton = true;
            this.cdvResGrp8.VisibleColumnHeader = false;
            this.cdvResGrp8.VisibleDescription = false;
            this.cdvResGrp8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvResGrp7
            // 
            this.cdvResGrp7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp7.BtnToolTipText = "";
            this.cdvResGrp7.ButtonWidth = 20;
            this.cdvResGrp7.DescText = "";
            this.cdvResGrp7.DisplaySubItemIndex = -1;
            this.cdvResGrp7.DisplayText = "";
            this.cdvResGrp7.Focusing = null;
            this.cdvResGrp7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp7.Index = 0;
            this.cdvResGrp7.IsViewBtnImage = false;
            this.cdvResGrp7.Location = new System.Drawing.Point(172, 160);
            this.cdvResGrp7.MaxLength = 30;
            this.cdvResGrp7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp7.MultiSelect = false;
            this.cdvResGrp7.Name = "cdvResGrp7";
            this.cdvResGrp7.ReadOnly = false;
            this.cdvResGrp7.SameWidthHeightOfButton = false;
            this.cdvResGrp7.SearchSubItemIndex = 0;
            this.cdvResGrp7.SelectedDescIndex = -1;
            this.cdvResGrp7.SelectedDescToQueryText = "";
            this.cdvResGrp7.SelectedSubItemIndex = -1;
            this.cdvResGrp7.SelectedValueToQueryText = "";
            this.cdvResGrp7.SelectionStart = 0;
            this.cdvResGrp7.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp7.SmallImageList = null;
            this.cdvResGrp7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp7.TabIndex = 13;
            this.cdvResGrp7.TextBoxToolTipText = "";
            this.cdvResGrp7.TextBoxWidth = 200;
            this.cdvResGrp7.VisibleButton = true;
            this.cdvResGrp7.VisibleColumnHeader = false;
            this.cdvResGrp7.VisibleDescription = false;
            this.cdvResGrp7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvResGrp6
            // 
            this.cdvResGrp6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp6.BtnToolTipText = "";
            this.cdvResGrp6.ButtonWidth = 20;
            this.cdvResGrp6.DescText = "";
            this.cdvResGrp6.DisplaySubItemIndex = -1;
            this.cdvResGrp6.DisplayText = "";
            this.cdvResGrp6.Focusing = null;
            this.cdvResGrp6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp6.Index = 0;
            this.cdvResGrp6.IsViewBtnImage = false;
            this.cdvResGrp6.Location = new System.Drawing.Point(172, 136);
            this.cdvResGrp6.MaxLength = 30;
            this.cdvResGrp6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp6.MultiSelect = false;
            this.cdvResGrp6.Name = "cdvResGrp6";
            this.cdvResGrp6.ReadOnly = false;
            this.cdvResGrp6.SameWidthHeightOfButton = false;
            this.cdvResGrp6.SearchSubItemIndex = 0;
            this.cdvResGrp6.SelectedDescIndex = -1;
            this.cdvResGrp6.SelectedDescToQueryText = "";
            this.cdvResGrp6.SelectedSubItemIndex = -1;
            this.cdvResGrp6.SelectedValueToQueryText = "";
            this.cdvResGrp6.SelectionStart = 0;
            this.cdvResGrp6.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp6.SmallImageList = null;
            this.cdvResGrp6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp6.TabIndex = 11;
            this.cdvResGrp6.TextBoxToolTipText = "";
            this.cdvResGrp6.TextBoxWidth = 200;
            this.cdvResGrp6.VisibleButton = true;
            this.cdvResGrp6.VisibleColumnHeader = false;
            this.cdvResGrp6.VisibleDescription = false;
            this.cdvResGrp6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvResGrp5
            // 
            this.cdvResGrp5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp5.BtnToolTipText = "";
            this.cdvResGrp5.ButtonWidth = 20;
            this.cdvResGrp5.DescText = "";
            this.cdvResGrp5.DisplaySubItemIndex = -1;
            this.cdvResGrp5.DisplayText = "";
            this.cdvResGrp5.Focusing = null;
            this.cdvResGrp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp5.Index = 0;
            this.cdvResGrp5.IsViewBtnImage = false;
            this.cdvResGrp5.Location = new System.Drawing.Point(172, 112);
            this.cdvResGrp5.MaxLength = 30;
            this.cdvResGrp5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp5.MultiSelect = false;
            this.cdvResGrp5.Name = "cdvResGrp5";
            this.cdvResGrp5.ReadOnly = false;
            this.cdvResGrp5.SameWidthHeightOfButton = false;
            this.cdvResGrp5.SearchSubItemIndex = 0;
            this.cdvResGrp5.SelectedDescIndex = -1;
            this.cdvResGrp5.SelectedDescToQueryText = "";
            this.cdvResGrp5.SelectedSubItemIndex = -1;
            this.cdvResGrp5.SelectedValueToQueryText = "";
            this.cdvResGrp5.SelectionStart = 0;
            this.cdvResGrp5.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp5.SmallImageList = null;
            this.cdvResGrp5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp5.TabIndex = 9;
            this.cdvResGrp5.TextBoxToolTipText = "";
            this.cdvResGrp5.TextBoxWidth = 200;
            this.cdvResGrp5.VisibleButton = true;
            this.cdvResGrp5.VisibleColumnHeader = false;
            this.cdvResGrp5.VisibleDescription = false;
            this.cdvResGrp5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvResGrp4
            // 
            this.cdvResGrp4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp4.BtnToolTipText = "";
            this.cdvResGrp4.ButtonWidth = 20;
            this.cdvResGrp4.DescText = "";
            this.cdvResGrp4.DisplaySubItemIndex = -1;
            this.cdvResGrp4.DisplayText = "";
            this.cdvResGrp4.Focusing = null;
            this.cdvResGrp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp4.Index = 0;
            this.cdvResGrp4.IsViewBtnImage = false;
            this.cdvResGrp4.Location = new System.Drawing.Point(172, 88);
            this.cdvResGrp4.MaxLength = 30;
            this.cdvResGrp4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp4.MultiSelect = false;
            this.cdvResGrp4.Name = "cdvResGrp4";
            this.cdvResGrp4.ReadOnly = false;
            this.cdvResGrp4.SameWidthHeightOfButton = false;
            this.cdvResGrp4.SearchSubItemIndex = 0;
            this.cdvResGrp4.SelectedDescIndex = -1;
            this.cdvResGrp4.SelectedDescToQueryText = "";
            this.cdvResGrp4.SelectedSubItemIndex = -1;
            this.cdvResGrp4.SelectedValueToQueryText = "";
            this.cdvResGrp4.SelectionStart = 0;
            this.cdvResGrp4.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp4.SmallImageList = null;
            this.cdvResGrp4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp4.TabIndex = 7;
            this.cdvResGrp4.TextBoxToolTipText = "";
            this.cdvResGrp4.TextBoxWidth = 200;
            this.cdvResGrp4.VisibleButton = true;
            this.cdvResGrp4.VisibleColumnHeader = false;
            this.cdvResGrp4.VisibleDescription = false;
            this.cdvResGrp4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvResGrp3
            // 
            this.cdvResGrp3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp3.BtnToolTipText = "";
            this.cdvResGrp3.ButtonWidth = 20;
            this.cdvResGrp3.DescText = "";
            this.cdvResGrp3.DisplaySubItemIndex = -1;
            this.cdvResGrp3.DisplayText = "";
            this.cdvResGrp3.Focusing = null;
            this.cdvResGrp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp3.Index = 0;
            this.cdvResGrp3.IsViewBtnImage = false;
            this.cdvResGrp3.Location = new System.Drawing.Point(172, 64);
            this.cdvResGrp3.MaxLength = 30;
            this.cdvResGrp3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp3.MultiSelect = false;
            this.cdvResGrp3.Name = "cdvResGrp3";
            this.cdvResGrp3.ReadOnly = false;
            this.cdvResGrp3.SameWidthHeightOfButton = false;
            this.cdvResGrp3.SearchSubItemIndex = 0;
            this.cdvResGrp3.SelectedDescIndex = -1;
            this.cdvResGrp3.SelectedDescToQueryText = "";
            this.cdvResGrp3.SelectedSubItemIndex = -1;
            this.cdvResGrp3.SelectedValueToQueryText = "";
            this.cdvResGrp3.SelectionStart = 0;
            this.cdvResGrp3.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp3.SmallImageList = null;
            this.cdvResGrp3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp3.TabIndex = 5;
            this.cdvResGrp3.TextBoxToolTipText = "";
            this.cdvResGrp3.TextBoxWidth = 200;
            this.cdvResGrp3.VisibleButton = true;
            this.cdvResGrp3.VisibleColumnHeader = false;
            this.cdvResGrp3.VisibleDescription = false;
            this.cdvResGrp3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvResGrp2
            // 
            this.cdvResGrp2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp2.BtnToolTipText = "";
            this.cdvResGrp2.ButtonWidth = 20;
            this.cdvResGrp2.DescText = "";
            this.cdvResGrp2.DisplaySubItemIndex = -1;
            this.cdvResGrp2.DisplayText = "";
            this.cdvResGrp2.Focusing = null;
            this.cdvResGrp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp2.Index = 0;
            this.cdvResGrp2.IsViewBtnImage = false;
            this.cdvResGrp2.Location = new System.Drawing.Point(172, 40);
            this.cdvResGrp2.MaxLength = 30;
            this.cdvResGrp2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp2.MultiSelect = false;
            this.cdvResGrp2.Name = "cdvResGrp2";
            this.cdvResGrp2.ReadOnly = false;
            this.cdvResGrp2.SameWidthHeightOfButton = false;
            this.cdvResGrp2.SearchSubItemIndex = 0;
            this.cdvResGrp2.SelectedDescIndex = -1;
            this.cdvResGrp2.SelectedDescToQueryText = "";
            this.cdvResGrp2.SelectedSubItemIndex = -1;
            this.cdvResGrp2.SelectedValueToQueryText = "";
            this.cdvResGrp2.SelectionStart = 0;
            this.cdvResGrp2.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp2.SmallImageList = null;
            this.cdvResGrp2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp2.TabIndex = 3;
            this.cdvResGrp2.TextBoxToolTipText = "";
            this.cdvResGrp2.TextBoxWidth = 200;
            this.cdvResGrp2.VisibleButton = true;
            this.cdvResGrp2.VisibleColumnHeader = false;
            this.cdvResGrp2.VisibleDescription = false;
            this.cdvResGrp2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvResGrp1
            // 
            this.cdvResGrp1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResGrp1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResGrp1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResGrp1.BtnToolTipText = "";
            this.cdvResGrp1.ButtonWidth = 20;
            this.cdvResGrp1.DescText = "";
            this.cdvResGrp1.DisplaySubItemIndex = -1;
            this.cdvResGrp1.DisplayText = "";
            this.cdvResGrp1.Focusing = null;
            this.cdvResGrp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResGrp1.Index = 0;
            this.cdvResGrp1.IsViewBtnImage = false;
            this.cdvResGrp1.Location = new System.Drawing.Point(172, 16);
            this.cdvResGrp1.MaxLength = 30;
            this.cdvResGrp1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResGrp1.MultiSelect = false;
            this.cdvResGrp1.Name = "cdvResGrp1";
            this.cdvResGrp1.ReadOnly = false;
            this.cdvResGrp1.SameWidthHeightOfButton = false;
            this.cdvResGrp1.SearchSubItemIndex = 0;
            this.cdvResGrp1.SelectedDescIndex = -1;
            this.cdvResGrp1.SelectedDescToQueryText = "";
            this.cdvResGrp1.SelectedSubItemIndex = -1;
            this.cdvResGrp1.SelectedValueToQueryText = "";
            this.cdvResGrp1.SelectionStart = 0;
            this.cdvResGrp1.Size = new System.Drawing.Size(200, 20);
            this.cdvResGrp1.SmallImageList = null;
            this.cdvResGrp1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResGrp1.TabIndex = 1;
            this.cdvResGrp1.TextBoxToolTipText = "";
            this.cdvResGrp1.TextBoxWidth = 200;
            this.cdvResGrp1.VisibleButton = true;
            this.cdvResGrp1.VisibleColumnHeader = false;
            this.cdvResGrp1.VisibleDescription = false;
            this.cdvResGrp1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // lblResGrp10
            // 
            this.lblResGrp10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp10.Location = new System.Drawing.Point(15, 235);
            this.lblResGrp10.Name = "lblResGrp10";
            this.lblResGrp10.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp10.TabIndex = 18;
            // 
            // lblResGrp9
            // 
            this.lblResGrp9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp9.Location = new System.Drawing.Point(15, 211);
            this.lblResGrp9.Name = "lblResGrp9";
            this.lblResGrp9.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp9.TabIndex = 16;
            // 
            // lblResGrp8
            // 
            this.lblResGrp8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp8.Location = new System.Drawing.Point(15, 187);
            this.lblResGrp8.Name = "lblResGrp8";
            this.lblResGrp8.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp8.TabIndex = 14;
            // 
            // lblResGrp7
            // 
            this.lblResGrp7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp7.Location = new System.Drawing.Point(15, 163);
            this.lblResGrp7.Name = "lblResGrp7";
            this.lblResGrp7.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp7.TabIndex = 12;
            // 
            // lblResGrp6
            // 
            this.lblResGrp6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp6.Location = new System.Drawing.Point(15, 139);
            this.lblResGrp6.Name = "lblResGrp6";
            this.lblResGrp6.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp6.TabIndex = 10;
            // 
            // lblResGrp5
            // 
            this.lblResGrp5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp5.Location = new System.Drawing.Point(15, 115);
            this.lblResGrp5.Name = "lblResGrp5";
            this.lblResGrp5.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp5.TabIndex = 8;
            // 
            // lblResGrp4
            // 
            this.lblResGrp4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp4.Location = new System.Drawing.Point(15, 91);
            this.lblResGrp4.Name = "lblResGrp4";
            this.lblResGrp4.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp4.TabIndex = 6;
            // 
            // lblResGrp3
            // 
            this.lblResGrp3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp3.Location = new System.Drawing.Point(15, 67);
            this.lblResGrp3.Name = "lblResGrp3";
            this.lblResGrp3.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp3.TabIndex = 4;
            // 
            // lblResGrp2
            // 
            this.lblResGrp2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp2.Location = new System.Drawing.Point(15, 43);
            this.lblResGrp2.Name = "lblResGrp2";
            this.lblResGrp2.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp2.TabIndex = 2;
            // 
            // lblResGrp1
            // 
            this.lblResGrp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResGrp1.Location = new System.Drawing.Point(15, 19);
            this.lblResGrp1.Name = "lblResGrp1";
            this.lblResGrp1.Size = new System.Drawing.Size(150, 14);
            this.lblResGrp1.TabIndex = 0;
            // 
            // tabAttribute
            // 
            this.tabAttribute.BackColor = System.Drawing.SystemColors.Control;
            this.tabAttribute.Controls.Add(this.udcAttributeStatus);
            this.tabAttribute.Location = new System.Drawing.Point(4, 22);
            this.tabAttribute.Name = "tabAttribute";
            this.tabAttribute.Size = new System.Drawing.Size(492, 388);
            this.tabAttribute.TabIndex = 6;
            this.tabAttribute.Text = "Attribute";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeFactory = "";
            this.udcAttributeStatus.AttributeKey = "";
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW_AND_UPDATE;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "RESOURCE";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(0, 0);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(492, 388);
            this.udcAttributeStatus.TabIndex = 0;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(492, 388);
            this.tbpCMF.TabIndex = 2;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.UseVisualStyleBackColor = true;
            this.tbpCMF.Visible = false;
            // 
            // grpCMF
            // 
            this.grpCMF.BackColor = System.Drawing.SystemColors.Control;
            this.grpCMF.Controls.Add(this.cdvCMF19);
            this.grpCMF.Controls.Add(this.cdvCMF18);
            this.grpCMF.Controls.Add(this.cdvCMF17);
            this.grpCMF.Controls.Add(this.cdvCMF16);
            this.grpCMF.Controls.Add(this.cdvCMF15);
            this.grpCMF.Controls.Add(this.cdvCMF14);
            this.grpCMF.Controls.Add(this.cdvCMF13);
            this.grpCMF.Controls.Add(this.cdvCMF12);
            this.grpCMF.Controls.Add(this.cdvCMF20);
            this.grpCMF.Controls.Add(this.cdvCMF11);
            this.grpCMF.Controls.Add(this.lblCMF20);
            this.grpCMF.Controls.Add(this.lblCMF19);
            this.grpCMF.Controls.Add(this.lblCMF18);
            this.grpCMF.Controls.Add(this.lblCMF17);
            this.grpCMF.Controls.Add(this.lblCMF16);
            this.grpCMF.Controls.Add(this.lblCMF15);
            this.grpCMF.Controls.Add(this.lblCMF14);
            this.grpCMF.Controls.Add(this.lblCMF13);
            this.grpCMF.Controls.Add(this.lblCMF12);
            this.grpCMF.Controls.Add(this.lblCMF11);
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
            this.grpCMF.Location = new System.Drawing.Point(3, 0);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(486, 385);
            this.grpCMF.TabIndex = 1;
            this.grpCMF.TabStop = false;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF19.BtnToolTipText = "";
            this.cdvCMF19.ButtonWidth = 20;
            this.cdvCMF19.DescText = "";
            this.cdvCMF19.DisplaySubItemIndex = -1;
            this.cdvCMF19.DisplayText = "";
            this.cdvCMF19.Focusing = null;
            this.cdvCMF19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF19.Index = 0;
            this.cdvCMF19.IsViewBtnImage = false;
            this.cdvCMF19.Location = new System.Drawing.Point(351, 210);
            this.cdvCMF19.MaxLength = 30;
            this.cdvCMF19.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF19.MultiSelect = false;
            this.cdvCMF19.Name = "cdvCMF19";
            this.cdvCMF19.ReadOnly = false;
            this.cdvCMF19.SameWidthHeightOfButton = false;
            this.cdvCMF19.SearchSubItemIndex = 0;
            this.cdvCMF19.SelectedDescIndex = -1;
            this.cdvCMF19.SelectedDescToQueryText = "";
            this.cdvCMF19.SelectedSubItemIndex = -1;
            this.cdvCMF19.SelectedValueToQueryText = "";
            this.cdvCMF19.SelectionStart = 0;
            this.cdvCMF19.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF19.SmallImageList = null;
            this.cdvCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF19.TabIndex = 97;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 130;
            this.cdvCMF19.VisibleButton = true;
            this.cdvCMF19.VisibleColumnHeader = false;
            this.cdvCMF19.VisibleDescription = false;
            this.cdvCMF19.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF18
            // 
            this.cdvCMF18.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF18.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF18.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF18.BtnToolTipText = "";
            this.cdvCMF18.ButtonWidth = 20;
            this.cdvCMF18.DescText = "";
            this.cdvCMF18.DisplaySubItemIndex = -1;
            this.cdvCMF18.DisplayText = "";
            this.cdvCMF18.Focusing = null;
            this.cdvCMF18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF18.Index = 0;
            this.cdvCMF18.IsViewBtnImage = false;
            this.cdvCMF18.Location = new System.Drawing.Point(351, 186);
            this.cdvCMF18.MaxLength = 30;
            this.cdvCMF18.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF18.MultiSelect = false;
            this.cdvCMF18.Name = "cdvCMF18";
            this.cdvCMF18.ReadOnly = false;
            this.cdvCMF18.SameWidthHeightOfButton = false;
            this.cdvCMF18.SearchSubItemIndex = 0;
            this.cdvCMF18.SelectedDescIndex = -1;
            this.cdvCMF18.SelectedDescToQueryText = "";
            this.cdvCMF18.SelectedSubItemIndex = -1;
            this.cdvCMF18.SelectedValueToQueryText = "";
            this.cdvCMF18.SelectionStart = 0;
            this.cdvCMF18.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF18.SmallImageList = null;
            this.cdvCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF18.TabIndex = 95;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 130;
            this.cdvCMF18.VisibleButton = true;
            this.cdvCMF18.VisibleColumnHeader = false;
            this.cdvCMF18.VisibleDescription = false;
            this.cdvCMF18.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF17
            // 
            this.cdvCMF17.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF17.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF17.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF17.BtnToolTipText = "";
            this.cdvCMF17.ButtonWidth = 20;
            this.cdvCMF17.DescText = "";
            this.cdvCMF17.DisplaySubItemIndex = -1;
            this.cdvCMF17.DisplayText = "";
            this.cdvCMF17.Focusing = null;
            this.cdvCMF17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF17.Index = 0;
            this.cdvCMF17.IsViewBtnImage = false;
            this.cdvCMF17.Location = new System.Drawing.Point(351, 162);
            this.cdvCMF17.MaxLength = 30;
            this.cdvCMF17.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF17.MultiSelect = false;
            this.cdvCMF17.Name = "cdvCMF17";
            this.cdvCMF17.ReadOnly = false;
            this.cdvCMF17.SameWidthHeightOfButton = false;
            this.cdvCMF17.SearchSubItemIndex = 0;
            this.cdvCMF17.SelectedDescIndex = -1;
            this.cdvCMF17.SelectedDescToQueryText = "";
            this.cdvCMF17.SelectedSubItemIndex = -1;
            this.cdvCMF17.SelectedValueToQueryText = "";
            this.cdvCMF17.SelectionStart = 0;
            this.cdvCMF17.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF17.SmallImageList = null;
            this.cdvCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF17.TabIndex = 93;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 130;
            this.cdvCMF17.VisibleButton = true;
            this.cdvCMF17.VisibleColumnHeader = false;
            this.cdvCMF17.VisibleDescription = false;
            this.cdvCMF17.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF16
            // 
            this.cdvCMF16.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF16.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF16.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF16.BtnToolTipText = "";
            this.cdvCMF16.ButtonWidth = 20;
            this.cdvCMF16.DescText = "";
            this.cdvCMF16.DisplaySubItemIndex = -1;
            this.cdvCMF16.DisplayText = "";
            this.cdvCMF16.Focusing = null;
            this.cdvCMF16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF16.Index = 0;
            this.cdvCMF16.IsViewBtnImage = false;
            this.cdvCMF16.Location = new System.Drawing.Point(351, 138);
            this.cdvCMF16.MaxLength = 30;
            this.cdvCMF16.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF16.MultiSelect = false;
            this.cdvCMF16.Name = "cdvCMF16";
            this.cdvCMF16.ReadOnly = false;
            this.cdvCMF16.SameWidthHeightOfButton = false;
            this.cdvCMF16.SearchSubItemIndex = 0;
            this.cdvCMF16.SelectedDescIndex = -1;
            this.cdvCMF16.SelectedDescToQueryText = "";
            this.cdvCMF16.SelectedSubItemIndex = -1;
            this.cdvCMF16.SelectedValueToQueryText = "";
            this.cdvCMF16.SelectionStart = 0;
            this.cdvCMF16.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF16.SmallImageList = null;
            this.cdvCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF16.TabIndex = 91;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 130;
            this.cdvCMF16.VisibleButton = true;
            this.cdvCMF16.VisibleColumnHeader = false;
            this.cdvCMF16.VisibleDescription = false;
            this.cdvCMF16.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF15
            // 
            this.cdvCMF15.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF15.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF15.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF15.BtnToolTipText = "";
            this.cdvCMF15.ButtonWidth = 20;
            this.cdvCMF15.DescText = "";
            this.cdvCMF15.DisplaySubItemIndex = -1;
            this.cdvCMF15.DisplayText = "";
            this.cdvCMF15.Focusing = null;
            this.cdvCMF15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF15.Index = 0;
            this.cdvCMF15.IsViewBtnImage = false;
            this.cdvCMF15.Location = new System.Drawing.Point(351, 114);
            this.cdvCMF15.MaxLength = 30;
            this.cdvCMF15.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF15.MultiSelect = false;
            this.cdvCMF15.Name = "cdvCMF15";
            this.cdvCMF15.ReadOnly = false;
            this.cdvCMF15.SameWidthHeightOfButton = false;
            this.cdvCMF15.SearchSubItemIndex = 0;
            this.cdvCMF15.SelectedDescIndex = -1;
            this.cdvCMF15.SelectedDescToQueryText = "";
            this.cdvCMF15.SelectedSubItemIndex = -1;
            this.cdvCMF15.SelectedValueToQueryText = "";
            this.cdvCMF15.SelectionStart = 0;
            this.cdvCMF15.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF15.SmallImageList = null;
            this.cdvCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF15.TabIndex = 89;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 130;
            this.cdvCMF15.VisibleButton = true;
            this.cdvCMF15.VisibleColumnHeader = false;
            this.cdvCMF15.VisibleDescription = false;
            this.cdvCMF15.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF14
            // 
            this.cdvCMF14.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF14.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF14.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF14.BtnToolTipText = "";
            this.cdvCMF14.ButtonWidth = 20;
            this.cdvCMF14.DescText = "";
            this.cdvCMF14.DisplaySubItemIndex = -1;
            this.cdvCMF14.DisplayText = "";
            this.cdvCMF14.Focusing = null;
            this.cdvCMF14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF14.Index = 0;
            this.cdvCMF14.IsViewBtnImage = false;
            this.cdvCMF14.Location = new System.Drawing.Point(351, 90);
            this.cdvCMF14.MaxLength = 30;
            this.cdvCMF14.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF14.MultiSelect = false;
            this.cdvCMF14.Name = "cdvCMF14";
            this.cdvCMF14.ReadOnly = false;
            this.cdvCMF14.SameWidthHeightOfButton = false;
            this.cdvCMF14.SearchSubItemIndex = 0;
            this.cdvCMF14.SelectedDescIndex = -1;
            this.cdvCMF14.SelectedDescToQueryText = "";
            this.cdvCMF14.SelectedSubItemIndex = -1;
            this.cdvCMF14.SelectedValueToQueryText = "";
            this.cdvCMF14.SelectionStart = 0;
            this.cdvCMF14.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF14.SmallImageList = null;
            this.cdvCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF14.TabIndex = 87;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 130;
            this.cdvCMF14.VisibleButton = true;
            this.cdvCMF14.VisibleColumnHeader = false;
            this.cdvCMF14.VisibleDescription = false;
            this.cdvCMF14.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF13
            // 
            this.cdvCMF13.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF13.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF13.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF13.BtnToolTipText = "";
            this.cdvCMF13.ButtonWidth = 20;
            this.cdvCMF13.DescText = "";
            this.cdvCMF13.DisplaySubItemIndex = -1;
            this.cdvCMF13.DisplayText = "";
            this.cdvCMF13.Focusing = null;
            this.cdvCMF13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF13.Index = 0;
            this.cdvCMF13.IsViewBtnImage = false;
            this.cdvCMF13.Location = new System.Drawing.Point(351, 66);
            this.cdvCMF13.MaxLength = 30;
            this.cdvCMF13.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF13.MultiSelect = false;
            this.cdvCMF13.Name = "cdvCMF13";
            this.cdvCMF13.ReadOnly = false;
            this.cdvCMF13.SameWidthHeightOfButton = false;
            this.cdvCMF13.SearchSubItemIndex = 0;
            this.cdvCMF13.SelectedDescIndex = -1;
            this.cdvCMF13.SelectedDescToQueryText = "";
            this.cdvCMF13.SelectedSubItemIndex = -1;
            this.cdvCMF13.SelectedValueToQueryText = "";
            this.cdvCMF13.SelectionStart = 0;
            this.cdvCMF13.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF13.SmallImageList = null;
            this.cdvCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF13.TabIndex = 85;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 130;
            this.cdvCMF13.VisibleButton = true;
            this.cdvCMF13.VisibleColumnHeader = false;
            this.cdvCMF13.VisibleDescription = false;
            this.cdvCMF13.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF12
            // 
            this.cdvCMF12.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF12.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF12.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF12.BtnToolTipText = "";
            this.cdvCMF12.ButtonWidth = 20;
            this.cdvCMF12.DescText = "";
            this.cdvCMF12.DisplaySubItemIndex = -1;
            this.cdvCMF12.DisplayText = "";
            this.cdvCMF12.Focusing = null;
            this.cdvCMF12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF12.Index = 0;
            this.cdvCMF12.IsViewBtnImage = false;
            this.cdvCMF12.Location = new System.Drawing.Point(351, 42);
            this.cdvCMF12.MaxLength = 30;
            this.cdvCMF12.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF12.MultiSelect = false;
            this.cdvCMF12.Name = "cdvCMF12";
            this.cdvCMF12.ReadOnly = false;
            this.cdvCMF12.SameWidthHeightOfButton = false;
            this.cdvCMF12.SearchSubItemIndex = 0;
            this.cdvCMF12.SelectedDescIndex = -1;
            this.cdvCMF12.SelectedDescToQueryText = "";
            this.cdvCMF12.SelectedSubItemIndex = -1;
            this.cdvCMF12.SelectedValueToQueryText = "";
            this.cdvCMF12.SelectionStart = 0;
            this.cdvCMF12.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF12.SmallImageList = null;
            this.cdvCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF12.TabIndex = 83;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 130;
            this.cdvCMF12.VisibleButton = true;
            this.cdvCMF12.VisibleColumnHeader = false;
            this.cdvCMF12.VisibleDescription = false;
            this.cdvCMF12.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF20
            // 
            this.cdvCMF20.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF20.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF20.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF20.BtnToolTipText = "";
            this.cdvCMF20.ButtonWidth = 20;
            this.cdvCMF20.DescText = "";
            this.cdvCMF20.DisplaySubItemIndex = -1;
            this.cdvCMF20.DisplayText = "";
            this.cdvCMF20.Focusing = null;
            this.cdvCMF20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF20.Index = 0;
            this.cdvCMF20.IsViewBtnImage = false;
            this.cdvCMF20.Location = new System.Drawing.Point(351, 234);
            this.cdvCMF20.MaxLength = 30;
            this.cdvCMF20.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF20.MultiSelect = false;
            this.cdvCMF20.Name = "cdvCMF20";
            this.cdvCMF20.ReadOnly = false;
            this.cdvCMF20.SameWidthHeightOfButton = false;
            this.cdvCMF20.SearchSubItemIndex = 0;
            this.cdvCMF20.SelectedDescIndex = -1;
            this.cdvCMF20.SelectedDescToQueryText = "";
            this.cdvCMF20.SelectedSubItemIndex = -1;
            this.cdvCMF20.SelectedValueToQueryText = "";
            this.cdvCMF20.SelectionStart = 0;
            this.cdvCMF20.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF20.SmallImageList = null;
            this.cdvCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF20.TabIndex = 99;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 130;
            this.cdvCMF20.VisibleButton = true;
            this.cdvCMF20.VisibleColumnHeader = false;
            this.cdvCMF20.VisibleDescription = false;
            this.cdvCMF20.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF11
            // 
            this.cdvCMF11.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF11.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF11.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF11.BtnToolTipText = "";
            this.cdvCMF11.ButtonWidth = 20;
            this.cdvCMF11.DescText = "";
            this.cdvCMF11.DisplaySubItemIndex = -1;
            this.cdvCMF11.DisplayText = "";
            this.cdvCMF11.Focusing = null;
            this.cdvCMF11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF11.Index = 0;
            this.cdvCMF11.IsViewBtnImage = false;
            this.cdvCMF11.Location = new System.Drawing.Point(351, 18);
            this.cdvCMF11.MaxLength = 30;
            this.cdvCMF11.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF11.MultiSelect = false;
            this.cdvCMF11.Name = "cdvCMF11";
            this.cdvCMF11.ReadOnly = false;
            this.cdvCMF11.SameWidthHeightOfButton = false;
            this.cdvCMF11.SearchSubItemIndex = 0;
            this.cdvCMF11.SelectedDescIndex = -1;
            this.cdvCMF11.SelectedDescToQueryText = "";
            this.cdvCMF11.SelectedSubItemIndex = -1;
            this.cdvCMF11.SelectedValueToQueryText = "";
            this.cdvCMF11.SelectionStart = 0;
            this.cdvCMF11.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF11.SmallImageList = null;
            this.cdvCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF11.TabIndex = 81;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 130;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            this.cdvCMF11.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(255, 238);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(90, 14);
            this.lblCMF20.TabIndex = 98;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(255, 214);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(90, 14);
            this.lblCMF19.TabIndex = 96;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(255, 190);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(90, 14);
            this.lblCMF18.TabIndex = 94;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(255, 166);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(90, 14);
            this.lblCMF17.TabIndex = 92;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(255, 142);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(90, 14);
            this.lblCMF16.TabIndex = 90;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(255, 118);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(90, 14);
            this.lblCMF15.TabIndex = 88;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(255, 94);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(90, 14);
            this.lblCMF14.TabIndex = 86;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(255, 70);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(90, 14);
            this.lblCMF13.TabIndex = 84;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(255, 46);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(90, 14);
            this.lblCMF12.TabIndex = 82;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(255, 22);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(90, 14);
            this.lblCMF11.TabIndex = 80;
            this.lblCMF11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvCMF9
            // 
            this.cdvCMF9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.ButtonWidth = 20;
            this.cdvCMF9.DescText = "";
            this.cdvCMF9.DisplaySubItemIndex = -1;
            this.cdvCMF9.DisplayText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF9.Index = 0;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(108, 210);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MultiSelect = false;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SameWidthHeightOfButton = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedDescToQueryText = "";
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectedValueToQueryText = "";
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 77;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 130;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF8
            // 
            this.cdvCMF8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.ButtonWidth = 20;
            this.cdvCMF8.DescText = "";
            this.cdvCMF8.DisplaySubItemIndex = -1;
            this.cdvCMF8.DisplayText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF8.Index = 0;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(108, 186);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MultiSelect = false;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SameWidthHeightOfButton = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedDescToQueryText = "";
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectedValueToQueryText = "";
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 75;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 130;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF7
            // 
            this.cdvCMF7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.ButtonWidth = 20;
            this.cdvCMF7.DescText = "";
            this.cdvCMF7.DisplaySubItemIndex = -1;
            this.cdvCMF7.DisplayText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF7.Index = 0;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(108, 162);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MultiSelect = false;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SameWidthHeightOfButton = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedDescToQueryText = "";
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectedValueToQueryText = "";
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 73;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 130;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF6
            // 
            this.cdvCMF6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.ButtonWidth = 20;
            this.cdvCMF6.DescText = "";
            this.cdvCMF6.DisplaySubItemIndex = -1;
            this.cdvCMF6.DisplayText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF6.Index = 0;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(108, 138);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MultiSelect = false;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SameWidthHeightOfButton = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedDescToQueryText = "";
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectedValueToQueryText = "";
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 71;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 130;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF5
            // 
            this.cdvCMF5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.ButtonWidth = 20;
            this.cdvCMF5.DescText = "";
            this.cdvCMF5.DisplaySubItemIndex = -1;
            this.cdvCMF5.DisplayText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF5.Index = 0;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(108, 114);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MultiSelect = false;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SameWidthHeightOfButton = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedDescToQueryText = "";
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectedValueToQueryText = "";
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 69;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 130;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF4
            // 
            this.cdvCMF4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.ButtonWidth = 20;
            this.cdvCMF4.DescText = "";
            this.cdvCMF4.DisplaySubItemIndex = -1;
            this.cdvCMF4.DisplayText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF4.Index = 0;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(108, 90);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MultiSelect = false;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SameWidthHeightOfButton = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedDescToQueryText = "";
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectedValueToQueryText = "";
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 67;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 130;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF3
            // 
            this.cdvCMF3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.ButtonWidth = 20;
            this.cdvCMF3.DescText = "";
            this.cdvCMF3.DisplaySubItemIndex = -1;
            this.cdvCMF3.DisplayText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF3.Index = 0;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(108, 66);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MultiSelect = false;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SameWidthHeightOfButton = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedDescToQueryText = "";
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectedValueToQueryText = "";
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 65;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 130;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF2
            // 
            this.cdvCMF2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.ButtonWidth = 20;
            this.cdvCMF2.DescText = "";
            this.cdvCMF2.DisplaySubItemIndex = -1;
            this.cdvCMF2.DisplayText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF2.Index = 0;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(108, 42);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MultiSelect = false;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SameWidthHeightOfButton = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedDescToQueryText = "";
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectedValueToQueryText = "";
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 63;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 130;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF10
            // 
            this.cdvCMF10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.ButtonWidth = 20;
            this.cdvCMF10.DescText = "";
            this.cdvCMF10.DisplaySubItemIndex = -1;
            this.cdvCMF10.DisplayText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF10.Index = 0;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(108, 234);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MultiSelect = false;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SameWidthHeightOfButton = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedDescToQueryText = "";
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectedValueToQueryText = "";
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 79;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 130;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCMF1
            // 
            this.cdvCMF1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.ButtonWidth = 20;
            this.cdvCMF1.DescText = "";
            this.cdvCMF1.DisplaySubItemIndex = -1;
            this.cdvCMF1.DisplayText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(108, 18);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MultiSelect = false;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SameWidthHeightOfButton = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedDescToQueryText = "";
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectedValueToQueryText = "";
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(130, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 61;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 130;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(12, 238);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(90, 14);
            this.lblCMF10.TabIndex = 78;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(12, 214);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(90, 14);
            this.lblCMF9.TabIndex = 76;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(12, 190);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(90, 14);
            this.lblCMF8.TabIndex = 74;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(12, 166);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(90, 14);
            this.lblCMF7.TabIndex = 72;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(12, 142);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(90, 14);
            this.lblCMF6.TabIndex = 70;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(12, 118);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(90, 14);
            this.lblCMF5.TabIndex = 68;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(12, 94);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(90, 14);
            this.lblCMF4.TabIndex = 66;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(12, 70);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(90, 14);
            this.lblCMF3.TabIndex = 64;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(12, 46);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(90, 14);
            this.lblCMF2.TabIndex = 62;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(12, 22);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(90, 14);
            this.lblCMF1.TabIndex = 60;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lisResource.Location = new System.Drawing.Point(3, 47);
            this.lisResource.MultiSelect = false;
            this.lisResource.Name = "lisResource";
            this.lisResource.Size = new System.Drawing.Size(229, 463);
            this.lisResource.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lisResource.TabIndex = 1;
            this.lisResource.UseCompatibleStateImageBehavior = false;
            this.lisResource.View = System.Windows.Forms.View.Details;
            this.lisResource.SelectedIndexChanged += new System.EventHandler(this.lisResource_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Resource";
            this.ColumnHeader1.Width = 80;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // frmRASSetupResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASSetupResource";
            this.Text = "Resource Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupResource_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupResource_Load);
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
            this.grpResource.ResumeLayout(false);
            this.grpResource.PerformLayout();
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.pnlGeneral.ResumeLayout(false);
            this.tabResource.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChamberGroup)).EndInit();
            this.tbpResStatus.ResumeLayout(false);
            this.grpResPrompt.ResumeLayout(false);
            this.grpResPrompt.PerformLayout();
            this.tbpGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResGrp1)).EndInit();
            this.tabAttribute.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF11)).EndInit();
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
        
        #region " Variable definition "
        bool b_load_flag;
        #endregion
        
        #region " Function definition "
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];
            
            sGrpTableName[0] = MPGC.MP_GCM_RES_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_RES_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_RES_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_RES_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_RES_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_RES_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_RES_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_RES_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_RES_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_RES_GRP_10;
            
            MPCR.SetGRPItem(MPGC.MP_GRP_RESOURCE, "lblResGrp", "cdvResGrp", grpGroup, sGrpTableName);
            MPCR.SetCMFItem(MPGC.MP_CMF_RESOURCE, "lblCmf", "cdvCmf", grpCMF);
            
        }
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            if (MPCF.CheckValue(txtResource, 1) == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":

                    if (MPCF.CheckValue(cdvResType, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvAreaID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCF.CheckValue(cdvSubAreaID, 1) == false)
                    {
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblResGrp", "cdvResGrp", grpGroup) == false)
                    {
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        return false;
                    }
                    break;
                case "DELETE":
                    
                    break;
                    
            }
            
            return true;
            
        }
        
        //
        // Refresh_Resourcelist()
        //       -  Refresh Resource List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool Refresh_Resourcelist()
        {
            string SelectedItem;
            
            try
            {
                SelectedItem = MPCF.Trim(txtResource.Text);
                MPCF.FieldClear(this.pnlRight);
                lisResource.Items.Clear();
                lblDataCount.Text = "";
                
                if (chkDeleteRes.Checked == false)
                {
                    if (RASLIST.ViewResourceList(lisResource, "", cdvType.Text, false) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(lisResource.Items.Count);
                    }
                }
                else if (chkDeleteRes.Checked == true)
                {
                    if (RASLIST.ViewResourceList(lisResource, "", cdvType.Text, true) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(lisResource.Items.Count);
                    }
                }
                
                if (lisResource.Items.Count > 0 && SelectedItem != "")
                {
                    MPCF.FindListItem(lisResource, SelectedItem, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return true;
            
        }
        
        //
        // View_Resource()
        //       -  View Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Resource()
        {
            TRSNode in_node = new TRSNode("View_Resource_In");
            TRSNode out_node = new TRSNode("View_Resource_Out");
            try
            {
                MPCF.FieldClear(this.pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(lisResource.SelectedItems[0].Text));

                if (MPCR.CallService("RAS", "RAS_View_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtResource.Text = out_node.GetString("RES_ID");
                txtDesc.Text = out_node.GetString("RES_DESC");
                txtShortDesc.Text = out_node.GetString("RES_SHORT_DESC");
                cdvResType.Text = out_node.GetString("RES_TYPE");

                cdvResGrp1.Text = out_node.GetString("RES_GRP_1");
                cdvResGrp2.Text = out_node.GetString("RES_GRP_2");
                cdvResGrp3.Text = out_node.GetString("RES_GRP_3");
                cdvResGrp4.Text = out_node.GetString("RES_GRP_4");
                cdvResGrp5.Text = out_node.GetString("RES_GRP_5");
                cdvResGrp6.Text = out_node.GetString("RES_GRP_6");
                cdvResGrp7.Text = out_node.GetString("RES_GRP_7");
                cdvResGrp8.Text = out_node.GetString("RES_GRP_8");
                cdvResGrp9.Text = out_node.GetString("RES_GRP_9");
                cdvResGrp10.Text = out_node.GetString("RES_GRP_10");

                cdvCMF1.Text = out_node.GetString("RES_CMF_1");
                cdvCMF2.Text = out_node.GetString("RES_CMF_2");
                cdvCMF3.Text = out_node.GetString("RES_CMF_3");
                cdvCMF4.Text = out_node.GetString("RES_CMF_4");
                cdvCMF5.Text = out_node.GetString("RES_CMF_5");
                cdvCMF6.Text = out_node.GetString("RES_CMF_6");
                cdvCMF7.Text = out_node.GetString("RES_CMF_7");
                cdvCMF8.Text = out_node.GetString("RES_CMF_8");
                cdvCMF9.Text = out_node.GetString("RES_CMF_9");
                cdvCMF10.Text = out_node.GetString("RES_CMF_10");
                cdvCMF11.Text = out_node.GetString("RES_CMF_11");
                cdvCMF12.Text = out_node.GetString("RES_CMF_12");
                cdvCMF13.Text = out_node.GetString("RES_CMF_13");
                cdvCMF14.Text = out_node.GetString("RES_CMF_14");
                cdvCMF15.Text = out_node.GetString("RES_CMF_15");
                cdvCMF16.Text = out_node.GetString("RES_CMF_16");
                cdvCMF17.Text = out_node.GetString("RES_CMF_17");
                cdvCMF18.Text = out_node.GetString("RES_CMF_18");
                cdvCMF19.Text = out_node.GetString("RES_CMF_19");
                cdvCMF20.Text = out_node.GetString("RES_CMF_20");

                cdvAreaID.Text = out_node.GetString("AREA_ID");
                cdvSubAreaID.Text = out_node.GetString("SUB_AREA_ID");
                txtLocation.Text = out_node.GetString("RES_LOCATION");

                switch (out_node.GetChar("PROC_RULE"))
                {
                    case MPGC.MP_RAS_PROC_RULE_C_SERIAL:
                        cboProcRule.SelectedIndex = 1;
                        break;
                    case MPGC.MP_RAS_PROC_RULE_C_BATCH:
                        cboProcRule.SelectedIndex = 2;
                        break;
                    default:
                        cboProcRule.SelectedIndex = 0;
                        break;
                }
                txtMaxProcCount.Text = out_node.GetInt("MAX_PROC_COUNT").ToString();

                if (MPCF.Trim(out_node.GetChar("PM_SCH_ENABLE_FLAG")) == "Y")
                {
                    chkPMSchEnableFlag.Checked = true;
                }
                else
                {
                    chkPMSchEnableFlag.Checked = false;
                }
                
                if (MPCF.Trim(out_node.GetChar("UNIT_BASE_ST_FLAG")) == "Y")
                {
                    chkUnitBaseStFlag.Checked = true;
                }
                else
                {
                    chkUnitBaseStFlag.Checked = false;
                }
                
                if (MPCF.Trim(out_node.GetChar("SEC_CHK_FLAG")) == "Y")
                {
                    chkSecChkFlag.Checked = true;
                }
                else
                {
                    chkSecChkFlag.Checked = false;
                }
                if (MPCF.Trim(out_node.GetChar("AUTO_GATHER_ALARM")) == "Y")
                {
                    chkRegisterAlarm.Checked = true;
                }
                else
                {
                    chkRegisterAlarm.Checked = false;
                }

                if (out_node.GetString("RES_CTRL_MODE").Equals(MPGC.MP_RAS_CTRL_MODE_S_ONLINELOCAL))
                {
                    cboCtrlMode.SelectedIndex = 0;
                }
                else if (out_node.GetString("RES_CTRL_MODE").Equals(MPGC.MP_RAS_CTRL_MODE_S_ONLINEREMOTE))
                {
                    cboCtrlMode.SelectedIndex = 1;
                }
                else if (out_node.GetString("RES_CTRL_MODE").Equals(MPGC.MP_RAS_CTRL_MODE_S_OFFLINE))
                {
                    cboCtrlMode.SelectedIndex = 2;
                }

                if (out_node.GetString("RES_PROC_MODE").Equals(MPGC.MP_RAS_PROC_MODE_MANUAL))
                {
                    cboProcMode.SelectedIndex = 0;
                }
                else if (out_node.GetString("RES_PROC_MODE").Equals(MPGC.MP_RAS_PROC_MODE_SEMIAUTO))
                {
                    cboProcMode.SelectedIndex = 1;
                }
                else if (out_node.GetString("RES_PROC_MODE").Equals(MPGC.MP_RAS_PROC_MODE_FULLAUTO))
                {
                    cboProcMode.SelectedIndex = 2;
                }

                txtResPrompt1.Text = out_node.GetString("RES_STS_PRT_1");
                txtResPrompt2.Text = out_node.GetString("RES_STS_PRT_2");
                txtResPrompt3.Text = out_node.GetString("RES_STS_PRT_3");
                txtResPrompt4.Text = out_node.GetString("RES_STS_PRT_4");
                txtResPrompt5.Text = out_node.GetString("RES_STS_PRT_5");
                txtResPrompt6.Text = out_node.GetString("RES_STS_PRT_6");
                txtResPrompt7.Text = out_node.GetString("RES_STS_PRT_7");
                txtResPrompt8.Text = out_node.GetString("RES_STS_PRT_8");
                txtResPrompt9.Text = out_node.GetString("RES_STS_PRT_9");
                txtResPrompt10.Text = out_node.GetString("RES_STS_PRT_10");
                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));


                if (out_node.GetChar("USE_FAC_PRT_FLAG") == 'Y')
                {
                    chkUseFacPrtFlag.Checked = true;
                    txtResPrompt1.Enabled = false;
                    txtResPrompt2.Enabled = false;
                    txtResPrompt3.Enabled = false;
                    txtResPrompt4.Enabled = false;
                    txtResPrompt5.Enabled = false;
                    txtResPrompt6.Enabled = false;
                    txtResPrompt7.Enabled = false;
                    txtResPrompt8.Enabled = false;
                    txtResPrompt9.Enabled = false;
                    txtResPrompt10.Enabled = false;
                }
                else
                {
                    chkUseFacPrtFlag.Checked = false;
                    txtResPrompt1.Enabled = true;
                    txtResPrompt2.Enabled = true;
                    txtResPrompt3.Enabled = true;
                    txtResPrompt4.Enabled = true;
                    txtResPrompt5.Enabled = true;
                    txtResPrompt6.Enabled = true;
                    txtResPrompt7.Enabled = true;
                    txtResPrompt8.Enabled = true;
                    txtResPrompt9.Enabled = true;
                    txtResPrompt10.Enabled = true;
                }
                if (MPCF.Trim(out_node.GetChar("DELETE_FLAG")) == "Y")
                {
                    // Delete 되었다 하더라도 화면에 현재 상태값은 보여야 하지 않나?
                    //MPCF.FieldClear(pnlGeneral);
                    btnUpdate.Text = MPCF.FindLanguage("Terminate", 1);
                    btnDelete.Text = MPCF.FindLanguage("Undelete", 1);
                }
                else
                {
                    btnUpdate.Text = MPCF.FindLanguage("Update", 1);
                    btnDelete.Text = MPCF.FindLanguage("Delete", 1);
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
        // Update_Resource()
        //       -  Update Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - ByVal c_step As String     : ?뺤옣 Process Step
        //
        private bool Update_Resource(char c_step)
        {
            TRSNode in_node = new TRSNode("Update_Resource_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            ListViewItem item;
            int idx;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("RES_ID", MPCF.Trim(txtResource.Text));
                in_node.AddString("RES_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("RES_SHORT_DESC", MPCF.Trim(txtShortDesc.Text));
                in_node.AddString("RES_TYPE", MPCF.Trim(cdvResType.Text));

                in_node.AddString("RES_GRP_1", MPCF.Trim(cdvResGrp1.Text));
                in_node.AddString("RES_GRP_2", MPCF.Trim(cdvResGrp2.Text));
                in_node.AddString("RES_GRP_3", MPCF.Trim(cdvResGrp3.Text));
                in_node.AddString("RES_GRP_4", MPCF.Trim(cdvResGrp4.Text));
                in_node.AddString("RES_GRP_5", MPCF.Trim(cdvResGrp5.Text));
                in_node.AddString("RES_GRP_6", MPCF.Trim(cdvResGrp6.Text));
                in_node.AddString("RES_GRP_7", MPCF.Trim(cdvResGrp7.Text));
                in_node.AddString("RES_GRP_8", MPCF.Trim(cdvResGrp8.Text));
                in_node.AddString("RES_GRP_9", MPCF.Trim(cdvResGrp9.Text));
                in_node.AddString("RES_GRP_10", MPCF.Trim(cdvResGrp10.Text));

                in_node.AddChar("USE_FAC_PRT_FLAG", (chkUseFacPrtFlag.Checked == true ? 'Y' : ' '));

                
                if (chkUseFacPrtFlag.Checked == false)
                {
                    in_node.AddString("RES_STS_PRT_1", MPCF.Trim(txtResPrompt1.Text));
                    in_node.AddString("RES_STS_PRT_2", MPCF.Trim(txtResPrompt2.Text));
                    in_node.AddString("RES_STS_PRT_3", MPCF.Trim(txtResPrompt3.Text));
                    in_node.AddString("RES_STS_PRT_4", MPCF.Trim(txtResPrompt4.Text));
                    in_node.AddString("RES_STS_PRT_5", MPCF.Trim(txtResPrompt5.Text));
                    in_node.AddString("RES_STS_PRT_6", MPCF.Trim(txtResPrompt6.Text));
                    in_node.AddString("RES_STS_PRT_7", MPCF.Trim(txtResPrompt7.Text));
                    in_node.AddString("RES_STS_PRT_8", MPCF.Trim(txtResPrompt8.Text));
                    in_node.AddString("RES_STS_PRT_9", MPCF.Trim(txtResPrompt9.Text));
                    in_node.AddString("RES_STS_PRT_10", MPCF.Trim(txtResPrompt10.Text));

                }
                in_node.AddString("RES_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("RES_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("RES_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("RES_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("RES_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("RES_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("RES_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("RES_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("RES_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("RES_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("RES_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("RES_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("RES_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("RES_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("RES_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("RES_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("RES_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("RES_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("RES_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("RES_CMF_20", MPCF.Trim(cdvCMF20.Text));

                in_node.AddString("AREA_ID", MPCF.Trim(cdvAreaID.Text));
                in_node.AddString("SUB_AREA_ID", MPCF.Trim(cdvSubAreaID.Text));
                in_node.AddString("RES_LOCATION", MPCF.Trim(txtLocation.Text));

                if (cboProcRule.Text == "SERIAL")
                {
                    in_node.AddChar("PROC_RULE" , 'S');
                }
                else if (cboProcRule.Text == "BATCH")
                {
                    in_node.AddChar("PROC_RULE" ,'B');
                }
                else
                {
                    in_node.AddChar("PROC_RULE" , ' ');
                }
                if (cboCtrlMode.Text == "ONLINE LOCAL")
                {
                    in_node.AddString("RES_CTRL_MODE", "OL");
                }
                else if (cboCtrlMode.Text == "ONLINE REMOTE")
                {
                    in_node.AddString("RES_CTRL_MODE", "OR");
                }
                else if (cboCtrlMode.Text == "OFFLINE")
                {
                    in_node.AddString("RES_CTRL_MODE", "OF");
                }
                if (MPCF.CheckNumeric(MPCF.Trim(txtMaxProcCount.Text)) == true)
                {
                    in_node.AddInt("MAX_PROC_COUNT", MPCF.ToInt(txtMaxProcCount.Text));

                }
                else
                {
                    in_node.AddInt("MAX_PROC_COUNT", 0);
                }

                in_node.AddChar("PM_SCH_ENABLE_FLAG", (chkPMSchEnableFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("UNIT_BASE_ST_FLAG", (chkUnitBaseStFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("SEC_CHK_FLAG", (chkSecChkFlag.Checked == true ? 'Y' : ' '));

                //Modify by J.S. 2011.06.16 DB Field GATHER_ALARM_FLAG는 조회시 AUTO_GATHER_ALARM로 조회되고 
                //장비 Setup시 GATHER_ALARM_FLAG로 문서화 되어 있음. 문서에 맞게 수정한다.
                in_node.AddChar("GATHER_ALARM_FLAG", (chkRegisterAlarm.Checked == true ? 'Y' : ' '));
                in_node.AddString("RES_PROC_MODE", MPCF.Trim(cboProcMode.Text));

                if (MPCR.CallService("RAS", "RAS_Update_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        item = lisResource.Items.Add(txtResource.Text, (int)SMALLICON_INDEX.IDX_RESOURCE);
                        item.SubItems.Add(txtDesc.Text);
                        item.Selected = true;
                        lisResource.Sorting = SortOrder.Ascending;
                        lisResource.Sort();
                        item.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisResource, MPCF.Trim(txtResource.Text),false) == true)
                        {
                            lisResource.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisResource, MPCF.Trim(txtResource.Text), false);
                        if (idx != - 1)
                        {
                            if (chkDeleteRes.Checked == true)
                            {
                                lisResource.Items[idx].ForeColor = Color.Magenta;
                            }
                            else
                            {
                                lisResource.Items[idx].Remove();
                            }
                            
                        }
                        lblDataCount.Text = MPCF.Trim(lisResource.Items.Count);
                    }
                }

                if (c_step != MPGC.MP_STEP_CONFIRM)
                {
                    MPCR.ShowSuccessMsg(out_node);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return true;
            
        }
        
        private void InitCodeView()
        {
            
            if (cdvResType.DisplaySubItemIndex != cdvResType.SelectedSubItemIndex)
            {
                cdvType_ButtonPress(cdvResType, null);
            }
            if (cdvChamberGroup.DisplaySubItemIndex != cdvChamberGroup.SelectedSubItemIndex)
            {
                cdvChamberGroup_ButtonPress(null, null);
            }
            if (cdvAreaID.DisplaySubItemIndex != cdvAreaID.SelectedSubItemIndex)
            {
                cdvAreaID_ButtonPress(null, null);
            }
            if (cdvSubAreaID.DisplaySubItemIndex != cdvSubAreaID.SelectedSubItemIndex)
            {
                cdvSubAreaID_ButtonPress(null, null);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASSetupResource_Load(object sender, System.EventArgs e)
        {
            
            MPCF.FieldClear(this);
            MPCF.FieldVisible(tbpCMF, false);
            MPCF.FieldVisible(tbpGroup, false);
            MPCF.InitListView(lisResource);
            
        }
        
        private void frmRASSetupResource_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                lisResource.Focus();
                //Resource Setting
                lblDataCount.Text = "";
                SetGroupCmfItem();
                InitCodeView();
                //Add by J.S. 2008.12.18 Checked is default
                chkUseFacPrtFlag.Checked = true;

                if (RASLIST.ViewResourceList(lisResource, "", cdvType.Text, false) == true)
                {
                    if (lisResource.Items.Count > 0)
                    {
                        lisResource.Items[0].Selected = true;
                    }
                    lblDataCount.Text = MPCF.Trim(lisResource.Items.Count);
                }
                else
                {
                    return;
                }
                
                b_load_flag = true;
            }
            
        }
        
        private void chkUseFacPrtFlag_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            if (chkUseFacPrtFlag.Checked == true)
            {
                txtResPrompt1.Enabled = false;
                txtResPrompt2.Enabled = false;
                txtResPrompt3.Enabled = false;
                txtResPrompt4.Enabled = false;
                txtResPrompt5.Enabled = false;
                txtResPrompt6.Enabled = false;
                txtResPrompt7.Enabled = false;
                txtResPrompt8.Enabled = false;
                txtResPrompt9.Enabled = false;
                txtResPrompt10.Enabled = false;
            }
            else
            {
                txtResPrompt1.Enabled = true;
                txtResPrompt2.Enabled = true;
                txtResPrompt3.Enabled = true;
                txtResPrompt4.Enabled = true;
                txtResPrompt5.Enabled = true;
                txtResPrompt6.Enabled = true;
                txtResPrompt7.Enabled = true;
                txtResPrompt8.Enabled = true;
                txtResPrompt9.Enabled = true;
                txtResPrompt10.Enabled = true;
            }
            
        }
        
        private void cdvType_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
            if (cdvTemp.AddEmptyRow(1) == false)
            {
                return;
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("CREATE") == true)
                {
                    if (Update_Resource(MPGC.MP_STEP_CREATE) == false)
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
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (btnUpdate.Text == MPCF.FindLanguage("Update", 1))
                {
                    if (CheckCondition("CREATE") == true)
                    {
                        if (Update_Resource(MPGC.MP_STEP_UPDATE) == false)
                        {
                            return;
                        }

                        if (MPGV.gbListAutoRefresh == true)
                        {
                            btnRefresh.PerformClick();
                        }
                    }
                }
                else
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                    if (CheckCondition("DELETE") == true)
                    {                       
                        if (Update_Resource(MPGC.MP_STEP_TERMINATE) == true)
                        {

                            MPCF.FieldClear(this.pnlRight);
                            if (MPGV.gbListAutoRefresh == true)
                            {
                                btnRefresh.PerformClick();
                            }
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
                if (btnDelete.Text == MPCF.FindLanguage("Undelete", 1))
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(156), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Update_Resource(MPGC.MP_STEP_UNDELETE) == false)
                        {
                            return;
                        }
                        
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            btnRefresh.PerformClick();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                    {
                        return;
                    }
                    if (CheckCondition("DELETE") == true)
                    {
                        if (Update_Resource(MPGC.MP_STEP_CONFIRM) == true)
                        {
                            if (Update_Resource(MPGC.MP_STEP_DELETE) == true)
                            {
                                
                                MPCF.FieldClear(this.pnlRight);
                                if (MPGV.gbListAutoRefresh == true)
                                {
                                    btnRefresh.PerformClick();
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                lisResource.Items.Clear();
                if (chkDeleteRes.Checked == false)
                {
                    if (RASLIST.ViewResourceList(lisResource, "", cdvType.Text, false) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(lisResource.Items.Count);
                    }
                }
                else if (chkDeleteRes.Checked == true)
                {
                    if (RASLIST.ViewResourceList(lisResource, "", cdvType.Text, true) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(lisResource.Items.Count);
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
            MPCF.ExportToExcel(lisResource, this.Text, "");            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (Refresh_Resourcelist() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        
        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            MPCR.CheckCMFKeyPress(sender, e);
            
        }
        
        private void txtMaxProcCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
            
        }
        
        private void chkDeleteRes_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            Refresh_Resourcelist();
            
        }
        
        private void cdvAreaID_ButtonPress(object sender, System.EventArgs e)
        {
            
            cdvAreaID.Init();
            MPCF.InitListView(cdvAreaID.GetListView);
            cdvAreaID.Columns.Add("AreaID", 50, HorizontalAlignment.Left);
            cdvAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAreaID.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvAreaID.GetListView, '1', MPGC.MP_RAS_AREA_CODE) == false)
            {
                return;
            }
            
        }

        private void cdvAreaID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvSubAreaID.Text = "";
        }
    
        private void cdvSubAreaID_ButtonPress(object sender, System.EventArgs e)
        {
            if(MPCF.Trim(cdvAreaID.Text) == "") 
            {
                return; 
            }

            //Sub Area
            cdvSubAreaID.Init();
            MPCF.InitListView(cdvSubAreaID.GetListView);
            cdvSubAreaID.Columns.Add("SubAreaID", 50, HorizontalAlignment.Left);
            cdvSubAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvSubAreaID.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList_AREA(cdvSubAreaID.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE, -1, null, "", false, -1, -1, null, cdvAreaID.Text) == false)
            {
                return;
            }
            
        }
        
        private void cdvChamberGroup_ButtonPress(object sender, System.EventArgs e)
        {
            cdvChamberGroup.Init();
            MPCF.InitListView(cdvChamberGroup.GetListView);
            cdvChamberGroup.Columns.Add("Chamber Group", 50, HorizontalAlignment.Left);
            cdvChamberGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvChamberGroup.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvChamberGroup.GetListView, '1', MPGC.MP_RAS_CHAMBER_GROUP) == false)
            {
                return;
            }
        }
        
        private void lisResource_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            MPCF.FieldClear(this.pnlRight);
            //Add by J.S. 2008.12.18 Checked is default
            chkUseFacPrtFlag.Checked = true;

            if (lisResource.SelectedItems.Count > 0)
            {
                txtResource.Text = lisResource.SelectedItems[0].Text;
                View_Resource();

                udcAttributeStatus.AttributeKey = txtResource.Text;
                udcAttributeStatus.View();
            }
            else
            {
                btnUpdate.Text = MPCF.FindLanguage("Update", 1);
                btnDelete.Text = MPCF.FindLanguage("Delete", 1);
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

        private void grpGeneral_Enter(object sender, EventArgs e)
        {

        }

        private void cdvSubAreaID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {

        }

        private void txtResource_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tabResource.SelectedTab == tabAttribute)
            {
                udcAttributeStatus.ClearValue();
            }
        }

          
    }
    
}
