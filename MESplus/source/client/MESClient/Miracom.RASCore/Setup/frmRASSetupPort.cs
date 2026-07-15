
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
//   File Name   : frmRASSetupPort.vb
//   Description : Setyp Port
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - initCodeView() : initial CodeView Control
//       - CheckCondition() : Check the conditions before transaction
//       - Update_Tool() : Create/Update/Delete Resource
//       - View_Tool_Type() : View Tool Type Information
//       - View_Tool() : View Tool Information
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
    public class frmRASSetupPort : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupPort()
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
        



        private System.Windows.Forms.Panel pnlType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.Label lblType;
        private Miracom.UI.Controls.MCListView.MCListView lisResource;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblVender;
        private System.Windows.Forms.Label lblToolLoc;
        private System.Windows.Forms.Label lblToolSetLoc;
        private System.Windows.Forms.Label lblToolState;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.TextBox txtPortStatus;
        private System.Windows.Forms.TextBox txtPortID;
        private System.Windows.Forms.Label lblPortID;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.ComboBox cboPortType;
        private System.Windows.Forms.Label lblProcRule;
        private System.Windows.Forms.TextBox txtBCRStatus;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.TextBox txtAddPortType;
        private System.Windows.Forms.TextBox txtPortLevel;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.TextBox txtPortSeq;
        private System.Windows.Forms.TextBox txtPortDesc;
        private System.Windows.Forms.TextBox txtCrrID;
        private System.Windows.Forms.ComboBox cboPortBatch;
        private System.Windows.Forms.TabControl tabPort;
        private System.Windows.Forms.GroupBox grpPortList;
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
        private TextBox txtAscState;
        private Label lblAscState;
        private TextBox txtAscObjID;
        private Label lblAscObjID;
        private TextBox txtAccState;
        private Label lblAccState;
        private TextBox txtRsvObjID;
        private Label lblRsvObjID;
        private TextBox txtRsvState;
        private Label lblRsvState;
        private Miracom.UI.Controls.MCListView.MCListView lisPort;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlType = new System.Windows.Forms.Panel();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.lisResource = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpPortList = new System.Windows.Forms.GroupBox();
            this.lisPort = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.tabPort = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.txtRsvObjID = new System.Windows.Forms.TextBox();
            this.lblRsvObjID = new System.Windows.Forms.Label();
            this.txtRsvState = new System.Windows.Forms.TextBox();
            this.lblRsvState = new System.Windows.Forms.Label();
            this.txtAccState = new System.Windows.Forms.TextBox();
            this.lblAccState = new System.Windows.Forms.Label();
            this.txtAscObjID = new System.Windows.Forms.TextBox();
            this.lblAscObjID = new System.Windows.Forms.Label();
            this.txtAscState = new System.Windows.Forms.TextBox();
            this.lblAscState = new System.Windows.Forms.Label();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.txtPortLevel = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cboPortBatch = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboPortType = new System.Windows.Forms.ComboBox();
            this.lblProcRule = new System.Windows.Forms.Label();
            this.txtAddPortType = new System.Windows.Forms.TextBox();
            this.lblVender = new System.Windows.Forms.Label();
            this.txtPortDesc = new System.Windows.Forms.TextBox();
            this.txtPortSeq = new System.Windows.Forms.TextBox();
            this.txtPortID = new System.Windows.Forms.TextBox();
            this.lblToolLoc = new System.Windows.Forms.Label();
            this.lblToolSetLoc = new System.Windows.Forms.Label();
            this.lblPortID = new System.Windows.Forms.Label();
            this.txtBCRStatus = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtCrrID = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPortStatus = new System.Windows.Forms.TextBox();
            this.lblToolState = new System.Windows.Forms.Label();
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
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.grpPortList.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.tabPort.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
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
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlGeneral);
            this.pnlRight.Controls.Add(this.grpPortList);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisResource);
            this.pnlLeft.Controls.Add(this.pnlType);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
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
            this.lblFormTitle.Text = "Port Setup";
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.cdvType);
            this.pnlType.Controls.Add(this.lblType);
            this.pnlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlType.Location = new System.Drawing.Point(0, 0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(232, 40);
            this.pnlType.TabIndex = 0;
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
            this.cdvType.Location = new System.Drawing.Point(92, 8);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = true;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(132, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 0;
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
            this.lblType.Location = new System.Drawing.Point(6, 11);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(80, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Resource Type";
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
            this.lisResource.Location = new System.Drawing.Point(0, 40);
            this.lisResource.MultiSelect = false;
            this.lisResource.Name = "lisResource";
            this.lisResource.Size = new System.Drawing.Size(232, 466);
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
            // grpPortList
            // 
            this.grpPortList.Controls.Add(this.lisPort);
            this.grpPortList.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPortList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPortList.Location = new System.Drawing.Point(0, 0);
            this.grpPortList.Name = "grpPortList";
            this.grpPortList.Size = new System.Drawing.Size(506, 184);
            this.grpPortList.TabIndex = 0;
            this.grpPortList.TabStop = false;
            // 
            // lisPort
            // 
            this.lisPort.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader9,
            this.ColumnHeader10,
            this.ColumnHeader11,
            this.ColumnHeader12,
            this.ColumnHeader13});
            this.lisPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisPort.EnableSort = true;
            this.lisPort.EnableSortIcon = true;
            this.lisPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisPort.FullRowSelect = true;
            this.lisPort.Location = new System.Drawing.Point(3, 16);
            this.lisPort.MultiSelect = false;
            this.lisPort.Name = "lisPort";
            this.lisPort.Size = new System.Drawing.Size(500, 165);
            this.lisPort.TabIndex = 0;
            this.lisPort.UseCompatibleStateImageBehavior = false;
            this.lisPort.View = System.Windows.Forms.View.Details;
            this.lisPort.SelectedIndexChanged += new System.EventHandler(this.lisPort_SelectedIndexChanged);
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Seq.";
            this.ColumnHeader3.Width = 36;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Port ID";
            this.ColumnHeader4.Width = 66;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Description";
            this.ColumnHeader5.Width = 78;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Status";
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Lot ID";
            this.ColumnHeader7.Width = 65;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Carrier ID";
            this.ColumnHeader8.Width = 64;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "BCR Status";
            this.ColumnHeader9.Width = 71;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Port Type";
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Port Batch Flag";
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Add Port Type";
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Port Level";
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.tabPort);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 184);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlGeneral.Size = new System.Drawing.Size(506, 322);
            this.pnlGeneral.TabIndex = 1;
            // 
            // tabPort
            // 
            this.tabPort.Controls.Add(this.tbpGeneral);
            this.tabPort.Controls.Add(this.tbpCMF);
            this.tabPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPort.ItemSize = new System.Drawing.Size(60, 18);
            this.tabPort.Location = new System.Drawing.Point(0, 5);
            this.tabPort.Name = "tabPort";
            this.tabPort.SelectedIndex = 0;
            this.tabPort.Size = new System.Drawing.Size(506, 317);
            this.tabPort.TabIndex = 0;
            this.tabPort.TabStop = false;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(498, 291);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.txtRsvObjID);
            this.grpGeneral.Controls.Add(this.lblRsvObjID);
            this.grpGeneral.Controls.Add(this.txtRsvState);
            this.grpGeneral.Controls.Add(this.lblRsvState);
            this.grpGeneral.Controls.Add(this.txtAccState);
            this.grpGeneral.Controls.Add(this.lblAccState);
            this.grpGeneral.Controls.Add(this.txtAscObjID);
            this.grpGeneral.Controls.Add(this.lblAscObjID);
            this.grpGeneral.Controls.Add(this.txtAscState);
            this.grpGeneral.Controls.Add(this.lblAscState);
            this.grpGeneral.Controls.Add(this.lblUpdateTime);
            this.grpGeneral.Controls.Add(this.lblUpdateUser);
            this.grpGeneral.Controls.Add(this.lblCreateTime);
            this.grpGeneral.Controls.Add(this.lblCreateUser);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.txtCreateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUser);
            this.grpGeneral.Controls.Add(this.txtCreateUser);
            this.grpGeneral.Controls.Add(this.txtPortLevel);
            this.grpGeneral.Controls.Add(this.Label5);
            this.grpGeneral.Controls.Add(this.cboPortBatch);
            this.grpGeneral.Controls.Add(this.Label4);
            this.grpGeneral.Controls.Add(this.cboPortType);
            this.grpGeneral.Controls.Add(this.lblProcRule);
            this.grpGeneral.Controls.Add(this.txtAddPortType);
            this.grpGeneral.Controls.Add(this.lblVender);
            this.grpGeneral.Controls.Add(this.txtPortDesc);
            this.grpGeneral.Controls.Add(this.txtPortSeq);
            this.grpGeneral.Controls.Add(this.txtPortID);
            this.grpGeneral.Controls.Add(this.lblToolLoc);
            this.grpGeneral.Controls.Add(this.lblToolSetLoc);
            this.grpGeneral.Controls.Add(this.lblPortID);
            this.grpGeneral.Controls.Add(this.txtBCRStatus);
            this.grpGeneral.Controls.Add(this.Label3);
            this.grpGeneral.Controls.Add(this.txtCrrID);
            this.grpGeneral.Controls.Add(this.Label2);
            this.grpGeneral.Controls.Add(this.txtLotID);
            this.grpGeneral.Controls.Add(this.Label1);
            this.grpGeneral.Controls.Add(this.txtPortStatus);
            this.grpGeneral.Controls.Add(this.lblToolState);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(492, 288);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // txtRsvObjID
            // 
            this.txtRsvObjID.Location = new System.Drawing.Point(360, 216);
            this.txtRsvObjID.MaxLength = 30;
            this.txtRsvObjID.Name = "txtRsvObjID";
            this.txtRsvObjID.ReadOnly = true;
            this.txtRsvObjID.Size = new System.Drawing.Size(116, 20);
            this.txtRsvObjID.TabIndex = 31;
            this.txtRsvObjID.TabStop = false;
            // 
            // lblRsvObjID
            // 
            this.lblRsvObjID.AutoSize = true;
            this.lblRsvObjID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRsvObjID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRsvObjID.Location = new System.Drawing.Point(251, 219);
            this.lblRsvObjID.Name = "lblRsvObjID";
            this.lblRsvObjID.Size = new System.Drawing.Size(112, 13);
            this.lblRsvObjID.TabIndex = 30;
            this.lblRsvObjID.Text = "Reservation Object ID";
            // 
            // txtRsvState
            // 
            this.txtRsvState.Location = new System.Drawing.Point(120, 216);
            this.txtRsvState.MaxLength = 1;
            this.txtRsvState.Name = "txtRsvState";
            this.txtRsvState.ReadOnly = true;
            this.txtRsvState.Size = new System.Drawing.Size(116, 20);
            this.txtRsvState.TabIndex = 29;
            this.txtRsvState.TabStop = false;
            // 
            // lblRsvState
            // 
            this.lblRsvState.AutoSize = true;
            this.lblRsvState.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRsvState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRsvState.Location = new System.Drawing.Point(12, 219);
            this.lblRsvState.Name = "lblRsvState";
            this.lblRsvState.Size = new System.Drawing.Size(92, 13);
            this.lblRsvState.TabIndex = 28;
            this.lblRsvState.Text = "Reservation State";
            // 
            // txtAccState
            // 
            this.txtAccState.Location = new System.Drawing.Point(120, 192);
            this.txtAccState.MaxLength = 1;
            this.txtAccState.Name = "txtAccState";
            this.txtAccState.ReadOnly = true;
            this.txtAccState.Size = new System.Drawing.Size(116, 20);
            this.txtAccState.TabIndex = 27;
            this.txtAccState.TabStop = false;
            // 
            // lblAccState
            // 
            this.lblAccState.AutoSize = true;
            this.lblAccState.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAccState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAccState.Location = new System.Drawing.Point(12, 195);
            this.lblAccState.Name = "lblAccState";
            this.lblAccState.Size = new System.Drawing.Size(100, 13);
            this.lblAccState.TabIndex = 26;
            this.lblAccState.Text = "Access Mode State";
            // 
            // txtAscObjID
            // 
            this.txtAscObjID.Location = new System.Drawing.Point(360, 167);
            this.txtAscObjID.MaxLength = 30;
            this.txtAscObjID.Name = "txtAscObjID";
            this.txtAscObjID.ReadOnly = true;
            this.txtAscObjID.Size = new System.Drawing.Size(116, 20);
            this.txtAscObjID.TabIndex = 25;
            this.txtAscObjID.TabStop = false;
            // 
            // lblAscObjID
            // 
            this.lblAscObjID.AutoSize = true;
            this.lblAscObjID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAscObjID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAscObjID.Location = new System.Drawing.Point(251, 170);
            this.lblAscObjID.Name = "lblAscObjID";
            this.lblAscObjID.Size = new System.Drawing.Size(109, 13);
            this.lblAscObjID.TabIndex = 24;
            this.lblAscObjID.Text = "Association Object ID";
            // 
            // txtAscState
            // 
            this.txtAscState.Location = new System.Drawing.Point(120, 167);
            this.txtAscState.MaxLength = 1;
            this.txtAscState.Name = "txtAscState";
            this.txtAscState.ReadOnly = true;
            this.txtAscState.Size = new System.Drawing.Size(116, 20);
            this.txtAscState.TabIndex = 23;
            this.txtAscState.TabStop = false;
            // 
            // lblAscState
            // 
            this.lblAscState.AutoSize = true;
            this.lblAscState.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAscState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAscState.Location = new System.Drawing.Point(12, 170);
            this.lblAscState.Name = "lblAscState";
            this.lblAscState.Size = new System.Drawing.Size(89, 13);
            this.lblAscState.TabIndex = 22;
            this.lblAscState.Text = "Association State";
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(251, 267);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 38;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(12, 266);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 36;
            this.lblUpdateUser.Text = "Update User";
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(251, 242);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 34;
            this.lblCreateTime.Text = "Create Time";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(12, 242);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 32;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(360, 264);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(116, 20);
            this.txtUpdateTime.TabIndex = 39;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(360, 240);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(116, 20);
            this.txtCreateTime.TabIndex = 35;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 264);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(116, 20);
            this.txtUpdateUser.TabIndex = 37;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 240);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(116, 20);
            this.txtCreateUser.TabIndex = 33;
            this.txtCreateUser.TabStop = false;
            // 
            // txtPortLevel
            // 
            this.txtPortLevel.Location = new System.Drawing.Point(360, 95);
            this.txtPortLevel.MaxLength = 1;
            this.txtPortLevel.Name = "txtPortLevel";
            this.txtPortLevel.Size = new System.Drawing.Size(116, 20);
            this.txtPortLevel.TabIndex = 13;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(251, 97);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(55, 13);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "Port Level";
            // 
            // cboPortBatch
            // 
            this.cboPortBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortBatch.Items.AddRange(new object[] {
            "Y",
            ""});
            this.cboPortBatch.Location = new System.Drawing.Point(360, 69);
            this.cboPortBatch.Name = "cboPortBatch";
            this.cboPortBatch.Size = new System.Drawing.Size(116, 21);
            this.cboPortBatch.TabIndex = 9;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(251, 71);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(57, 13);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Port Batch";
            // 
            // cboPortType
            // 
            this.cboPortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortType.Items.AddRange(new object[] {
            "LOAD",
            "UNLOAD",
            "BOTH"});
            this.cboPortType.Location = new System.Drawing.Point(120, 69);
            this.cboPortType.Name = "cboPortType";
            this.cboPortType.Size = new System.Drawing.Size(116, 21);
            this.cboPortType.TabIndex = 7;
            // 
            // lblProcRule
            // 
            this.lblProcRule.AutoSize = true;
            this.lblProcRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcRule.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProcRule.Location = new System.Drawing.Point(12, 71);
            this.lblProcRule.Name = "lblProcRule";
            this.lblProcRule.Size = new System.Drawing.Size(62, 13);
            this.lblProcRule.TabIndex = 6;
            this.lblProcRule.Text = "Port Type";
            // 
            // txtAddPortType
            // 
            this.txtAddPortType.Location = new System.Drawing.Point(120, 95);
            this.txtAddPortType.MaxLength = 1;
            this.txtAddPortType.Name = "txtAddPortType";
            this.txtAddPortType.Size = new System.Drawing.Size(116, 20);
            this.txtAddPortType.TabIndex = 11;
            // 
            // lblVender
            // 
            this.lblVender.AutoSize = true;
            this.lblVender.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVender.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVender.Location = new System.Drawing.Point(12, 98);
            this.lblVender.Name = "lblVender";
            this.lblVender.Size = new System.Drawing.Size(75, 13);
            this.lblVender.TabIndex = 10;
            this.lblVender.Text = "Add Port Type";
            // 
            // txtPortDesc
            // 
            this.txtPortDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPortDesc.Location = new System.Drawing.Point(120, 43);
            this.txtPortDesc.MaxLength = 200;
            this.txtPortDesc.Name = "txtPortDesc";
            this.txtPortDesc.Size = new System.Drawing.Size(356, 20);
            this.txtPortDesc.TabIndex = 5;
            // 
            // txtPortSeq
            // 
            this.txtPortSeq.Location = new System.Drawing.Point(360, 20);
            this.txtPortSeq.MaxLength = 6;
            this.txtPortSeq.Name = "txtPortSeq";
            this.txtPortSeq.Size = new System.Drawing.Size(116, 20);
            this.txtPortSeq.TabIndex = 3;
            this.txtPortSeq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPortSequence_KeyPress);
            // 
            // txtPortID
            // 
            this.txtPortID.Location = new System.Drawing.Point(120, 19);
            this.txtPortID.MaxLength = 10;
            this.txtPortID.Name = "txtPortID";
            this.txtPortID.Size = new System.Drawing.Size(116, 20);
            this.txtPortID.TabIndex = 1;
            // 
            // lblToolLoc
            // 
            this.lblToolLoc.AutoSize = true;
            this.lblToolLoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolLoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolLoc.Location = new System.Drawing.Point(12, 47);
            this.lblToolLoc.Name = "lblToolLoc";
            this.lblToolLoc.Size = new System.Drawing.Size(60, 13);
            this.lblToolLoc.TabIndex = 4;
            this.lblToolLoc.Text = "Description";
            // 
            // lblToolSetLoc
            // 
            this.lblToolSetLoc.AutoSize = true;
            this.lblToolSetLoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolSetLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolSetLoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolSetLoc.Location = new System.Drawing.Point(252, 22);
            this.lblToolSetLoc.Name = "lblToolSetLoc";
            this.lblToolSetLoc.Size = new System.Drawing.Size(91, 13);
            this.lblToolSetLoc.TabIndex = 2;
            this.lblToolSetLoc.Text = "Port Sequence";
            // 
            // lblPortID
            // 
            this.lblPortID.AutoSize = true;
            this.lblPortID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPortID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPortID.Location = new System.Drawing.Point(12, 21);
            this.lblPortID.Name = "lblPortID";
            this.lblPortID.Size = new System.Drawing.Size(47, 13);
            this.lblPortID.TabIndex = 0;
            this.lblPortID.Text = "Port ID";
            // 
            // txtBCRStatus
            // 
            this.txtBCRStatus.Location = new System.Drawing.Point(360, 142);
            this.txtBCRStatus.MaxLength = 1;
            this.txtBCRStatus.Name = "txtBCRStatus";
            this.txtBCRStatus.ReadOnly = true;
            this.txtBCRStatus.Size = new System.Drawing.Size(116, 20);
            this.txtBCRStatus.TabIndex = 21;
            this.txtBCRStatus.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(251, 145);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(62, 13);
            this.Label3.TabIndex = 20;
            this.Label3.Text = "BCR Status";
            // 
            // txtCrrID
            // 
            this.txtCrrID.Location = new System.Drawing.Point(360, 118);
            this.txtCrrID.MaxLength = 20;
            this.txtCrrID.Name = "txtCrrID";
            this.txtCrrID.ReadOnly = true;
            this.txtCrrID.Size = new System.Drawing.Size(116, 20);
            this.txtCrrID.TabIndex = 17;
            this.txtCrrID.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(251, 121);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(51, 13);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Carrier ID";
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(120, 142);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(116, 20);
            this.txtLotID.TabIndex = 19;
            this.txtLotID.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(12, 145);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(36, 13);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "Lot ID";
            // 
            // txtPortStatus
            // 
            this.txtPortStatus.Location = new System.Drawing.Point(120, 118);
            this.txtPortStatus.MaxLength = 10;
            this.txtPortStatus.Name = "txtPortStatus";
            this.txtPortStatus.ReadOnly = true;
            this.txtPortStatus.Size = new System.Drawing.Size(116, 20);
            this.txtPortStatus.TabIndex = 15;
            this.txtPortStatus.TabStop = false;
            // 
            // lblToolState
            // 
            this.lblToolState.AutoSize = true;
            this.lblToolState.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolState.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolState.Location = new System.Drawing.Point(12, 121);
            this.lblToolState.Name = "lblToolState";
            this.lblToolState.Size = new System.Drawing.Size(74, 13);
            this.lblToolState.TabIndex = 14;
            this.lblToolState.Text = "Transfer State";
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(498, 291);
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
            this.grpCMF.Size = new System.Drawing.Size(492, 288);
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
            // frmRASSetupPort
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupPort";
            this.Text = "Port Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupPort_Activated);
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
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.grpPortList.ResumeLayout(false);
            this.pnlGeneral.ResumeLayout(false);
            this.tabPort.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
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
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            
            try
            {

                switch (MPCF.Trim(FuncName))
                {
                    case "Create_Port":

                        if (MPCF.CheckValue(txtPortID, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtPortSeq, 2) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cboPortType, 1) == false)
                        {
                            return false;
                        }
                        if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                        {
                            tabPort.SelectedTab = tbpCMF;
                            return false;
                        }
                        break;
                        
                    case "Update_Port":

                        if (MPCF.CheckValue(txtPortID, 1) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(txtPortSeq, 2) == false)
                        {
                            return false;
                        }
                        if (MPCF.CheckValue(cboPortType, 1) == false)
                        {
                            return false;
                        }
                        if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                        {
                            tabPort.SelectedTab = tbpCMF;
                            return false;
                        }
                        break;
                    case "Delete_Port":

                        if (MPCF.CheckValue(txtPortID, 1) == false)
                        {
                            return false;
                        }
                        break;
                        
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        // ViewPortListDetail()
        //       - View Port List
        // Return Value
        //       - boolean : True / False
        // PORT LISTë¥?ì¡°íšŒ?œë‹¤.
        
        private bool ViewPortList(Control control, char c_step, string sResource, string sSubResource)
        {
            
            int i;
            ListViewItem itmX;

            TRSNode in_node = new TRSNode("View_Port_List_In");
            TRSNode out_node = new TRSNode("View_Port_List_Out");
            
            MPCF.InitListView((ListView)control);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("RES_ID", sResource);
            in_node.AddString("SUBRES_ID", sSubResource);

            if (MPCR.CallService("RAS", "RAS_View_Port_List", in_node, ref out_node) == false)
            {
                return false;
            }
            
            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                itmX = new ListViewItem(MPCF.Trim(out_node.GetList(0)[i].GetInt("PORT_SEQ")), (int)SMALLICON_INDEX.IDX_SETUP);
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PORT_ID")));
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("PORT_DESC")));
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("TRS_STATE")));
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("LOT_ID")));
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("CRR_ID")));
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("BCR_STATUS_FLAG")));
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("PORT_TYPE")));
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("PORT_BATCH_FLAG")));
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("ADD_PORT_TYPE")));
                itmX.SubItems.Add(MPCF.Trim(out_node.GetList(0)[i].GetChar("PORT_LEVEL")));
                
                ((ListView) control).Items.Add(itmX);
            }
            
            return true;
            
        }
        
        // View_Port()
        //       -  View Port
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Port()
        {
            TRSNode in_node = new TRSNode("View_Port_In");
            TRSNode out_node = new TRSNode("View_Port_Out");
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("RES_ID", MPCF.Trim(lisResource.SelectedItems[0].Text));
                in_node.AddString("SUBRES_ID", "");
                in_node.AddString("PORT_ID", MPCF.Trim(lisPort.SelectedItems[0].SubItems[1].Text));

                if (MPCR.CallService("RAS", "RAS_View_Port", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtPortSeq.Text = out_node.GetInt("PORT_SEQ").ToString();
                txtPortID.Text = out_node.GetString("PORT_ID");
                txtPortDesc.Text = out_node.GetString("PORT_DESC");
                txtPortStatus.Text = out_node.GetString("TRS_STATE");

                txtLotID.Text = out_node.GetString("LOT_ID");
                txtCrrID.Text = out_node.GetString("CRR_ID");
                txtBCRStatus.Text = out_node.GetChar("BCR_STATUS_FLAG").ToString();

                txtAscState.Text = out_node.GetChar("ASC_STATE").ToString();
                txtAscObjID.Text = out_node.GetString("ASC_OBJ_ID");
                txtAccState.Text = out_node.GetChar("ACC_STATE").ToString();
                txtRsvState.Text = out_node.GetChar("RSV_STATE").ToString();
                txtRsvObjID.Text = out_node.GetString("RSV_OBJ_ID");
                

                if (out_node.GetChar("PORT_TYPE") == 'L')
                {
                    cboPortType.SelectedIndex = 0;
                }
                else if (out_node.GetChar("PORT_TYPE") == 'U')
                {
                    cboPortType.SelectedIndex = 1;
                }
                else
                {
                    cboPortType.SelectedIndex = 2;
                }
                if (out_node.GetChar("PORT_BATCH_FLAG") == 'Y')
                {
                    cboPortBatch.SelectedIndex = 0;
                }
                else
                {
                    cboPortBatch.SelectedIndex = 1;
                }
                txtAddPortType.Text = out_node.GetChar("ADD_PORT_TYPE").ToString();
                txtPortLevel.Text = out_node.GetChar("PORT_LEVEL").ToString();

                cdvCMF1.Text = out_node.GetString("PORT_CMF_1");
                cdvCMF2.Text = out_node.GetString("PORT_CMF_2");
                cdvCMF3.Text = out_node.GetString("PORT_CMF_3");
                cdvCMF4.Text = out_node.GetString("PORT_CMF_4");
                cdvCMF5.Text = out_node.GetString("PORT_CMF_5");
                cdvCMF6.Text = out_node.GetString("PORT_CMF_6");
                cdvCMF7.Text = out_node.GetString("PORT_CMF_7");
                cdvCMF8.Text = out_node.GetString("PORT_CMF_8");
                cdvCMF9.Text = out_node.GetString("PORT_CMF_9");
                cdvCMF10.Text = out_node.GetString("PORT_CMF_10");
                cdvCMF11.Text = out_node.GetString("PORT_CMF_11");
                cdvCMF12.Text = out_node.GetString("PORT_CMF_12");
                cdvCMF13.Text = out_node.GetString("PORT_CMF_13");
                cdvCMF14.Text = out_node.GetString("PORT_CMF_14");
                cdvCMF15.Text = out_node.GetString("PORT_CMF_15");
                cdvCMF16.Text = out_node.GetString("PORT_CMF_16");
                cdvCMF17.Text = out_node.GetString("PORT_CMF_17");
                cdvCMF18.Text = out_node.GetString("PORT_CMF_18");
                cdvCMF19.Text = out_node.GetString("PORT_CMF_19");
                cdvCMF20.Text = out_node.GetString("PORT_CMF_20");

                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //
        // Update_Port()
        //       -  Update Port
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - ByVal c_step As String     : ?•ìž¥ Process Step
        //
        private bool Update_Port(char c_step)
        {
            TRSNode in_node = new TRSNode("Update_Port_In");
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {                
                if (lisResource.SelectedItems.Count <= 0)
                {
                    return false;
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("RES_ID", MPCF.Trim(lisResource.SelectedItems[0].Text));
                in_node.AddString("SUBRES_ID", "");
                in_node.AddString("PORT_ID", MPCF.Trim(txtPortID.Text));
                in_node.AddString("PORT_DESC", MPCF.Trim(txtPortDesc.Text));
                in_node.AddInt("PORT_SEQ", MPCF.ToInt(txtPortSeq.Text));

                if (cboPortType.Text == "LOAD")
                {
                    in_node.AddChar("PORT_TYPE", 'L');
                }
                else if (cboPortType.Text == "UNLOAD")
                {
                    in_node.AddChar("PORT_TYPE", 'U');
                }
                else
                {
                    in_node.AddChar("PORT_TYPE", 'B');
                }
                
                if (cboPortBatch.Text == "Y")
                {
                    in_node.AddChar("PORT_BATCH_FLAG",'Y');
                }
                else
                {
                    in_node.AddChar("PORT_BATCH_FLAG", ' ');
                }

                in_node.AddChar("ADD_PORT_TYPE", MPCF.ToChar(MPCF.Trim(txtAddPortType.Text)));
                in_node.AddChar("PORT_LEVEL", MPCF.ToChar(MPCF.Trim(txtPortLevel.Text)));

                in_node.AddString("PORT_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("PORT_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("PORT_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("PORT_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("PORT_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("PORT_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("PORT_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("PORT_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("PORT_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("PORT_CMF_10", MPCF.Trim(cdvCMF10.Text));
                in_node.AddString("PORT_CMF_11", MPCF.Trim(cdvCMF11.Text));
                in_node.AddString("PORT_CMF_12", MPCF.Trim(cdvCMF12.Text));
                in_node.AddString("PORT_CMF_13", MPCF.Trim(cdvCMF13.Text));
                in_node.AddString("PORT_CMF_14", MPCF.Trim(cdvCMF14.Text));
                in_node.AddString("PORT_CMF_15", MPCF.Trim(cdvCMF15.Text));
                in_node.AddString("PORT_CMF_16", MPCF.Trim(cdvCMF16.Text));
                in_node.AddString("PORT_CMF_17", MPCF.Trim(cdvCMF17.Text));
                in_node.AddString("PORT_CMF_18", MPCF.Trim(cdvCMF18.Text));
                in_node.AddString("PORT_CMF_19", MPCF.Trim(cdvCMF19.Text));
                in_node.AddString("PORT_CMF_20", MPCF.Trim(cdvCMF20.Text));

                if (MPCR.CallService("RAS", "RAS_Update_Port", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
                
                //If gbListAutoRefresh = False Then
                //    If FindListItem(lisResource, RTrim(txtResource.Text)) = True Then
                //        lisResource.SelectedItems(0).SubItems(1).Text = RTrim(txtDesc.Text)
                //    End If
                //End If
                
                return true;
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
        
        private void frmRASSetupPort_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.FieldVisible(tbpCMF, false);
                MPCF.InitListView(lisResource);
                MPCF.InitListView(lisPort);
                
                lisResource.Focus();
                MPCR.SetCMFItem(MPGC.MP_CMF_PORT, "lblCmf", "cdvCmf", grpCMF);
                
                //Resource Setting
                lblDataCount.Text = "";
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
        
        private void cdvType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                lblDataCount.Text = "";
                lisResource.Items.Clear();
                if (RASLIST.ViewResourceList(lisResource, "", cdvType.Text, false) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisResource.Items.Count);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight);
                MPCF.InitListView(lisPort);
                if (RASLIST.ViewResourceList(lisResource, "", cdvType.Text, false) == true)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        
        private void txtPortSequence_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
            
        }
        
        private void lisResource_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            //Port ë¦¿ìŠ¤?¸ë? ì¡°íšŒ?œë‹¤
            MPCF.FieldClear(this.pnlRight);
            if (lisResource.SelectedItems.Count > 0)
            {
                ViewPortList(lisPort, '1', lisResource.SelectedItems[0].Text, "");
                //txtResource.Text = lisResource.SelectedItems.Item(0).Text
                //View_Resource()
            }
            
        }
        
        private void lisPort_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            
            if (lisResource.SelectedItems.Count <= 0)
            {
                return;
            }
            
            //Port ë¦¿ìŠ¤?¸ë? ì¡°íšŒ?œë‹¤
            MPCF.FieldClear(this.grpGeneral);
            if (lisPort.SelectedItems.Count > 0)
            {
                View_Port();
                //txtResource.Text = lisResource.SelectedItems.Item(0).Text
                //View_Resource()
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisPort, this.Text, "");
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Create_Port", MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                
                if (Update_Port(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                
                ViewPortList(lisPort, '1', lisResource.SelectedItems[0].Text, "");

                MPCF.FindListItem(lisPort, MPCF.Trim(txtPortID.Text), 1, false);
                
                
                
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
                
                if (CheckCondition("Create_Port", MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                
                if (Update_Port(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                
                ViewPortList(lisPort, '1', lisResource.SelectedItems[0].Text, "");

                MPCF.FindListItem(lisPort, MPCF.Trim(txtPortID.Text), 1, false);
                
                
                
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
                if (CheckCondition("Create_Port", MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                
                if (Update_Port(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                
                ViewPortList(lisPort, '1', lisResource.SelectedItems[0].Text, "");
                MPCF.FieldClear(this.grpGeneral);
                
                
                
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

        
        
    }
    
}
