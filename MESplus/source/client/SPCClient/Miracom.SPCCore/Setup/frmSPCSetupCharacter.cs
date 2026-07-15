
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.H101Core;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.UI.Controls;

//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCSetupCharacter.vb
//   Description :
//
//   SPC Version : 1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the Conditions before Transaction
//       - SetGroupCmfItem() : CMF and Group Definition
//       - View_Character() : View Character
//       - Update_Character() : Create/Update/Delete Character
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-04-27 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCSetupCharacter : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCSetupCharacter()
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
        



        public System.Windows.Forms.Panel pnlRight;
        public System.Windows.Forms.Panel pnlLeft;
        public System.Windows.Forms.Panel pnlBottom;
        public System.Windows.Forms.Panel pnlFind;
        public System.Windows.Forms.Button btnExcel;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnNext;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtFind;
        public System.Windows.Forms.Button btnCreate;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnClose;
        internal Miracom.UI.Controls.MCListView.MCListView lisCharacter;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.GroupBox grpCharacter;
        internal System.Windows.Forms.Label lblDesc;
        internal System.Windows.Forms.Label lblCharacter;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCharacterDesc;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCharacter;
        internal System.Windows.Forms.Panel pnlTab;
        internal System.Windows.Forms.TabControl tabCharacter;
        internal System.Windows.Forms.TabPage tabGeneral;
        internal System.Windows.Forms.GroupBox grpDateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUpdateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCreateTime;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtUpdateUser;
        internal System.Windows.Forms.Label lblUpdate;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtCreateUser;
        internal System.Windows.Forms.Label lblCreate;
        internal System.Windows.Forms.GroupBox grpCharacterSetup;
        internal System.Windows.Forms.RadioButton rbnNumber;
        internal System.Windows.Forms.RadioButton rbnAscii;
        internal System.Windows.Forms.Label lblValueType;
        internal System.Windows.Forms.TabPage tabGroup;
        internal System.Windows.Forms.GroupBox grpGroup;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup10;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup9;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup8;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup7;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup6;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup5;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup4;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup3;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup2;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup1;
        internal System.Windows.Forms.Label lblGroup10;
        internal System.Windows.Forms.Label lblGroup9;
        internal System.Windows.Forms.Label lblGroup8;
        internal System.Windows.Forms.Label lblGroup7;
        internal System.Windows.Forms.Label lblGroup6;
        internal System.Windows.Forms.Label lblGroup5;
        internal System.Windows.Forms.Label lblGroup4;
        internal System.Windows.Forms.Label lblGroup3;
        internal System.Windows.Forms.Label lblGroup2;
        internal System.Windows.Forms.Label lblGroup1;
        internal System.Windows.Forms.TabPage tabCMF;
        internal System.Windows.Forms.GroupBox grpCMF;
        internal System.Windows.Forms.Label lblCMF3;
        internal System.Windows.Forms.Label lblCMF2;
        internal System.Windows.Forms.Label lblCMF1;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF5;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF10;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF9;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF8;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF7;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF6;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF4;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF3;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF2;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvCMF1;
        internal System.Windows.Forms.Label lblCMF10;
        internal System.Windows.Forms.Label lblCMF9;
        internal System.Windows.Forms.Label lblCMF8;
        internal System.Windows.Forms.Label lblCMF7;
        internal System.Windows.Forms.Label lblCMF6;
        internal System.Windows.Forms.Label lblCMF5;
        internal System.Windows.Forms.Label lblCMF4;
        internal System.Windows.Forms.Splitter splMain;
        public System.Windows.Forms.Label lblDataCount;
        public System.Windows.Forms.Label lblDataCountBack;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSPCSetupCharacter));
            this.pnlRight = new System.Windows.Forms.Panel();
            base.Load += new System.EventHandler(frmSPCSetupCharacter_Load);
            base.Activated += new System.EventHandler(frmSPCSetupCharacter_Activated);
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabCharacter = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.grpDateTime = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtCreateTime = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtUpdateUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblCreate = new System.Windows.Forms.Label();
            this.grpCharacterSetup = new System.Windows.Forms.GroupBox();
            this.rbnNumber = new System.Windows.Forms.RadioButton();
            this.rbnNumber.Click += new System.EventHandler(rbnNumeric_Click);
            this.rbnAscii = new System.Windows.Forms.RadioButton();
            this.rbnAscii.Click += new System.EventHandler(rbnNumeric_Click);
            this.lblValueType = new System.Windows.Forms.Label();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup10.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvGroup9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup9.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvGroup8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup8.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvGroup7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup7.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvGroup6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup6.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvGroup5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup5.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvGroup4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup4.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvGroup3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup3.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvGroup2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup2.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvGroup1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup1.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
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
            this.cdvCMF5.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF5.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.cdvCMF10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF10.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF10.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.cdvCMF9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF9.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF9.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.cdvCMF8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF8.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF8.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.cdvCMF7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF7.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF7.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.cdvCMF6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF6.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF6.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.cdvCMF4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF4.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF4.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.cdvCMF3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF3.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF3.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.cdvCMF2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF2.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF2.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.cdvCMF1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvCMF1.ButtonPress += new System.EventHandler(cdvGrpCmf_ButtonPress);
            this.cdvCMF1.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(cdvCMF_TextBoxKeyPress);
            this.lblCMF10 = new System.Windows.Forms.Label();
            this.lblCMF9 = new System.Windows.Forms.Label();
            this.lblCMF8 = new System.Windows.Forms.Label();
            this.lblCMF7 = new System.Windows.Forms.Label();
            this.lblCMF6 = new System.Windows.Forms.Label();
            this.lblCMF5 = new System.Windows.Forms.Label();
            this.lblCMF4 = new System.Windows.Forms.Label();
            this.grpCharacter = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblCharacter = new System.Windows.Forms.Label();
            this.txtCharacterDesc = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtCharacter = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lisCharacter = new Miracom.UI.Controls.MCListView.MCListView();
            this.lisCharacter.SelectedIndexChanged += new System.EventHandler(lisCharacter_SelectedIndexChanged);
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlFind = new System.Windows.Forms.Panel();
            this.lblDataCount = new System.Windows.Forms.Label();
            this.lblDataCountBack = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnExcel.Click += new System.EventHandler(btnExcel_Click);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefresh.Click += new System.EventHandler(btnRefresh_Click);
            this.btnNext = new System.Windows.Forms.Button();
            this.btnNext.Click += new System.EventHandler(btnNext_Click);
            this.txtFind = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtFind.TextChanged += new System.EventHandler(txtFind_TextChanged);
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCreate.Click += new System.EventHandler(btnCreate_Click);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelete.Click += new System.EventHandler(btnDelete_Click);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnUpdate.Click += new System.EventHandler(btnUpdate_Click);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClose.Click += new System.EventHandler(btnClose_Click);
            this.splMain = new System.Windows.Forms.Splitter();
            this.pnlRight.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabCharacter.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.grpDateTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.txtUpdateTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.txtCreateTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.txtUpdateUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.txtCreateUser).BeginInit();
            this.grpCharacterSetup.SuspendLayout();
            this.tabGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup10).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup9).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup8).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup7).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup6).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup5).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup4).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup3).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup2).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup1).BeginInit();
            this.tabCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF5).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF10).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF9).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF8).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF7).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF6).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF4).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF3).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF2).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF1).BeginInit();
            this.grpCharacter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.txtCharacterDesc).BeginInit();
            ((System.ComponentModel.ISupportInitialize) this.txtCharacter).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) this.txtFind).BeginInit();
            this.SuspendLayout();
            //
            //pnlRight
            //
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.grpCharacter);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.DockPadding.Bottom = 3;
            this.pnlRight.DockPadding.Left = 3;
            this.pnlRight.DockPadding.Top = 3;
            this.pnlRight.Location = new System.Drawing.Point(232, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(510, 506);
            this.pnlRight.TabIndex = 2;
            //
            //pnlTab
            //
            this.pnlTab.Controls.Add(this.tabCharacter);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.DockPadding.Top = 5;
            this.pnlTab.Location = new System.Drawing.Point(3, 74);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Size = new System.Drawing.Size(507, 429);
            this.pnlTab.TabIndex = 1;
            //
            //tabCharacter
            //
            this.tabCharacter.Controls.Add(this.tabGeneral);
            this.tabCharacter.Controls.Add(this.tabGroup);
            this.tabCharacter.Controls.Add(this.tabCMF);
            this.tabCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCharacter.ItemSize = new System.Drawing.Size(60, 18);
            this.tabCharacter.Location = new System.Drawing.Point(0, 5);
            this.tabCharacter.Name = "tabCharacter";
            this.tabCharacter.SelectedIndex = 0;
            this.tabCharacter.Size = new System.Drawing.Size(507, 424);
            this.tabCharacter.TabIndex = 0;
            //
            //tabGeneral
            //
            this.tabGeneral.Controls.Add(this.grpDateTime);
            this.tabGeneral.Controls.Add(this.grpCharacterSetup);
            this.tabGeneral.DockPadding.Bottom = 3;
            this.tabGeneral.DockPadding.Left = 3;
            this.tabGeneral.DockPadding.Right = 3;
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(499, 398);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            //
            //grpDateTime
            //
            this.grpDateTime.Controls.Add(this.txtUpdateTime);
            this.grpDateTime.Controls.Add(this.txtCreateTime);
            this.grpDateTime.Controls.Add(this.txtUpdateUser);
            this.grpDateTime.Controls.Add(this.lblUpdate);
            this.grpDateTime.Controls.Add(this.txtCreateUser);
            this.grpDateTime.Controls.Add(this.lblCreate);
            this.grpDateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDateTime.Location = new System.Drawing.Point(3, 47);
            this.grpDateTime.Name = "grpDateTime";
            this.grpDateTime.Size = new System.Drawing.Size(493, 70);
            this.grpDateTime.TabIndex = 1;
            this.grpDateTime.TabStop = false;
            //
            //txtUpdateTime
            //
            this.txtUpdateTime.Location = new System.Drawing.Point(306, 40);
            this.txtUpdateTime.MaxLength = 20;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 21);
            this.txtUpdateTime.TabIndex = 3;
            //
            //txtCreateTime
            //
            this.txtCreateTime.Location = new System.Drawing.Point(306, 16);
            this.txtCreateTime.MaxLength = 20;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 21);
            this.txtCreateTime.TabIndex = 1;
            //
            //txtUpdateUser
            //
            this.txtUpdateUser.Location = new System.Drawing.Point(126, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 21);
            this.txtUpdateUser.TabIndex = 2;
            //
            //lblUpdate
            //
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(10, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(100, 14);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //txtCreateUser
            //
            this.txtCreateUser.Location = new System.Drawing.Point(126, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 21);
            this.txtCreateUser.TabIndex = 0;
            //
            //lblCreate
            //
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(10, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(100, 14);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            //grpCharacterSetup
            //
            this.grpCharacterSetup.Controls.Add(this.rbnNumber);
            this.grpCharacterSetup.Controls.Add(this.rbnAscii);
            this.grpCharacterSetup.Controls.Add(this.lblValueType);
            this.grpCharacterSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCharacterSetup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCharacterSetup.Location = new System.Drawing.Point(3, 0);
            this.grpCharacterSetup.Name = "grpCharacterSetup";
            this.grpCharacterSetup.Size = new System.Drawing.Size(493, 47);
            this.grpCharacterSetup.TabIndex = 0;
            this.grpCharacterSetup.TabStop = false;
            //
            //rbnNumber
            //
            this.rbnNumber.Checked = true;
            this.rbnNumber.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnNumber.Location = new System.Drawing.Point(187, 19);
            this.rbnNumber.Name = "rbnNumber";
            this.rbnNumber.Size = new System.Drawing.Size(76, 14);
            this.rbnNumber.TabIndex = 0;
            this.rbnNumber.TabStop = true;
            this.rbnNumber.Text = "Number";
            //
            //rbnAscii
            //
            this.rbnAscii.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnAscii.Location = new System.Drawing.Point(357, 19);
            this.rbnAscii.Name = "rbnAscii";
            this.rbnAscii.Size = new System.Drawing.Size(76, 14);
            this.rbnAscii.TabIndex = 1;
            this.rbnAscii.TabStop = true;
            this.rbnAscii.Text = "Ascii";
            //
            //lblValueType
            //
            this.lblValueType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValueType.Location = new System.Drawing.Point(10, 19);
            this.lblValueType.Name = "lblValueType";
            this.lblValueType.Size = new System.Drawing.Size(68, 14);
            this.lblValueType.TabIndex = 0;
            this.lblValueType.Text = "Value Type";
            //
            //tabGroup
            //
            this.tabGroup.Controls.Add(this.grpGroup);
            this.tabGroup.DockPadding.Bottom = 3;
            this.tabGroup.DockPadding.Left = 3;
            this.tabGroup.DockPadding.Right = 3;
            this.tabGroup.Location = new System.Drawing.Point(4, 22);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Size = new System.Drawing.Size(499, 398);
            this.tabGroup.TabIndex = 1;
            this.tabGroup.Text = "Group Setup";
            this.tabGroup.Visible = false;
            //
            //grpGroup
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
            this.grpGroup.Size = new System.Drawing.Size(493, 395);
            this.grpGroup.TabIndex = 1;
            this.grpGroup.TabStop = false;
            //
            //cdvGroup10
            //
            this.cdvGroup10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup10.BtnToolTipText = "";
            this.cdvGroup10.Focusing = null;
            this.cdvGroup10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup10.Index = 9;
            this.cdvGroup10.IsViewBtnImage = false;
            this.cdvGroup10.Location = new System.Drawing.Point(172, 232);
            this.cdvGroup10.MaxLength = 20;
            this.cdvGroup10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.Name = "cdvGroup10";
            this.cdvGroup10.ReadOnly = false;
            this.cdvGroup10.SelectedSubItemIndex = - 1;
            this.cdvGroup10.SelectionStart = 0;
            this.cdvGroup10.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup10.SmallImageList = null;
            this.cdvGroup10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup10.TabIndex = 9;
            this.cdvGroup10.TextBoxToolTipText = "";
            this.cdvGroup10.VisibleButton = true;
            this.cdvGroup10.VisibleColumnHeader = false;
            //
            //cdvGroup9
            //
            this.cdvGroup9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup9.BtnToolTipText = "";
            this.cdvGroup9.Focusing = null;
            this.cdvGroup9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup9.Index = 8;
            this.cdvGroup9.IsViewBtnImage = false;
            this.cdvGroup9.Location = new System.Drawing.Point(172, 208);
            this.cdvGroup9.MaxLength = 20;
            this.cdvGroup9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.Name = "cdvGroup9";
            this.cdvGroup9.ReadOnly = false;
            this.cdvGroup9.SelectedSubItemIndex = - 1;
            this.cdvGroup9.SelectionStart = 0;
            this.cdvGroup9.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup9.SmallImageList = null;
            this.cdvGroup9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup9.TabIndex = 8;
            this.cdvGroup9.TextBoxToolTipText = "";
            this.cdvGroup9.VisibleButton = true;
            this.cdvGroup9.VisibleColumnHeader = false;
            //
            //cdvGroup8
            //
            this.cdvGroup8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup8.BtnToolTipText = "";
            this.cdvGroup8.Focusing = null;
            this.cdvGroup8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup8.Index = 7;
            this.cdvGroup8.IsViewBtnImage = false;
            this.cdvGroup8.Location = new System.Drawing.Point(172, 184);
            this.cdvGroup8.MaxLength = 20;
            this.cdvGroup8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.Name = "cdvGroup8";
            this.cdvGroup8.ReadOnly = false;
            this.cdvGroup8.SelectedSubItemIndex = - 1;
            this.cdvGroup8.SelectionStart = 0;
            this.cdvGroup8.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup8.SmallImageList = null;
            this.cdvGroup8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup8.TabIndex = 7;
            this.cdvGroup8.TextBoxToolTipText = "";
            this.cdvGroup8.VisibleButton = true;
            this.cdvGroup8.VisibleColumnHeader = false;
            //
            //cdvGroup7
            //
            this.cdvGroup7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup7.BtnToolTipText = "";
            this.cdvGroup7.Focusing = null;
            this.cdvGroup7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup7.Index = 6;
            this.cdvGroup7.IsViewBtnImage = false;
            this.cdvGroup7.Location = new System.Drawing.Point(172, 160);
            this.cdvGroup7.MaxLength = 20;
            this.cdvGroup7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.Name = "cdvGroup7";
            this.cdvGroup7.ReadOnly = false;
            this.cdvGroup7.SelectedSubItemIndex = - 1;
            this.cdvGroup7.SelectionStart = 0;
            this.cdvGroup7.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup7.SmallImageList = null;
            this.cdvGroup7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup7.TabIndex = 6;
            this.cdvGroup7.TextBoxToolTipText = "";
            this.cdvGroup7.VisibleButton = true;
            this.cdvGroup7.VisibleColumnHeader = false;
            //
            //cdvGroup6
            //
            this.cdvGroup6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup6.BtnToolTipText = "";
            this.cdvGroup6.Focusing = null;
            this.cdvGroup6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup6.Index = 5;
            this.cdvGroup6.IsViewBtnImage = false;
            this.cdvGroup6.Location = new System.Drawing.Point(172, 136);
            this.cdvGroup6.MaxLength = 20;
            this.cdvGroup6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.Name = "cdvGroup6";
            this.cdvGroup6.ReadOnly = false;
            this.cdvGroup6.SelectedSubItemIndex = - 1;
            this.cdvGroup6.SelectionStart = 0;
            this.cdvGroup6.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup6.SmallImageList = null;
            this.cdvGroup6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup6.TabIndex = 5;
            this.cdvGroup6.TextBoxToolTipText = "";
            this.cdvGroup6.VisibleButton = true;
            this.cdvGroup6.VisibleColumnHeader = false;
            //
            //cdvGroup5
            //
            this.cdvGroup5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup5.BtnToolTipText = "";
            this.cdvGroup5.Focusing = null;
            this.cdvGroup5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup5.Index = 4;
            this.cdvGroup5.IsViewBtnImage = false;
            this.cdvGroup5.Location = new System.Drawing.Point(172, 112);
            this.cdvGroup5.MaxLength = 20;
            this.cdvGroup5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.Name = "cdvGroup5";
            this.cdvGroup5.ReadOnly = false;
            this.cdvGroup5.SelectedSubItemIndex = - 1;
            this.cdvGroup5.SelectionStart = 0;
            this.cdvGroup5.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup5.SmallImageList = null;
            this.cdvGroup5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup5.TabIndex = 4;
            this.cdvGroup5.TextBoxToolTipText = "";
            this.cdvGroup5.VisibleButton = true;
            this.cdvGroup5.VisibleColumnHeader = false;
            //
            //cdvGroup4
            //
            this.cdvGroup4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup4.BtnToolTipText = "";
            this.cdvGroup4.Focusing = null;
            this.cdvGroup4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup4.Index = 3;
            this.cdvGroup4.IsViewBtnImage = false;
            this.cdvGroup4.Location = new System.Drawing.Point(172, 88);
            this.cdvGroup4.MaxLength = 20;
            this.cdvGroup4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.Name = "cdvGroup4";
            this.cdvGroup4.ReadOnly = false;
            this.cdvGroup4.SelectedSubItemIndex = - 1;
            this.cdvGroup4.SelectionStart = 0;
            this.cdvGroup4.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup4.SmallImageList = null;
            this.cdvGroup4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup4.TabIndex = 3;
            this.cdvGroup4.TextBoxToolTipText = "";
            this.cdvGroup4.VisibleButton = true;
            this.cdvGroup4.VisibleColumnHeader = false;
            //
            //cdvGroup3
            //
            this.cdvGroup3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup3.BtnToolTipText = "";
            this.cdvGroup3.Focusing = null;
            this.cdvGroup3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup3.Index = 2;
            this.cdvGroup3.IsViewBtnImage = false;
            this.cdvGroup3.Location = new System.Drawing.Point(172, 64);
            this.cdvGroup3.MaxLength = 20;
            this.cdvGroup3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.Name = "cdvGroup3";
            this.cdvGroup3.ReadOnly = false;
            this.cdvGroup3.SelectedSubItemIndex = - 1;
            this.cdvGroup3.SelectionStart = 0;
            this.cdvGroup3.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup3.SmallImageList = null;
            this.cdvGroup3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup3.TabIndex = 2;
            this.cdvGroup3.TextBoxToolTipText = "";
            this.cdvGroup3.VisibleButton = true;
            this.cdvGroup3.VisibleColumnHeader = false;
            //
            //cdvGroup2
            //
            this.cdvGroup2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup2.BtnToolTipText = "";
            this.cdvGroup2.Focusing = null;
            this.cdvGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup2.Index = 1;
            this.cdvGroup2.IsViewBtnImage = false;
            this.cdvGroup2.Location = new System.Drawing.Point(172, 40);
            this.cdvGroup2.MaxLength = 20;
            this.cdvGroup2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.Name = "cdvGroup2";
            this.cdvGroup2.ReadOnly = false;
            this.cdvGroup2.SelectedSubItemIndex = - 1;
            this.cdvGroup2.SelectionStart = 0;
            this.cdvGroup2.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup2.SmallImageList = null;
            this.cdvGroup2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup2.TabIndex = 1;
            this.cdvGroup2.TextBoxToolTipText = "";
            this.cdvGroup2.VisibleButton = true;
            this.cdvGroup2.VisibleColumnHeader = false;
            //
            //cdvGroup1
            //
            this.cdvGroup1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup1.BtnToolTipText = "";
            this.cdvGroup1.Focusing = null;
            this.cdvGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvGroup1.Index = 0;
            this.cdvGroup1.IsViewBtnImage = false;
            this.cdvGroup1.Location = new System.Drawing.Point(172, 16);
            this.cdvGroup1.MaxLength = 20;
            this.cdvGroup1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = false;
            this.cdvGroup1.SelectedSubItemIndex = - 1;
            this.cdvGroup1.SelectionStart = 0;
            this.cdvGroup1.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup1.SmallImageList = null;
            this.cdvGroup1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup1.TabIndex = 0;
            this.cdvGroup1.TextBoxToolTipText = "";
            this.cdvGroup1.VisibleButton = true;
            this.cdvGroup1.VisibleColumnHeader = false;
            //
            //lblGroup10
            //
            this.lblGroup10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup10.Location = new System.Drawing.Point(15, 235);
            this.lblGroup10.Name = "lblGroup10";
            this.lblGroup10.Size = new System.Drawing.Size(150, 14);
            this.lblGroup10.TabIndex = 18;
            //
            //lblGroup9
            //
            this.lblGroup9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup9.Location = new System.Drawing.Point(15, 211);
            this.lblGroup9.Name = "lblGroup9";
            this.lblGroup9.Size = new System.Drawing.Size(150, 14);
            this.lblGroup9.TabIndex = 16;
            //
            //lblGroup8
            //
            this.lblGroup8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup8.Location = new System.Drawing.Point(15, 187);
            this.lblGroup8.Name = "lblGroup8";
            this.lblGroup8.Size = new System.Drawing.Size(150, 14);
            this.lblGroup8.TabIndex = 14;
            //
            //lblGroup7
            //
            this.lblGroup7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup7.Location = new System.Drawing.Point(15, 163);
            this.lblGroup7.Name = "lblGroup7";
            this.lblGroup7.Size = new System.Drawing.Size(150, 14);
            this.lblGroup7.TabIndex = 12;
            //
            //lblGroup6
            //
            this.lblGroup6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup6.Location = new System.Drawing.Point(15, 139);
            this.lblGroup6.Name = "lblGroup6";
            this.lblGroup6.Size = new System.Drawing.Size(150, 14);
            this.lblGroup6.TabIndex = 10;
            //
            //lblGroup5
            //
            this.lblGroup5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup5.Location = new System.Drawing.Point(15, 115);
            this.lblGroup5.Name = "lblGroup5";
            this.lblGroup5.Size = new System.Drawing.Size(150, 14);
            this.lblGroup5.TabIndex = 8;
            //
            //lblGroup4
            //
            this.lblGroup4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup4.Location = new System.Drawing.Point(15, 91);
            this.lblGroup4.Name = "lblGroup4";
            this.lblGroup4.Size = new System.Drawing.Size(150, 14);
            this.lblGroup4.TabIndex = 6;
            //
            //lblGroup3
            //
            this.lblGroup3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup3.Location = new System.Drawing.Point(15, 67);
            this.lblGroup3.Name = "lblGroup3";
            this.lblGroup3.Size = new System.Drawing.Size(150, 14);
            this.lblGroup3.TabIndex = 4;
            //
            //lblGroup2
            //
            this.lblGroup2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup2.Location = new System.Drawing.Point(15, 43);
            this.lblGroup2.Name = "lblGroup2";
            this.lblGroup2.Size = new System.Drawing.Size(150, 14);
            this.lblGroup2.TabIndex = 2;
            //
            //lblGroup1
            //
            this.lblGroup1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGroup1.Location = new System.Drawing.Point(15, 19);
            this.lblGroup1.Name = "lblGroup1";
            this.lblGroup1.Size = new System.Drawing.Size(150, 14);
            this.lblGroup1.TabIndex = 0;
            //
            //tabCMF
            //
            this.tabCMF.Controls.Add(this.grpCMF);
            this.tabCMF.DockPadding.Bottom = 3;
            this.tabCMF.DockPadding.Left = 3;
            this.tabCMF.DockPadding.Right = 3;
            this.tabCMF.Location = new System.Drawing.Point(4, 22);
            this.tabCMF.Name = "tabCMF";
            this.tabCMF.Size = new System.Drawing.Size(499, 398);
            this.tabCMF.TabIndex = 2;
            this.tabCMF.Text = "Customized Field";
            this.tabCMF.Visible = false;
            //
            //grpCMF
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
            this.grpCMF.Size = new System.Drawing.Size(493, 395);
            this.grpCMF.TabIndex = 1;
            this.grpCMF.TabStop = false;
            //
            //lblCMF3
            //
            this.lblCMF3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF3.Location = new System.Drawing.Point(15, 67);
            this.lblCMF3.Name = "lblCMF3";
            this.lblCMF3.Size = new System.Drawing.Size(150, 14);
            this.lblCMF3.TabIndex = 22;
            //
            //lblCMF2
            //
            this.lblCMF2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF2.Location = new System.Drawing.Point(15, 43);
            this.lblCMF2.Name = "lblCMF2";
            this.lblCMF2.Size = new System.Drawing.Size(150, 14);
            this.lblCMF2.TabIndex = 21;
            //
            //lblCMF1
            //
            this.lblCMF1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF1.Location = new System.Drawing.Point(15, 19);
            this.lblCMF1.Name = "lblCMF1";
            this.lblCMF1.Size = new System.Drawing.Size(150, 14);
            this.lblCMF1.TabIndex = 20;
            //
            //cdvCMF5
            //
            this.cdvCMF5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF5.BtnToolTipText = "";
            this.cdvCMF5.Focusing = null;
            this.cdvCMF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF5.Index = 4;
            this.cdvCMF5.IsViewBtnImage = false;
            this.cdvCMF5.Location = new System.Drawing.Point(172, 112);
            this.cdvCMF5.MaxLength = 30;
            this.cdvCMF5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF5.Name = "cdvCMF5";
            this.cdvCMF5.ReadOnly = false;
            this.cdvCMF5.SelectedSubItemIndex = - 1;
            this.cdvCMF5.SelectionStart = 0;
            this.cdvCMF5.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF5.SmallImageList = null;
            this.cdvCMF5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF5.TabIndex = 4;
            this.cdvCMF5.TextBoxToolTipText = "";
            this.cdvCMF5.VisibleButton = true;
            this.cdvCMF5.VisibleColumnHeader = false;
            //
            //cdvCMF10
            //
            this.cdvCMF10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF10.BtnToolTipText = "";
            this.cdvCMF10.Focusing = null;
            this.cdvCMF10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF10.Index = 9;
            this.cdvCMF10.IsViewBtnImage = false;
            this.cdvCMF10.Location = new System.Drawing.Point(172, 232);
            this.cdvCMF10.MaxLength = 30;
            this.cdvCMF10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF10.Name = "cdvCMF10";
            this.cdvCMF10.ReadOnly = false;
            this.cdvCMF10.SelectedSubItemIndex = - 1;
            this.cdvCMF10.SelectionStart = 0;
            this.cdvCMF10.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF10.SmallImageList = null;
            this.cdvCMF10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF10.TabIndex = 9;
            this.cdvCMF10.TextBoxToolTipText = "";
            this.cdvCMF10.VisibleButton = true;
            this.cdvCMF10.VisibleColumnHeader = false;
            //
            //cdvCMF9
            //
            this.cdvCMF9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF9.BtnToolTipText = "";
            this.cdvCMF9.Focusing = null;
            this.cdvCMF9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF9.Index = 8;
            this.cdvCMF9.IsViewBtnImage = false;
            this.cdvCMF9.Location = new System.Drawing.Point(172, 208);
            this.cdvCMF9.MaxLength = 30;
            this.cdvCMF9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF9.Name = "cdvCMF9";
            this.cdvCMF9.ReadOnly = false;
            this.cdvCMF9.SelectedSubItemIndex = - 1;
            this.cdvCMF9.SelectionStart = 0;
            this.cdvCMF9.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF9.SmallImageList = null;
            this.cdvCMF9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF9.TabIndex = 8;
            this.cdvCMF9.TextBoxToolTipText = "";
            this.cdvCMF9.VisibleButton = true;
            this.cdvCMF9.VisibleColumnHeader = false;
            //
            //cdvCMF8
            //
            this.cdvCMF8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF8.BtnToolTipText = "";
            this.cdvCMF8.Focusing = null;
            this.cdvCMF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF8.Index = 7;
            this.cdvCMF8.IsViewBtnImage = false;
            this.cdvCMF8.Location = new System.Drawing.Point(172, 184);
            this.cdvCMF8.MaxLength = 30;
            this.cdvCMF8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF8.Name = "cdvCMF8";
            this.cdvCMF8.ReadOnly = false;
            this.cdvCMF8.SelectedSubItemIndex = - 1;
            this.cdvCMF8.SelectionStart = 0;
            this.cdvCMF8.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF8.SmallImageList = null;
            this.cdvCMF8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF8.TabIndex = 7;
            this.cdvCMF8.TextBoxToolTipText = "";
            this.cdvCMF8.VisibleButton = true;
            this.cdvCMF8.VisibleColumnHeader = false;
            //
            //cdvCMF7
            //
            this.cdvCMF7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF7.BtnToolTipText = "";
            this.cdvCMF7.Focusing = null;
            this.cdvCMF7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF7.Index = 6;
            this.cdvCMF7.IsViewBtnImage = false;
            this.cdvCMF7.Location = new System.Drawing.Point(172, 160);
            this.cdvCMF7.MaxLength = 30;
            this.cdvCMF7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF7.Name = "cdvCMF7";
            this.cdvCMF7.ReadOnly = false;
            this.cdvCMF7.SelectedSubItemIndex = - 1;
            this.cdvCMF7.SelectionStart = 0;
            this.cdvCMF7.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF7.SmallImageList = null;
            this.cdvCMF7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF7.TabIndex = 6;
            this.cdvCMF7.TextBoxToolTipText = "";
            this.cdvCMF7.VisibleButton = true;
            this.cdvCMF7.VisibleColumnHeader = false;
            //
            //cdvCMF6
            //
            this.cdvCMF6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF6.BtnToolTipText = "";
            this.cdvCMF6.Focusing = null;
            this.cdvCMF6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF6.Index = 5;
            this.cdvCMF6.IsViewBtnImage = false;
            this.cdvCMF6.Location = new System.Drawing.Point(172, 136);
            this.cdvCMF6.MaxLength = 30;
            this.cdvCMF6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF6.Name = "cdvCMF6";
            this.cdvCMF6.ReadOnly = false;
            this.cdvCMF6.SelectedSubItemIndex = - 1;
            this.cdvCMF6.SelectionStart = 0;
            this.cdvCMF6.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF6.SmallImageList = null;
            this.cdvCMF6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF6.TabIndex = 5;
            this.cdvCMF6.TextBoxToolTipText = "";
            this.cdvCMF6.VisibleButton = true;
            this.cdvCMF6.VisibleColumnHeader = false;
            //
            //cdvCMF4
            //
            this.cdvCMF4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF4.BtnToolTipText = "";
            this.cdvCMF4.Focusing = null;
            this.cdvCMF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF4.Index = 3;
            this.cdvCMF4.IsViewBtnImage = false;
            this.cdvCMF4.Location = new System.Drawing.Point(172, 88);
            this.cdvCMF4.MaxLength = 30;
            this.cdvCMF4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF4.Name = "cdvCMF4";
            this.cdvCMF4.ReadOnly = false;
            this.cdvCMF4.SelectedSubItemIndex = - 1;
            this.cdvCMF4.SelectionStart = 0;
            this.cdvCMF4.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF4.SmallImageList = null;
            this.cdvCMF4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF4.TabIndex = 3;
            this.cdvCMF4.TextBoxToolTipText = "";
            this.cdvCMF4.VisibleButton = true;
            this.cdvCMF4.VisibleColumnHeader = false;
            //
            //cdvCMF3
            //
            this.cdvCMF3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF3.BtnToolTipText = "";
            this.cdvCMF3.Focusing = null;
            this.cdvCMF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF3.Index = 2;
            this.cdvCMF3.IsViewBtnImage = false;
            this.cdvCMF3.Location = new System.Drawing.Point(172, 64);
            this.cdvCMF3.MaxLength = 30;
            this.cdvCMF3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF3.Name = "cdvCMF3";
            this.cdvCMF3.ReadOnly = false;
            this.cdvCMF3.SelectedSubItemIndex = - 1;
            this.cdvCMF3.SelectionStart = 0;
            this.cdvCMF3.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF3.SmallImageList = null;
            this.cdvCMF3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF3.TabIndex = 2;
            this.cdvCMF3.TextBoxToolTipText = "";
            this.cdvCMF3.VisibleButton = true;
            this.cdvCMF3.VisibleColumnHeader = false;
            //
            //cdvCMF2
            //
            this.cdvCMF2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF2.BtnToolTipText = "";
            this.cdvCMF2.Focusing = null;
            this.cdvCMF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF2.Index = 1;
            this.cdvCMF2.IsViewBtnImage = false;
            this.cdvCMF2.Location = new System.Drawing.Point(172, 40);
            this.cdvCMF2.MaxLength = 30;
            this.cdvCMF2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF2.Name = "cdvCMF2";
            this.cdvCMF2.ReadOnly = false;
            this.cdvCMF2.SelectedSubItemIndex = - 1;
            this.cdvCMF2.SelectionStart = 0;
            this.cdvCMF2.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF2.SmallImageList = null;
            this.cdvCMF2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF2.TabIndex = 1;
            this.cdvCMF2.TextBoxToolTipText = "";
            this.cdvCMF2.VisibleButton = true;
            this.cdvCMF2.VisibleColumnHeader = false;
            //
            //cdvCMF1
            //
            this.cdvCMF1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCMF1.BtnToolTipText = "";
            this.cdvCMF1.Focusing = null;
            this.cdvCMF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cdvCMF1.Index = 0;
            this.cdvCMF1.IsViewBtnImage = false;
            this.cdvCMF1.Location = new System.Drawing.Point(172, 16);
            this.cdvCMF1.MaxLength = 30;
            this.cdvCMF1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCMF1.Name = "cdvCMF1";
            this.cdvCMF1.ReadOnly = false;
            this.cdvCMF1.SelectedSubItemIndex = - 1;
            this.cdvCMF1.SelectionStart = 0;
            this.cdvCMF1.Size = new System.Drawing.Size(200, 20);
            this.cdvCMF1.SmallImageList = null;
            this.cdvCMF1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCMF1.TabIndex = 0;
            this.cdvCMF1.TextBoxToolTipText = "";
            this.cdvCMF1.VisibleButton = true;
            this.cdvCMF1.VisibleColumnHeader = false;
            //
            //lblCMF10
            //
            this.lblCMF10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF10.Location = new System.Drawing.Point(15, 235);
            this.lblCMF10.Name = "lblCMF10";
            this.lblCMF10.Size = new System.Drawing.Size(150, 14);
            this.lblCMF10.TabIndex = 18;
            //
            //lblCMF9
            //
            this.lblCMF9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF9.Location = new System.Drawing.Point(15, 211);
            this.lblCMF9.Name = "lblCMF9";
            this.lblCMF9.Size = new System.Drawing.Size(150, 14);
            this.lblCMF9.TabIndex = 16;
            //
            //lblCMF8
            //
            this.lblCMF8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF8.Location = new System.Drawing.Point(15, 187);
            this.lblCMF8.Name = "lblCMF8";
            this.lblCMF8.Size = new System.Drawing.Size(150, 14);
            this.lblCMF8.TabIndex = 14;
            //
            //lblCMF7
            //
            this.lblCMF7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF7.Location = new System.Drawing.Point(15, 163);
            this.lblCMF7.Name = "lblCMF7";
            this.lblCMF7.Size = new System.Drawing.Size(150, 14);
            this.lblCMF7.TabIndex = 12;
            //
            //lblCMF6
            //
            this.lblCMF6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF6.Location = new System.Drawing.Point(15, 139);
            this.lblCMF6.Name = "lblCMF6";
            this.lblCMF6.Size = new System.Drawing.Size(150, 14);
            this.lblCMF6.TabIndex = 10;
            //
            //lblCMF5
            //
            this.lblCMF5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF5.Location = new System.Drawing.Point(15, 115);
            this.lblCMF5.Name = "lblCMF5";
            this.lblCMF5.Size = new System.Drawing.Size(150, 14);
            this.lblCMF5.TabIndex = 8;
            //
            //lblCMF4
            //
            this.lblCMF4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCMF4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCMF4.Location = new System.Drawing.Point(15, 91);
            this.lblCMF4.Name = "lblCMF4";
            this.lblCMF4.Size = new System.Drawing.Size(150, 14);
            this.lblCMF4.TabIndex = 6;
            //
            //grpCharacter
            //
            this.grpCharacter.Controls.Add(this.lblDesc);
            this.grpCharacter.Controls.Add(this.lblCharacter);
            this.grpCharacter.Controls.Add(this.txtCharacterDesc);
            this.grpCharacter.Controls.Add(this.txtCharacter);
            this.grpCharacter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCharacter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCharacter.Location = new System.Drawing.Point(3, 3);
            this.grpCharacter.Name = "grpCharacter";
            this.grpCharacter.Size = new System.Drawing.Size(507, 71);
            this.grpCharacter.TabIndex = 0;
            this.grpCharacter.TabStop = false;
            //
            //lblDesc
            //
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 14);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            //
            //lblCharacter
            //
            this.lblCharacter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblCharacter.Location = new System.Drawing.Point(15, 19);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(100, 14);
            this.lblCharacter.TabIndex = 0;
            this.lblCharacter.Text = "Character ID";
            //
            //txtCharacterDesc
            //
            this.txtCharacterDesc.Location = new System.Drawing.Point(120, 40);
            this.txtCharacterDesc.MaxLength = 50;
            this.txtCharacterDesc.Name = "txtCharacterDesc";
            this.txtCharacterDesc.Size = new System.Drawing.Size(360, 21);
            this.txtCharacterDesc.TabIndex = 1;
            //
            //txtCharacter
            //
            this.txtCharacter.Location = new System.Drawing.Point(120, 16);
            this.txtCharacter.MaxLength = 25;
            this.txtCharacter.Name = "txtCharacter";
            this.txtCharacter.Size = new System.Drawing.Size(200, 21);
            this.txtCharacter.TabIndex = 0;
            //
            //pnlLeft
            //
            this.pnlLeft.Controls.Add(this.lisCharacter);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.DockPadding.Bottom = 3;
            this.pnlLeft.DockPadding.Left = 3;
            this.pnlLeft.DockPadding.Top = 3;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            this.pnlLeft.TabIndex = 0;
            //
            //lisCharacter
            //
            this.lisCharacter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader2 });
            this.lisCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisCharacter.FullRowSelect = true;
            this.lisCharacter.Location = new System.Drawing.Point(3, 3);
            this.lisCharacter.MultiSelect = false;
            this.lisCharacter.Name = "lisCharacter";
            this.lisCharacter.Size = new System.Drawing.Size(229, 500);
            this.lisCharacter.TabIndex = 0;
            this.lisCharacter.TabStop = false;
            this.lisCharacter.View = System.Windows.Forms.View.Details;
            //
            //ColumnHeader1
            //
            this.ColumnHeader1.Text = "Character";
            this.ColumnHeader1.Width = 100;
            //
            //ColumnHeader2
            //
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            //
            //pnlBottom
            //
            this.pnlBottom.Controls.Add(this.pnlFind);
            this.pnlBottom.Controls.Add(this.btnCreate);
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 1;
            //
            //pnlFind
            //
            this.pnlFind.Controls.Add(this.lblDataCount);
            this.pnlFind.Controls.Add(this.lblDataCountBack);
            this.pnlFind.Controls.Add(this.btnExcel);
            this.pnlFind.Controls.Add(this.btnRefresh);
            this.pnlFind.Controls.Add(this.btnNext);
            this.pnlFind.Controls.Add(this.txtFind);
            this.pnlFind.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFind.Location = new System.Drawing.Point(0, 0);
            this.pnlFind.Name = "pnlFind";
            this.pnlFind.Size = new System.Drawing.Size(232, 40);
            this.pnlFind.TabIndex = 0;
            //
            //lblDataCount
            //
            this.lblDataCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCount.Location = new System.Drawing.Point(7, 13);
            this.lblDataCount.Name = "lblDataCount";
            this.lblDataCount.Size = new System.Drawing.Size(36, 16);
            this.lblDataCount.TabIndex = 7;
            this.lblDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //lblDataCountBack
            //
            this.lblDataCountBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDataCountBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDataCountBack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCountBack.Location = new System.Drawing.Point(4, 8);
            this.lblDataCountBack.Name = "lblDataCountBack";
            this.lblDataCountBack.Size = new System.Drawing.Size(42, 24);
            this.lblDataCountBack.TabIndex = 6;
            this.lblDataCountBack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            //btnExcel
            //
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = (System.Drawing.Image) resources.GetObject("btnExcel.Image");
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(200, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 3;
            //
            //btnRefresh
            //
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = (System.Drawing.Image) resources.GetObject("btnRefresh.Image");
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(174, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 2;
            //
            //btnNext
            //
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Image = (System.Drawing.Image) resources.GetObject("btnNext.Image");
            this.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNext.Location = new System.Drawing.Point(148, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 24);
            this.btnNext.TabIndex = 1;
            //
            //txtFind
            //
            this.txtFind.AutoSize = false;
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtFind.Location = new System.Drawing.Point(48, 8);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(96, 24);
            this.txtFind.TabIndex = 0;
            //
            //btnCreate
            //
            this.btnCreate.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreate.Location = new System.Drawing.Point(374, 8);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(88, 26);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            //
            //btnDelete
            //
            this.btnDelete.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(558, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 26);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            //
            //btnUpdate
            //
            this.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(466, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 26);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            //
            //btnClose
            //
            this.btnClose.Anchor = (System.Windows.Forms.AnchorStyles) (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(650, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            //
            //splMain
            //
            this.splMain.Location = new System.Drawing.Point(232, 0);
            this.splMain.Name = "splMain";
            this.splMain.Size = new System.Drawing.Size(3, 506);
            this.splMain.TabIndex = 0;
            this.splMain.TabStop = false;
            //
            //frmSPCSetupCharacter
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCSetupCharacter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Character Setup";
            this.pnlRight.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabCharacter.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.grpDateTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) this.txtUpdateTime).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.txtCreateTime).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.txtUpdateUser).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.txtCreateUser).EndInit();
            this.grpCharacterSetup.ResumeLayout(false);
            this.tabGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup10).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup9).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup8).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup7).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup6).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup5).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup4).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup3).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup2).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvGroup1).EndInit();
            this.tabCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF5).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF10).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF9).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF8).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF7).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF6).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF4).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF3).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF2).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.cdvCMF1).EndInit();
            this.grpCharacter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) this.txtCharacterDesc).EndInit();
            ((System.ComponentModel.ISupportInitialize) this.txtCharacter).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlFind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) this.txtFind).EndInit();
            this.ResumeLayout(false);
            
        }
        
        #endregion
        
        #region " Variable Definition"
        
        bool b_load_flag;
        
        #endregion
        
        #region " Function Implementations"
        
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
                            txtCharacter.Select();
                            return false;
                        }
                        switch (ProcStep)
                        {
                            case MPGC.MP_STEP_CREATE:
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
                MPCF.ShowMsgBox("frmSPCSetupCharacter.CheckCondition()\n" + ex.Message);
                return false;
            }
        }
        
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(string ProcStep)
        {
            
            try
            {
                if (ProcStep == "1")
                {
                    MPCF.FieldClear(this.pnlRight);
                }
                else if (ProcStep == "2")
                {
                    MPCF.ClearList(lisCharacter, true);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.ClearData()\n" + ex.Message);
            }
            
        }
        
        // View_Character()
        //       - View Character
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Character()
        {
            
            EDC_View_Character_In_Tag View_Character_In = new EDC_View_Character_In_Tag();
            EDC_View_Character_Out_Tag View_Character_Out = new EDC_View_Character_Out_Tag();
            
            try
            {
                ClearData("1");
                
                View_Character_In.h_passport = MPGV.gsPassport;
                View_Character_In.h_language = MPGV.gcLanguage;
                View_Character_In.h_factory = MPGV.gsFactory;
                View_Character_In.h_user_id = MPGV.gsUserID;
                View_Character_In.h_password = MPGV.gsPassword;
                View_Character_In.h_proc_step = '1';
                View_Character_In.char_id = lisCharacter.SelectedItems[0].Text;
                
                if (EDCCaster.EDC_View_Character(View_Character_In, ref View_Character_Out) == false)
                {
                    MPCF.ShowMsgBox(h101stub.StatusMessage);
                    return false;
                }
                if (View_Character_Out.h_status_value != MPGC.MP_SUCCESS_STATUS)
                {
                    MPCF.ShowMsgBox(MPCF.MakeErrorMsg(View_Character_Out.h_msg_code, View_Character_Out.h_msg, View_Character_Out.h_db_err_msg, View_Character_Out.h_field_msg));
                    return false;
                }
                
                //General
                txtCharacter.Text = MPCF.Trim(View_Character_Out.char_id);
                txtCharacterDesc.Text = MPCF.Trim(View_Character_Out.char_desc);
                txtCreateUser.Text = MPCF.Trim(View_Character_Out.create_user_id);
                txtCreateTime.Text = MPCF.MakeDateFormat(View_Character_Out.create_time);
                txtUpdateUser.Text = MPCF.Trim(View_Character_Out.update_user_id);
                txtUpdateTime.Text = MPCF.MakeDateFormat(View_Character_Out.update_time);
                
                //Check Value Type
                rbnNumber.Checked = (MPCF.Trim(View_Character_Out.value_type) == "N") ? true : false;
                rbnAscii.Checked = (MPCF.Trim(View_Character_Out.value_type) == "A") ? true : false;
                
                //Group Setup
                cdvGroup1.Text = MPCF.Trim(View_Character_Out.char_grp_1);
                cdvGroup2.Text = MPCF.Trim(View_Character_Out.char_grp_2);
                cdvGroup3.Text = MPCF.Trim(View_Character_Out.char_grp_3);
                cdvGroup4.Text = MPCF.Trim(View_Character_Out.char_grp_4);
                cdvGroup5.Text = MPCF.Trim(View_Character_Out.char_grp_5);
                cdvGroup6.Text = MPCF.Trim(View_Character_Out.char_grp_6);
                cdvGroup7.Text = MPCF.Trim(View_Character_Out.char_grp_7);
                cdvGroup8.Text = MPCF.Trim(View_Character_Out.char_grp_8);
                cdvGroup9.Text = MPCF.Trim(View_Character_Out.char_grp_9);
                cdvGroup10.Text = MPCF.Trim(View_Character_Out.char_grp_10);
                
                //Customized Field
                cdvCMF1.Text = MPCF.Trim(View_Character_Out.char_cmf_1);
                cdvCMF2.Text = MPCF.Trim(View_Character_Out.char_cmf_2);
                cdvCMF3.Text = MPCF.Trim(View_Character_Out.char_cmf_3);
                cdvCMF4.Text = MPCF.Trim(View_Character_Out.char_cmf_4);
                cdvCMF5.Text = MPCF.Trim(View_Character_Out.char_cmf_5);
                cdvCMF6.Text = MPCF.Trim(View_Character_Out.char_cmf_6);
                cdvCMF7.Text = MPCF.Trim(View_Character_Out.char_cmf_7);
                cdvCMF8.Text = MPCF.Trim(View_Character_Out.char_cmf_8);
                cdvCMF9.Text = MPCF.Trim(View_Character_Out.char_cmf_9);
                cdvCMF10.Text = MPCF.Trim(View_Character_Out.char_cmf_10);
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.View_Character()\n" + ex.Message);
                return false;
            }
            
        }
        
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
            
            EDC_Update_Character_In_Tag Update_Character_In =  new EDC_Update_Character_In_Tag();
            Cmn_Out_Tag Cmn_Out = new Cmn_Out_Tag();
            
            try
            {
                Update_Character_In._C.h_passport = MPGV.gsPassport;
                Update_Character_In._C.h_language = MPGV.gcLanguage;
                Update_Character_In._C.h_factory = MPGV.gsFactory;
                Update_Character_In._C.h_user_id = MPGV.gsUserID;
                Update_Character_In._C.h_password = MPGV.gsPassword;
                Update_Character_In._C.h_proc_step = ProcStep;
                Update_Character_In._C.char_id = MPCF.Trim(txtCharacter.Text);
                Update_Character_In._C.char_desc = MPCF.Trim(txtCharacterDesc.Text);
                
                if (rbnNumber.Checked == true)
                {
                    Update_Character_In._C.value_type = 'N';
                }
                if (rbnAscii.Checked == true)
                {
                    Update_Character_In._C.value_type = 'A';
                }
                
                Update_Character_In._C.char_grp_1 = MPCF.Trim(cdvGroup1.Text);
                Update_Character_In._C.char_grp_2 = MPCF.Trim(cdvGroup2.Text);
                Update_Character_In._C.char_grp_3 = MPCF.Trim(cdvGroup3.Text);
                Update_Character_In._C.char_grp_4 = MPCF.Trim(cdvGroup4.Text);
                Update_Character_In._C.char_grp_5 = MPCF.Trim(cdvGroup5.Text);
                Update_Character_In._C.char_grp_6 = MPCF.Trim(cdvGroup6.Text);
                Update_Character_In._C.char_grp_7 = MPCF.Trim(cdvGroup7.Text);
                Update_Character_In._C.char_grp_8 = MPCF.Trim(cdvGroup8.Text);
                Update_Character_In._C.char_grp_9 = MPCF.Trim(cdvGroup9.Text);
                Update_Character_In._C.char_grp_10 = MPCF.Trim(cdvGroup10.Text);
                
                Update_Character_In._C.char_cmf_1 = MPCF.Trim(cdvCMF1.Text);
                Update_Character_In._C.char_cmf_2 = MPCF.Trim(cdvCMF2.Text);
                Update_Character_In._C.char_cmf_3 = MPCF.Trim(cdvCMF3.Text);
                Update_Character_In._C.char_cmf_4 = MPCF.Trim(cdvCMF4.Text);
                Update_Character_In._C.char_cmf_5 = MPCF.Trim(cdvCMF5.Text);
                Update_Character_In._C.char_cmf_6 = MPCF.Trim(cdvCMF6.Text);
                Update_Character_In._C.char_cmf_7 = MPCF.Trim(cdvCMF7.Text);
                Update_Character_In._C.char_cmf_8 = MPCF.Trim(cdvCMF8.Text);
                Update_Character_In._C.char_cmf_9 = MPCF.Trim(cdvCMF9.Text);
                Update_Character_In._C.char_cmf_10 = MPCF.Trim(cdvCMF10.Text);
                
                if (EDCCaster.EDC_Update_Character(Update_Character_In, ref Cmn_Out) == false)
                {
                    MPCF.ShowMsgBox(h101stub.StatusMessage);
                    return false;
                }
                if (Cmn_Out.h_status_value != MPGC.MP_SUCCESS_STATUS)
                {
                    MPCF.ShowMsgBox(MPCF.MakeErrorMsg(Cmn_Out.h_msg_code, Cmn_Out.h_msg, Cmn_Out.h_db_err_msg, Cmn_Out.h_field_msg));
                    return false;
                }
                
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
                        if (idx != - 1)
                        {
                            lisCharacter.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = lisCharacter.Items.Count.ToString();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.Update_Character()\n" + ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        // SetGroupCmfItem()
        //       - Set Group / Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        //
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
                MPCF.ShowMsgBox("frmSPCSetupCharacter.SetGroupCmfItem()\n" + ex.Message);
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
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCSetupCharacter_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                
                MPCF.InitListView(lisCharacter);
                MPCF.FieldVisible(grpGroup, false);
                MPCF.FieldVisible(grpCMF, false);
                MPCF.GetTextboxStyle(this.Controls);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.frmSPCSetupCharacter_Load()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCSetupCharacter_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    lblDataCount.Text = "";
                    SetGroupCmfItem();

                    if (EDCLIST.ViewEDCCharacterList(lisCharacter, '1', "", null, "") == true)
                    {
                        lblDataCount.Text = lisCharacter.Items.Count.ToString();
                        if (lisCharacter.Items.Count > 0)
                        {
                            lisCharacter.Items[0].Selected = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                    
                    b_load_flag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.frmSPCSetupCharacter_Activated()\n" + ex.Message);
            }
            
        }
        
        private void rbnNumeric_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                rbnNumber.Checked = false;
                rbnAscii.Checked = false;
                ((RadioButton) sender).Checked = true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.rbnNumeric_Click()\n" + ex.Message);
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
                    MPCF.ShowMsgBox(MPCF.GetMessage(52));
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.btnUpdate_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 1) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Character", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Character(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    MPCF.ShowMsgBox(MPCF.GetMessage(52));
                    MPCF.FieldClear(this.pnlRight);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.btnDelete_Click()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCSetupCharacter.lisCharacter_SelectedIndexChanged()\n" + ex.Message);
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
                    MPCF.ShowMsgBox(MPCF.GetMessage(52));
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.btnCreate_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (EDCLIST.ViewEDCCharacterList(lisCharacter, '1', "", null, "") == false)
                {
                    return;
                }
                lblDataCount.Text = lisCharacter.Items.Count.ToString();
                if (lisCharacter.Items.Count > 0)
                {
                    MPCF.FindListItem(lisCharacter, txtCharacter.Text, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.btnRefresh_Click()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCSetupCharacter.btnExcel_Click()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCSetupCharacter.cdvGrpCmf_ButtonPress()\n" + ex.Message);
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
                MPCF.ShowMsgBox("frmSPCSetupCharacter.cdvCMF_TextBoxKeyPress()\n" + ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemNextPartial(lisCharacter, txtFind.Text, true, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.btnNext_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemPartial(lisCharacter, txtFind.Text, 0, true, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.txtFind_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCSetupCharacter.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
