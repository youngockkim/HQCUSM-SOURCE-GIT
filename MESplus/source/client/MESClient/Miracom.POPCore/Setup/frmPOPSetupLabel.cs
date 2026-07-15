
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
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmPOPSetupLabel.vb
//   Description : Label Definition Form
//
//   MES Version : 1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Label() : View Label definition
//       - Update_Label() : Create/Update/Delete Label definition
//       - initCodeView() :   initial CodeView Control
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-04-27 : Created by HS Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _POP = True Then

namespace Miracom.POPCore
{
    public class frmPOPSetupLabel : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmPOPSetupLabel()
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
        



        private System.Windows.Forms.GroupBox grpLabel;
        private System.Windows.Forms.Panel pnlLabelInfo;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TabControl tabLabel;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.GroupBox grpCmf;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCmf10;
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
        private Miracom.UI.Controls.MCListView.MCListView lisLabel;
        private System.Windows.Forms.ColumnHeader colMaterial;
        private System.Windows.Forms.ColumnHeader colMatDesc;
        private System.Windows.Forms.GroupBox grpCopyTable;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblToLabel;
        private System.Windows.Forms.TextBox txtToLabel;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.TabPage tbpCopy;
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.GroupBox grbPage;
        private System.Windows.Forms.Label lblPageHeight;
        private System.Windows.Forms.TextBox txtPageHeight;
        private System.Windows.Forms.Label lblPageWidth;
        private System.Windows.Forms.TextBox txtPageWidth;
        private System.Windows.Forms.Panel pnlLabel;
        private System.Windows.Forms.GroupBox grpLabelSize;
        private System.Windows.Forms.Label lblLabelHeight;
        private System.Windows.Forms.TextBox txtLabelHeight;
        private System.Windows.Forms.Label lblLabelWidth;
        private System.Windows.Forms.TextBox txtLabelWidth;
        private System.Windows.Forms.GroupBox grbMargin;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.GroupBox grbType;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.NumericUpDown nudOriginY;
        private System.Windows.Forms.NumericUpDown nudOriginX;
        private System.Windows.Forms.Label lblOriginX;
        private System.Windows.Forms.Label lblOriginY;
        private System.Windows.Forms.NumericUpDown nudDarkness;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.ComboBox cboInvert;
        private System.Windows.Forms.TextBox txtPrintQty;
        private System.Windows.Forms.ComboBox cboReverse;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label lblSpeed;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResolution;
        private System.Windows.Forms.Label lblResolution;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPrinterType;
        private System.Windows.Forms.Label lblPrinterType;
        private System.Windows.Forms.RadioButton rbnPortrait;
        private System.Windows.Forms.RadioButton rbnLandscape;
        private System.Windows.Forms.PictureBox picPortrait;
        private System.Windows.Forms.PictureBox picLandscape;
        private System.Windows.Forms.Label lblCMF6;
        private System.Windows.Forms.Label lblCMF5;
        private System.Windows.Forms.Label lblCMF4;
        private System.Windows.Forms.Label lblCMF7;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOPSetupLabel));
            this.grpLabel = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.pnlLabelInfo = new System.Windows.Forms.Panel();
            this.tabLabel = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.nudOriginY = new System.Windows.Forms.NumericUpDown();
            this.nudOriginX = new System.Windows.Forms.NumericUpDown();
            this.lblOriginX = new System.Windows.Forms.Label();
            this.lblOriginY = new System.Windows.Forms.Label();
            this.nudDarkness = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboInvert = new System.Windows.Forms.ComboBox();
            this.txtPrintQty = new System.Windows.Forms.TextBox();
            this.cboReverse = new System.Windows.Forms.ComboBox();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.cdvResolution = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResolution = new System.Windows.Forms.Label();
            this.cdvPrinterType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPrinterType = new System.Windows.Forms.Label();
            this.pnlLabel = new System.Windows.Forms.Panel();
            this.grbMargin = new System.Windows.Forms.GroupBox();
            this.lblLeft = new System.Windows.Forms.Label();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.lblTop = new System.Windows.Forms.Label();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.grpLabelSize = new System.Windows.Forms.GroupBox();
            this.lblLabelHeight = new System.Windows.Forms.Label();
            this.txtLabelHeight = new System.Windows.Forms.TextBox();
            this.lblLabelWidth = new System.Windows.Forms.Label();
            this.txtLabelWidth = new System.Windows.Forms.TextBox();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.grbType = new System.Windows.Forms.GroupBox();
            this.picLandscape = new System.Windows.Forms.PictureBox();
            this.picPortrait = new System.Windows.Forms.PictureBox();
            this.rbnLandscape = new System.Windows.Forms.RadioButton();
            this.rbnPortrait = new System.Windows.Forms.RadioButton();
            this.grbPage = new System.Windows.Forms.GroupBox();
            this.lblPageHeight = new System.Windows.Forms.Label();
            this.txtPageHeight = new System.Windows.Forms.TextBox();
            this.lblPageWidth = new System.Windows.Forms.Label();
            this.txtPageWidth = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCmf = new System.Windows.Forms.GroupBox();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.cdvCmf10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
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
            this.tbpCopy = new System.Windows.Forms.TabPage();
            this.grpCopyTable = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblToLabel = new System.Windows.Forms.Label();
            this.txtToLabel = new System.Windows.Forms.TextBox();
            this.lisLabel = new Miracom.UI.Controls.MCListView.MCListView();
            this.colMaterial = new System.Windows.Forms.ColumnHeader();
            this.colMatDesc = new System.Windows.Forms.ColumnHeader();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpLabel.SuspendLayout();
            this.pnlLabelInfo.SuspendLayout();
            this.tabLabel.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOriginY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOriginX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDarkness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrinterType)).BeginInit();
            this.pnlLabel.SuspendLayout();
            this.grbMargin.SuspendLayout();
            this.grpLabelSize.SuspendLayout();
            this.pnlPage.SuspendLayout();
            this.grbType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLandscape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPortrait)).BeginInit();
            this.grbPage.SuspendLayout();
            this.GroupBox1.SuspendLayout();
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
            this.tbpCopy.SuspendLayout();
            this.grpCopyTable.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.pnlLabelInfo);
            this.pnlRight.Controls.Add(this.grpLabel);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisLabel);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            this.pnlLeft.TabIndex = 0;
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
            this.pnlBottom.TabIndex = 3;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Label Setup";
            // 
            // grpLabel
            // 
            this.grpLabel.Controls.Add(this.txtDesc);
            this.grpLabel.Controls.Add(this.Label6);
            this.grpLabel.Controls.Add(this.txtLabel);
            this.grpLabel.Controls.Add(this.lblLabel);
            this.grpLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLabel.Location = new System.Drawing.Point(0, 3);
            this.grpLabel.Name = "grpLabel";
            this.grpLabel.Size = new System.Drawing.Size(503, 71);
            this.grpLabel.TabIndex = 0;
            this.grpLabel.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(368, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // Label6
            // 
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(16, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(100, 14);
            this.Label6.TabIndex = 2;
            this.Label6.Text = "Description";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLabel
            // 
            this.txtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabel.Location = new System.Drawing.Point(120, 16);
            this.txtLabel.MaxLength = 25;
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(200, 20);
            this.txtLabel.TabIndex = 1;
            // 
            // lblLabel
            // 
            this.lblLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabel.Location = new System.Drawing.Point(15, 19);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(100, 14);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Label";
            this.lblLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlLabelInfo
            // 
            this.pnlLabelInfo.Controls.Add(this.tabLabel);
            this.pnlLabelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLabelInfo.Location = new System.Drawing.Point(0, 74);
            this.pnlLabelInfo.Name = "pnlLabelInfo";
            this.pnlLabelInfo.Size = new System.Drawing.Size(503, 436);
            this.pnlLabelInfo.TabIndex = 1;
            // 
            // tabLabel
            // 
            this.tabLabel.Controls.Add(this.tbpGeneral);
            this.tabLabel.Controls.Add(this.tbpCMF);
            this.tabLabel.Controls.Add(this.tbpCopy);
            this.tabLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tabLabel.ItemSize = new System.Drawing.Size(60, 18);
            this.tabLabel.Location = new System.Drawing.Point(0, 0);
            this.tabLabel.Name = "tabLabel";
            this.tabLabel.SelectedIndex = 0;
            this.tabLabel.Size = new System.Drawing.Size(503, 436);
            this.tabLabel.TabIndex = 1;
            this.tabLabel.SelectedIndexChanged += new System.EventHandler(this.tabLabel_SelectedIndexChanged);
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.GroupBox3);
            this.tbpGeneral.Controls.Add(this.pnlLabel);
            this.tbpGeneral.Controls.Add(this.pnlPage);
            this.tbpGeneral.Controls.Add(this.GroupBox1);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(495, 410);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.nudOriginY);
            this.GroupBox3.Controls.Add(this.nudOriginX);
            this.GroupBox3.Controls.Add(this.lblOriginX);
            this.GroupBox3.Controls.Add(this.lblOriginY);
            this.GroupBox3.Controls.Add(this.nudDarkness);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Controls.Add(this.cboInvert);
            this.GroupBox3.Controls.Add(this.txtPrintQty);
            this.GroupBox3.Controls.Add(this.cboReverse);
            this.GroupBox3.Controls.Add(this.nudSpeed);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Controls.Add(this.Label2);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Controls.Add(this.lblSpeed);
            this.GroupBox3.Controls.Add(this.cdvResolution);
            this.GroupBox3.Controls.Add(this.lblResolution);
            this.GroupBox3.Controls.Add(this.cdvPrinterType);
            this.GroupBox3.Controls.Add(this.lblPrinterType);
            this.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(3, 140);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(489, 196);
            this.GroupBox3.TabIndex = 4;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Print";
            // 
            // nudOriginY
            // 
            this.nudOriginY.DecimalPlaces = 1;
            this.nudOriginY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nudOriginY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudOriginY.Location = new System.Drawing.Point(360, 15);
            this.nudOriginY.Name = "nudOriginY";
            this.nudOriginY.Size = new System.Drawing.Size(121, 20);
            this.nudOriginY.TabIndex = 3;
            // 
            // nudOriginX
            // 
            this.nudOriginX.DecimalPlaces = 1;
            this.nudOriginX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nudOriginX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudOriginX.Location = new System.Drawing.Point(120, 15);
            this.nudOriginX.Name = "nudOriginX";
            this.nudOriginX.Size = new System.Drawing.Size(116, 20);
            this.nudOriginX.TabIndex = 1;
            // 
            // lblOriginX
            // 
            this.lblOriginX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOriginX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOriginX.Location = new System.Drawing.Point(12, 18);
            this.lblOriginX.Name = "lblOriginX";
            this.lblOriginX.Size = new System.Drawing.Size(104, 14);
            this.lblOriginX.TabIndex = 0;
            this.lblOriginX.Text = "Origin X (Dots)";
            // 
            // lblOriginY
            // 
            this.lblOriginY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOriginY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOriginY.Location = new System.Drawing.Point(252, 18);
            this.lblOriginY.Name = "lblOriginY";
            this.lblOriginY.Size = new System.Drawing.Size(104, 14);
            this.lblOriginY.TabIndex = 2;
            this.lblOriginY.Text = "Origin Y (Dots)";
            // 
            // nudDarkness
            // 
            this.nudDarkness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nudDarkness.Location = new System.Drawing.Point(360, 41);
            this.nudDarkness.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudDarkness.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.nudDarkness.Name = "nudDarkness";
            this.nudDarkness.Size = new System.Drawing.Size(121, 20);
            this.nudDarkness.TabIndex = 7;
            // 
            // Label4
            // 
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label4.Location = new System.Drawing.Point(252, 44);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(104, 14);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Darkness";
            // 
            // cboInvert
            // 
            this.cboInvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboInvert.Items.AddRange(new object[] {
            "N",
            "I"});
            this.cboInvert.Location = new System.Drawing.Point(120, 67);
            this.cboInvert.Name = "cboInvert";
            this.cboInvert.Size = new System.Drawing.Size(116, 21);
            this.cboInvert.TabIndex = 9;
            // 
            // txtPrintQty
            // 
            this.txtPrintQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPrintQty.Location = new System.Drawing.Point(120, 120);
            this.txtPrintQty.MaxLength = 10;
            this.txtPrintQty.Name = "txtPrintQty";
            this.txtPrintQty.Size = new System.Drawing.Size(116, 20);
            this.txtPrintQty.TabIndex = 17;
            this.txtPrintQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboReverse
            // 
            this.cboReverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboReverse.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cboReverse.Location = new System.Drawing.Point(120, 94);
            this.cboReverse.Name = "cboReverse";
            this.cboReverse.Size = new System.Drawing.Size(116, 21);
            this.cboReverse.TabIndex = 13;
            // 
            // nudSpeed
            // 
            this.nudSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nudSpeed.Location = new System.Drawing.Point(120, 41);
            this.nudSpeed.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudSpeed.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(116, 20);
            this.nudSpeed.TabIndex = 5;
            this.nudSpeed.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Label3
            // 
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label3.Location = new System.Drawing.Point(12, 98);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(104, 14);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Reverse";
            // 
            // Label2
            // 
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label2.Location = new System.Drawing.Point(12, 124);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(104, 14);
            this.Label2.TabIndex = 16;
            this.Label2.Text = "Print Qty";
            // 
            // Label1
            // 
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Label1.Location = new System.Drawing.Point(12, 70);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(104, 14);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "Invert";
            // 
            // lblSpeed
            // 
            this.lblSpeed.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSpeed.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblSpeed.Location = new System.Drawing.Point(12, 44);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(104, 14);
            this.lblSpeed.TabIndex = 4;
            this.lblSpeed.Text = "Print Speed";
            // 
            // cdvResolution
            // 
            this.cdvResolution.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResolution.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResolution.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResolution.BtnToolTipText = "";
            this.cdvResolution.DescText = "";
            this.cdvResolution.DisplaySubItemIndex = 0;
            this.cdvResolution.DisplayText = "";
            this.cdvResolution.Focusing = null;
            this.cdvResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvResolution.Index = 0;
            this.cdvResolution.IsViewBtnImage = false;
            this.cdvResolution.Location = new System.Drawing.Point(360, 95);
            this.cdvResolution.MaxLength = 10;
            this.cdvResolution.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResolution.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResolution.Name = "cdvResolution";
            this.cdvResolution.ReadOnly = false;
            this.cdvResolution.SearchSubItemIndex = 0;
            this.cdvResolution.SelectedDescIndex = -1;
            this.cdvResolution.SelectedSubItemIndex = 0;
            this.cdvResolution.SelectionStart = 0;
            this.cdvResolution.Size = new System.Drawing.Size(121, 21);
            this.cdvResolution.SmallImageList = null;
            this.cdvResolution.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResolution.TabIndex = 15;
            this.cdvResolution.TextBoxToolTipText = "";
            this.cdvResolution.TextBoxWidth = 121;
            this.cdvResolution.VisibleButton = true;
            this.cdvResolution.VisibleColumnHeader = false;
            this.cdvResolution.VisibleDescription = false;
            this.cdvResolution.ButtonPress += new System.EventHandler(this.cdvResolution_ButtonPress);
            // 
            // lblResolution
            // 
            this.lblResolution.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolution.Location = new System.Drawing.Point(252, 98);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(104, 14);
            this.lblResolution.TabIndex = 14;
            this.lblResolution.Text = "Resolution(DPI)";
            // 
            // cdvPrinterType
            // 
            this.cdvPrinterType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPrinterType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPrinterType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPrinterType.BtnToolTipText = "";
            this.cdvPrinterType.DescText = "";
            this.cdvPrinterType.DisplaySubItemIndex = 0;
            this.cdvPrinterType.DisplayText = "";
            this.cdvPrinterType.Focusing = null;
            this.cdvPrinterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvPrinterType.Index = 0;
            this.cdvPrinterType.IsViewBtnImage = false;
            this.cdvPrinterType.Location = new System.Drawing.Point(360, 67);
            this.cdvPrinterType.MaxLength = 20;
            this.cdvPrinterType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPrinterType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPrinterType.Name = "cdvPrinterType";
            this.cdvPrinterType.ReadOnly = false;
            this.cdvPrinterType.SearchSubItemIndex = 0;
            this.cdvPrinterType.SelectedDescIndex = -1;
            this.cdvPrinterType.SelectedSubItemIndex = 0;
            this.cdvPrinterType.SelectionStart = 0;
            this.cdvPrinterType.Size = new System.Drawing.Size(121, 21);
            this.cdvPrinterType.SmallImageList = null;
            this.cdvPrinterType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPrinterType.TabIndex = 11;
            this.cdvPrinterType.TextBoxToolTipText = "";
            this.cdvPrinterType.TextBoxWidth = 121;
            this.cdvPrinterType.VisibleButton = true;
            this.cdvPrinterType.VisibleColumnHeader = false;
            this.cdvPrinterType.VisibleDescription = false;
            this.cdvPrinterType.ButtonPress += new System.EventHandler(this.cdvPrinterType_ButtonPress);
            // 
            // lblPrinterType
            // 
            this.lblPrinterType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrinterType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinterType.Location = new System.Drawing.Point(252, 70);
            this.lblPrinterType.Name = "lblPrinterType";
            this.lblPrinterType.Size = new System.Drawing.Size(104, 14);
            this.lblPrinterType.TabIndex = 10;
            this.lblPrinterType.Text = "Printer Type";
            // 
            // pnlLabel
            // 
            this.pnlLabel.Controls.Add(this.grbMargin);
            this.pnlLabel.Controls.Add(this.grpLabelSize);
            this.pnlLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLabel.Location = new System.Drawing.Point(3, 70);
            this.pnlLabel.Name = "pnlLabel";
            this.pnlLabel.Size = new System.Drawing.Size(489, 70);
            this.pnlLabel.TabIndex = 1;
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.lblLeft);
            this.grbMargin.Controls.Add(this.txtLeft);
            this.grbMargin.Controls.Add(this.lblTop);
            this.grbMargin.Controls.Add(this.txtTop);
            this.grbMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbMargin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbMargin.Location = new System.Drawing.Point(246, 0);
            this.grbMargin.Name = "grbMargin";
            this.grbMargin.Size = new System.Drawing.Size(243, 70);
            this.grbMargin.TabIndex = 3;
            this.grbMargin.TabStop = false;
            this.grbMargin.Text = "Margin(mm)";
            // 
            // lblLeft
            // 
            this.lblLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLeft.Location = new System.Drawing.Point(12, 19);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(104, 14);
            this.lblLeft.TabIndex = 0;
            this.lblLeft.Text = "Left";
            // 
            // txtLeft
            // 
            this.txtLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeft.Location = new System.Drawing.Point(114, 16);
            this.txtLeft.MaxLength = 10;
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(121, 20);
            this.txtLeft.TabIndex = 1;
            this.txtLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTop
            // 
            this.lblTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTop.Location = new System.Drawing.Point(12, 43);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(104, 14);
            this.lblTop.TabIndex = 2;
            this.lblTop.Text = "Top";
            // 
            // txtTop
            // 
            this.txtTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTop.Location = new System.Drawing.Point(114, 39);
            this.txtTop.MaxLength = 10;
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(121, 20);
            this.txtTop.TabIndex = 3;
            this.txtTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpLabelSize
            // 
            this.grpLabelSize.Controls.Add(this.lblLabelHeight);
            this.grpLabelSize.Controls.Add(this.txtLabelHeight);
            this.grpLabelSize.Controls.Add(this.lblLabelWidth);
            this.grpLabelSize.Controls.Add(this.txtLabelWidth);
            this.grpLabelSize.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpLabelSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLabelSize.Location = new System.Drawing.Point(0, 0);
            this.grpLabelSize.Name = "grpLabelSize";
            this.grpLabelSize.Size = new System.Drawing.Size(246, 70);
            this.grpLabelSize.TabIndex = 2;
            this.grpLabelSize.TabStop = false;
            this.grpLabelSize.Text = "Label(mm)";
            // 
            // lblLabelHeight
            // 
            this.lblLabelHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLabelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelHeight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLabelHeight.Location = new System.Drawing.Point(12, 41);
            this.lblLabelHeight.Name = "lblLabelHeight";
            this.lblLabelHeight.Size = new System.Drawing.Size(104, 14);
            this.lblLabelHeight.TabIndex = 2;
            this.lblLabelHeight.Text = "Height";
            // 
            // txtLabelHeight
            // 
            this.txtLabelHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelHeight.Location = new System.Drawing.Point(120, 39);
            this.txtLabelHeight.MaxLength = 10;
            this.txtLabelHeight.Name = "txtLabelHeight";
            this.txtLabelHeight.Size = new System.Drawing.Size(116, 20);
            this.txtLabelHeight.TabIndex = 3;
            this.txtLabelHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLabelWidth
            // 
            this.lblLabelWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLabelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelWidth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLabelWidth.Location = new System.Drawing.Point(12, 18);
            this.lblLabelWidth.Name = "lblLabelWidth";
            this.lblLabelWidth.Size = new System.Drawing.Size(104, 14);
            this.lblLabelWidth.TabIndex = 0;
            this.lblLabelWidth.Text = "Width";
            // 
            // txtLabelWidth
            // 
            this.txtLabelWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabelWidth.Location = new System.Drawing.Point(120, 16);
            this.txtLabelWidth.MaxLength = 10;
            this.txtLabelWidth.Name = "txtLabelWidth";
            this.txtLabelWidth.Size = new System.Drawing.Size(116, 20);
            this.txtLabelWidth.TabIndex = 1;
            this.txtLabelWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlPage
            // 
            this.pnlPage.Controls.Add(this.grbType);
            this.pnlPage.Controls.Add(this.grbPage);
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPage.Location = new System.Drawing.Point(3, 0);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(489, 70);
            this.pnlPage.TabIndex = 0;
            // 
            // grbType
            // 
            this.grbType.Controls.Add(this.picLandscape);
            this.grbType.Controls.Add(this.picPortrait);
            this.grbType.Controls.Add(this.rbnLandscape);
            this.grbType.Controls.Add(this.rbnPortrait);
            this.grbType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbType.Location = new System.Drawing.Point(246, 0);
            this.grbType.Name = "grbType";
            this.grbType.Size = new System.Drawing.Size(243, 70);
            this.grbType.TabIndex = 1;
            this.grbType.TabStop = false;
            this.grbType.Text = "Type";
            // 
            // picLandscape
            // 
            this.picLandscape.Image = ((System.Drawing.Image)(resources.GetObject("picLandscape.Image")));
            this.picLandscape.Location = new System.Drawing.Point(169, 18);
            this.picLandscape.Name = "picLandscape";
            this.picLandscape.Size = new System.Drawing.Size(32, 32);
            this.picLandscape.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLandscape.TabIndex = 3;
            this.picLandscape.TabStop = false;
            // 
            // picPortrait
            // 
            this.picPortrait.Image = ((System.Drawing.Image)(resources.GetObject("picPortrait.Image")));
            this.picPortrait.Location = new System.Drawing.Point(169, 18);
            this.picPortrait.Name = "picPortrait";
            this.picPortrait.Size = new System.Drawing.Size(32, 32);
            this.picPortrait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPortrait.TabIndex = 2;
            this.picPortrait.TabStop = false;
            // 
            // rbnLandscape
            // 
            this.rbnLandscape.Location = new System.Drawing.Point(8, 37);
            this.rbnLandscape.Name = "rbnLandscape";
            this.rbnLandscape.Size = new System.Drawing.Size(104, 24);
            this.rbnLandscape.TabIndex = 1;
            this.rbnLandscape.Text = "Landscape";
            this.rbnLandscape.CheckedChanged += new System.EventHandler(this.bnLandscape_CheckedChanged);
            // 
            // rbnPortrait
            // 
            this.rbnPortrait.Checked = true;
            this.rbnPortrait.Location = new System.Drawing.Point(8, 14);
            this.rbnPortrait.Name = "rbnPortrait";
            this.rbnPortrait.Size = new System.Drawing.Size(104, 24);
            this.rbnPortrait.TabIndex = 0;
            this.rbnPortrait.TabStop = true;
            this.rbnPortrait.Text = "Portrait";
            this.rbnPortrait.CheckedChanged += new System.EventHandler(this.rbnPortrait_CheckedChanged);
            // 
            // grbPage
            // 
            this.grbPage.Controls.Add(this.lblPageHeight);
            this.grbPage.Controls.Add(this.txtPageHeight);
            this.grbPage.Controls.Add(this.lblPageWidth);
            this.grbPage.Controls.Add(this.txtPageWidth);
            this.grbPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbPage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbPage.Location = new System.Drawing.Point(0, 0);
            this.grbPage.Name = "grbPage";
            this.grbPage.Size = new System.Drawing.Size(246, 70);
            this.grbPage.TabIndex = 0;
            this.grbPage.TabStop = false;
            this.grbPage.Text = "Page(mm)";
            // 
            // lblPageHeight
            // 
            this.lblPageHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPageHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageHeight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPageHeight.Location = new System.Drawing.Point(11, 41);
            this.lblPageHeight.Name = "lblPageHeight";
            this.lblPageHeight.Size = new System.Drawing.Size(104, 14);
            this.lblPageHeight.TabIndex = 2;
            this.lblPageHeight.Text = "Height";
            // 
            // txtPageHeight
            // 
            this.txtPageHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageHeight.Location = new System.Drawing.Point(119, 39);
            this.txtPageHeight.MaxLength = 10;
            this.txtPageHeight.Name = "txtPageHeight";
            this.txtPageHeight.Size = new System.Drawing.Size(116, 20);
            this.txtPageHeight.TabIndex = 3;
            this.txtPageHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPageWidth
            // 
            this.lblPageWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPageWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageWidth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPageWidth.Location = new System.Drawing.Point(12, 18);
            this.lblPageWidth.Name = "lblPageWidth";
            this.lblPageWidth.Size = new System.Drawing.Size(104, 14);
            this.lblPageWidth.TabIndex = 0;
            this.lblPageWidth.Text = "Width";
            // 
            // txtPageWidth
            // 
            this.txtPageWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageWidth.Location = new System.Drawing.Point(120, 16);
            this.txtPageWidth.MaxLength = 10;
            this.txtPageWidth.Name = "txtPageWidth";
            this.txtPageWidth.Size = new System.Drawing.Size(116, 20);
            this.txtPageWidth.TabIndex = 1;
            this.txtPageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtUpdateTime);
            this.GroupBox1.Controls.Add(this.txtCreateTime);
            this.GroupBox1.Controls.Add(this.txtUpdateUser);
            this.GroupBox1.Controls.Add(this.lblUpdate);
            this.GroupBox1.Controls.Add(this.txtCreateUser);
            this.GroupBox1.Controls.Add(this.lblCreate);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GroupBox1.Location = new System.Drawing.Point(3, 336);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(489, 71);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(305, 40);
            this.txtUpdateTime.MaxLength = 20;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(305, 16);
            this.txtCreateTime.MaxLength = 20;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(125, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(13, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(100, 14);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(125, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(13, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(100, 14);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCmf);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(495, 410);
            this.tbpCMF.TabIndex = 1;
            this.tbpCMF.Text = "Customized Field";
            this.tbpCMF.Visible = false;
            // 
            // grpCmf
            // 
            this.grpCmf.Controls.Add(this.lblCMF7);
            this.grpCmf.Controls.Add(this.lblCMF6);
            this.grpCmf.Controls.Add(this.lblCMF5);
            this.grpCmf.Controls.Add(this.lblCMF4);
            this.grpCmf.Controls.Add(this.cdvCmf10);
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
            this.grpCmf.Size = new System.Drawing.Size(489, 407);
            this.grpCmf.TabIndex = 1;
            this.grpCmf.TabStop = false;
            this.grpCmf.Text = "Customized Field (1~10)";
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
            this.cdvCmf10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
            this.cdvCmf10.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
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
            this.cdvCmf8.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
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
            this.cdvCmf7.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
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
            this.cdvCmf6.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
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
            this.cdvCmf5.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
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
            this.cdvCmf4.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
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
            this.cdvCmf3.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
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
            this.cdvCmf2.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
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
            this.cdvCmf1.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
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
            this.cdvCmf9.ButtonPress += new System.EventHandler(this.cdvCmf_ButtonPress);
            // 
            // tbpCopy
            // 
            this.tbpCopy.Controls.Add(this.grpCopyTable);
            this.tbpCopy.Location = new System.Drawing.Point(4, 22);
            this.tbpCopy.Name = "tbpCopy";
            this.tbpCopy.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCopy.Size = new System.Drawing.Size(495, 410);
            this.tbpCopy.TabIndex = 2;
            this.tbpCopy.Text = "Copy Label";
            // 
            // grpCopyTable
            // 
            this.grpCopyTable.Controls.Add(this.btnCopy);
            this.grpCopyTable.Controls.Add(this.lblToLabel);
            this.grpCopyTable.Controls.Add(this.txtToLabel);
            this.grpCopyTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyTable.Location = new System.Drawing.Point(3, 0);
            this.grpCopyTable.Name = "grpCopyTable";
            this.grpCopyTable.Size = new System.Drawing.Size(489, 49);
            this.grpCopyTable.TabIndex = 1;
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
            // lblToLabel
            // 
            this.lblToLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToLabel.Location = new System.Drawing.Point(8, 19);
            this.lblToLabel.Name = "lblToLabel";
            this.lblToLabel.Size = new System.Drawing.Size(70, 14);
            this.lblToLabel.TabIndex = 0;
            this.lblToLabel.Text = "To Label";
            this.lblToLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToLabel
            // 
            this.txtToLabel.Location = new System.Drawing.Point(83, 16);
            this.txtToLabel.MaxLength = 20;
            this.txtToLabel.Name = "txtToLabel";
            this.txtToLabel.Size = new System.Drawing.Size(123, 20);
            this.txtToLabel.TabIndex = 1;
            // 
            // lisLabel
            // 
            this.lisLabel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaterial,
            this.colMatDesc});
            this.lisLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisLabel.EnableSort = true;
            this.lisLabel.EnableSortIcon = true;
            this.lisLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisLabel.FullRowSelect = true;
            this.lisLabel.Location = new System.Drawing.Point(3, 3);
            this.lisLabel.MultiSelect = false;
            this.lisLabel.Name = "lisLabel";
            this.lisLabel.Size = new System.Drawing.Size(229, 507);
            this.lisLabel.TabIndex = 0;
            this.lisLabel.UseCompatibleStateImageBehavior = false;
            this.lisLabel.View = System.Windows.Forms.View.Details;
            this.lisLabel.SelectedIndexChanged += new System.EventHandler(this.lisLabel_SelectedIndexChanged);
            // 
            // colMaterial
            // 
            this.colMaterial.Text = "Label";
            this.colMaterial.Width = 100;
            // 
            // colMatDesc
            // 
            this.colMatDesc.Text = "Description";
            this.colMatDesc.Width = 300;
            // 
            // frmPOPSetupLabel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmPOPSetupLabel";
            this.Text = "Label Setup";
            this.Activated += new System.EventHandler(this.frmPOPSetupLabel_Activated);
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
            this.pnlLabelInfo.ResumeLayout(false);
            this.tabLabel.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOriginY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOriginX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDarkness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPrinterType)).EndInit();
            this.pnlLabel.ResumeLayout(false);
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.grpLabelSize.ResumeLayout(false);
            this.grpLabelSize.PerformLayout();
            this.pnlPage.ResumeLayout(false);
            this.grbType.ResumeLayout(false);
            this.grbType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLandscape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPortrait)).EndInit();
            this.grbPage.ResumeLayout(false);
            this.grbPage.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
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
            this.tbpCopy.ResumeLayout(false);
            this.grpCopyTable.ResumeLayout(false);
            this.grpCopyTable.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Constant Definition"
        
        #endregion
        
        #region "Variable Definition"
        
        bool b_load_flag;
        bool bViewFlag;
        
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
            try
            {
                switch (FuncName.Trim())
                {
                    case "Update_Label":
                        
                        if (txtLabel.Text.Trim() == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtLabel.Select();
                            return false;
                        }
                        switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                        {
                            case MPGC.MP_STEP_CREATE:

                                if (MPCF.CheckValue(txtPageWidth, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtPageHeight, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtLabelWidth, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtLabelHeight, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtLeft, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtTop, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.ToDbl(txtPageWidth.Text) < MPCF.ToDbl(txtLabelWidth.Text))
                                {
                                    txtLabelWidth.Text = txtPageWidth.Text;
                                    txtLabelWidth.Focus();
                                    return false;
                                }
                                if (MPCF.ToDbl(txtPageHeight.Text) < MPCF.ToDbl(txtLabelHeight.Text))
                                {
                                    txtLabelHeight.Text = txtPageHeight.Text;
                                    txtLabelHeight.Focus();
                                    return false;
                                }
                                if (MPCF.ToDbl(txtPageWidth.Text) - MPCF.ToDbl(txtLabelWidth.Text) < 0)
                                {
                                    txtLabelWidth.Text = Convert.ToString(MPCF.ToDbl(txtPageWidth.Text) - MPCF.ToDbl(txtLeft.Text));
                                }
                                if (MPCF.ToDbl(txtPageHeight.Text) - MPCF.ToDbl(txtLabelHeight.Text) < 0)
                                {
                                    txtLabelHeight.Text = Convert.ToString(MPCF.ToDbl(txtPageHeight.Text) - MPCF.ToDbl(txtTop.Text));
                                }
                                if (MPCF.CheckValue(txtPrintQty, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(cdvResolution, 1) == false)
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


                                if (MPCF.CheckValue(txtPageWidth, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtPageHeight, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtLabelWidth, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtLabelHeight, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtLeft, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(txtTop, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.ToDbl(txtPageWidth.Text) < MPCF.ToDbl(txtLabelWidth.Text))
                                {
                                    txtLabelWidth.Text = txtPageWidth.Text;
                                    txtLabelWidth.Focus();
                                    return false;
                                }
                                if (MPCF.ToDbl(txtPageHeight.Text) < MPCF.ToDbl(txtLabelHeight.Text))
                                {
                                    txtLabelHeight.Text = txtPageHeight.Text;
                                    txtLabelHeight.Focus();
                                    return false;
                                }
                                if (MPCF.ToDbl(txtPageWidth.Text) - MPCF.ToDbl(txtLabelWidth.Text) < 0)
                                {
                                    txtLabelWidth.Text = Convert.ToString(MPCF.ToDbl(txtPageWidth.Text) - MPCF.ToDbl(txtLeft.Text));
                                }
                                if (MPCF.ToDbl(txtPageHeight.Text) - MPCF.ToDbl(txtLabelHeight.Text) < 0)
                                {
                                    txtLabelHeight.Text = Convert.ToString(MPCF.ToDbl(txtPageHeight.Text) - MPCF.ToDbl(txtTop.Text));
                                }
                                if (MPCF.CheckValue(txtPrintQty, 2) == false)
                                {
                                    return false;
                                }
                                if (MPCF.CheckValue(cdvResolution, 1) == false)
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
                    case "View_Label":
                        
                        break;
                        
                    case "Copy_Label":
                        
                        if (txtLabel.Text.Trim() == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtLabel.Select();
                            return false;
                        }
                        if (txtToLabel.Text.Trim() == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtToLabel.Select();
                            return false;
                        }
                        
                        return true;
                        
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
                    MPCF.FieldClear(this.pnlRight);
                }
                else if (ProcStep == '2')
                {
                    MPCF.ClearList(lisLabel, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //-----------------------------------------------------------------------------
        //
        // View_Label()
        //       - View Label Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        private bool View_Label()
        {
            TRSNode in_node = new TRSNode("View_Label_In");
            TRSNode out_node = new TRSNode("View_Label_Out");
            
            try
            {
                ClearData('1');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LABEL_ID", lisLabel.SelectedItems[0].Text);
                
                if (MPCR.CallService("POP", "POP_View_Label", in_node, ref out_node) == false)
                {
                    return false;
                }

                //General
                txtLabel.Text = out_node.GetString("LABEL_ID");
                txtDesc.Text = out_node.GetString("LABEL_DESC");

                //Customized Field
                cdvCmf1.Text = out_node.GetString("LABEL_CMF_1");
                cdvCmf2.Text = out_node.GetString("LABEL_CMF_2");
                cdvCmf3.Text = out_node.GetString("LABEL_CMF_3");
                cdvCmf4.Text = out_node.GetString("LABEL_CMF_4");
                cdvCmf5.Text = out_node.GetString("LABEL_CMF_5");
                cdvCmf6.Text = out_node.GetString("LABEL_CMF_6");
                cdvCmf7.Text = out_node.GetString("LABEL_CMF_7");
                cdvCmf8.Text = out_node.GetString("LABEL_CMF_8");
                cdvCmf9.Text = out_node.GetString("LABEL_CMF_9");
                cdvCmf10.Text = out_node.GetString("LABEL_CMF_10");

                txtPageWidth.Text = MPCF.Trim(out_node.GetDouble("PAGE_WIDTH"));
                txtPageHeight.Text = MPCF.Trim(out_node.GetDouble("PAGE_HEIGHT"));
                txtLabelWidth.Text = MPCF.Trim(out_node.GetDouble("LABEL_WIDTH"));
                txtLabelHeight.Text = MPCF.Trim(out_node.GetDouble("LABEL_HEIGHT"));
                txtLeft.Text = MPCF.Trim(out_node.GetDouble("MARGIN_LEFT"));
                txtTop.Text = MPCF.Trim(out_node.GetDouble("MARGIN_TOP"));
                
                bViewFlag = true;
                if (MPCF.Trim(out_node.GetChar("LABEL_TYPE")) == "P")
                {
                    rbnPortrait.Checked = true;
                }
                else
                {
                    rbnLandscape.Checked = true;
                }
                bViewFlag = false;

                cdvPrinterType.Text = out_node.GetString("PRINTER_TYPE");
                cdvResolution.Text = out_node.GetString("RESOLUTION");

                nudSpeed.Text = MPCF.Trim(out_node.GetChar("PRINT_SPEED"));
                cboInvert.Text = MPCF.Trim(out_node.GetChar("INVERT"));
                cboReverse.Text = MPCF.Trim(out_node.GetChar("REVERSE"));
                txtPrintQty.Text = MPCF.Trim(out_node.GetInt("PRINT_QTY"));
                nudDarkness.Text = MPCF.Trim(out_node.GetInt("DARKNESS"));

                nudOriginX.Text = MPCF.Trim(out_node.GetDouble("ORIGIN_X"));
                nudOriginY.Text = MPCF.Trim(out_node.GetDouble("ORIGIN_Y"));
                
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
        // Update_Label()
        //       - Create/Update/Delete Label Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        //-----------------------------------------------------------------------------
        private bool Update_Label(char ProcStep)
        {
            
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("Update_Label_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            try
            {
                MPCR.SetInMsg(in_node);                
                in_node.ProcStep = ProcStep;
                in_node.AddString("LABEL_ID", txtLabel.Text);
                in_node.AddString("LABEL_DESC", txtDesc.Text.TrimEnd());
                
                in_node.AddDouble("PAGE_WIDTH", MPCF.ToDbl(txtPageWidth.Text.TrimEnd()));
                in_node.AddDouble("PAGE_HEIGHT", MPCF.ToDbl(txtPageHeight.Text.TrimEnd()));
                in_node.AddDouble("LABEL_WIDTH", MPCF.ToDbl(txtLabelWidth.Text.TrimEnd()));
                in_node.AddDouble("LABEL_HEIGHT", MPCF.ToDbl(txtLabelHeight.Text.TrimEnd()));

                in_node.AddDouble("MARGIN_LEFT", MPCF.ToDbl(txtLeft.Text.TrimEnd()));
                in_node.AddDouble("MARGIN_TOP", MPCF.ToDbl(txtTop.Text.TrimEnd()));
                
                if (rbnPortrait.Checked == true)
                {
                    in_node.AddChar("LABEL_TYPE", 'P');
                }
                else
                {
                    in_node.AddChar("LABEL_TYPE", 'L');
                }

                in_node.AddDouble("ORIGIN_X", (double)nudOriginX.Value);
                //Modify by J.S. 2009.04.10
                in_node.AddDouble("ORIGIN_Y", (double)nudOriginY.Value);
                
                in_node.AddString("PRINTER_TYPE", cdvPrinterType.Text.TrimEnd());
                in_node.AddString("RESOLUTION", cdvResolution.Text.TrimEnd());

                in_node.AddChar("PRINT_SPEED", MPCF.ToChar(nudSpeed.Text.TrimEnd()));
                in_node.AddChar("INVERT", (cboInvert.Text.Trim() == "") ? 'N' : MPCF.ToChar(cboInvert.Text.Trim()));
                in_node.AddChar("REVERSE", (cboReverse.Text.Trim() == "") ? 'N' : MPCF.ToChar(cboReverse.Text.Trim()));

                in_node.AddInt("DARKNESS", (int)nudDarkness.Value);
                in_node.AddInt("PRINT_QTY", (txtPrintQty.Text.Trim() == "") ? 1 : MPCF.ToInt(txtPrintQty.Text.Trim()));
                
                in_node.AddString("LABEL_CMF_1", cdvCmf1.Text.TrimEnd());
                in_node.AddString("LABEL_CMF_2", cdvCmf2.Text.TrimEnd());
                in_node.AddString("LABEL_CMF_3", cdvCmf3.Text.TrimEnd());
                in_node.AddString("LABEL_CMF_4", cdvCmf4.Text.TrimEnd());
                in_node.AddString("LABEL_CMF_5", cdvCmf5.Text.TrimEnd());
                in_node.AddString("LABEL_CMF_6", cdvCmf6.Text.TrimEnd());
                in_node.AddString("LABEL_CMF_7", cdvCmf7.Text.TrimEnd());
                in_node.AddString("LABEL_CMF_8", cdvCmf8.Text.TrimEnd());
                in_node.AddString("LABEL_CMF_9", cdvCmf9.Text.TrimEnd());
                in_node.AddString("LABEL_CMF_10", cdvCmf10.Text.TrimEnd());
                
                if (MPCR.CallService("POP", "POP_Update_Label", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisLabel.Items.Add(txtLabel.Text.Trim(), (int)SMALLICON_INDEX.IDX_LABEL);
                        itm.SubItems.Add(txtDesc.Text.Trim());
                        itm.Selected = true;
                        lisLabel.Sorting = SortOrder.Ascending;
                        lisLabel.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisLabel, txtLabel.Text.TrimEnd(), false) == true)
                        {
                            lisLabel.SelectedItems[0].SubItems[1].Text = txtDesc.Text.TrimEnd();
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisLabel, txtLabel.Text.TrimEnd(), false);
                        if (idx != - 1)
                        {
                            lisLabel.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisLabel.Items.Count.ToString();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            MPCR.ShowSuccessMsg(out_node);
            return true;
            
        }
        
        //
        // Copy_Label()
        //       - Copy Label Definition & Design
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Copy_Label(char ProcStep)
        {
            ListViewItem itm;
            
            TRSNode in_node = new TRSNode("Copy_Label_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            try
            {
                MPCR.SetInMsg(in_node);                
                in_node.ProcStep = ProcStep;                
                in_node.AddString("LABEL_ID", txtToLabel.Text);
                in_node.AddString("FROM_LABEL_ID", txtLabel.Text);
                
                if (MPCR.CallService("POP", "POP_Copy_Label", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_COPY)
                    {
                        itm = lisLabel.Items.Add(txtToLabel.Text.Trim(), (int)SMALLICON_INDEX.IDX_OPER);
                        itm.SubItems.Add(txtDesc.Text.Trim());
                        itm.Selected = true;
                        lisLabel.Sorting = SortOrder.Ascending;
                        lisLabel.Sort();
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
        
        private void swap(string aValue1, string aValue2)
        {
            string t = aValue1;
            
            aValue1 = aValue2;
            aValue2 = t;
        }
        
        private void InitCodeView()
        {
            
            if (cdvPrinterType.DisplaySubItemIndex != cdvPrinterType.SelectedSubItemIndex)
            {
                cdvPrinterType_ButtonPress(null, null);
            }
            if (cdvResolution.DisplaySubItemIndex != cdvResolution.SelectedSubItemIndex)
            {
                cdvResolution_ButtonPress(null, null);
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisLabel;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmPOPSetupLabel_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.InitListView(lisLabel);
                InitCodeView();
                MPCR.SetCMFItem(MPGC.MP_CMF_LABEL, "lblCmf", "cdvCmf", grpCmf);
                
                POPLIST.ViewLabelList(lisLabel, '1', "", 0, "", null, "");
                if (lisLabel.Items.Count > 0)
                {
                    lisLabel.Items[0].Selected = true;
                }
                lblDataCount.Text = lisLabel.Items.Count.ToString();

                if (MPCR.CheckSecurityFormControl(this, ref this.DisabledFormControls) == false)
                {
                    return;
                }

                b_load_flag = true;
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (POPLIST.ViewLabelList(lisLabel, '1', "", 0, "", null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisLabel.Items.Count.ToString();
                if (lisLabel.Items.Count > 0)
                {
                    MPCF.FindListItem(lisLabel, txtLabel.Text.Trim(), false);
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
                if (CheckCondition("Update_Label", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Label(MPGC.MP_STEP_CREATE) == false)
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
                
                if (CheckCondition("Update_Label", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Label(MPGC.MP_STEP_UPDATE) == false)
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
                
                if (CheckCondition("Update_Label", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Label(MPGC.MP_STEP_DELETE) == false)
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
        
        private void lisLabel_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight);
                
                if (lisLabel.SelectedItems.Count > 0)
                {
                    txtLabel.Text = lisLabel.SelectedItems[0].Text;
                    View_Label();
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
                MPCF.ExportToExcel(lisLabel, this.Text, "");
                
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
            
            MPCF.FindListItemNextPartial(lisLabel, txtFind.Text.Trim(), true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.FindListItemPartial(lisLabel, txtFind.Text.Trim(), 0, true, false);
            
        }
        
        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (CheckCondition("Copy_Label", MPGC.MP_STEP_COPY) == true)
                {
                    if (Copy_Label(MPGC.MP_STEP_COPY) == false)
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
        
        private void tabLabel_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!(tabLabel.SelectedTab == tbpCopy))
            {
                MPCR.CheckSecurityFormControlSub(btnCreate, this.DisabledFormControls, true);
                MPCR.CheckSecurityFormControlSub(btnUpdate, this.DisabledFormControls, true);
                MPCR.CheckSecurityFormControlSub(btnDelete, this.DisabledFormControls, true);
            }
            else
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
        
        private void rbnPortrait_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            picPortrait.Visible = rbnPortrait.Checked;
            picLandscape.Visible = rbnLandscape.Checked;
            if (bViewFlag == false)
            {
                swap(txtPageHeight.Text, txtPageWidth.Text);
                swap(txtLabelHeight.Text, txtLabelWidth.Text);
                swap(txtLeft.Text, txtTop.Text);
                swap(nudOriginX.Text, nudOriginY.Text);
            }
        }
        
        private void bnLandscape_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            picPortrait.Visible = rbnPortrait.Checked;
            picLandscape.Visible = rbnLandscape.Checked;
        }
        
        private void cdvPrinterType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvPrinterType.Init();
            MPCF.InitListView(cdvPrinterType.GetListView);
            cdvPrinterType.Columns.Add("Printer Type", 100, HorizontalAlignment.Left);
            cdvPrinterType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvPrinterType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvPrinterType.GetListView, '1', MPGC.MP_POP_PRINTER_TYPE);
        }
        
        private void cdvResolution_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResolution.Init();
            MPCF.InitListView(cdvResolution.GetListView);
            cdvResolution.Columns.Add("Resoultion", 100, HorizontalAlignment.Left);
            cdvResolution.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResolution.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvResolution.GetListView, '1', MPGC.MP_POP_RESOLUTION);
            
            rbnPortrait.Checked = true;
        }
        
    }
    //#End If
}
