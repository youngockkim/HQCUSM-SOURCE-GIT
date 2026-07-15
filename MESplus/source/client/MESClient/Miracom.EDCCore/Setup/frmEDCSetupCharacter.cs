
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
//   File Name   : frmEDCSetupCharacter.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - InitControl() : Group & CMF Initialize
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the Conditions before Transaction
//       - CheckCMF() : CMF and Group Definition Validation Check
//       - View_Character() : View Character
//       - Update_Character() : Create/Update/Delete Character
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-14 : Created by W.Y. Choi
//       - 2008-01-11 : Modified by LAVERWON : Unit, Spec. Limit, Warning Limit Added
//
//
//   Copyright(C) 1998-2008 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.EDCCore
{
    public class frmEDCSetupCharacter : Miracom.MESCore.SetupForm02
    {

#if _EDC

        #region " Windows Form auto generated code "

        public frmEDCSetupCharacter()
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
        private System.Windows.Forms.Label lblCharacter;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.TabControl tabCharacter;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabCMF;
        private System.Windows.Forms.GroupBox grpCharacter;
        private System.Windows.Forms.GroupBox grpDateTime;
        private System.Windows.Forms.GroupBox grpCharacterSetup;
        private System.Windows.Forms.Label lblValueType;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TextBox txtCharacterDesc;
        private System.Windows.Forms.TextBox txtCharacter;
        private Miracom.UI.Controls.MCListView.MCListView lisCharacter;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.RadioButton rbnAscii;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.RadioButton rbnNumber;
        private System.Windows.Forms.GroupBox grpCMF;
        private System.Windows.Forms.Label lblCMF3;
        private System.Windows.Forms.Label lblCMF2;
        private System.Windows.Forms.Label lblCMF1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        private System.Windows.Forms.Label lblCMF10;
        private System.Windows.Forms.Label lblCMF9;
        private System.Windows.Forms.Label lblCMF8;
        private System.Windows.Forms.Label lblCMF7;
        private System.Windows.Forms.Label lblCMF6;
        private System.Windows.Forms.Label lblCMF5;
        private System.Windows.Forms.Label lblCMF4;
        private System.Windows.Forms.GroupBox grpGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup9;
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
        private Panel pnlSpecLimit;
        private GroupBox grpSpecLimit;
        private Label lblUnit;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvUnit;
        private Panel pnlWarnLimit;
        private GroupBox grpWarnLimit;
        private Label lblLowerSpecLimit;
        private TextBox txtLowerSpecLimit;
        private Label lblUpperSpecLimit;
        private TextBox txtUpperSpecLimit;
        private Label lblTargetValue;
        private Label lblLowerWarnLimit;
        private TextBox txtLowerWarnLimit;
        private Label lblUpperWarnLimit;
        private TextBox txtUpperWarnLimit;
        private UI.Controls.MCCodeView.MCCodeView cdvTargetValue;
        private UI.Controls.MCCodeView.MCCodeView cdvValidTable;
        private Label lblValidTable;
        private ComboBox cboCharType;
        private Label lblCharType;
        private Label lblAttachDir;
        private TextBox txtAttachDir;
        private System.Windows.Forms.Label lblGroup1;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.lisCharacter = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpCharacter = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblCharacter = new System.Windows.Forms.Label();
            this.txtCharacterDesc = new System.Windows.Forms.TextBox();
            this.txtCharacter = new System.Windows.Forms.TextBox();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabCharacter = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.pnlWarnLimit = new System.Windows.Forms.Panel();
            this.grpWarnLimit = new System.Windows.Forms.GroupBox();
            this.lblLowerWarnLimit = new System.Windows.Forms.Label();
            this.txtLowerWarnLimit = new System.Windows.Forms.TextBox();
            this.lblUpperWarnLimit = new System.Windows.Forms.Label();
            this.txtUpperWarnLimit = new System.Windows.Forms.TextBox();
            this.grpDateTime = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.pnlSpecLimit = new System.Windows.Forms.Panel();
            this.grpSpecLimit = new System.Windows.Forms.GroupBox();
            this.lblAttachDir = new System.Windows.Forms.Label();
            this.txtAttachDir = new System.Windows.Forms.TextBox();
            this.cdvTargetValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvValidTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValidTable = new System.Windows.Forms.Label();
            this.lblLowerSpecLimit = new System.Windows.Forms.Label();
            this.txtLowerSpecLimit = new System.Windows.Forms.TextBox();
            this.lblUpperSpecLimit = new System.Windows.Forms.Label();
            this.txtUpperSpecLimit = new System.Windows.Forms.TextBox();
            this.lblTargetValue = new System.Windows.Forms.Label();
            this.grpCharacterSetup = new System.Windows.Forms.GroupBox();
            this.cboCharType = new System.Windows.Forms.ComboBox();
            this.lblCharType = new System.Windows.Forms.Label();
            this.cdvUnit = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUnit = new System.Windows.Forms.Label();
            this.rbnNumber = new System.Windows.Forms.RadioButton();
            this.rbnAscii = new System.Windows.Forms.RadioButton();
            this.lblValueType = new System.Windows.Forms.Label();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
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
            this.tabCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.lblCMF3 = new System.Windows.Forms.Label();
            this.lblCMF2 = new System.Windows.Forms.Label();
            this.lblCMF1 = new System.Windows.Forms.Label();
            this.cdvCMF5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpCharacter.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabCharacter.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.pnlWarnLimit.SuspendLayout();
            this.grpWarnLimit.SuspendLayout();
            this.grpDateTime.SuspendLayout();
            this.pnlSpecLimit.SuspendLayout();
            this.grpSpecLimit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValidTable)).BeginInit();
            this.grpCharacterSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit)).BeginInit();
            this.tabGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            this.tabCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
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
            this.pnlRight.Controls.Add(this.grpCharacter);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisCharacter);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            this.pnlLeft.TabStop = true;
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
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Character Setup";
            // 
            // lisCharacter
            // 
            this.lisCharacter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCharacter.EnableSort = true;
            this.lisCharacter.EnableSortIcon = true;
            this.lisCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisCharacter.FullRowSelect = true;
            this.lisCharacter.Location = new System.Drawing.Point(3, 3);
            this.lisCharacter.MultiSelect = false;
            this.lisCharacter.Name = "lisCharacter";
            this.lisCharacter.Size = new System.Drawing.Size(229, 507);
            this.lisCharacter.TabIndex = 0;
            this.lisCharacter.UseCompatibleStateImageBehavior = false;
            this.lisCharacter.View = System.Windows.Forms.View.Details;
            this.lisCharacter.SelectedIndexChanged += new System.EventHandler(this.lisCharacter_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Character";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // grpCharacter
            // 
            this.grpCharacter.Controls.Add(this.lblDesc);
            this.grpCharacter.Controls.Add(this.lblCharacter);
            this.grpCharacter.Controls.Add(this.txtCharacterDesc);
            this.grpCharacter.Controls.Add(this.txtCharacter);
            this.grpCharacter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCharacter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCharacter.Location = new System.Drawing.Point(3, 0);
            this.grpCharacter.Name = "grpCharacter";
            this.grpCharacter.Size = new System.Drawing.Size(500, 71);
            this.grpCharacter.TabIndex = 0;
            this.grpCharacter.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblCharacter
            // 
            this.lblCharacter.AutoSize = true;
            this.lblCharacter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacter.Location = new System.Drawing.Point(15, 19);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(62, 13);
            this.lblCharacter.TabIndex = 0;
            this.lblCharacter.Text = "Character";
            // 
            // txtCharacterDesc
            // 
            this.txtCharacterDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCharacterDesc.Location = new System.Drawing.Point(127, 40);
            this.txtCharacterDesc.MaxLength = 200;
            this.txtCharacterDesc.Name = "txtCharacterDesc";
            this.txtCharacterDesc.Size = new System.Drawing.Size(355, 20);
            this.txtCharacterDesc.TabIndex = 3;
            // 
            // txtCharacter
            // 
            this.txtCharacter.Location = new System.Drawing.Point(127, 16);
            this.txtCharacter.MaxLength = 25;
            this.txtCharacter.Name = "txtCharacter";
            this.txtCharacter.Size = new System.Drawing.Size(177, 20);
            this.txtCharacter.TabIndex = 1;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabCharacter);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(3, 71);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(500, 439);
            this.pnlTab.TabIndex = 1;
            // 
            // tabCharacter
            // 
            this.tabCharacter.Controls.Add(this.tabGeneral);
            this.tabCharacter.Controls.Add(this.tabGroup);
            this.tabCharacter.Controls.Add(this.tabCMF);
            this.tabCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCharacter.ItemSize = new System.Drawing.Size(60, 18);
            this.tabCharacter.Location = new System.Drawing.Point(0, 5);
            this.tabCharacter.Name = "tabCharacter";
            this.tabCharacter.SelectedIndex = 0;
            this.tabCharacter.Size = new System.Drawing.Size(500, 434);
            this.tabCharacter.TabIndex = 1;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.pnlWarnLimit);
            this.tabGeneral.Controls.Add(this.grpDateTime);
            this.tabGeneral.Controls.Add(this.pnlSpecLimit);
            this.tabGeneral.Controls.Add(this.grpCharacterSetup);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tabGeneral.Size = new System.Drawing.Size(492, 408);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // pnlWarnLimit
            // 
            this.pnlWarnLimit.Controls.Add(this.grpWarnLimit);
            this.pnlWarnLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWarnLimit.Location = new System.Drawing.Point(3, 256);
            this.pnlWarnLimit.Name = "pnlWarnLimit";
            this.pnlWarnLimit.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlWarnLimit.Size = new System.Drawing.Size(486, 79);
            this.pnlWarnLimit.TabIndex = 2;
            // 
            // grpWarnLimit
            // 
            this.grpWarnLimit.Controls.Add(this.lblLowerWarnLimit);
            this.grpWarnLimit.Controls.Add(this.txtLowerWarnLimit);
            this.grpWarnLimit.Controls.Add(this.lblUpperWarnLimit);
            this.grpWarnLimit.Controls.Add(this.txtUpperWarnLimit);
            this.grpWarnLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWarnLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpWarnLimit.Location = new System.Drawing.Point(0, 4);
            this.grpWarnLimit.Name = "grpWarnLimit";
            this.grpWarnLimit.Size = new System.Drawing.Size(486, 75);
            this.grpWarnLimit.TabIndex = 0;
            this.grpWarnLimit.TabStop = false;
            this.grpWarnLimit.Text = "Default Warning Limit";
            // 
            // lblLowerWarnLimit
            // 
            this.lblLowerWarnLimit.AutoSize = true;
            this.lblLowerWarnLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLowerWarnLimit.Location = new System.Drawing.Point(15, 45);
            this.lblLowerWarnLimit.Name = "lblLowerWarnLimit";
            this.lblLowerWarnLimit.Size = new System.Drawing.Size(92, 13);
            this.lblLowerWarnLimit.TabIndex = 2;
            this.lblLowerWarnLimit.Text = "Lower Warn. Limit";
            // 
            // txtLowerWarnLimit
            // 
            this.txtLowerWarnLimit.Location = new System.Drawing.Point(120, 42);
            this.txtLowerWarnLimit.MaxLength = 25;
            this.txtLowerWarnLimit.Name = "txtLowerWarnLimit";
            this.txtLowerWarnLimit.Size = new System.Drawing.Size(177, 20);
            this.txtLowerWarnLimit.TabIndex = 3;
            // 
            // lblUpperWarnLimit
            // 
            this.lblUpperWarnLimit.AutoSize = true;
            this.lblUpperWarnLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpperWarnLimit.Location = new System.Drawing.Point(15, 21);
            this.lblUpperWarnLimit.Name = "lblUpperWarnLimit";
            this.lblUpperWarnLimit.Size = new System.Drawing.Size(92, 13);
            this.lblUpperWarnLimit.TabIndex = 0;
            this.lblUpperWarnLimit.Text = "Upper Warn. Limit";
            // 
            // txtUpperWarnLimit
            // 
            this.txtUpperWarnLimit.Location = new System.Drawing.Point(120, 18);
            this.txtUpperWarnLimit.MaxLength = 25;
            this.txtUpperWarnLimit.Name = "txtUpperWarnLimit";
            this.txtUpperWarnLimit.Size = new System.Drawing.Size(177, 20);
            this.txtUpperWarnLimit.TabIndex = 1;
            // 
            // grpDateTime
            // 
            this.grpDateTime.Controls.Add(this.txtUpdateTime);
            this.grpDateTime.Controls.Add(this.txtCreateTime);
            this.grpDateTime.Controls.Add(this.txtUpdateUser);
            this.grpDateTime.Controls.Add(this.lblUpdate);
            this.grpDateTime.Controls.Add(this.txtCreateUser);
            this.grpDateTime.Controls.Add(this.lblCreate);
            this.grpDateTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDateTime.Location = new System.Drawing.Point(3, 335);
            this.grpDateTime.Name = "grpDateTime";
            this.grpDateTime.Size = new System.Drawing.Size(486, 70);
            this.grpDateTime.TabIndex = 3;
            this.grpDateTime.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(301, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(301, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
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
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
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
            // pnlSpecLimit
            // 
            this.pnlSpecLimit.Controls.Add(this.grpSpecLimit);
            this.pnlSpecLimit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpecLimit.Location = new System.Drawing.Point(3, 98);
            this.pnlSpecLimit.Name = "pnlSpecLimit";
            this.pnlSpecLimit.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlSpecLimit.Size = new System.Drawing.Size(486, 158);
            this.pnlSpecLimit.TabIndex = 1;
            // 
            // grpSpecLimit
            // 
            this.grpSpecLimit.Controls.Add(this.lblAttachDir);
            this.grpSpecLimit.Controls.Add(this.txtAttachDir);
            this.grpSpecLimit.Controls.Add(this.cdvTargetValue);
            this.grpSpecLimit.Controls.Add(this.cdvValidTable);
            this.grpSpecLimit.Controls.Add(this.lblValidTable);
            this.grpSpecLimit.Controls.Add(this.lblLowerSpecLimit);
            this.grpSpecLimit.Controls.Add(this.txtLowerSpecLimit);
            this.grpSpecLimit.Controls.Add(this.lblUpperSpecLimit);
            this.grpSpecLimit.Controls.Add(this.txtUpperSpecLimit);
            this.grpSpecLimit.Controls.Add(this.lblTargetValue);
            this.grpSpecLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSpecLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpSpecLimit.Location = new System.Drawing.Point(0, 4);
            this.grpSpecLimit.Name = "grpSpecLimit";
            this.grpSpecLimit.Size = new System.Drawing.Size(486, 154);
            this.grpSpecLimit.TabIndex = 0;
            this.grpSpecLimit.TabStop = false;
            this.grpSpecLimit.Text = "Default Specification Limit";
            // 
            // lblAttachDir
            // 
            this.lblAttachDir.AutoSize = true;
            this.lblAttachDir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachDir.Location = new System.Drawing.Point(15, 127);
            this.lblAttachDir.Name = "lblAttachDir";
            this.lblAttachDir.Size = new System.Drawing.Size(102, 13);
            this.lblAttachDir.TabIndex = 8;
            this.lblAttachDir.Text = "Attach File Directory";
            // 
            // txtAttachDir
            // 
            this.txtAttachDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttachDir.Location = new System.Drawing.Point(120, 124);
            this.txtAttachDir.MaxLength = 1000;
            this.txtAttachDir.Name = "txtAttachDir";
            this.txtAttachDir.ReadOnly = true;
            this.txtAttachDir.Size = new System.Drawing.Size(360, 20);
            this.txtAttachDir.TabIndex = 9;
            // 
            // cdvTargetValue
            // 
            this.cdvTargetValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTargetValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTargetValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTargetValue.BtnToolTipText = "";
            this.cdvTargetValue.DescText = "";
            this.cdvTargetValue.DisplaySubItemIndex = 0;
            this.cdvTargetValue.DisplayText = "";
            this.cdvTargetValue.Focusing = null;
            this.cdvTargetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTargetValue.Index = 0;
            this.cdvTargetValue.IsViewBtnImage = false;
            this.cdvTargetValue.Location = new System.Drawing.Point(120, 43);
            this.cdvTargetValue.MaxLength = 25;
            this.cdvTargetValue.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTargetValue.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTargetValue.Name = "cdvTargetValue";
            this.cdvTargetValue.ReadOnly = false;
            this.cdvTargetValue.SearchSubItemIndex = 0;
            this.cdvTargetValue.SelectedDescIndex = 0;
            this.cdvTargetValue.SelectedSubItemIndex = 0;
            this.cdvTargetValue.SelectionStart = 0;
            this.cdvTargetValue.Size = new System.Drawing.Size(177, 20);
            this.cdvTargetValue.SmallImageList = null;
            this.cdvTargetValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTargetValue.TabIndex = 3;
            this.cdvTargetValue.TextBoxToolTipText = "";
            this.cdvTargetValue.TextBoxWidth = 177;
            this.cdvTargetValue.VisibleButton = true;
            this.cdvTargetValue.VisibleColumnHeader = false;
            this.cdvTargetValue.VisibleDescription = false;
            this.cdvTargetValue.ButtonPress += new System.EventHandler(this.cdvTargetValue_ButtonPress);
            // 
            // cdvValidTable
            // 
            this.cdvValidTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValidTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValidTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValidTable.BtnToolTipText = "";
            this.cdvValidTable.DescText = "";
            this.cdvValidTable.DisplaySubItemIndex = 0;
            this.cdvValidTable.DisplayText = "";
            this.cdvValidTable.Focusing = null;
            this.cdvValidTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValidTable.Index = 0;
            this.cdvValidTable.IsViewBtnImage = false;
            this.cdvValidTable.Location = new System.Drawing.Point(120, 18);
            this.cdvValidTable.MaxLength = 20;
            this.cdvValidTable.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValidTable.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValidTable.Name = "cdvValidTable";
            this.cdvValidTable.ReadOnly = true;
            this.cdvValidTable.SearchSubItemIndex = 0;
            this.cdvValidTable.SelectedDescIndex = 0;
            this.cdvValidTable.SelectedSubItemIndex = 0;
            this.cdvValidTable.SelectionStart = 0;
            this.cdvValidTable.Size = new System.Drawing.Size(177, 20);
            this.cdvValidTable.SmallImageList = null;
            this.cdvValidTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValidTable.TabIndex = 1;
            this.cdvValidTable.TextBoxToolTipText = "";
            this.cdvValidTable.TextBoxWidth = 177;
            this.cdvValidTable.VisibleButton = true;
            this.cdvValidTable.VisibleColumnHeader = false;
            this.cdvValidTable.VisibleDescription = false;
            this.cdvValidTable.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvValidTable_SelectedItemChanged);
            this.cdvValidTable.ButtonPress += new System.EventHandler(this.cdvValidTable_ButtonPress);
            // 
            // lblValidTable
            // 
            this.lblValidTable.AutoSize = true;
            this.lblValidTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValidTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidTable.Location = new System.Drawing.Point(15, 22);
            this.lblValidTable.Name = "lblValidTable";
            this.lblValidTable.Size = new System.Drawing.Size(83, 13);
            this.lblValidTable.TabIndex = 0;
            this.lblValidTable.Text = "Validation Table";
            // 
            // lblLowerSpecLimit
            // 
            this.lblLowerSpecLimit.AutoSize = true;
            this.lblLowerSpecLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLowerSpecLimit.Location = new System.Drawing.Point(15, 103);
            this.lblLowerSpecLimit.Name = "lblLowerSpecLimit";
            this.lblLowerSpecLimit.Size = new System.Drawing.Size(91, 13);
            this.lblLowerSpecLimit.TabIndex = 6;
            this.lblLowerSpecLimit.Text = "Lower Spec. Limit";
            // 
            // txtLowerSpecLimit
            // 
            this.txtLowerSpecLimit.Location = new System.Drawing.Point(120, 100);
            this.txtLowerSpecLimit.MaxLength = 25;
            this.txtLowerSpecLimit.Name = "txtLowerSpecLimit";
            this.txtLowerSpecLimit.Size = new System.Drawing.Size(177, 20);
            this.txtLowerSpecLimit.TabIndex = 7;
            // 
            // lblUpperSpecLimit
            // 
            this.lblUpperSpecLimit.AutoSize = true;
            this.lblUpperSpecLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpperSpecLimit.Location = new System.Drawing.Point(15, 79);
            this.lblUpperSpecLimit.Name = "lblUpperSpecLimit";
            this.lblUpperSpecLimit.Size = new System.Drawing.Size(91, 13);
            this.lblUpperSpecLimit.TabIndex = 4;
            this.lblUpperSpecLimit.Text = "Upper Spec. Limit";
            // 
            // txtUpperSpecLimit
            // 
            this.txtUpperSpecLimit.Location = new System.Drawing.Point(120, 76);
            this.txtUpperSpecLimit.MaxLength = 25;
            this.txtUpperSpecLimit.Name = "txtUpperSpecLimit";
            this.txtUpperSpecLimit.Size = new System.Drawing.Size(177, 20);
            this.txtUpperSpecLimit.TabIndex = 5;
            // 
            // lblTargetValue
            // 
            this.lblTargetValue.AutoSize = true;
            this.lblTargetValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTargetValue.Location = new System.Drawing.Point(15, 47);
            this.lblTargetValue.Name = "lblTargetValue";
            this.lblTargetValue.Size = new System.Drawing.Size(68, 13);
            this.lblTargetValue.TabIndex = 2;
            this.lblTargetValue.Text = "Target Value";
            // 
            // grpCharacterSetup
            // 
            this.grpCharacterSetup.Controls.Add(this.cboCharType);
            this.grpCharacterSetup.Controls.Add(this.lblCharType);
            this.grpCharacterSetup.Controls.Add(this.cdvUnit);
            this.grpCharacterSetup.Controls.Add(this.lblUnit);
            this.grpCharacterSetup.Controls.Add(this.rbnNumber);
            this.grpCharacterSetup.Controls.Add(this.rbnAscii);
            this.grpCharacterSetup.Controls.Add(this.lblValueType);
            this.grpCharacterSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCharacterSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCharacterSetup.Location = new System.Drawing.Point(3, 0);
            this.grpCharacterSetup.Name = "grpCharacterSetup";
            this.grpCharacterSetup.Size = new System.Drawing.Size(486, 98);
            this.grpCharacterSetup.TabIndex = 0;
            this.grpCharacterSetup.TabStop = false;
            // 
            // cboCharType
            // 
            this.cboCharType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharType.FormattingEnabled = true;
            this.cboCharType.Items.AddRange(new object[] {
            "EDC Only",
            "Spec Only",
            "Both"});
            this.cboCharType.Location = new System.Drawing.Point(120, 66);
            this.cboCharType.Name = "cboCharType";
            this.cboCharType.Size = new System.Drawing.Size(177, 21);
            this.cboCharType.TabIndex = 6;
            this.cboCharType.SelectedIndexChanged += new System.EventHandler(this.cboCharType_SelectedIndexChanged);
            // 
            // lblCharType
            // 
            this.lblCharType.AutoSize = true;
            this.lblCharType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCharType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharType.Location = new System.Drawing.Point(15, 70);
            this.lblCharType.Name = "lblCharType";
            this.lblCharType.Size = new System.Drawing.Size(94, 13);
            this.lblCharType.TabIndex = 5;
            this.lblCharType.Text = "Character Type";
            // 
            // cdvUnit
            // 
            this.cdvUnit.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUnit.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUnit.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUnit.BtnToolTipText = "";
            this.cdvUnit.DescText = "";
            this.cdvUnit.DisplaySubItemIndex = 0;
            this.cdvUnit.DisplayText = "";
            this.cdvUnit.Focusing = null;
            this.cdvUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvUnit.Index = 0;
            this.cdvUnit.IsViewBtnImage = false;
            this.cdvUnit.Location = new System.Drawing.Point(120, 41);
            this.cdvUnit.MaxLength = 10;
            this.cdvUnit.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUnit.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUnit.Name = "cdvUnit";
            this.cdvUnit.ReadOnly = false;
            this.cdvUnit.SearchSubItemIndex = 0;
            this.cdvUnit.SelectedDescIndex = 0;
            this.cdvUnit.SelectedSubItemIndex = 0;
            this.cdvUnit.SelectionStart = 0;
            this.cdvUnit.Size = new System.Drawing.Size(177, 20);
            this.cdvUnit.SmallImageList = null;
            this.cdvUnit.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUnit.TabIndex = 4;
            this.cdvUnit.TextBoxToolTipText = "";
            this.cdvUnit.TextBoxWidth = 177;
            this.cdvUnit.VisibleButton = true;
            this.cdvUnit.VisibleColumnHeader = false;
            this.cdvUnit.VisibleDescription = false;
            this.cdvUnit.ButtonPress += new System.EventHandler(this.cdvUnit_ButtonPress);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.Location = new System.Drawing.Point(15, 45);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "Unit";
            // 
            // rbnNumber
            // 
            this.rbnNumber.AutoSize = true;
            this.rbnNumber.Checked = true;
            this.rbnNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnNumber.Location = new System.Drawing.Point(123, 19);
            this.rbnNumber.Name = "rbnNumber";
            this.rbnNumber.Size = new System.Drawing.Size(68, 18);
            this.rbnNumber.TabIndex = 1;
            this.rbnNumber.TabStop = true;
            this.rbnNumber.Text = "Number";
            this.rbnNumber.CheckedChanged += new System.EventHandler(this.ValueType_CheckedChanged);
            this.rbnNumber.Click += new System.EventHandler(this.rbnNumeric_Click);
            // 
            // rbnAscii
            // 
            this.rbnAscii.AutoSize = true;
            this.rbnAscii.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnAscii.Location = new System.Drawing.Point(221, 19);
            this.rbnAscii.Name = "rbnAscii";
            this.rbnAscii.Size = new System.Drawing.Size(53, 18);
            this.rbnAscii.TabIndex = 2;
            this.rbnAscii.Text = "Ascii";
            this.rbnAscii.CheckedChanged += new System.EventHandler(this.ValueType_CheckedChanged);
            this.rbnAscii.Click += new System.EventHandler(this.rbnNumeric_Click);
            // 
            // lblValueType
            // 
            this.lblValueType.AutoSize = true;
            this.lblValueType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValueType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueType.Location = new System.Drawing.Point(15, 22);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(71, 13);
            this.lblValueType.TabIndex = 0;
            this.lblValueType.Text = "Value Type";
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.grpGroup);
            this.tabGroup.Location = new System.Drawing.Point(4, 22);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tabGroup.Size = new System.Drawing.Size(492, 408);
            this.tabGroup.TabIndex = 1;
            this.tabGroup.Text = "Group Setup";
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.cdvGroup10);
            this.grpGroup.Controls.Add(this.cdvGroup9);
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
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpGroup.Location = new System.Drawing.Point(3, 0);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(486, 405);
            this.grpGroup.TabIndex = 1;
            this.grpGroup.TabStop = false;
            // 
            // cdvGroup10
            // 
            this.cdvGroup10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup10.BtnToolTipText = "";
            this.cdvGroup10.DescText = "";
            this.cdvGroup10.DisplaySubItemIndex = -1;
            this.cdvGroup10.DisplayText = "";
            this.cdvGroup10.Focusing = null;
            this.cdvGroup10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup10.Index = 9;
            this.cdvGroup10.IsViewBtnImage = false;
            this.cdvGroup10.Location = new System.Drawing.Point(172, 232);
            this.cdvGroup10.MaxLength = 30;
            this.cdvGroup10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.Name = "cdvGroup10";
            this.cdvGroup10.ReadOnly = false;
            this.cdvGroup10.SearchSubItemIndex = 0;
            this.cdvGroup10.SelectedDescIndex = -1;
            this.cdvGroup10.SelectedSubItemIndex = -1;
            this.cdvGroup10.SelectionStart = 0;
            this.cdvGroup10.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup10.SmallImageList = null;
            this.cdvGroup10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup10.TabIndex = 9;
            this.cdvGroup10.TextBoxToolTipText = "";
            this.cdvGroup10.TextBoxWidth = 200;
            this.cdvGroup10.VisibleButton = true;
            this.cdvGroup10.VisibleColumnHeader = false;
            this.cdvGroup10.VisibleDescription = false;
            this.cdvGroup10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup9
            // 
            this.cdvGroup9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup9.BtnToolTipText = "";
            this.cdvGroup9.DescText = "";
            this.cdvGroup9.DisplaySubItemIndex = -1;
            this.cdvGroup9.DisplayText = "";
            this.cdvGroup9.Focusing = null;
            this.cdvGroup9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup9.Index = 8;
            this.cdvGroup9.IsViewBtnImage = false;
            this.cdvGroup9.Location = new System.Drawing.Point(172, 208);
            this.cdvGroup9.MaxLength = 30;
            this.cdvGroup9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.Name = "cdvGroup9";
            this.cdvGroup9.ReadOnly = false;
            this.cdvGroup9.SearchSubItemIndex = 0;
            this.cdvGroup9.SelectedDescIndex = -1;
            this.cdvGroup9.SelectedSubItemIndex = -1;
            this.cdvGroup9.SelectionStart = 0;
            this.cdvGroup9.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup9.SmallImageList = null;
            this.cdvGroup9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup9.TabIndex = 8;
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
            this.cdvGroup8.DescText = "";
            this.cdvGroup8.DisplaySubItemIndex = -1;
            this.cdvGroup8.DisplayText = "";
            this.cdvGroup8.Focusing = null;
            this.cdvGroup8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup8.Index = 7;
            this.cdvGroup8.IsViewBtnImage = false;
            this.cdvGroup8.Location = new System.Drawing.Point(172, 184);
            this.cdvGroup8.MaxLength = 30;
            this.cdvGroup8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.Name = "cdvGroup8";
            this.cdvGroup8.ReadOnly = false;
            this.cdvGroup8.SearchSubItemIndex = 0;
            this.cdvGroup8.SelectedDescIndex = -1;
            this.cdvGroup8.SelectedSubItemIndex = -1;
            this.cdvGroup8.SelectionStart = 0;
            this.cdvGroup8.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup8.SmallImageList = null;
            this.cdvGroup8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup8.TabIndex = 7;
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
            this.cdvGroup7.DescText = "";
            this.cdvGroup7.DisplaySubItemIndex = -1;
            this.cdvGroup7.DisplayText = "";
            this.cdvGroup7.Focusing = null;
            this.cdvGroup7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup7.Index = 6;
            this.cdvGroup7.IsViewBtnImage = false;
            this.cdvGroup7.Location = new System.Drawing.Point(172, 160);
            this.cdvGroup7.MaxLength = 30;
            this.cdvGroup7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.Name = "cdvGroup7";
            this.cdvGroup7.ReadOnly = false;
            this.cdvGroup7.SearchSubItemIndex = 0;
            this.cdvGroup7.SelectedDescIndex = -1;
            this.cdvGroup7.SelectedSubItemIndex = -1;
            this.cdvGroup7.SelectionStart = 0;
            this.cdvGroup7.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup7.SmallImageList = null;
            this.cdvGroup7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup7.TabIndex = 6;
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
            this.cdvGroup6.DescText = "";
            this.cdvGroup6.DisplaySubItemIndex = -1;
            this.cdvGroup6.DisplayText = "";
            this.cdvGroup6.Focusing = null;
            this.cdvGroup6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup6.Index = 5;
            this.cdvGroup6.IsViewBtnImage = false;
            this.cdvGroup6.Location = new System.Drawing.Point(172, 136);
            this.cdvGroup6.MaxLength = 30;
            this.cdvGroup6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.Name = "cdvGroup6";
            this.cdvGroup6.ReadOnly = false;
            this.cdvGroup6.SearchSubItemIndex = 0;
            this.cdvGroup6.SelectedDescIndex = -1;
            this.cdvGroup6.SelectedSubItemIndex = -1;
            this.cdvGroup6.SelectionStart = 0;
            this.cdvGroup6.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup6.SmallImageList = null;
            this.cdvGroup6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup6.TabIndex = 5;
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
            this.cdvGroup5.DescText = "";
            this.cdvGroup5.DisplaySubItemIndex = -1;
            this.cdvGroup5.DisplayText = "";
            this.cdvGroup5.Focusing = null;
            this.cdvGroup5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup5.Index = 4;
            this.cdvGroup5.IsViewBtnImage = false;
            this.cdvGroup5.Location = new System.Drawing.Point(172, 112);
            this.cdvGroup5.MaxLength = 30;
            this.cdvGroup5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.Name = "cdvGroup5";
            this.cdvGroup5.ReadOnly = false;
            this.cdvGroup5.SearchSubItemIndex = 0;
            this.cdvGroup5.SelectedDescIndex = -1;
            this.cdvGroup5.SelectedSubItemIndex = -1;
            this.cdvGroup5.SelectionStart = 0;
            this.cdvGroup5.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup5.SmallImageList = null;
            this.cdvGroup5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup5.TabIndex = 4;
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
            this.cdvGroup4.DescText = "";
            this.cdvGroup4.DisplaySubItemIndex = -1;
            this.cdvGroup4.DisplayText = "";
            this.cdvGroup4.Focusing = null;
            this.cdvGroup4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup4.Index = 3;
            this.cdvGroup4.IsViewBtnImage = false;
            this.cdvGroup4.Location = new System.Drawing.Point(172, 88);
            this.cdvGroup4.MaxLength = 30;
            this.cdvGroup4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.Name = "cdvGroup4";
            this.cdvGroup4.ReadOnly = false;
            this.cdvGroup4.SearchSubItemIndex = 0;
            this.cdvGroup4.SelectedDescIndex = -1;
            this.cdvGroup4.SelectedSubItemIndex = -1;
            this.cdvGroup4.SelectionStart = 0;
            this.cdvGroup4.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup4.SmallImageList = null;
            this.cdvGroup4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup4.TabIndex = 3;
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
            this.cdvGroup3.DescText = "";
            this.cdvGroup3.DisplaySubItemIndex = -1;
            this.cdvGroup3.DisplayText = "";
            this.cdvGroup3.Focusing = null;
            this.cdvGroup3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup3.Index = 2;
            this.cdvGroup3.IsViewBtnImage = false;
            this.cdvGroup3.Location = new System.Drawing.Point(172, 64);
            this.cdvGroup3.MaxLength = 30;
            this.cdvGroup3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.Name = "cdvGroup3";
            this.cdvGroup3.ReadOnly = false;
            this.cdvGroup3.SearchSubItemIndex = 0;
            this.cdvGroup3.SelectedDescIndex = -1;
            this.cdvGroup3.SelectedSubItemIndex = -1;
            this.cdvGroup3.SelectionStart = 0;
            this.cdvGroup3.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup3.SmallImageList = null;
            this.cdvGroup3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup3.TabIndex = 2;
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
            this.cdvGroup2.DescText = "";
            this.cdvGroup2.DisplaySubItemIndex = -1;
            this.cdvGroup2.DisplayText = "";
            this.cdvGroup2.Focusing = null;
            this.cdvGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup2.Index = 1;
            this.cdvGroup2.IsViewBtnImage = false;
            this.cdvGroup2.Location = new System.Drawing.Point(172, 40);
            this.cdvGroup2.MaxLength = 30;
            this.cdvGroup2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.Name = "cdvGroup2";
            this.cdvGroup2.ReadOnly = false;
            this.cdvGroup2.SearchSubItemIndex = 0;
            this.cdvGroup2.SelectedDescIndex = -1;
            this.cdvGroup2.SelectedSubItemIndex = -1;
            this.cdvGroup2.SelectionStart = 0;
            this.cdvGroup2.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup2.SmallImageList = null;
            this.cdvGroup2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup2.TabIndex = 1;
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
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = false;
            this.cdvGroup1.SearchSubItemIndex = 0;
            this.cdvGroup1.SelectedDescIndex = -1;
            this.cdvGroup1.SelectedSubItemIndex = -1;
            this.cdvGroup1.SelectionStart = 0;
            this.cdvGroup1.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup1.SmallImageList = null;
            this.cdvGroup1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup1.TabIndex = 0;
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
            // tabCMF
            // 
            this.tabCMF.Controls.Add(this.grpCMF);
            this.tabCMF.Location = new System.Drawing.Point(4, 22);
            this.tabCMF.Name = "tabCMF";
            this.tabCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tabCMF.Size = new System.Drawing.Size(492, 408);
            this.tabCMF.TabIndex = 2;
            this.tabCMF.Text = "Customized Field";
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.lblCMF3);
            this.grpCMF.Controls.Add(this.lblCMF2);
            this.grpCMF.Controls.Add(this.lblCMF1);
            this.grpCMF.Controls.Add(this.cdvCMF5);
            this.grpCMF.Controls.Add(this.cdvCMF10);
            this.grpCMF.Controls.Add(this.cdvCMF9);
            this.grpCMF.Controls.Add(this.cdvCMF8);
            this.grpCMF.Controls.Add(this.cdvCMF7);
            this.grpCMF.Controls.Add(this.cdvCMF6);
            this.grpCMF.Controls.Add(this.cdvCMF4);
            this.grpCMF.Controls.Add(this.cdvCMF3);
            this.grpCMF.Controls.Add(this.cdvCMF2);
            this.grpCMF.Controls.Add(this.cdvCMF1);
            this.grpCMF.Controls.Add(this.lblCMF10);
            this.grpCMF.Controls.Add(this.lblCMF9);
            this.grpCMF.Controls.Add(this.lblCMF8);
            this.grpCMF.Controls.Add(this.lblCMF7);
            this.grpCMF.Controls.Add(this.lblCMF6);
            this.grpCMF.Controls.Add(this.lblCMF5);
            this.grpCMF.Controls.Add(this.lblCMF4);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpCMF.Location = new System.Drawing.Point(3, 0);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(486, 405);
            this.grpCMF.TabIndex = 1;
            this.grpCMF.TabStop = false;
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
            this.cdvCMF5.Index = 4;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(172, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SearchSubItemIndex = 0;
            this.cdvCMF5.SelectedDescIndex = -1;
            this.cdvCMF5.SelectedSubItemIndex = -1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 4;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.TextBoxWidth = 200;
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            this.cdvCMF5.VisibleDescription = false;
            this.cdvCMF5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF10.Index = 9;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(172, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SearchSubItemIndex = 0;
            this.cdvCMF10.SelectedDescIndex = -1;
            this.cdvCMF10.SelectedSubItemIndex = -1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 9;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.TextBoxWidth = 200;
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            this.cdvCMF10.VisibleDescription = false;
            this.cdvCMF10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF9.Index = 8;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(172, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SearchSubItemIndex = 0;
            this.cdvCMF9.SelectedDescIndex = -1;
            this.cdvCMF9.SelectedSubItemIndex = -1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 8;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.TextBoxWidth = 200;
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
            this.cdvCMF8.Index = 7;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(172, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SearchSubItemIndex = 0;
            this.cdvCMF8.SelectedDescIndex = -1;
            this.cdvCMF8.SelectedSubItemIndex = -1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 7;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.TextBoxWidth = 200;
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
            this.cdvCMF7.Index = 6;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(172, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SearchSubItemIndex = 0;
            this.cdvCMF7.SelectedDescIndex = -1;
            this.cdvCMF7.SelectedSubItemIndex = -1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 6;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.TextBoxWidth = 200;
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
            this.cdvCMF6.Index = 5;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(172, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SearchSubItemIndex = 0;
            this.cdvCMF6.SelectedDescIndex = -1;
            this.cdvCMF6.SelectedSubItemIndex = -1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 5;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.TextBoxWidth = 200;
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            this.cdvCMF6.VisibleDescription = false;
            this.cdvCMF6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF4.Index = 3;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(172, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SearchSubItemIndex = 0;
            this.cdvCMF4.SelectedDescIndex = -1;
            this.cdvCMF4.SelectedSubItemIndex = -1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 3;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.TextBoxWidth = 200;
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
            this.cdvCMF3.Index = 2;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(172, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SearchSubItemIndex = 0;
            this.cdvCMF3.SelectedDescIndex = -1;
            this.cdvCMF3.SelectedSubItemIndex = -1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 2;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.TextBoxWidth = 200;
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
            this.cdvCMF2.Index = 1;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(172, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SearchSubItemIndex = 0;
            this.cdvCMF2.SelectedDescIndex = -1;
            this.cdvCMF2.SelectedSubItemIndex = -1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 1;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.TextBoxWidth = 200;
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            this.cdvCMF2.VisibleDescription = false;
            this.cdvCMF2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            this.cdvCMF1.Location = new System.Drawing.Point(172, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SearchSubItemIndex = 0;
            this.cdvCMF1.SelectedDescIndex = -1;
            this.cdvCMF1.SelectedSubItemIndex = -1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 0;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.TextBoxWidth = 200;
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            this.cdvCMF1.VisibleDescription = false;
            this.cdvCMF1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCMF_TextBoxKeyPress);
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
            // frmEDCSetupCharacter
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmEDCSetupCharacter";
            this.Text = "Character Setup";
            this.Activated += new System.EventHandler(this.frmEDCSetupCharacter_Activated);
            this.Load += new System.EventHandler(this.frmEDCSetupCharacter_Load);
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
            this.grpCharacter.ResumeLayout(false);
            this.grpCharacter.PerformLayout();
            this.pnlTab.ResumeLayout(false);
            this.tabCharacter.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.pnlWarnLimit.ResumeLayout(false);
            this.grpWarnLimit.ResumeLayout(false);
            this.grpWarnLimit.PerformLayout();
            this.grpDateTime.ResumeLayout(false);
            this.grpDateTime.PerformLayout();
            this.pnlSpecLimit.ResumeLayout(false);
            this.grpSpecLimit.ResumeLayout(false);
            this.grpSpecLimit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTargetValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValidTable)).EndInit();
            this.grpCharacterSetup.ResumeLayout(false);
            this.grpCharacterSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUnit)).EndInit();
            this.tabGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            this.tabCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCMF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Variable Definition"

        bool LoadFlag;

        #endregion

        #region " Function Definition"

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
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_Character":

                        if (txtCharacter.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtCharacter.Focus();
                            return false;
                        }

                        if (cboCharType.SelectedIndex < 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            cboCharType.Focus();
                            return false;
                        }

                        if (this.rbnNumber.Checked == true)
                        {
                            // Target Value
                            if (MPCF.Trim(this.cdvTargetValue.Text) != "")
                            {
                                if (MPCF.CheckNumeric(this.cdvTargetValue.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    this.cdvTargetValue.GetTextBox.Focus();
                                    this.cdvTargetValue.GetTextBox.SelectAll();
                                    return false;
                                }
                            }
                            // Upper Spec Limit
                            if (MPCF.Trim(this.txtUpperSpecLimit.Text) != "")
                            {
                                if (MPCF.CheckNumeric(this.txtUpperSpecLimit.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    this.txtUpperSpecLimit.Focus();
                                    this.txtUpperSpecLimit.SelectAll();
                                    return false;
                                }
                            }
                            // Lower Spec Limit
                            if (MPCF.Trim(this.txtLowerSpecLimit.Text) != "")
                            {
                                if (MPCF.CheckNumeric(this.txtLowerSpecLimit.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    this.txtLowerSpecLimit.Focus();
                                    this.txtLowerSpecLimit.SelectAll();
                                    return false;
                                }
                            }
                            // Upper Waning Limit
                            if (MPCF.Trim(this.txtUpperWarnLimit.Text) != "")
                            {
                                if (MPCF.CheckNumeric(this.txtUpperWarnLimit.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    this.txtUpperWarnLimit.Focus();
                                    this.txtUpperWarnLimit.SelectAll();
                                    return false;
                                }
                            }
                            // Lower Waning Limit
                            if (MPCF.Trim(this.txtLowerWarnLimit.Text) != "")
                            {
                                if (MPCF.CheckNumeric(this.txtLowerWarnLimit.Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    this.txtLowerWarnLimit.Focus();
                                    this.txtLowerWarnLimit.SelectAll();
                                    return false;
                                }
                            }
                        }

                        switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                        {
                            case MPGC.MP_STEP_CREATE:
                                if (this.rbnAscii.Checked == false && this.rbnNumber.Checked == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    this.tabCharacter.SelectedIndex = 0;
                                    rbnAscii.Focus();
                                    return false;
                                }
                                if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                                {
                                    return false;
                                }
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                                {
                                    return false;
                                }
                                break;

                            case MPGC.MP_STEP_UPDATE:

                                if (this.rbnAscii.Checked == false && this.rbnNumber.Checked == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    this.tabCharacter.SelectedIndex = 0;
                                    rbnAscii.Focus();
                                    return false;
                                }
                                if (MPCR.CheckGRPCMFValue("lblGroup", "cdvGroup", grpGroup) == false)
                                {
                                    return false;
                                }
                                if (MPCR.CheckGRPCMFValue("lblCMF", "cdvCMF", grpCMF) == false)
                                {
                                    return false;
                                }
                                break;
                            case MPGC.MP_STEP_DELETE:

                                return true;

                        }
                        break;
                    case "View_Character":

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

        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //

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
                    MPCF.ClearList(lisCharacter, true);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }


        //
        // View_Character()
        //       - View Character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Character()
        {
            TRSNode in_node = new TRSNode("VIEW_CHARACTER_IN");
            TRSNode out_node = new TRSNode("VIEW_CHARACTER_OUT");

            try
            {
                ClearData('1');
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHAR_ID", lisCharacter.SelectedItems[0].Text);

                if (MPCR.CallService("EDC", "EDC_View_Character", in_node, ref out_node) == false)
                {
                    return false;
                }

                //General
                txtCharacter.Text = MPCF.Trim(out_node.GetString("CHAR_ID"));
                txtCharacterDesc.Text = MPCF.Trim(out_node.GetString("CHAR_DESC"));
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                //Check Value Type
                rbnNumber.Checked = (MPCF.Trim(out_node.GetChar("VALUE_TYPE")) == "N") ? true : false;
                rbnAscii.Checked = (MPCF.Trim(out_node.GetChar("VALUE_TYPE")) == "A") ? true : false;

                //Group Setup
                cdvGroup1.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_1"));
                cdvGroup2.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_2"));
                cdvGroup3.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_3"));
                cdvGroup4.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_4"));
                cdvGroup5.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_5"));
                cdvGroup6.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_6"));
                cdvGroup7.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_7"));
                cdvGroup8.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_8"));
                cdvGroup9.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_9"));
                cdvGroup10.Text = MPCF.Trim(out_node.GetString("CHAR_GRP_10"));

                //Customized Field
                cdvCMF1.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_1"));
                cdvCMF2.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_2"));
                cdvCMF3.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_3"));
                cdvCMF4.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_4"));
                cdvCMF5.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_5"));
                cdvCMF6.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_6"));
                cdvCMF7.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_7"));
                cdvCMF8.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_8"));
                cdvCMF9.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_9"));
                cdvCMF10.Text = MPCF.Trim(out_node.GetString("CHAR_CMF_10"));

                //Unit, Specification Limit and Warning Limit - Added by LAVERWON (08/01/11)
                cdvUnit.Text = MPCF.Trim(out_node.GetString("UNIT"));
                cdvTargetValue.Text = MPCF.Trim(out_node.GetString("TARGET_VALUE"));
                txtUpperSpecLimit.Text = MPCF.Trim(out_node.GetString("UPPER_SPEC_LIMIT"));
                txtLowerSpecLimit.Text = MPCF.Trim(out_node.GetString("LOWER_SPEC_LIMIT"));
                txtUpperWarnLimit.Text = MPCF.Trim(out_node.GetString("UPPER_WARN_LIMIT"));
                txtLowerWarnLimit.Text = MPCF.Trim(out_node.GetString("LOWER_WARN_LIMIT"));

                cboCharType.SelectedIndex = -1;
                if (out_node.GetChar("CHAR_TYPE") == 'E')
                {
                    cboCharType.SelectedIndex = 0;
                }
                else if (out_node.GetChar("CHAR_TYPE") == 'S')
                {
                    cboCharType.SelectedIndex = 1;
                }
                else if (out_node.GetChar("CHAR_TYPE") == 'B')
                {
                    cboCharType.SelectedIndex = 2;
                }

                cdvValidTable.Text = out_node.GetString("VALID_TABLE");
                /* 2013.06.12. Aiden. Character 의 SPEC File Attach 경로를 추가 */
                txtAttachDir.Text = out_node.GetString("ATTACH_FILE_DIR");

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        //
        // Update_Character()
        //       - Create/Update/Delete Character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_Character(char ProcStep)
        {

            int idx;
            ListViewItem itm;

            TRSNode in_node = new TRSNode("UPDATE_CHARACTER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("CHAR_ID", MPCF.Trim(txtCharacter.Text));
                in_node.AddString("CHAR_DESC", MPCF.Trim(txtCharacterDesc.Text));

                if (rbnNumber.Checked == true)
                {
                    in_node.AddChar("VALUE_TYPE", 'N');
                }
                if (rbnAscii.Checked == true)
                {
                    in_node.AddChar("VALUE_TYPE", 'A');
                }

                in_node.AddString("CHAR_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("CHAR_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("CHAR_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("CHAR_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("CHAR_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("CHAR_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("CHAR_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("CHAR_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("CHAR_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("CHAR_GRP_10", MPCF.Trim(cdvGroup10.Text));

                in_node.AddString("CHAR_CMF_1", MPCF.Trim(cdvCMF1.Text));
                in_node.AddString("CHAR_CMF_2", MPCF.Trim(cdvCMF2.Text));
                in_node.AddString("CHAR_CMF_3", MPCF.Trim(cdvCMF3.Text));
                in_node.AddString("CHAR_CMF_4", MPCF.Trim(cdvCMF4.Text));
                in_node.AddString("CHAR_CMF_5", MPCF.Trim(cdvCMF5.Text));
                in_node.AddString("CHAR_CMF_6", MPCF.Trim(cdvCMF6.Text));
                in_node.AddString("CHAR_CMF_7", MPCF.Trim(cdvCMF7.Text));
                in_node.AddString("CHAR_CMF_8", MPCF.Trim(cdvCMF8.Text));
                in_node.AddString("CHAR_CMF_9", MPCF.Trim(cdvCMF9.Text));
                in_node.AddString("CHAR_CMF_10", MPCF.Trim(cdvCMF10.Text));

                //Unit, Specification Limit and Warning Limit - Added by LAVERWON (08/01/11)
                in_node.AddString("UNIT", MPCF.Trim(this.cdvUnit.Text));
                in_node.AddString("TARGET_VALUE", MPCF.Trim(this.cdvTargetValue.Text));
                in_node.AddString("UPPER_SPEC_LIMIT", MPCF.Trim(this.txtUpperSpecLimit.Text));
                in_node.AddString("LOWER_SPEC_LIMIT", MPCF.Trim(this.txtLowerSpecLimit.Text));
                in_node.AddString("UPPER_WARN_LIMIT", MPCF.Trim(this.txtUpperWarnLimit.Text));
                in_node.AddString("LOWER_WARN_LIMIT", MPCF.Trim(this.txtLowerWarnLimit.Text));

                switch(cboCharType.SelectedIndex)
                {
                    case 0: in_node.AddChar("CHAR_TYPE", 'E'); break;
                    case 1: in_node.AddChar("CHAR_TYPE", 'S'); break;
                    case 2: in_node.AddChar("CHAR_TYPE", 'B'); break;
                }
                in_node.AddString("VALID_TABLE", cdvValidTable.Text);
                /* 2013.06.12. Aiden. Character 의 SPEC File Attach 경로를 추가 */
                in_node.AddString("ATTACH_FILE_DIR", txtAttachDir.Text);
                

                if (MPCR.CallService("EDC", "EDC_Update_Character", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisCharacter.Items.Add(txtCharacter.Text, (int)SMALLICON_INDEX.IDX_CHARACTER);
                        itm.SubItems.Add(txtCharacterDesc.Text);
                        itm.Selected = true;
                        lisCharacter.Sorting = SortOrder.Ascending;
                        lisCharacter.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisCharacter, MPCF.Trim(txtCharacter.Text), false) == true)
                        {
                            lisCharacter.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtCharacterDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisCharacter, MPCF.Trim(txtCharacter.Text), false);
                        if (idx != -1)
                        {
                            lisCharacter.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisCharacter.Items.Count);
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
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        private void SetGroupCmfItem()
        {

            string[] sGrpTableName = new string[10];

            try
            {

                sGrpTableName[0] = MPGC.MP_GCM_CHAR_GRP_1;
                sGrpTableName[1] = MPGC.MP_GCM_CHAR_GRP_2;
                sGrpTableName[2] = MPGC.MP_GCM_CHAR_GRP_3;
                sGrpTableName[3] = MPGC.MP_GCM_CHAR_GRP_4;
                sGrpTableName[4] = MPGC.MP_GCM_CHAR_GRP_5;
                sGrpTableName[5] = MPGC.MP_GCM_CHAR_GRP_6;
                sGrpTableName[6] = MPGC.MP_GCM_CHAR_GRP_7;
                sGrpTableName[7] = MPGC.MP_GCM_CHAR_GRP_8;
                sGrpTableName[8] = MPGC.MP_GCM_CHAR_GRP_9;
                sGrpTableName[9] = MPGC.MP_GCM_CHAR_GRP_10;

                MPCR.SetGRPItem(MPGC.MP_GRP_CHARACTER, "lblGroup", "cdvGroup", grpGroup, sGrpTableName);
                MPCR.SetCMFItem(MPGC.MP_CMF_CHARACTER, "lblCMF", "cdvCMF", grpCMF);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.lisCharacter;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        //
        // SetEnableLimit()
        //       - Specification and warning limit set enable or disable by value type
        // Return Value
        //       -
        // Arguments
        //       - bool bNumericType : numeric type or ascii type
        //
        public void SetEnableLimit(bool bNumericType)
        {
            try
            {
                if (bNumericType == true)
                {
                    this.txtUpperSpecLimit.ReadOnly = false;
                    this.txtLowerSpecLimit.ReadOnly = false;
                    this.txtUpperWarnLimit.ReadOnly = false;
                    this.txtLowerWarnLimit.ReadOnly = false;
                }
                else
                {
                    this.txtUpperSpecLimit.Text = "";
                    this.txtLowerSpecLimit.Text = "";
                    this.txtUpperWarnLimit.Text = "";
                    this.txtLowerWarnLimit.Text = "";

                    this.txtUpperSpecLimit.ReadOnly = true;
                    this.txtLowerSpecLimit.ReadOnly = true;
                    this.txtUpperWarnLimit.ReadOnly = true;
                    this.txtLowerWarnLimit.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        #endregion

        private void frmEDCSetupCharacter_Load(object sender, System.EventArgs e)
        {

            try
            {

                MPCF.InitListView(lisCharacter);
                MPCF.FieldVisible(grpGroup, false);
                MPCF.FieldVisible(grpCMF, false);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void frmEDCSetupCharacter_Activated(object sender, System.EventArgs e)
        {

            try
            {

                if (LoadFlag == false)
                {
                    lblDataCount.Text = "";
                    SetGroupCmfItem();

                    if (EDCLIST.ViewEDCCharacterList(lisCharacter, '1', ' ') == true)
                    {
                        lblDataCount.Text = MPCF.Trim(lisCharacter.Items.Count);
                        if (lisCharacter.Items.Count > 0)
                        {
                            lisCharacter.Items[0].Selected = true;
                        }
                    }
                    else
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

        private void rbnNumeric_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                rbnNumber.Checked = false;
                rbnAscii.Checked = false;
                ((RadioButton)sender).Checked = true;
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
                if (CheckCondition("Update_Character", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Character(MPGC.MP_STEP_UPDATE) == false)
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
                if (CheckCondition("Update_Character", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Character(MPGC.MP_STEP_DELETE) == false)
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

        private void lisCharacter_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            try
            {
                MPCF.FieldClear(this.pnlRight);
                if (lisCharacter.SelectedItems.Count > 0)
                {
                    txtCharacter.Text = lisCharacter.SelectedItems[0].Text;
                    View_Character();
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
                if (CheckCondition("Update_Character", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Character(MPGC.MP_STEP_CREATE) == false)
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

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                lblDataCount.Text = "";
                if (EDCLIST.ViewEDCCharacterList(lisCharacter, '1', ' ') == false)
                {
                    return;
                }
                lblDataCount.Text = MPCF.Trim(lisCharacter.Items.Count);
                if (lisCharacter.Items.Count > 0)
                {
                    MPCF.FindListItem(lisCharacter, txtCharacter.Text, false);
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
                MPCF.ExportToExcel(lisCharacter, this.Text, "");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvGrpCmf_ButtonPress(object sender, System.EventArgs e)
        {

            try
            {
                MPCR.ProcGRPCMFButtonPress(sender);
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

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisCharacter, txtFind.Text, true, false);

        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisCharacter, txtFind.Text, 0, true, false);

        }

        private void ValueType_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                SetEnableLimit(this.rbnNumber.Checked);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvUnit_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                // GCM Table Unit List
                cdvUnit.Init();
                MPCF.InitListView(cdvUnit.GetListView);
                cdvUnit.Columns.Add("Unit", 50, HorizontalAlignment.Left);
                cdvUnit.Columns.Add("Description", 100, HorizontalAlignment.Left);
                if (BASLIST.ViewGCMDataList(cdvUnit.GetListView, '1', MPGC.MP_EDC_UNIT_TABLE) == false)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvValidTable_ButtonPress(object sender, EventArgs e)
        {
            cdvValidTable.Init();
            MPCF.InitListView(cdvValidTable.GetListView);
            cdvValidTable.Columns.Add("GCM Table", 50, HorizontalAlignment.Left);
            cdvValidTable.Columns.Add("Description", 100, HorizontalAlignment.Left);
            if (BASLIST.ViewGCMTableList(cdvValidTable.GetListView, '1', true) == false)
            {
                cdvValidTable.IsPopup = false;
                return;
            }
            cdvValidTable.InsertEmptyRow(0, 1);
        }

        private void cdvValidTable_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvTargetValue.Text = "";

            if (MPCF.Trim(cdvValidTable.Text) == "")
            {
                cdvTargetValue.VisibleButton = false;
                cdvTargetValue.ReadOnly = false;
            }
            else
            {
                cdvTargetValue.VisibleButton = true;
                cdvTargetValue.ReadOnly = true;
            }
        }

        private void cdvTargetValue_ButtonPress(object sender, EventArgs e)
        {
            cdvTargetValue.Init();
            MPCF.InitListView(cdvTargetValue.GetListView);
            cdvTargetValue.Columns.Add("Target Value", 50, HorizontalAlignment.Left);
            cdvTargetValue.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvTargetValue.SelectedSubItemIndex = 0;

            if (BASLIST.ViewGCMDataList(cdvTargetValue.GetListView, '1', cdvValidTable.Text) == false)
            {
                cdvTargetValue.IsPopup = false;
                return;
            }
            cdvTargetValue.InsertEmptyRow(0, 1);
        }

        /* 2013.06.12. Aiden. Character 의 SPEC File Attach 경로를 추가 */
        private void cboCharType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCharType.SelectedIndex == 0)
            {
                txtAttachDir.Text = "";
                txtAttachDir.ReadOnly = true;
            }
            else
            {
                txtAttachDir.ReadOnly = false;
            }
        }


#endif // _EDC

    }
}
