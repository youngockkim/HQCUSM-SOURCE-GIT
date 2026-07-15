
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPSetupOperation.vb
//   Description : Operation Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetGroupCmfItem() : Set Group/Cmf property to control
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - Update_Operation() : Create/Update/Delete Operation
//       - View_Operation() : Find Operation and View Operation
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-10 : Created by CM Koo
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
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPSetupOperation : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPSetupOperation()
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
        



        private Miracom.UI.Controls.MCListView.MCListView lisOper;
        private System.Windows.Forms.ColumnHeader colOper;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.Panel pnlOperTop;
        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblOper;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.Panel pnlOperMid;
        private System.Windows.Forms.TabControl tabOper;
        private System.Windows.Forms.TabPage tbpGroup;
        private System.Windows.Forms.GroupBox grpGroup;
        private System.Windows.Forms.TabPage tbpCmf;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup10;
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
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup9;
        private System.Windows.Forms.Panel pnlGenLeft;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.TextBox txtCreateUser;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubAreaId;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAreaId;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit1;
        private System.Windows.Forms.Label lblSubAreaId;
        private System.Windows.Forms.Label lblAreaId;
        private System.Windows.Forms.Label lblUnit3;
        private System.Windows.Forms.Label lblUnit2;
        private System.Windows.Forms.Label lblUnit1;
        private System.Windows.Forms.Panel pnlGenMidTop;
        private System.Windows.Forms.Panel pnlGenMidMid;
        private System.Windows.Forms.GroupBox grpTable;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRework;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLoss;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvBonus;
        private System.Windows.Forms.Label lblRework;
        private System.Windows.Forms.Label lblBonus;
        private System.Windows.Forms.Label lblLoss;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.CheckBox chkStart;
        private System.Windows.Forms.CheckBox chkErp;
        private System.Windows.Forms.CheckBox chkEnd;
        private System.Windows.Forms.CheckBox chkShipping;
        private System.Windows.Forms.CheckBox chkInv;
        private System.Windows.Forms.CheckBox chkTransit;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.Panel pnlGenMid;
        private System.Windows.Forms.CheckBox chkSecChkFlag;
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
        private Label lblShortDesc;
        private TextBox txtShortDesc;
        private System.Windows.Forms.CheckBox chkPull;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.colOper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lisOper = new Miracom.UI.Controls.MCListView.MCListView();
            this.pnlOperTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.lblShortDesc = new System.Windows.Forms.Label();
            this.txtShortDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.pnlOperMid = new System.Windows.Forms.Panel();
            this.tabOper = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlGenMid = new System.Windows.Forms.Panel();
            this.pnlGenMidMid = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.chkSecChkFlag = new System.Windows.Forms.CheckBox();
            this.chkPull = new System.Windows.Forms.CheckBox();
            this.chkStart = new System.Windows.Forms.CheckBox();
            this.chkErp = new System.Windows.Forms.CheckBox();
            this.chkEnd = new System.Windows.Forms.CheckBox();
            this.chkShipping = new System.Windows.Forms.CheckBox();
            this.chkInv = new System.Windows.Forms.CheckBox();
            this.chkTransit = new System.Windows.Forms.CheckBox();
            this.pnlGenMidTop = new System.Windows.Forms.Panel();
            this.grpTable = new System.Windows.Forms.GroupBox();
            this.cdvRework = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvLoss = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvBonus = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRework = new System.Windows.Forms.Label();
            this.lblBonus = new System.Windows.Forms.Label();
            this.lblLoss = new System.Windows.Forms.Label();
            this.pnlGenLeft = new System.Windows.Forms.Panel();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.cdvSubAreaId = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAreaId = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvUnit1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubAreaId = new System.Windows.Forms.Label();
            this.lblAreaId = new System.Windows.Forms.Label();
            this.lblUnit3 = new System.Windows.Forms.Label();
            this.lblUnit2 = new System.Windows.Forms.Label();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.tbpGroup = new System.Windows.Forms.TabPage();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
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
            this.cdvGroup9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.tbpAttribute = new System.Windows.Forms.TabPage();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.tbpCmf = new System.Windows.Forms.TabPage();
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
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlOperTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            this.pnlOperMid.SuspendLayout();
            this.tabOper.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGenMid.SuspendLayout();
            this.pnlGenMidMid.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlGenMidTop.SuspendLayout();
            this.grpTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRework)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBonus)).BeginInit();
            this.pnlGenLeft.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1)).BeginInit();
            this.tbpGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).BeginInit();
            this.tbpAttribute.SuspendLayout();
            this.tbpCmf.SuspendLayout();
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
            this.txtFind.MaxLength = 10;
            this.txtFind.TabIndex = 0;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlOperMid);
            this.pnlRight.Controls.Add(this.pnlOperTop);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisOper);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Operation Setup";
            // 
            // colOper
            // 
            this.colOper.Text = "Operation";
            this.colOper.Width = 100;
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 300;
            // 
            // lisOper
            // 
            this.lisOper.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOper,
            this.colDesc});
            this.lisOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisOper.EnableSort = true;
            this.lisOper.EnableSortIcon = true;
            this.lisOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisOper.FullRowSelect = true;
            this.lisOper.Location = new System.Drawing.Point(3, 3);
            this.lisOper.MultiSelect = false;
            this.lisOper.Name = "lisOper";
            this.lisOper.Size = new System.Drawing.Size(229, 507);
            this.lisOper.TabIndex = 0;
            this.lisOper.UseCompatibleStateImageBehavior = false;
            this.lisOper.View = System.Windows.Forms.View.Details;
            this.lisOper.SelectedIndexChanged += new System.EventHandler(this.lisOper_SelectedIndexChanged);
            // 
            // pnlOperTop
            // 
            this.pnlOperTop.Controls.Add(this.grpTop);
            this.pnlOperTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOperTop.Location = new System.Drawing.Point(3, 0);
            this.pnlOperTop.Name = "pnlOperTop";
            this.pnlOperTop.Size = new System.Drawing.Size(500, 91);
            this.pnlOperTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.lblShortDesc);
            this.grpTop.Controls.Add(this.txtShortDesc);
            this.grpTop.Controls.Add(this.lblDesc);
            this.grpTop.Controls.Add(this.lblOper);
            this.grpTop.Controls.Add(this.txtDesc);
            this.grpTop.Controls.Add(this.txtOper);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(0, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(500, 91);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
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
            this.txtShortDesc.Location = new System.Drawing.Point(120, 40);
            this.txtShortDesc.MaxLength = 50;
            this.txtShortDesc.Name = "txtShortDesc";
            this.txtShortDesc.Size = new System.Drawing.Size(374, 20);
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
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOper.Location = new System.Drawing.Point(15, 19);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(62, 13);
            this.lblOper.TabIndex = 0;
            this.lblOper.Text = "Operation";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 64);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(374, 20);
            this.txtDesc.TabIndex = 5;
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(120, 16);
            this.txtOper.MaxLength = 10;
            this.txtOper.Name = "txtOper";
            this.txtOper.Size = new System.Drawing.Size(200, 20);
            this.txtOper.TabIndex = 1;
            this.txtOper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOper_KeyPress);
            // 
            // pnlOperMid
            // 
            this.pnlOperMid.Controls.Add(this.tabOper);
            this.pnlOperMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOperMid.Location = new System.Drawing.Point(3, 91);
            this.pnlOperMid.Name = "pnlOperMid";
            this.pnlOperMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.pnlOperMid.Size = new System.Drawing.Size(500, 422);
            this.pnlOperMid.TabIndex = 1;
            // 
            // tabOper
            // 
            this.tabOper.Controls.Add(this.tbpGeneral);
            this.tabOper.Controls.Add(this.tbpGroup);
            this.tabOper.Controls.Add(this.tbpAttribute);
            this.tabOper.Controls.Add(this.tbpCmf);
            this.tabOper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOper.ItemSize = new System.Drawing.Size(60, 18);
            this.tabOper.Location = new System.Drawing.Point(0, 5);
            this.tabOper.Name = "tabOper";
            this.tabOper.SelectedIndex = 0;
            this.tabOper.Size = new System.Drawing.Size(500, 414);
            this.tabOper.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGenMid);
            this.tbpGeneral.Controls.Add(this.pnlGenLeft);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 388);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlGenMid
            // 
            this.pnlGenMid.Controls.Add(this.pnlGenMidMid);
            this.pnlGenMid.Controls.Add(this.pnlGenMidTop);
            this.pnlGenMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGenMid.Location = new System.Drawing.Point(249, 5);
            this.pnlGenMid.Name = "pnlGenMid";
            this.pnlGenMid.Size = new System.Drawing.Size(240, 380);
            this.pnlGenMid.TabIndex = 1;
            // 
            // pnlGenMidMid
            // 
            this.pnlGenMidMid.Controls.Add(this.grpOption);
            this.pnlGenMidMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGenMidMid.Location = new System.Drawing.Point(0, 108);
            this.pnlGenMidMid.Name = "pnlGenMidMid";
            this.pnlGenMidMid.Size = new System.Drawing.Size(240, 272);
            this.pnlGenMidMid.TabIndex = 1;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkSecChkFlag);
            this.grpOption.Controls.Add(this.chkPull);
            this.grpOption.Controls.Add(this.chkStart);
            this.grpOption.Controls.Add(this.chkErp);
            this.grpOption.Controls.Add(this.chkEnd);
            this.grpOption.Controls.Add(this.chkShipping);
            this.grpOption.Controls.Add(this.chkInv);
            this.grpOption.Controls.Add(this.chkTransit);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpOption.Location = new System.Drawing.Point(0, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(240, 272);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Option";
            // 
            // chkSecChkFlag
            // 
            this.chkSecChkFlag.AutoSize = true;
            this.chkSecChkFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSecChkFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSecChkFlag.Location = new System.Drawing.Point(18, 254);
            this.chkSecChkFlag.Name = "chkSecChkFlag";
            this.chkSecChkFlag.Size = new System.Drawing.Size(153, 18);
            this.chkSecChkFlag.TabIndex = 7;
            this.chkSecChkFlag.Text = "Check Security Operation";
            // 
            // chkPull
            // 
            this.chkPull.AutoSize = true;
            this.chkPull.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkPull.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPull.Location = new System.Drawing.Point(18, 220);
            this.chkPull.Name = "chkPull";
            this.chkPull.Size = new System.Drawing.Size(108, 18);
            this.chkPull.TabIndex = 6;
            this.chkPull.Text = "PULL Operation";
            // 
            // chkStart
            // 
            this.chkStart.AutoSize = true;
            this.chkStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkStart.Location = new System.Drawing.Point(18, 186);
            this.chkStart.Name = "chkStart";
            this.chkStart.Size = new System.Drawing.Size(100, 18);
            this.chkStart.TabIndex = 5;
            this.chkStart.Text = "Start Required";
            // 
            // chkErp
            // 
            this.chkErp.AutoSize = true;
            this.chkErp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkErp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkErp.Location = new System.Drawing.Point(18, 152);
            this.chkErp.Name = "chkErp";
            this.chkErp.Size = new System.Drawing.Size(99, 18);
            this.chkErp.TabIndex = 4;
            this.chkErp.Text = "ERP Interface";
            // 
            // chkEnd
            // 
            this.chkEnd.AutoSize = true;
            this.chkEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkEnd.Location = new System.Drawing.Point(18, 118);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(100, 18);
            this.chkEnd.TabIndex = 3;
            this.chkEnd.Text = "End Operation";
            // 
            // chkShipping
            // 
            this.chkShipping.AutoSize = true;
            this.chkShipping.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkShipping.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkShipping.Location = new System.Drawing.Point(18, 84);
            this.chkShipping.Name = "chkShipping";
            this.chkShipping.Size = new System.Drawing.Size(122, 18);
            this.chkShipping.TabIndex = 2;
            this.chkShipping.Text = "Shipping Operation";
            // 
            // chkInv
            // 
            this.chkInv.AutoSize = true;
            this.chkInv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkInv.Location = new System.Drawing.Point(18, 52);
            this.chkInv.Name = "chkInv";
            this.chkInv.Size = new System.Drawing.Size(125, 18);
            this.chkInv.TabIndex = 1;
            this.chkInv.Text = "Inventory Operation";
            // 
            // chkTransit
            // 
            this.chkTransit.AutoSize = true;
            this.chkTransit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTransit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTransit.Location = new System.Drawing.Point(18, 20);
            this.chkTransit.Name = "chkTransit";
            this.chkTransit.Size = new System.Drawing.Size(113, 18);
            this.chkTransit.TabIndex = 0;
            this.chkTransit.Text = "Transit Operation";
            // 
            // pnlGenMidTop
            // 
            this.pnlGenMidTop.Controls.Add(this.grpTable);
            this.pnlGenMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGenMidTop.Location = new System.Drawing.Point(0, 0);
            this.pnlGenMidTop.Name = "pnlGenMidTop";
            this.pnlGenMidTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnlGenMidTop.Size = new System.Drawing.Size(240, 108);
            this.pnlGenMidTop.TabIndex = 0;
            // 
            // grpTable
            // 
            this.grpTable.Controls.Add(this.cdvRework);
            this.grpTable.Controls.Add(this.cdvLoss);
            this.grpTable.Controls.Add(this.cdvBonus);
            this.grpTable.Controls.Add(this.lblRework);
            this.grpTable.Controls.Add(this.lblBonus);
            this.grpTable.Controls.Add(this.lblLoss);
            this.grpTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpTable.Location = new System.Drawing.Point(0, 0);
            this.grpTable.Name = "grpTable";
            this.grpTable.Size = new System.Drawing.Size(240, 103);
            this.grpTable.TabIndex = 0;
            this.grpTable.TabStop = false;
            this.grpTable.Text = "Table Information";
            // 
            // cdvRework
            // 
            this.cdvRework.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRework.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRework.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRework.BtnToolTipText = "";
            this.cdvRework.ButtonWidth = 20;
            this.cdvRework.DescText = "";
            this.cdvRework.DisplaySubItemIndex = -1;
            this.cdvRework.DisplayText = "";
            this.cdvRework.Focusing = null;
            this.cdvRework.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRework.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvRework.Index = 0;
            this.cdvRework.IsViewBtnImage = false;
            this.cdvRework.Location = new System.Drawing.Point(96, 64);
            this.cdvRework.MaxLength = 20;
            this.cdvRework.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRework.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRework.MultiSelect = false;
            this.cdvRework.Name = "cdvRework";
            this.cdvRework.ReadOnly = false;
            this.cdvRework.SameWidthHeightOfButton = false;
            this.cdvRework.SearchSubItemIndex = 0;
            this.cdvRework.SelectedDescIndex = -1;
            this.cdvRework.SelectedDescToQueryText = "";
            this.cdvRework.SelectedSubItemIndex = -1;
            this.cdvRework.SelectedValueToQueryText = "";
            this.cdvRework.SelectionStart = 0;
            this.cdvRework.Size = new System.Drawing.Size(136, 20);
            this.cdvRework.SmallImageList = null;
            this.cdvRework.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRework.TabIndex = 5;
            this.cdvRework.TextBoxToolTipText = "";
            this.cdvRework.TextBoxWidth = 136;
            this.cdvRework.VisibleButton = true;
            this.cdvRework.VisibleColumnHeader = false;
            this.cdvRework.VisibleDescription = false;
            this.cdvRework.ButtonPress += new System.EventHandler(this.cdvRework_ButtonPress);
            // 
            // cdvLoss
            // 
            this.cdvLoss.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLoss.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLoss.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLoss.BtnToolTipText = "";
            this.cdvLoss.ButtonWidth = 20;
            this.cdvLoss.DescText = "";
            this.cdvLoss.DisplaySubItemIndex = -1;
            this.cdvLoss.DisplayText = "";
            this.cdvLoss.Focusing = null;
            this.cdvLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLoss.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvLoss.Index = 0;
            this.cdvLoss.IsViewBtnImage = false;
            this.cdvLoss.Location = new System.Drawing.Point(96, 16);
            this.cdvLoss.MaxLength = 20;
            this.cdvLoss.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLoss.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLoss.MultiSelect = false;
            this.cdvLoss.Name = "cdvLoss";
            this.cdvLoss.ReadOnly = false;
            this.cdvLoss.SameWidthHeightOfButton = false;
            this.cdvLoss.SearchSubItemIndex = 0;
            this.cdvLoss.SelectedDescIndex = -1;
            this.cdvLoss.SelectedDescToQueryText = "";
            this.cdvLoss.SelectedSubItemIndex = -1;
            this.cdvLoss.SelectedValueToQueryText = "";
            this.cdvLoss.SelectionStart = 0;
            this.cdvLoss.Size = new System.Drawing.Size(136, 20);
            this.cdvLoss.SmallImageList = null;
            this.cdvLoss.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLoss.TabIndex = 1;
            this.cdvLoss.TextBoxToolTipText = "";
            this.cdvLoss.TextBoxWidth = 136;
            this.cdvLoss.VisibleButton = true;
            this.cdvLoss.VisibleColumnHeader = false;
            this.cdvLoss.VisibleDescription = false;
            this.cdvLoss.ButtonPress += new System.EventHandler(this.cdvLoss_ButtonPress);
            // 
            // cdvBonus
            // 
            this.cdvBonus.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBonus.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBonus.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvBonus.BtnToolTipText = "";
            this.cdvBonus.ButtonWidth = 20;
            this.cdvBonus.DescText = "";
            this.cdvBonus.DisplaySubItemIndex = -1;
            this.cdvBonus.DisplayText = "";
            this.cdvBonus.Focusing = null;
            this.cdvBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvBonus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvBonus.Index = 0;
            this.cdvBonus.IsViewBtnImage = false;
            this.cdvBonus.Location = new System.Drawing.Point(96, 40);
            this.cdvBonus.MaxLength = 20;
            this.cdvBonus.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvBonus.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvBonus.MultiSelect = false;
            this.cdvBonus.Name = "cdvBonus";
            this.cdvBonus.ReadOnly = false;
            this.cdvBonus.SameWidthHeightOfButton = false;
            this.cdvBonus.SearchSubItemIndex = 0;
            this.cdvBonus.SelectedDescIndex = -1;
            this.cdvBonus.SelectedDescToQueryText = "";
            this.cdvBonus.SelectedSubItemIndex = -1;
            this.cdvBonus.SelectedValueToQueryText = "";
            this.cdvBonus.SelectionStart = 0;
            this.cdvBonus.Size = new System.Drawing.Size(136, 20);
            this.cdvBonus.SmallImageList = null;
            this.cdvBonus.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvBonus.TabIndex = 3;
            this.cdvBonus.TextBoxToolTipText = "";
            this.cdvBonus.TextBoxWidth = 136;
            this.cdvBonus.VisibleButton = true;
            this.cdvBonus.VisibleColumnHeader = false;
            this.cdvBonus.VisibleDescription = false;
            this.cdvBonus.ButtonPress += new System.EventHandler(this.cdvBonus_ButtonPress);
            // 
            // lblRework
            // 
            this.lblRework.AutoSize = true;
            this.lblRework.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRework.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRework.Location = new System.Drawing.Point(18, 67);
            this.lblRework.Name = "lblRework";
            this.lblRework.Size = new System.Drawing.Size(74, 13);
            this.lblRework.TabIndex = 4;
            this.lblRework.Text = "Rework Table";
            // 
            // lblBonus
            // 
            this.lblBonus.AutoSize = true;
            this.lblBonus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBonus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBonus.Location = new System.Drawing.Point(18, 43);
            this.lblBonus.Name = "lblBonus";
            this.lblBonus.Size = new System.Drawing.Size(67, 13);
            this.lblBonus.TabIndex = 2;
            this.lblBonus.Text = "Bonus Table";
            // 
            // lblLoss
            // 
            this.lblLoss.AutoSize = true;
            this.lblLoss.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLoss.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLoss.Location = new System.Drawing.Point(18, 19);
            this.lblLoss.Name = "lblLoss";
            this.lblLoss.Size = new System.Drawing.Size(59, 13);
            this.lblLoss.TabIndex = 0;
            this.lblLoss.Text = "Loss Table";
            // 
            // pnlGenLeft
            // 
            this.pnlGenLeft.Controls.Add(this.grpGeneral);
            this.pnlGenLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGenLeft.Location = new System.Drawing.Point(3, 5);
            this.pnlGenLeft.Name = "pnlGenLeft";
            this.pnlGenLeft.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlGenLeft.Size = new System.Drawing.Size(246, 380);
            this.pnlGenLeft.TabIndex = 0;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.lblUpdateUser);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.lblUpdateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.lblCreateUser);
            this.grpGeneral.Controls.Add(this.txtCreateTime);
            this.grpGeneral.Controls.Add(this.lblCreateTime);
            this.grpGeneral.Controls.Add(this.txtCreateUser);
            this.grpGeneral.Controls.Add(this.cdvSubAreaId);
            this.grpGeneral.Controls.Add(this.cdvAreaId);
            this.grpGeneral.Controls.Add(this.cdvUnit3);
            this.grpGeneral.Controls.Add(this.cdvUnit2);
            this.grpGeneral.Controls.Add(this.cdvUnit1);
            this.grpGeneral.Controls.Add(this.lblSubAreaId);
            this.grpGeneral.Controls.Add(this.lblAreaId);
            this.grpGeneral.Controls.Add(this.lblUnit3);
            this.grpGeneral.Controls.Add(this.lblUnit2);
            this.grpGeneral.Controls.Add(this.lblUnit1);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpGeneral.Location = new System.Drawing.Point(0, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(241, 380);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(8, 204);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 14;
            this.lblUpdateUser.Text = "Update User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(98, 226);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(136, 20);
            this.txtUpdateTime.TabIndex = 17;
            this.txtUpdateTime.TabStop = false;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(8, 230);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 16;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(98, 202);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(136, 20);
            this.txtUpdateUser.TabIndex = 15;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(8, 154);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 10;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(98, 176);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(136, 20);
            this.txtCreateTime.TabIndex = 13;
            this.txtCreateTime.TabStop = false;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(8, 180);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 12;
            this.lblCreateTime.Text = "Create Time";
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(98, 152);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(136, 20);
            this.txtCreateUser.TabIndex = 11;
            this.txtCreateUser.TabStop = false;
            // 
            // cdvSubAreaId
            // 
            this.cdvSubAreaId.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubAreaId.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubAreaId.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubAreaId.BtnToolTipText = "";
            this.cdvSubAreaId.ButtonWidth = 20;
            this.cdvSubAreaId.DescText = "";
            this.cdvSubAreaId.DisplaySubItemIndex = -1;
            this.cdvSubAreaId.DisplayText = "";
            this.cdvSubAreaId.Focusing = null;
            this.cdvSubAreaId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubAreaId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvSubAreaId.Index = 0;
            this.cdvSubAreaId.IsViewBtnImage = false;
            this.cdvSubAreaId.Location = new System.Drawing.Point(98, 112);
            this.cdvSubAreaId.MaxLength = 20;
            this.cdvSubAreaId.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaId.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaId.MultiSelect = false;
            this.cdvSubAreaId.Name = "cdvSubAreaId";
            this.cdvSubAreaId.ReadOnly = false;
            this.cdvSubAreaId.SameWidthHeightOfButton = false;
            this.cdvSubAreaId.SearchSubItemIndex = 0;
            this.cdvSubAreaId.SelectedDescIndex = -1;
            this.cdvSubAreaId.SelectedDescToQueryText = "";
            this.cdvSubAreaId.SelectedSubItemIndex = -1;
            this.cdvSubAreaId.SelectedValueToQueryText = "";
            this.cdvSubAreaId.SelectionStart = 0;
            this.cdvSubAreaId.Size = new System.Drawing.Size(136, 20);
            this.cdvSubAreaId.SmallImageList = null;
            this.cdvSubAreaId.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubAreaId.TabIndex = 9;
            this.cdvSubAreaId.TextBoxToolTipText = "";
            this.cdvSubAreaId.TextBoxWidth = 136;
            this.cdvSubAreaId.VisibleButton = true;
            this.cdvSubAreaId.VisibleColumnHeader = false;
            this.cdvSubAreaId.VisibleDescription = false;
            this.cdvSubAreaId.ButtonPress += new System.EventHandler(this.cdvSubAreaId_ButtonPress);
            // 
            // cdvAreaId
            // 
            this.cdvAreaId.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAreaId.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAreaId.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAreaId.BtnToolTipText = "";
            this.cdvAreaId.ButtonWidth = 20;
            this.cdvAreaId.DescText = "";
            this.cdvAreaId.DisplaySubItemIndex = -1;
            this.cdvAreaId.DisplayText = "";
            this.cdvAreaId.Focusing = null;
            this.cdvAreaId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAreaId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvAreaId.Index = 0;
            this.cdvAreaId.IsViewBtnImage = false;
            this.cdvAreaId.Location = new System.Drawing.Point(98, 88);
            this.cdvAreaId.MaxLength = 20;
            this.cdvAreaId.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAreaId.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAreaId.MultiSelect = false;
            this.cdvAreaId.Name = "cdvAreaId";
            this.cdvAreaId.ReadOnly = false;
            this.cdvAreaId.SameWidthHeightOfButton = false;
            this.cdvAreaId.SearchSubItemIndex = 0;
            this.cdvAreaId.SelectedDescIndex = -1;
            this.cdvAreaId.SelectedDescToQueryText = "";
            this.cdvAreaId.SelectedSubItemIndex = -1;
            this.cdvAreaId.SelectedValueToQueryText = "";
            this.cdvAreaId.SelectionStart = 0;
            this.cdvAreaId.Size = new System.Drawing.Size(136, 20);
            this.cdvAreaId.SmallImageList = null;
            this.cdvAreaId.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAreaId.TabIndex = 7;
            this.cdvAreaId.TextBoxToolTipText = "";
            this.cdvAreaId.TextBoxWidth = 136;
            this.cdvAreaId.VisibleButton = true;
            this.cdvAreaId.VisibleColumnHeader = false;
            this.cdvAreaId.VisibleDescription = false;
            this.cdvAreaId.ButtonPress += new System.EventHandler(this.cdvAreaId_ButtonPress);
            // 
            // cdvUnit3
            // 
            this.cdvUnit3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit3.BtnToolTipText = "";
            this.cdvUnit3.ButtonWidth = 20;
            this.cdvUnit3.DescText = "";
            this.cdvUnit3.DisplaySubItemIndex = -1;
            this.cdvUnit3.DisplayText = "";
            this.cdvUnit3.Focusing = null;
            this.cdvUnit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvUnit3.Index = 0;
            this.cdvUnit3.IsViewBtnImage = false;
            this.cdvUnit3.Location = new System.Drawing.Point(98, 64);
            this.cdvUnit3.MaxLength = 10;
            this.cdvUnit3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit3.MultiSelect = false;
            this.cdvUnit3.Name = "cdvUnit3";
            this.cdvUnit3.ReadOnly = false;
            this.cdvUnit3.SameWidthHeightOfButton = false;
            this.cdvUnit3.SearchSubItemIndex = 0;
            this.cdvUnit3.SelectedDescIndex = -1;
            this.cdvUnit3.SelectedDescToQueryText = "";
            this.cdvUnit3.SelectedSubItemIndex = -1;
            this.cdvUnit3.SelectedValueToQueryText = "";
            this.cdvUnit3.SelectionStart = 0;
            this.cdvUnit3.Size = new System.Drawing.Size(136, 20);
            this.cdvUnit3.SmallImageList = null;
            this.cdvUnit3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit3.TabIndex = 5;
            this.cdvUnit3.TextBoxToolTipText = "";
            this.cdvUnit3.TextBoxWidth = 136;
            this.cdvUnit3.VisibleButton = true;
            this.cdvUnit3.VisibleColumnHeader = false;
            this.cdvUnit3.VisibleDescription = false;
            this.cdvUnit3.ButtonPress += new System.EventHandler(this.cdvControl_ButtonPress);
            // 
            // cdvUnit2
            // 
            this.cdvUnit2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit2.BtnToolTipText = "";
            this.cdvUnit2.ButtonWidth = 20;
            this.cdvUnit2.DescText = "";
            this.cdvUnit2.DisplaySubItemIndex = -1;
            this.cdvUnit2.DisplayText = "";
            this.cdvUnit2.Focusing = null;
            this.cdvUnit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvUnit2.Index = 0;
            this.cdvUnit2.IsViewBtnImage = false;
            this.cdvUnit2.Location = new System.Drawing.Point(98, 40);
            this.cdvUnit2.MaxLength = 10;
            this.cdvUnit2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit2.MultiSelect = false;
            this.cdvUnit2.Name = "cdvUnit2";
            this.cdvUnit2.ReadOnly = false;
            this.cdvUnit2.SameWidthHeightOfButton = false;
            this.cdvUnit2.SearchSubItemIndex = 0;
            this.cdvUnit2.SelectedDescIndex = -1;
            this.cdvUnit2.SelectedDescToQueryText = "";
            this.cdvUnit2.SelectedSubItemIndex = -1;
            this.cdvUnit2.SelectedValueToQueryText = "";
            this.cdvUnit2.SelectionStart = 0;
            this.cdvUnit2.Size = new System.Drawing.Size(136, 20);
            this.cdvUnit2.SmallImageList = null;
            this.cdvUnit2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit2.TabIndex = 3;
            this.cdvUnit2.TextBoxToolTipText = "";
            this.cdvUnit2.TextBoxWidth = 136;
            this.cdvUnit2.VisibleButton = true;
            this.cdvUnit2.VisibleColumnHeader = false;
            this.cdvUnit2.VisibleDescription = false;
            this.cdvUnit2.ButtonPress += new System.EventHandler(this.cdvControl_ButtonPress);
            // 
            // cdvUnit1
            // 
            this.cdvUnit1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit1.BtnToolTipText = "";
            this.cdvUnit1.ButtonWidth = 20;
            this.cdvUnit1.DescText = "";
            this.cdvUnit1.DisplaySubItemIndex = -1;
            this.cdvUnit1.DisplayText = "";
            this.cdvUnit1.Focusing = null;
            this.cdvUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cdvUnit1.Index = 0;
            this.cdvUnit1.IsViewBtnImage = false;
            this.cdvUnit1.Location = new System.Drawing.Point(98, 16);
            this.cdvUnit1.MaxLength = 10;
            this.cdvUnit1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit1.MultiSelect = false;
            this.cdvUnit1.Name = "cdvUnit1";
            this.cdvUnit1.ReadOnly = false;
            this.cdvUnit1.SameWidthHeightOfButton = false;
            this.cdvUnit1.SearchSubItemIndex = 0;
            this.cdvUnit1.SelectedDescIndex = -1;
            this.cdvUnit1.SelectedDescToQueryText = "";
            this.cdvUnit1.SelectedSubItemIndex = -1;
            this.cdvUnit1.SelectedValueToQueryText = "";
            this.cdvUnit1.SelectionStart = 0;
            this.cdvUnit1.Size = new System.Drawing.Size(136, 20);
            this.cdvUnit1.SmallImageList = null;
            this.cdvUnit1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit1.TabIndex = 1;
            this.cdvUnit1.TextBoxToolTipText = "";
            this.cdvUnit1.TextBoxWidth = 136;
            this.cdvUnit1.VisibleButton = true;
            this.cdvUnit1.VisibleColumnHeader = false;
            this.cdvUnit1.VisibleDescription = false;
            this.cdvUnit1.ButtonPress += new System.EventHandler(this.cdvControl_ButtonPress);
            // 
            // lblSubAreaId
            // 
            this.lblSubAreaId.AutoSize = true;
            this.lblSubAreaId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubAreaId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubAreaId.Location = new System.Drawing.Point(8, 115);
            this.lblSubAreaId.Name = "lblSubAreaId";
            this.lblSubAreaId.Size = new System.Drawing.Size(65, 13);
            this.lblSubAreaId.TabIndex = 8;
            this.lblSubAreaId.Text = "Sub Area ID";
            // 
            // lblAreaId
            // 
            this.lblAreaId.AutoSize = true;
            this.lblAreaId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAreaId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAreaId.Location = new System.Drawing.Point(8, 91);
            this.lblAreaId.Name = "lblAreaId";
            this.lblAreaId.Size = new System.Drawing.Size(43, 13);
            this.lblAreaId.TabIndex = 6;
            this.lblAreaId.Text = "Area ID";
            // 
            // lblUnit3
            // 
            this.lblUnit3.AutoSize = true;
            this.lblUnit3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnit3.Location = new System.Drawing.Point(8, 67);
            this.lblUnit3.Name = "lblUnit3";
            this.lblUnit3.Size = new System.Drawing.Size(35, 13);
            this.lblUnit3.TabIndex = 4;
            this.lblUnit3.Text = "Unit 3";
            // 
            // lblUnit2
            // 
            this.lblUnit2.AutoSize = true;
            this.lblUnit2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnit2.Location = new System.Drawing.Point(8, 43);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.Size = new System.Drawing.Size(35, 13);
            this.lblUnit2.TabIndex = 2;
            this.lblUnit2.Text = "Unit 2";
            // 
            // lblUnit1
            // 
            this.lblUnit1.AutoSize = true;
            this.lblUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUnit1.Location = new System.Drawing.Point(8, 19);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.Size = new System.Drawing.Size(35, 13);
            this.lblUnit1.TabIndex = 0;
            this.lblUnit1.Text = "Unit 1";
            // 
            // tbpGroup
            // 
            this.tbpGroup.Controls.Add(this.grpGroup);
            this.tbpGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpGroup.Name = "tbpGroup";
            this.tbpGroup.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpGroup.Size = new System.Drawing.Size(492, 388);
            this.tbpGroup.TabIndex = 1;
            this.tbpGroup.Text = "Group Setup";
            this.tbpGroup.Visible = false;
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.cdvGroup10);
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
            this.grpGroup.Controls.Add(this.cdvGroup9);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpGroup.Location = new System.Drawing.Point(3, 5);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(486, 380);
            this.grpGroup.TabIndex = 0;
            this.grpGroup.TabStop = false;
            this.grpGroup.Text = "Operation Group (1~10)";
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
            this.cdvGroup10.Location = new System.Drawing.Point(172, 232);
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
            this.cdvGroup8.Location = new System.Drawing.Point(172, 184);
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
            this.cdvGroup7.Location = new System.Drawing.Point(172, 160);
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
            this.cdvGroup6.Location = new System.Drawing.Point(172, 136);
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
            this.cdvGroup5.Location = new System.Drawing.Point(172, 112);
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
            this.cdvGroup4.Location = new System.Drawing.Point(172, 88);
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
            this.cdvGroup3.Location = new System.Drawing.Point(172, 64);
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
            this.cdvGroup2.Location = new System.Drawing.Point(172, 40);
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
            this.cdvGroup1.Location = new System.Drawing.Point(172, 16);
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
            this.cdvGroup9.Location = new System.Drawing.Point(172, 208);
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
            // tbpAttribute
            // 
            this.tbpAttribute.Controls.Add(this.udcAttributeStatus);
            this.tbpAttribute.Location = new System.Drawing.Point(4, 22);
            this.tbpAttribute.Name = "tbpAttribute";
            this.tbpAttribute.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAttribute.Size = new System.Drawing.Size(492, 388);
            this.tbpAttribute.TabIndex = 3;
            this.tbpAttribute.Text = "Attribute";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeFactory = "";
            this.udcAttributeStatus.AttributeKey = this.txtOper.Text;
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW_AND_UPDATE;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "OPER";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(3, 3);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(486, 382);
            this.udcAttributeStatus.TabIndex = 1;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // tbpCmf
            // 
            this.tbpCmf.Controls.Add(this.grpCMF);
            this.tbpCmf.Location = new System.Drawing.Point(4, 22);
            this.tbpCmf.Name = "tbpCmf";
            this.tbpCmf.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpCmf.Size = new System.Drawing.Size(492, 388);
            this.tbpCmf.TabIndex = 2;
            this.tbpCmf.Text = "Customized Field";
            this.tbpCmf.Visible = false;
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
            this.grpCMF.Size = new System.Drawing.Size(486, 380);
            this.grpCMF.TabIndex = 0;
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
            this.cdvCMF19.Location = new System.Drawing.Point(352, 210);
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
            this.cdvCMF19.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF19.SmallImageList = null;
            this.cdvCMF19.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF19.TabIndex = 37;
            this.cdvCMF19.TextBoxToolTipText = "";
            this.cdvCMF19.TextBoxWidth = 125;
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
            this.cdvCMF18.Location = new System.Drawing.Point(352, 186);
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
            this.cdvCMF18.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF18.SmallImageList = null;
            this.cdvCMF18.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF18.TabIndex = 35;
            this.cdvCMF18.TextBoxToolTipText = "";
            this.cdvCMF18.TextBoxWidth = 125;
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
            this.cdvCMF17.Location = new System.Drawing.Point(352, 162);
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
            this.cdvCMF17.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF17.SmallImageList = null;
            this.cdvCMF17.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF17.TabIndex = 33;
            this.cdvCMF17.TextBoxToolTipText = "";
            this.cdvCMF17.TextBoxWidth = 125;
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
            this.cdvCMF16.Location = new System.Drawing.Point(352, 138);
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
            this.cdvCMF16.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF16.SmallImageList = null;
            this.cdvCMF16.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF16.TabIndex = 31;
            this.cdvCMF16.TextBoxToolTipText = "";
            this.cdvCMF16.TextBoxWidth = 125;
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
            this.cdvCMF15.Location = new System.Drawing.Point(352, 114);
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
            this.cdvCMF15.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF15.SmallImageList = null;
            this.cdvCMF15.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF15.TabIndex = 29;
            this.cdvCMF15.TextBoxToolTipText = "";
            this.cdvCMF15.TextBoxWidth = 125;
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
            this.cdvCMF14.Location = new System.Drawing.Point(352, 90);
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
            this.cdvCMF14.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF14.SmallImageList = null;
            this.cdvCMF14.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF14.TabIndex = 27;
            this.cdvCMF14.TextBoxToolTipText = "";
            this.cdvCMF14.TextBoxWidth = 125;
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
            this.cdvCMF13.Location = new System.Drawing.Point(352, 66);
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
            this.cdvCMF13.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF13.SmallImageList = null;
            this.cdvCMF13.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF13.TabIndex = 25;
            this.cdvCMF13.TextBoxToolTipText = "";
            this.cdvCMF13.TextBoxWidth = 125;
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
            this.cdvCMF12.Location = new System.Drawing.Point(352, 42);
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
            this.cdvCMF12.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF12.SmallImageList = null;
            this.cdvCMF12.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF12.TabIndex = 23;
            this.cdvCMF12.TextBoxToolTipText = "";
            this.cdvCMF12.TextBoxWidth = 125;
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
            this.cdvCMF20.Location = new System.Drawing.Point(352, 234);
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
            this.cdvCMF20.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF20.SmallImageList = null;
            this.cdvCMF20.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF20.TabIndex = 39;
            this.cdvCMF20.TextBoxToolTipText = "";
            this.cdvCMF20.TextBoxWidth = 125;
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
            this.cdvCMF11.Location = new System.Drawing.Point(352, 18);
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
            this.cdvCMF11.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF11.SmallImageList = null;
            this.cdvCMF11.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF11.TabIndex = 21;
            this.cdvCMF11.TextBoxToolTipText = "";
            this.cdvCMF11.TextBoxWidth = 125;
            this.cdvCMF11.VisibleButton = true;
            this.cdvCMF11.VisibleColumnHeader = false;
            this.cdvCMF11.VisibleDescription = false;
            this.cdvCMF11.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF11.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF20
            // 
            this.lblCMF20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF20.Location = new System.Drawing.Point(251, 238);
            this.lblCMF20.Name = "lblCMF20";
            this.lblCMF20.Size = new System.Drawing.Size(98, 14);
            this.lblCMF20.TabIndex = 38;
            this.lblCMF20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF19
            // 
            this.lblCMF19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF19.Location = new System.Drawing.Point(251, 214);
            this.lblCMF19.Name = "lblCMF19";
            this.lblCMF19.Size = new System.Drawing.Size(98, 14);
            this.lblCMF19.TabIndex = 36;
            this.lblCMF19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF18
            // 
            this.lblCMF18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF18.Location = new System.Drawing.Point(251, 190);
            this.lblCMF18.Name = "lblCMF18";
            this.lblCMF18.Size = new System.Drawing.Size(98, 14);
            this.lblCMF18.TabIndex = 34;
            this.lblCMF18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF17
            // 
            this.lblCMF17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF17.Location = new System.Drawing.Point(251, 166);
            this.lblCMF17.Name = "lblCMF17";
            this.lblCMF17.Size = new System.Drawing.Size(98, 14);
            this.lblCMF17.TabIndex = 32;
            this.lblCMF17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF16
            // 
            this.lblCMF16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF16.Location = new System.Drawing.Point(251, 142);
            this.lblCMF16.Name = "lblCMF16";
            this.lblCMF16.Size = new System.Drawing.Size(98, 14);
            this.lblCMF16.TabIndex = 30;
            this.lblCMF16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF15
            // 
            this.lblCMF15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF15.Location = new System.Drawing.Point(251, 118);
            this.lblCMF15.Name = "lblCMF15";
            this.lblCMF15.Size = new System.Drawing.Size(98, 14);
            this.lblCMF15.TabIndex = 28;
            this.lblCMF15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF14
            // 
            this.lblCMF14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF14.Location = new System.Drawing.Point(251, 94);
            this.lblCMF14.Name = "lblCMF14";
            this.lblCMF14.Size = new System.Drawing.Size(98, 14);
            this.lblCMF14.TabIndex = 26;
            this.lblCMF14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF13
            // 
            this.lblCMF13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF13.Location = new System.Drawing.Point(251, 70);
            this.lblCMF13.Name = "lblCMF13";
            this.lblCMF13.Size = new System.Drawing.Size(98, 14);
            this.lblCMF13.TabIndex = 24;
            this.lblCMF13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF12
            // 
            this.lblCMF12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF12.Location = new System.Drawing.Point(251, 46);
            this.lblCMF12.Name = "lblCMF12";
            this.lblCMF12.Size = new System.Drawing.Size(98, 14);
            this.lblCMF12.TabIndex = 22;
            this.lblCMF12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF11
            // 
            this.lblCMF11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF11.Location = new System.Drawing.Point(251, 22);
            this.lblCMF11.Name = "lblCMF11";
            this.lblCMF11.Size = new System.Drawing.Size(98, 14);
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
            this.cdvCMF9.Location = new System.Drawing.Point(109, 210);
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
            this.cdvCMF9.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 17;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 125;
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
            this.cdvCMF8.Location = new System.Drawing.Point(109, 186);
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
            this.cdvCMF8.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 15;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 125;
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
            this.cdvCMF7.Location = new System.Drawing.Point(109, 162);
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
            this.cdvCMF7.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 13;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 125;
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
            this.cdvCMF6.Location = new System.Drawing.Point(109, 138);
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
            this.cdvCMF6.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 11;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 125;
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
            this.cdvCMF5.Location = new System.Drawing.Point(109, 114);
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
            this.cdvCMF5.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 9;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 125;
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
            this.cdvCMF4.Location = new System.Drawing.Point(109, 90);
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
            this.cdvCMF4.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 7;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 125;
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
            this.cdvCMF3.Location = new System.Drawing.Point(109, 66);
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
            this.cdvCMF3.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 5;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 125;
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
            this.cdvCMF2.Location = new System.Drawing.Point(109, 42);
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
            this.cdvCMF2.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 3;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 125;
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
            this.cdvCMF10.Location = new System.Drawing.Point(109, 234);
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
            this.cdvCMF10.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 19;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 125;
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
            this.cdvCMF1.Location = new System.Drawing.Point(109, 18);
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
            this.cdvCMF1.Size = new System.Drawing.Size(125, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 1;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 125;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF10
            // 
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.Location = new System.Drawing.Point(8, 238);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(98, 14);
            this.lblCMF10.TabIndex = 18;
            this.lblCMF10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF9
            // 
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.Location = new System.Drawing.Point(8, 214);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(98, 14);
            this.lblCMF9.TabIndex = 16;
            this.lblCMF9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF8
            // 
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.Location = new System.Drawing.Point(8, 190);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(98, 14);
            this.lblCMF8.TabIndex = 14;
            this.lblCMF8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.Location = new System.Drawing.Point(8, 166);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(98, 14);
            this.lblCMF7.TabIndex = 12;
            this.lblCMF7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.Location = new System.Drawing.Point(8, 142);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(98, 14);
            this.lblCMF6.TabIndex = 10;
            this.lblCMF6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.Location = new System.Drawing.Point(8, 118);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(98, 14);
            this.lblCMF5.TabIndex = 8;
            this.lblCMF5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF4
            // 
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.Location = new System.Drawing.Point(8, 94);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(98, 14);
            this.lblCMF4.TabIndex = 6;
            this.lblCMF4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF3
            // 
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.Location = new System.Drawing.Point(8, 70);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(98, 14);
            this.lblCMF3.TabIndex = 4;
            this.lblCMF3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF2
            // 
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.Location = new System.Drawing.Point(8, 46);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(98, 14);
            this.lblCMF2.TabIndex = 2;
            this.lblCMF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCMF1
            // 
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.Location = new System.Drawing.Point(8, 22);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(98, 14);
            this.lblCMF1.TabIndex = 0;
            this.lblCMF1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPSetupOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPSetupOperation";
            this.Text = "Operation Setup";
            this.Activated += new System.EventHandler(this.frmWIPSetupOperation_Activated);
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
            this.pnlOperTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            this.pnlOperMid.ResumeLayout(false);
            this.tabOper.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlGenMid.ResumeLayout(false);
            this.pnlGenMidMid.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlGenMidTop.ResumeLayout(false);
            this.grpTable.ResumeLayout(false);
            this.grpTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRework)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBonus)).EndInit();
            this.pnlGenLeft.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit1)).EndInit();
            this.tbpGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).EndInit();
            this.tbpAttribute.ResumeLayout(false);
            this.tbpCmf.ResumeLayout(false);
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
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        // SetGroupCmfItem()
        //       -   Set Group/Cmf property to control
        // Return Value
        //       -
        // Arguments
        //       -
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];
            
            sGrpTableName[0] = MPGC.MP_GCM_OPER_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_OPER_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_OPER_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_OPER_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_OPER_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_OPER_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_OPER_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_OPER_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_OPER_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_OPER_GRP_10;
            
            MPCR.SetGRPItem(MPGC.MP_GRP_OPERATION, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
            MPCR.SetCMFItem(MPGC.MP_CMF_OPERATION, "lblCMF", "cdvCMF", grpCMF);
            
        }
        
        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition(string FuncName)
        {
            if (MPCF.CheckValue(txtOper, 1) == false)
            {
                return false;
            }
            
            switch (MPCF.Trim(FuncName))
            {
                case "CREATE":
                    
                    if ((cdvUnit1.Text == "") &&(cdvUnit2.Text == "") &&(cdvUnit3.Text == ""))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabOper.SelectedTab = tbpGeneral;
                        cdvUnit1.Focus();
                        return false;
                    }
                    if (cdvUnit1.Text != "" &&(cdvUnit1.Text == MPCF.Trim(cdvUnit2.Text) || cdvUnit1.Text == MPCF.Trim(cdvUnit3.Text)))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(159));
                        tabOper.SelectedTab = tbpGeneral;
                        cdvUnit1.Focus();
                        return false;
                    }
                    if (cdvUnit2.Text != "" &&(cdvUnit2.Text == MPCF.Trim(cdvUnit1.Text) || cdvUnit2.Text == MPCF.Trim(cdvUnit3.Text)))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(159));
                        tabOper.SelectedTab = tbpGeneral;
                        cdvUnit2.Focus();
                        return false;
                    }
                    if (cdvUnit3.Text != "" &&(cdvUnit3.Text == MPCF.Trim(cdvUnit1.Text) || cdvUnit3.Text == MPCF.Trim(cdvUnit2.Text)))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(159));
                        tabOper.SelectedTab = tbpGeneral;
                        cdvUnit3.Focus();
                        return false;
                    }
                    
                    if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    {
                        tabOper.SelectedTab = tbpGroup;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        tabOper.SelectedTab = tbpCmf;
                        return false;
                    }
                    break;
                case "UPDATE":
                    
                    if ((cdvUnit1.Text == "") &&(cdvUnit2.Text == "") &&(cdvUnit3.Text == ""))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        tabOper.SelectedTab = tbpGeneral;
                        cdvUnit1.Focus();
                        return false;
                    }
                    if (cdvUnit1.Text != "" && (cdvUnit1.Text == MPCF.Trim(cdvUnit2.Text) || cdvUnit1.Text == MPCF.Trim(cdvUnit3.Text)))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(159));
                        tabOper.SelectedTab = tbpGeneral;
                        cdvUnit1.Focus();
                        return false;
                    }
                    if (cdvUnit2.Text != "" &&(cdvUnit2.Text == MPCF.Trim(cdvUnit1.Text) || cdvUnit2.Text == MPCF.Trim(cdvUnit3.Text)))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(159));
                        tabOper.SelectedTab = tbpGeneral;
                        cdvUnit2.Focus();
                        return false;
                    }
                    if (cdvUnit3.Text != "" &&(cdvUnit3.Text == MPCF.Trim(cdvUnit1.Text) || cdvUnit3.Text == MPCF.Trim(cdvUnit2.Text)))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(159));
                        tabOper.SelectedTab = tbpGeneral;
                        cdvUnit3.Focus();
                        return false;
                    }
                    
                    if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                    {
                        tabOper.SelectedTab = tbpGroup;
                        return false;
                    }
                    if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                    {
                        tabOper.SelectedTab = tbpCmf;
                        return false;
                    }
                    break;
            }
            
            return true;
        }
        // View_Operation()
        //       -  View Operation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool View_Operation()
        {

            TRSNode in_node = new TRSNode("VIEW_OPERATION_IN");
            TRSNode out_node = new TRSNode("VIEW_OPERATION_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("OPER", MPCF.Trim(txtOper.Text));

            if (MPCR.CallService("WIP", "WIP_View_Operation", in_node, ref out_node) == false)
            {
                return false;
            }

            txtOper.Text = MPCF.Trim(out_node.GetString("OPER"));
            txtDesc.Text = MPCF.Trim(out_node.GetString("OPER_DESC"));
            txtShortDesc.Text = MPCF.Trim(out_node.GetString("OPER_SHORT_DESC"));

            cdvGroup1.Text = MPCF.Trim(out_node.GetString("OPER_GRP_1"));
            cdvGroup2.Text = MPCF.Trim(out_node.GetString("OPER_GRP_2"));
            cdvGroup3.Text = MPCF.Trim(out_node.GetString("OPER_GRP_3"));
            cdvGroup4.Text = MPCF.Trim(out_node.GetString("OPER_GRP_4"));
            cdvGroup5.Text = MPCF.Trim(out_node.GetString("OPER_GRP_5"));
            cdvGroup6.Text = MPCF.Trim(out_node.GetString("OPER_GRP_6"));
            cdvGroup7.Text = MPCF.Trim(out_node.GetString("OPER_GRP_7"));
            cdvGroup8.Text = MPCF.Trim(out_node.GetString("OPER_GRP_8"));
            cdvGroup9.Text = MPCF.Trim(out_node.GetString("OPER_GRP_9"));
            cdvGroup10.Text = MPCF.Trim(out_node.GetString("OPER_GRP_10"));

            cdvCMF1.Text = MPCF.Trim(out_node.GetString("OPER_CMF_1"));
            cdvCMF2.Text = MPCF.Trim(out_node.GetString("OPER_CMF_2"));
            cdvCMF3.Text = MPCF.Trim(out_node.GetString("OPER_CMF_3"));
            cdvCMF4.Text = MPCF.Trim(out_node.GetString("OPER_CMF_4"));
            cdvCMF5.Text = MPCF.Trim(out_node.GetString("OPER_CMF_5"));
            cdvCMF6.Text = MPCF.Trim(out_node.GetString("OPER_CMF_6"));
            cdvCMF7.Text = MPCF.Trim(out_node.GetString("OPER_CMF_7"));
            cdvCMF8.Text = MPCF.Trim(out_node.GetString("OPER_CMF_8"));
            cdvCMF9.Text = MPCF.Trim(out_node.GetString("OPER_CMF_9"));
            cdvCMF10.Text = MPCF.Trim(out_node.GetString("OPER_CMF_10"));
            cdvCMF11.Text = MPCF.Trim(out_node.GetString("OPER_CMF_11"));
            cdvCMF12.Text = MPCF.Trim(out_node.GetString("OPER_CMF_12"));
            cdvCMF13.Text = MPCF.Trim(out_node.GetString("OPER_CMF_13"));
            cdvCMF14.Text = MPCF.Trim(out_node.GetString("OPER_CMF_14"));
            cdvCMF15.Text = MPCF.Trim(out_node.GetString("OPER_CMF_15"));
            cdvCMF16.Text = MPCF.Trim(out_node.GetString("OPER_CMF_16"));
            cdvCMF17.Text = MPCF.Trim(out_node.GetString("OPER_CMF_17"));
            cdvCMF18.Text = MPCF.Trim(out_node.GetString("OPER_CMF_18"));
            cdvCMF19.Text = MPCF.Trim(out_node.GetString("OPER_CMF_19"));
            cdvCMF20.Text = MPCF.Trim(out_node.GetString("OPER_CMF_20"));

            cdvUnit1.Text = MPCF.Trim(out_node.GetString("UNIT_1"));
            cdvUnit2.Text = MPCF.Trim(out_node.GetString("UNIT_2"));
            cdvUnit3.Text = MPCF.Trim(out_node.GetString("UNIT_3"));

            cdvAreaId.Text = MPCF.Trim(out_node.GetString("AREA_ID"));
            cdvSubAreaId.Text = MPCF.Trim(out_node.GetString("SUB_AREA_ID"));

            chkPull.Checked = (out_node.GetChar("PUSH_PULL_FLAG") == 'Y') ? true : false;
            chkSecChkFlag.Checked = (out_node.GetChar("SEC_CHK_FLAG") == 'Y') ? true : false;
            chkTransit.Checked = (out_node.GetChar("TRANSIT_FLAG") == 'Y') ? true : false;
            chkInv.Checked = (out_node.GetChar("INV_FLAG") == 'Y') ? true : false;
            chkErp.Checked = (out_node.GetChar("ERP_FLAG") == 'Y') ? true : false;
            chkStart.Checked = (out_node.GetChar("START_REQUIRE_FLAG") == 'Y') ? true : false;
            chkEnd.Checked = (out_node.GetChar("END_OPER_FLAG") == 'Y') ? true : false;
            chkShipping.Checked = (out_node.GetChar("SHIP_FLAG") == 'Y') ? true : false;

            cdvLoss.Text = MPCF.Trim(out_node.GetString("LOSS_TBL"));
            cdvBonus.Text = MPCF.Trim(out_node.GetString("BONUS_TBL"));
            cdvRework.Text = MPCF.Trim(out_node.GetString("REWORK_TBL"));

            txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
            txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

            udcAttributeStatus.AttributeKey = txtOper.Text;
            udcAttributeStatus.View();

            return true;

        }

        //
        // Update_Operation()
        //       -   Create and Update and Delete Operation
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : MP_STEP_CREATE/UPDATE/DELETE
        //
        private bool Update_Operation(char ProcStep)
        {

            TRSNode in_node = new TRSNode("UPDATE_OPERATION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            ListViewItem itm;
            int idx;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("OPER", MPCF.Trim(txtOper.Text));
                in_node.AddString("OPER_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("OPER_SHORT_DESC", MPCF.Trim(txtShortDesc.Text));

                in_node.AddString("OPER_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("OPER_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("OPER_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("OPER_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("OPER_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("OPER_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("OPER_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("OPER_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("OPER_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("OPER_GRP_10", MPCF.Trim(cdvGroup10.Text));

                in_node.AddString("OPER_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("OPER_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("OPER_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("OPER_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("OPER_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("OPER_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("OPER_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("OPER_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("OPER_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("OPER_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("OPER_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("OPER_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("OPER_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("OPER_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("OPER_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("OPER_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("OPER_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("OPER_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("OPER_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("OPER_CMF_20", MPCF.Trim(cdvCMF20.Text));

                in_node.AddString("UNIT_1", MPCF.Trim(cdvUnit1.Text));
                in_node.AddString("UNIT_2", MPCF.Trim(cdvUnit2.Text));
                in_node.AddString("UNIT_3", MPCF.Trim(cdvUnit3.Text));

                in_node.AddString("AREA_ID", MPCF.Trim(cdvAreaId.Text));
                in_node.AddString("SUB_AREA_ID", MPCF.Trim(cdvSubAreaId.Text));

                in_node.AddChar("PUSH_PULL_FLAG", chkPull.Checked == true ? 'Y' : ' ');
                in_node.AddChar("SEC_CHK_FLAG", chkSecChkFlag.Checked == true ? 'Y' : ' ');
                in_node.AddChar("TRANSIT_FLAG", chkTransit.Checked == true ? 'Y' : ' ');
                in_node.AddChar("INV_FLAG", chkInv.Checked == true ? 'Y' : ' ');
                in_node.AddChar("ERP_FLAG", chkErp.Checked == true ? 'Y' : ' ');
                in_node.AddChar("START_REQUIRE_FLAG", chkStart.Checked == true ? 'Y' : ' ');
                in_node.AddChar("END_OPER_FLAG", chkEnd.Checked == true ? 'Y' : ' ');
                in_node.AddChar("SHIP_FLAG", chkShipping.Checked == true ? 'Y' : ' ');

                in_node.AddString("LOSS_TBL", MPCF.Trim(cdvLoss.Text));
                in_node.AddString("BONUS_TBL", MPCF.Trim(cdvBonus.Text));
                in_node.AddString("REWORK_TBL", MPCF.Trim(cdvRework.Text));

                if (MPCR.CallService("WIP", "WIP_Update_Operation", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisOper.Items.Add(txtOper.Text, (int)SMALLICON_INDEX.IDX_OPER);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisOper.Sorting = SortOrder.Ascending;
                        lisOper.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisOper, MPCF.Trim(txtOper.Text), false) == true)
                        {
                            lisOper.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisOper, MPCF.Trim(txtOper.Text), false);
                        if (idx != -1)
                        {
                            lisOper.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisOper.Items.Count.ToString();
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
                return this.lisOper;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPSetupOperation_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {

                MPCF.FieldClear(this);
                MPCF.InitListView(lisOper);
                SetGroupCmfItem();
                
                WIPLIST.ViewOperationList(lisOper, '1', "", 0,"", "", null, "");
                if (lisOper.Items.Count > 0)
                {
                    lisOper.Items[0].Selected = true;
                }
                lblDataCount.Text = lisOper.Items.Count.ToString();
                
                b_load_flag = true;
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
        
        private void lisOper_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FieldClear(this.pnlRight);
            if (lisOper.SelectedItems.Count > 0)
            {
                txtOper.Text = lisOper.SelectedItems[0].Text;
                View_Operation();
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisOper, this.Text, "");
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (WIPLIST.ViewOperationList(lisOper, '1', "", 0,"", "", null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisOper.Items.Count.ToString();
                if (lisOper.Items.Count > 0)
                {
                    MPCF.FindListItem(lisOper, txtOper.Text, false);
                }
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
                if (CheckCondition("CREATE") == true)
                {
                    if (Update_Operation(MPGC.MP_STEP_CREATE) == false)
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
                if (CheckCondition("UPDATE") == true)
                {
                    if (Update_Operation(MPGC.MP_STEP_UPDATE) == false)
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
                    if (Update_Operation(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    MPCF.FieldClear(this.pnlRight);
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
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemNextPartial(lisOper, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisOper, txtFind.Text, 0, true, false);
            
        }
        
        private void cdvLoss_ButtonPress(object sender, System.EventArgs e)
        {
            cdvLoss.Init();
            MPCF.InitListView(cdvLoss.GetListView);
            cdvLoss.Columns.Add("Loss Code", 150, HorizontalAlignment.Left);
            cdvLoss.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvLoss.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvLoss.GetListView, '1');
            
        }
        
        private void cdvBonus_ButtonPress(object sender, System.EventArgs e)
        {
            cdvBonus.Init();
            MPCF.InitListView(cdvBonus.GetListView);
            cdvBonus.Columns.Add("Bonus Code", 150, HorizontalAlignment.Left);
            cdvBonus.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvBonus.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvBonus.GetListView, '1');
            
        }
        
        private void cdvRework_ButtonPress(object sender, System.EventArgs e)
        {
            cdvRework.Init();
            MPCF.InitListView(cdvRework.GetListView);
            cdvRework.Columns.Add("Rework Code", 150, HorizontalAlignment.Left);
            cdvRework.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvRework.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvRework.GetListView, '1');
        }
        
        private void cdvControl_ButtonPress(System.Object sender, System.EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            
            cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
            
            cdvTemp.Init();
            cdvTemp.Columns.Add("Unit", 50, HorizontalAlignment.Left);
            cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTemp.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvTemp.GetListView, '1', MPGC.MP_WIP_UNIT_TABLE);
            
        }
        
        private void cdvAreaId_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAreaId.Init();
            MPCF.InitListView(cdvAreaId.GetListView);
            cdvAreaId.Columns.Add("Area", 100, HorizontalAlignment.Left);
            cdvAreaId.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAreaId.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAreaId.GetListView, '1', MPGC.MP_RAS_AREA_CODE);
        }
        
        private void cdvSubAreaId_ButtonPress(object sender, System.EventArgs e)
        {
            //Modify by J.S. 2008.12.23 for area, subarea relationship
            if (MPCF.RTrim(cdvAreaId.Text) == "")
            {
                cdvSubAreaId.Init();
                MPCF.InitListView(cdvSubAreaId.GetListView);
                cdvSubAreaId.Columns.Add("Bay", 100, HorizontalAlignment.Left);
                cdvSubAreaId.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSubAreaId.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvSubAreaId.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE);
            }
            else
            {
                cdvSubAreaId.Init();
                MPCF.InitListView(cdvSubAreaId.GetListView);
                cdvSubAreaId.Columns.Add("Bay", 100, HorizontalAlignment.Left);
                cdvSubAreaId.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSubAreaId.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList_AREA(cdvSubAreaId.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE, -1, null, "", false, -1, -1, null, cdvAreaId.Text) == false)
                {
                    return;
                }
            }
        }

        private void txtOper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tabOper.SelectedTab == tbpAttribute)
            {
                udcAttributeStatus.ClearValue();
            }
        }
        
    }
    
}
