
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
//   File Name   : frmQCMSetupInspectionItem.vb
//   Description : Inspection Item Definition Form
//
//   MES Version : 1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Inspection_Item() : View Inspection Item definition
//       - Update_Inspection_Item() : Create/Update/Delete Inspection Item definition
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
    public class frmQCMSetupInspectionItem : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMSetupInspectionItem()
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
        private Miracom.UI.Controls.MCListView.MCListView lisInspItem;
        private System.Windows.Forms.ColumnHeader colInspItem;
        private System.Windows.Forms.ColumnHeader colInspItemDesc;
        private System.Windows.Forms.GroupBox grpLabel;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtInspItem;
        private System.Windows.Forms.Label lblInspItem;
        private System.Windows.Forms.TabControl tabSampling;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.CheckBox chkNoResultValue;
        private System.Windows.Forms.CheckBox chkInactive;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvDefectGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSamplingProc;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspMethod;
        private System.Windows.Forms.Label lblDefectGroup;
        private System.Windows.Forms.Label lblInspMethod;
        private System.Windows.Forms.Label lblSamplingProc;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.GroupBox grpCmf;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf10;
        private System.Windows.Forms.Label lblCMF6;
        private System.Windows.Forms.Label lblCMF7;
        private System.Windows.Forms.Label lblCMF5;
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
        private System.Windows.Forms.Panel pnlInspItemtab;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.lisInspItem = new Miracom.UI.Controls.MCListView.MCListView();
            this.colInspItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInspItemDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpLabel = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtInspItem = new System.Windows.Forms.TextBox();
            this.lblInspItem = new System.Windows.Forms.Label();
            this.pnlInspItemtab = new System.Windows.Forms.Panel();
            this.tabSampling = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNoResultValue = new System.Windows.Forms.CheckBox();
            this.chkInactive = new System.Windows.Forms.CheckBox();
            this.cdvDefectGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvSamplingProc = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvInspMethod = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDefectGroup = new System.Windows.Forms.Label();
            this.lblInspMethod = new System.Windows.Forms.Label();
            this.lblSamplingProc = new System.Windows.Forms.Label();
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
            this.pnlInspItemtab.SuspendLayout();
            this.tabSampling.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefectGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSamplingProc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspMethod)).BeginInit();
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
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlInspItemtab);
            this.pnlRight.Controls.Add(this.grpLabel);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisInspItem);
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
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "SetupForm02";
            // 
            // lisInspItem
            // 
            this.lisInspItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInspItem,
            this.colInspItemDesc});
            this.lisInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisInspItem.EnableSort = true;
            this.lisInspItem.EnableSortIcon = true;
            this.lisInspItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisInspItem.FullRowSelect = true;
            this.lisInspItem.Location = new System.Drawing.Point(3, 3);
            this.lisInspItem.MultiSelect = false;
            this.lisInspItem.Name = "lisInspItem";
            this.lisInspItem.Size = new System.Drawing.Size(229, 507);
            this.lisInspItem.TabIndex = 0;
            this.lisInspItem.UseCompatibleStateImageBehavior = false;
            this.lisInspItem.View = System.Windows.Forms.View.Details;
            this.lisInspItem.SelectedIndexChanged += new System.EventHandler(this.lisInspItem_SelectedIndexChanged);
            // 
            // colInspItem
            // 
            this.colInspItem.Text = "Inspection Item";
            this.colInspItem.Width = 100;
            // 
            // colInspItemDesc
            // 
            this.colInspItemDesc.Text = "Description";
            this.colInspItemDesc.Width = 300;
            // 
            // grpLabel
            // 
            this.grpLabel.Controls.Add(this.txtDesc);
            this.grpLabel.Controls.Add(this.Label6);
            this.grpLabel.Controls.Add(this.txtInspItem);
            this.grpLabel.Controls.Add(this.lblInspItem);
            this.grpLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLabel.Location = new System.Drawing.Point(0, 0);
            this.grpLabel.Name = "grpLabel";
            this.grpLabel.Size = new System.Drawing.Size(506, 71);
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
            // txtInspItem
            // 
            this.txtInspItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInspItem.Location = new System.Drawing.Point(135, 16);
            this.txtInspItem.MaxLength = 25;
            this.txtInspItem.Name = "txtInspItem";
            this.txtInspItem.Size = new System.Drawing.Size(173, 20);
            this.txtInspItem.TabIndex = 1;
            // 
            // lblInspItem
            // 
            this.lblInspItem.AutoSize = true;
            this.lblInspItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspItem.Location = new System.Drawing.Point(15, 19);
            this.lblInspItem.Name = "lblInspItem";
            this.lblInspItem.Size = new System.Drawing.Size(94, 13);
            this.lblInspItem.TabIndex = 0;
            this.lblInspItem.Text = "Inspection Item";
            this.lblInspItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlInspItemtab
            // 
            this.pnlInspItemtab.Controls.Add(this.tabSampling);
            this.pnlInspItemtab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspItemtab.Location = new System.Drawing.Point(0, 71);
            this.pnlInspItemtab.Name = "pnlInspItemtab";
            this.pnlInspItemtab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlInspItemtab.Size = new System.Drawing.Size(506, 442);
            this.pnlInspItemtab.TabIndex = 1;
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
            this.tabSampling.Size = new System.Drawing.Size(506, 437);
            this.tabSampling.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.GroupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(498, 411);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // GroupBox1
            // 
            this.GroupBox1.AutoSize = true;
            this.GroupBox1.Controls.Add(this.chkNoResultValue);
            this.GroupBox1.Controls.Add(this.chkInactive);
            this.GroupBox1.Controls.Add(this.cdvDefectGroup);
            this.GroupBox1.Controls.Add(this.cdvSamplingProc);
            this.GroupBox1.Controls.Add(this.cdvInspMethod);
            this.GroupBox1.Controls.Add(this.lblDefectGroup);
            this.GroupBox1.Controls.Add(this.lblInspMethod);
            this.GroupBox1.Controls.Add(this.lblSamplingProc);
            this.GroupBox1.Controls.Add(this.txtUpdateTime);
            this.GroupBox1.Controls.Add(this.txtCreateTime);
            this.GroupBox1.Controls.Add(this.txtUpdateUser);
            this.GroupBox1.Controls.Add(this.lblUpdate);
            this.GroupBox1.Controls.Add(this.txtCreateUser);
            this.GroupBox1.Controls.Add(this.lblCreate);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(3, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(492, 408);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            // 
            // chkNoResultValue
            // 
            this.chkNoResultValue.AutoSize = true;
            this.chkNoResultValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkNoResultValue.Location = new System.Drawing.Point(15, 114);
            this.chkNoResultValue.Name = "chkNoResultValue";
            this.chkNoResultValue.Size = new System.Drawing.Size(109, 18);
            this.chkNoResultValue.TabIndex = 7;
            this.chkNoResultValue.Text = "No Result Value";
            // 
            // chkInactive
            // 
            this.chkInactive.AutoSize = true;
            this.chkInactive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInactive.Location = new System.Drawing.Point(15, 18);
            this.chkInactive.Name = "chkInactive";
            this.chkInactive.Size = new System.Drawing.Size(70, 18);
            this.chkInactive.TabIndex = 0;
            this.chkInactive.Text = "Inactive";
            // 
            // cdvDefectGroup
            // 
            this.cdvDefectGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDefectGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDefectGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvDefectGroup.BtnToolTipText = "";
            this.cdvDefectGroup.DescText = "";
            this.cdvDefectGroup.DisplaySubItemIndex = -1;
            this.cdvDefectGroup.DisplayText = "";
            this.cdvDefectGroup.Focusing = null;
            this.cdvDefectGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDefectGroup.Index = 0;
            this.cdvDefectGroup.IsViewBtnImage = false;
            this.cdvDefectGroup.Location = new System.Drawing.Point(172, 89);
            this.cdvDefectGroup.MaxLength = 30;
            this.cdvDefectGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvDefectGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvDefectGroup.Name = "cdvDefectGroup";
            this.cdvDefectGroup.ReadOnly = false;
            this.cdvDefectGroup.SearchSubItemIndex = 0;
            this.cdvDefectGroup.SelectedDescIndex = -1;
            this.cdvDefectGroup.SelectedSubItemIndex = -1;
            this.cdvDefectGroup.SelectionStart = 0;
            this.cdvDefectGroup.Size = new System.Drawing.Size(200, 20);
            this.cdvDefectGroup.SmallImageList = null;
            this.cdvDefectGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvDefectGroup.TabIndex = 6;
            this.cdvDefectGroup.TextBoxToolTipText = "";
            this.cdvDefectGroup.TextBoxWidth = 200;
            this.cdvDefectGroup.VisibleButton = true;
            this.cdvDefectGroup.VisibleColumnHeader = false;
            this.cdvDefectGroup.VisibleDescription = false;
            this.cdvDefectGroup.ButtonPress += new System.EventHandler(this.cdvDefectGroup_ButtonPress);
            // 
            // cdvSamplingProc
            // 
            this.cdvSamplingProc.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSamplingProc.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSamplingProc.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSamplingProc.BtnToolTipText = "";
            this.cdvSamplingProc.DescText = "";
            this.cdvSamplingProc.DisplaySubItemIndex = -1;
            this.cdvSamplingProc.DisplayText = "";
            this.cdvSamplingProc.Focusing = null;
            this.cdvSamplingProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSamplingProc.Index = 0;
            this.cdvSamplingProc.IsViewBtnImage = false;
            this.cdvSamplingProc.Location = new System.Drawing.Point(172, 65);
            this.cdvSamplingProc.MaxLength = 30;
            this.cdvSamplingProc.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSamplingProc.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSamplingProc.Name = "cdvSamplingProc";
            this.cdvSamplingProc.ReadOnly = false;
            this.cdvSamplingProc.SearchSubItemIndex = 0;
            this.cdvSamplingProc.SelectedDescIndex = -1;
            this.cdvSamplingProc.SelectedSubItemIndex = -1;
            this.cdvSamplingProc.SelectionStart = 0;
            this.cdvSamplingProc.Size = new System.Drawing.Size(200, 20);
            this.cdvSamplingProc.SmallImageList = null;
            this.cdvSamplingProc.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSamplingProc.TabIndex = 4;
            this.cdvSamplingProc.TextBoxToolTipText = "";
            this.cdvSamplingProc.TextBoxWidth = 200;
            this.cdvSamplingProc.VisibleButton = true;
            this.cdvSamplingProc.VisibleColumnHeader = false;
            this.cdvSamplingProc.VisibleDescription = false;
            this.cdvSamplingProc.ButtonPress += new System.EventHandler(this.cdvSamplingProc_ButtonPress);
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
            this.cdvInspMethod.Location = new System.Drawing.Point(172, 41);
            this.cdvInspMethod.MaxLength = 30;
            this.cdvInspMethod.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspMethod.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspMethod.Name = "cdvInspMethod";
            this.cdvInspMethod.ReadOnly = false;
            this.cdvInspMethod.SearchSubItemIndex = 0;
            this.cdvInspMethod.SelectedDescIndex = -1;
            this.cdvInspMethod.SelectedSubItemIndex = -1;
            this.cdvInspMethod.SelectionStart = 0;
            this.cdvInspMethod.Size = new System.Drawing.Size(200, 20);
            this.cdvInspMethod.SmallImageList = null;
            this.cdvInspMethod.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspMethod.TabIndex = 2;
            this.cdvInspMethod.TextBoxToolTipText = "";
            this.cdvInspMethod.TextBoxWidth = 200;
            this.cdvInspMethod.VisibleButton = true;
            this.cdvInspMethod.VisibleColumnHeader = false;
            this.cdvInspMethod.VisibleDescription = false;
            this.cdvInspMethod.ButtonPress += new System.EventHandler(this.cdvInspMethod_ButtonPress);
            // 
            // lblDefectGroup
            // 
            this.lblDefectGroup.AutoSize = true;
            this.lblDefectGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDefectGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefectGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDefectGroup.Location = new System.Drawing.Point(15, 92);
            this.lblDefectGroup.Name = "lblDefectGroup";
            this.lblDefectGroup.Size = new System.Drawing.Size(83, 13);
            this.lblDefectGroup.TabIndex = 5;
            this.lblDefectGroup.Text = "Defect Group";
            // 
            // lblInspMethod
            // 
            this.lblInspMethod.AutoSize = true;
            this.lblInspMethod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspMethod.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblInspMethod.Location = new System.Drawing.Point(15, 44);
            this.lblInspMethod.Name = "lblInspMethod";
            this.lblInspMethod.Size = new System.Drawing.Size(112, 13);
            this.lblInspMethod.TabIndex = 1;
            this.lblInspMethod.Text = "Inspection Method";
            // 
            // lblSamplingProc
            // 
            this.lblSamplingProc.AutoSize = true;
            this.lblSamplingProc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSamplingProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSamplingProc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSamplingProc.Location = new System.Drawing.Point(15, 68);
            this.lblSamplingProc.Name = "lblSamplingProc";
            this.lblSamplingProc.Size = new System.Drawing.Size(120, 13);
            this.lblSamplingProc.TabIndex = 3;
            this.lblSamplingProc.Text = "Sampling Procedure";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(304, 372);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 13;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(304, 348);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 10;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(124, 372);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 12;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(12, 374);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 11;
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
            this.txtCreateUser.TabIndex = 9;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(12, 350);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 8;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCmf);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(498, 411);
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
            this.grpCmf.Size = new System.Drawing.Size(492, 408);
            this.grpCmf.TabIndex = 1;
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
            this.cdvCmf10.TabIndex = 26;
            this.cdvCmf10.TextBoxToolTipText = "";
            this.cdvCmf10.TextBoxWidth = 200;
            this.cdvCmf10.VisibleButton = true;
            this.cdvCmf10.VisibleColumnHeader = false;
            this.cdvCmf10.VisibleDescription = false;
            this.cdvCmf10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // lblCMF6
            // 
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF6.Location = new System.Drawing.Point(15, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(150, 14);
            this.lblCMF6.TabIndex = 24;
            // 
            // lblCMF7
            // 
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF7.Location = new System.Drawing.Point(15, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(150, 14);
            this.lblCMF7.TabIndex = 22;
            // 
            // lblCMF5
            // 
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF5.Location = new System.Drawing.Point(15, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(150, 14);
            this.lblCMF5.TabIndex = 20;
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
            this.cdvCmf9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            // 
            // frmQCMSetupInspectionItem
            // 
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmQCMSetupInspectionItem";
            this.Text = "Inspection Item Setup";
            this.Activated += new System.EventHandler(this.frmQCMSetupInspectionItem_Activated);
            this.Load += new System.EventHandler(this.frmQCMSetupInspectionItem_Load);
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
            this.pnlInspItemtab.ResumeLayout(false);
            this.tabSampling.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.tbpGeneral.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDefectGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSamplingProc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspMethod)).EndInit();
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
                //returnValue = false;
                
                switch (FuncName)
                {
                    case "Update_Inspection_Item":


                        if (MPCF.CheckValue(txtInspItem, 1) == false)
                        {
                            return false;
                        }
                        
                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:

                                if (MPCF.CheckValue(cdvSamplingProc, 1) == false)
                                {
                                    return false;
                                }

                                if (MPCF.CheckValue(cdvInspMethod, 1) == false)
                                {
                                    return false;
                                }

                                if (MPCF.CheckValue(cdvDefectGroup, 1) == false)
                                {
                                    return false;
                                }
                                
                                //CMF Validation Check
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCmf) == false)
                                {
                                    return false;
                                }
                                break;
                                
                                
                            case MPGC.MP_STEP_UPDATE:


                                if (MPCF.CheckValue(cdvSamplingProc, 1) == false)
                                {
                                    return false;
                                }

                                if (MPCF.CheckValue(cdvInspMethod, 1) == false)
                                {
                                    return false;
                                }

                                if (MPCF.CheckValue(cdvDefectGroup, 1) == false)
                                {
                                    return false;
                                }
                                
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
                    case "View_Inspection_Item":
                        
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
                    MPCF.ClearList(lisInspItem, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //-----------------------------------------------------------------------------
        //
        // View_Inspection_Item()
        //       - View Inspection Item Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        private bool View_Inspection_Item()
        {
            TRSNode in_node = new TRSNode("VIEW_INSPECTION_ITEM_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_ITEM_OUT");
            
            try
            {
                ClearData('1');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INSP_ITEM", lisInspItem.SelectedItems[0].Text);

                if (MPCR.CallService("QCM", "QCM_View_Inspection_Item", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                //General            
                txtInspItem.Text = out_node.GetString("INSP_ITEM");
                txtDesc.Text = out_node.GetString("INSP_ITEM_DESC");

                chkInactive.Checked = (out_node.GetChar("ACTIVE_FLAG") == 'Y') ? false : true;
                cdvInspMethod.Text = out_node.GetString("INSP_METHOD");
                cdvSamplingProc.Text = out_node.GetString("SAMPLE_PROC");
                cdvDefectGroup.Text = out_node.GetString("DEFECT_GROUP");
                chkNoResultValue.Checked = (out_node.GetChar("VALUE_FLAG") == 'Y') ? false : true;

                //Customized Field
                cdvCmf1.Text = out_node.GetString("ITEM_CMF_1");
                cdvCmf2.Text = out_node.GetString("ITEM_CMF_2");
                cdvCmf3.Text = out_node.GetString("ITEM_CMF_3");
                cdvCmf4.Text = out_node.GetString("ITEM_CMF_4");
                cdvCmf5.Text = out_node.GetString("ITEM_CMF_5");
                cdvCmf6.Text = out_node.GetString("ITEM_CMF_6");
                cdvCmf7.Text = out_node.GetString("ITEM_CMF_7");
                cdvCmf8.Text = out_node.GetString("ITEM_CMF_8");
                cdvCmf9.Text = out_node.GetString("ITEM_CMF_9");
                cdvCmf10.Text = out_node.GetString("ITEM_CMF_10");

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
        // Update_Inspection_Item()
        //       - Create/Update/Delete Inspection Item Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        //-----------------------------------------------------------------------------
        private bool Update_Inspection_Item(char ProcStep)
        {
            
            //int i;
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_INSPECTION_ITEM_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("INSP_ITEM", MPCF.Trim(txtInspItem.Text));
                in_node.AddString("INSP_ITEM_DESC", MPCF.Trim(txtDesc.Text));

                in_node.AddChar("ACTIVE_FLAG", (chkInactive.Checked ? 'N' : 'Y'));
                in_node.AddString("SAMPLE_PROC", MPCF.Trim(cdvSamplingProc.Text));
                in_node.AddString("DEFECT_GROUP", MPCF.Trim(cdvDefectGroup.Text));
                in_node.AddString("INSP_METHOD", MPCF.Trim(cdvInspMethod.Text));
                in_node.AddChar("VALUE_FLAG", (chkNoResultValue.Checked ? 'N' : 'Y'));

                in_node.AddString("ITEM_CMF_1", MPCF.Trim(cdvCmf1.Text));
                in_node.AddString("ITEM_CMF_2", MPCF.Trim(cdvCmf2.Text));
                in_node.AddString("ITEM_CMF_3", MPCF.Trim(cdvCmf3.Text));
                in_node.AddString("ITEM_CMF_4", MPCF.Trim(cdvCmf4.Text));
                in_node.AddString("ITEM_CMF_5", MPCF.Trim(cdvCmf5.Text));
                in_node.AddString("ITEM_CMF_6", MPCF.Trim(cdvCmf6.Text));
                in_node.AddString("ITEM_CMF_7", MPCF.Trim(cdvCmf7.Text));
                in_node.AddString("ITEM_CMF_8", MPCF.Trim(cdvCmf8.Text));
                in_node.AddString("ITEM_CMF_9", MPCF.Trim(cdvCmf9.Text));
                in_node.AddString("ITEM_CMF_10", MPCF.Trim(cdvCmf10.Text));

                if (MPCR.CallService("QCM", "QCM_Update_Inspection_Item", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisInspItem.Items.Add(txtInspItem.Text, (int)SMALLICON_INDEX.IDX_CHARACTER);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisInspItem.Sorting = SortOrder.Ascending;
                        lisInspItem.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisInspItem, MPCF.Trim(txtInspItem.Text), false) == true)
                        {
                            lisInspItem.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisInspItem, MPCF.Trim(txtInspItem.Text), false);
                        if (idx != - 1)
                        {
                            lisInspItem.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisInspItem.Items.Count.ToString();
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
                return this.lisInspItem;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmQCMSetupInspectionItem_Load(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmQCMSetupInspectionItem_Activated(object sender, System.EventArgs e)
        {
            
            if (bLoadFlag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.InitListView(lisInspItem);
                MPCR.SetCMFItem(MPGC.MP_CMF_INSP_ITEM, "lblCmf", "cdvCmf", grpCmf);
                
                QCMLIST.ViewInspectionItemList(lisInspItem, '1', "", null, "");
                if (lisInspItem.Items.Count > 0)
                {
                    lisInspItem.Items[0].Selected = true;
                }
                lblDataCount.Text =  lisInspItem.Items.Count.ToString();
                
                bLoadFlag = true;
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (QCMLIST.ViewInspectionItemList(lisInspItem, '1', "", null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisInspItem.Items.Count.ToString();
                if (lisInspItem.Items.Count > 0)
                {
                    MPCF.FindListItem(lisInspItem, txtInspItem.Text, false);
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
                if (CheckCondition("Update_Inspection_Item", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Inspection_Item(MPGC.MP_STEP_CREATE) == false)
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
                
                if (CheckCondition("Update_Inspection_Item", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Inspection_Item(MPGC.MP_STEP_UPDATE) == false)
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
                
                if (CheckCondition("Update_Inspection_Item", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Inspection_Item(MPGC.MP_STEP_DELETE) == false)
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
        
        private void lisInspItem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight, null, null, null, null, null, false);
                
                if (lisInspItem.SelectedItems.Count > 0)
                {
                    txtInspItem.Text = lisInspItem.SelectedItems[0].Text;
                    View_Inspection_Item();
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
                MPCF.ExportToExcel(lisInspItem, this.Text, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCMF_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
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
            
            MPCF.FindListItemNextPartial(lisInspItem, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemPartial(lisInspItem, txtFind.Text, 0, true, false);
            
        }
        
        private void cdvInspMethod_ButtonPress(object sender, System.EventArgs e)
        {
            cdvInspMethod.Init();
            MPCF.InitListView(cdvInspMethod.GetListView);
            cdvInspMethod.Columns.Add("Inspection Method", 100, HorizontalAlignment.Left);
            cdvInspMethod.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvInspMethod.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvInspMethod.GetListView, '1', MPGC.MP_QCM_INSP_METHOD);
        }
        
        private void cdvDefectGroup_ButtonPress(object sender, System.EventArgs e)
        {
            cdvDefectGroup.Init();
            MPCF.InitListView(cdvDefectGroup.GetListView);
            cdvDefectGroup.Columns.Add("Defect Group", 100, HorizontalAlignment.Left);
            cdvDefectGroup.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvDefectGroup.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvDefectGroup.GetListView, '1', MPGC.MP_QCM_DEFECT_GRP);
        }
        
        private void cdvSamplingProc_ButtonPress(object sender, System.EventArgs e)
        {
            
            cdvSamplingProc.Init();
            MPCF.InitListView(cdvSamplingProc.GetListView);
            cdvSamplingProc.Columns.Add("Sampling Proc", 100, HorizontalAlignment.Left);
            cdvSamplingProc.Columns.Add("Desc", 300, HorizontalAlignment.Left);
            cdvSamplingProc.SelectedSubItemIndex = 0;
            QCMLIST.ViewSamplingProcedureList(cdvSamplingProc.GetListView, '1', "", null, "");
            
        }
        
    }
    //#End If
}
