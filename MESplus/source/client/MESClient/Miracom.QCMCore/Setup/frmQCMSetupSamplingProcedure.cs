
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
//   File Name   : frmQCMSetupSamplingProcedure.vb
//   Description : Sampling Procedure Definition Form
//
//   MES Version : 1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Sampling_Procedure() : View Label definition
//       - Update_Sampling_Procedure() : Create/Update/Delete Label definition
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
    public class frmQCMSetupSamplingProcedure : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMSetupSamplingProcedure()
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
        private System.Windows.Forms.ColumnHeader colProc;
        private System.Windows.Forms.ColumnHeader colProcDesc;
        private System.Windows.Forms.GroupBox grpLabel;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.GroupBox grpCmf;
        private System.Windows.Forms.Label lblCMF4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf1;
        private System.Windows.Forms.Label lblCMF10;
        private System.Windows.Forms.Label lblCMF9;
        private System.Windows.Forms.Label lblCMF8;
        private System.Windows.Forms.Label lblCMF3;
        private System.Windows.Forms.Label lblCMF2;
        private System.Windows.Forms.Label lblCMF1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf9;
        private System.Windows.Forms.Label lblCMF5;
        private System.Windows.Forms.Label lblCMF7;
        private System.Windows.Forms.Label lblCMF6;
        private Miracom.UI.Controls.MCListView.MCListView lisSampling;
        private System.Windows.Forms.TextBox txtSampling;
        private System.Windows.Forms.Label lblSampling;
        private System.Windows.Forms.TabControl tabSampling;
        private System.Windows.Forms.Label lblCheckDetermineFlag;
        private System.Windows.Forms.Label lblSamplingCount;
        private System.Windows.Forms.Label lblSamplingRate;
        private System.Windows.Forms.ComboBox cboCheckDetermine;
        private System.Windows.Forms.TextBox txtSamplingRate;
        private System.Windows.Forms.TextBox txtSamplingScheme;
        private System.Windows.Forms.Label lblSamplingScheme;
        private System.Windows.Forms.Label lblDetermineValue;
        private System.Windows.Forms.TextBox txtDetermineValue;
        private System.Windows.Forms.Label lblSamplingType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSamplingType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf10;
        private System.Windows.Forms.Panel pnlProctab;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtSamplingQty;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisSampling = new Miracom.UI.Controls.MCListView.MCListView();
            this.colProc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProcDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpLabel = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtSampling = new System.Windows.Forms.TextBox();
            this.lblSampling = new System.Windows.Forms.Label();
            this.pnlProctab = new System.Windows.Forms.Panel();
            this.tabSampling = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cdvSamplingType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSamplingType = new System.Windows.Forms.Label();
            this.txtDetermineValue = new System.Windows.Forms.TextBox();
            this.lblDetermineValue = new System.Windows.Forms.Label();
            this.txtSamplingScheme = new System.Windows.Forms.TextBox();
            this.lblSamplingScheme = new System.Windows.Forms.Label();
            this.txtSamplingRate = new System.Windows.Forms.TextBox();
            this.txtSamplingQty = new System.Windows.Forms.TextBox();
            this.cboCheckDetermine = new System.Windows.Forms.ComboBox();
            this.lblSamplingRate = new System.Windows.Forms.Label();
            this.lblSamplingCount = new System.Windows.Forms.Label();
            this.lblCheckDetermineFlag = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCmf = new System.Windows.Forms.GroupBox();
            this.cdvCmf10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.cdvCmf8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCmf7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCmf6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCmf5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCmf4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCmf3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCmf2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCmf1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.cdvCmf9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpLabel.SuspendLayout();
            this.pnlProctab.SuspendLayout();
            this.tabSampling.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSamplingType)).BeginInit();
            this.tbpCMF.SuspendLayout();
            this.grpCmf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf9)).BeginInit();
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
            this.pnlRight.Controls.Add(this.pnlProctab);
            this.pnlRight.Controls.Add(this.grpLabel);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisSampling);
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
            this.lblFormTitle.Text = "Sampling Procedure Setup";
            // 
            // lisSampling
            // 
            this.lisSampling.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProc,
            this.colProcDesc});
            this.lisSampling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisSampling.EnableSort = true;
            this.lisSampling.EnableSortIcon = true;
            this.lisSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisSampling.FullRowSelect = true;
            this.lisSampling.Location = new System.Drawing.Point(3, 3);
            this.lisSampling.MultiSelect = false;
            this.lisSampling.Name = "lisSampling";
            this.lisSampling.Size = new System.Drawing.Size(229, 500);
            this.lisSampling.TabIndex = 0;
            this.lisSampling.UseCompatibleStateImageBehavior = false;
            this.lisSampling.View = System.Windows.Forms.View.Details;
            this.lisSampling.SelectedIndexChanged += new System.EventHandler(this.lisSampling_SelectedIndexChanged);
            // 
            // colProc
            // 
            this.colProc.Text = "Sampling Procedure";
            this.colProc.Width = 100;
            // 
            // colProcDesc
            // 
            this.colProcDesc.Text = "Description";
            this.colProcDesc.Width = 300;
            // 
            // grpLabel
            // 
            this.grpLabel.Controls.Add(this.txtDesc);
            this.grpLabel.Controls.Add(this.Label6);
            this.grpLabel.Controls.Add(this.txtSampling);
            this.grpLabel.Controls.Add(this.lblSampling);
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
            this.txtDesc.Location = new System.Drawing.Point(135, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(352, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(16, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 13);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Description";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSampling
            // 
            this.txtSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSampling.Location = new System.Drawing.Point(135, 17);
            this.txtSampling.MaxLength = 30;
            this.txtSampling.Name = "txtSampling";
            this.txtSampling.Size = new System.Drawing.Size(173, 20);
            this.txtSampling.TabIndex = 1;
            // 
            // lblSampling
            // 
            this.lblSampling.AutoSize = true;
            this.lblSampling.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampling.Location = new System.Drawing.Point(15, 19);
            this.lblSampling.Name = "lblSampling";
            this.lblSampling.Size = new System.Drawing.Size(120, 13);
            this.lblSampling.TabIndex = 0;
            this.lblSampling.Text = "Sampling Procedure";
            this.lblSampling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlProctab
            // 
            this.pnlProctab.Controls.Add(this.tabSampling);
            this.pnlProctab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlProctab.Location = new System.Drawing.Point(3, 71);
            this.pnlProctab.Name = "pnlProctab";
            this.pnlProctab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlProctab.Size = new System.Drawing.Size(500, 432);
            this.pnlProctab.TabIndex = 2;
            // 
            // tabSampling
            // 
            this.tabSampling.Controls.Add(this.tbpGeneral);
            this.tabSampling.Controls.Add(this.tbpCMF);
            this.tabSampling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSampling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabSampling.ItemSize = new System.Drawing.Size(60, 18);
            this.tabSampling.Location = new System.Drawing.Point(0, 5);
            this.tabSampling.Name = "tabSampling";
            this.tabSampling.SelectedIndex = 0;
            this.tabSampling.Size = new System.Drawing.Size(500, 427);
            this.tabSampling.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.GroupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 401);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.cdvSamplingType);
            this.GroupBox1.Controls.Add(this.lblSamplingType);
            this.GroupBox1.Controls.Add(this.txtDetermineValue);
            this.GroupBox1.Controls.Add(this.lblDetermineValue);
            this.GroupBox1.Controls.Add(this.txtSamplingScheme);
            this.GroupBox1.Controls.Add(this.lblSamplingScheme);
            this.GroupBox1.Controls.Add(this.txtSamplingRate);
            this.GroupBox1.Controls.Add(this.txtSamplingQty);
            this.GroupBox1.Controls.Add(this.cboCheckDetermine);
            this.GroupBox1.Controls.Add(this.lblSamplingRate);
            this.GroupBox1.Controls.Add(this.lblSamplingCount);
            this.GroupBox1.Controls.Add(this.lblCheckDetermineFlag);
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
            this.GroupBox1.Size = new System.Drawing.Size(486, 398);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Location = new System.Drawing.Point(380, 43);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(13, 14);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "%";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvSamplingType
            // 
            this.cdvSamplingType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSamplingType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSamplingType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSamplingType.BtnToolTipText = "";
            this.cdvSamplingType.DescText = "";
            this.cdvSamplingType.DisplaySubItemIndex = -1;
            this.cdvSamplingType.DisplayText = "";
            this.cdvSamplingType.Focusing = null;
            this.cdvSamplingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSamplingType.Index = 0;
            this.cdvSamplingType.IsViewBtnImage = false;
            this.cdvSamplingType.Location = new System.Drawing.Point(172, 16);
            this.cdvSamplingType.MaxLength = 30;
            this.cdvSamplingType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSamplingType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSamplingType.Name = "cdvSamplingType";
            this.cdvSamplingType.ReadOnly = false;
            this.cdvSamplingType.SearchSubItemIndex = 0;
            this.cdvSamplingType.SelectedDescIndex = -1;
            this.cdvSamplingType.SelectedSubItemIndex = -1;
            this.cdvSamplingType.SelectionStart = 0;
            this.cdvSamplingType.Size = new System.Drawing.Size(200, 20);
            this.cdvSamplingType.SmallImageList = null;
            this.cdvSamplingType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSamplingType.TabIndex = 1;
            this.cdvSamplingType.TextBoxToolTipText = "";
            this.cdvSamplingType.TextBoxWidth = 200;
            this.cdvSamplingType.VisibleButton = true;
            this.cdvSamplingType.VisibleColumnHeader = false;
            this.cdvSamplingType.VisibleDescription = false;
            this.cdvSamplingType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSamplingType_SelectedItemChanged);
            this.cdvSamplingType.ButtonPress += new System.EventHandler(this.cdvSamplingType_ButtonPress);
            this.cdvSamplingType.TextBoxTextChanged += new System.EventHandler(this.cdvSamplingType_TextBoxTextChanged);
            // 
            // lblSamplingType
            // 
            this.lblSamplingType.AutoSize = true;
            this.lblSamplingType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSamplingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamplingType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSamplingType.Location = new System.Drawing.Point(15, 20);
            this.lblSamplingType.Name = "lblSamplingType";
            this.lblSamplingType.Size = new System.Drawing.Size(90, 13);
            this.lblSamplingType.TabIndex = 0;
            this.lblSamplingType.Text = "Sampling Type";
            // 
            // txtDetermineValue
            // 
            this.txtDetermineValue.Enabled = false;
            this.txtDetermineValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetermineValue.Location = new System.Drawing.Point(172, 112);
            this.txtDetermineValue.MaxLength = 11;
            this.txtDetermineValue.Name = "txtDetermineValue";
            this.txtDetermineValue.Size = new System.Drawing.Size(200, 20);
            this.txtDetermineValue.TabIndex = 10;
            this.txtDetermineValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDetermineValue.Visible = false;
            // 
            // lblDetermineValue
            // 
            this.lblDetermineValue.AutoSize = true;
            this.lblDetermineValue.Enabled = false;
            this.lblDetermineValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDetermineValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetermineValue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDetermineValue.Location = new System.Drawing.Point(15, 116);
            this.lblDetermineValue.Name = "lblDetermineValue";
            this.lblDetermineValue.Size = new System.Drawing.Size(85, 13);
            this.lblDetermineValue.TabIndex = 9;
            this.lblDetermineValue.Text = "Determine Value";
            this.lblDetermineValue.Visible = false;
            // 
            // txtSamplingScheme
            // 
            this.txtSamplingScheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSamplingScheme.Location = new System.Drawing.Point(172, 88);
            this.txtSamplingScheme.MaxLength = 30;
            this.txtSamplingScheme.Name = "txtSamplingScheme";
            this.txtSamplingScheme.Size = new System.Drawing.Size(200, 20);
            this.txtSamplingScheme.TabIndex = 8;
            this.txtSamplingScheme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSamplingScheme
            // 
            this.lblSamplingScheme.AutoSize = true;
            this.lblSamplingScheme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSamplingScheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamplingScheme.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSamplingScheme.Location = new System.Drawing.Point(15, 92);
            this.lblSamplingScheme.Name = "lblSamplingScheme";
            this.lblSamplingScheme.Size = new System.Drawing.Size(92, 13);
            this.lblSamplingScheme.TabIndex = 7;
            this.lblSamplingScheme.Text = "Sampling Scheme";
            // 
            // txtSamplingRate
            // 
            this.txtSamplingRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSamplingRate.Location = new System.Drawing.Point(172, 40);
            this.txtSamplingRate.MaxLength = 6;
            this.txtSamplingRate.Name = "txtSamplingRate";
            this.txtSamplingRate.Size = new System.Drawing.Size(200, 20);
            this.txtSamplingRate.TabIndex = 3;
            this.txtSamplingRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSamplingQty
            // 
            this.txtSamplingQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSamplingQty.Location = new System.Drawing.Point(172, 64);
            this.txtSamplingQty.MaxLength = 11;
            this.txtSamplingQty.Name = "txtSamplingQty";
            this.txtSamplingQty.Size = new System.Drawing.Size(200, 20);
            this.txtSamplingQty.TabIndex = 6;
            this.txtSamplingQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboCheckDetermine
            // 
            this.cboCheckDetermine.Enabled = false;
            this.cboCheckDetermine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCheckDetermine.Items.AddRange(new object[] {
            "=",
            "!",
            ">",
            "<",
            ">=",
            "<=",
            "<>"});
            this.cboCheckDetermine.Location = new System.Drawing.Point(172, 136);
            this.cboCheckDetermine.Name = "cboCheckDetermine";
            this.cboCheckDetermine.Size = new System.Drawing.Size(200, 21);
            this.cboCheckDetermine.TabIndex = 12;
            this.cboCheckDetermine.Visible = false;
            // 
            // lblSamplingRate
            // 
            this.lblSamplingRate.AutoSize = true;
            this.lblSamplingRate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSamplingRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamplingRate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSamplingRate.Location = new System.Drawing.Point(15, 42);
            this.lblSamplingRate.Name = "lblSamplingRate";
            this.lblSamplingRate.Size = new System.Drawing.Size(76, 13);
            this.lblSamplingRate.TabIndex = 2;
            this.lblSamplingRate.Text = "Sampling Rate";
            // 
            // lblSamplingCount
            // 
            this.lblSamplingCount.AutoSize = true;
            this.lblSamplingCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSamplingCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamplingCount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSamplingCount.Location = new System.Drawing.Point(15, 68);
            this.lblSamplingCount.Name = "lblSamplingCount";
            this.lblSamplingCount.Size = new System.Drawing.Size(85, 13);
            this.lblSamplingCount.TabIndex = 5;
            this.lblSamplingCount.Text = "Fix Sampling Qty";
            // 
            // lblCheckDetermineFlag
            // 
            this.lblCheckDetermineFlag.AutoSize = true;
            this.lblCheckDetermineFlag.Enabled = false;
            this.lblCheckDetermineFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCheckDetermineFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckDetermineFlag.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCheckDetermineFlag.Location = new System.Drawing.Point(15, 140);
            this.lblCheckDetermineFlag.Name = "lblCheckDetermineFlag";
            this.lblCheckDetermineFlag.Size = new System.Drawing.Size(89, 13);
            this.lblCheckDetermineFlag.TabIndex = 11;
            this.lblCheckDetermineFlag.Text = "Check Determine";
            this.lblCheckDetermineFlag.Visible = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(304, 372);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 18;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(304, 348);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 15;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(124, 372);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 17;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(12, 374);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 16;
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
            this.txtCreateUser.TabIndex = 14;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(12, 350);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 13;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCmf);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(492, 401);
            this.tbpCMF.TabIndex = 1;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.Visible = false;
            // 
            // grpCmf
            // 
            this.grpCmf.Controls.Add(this.cdvCmf10);
            this.grpCmf.Controls.Add(this.lblCMF6);
            this.grpCmf.Controls.Add(this.lblCMF7);
            this.grpCmf.Controls.Add(this.lblCMF5);
            this.grpCmf.Controls.Add(this.lblCMF4);
            this.grpCmf.Controls.Add(this.cdvCmf8);
            this.grpCmf.Controls.Add(this.cdvCmf7);
            this.grpCmf.Controls.Add(this.cdvCmf6);
            this.grpCmf.Controls.Add(this.cdvCmf5);
            this.grpCmf.Controls.Add(this.cdvCmf4);
            this.grpCmf.Controls.Add(this.cdvCmf3);
            this.grpCmf.Controls.Add(this.cdvCmf2);
            this.grpCmf.Controls.Add(this.cdvCmf1);
            this.grpCmf.Controls.Add(this.lblCMF10);
            this.grpCmf.Controls.Add(this.lblCMF9);
            this.grpCmf.Controls.Add(this.lblCMF8);
            this.grpCmf.Controls.Add(this.lblCMF3);
            this.grpCmf.Controls.Add(this.lblCMF2);
            this.grpCmf.Controls.Add(this.lblCMF1);
            this.grpCmf.Controls.Add(this.cdvCmf9);
            this.grpCmf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCmf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCmf.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpCmf.Location = new System.Drawing.Point(3, 0);
            this.grpCmf.Name = "grpCmf";
            this.grpCmf.Size = new System.Drawing.Size(486, 398);
            this.grpCmf.TabIndex = 0;
            this.grpCmf.TabStop = false;
            this.grpCmf.Text = "Customized Field (1~10)";
            // 
            // cdvCmf10
            // 
            this.cdvCmf10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf10.BtnToolTipText = "";
            this.cdvCmf10.DescText = "";
            this.cdvCmf10.DisplaySubItemIndex = -1;
            this.cdvCmf10.DisplayText = "";
            this.cdvCmf10.Focusing = null;
            this.cdvCmf10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf10.Index = 0;
            this.cdvCmf10.IsViewBtnImage = false;
            this.cdvCmf10.Location = new System.Drawing.Point(172, 232);
            this.cdvCmf10.MaxLength = 30;
            this.cdvCmf10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf10.Name = "cdvCmf10";
            this.cdvCmf10.ReadOnly = false;
            this.cdvCmf10.SearchSubItemIndex = 0;
            this.cdvCmf10.SelectedDescIndex = -1;
            this.cdvCmf10.SelectedSubItemIndex = -1;
            this.cdvCmf10.SelectionStart = 0;
            this.cdvCmf10.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf10.SmallImageList = null;
            this.cdvCmf10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf10.TabIndex = 19;
            this.cdvCmf10.TextBoxToolTipText = "";
            this.cdvCmf10.TextBoxWidth = 200;
            this.cdvCmf10.VisibleButton = true;
            this.cdvCmf10.VisibleColumnHeader = false;
            this.cdvCmf10.VisibleDescription = false;
            this.cdvCmf10.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF7.Location = new System.Drawing.Point(15, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(150, 14);
            this.lblCMF7.TabIndex = 12;
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
            // cdvCmf8
            // 
            this.cdvCmf8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf8.BtnToolTipText = "";
            this.cdvCmf8.DescText = "";
            this.cdvCmf8.DisplaySubItemIndex = -1;
            this.cdvCmf8.DisplayText = "";
            this.cdvCmf8.Focusing = null;
            this.cdvCmf8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf8.Index = 0;
            this.cdvCmf8.IsViewBtnImage = false;
            this.cdvCmf8.Location = new System.Drawing.Point(172, 184);
            this.cdvCmf8.MaxLength = 30;
            this.cdvCmf8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf8.Name = "cdvCmf8";
            this.cdvCmf8.ReadOnly = false;
            this.cdvCmf8.SearchSubItemIndex = 0;
            this.cdvCmf8.SelectedDescIndex = -1;
            this.cdvCmf8.SelectedSubItemIndex = -1;
            this.cdvCmf8.SelectionStart = 0;
            this.cdvCmf8.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf8.SmallImageList = null;
            this.cdvCmf8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf8.TabIndex = 15;
            this.cdvCmf8.TextBoxToolTipText = "";
            this.cdvCmf8.TextBoxWidth = 200;
            this.cdvCmf8.VisibleButton = true;
            this.cdvCmf8.VisibleColumnHeader = false;
            this.cdvCmf8.VisibleDescription = false;
            this.cdvCmf8.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCmf7
            // 
            this.cdvCmf7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf7.BtnToolTipText = "";
            this.cdvCmf7.DescText = "";
            this.cdvCmf7.DisplaySubItemIndex = -1;
            this.cdvCmf7.DisplayText = "";
            this.cdvCmf7.Focusing = null;
            this.cdvCmf7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf7.Index = 0;
            this.cdvCmf7.IsViewBtnImage = false;
            this.cdvCmf7.Location = new System.Drawing.Point(172, 160);
            this.cdvCmf7.MaxLength = 30;
            this.cdvCmf7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf7.Name = "cdvCmf7";
            this.cdvCmf7.ReadOnly = false;
            this.cdvCmf7.SearchSubItemIndex = 0;
            this.cdvCmf7.SelectedDescIndex = -1;
            this.cdvCmf7.SelectedSubItemIndex = -1;
            this.cdvCmf7.SelectionStart = 0;
            this.cdvCmf7.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf7.SmallImageList = null;
            this.cdvCmf7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf7.TabIndex = 13;
            this.cdvCmf7.TextBoxToolTipText = "";
            this.cdvCmf7.TextBoxWidth = 200;
            this.cdvCmf7.VisibleButton = true;
            this.cdvCmf7.VisibleColumnHeader = false;
            this.cdvCmf7.VisibleDescription = false;
            this.cdvCmf7.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCmf6
            // 
            this.cdvCmf6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf6.BtnToolTipText = "";
            this.cdvCmf6.DescText = "";
            this.cdvCmf6.DisplaySubItemIndex = -1;
            this.cdvCmf6.DisplayText = "";
            this.cdvCmf6.Focusing = null;
            this.cdvCmf6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf6.Index = 0;
            this.cdvCmf6.IsViewBtnImage = false;
            this.cdvCmf6.Location = new System.Drawing.Point(172, 136);
            this.cdvCmf6.MaxLength = 30;
            this.cdvCmf6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf6.Name = "cdvCmf6";
            this.cdvCmf6.ReadOnly = false;
            this.cdvCmf6.SearchSubItemIndex = 0;
            this.cdvCmf6.SelectedDescIndex = -1;
            this.cdvCmf6.SelectedSubItemIndex = -1;
            this.cdvCmf6.SelectionStart = 0;
            this.cdvCmf6.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf6.SmallImageList = null;
            this.cdvCmf6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf6.TabIndex = 11;
            this.cdvCmf6.TextBoxToolTipText = "";
            this.cdvCmf6.TextBoxWidth = 200;
            this.cdvCmf6.VisibleButton = true;
            this.cdvCmf6.VisibleColumnHeader = false;
            this.cdvCmf6.VisibleDescription = false;
            this.cdvCmf6.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCmf5
            // 
            this.cdvCmf5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf5.BtnToolTipText = "";
            this.cdvCmf5.DescText = "";
            this.cdvCmf5.DisplaySubItemIndex = -1;
            this.cdvCmf5.DisplayText = "";
            this.cdvCmf5.Focusing = null;
            this.cdvCmf5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf5.Index = 0;
            this.cdvCmf5.IsViewBtnImage = false;
            this.cdvCmf5.Location = new System.Drawing.Point(172, 112);
            this.cdvCmf5.MaxLength = 30;
            this.cdvCmf5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf5.Name = "cdvCmf5";
            this.cdvCmf5.ReadOnly = false;
            this.cdvCmf5.SearchSubItemIndex = 0;
            this.cdvCmf5.SelectedDescIndex = -1;
            this.cdvCmf5.SelectedSubItemIndex = -1;
            this.cdvCmf5.SelectionStart = 0;
            this.cdvCmf5.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf5.SmallImageList = null;
            this.cdvCmf5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf5.TabIndex = 9;
            this.cdvCmf5.TextBoxToolTipText = "";
            this.cdvCmf5.TextBoxWidth = 200;
            this.cdvCmf5.VisibleButton = true;
            this.cdvCmf5.VisibleColumnHeader = false;
            this.cdvCmf5.VisibleDescription = false;
            this.cdvCmf5.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCmf4
            // 
            this.cdvCmf4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf4.BtnToolTipText = "";
            this.cdvCmf4.DescText = "";
            this.cdvCmf4.DisplaySubItemIndex = -1;
            this.cdvCmf4.DisplayText = "";
            this.cdvCmf4.Focusing = null;
            this.cdvCmf4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf4.Index = 0;
            this.cdvCmf4.IsViewBtnImage = false;
            this.cdvCmf4.Location = new System.Drawing.Point(172, 88);
            this.cdvCmf4.MaxLength = 30;
            this.cdvCmf4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf4.Name = "cdvCmf4";
            this.cdvCmf4.ReadOnly = false;
            this.cdvCmf4.SearchSubItemIndex = 0;
            this.cdvCmf4.SelectedDescIndex = -1;
            this.cdvCmf4.SelectedSubItemIndex = -1;
            this.cdvCmf4.SelectionStart = 0;
            this.cdvCmf4.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf4.SmallImageList = null;
            this.cdvCmf4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf4.TabIndex = 7;
            this.cdvCmf4.TextBoxToolTipText = "";
            this.cdvCmf4.TextBoxWidth = 200;
            this.cdvCmf4.VisibleButton = true;
            this.cdvCmf4.VisibleColumnHeader = false;
            this.cdvCmf4.VisibleDescription = false;
            this.cdvCmf4.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCmf3
            // 
            this.cdvCmf3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf3.BtnToolTipText = "";
            this.cdvCmf3.DescText = "";
            this.cdvCmf3.DisplaySubItemIndex = -1;
            this.cdvCmf3.DisplayText = "";
            this.cdvCmf3.Focusing = null;
            this.cdvCmf3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf3.Index = 0;
            this.cdvCmf3.IsViewBtnImage = false;
            this.cdvCmf3.Location = new System.Drawing.Point(172, 64);
            this.cdvCmf3.MaxLength = 30;
            this.cdvCmf3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf3.Name = "cdvCmf3";
            this.cdvCmf3.ReadOnly = false;
            this.cdvCmf3.SearchSubItemIndex = 0;
            this.cdvCmf3.SelectedDescIndex = -1;
            this.cdvCmf3.SelectedSubItemIndex = -1;
            this.cdvCmf3.SelectionStart = 0;
            this.cdvCmf3.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf3.SmallImageList = null;
            this.cdvCmf3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf3.TabIndex = 5;
            this.cdvCmf3.TextBoxToolTipText = "";
            this.cdvCmf3.TextBoxWidth = 200;
            this.cdvCmf3.VisibleButton = true;
            this.cdvCmf3.VisibleColumnHeader = false;
            this.cdvCmf3.VisibleDescription = false;
            this.cdvCmf3.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCmf2
            // 
            this.cdvCmf2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf2.BtnToolTipText = "";
            this.cdvCmf2.DescText = "";
            this.cdvCmf2.DisplaySubItemIndex = -1;
            this.cdvCmf2.DisplayText = "";
            this.cdvCmf2.Focusing = null;
            this.cdvCmf2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf2.Index = 0;
            this.cdvCmf2.IsViewBtnImage = false;
            this.cdvCmf2.Location = new System.Drawing.Point(172, 40);
            this.cdvCmf2.MaxLength = 30;
            this.cdvCmf2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf2.Name = "cdvCmf2";
            this.cdvCmf2.ReadOnly = false;
            this.cdvCmf2.SearchSubItemIndex = 0;
            this.cdvCmf2.SelectedDescIndex = -1;
            this.cdvCmf2.SelectedSubItemIndex = -1;
            this.cdvCmf2.SelectionStart = 0;
            this.cdvCmf2.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf2.SmallImageList = null;
            this.cdvCmf2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf2.TabIndex = 3;
            this.cdvCmf2.TextBoxToolTipText = "";
            this.cdvCmf2.TextBoxWidth = 200;
            this.cdvCmf2.VisibleButton = true;
            this.cdvCmf2.VisibleColumnHeader = false;
            this.cdvCmf2.VisibleDescription = false;
            this.cdvCmf2.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // cdvCmf1
            // 
            this.cdvCmf1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf1.BtnToolTipText = "";
            this.cdvCmf1.DescText = "";
            this.cdvCmf1.DisplaySubItemIndex = -1;
            this.cdvCmf1.DisplayText = "";
            this.cdvCmf1.Focusing = null;
            this.cdvCmf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf1.Index = 0;
            this.cdvCmf1.IsViewBtnImage = false;
            this.cdvCmf1.Location = new System.Drawing.Point(172, 16);
            this.cdvCmf1.MaxLength = 30;
            this.cdvCmf1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf1.Name = "cdvCmf1";
            this.cdvCmf1.ReadOnly = false;
            this.cdvCmf1.SearchSubItemIndex = 0;
            this.cdvCmf1.SelectedDescIndex = -1;
            this.cdvCmf1.SelectedSubItemIndex = -1;
            this.cdvCmf1.SelectionStart = 0;
            this.cdvCmf1.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf1.SmallImageList = null;
            this.cdvCmf1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf1.TabIndex = 1;
            this.cdvCmf1.TextBoxToolTipText = "";
            this.cdvCmf1.TextBoxWidth = 200;
            this.cdvCmf1.VisibleButton = true;
            this.cdvCmf1.VisibleColumnHeader = false;
            this.cdvCmf1.VisibleDescription = false;
            this.cdvCmf1.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            // cdvCmf9
            // 
            this.cdvCmf9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCmf9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCmf9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCmf9.BtnToolTipText = "";
            this.cdvCmf9.DescText = "";
            this.cdvCmf9.DisplaySubItemIndex = -1;
            this.cdvCmf9.DisplayText = "";
            this.cdvCmf9.Focusing = null;
            this.cdvCmf9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCmf9.Index = 0;
            this.cdvCmf9.IsViewBtnImage = false;
            this.cdvCmf9.Location = new System.Drawing.Point(172, 208);
            this.cdvCmf9.MaxLength = 30;
            this.cdvCmf9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCmf9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCmf9.Name = "cdvCmf9";
            this.cdvCmf9.ReadOnly = false;
            this.cdvCmf9.SearchSubItemIndex = 0;
            this.cdvCmf9.SelectedDescIndex = -1;
            this.cdvCmf9.SelectedSubItemIndex = -1;
            this.cdvCmf9.SelectionStart = 0;
            this.cdvCmf9.Size = new System.Drawing.Size(200, 20);
            this.cdvCmf9.SmallImageList = null;
            this.cdvCmf9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCmf9.TabIndex = 17;
            this.cdvCmf9.TextBoxToolTipText = "";
            this.cdvCmf9.TextBoxWidth = 200;
            this.cdvCmf9.VisibleButton = true;
            this.cdvCmf9.VisibleColumnHeader = false;
            this.cdvCmf9.VisibleDescription = false;
            this.cdvCmf9.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            this.cdvCmf9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // frmQCMSetupSamplingProcedure
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmQCMSetupSamplingProcedure";
            this.Tag = "QCM1001";
            this.Text = "Sampling Procedure Setup";
            this.Activated += new System.EventHandler(this.frmQCMSetupSamplingProcedure_Activated);
            this.Load += new System.EventHandler(this.frmQCMSetupSamplingProcedure_Load);
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
            this.pnlProctab.ResumeLayout(false);
            this.tabSampling.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSamplingType)).EndInit();
            this.tbpCMF.ResumeLayout(false);
            this.grpCmf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCmf9)).EndInit();
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
                    case "Update_Sampling_Procedure":


                        if (MPCF.CheckValue(txtSampling, 1) == false)
                        {
                            return false;
                        }
                        
                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:
                                
                                if (cdvSamplingType.Text == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    cdvSamplingType.Select();
                                    return false;
                                }

                                //if (MPCF.CheckValue(txtDetermineValue, 2) == false)
                                //{
                                //    return false;
                                //}

                                //if (MPCF.CheckValue(cboCheckDetermine, 1) == false)
                                //{
                                //    return false;
                                //}
                                
                                //CMF Validation Check
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCmf) == false)
                                {
                                    return false;
                                }
                                break;
                                
                                
                            case MPGC.MP_STEP_UPDATE:
                                
                                
                                if (cdvSamplingType.Text == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    cdvSamplingType.Select();
                                    return false;
                                }

                                //if (MPCF.CheckValue(txtDetermineValue, 2) == false)
                                //{
                                //    return false;
                                //}

                                //if (MPCF.CheckValue(cboCheckDetermine, 1) == false)
                                //{
                                //    return false;
                                //}
                                
                                //CMF Validation Check
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCmf) == false)
                                {
                                    return false;
                                }
                                break;
                                
                            case MPGC.MP_STEP_DELETE:
                                
                                return true;
                                
                        }
                        break;
                    case "View_Sampling_Procedure":
                        
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
                    MPCF.FieldClear(this.pnlRight, null, null, null, null, null, false);
                }
                else if (ProcStep == '2')
                {
                    MPCF.ClearList(lisSampling, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //-----------------------------------------------------------------------------
        //
        // View_Sampling_Procedure()
        //       - View Sampling Procedure Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        private bool View_Sampling_Procedure()
        {
            TRSNode in_node = new TRSNode("VIEW_SAMPLING_PROCEDURE_IN");
            TRSNode out_node = new TRSNode("VIEW_SAMPLING_PROCEDURE_OUT");
            
            try
            {
                ClearData('1');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SAMPLE_PROC", lisSampling.SelectedItems[0].Text);

                if (MPCR.CallService("QCM", "QCM_View_Sampling_Procedure", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                //General
                txtSampling.Text = out_node.GetString("SAMPLE_PROC");
                txtDesc.Text = out_node.GetString("SAMPLE_PROC_DESC");

                cdvSamplingType.Text = out_node.GetString("SAMPLE_PROC_TYPE");
                //Modify J.S. Bug Fix GetString -> GetInt
                txtSamplingRate.Text = out_node.GetInt("SAMPLE_RATE").ToString();
                txtSamplingQty.Text = out_node.GetDouble("SAMPLE_QTY").ToString();
                txtSamplingScheme.Text = out_node.GetString("SAMPLE_SCHEME");
                txtDetermineValue.Text = out_node.GetDouble("DETERMINE_VALUE").ToString();
                cboCheckDetermine.Text = out_node.GetString("CHECK_DETERMINE_FLAG");

                //Customized Field
                cdvCmf1.Text = out_node.GetString("PROC_CMF_1");
                cdvCmf2.Text = out_node.GetString("PROC_CMF_2");
                cdvCmf3.Text = out_node.GetString("PROC_CMF_3");
                cdvCmf4.Text = out_node.GetString("PROC_CMF_4");
                cdvCmf5.Text = out_node.GetString("PROC_CMF_5");
                cdvCmf6.Text = out_node.GetString("PROC_CMF_6");
                cdvCmf7.Text = out_node.GetString("PROC_CMF_7");
                cdvCmf8.Text = out_node.GetString("PROC_CMF_8");
                cdvCmf9.Text = out_node.GetString("PROC_CMF_9");
                cdvCmf10.Text = out_node.GetString("PROC_CMF_10");

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
        // Update_Sampling_Procedure()
        //       - Create/Update/Delete Sampling Procedure Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        //-----------------------------------------------------------------------------
        private bool Update_Sampling_Procedure(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_SAMPLING_PROCEDURE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("SAMPLE_PROC", MPCF.Trim(txtSampling.Text));
                in_node.AddString("SAMPLE_PROC_DESC", MPCF.Trim(txtDesc.Text));

                in_node.AddString("SAMPLE_PROC_TYPE", MPCF.Trim(cdvSamplingType.Text));
                in_node.AddDouble("SAMPLE_QTY", MPCF.ToDbl(txtSamplingQty.Text));
                in_node.AddInt("SAMPLE_RATE", MPCF.ToInt(txtSamplingRate.Text));
                in_node.AddString("SAMPLE_SCHEME", MPCF.Trim(txtSamplingScheme.Text));
                in_node.AddDouble("DETERMINE_VALUE", MPCF.ToDbl(txtDetermineValue.Text));
                in_node.AddString("CHECK_DETERMINE_FLAG", MPCF.Trim(cboCheckDetermine.Text));

                in_node.AddString("PROC_CMF_1", MPCF.Trim(cdvCmf1.Text));
                in_node.AddString("PROC_CMF_2", MPCF.Trim(cdvCmf2.Text));
                in_node.AddString("PROC_CMF_3", MPCF.Trim(cdvCmf3.Text));
                in_node.AddString("PROC_CMF_4", MPCF.Trim(cdvCmf4.Text));
                in_node.AddString("PROC_CMF_5", MPCF.Trim(cdvCmf5.Text));
                in_node.AddString("PROC_CMF_6", MPCF.Trim(cdvCmf6.Text));
                in_node.AddString("PROC_CMF_7", MPCF.Trim(cdvCmf7.Text));
                in_node.AddString("PROC_CMF_8", MPCF.Trim(cdvCmf8.Text));
                in_node.AddString("PROC_CMF_9", MPCF.Trim(cdvCmf9.Text));
                in_node.AddString("PROC_CMF_10", MPCF.Trim(cdvCmf10.Text));

                if (MPCR.CallService("QCM", "QCM_Update_Sampling_Procedure", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisSampling.Items.Add(txtSampling.Text, (int)SMALLICON_INDEX.IDX_CHARACTER);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisSampling.Sorting = SortOrder.Ascending;
                        lisSampling.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisSampling, MPCF.Trim(txtSampling.Text), false) == true)
                        {
                            lisSampling.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisSampling, MPCF.Trim(txtSampling.Text), false);
                        if (idx != - 1)
                        {
                            lisSampling.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisSampling.Items.Count.ToString();
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
                return this.lisSampling;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmQCMSetupSamplingProcedure_Load(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmQCMSetupSamplingProcedure_Activated(object sender, System.EventArgs e)
        {
            
            if (bLoadFlag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.InitListView(lisSampling);
                MPCR.SetCMFItem(MPGC.MP_CMF_SMP_PROC, "lblCmf", "cdvCmf", grpCmf);
                
                QCMLIST.ViewSamplingProcedureList(lisSampling, '1', "", null, "");
                if (lisSampling.Items.Count > 0)
                {
                    lisSampling.Items[0].Selected = true;
                }
                lblDataCount.Text = lisSampling.Items.Count.ToString();
                
                bLoadFlag = true;
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (QCMLIST.ViewSamplingProcedureList(lisSampling, '1', "", null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisSampling.Items.Count.ToString();
                if (lisSampling.Items.Count > 0)
                {
                    MPCF.FindListItem(lisSampling, txtSampling.Text, false);
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
                if (CheckCondition("Update_Sampling_Procedure", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Sampling_Procedure(MPGC.MP_STEP_CREATE) == false)
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
                
                if (CheckCondition("Update_Sampling_Procedure", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Sampling_Procedure(MPGC.MP_STEP_UPDATE) == false)
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
                
                if (CheckCondition("Update_Sampling_Procedure", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Sampling_Procedure(MPGC.MP_STEP_DELETE) == false)
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
        
        private void lisSampling_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight, null, null, null, null, null, false);
                
                if (lisSampling.SelectedItems.Count > 0)
                {
                    txtSampling.Text = lisSampling.SelectedItems[0].Text;
                    View_Sampling_Procedure();
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
                MPCF.ExportToExcel(lisSampling, this.Text, "");
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
        
        private void cdvCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemNextPartial(lisSampling, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemPartial(lisSampling, txtFind.Text, 0, true, false);
            
        }
        
        private void cdvSamplingType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            txtSamplingRate.Text = "";
            txtSamplingQty.Text = "";
            txtSamplingScheme.Text = "";
            
        }
        
        private void cdvSamplingType_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            txtSamplingRate.Enabled = false;
            txtSamplingQty.Enabled = false;
            txtSamplingScheme.Enabled = false;
            switch (cdvSamplingType.Text)
            {
                case MPGC.MP_QCM_SMP_TYPE_MANUAL: //Manual
                    
                    break;
                    
                case MPGC.MP_QCM_SMP_TYPE_USED_PERCENTAGE: //Used percentage
                    
                    txtSamplingRate.Enabled = true;
                    break;
                case MPGC.MP_QCM_SMP_TYPE_FIXED_SAMPLE: //Fixed Sample
                    
                    txtSamplingQty.Enabled = true;
                    break;
                case MPGC.MP_QCM_SMP_TYPE_TOTAL_INSPECTION: //Total Inspection
                    
                    txtSamplingRate.Text = "100";
                    break;
                case MPGC.MP_QCM_SMP_TYPE_USED_SCHEME: //Used Scheme
                    
                    txtSamplingScheme.Enabled = true;
                    break;
            }
        }
        
        private void cdvSamplingType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvSamplingType.Init();
            MPCF.InitListView(cdvSamplingType.GetListView);
            cdvSamplingType.Columns.Add("Sampling Type", 100, HorizontalAlignment.Left);
            cdvSamplingType.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvSamplingType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvSamplingType.GetListView, '1', MPGC.MP_QCM_SMP_PROC_TYPE);
        }
        
    }
    //#End If
}
