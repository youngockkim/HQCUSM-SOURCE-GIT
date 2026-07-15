
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

//#If _RTD = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRTDSetupRuleItemItem.vb
//   Description :
//
//   MES Version : 4.2.0.0
//
//   Function List
//       - CheckCondition : Check the Conditions before Transaction
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2008-06-18 : Created by LAVERWON
//
//
//   Copyright(C) 1998-2008 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.RTDCore
{
    public class frmRTDSetupRuleItem : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRTDSetupRuleItem()
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
        



        private System.Windows.Forms.GroupBox grpDsp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblRuleID;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtRuleID;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.TabPage tbpItems;
        private Miracom.UI.Controls.MCListView.MCListView lisRule;
        private System.Windows.Forms.ColumnHeader colRuleID;
        private System.Windows.Forms.ColumnHeader colDspDesc;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader3;
        private Miracom.UI.Controls.MCListView.MCListView lisRuleItem;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.GroupBox grpRule;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.ComboBox cboLevel;
        private System.Windows.Forms.ComboBox cboSortType;
        private System.Windows.Forms.Label lblSortType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.ComboBox cboPoint;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.GroupBox grpCreateInfo;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.TabControl tabRule;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue1;
        private System.Windows.Forms.Label lblValue1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvValue2;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private ComboBox cboClassType;
        private Label lblClassType;
        private ComboBox cboLotType;
        private Label lblLotType;
        private CheckBox chkSelectFlag;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private TextBox txtValue2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRuleType;
        private Label lblRuleType;
        private TabPage tbpCopyRule;
        private GroupBox grpCopyRule;
        private Button btnCopy;
        private Label lblToRule;
        private TextBox txtToRule;
        private CheckBox chkReal;
        private CheckBox chkCapableFlag;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Label lblDesciption;
        private TextBox txtDescription;
        private ComboBox cboOperator;
        private Label lblOperator;
        private UI.Controls.MCCodeView.MCCodeView cdvTableName;
        private Label lblTableName;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader colRuleType;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.grpDsp = new System.Windows.Forms.GroupBox();
            this.cdvRuleType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRuleType = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblRuleID = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtRuleID = new System.Windows.Forms.TextBox();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabRule = new System.Windows.Forms.TabControl();
            this.tbpItems = new System.Windows.Forms.TabPage();
            this.grpRule = new System.Windows.Forms.GroupBox();
            this.cdvTableName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTableName = new System.Windows.Forms.Label();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDesciption = new System.Windows.Forms.Label();
            this.chkCapableFlag = new System.Windows.Forms.CheckBox();
            this.chkReal = new System.Windows.Forms.CheckBox();
            this.cdvValue2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.cboClassType = new System.Windows.Forms.ComboBox();
            this.lblClassType = new System.Windows.Forms.Label();
            this.cboLotType = new System.Windows.Forms.ComboBox();
            this.lblLotType = new System.Windows.Forms.Label();
            this.chkSelectFlag = new System.Windows.Forms.CheckBox();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.cboPoint = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.cdvValue1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.cdvKey = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblKey = new System.Windows.Forms.Label();
            this.cboSortType = new System.Windows.Forms.ComboBox();
            this.lblSortType = new System.Windows.Forms.Label();
            this.cboLevel = new System.Windows.Forms.ComboBox();
            this.lblLevel = new System.Windows.Forms.Label();
            this.grpCreateInfo = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lisRuleItem = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpCopyRule = new System.Windows.Forms.TabPage();
            this.grpCopyRule = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblToRule = new System.Windows.Forms.Label();
            this.txtToRule = new System.Windows.Forms.TextBox();
            this.lisRule = new Miracom.UI.Controls.MCListView.MCListView();
            this.colRuleID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRuleType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDspDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpDsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRuleType)).BeginInit();
            this.pnlTab.SuspendLayout();
            this.tabRule.SuspendLayout();
            this.tbpItems.SuspendLayout();
            this.grpRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey)).BeginInit();
            this.grpCreateInfo.SuspendLayout();
            this.tbpCopyRule.SuspendLayout();
            this.grpCopyRule.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.grpDsp);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisRule);
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
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Rule Setup";
            // 
            // grpDsp
            // 
            this.grpDsp.Controls.Add(this.cdvRuleType);
            this.grpDsp.Controls.Add(this.lblRuleType);
            this.grpDsp.Controls.Add(this.lblDesc);
            this.grpDsp.Controls.Add(this.lblRuleID);
            this.grpDsp.Controls.Add(this.txtDesc);
            this.grpDsp.Controls.Add(this.txtRuleID);
            this.grpDsp.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDsp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpDsp.Location = new System.Drawing.Point(3, 0);
            this.grpDsp.Name = "grpDsp";
            this.grpDsp.Size = new System.Drawing.Size(500, 70);
            this.grpDsp.TabIndex = 0;
            this.grpDsp.TabStop = false;
            // 
            // cdvRuleType
            // 
            this.cdvRuleType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRuleType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRuleType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRuleType.BtnToolTipText = "";
            this.cdvRuleType.ButtonWidth = 20;
            this.cdvRuleType.DescText = "";
            this.cdvRuleType.DisplaySubItemIndex = -1;
            this.cdvRuleType.DisplayText = "";
            this.cdvRuleType.Focusing = null;
            this.cdvRuleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRuleType.Index = 0;
            this.cdvRuleType.IsViewBtnImage = false;
            this.cdvRuleType.Location = new System.Drawing.Point(432, 16);
            this.cdvRuleType.MaxLength = 20;
            this.cdvRuleType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRuleType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRuleType.MultiSelect = false;
            this.cdvRuleType.Name = "cdvRuleType";
            this.cdvRuleType.ReadOnly = true;
            this.cdvRuleType.SameWidthHeightOfButton = false;
            this.cdvRuleType.SearchSubItemIndex = 0;
            this.cdvRuleType.SelectedDescIndex = -1;
            this.cdvRuleType.SelectedDescToQueryText = "";
            this.cdvRuleType.SelectedSubItemIndex = -1;
            this.cdvRuleType.SelectedValueToQueryText = "";
            this.cdvRuleType.SelectionStart = 0;
            this.cdvRuleType.Size = new System.Drawing.Size(56, 20);
            this.cdvRuleType.SmallImageList = null;
            this.cdvRuleType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRuleType.TabIndex = 3;
            this.cdvRuleType.TextBoxToolTipText = "";
            this.cdvRuleType.TextBoxWidth = 56;
            this.cdvRuleType.VisibleButton = false;
            this.cdvRuleType.VisibleColumnHeader = false;
            this.cdvRuleType.VisibleDescription = false;
            // 
            // lblRuleType
            // 
            this.lblRuleType.AutoSize = true;
            this.lblRuleType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRuleType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuleType.Location = new System.Drawing.Point(331, 19);
            this.lblRuleType.Name = "lblRuleType";
            this.lblRuleType.Size = new System.Drawing.Size(65, 13);
            this.lblRuleType.TabIndex = 2;
            this.lblRuleType.Text = "Rule Type";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 42);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblRuleID
            // 
            this.lblRuleID.AutoSize = true;
            this.lblRuleID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRuleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuleID.Location = new System.Drawing.Point(15, 19);
            this.lblRuleID.Name = "lblRuleID";
            this.lblRuleID.Size = new System.Drawing.Size(50, 13);
            this.lblRuleID.TabIndex = 0;
            this.lblRuleID.Text = "Rule ID";
            this.lblRuleID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(368, 20);
            this.txtDesc.TabIndex = 5;
            // 
            // txtRuleID
            // 
            this.txtRuleID.Location = new System.Drawing.Point(120, 16);
            this.txtRuleID.MaxLength = 20;
            this.txtRuleID.Name = "txtRuleID";
            this.txtRuleID.ReadOnly = true;
            this.txtRuleID.Size = new System.Drawing.Size(200, 20);
            this.txtRuleID.TabIndex = 1;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabRule);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(3, 70);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(500, 443);
            this.pnlTab.TabIndex = 1;
            // 
            // tabRule
            // 
            this.tabRule.Controls.Add(this.tbpItems);
            this.tabRule.Controls.Add(this.tbpCopyRule);
            this.tabRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRule.ItemSize = new System.Drawing.Size(60, 18);
            this.tabRule.Location = new System.Drawing.Point(0, 5);
            this.tabRule.Name = "tabRule";
            this.tabRule.SelectedIndex = 0;
            this.tabRule.Size = new System.Drawing.Size(500, 438);
            this.tabRule.TabIndex = 1;
            this.tabRule.SelectedIndexChanged += new System.EventHandler(this.tabRule_SelectedIndexChanged);
            // 
            // tbpItems
            // 
            this.tbpItems.Controls.Add(this.grpRule);
            this.tbpItems.Controls.Add(this.grpCreateInfo);
            this.tbpItems.Controls.Add(this.lisRuleItem);
            this.tbpItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpItems.Location = new System.Drawing.Point(4, 22);
            this.tbpItems.Name = "tbpItems";
            this.tbpItems.Padding = new System.Windows.Forms.Padding(5);
            this.tbpItems.Size = new System.Drawing.Size(492, 412);
            this.tbpItems.TabIndex = 2;
            this.tbpItems.Text = "Item Definition";
            this.tbpItems.Visible = false;
            // 
            // grpRule
            // 
            this.grpRule.Controls.Add(this.cdvTableName);
            this.grpRule.Controls.Add(this.lblTableName);
            this.grpRule.Controls.Add(this.cboOperator);
            this.grpRule.Controls.Add(this.lblOperator);
            this.grpRule.Controls.Add(this.txtDescription);
            this.grpRule.Controls.Add(this.lblDesciption);
            this.grpRule.Controls.Add(this.chkCapableFlag);
            this.grpRule.Controls.Add(this.chkReal);
            this.grpRule.Controls.Add(this.cdvValue2);
            this.grpRule.Controls.Add(this.txtValue2);
            this.grpRule.Controls.Add(this.cboClassType);
            this.grpRule.Controls.Add(this.lblClassType);
            this.grpRule.Controls.Add(this.cboLotType);
            this.grpRule.Controls.Add(this.lblLotType);
            this.grpRule.Controls.Add(this.chkSelectFlag);
            this.grpRule.Controls.Add(this.lblValue2);
            this.grpRule.Controls.Add(this.cboPoint);
            this.grpRule.Controls.Add(this.lblPoint);
            this.grpRule.Controls.Add(this.cdvValue1);
            this.grpRule.Controls.Add(this.lblValue1);
            this.grpRule.Controls.Add(this.cdvKey);
            this.grpRule.Controls.Add(this.lblKey);
            this.grpRule.Controls.Add(this.cboSortType);
            this.grpRule.Controls.Add(this.lblSortType);
            this.grpRule.Controls.Add(this.cboLevel);
            this.grpRule.Controls.Add(this.lblLevel);
            this.grpRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRule.Location = new System.Drawing.Point(5, 153);
            this.grpRule.Name = "grpRule";
            this.grpRule.Size = new System.Drawing.Size(482, 184);
            this.grpRule.TabIndex = 1;
            this.grpRule.TabStop = false;
            // 
            // cdvTableName
            // 
            this.cdvTableName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTableName.BtnToolTipText = "";
            this.cdvTableName.ButtonWidth = 20;
            this.cdvTableName.DescText = "";
            this.cdvTableName.DisplaySubItemIndex = -1;
            this.cdvTableName.DisplayText = "";
            this.cdvTableName.Focusing = null;
            this.cdvTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableName.Index = 0;
            this.cdvTableName.IsViewBtnImage = false;
            this.cdvTableName.Location = new System.Drawing.Point(331, 136);
            this.cdvTableName.MaxLength = 255;
            this.cdvTableName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTableName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTableName.MultiSelect = false;
            this.cdvTableName.Name = "cdvTableName";
            this.cdvTableName.ReadOnly = true;
            this.cdvTableName.SameWidthHeightOfButton = false;
            this.cdvTableName.SearchSubItemIndex = 0;
            this.cdvTableName.SelectedDescIndex = -1;
            this.cdvTableName.SelectedDescToQueryText = "";
            this.cdvTableName.SelectedSubItemIndex = -1;
            this.cdvTableName.SelectedValueToQueryText = "";
            this.cdvTableName.SelectionStart = 0;
            this.cdvTableName.Size = new System.Drawing.Size(143, 20);
            this.cdvTableName.SmallImageList = null;
            this.cdvTableName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTableName.TabIndex = 24;
            this.cdvTableName.TextBoxToolTipText = "";
            this.cdvTableName.TextBoxWidth = 143;
            this.cdvTableName.Visible = false;
            this.cdvTableName.VisibleButton = true;
            this.cdvTableName.VisibleColumnHeader = false;
            this.cdvTableName.VisibleDescription = false;
            this.cdvTableName.ButtonPress += new System.EventHandler(this.cdvTableName_ButtonPress);
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.Location = new System.Drawing.Point(267, 139);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(65, 13);
            this.lblTableName.TabIndex = 23;
            this.lblTableName.Text = "Table Name";
            this.lblTableName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTableName.Visible = false;
            // 
            // cboOperator
            // 
            this.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Items.AddRange(new object[] {
            "=",
            "!=",
            ">",
            ">=",
            "<",
            "<=",
            "IN",
            "NOT IN",
            "LIKE",
            "NOT LIKE",
            "IS",
            "IS NOT"});
            this.cboOperator.Location = new System.Drawing.Point(385, 111);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(89, 21);
            this.cboOperator.TabIndex = 22;
            this.cboOperator.SelectedIndexChanged += new System.EventHandler(this.cboOperator_SelectedIndexChanged);
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperator.Location = new System.Drawing.Point(331, 115);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(48, 13);
            this.lblOperator.TabIndex = 21;
            this.lblOperator.Text = "Operator";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(120, 159);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(354, 20);
            this.txtDescription.TabIndex = 20;
            // 
            // lblDesciption
            // 
            this.lblDesciption.AutoSize = true;
            this.lblDesciption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesciption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesciption.Location = new System.Drawing.Point(15, 166);
            this.lblDesciption.Name = "lblDesciption";
            this.lblDesciption.Size = new System.Drawing.Size(71, 13);
            this.lblDesciption.TabIndex = 19;
            this.lblDesciption.Text = "Description";
            this.lblDesciption.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // chkCapableFlag
            // 
            this.chkCapableFlag.AutoSize = true;
            this.chkCapableFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCapableFlag.Location = new System.Drawing.Point(331, 42);
            this.chkCapableFlag.Name = "chkCapableFlag";
            this.chkCapableFlag.Size = new System.Drawing.Size(87, 17);
            this.chkCapableFlag.TabIndex = 13;
            this.chkCapableFlag.Text = "Uncapable";
            // 
            // chkReal
            // 
            this.chkReal.AutoSize = true;
            this.chkReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReal.Location = new System.Drawing.Point(178, 138);
            this.chkReal.Name = "chkReal";
            this.chkReal.Size = new System.Drawing.Size(83, 17);
            this.chkReal.TabIndex = 18;
            this.chkReal.Text = "Real Time";
            // 
            // cdvValue2
            // 
            this.cdvValue2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue2.BtnToolTipText = "";
            this.cdvValue2.ButtonWidth = 20;
            this.cdvValue2.DescText = "";
            this.cdvValue2.DisplaySubItemIndex = -1;
            this.cdvValue2.DisplayText = "";
            this.cdvValue2.Focusing = null;
            this.cdvValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue2.Index = 0;
            this.cdvValue2.IsViewBtnImage = false;
            this.cdvValue2.Location = new System.Drawing.Point(120, 112);
            this.cdvValue2.MaxLength = 100;
            this.cdvValue2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue2.MultiSelect = false;
            this.cdvValue2.Name = "cdvValue2";
            this.cdvValue2.ReadOnly = true;
            this.cdvValue2.SameWidthHeightOfButton = false;
            this.cdvValue2.SearchSubItemIndex = 0;
            this.cdvValue2.SelectedDescIndex = -1;
            this.cdvValue2.SelectedDescToQueryText = "";
            this.cdvValue2.SelectedSubItemIndex = -1;
            this.cdvValue2.SelectedValueToQueryText = "";
            this.cdvValue2.SelectionStart = 0;
            this.cdvValue2.Size = new System.Drawing.Size(200, 20);
            this.cdvValue2.SmallImageList = null;
            this.cdvValue2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue2.TabIndex = 9;
            this.cdvValue2.TextBoxToolTipText = "";
            this.cdvValue2.TextBoxWidth = 200;
            this.cdvValue2.VisibleButton = true;
            this.cdvValue2.VisibleColumnHeader = false;
            this.cdvValue2.VisibleDescription = false;
            this.cdvValue2.ButtonPress += new System.EventHandler(this.cdvValue2_ButtonPress);
            // 
            // txtValue2
            // 
            this.txtValue2.Location = new System.Drawing.Point(120, 112);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(200, 20);
            this.txtValue2.TabIndex = 16;
            this.txtValue2.Visible = false;
            // 
            // cboClassType
            // 
            this.cboClassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassType.Items.AddRange(new object[] {
            "N",
            "P",
            "T"});
            this.cboClassType.Location = new System.Drawing.Point(422, 88);
            this.cboClassType.Name = "cboClassType";
            this.cboClassType.Size = new System.Drawing.Size(52, 21);
            this.cboClassType.TabIndex = 17;
            this.cboClassType.DropDownClosed += new System.EventHandler(this.cboClassType_DropDownClosed);
            // 
            // lblClassType
            // 
            this.lblClassType.AutoSize = true;
            this.lblClassType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblClassType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassType.Location = new System.Drawing.Point(331, 91);
            this.lblClassType.Name = "lblClassType";
            this.lblClassType.Size = new System.Drawing.Size(69, 13);
            this.lblClassType.TabIndex = 16;
            this.lblClassType.Text = "Class Type";
            this.lblClassType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cboLotType
            // 
            this.cboLotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLotType.Items.AddRange(new object[] {
            "A",
            "L"});
            this.cboLotType.Location = new System.Drawing.Point(422, 64);
            this.cboLotType.Name = "cboLotType";
            this.cboLotType.Size = new System.Drawing.Size(52, 21);
            this.cboLotType.TabIndex = 15;
            this.cboLotType.DropDownClosed += new System.EventHandler(this.cboLotType_DropDownClosed);
            // 
            // lblLotType
            // 
            this.lblLotType.AutoSize = true;
            this.lblLotType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotType.Location = new System.Drawing.Point(331, 67);
            this.lblLotType.Name = "lblLotType";
            this.lblLotType.Size = new System.Drawing.Size(57, 13);
            this.lblLotType.TabIndex = 14;
            this.lblLotType.Text = "Lot Type";
            this.lblLotType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // chkSelectFlag
            // 
            this.chkSelectFlag.AutoSize = true;
            this.chkSelectFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectFlag.Location = new System.Drawing.Point(331, 19);
            this.chkSelectFlag.Name = "chkSelectFlag";
            this.chkSelectFlag.Size = new System.Drawing.Size(100, 17);
            this.chkSelectFlag.TabIndex = 12;
            this.chkSelectFlag.Text = "Unselectable";
            // 
            // lblValue2
            // 
            this.lblValue2.AutoSize = true;
            this.lblValue2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue2.Location = new System.Drawing.Point(15, 115);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(50, 13);
            this.lblValue2.TabIndex = 8;
            this.lblValue2.Text = "Value 2";
            // 
            // cboPoint
            // 
            this.cboPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPoint.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cboPoint.Location = new System.Drawing.Point(120, 136);
            this.cboPoint.Name = "cboPoint";
            this.cboPoint.Size = new System.Drawing.Size(52, 21);
            this.cboPoint.TabIndex = 11;
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint.Location = new System.Drawing.Point(15, 139);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(36, 13);
            this.lblPoint.TabIndex = 10;
            this.lblPoint.Text = "Point";
            this.lblPoint.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cdvValue1
            // 
            this.cdvValue1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvValue1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvValue1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvValue1.BtnToolTipText = "";
            this.cdvValue1.ButtonWidth = 20;
            this.cdvValue1.DescText = "";
            this.cdvValue1.DisplaySubItemIndex = -1;
            this.cdvValue1.DisplayText = "";
            this.cdvValue1.Focusing = null;
            this.cdvValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvValue1.Index = 0;
            this.cdvValue1.IsViewBtnImage = false;
            this.cdvValue1.Location = new System.Drawing.Point(120, 88);
            this.cdvValue1.MaxLength = 100;
            this.cdvValue1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvValue1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvValue1.MultiSelect = false;
            this.cdvValue1.Name = "cdvValue1";
            this.cdvValue1.ReadOnly = true;
            this.cdvValue1.SameWidthHeightOfButton = false;
            this.cdvValue1.SearchSubItemIndex = 0;
            this.cdvValue1.SelectedDescIndex = -1;
            this.cdvValue1.SelectedDescToQueryText = "";
            this.cdvValue1.SelectedSubItemIndex = -1;
            this.cdvValue1.SelectedValueToQueryText = "";
            this.cdvValue1.SelectionStart = 0;
            this.cdvValue1.Size = new System.Drawing.Size(200, 20);
            this.cdvValue1.SmallImageList = null;
            this.cdvValue1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvValue1.TabIndex = 7;
            this.cdvValue1.TextBoxToolTipText = "";
            this.cdvValue1.TextBoxWidth = 200;
            this.cdvValue1.VisibleButton = true;
            this.cdvValue1.VisibleColumnHeader = false;
            this.cdvValue1.VisibleDescription = false;
            this.cdvValue1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvValue1_SelectedItemChanged);
            this.cdvValue1.ButtonPress += new System.EventHandler(this.cdvValue_ButtonPress);
            // 
            // lblValue1
            // 
            this.lblValue1.AutoSize = true;
            this.lblValue1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue1.Location = new System.Drawing.Point(15, 91);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(50, 13);
            this.lblValue1.TabIndex = 6;
            this.lblValue1.Text = "Value 1";
            // 
            // cdvKey
            // 
            this.cdvKey.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvKey.BorderHotColor = System.Drawing.Color.Black;
            this.cdvKey.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvKey.BtnToolTipText = "";
            this.cdvKey.ButtonWidth = 20;
            this.cdvKey.DescText = "";
            this.cdvKey.DisplaySubItemIndex = -1;
            this.cdvKey.DisplayText = "";
            this.cdvKey.Focusing = null;
            this.cdvKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvKey.Index = 0;
            this.cdvKey.IsViewBtnImage = false;
            this.cdvKey.Location = new System.Drawing.Point(120, 64);
            this.cdvKey.MaxLength = 20;
            this.cdvKey.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvKey.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvKey.MultiSelect = false;
            this.cdvKey.Name = "cdvKey";
            this.cdvKey.ReadOnly = true;
            this.cdvKey.SameWidthHeightOfButton = false;
            this.cdvKey.SearchSubItemIndex = 0;
            this.cdvKey.SelectedDescIndex = -1;
            this.cdvKey.SelectedDescToQueryText = "";
            this.cdvKey.SelectedSubItemIndex = -1;
            this.cdvKey.SelectedValueToQueryText = "";
            this.cdvKey.SelectionStart = 0;
            this.cdvKey.Size = new System.Drawing.Size(200, 20);
            this.cdvKey.SmallImageList = null;
            this.cdvKey.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvKey.TabIndex = 5;
            this.cdvKey.TextBoxToolTipText = "";
            this.cdvKey.TextBoxWidth = 200;
            this.cdvKey.VisibleButton = true;
            this.cdvKey.VisibleColumnHeader = false;
            this.cdvKey.VisibleDescription = false;
            this.cdvKey.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvKey_SelectedItemChanged);
            this.cdvKey.ButtonPress += new System.EventHandler(this.cdvKey_ButtonPress);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(15, 67);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(28, 13);
            this.lblKey.TabIndex = 4;
            this.lblKey.Text = "Key";
            // 
            // cboSortType
            // 
            this.cboSortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortType.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.cboSortType.Location = new System.Drawing.Point(120, 40);
            this.cboSortType.Name = "cboSortType";
            this.cboSortType.Size = new System.Drawing.Size(116, 21);
            this.cboSortType.TabIndex = 3;
            // 
            // lblSortType
            // 
            this.lblSortType.AutoSize = true;
            this.lblSortType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortType.Location = new System.Drawing.Point(15, 42);
            this.lblSortType.Name = "lblSortType";
            this.lblSortType.Size = new System.Drawing.Size(79, 13);
            this.lblSortType.TabIndex = 2;
            this.lblSortType.Text = "Sorting Type";
            this.lblSortType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cboLevel
            // 
            this.cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cboLevel.Location = new System.Drawing.Point(120, 16);
            this.cboLevel.Name = "cboLevel";
            this.cboLevel.Size = new System.Drawing.Size(52, 21);
            this.cboLevel.TabIndex = 1;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(15, 19);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(38, 13);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Level";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // grpCreateInfo
            // 
            this.grpCreateInfo.Controls.Add(this.txtUpdateTime);
            this.grpCreateInfo.Controls.Add(this.txtCreateTime);
            this.grpCreateInfo.Controls.Add(this.txtUpdateUser);
            this.grpCreateInfo.Controls.Add(this.lblUpdate);
            this.grpCreateInfo.Controls.Add(this.txtCreateUser);
            this.grpCreateInfo.Controls.Add(this.lblCreate);
            this.grpCreateInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpCreateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCreateInfo.Location = new System.Drawing.Point(5, 337);
            this.grpCreateInfo.Name = "grpCreateInfo";
            this.grpCreateInfo.Size = new System.Drawing.Size(482, 70);
            this.grpCreateInfo.TabIndex = 2;
            this.grpCreateInfo.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(300, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(300, 16);
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
            this.lblUpdate.Location = new System.Drawing.Point(10, 43);
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
            this.lblCreate.Location = new System.Drawing.Point(10, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lisRuleItem
            // 
            this.lisRuleItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader11,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader12,
            this.ColumnHeader5,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lisRuleItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lisRuleItem.EnableSort = true;
            this.lisRuleItem.EnableSortIcon = true;
            this.lisRuleItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRuleItem.FullRowSelect = true;
            this.lisRuleItem.HideSelection = false;
            this.lisRuleItem.Location = new System.Drawing.Point(5, 5);
            this.lisRuleItem.MultiSelect = false;
            this.lisRuleItem.Name = "lisRuleItem";
            this.lisRuleItem.Size = new System.Drawing.Size(482, 148);
            this.lisRuleItem.TabIndex = 0;
            this.lisRuleItem.UseCompatibleStateImageBehavior = false;
            this.lisRuleItem.View = System.Windows.Forms.View.Details;
            this.lisRuleItem.SelectedIndexChanged += new System.EventHandler(this.lisRuleItem_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Level";
            this.ColumnHeader1.Width = 45;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Class";
            this.ColumnHeader11.Width = 40;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Sorting";
            this.ColumnHeader2.Width = 55;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Key";
            this.ColumnHeader3.Width = 150;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Value 1";
            this.ColumnHeader4.Width = 100;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Value 2";
            this.ColumnHeader12.Width = 100;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Point";
            this.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader5.Width = 40;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Unselected Flag";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader15.Width = 70;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Lot Type";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Capable Flag";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Description";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Operator";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Table Name";
            // 
            // tbpCopyRule
            // 
            this.tbpCopyRule.BackColor = System.Drawing.SystemColors.Control;
            this.tbpCopyRule.Controls.Add(this.grpCopyRule);
            this.tbpCopyRule.Location = new System.Drawing.Point(4, 22);
            this.tbpCopyRule.Name = "tbpCopyRule";
            this.tbpCopyRule.Size = new System.Drawing.Size(492, 412);
            this.tbpCopyRule.TabIndex = 3;
            this.tbpCopyRule.Text = "Copy Rule";
            // 
            // grpCopyRule
            // 
            this.grpCopyRule.Controls.Add(this.btnCopy);
            this.grpCopyRule.Controls.Add(this.lblToRule);
            this.grpCopyRule.Controls.Add(this.txtToRule);
            this.grpCopyRule.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyRule.Location = new System.Drawing.Point(0, 0);
            this.grpCopyRule.Name = "grpCopyRule";
            this.grpCopyRule.Size = new System.Drawing.Size(492, 47);
            this.grpCopyRule.TabIndex = 2;
            this.grpCopyRule.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(330, 15);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblToRule
            // 
            this.lblToRule.AutoSize = true;
            this.lblToRule.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToRule.Location = new System.Drawing.Point(15, 19);
            this.lblToRule.Name = "lblToRule";
            this.lblToRule.Size = new System.Drawing.Size(45, 13);
            this.lblToRule.TabIndex = 0;
            this.lblToRule.Text = "To Rule";
            this.lblToRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToRule
            // 
            this.txtToRule.Location = new System.Drawing.Point(120, 16);
            this.txtToRule.MaxLength = 20;
            this.txtToRule.Name = "txtToRule";
            this.txtToRule.Size = new System.Drawing.Size(200, 20);
            this.txtToRule.TabIndex = 1;
            // 
            // lisRule
            // 
            this.lisRule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRuleID,
            this.colRuleType,
            this.colDspDesc});
            this.lisRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisRule.EnableSort = true;
            this.lisRule.EnableSortIcon = true;
            this.lisRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisRule.FullRowSelect = true;
            this.lisRule.HideSelection = false;
            this.lisRule.Location = new System.Drawing.Point(3, 3);
            this.lisRule.MultiSelect = false;
            this.lisRule.Name = "lisRule";
            this.lisRule.Size = new System.Drawing.Size(229, 508);
            this.lisRule.TabIndex = 0;
            this.lisRule.UseCompatibleStateImageBehavior = false;
            this.lisRule.View = System.Windows.Forms.View.Details;
            this.lisRule.SelectedIndexChanged += new System.EventHandler(this.lisRule_SelectedIndexChanged);
            // 
            // colRuleID
            // 
            this.colRuleID.Text = "Rule ID";
            this.colRuleID.Width = 100;
            // 
            // colRuleType
            // 
            this.colRuleType.Text = "Rule Type";
            this.colRuleType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colRuleType.Width = 65;
            // 
            // colDspDesc
            // 
            this.colDspDesc.Text = "Description";
            this.colDspDesc.Width = 300;
            // 
            // frmRTDSetupRuleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRTDSetupRuleItem";
            this.Text = "Dispatcher Rule Item Setup";
            this.Activated += new System.EventHandler(this.frmRTDSetupRuleItem_Activated);
            this.Load += new System.EventHandler(this.frmRTDSetupRuleItem_Load);
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
            this.grpDsp.ResumeLayout(false);
            this.grpDsp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRuleType)).EndInit();
            this.pnlTab.ResumeLayout(false);
            this.tabRule.ResumeLayout(false);
            this.tbpItems.ResumeLayout(false);
            this.grpRule.ResumeLayout(false);
            this.grpRule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvKey)).EndInit();
            this.grpCreateInfo.ResumeLayout(false);
            this.grpCreateInfo.PerformLayout();
            this.tbpCopyRule.ResumeLayout(false);
            this.grpCopyRule.ResumeLayout(false);
            this.grpCopyRule.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Variable Definition"
        bool b_load_flag = false;
        private bool b_use_operator_in_rule = false;
        private bool b_operator_selection_changed = false;

        #endregion
        
        #region "Function Definition"
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(char c_step)
        {
            
            try
            {
                int idx;
                if (MPCF.CheckValue(txtRuleID, 1) == false)
                {
                    return false;
                }
                
                switch (c_step)
                {
                    case MPGC.MP_STEP_CREATE:
                        
                        if (tabRule.SelectedTab == tbpItems)
                        {
                            if (MPCF.CheckValue(cboLevel, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.CheckValue(cboSortType, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.CheckValue(cdvKey, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.Trim(cdvKey.Tag).Length == 1)
                            {
                                if (cdvValue1.Visible == true && cdvValue1.Enabled == true)
                                {
                                    if (MPCF.CheckValue(cdvValue1, 1) == false)
                                    {
                                        return false;
                                    }

                                }
                                if (cdvValue2.Visible == true && cdvValue2.Enabled == true)
                                {
                                    if (MPCF.CheckValue(cdvValue2, 1) == false)
                                    {
                                        return false;
                                    }

                                }
                                /* Updated By YJJung 151116 Validation 추가 txtValue2 */
                                if (txtValue2.Visible == true && txtValue2.Enabled == true)
                                {
                                    if (MPCF.CheckValue(txtValue2, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                /* Updated End */
                            }
                            else if (MPCF.Trim(cdvKey.Tag).Length > 1)
                            {
                                /* Updated By YJJung 160315 Customized Rule 인 경우 Visible 여부도 Check Value 하는 기준으로 적용 */
                                if (MPCF.Trim(cdvValue1.Tag) == "Y" && cdvValue1.Visible == true && cdvValue1.Enabled == true)
                                {
                                    if (MPCF.CheckValue(cdvValue1, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                if (MPCF.Trim(cdvValue2.Tag) == "Y" && cdvValue2.Visible == true && cdvValue2.Enabled == true)
                                {
                                    if (MPCF.CheckValue(cdvValue2, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                if (txtValue2.Visible == true && txtValue2.Enabled == true)
                                {
                                    if (MPCF.CheckValue(txtValue2, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                            }
                            if (cboPoint.Visible == true)
                            {
                                if (MPCF.CheckValue(cboPoint, 1) == false)
                                {
                                    return false;
                                }
                            }
                            if (MPCF.Trim(cdvKey.Tag).Length > 1)
                            {
                                if (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K" && chkReal.Checked == true) //외부 함수일 경우
                                {
                                    if (ExistListItem(lisRuleItem, cboLevel.Text, '1') == true)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(280));
                                        cboLevel.Focus();
                                        return false;
                                    }
                                }
                            }

                            if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "T" || MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "C")
                            {
                                if (ExistListItem(lisRuleItem, cboLevel.Text, '1') == true)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(281));
                                    cboLevel.Focus();
                                    return false;
                                }
                            }
                            else if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "N")
                            {
                                idx = MPCF.FindListItemIndex(lisRuleItem, cboLevel.Text, false);
                                if (idx != -1)
                                {
                                    if (lisRuleItem.Items[idx].SubItems[1].Text != "N")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(194));
                                        cboLevel.Focus();
                                        return false;
                                    }
                                    if (MPCF.Trim(cdvKey.Tag).Length == 1) //외부 룰이 아닌것
                                    {
                                        if (lisRuleItem.Items[idx].SubItems[8].Text == "Y")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(280));
                                            cboLevel.Focus();
                                            return false;
                                        }
                                    }
                                }
                            }
                            else if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "P" )
                            {
                                idx = MPCF.FindListItemIndex(lisRuleItem, cboLevel.Text, false);
                                if (idx != - 1)
                                {
                                    if (lisRuleItem.Items[idx].SubItems[1].Text != "P")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(194));
                                        cboLevel.Focus();
                                        return false;
                                    }
                                    if (MPCF.Trim(cdvKey.Tag).Length == 1) //외부 룰이 아닌것
                                    {
                                        if (lisRuleItem.Items[idx].SubItems[8].Text == "Y")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(280));
                                            cboLevel.Focus();
                                            return false;
                                        }
                                    }
                                }
                            }
                            
                            if (cdvKey.Text == "LOT_INFO_MATCH" || cdvKey.Text == "RES_INFO_MATCH" || cdvKey.Text == "PORT_INFO_MATCH")
                            {
                                if (cboLotType.Visible == true)
                                {
                                    if (MPCF.CheckValue(cboLotType, 1) == false)
                                    {
                                        return false;
                                    }
                                }

                                if (cboClassType.Visible == true)
                                {
                                    if (MPCF.CheckValue(cboClassType, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                            }
                            /* Added By YJJung 150901 */
                            if (cdvTableName.Visible == true)
                            {
                                if (MPCF.CheckValue(cdvTableName, 1) == false)
                                {
                                    return false;
                                }
                            }
                        }                        
                        break;
                    case MPGC.MP_STEP_UPDATE:

                        if (tabRule.SelectedTab == tbpItems)
                        {
                            if (lisRuleItem.SelectedItems.Count <= 0)
                            {
                                if (lisRuleItem.Items.Count > 0)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(109));
                                    lisRuleItem.Items[0].Selected = true;
                                    lisRuleItem.Focus();
                                }
                                return false;
                            }
                            if (MPCF.CheckValue(cboLevel, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.CheckValue(cboSortType, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.CheckValue(cdvKey, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.Trim(cdvKey.Tag).Length == 1)
                            {
                                if (cdvValue1.Visible == true && cdvValue1.Enabled == true)
                                {
                                    if (MPCF.CheckValue(cdvValue1, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                if (cdvValue2.Visible == true && cdvValue2.Enabled == true)
                                {
                                    if (MPCF.CheckValue(cdvValue2, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                /* Updated By YJJung 151116 Validation 추가 txtValue2 */
                                if (txtValue2.Visible == true && txtValue2.Enabled == true)
                                {
                                    if (MPCF.CheckValue(txtValue2, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                /* Updated End */
                            }
                            else if (MPCF.Trim(cdvKey.Tag).Length > 1)
                            {
                                /* Updated By YJJung 160315 Customized Rule 인 경우 Visible 여부도 Check Value 하는 기준으로 적용 */
                                if (MPCF.Trim(cdvValue1.Tag) == "Y" && cdvValue1.Visible == true && cdvValue1.Enabled == true)
                                {
                                    if (MPCF.CheckValue(cdvValue1, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                if (MPCF.Trim(cdvValue2.Tag) == "Y" && cdvValue2.Visible == true && cdvValue2.Enabled == true)
                                {
                                    if (MPCF.CheckValue(cdvValue2, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                                if (txtValue2.Visible == true && txtValue2.Enabled == true)
                                {
                                    if (MPCF.CheckValue(txtValue2, 1) == false)
                                    {
                                        return false;
                                    }
                                }
                            }
                            if (cboPoint.Visible == true)
                            {
                                if (MPCF.CheckValue(cboPoint, 1) == false)
                                {
                                    return false;
                                }
                            }
                            if (MPCF.Trim(cdvKey.Tag).Length > 1)
                            {
                                if (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K" && chkReal.Checked == true) //외부 함수일 경우
                                {
                                    if (ExistListItem(lisRuleItem, cboLevel.Text, '2') == true)
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(280));
                                        cboLevel.Focus();
                                        return false;
                                    }
                                }
                            }

                            if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "T" || MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "C")
                            {
                                if (ExistListItem(lisRuleItem, cboLevel.Text, '2') == true)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(281));
                                    cboLevel.Focus();
                                    return false;
                                }
                            }
                            else if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "N")
                            {
                                idx = MPCF.FindListItemIndex(lisRuleItem, cboLevel.Text, false);
                                if (idx != -1)
                                {
                                    if (lisRuleItem.Items[idx].SubItems[1].Text != "N")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(194));
                                        cboLevel.Focus();
                                        return false;
                                    }
                                    if (MPCF.Trim(cdvKey.Tag).Length == 1) //외부 룰이 아닌것
                                    {
                                        if (lisRuleItem.Items[idx].SubItems[8].Text == "Y")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(280));
                                            cboLevel.Focus();
                                            return false;
                                        }
                                    }
                                }
                            }
                            else if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "P")
                            {
                                idx = MPCF.FindListItemIndex(lisRuleItem, cboLevel.Text, false);
                                if (idx != -1)
                                {
                                    if (lisRuleItem.Items[idx].SubItems[1].Text != "P")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(194));
                                        cboLevel.Focus();
                                        return false;
                                    }
                                    if (MPCF.Trim(cdvKey.Tag).Length == 1) //외부 룰이 아닌것
                                    {
                                        if (lisRuleItem.Items[idx].SubItems[8].Text == "Y")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(280));
                                            cboLevel.Focus();
                                            return false;
                                        }
                                    }
                                }
                            }
                            /* Added By YJJung 150901 */
                            if (cdvTableName.Visible == true)
                            {
                                if (MPCF.CheckValue(cdvTableName, 1) == false)
                                {
                                    return false;
                                }
                            }
                        }
                        break;

                    case MPGC.MP_STEP_DELETE:
                        
                        if (tabRule.SelectedTab == tbpItems)
                        {
                            if (MPCF.CheckValue(cboLevel, 1) == false)
                            {
                                return false;
                            }
                            if (MPCF.CheckValue(cdvKey, 1) == false)
                            {
                                return false;
                            }
                            if (cdvValue1.Visible == true && cdvValue1.Enabled == true)
                            {
                                if (MPCF.CheckValue(cdvValue1, 1) == false)
                                {
                                    return false;
                                }
                            }
                            if (cdvValue2.Visible == true && cdvValue2.Enabled == true)
                            {
                                if (MPCF.CheckValue(cdvValue2, 1) == false)
                                {
                                    return false;
                                }
                            }
                            /* Updated By YJJung 151116 Validation 추가 txtValue2 */
                            if (txtValue2.Visible == true && txtValue2.Enabled == true)
                            {
                                if (MPCF.CheckValue(txtValue2, 1) == false)
                                {
                                    return false;
                                }
                            }
                            /* Updated End */
                        }                        
                        break;

                    case MPGC.MP_STEP_COPY:
                        if (MPCF.CheckValue(txtRuleID, 1) == false)
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

        //
        // Copy_Dispatch_Rule()
        //       - Copy Dispatcher Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("C" - Copy)
        //
        private bool Copy_Dispatch_Rule(char c_step)
        {
            TRSNode in_node = new TRSNode("COPY_DISPATCH_RULE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("FROM_RULE_ID", MPCF.Trim(txtRuleID.Text));
                in_node.AddString("TO_RULE_ID", MPCF.Trim(txtToRule.Text));

                if (MPCR.CallService("RTD", "RTD_Copy_Dispatch_Rule", in_node, ref out_node) == false)
                {
                    return false;
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
        // Update_Rule_Items()
        //       - Create/Update/Delete Rule Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("I" - Create, "U" - Update, "D" - Delete)
        //
        private bool Update_Rule_Items(char c_step)
        {
            TRSNode in_node = new TRSNode("UPDATE_RULE_ITEMS_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;

                in_node.AddString("RULE_ID", MPCF.Trim(txtRuleID.Text));
                /* 150722 Added By YJJung Description for Rule Item is added */
                in_node.AddString("RULE_ITEM_DESC", MPCF.Trim(txtDescription.Text));
                /* Added End */
                if (tabRule.SelectedTab == tbpItems)
                {
                    in_node.AddChar("RULE_TYPE", MPCF.ToChar(cdvRuleType.Text));
                    in_node.AddChar("SORTING_TYPE", cboSortType.SelectedIndex == 1 ? 'D' : 'A');
                    if (cboPoint.Visible == true)
                        in_node.AddInt("KEY_POINT", (MPCF.Trim(cboPoint.Text) == "") ? 0 : MPCF.ToInt(cboPoint.Text));
                    else
                        in_node.AddInt("KEY_POINT", 0);

                    if (cdvKey.Text == "LOT_INFO_MATCH" || cdvKey.Text == "RES_INFO_MATCH" || cdvKey.Text == "PORT_INFO_MATCH")
                        in_node.AddChar("CLASS_TYPE", MPCF.ToChar(cboClassType.Text));
                    else
                        in_node.AddChar("CLASS_TYPE", MPCF.ToChar(MPCF.Trim(cdvKey.Tag).Substring(0, 1)));

                    if (MPCF.Trim(cdvKey.Tag).Length > 1)
                    {
                        if (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K") //외부 함수일 경우
                        {
                            in_node.AddChar("LOT_TYPE", chkReal.Checked == true ? 'Y' : 'N');
                        }
                    }
                    else
                    {
                        if (cboLotType.Visible == true)
                        {
                            in_node.AddChar("LOT_TYPE", MPCF.ToChar(cboLotType.Text));
                        }
                        else
                        {
                            in_node.AddChar("LOT_TYPE", ' ');
                        }
                    }
                    if (chkSelectFlag.Visible == true)
                    {
                        in_node.AddChar("UNSELECT_FLAG", chkSelectFlag.Checked == true ? 'Y' : ' ');
                    }
                    else
                    {
                        in_node.AddChar("UNSELECT_FLAG", ' ');
                    }
                    //Add by J.S. 2009.01.19
                    if (chkCapableFlag.Visible == true)
                    {
                        in_node.AddChar("CAPABLE_FLAG", chkCapableFlag.Checked == true ? 'N' : ' ');
                    }
                    else
                    {
                        in_node.AddChar("CAPABLE_FLAG", ' ');
                    }
                    if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        in_node.AddInt("PRIO_LEVEL", MPCF.ToInt(lisRuleItem.SelectedItems[0].Text));
                        in_node.AddString("PRIO_KEY", lisRuleItem.SelectedItems[0].SubItems[3].Text);
                        in_node.AddString("KEY_VALUE_1", lisRuleItem.SelectedItems[0].SubItems[4].Text);
                        in_node.AddString("KEY_VALUE_2", lisRuleItem.SelectedItems[0].SubItems[5].Text);
                        in_node.AddInt("TO_PRIO_LEVEL", MPCF.ToInt(cboLevel.Text));
                        in_node.AddString("TO_PRIO_KEY", MPCF.Trim(cdvKey.Text));
                        in_node.AddString("TO_KEY_VALUE_1", MPCF.Trim(cdvValue1.Text));
                        /* Updated By YJJung Customized Rules 의 Key Value 2도 Update 되게 변경*/
                        if (cdvKey.Text == "LOT_INFO_MATCH" || cdvKey.Text == "RES_INFO_MATCH" || cdvKey.Text == "PORT_INFO_MATCH" || 
                            (MPCF.Trim(cdvKey.Tag).Length > 1 && (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K")))
                        {
                            if (txtValue2.Visible == true)
                            {
                                in_node.AddString("TO_KEY_VALUE_2", MPCF.Trim(txtValue2.Text));
                            }
                            else
                            {
                                in_node.AddString("TO_KEY_VALUE_2", MPCF.Trim(cdvValue2.Text));
                            }
                        }
                        else
                        {
                            in_node.AddString("TO_KEY_VALUE_2", MPCF.Trim(cdvValue2.Text));
                        }
                        /* Added By YJJung For the information of operator and GCM Table */
                        in_node.AddString("OPERATOR", lisRuleItem.SelectedItems[0].SubItems[11].Text);
                        in_node.AddString("TABLE_NAME", lisRuleItem.SelectedItems[0].SubItems[12].Text);
                        if (cboOperator.Visible == true)
                        {
                            in_node.AddString("TO_OPERATOR", MPCF.Trim(cboOperator.Text));
                        }
                        if (cdvTableName.Visible == true)
                        {
                            in_node.AddString("TO_TABLE_NAME", MPCF.Trim(cdvTableName.Text));
                        }
                        /* Added End */
                    }
                    else
                    {
                        /* Added By YJJung For the information of operator and GCM Table */
                        if (cboOperator.Visible == true)
                        {
                            in_node.AddString("OPERATOR", MPCF.Trim(cboOperator.Text));
                        }
                        if (cdvTableName.Visible == true)
                        {
                            in_node.AddString("TABLE_NAME", MPCF.Trim(cdvTableName.Text));
                        }
                        /* Added End */
                        in_node.AddInt("PRIO_LEVEL", MPCF.ToInt(cboLevel.Text));
                        in_node.AddString("PRIO_KEY", MPCF.Trim(cdvKey.Text));
                        if (cdvKey.Text == "SCH_START_TIME")
                            in_node.AddString("KEY_VALUE_1", MPCF.Trim(txtRuleID.Text));
                        else
                            in_node.AddString("KEY_VALUE_1", MPCF.Trim(cdvValue1.Text));

                        /* Updated By YJJung Customized Rules 의 Key Value 2도 Update 되게 변경*/
                        if (cdvKey.Text == "LOT_INFO_MATCH" || cdvKey.Text == "RES_INFO_MATCH" || cdvKey.Text == "PORT_INFO_MATCH" ||
                            (MPCF.Trim(cdvKey.Tag).Length > 1 && (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K")))
                        {
                            if (txtValue2.Visible == true)
                            {
                                in_node.AddString("KEY_VALUE_2", MPCF.Trim(txtValue2.Text));
                            }
                            else
                            {
                                in_node.AddString("KEY_VALUE_2", MPCF.Trim(cdvValue2.Text));
                            }
                        }
                        else
                            in_node.AddString("KEY_VALUE_2", MPCF.Trim(cdvValue2.Text));
                    }
                    
                }

                if (MPCR.CallService("RTD", "RTD_Update_Rule_Items", in_node, ref out_node) == false)
                {
                    return false;
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
        // View_Rule_Item()
        //       - View Rule Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Rule_Item(string sRuleType)
        {
            TRSNode in_node = new TRSNode("VIEW_RULE_ITEM_IN");
            TRSNode out_node = new TRSNode("VIEW_RULE_ITEM_OUT");
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.AddString("RULE_ID", MPCF.Trim(txtRuleID.Text));

                in_node.AddChar("RULE_TYPE", MPCF.ToChar(sRuleType));
                in_node.AddInt("PRIO_LEVEL", MPCF.ToInt(lisRuleItem.SelectedItems[0].Text));
                in_node.AddString("PRIO_KEY", lisRuleItem.SelectedItems[0].SubItems[3].Text);
                in_node.AddString("KEY_VALUE_1", lisRuleItem.SelectedItems[0].SubItems[4].Text);
                in_node.AddString("KEY_VALUE_2", lisRuleItem.SelectedItems[0].SubItems[5].Text);
                in_node.AddString("OPERATOR", lisRuleItem.SelectedItems[0].SubItems[11].Text);
                in_node.AddString("TABLE_NAME", lisRuleItem.SelectedItems[0].SubItems[12].Text);

                if (MPCR.CallService("RTD", "RTD_View_Rule_Item", in_node, ref out_node) == false)
                {
                    return false;
                }
               
                cboLevel.Text = MPCF.Trim(out_node.GetInt("PRIO_LEVEL"));
                cboSortType.SelectedIndex = (out_node.GetChar("SORTING_TYPE") == 'D') ? 1 : 0;
                cdvKey.Text = MPCF.Trim(out_node.GetString("PRIO_KEY"));
                cdvKey.Tag = MPCF.Trim(out_node.GetChar("CLASS_TYPE"));
                if (MPCF.Trim(out_node.GetChar("LOT_TYPE")) == "Y" || MPCF.Trim(out_node.GetChar("LOT_TYPE")) == "N")
                {
                    cdvKey.Tag = MPCF.Trim(out_node.GetChar("CLASS_TYPE")) + "K" + MPCF.Trim(out_node.GetString("VALUE_COUNT"));
                    if (MPCF.Trim(out_node.GetChar("LOT_TYPE")) == "Y")
                    {
                        chkReal.Checked = true;
                    }
                    else if (MPCF.Trim(out_node.GetChar("LOT_TYPE")) == "N")
                    {
                        chkReal.Checked = false;
                    }
                }
                else
                {
                    chkReal.Checked = false;
                }
                SetControlProperty(MPCF.Trim(out_node.GetChar("RULE_TYPE")));
                cdvValue1.Text = MPCF.Trim(out_node.GetString("KEY_VALUE_1"));
                /* Updated By YJJung Customized Rules 의 Key Value 2도 보이게 변경 */
                if (cdvKey.Text == "LOT_INFO_MATCH" || cdvKey.Text == "RES_INFO_MATCH" || cdvKey.Text == "PORT_INFO_MATCH" ||
                    (MPCF.Trim(cdvKey.Tag).Length > 1 && (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K")))
                {
                    cboLotType.Text = MPCF.Trim(out_node.GetChar("LOT_TYPE"));
                    cboClassType.Text = MPCF.Trim(out_node.GetChar("CLASS_TYPE"));
                    
                    cdvValue2.Text = MPCF.Trim(out_node.GetString("KEY_VALUE_2"));
                    txtValue2.Text = MPCF.Trim(out_node.GetString("KEY_VALUE_2"));
                    
                }
                else
                {
                    cdvValue2.Text = MPCF.Trim(out_node.GetString("KEY_VALUE_2"));
                }

                cboPoint.Text = MPCF.Trim(out_node.GetInt("KEY_POINT"));
                txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                chkSelectFlag.Checked = out_node.GetChar("UNSELECT_FLAG") == 'Y' ? true : false;
                chkCapableFlag.Checked = out_node.GetChar("CAPABLE_FLAG") == 'N' ? true : false;
                /* Added By YJJung 150722 description for rule item is added */
                txtDescription.Text = MPCF.Trim(out_node.GetString("RULE_ITEM_DESC"));
                /* Added End */
                b_operator_selection_changed = true;
                b_use_operator_in_rule = MPGO.UseOperatorInRule();
                if (b_use_operator_in_rule != true)
                {
                    cboOperator.Visible = false;
                    lblOperator.Visible = false;
                }
                if (cboOperator.Visible == true ) 
                {
                    /* Added By YJJung 150811 for operator and table name select */
                    if (MPCF.Trim(out_node.GetString("OPERATOR")) == "=")
                    {
                        cboOperator.SelectedIndex = 0;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == "!=")
                    {
                        cboOperator.SelectedIndex = 1;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == ">")
                    {
                        cboOperator.SelectedIndex = 2;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == ">=")
                    {
                        cboOperator.SelectedIndex = 3;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == "<")
                    {
                        cboOperator.SelectedIndex = 4;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == "<=")
                    {
                        cboOperator.SelectedIndex = 5;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == "IN")
                    {
                        cboOperator.SelectedIndex = 6;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == "NOT IN")
                    {
                        cboOperator.SelectedIndex = 7;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == "LIKE")
                    {
                        cboOperator.SelectedIndex = 8;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == "NOT LIKE")
                    {
                        cboOperator.SelectedIndex = 9;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == "IS")
                    {
                        cboOperator.SelectedIndex = 10;
                    }
                    else if (MPCF.Trim(out_node.GetString("OPERATOR")) == "IS NOT")
                    {
                        cboOperator.SelectedIndex = 11;
                    }
                }
                b_operator_selection_changed = false;
                if (cdvTableName.Visible == true)
                {
                    cdvTableName.Text = MPCF.Trim(out_node.GetString("TABLE_NAME"));
                }
                /* Added End */
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        
        private void SetControlProperty(string sRuleType)
        {
            
            try
            {
                
                b_use_operator_in_rule = MPGO.UseOperatorInRule();
                
                switch (sRuleType)
                {
                    case "L":
                        
                        cdvValue1.Text = "";
                        cdvValue2.Text = "";
                        txtValue2.Text = "";

                        cboLotType.Text = "";
                        cboClassType.Text = "";
                        cboPoint.SelectedIndex = -1;
                        cboOperator.SelectedIndex = 0;
                        lblTableName.Visible = false;
                        cdvTableName.Visible = false;
                        switch (cdvKey.Text) //((RTD_RULE_LOT)(object)cdvKey.Text)
                        {
                            case "LOT_INFO_MATCH": //RTD_RULE_LOT.LOT_INFO_MATCH :
                                    lblValue1.Visible = true;
                                    lblValue1.Text = MPCF.FindLanguage("Lot Info", 0);
                                    cdvValue1.Visible = true;
                                    cdvValue1.VisibleButton = true;
                                    cdvValue1.ReadOnly = true;
                                    cdvValue2.Visible = false;
                                    
                                    /* Added By YJJung 150731 For operator in RTD */
                                    if (b_use_operator_in_rule == true)
                                    {
                                        lblOperator.Visible = true;
                                        cboOperator.Visible = true;
                                    }
                                    /* End */
                                    if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "P")
                                    {
                                        lblValue2.Visible = true;
                                        lblValue2.Text = MPCF.FindLanguage("Value", 0);
                                        if (cboOperator.SelectedIndex == 10 || cboOperator.SelectedIndex == 11)
                                        {
                                            txtValue2.Visible = false;
                                            cdvValue2.Visible = true;
                                        }
                                        else
                                        {
                                            txtValue2.Visible = true;
                                            cdvValue2.Visible = false;
                                        }
                                        lblPoint.Visible = true;
                                        cboPoint.Visible = true;
                                    }
                                    else
                                    {
                                        lblValue2.Visible = false;
                                        txtValue2.Visible = false;
                                        lblPoint.Visible = false;
                                        cboPoint.Visible = false;
                                    }
                                    lblClassType.Visible = true;
                                    cboClassType.Visible = true;

                                    lblLotType.Text = "Lot Type";
                                    lblLotType.Visible = true;
                                    
                                    cboLotType.Items.Clear();
                                    cboLotType.Items.Add("A");
                                    cboLotType.Items.Add("L");
                                    cboLotType.Visible = true;
                                
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    break;
                                    
                            case "NEXT_RESOURCE_UP": //RTD_RULE_LOT.NEXT_RESOURCE_UP:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;
                            case "SMALL_NEXT_OPER_WIP": //RTD_RULE_LOT.SMALL_NEXT_OPER_WIP:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = false;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = false;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;
                                    
                            case "EARLIEST_START_TIME": //RTD_RULE_LOT.EARLIEST_START_TIME:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = false;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = false;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;

                            case "SHORTEST_DUE_TIME": //RTD_RULE_LOT.SHORTEST_DUE_TIME:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = false;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = false;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;
                                    
                            case "LONGEST_WAIT_TIME": //RTD_RULE_LOT.LONGEST_WAIT_TIME:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = false;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = false;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;
                                    
                            case "MOST_LOT_QUANTITY3": //RTD_RULE_LOT.MOST_LOT_QUANTITY3:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = false;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = false;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;
                                    
                            case "MOST_LOT_QUANTITY2": //RTD_RULE_LOT.MOST_LOT_QUANTITY2:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = false;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = false;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;

                            case "MOST_LOT_QUANTITY1": //RTD_RULE_LOT.MOST_LOT_QUANTITY1:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    cboPoint.Visible = false;
                                    chkSelectFlag.Visible = false;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = false;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;
                                    
                            case "STARTED_LOT": //RTD_RULE_LOT.STARTED_LOT:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;
                                    
                            case "NSTD_LOT": //RTD_RULE_LOT.NSTD_LOT:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;
                                    
                            case "LOT_STATUS_MATCH": //RTD_RULE_LOT.LOT_STATUS_MATCH:
                                    lblValue1.Visible = true;
                                    lblValue1.Text = MPCF.FindLanguage("Lot Status", 0);
                                    cdvValue1.Visible = true;
                                    cdvValue1.VisibleButton = true;
                                    cdvValue1.ReadOnly = true;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;

                                    /* Added By YJJung 150731 For operator in RTD */
                                    if (b_use_operator_in_rule == true)
                                    {
                                        cboOperator.Visible = true;
                                        lblOperator.Visible = true;
                                    }
                                    /* End */
                                    break;

                            case "ORDER_MATCH":
                                #if _ORD
                                    
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Order ID", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                txtValue2.Visible = false;
                                lblClassType.Visible = false;
                                cboClassType.Visible = false;
                                lblLotType.Visible = false;
                                cboLotType.Visible = false;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                #endif
                                break;
                               
                            case "RECIPE_MATCH":
                                #if _RCP
                                    
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("PP ID", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = false;
                                cdvValue1.ReadOnly = false;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                txtValue2.Visible = false;
                                lblClassType.Visible = false;
                                cboClassType.Visible = false;
                                lblLotType.Visible = false;
                                cboLotType.Visible = false;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                #endif
                                break;
                                case "TOOL_MATCH":
                                #if _TOOL
                                    
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Tool Type", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = true;
                                lblValue2.Text = MPCF.FindLanguage("Tool", 0);
                                cdvValue2.Visible = true;
                                cdvValue2.VisibleButton = true;
                                cdvValue2.ReadOnly = true;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                txtValue2.Visible = false;
                                lblClassType.Visible = false;
                                cboClassType.Visible = false;
                                lblLotType.Visible = false;
                                cboLotType.Visible = false;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                #endif
                                break;

                            case "MATERIAL_MATCH": //RTD_RULE_LOT.MATERIAL_MATCH:
                                    lblValue1.Visible = true;
                                    lblValue1.Text = MPCF.FindLanguage("Material", 0);
                                    cdvValue1.Visible = true;
                                    cdvValue1.VisibleButton = true;
                                    cdvValue1.ReadOnly = true;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    if (b_use_operator_in_rule == true)
                                    {
                                        cboOperator.Visible = true;
                                        lblOperator.Visible = true;
                                    }
                                    /* End */
                                    break;

                            case "CREATE_CODE_MATCH": //RTD_RULE_LOT.CREATE_CODE_MATCH:
                                    lblValue1.Visible = true;
                                    lblValue1.Text = MPCF.FindLanguage("Create Code", 0);
                                    cdvValue1.Visible = true;
                                    cdvValue1.VisibleButton = true;
                                    cdvValue1.ReadOnly = true;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    if (b_use_operator_in_rule == true)
                                    {
                                        cboOperator.Visible = true;
                                        lblOperator.Visible = true;
                                    }
                                    /* End */
                                    break;

                            case "OWNER_CODE_MATCH": //RTD_RULE_LOT.OWNER_CODE_MATCH:
                                    lblValue1.Visible = true;
                                    lblValue1.Text = MPCF.FindLanguage("Owner Code", 0);
                                    cdvValue1.Visible = true;
                                    cdvValue1.VisibleButton = true;
                                    cdvValue1.ReadOnly = true;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    if (b_use_operator_in_rule == true)
                                    {
                                        cboOperator.Visible = true;
                                        lblOperator.Visible = true;
                                    }
                                    /* End */
                                    break;

                            case "REWORK_CODE_MATCH": //RTD_RULE_LOT.REWORK_CODE_MATCH:
                                    lblValue1.Visible = true;
                                    lblValue1.Text = MPCF.FindLanguage("Rework Code", 0);
                                    cdvValue1.Visible = true;
                                    cdvValue1.VisibleButton = true;
                                    cdvValue1.ReadOnly = true;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    if (b_use_operator_in_rule == true)
                                    {
                                        cboOperator.Visible = true;
                                        lblOperator.Visible = true;
                                    }
                                    /* End */
                                    break;

                            case "PRIORITY_LEVEL": //RTD_RULE_LOT.PRIORITY_LEVEL:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = false;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = false;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;

                            case "SCH_START_TIME": //RTD_RULE_LOT.SCH_START_TIME:
                                    lblValue1.Visible = false;
                                    cdvValue1.Visible = false;
                                    lblValue2.Visible = false;
                                    cdvValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                    txtValue2.Visible = false;
                                    lblClassType.Visible = false;
                                    cboClassType.Visible = false;
                                    lblLotType.Visible = false;
                                    cboLotType.Visible = false;
                                    chkSelectFlag.Visible = false;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = false;
                                    /* Added By YJJung 150731 For operator in RTD */
                                    cboOperator.Visible = false;
                                    lblOperator.Visible = false;
                                    /* End */
                                    break;
                            case "MIN_CRITICAL_RATIO":
                                lblValue1.Visible = false;
                                cdvValue1.Visible = false;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                lblPoint.Visible = false;
                                cboPoint.Visible = false;
                                txtValue2.Visible = false;
                                lblClassType.Visible = false;
                                cboClassType.Visible = false;
                                lblLotType.Visible = false;
                                cboLotType.Visible = false;
                                chkSelectFlag.Visible = false;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = false;
                                /* Added By YJJung 150731 For operator in RTD */
                                cboOperator.Visible = false;
                                lblOperator.Visible = false;
                                /* End */
                                break;

                            case "LAST_MATERIAL_MATCH":
                                lblValue1.Visible = false;
                                cdvValue1.Visible = false;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                txtValue2.Visible = false;
                                lblClassType.Visible = false;
                                cboClassType.Visible = false;
                                lblLotType.Visible = false;
                                cboLotType.Visible = false;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                cboOperator.Visible = false;
                                lblOperator.Visible = false;
                                /* End */
                                break;

                            case "LESS_WIP_FOLLOW_OPER":
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Look oper count", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                lblPoint.Visible = false;
                                cboPoint.Visible = false;
                                txtValue2.Visible = false;
                                lblClassType.Visible = false;
                                cboClassType.Visible = false;
                                lblLotType.Visible = false;
                                cboLotType.Visible = false;
                                chkSelectFlag.Visible = false;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = false;
                                break;

                            case "LAST_RECIPE_MATCH":
                                lblValue1.Visible = false;
                                cdvValue1.Visible = false;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                txtValue2.Visible = false;
                                lblClassType.Visible = false;
                                cboClassType.Visible = false;
                                lblLotType.Visible = false;
                                cboLotType.Visible = false;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                cboOperator.Visible = false;
                                lblOperator.Visible = false;
                                /* End */
                                break;

                            case "":
                                lblValue1.Visible = true;
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = true;
                                cdvValue2.Visible = true;
                                cdvValue2.VisibleButton = true;
                                cdvValue2.ReadOnly = true;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                txtValue2.Visible = true;
                                lblClassType.Visible = true;
                                cboClassType.Visible = true;
                                lblLotType.Text = "Lot Type";
                                lblLotType.Visible = true;

                                cboLotType.Items.Clear();
                                cboLotType.Items.Add("A");
                                cboLotType.Items.Add("L");
                                cboLotType.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;
                            default:
                                if (MPCF.Trim(cdvKey.Tag).Length > 1 ) //Custom Rule일 경우
                                {
                                    if (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K")
                                    {
                                        //Add by J.S. 2009.03.18 for check value field
                                        cdvValue1.Tag = "";
                                        cdvValue2.Tag = "";

                                        if (MPCF.Trim(cdvKey.Tag).Substring(2, 1) == "0")
                                        {
                                            lblValue1.Visible = false;
                                            cdvValue1.Visible = false;
                                            lblValue2.Visible = false;
                                            cdvValue2.Visible = false;
                                        }
                                        else if (MPCF.Trim(cdvKey.Tag).Substring(2, 1) == "1")
                                        {
                                            lblValue1.Text = MPCF.FindLanguage("Value 1", 0);
                                            lblValue1.Visible = true;
                                            cdvValue1.Visible = true;
                                            cdvValue1.VisibleButton = false;
                                            cdvValue1.ReadOnly = false;
                                            /* Added By YJJung 160215 For Bug Fix */
                                            cdvValue1.Enabled = true;
                                            /* Added End */
                                            lblValue2.Visible = false;
                                            cdvValue2.Visible = false;
                                            /* Added By YJJung 150731 For operator in RTD */
                                            if (b_use_operator_in_rule == true)
                                            {
                                                lblOperator.Visible = true;
                                                cboOperator.Visible = true;
                                            }
                                        
                                        }
                                        else if (MPCF.Trim(cdvKey.Tag).Substring(2, 1) == "2")
                                        {
                                            lblValue1.Text = MPCF.FindLanguage("Value 1", 0);
                                            lblValue1.Visible = true;
                                            cdvValue1.Visible = true;
                                            cdvValue1.VisibleButton = false;
                                            cdvValue1.ReadOnly = false;
                                            /* Added By YJJung 160215 For Bug Fix */
                                            cdvValue1.Enabled = true;
                                            /* Added End */
                                            lblValue2.Text = MPCF.FindLanguage("Value 2", 0);
                                            lblValue2.Visible = true;
                                            cdvValue2.Visible = true;
                                            cdvValue2.VisibleButton = false;
                                            cdvValue2.ReadOnly = false;
                                            /* Added By YJJung 160215 For Bug Fix */
                                            cdvValue2.Enabled = true;
                                            /* Added End */
                                            /* Added By YJJung 150731 For operator in RTD */
                                            if (b_use_operator_in_rule == true)
                                            {
                                                lblOperator.Visible = true;
                                                cboOperator.Visible = true;
                                            }
                                        
                                        }
                                        if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "P")
                                        {
                                            lblPoint.Visible = true;
                                            cboPoint.Visible = true;
                                            chkSelectFlag.Visible = true;
                                            //Add by J.S. 2009.01.19
                                            chkCapableFlag.Visible = true;
                                        }
                                        else
                                        {
                                            lblPoint.Visible = false;
                                            cboPoint.Visible = false;
                                            chkSelectFlag.Visible = true;
                                            //Add by J.S. 2009.01.19
                                            chkCapableFlag.Visible = true;
                                        }
                                        txtValue2.Visible = false;
                                        lblClassType.Visible = false;
                                        cboClassType.Visible = false;
                                        lblLotType.Visible = false;
                                        cboLotType.Visible = false;
                                        if (MPCF.Trim(cdvKey.Tag).Length > 2)
                                        {
                                            if (MPCF.ToInt( MPCF.Trim(cdvKey.Tag).Substring(2, 1)) == 1)
                                            {
                                                cdvValue1.Tag = "Y";
                                            }
                                            else if (MPCF.ToInt( MPCF.Trim(cdvKey.Tag).Substring(2, 1)) > 1)
                                            {
                                                cdvValue1.Tag = "Y";
                                                cdvValue2.Tag = "Y";
                                            }
                                        }
                                        
                                        
                                        break;
                                    }
                                    break;
                                }
                                else
                                {
                                    lblValue1.Visible = true;
                                    cdvValue1.Visible = true;
                                    cdvValue1.VisibleButton = true;
                                    cdvValue1.ReadOnly = true;
                                    lblValue2.Visible = true;
                                    cdvValue2.Visible = true;
                                    cdvValue2.VisibleButton = true;
                                    cdvValue2.ReadOnly = true;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = true;
                                    lblClassType.Visible = true;
                                    cboClassType.Visible = true;
                                    lblLotType.Text = "Lot Type";
                                    lblLotType.Visible = true;

                                    cboLotType.Items.Clear();
                                    cboLotType.Items.Add("A");
                                    cboLotType.Items.Add("L");
                                    cboLotType.Visible = true;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    break;
                                }                                
                        }
                        if (cdvKey.Text == "LOT_INFO_MATCH")
                        {
                            SetLocation(cdvValue1.Visible, txtValue2.Visible, cboPoint.Visible, "L");
                        }
                        else
                        {
                            SetLocation(cdvValue1.Visible, cdvValue2.Visible, cboPoint.Visible, "L");
                        }
                        break;

#if _RAS                        
                    case "R" :
                        cdvValue1.Text = "";
                        cdvValue2.Text = "";
                        cboPoint.SelectedIndex = -1;
                        lblClassType.Visible = false;
                        cboClassType.Visible = false;
                        lblLotType.Visible = false;
                        cboLotType.Visible = false;
                        cboOperator.SelectedIndex = 0;
                        switch (cdvKey.Text) //((RTD_RULE_RES)(object)cdvKey.Text)
                        {
                            case "LAST_EVENT_MATCH": //RTD_RULE_RES.LAST_EVENT_MATCH:
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Event ID", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                txtValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;

                            case "RESOURCE_TYPE_MATCH": //RTD_RULE_RES.RESOURCE_TYPE_MATCH:
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Type", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                txtValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;

                            case "PRIMARY_STATUS": //RTD_RULE_RES.PRIMARY_STATUS:
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Status", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                txtValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;

                            case "UP_DOWN_STATUS": //RTD_RULE_RES.UP_DOWN_STATUS:
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Status", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                txtValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;

                            case "RES_INFO_MATCH": //RTD_RULE_LOT.LOT_STATUS_MATCH:
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Res Info", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "P")
                                {
                                    lblValue2.Visible = true;
                                    lblValue2.Text = MPCF.FindLanguage("Value", 0);
                                    txtValue2.Visible = true;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                }
                                else
                                {
                                    lblValue2.Visible = false;
                                    txtValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                }
                                
                                cdvValue2.Visible = false;
                                
                                lblClassType.Visible = true;
                                cboClassType.Visible = true;

                                lblLotType.Text = "Res Type";
                                lblLotType.Visible = true;

                                cboLotType.Items.Clear();
                                cboLotType.Items.Add("A");
                                cboLotType.Items.Add("R");
                                cboLotType.Visible = true;

                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;
                            case "":
                                lblValue1.Visible = true;
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = true;
                                cdvValue2.Visible = true;
                                cdvValue2.VisibleButton = true;
                                cdvValue2.ReadOnly = true;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                txtValue2.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                break;
                            default:
                                if (MPCF.Trim(cdvKey.Tag).Length > 1)
                                {
                                    if (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K")
                                    {
                                        if (MPCF.Trim(cdvKey.Tag).Substring(2, 1) == "0")
                                        {
                                            lblValue1.Visible = false;
                                            cdvValue1.Visible = false;
                                            lblValue2.Visible = false;
                                            cdvValue2.Visible = false;
                                        }
                                        else if (MPCF.Trim(cdvKey.Tag).Substring(2, 1) == "1")
                                        {
                                            lblValue1.Text = MPCF.FindLanguage("Value 1", 0);
                                            lblValue1.Visible = true;
                                            cdvValue1.Visible = true;
                                            cdvValue1.VisibleButton = false;
                                            cdvValue1.ReadOnly = false;
                                            /* Added By YJJung 160215 For Bug Fix */
                                            cdvValue1.Enabled = true;
                                            /* Added End */
                                            lblValue2.Visible = false;
                                            cdvValue2.Visible = false;
                                            /* Added By YJJung 150731 For operator in RTD */
                                            if (b_use_operator_in_rule == true)
                                            {
                                                lblOperator.Visible = true;
                                                cboOperator.Visible = true;
                                            }
                                        }
                                        else if (MPCF.Trim(cdvKey.Tag).Substring(2, 1) == "2")
                                        {
                                            lblValue1.Text = MPCF.FindLanguage("Value 1", 0);
                                            lblValue1.Visible = true;
                                            cdvValue1.Visible = true;
                                            cdvValue1.VisibleButton = false;
                                            cdvValue1.ReadOnly = false;
                                            /* Added By YJJung 160215 For Bug Fix */
                                            cdvValue1.Enabled = true;
                                            /* Added End */
                                            lblValue2.Text = MPCF.FindLanguage("Value 2", 0);
                                            lblValue2.Visible = true;
                                            cdvValue2.Visible = true;
                                            cdvValue2.VisibleButton = false;
                                            cdvValue2.ReadOnly = false;
                                            /* Added By YJJung 160215 For Bug Fix */
                                            cdvValue2.Enabled = true;
                                            /* Added End */
                                            /* Added By YJJung 150731 For operator in RTD */
                                            if (b_use_operator_in_rule == true)
                                            {
                                                lblOperator.Visible = true;
                                                cboOperator.Visible = true;
                                            }
                                        }
                                        if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "P")
                                        {
                                            lblPoint.Visible = true;
                                            cboPoint.Visible = true;
                                            chkSelectFlag.Visible = true;
                                            //Add by J.S. 2009.01.19
                                            chkCapableFlag.Visible = true;
                                        }
                                        else
                                        {
                                            lblPoint.Visible = false;
                                            cboPoint.Visible = false;
                                            chkSelectFlag.Visible = false;
                                            //Add by J.S. 2009.01.19
                                            chkCapableFlag.Visible = false;
                                        }
                                        txtValue2.Visible = false;
                                        lblClassType.Visible = false;
                                        cboClassType.Visible = false;
                                        lblLotType.Visible = false;
                                        cboLotType.Visible = false;
                                        if (MPCF.Trim(cdvKey.Tag).Length > 2)
                                        {
                                            if (MPCF.ToInt( MPCF.Trim(cdvKey.Tag).Substring(2, 1)) == 1)
                                            {
                                                cdvValue1.Tag = "Y";
                                            }
                                            else if (MPCF.ToInt( MPCF.Trim(cdvKey.Tag).Substring(2, 1)) > 1)
                                            {
                                                cdvValue1.Tag = "Y";
                                                cdvValue2.Tag = "Y";
                                            }
                                        }
                                        break;
                                    }
                                    break;
                                }
                                else
                                {
                                    lblValue1.Visible = true;
                                    cdvValue1.Visible = true;
                                    cdvValue1.VisibleButton = true;
                                    cdvValue1.ReadOnly = true;
                                    lblValue2.Visible = true;
                                    cdvValue2.Visible = true;
                                    cdvValue2.VisibleButton = true;
                                    cdvValue2.ReadOnly = true;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = true;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    cboOperator.Text = "";
                                    cboOperator.Visible = false;
                                    cdvTableName.Text = "";
                                    cdvTableName.Visible = false;
                                    break;
                                }
                               
                        }

                        if (cdvKey.Text == "RES_INFO_MATCH")
                        {
                            SetLocation(cdvValue1.Visible, txtValue2.Visible, cboPoint.Visible, "R");
                        }
                        else
                        {
                            SetLocation(cdvValue1.Visible, cdvValue2.Visible, cboPoint.Visible, "R");
                        }
                                                
#endif
                        break;

                    case "P":
                        cdvValue1.Text = "";
                        cdvValue2.Text = "";
                        cboPoint.SelectedIndex = -1;
                        lblClassType.Visible = false;
                        cboClassType.Visible = false;
                        lblLotType.Visible = false;
                        cboLotType.Visible = false;
                        cboOperator.SelectedIndex = 0;
                        switch (cdvKey.Text) //((RTD_RULE_PORT)(object)cdvKey.Text)
                        {
                            case "PORT_TYPE_MATCH": //RTD_RULE_PORT.PORT_TYPE_MATCH:
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Type", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                txtValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;

                            case "PORT_INFO_MATCH": //RTD_RULE_PORT.PORT_INFO_MATCH:
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Port Info", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "P")
                                {
                                    lblValue2.Visible = true;
                                    lblValue2.Text = MPCF.FindLanguage("Value", 0);
                                    txtValue2.Visible = true;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                }
                                else
                                {
                                    lblValue2.Visible = false;
                                    txtValue2.Visible = false;
                                    lblPoint.Visible = false;
                                    cboPoint.Visible = false;
                                }

                                cdvValue2.Visible = false;

                                lblClassType.Visible = true;
                                cboClassType.Visible = true;

                                lblLotType.Text = "Port Type";
                                lblLotType.Visible = true;
                                lblLotType.Enabled = false;

                                cboLotType.Items.Clear();
                                cboLotType.Items.Add("A");
                                cboLotType.Items.Add("P");
                                cboLotType.Text = "P";
                                cboLotType.Visible = true;
                                cboLotType.Enabled = false;

                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;
                            case "PORT_SEQ": //RTD_RULE_PORT.PORT_SEQ:
                                lblValue1.Visible = false;
                                cdvValue1.Visible = false;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                lblPoint.Visible = false;
                                txtValue2.Visible = false;
                                lblClassType.Visible = false;
                                cboClassType.Visible = false;
                                lblLotType.Visible = false;
                                cboLotType.Visible = false;
                                cboPoint.Visible = false;
                                chkSelectFlag.Visible = false;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = false;
                                /* Added By YJJung 150731 For operator in RTD */
                                cboOperator.Visible = false;
                                lblOperator.Visible = false;
                                /* End */
                                break;
                            case "PORT_LAST_HIST_SEQ": //RTD_RULE_PORT.PORT_LAST_HIST_SEQ:
                                lblValue1.Visible = false;
                                cdvValue1.Visible = false;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                lblPoint.Visible = false;
                                txtValue2.Visible = false;
                                lblClassType.Visible = false;
                                cboClassType.Visible = false;
                                lblLotType.Visible = false;
                                cboLotType.Visible = false;
                                cboPoint.Visible = false;
                                chkSelectFlag.Visible = false;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = false;
                                /* Added By YJJung 150731 For operator in RTD */
                                cboOperator.Visible = false;
                                lblOperator.Visible = false;
                                /* End */
                                break;
                            case "PORT_LOT_MATCH": //RTD_RULE_PORT.PORT_LOT_MATCH:
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("LOT ID", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                txtValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;

                            case "PORT_RES_MATCH": //RTD_RULE_PORT.PORT_RES_MATCH:
                                lblValue1.Visible = true;
                                lblValue1.Text = MPCF.FindLanguage("Resource", 0);
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = false;
                                cdvValue2.Visible = false;
                                txtValue2.Visible = false;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                /* Added By YJJung 150731 For operator in RTD */
                                if (b_use_operator_in_rule == true)
                                {
                                    cboOperator.Visible = true;
                                    lblOperator.Visible = true;
                                }
                                /* End */
                                break;

                            case "":
                                lblValue1.Visible = true;
                                cdvValue1.Visible = true;
                                cdvValue1.VisibleButton = true;
                                cdvValue1.ReadOnly = true;
                                lblValue2.Visible = true;
                                cdvValue2.Visible = true;
                                cdvValue2.VisibleButton = true;
                                cdvValue2.ReadOnly = true;
                                lblPoint.Visible = true;
                                cboPoint.Visible = true;
                                txtValue2.Visible = true;
                                chkSelectFlag.Visible = true;
                                //Add by J.S. 2009.01.19
                                chkCapableFlag.Visible = true;
                                break;
                            default:
                                if (MPCF.Trim(cdvKey.Tag).Length > 1)
                                {
                                    if (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K")
                                    {
                                        if (MPCF.Trim(cdvKey.Tag).Substring(2, 1) == "0")
                                        {
                                            lblValue1.Visible = false;
                                            cdvValue1.Visible = false;
                                            lblValue2.Visible = false;
                                            cdvValue2.Visible = false;
                                        }
                                        else if (MPCF.Trim(cdvKey.Tag).Substring(2, 1) == "1")
                                        {
                                            lblValue1.Text = MPCF.FindLanguage("Value 1", 0);
                                            lblValue1.Visible = true;
                                            cdvValue1.Visible = true;
                                            cdvValue1.VisibleButton = false;
                                            cdvValue1.ReadOnly = false;
                                            /* Added By YJJung 160215 For Bug Fix */
                                            cdvValue1.Enabled = true;
                                            /* Added End */
                                            lblValue2.Visible = false;
                                            cdvValue2.Visible = false;
                                            /* Added By YJJung 150731 For operator in RTD */
                                            if (b_use_operator_in_rule == true)
                                            {
                                                lblOperator.Visible = true;
                                                cboOperator.Visible = true;
                                            }
                                        }
                                        else if (MPCF.Trim(cdvKey.Tag).Substring(2, 1) == "2")
                                        {
                                            lblValue1.Text = MPCF.FindLanguage("Value 1", 0);
                                            lblValue1.Visible = true;
                                            cdvValue1.Visible = true;
                                            cdvValue1.VisibleButton = false;
                                            cdvValue1.ReadOnly = false;
                                            /* Added By YJJung 160215 For Bug Fix */
                                            cdvValue1.Enabled = true;
                                            /* Added End */
                                            lblValue2.Text = MPCF.FindLanguage("Value 2", 0);
                                            lblValue2.Visible = true;
                                            cdvValue2.Visible = true;
                                            cdvValue2.VisibleButton = false;
                                            cdvValue2.ReadOnly = false;
                                            /* Added By YJJung 160215 For Bug Fix */
                                            cdvValue2.Enabled = true;
                                            /* Added End */
                                            /* Added By YJJung 150731 For operator in RTD */
                                            if (b_use_operator_in_rule == true)
                                            {
                                                lblOperator.Visible = true;
                                                cboOperator.Visible = true;
                                            }
                                        }
                                        if (MPCF.Trim(cdvKey.Tag).Substring(0, 1) == "P")
                                        {
                                            lblPoint.Visible = true;
                                            cboPoint.Visible = true;
                                            chkSelectFlag.Visible = true;
                                            //Add by J.S. 2009.01.19
                                            chkCapableFlag.Visible = true;
                                        }
                                        else
                                        {
                                            lblPoint.Visible = false;
                                            cboPoint.Visible = false;
                                            chkSelectFlag.Visible = false;
                                            //Add by J.S. 2009.01.19
                                            chkCapableFlag.Visible = false;
                                        }
                                        txtValue2.Visible = false;
                                        lblClassType.Visible = false;
                                        cboClassType.Visible = false;
                                        lblLotType.Visible = false;
                                        cboLotType.Visible = false;
                                        if (MPCF.Trim(cdvKey.Tag).Length > 2)
                                        {
                                            if (MPCF.ToInt(MPCF.Trim(cdvKey.Tag).Substring(2, 1)) == 1)
                                            {
                                                cdvValue1.Tag = "Y";
                                            }
                                            else if (MPCF.ToInt(MPCF.Trim(cdvKey.Tag).Substring(2, 1)) > 1)
                                            {
                                                cdvValue1.Tag = "Y";
                                                cdvValue2.Tag = "Y";
                                            }
                                        }
                                        break;
                                    }
                                    break;
                                }
                                else
                                {
                                    lblValue1.Visible = true;
                                    cdvValue1.Visible = true;
                                    cdvValue1.VisibleButton = true;
                                    cdvValue1.ReadOnly = true;
                                    lblValue2.Visible = true;
                                    cdvValue2.Visible = true;
                                    cdvValue2.VisibleButton = true;
                                    cdvValue2.ReadOnly = true;
                                    lblPoint.Visible = true;
                                    cboPoint.Visible = true;
                                    txtValue2.Visible = true;
                                    chkSelectFlag.Visible = true;
                                    //Add by J.S. 2009.01.19
                                    chkCapableFlag.Visible = true;
                                    cboOperator.Text = "";
                                    cboOperator.Visible = false;
                                    cdvTableName.Text = "";
                                    cdvTableName.Visible = false;
                                    break;
                                }

                        }

                        if (cdvKey.Text == "PORT_INFO_MATCH")
                        {
                            SetLocation(cdvValue1.Visible, txtValue2.Visible, cboPoint.Visible, "P");
                        }
                        else
                        {
                            SetLocation(cdvValue1.Visible, cdvValue2.Visible, cboPoint.Visible, "P");
                        }
                        break;
                }

                if (MPCF.Trim(cdvKey.Tag).Length > 1)
                {
                    if (MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K")
                    {
                        chkReal.Visible = true;
                    }
                }
                else
                {
                    chkReal.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //
        // SetLotEnumList()
        //       - Enum to List
        // Return Value
        //       -
        // Arguments
        //       - ByVal cboTarget As ComboBox   :  Combo Box
        //       - ByVal enumType As Type        :  Type
        //
        private void SetLotEnumList(ListView cdvTarget)
        {
            ListViewItem itmX;
            try
            {
                string sEnumString = "";
                foreach (string tempLoopVar_sEnumString in @Enum.GetNames(typeof(RTD_RULE_LOT)))
                {
                    sEnumString = tempLoopVar_sEnumString;
#if _RCP
#else

                    if (sEnumString == RTD_RULE_LOT.RECIPE_MATCH.ToString())
                    {
                        continue;
                    }
#endif
// Delete BY James Kwon 2008/02/15
//#if _TOOL
//#else
// End of Delete
                    if (sEnumString == RTD_RULE_LOT.TOOL_MATCH.ToString())
                    {
                        continue;
                    }
// Delete BY James Kwon 2008/02/15
//#endif
// End of Delete
                    itmX = new ListViewItem(sEnumString, (int)SMALLICON_INDEX.IDX_KEY);
                    if (sEnumString == RTD_RULE_LOT.MIN_CRITICAL_RATIO.ToString())
                    {
                        itmX.SubItems.Add("C");
                    }
                    else if (sEnumString == RTD_RULE_LOT.MOST_LOT_QUANTITY1.ToString() || sEnumString == RTD_RULE_LOT.MOST_LOT_QUANTITY2.ToString() || sEnumString == RTD_RULE_LOT.MOST_LOT_QUANTITY3.ToString() || sEnumString == RTD_RULE_LOT.SMALL_NEXT_OPER_WIP.ToString())
                    {
                        itmX.SubItems.Add("N");
                    }
                    else if (sEnumString == RTD_RULE_LOT.LONGEST_WAIT_TIME.ToString() || sEnumString == RTD_RULE_LOT.SHORTEST_DUE_TIME.ToString() || sEnumString == RTD_RULE_LOT.EARLIEST_START_TIME.ToString() || sEnumString == RTD_RULE_LOT.SCH_START_TIME.ToString() || sEnumString == RTD_RULE_LOT.LESS_WIP_FOLLOW_OPER.ToString())
                    {
                        itmX.SubItems.Add("T");
                    }
                    else
                    {
                        itmX.SubItems.Add("P");
                    }
                    cdvTarget.Items.Add(itmX);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        //
        // SetResEnumList()
        //       - Enum to List
        // Return Value
        //       -
        // Arguments
        //       - ByVal cboTarget As ComboBox   :  Combo Box
        //       - ByVal enumType As Type        :  Type
        //
        private void SetResEnumList(ListView cdvTarget)
        {
            
            ListViewItem itmX;
            
            try
            {
                string sEnumString = "";
                #if _RAS
                foreach (string tempLoopVar_sEnumString in @Enum.GetNames(typeof(RTD_RULE_RES)))
                {
                    sEnumString = tempLoopVar_sEnumString;
                    itmX = new ListViewItem(sEnumString, (int)SMALLICON_INDEX.IDX_KEY);
                    //if (sEnumString == RTD_RULE_RES.UP_DOWN_STATUS.ToString() || sEnumString == RTD_RULE_RES.PRIMARY_STATUS.ToString() || sEnumString == RTD_RULE_RES.RESOURCE_TYPE_MATCH.ToString() || sEnumString == RTD_RULE_RES.LAST_EVENT_MATCH.ToString())
                    //{
                    //    itmX.SubItems.Add("P");
                    //}
                    //else
                    //{
                    //    itmX.SubItems.Add("T");
                    //    itmX.SubItems.Add("N");
                    //}
                    itmX.SubItems.Add("P");
                    cdvTarget.Items.Add(itmX);
                }
                #endif
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        //
        // SetResEnumList()
        //       - Enum to List
        // Return Value
        //       -
        // Arguments
        //       - ByVal cboTarget As ComboBox   :  Combo Box
        //       - ByVal enumType As Type        :  Type
        //
        private void SetPortEnumList(ListView cdvTarget)
        {

            ListViewItem itmX;

            try
            {
                string sEnumString = "";
#if _RAS
                foreach (string tempLoopVar_sEnumString in @Enum.GetNames(typeof(RTD_RULE_PORT)))
                {
                    sEnumString = tempLoopVar_sEnumString;
                    itmX = new ListViewItem(sEnumString, (int)SMALLICON_INDEX.IDX_KEY);
                    itmX.SubItems.Add("P");
                    cdvTarget.Items.Add(itmX);
                }
#endif

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }
        private void SetLocation(bool bValue1, bool bValue2, bool bPoint, string sRuleType)
        {
            try
            {
                if (bValue1 == true && bValue2 == true && bPoint == true)
                {
                    lblValue1.Top = 91;
                    cdvValue1.Top = 88;
                    lblValue2.Top = 115;
                    cdvValue2.Top = 112;
                    lblPoint.Top = 139;
                    cboPoint.Top = 136;
                }
                else if (bValue1 == true && bValue2 == false && bPoint == true)
                {
                    lblValue1.Top = 91;
                    cdvValue1.Top = 88;
                    lblPoint.Top = 115;
                    cboPoint.Top = 112;                
                }
                else if (bValue1 == false && bValue2 == false && bPoint == true)
                {
                    lblPoint.Top = 91;
                    cboPoint.Top = 88;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private bool ExistListItem(ListView MyListView, string Item, char c_step)
        {
            int index;
            
            if (Item == "")
            {
                return false;
            }
            if (c_step == '1')
            {
                for (index = 0; index <= MyListView.Items.Count - 1; index++)
                {
                    if (MyListView.Items[index].Text == Item)
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (index = 0; index <= MyListView.Items.Count - 1; index++)
                {
                    if (MyListView.Items[index].Text == Item)
                    {
                        if (MyListView.SelectedItems[0].Index != index)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisRule;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }

        private bool GetTableColumn(ListView listView, char c_rule_type)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            if (c_rule_type == 'L')
            {
                in_node.AddString("SQL", "SELECT * FROM MWIPLOTSTS WHERE ROWNUM = 1");
            }
            else if (c_rule_type == 'R')
            {
                in_node.AddString("SQL", "SELECT * FROM MRASRESDEF WHERE ROWNUM = 1");
            }
            else if (c_rule_type == 'P')
            {
                in_node.AddString("SQL", "SELECT * FROM MRASPOTDEF WHERE ROWNUM = 1");
            }

            if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
            {
                return false;
            }

            for (int iCol = 1; iCol < out_node.GetList(0).Count; iCol++)
            {
                ListViewItem listViewItem = new ListViewItem(out_node.GetList(0)[iCol].GetString("NAME"));
                listViewItem.SubItems.Add(out_node.GetList(0)[iCol].GetString("TYPE"));

                listView.Items.Add(listViewItem);
            }

            return true;
        }

        private bool GetAttrNames(ListView listView, char c_rule_type)
        {
            TRSNode in_node = new TRSNode("LIST_IN");
            TRSNode out_node = new TRSNode("LIST_OUT");

            int i;

            MPCF.InitListView(listView);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            if (c_rule_type == 'L')
            {
                in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_LOT);
            }
            else if (c_rule_type == 'R')
            {
                in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_RESOURCE);
            }
            else if (c_rule_type == 'P')
            {
                in_node.AddString("ATTR_TYPE", MPGC.MP_ATTR_TYPE_RESOURCE);
            }

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Attribute_Name_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    ListViewItem listViewItem = new ListViewItem(out_node.GetList(0)[i].GetString("ATTR_NAME"));
                    listViewItem.SubItems.Add(out_node.GetList(0)[i].GetString("ATTR_DESC"));

                    listView.Items.Add(listViewItem);
                }
                in_node.SetString("NEXT_ATTR_NAME", out_node.GetString("NEXT_ATTR_NAME"));
                in_node.SetInt("NEXT_ATTR_SEQ", out_node.GetInt("NEXT_ATTR_SEQ"));

            } while (out_node.GetString("NEXT_ATTR_NAME") != "" || out_node.GetInt("NEXT_ATTR_SEQ") > 0);

            return true;
        }

       #endregion
        
        private void frmRTDSetupRuleItem_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {

                    lblDataCount.Text = "";
                    if (RTDLIST.ViewRuleList(lisRule, '1', null, "", ' ') == true)
                    {
                        lblDataCount.Text = lisRule.Items.Count.ToString();
                    }
                    else
                    {
                        return;
                    }
                    if (lisRule.Items.Count > 0)
                    {
                        lisRule.Items[0].Selected = true;
                    }

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmRTDSetupRuleItem_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this);
                MPCF.InitListView(lisRule);
                MPCF.InitListView(lisRuleItem);

                cdvRuleType.BackColor = System.Drawing.SystemColors.Control;
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
                MPCF.ExportToExcel(lisRule, this.Text, "");
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
                if (RTDLIST.ViewRuleList(lisRule, '1', null, "", ' ') == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisRule.Items.Count);
                }
                if (lisRule.Items.Count > 0)
                {
                    MPCF.FindListItem(lisRule, txtRuleID.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemNextPartial(lisRule, txtFind.Text, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FindListItemPartial(lisRule, txtFind.Text, 0, true, false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisRule_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight);
                MPCF.ClearList(this.lisRuleItem, true);
                cdvValue1.Init();
                cdvValue2.Init();
                
                if (lisRule.SelectedItems.Count > 0)
                {
                    txtRuleID.Text = lisRule.SelectedItems[0].Text;
                    cdvRuleType.Text = lisRule.SelectedItems[0].SubItems[1].Text;
                    txtDesc.Text = lisRule.SelectedItems[0].SubItems[2].Text;
                    if (RTDLIST.ViewRuleItemList(lisRuleItem, '1', txtRuleID.Text, Convert.ToChar(MPCF.Trim(cdvRuleType.Text)), null, "") == true)
                    {
                        if (lisRuleItem.Items.Count > 0)
                        {
                            lisRuleItem.Items[0].Selected = true;
                        }
                        else
                        {
                            SetControlProperty(MPCF.Trim(cdvRuleType.Text));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void lisRuleItem_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.grpRule);
                if (lisRuleItem.SelectedItems.Count > 0)
                {
                    View_Rule_Item(MPCF.Trim(cdvRuleType.Text));
                }
                else
                {

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
                if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                if (Update_Rule_Items(MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                
                RTDLIST.ViewRuleItemList(lisRuleItem, '1', txtRuleID.Text, Convert.ToChar(MPCF.Trim(cdvRuleType.Text)), null, "");

                //Add by J.S. 2009.03.18
                MPCF.FindListItem(lisRuleItem, cboLevel.Text, 0, cdvKey.Text, 3, false);


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
                if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                if (Update_Rule_Items(MPGC.MP_STEP_DELETE) == false)
                {
                    return;
                }
                
               MPCF.FieldClear(this.grpRule);
                RTDLIST.ViewRuleItemList(lisRuleItem, '1', txtRuleID.Text, Convert.ToChar(MPCF.Trim(cdvRuleType.Text)), null, "");

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
                if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                if (Update_Rule_Items(MPGC.MP_STEP_UPDATE) == false)
                {
                    return;
                }
                
                RTDLIST.ViewRuleItemList(lisRuleItem, '1', txtRuleID.Text, Convert.ToChar(MPCF.Trim(cdvRuleType.Text)), null, "");

                //Add by J.S. 2009.03.18
                MPCF.FindListItem(lisRuleItem, cboLevel.Text, 0, cdvKey.Text, 3, false);
            
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvKey_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvKey.Init();
                MPCF.InitListView(cdvKey.GetListView);
                cdvKey.Columns.Add("Key", 100, HorizontalAlignment.Left);
                cdvKey.Columns.Add("Type", 50, HorizontalAlignment.Left);
                cdvKey.SelectedSubItemIndex = 0;
                if (Convert.ToChar(MPCF.Trim(cdvRuleType.Text)) == 'L')
                    SetLotEnumList(cdvKey.GetListView);
                else if (Convert.ToChar(MPCF.Trim(cdvRuleType.Text)) == 'R')
                    SetResEnumList(cdvKey.GetListView);
                else if (Convert.ToChar(MPCF.Trim(cdvRuleType.Text)) == 'P')
                    SetPortEnumList(cdvKey.GetListView);

                SVMLIST.ViewServiceListbyKey(cdvKey.GetListView, "RTD",MPCF.Trim(cdvRuleType.Text),  false);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvKey_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (MPCF.Trim(cdvKey.Text) == "")
                {
                    return;
                }
                cdvValue1.Init();
                cdvValue2.Init();
                cdvKey.Tag = cdvKey.SelectedItem.SubItems[1].Text;
                if (cdvKey.SelectedItem.Tag != null)
                {
                    cdvKey.Tag = MPCF.Trim(cdvKey.Tag) + MPCF.Trim(cdvKey.SelectedItem.Tag);
                }
                SetControlProperty(MPCF.Trim(cdvRuleType.Text));
                if (MPCF.Trim(cdvKey.Tag) != "")
                {
                    cboClassType.Text = MPCF.Trim(cdvKey.Tag).Substring(0, 1);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvValue_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (MPCF.Trim(cdvRuleType.Text) == "L")
                {
                   
                    if (cdvKey.Text != RTD_RULE_LOT.LOT_INFO_MATCH.ToString() && (cboOperator.SelectedIndex == 10 || cboOperator.SelectedIndex == 11))
                    {
                        return;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.LOT_INFO_MATCH.ToString())
                    {
                        if (MPCF.CheckValue(cboLotType, 1) == false)
                        {
                            return;
                        }

                        if (cboLotType.Text == "L")
                        {
                            //MWIPLOTSTS의 전체 Field를 가져와 보여줌
                            cdvValue1.Init();
                            MPCF.InitListView(cdvValue1.GetListView);
                            cdvValue1.Columns.Add("Column ID", 100, HorizontalAlignment.Left);
                            cdvValue1.Columns.Add("Column Type", 100, HorizontalAlignment.Left);
                            cdvValue1.SelectedSubItemIndex = 0;
                            GetTableColumn(cdvValue1.GetListView, 'L');
                        }
                        else if (cboLotType.Text == "A")
                        {
                            //MATRNAMDEF 의 전체 Attribute Name를 가져와 보여줌
                            cdvValue1.Init();
                            MPCF.InitListView(cdvValue1.GetListView);
                            cdvValue1.Columns.Add("Column ID", 100, HorizontalAlignment.Left);
                            cdvValue1.Columns.Add("Column Type", 100, HorizontalAlignment.Left);
                            cdvValue1.SelectedSubItemIndex = 0;
                            GetAttrNames(cdvValue1.GetListView, 'L');
                        }
                        //
                        //cdvKey.IsPopup = false;
                    }
                   

                    if (cdvKey.Text == RTD_RULE_LOT.MATERIAL_MATCH.ToString())
                    {

                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Material ID", 100, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        WIPLIST.ViewMaterialList(cdvValue1.GetListView, '1');
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.RECIPE_MATCH.ToString())
                    {
#if _RCP

                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Resource", 150, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        RTDLIST.ViewDspResList(cdvValue1.GetListView, '1', txtRuleID.Text, null, "");
#endif
                    }

                    if (cdvKey.Text == RTD_RULE_LOT.TOOL_MATCH.ToString())
                    {
#if _TOOL
                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Type", 100, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        RASLIST.ViewToolTypeList(cdvValue1.GetListView, '1', 'N', 'N', null);
#endif
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.ORDER_MATCH.ToString())
                    {
#if _ORD

                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Order ID", 100, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Mat ID", 200, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Mat Ver", 200, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Order Qty", 200, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        ORDLIST.ViewOrderList(cdvValue1.GetListView, '1', "", null, "");
#endif
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.NEXT_RESOURCE_UP.ToString())
                    {
                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.SMALL_NEXT_OPER_WIP.ToString())
                    {
                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.EARLIEST_START_TIME.ToString())
                    {

                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.SHORTEST_DUE_TIME.ToString())
                    {

                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.LONGEST_WAIT_TIME.ToString())
                    {

                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.STARTED_LOT.ToString())
                    {
                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.NSTD_LOT.ToString())
                    {
                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.MOST_LOT_QUANTITY3.ToString())
                    {
                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.MOST_LOT_QUANTITY2.ToString())
                    {
                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.MOST_LOT_QUANTITY1.ToString())
                    {
                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.LOT_STATUS_MATCH.ToString())
                    {
                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("LOT STATUS", 50, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        cdvValue1.Items.Add(MPGC.MP_LOT_STATUS_PROC, (int)SMALLICON_INDEX.IDX_CODE_DATA);
                        cdvValue1.Items.Add(MPGC.MP_LOT_STATUS_WAIT, (int)SMALLICON_INDEX.IDX_CODE_DATA);
                        cdvValue1.Items.Add(MPGC.MP_LOT_STATUS_RESV, (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.CREATE_CODE_MATCH.ToString())
                    {
                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Rework Code", 50, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        BASLIST.ViewGCMDataList(cdvValue1.GetListView, '1', "CREATE_CODE");
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.OWNER_CODE_MATCH.ToString())
                    {
                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Rework Code", 50, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        BASLIST.ViewGCMDataList(cdvValue1.GetListView, '1', "OWNER_CODE");
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.REWORK_CODE_MATCH.ToString())
                    {
                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Rework Code", 50, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        BASLIST.ViewGCMDataList(cdvValue1.GetListView, '1', "REWORK_CODE");
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.PRIORITY_LEVEL.ToString())
                    {
                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.SCH_START_TIME.ToString())
                    {

                        cdvKey.IsPopup = false;
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.LESS_WIP_FOLLOW_OPER.ToString())
                    {
                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Count", 50, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        for (int i = 1; i <= 10; i++)
                        {
                            cdvValue1.Items.Add(i.ToString(), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                        }                        
                    }
                }
                else if (MPCF.Trim(cdvRuleType.Text) == "R")
                {

#if _RAS            
                    if (cdvKey.Text != RTD_RULE_RES.RES_INFO_MATCH.ToString() && (cboOperator.SelectedIndex == 10 || cboOperator.SelectedIndex == 11))
                    {
                        return;
                    }
                    if (cdvKey.Text == RTD_RULE_RES.LAST_EVENT_MATCH.ToString())
                    {

                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Event ID", 50, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        RASLIST.ViewEventList(cdvValue1.GetListView, '1', "", null, "");
                    }
                    if (cdvKey.Text == RTD_RULE_RES.RESOURCE_TYPE_MATCH.ToString())
                    {

                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Resource Type", 50, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        BASLIST.ViewGCMDataList(cdvValue1.GetListView, '1', MPGC.MP_RAS_RES_TYPE);
                    }
                    if (cdvKey.Text == RTD_RULE_RES.PRIMARY_STATUS.ToString())
                    {

                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Primary Status", 50, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        RTDLIST.ViewResourcePriSts(cdvValue1.GetListView, '1');
                    }
                    if (cdvKey.Text == RTD_RULE_RES.UP_DOWN_STATUS.ToString())
                    {

                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Status", 50, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        cdvValue1.Items.Add("UP", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                        cdvValue1.Items.Add("DOWN", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    }
                    if (cdvKey.Text == RTD_RULE_RES.RES_INFO_MATCH.ToString())
                    {
                        if (MPCF.CheckValue(cboLotType, 1) == false)
                        {
                            return;
                        }

                        if (cboLotType.Text == "R")
                        {
                            //MWIPLOTSTS의 전체 Field를 가져와 보여줌
                            cdvValue1.Init();
                            MPCF.InitListView(cdvValue1.GetListView);
                            cdvValue1.Columns.Add("Column ID", 100, HorizontalAlignment.Left);
                            cdvValue1.Columns.Add("Column Type", 100, HorizontalAlignment.Left);
                            cdvValue1.SelectedSubItemIndex = 0;
                            GetTableColumn(cdvValue1.GetListView, 'R');
                        }
                        else if (cboLotType.Text == "A")
                        {
                            //MATRNAMDEF 의 전체 Attribute Name를 가져와 보여줌
                            cdvValue1.Init();
                            MPCF.InitListView(cdvValue1.GetListView);
                            cdvValue1.Columns.Add("Column ID", 100, HorizontalAlignment.Left);
                            cdvValue1.Columns.Add("Column Type", 100, HorizontalAlignment.Left);
                            cdvValue1.SelectedSubItemIndex = 0;
                            GetAttrNames(cdvValue1.GetListView, 'R');
                        }
                        //
                        //cdvKey.IsPopup = false;
                    }


                    cdvKey.IsPopup = false;
                }
#endif
                else if (MPCF.Trim(cdvRuleType.Text) == "P")
                {
                    if (cdvKey.Text != RTD_RULE_PORT.PORT_INFO_MATCH.ToString() && (cboOperator.SelectedIndex == 10 || cboOperator.SelectedIndex == 11))
                    {
                        return;
                    }

                    if (cdvKey.Text == RTD_RULE_PORT.PORT_TYPE_MATCH.ToString())
                    {

                        cdvValue1.Init();
                        MPCF.InitListView(cdvValue1.GetListView);
                        cdvValue1.Columns.Add("Port Type", 50, HorizontalAlignment.Left);
                        cdvValue1.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                        cdvValue1.SelectedSubItemIndex = 0;
                        BASLIST.ViewGCMDataList(cdvValue1.GetListView, '1', MPGC.MP_RAS_PORT_TYPE);
                    }
 
                    if (cdvKey.Text == RTD_RULE_PORT.PORT_INFO_MATCH.ToString())
                    {
                        if (MPCF.CheckValue(cboLotType, 1) == false)
                        {
                            return;
                        }

                        if (cboLotType.Text == "P")
                        {
                            cdvValue1.Init();
                            MPCF.InitListView(cdvValue1.GetListView);
                            cdvValue1.Columns.Add("Column ID", 100, HorizontalAlignment.Left);
                            cdvValue1.Columns.Add("Column Type", 100, HorizontalAlignment.Left);
                            cdvValue1.SelectedSubItemIndex = 0;
                            GetTableColumn(cdvValue1.GetListView, 'P');
                        }
                        else if (cboLotType.Text == "A")
                        {
                            //MATRNAMDEF 의 전체 Attribute Name를 가져와 보여줌
                            cdvValue1.Init();
                            MPCF.InitListView(cdvValue1.GetListView);
                            cdvValue1.Columns.Add("Column ID", 100, HorizontalAlignment.Left);
                            cdvValue1.Columns.Add("Column Type", 100, HorizontalAlignment.Left);
                            cdvValue1.SelectedSubItemIndex = 0;
                            GetAttrNames(cdvValue1.GetListView, 'R');
                        }
                        //
                        //cdvKey.IsPopup = false;
                    }


                    cdvKey.IsPopup = false;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvValue2_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(cdvValue1, 1) == false)
                {
                    cdvValue1.Focus();
                    cdvValue2.Init();
                    return;
                }
                else
                {
                    cdvValue2.Init();
                    MPCF.InitListView(cdvValue2.GetListView);
                    cdvValue2.Columns.Add("Null/Blank", 50, HorizontalAlignment.Left);
                    cdvValue2.SelectedSubItemIndex = 0;
                    cdvValue2.Items.Add("$NULL", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    cdvValue2.Items.Add("$BLANK", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    cdvValue2.InsertEmptyRow(0, 1);
                }

                if (MPCF.Trim(cdvRuleType.Text) == "L")
                {
                    if (cdvKey.Text == RTD_RULE_LOT.RECIPE_MATCH.ToString())
                    {
#if _RCP
                        cdvValue2.Init();
                        MPCF.InitListView(cdvValue2.GetListView);
                        cdvValue2.Columns.Add("Recipe", 150, HorizontalAlignment.Left);
                        cdvValue2.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                        cdvValue2.SelectedSubItemIndex = 0;
                        RCPLIST.ViewRecipeList(cdvValue2.GetListView, '1', cdvValue1.Text, "", null, "", -1, -1);
#endif
                    }
                    if (cdvKey.Text == RTD_RULE_LOT.TOOL_MATCH.ToString())
                    {
#if _TOOL
                        cdvValue2.Init();
                        MPCF.InitListView(cdvValue2.GetListView);
                        cdvValue2.Columns.Add("Reticle", 100, HorizontalAlignment.Left);
                        cdvValue2.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                        cdvValue2.SelectedSubItemIndex = 0;
                        RASLIST.ViewToolList(cdvValue2.GetListView, '2', cdvValue1.Text, ' ', false, null);
#endif
                    }
                }
                else if (MPCF.Trim(cdvRuleType.Text) == "R")
                {
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvValue1_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                cdvValue2.Text = "";
                txtValue2.Text = "";

                cboLotType.Text = "";
                cboClassType.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cboClassType_DropDownClosed(object sender, EventArgs e)
        {
            if (cboClassType.Text == "P")
            {
                lblValue2.Visible = true;
                txtValue2.Visible = true;

                lblPoint.Visible = true;
                cboPoint.Visible = true;
            }
            else
            {
                txtValue2.Text = "";
                cdvValue2.Text = "";
                cboPoint.Text = "";

                lblValue2.Visible = false;
                txtValue2.Visible = false;
                cdvValue2.Visible = false;

                lblPoint.Visible = false;
                cboPoint.Visible = false;
            }
        }

        private void cboLotType_DropDownClosed(object sender, EventArgs e)
        {
            cdvValue1.Text = "";
            txtValue2.Text = "";
            cboClassType.Text = "";
            cboPoint.Text = "";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition(MPGC.MP_STEP_COPY) == false)
                {
                    return;
                }
                if (Copy_Dispatch_Rule(MPGC.MP_STEP_COPY) == false)
                {
                    return;
                }

                btnRefresh.PerformClick();

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void tabRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabRule.SelectedTab == this.tbpItems)
                {
                    MPCF.FieldClear(this.pnlRight);
                    MPCF.ClearList(this.lisRuleItem, true);
                    cdvValue1.Init();
                    cdvValue2.Init();

                    if (lisRule.SelectedItems.Count > 0)
                    {
                        txtRuleID.Text = lisRule.SelectedItems[0].Text;
                        cdvRuleType.Text = lisRule.SelectedItems[0].SubItems[1].Text;
                        txtDesc.Text = lisRule.SelectedItems[0].SubItems[2].Text;
                        if (RTDLIST.ViewRuleItemList(lisRuleItem, '1', txtRuleID.Text, Convert.ToChar(MPCF.Trim(cdvRuleType.Text)), null, "") == true)
                        {
                            if (lisRuleItem.Items.Count > 0)
                            {
                                lisRuleItem.Items[0].Selected = true;
                            }
                            else
                            {
                                SetControlProperty(MPCF.Trim(cdvRuleType.Text));
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
        /* Added By YJJung 150731 */
        private void cboOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOperator.SelectedIndex == 6 || cboOperator.SelectedIndex == 7 )
            {
                lblTableName.Text = "Table Name";
                lblTableName.Visible = true;
                cdvTableName.Visible = true;
                cdvTableName.Text = "";
                if (cdvValue2.Visible == true || txtValue2.Visible == true)
                {
                    cdvValue2.Text = "";
                    cdvValue2.Enabled = false;
                    txtValue2.Text = "";
                    txtValue2.Enabled = false;
                }
                else if (cdvValue1.Visible == true)
                {
                    cdvValue1.Text = "";
                    cdvValue1.Enabled = false;
                }

            }
            else if (cboOperator.SelectedIndex == 2 || cboOperator.SelectedIndex == 3 || cboOperator.SelectedIndex == 4 || cboOperator.SelectedIndex == 5 ||
                cboOperator.SelectedIndex == 8 || cboOperator.SelectedIndex == 9 )
            {
                lblTableName.Visible = false;
                cdvTableName.Visible = false;
                if (cdvValue2.Visible == true || txtValue2.Visible == true)
                {
                    cdvValue2.Enabled = false;
                    cdvValue2.VisibleButton = false;
                    cdvValue2.ReadOnly = false;
                    cdvValue2.Visible = false;
                    if (b_operator_selection_changed == false)
                    {
                        cdvValue2.Text = "";
                    }
                    txtValue2.Enabled = true;
                    txtValue2.Visible = true;
                    if (b_operator_selection_changed == false)
                    {
                        txtValue2.Text = "";
                    }
                    
                }
                else if (cdvValue1.Visible == true)
                {
                    cdvValue1.VisibleButton = false;
                    cdvValue1.Enabled = true;
                    cdvValue1.ReadOnly = false;
                    if (b_operator_selection_changed == false)
                    {
                        cdvValue1.Text = "";
                    }
                }
            }
            else if (cboOperator.SelectedIndex == 10 || cboOperator.SelectedIndex == 11)
            {
                lblTableName.Visible = false;
                cdvTableName.Visible = false;
                if (cdvValue2.Visible == true || txtValue2.Visible == true)
                {
                    txtValue2.Visible = false;
                    cdvValue2.Visible = true;
                    if (b_operator_selection_changed == false)
                    {
                        txtValue2.Text = "";
                    }
                    cdvValue2.VisibleButton = true;
                    cdvValue2.Enabled = true;
                    cdvValue2.ReadOnly = true;
                    if (b_operator_selection_changed == false)
                    {
                        cdvValue2.Text = "";
                    }
                    cdvValue2.Init();
                    MPCF.InitListView(cdvValue2.GetListView);
                    cdvValue2.Columns.Add("Null/Blank", 50, HorizontalAlignment.Left);
                    cdvValue2.SelectedSubItemIndex = 0;
                    cdvValue2.Items.Add("$NULL", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    cdvValue2.Items.Add("$BLANK", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    cdvValue2.InsertEmptyRow(0, 1);
                }
                else if (cdvValue1.Visible == true )
                {
                    cdvValue1.Visible = true;
                    cdvValue1.VisibleButton = true;
                    cdvValue1.Enabled = true;
                    cdvValue1.ReadOnly = true;
                    if (b_operator_selection_changed == false)
                    {
                        cdvValue1.Text = "";
                    }
                    cdvValue1.Init();
                    MPCF.InitListView(cdvValue1.GetListView);
                    cdvValue1.Columns.Add("Null/Blank", 50, HorizontalAlignment.Left);
                    cdvValue1.SelectedSubItemIndex = 0;
                    cdvValue1.Items.Add("$NULL", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    cdvValue1.Items.Add("$BLANK", (int)SMALLICON_INDEX.IDX_CODE_DATA);
                    cdvValue1.InsertEmptyRow(0, 1);
                }
            }
            else
            {
                lblTableName.Visible = false;
                cdvTableName.Visible = false;
                if (cdvValue2.Visible == true || txtValue2.Visible == true)
                {
                    cdvValue2.Enabled = false;
                    cdvValue2.VisibleButton = false;
                    cdvValue2.ReadOnly = false;
                    cdvValue2.Visible = false;
                    if (b_operator_selection_changed == false)
                    {
                        cdvValue2.Text = "";
                    }
                    txtValue2.Enabled = true;
                    txtValue2.Visible = true;
                    if (b_operator_selection_changed == false)
                    {
                        txtValue2.Text = "";
                    }

                }
                else if (cdvValue1.Visible == true)
                {
                    if (b_operator_selection_changed == false)
                    {
                        cdvValue1.Text = "";
                    }
                    /* Updated BY YJJung 160407 Bug Fix Custom 룰인 경우 굳이 바꿀 필요 없음*/
                    if (MPCF.Trim(cdvKey.Tag).Length > 1 && MPCF.Trim(cdvKey.Tag).Substring(1, 1) == "K")
                    {
                        // Do Nothing 
                        cdvValue1.VisibleButton = false;
                        cdvValue1.Enabled = true;
                    }
                    else
                    {
                        cdvValue1.VisibleButton = true;
                        cdvValue1.Enabled = true;
                        cdvValue1.ReadOnly = true;
                    }
                }
            }

        }

        private void cdvTableName_ButtonPress(object sender, EventArgs e)
        {
            cdvTableName.Init();
            MPCF.InitListView(cdvTableName.GetListView);
            cdvTableName.Columns.Add("Table", 50, HorizontalAlignment.Left);
            cdvTableName.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvTableName.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvTableName.GetListView, '1');
            cdvTableName.InsertEmptyRow(0, 1);
        }

    }
//#End If
}
