
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupFlow.vb
//   Description : Flow Setup
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Table() : View General Code Table definition
//       - View_Table_List() : View all table list which is included in one factory
//       - Update_Table() : Create/Update/Delete General code Table definition
//       - View_User_Group_List() : View all user group list
//
//   Detail Description
//       -
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-11 : Created by WK
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
using Miracom.CliFrx;
using Miracom.UI;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPSetupFlow : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPSetupFlow()
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
        



        private System.Windows.Forms.GroupBox grpFlow;
        private System.Windows.Forms.Label lblFlowDesc;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.TextBox txtFlowDesc;
        private System.Windows.Forms.TextBox txtFlow;
        private Miracom.UI.Controls.MCListView.MCListView lisFlow;
        private System.Windows.Forms.ColumnHeader colFlow;
        private System.Windows.Forms.ColumnHeader colFlowDesc;
        private System.Windows.Forms.Panel pnlRightFill;
        private System.Windows.Forms.TabControl tabFlow;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.TabPage tbpGroup;
        private System.Windows.Forms.TabPage tbpAttachOper;
        private System.Windows.Forms.Panel pnlCMFFill;
        private System.Windows.Forms.Panel pnlGroupFill;
        private System.Windows.Forms.Panel pnlAttachOperFill;
        private System.Windows.Forms.TabPage tbpCopyFlow;
        private System.Windows.Forms.Panel pnlCopyFlowFill;
        private System.Windows.Forms.GroupBox grpCopyFlow;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblToFlow;
        private System.Windows.Forms.TextBox txtToFlow;
        private System.Windows.Forms.GroupBox grpGroup;
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
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup10;
        private System.Windows.Forms.Panel pnlAttachOperMid;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Panel pnlAttachOper;
        private Miracom.UI.Controls.MCListView.MCListView lisAttachOper;
        private System.Windows.Forms.ColumnHeader colAttachOperation;
        private System.Windows.Forms.ColumnHeader colAttachOperationGroup;
        private System.Windows.Forms.ColumnHeader colAttachOperationOption;
        private System.Windows.Forms.ColumnHeader colAttachOperationDesc;
        private System.Windows.Forms.Panel pnlOperList;
        private System.Windows.Forms.Panel pnlOperListTop;
        private System.Windows.Forms.Panel pnlOperListFill;
        private Miracom.UI.Controls.MCListView.MCListView lisOperList;
        private System.Windows.Forms.ColumnHeader colOperation;
        private System.Windows.Forms.ColumnHeader colOperationDesc;
        private System.Windows.Forms.Label lblOptionalGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOptionalGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOptionalGroupOption;
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
        private TabPage tbpAttribute;
        private Miracom.BASCore.udcAttributeStatus udcAttributeStatus;
        private Button btnDown;
        private Button btnUp;
        protected Button btnOperExcel;
        private Label lblFlowShortDesc;
        private TextBox txtFlowShortDesc;
        private System.Windows.Forms.Label lblOptionalGroupOption;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPSetupFlow));
            this.grpFlow = new System.Windows.Forms.GroupBox();
            this.lblFlowShortDesc = new System.Windows.Forms.Label();
            this.txtFlowShortDesc = new System.Windows.Forms.TextBox();
            this.lblFlowDesc = new System.Windows.Forms.Label();
            this.lblFlow = new System.Windows.Forms.Label();
            this.txtFlowDesc = new System.Windows.Forms.TextBox();
            this.txtFlow = new System.Windows.Forms.TextBox();
            this.lisFlow = new Miracom.UI.Controls.MCListView.MCListView();
            this.colFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlowDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlRightFill = new System.Windows.Forms.Panel();
            this.tabFlow = new System.Windows.Forms.TabControl();
            this.tbpGroup = new System.Windows.Forms.TabPage();
            this.pnlGroupFill = new System.Windows.Forms.Panel();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
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
            this.tbpAttachOper = new System.Windows.Forms.TabPage();
            this.pnlAttachOperFill = new System.Windows.Forms.Panel();
            this.pnlOperList = new System.Windows.Forms.Panel();
            this.pnlOperListFill = new System.Windows.Forms.Panel();
            this.lisOperList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperationDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlOperListTop = new System.Windows.Forms.Panel();
            this.cdvOptionalGroupOption = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOptionalGroupOption = new System.Windows.Forms.Label();
            this.cdvOptionalGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOptionalGroup = new System.Windows.Forms.Label();
            this.pnlAttachOper = new System.Windows.Forms.Panel();
            this.lisAttachOper = new Miracom.UI.Controls.MCListView.MCListView();
            this.colAttachOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAttachOperationDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAttachOperationGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAttachOperationOption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlAttachOperMid = new System.Windows.Forms.Panel();
            this.btnOperExcel = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.tbpAttribute = new System.Windows.Forms.TabPage();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.pnlCMFFill = new System.Windows.Forms.Panel();
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
            this.tbpCopyFlow = new System.Windows.Forms.TabPage();
            this.pnlCopyFlowFill = new System.Windows.Forms.Panel();
            this.grpCopyFlow = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblToFlow = new System.Windows.Forms.Label();
            this.txtToFlow = new System.Windows.Forms.TextBox();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpFlow.SuspendLayout();
            this.pnlRightFill.SuspendLayout();
            this.tabFlow.SuspendLayout();
            this.tbpGroup.SuspendLayout();
            this.pnlGroupFill.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            this.tbpAttachOper.SuspendLayout();
            this.pnlAttachOperFill.SuspendLayout();
            this.pnlOperList.SuspendLayout();
            this.pnlOperListFill.SuspendLayout();
            this.pnlOperListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionalGroupOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionalGroup)).BeginInit();
            this.pnlAttachOper.SuspendLayout();
            this.pnlAttachOperMid.SuspendLayout();
            this.tbpAttribute.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.pnlCMFFill.SuspendLayout();
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
            this.tbpCopyFlow.SuspendLayout();
            this.pnlCopyFlowFill.SuspendLayout();
            this.grpCopyFlow.SuspendLayout();
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
            this.txtFind.MaxLength = 20;
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlRightFill);
            this.pnlRight.Controls.Add(this.grpFlow);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisFlow);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 2);
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
            // pnlTop
            // 
            this.pnlTop.Padding = new System.Windows.Forms.Padding(1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(1, 1);
            this.lblFormTitle.Size = new System.Drawing.Size(740, 0);
            this.lblFormTitle.Text = "Flow Setup";
            // 
            // grpFlow
            // 
            this.grpFlow.Controls.Add(this.lblFlowShortDesc);
            this.grpFlow.Controls.Add(this.txtFlowShortDesc);
            this.grpFlow.Controls.Add(this.lblFlowDesc);
            this.grpFlow.Controls.Add(this.lblFlow);
            this.grpFlow.Controls.Add(this.txtFlowDesc);
            this.grpFlow.Controls.Add(this.txtFlow);
            this.grpFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFlow.Location = new System.Drawing.Point(3, 0);
            this.grpFlow.Name = "grpFlow";
            this.grpFlow.Size = new System.Drawing.Size(500, 91);
            this.grpFlow.TabIndex = 0;
            this.grpFlow.TabStop = false;
            // 
            // lblFlowShortDesc
            // 
            this.lblFlowShortDesc.AutoSize = true;
            this.lblFlowShortDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlowShortDesc.Location = new System.Drawing.Point(15, 42);
            this.lblFlowShortDesc.Name = "lblFlowShortDesc";
            this.lblFlowShortDesc.Size = new System.Drawing.Size(88, 13);
            this.lblFlowShortDesc.TabIndex = 2;
            this.lblFlowShortDesc.Text = "Short Description";
            this.lblFlowShortDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtFlowShortDesc
            // 
            this.txtFlowShortDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFlowShortDesc.Location = new System.Drawing.Point(120, 40);
            this.txtFlowShortDesc.MaxLength = 50;
            this.txtFlowShortDesc.Name = "txtFlowShortDesc";
            this.txtFlowShortDesc.Size = new System.Drawing.Size(368, 20);
            this.txtFlowShortDesc.TabIndex = 3;
            // 
            // lblFlowDesc
            // 
            this.lblFlowDesc.AutoSize = true;
            this.lblFlowDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlowDesc.Location = new System.Drawing.Point(15, 66);
            this.lblFlowDesc.Name = "lblFlowDesc";
            this.lblFlowDesc.Size = new System.Drawing.Size(60, 13);
            this.lblFlowDesc.TabIndex = 4;
            this.lblFlowDesc.Text = "Description";
            this.lblFlowDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlow.Location = new System.Drawing.Point(15, 19);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(33, 13);
            this.lblFlow.TabIndex = 0;
            this.lblFlow.Text = "Flow";
            this.lblFlow.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtFlowDesc
            // 
            this.txtFlowDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFlowDesc.Location = new System.Drawing.Point(120, 64);
            this.txtFlowDesc.MaxLength = 200;
            this.txtFlowDesc.Name = "txtFlowDesc";
            this.txtFlowDesc.Size = new System.Drawing.Size(368, 20);
            this.txtFlowDesc.TabIndex = 5;
            // 
            // txtFlow
            // 
            this.txtFlow.Location = new System.Drawing.Point(120, 16);
            this.txtFlow.MaxLength = 20;
            this.txtFlow.Name = "txtFlow";
            this.txtFlow.Size = new System.Drawing.Size(200, 20);
            this.txtFlow.TabIndex = 1;
            this.txtFlow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFlow_KeyPress);
            // 
            // lisFlow
            // 
            this.lisFlow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFlow,
            this.colFlowDesc});
            this.lisFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisFlow.EnableSort = true;
            this.lisFlow.EnableSortIcon = true;
            this.lisFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisFlow.FullRowSelect = true;
            this.lisFlow.HideSelection = false;
            this.lisFlow.Location = new System.Drawing.Point(3, 3);
            this.lisFlow.MultiSelect = false;
            this.lisFlow.Name = "lisFlow";
            this.lisFlow.Size = new System.Drawing.Size(229, 508);
            this.lisFlow.TabIndex = 0;
            this.lisFlow.UseCompatibleStateImageBehavior = false;
            this.lisFlow.View = System.Windows.Forms.View.Details;
            this.lisFlow.SelectedIndexChanged += new System.EventHandler(this.lisFlow_SelectedIndexChanged);
            // 
            // colFlow
            // 
            this.colFlow.Text = "Flow";
            this.colFlow.Width = 120;
            // 
            // colFlowDesc
            // 
            this.colFlowDesc.Text = "Description";
            this.colFlowDesc.Width = 300;
            // 
            // pnlRightFill
            // 
            this.pnlRightFill.Controls.Add(this.tabFlow);
            this.pnlRightFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightFill.Location = new System.Drawing.Point(3, 91);
            this.pnlRightFill.Name = "pnlRightFill";
            this.pnlRightFill.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlRightFill.Size = new System.Drawing.Size(500, 422);
            this.pnlRightFill.TabIndex = 1;
            // 
            // tabFlow
            // 
            this.tabFlow.Controls.Add(this.tbpGroup);
            this.tabFlow.Controls.Add(this.tbpAttachOper);
            this.tabFlow.Controls.Add(this.tbpAttribute);
            this.tabFlow.Controls.Add(this.tbpCMF);
            this.tabFlow.Controls.Add(this.tbpCopyFlow);
            this.tabFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFlow.ItemSize = new System.Drawing.Size(60, 18);
            this.tabFlow.Location = new System.Drawing.Point(0, 5);
            this.tabFlow.Name = "tabFlow";
            this.tabFlow.SelectedIndex = 0;
            this.tabFlow.Size = new System.Drawing.Size(500, 417);
            this.tabFlow.TabIndex = 0;
            this.tabFlow.SelectedIndexChanged += new System.EventHandler(this.tabFlow_SelectedIndexChanged);
            // 
            // tbpGroup
            // 
            this.tbpGroup.Controls.Add(this.pnlGroupFill);
            this.tbpGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpGroup.Name = "tbpGroup";
            this.tbpGroup.Size = new System.Drawing.Size(492, 391);
            this.tbpGroup.TabIndex = 3;
            this.tbpGroup.Text = "Group Setup";
            this.tbpGroup.Visible = false;
            // 
            // pnlGroupFill
            // 
            this.pnlGroupFill.Controls.Add(this.grpGroup);
            this.pnlGroupFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroupFill.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupFill.Name = "pnlGroupFill";
            this.pnlGroupFill.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlGroupFill.Size = new System.Drawing.Size(492, 391);
            this.pnlGroupFill.TabIndex = 0;
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.cdvGroup9);
            this.grpGroup.Controls.Add(this.cdvGroup8);
            this.grpGroup.Controls.Add(this.cdvGroup7);
            this.grpGroup.Controls.Add(this.cdvGroup6);
            this.grpGroup.Controls.Add(this.cdvGroup5);
            this.grpGroup.Controls.Add(this.cdvGroup4);
            this.grpGroup.Controls.Add(this.cdvGroup3);
            this.grpGroup.Controls.Add(this.cdvGroup2);
            this.grpGroup.Controls.Add(this.cdvGroup10);
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
            this.grpGroup.Location = new System.Drawing.Point(3, 5);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(486, 383);
            this.grpGroup.TabIndex = 0;
            this.grpGroup.TabStop = false;
            this.grpGroup.Text = "Flow Group (1~10)";
            // 
            // cdvGroup9
            // 
            this.cdvGroup9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup9.BtnToolTipText = "";
            this.cdvGroup9.ButtonWidth = 20;
            this.cdvGroup9.DescText = "";
            this.cdvGroup9.DisplaySubItemIndex = -1;
            this.cdvGroup9.DisplayText = "";
            this.cdvGroup9.Focusing = null;
            this.cdvGroup9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup9.Index = 0;
            this.cdvGroup9.IsViewBtnImage = false;
            this.cdvGroup9.Location = new System.Drawing.Point(172, 210);
            this.cdvGroup9.MaxLength = 30;
            this.cdvGroup9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MultiSelect = false;
            this.cdvGroup9.Name = "cdvGroup9";
            this.cdvGroup9.ReadOnly = false;
            this.cdvGroup9.SameWidthHeightOfButton = false;
            this.cdvGroup9.SearchSubItemIndex = 0;
            this.cdvGroup9.SelectedDescIndex = -1;
            this.cdvGroup9.SelectedDescToQueryText = "";
            this.cdvGroup9.SelectedSubItemIndex = -1;
            this.cdvGroup9.SelectedValueToQueryText = "";
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
            this.cdvGroup9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup8
            // 
            this.cdvGroup8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup8.BtnToolTipText = "";
            this.cdvGroup8.ButtonWidth = 20;
            this.cdvGroup8.DescText = "";
            this.cdvGroup8.DisplaySubItemIndex = -1;
            this.cdvGroup8.DisplayText = "";
            this.cdvGroup8.Focusing = null;
            this.cdvGroup8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup8.Index = 0;
            this.cdvGroup8.IsViewBtnImage = false;
            this.cdvGroup8.Location = new System.Drawing.Point(172, 186);
            this.cdvGroup8.MaxLength = 30;
            this.cdvGroup8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MultiSelect = false;
            this.cdvGroup8.Name = "cdvGroup8";
            this.cdvGroup8.ReadOnly = false;
            this.cdvGroup8.SameWidthHeightOfButton = false;
            this.cdvGroup8.SearchSubItemIndex = 0;
            this.cdvGroup8.SelectedDescIndex = -1;
            this.cdvGroup8.SelectedDescToQueryText = "";
            this.cdvGroup8.SelectedSubItemIndex = -1;
            this.cdvGroup8.SelectedValueToQueryText = "";
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
            this.cdvGroup8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup7
            // 
            this.cdvGroup7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup7.BtnToolTipText = "";
            this.cdvGroup7.ButtonWidth = 20;
            this.cdvGroup7.DescText = "";
            this.cdvGroup7.DisplaySubItemIndex = -1;
            this.cdvGroup7.DisplayText = "";
            this.cdvGroup7.Focusing = null;
            this.cdvGroup7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup7.Index = 0;
            this.cdvGroup7.IsViewBtnImage = false;
            this.cdvGroup7.Location = new System.Drawing.Point(172, 162);
            this.cdvGroup7.MaxLength = 30;
            this.cdvGroup7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MultiSelect = false;
            this.cdvGroup7.Name = "cdvGroup7";
            this.cdvGroup7.ReadOnly = false;
            this.cdvGroup7.SameWidthHeightOfButton = false;
            this.cdvGroup7.SearchSubItemIndex = 0;
            this.cdvGroup7.SelectedDescIndex = -1;
            this.cdvGroup7.SelectedDescToQueryText = "";
            this.cdvGroup7.SelectedSubItemIndex = -1;
            this.cdvGroup7.SelectedValueToQueryText = "";
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
            this.cdvGroup7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup6
            // 
            this.cdvGroup6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup6.BtnToolTipText = "";
            this.cdvGroup6.ButtonWidth = 20;
            this.cdvGroup6.DescText = "";
            this.cdvGroup6.DisplaySubItemIndex = -1;
            this.cdvGroup6.DisplayText = "";
            this.cdvGroup6.Focusing = null;
            this.cdvGroup6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup6.Index = 0;
            this.cdvGroup6.IsViewBtnImage = false;
            this.cdvGroup6.Location = new System.Drawing.Point(172, 138);
            this.cdvGroup6.MaxLength = 30;
            this.cdvGroup6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MultiSelect = false;
            this.cdvGroup6.Name = "cdvGroup6";
            this.cdvGroup6.ReadOnly = false;
            this.cdvGroup6.SameWidthHeightOfButton = false;
            this.cdvGroup6.SearchSubItemIndex = 0;
            this.cdvGroup6.SelectedDescIndex = -1;
            this.cdvGroup6.SelectedDescToQueryText = "";
            this.cdvGroup6.SelectedSubItemIndex = -1;
            this.cdvGroup6.SelectedValueToQueryText = "";
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
            this.cdvGroup6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup5
            // 
            this.cdvGroup5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup5.BtnToolTipText = "";
            this.cdvGroup5.ButtonWidth = 20;
            this.cdvGroup5.DescText = "";
            this.cdvGroup5.DisplaySubItemIndex = -1;
            this.cdvGroup5.DisplayText = "";
            this.cdvGroup5.Focusing = null;
            this.cdvGroup5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup5.Index = 0;
            this.cdvGroup5.IsViewBtnImage = false;
            this.cdvGroup5.Location = new System.Drawing.Point(172, 114);
            this.cdvGroup5.MaxLength = 30;
            this.cdvGroup5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MultiSelect = false;
            this.cdvGroup5.Name = "cdvGroup5";
            this.cdvGroup5.ReadOnly = false;
            this.cdvGroup5.SameWidthHeightOfButton = false;
            this.cdvGroup5.SearchSubItemIndex = 0;
            this.cdvGroup5.SelectedDescIndex = -1;
            this.cdvGroup5.SelectedDescToQueryText = "";
            this.cdvGroup5.SelectedSubItemIndex = -1;
            this.cdvGroup5.SelectedValueToQueryText = "";
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
            this.cdvGroup5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup4
            // 
            this.cdvGroup4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup4.BtnToolTipText = "";
            this.cdvGroup4.ButtonWidth = 20;
            this.cdvGroup4.DescText = "";
            this.cdvGroup4.DisplaySubItemIndex = -1;
            this.cdvGroup4.DisplayText = "";
            this.cdvGroup4.Focusing = null;
            this.cdvGroup4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup4.Index = 0;
            this.cdvGroup4.IsViewBtnImage = false;
            this.cdvGroup4.Location = new System.Drawing.Point(172, 90);
            this.cdvGroup4.MaxLength = 30;
            this.cdvGroup4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MultiSelect = false;
            this.cdvGroup4.Name = "cdvGroup4";
            this.cdvGroup4.ReadOnly = false;
            this.cdvGroup4.SameWidthHeightOfButton = false;
            this.cdvGroup4.SearchSubItemIndex = 0;
            this.cdvGroup4.SelectedDescIndex = -1;
            this.cdvGroup4.SelectedDescToQueryText = "";
            this.cdvGroup4.SelectedSubItemIndex = -1;
            this.cdvGroup4.SelectedValueToQueryText = "";
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
            this.cdvGroup4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup3
            // 
            this.cdvGroup3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup3.BtnToolTipText = "";
            this.cdvGroup3.ButtonWidth = 20;
            this.cdvGroup3.DescText = "";
            this.cdvGroup3.DisplaySubItemIndex = -1;
            this.cdvGroup3.DisplayText = "";
            this.cdvGroup3.Focusing = null;
            this.cdvGroup3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup3.Index = 0;
            this.cdvGroup3.IsViewBtnImage = false;
            this.cdvGroup3.Location = new System.Drawing.Point(172, 66);
            this.cdvGroup3.MaxLength = 30;
            this.cdvGroup3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MultiSelect = false;
            this.cdvGroup3.Name = "cdvGroup3";
            this.cdvGroup3.ReadOnly = false;
            this.cdvGroup3.SameWidthHeightOfButton = false;
            this.cdvGroup3.SearchSubItemIndex = 0;
            this.cdvGroup3.SelectedDescIndex = -1;
            this.cdvGroup3.SelectedDescToQueryText = "";
            this.cdvGroup3.SelectedSubItemIndex = -1;
            this.cdvGroup3.SelectedValueToQueryText = "";
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
            this.cdvGroup3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup2
            // 
            this.cdvGroup2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup2.BtnToolTipText = "";
            this.cdvGroup2.ButtonWidth = 20;
            this.cdvGroup2.DescText = "";
            this.cdvGroup2.DisplaySubItemIndex = -1;
            this.cdvGroup2.DisplayText = "";
            this.cdvGroup2.Focusing = null;
            this.cdvGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup2.Index = 0;
            this.cdvGroup2.IsViewBtnImage = false;
            this.cdvGroup2.Location = new System.Drawing.Point(172, 42);
            this.cdvGroup2.MaxLength = 30;
            this.cdvGroup2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MultiSelect = false;
            this.cdvGroup2.Name = "cdvGroup2";
            this.cdvGroup2.ReadOnly = false;
            this.cdvGroup2.SameWidthHeightOfButton = false;
            this.cdvGroup2.SearchSubItemIndex = 0;
            this.cdvGroup2.SelectedDescIndex = -1;
            this.cdvGroup2.SelectedDescToQueryText = "";
            this.cdvGroup2.SelectedSubItemIndex = -1;
            this.cdvGroup2.SelectedValueToQueryText = "";
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
            this.cdvGroup2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup10
            // 
            this.cdvGroup10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup10.BtnToolTipText = "";
            this.cdvGroup10.ButtonWidth = 20;
            this.cdvGroup10.DescText = "";
            this.cdvGroup10.DisplaySubItemIndex = -1;
            this.cdvGroup10.DisplayText = "";
            this.cdvGroup10.Focusing = null;
            this.cdvGroup10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup10.Index = 0;
            this.cdvGroup10.IsViewBtnImage = false;
            this.cdvGroup10.Location = new System.Drawing.Point(172, 234);
            this.cdvGroup10.MaxLength = 30;
            this.cdvGroup10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MultiSelect = false;
            this.cdvGroup10.Name = "cdvGroup10";
            this.cdvGroup10.ReadOnly = false;
            this.cdvGroup10.SameWidthHeightOfButton = false;
            this.cdvGroup10.SearchSubItemIndex = 0;
            this.cdvGroup10.SelectedDescIndex = -1;
            this.cdvGroup10.SelectedDescToQueryText = "";
            this.cdvGroup10.SelectedSubItemIndex = -1;
            this.cdvGroup10.SelectedValueToQueryText = "";
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
            this.cdvGroup10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup1
            // 
            this.cdvGroup1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup1.BtnToolTipText = "";
            this.cdvGroup1.ButtonWidth = 20;
            this.cdvGroup1.DescText = "";
            this.cdvGroup1.DisplaySubItemIndex = -1;
            this.cdvGroup1.DisplayText = "";
            this.cdvGroup1.Focusing = null;
            this.cdvGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup1.Index = 0;
            this.cdvGroup1.IsViewBtnImage = false;
            this.cdvGroup1.Location = new System.Drawing.Point(172, 18);
            this.cdvGroup1.MaxLength = 30;
            this.cdvGroup1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MultiSelect = false;
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = false;
            this.cdvGroup1.SameWidthHeightOfButton = false;
            this.cdvGroup1.SearchSubItemIndex = 0;
            this.cdvGroup1.SelectedDescIndex = -1;
            this.cdvGroup1.SelectedDescToQueryText = "";
            this.cdvGroup1.SelectedSubItemIndex = -1;
            this.cdvGroup1.SelectedValueToQueryText = "";
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
            this.cdvGroup1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // lblGroup10
            // 
            this.lblGroup10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup10.Location = new System.Drawing.Point(16, 237);
            this.lblGroup10.Name = "lblGroup10";
            this.lblGroup10.Size = new System.Drawing.Size(150, 14);
            this.lblGroup10.TabIndex = 18;
            this.lblGroup10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup9
            // 
            this.lblGroup9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup9.Location = new System.Drawing.Point(16, 213);
            this.lblGroup9.Name = "lblGroup9";
            this.lblGroup9.Size = new System.Drawing.Size(150, 14);
            this.lblGroup9.TabIndex = 16;
            this.lblGroup9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup8
            // 
            this.lblGroup8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup8.Location = new System.Drawing.Point(16, 189);
            this.lblGroup8.Name = "lblGroup8";
            this.lblGroup8.Size = new System.Drawing.Size(150, 14);
            this.lblGroup8.TabIndex = 14;
            this.lblGroup8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup7
            // 
            this.lblGroup7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup7.Location = new System.Drawing.Point(16, 165);
            this.lblGroup7.Name = "lblGroup7";
            this.lblGroup7.Size = new System.Drawing.Size(150, 14);
            this.lblGroup7.TabIndex = 12;
            this.lblGroup7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup6
            // 
            this.lblGroup6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup6.Location = new System.Drawing.Point(16, 141);
            this.lblGroup6.Name = "lblGroup6";
            this.lblGroup6.Size = new System.Drawing.Size(150, 14);
            this.lblGroup6.TabIndex = 10;
            this.lblGroup6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup5
            // 
            this.lblGroup5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup5.Location = new System.Drawing.Point(16, 117);
            this.lblGroup5.Name = "lblGroup5";
            this.lblGroup5.Size = new System.Drawing.Size(150, 14);
            this.lblGroup5.TabIndex = 8;
            this.lblGroup5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup4
            // 
            this.lblGroup4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup4.Location = new System.Drawing.Point(16, 93);
            this.lblGroup4.Name = "lblGroup4";
            this.lblGroup4.Size = new System.Drawing.Size(150, 14);
            this.lblGroup4.TabIndex = 6;
            this.lblGroup4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup3
            // 
            this.lblGroup3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup3.Location = new System.Drawing.Point(16, 69);
            this.lblGroup3.Name = "lblGroup3";
            this.lblGroup3.Size = new System.Drawing.Size(150, 14);
            this.lblGroup3.TabIndex = 4;
            this.lblGroup3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup2
            // 
            this.lblGroup2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup2.Location = new System.Drawing.Point(16, 45);
            this.lblGroup2.Name = "lblGroup2";
            this.lblGroup2.Size = new System.Drawing.Size(150, 14);
            this.lblGroup2.TabIndex = 2;
            this.lblGroup2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGroup1
            // 
            this.lblGroup1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup1.Location = new System.Drawing.Point(16, 21);
            this.lblGroup1.Name = "lblGroup1";
            this.lblGroup1.Size = new System.Drawing.Size(150, 14);
            this.lblGroup1.TabIndex = 0;
            this.lblGroup1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpAttachOper
            // 
            this.tbpAttachOper.Controls.Add(this.pnlAttachOperFill);
            this.tbpAttachOper.Location = new System.Drawing.Point(4, 22);
            this.tbpAttachOper.Name = "tbpAttachOper";
            this.tbpAttachOper.Size = new System.Drawing.Size(492, 391);
            this.tbpAttachOper.TabIndex = 2;
            this.tbpAttachOper.Text = "Attach Operation";
            this.tbpAttachOper.Visible = false;
            // 
            // pnlAttachOperFill
            // 
            this.pnlAttachOperFill.Controls.Add(this.pnlOperList);
            this.pnlAttachOperFill.Controls.Add(this.pnlAttachOper);
            this.pnlAttachOperFill.Controls.Add(this.pnlAttachOperMid);
            this.pnlAttachOperFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttachOperFill.Location = new System.Drawing.Point(0, 0);
            this.pnlAttachOperFill.Name = "pnlAttachOperFill";
            this.pnlAttachOperFill.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlAttachOperFill.Size = new System.Drawing.Size(492, 391);
            this.pnlAttachOperFill.TabIndex = 0;
            this.pnlAttachOperFill.Resize += new System.EventHandler(this.pnlAttachOperFill_Resize);
            // 
            // pnlOperList
            // 
            this.pnlOperList.Controls.Add(this.pnlOperListFill);
            this.pnlOperList.Controls.Add(this.pnlOperListTop);
            this.pnlOperList.Location = new System.Drawing.Point(272, 16);
            this.pnlOperList.Name = "pnlOperList";
            this.pnlOperList.Size = new System.Drawing.Size(216, 386);
            this.pnlOperList.TabIndex = 6;
            // 
            // pnlOperListFill
            // 
            this.pnlOperListFill.Controls.Add(this.lisOperList);
            this.pnlOperListFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOperListFill.Location = new System.Drawing.Point(0, 74);
            this.pnlOperListFill.Name = "pnlOperListFill";
            this.pnlOperListFill.Size = new System.Drawing.Size(216, 312);
            this.pnlOperListFill.TabIndex = 4;
            // 
            // lisOperList
            // 
            this.lisOperList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOperation,
            this.colOperationDesc});
            this.lisOperList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisOperList.EnableSort = true;
            this.lisOperList.EnableSortIcon = true;
            this.lisOperList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisOperList.FullRowSelect = true;
            this.lisOperList.Location = new System.Drawing.Point(0, 0);
            this.lisOperList.Name = "lisOperList";
            this.lisOperList.Size = new System.Drawing.Size(216, 312);
            this.lisOperList.TabIndex = 0;
            this.lisOperList.UseCompatibleStateImageBehavior = false;
            this.lisOperList.View = System.Windows.Forms.View.Details;
            this.lisOperList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lisOperList_ColumnClick);
            // 
            // colOperation
            // 
            this.colOperation.Text = "Operation";
            this.colOperation.Width = 68;
            // 
            // colOperationDesc
            // 
            this.colOperationDesc.Text = "Description";
            this.colOperationDesc.Width = 129;
            // 
            // pnlOperListTop
            // 
            this.pnlOperListTop.Controls.Add(this.cdvOptionalGroupOption);
            this.pnlOperListTop.Controls.Add(this.lblOptionalGroupOption);
            this.pnlOperListTop.Controls.Add(this.cdvOptionalGroup);
            this.pnlOperListTop.Controls.Add(this.lblOptionalGroup);
            this.pnlOperListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOperListTop.Location = new System.Drawing.Point(0, 0);
            this.pnlOperListTop.Name = "pnlOperListTop";
            this.pnlOperListTop.Size = new System.Drawing.Size(216, 74);
            this.pnlOperListTop.TabIndex = 0;
            // 
            // cdvOptionalGroupOption
            // 
            this.cdvOptionalGroupOption.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOptionalGroupOption.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOptionalGroupOption.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOptionalGroupOption.BtnToolTipText = "";
            this.cdvOptionalGroupOption.ButtonWidth = 20;
            this.cdvOptionalGroupOption.DescText = "";
            this.cdvOptionalGroupOption.DisplaySubItemIndex = 0;
            this.cdvOptionalGroupOption.DisplayText = "";
            this.cdvOptionalGroupOption.Focusing = null;
            this.cdvOptionalGroupOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOptionalGroupOption.Index = 0;
            this.cdvOptionalGroupOption.IsViewBtnImage = false;
            this.cdvOptionalGroupOption.Location = new System.Drawing.Point(0, 52);
            this.cdvOptionalGroupOption.MaxLength = 1;
            this.cdvOptionalGroupOption.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOptionalGroupOption.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOptionalGroupOption.MultiSelect = false;
            this.cdvOptionalGroupOption.Name = "cdvOptionalGroupOption";
            this.cdvOptionalGroupOption.ReadOnly = false;
            this.cdvOptionalGroupOption.SameWidthHeightOfButton = false;
            this.cdvOptionalGroupOption.SearchSubItemIndex = 0;
            this.cdvOptionalGroupOption.SelectedDescIndex = -1;
            this.cdvOptionalGroupOption.SelectedDescToQueryText = "";
            this.cdvOptionalGroupOption.SelectedSubItemIndex = 0;
            this.cdvOptionalGroupOption.SelectedValueToQueryText = "";
            this.cdvOptionalGroupOption.SelectionStart = 0;
            this.cdvOptionalGroupOption.Size = new System.Drawing.Size(176, 20);
            this.cdvOptionalGroupOption.SmallImageList = null;
            this.cdvOptionalGroupOption.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOptionalGroupOption.TabIndex = 3;
            this.cdvOptionalGroupOption.TextBoxToolTipText = "";
            this.cdvOptionalGroupOption.TextBoxWidth = 176;
            this.cdvOptionalGroupOption.VisibleButton = false;
            this.cdvOptionalGroupOption.VisibleColumnHeader = false;
            this.cdvOptionalGroupOption.VisibleDescription = false;
            // 
            // lblOptionalGroupOption
            // 
            this.lblOptionalGroupOption.AutoSize = true;
            this.lblOptionalGroupOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOptionalGroupOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionalGroupOption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOptionalGroupOption.Location = new System.Drawing.Point(2, 38);
            this.lblOptionalGroupOption.Name = "lblOptionalGroupOption";
            this.lblOptionalGroupOption.Size = new System.Drawing.Size(112, 13);
            this.lblOptionalGroupOption.TabIndex = 2;
            this.lblOptionalGroupOption.Text = "Optional Group Option";
            // 
            // cdvOptionalGroup
            // 
            this.cdvOptionalGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOptionalGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOptionalGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOptionalGroup.BtnToolTipText = "";
            this.cdvOptionalGroup.ButtonWidth = 20;
            this.cdvOptionalGroup.DescText = "";
            this.cdvOptionalGroup.DisplaySubItemIndex = 0;
            this.cdvOptionalGroup.DisplayText = "";
            this.cdvOptionalGroup.Focusing = null;
            this.cdvOptionalGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOptionalGroup.Index = 0;
            this.cdvOptionalGroup.IsViewBtnImage = false;
            this.cdvOptionalGroup.Location = new System.Drawing.Point(0, 16);
            this.cdvOptionalGroup.MaxLength = 20;
            this.cdvOptionalGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOptionalGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOptionalGroup.MultiSelect = false;
            this.cdvOptionalGroup.Name = "cdvOptionalGroup";
            this.cdvOptionalGroup.ReadOnly = false;
            this.cdvOptionalGroup.SameWidthHeightOfButton = false;
            this.cdvOptionalGroup.SearchSubItemIndex = 0;
            this.cdvOptionalGroup.SelectedDescIndex = -1;
            this.cdvOptionalGroup.SelectedDescToQueryText = "";
            this.cdvOptionalGroup.SelectedSubItemIndex = 0;
            this.cdvOptionalGroup.SelectedValueToQueryText = "";
            this.cdvOptionalGroup.SelectionStart = 0;
            this.cdvOptionalGroup.Size = new System.Drawing.Size(176, 20);
            this.cdvOptionalGroup.SmallImageList = null;
            this.cdvOptionalGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOptionalGroup.TabIndex = 1;
            this.cdvOptionalGroup.TextBoxToolTipText = "";
            this.cdvOptionalGroup.TextBoxWidth = 176;
            this.cdvOptionalGroup.VisibleButton = false;
            this.cdvOptionalGroup.VisibleColumnHeader = false;
            this.cdvOptionalGroup.VisibleDescription = false;
            // 
            // lblOptionalGroup
            // 
            this.lblOptionalGroup.AutoSize = true;
            this.lblOptionalGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOptionalGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionalGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOptionalGroup.Location = new System.Drawing.Point(2, 2);
            this.lblOptionalGroup.Name = "lblOptionalGroup";
            this.lblOptionalGroup.Size = new System.Drawing.Size(78, 13);
            this.lblOptionalGroup.TabIndex = 0;
            this.lblOptionalGroup.Text = "Optional Group";
            // 
            // pnlAttachOper
            // 
            this.pnlAttachOper.Controls.Add(this.lisAttachOper);
            this.pnlAttachOper.Location = new System.Drawing.Point(10, 32);
            this.pnlAttachOper.Name = "pnlAttachOper";
            this.pnlAttachOper.Size = new System.Drawing.Size(192, 360);
            this.pnlAttachOper.TabIndex = 3;
            // 
            // lisAttachOper
            // 
            this.lisAttachOper.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAttachOperation,
            this.colAttachOperationDesc,
            this.colAttachOperationGroup,
            this.colAttachOperationOption});
            this.lisAttachOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachOper.EnableSort = false;
            this.lisAttachOper.EnableSortIcon = false;
            this.lisAttachOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachOper.FullRowSelect = true;
            this.lisAttachOper.Location = new System.Drawing.Point(0, 0);
            this.lisAttachOper.Name = "lisAttachOper";
            this.lisAttachOper.Size = new System.Drawing.Size(192, 360);
            this.lisAttachOper.TabIndex = 0;
            this.lisAttachOper.UseCompatibleStateImageBehavior = false;
            this.lisAttachOper.View = System.Windows.Forms.View.Details;
            this.lisAttachOper.SelectedIndexChanged += new System.EventHandler(this.lisAttachOper_SelectedIndexChanged);
            // 
            // colAttachOperation
            // 
            this.colAttachOperation.Text = "Operation";
            this.colAttachOperation.Width = 69;
            // 
            // colAttachOperationDesc
            // 
            this.colAttachOperationDesc.Text = "Description";
            this.colAttachOperationDesc.Width = 128;
            // 
            // colAttachOperationGroup
            // 
            this.colAttachOperationGroup.Text = "Group";
            this.colAttachOperationGroup.Width = 50;
            // 
            // colAttachOperationOption
            // 
            this.colAttachOperationOption.Text = "Option";
            this.colAttachOperationOption.Width = 50;
            // 
            // pnlAttachOperMid
            // 
            this.pnlAttachOperMid.Controls.Add(this.btnOperExcel);
            this.pnlAttachOperMid.Controls.Add(this.btnDown);
            this.pnlAttachOperMid.Controls.Add(this.btnUp);
            this.pnlAttachOperMid.Controls.Add(this.btnToRight);
            this.pnlAttachOperMid.Controls.Add(this.btnToLeft);
            this.pnlAttachOperMid.Location = new System.Drawing.Point(212, 64);
            this.pnlAttachOperMid.Name = "pnlAttachOperMid";
            this.pnlAttachOperMid.Size = new System.Drawing.Size(46, 277);
            this.pnlAttachOperMid.TabIndex = 4;
            // 
            // btnOperExcel
            // 
            this.btnOperExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOperExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOperExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnOperExcel.Image")));
            this.btnOperExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOperExcel.Location = new System.Drawing.Point(3, 250);
            this.btnOperExcel.Name = "btnOperExcel";
            this.btnOperExcel.Size = new System.Drawing.Size(24, 24);
            this.btnOperExcel.TabIndex = 9;
            this.btnOperExcel.Click += new System.EventHandler(this.btnOperExcel_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(3, 222);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 24);
            this.btnDown.TabIndex = 7;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Location = new System.Drawing.Point(3, 196);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 24);
            this.btnUp.TabIndex = 6;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToRight.Location = new System.Drawing.Point(11, 141);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(24, 24);
            this.btnToRight.TabIndex = 5;
            this.btnToRight.Text = ">";
            this.btnToRight.Click += new System.EventHandler(this.btnToRight_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToLeft.Location = new System.Drawing.Point(11, 112);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(24, 24);
            this.btnToLeft.TabIndex = 4;
            this.btnToLeft.Text = "< ";
            this.btnToLeft.Click += new System.EventHandler(this.btnToLeft_Click);
            // 
            // tbpAttribute
            // 
            this.tbpAttribute.Controls.Add(this.udcAttributeStatus);
            this.tbpAttribute.Location = new System.Drawing.Point(4, 22);
            this.tbpAttribute.Name = "tbpAttribute";
            this.tbpAttribute.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAttribute.Size = new System.Drawing.Size(492, 391);
            this.tbpAttribute.TabIndex = 5;
            this.tbpAttribute.Text = "Attribute";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeFactory = "";
            this.udcAttributeStatus.AttributeKey = this.txtFlow.Text;
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW_AND_UPDATE;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "FLOW";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(3, 3);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(486, 385);
            this.udcAttributeStatus.TabIndex = 1;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.pnlCMFFill);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Size = new System.Drawing.Size(492, 391);
            this.tbpCMF.TabIndex = 1;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.Visible = false;
            // 
            // pnlCMFFill
            // 
            this.pnlCMFFill.Controls.Add(this.grpCMF);
            this.pnlCMFFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCMFFill.Location = new System.Drawing.Point(0, 0);
            this.pnlCMFFill.Name = "pnlCMFFill";
            this.pnlCMFFill.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlCMFFill.Size = new System.Drawing.Size(492, 391);
            this.pnlCMFFill.TabIndex = 0;
            // 
            // grpCMF
            // 
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
            this.grpCMF.Location = new System.Drawing.Point(3, 5);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(486, 383);
            this.grpCMF.TabIndex = 1;
            this.grpCMF.TabStop = false;
            this.grpCMF.Text = "Customized Field (1~20)";
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
            this.cdvCMF19.Location = new System.Drawing.Point(347, 210);
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
            this.cdvCMF19.TabIndex = 37;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 130;
            this.cdvCMF19.VisibleButton = true;
            this.cdvCMF19.VisibleColumnHeader = false;
            this.cdvCMF19.VisibleDescription = false;
            this.cdvCMF19.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF19.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF18.Location = new System.Drawing.Point(347, 186);
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
            this.cdvCMF18.TabIndex = 35;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 130;
            this.cdvCMF18.VisibleButton = true;
            this.cdvCMF18.VisibleColumnHeader = false;
            this.cdvCMF18.VisibleDescription = false;
            this.cdvCMF18.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF18.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF17.Location = new System.Drawing.Point(347, 162);
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
            this.cdvCMF17.TabIndex = 33;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 130;
            this.cdvCMF17.VisibleButton = true;
            this.cdvCMF17.VisibleColumnHeader = false;
            this.cdvCMF17.VisibleDescription = false;
            this.cdvCMF17.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF17.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF16.Location = new System.Drawing.Point(347, 138);
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
            this.cdvCMF16.TabIndex = 31;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 130;
            this.cdvCMF16.VisibleButton = true;
            this.cdvCMF16.VisibleColumnHeader = false;
            this.cdvCMF16.VisibleDescription = false;
            this.cdvCMF16.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF16.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF15.Location = new System.Drawing.Point(347, 114);
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
            this.cdvCMF15.TabIndex = 29;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 130;
            this.cdvCMF15.VisibleButton = true;
            this.cdvCMF15.VisibleColumnHeader = false;
            this.cdvCMF15.VisibleDescription = false;
            this.cdvCMF15.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF15.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF14.Location = new System.Drawing.Point(347, 90);
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
            this.cdvCMF14.TabIndex = 27;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 130;
            this.cdvCMF14.VisibleButton = true;
            this.cdvCMF14.VisibleColumnHeader = false;
            this.cdvCMF14.VisibleDescription = false;
            this.cdvCMF14.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF14.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF13.Location = new System.Drawing.Point(347, 66);
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
            this.cdvCMF13.TabIndex = 25;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 130;
            this.cdvCMF13.VisibleButton = true;
            this.cdvCMF13.VisibleColumnHeader = false;
            this.cdvCMF13.VisibleDescription = false;
            this.cdvCMF13.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF13.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF12.Location = new System.Drawing.Point(347, 42);
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
            this.cdvCMF12.TabIndex = 23;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 130;
            this.cdvCMF12.VisibleButton = true;
            this.cdvCMF12.VisibleColumnHeader = false;
            this.cdvCMF12.VisibleDescription = false;
            this.cdvCMF12.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF12.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF20.Location = new System.Drawing.Point(347, 234);
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
            this.cdvCMF20.TabIndex = 39;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 130;
            this.cdvCMF20.VisibleButton = true;
            this.cdvCMF20.VisibleColumnHeader = false;
            this.cdvCMF20.VisibleDescription = false;
            this.cdvCMF20.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF20.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF11.Location = new System.Drawing.Point(347, 18);
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
            this.cdvCMF11.TabIndex = 21;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 130;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            this.cdvCMF11.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(251, 238);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(90, 14);
            this.lblCMF20.TabIndex = 38;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(251, 214);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(90, 14);
            this.lblCMF19.TabIndex = 36;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(251, 190);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(90, 14);
            this.lblCMF18.TabIndex = 34;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(251, 166);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(90, 14);
            this.lblCMF17.TabIndex = 32;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(251, 142);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(90, 14);
            this.lblCMF16.TabIndex = 30;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(251, 118);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(90, 14);
            this.lblCMF15.TabIndex = 28;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(251, 94);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(90, 14);
            this.lblCMF14.TabIndex = 26;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(251, 70);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(90, 14);
            this.lblCMF13.TabIndex = 24;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(251, 46);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(90, 14);
            this.lblCMF12.TabIndex = 22;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(251, 22);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(90, 14);
            this.lblCMF11.TabIndex = 20;
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
            this.cdvCMF9.Location = new System.Drawing.Point(104, 210);
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
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 130;
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            this.cdvCMF9.VisibleDescription = false;
            this.cdvCMF9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF8.Location = new System.Drawing.Point(104, 186);
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
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 130;
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            this.cdvCMF8.VisibleDescription = false;
            this.cdvCMF8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF7.Location = new System.Drawing.Point(104, 162);
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
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 130;
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            this.cdvCMF7.VisibleDescription = false;
            this.cdvCMF7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF6.Location = new System.Drawing.Point(104, 138);
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
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 130;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF5.Location = new System.Drawing.Point(104, 114);
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
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 130;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF4.Location = new System.Drawing.Point(104, 90);
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
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 130;
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            this.cdvCMF4.VisibleDescription = false;
            this.cdvCMF4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF3.Location = new System.Drawing.Point(104, 66);
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
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 130;
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            this.cdvCMF3.VisibleDescription = false;
            this.cdvCMF3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF2.Location = new System.Drawing.Point(104, 42);
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
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 130;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF10.Location = new System.Drawing.Point(104, 234);
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
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 130;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
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
            this.cdvCMF1.Location = new System.Drawing.Point(104, 18);
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
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 130;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCmf_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(8, 238);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(90, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(8, 214);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(90, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(8, 190);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(90, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(8, 166);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(90, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(8, 142);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(90, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(8, 118);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(90, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(8, 94);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(90, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(8, 70);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(90, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(8, 46);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(90, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(8, 22);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(90, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCopyFlow
            // 
            this.tbpCopyFlow.Controls.Add(this.pnlCopyFlowFill);
            this.tbpCopyFlow.Location = new System.Drawing.Point(4, 22);
            this.tbpCopyFlow.Name = "tbpCopyFlow";
            this.tbpCopyFlow.Size = new System.Drawing.Size(492, 391);
            this.tbpCopyFlow.TabIndex = 4;
            this.tbpCopyFlow.Text = "Copy Flow";
            // 
            // pnlCopyFlowFill
            // 
            this.pnlCopyFlowFill.Controls.Add(this.grpCopyFlow);
            this.pnlCopyFlowFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCopyFlowFill.Location = new System.Drawing.Point(0, 0);
            this.pnlCopyFlowFill.Name = "pnlCopyFlowFill";
            this.pnlCopyFlowFill.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlCopyFlowFill.Size = new System.Drawing.Size(492, 391);
            this.pnlCopyFlowFill.TabIndex = 0;
            // 
            // grpCopyFlow
            // 
            this.grpCopyFlow.Controls.Add(this.btnCopy);
            this.grpCopyFlow.Controls.Add(this.lblToFlow);
            this.grpCopyFlow.Controls.Add(this.txtToFlow);
            this.grpCopyFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyFlow.Location = new System.Drawing.Point(3, 5);
            this.grpCopyFlow.Name = "grpCopyFlow";
            this.grpCopyFlow.Size = new System.Drawing.Size(486, 47);
            this.grpCopyFlow.TabIndex = 0;
            this.grpCopyFlow.TabStop = false;
            this.grpCopyFlow.Text = "Copy Flow";
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(318, 15);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(80, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblToFlow
            // 
            this.lblToFlow.AutoSize = true;
            this.lblToFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToFlow.Location = new System.Drawing.Point(20, 19);
            this.lblToFlow.Name = "lblToFlow";
            this.lblToFlow.Size = new System.Drawing.Size(45, 13);
            this.lblToFlow.TabIndex = 0;
            this.lblToFlow.Text = "To Flow";
            this.lblToFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToFlow
            // 
            this.txtToFlow.Location = new System.Drawing.Point(115, 16);
            this.txtToFlow.MaxLength = 20;
            this.txtToFlow.Name = "txtToFlow";
            this.txtToFlow.Size = new System.Drawing.Size(200, 20);
            this.txtToFlow.TabIndex = 1;
            // 
            // frmWIPSetupFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPSetupFlow";
            this.Text = "Flow Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupFlow_Activated);
            this.Load += new System.EventHandler(this.frmWIPSetupFlow_Load);
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
            this.grpFlow.ResumeLayout(false);
            this.grpFlow.PerformLayout();
            this.pnlRightFill.ResumeLayout(false);
            this.tabFlow.ResumeLayout(false);
            this.tbpGroup.ResumeLayout(false);
            this.pnlGroupFill.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            this.tbpAttachOper.ResumeLayout(false);
            this.pnlAttachOperFill.ResumeLayout(false);
            this.pnlOperList.ResumeLayout(false);
            this.pnlOperListFill.ResumeLayout(false);
            this.pnlOperListTop.ResumeLayout(false);
            this.pnlOperListTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionalGroupOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOptionalGroup)).EndInit();
            this.pnlAttachOper.ResumeLayout(false);
            this.pnlAttachOperMid.ResumeLayout(false);
            this.tbpAttribute.ResumeLayout(false);
            this.tbpCMF.ResumeLayout(false);
            this.pnlCMFFill.ResumeLayout(false);
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
            this.tbpCopyFlow.ResumeLayout(false);
            this.pnlCopyFlowFill.ResumeLayout(false);
            this.grpCopyFlow.ResumeLayout(false);
            this.grpCopyFlow.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool LoadFlag;
        private bool b_is_work = false;
        
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
        private void ClearData(string ProcStep)
        {
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this);
                }
                else if (ProcStep == "2")
                {
                    lisFlow.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];
            
            sGrpTableName[0] = MPGC.MP_GCM_FLOW_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_FLOW_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_FLOW_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_FLOW_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_FLOW_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_FLOW_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_FLOW_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_FLOW_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_FLOW_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_FLOW_GRP_10;
            
            MPCR.SetGRPItem(MPGC.MP_GRP_FLOW, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
            MPCR.SetCMFItem(MPGC.MP_CMF_FLOW, "lblCMF", "cdvCmf", grpCMF);
            
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

            if (MPCF.CheckValue(txtFlow, 1) == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":
                    
                    if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    {
                        tabFlow.SelectedTab = tbpGroup;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCmf", grpCMF) == false)
                    {
                        tabFlow.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
                case "UPDATE":
                    
                    if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    {
                        tabFlow.SelectedTab = tbpGroup;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCmf", grpCMF) == false)
                    {
                        tabFlow.SelectedTab = tbpCMF;
                        return false;
                    }
                    break;
                case "ATTACH_OPER":
                    
                    if (lisOperList.SelectedItems.Count <= 0 || lisAttachOper.SelectedItems.Count <= 0)
                    {
                        return false;
                    }
                    break;
                case "DETACH_OPER":
                    
                    if (lisAttachOper.SelectedItems.Count <= 0)
                    {
                        return false;
                    }
                    if (lisAttachOper.SelectedItems[0].Index >= lisAttachOper.Items.Count - 1)
                    {
                        return false;
                    }
                    break;
                case "UPDATE_OPTIONAL_GROUP":
                    
                    if (lisAttachOper.SelectedItems.Count <= 0)
                    {
                        return false;
                    }
                    if (lisAttachOper.SelectedItems[0].Index >= lisAttachOper.Items.Count - 1)
                    {
                        return false;
                    }
                    break;
            }
            
            return true;
            
        }

        private bool Update_Flow(char ProcStep)
        {

            TRSNode in_node = new TRSNode("UPDATE_FLOW_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            ListViewItem itm;
            int idx;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FLOW", MPCF.Trim(txtFlow.Text));
                in_node.AddString("FLOW_DESC", MPCF.Trim(txtFlowDesc.Text));
                in_node.AddString("FLOW_SHORT_DESC", MPCF.Trim(txtFlowShortDesc.Text));

                in_node.AddString("FLOW_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("FLOW_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("FLOW_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("FLOW_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("FLOW_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("FLOW_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("FLOW_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("FLOW_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("FLOW_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("FLOW_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("FLOW_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("FLOW_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("FLOW_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("FLOW_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("FLOW_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("FLOW_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("FLOW_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("FLOW_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("FLOW_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("FLOW_CMF_20", MPCF.Trim(cdvCMF20.Text));

                in_node.AddString("FLOW_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("FLOW_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("FLOW_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("FLOW_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("FLOW_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("FLOW_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("FLOW_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("FLOW_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("FLOW_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("FLOW_GRP_10", MPCF.Trim(cdvGroup10.Text));

                if (MPCR.CallService("WIP", "WIP_Update_Flow", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisFlow.Items.Add(txtFlow.Text, (int)SMALLICON_INDEX.IDX_FLOW);
                        itm.SubItems.Add(txtFlowDesc.Text);
                        itm.Selected = true;
                        lisFlow.Sorting = SortOrder.Ascending;
                        lisFlow.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisFlow, MPCF.Trim(txtFlow.Text), false) == true)
                        {
                            lisFlow.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtFlowDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisFlow, MPCF.Trim(txtFlow.Text), false);
                        if (idx != -1)
                        {
                            lisFlow.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisFlow.Items.Count.ToString();
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
        // View_Flow()
        //       - View Flow Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Flow()
        {

            TRSNode in_node = new TRSNode("VIEW_FLOW_IN");
            TRSNode out_node = new TRSNode("VIEW_FLOW_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(txtFlow.Text));

            if (MPCR.CallService("WIP", "WIP_View_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            txtFlow.Text = MPCF.Trim(out_node.GetString("FLOW"));
            txtFlowDesc.Text = MPCF.Trim(out_node.GetString("FLOW_DESC"));
            txtFlowShortDesc.Text = MPCF.Trim(out_node.GetString("FLOW_SHORT_DESC"));

            cdvGroup1.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_1"));
            cdvGroup2.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_2"));
            cdvGroup3.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_3"));
            cdvGroup4.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_4"));
            cdvGroup5.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_5"));
            cdvGroup6.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_6"));
            cdvGroup7.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_7"));
            cdvGroup8.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_8"));
            cdvGroup9.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_9"));
            cdvGroup10.Text = MPCF.Trim(out_node.GetString("FLOW_GRP_10"));

            cdvCMF1.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_1"));
            cdvCMF2.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_2"));
            cdvCMF3.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_3"));
            cdvCMF4.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_4"));
            cdvCMF5.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_5"));
            cdvCMF6.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_6"));
            cdvCMF7.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_7"));
            cdvCMF8.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_8"));
            cdvCMF9.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_9"));
            cdvCMF10.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_10"));
            cdvCMF11.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_11"));
            cdvCMF12.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_12"));
            cdvCMF13.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_13"));
            cdvCMF14.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_14"));
            cdvCMF15.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_15"));
            cdvCMF16.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_16"));
            cdvCMF17.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_17"));
            cdvCMF18.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_18"));
            cdvCMF19.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_19"));
            cdvCMF20.Text = MPCF.Trim(out_node.GetString("FLOW_CMF_20"));

            udcAttributeStatus.AttributeKey = txtFlow.Text;
            udcAttributeStatus.View();

            return true;

        }

        private bool Attach_Oper_ToFlow(string sFlow, string sAttachOper, string sBeforeOper)
        {

            TRSNode in_node = new TRSNode("ATTACH_OPER_TOFLOW_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("FLOW", MPCF.Trim(sFlow));
            in_node.AddString("OPER", MPCF.Trim(sAttachOper));
            in_node.AddString("ADD_BEFORE_OPER", MPCF.Trim(sBeforeOper));

            if (MPCR.CallService("WIP", "WIP_Attach_Oper_ToFlow", in_node, ref out_node) == false)
            {
                return false;
            }

            if (Update_Optional_Oper(sFlow, sAttachOper, true) == false)
            {
                cdvOptionalGroup.Text = "";
                cdvOptionalGroupOption.Text = "";
            }

            return true;

        }

        private bool Detach_Oper_FromFlow(string sFlow, string sOper)
        {

            TRSNode in_node = new TRSNode("DETACH_OPER_FROMFLOW_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("FLOW", MPCF.Trim(sFlow));
            in_node.AddString("OPER", MPCF.Trim(sOper));

            if (MPCR.CallService("WIP", "WIP_Detach_Oper_FromFlow", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;

        }

        private bool Copy_Flow(string sToFlow)
        {
            TRSNode in_node = new TRSNode("COPY_FLOW_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            ListViewItem itm;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("FLOW", MPCF.Trim(txtFlow.Text));
            in_node.AddString("TO_FLOW", MPCF.Trim(sToFlow));

            if (MPCR.CallService("WIP", "WIP_Copy_Flow", in_node, ref out_node) == false)
            {
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);

            if (MPGV.gbListAutoRefresh == false)
            {
                itm = lisFlow.Items.Add(sToFlow, (int)SMALLICON_INDEX.IDX_FLOW);
                itm.SubItems.Add(txtFlowDesc.Text);
                itm.Selected = true;
                lisFlow.Sorting = SortOrder.Ascending;
                lisFlow.Sort();
                itm.EnsureVisible();
                lblDataCount.Text = lisFlow.Items.Count.ToString();
            }

            return true;

        }

        //
        // Update_Optional_Oper()
        //       - Update Optional Oper Group
        // Return Value
        //       - boolean : True / False
        // Arguments
        //        -
        //
        private bool Update_Optional_Oper(string sFlow, string sOper, bool bNoSuccessMessage)
        {
            TRSNode in_node = new TRSNode("UPDATE_OPTIONAL_OPER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = MPGC.MP_STEP_UPDATE;

            in_node.AddString("FLOW", MPCF.Trim(sFlow));
            in_node.AddString("OPER", MPCF.Trim(sOper));
            in_node.AddString("OPT_OPER_GROUP", MPCF.Trim(cdvOptionalGroup.Text));
            in_node.AddChar("OPT_OPER_OPTION_FLAG", MPCF.ToChar(cdvOptionalGroupOption.Text));

            if (MPCR.CallService("WIP", "WIP_Update_Optional_Oper", in_node, ref out_node) == false)
            {
                return false;
            }

            if (bNoSuccessMessage == false)
            {
                MPCR.ShowSuccessMsg(out_node);
            }

            return true;

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.lisFlow;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        private bool Swap_Oper_Sequence(string sAOper, int iAOperSeq, string sBOper, int iBOperSeq)
        {
            TRSNode in_node = new TRSNode("SWAP_OPER_SEQ_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("FLOW", MPCF.Trim(txtFlow.Text));
            in_node.AddString("OPER_1", MPCF.Trim(sAOper));
            in_node.AddInt("OPER_SEQ_NUM_1", iAOperSeq);
            in_node.AddString("OPER_2", MPCF.Trim(sBOper));
            in_node.AddInt("OPER_SEQ_NUM_2", iBOperSeq);

            if (MPCR.CallService("WIP", "WIP_Swap_Operation_Seq", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }


        private void Swap_List_Item(int iAOperSeq, int iBOperSeq)
        {
            string sAOper, sAGroup, sAOption, sADesc;
            string sBOper, sBGroup, sBOption, sBDesc;

            //2014.04.03 Optional Group, Option 칼럼의 위치를 Description 다음으로 이동
            sAOper = lisAttachOper.Items[iAOperSeq].SubItems[0].Text;
            sADesc = lisAttachOper.Items[iAOperSeq].SubItems[1].Text;
            sAGroup = lisAttachOper.Items[iAOperSeq].SubItems[2].Text;
            sAOption = lisAttachOper.Items[iAOperSeq].SubItems[3].Text;

            sBOper = lisAttachOper.Items[iBOperSeq].SubItems[0].Text;
            sBDesc = lisAttachOper.Items[iBOperSeq].SubItems[1].Text;
            sBGroup = lisAttachOper.Items[iBOperSeq].SubItems[2].Text;
            sBOption = lisAttachOper.Items[iBOperSeq].SubItems[3].Text;

            lisAttachOper.Items[iAOperSeq].SubItems[0].Text = sBOper;
            lisAttachOper.Items[iAOperSeq].SubItems[1].Text = sBDesc;
            lisAttachOper.Items[iAOperSeq].SubItems[2].Text = sBGroup;
            lisAttachOper.Items[iAOperSeq].SubItems[3].Text = sBOption;            

            lisAttachOper.Items[iBOperSeq].SubItems[0].Text = sAOper;
            lisAttachOper.Items[iBOperSeq].SubItems[1].Text = sADesc;
            lisAttachOper.Items[iBOperSeq].SubItems[2].Text = sAGroup;
            lisAttachOper.Items[iBOperSeq].SubItems[3].Text = sAOption;            
        }
        
        #endregion
        
        private void frmWIPSetupFlow_Load(object sender, System.EventArgs e)
        {
            
            MPCF.InitListView(lisFlow);
            MPCF.InitListView(lisAttachOper);
            MPCF.InitListView(lisOperList);
            
            cdvOptionalGroup.Init();
            cdvOptionalGroup.SelectedSubItemIndex = 0;
            cdvOptionalGroup.DisplaySubItemIndex = 0;
            
            cdvOptionalGroupOption.Init();
            cdvOptionalGroupOption.SelectedSubItemIndex = 0;
            cdvOptionalGroupOption.DisplaySubItemIndex = 0;
            
        }
        
        private void frmWIPSetupFlow_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (LoadFlag == false)
                {
                    tabFlow_SelectedIndexChanged(null, null);
                    pnlAttachOperFill_Resize(null, null);
                    
                    ClearData("1");
                    SetGroupCmfItem();
                    
                    if (WIPLIST.ViewFlowList(lisFlow, '1', "",0, "", null, "") == false)
                    {
                        return;
                    }
                    lblDataCount.Text = lisFlow.Items.Count.ToString();
                    if (lisFlow.Items.Count > 0)
                    {
                        lisFlow.Items[0].Selected = true;
                    }
                    if (WIPLIST.ViewOperationList(lisOperList, '1', "", 0,"", "", null, "") == false)
                    {
                        return;
                    }

                    LoadFlag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void tabFlow_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            if (tabFlow.SelectedTab == tbpAttachOper)
            {
                btnCreate.Enabled = false;
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                btnDelete.Enabled = false;
            }
            else if (tabFlow.SelectedTab == tbpCopyFlow)
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("CREATE") == true)
                {
                    if (Update_Flow(MPGC.MP_STEP_CREATE) == false)
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
                if (tabFlow.SelectedTab == tbpAttachOper)
                {
                    if (CheckCondition("UPDATE_OPTIONAL_GROUP") == true)
                    {
                        string sOper;
                        sOper = lisAttachOper.SelectedItems[0].Text;
                        
                        if (Update_Optional_Oper(txtFlow.Text, sOper, false) == false)
                        {
                            return;
                        }
                        //2014.04.03 Optional Group, Option 칼럼의 위치를 Description 다음으로 이동
                        lisAttachOper.SelectedItems[0].SubItems[2].Text = MPCF.Trim(cdvOptionalGroup.Text);
                        lisAttachOper.SelectedItems[0].SubItems[3].Text = MPCF.Trim(cdvOptionalGroupOption.Text);
                    }
                }
                else
                {
                    if (CheckCondition("UPDATE") == true)
                    {
                        if (Update_Flow(MPGC.MP_STEP_UPDATE) == false)
                        {
                            return;
                        }
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            btnRefresh.PerformClick();
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
                if (CheckCondition("DELETE") == true)
                {
                    if (Update_Flow(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    ClearData("1");
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
        
        private void lisFlow_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FieldClear(this.pnlRight);
            if (lisFlow.SelectedItems.Count > 0)
            {
                txtFlow.Text = lisFlow.SelectedItems[0].Text;
                if (View_Flow() == false)
                {
                    return;
                }
                
                if (WIPLIST.ViewOperationList(lisAttachOper, '2', "", 0,txtFlow.Text, "", null, "") == false)
                {
                    return;
                }

                ListViewItem itmX;

                itmX = lisAttachOper.Items.Insert(lisAttachOper.Items.Count, "Attach ...", (int)SMALLICON_INDEX.IDX_OPER);
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");
                itmX.SubItems.Add("");

                //lisAttachOper.Items.Add("Attach ...", (int)SMALLICON_INDEX.IDX_OPER);
                lisAttachOper.Items[0].Selected = true;
                lisAttachOper.Items[0].EnsureVisible();
            }
            
        }
        
        private void cdvGrpCmf_ButtonPress(object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        
        private void cdvCmf_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            MPCR.CheckCMFKeyPress(sender, e);
            
        }
        
        private void btnToLeft_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                
                string sAOper;
                string sBOper;
                ListViewItem itmX;
                int idx;
                int i;
                
                if (CheckCondition("ATTACH_OPER") == false)
                {
                    return;
                }
                
                for (i = 0; i <= lisOperList.SelectedItems.Count - 1; i++)
                {
                    sAOper = lisOperList.SelectedItems[i].Text;
                    sBOper = lisAttachOper.SelectedItems[0].Text;
                    
                    if (sBOper == "Attach ...")
                    {
                        sBOper = "";
                    }
                    
                    if (Attach_Oper_ToFlow(txtFlow.Text, sAOper, sBOper) == true)
                    {
                        if (MPCF.FindListItem(lisAttachOper, sAOper, false) == false)
                        {
                            itmX = lisAttachOper.Items.Insert(lisAttachOper.SelectedItems[0].Index, sAOper, (int)SMALLICON_INDEX.IDX_OPER);
                            //2014.04.03 Optional Group, Option 칼럼의 위치를 Description 다음으로 이동
                            itmX.SubItems.Add(lisOperList.SelectedItems[i].SubItems[1].Text);
                            itmX.SubItems.Add(cdvOptionalGroup.Text);
                            itmX.SubItems.Add(cdvOptionalGroupOption.Text);                            
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                if (lisOperList.SelectedItems.Count == 1)
                {
                    idx = lisOperList.SelectedItems[0].Index;
                    if (idx + 1 < lisOperList.Items.Count)
                    {
                        lisOperList.Items[idx].Selected = false;
                        lisOperList.Items[idx + 1].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnToRight_Click(System.Object sender, System.EventArgs e)
        {
            int iIdx = 0;
            int i;
            
            if (CheckCondition("DETACH_OPER") == false)
            {
                return;
            }
            for (i = lisAttachOper.SelectedItems.Count - 1; i >= 0; i--)
            {
                if (lisAttachOper.SelectedItems[i].Text != "Attach ...")
                {
                    if (Detach_Oper_FromFlow(txtFlow.Text, lisAttachOper.SelectedItems[i].Text) == true)
                    {
                        iIdx = lisAttachOper.SelectedItems[i].Index;
                        lisAttachOper.Items.RemoveAt(iIdx);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (lisAttachOper.Items.Count - 1 == iIdx && iIdx > 0)
            {
                iIdx--;
            }
            lisAttachOper.Items[iIdx].Selected = true;
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisFlow, this.Text, "");
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (WIPLIST.ViewFlowList(lisFlow, '1', "",0, "", null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisFlow.Items.Count.ToString();
                if (lisFlow.Items.Count > 0)
                {
                    MPCF.FindListItem(lisFlow, txtFlow.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisFlow, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisFlow, txtFind.Text, 0, true, false);
            
        }
        
        private void pnlAttachOperFill_Resize(object sender, System.EventArgs e)
        {
            
            MPCF.FieldAdjust(pnlAttachOperFill, pnlAttachOper, pnlOperList, pnlAttachOperMid, 40);
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(txtFlow, 1) == false)
            {
                return;
            }
            if (MPCF.CheckValue(txtToFlow, 1) == false)
            {
                return;
            }
            
            if (Copy_Flow(txtToFlow.Text) == true)
            {
                txtToFlow.Text = "";
                if (MPGV.gbListAutoRefresh == true)
                {
                    btnRefresh.PerformClick();
                }
            }
        }
        
        private void lisAttachOper_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lisAttachOper.SelectedItems.Count > 0)
            {
                if (lisAttachOper.SelectedItems[0].Index < lisAttachOper.Items.Count - 1)
                {
                    //2014.04.03 Optional Group, Option 칼럼의 위치를 Description 다음으로 이동
                    cdvOptionalGroup.Text = lisAttachOper.SelectedItems[0].SubItems[2].Text;
                    cdvOptionalGroupOption.Text = lisAttachOper.SelectedItems[0].SubItems[3].Text;
                }
            }
        }
        
        private void lisOperList_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //If ViewOperationList(lisOperList, "1") = False Then Exit Sub
            //View ?댄썑 Sorting ?댁빞 ?좎??
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string sAOper, sBOper;
            int iAOperSeq, iBOperSeq;
            ListView.SelectedListViewItemCollection lisItems = lisAttachOper.SelectedItems;

            // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
            if (lisAttachOper.Items.Count < 3)
                return;

            // 선택된 아이템이 없는 경우 동작하지 않도록 함
            if (lisItems.Count == 0)
                return;

            // 선택된 아이템이 전체를 천택한 경우 동작하지 않도록 함
            if (lisItems.Count > lisAttachOper.Items.Count - 2)
                return;

            if (b_is_work == false)
            {
                b_is_work = true;
                for (int i = 0; i < lisItems.Count; i++)
                {
                    if (lisItems[i].Index == 0)
                        continue;

                    if (lisItems[i].Index > lisAttachOper.Items.Count - 2)
                        continue;

                    iAOperSeq = lisItems[i].Index;
                    iBOperSeq = iAOperSeq - 1;

                    if (lisAttachOper.Items[iBOperSeq].Selected == true)
                        continue;

                    sAOper = lisAttachOper.Items[iAOperSeq].Text;
                    sBOper = lisAttachOper.Items[iBOperSeq].Text;

                    // Index 번호와 실제 번호 사이의 차이값 1을 Seq Num에 더해줌
                    if (Swap_Oper_Sequence(sBOper, iBOperSeq + 1, sAOper, iAOperSeq + 1) == true)
                    {
                        Swap_List_Item(iAOperSeq, iBOperSeq);
                        lisAttachOper.Items[iAOperSeq].Selected = false;
                        lisAttachOper.Items[iBOperSeq].Selected = true;
                    }
                }
                b_is_work = false;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string sAOper, sBOper;
            int iAOperSeq, iBOperSeq;
            ListView.SelectedListViewItemCollection lisItems = lisAttachOper.SelectedItems;

            // 리스트에 아이템이 Attach를 제외하고 한개만 존재할때는 동작하지 않도록 함
            if (lisAttachOper.Items.Count < 3)
                return;

            // 선택된 아이템이 없는 경우 동작하지 않도록 함
            if (lisItems.Count == 0)
                return;

            // 선택된 아이템이 전체를 선택한 경우 동작하지 않도록 함
            if (lisItems.Count > lisAttachOper.Items.Count - 2)
                return;

            if (b_is_work == false)
            {
                b_is_work = true;
                for (int i = lisItems.Count - 1; i >= 0; i--)
                {
                    if (lisItems[i].Index > lisAttachOper.Items.Count - 3)
                        continue;

                    iAOperSeq = lisItems[i].Index;
                    iBOperSeq = iAOperSeq + 1;

                    if (lisAttachOper.Items[iBOperSeq].Selected == true)
                        continue;

                    sAOper = lisAttachOper.Items[iAOperSeq].Text;
                    sBOper = lisAttachOper.Items[iBOperSeq].Text;

                    // Index 번호와 실제 번호 사이의 차이값 1을 Seq Num에 더해줌
                    if (Swap_Oper_Sequence(sAOper, iAOperSeq + 1, sBOper, iBOperSeq + 1) == true)
                    {
                        Swap_List_Item(iAOperSeq, iBOperSeq);
                        lisAttachOper.Items[iAOperSeq].Selected = false;
                        lisAttachOper.Items[iBOperSeq].Selected = true;
                    }
                }
                b_is_work = false;
            }

        }

        private void btnOperExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;

                sCond = "Flow : " + lisFlow.SelectedItems[0].Text;
                MPCF.ExportToExcel(lisAttachOper, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtFlow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tabFlow.SelectedTab == tbpAttribute)
            {
                udcAttributeStatus.ClearValue();
            }
        }
        
    }
    
}
