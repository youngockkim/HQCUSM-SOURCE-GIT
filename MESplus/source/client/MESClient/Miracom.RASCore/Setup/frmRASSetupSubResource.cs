
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
//   Description : Sub Resource Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetGroupCmfItem() : Set Group/Cmf property to control
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - Update_Sub_Resource() : Create/Update/Delete Sub Resource
//       - View_Sub_Resource() : Find Sub Resource and SubView Resource
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-03-21 : Created by Daniel Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASSetupSubResource : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupSubResource()
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
        private System.Windows.Forms.GroupBox grpResource;
        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.TabControl tabResource;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblResType;
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
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResType;
        private System.Windows.Forms.CheckBox chkDeleteRes;
        private System.Windows.Forms.TreeView tvResource;
        private System.Windows.Forms.CheckBox chkChamberFlag;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChamberGroup;
        private System.Windows.Forms.Label lblChamberGroup;
        private System.Windows.Forms.TextBox txtSubResource;
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
        private System.Windows.Forms.MonthCalendar MonthCalendar1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpResource = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblResource = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtSubResource = new System.Windows.Forms.TextBox();
            this.pnlType = new System.Windows.Forms.Panel();
            this.chkDeleteRes = new System.Windows.Forms.CheckBox();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.tabResource = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cdvSubResType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
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
            this.tvResource = new System.Windows.Forms.TreeView();
            this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChamberGroup)).BeginInit();
            this.tbpResStatus.SuspendLayout();
            this.grpResPrompt.SuspendLayout();
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
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlGeneral);
            this.pnlRight.Controls.Add(this.grpResource);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvResource);
            this.pnlLeft.Controls.Add(this.pnlType);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
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
            this.pnlBottom.Controls.Add(this.MonthCalendar1);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.MonthCalendar1, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Resource Setup";
            // 
            // grpResource
            // 
            this.grpResource.Controls.Add(this.lblDesc);
            this.grpResource.Controls.Add(this.lblResource);
            this.grpResource.Controls.Add(this.txtDesc);
            this.grpResource.Controls.Add(this.txtSubResource);
            this.grpResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpResource.Location = new System.Drawing.Point(3, 0);
            this.grpResource.Name = "grpResource";
            this.grpResource.Size = new System.Drawing.Size(500, 71);
            this.grpResource.TabIndex = 0;
            this.grpResource.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(16, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResource.Location = new System.Drawing.Point(15, 19);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(87, 13);
            this.lblResource.TabIndex = 0;
            this.lblResource.Text = "Sub Resource";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(142, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(348, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // txtSubResource
            // 
            this.txtSubResource.Location = new System.Drawing.Point(142, 16);
            this.txtSubResource.MaxLength = 20;
            this.txtSubResource.Name = "txtSubResource";
            this.txtSubResource.Size = new System.Drawing.Size(200, 20);
            this.txtSubResource.TabIndex = 1;
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.chkDeleteRes);
            this.pnlType.Controls.Add(this.cdvType);
            this.pnlType.Controls.Add(this.lblType);
            this.pnlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlType.Location = new System.Drawing.Point(3, 0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(229, 56);
            this.pnlType.TabIndex = 0;
            // 
            // chkDeleteRes
            // 
            this.chkDeleteRes.AutoSize = true;
            this.chkDeleteRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDeleteRes.Location = new System.Drawing.Point(6, 34);
            this.chkDeleteRes.Name = "chkDeleteRes";
            this.chkDeleteRes.Size = new System.Drawing.Size(172, 18);
            this.chkDeleteRes.TabIndex = 2;
            this.chkDeleteRes.Text = "Include Delete Sub Resource";
            this.chkDeleteRes.CheckedChanged += new System.EventHandler(this.chkDeleteRes_CheckedChanged);
            // 
            // cdvType
            // 
            this.cdvType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvType.BtnToolTipText = "";
            this.cdvType.DescText = "";
            this.cdvType.DisplaySubItemIndex = -1;
            this.cdvType.DisplayText = "";
            this.cdvType.Focusing = null;
            this.cdvType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.Location = new System.Drawing.Point(97, 8);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(127, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 127;
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
            this.lblType.Location = new System.Drawing.Point(6, 11);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Resource Type";
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.tabResource);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(3, 71);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlGeneral.Size = new System.Drawing.Size(500, 432);
            this.pnlGeneral.TabIndex = 1;
            // 
            // tabResource
            // 
            this.tabResource.Controls.Add(this.tbpGeneral);
            this.tabResource.Controls.Add(this.tbpResStatus);
            this.tabResource.Controls.Add(this.tbpCMF);
            this.tabResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResource.ItemSize = new System.Drawing.Size(60, 18);
            this.tabResource.Location = new System.Drawing.Point(0, 5);
            this.tabResource.Name = "tabResource";
            this.tabResource.SelectedIndex = 0;
            this.tabResource.Size = new System.Drawing.Size(500, 427);
            this.tabResource.TabIndex = 0;
            this.tabResource.TabStop = false;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 401);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.cdvSubResType);
            this.grpGeneral.Controls.Add(this.lblUpdateTime);
            this.grpGeneral.Controls.Add(this.lblUpdateUser);
            this.grpGeneral.Controls.Add(this.lblCreateTime);
            this.grpGeneral.Controls.Add(this.lblCreateUser);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.txtCreateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.txtCreateUser);
            this.grpGeneral.Controls.Add(this.txtLocation);
            this.grpGeneral.Controls.Add(this.lblLocation);
            this.grpGeneral.Controls.Add(this.lblResType);
            this.grpGeneral.Controls.Add(this.chkChamberFlag);
            this.grpGeneral.Controls.Add(this.cdvChamberGroup);
            this.grpGeneral.Controls.Add(this.lblChamberGroup);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(486, 398);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // cdvSubResType
            // 
            this.cdvSubResType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResType.BtnToolTipText = "";
            this.cdvSubResType.DescText = "";
            this.cdvSubResType.DisplaySubItemIndex = -1;
            this.cdvSubResType.DisplayText = "";
            this.cdvSubResType.Focusing = null;
            this.cdvSubResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResType.Index = 0;
            this.cdvSubResType.IsViewBtnImage = false;
            this.cdvSubResType.Location = new System.Drawing.Point(136, 16);
            this.cdvSubResType.MaxLength = 20;
            this.cdvSubResType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResType.Name = "cdvSubResType";
            this.cdvSubResType.ReadOnly = false;
            this.cdvSubResType.SearchSubItemIndex = 0;
            this.cdvSubResType.SelectedDescIndex = -1;
            this.cdvSubResType.SelectedSubItemIndex = -1;
            this.cdvSubResType.SelectionStart = 0;
            this.cdvSubResType.Size = new System.Drawing.Size(133, 20);
            this.cdvSubResType.SmallImageList = null;
            this.cdvSubResType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResType.TabIndex = 1;
            this.cdvSubResType.TextBoxToolTipText = "";
            this.cdvSubResType.TextBoxWidth = 133;
            this.cdvSubResType.VisibleButton = true;
            this.cdvSubResType.VisibleColumnHeader = false;
            this.cdvSubResType.VisibleDescription = false;
            this.cdvSubResType.ButtonPress += new System.EventHandler(this.cdvSubResType_ButtonPress);
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(12, 184);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 13;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(12, 160);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 11;
            this.lblUpdateUser.Text = "Update User";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(12, 136);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 9;
            this.lblCreateTime.Text = "Create Time";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(12, 112);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 7;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(136, 182);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateTime.TabIndex = 14;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(136, 134);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(133, 20);
            this.txtCreateTime.TabIndex = 10;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(136, 158);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(133, 20);
            this.txtUpdateUser.TabIndex = 12;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(136, 110);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(133, 20);
            this.txtCreateUser.TabIndex = 8;
            this.txtCreateUser.TabStop = false;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(136, 86);
            this.txtLocation.MaxLength = 20;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(133, 20);
            this.txtLocation.TabIndex = 6;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLocation.Location = new System.Drawing.Point(13, 90);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "Location";
            // 
            // lblResType
            // 
            this.lblResType.AutoSize = true;
            this.lblResType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResType.Location = new System.Drawing.Point(13, 19);
            this.lblResType.Name = "lblResType";
            this.lblResType.Size = new System.Drawing.Size(119, 13);
            this.lblResType.TabIndex = 0;
            this.lblResType.Text = "Sub Resource Type";
            // 
            // chkChamberFlag
            // 
            this.chkChamberFlag.AutoSize = true;
            this.chkChamberFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkChamberFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkChamberFlag.Location = new System.Drawing.Point(12, 66);
            this.chkChamberFlag.Name = "chkChamberFlag";
            this.chkChamberFlag.Size = new System.Drawing.Size(153, 18);
            this.chkChamberFlag.TabIndex = 4;
            this.chkChamberFlag.Text = "Chamber Dependent Flag";
            // 
            // cdvChamberGroup
            // 
            this.cdvChamberGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChamberGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChamberGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChamberGroup.BtnToolTipText = "";
            this.cdvChamberGroup.DescText = "";
            this.cdvChamberGroup.DisplaySubItemIndex = -1;
            this.cdvChamberGroup.DisplayText = "";
            this.cdvChamberGroup.Focusing = null;
            this.cdvChamberGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChamberGroup.Index = 0;
            this.cdvChamberGroup.IsViewBtnImage = false;
            this.cdvChamberGroup.Location = new System.Drawing.Point(136, 40);
            this.cdvChamberGroup.MaxLength = 20;
            this.cdvChamberGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChamberGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChamberGroup.Name = "cdvChamberGroup";
            this.cdvChamberGroup.ReadOnly = false;
            this.cdvChamberGroup.SearchSubItemIndex = 0;
            this.cdvChamberGroup.SelectedDescIndex = -1;
            this.cdvChamberGroup.SelectedSubItemIndex = -1;
            this.cdvChamberGroup.SelectionStart = 0;
            this.cdvChamberGroup.Size = new System.Drawing.Size(133, 20);
            this.cdvChamberGroup.SmallImageList = null;
            this.cdvChamberGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChamberGroup.TabIndex = 3;
            this.cdvChamberGroup.TextBoxToolTipText = "";
            this.cdvChamberGroup.TextBoxWidth = 133;
            this.cdvChamberGroup.VisibleButton = true;
            this.cdvChamberGroup.VisibleColumnHeader = false;
            this.cdvChamberGroup.VisibleDescription = false;
            this.cdvChamberGroup.ButtonPress += new System.EventHandler(this.cdvChamberGroup_ButtonPress);
            // 
            // lblChamberGroup
            // 
            this.lblChamberGroup.AutoSize = true;
            this.lblChamberGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChamberGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChamberGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChamberGroup.Location = new System.Drawing.Point(12, 44);
            this.lblChamberGroup.Name = "lblChamberGroup";
            this.lblChamberGroup.Size = new System.Drawing.Size(81, 13);
            this.lblChamberGroup.TabIndex = 2;
            this.lblChamberGroup.Text = "Chamber Group";
            // 
            // tbpResStatus
            // 
            this.tbpResStatus.Controls.Add(this.grpResPrompt);
            this.tbpResStatus.Location = new System.Drawing.Point(4, 22);
            this.tbpResStatus.Name = "tbpResStatus";
            this.tbpResStatus.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpResStatus.Size = new System.Drawing.Size(492, 401);
            this.tbpResStatus.TabIndex = 5;
            this.tbpResStatus.Text = "Status Prompt";
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
            this.grpResPrompt.Size = new System.Drawing.Size(486, 398);
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
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(492, 401);
            this.tbpCMF.TabIndex = 2;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.Visible = false;
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
            this.grpCMF.Location = new System.Drawing.Point(3, 0);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(486, 398);
            this.grpCMF.TabIndex = 1;
            this.grpCMF.TabStop = false;
            // 
            // cdvCMF19
            // 
            this.cdvCMF19.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCMF19.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCMF19.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF19.BtnToolTipText = "";
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
            this.cdvCMF19.Name = "cdvCMF19";
            this.cdvCMF19.ReadOnly = false;
            this.cdvCMF19.SearchSubItemIndex = 0;
            this.cdvCMF19.SelectedDescIndex = -1;
            this.cdvCMF19.SelectedSubItemIndex = -1;
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
            this.cdvCMF18.Name = "cdvCMF18";
            this.cdvCMF18.ReadOnly = false;
            this.cdvCMF18.SearchSubItemIndex = 0;
            this.cdvCMF18.SelectedDescIndex = -1;
            this.cdvCMF18.SelectedSubItemIndex = -1;
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
            this.cdvCMF17.Name = "cdvCMF17";
            this.cdvCMF17.ReadOnly = false;
            this.cdvCMF17.SearchSubItemIndex = 0;
            this.cdvCMF17.SelectedDescIndex = -1;
            this.cdvCMF17.SelectedSubItemIndex = -1;
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
            this.cdvCMF16.Name = "cdvCMF16";
            this.cdvCMF16.ReadOnly = false;
            this.cdvCMF16.SearchSubItemIndex = 0;
            this.cdvCMF16.SelectedDescIndex = -1;
            this.cdvCMF16.SelectedSubItemIndex = -1;
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
            this.cdvCMF15.Name = "cdvCMF15";
            this.cdvCMF15.ReadOnly = false;
            this.cdvCMF15.SearchSubItemIndex = 0;
            this.cdvCMF15.SelectedDescIndex = -1;
            this.cdvCMF15.SelectedSubItemIndex = -1;
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
            this.cdvCMF14.Name = "cdvCMF14";
            this.cdvCMF14.ReadOnly = false;
            this.cdvCMF14.SearchSubItemIndex = 0;
            this.cdvCMF14.SelectedDescIndex = -1;
            this.cdvCMF14.SelectedSubItemIndex = -1;
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
            this.cdvCMF13.Name = "cdvCMF13";
            this.cdvCMF13.ReadOnly = false;
            this.cdvCMF13.SearchSubItemIndex = 0;
            this.cdvCMF13.SelectedDescIndex = -1;
            this.cdvCMF13.SelectedSubItemIndex = -1;
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
            this.cdvCMF12.Name = "cdvCMF12";
            this.cdvCMF12.ReadOnly = false;
            this.cdvCMF12.SearchSubItemIndex = 0;
            this.cdvCMF12.SelectedDescIndex = -1;
            this.cdvCMF12.SelectedSubItemIndex = -1;
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
            this.cdvCMF20.Name = "cdvCMF20";
            this.cdvCMF20.ReadOnly = false;
            this.cdvCMF20.SearchSubItemIndex = 0;
            this.cdvCMF20.SelectedDescIndex = -1;
            this.cdvCMF20.SelectedSubItemIndex = -1;
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
            this.cdvCMF11.Name = "cdvCMF11";
            this.cdvCMF11.ReadOnly = false;
            this.cdvCMF11.SearchSubItemIndex = 0;
            this.cdvCMF11.SelectedDescIndex = -1;
            this.cdvCMF11.SelectedSubItemIndex = -1;
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
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
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
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
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
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
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
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
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
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
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
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
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
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
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
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
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
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
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
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
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
            // tvResource
            // 
            this.tvResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvResource.Location = new System.Drawing.Point(3, 56);
            this.tvResource.Name = "tvResource";
            this.tvResource.Size = new System.Drawing.Size(229, 447);
            this.tvResource.TabIndex = 1;
            this.tvResource.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvResource_AfterSelect);
            this.tvResource.Click += new System.EventHandler(this.tvResource_Click);
            // 
            // MonthCalendar1
            // 
            this.MonthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.MonthCalendar1.Name = "MonthCalendar1";
            this.MonthCalendar1.TabIndex = 5;
            // 
            // frmRASSetupSubResource
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupSubResource";
            this.Text = "Sub Resource Setup";
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChamberGroup)).EndInit();
            this.tbpResStatus.ResumeLayout(false);
            this.grpResPrompt.ResumeLayout(false);
            this.grpResPrompt.PerformLayout();
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
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            if (MPCF.CheckValue(txtSubResource, 1) == false)
            {
                return false;
            }
            if (tvResource.SelectedNode == null)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(109));
                tvResource.Select();
                return false;
            }
            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":

                    if (MPCF.CheckValue(cdvSubResType, 1) == false)
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
            TreeNode node;

            try
            {
                lblDataCount.Text = "";
                tvResource.Nodes.Clear();
                node = tvResource.Nodes.Add(MPGV.gsFactory);

                if (RASLIST.ViewResourceList(tvResource, '1', "", cdvType.Text, "", "", "", 0, "", "", ' ', "", false, tvResource.TopNode, "") == true)
                {
                    lblDataCount.Text = MPCF.Trim(tvResource.GetNodeCount(false));
                    if (tvResource.GetNodeCount(false) > 0)
                    {
                        tvResource.SelectedNode = tvResource.TopNode.FirstNode;
                    }
                }

                tvResource.ExpandAll();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            
            return true;
            
        }
        
        //
        // View_Sub_Resource()
        //       -  View Sub Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Sub_Resource()
        {
            TRSNode in_node = new TRSNode("View_Sub_Resource_In");
            TRSNode out_node = new TRSNode("View_Sub_Resource_Out");
           
            TreeNode nodeX = new TreeNode();
            
            try
            {
                MPCF.FieldClear(this.pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SUBRES_ID", MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false));

                nodeX = tvResource.SelectedNode;
                do
                {
                    nodeX = nodeX.Parent;
                } while (nodeX.ImageIndex != (int)SMALLICON_INDEX.IDX_RESOURCE && 
                         nodeX.ImageIndex != (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN);
                
                //View_Sub_Resource_In.res_id = nodeX.Text.Substring(0, nodeX.Text.IndexOf(":") - 2);
                in_node.AddString("RES_ID", MPCF.SubtractString(nodeX.Text, ":", false, false));

                if (MPCR.CallService("RAS", "RAS_View_Sub_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtSubResource.Text = out_node.GetString("SUBRES_ID");
                txtDesc.Text = out_node.GetString("SUBRES_DESC");
                cdvSubResType.Text = out_node.GetString("SUBRES_TYPE");

                cdvCMF1.Text = out_node.GetString("SUBRES_CMF_1");
                cdvCMF2.Text = out_node.GetString("SUBRES_CMF_2");
                cdvCMF3.Text = out_node.GetString("SUBRES_CMF_3");
                cdvCMF4.Text = out_node.GetString("SUBRES_CMF_4");
                cdvCMF5.Text = out_node.GetString("SUBRES_CMF_5");
                cdvCMF6.Text = out_node.GetString("SUBRES_CMF_6");
                cdvCMF7.Text = out_node.GetString("SUBRES_CMF_7");
                cdvCMF8.Text = out_node.GetString("SUBRES_CMF_8");
                cdvCMF9.Text = out_node.GetString("SUBRES_CMF_9");
                cdvCMF10.Text = out_node.GetString("SUBRES_CMF_10");
                cdvCMF11.Text = out_node.GetString("SUBRES_CMF_11");
                cdvCMF12.Text = out_node.GetString("SUBRES_CMF_12");
                cdvCMF13.Text = out_node.GetString("SUBRES_CMF_13");
                cdvCMF14.Text = out_node.GetString("SUBRES_CMF_14");
                cdvCMF15.Text = out_node.GetString("SUBRES_CMF_15");
                cdvCMF16.Text = out_node.GetString("SUBRES_CMF_16");
                cdvCMF17.Text = out_node.GetString("SUBRES_CMF_17");
                cdvCMF18.Text = out_node.GetString("SUBRES_CMF_18");
                cdvCMF19.Text = out_node.GetString("SUBRES_CMF_19");
                cdvCMF20.Text = out_node.GetString("SUBRES_CMF_20");

                txtLocation.Text = out_node.GetString("SUBRES_LOCATION");
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

                if (out_node.GetChar("CHAMBER_TYPE_FLAG") == 'Y')
                {
                    chkChamberFlag.Checked = true;
                }
                else
                {
                    chkChamberFlag.Checked = false;
                }
                cdvChamberGroup.Text = MPCF.Trim(out_node.GetString("CHAMBER_GRP_ID"));
                
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
                cdvCMF1.Text = out_node.GetString("SUBRES_CMF_1");
                cdvCMF2.Text = out_node.GetString("SUBRES_CMF_2");
                cdvCMF3.Text = out_node.GetString("SUBRES_CMF_3");
                cdvCMF4.Text = out_node.GetString("SUBRES_CMF_4");
                cdvCMF5.Text = out_node.GetString("SUBRES_CMF_5");
                cdvCMF6.Text = out_node.GetString("SUBRES_CMF_6");
                cdvCMF7.Text = out_node.GetString("SUBRES_CMF_7");
                cdvCMF8.Text = out_node.GetString("SUBRES_CMF_8");
                cdvCMF9.Text = out_node.GetString("SUBRES_CMF_9");
                cdvCMF10.Text = out_node.GetString("SUBRES_CMF_10");
                cdvCMF11.Text = out_node.GetString("SUBRES_CMF_11");
                cdvCMF12.Text = out_node.GetString("SUBRES_CMF_12");
                cdvCMF13.Text = out_node.GetString("SUBRES_CMF_13");
                cdvCMF14.Text = out_node.GetString("SUBRES_CMF_14");
                cdvCMF15.Text = out_node.GetString("SUBRES_CMF_15");
                cdvCMF16.Text = out_node.GetString("SUBRES_CMF_16");
                cdvCMF17.Text = out_node.GetString("SUBRES_CMF_17");
                cdvCMF18.Text = out_node.GetString("SUBRES_CMF_18");
                cdvCMF19.Text = out_node.GetString("SUBRES_CMF_19");
                cdvCMF20.Text = out_node.GetString("SUBRES_CMF_20");


                if (MPCF.Trim(out_node.GetChar("DELETE_FLAG")) == "Y")
                {
                    MPCF.FieldClear(pnlGeneral);
                    btnCreate.Enabled = false;
                    btnUpdate.Text = MPCF.FindLanguage("Terminate", 1);
                    btnDelete.Text = MPCF.FindLanguage("Undelete", 1);                   
                }
                else
                {
                    btnCreate.Enabled = true;
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
        // Update_Sub_Resource()
        //       -  Update Sub Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - ByVal c_step As String     : ?•ìž¥ Process Step
        //
        private bool Update_Sub_Resource(char c_step)
        {
            TRSNode in_node = new TRSNode("Update_Sub_Resource_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TreeNode nodeX;
            string sResID = string.Empty;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                int i;
                if (tvResource.SelectedNode.Parent == null)
                {
                    return true;
                }

                i = tvResource.SelectedNode.Parent.ImageIndex;
                if (tvResource.SelectedNode.Parent.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                {
                    sResID = FindResourceID(tvResource, tvResource.SelectedNode);
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        //Update_Sub_Resource_In._C.parents_subres_id = tvResource.SelectedNode.Text.Substring(0, tvResource.SelectedNode.Text.IndexOf(":") - 2);
                        in_node.AddString("PARENTS_SUBRES_ID", MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false));

                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE || c_step == MPGC.MP_STEP_DELETE)
                    {
                        //Update_Sub_Resource_In._C.parents_subres_id = tvResource.SelectedNode.Parent.Text.Substring(0, tvResource.SelectedNode.Parent.Text.IndexOf(":") - 2);
                        in_node.AddString("PARENTS_SUBRES_ID", MPCF.SubtractString(tvResource.SelectedNode.Parent.Text, ":", false, false));

                    }
                }
                else if (tvResource.SelectedNode.Parent.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvResource.SelectedNode.Parent.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                {
                    if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP && c_step == MPGC.MP_STEP_CREATE)
                    {
                        sResID = FindResourceID(tvResource, tvResource.SelectedNode);
                        //Update_Sub_Resource_In._C.parents_subres_id = tvResource.SelectedNode.Text.Substring(0, tvResource.SelectedNode.Text.IndexOf(":") - 2);
                        in_node.AddString("PARENTS_SUBRES_ID", MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false));

                    }
                    else
                    {
                        //sResID = tvResource.SelectedNode.Parent.Text.Substring(0, tvResource.SelectedNode.Parent.Text.IndexOf(":") - 2);
                        sResID = MPCF.SubtractString(tvResource.SelectedNode.Parent.Text, ":", false, false);
                    }
                }
                else if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                {
                    //sResID = tvResource.SelectedNode.Text.Substring(0, tvResource.SelectedNode.Text.IndexOf(":") - 2);
                    sResID = MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false);
                }
                in_node.AddString("RES_ID", sResID);
                
                in_node.AddString("SUBRES_ID", MPCF.Trim(txtSubResource.Text));
                in_node.AddString("SUBRES_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("SUBRES_TYPE", MPCF.Trim(cdvSubResType.Text));

                in_node.AddChar("USE_FAC_PRT_FLAG", (chkUseFacPrtFlag.Checked == true ? 'Y' : ' '));
                in_node.AddChar("CHAMBER_TYPE_FLAG", (chkChamberFlag.Checked == true ? 'Y' : ' '));
                in_node.AddString("CHAMBER_GRP_ID", MPCF.Trim(cdvChamberGroup.Text));

                
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
                    in_node.AddString("SUBRES_STS_1", MPCF.Trim(txtResPrompt1.Text));
                    in_node.AddString("SUBRES_STS_2", MPCF.Trim(txtResPrompt2.Text));
                    in_node.AddString("SUBRES_STS_3", MPCF.Trim(txtResPrompt3.Text));
                    in_node.AddString("SUBRES_STS_4", MPCF.Trim(txtResPrompt4.Text));
                    in_node.AddString("SUBRES_STS_5", MPCF.Trim(txtResPrompt5.Text));
                    in_node.AddString("SUBRES_STS_6", MPCF.Trim(txtResPrompt6.Text));
                    in_node.AddString("SUBRES_STS_7", MPCF.Trim(txtResPrompt7.Text));
                    in_node.AddString("SUBRES_STS_8", MPCF.Trim(txtResPrompt8.Text));
                    in_node.AddString("SUBRES_STS_9", MPCF.Trim(txtResPrompt9.Text));
                    in_node.AddString("SUBRES_STS_10", MPCF.Trim(txtResPrompt10.Text));

                }

                in_node.AddString("SUBRES_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("SUBRES_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("SUBRES_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("SUBRES_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("SUBRES_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("SUBRES_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("SUBRES_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("SUBRES_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("SUBRES_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("SUBRES_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("SUBRES_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("SUBRES_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("SUBRES_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("SUBRES_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("SUBRES_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("SUBRES_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("SUBRES_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("SUBRES_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("SUBRES_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("SUBRES_CMF_20", MPCF.Trim(cdvCMF20.Text));
                in_node.AddString("SUBRES_LOCATION", MPCF.Trim(txtLocation.Text));

                if (MPCR.CallService("RAS", "RAS_Update_Sub_Resource", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        nodeX = new TreeNode(MPCF.Trim(txtSubResource.Text) + " : " + MPCF.Trim(txtDesc.Text), (int)SMALLICON_INDEX.IDX_SUB_EQUIP, (int)SMALLICON_INDEX.IDX_SUB_EQUIP);
                        if (!(tvResource.SelectedNode.Parent == null))
                        {
                            tvResource.SelectedNode.Nodes.Add(nodeX);
                        }
                        else
                        {
                            tvResource.Nodes.Add(nodeX);
                        }
                        tvResource.SelectedNode = nodeX;
                        nodeX.EnsureVisible();
                        lblDataCount.Text = MPCF.Trim(tvResource.GetNodeCount(false));
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        tvResource.SelectedNode.Text = MPCF.Trim(txtSubResource.Text) + " : " + MPCF.Trim(txtDesc.Text);
                    }
                    else if (c_step == MPGC.MP_STEP_DELETE)
                    {
                        if (chkDeleteRes.Checked == true)
                        {
                            tvResource.SelectedNode.ForeColor = Color.Magenta;
                        }
                        else
                        {
                            tvResource.SelectedNode.ForeColor = Color.Magenta;
                        }
                        
                    }
                    else if (c_step == MPGC.MP_STEP_UNDELETE)
                    {
                        tvResource.SelectedNode.ForeColor = tvResource.SelectedNode.Parent.ForeColor;
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
            MPCF.InitTreeView(tvResource);
            
        }
        
        private void frmRASSetupResource_Activated(object sender, System.EventArgs e)
        {
            TreeNode node;
            
            if (b_load_flag == false)
            {
                tvResource.Focus();
                MPCR.SetCMFItem(MPGC.MP_CMF_SUBRESOURCE, "lblCmf", "cdvCmf", grpCMF);
                
                if (cdvSubResType.DisplaySubItemIndex != cdvSubResType.SelectedSubItemIndex)
                {
                    cdvSubResType_ButtonPress(cdvSubResType, null);
                }
                if (cdvChamberGroup.DisplaySubItemIndex != cdvChamberGroup.SelectedSubItemIndex)
                {
                    cdvChamberGroup_ButtonPress(cdvChamberGroup, null);
                }
                
                //Resource Setting
                tvResource.ShowRootLines = true;
                node = tvResource.Nodes.Add(MPGV.gsFactory);
                node.ImageIndex =  (int)SMALLICON_INDEX.IDX_FACTORY;
                node.SelectedImageIndex =  (int)SMALLICON_INDEX.IDX_FACTORY;
                lblDataCount.Text = "";
                //if (RASLIST.ViewResourceList(tvResource, "", cdvType.Text, false) == true)
                //{
                //    lblDataCount.Text = MPCF.Trim(tvResource.TopNode.GetNodeCount(false));
                //}
                //else
                //{
                //    return;
                //}

                node.Expand();
                
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
            string sResID;
            string sSubResID;
            int iListCount = 0;
            
            try
            {
                if (CheckCondition("CREATE") == true)
                {
                    if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_FACTORY ||
                        tvResource.SelectedNode.ImageIndex == -1)
                    {
                    }
                    else
                    {
                        if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                        {
                            if (Update_Sub_Resource(MPGC.MP_STEP_CREATE) == false)
                            {
                                return;
                            }
                        }
                        else if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                        {
                            if (Update_Sub_Resource(MPGC.MP_STEP_CREATE) == false)
                            {
                                return;
                            }
                        }

                        if (MPGV.gbListAutoRefresh == true)
                        {
                            //btnRefresh.PerformClick()
                            if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                            {
                                sSubResID = "";
                            }
                            else
                            {
                                sSubResID = MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false);
                            }
                            sResID = FindResourceID(tvResource, tvResource.SelectedNode);
                            tvResource.SelectedNode.Nodes.Clear();
                            if (chkDeleteRes.Checked == false)
                            {
                                if (RASLIST.ViewSubResourceList(tvResource, '1', sResID, MPGV.gsFactory, sSubResID, "", false, tvResource.SelectedNode, ref iListCount) == true)
                                {
                                    lblDataCount.Text = MPCF.Trim(iListCount);
                                    if (iListCount > 0)
                                    {
                                        tvResource.SelectedNode.EnsureVisible();
                                        tvResource.SelectedNode.Expand();
                                    }
                                }
                            }
                            else if (chkDeleteRes.Checked == true)
                            {
                                if (RASLIST.ViewSubResourceList(tvResource, '2', sResID, MPGV.gsFactory, sSubResID, "", false, tvResource.SelectedNode, ref iListCount) == true)
                                {
                                    lblDataCount.Text = MPCF.Trim(iListCount);
                                    if (iListCount > 0)
                                    {
                                        tvResource.SelectedNode.EnsureVisible();
                                        tvResource.SelectedNode.Expand();
                                    }
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
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            string sResID;
            int iListCount = 0;
            TreeNode TempNode;
            TreeNode FindNode;
            string sSelectPath;
            string sSubResID = "";
            try
            {
                if (btnUpdate.Text == MPCF.FindLanguage("Update", 1))
                {
                    if (CheckCondition("CREATE") == true)
                    {
                        if (Update_Sub_Resource(MPGC.MP_STEP_UPDATE) == false)
                        {
                            return;
                        }

                        if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_FACTORY ||
                            tvResource.SelectedNode.ImageIndex == -1)
                        {

                        }
                        else
                        {
                            if (MPGV.gbListAutoRefresh == true)
                            {
                                //btnRefresh.PerformClick()
                                if (tvResource.SelectedNode == null)
                                {
                                    return;
                                }
                                sResID = FindResourceID(tvResource, tvResource.SelectedNode);
                                if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                                {
                                    sSelectPath = tvResource.SelectedNode.Parent.FullPath + "\\" + txtSubResource.Text + " : " + txtDesc.Text;
                                    TempNode = tvResource.SelectedNode.Parent;
                                }
                                else
                                {
                                    sSelectPath = tvResource.SelectedNode.FullPath + "\\" + txtSubResource.Text + " : " + txtDesc.Text;
                                    TempNode = tvResource.SelectedNode;
                                }
                                if (TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                                {
                                    //sSubResID = TempNode.Text.Substring(0, TempNode.Text.IndexOf(":") - 2);
                                    sSubResID = MPCF.SubtractString(TempNode.Text, ":", false, false);
                                }
                                tvResource.SelectedNode = null;
                                TempNode.Nodes.Clear();
                                if (chkDeleteRes.Checked == false)
                                {
                                    if (RASLIST.ViewSubResourceList(tvResource, '1', sResID, MPGV.gsFactory, sSubResID, "", false, TempNode, ref iListCount) == true)
                                    {
                                        lblDataCount.Text = MPCF.Trim(iListCount);
                                        if (iListCount > 0)
                                        {
                                            FindNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                            if (!(FindNode == null))
                                            {
                                                tvResource.SelectedNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                                tvResource.SelectedNode.EnsureVisible();
                                                tvResource.SelectedNode.Expand();
                                            }
                                        }
                                    }
                                }
                                else if (chkDeleteRes.Checked == true)
                                {
                                    if (RASLIST.ViewSubResourceList(tvResource, '2', sResID, MPGV.gsFactory, sSubResID, "", false, TempNode, ref iListCount) == true)
                                    {
                                        lblDataCount.Text = MPCF.Trim(iListCount);
                                        if (iListCount > 0)
                                        {
                                            FindNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                            if (!(FindNode == null))
                                            {
                                                tvResource.SelectedNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                                tvResource.SelectedNode.EnsureVisible();
                                                tvResource.SelectedNode.Expand();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (btnUpdate.Text == MPCF.FindLanguage("Terminate", 1))
                {
                    if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (Update_Sub_Resource('T') == false)
                        {
                            return;
                        }
                        
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            //btnRefresh.PerformClick()
                            if (tvResource.SelectedNode == null)
                            {
                                return;
                            }
                            sResID = FindResourceID(tvResource, tvResource.SelectedNode);
                            sSelectPath = tvResource.SelectedNode.FullPath;
                            TempNode = tvResource.SelectedNode.Parent;
                            if (TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                            {
                                //sSubResID = TempNode.Text.Substring(0, TempNode.Text.IndexOf(":") - 2);
                                sSubResID = MPCF.SubtractString(TempNode.Text, ":", false, false);
                            }
                            tvResource.SelectedNode = null;
                            TempNode.Nodes.Clear();
                            if (chkDeleteRes.Checked == false)
                            {
                                if (RASLIST.ViewSubResourceList(tvResource, '1', sResID, MPGV.gsFactory, sSubResID, "", false, TempNode, ref iListCount) == true)
                                {
                                    lblDataCount.Text = MPCF.Trim(iListCount);
                                    if (iListCount > 0)
                                    {
                                        FindNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                        if (!(FindNode == null))
                                        {
                                            tvResource.SelectedNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                            tvResource.SelectedNode.EnsureVisible();
                                            tvResource.SelectedNode.Expand();
                                        }
                                    }
                                }
                            }
                            else if (chkDeleteRes.Checked == true)
                            {
                                if (RASLIST.ViewSubResourceList(tvResource, '2', sResID, MPGV.gsFactory, sSubResID, "", false, TempNode, ref iListCount) == true)
                                {
                                    lblDataCount.Text = MPCF.Trim(iListCount);
                                    if (iListCount > 0)
                                    {
                                        FindNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                        if (!(FindNode == null))
                                        {
                                            tvResource.SelectedNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                            tvResource.SelectedNode.EnsureVisible();
                                            tvResource.SelectedNode.Expand();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
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
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                string sResID;
                int iListCount = 0;
                TreeNode TempNode;
                TreeNode FindNode;
                string sSelectPath;
                string sSubResID = "";
                
                if (tvResource.SelectedNode == null) return;

                if(tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_FACTORY ||
                    tvResource.SelectedNode.ImageIndex == -1)
                {
                }
                else
                {
                    if (btnDelete.Text == MPCF.FindLanguage("Delete", 1))
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                        {
                            return;
                        }
                        if (CheckCondition("DELETE") == true)
                        {
                            if (Update_Sub_Resource(MPGC.MP_STEP_CONFIRM) == true)
                            {
                                if (Update_Sub_Resource(MPGC.MP_STEP_DELETE) == true)
                                {

                                    MPCF.FieldClear(this.pnlRight);
                                    if (MPGV.gbListAutoRefresh == true)
                                    {
                                        //btnRefresh.PerformClick()
                                        if (tvResource.SelectedNode == null)
                                        {
                                            return;
                                        }
                                        sResID = FindResourceID(tvResource, tvResource.SelectedNode);
                                        sSelectPath = tvResource.SelectedNode.FullPath;
                                        TempNode = tvResource.SelectedNode.Parent;
                                        if (TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                                        {
                                            //sSubResID = TempNode.Text.Substring(0, TempNode.Text.IndexOf(":") - 2);
                                            sSubResID = MPCF.SubtractString(TempNode.Text, ":", false, false);
                                        }
                                        tvResource.SelectedNode = null;
                                        TempNode.Nodes.Clear();
                                        if (chkDeleteRes.Checked == false)
                                        {
                                            if (RASLIST.ViewSubResourceList(tvResource, '1', sResID, MPGV.gsFactory, sSubResID, "", false, TempNode, ref iListCount) == true)
                                            {
                                                lblDataCount.Text = MPCF.Trim(iListCount);
                                            }
                                        }
                                        else if (chkDeleteRes.Checked == true)
                                        {
                                            if (RASLIST.ViewSubResourceList(tvResource, '2', sResID, MPGV.gsFactory, sSubResID, "", false, TempNode, ref iListCount) == true)
                                            {
                                                lblDataCount.Text = MPCF.Trim(iListCount);
                                                if (iListCount > 0)
                                                {
                                                    FindNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                                    if (!(FindNode == null))
                                                    {
                                                        tvResource.SelectedNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                                        tvResource.SelectedNode.EnsureVisible();
                                                        tvResource.SelectedNode.Expand();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (btnDelete.Text == MPCF.FindLanguage("Undelete", 1))
                    {
                        if (MPCF.ShowMsgBox(MPCF.GetMessage(156), MessageBoxButtons.YesNo, 1) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (Update_Sub_Resource(MPGC.MP_STEP_UNDELETE) == false)
                            {
                                return;
                            }

                            if (MPGV.gbListAutoRefresh == true)
                            {
                                //btnRefresh.PerformClick()
                                if (tvResource.SelectedNode == null)
                                {
                                    return;
                                }
                                sResID = FindResourceID(tvResource, tvResource.SelectedNode);
                                sSelectPath = tvResource.SelectedNode.FullPath;
                                TempNode = tvResource.SelectedNode.Parent;
                                if (TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
                                {
                                    //sSubResID = TempNode.Text.Substring(0, TempNode.Text.IndexOf(":") - 2);
                                    sSubResID = MPCF.SubtractString(TempNode.Text, ":", false, false);
                                }
                                tvResource.SelectedNode = null;
                                TempNode.Nodes.Clear();
                                if (chkDeleteRes.Checked == false)
                                {
                                    if (RASLIST.ViewSubResourceList(tvResource, '1', sResID, MPGV.gsFactory, sSubResID, "", false, TempNode, ref iListCount) == true)
                                    {
                                        lblDataCount.Text = MPCF.Trim(iListCount);
                                        if (iListCount > 0)
                                        {
                                            FindNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                            if (!(FindNode == null))
                                            {
                                                tvResource.SelectedNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                                tvResource.SelectedNode.EnsureVisible();
                                                tvResource.SelectedNode.Expand();
                                            }
                                        }
                                    }
                                }
                                else if (chkDeleteRes.Checked == true)
                                {
                                    if (RASLIST.ViewSubResourceList(tvResource, '2', sResID, MPGV.gsFactory, sSubResID, "", false, TempNode, ref iListCount) == true)
                                    {
                                        lblDataCount.Text = MPCF.Trim(iListCount);
                                        if (iListCount > 0)
                                        {
                                            FindNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                            if (!(FindNode == null))
                                            {
                                                tvResource.SelectedNode = MPCF.FindTreeNode(TempNode, sSelectPath);
                                                tvResource.SelectedNode.EnsureVisible();
                                                tvResource.SelectedNode.Expand();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
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
        
        private void cdvType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            TreeNode node;
            
            try
            {
                lblDataCount.Text = "";
                tvResource.Nodes.Clear();
                node = tvResource.Nodes.Add(MPGV.gsFactory);
                if (chkDeleteRes.Checked == false)
                {
                    if (RASLIST.ViewResourceList(tvResource, '1', "", cdvType.Text, "", "", "", 0, "", "", ' ', "", false, tvResource.TopNode, "") == true)
                    {
                        lblDataCount.Text = MPCF.Trim(tvResource.GetNodeCount(false));
                        if (tvResource.GetNodeCount(false) > 0)
                        {
                            tvResource.SelectedNode = tvResource.TopNode.FirstNode;
                        }
                    }
                }
                else if (chkDeleteRes.Checked == true)
                {
                    if (RASLIST.ViewResourceList(tvResource, '1', "", cdvType.Text, "", "", "", 0, "", "", ' ', "", true, tvResource.TopNode, "") == true)
                    {
                        lblDataCount.Text = MPCF.Trim(tvResource.GetNodeCount(false));
                        if (tvResource.GetNodeCount(false) > 0)
                        {
                            tvResource.SelectedNode = tvResource.TopNode.FirstNode;
                        }
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
            
            //ExportToExcel(tvResource, Me.Text)
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            string SelectedNodePath;
            try
            {
                if (tvResource.SelectedNode == null)
                {
                    return;
                }
                //If tvResource.SelectedNode.ImageIndex = (int)SMALLICON_INDEX.IDX_RESOURCE) Then
                SelectedNodePath = tvResource.SelectedNode.FullPath;
                if (Refresh_Resourcelist() == false)
                {
                    return;
                }
                
                if (tvResource.GetNodeCount(true) > 1)
                {
                    tvResource.SelectedNode = MPCF.FindTreeNode(tvResource, SelectedNodePath);
                    if (tvResource.SelectedNode == null)
                    {
                        tvResource.SelectedNode = tvResource.TopNode.FirstNode;
                    }
                }
                //End If
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
        
        private void chkDeleteRes_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            Refresh_Resourcelist();
        }
        
        private void tvResource_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            string sResID;
            string sSubResID;
            int iListCount = 0;
            
            if (tvResource.SelectedNode == null)
            {
                return;
            }
            
            if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_FACTORY)
            {
                MPCF.FieldClear(this.pnlRight);
                tvResource.TopNode.Nodes.Clear();
                //If chkDeleteRes.Checked = False Then
                if (RASLIST.ViewResourceList(tvResource, '1', "", cdvType.Text, "", "", "", 0, "", "", ' ', "", false, tvResource.TopNode, "") == true)
                {
                    lblDataCount.Text = MPCF.Trim(tvResource.GetNodeCount(false));
                    if (tvResource.GetNodeCount(false) > 0)
                    {
                        tvResource.SelectedNode = tvResource.TopNode.FirstNode;
                    }
                }
                //ElseIf chkDeleteRes.Checked = True Then
                //    If ViewResourceList(tvResource, "2", cdvType.Text, "", "", "", tvResource.TopNode) = True Then
                //        lblDataCount.Text = tvResource.GetNodeCount(False)
                //        If tvResource.GetNodeCount(False) > 0 Then
                //            tvResource.SelectedNode = tvResource.TopNode.FirstNode
                //        End If
                //    End If
                //End If
            }
            else if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
            {
                MPCF.FieldClear(this.pnlRight);
                //sResID = tvResource.SelectedNode.Text.Substring(0, tvResource.SelectedNode.Text.IndexOf(":") - 2);
                sResID = MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false);
                tvResource.SelectedNode.Nodes.Clear();
                if (chkDeleteRes.Checked == false)
                {
                    if (RASLIST.ViewSubResourceList(tvResource, '1', sResID, MPGV.gsFactory, "", "", false, tvResource.SelectedNode, ref iListCount) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(iListCount);
                        if (iListCount > 0)
                        {
                            tvResource.SelectedNode.EnsureVisible();
                            tvResource.SelectedNode.Expand();
                        }
                    }
                }
                else if (chkDeleteRes.Checked == true)
                {
                    if (RASLIST.ViewSubResourceList(tvResource, '2', sResID, MPGV.gsFactory, "", "", false, tvResource.SelectedNode, ref iListCount) == true)
                    {
                        lblDataCount.Text = MPCF.Trim(iListCount);
                        if (iListCount > 0)
                        {
                            tvResource.SelectedNode.EnsureVisible();
                            tvResource.SelectedNode.Expand();
                        }
                    }
                }
                
                //ElseIf tvResource.SelectedNode.ImageIndex = (int)SMALLICON_INDEX.IDX_DOWN_EQUIP Then
                //    FieldClear(Me.pnlRight)
            }
            else if (tvResource.SelectedNode.ImageIndex == (int)SMALLICON_INDEX.IDX_SUB_EQUIP)
            {
                
                if (View_Sub_Resource() == true)
                {
                    if (tvResource.SelectedNode.ForeColor.Name == Color.Magenta.Name)
                    {
                        MPCF.FieldClear(pnlGeneral);
                        btnCreate.Enabled = false;
                        btnUpdate.Text = MPCF.FindLanguage("Terminate", 1);
                        btnDelete.Text = MPCF.FindLanguage("Undelete", 1);         
                        return;
                    }
                    else
                    {
                        btnCreate.Enabled = true;
                        btnUpdate.Text = MPCF.FindLanguage("Update", 1);
                        btnDelete.Text = MPCF.FindLanguage("Delete", 1);
                    }
                    
                    sResID = FindResourceID(tvResource, tvResource.SelectedNode);
                    //sSubResID = tvResource.SelectedNode.Text.Substring(0, tvResource.SelectedNode.Text.IndexOf(":") - 2);
                    sSubResID = MPCF.SubtractString(tvResource.SelectedNode.Text, ":", false, false);
                    tvResource.SelectedNode.Nodes.Clear();
                    if (chkDeleteRes.Checked == false)
                    {
                        if (RASLIST.ViewSubResourceList(tvResource, '1', sResID, MPGV.gsFactory, sSubResID, "", false, tvResource.SelectedNode, ref iListCount) == true)
                        {
                            lblDataCount.Text = MPCF.Trim(iListCount);
                            if (iListCount > 0)
                            {
                                tvResource.SelectedNode.EnsureVisible();
                                tvResource.SelectedNode.Expand();
                            }
                        }
                    }
                    else if (chkDeleteRes.Checked == true)
                    {
                        if (RASLIST.ViewSubResourceList(tvResource, '2', sResID, MPGV.gsFactory, sSubResID, "", false, tvResource.SelectedNode, ref iListCount) == true)
                        {
                            lblDataCount.Text = MPCF.Trim(iListCount);
                            if (iListCount > 0)
                            {
                                tvResource.SelectedNode.EnsureVisible();
                                tvResource.SelectedNode.Expand();
                            }
                        }
                    }
                }
                
            }
            
        }
        
        private void tvResource_Click(object sender, System.EventArgs e)
        {
            //tvResource.SelectedNode = Nothing
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
        
        // FindResourceID()
        //       - Find Resource ID
        // Return Value
        //       - Resource ID : String
        // Arguments
        //       - ByVal Tree As TreeView
        //        - ByVal Item As String
        //        - ByVal Parent As String
        public string FindResourceID(TreeView Tree, TreeNode StartNode)
        {
            string returnValue;
            int i;
            TreeNode FindNode;
            TreeNode TempNode;
            
            returnValue = "";
            TempNode = StartNode;
            
            if (TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || TempNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
            {
                //returnValue = TempNode.Text.Substring(0, TempNode.Text.IndexOf(":") - 2);
                returnValue = MPCF.SubtractString(TempNode.Text, ":", false, false);
                return returnValue;
            }
            
            for (i = 0; i <= Tree.GetNodeCount(true); i++)
            {
                FindNode = TempNode.Parent;
                if (FindNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE || FindNode.ImageIndex == (int)SMALLICON_INDEX.IDX_RESOURCE_DOWN)
                {
                    //returnValue = FindNode.Text.Substring(0, FindNode.Text.IndexOf(":") - 2);
                    returnValue = MPCF.SubtractString(FindNode.Text, ":", false, false);
                    return returnValue;
                }
                
                if (FindNode.Parent == null)
                {
                    return "";
                }
                
                TempNode = FindNode;
            }
            
            return returnValue;
        }
        
        private void cdvSubResType_ButtonPress(object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            MPCF.InitListView(cdvTemp.GetListView);
            cdvTemp.Columns.Add("Type", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_RAS_SUBRES_TYPE);
            if (cdvTemp.AddEmptyRow(1) == false)
            {
                return;
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            tvResource.SelectedNode = MPCF.FindTreeNode(tvResource.TopNode, tvResource.TopNode.FullPath + tvResource.PathSeparator + txtFind.Text);
        }
    }
    
}
