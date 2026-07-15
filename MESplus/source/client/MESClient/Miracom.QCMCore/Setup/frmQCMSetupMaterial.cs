
using Miracom.CliFrx;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmQCMSetupMaterial.vb
//   Description : Inspection Material Definition Form
//
//   MES Version : 1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Inspection_Material() : View Inspection Material definition
//       - Update_Inspection_Material() : Create/Update/Delete Inspection Material definition
//       - initCodeView() :   initial CodeView Control
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-12-16 : Created by HS Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _QCM = True Then

namespace Miracom.QCMCore
{
    public class frmQCMSetupMaterial : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMSetupMaterial()
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
        private Miracom.UI.Controls.MCListView.MCListView lisMaterial;
        private System.Windows.Forms.ColumnHeader colMaterial;
        private System.Windows.Forms.ColumnHeader colMatDesc;
        private System.Windows.Forms.GroupBox grpMaterial;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Panel pnltab;
        private System.Windows.Forms.TabControl tabSampling;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TextBox txtMaxBatchQty;
        private System.Windows.Forms.Label lblMaxBatchQty;
        private System.Windows.Forms.CheckBox chkTotalInspection;
        private System.Windows.Forms.CheckBox chkAutoFinal;
        private System.Windows.Forms.CheckBox chkSkipResult;
        private System.Windows.Forms.CheckBox chkIQC;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvIQCInspSetID;
        private System.Windows.Forms.Label lblIQCInspSet;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPQCInspSetID;
        private System.Windows.Forms.Label lblPQCInspSetID;
        private System.Windows.Forms.CheckBox chkPQC;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOQCInspSetID;
        private System.Windows.Forms.Label lblOQCInspSetID;
        private System.Windows.Forms.CheckBox chkOQC;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRMAInspSetID;
        private System.Windows.Forms.Label lblRMAInspSetID;
        private System.Windows.Forms.CheckBox chkRMA;
        private ColumnHeader colMatVer;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.Label lblUnit1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisMaterial = new Miracom.UI.Controls.MCListView.MCListView();
            this.colMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMatDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpMaterial = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.pnltab = new System.Windows.Forms.Panel();
            this.tabSampling = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.cdvRMAInspSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRMAInspSetID = new System.Windows.Forms.Label();
            this.chkRMA = new System.Windows.Forms.CheckBox();
            this.cdvOQCInspSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOQCInspSetID = new System.Windows.Forms.Label();
            this.chkOQC = new System.Windows.Forms.CheckBox();
            this.cdvPQCInspSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPQCInspSetID = new System.Windows.Forms.Label();
            this.chkPQC = new System.Windows.Forms.CheckBox();
            this.cdvIQCInspSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblIQCInspSet = new System.Windows.Forms.Label();
            this.chkIQC = new System.Windows.Forms.CheckBox();
            this.chkSkipResult = new System.Windows.Forms.CheckBox();
            this.chkAutoFinal = new System.Windows.Forms.CheckBox();
            this.chkTotalInspection = new System.Windows.Forms.CheckBox();
            this.txtMaxBatchQty = new System.Windows.Forms.TextBox();
            this.lblMaxBatchQty = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpMaterial.SuspendLayout();
            this.pnltab.SuspendLayout();
            this.tabSampling.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRMAInspSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOQCInspSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPQCInspSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvIQCInspSetID)).BeginInit();
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
            this.pnlRight.Controls.Add(this.pnltab);
            this.pnlRight.Controls.Add(this.grpMaterial);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisMaterial);
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
            this.lblFormTitle.Text = "Inspection Material Setup";
            // 
            // lisMaterial
            // 
            this.lisMaterial.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaterial,
            this.colMatVer,
            this.colMatDesc});
            this.lisMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisMaterial.EnableSort = true;
            this.lisMaterial.EnableSortIcon = true;
            this.lisMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisMaterial.FullRowSelect = true;
            this.lisMaterial.Location = new System.Drawing.Point(3, 3);
            this.lisMaterial.MultiSelect = false;
            this.lisMaterial.Name = "lisMaterial";
            this.lisMaterial.Size = new System.Drawing.Size(229, 500);
            this.lisMaterial.TabIndex = 0;
            this.lisMaterial.UseCompatibleStateImageBehavior = false;
            this.lisMaterial.View = System.Windows.Forms.View.Details;
            this.lisMaterial.SelectedIndexChanged += new System.EventHandler(this.lisMaterial_SelectedIndexChanged);
            // 
            // colMaterial
            // 
            this.colMaterial.Text = "Material";
            this.colMaterial.Width = 100;
            // 
            // colMatVer
            // 
            this.colMatVer.Text = "Mat Ver";
            // 
            // colMatDesc
            // 
            this.colMatDesc.Text = "Description";
            this.colMatDesc.Width = 300;
            // 
            // grpMaterial
            // 
            this.grpMaterial.Controls.Add(this.cdvMaterial);
            this.grpMaterial.Controls.Add(this.txtDesc);
            this.grpMaterial.Controls.Add(this.Label6);
            this.grpMaterial.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpMaterial.Location = new System.Drawing.Point(3, 3);
            this.grpMaterial.Name = "grpMaterial";
            this.grpMaterial.Size = new System.Drawing.Size(500, 71);
            this.grpMaterial.TabIndex = 0;
            this.grpMaterial.TabStop = false;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(16, 13);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(321, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 119;
            this.cdvMaterial.WidthMaterialAndVersion = 202;
            this.cdvMaterial.WidthVersion = 50;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Enabled = false;
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(135, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(355, 20);
            this.txtDesc.TabIndex = 2;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(16, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 13);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Description";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnltab
            // 
            this.pnltab.Controls.Add(this.tabSampling);
            this.pnltab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnltab.Location = new System.Drawing.Point(3, 74);
            this.pnltab.Name = "pnltab";
            this.pnltab.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnltab.Size = new System.Drawing.Size(500, 429);
            this.pnltab.TabIndex = 1;
            // 
            // tabSampling
            // 
            this.tabSampling.Controls.Add(this.tbpGeneral);
            this.tabSampling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabSampling.ItemSize = new System.Drawing.Size(60, 18);
            this.tabSampling.Location = new System.Drawing.Point(0, 3);
            this.tabSampling.Name = "tabSampling";
            this.tabSampling.SelectedIndex = 0;
            this.tabSampling.Size = new System.Drawing.Size(500, 426);
            this.tabSampling.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.GroupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 400);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lblUnit1);
            this.GroupBox1.Controls.Add(this.cdvRMAInspSetID);
            this.GroupBox1.Controls.Add(this.lblRMAInspSetID);
            this.GroupBox1.Controls.Add(this.chkRMA);
            this.GroupBox1.Controls.Add(this.cdvOQCInspSetID);
            this.GroupBox1.Controls.Add(this.lblOQCInspSetID);
            this.GroupBox1.Controls.Add(this.chkOQC);
            this.GroupBox1.Controls.Add(this.cdvPQCInspSetID);
            this.GroupBox1.Controls.Add(this.lblPQCInspSetID);
            this.GroupBox1.Controls.Add(this.chkPQC);
            this.GroupBox1.Controls.Add(this.cdvIQCInspSetID);
            this.GroupBox1.Controls.Add(this.lblIQCInspSet);
            this.GroupBox1.Controls.Add(this.chkIQC);
            this.GroupBox1.Controls.Add(this.chkSkipResult);
            this.GroupBox1.Controls.Add(this.chkAutoFinal);
            this.GroupBox1.Controls.Add(this.chkTotalInspection);
            this.GroupBox1.Controls.Add(this.txtMaxBatchQty);
            this.GroupBox1.Controls.Add(this.lblMaxBatchQty);
            this.GroupBox1.Controls.Add(this.txtUpdateTime);
            this.GroupBox1.Controls.Add(this.txtCreateTime);
            this.GroupBox1.Controls.Add(this.txtUpdateUser);
            this.GroupBox1.Controls.Add(this.lblUpdate);
            this.GroupBox1.Controls.Add(this.txtCreateUser);
            this.GroupBox1.Controls.Add(this.lblCreate);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(3, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(486, 397);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // lblUnit1
            // 
            this.lblUnit1.AutoSize = true;
            this.lblUnit1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUnit1.Location = new System.Drawing.Point(376, 93);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.Size = new System.Drawing.Size(32, 13);
            this.lblUnit1.TabIndex = 5;
            this.lblUnit1.Text = "Unit1";
            this.lblUnit1.Visible = false;
            // 
            // cdvRMAInspSetID
            // 
            this.cdvRMAInspSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRMAInspSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRMAInspSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRMAInspSetID.BtnToolTipText = "";
            this.cdvRMAInspSetID.DescText = "";
            this.cdvRMAInspSetID.DisplaySubItemIndex = -1;
            this.cdvRMAInspSetID.DisplayText = "";
            this.cdvRMAInspSetID.Enabled = false;
            this.cdvRMAInspSetID.Focusing = null;
            this.cdvRMAInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRMAInspSetID.Index = 0;
            this.cdvRMAInspSetID.IsViewBtnImage = false;
            this.cdvRMAInspSetID.Location = new System.Drawing.Point(172, 268);
            this.cdvRMAInspSetID.MaxLength = 30;
            this.cdvRMAInspSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRMAInspSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRMAInspSetID.Name = "cdvRMAInspSetID";
            this.cdvRMAInspSetID.ReadOnly = false;
            this.cdvRMAInspSetID.SearchSubItemIndex = 0;
            this.cdvRMAInspSetID.SelectedDescIndex = -1;
            this.cdvRMAInspSetID.SelectedSubItemIndex = -1;
            this.cdvRMAInspSetID.SelectionStart = 0;
            this.cdvRMAInspSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvRMAInspSetID.SmallImageList = null;
            this.cdvRMAInspSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRMAInspSetID.TabIndex = 17;
            this.cdvRMAInspSetID.TextBoxToolTipText = "";
            this.cdvRMAInspSetID.TextBoxWidth = 200;
            this.cdvRMAInspSetID.VisibleButton = true;
            this.cdvRMAInspSetID.VisibleColumnHeader = false;
            this.cdvRMAInspSetID.VisibleDescription = false;
            this.cdvRMAInspSetID.ButtonPress += new System.EventHandler(this.cdvRMAInspSetID_ButtonPress);
            // 
            // lblRMAInspSetID
            // 
            this.lblRMAInspSetID.AutoSize = true;
            this.lblRMAInspSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRMAInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMAInspSetID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblRMAInspSetID.Location = new System.Drawing.Point(15, 272);
            this.lblRMAInspSetID.Name = "lblRMAInspSetID";
            this.lblRMAInspSetID.Size = new System.Drawing.Size(90, 13);
            this.lblRMAInspSetID.TabIndex = 16;
            this.lblRMAInspSetID.Text = "RMA Insp. Set ID";
            // 
            // chkRMA
            // 
            this.chkRMA.AutoSize = true;
            this.chkRMA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRMA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkRMA.Location = new System.Drawing.Point(15, 249);
            this.chkRMA.Name = "chkRMA";
            this.chkRMA.Size = new System.Drawing.Size(56, 18);
            this.chkRMA.TabIndex = 15;
            this.chkRMA.Tag = "RMA";
            this.chkRMA.Text = "RMA";
            this.chkRMA.CheckedChanged += new System.EventHandler(this.chkRMA_CheckedChanged);
            // 
            // cdvOQCInspSetID
            // 
            this.cdvOQCInspSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOQCInspSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOQCInspSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOQCInspSetID.BtnToolTipText = "";
            this.cdvOQCInspSetID.DescText = "";
            this.cdvOQCInspSetID.DisplaySubItemIndex = -1;
            this.cdvOQCInspSetID.DisplayText = "";
            this.cdvOQCInspSetID.Enabled = false;
            this.cdvOQCInspSetID.Focusing = null;
            this.cdvOQCInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOQCInspSetID.Index = 0;
            this.cdvOQCInspSetID.IsViewBtnImage = false;
            this.cdvOQCInspSetID.Location = new System.Drawing.Point(172, 224);
            this.cdvOQCInspSetID.MaxLength = 30;
            this.cdvOQCInspSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOQCInspSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOQCInspSetID.Name = "cdvOQCInspSetID";
            this.cdvOQCInspSetID.ReadOnly = false;
            this.cdvOQCInspSetID.SearchSubItemIndex = 0;
            this.cdvOQCInspSetID.SelectedDescIndex = -1;
            this.cdvOQCInspSetID.SelectedSubItemIndex = -1;
            this.cdvOQCInspSetID.SelectionStart = 0;
            this.cdvOQCInspSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvOQCInspSetID.SmallImageList = null;
            this.cdvOQCInspSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOQCInspSetID.TabIndex = 14;
            this.cdvOQCInspSetID.TextBoxToolTipText = "";
            this.cdvOQCInspSetID.TextBoxWidth = 200;
            this.cdvOQCInspSetID.VisibleButton = true;
            this.cdvOQCInspSetID.VisibleColumnHeader = false;
            this.cdvOQCInspSetID.VisibleDescription = false;
            this.cdvOQCInspSetID.ButtonPress += new System.EventHandler(this.cdvOQCInspSetID_ButtonPress);
            // 
            // lblOQCInspSetID
            // 
            this.lblOQCInspSetID.AutoSize = true;
            this.lblOQCInspSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOQCInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOQCInspSetID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOQCInspSetID.Location = new System.Drawing.Point(15, 228);
            this.lblOQCInspSetID.Name = "lblOQCInspSetID";
            this.lblOQCInspSetID.Size = new System.Drawing.Size(89, 13);
            this.lblOQCInspSetID.TabIndex = 13;
            this.lblOQCInspSetID.Text = "OQC Insp. Set ID";
            // 
            // chkOQC
            // 
            this.chkOQC.AutoSize = true;
            this.chkOQC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOQC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOQC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkOQC.Location = new System.Drawing.Point(15, 205);
            this.chkOQC.Name = "chkOQC";
            this.chkOQC.Size = new System.Drawing.Size(55, 18);
            this.chkOQC.TabIndex = 12;
            this.chkOQC.Tag = "OQC";
            this.chkOQC.Text = "OQC";
            this.chkOQC.CheckedChanged += new System.EventHandler(this.chkOQC_CheckedChanged);
            // 
            // cdvPQCInspSetID
            // 
            this.cdvPQCInspSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPQCInspSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPQCInspSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPQCInspSetID.BtnToolTipText = "";
            this.cdvPQCInspSetID.DescText = "";
            this.cdvPQCInspSetID.DisplaySubItemIndex = -1;
            this.cdvPQCInspSetID.DisplayText = "";
            this.cdvPQCInspSetID.Enabled = false;
            this.cdvPQCInspSetID.Focusing = null;
            this.cdvPQCInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPQCInspSetID.Index = 0;
            this.cdvPQCInspSetID.IsViewBtnImage = false;
            this.cdvPQCInspSetID.Location = new System.Drawing.Point(172, 180);
            this.cdvPQCInspSetID.MaxLength = 30;
            this.cdvPQCInspSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPQCInspSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPQCInspSetID.Name = "cdvPQCInspSetID";
            this.cdvPQCInspSetID.ReadOnly = false;
            this.cdvPQCInspSetID.SearchSubItemIndex = 0;
            this.cdvPQCInspSetID.SelectedDescIndex = -1;
            this.cdvPQCInspSetID.SelectedSubItemIndex = -1;
            this.cdvPQCInspSetID.SelectionStart = 0;
            this.cdvPQCInspSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvPQCInspSetID.SmallImageList = null;
            this.cdvPQCInspSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPQCInspSetID.TabIndex = 11;
            this.cdvPQCInspSetID.TextBoxToolTipText = "";
            this.cdvPQCInspSetID.TextBoxWidth = 200;
            this.cdvPQCInspSetID.VisibleButton = true;
            this.cdvPQCInspSetID.VisibleColumnHeader = false;
            this.cdvPQCInspSetID.VisibleDescription = false;
            this.cdvPQCInspSetID.ButtonPress += new System.EventHandler(this.cdvPQCInspSetID_ButtonPress);
            // 
            // lblPQCInspSetID
            // 
            this.lblPQCInspSetID.AutoSize = true;
            this.lblPQCInspSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPQCInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPQCInspSetID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblPQCInspSetID.Location = new System.Drawing.Point(15, 184);
            this.lblPQCInspSetID.Name = "lblPQCInspSetID";
            this.lblPQCInspSetID.Size = new System.Drawing.Size(88, 13);
            this.lblPQCInspSetID.TabIndex = 10;
            this.lblPQCInspSetID.Text = "PQC Insp. Set ID";
            // 
            // chkPQC
            // 
            this.chkPQC.AutoSize = true;
            this.chkPQC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkPQC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPQC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkPQC.Location = new System.Drawing.Point(15, 161);
            this.chkPQC.Name = "chkPQC";
            this.chkPQC.Size = new System.Drawing.Size(54, 18);
            this.chkPQC.TabIndex = 9;
            this.chkPQC.Tag = "PQC";
            this.chkPQC.Text = "PQC";
            this.chkPQC.CheckedChanged += new System.EventHandler(this.chkPQC_CheckedChanged);
            // 
            // cdvIQCInspSetID
            // 
            this.cdvIQCInspSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvIQCInspSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvIQCInspSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvIQCInspSetID.BtnToolTipText = "";
            this.cdvIQCInspSetID.DescText = "";
            this.cdvIQCInspSetID.DisplaySubItemIndex = -1;
            this.cdvIQCInspSetID.DisplayText = "";
            this.cdvIQCInspSetID.Enabled = false;
            this.cdvIQCInspSetID.Focusing = null;
            this.cdvIQCInspSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvIQCInspSetID.Index = 0;
            this.cdvIQCInspSetID.IsViewBtnImage = false;
            this.cdvIQCInspSetID.Location = new System.Drawing.Point(172, 136);
            this.cdvIQCInspSetID.MaxLength = 30;
            this.cdvIQCInspSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvIQCInspSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvIQCInspSetID.Name = "cdvIQCInspSetID";
            this.cdvIQCInspSetID.ReadOnly = false;
            this.cdvIQCInspSetID.SearchSubItemIndex = 0;
            this.cdvIQCInspSetID.SelectedDescIndex = -1;
            this.cdvIQCInspSetID.SelectedSubItemIndex = -1;
            this.cdvIQCInspSetID.SelectionStart = 0;
            this.cdvIQCInspSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvIQCInspSetID.SmallImageList = null;
            this.cdvIQCInspSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvIQCInspSetID.TabIndex = 8;
            this.cdvIQCInspSetID.TextBoxToolTipText = "";
            this.cdvIQCInspSetID.TextBoxWidth = 200;
            this.cdvIQCInspSetID.VisibleButton = true;
            this.cdvIQCInspSetID.VisibleColumnHeader = false;
            this.cdvIQCInspSetID.VisibleDescription = false;
            this.cdvIQCInspSetID.ButtonPress += new System.EventHandler(this.cdvIQCInspSetID_ButtonPress);
            // 
            // lblIQCInspSet
            // 
            this.lblIQCInspSet.AutoSize = true;
            this.lblIQCInspSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblIQCInspSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIQCInspSet.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblIQCInspSet.Location = new System.Drawing.Point(15, 140);
            this.lblIQCInspSet.Name = "lblIQCInspSet";
            this.lblIQCInspSet.Size = new System.Drawing.Size(84, 13);
            this.lblIQCInspSet.TabIndex = 7;
            this.lblIQCInspSet.Text = "IQC Insp. Set ID";
            // 
            // chkIQC
            // 
            this.chkIQC.AutoSize = true;
            this.chkIQC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIQC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIQC.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkIQC.Location = new System.Drawing.Point(15, 115);
            this.chkIQC.Name = "chkIQC";
            this.chkIQC.Size = new System.Drawing.Size(50, 18);
            this.chkIQC.TabIndex = 6;
            this.chkIQC.Tag = "IQC";
            this.chkIQC.Text = "IQC";
            this.chkIQC.CheckedChanged += new System.EventHandler(this.chkIQC_CheckedChanged);
            // 
            // chkSkipResult
            // 
            this.chkSkipResult.AutoSize = true;
            this.chkSkipResult.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSkipResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSkipResult.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkSkipResult.Location = new System.Drawing.Point(15, 67);
            this.chkSkipResult.Name = "chkSkipResult";
            this.chkSkipResult.Size = new System.Drawing.Size(138, 18);
            this.chkSkipResult.TabIndex = 2;
            this.chkSkipResult.Text = "Skip Result Recording";
            // 
            // chkAutoFinal
            // 
            this.chkAutoFinal.AutoSize = true;
            this.chkAutoFinal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkAutoFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoFinal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkAutoFinal.Location = new System.Drawing.Point(15, 43);
            this.chkAutoFinal.Name = "chkAutoFinal";
            this.chkAutoFinal.Size = new System.Drawing.Size(126, 18);
            this.chkAutoFinal.TabIndex = 1;
            this.chkAutoFinal.Text = "Auto. Final Decision";
            // 
            // chkTotalInspection
            // 
            this.chkTotalInspection.AutoSize = true;
            this.chkTotalInspection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTotalInspection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTotalInspection.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkTotalInspection.Location = new System.Drawing.Point(15, 19);
            this.chkTotalInspection.Name = "chkTotalInspection";
            this.chkTotalInspection.Size = new System.Drawing.Size(110, 18);
            this.chkTotalInspection.TabIndex = 0;
            this.chkTotalInspection.Text = "100% Inspection";
            // 
            // txtMaxBatchQty
            // 
            this.txtMaxBatchQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxBatchQty.Location = new System.Drawing.Point(172, 90);
            this.txtMaxBatchQty.MaxLength = 11;
            this.txtMaxBatchQty.Name = "txtMaxBatchQty";
            this.txtMaxBatchQty.Size = new System.Drawing.Size(200, 20);
            this.txtMaxBatchQty.TabIndex = 4;
            this.txtMaxBatchQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxBatchQty.Visible = false;
            // 
            // lblMaxBatchQty
            // 
            this.lblMaxBatchQty.AutoSize = true;
            this.lblMaxBatchQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxBatchQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxBatchQty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblMaxBatchQty.Location = new System.Drawing.Point(15, 94);
            this.lblMaxBatchQty.Name = "lblMaxBatchQty";
            this.lblMaxBatchQty.Size = new System.Drawing.Size(77, 13);
            this.lblMaxBatchQty.TabIndex = 3;
            this.lblMaxBatchQty.Text = "Max Batch Qty";
            this.lblMaxBatchQty.Visible = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(304, 372);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 23;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(304, 348);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 20;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(124, 372);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 22;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(12, 374);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 21;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(124, 348);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 19;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(12, 350);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 18;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmQCMSetupMaterial
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmQCMSetupMaterial";
            this.Tag = "QCM1006";
            this.Text = "Inspection Material Setup";
            this.Activated += new System.EventHandler(this.frmQCMSetupMaterial_Activated);
            this.Load += new System.EventHandler(this.frmQCMSetupMaterial_Load);
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
            this.grpMaterial.ResumeLayout(false);
            this.grpMaterial.PerformLayout();
            this.pnltab.ResumeLayout(false);
            this.tabSampling.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRMAInspSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOQCInspSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPQCInspSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvIQCInspSetID)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Constant Definition"
        
        #endregion
        
        #region "Variable Definition"
        
        bool bLoadFlag;
        
        #endregion
        
        #region " Function Definition"
        
        //-----------------------------------------------------------------------------
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        //-----------------------------------------------------------------------------
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            //bool returnValue;
            
            try
            {
//                returnValue = false;
                
                switch (FuncName)
                {
                    case "Update_Inspection_Material":


                        if ( cdvMaterial.CheckValue() == false)
                        {
                            return false;
                        }
                        
                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:
                                
                                if (txtMaxBatchQty.Text != "")
                                {
                                    if (MPCF.CheckNumeric(txtMaxBatchQty.Text) == false)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                        txtMaxBatchQty.Focus();
                                        return false;
                                    }
                                }
                                
                                if (chkIQC.Checked == true)
                                {
                                    if (MPCF.CheckValue(cdvIQCInspSetID, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                
                                if (chkPQC.Checked == true)
                                {
                                    if (MPCF.CheckValue(cdvPQCInspSetID, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                
                                if (chkOQC.Checked == true)
                                {
                                    if (MPCF.CheckValue(cdvOQCInspSetID, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                
                                if (chkRMA.Checked == true)
                                {
                                    if (MPCF.CheckValue(cdvRMAInspSetID, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                break;
                                
                                
                            case MPGC.MP_STEP_UPDATE:
                                
                                
                                if (txtMaxBatchQty.Text != "")
                                {
                                    if (MPCF.CheckNumeric(txtMaxBatchQty.Text) == false)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                        txtMaxBatchQty.Focus();
                                        return false;
                                    }
                                }
                                
                                if (chkIQC.Checked == true)
                                {
                                    if (MPCF.CheckValue(cdvIQCInspSetID, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                
                                if (chkPQC.Checked == true)
                                {
                                    if (MPCF.CheckValue(cdvPQCInspSetID, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                
                                if (chkOQC.Checked == true)
                                {
                                    if (MPCF.CheckValue(cdvOQCInspSetID, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                
                                if (chkRMA.Checked == true)
                                {
                                    if (MPCF.CheckValue(cdvRMAInspSetID, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                break;
                                
                            case MPGC.MP_STEP_DELETE:
                                
                                return true;
                                
                        }
                        break;
                    case "View_Inspection_Material":
                        
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
        
        //-----------------------------------------------------------------------------
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        //-----------------------------------------------------------------------------
        private void ClearData(char ProcStep)
        {
            
            try
            {
                
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this.pnlRight, cdvMaterial , txtDesc, null, null, null, false);
                }
                else if (ProcStep == '2')
                {
                    MPCF.ClearList(lisMaterial, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //-----------------------------------------------------------------------------
        //
        // View_Inspection_Material()
        //       - View Inspection Material Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        private bool View_Inspection_Material()
        {
            TRSNode in_node = new TRSNode("VIEW_INSPECTION_MATERIAL_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_MATERIAL_OUT");

            try
            {
                ClearData('1');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("MAT_ID", lisMaterial.SelectedItems[0].Text);
                in_node.AddInt("MAT_VER", MPCF.ToInt(lisMaterial.SelectedItems[0].SubItems[1].Text));
                
                if (MPCR.CallService("QCM", "QCM_View_Inspection_Material", in_node, ref out_node) == false)
                {
                    return false;
                }
                if (out_node.StatusValue != MPGC.MP_SUCCESS_STATUS)
                {
                    if (out_node.MsgCode != "QCM-0018")
                    {
                        MPCF.ShowMsgBox(MPCF.MakeErrorMsg(out_node.MsgCode, out_node.Msg, out_node.DBErrMsg, out_node.FieldMsg));
                    }
                    return false;
                }
                
                //General

                cdvMaterial.Text = out_node.GetString("MAT_ID");
                cdvMaterial.Version = out_node.GetInt("MAT_VER");
                txtDesc.Text = out_node.GetString("MAT_DESC");

                chkTotalInspection.Checked = (out_node.GetChar("TOTAL_INSP") == 'Y') ? true : false;
                chkAutoFinal.Checked = (out_node.GetChar("AUTO_FINAL") == 'Y') ? true : false;
                chkSkipResult.Checked = (out_node.GetChar("SKIP_RESULT_RECORD") == 'Y') ? true : false;
                //Modify by J.S. 2009.04.09
                txtMaxBatchQty.Text = out_node.GetDouble("MAX_QTY").ToString();

                chkIQC.Checked = (out_node.GetChar("IQC_FLAG") == 'Y') ? true : false;
                cdvIQCInspSetID.Text = out_node.GetString("IQC_INSP_SET_ID");
                chkPQC.Checked = (out_node.GetChar("PQC_FLAG") == 'Y') ? true : false;
                cdvPQCInspSetID.Text = out_node.GetString("PQC_INSP_SET_ID");
                chkOQC.Checked = (out_node.GetChar("OQC_FLAG") == 'Y') ? true : false;
                cdvOQCInspSetID.Text = out_node.GetString("OQC_INSP_SET_ID");
                chkRMA.Checked = (out_node.GetChar("RMA_FLAG") == 'Y') ? true : false;
                cdvRMAInspSetID.Text = out_node.GetString("RMA_INSP_SET_ID");

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
        
        //-----------------------------------------------------------------------------
        //
        // Update_Inspection_Material()
        //       - Create/Update/Delete Inspection Material Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        //-----------------------------------------------------------------------------
        private bool Update_Inspection_Material(char ProcStep)
        {            
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_INSPECTION_MATERIAL_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddInt("MAT_VER", cdvMaterial.Version);

                in_node.AddChar("TOTAL_INSP", (chkTotalInspection.Checked ? 'Y' : 'N'));
                in_node.AddChar("AUTO_FINAL", (chkAutoFinal.Checked ? 'Y' : 'N'));
                in_node.AddChar("SKIP_RESULT_RECORD", (chkSkipResult.Checked ? 'Y' : 'N'));
                
                if (txtMaxBatchQty.Text == "")
                {
                    in_node.AddDouble("MAX_QTY", 0.0);
                }
                else
                {
                    in_node.AddDouble("MAX_QTY", MPCF.ToDbl(txtMaxBatchQty.Text));
                }

                in_node.AddChar("IQC_FLAG", (chkIQC.Checked ? 'Y' : 'N'));
                in_node.AddString("IQC_INSP_SET_ID", MPCF.Trim(cdvIQCInspSetID.Text));
                in_node.AddChar("PQC_FLAG", (chkPQC.Checked ? 'Y' : 'N'));
                in_node.AddString("PQC_INSP_SET_ID", MPCF.Trim(cdvPQCInspSetID.Text));
                in_node.AddChar("OQC_FLAG", (chkOQC.Checked ? 'Y' : 'N'));
                in_node.AddString("OQC_INSP_SET_ID", MPCF.Trim(cdvOQCInspSetID.Text));
                in_node.AddChar("RMA_FLAG", (chkRMA.Checked ? 'Y' : 'N'));
                in_node.AddString("RMA_INSP_SET_ID", MPCF.Trim(cdvRMAInspSetID.Text));

                if (MPCR.CallService("QCM", "QCM_Update_Inspection_Material", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisMaterial.Items.Add(cdvMaterial.Text, (int)SMALLICON_INDEX.IDX_CHARACTER);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisMaterial.Sorting = SortOrder.Ascending;
                        lisMaterial.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisMaterial, MPCF.Trim(cdvMaterial.Text), false) == true)
                        {
                            lisMaterial.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisMaterial, MPCF.Trim(cdvMaterial.Text), false);
                        if (idx != - 1)
                        {
                            lisMaterial.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisMaterial.Items.Count.ToString();
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
                return this.lisMaterial;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmQCMSetupMaterial_Load(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmQCMSetupMaterial_Activated(object sender, System.EventArgs e)
        {
            
            if (bLoadFlag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.InitListView(lisMaterial);

                chkIQC.Checked = false;
                chkPQC.Checked = false;
                chkOQC.Checked = false;
                chkRMA.Checked = false;
                
                QCMLIST.ViewInspectionMaterialList(lisMaterial, '2', "", null, "");
                if (lisMaterial.Items.Count > 0)
                {
                    lisMaterial.Items[0].Selected = true;
                }
                lblDataCount.Text = lisMaterial.Items.Count.ToString(); 
                
                bLoadFlag = true;
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (QCMLIST.ViewInspectionMaterialList(lisMaterial, '2', "", null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisMaterial.Items.Count.ToString();
                if (lisMaterial.Items.Count > 0)
                {
                    MPCF.FindListItem(lisMaterial, cdvMaterial.Text, false);
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
                if (CheckCondition("Update_Inspection_Material", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Inspection_Material(MPGC.MP_STEP_CREATE) == false)
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
                
                if (CheckCondition("Update_Inspection_Material", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Inspection_Material(MPGC.MP_STEP_UPDATE) == false)
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
                
                if (CheckCondition("Update_Inspection_Material", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Inspection_Material(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    MPCF.FieldClear(this.pnlRight, null, null, null, null, null, false);
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
        
        private void lisMaterial_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight, null, null, null, null, null, false);
                
                if (lisMaterial.SelectedItems.Count > 0)
                {
                    cdvMaterial.Text = lisMaterial.SelectedItems[0].Text;
                    cdvMaterial.Version = MPCF.ToInt(lisMaterial.SelectedItems[0].SubItems[1].Text);
                    txtDesc.Text = lisMaterial.SelectedItems[0].SubItems[2].Text;
                    View_Inspection_Material();
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
                MPCF.ExportToExcel(lisMaterial, this.Text, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemNextPartial(lisMaterial, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemPartial(lisMaterial, txtFind.Text, 0, true, false);
            
        }
        
        private void chkIQC_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            cdvIQCInspSetID.Enabled = chkIQC.Checked;
            if (chkIQC.Checked == false)
            {
                cdvIQCInspSetID.Text = "";
            }
        }
        
        private void chkRMA_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            cdvRMAInspSetID.Enabled = chkRMA.Checked;
            if (chkRMA.Checked == false)
            {
                cdvRMAInspSetID.Text = "";
            }
        }
        
        private void chkPQC_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            cdvPQCInspSetID.Enabled = chkPQC.Checked;
            if (chkPQC.Checked == false)
            {
                cdvPQCInspSetID.Text = "";
            }
        }
        
        private void chkOQC_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            cdvOQCInspSetID.Enabled = chkOQC.Checked;
            if (chkOQC.Checked == false)
            {
                cdvOQCInspSetID.Text = "";
            }
        }
        
        private void cdvIQCInspSetID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvIQCInspSetID.Init();
            MPCF.InitListView(cdvIQCInspSetID.GetListView);
            cdvIQCInspSetID.Columns.Add("Inspection Set", 100, HorizontalAlignment.Left);
            cdvIQCInspSetID.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvIQCInspSetID.SelectedSubItemIndex = 0;
            QCMLIST.ViewInspectionSetList(cdvIQCInspSetID.GetListView, '1', MPGC.MP_QCM_INSP_TYPE_IQC, "", null, "");
        }
        
        private void cdvPQCInspSetID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvPQCInspSetID.Init();
            MPCF.InitListView(cdvPQCInspSetID.GetListView);
            cdvPQCInspSetID.Columns.Add("Inspection Set", 100, HorizontalAlignment.Left);
            cdvPQCInspSetID.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvPQCInspSetID.SelectedSubItemIndex = 0;
            QCMLIST.ViewInspectionSetList(cdvPQCInspSetID.GetListView, '1', MPGC.MP_QCM_INSP_TYPE_PQC, "", null, "");
        }
        
        private void cdvOQCInspSetID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOQCInspSetID.Init();
            MPCF.InitListView(cdvOQCInspSetID.GetListView);
            cdvOQCInspSetID.Columns.Add("Inspection Set", 100, HorizontalAlignment.Left);
            cdvOQCInspSetID.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvOQCInspSetID.SelectedSubItemIndex = 0;
            QCMLIST.ViewInspectionSetList(cdvOQCInspSetID.GetListView, '1', MPGC.MP_QCM_INSP_TYPE_OQC, "", null, "");
        }
        
        private void cdvRMAInspSetID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvRMAInspSetID.Init();
            MPCF.InitListView(cdvRMAInspSetID.GetListView);
            cdvRMAInspSetID.Columns.Add("Inspection Set", 100, HorizontalAlignment.Left);
            cdvRMAInspSetID.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvRMAInspSetID.SelectedSubItemIndex = 0;
            QCMLIST.ViewInspectionSetList(cdvRMAInspSetID.GetListView, '1', MPGC.MP_QCM_INSP_TYPE_RMA, "", null, "");
        }
        
    }
    //#End If
}
