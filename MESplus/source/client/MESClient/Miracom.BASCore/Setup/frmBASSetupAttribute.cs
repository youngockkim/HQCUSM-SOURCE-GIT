
using System.Data;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupAttribute.vb
//   Description : MES Cient Form Attribute Setup Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check Create/Update/Delete condition
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2006-07-05 : Created by Aiden Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//Imports

namespace Miracom.BASCore
{
    public class frmBASSetupAttribute : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmBASSetupAttribute()
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
        



        private Miracom.UI.Controls.MCListView.MCListView lisAttrList;
        private System.Windows.Forms.ColumnHeader colSeq;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.Panel pnlListTop;
        private System.Windows.Forms.Panel pnlListMid;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAType;
        private System.Windows.Forms.Label lblAType;
        private System.Windows.Forms.GroupBox grpAttributeName;
        private System.Windows.Forms.Panel pnlAttrInfo;
        private System.Windows.Forms.GroupBox grpAttributeInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrType;
        private System.Windows.Forms.Label lblAttrType;
        private System.Windows.Forms.Label lblAttrSeq;
        private System.Windows.Forms.TextBox txtAttrName;
        private System.Windows.Forms.Label lblAttrName;
        private System.Windows.Forms.TextBox txtAttrDesc;
        private System.Windows.Forms.Label lblAttrDesc;
        private System.Windows.Forms.Label lblAttrFormat;
        private System.Windows.Forms.ComboBox cboFormat;
        private System.Windows.Forms.Label lblAttrSize;
        private System.Windows.Forms.ComboBox cboTblType;
        private System.Windows.Forms.Label lblAttrTblType;
        private System.Windows.Forms.Label lblTable;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTable;
        private System.Windows.Forms.Label lblUpdateUser;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblCreateUser;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.TextBox txtCreateUser;
        private NumericUpDown txtAttrSize;
        private NumericUpDown txtSeq;
        private CheckBox chkAllowBlankValue;
        private CheckBox chkSecurity;
        private CheckBox chkIndependentFlag;
        private CheckBox chkNoHistory;
        private CheckBox chkSysFlag;
        private TextBox txtSeparator;
        private CheckBox chkIsArray;
        private Label lblSeparator;
        private Label lblMax;
        private System.Windows.Forms.ColumnHeader colType;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASSetupAttribute));
            this.pnlListTop = new System.Windows.Forms.Panel();
            this.cdvAType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAType = new System.Windows.Forms.Label();
            this.pnlListMid = new System.Windows.Forms.Panel();
            this.lisAttrList = new Miracom.UI.Controls.MCListView.MCListView();
            this.colSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpAttributeName = new System.Windows.Forms.GroupBox();
            this.txtAttrDesc = new System.Windows.Forms.TextBox();
            this.lblAttrDesc = new System.Windows.Forms.Label();
            this.txtAttrName = new System.Windows.Forms.TextBox();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.lblAttrSeq = new System.Windows.Forms.Label();
            this.cdvAttrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.pnlAttrInfo = new System.Windows.Forms.Panel();
            this.grpAttributeInfo = new System.Windows.Forms.GroupBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.txtSeparator = new System.Windows.Forms.TextBox();
            this.chkIsArray = new System.Windows.Forms.CheckBox();
            this.chkSysFlag = new System.Windows.Forms.CheckBox();
            this.chkNoHistory = new System.Windows.Forms.CheckBox();
            this.chkIndependentFlag = new System.Windows.Forms.CheckBox();
            this.chkSecurity = new System.Windows.Forms.CheckBox();
            this.chkAllowBlankValue = new System.Windows.Forms.CheckBox();
            this.txtAttrSize = new System.Windows.Forms.NumericUpDown();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.cdvTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTable = new System.Windows.Forms.Label();
            this.cboTblType = new System.Windows.Forms.ComboBox();
            this.lblAttrTblType = new System.Windows.Forms.Label();
            this.lblAttrSize = new System.Windows.Forms.Label();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.lblAttrFormat = new System.Windows.Forms.Label();
            this.txtSeq = new System.Windows.Forms.NumericUpDown();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlListTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAType)).BeginInit();
            this.pnlListMid.SuspendLayout();
            this.grpAttributeName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).BeginInit();
            this.pnlAttrInfo.SuspendLayout();
            this.grpAttributeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttrSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeq)).BeginInit();
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
            this.pnlRight.Controls.Add(this.txtSeq);
            this.pnlRight.Controls.Add(this.pnlAttrInfo);
            this.pnlRight.Controls.Add(this.grpAttributeName);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlListMid);
            this.pnlLeft.Controls.Add(this.pnlListTop);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
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
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "BaseForm02";
            // 
            // pnlListTop
            // 
            this.pnlListTop.Controls.Add(this.cdvAType);
            this.pnlListTop.Controls.Add(this.lblAType);
            this.pnlListTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListTop.Location = new System.Drawing.Point(0, 0);
            this.pnlListTop.Name = "pnlListTop";
            this.pnlListTop.Size = new System.Drawing.Size(232, 32);
            this.pnlListTop.TabIndex = 0;
            // 
            // cdvAType
            // 
            this.cdvAType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvAType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAType.BtnToolTipText = "";
            this.cdvAType.DescText = "";
            this.cdvAType.DisplaySubItemIndex = 0;
            this.cdvAType.DisplayText = "";
            this.cdvAType.Focusing = null;
            this.cdvAType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAType.Index = 0;
            this.cdvAType.IsViewBtnImage = false;
            this.cdvAType.Location = new System.Drawing.Point(97, 5);
            this.cdvAType.MaxLength = 20;
            this.cdvAType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAType.Name = "cdvAType";
            this.cdvAType.ReadOnly = false;
            this.cdvAType.SearchSubItemIndex = 0;
            this.cdvAType.SelectedDescIndex = -1;
            this.cdvAType.SelectedSubItemIndex = 0;
            this.cdvAType.SelectionStart = 0;
            this.cdvAType.Size = new System.Drawing.Size(128, 20);
            this.cdvAType.SmallImageList = null;
            this.cdvAType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAType.TabIndex = 1;
            this.cdvAType.TextBoxToolTipText = "";
            this.cdvAType.TextBoxWidth = 128;
            this.cdvAType.VisibleButton = true;
            this.cdvAType.VisibleColumnHeader = false;
            this.cdvAType.VisibleDescription = false;
            this.cdvAType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAType_SelectedItemChanged);
            this.cdvAType.ButtonPress += new System.EventHandler(this.cdvAType_ButtonPress);
            // 
            // lblAType
            // 
            this.lblAType.AutoSize = true;
            this.lblAType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAType.Location = new System.Drawing.Point(7, 8);
            this.lblAType.Name = "lblAType";
            this.lblAType.Size = new System.Drawing.Size(73, 13);
            this.lblAType.TabIndex = 0;
            this.lblAType.Text = "Attribute Type";
            // 
            // pnlListMid
            // 
            this.pnlListMid.Controls.Add(this.lisAttrList);
            this.pnlListMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListMid.Location = new System.Drawing.Point(0, 32);
            this.pnlListMid.Name = "pnlListMid";
            this.pnlListMid.Size = new System.Drawing.Size(232, 481);
            this.pnlListMid.TabIndex = 1;
            // 
            // lisAttrList
            // 
            this.lisAttrList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSeq,
            this.colName,
            this.colType,
            this.colDesc});
            this.lisAttrList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttrList.EnableSort = true;
            this.lisAttrList.EnableSortIcon = true;
            this.lisAttrList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttrList.FullRowSelect = true;
            this.lisAttrList.Location = new System.Drawing.Point(0, 0);
            this.lisAttrList.MultiSelect = false;
            this.lisAttrList.Name = "lisAttrList";
            this.lisAttrList.Size = new System.Drawing.Size(232, 481);
            this.lisAttrList.TabIndex = 0;
            this.lisAttrList.UseCompatibleStateImageBehavior = false;
            this.lisAttrList.View = System.Windows.Forms.View.Details;
            this.lisAttrList.SelectedIndexChanged += new System.EventHandler(this.lisAttrList_SelectedIndexChanged);
            // 
            // colSeq
            // 
            this.colSeq.Text = "Seq";
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 120;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 120;
            // 
            // grpAttributeName
            // 
            this.grpAttributeName.Controls.Add(this.txtAttrDesc);
            this.grpAttributeName.Controls.Add(this.lblAttrDesc);
            this.grpAttributeName.Controls.Add(this.txtAttrName);
            this.grpAttributeName.Controls.Add(this.lblAttrName);
            this.grpAttributeName.Controls.Add(this.lblAttrSeq);
            this.grpAttributeName.Controls.Add(this.cdvAttrType);
            this.grpAttributeName.Controls.Add(this.lblAttrType);
            this.grpAttributeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpAttributeName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAttributeName.Location = new System.Drawing.Point(3, 0);
            this.grpAttributeName.Name = "grpAttributeName";
            this.grpAttributeName.Size = new System.Drawing.Size(500, 98);
            this.grpAttributeName.TabIndex = 0;
            this.grpAttributeName.TabStop = false;
            // 
            // txtAttrDesc
            // 
            this.txtAttrDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttrDesc.Location = new System.Drawing.Point(116, 68);
            this.txtAttrDesc.MaxLength = 200;
            this.txtAttrDesc.Name = "txtAttrDesc";
            this.txtAttrDesc.Size = new System.Drawing.Size(372, 20);
            this.txtAttrDesc.TabIndex = 6;
            // 
            // lblAttrDesc
            // 
            this.lblAttrDesc.AutoSize = true;
            this.lblAttrDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrDesc.Location = new System.Drawing.Point(16, 71);
            this.lblAttrDesc.Name = "lblAttrDesc";
            this.lblAttrDesc.Size = new System.Drawing.Size(60, 13);
            this.lblAttrDesc.TabIndex = 5;
            this.lblAttrDesc.Text = "Description";
            // 
            // txtAttrName
            // 
            this.txtAttrName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttrName.Location = new System.Drawing.Point(116, 42);
            this.txtAttrName.MaxLength = 100;
            this.txtAttrName.Name = "txtAttrName";
            this.txtAttrName.Size = new System.Drawing.Size(372, 20);
            this.txtAttrName.TabIndex = 4;
            this.txtAttrName.TextChanged += new System.EventHandler(this.txtAttrName_TextChanged);
            this.txtAttrName.Leave += new System.EventHandler(this.txtAttrName_Leave);
            // 
            // lblAttrName
            // 
            this.lblAttrName.AutoSize = true;
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrName.Location = new System.Drawing.Point(16, 45);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(91, 13);
            this.lblAttrName.TabIndex = 3;
            this.lblAttrName.Text = "Attribute Name";
            // 
            // lblAttrSeq
            // 
            this.lblAttrSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrSeq.Location = new System.Drawing.Point(344, 19);
            this.lblAttrSeq.Name = "lblAttrSeq";
            this.lblAttrSeq.Size = new System.Drawing.Size(44, 14);
            this.lblAttrSeq.TabIndex = 2;
            this.lblAttrSeq.Text = "Seq";
            // 
            // cdvAttrType
            // 
            this.cdvAttrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrType.BtnToolTipText = "";
            this.cdvAttrType.DescText = "";
            this.cdvAttrType.DisplaySubItemIndex = 0;
            this.cdvAttrType.DisplayText = "";
            this.cdvAttrType.Focusing = null;
            this.cdvAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrType.Index = 0;
            this.cdvAttrType.IsViewBtnImage = false;
            this.cdvAttrType.Location = new System.Drawing.Point(116, 16);
            this.cdvAttrType.MaxLength = 20;
            this.cdvAttrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.Name = "cdvAttrType";
            this.cdvAttrType.ReadOnly = false;
            this.cdvAttrType.SearchSubItemIndex = 0;
            this.cdvAttrType.SelectedDescIndex = -1;
            this.cdvAttrType.SelectedSubItemIndex = 0;
            this.cdvAttrType.SelectionStart = 0;
            this.cdvAttrType.Size = new System.Drawing.Size(200, 20);
            this.cdvAttrType.SmallImageList = null;
            this.cdvAttrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrType.TabIndex = 1;
            this.cdvAttrType.TextBoxToolTipText = "";
            this.cdvAttrType.TextBoxWidth = 200;
            this.cdvAttrType.VisibleButton = true;
            this.cdvAttrType.VisibleColumnHeader = false;
            this.cdvAttrType.VisibleDescription = false;
            this.cdvAttrType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrType_SelectedItemChanged);
            this.cdvAttrType.ButtonPress += new System.EventHandler(this.cdvAttrType_ButtonPress);
            this.cdvAttrType.Leave += new System.EventHandler(this.cdvAttrType_Leave);
            // 
            // lblAttrType
            // 
            this.lblAttrType.AutoSize = true;
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrType.Location = new System.Drawing.Point(16, 19);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(87, 13);
            this.lblAttrType.TabIndex = 0;
            this.lblAttrType.Text = "Attribute Type";
            // 
            // pnlAttrInfo
            // 
            this.pnlAttrInfo.Controls.Add(this.grpAttributeInfo);
            this.pnlAttrInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttrInfo.Location = new System.Drawing.Point(3, 98);
            this.pnlAttrInfo.Name = "pnlAttrInfo";
            this.pnlAttrInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlAttrInfo.Size = new System.Drawing.Size(500, 415);
            this.pnlAttrInfo.TabIndex = 1;
            // 
            // grpAttributeInfo
            // 
            this.grpAttributeInfo.Controls.Add(this.lblMax);
            this.grpAttributeInfo.Controls.Add(this.lblSeparator);
            this.grpAttributeInfo.Controls.Add(this.txtSeparator);
            this.grpAttributeInfo.Controls.Add(this.chkIsArray);
            this.grpAttributeInfo.Controls.Add(this.chkSysFlag);
            this.grpAttributeInfo.Controls.Add(this.chkNoHistory);
            this.grpAttributeInfo.Controls.Add(this.chkIndependentFlag);
            this.grpAttributeInfo.Controls.Add(this.chkSecurity);
            this.grpAttributeInfo.Controls.Add(this.chkAllowBlankValue);
            this.grpAttributeInfo.Controls.Add(this.txtAttrSize);
            this.grpAttributeInfo.Controls.Add(this.lblUpdateUser);
            this.grpAttributeInfo.Controls.Add(this.txtUpdateTime);
            this.grpAttributeInfo.Controls.Add(this.lblUpdateTime);
            this.grpAttributeInfo.Controls.Add(this.txtUpdateUser);
            this.grpAttributeInfo.Controls.Add(this.lblCreateUser);
            this.grpAttributeInfo.Controls.Add(this.txtCreateTime);
            this.grpAttributeInfo.Controls.Add(this.lblCreateTime);
            this.grpAttributeInfo.Controls.Add(this.txtCreateUser);
            this.grpAttributeInfo.Controls.Add(this.cdvTable);
            this.grpAttributeInfo.Controls.Add(this.lblTable);
            this.grpAttributeInfo.Controls.Add(this.cboTblType);
            this.grpAttributeInfo.Controls.Add(this.lblAttrTblType);
            this.grpAttributeInfo.Controls.Add(this.lblAttrSize);
            this.grpAttributeInfo.Controls.Add(this.cboFormat);
            this.grpAttributeInfo.Controls.Add(this.lblAttrFormat);
            this.grpAttributeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAttributeInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpAttributeInfo.Location = new System.Drawing.Point(0, 5);
            this.grpAttributeInfo.Name = "grpAttributeInfo";
            this.grpAttributeInfo.Size = new System.Drawing.Size(500, 410);
            this.grpAttributeInfo.TabIndex = 0;
            this.grpAttributeInfo.TabStop = false;
            this.grpAttributeInfo.Text = "Attribute Information";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMax.Location = new System.Drawing.Point(256, 51);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(60, 13);
            this.lblMax.TabIndex = 21;
            this.lblMax.Text = "(Max 1000)";
            // 
            // lblSeparator
            // 
            this.lblSeparator.AutoSize = true;
            this.lblSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSeparator.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSeparator.Location = new System.Drawing.Point(436, 25);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(53, 13);
            this.lblSeparator.TabIndex = 21;
            this.lblSeparator.Text = "Separator";
            // 
            // txtSeparator
            // 
            this.txtSeparator.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeparator.Location = new System.Drawing.Point(411, 18);
            this.txtSeparator.MaxLength = 1;
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(21, 26);
            this.txtSeparator.TabIndex = 9;
            // 
            // chkIsArray
            // 
            this.chkIsArray.AutoSize = true;
            this.chkIsArray.Location = new System.Drawing.Point(327, 23);
            this.chkIsArray.Name = "chkIsArray";
            this.chkIsArray.Size = new System.Drawing.Size(77, 17);
            this.chkIsArray.TabIndex = 8;
            this.chkIsArray.Text = "Array Type";
            this.chkIsArray.UseVisualStyleBackColor = true;
            this.chkIsArray.CheckedChanged += new System.EventHandler(this.chkIsArray_CheckedChanged);
            // 
            // chkSysFlag
            // 
            this.chkSysFlag.AutoSize = true;
            this.chkSysFlag.Location = new System.Drawing.Point(327, 157);
            this.chkSysFlag.Name = "chkSysFlag";
            this.chkSysFlag.Size = new System.Drawing.Size(125, 17);
            this.chkSysFlag.TabIndex = 14;
            this.chkSysFlag.Text = "System Attribute Flag";
            this.chkSysFlag.UseVisualStyleBackColor = true;
            // 
            // chkNoHistory
            // 
            this.chkNoHistory.AutoSize = true;
            this.chkNoHistory.Location = new System.Drawing.Point(327, 131);
            this.chkNoHistory.Name = "chkNoHistory";
            this.chkNoHistory.Size = new System.Drawing.Size(140, 17);
            this.chkNoHistory.TabIndex = 13;
            this.chkNoHistory.Text = "Do not make history flag";
            this.chkNoHistory.UseVisualStyleBackColor = true;
            // 
            // chkIndependentFlag
            // 
            this.chkIndependentFlag.AutoSize = true;
            this.chkIndependentFlag.Location = new System.Drawing.Point(327, 77);
            this.chkIndependentFlag.Name = "chkIndependentFlag";
            this.chkIndependentFlag.Size = new System.Drawing.Size(142, 17);
            this.chkIndependentFlag.TabIndex = 11;
            this.chkIndependentFlag.Text = "Key History Independent";
            this.chkIndependentFlag.UseVisualStyleBackColor = true;
            // 
            // chkSecurity
            // 
            this.chkSecurity.AutoSize = true;
            this.chkSecurity.Location = new System.Drawing.Point(327, 50);
            this.chkSecurity.Name = "chkSecurity";
            this.chkSecurity.Size = new System.Drawing.Size(98, 17);
            this.chkSecurity.TabIndex = 10;
            this.chkSecurity.Text = "Check Security";
            this.chkSecurity.UseVisualStyleBackColor = true;
            // 
            // chkAllowBlankValue
            // 
            this.chkAllowBlankValue.AutoSize = true;
            this.chkAllowBlankValue.Enabled = false;
            this.chkAllowBlankValue.Location = new System.Drawing.Point(327, 104);
            this.chkAllowBlankValue.Name = "chkAllowBlankValue";
            this.chkAllowBlankValue.Size = new System.Drawing.Size(111, 17);
            this.chkAllowBlankValue.TabIndex = 12;
            this.chkAllowBlankValue.Text = "Allow Blank Value";
            this.chkAllowBlankValue.UseVisualStyleBackColor = true;
            // 
            // txtAttrSize
            // 
            this.txtAttrSize.Location = new System.Drawing.Point(116, 48);
            this.txtAttrSize.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtAttrSize.Name = "txtAttrSize";
            this.txtAttrSize.Size = new System.Drawing.Size(134, 20);
            this.txtAttrSize.TabIndex = 3;
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(16, 228);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUser.TabIndex = 17;
            this.lblUpdateUser.Text = "Update User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(116, 251);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(200, 20);
            this.txtUpdateTime.TabIndex = 20;
            this.txtUpdateTime.TabStop = false;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(16, 254);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 19;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(116, 225);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(200, 20);
            this.txtUpdateUser.TabIndex = 18;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(16, 176);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUser.TabIndex = 13;
            this.lblCreateUser.Text = "Create User";
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(116, 199);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(200, 20);
            this.txtCreateTime.TabIndex = 16;
            this.txtCreateTime.TabStop = false;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(16, 202);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 15;
            this.lblCreateTime.Text = "Create Time";
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(116, 173);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(200, 20);
            this.txtCreateUser.TabIndex = 14;
            this.txtCreateUser.TabStop = false;
            // 
            // cdvTable
            // 
            this.cdvTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTable.BtnToolTipText = "";
            this.cdvTable.DescText = "";
            this.cdvTable.DisplaySubItemIndex = 0;
            this.cdvTable.DisplayText = "";
            this.cdvTable.Focusing = null;
            this.cdvTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTable.Index = 0;
            this.cdvTable.IsViewBtnImage = false;
            this.cdvTable.Location = new System.Drawing.Point(116, 102);
            this.cdvTable.MaxLength = 20;
            this.cdvTable.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTable.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTable.Name = "cdvTable";
            this.cdvTable.ReadOnly = false;
            this.cdvTable.SearchSubItemIndex = 0;
            this.cdvTable.SelectedDescIndex = -1;
            this.cdvTable.SelectedSubItemIndex = 0;
            this.cdvTable.SelectionStart = 0;
            this.cdvTable.Size = new System.Drawing.Size(200, 20);
            this.cdvTable.SmallImageList = null;
            this.cdvTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTable.TabIndex = 7;
            this.cdvTable.TextBoxToolTipText = "";
            this.cdvTable.TextBoxWidth = 200;
            this.cdvTable.VisibleButton = true;
            this.cdvTable.VisibleColumnHeader = false;
            this.cdvTable.VisibleDescription = false;
            this.cdvTable.ButtonPress += new System.EventHandler(this.cdvTable_ButtonPress);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTable.Location = new System.Drawing.Point(16, 105);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(60, 13);
            this.lblTable.TabIndex = 6;
            this.lblTable.Text = "Valid Table";
            // 
            // cboTblType
            // 
            this.cboTblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTblType.Items.AddRange(new object[] {
            "",
            "A : Allowed",
            "N : Not Allowed"});
            this.cboTblType.Location = new System.Drawing.Point(116, 74);
            this.cboTblType.Name = "cboTblType";
            this.cboTblType.Size = new System.Drawing.Size(200, 21);
            this.cboTblType.TabIndex = 5;
            this.cboTblType.SelectedIndexChanged += new System.EventHandler(this.cboTblType_SelectedIndexChanged);
            this.cboTblType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboControl_KeyPress);
            // 
            // lblAttrTblType
            // 
            this.lblAttrTblType.AutoSize = true;
            this.lblAttrTblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrTblType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrTblType.Location = new System.Drawing.Point(16, 77);
            this.lblAttrTblType.Name = "lblAttrTblType";
            this.lblAttrTblType.Size = new System.Drawing.Size(87, 13);
            this.lblAttrTblType.TabIndex = 4;
            this.lblAttrTblType.Text = "Valid Table Type";
            // 
            // lblAttrSize
            // 
            this.lblAttrSize.AutoSize = true;
            this.lblAttrSize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrSize.Location = new System.Drawing.Point(16, 51);
            this.lblAttrSize.Name = "lblAttrSize";
            this.lblAttrSize.Size = new System.Drawing.Size(27, 13);
            this.lblAttrSize.TabIndex = 2;
            this.lblAttrSize.Text = "Size";
            // 
            // cboFormat
            // 
            this.cboFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboFormat.Items.AddRange(new object[] {
            "A : Ascii",
            "N : Number",
            "F : Float"});
            this.cboFormat.Location = new System.Drawing.Point(116, 20);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(200, 21);
            this.cboFormat.TabIndex = 1;
            this.cboFormat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboControl_KeyPress);
            // 
            // lblAttrFormat
            // 
            this.lblAttrFormat.AutoSize = true;
            this.lblAttrFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrFormat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAttrFormat.Location = new System.Drawing.Point(16, 23);
            this.lblAttrFormat.Name = "lblAttrFormat";
            this.lblAttrFormat.Size = new System.Drawing.Size(39, 13);
            this.lblAttrFormat.TabIndex = 0;
            this.lblAttrFormat.Text = "Format";
            // 
            // txtSeq
            // 
            this.txtSeq.Location = new System.Drawing.Point(384, 16);
            this.txtSeq.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(107, 20);
            this.txtSeq.TabIndex = 1;
            // 
            // frmBASSetupAttribute
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBASSetupAttribute";
            this.Text = "Attribute Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupAttributes_Activated);
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
            this.pnlListTop.ResumeLayout(false);
            this.pnlListTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAType)).EndInit();
            this.pnlListMid.ResumeLayout(false);
            this.grpAttributeName.ResumeLayout(false);
            this.grpAttributeName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).EndInit();
            this.pnlAttrInfo.ResumeLayout(false);
            this.grpAttributeInfo.ResumeLayout(false);
            this.grpAttributeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAttrSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeq)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        private string SelectComboBox(ComboBox cbo, char cItem)
        {
            int i;
            
            for (i = 0; i < cbo.Items.Count; i++)
            {
                if (cItem.ToString() == (MPCF.Trim(cbo.Items[i]).Length > 0 ? MPCF.Trim(cbo.Items[i]).Substring(0, 1) : ""))
                {
                    return MPCF.Trim(cbo.Items[i]);
                }
            }
            
            return "";
        }

        // Check_System_Flag()
        //       - Check Attribute Name System Flag
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVla sAttrType                : Attribute Type
        //       - ByVla sAttrName                : Attribute Name
        private bool Check_System_Flag(string sAttrType, string sAttrName)
        {
            try
            {
                TRSNode in_node = new TRSNode("ATTR_IN");
                TRSNode out_node = new TRSNode("ATTR_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("ATTR_TYPE", MPCF.Trim(sAttrType));
                in_node.AddString("ATTR_NAME", MPCF.Trim(sAttrName));

                //Ignore Message
                if (MPCR.CallService("BAS", "BAS_View_Attribute_Name", in_node, ref out_node, true) == false)
                {
                    return false;
                }

                chkSysFlag.Checked = out_node.GetChar("SYS_ATR_FLAG") == 'Y' ? true : false;
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        // View_Attribute_Name()
        //       - View Attribute Name
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVla sAttrType                : Attribute Type
        //       - ByVla sAttrName                : Attribute Name
        private bool View_Attribute_Name(string sAttrType, string sAttrName)
        {
            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("ATTR_OUT");

            /*** #1017 System Attribute (2012.04.25 by JYPARK) ***/
            chkSysFlag.Checked = false;
            /*** End of Add (2012.04.25) ***/

            /*** #1088 System Attribute (2012.11.13 by SSKIM) ***/
            chkIsArray.Checked = false;
            txtSeparator.Text = string.Empty;
            txtSeparator.Enabled = false;
            /*** End of Add (2012.11.13) ***/


            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("ATTR_TYPE", MPCF.Trim(sAttrType));
            in_node.AddString("ATTR_NAME", MPCF.Trim(sAttrName));


            if (MPCR.CallService("BAS", "BAS_View_Attribute_Name", in_node, ref out_node) == false )
            {
                return false;
            }
            
            cdvAttrType.Text = out_node.GetString("ATTR_TYPE");
            txtSeq.Value = out_node.GetInt("ATTR_SEQ");
            txtAttrName.Text = out_node.GetString("ATTR_NAME");
            txtAttrDesc.Text = out_node.GetString("ATTR_DESC");
            cboFormat.Text = SelectComboBox(cboFormat, out_node.GetChar("ATTR_FMT"));
            txtAttrSize.Value = out_node.GetInt("ATTR_SIZE");
            cboTblType.Text = SelectComboBox(cboTblType, out_node.GetChar("VALID_TBL_TYPE"));
            cdvTable.Text = out_node.GetString("VALID_TBL");

            if (out_node.GetChar("ALLOW_BLANK") == 'Y')
                chkAllowBlankValue.Checked = true;
            else
                chkAllowBlankValue.Checked = false;

            if (out_node.GetChar("SEC_CHK_FLAG") == 'Y')
                chkSecurity.Checked = true;
            else
                chkSecurity.Checked = false;

            if (out_node.GetChar("KEY_HIST_INDEPENDENT_FLAG") == 'Y')
                chkIndependentFlag.Checked = true;
            else
                chkIndependentFlag.Checked = false;

            /*** #995 Enhancement Attribute User Control (2012.04.13 by JYPARK) ***/
            chkNoHistory.Checked = out_node.GetChar("NO_HISTORY_FLAG") == 'Y' ? true : false;
            /*** End of Modification (2012.04.13) ***/
            /*** #1017 System Attribute (2012.04.25 by JYPARK) ***/
            chkSysFlag.Checked = out_node.GetChar("SYS_ATR_FLAG") == 'Y' ? true : false;
            /*** End of Add (2012.04.25) ***/

            /*** #1088 System Attribute (2012.11.13 by SSKIM) ***/
            chkIsArray.Checked = out_node.GetChar("ARRAY_TYPE_FLAG") == 'Y' ? true : false;
            txtSeparator.Text = out_node.GetChar("ARRAY_SEPARATOR").ToString();
            /*** End of Add (2012.11.13) ***/

            txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
            txtCreateTime.Text =  MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
            txtUpdateTime.Text =  MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
            
            return true;
        }
        
        //
        // Update_Attribute()
        //       - Change Attribute information
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVla c_step                : Create/Update/Delete 구분
        //
        private bool Update_Attribute(char c_step)
        {


            TRSNode in_node = new TRSNode("ATTR_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("ATTR_TYPE", MPCF.Trim(cdvAttrType.Text));
                in_node.AddString("ATTR_NAME", MPCF.Trim(txtAttrName.Text));
                in_node.AddString("ATTR_DESC", MPCF.Trim(txtAttrDesc.Text));
                in_node.AddInt("ATTR_SEQ", txtSeq.Value);
                in_node.AddChar("ATTR_FMT", cboFormat.Text.Length > 0 ? MPCF.ToChar(cboFormat.Text.Substring(0, 1)) : ' ');
                in_node.AddInt("ATTR_SIZE", txtAttrSize.Value);
                
                /*** #1088 System Attribute (2012.11.13 by SSKIM) ***/
                if (chkIsArray.Checked == true)
                {
                    in_node.AddChar("ARRAY_SEPARATOR", txtSeparator.Text);
                    in_node.AddChar("ARRAY_TYPE_FLAG ", 'Y');
                }
                /**  End Of 2012.11.13 **/

                if (cboTblType.Text != "")
                {
                    in_node.AddChar("VALID_TBL_TYPE", cboTblType.Text.Length > 0 ? MPCF.ToChar(cboTblType.Text.Substring(0, 1)) : ' ');
                }
                in_node.AddString("VALID_TBL", MPCF.Trim(cdvTable.Text));

                if (chkAllowBlankValue.Enabled == true && chkAllowBlankValue.Checked == true)
                {
                    in_node.AddChar("ALLOW_BLANK", 'Y');
                }

                if (chkSecurity.Checked == true)
                {
                    in_node.AddChar("SEC_CHK_FLAG", 'Y');
                }
                if (chkIndependentFlag.Checked == true)
                {
                    in_node.AddChar("KEY_HIST_INDEPENDENT_FLAG", 'Y');
                }
                /*** #995 Enhancement Attribute User Control (2012.04.13 by JYPARK) ***/
                in_node.AddChar("NO_HISTORY_FLAG", (chkNoHistory.Checked ? 'Y' : ' '));
                /*** End of Add (2012.04.13) ***/
                /*** #1017 System Attribute (2012.04.25 by JYPARK) ***/
                in_node.AddChar("SYS_ATR_FLAG", (chkSysFlag.Checked ? 'Y' : ' '));
                /*** End of Add (2012.04.25) ***/

                if (MPCR.CallService("BAS", "BAS_Update_Attribute", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
                
                btnRefresh.PerformClick();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        // CheckCondition()
        //       - check Create/Update/Delete condition
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal FuncName As String      : Function Name
        //       - Optional ByVal ProcStep As String        : Create/Update/Delete 구분
        //
        private bool CheckCondition(char ProcStep)
        {

            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(txtAttrName, 1) == false)
            {
                return false;
            }
            if (txtSeq.Value < 0)
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(114));
                txtSeq.Focus();
                return false;
            }

            /**  #1088 System Attribute (2012.11.13 by SSKIM) ***/
            if (chkIsArray.Checked)
            { 
                //is Number 
                if (cboFormat.Text.Contains("N :") || cboFormat.Text.Contains("F :"))
                {
                    if (MPCF.Trim(txtSeparator.Text) == "." || MPCF.Trim(txtSeparator.Text) == ",")
                    {
                         MPCF.ShowMsgBox(MPCF.GetMessage(347));
                        txtSeparator.Focus();
                        return false;
                    }
                }
            }
            /** End of (2012.11.13 by SSKIM)  **/

            switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
            {
                case MPGC.MP_STEP_CREATE:
                    if (cboFormat.Text == "")
                    {
                        cboFormat.Text = SelectComboBox(cboFormat, 'A');
                    }

                    if (txtAttrSize.Value < 1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(114));
                        txtAttrSize.Focus();
                        return false;
                    }

                    if (txtAttrSize.Value > 1000)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(360));
                        txtAttrSize.Focus();
                        return false;
                    }

                    if (cboTblType.SelectedIndex > 0)
                    {
                        if (MPCF.CheckValue(cdvTable, 1) == false)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        cdvTable.Text = "";
                    }
                    break;


                case MPGC.MP_STEP_UPDATE:

                    if (cboFormat.Text == "")
                    {
                        cboFormat.Text = SelectComboBox(cboFormat, 'A');
                    }

                    if (txtAttrSize.Value < 1)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(114));
                        txtAttrSize.Focus();
                        return false;
                    }

                    if (txtAttrSize.Value > 1000)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(360));
                        txtAttrSize.Focus();
                        return false;
                    }

                    if (cboTblType.SelectedIndex > 0)
                    {
                        if (MPCF.CheckValue(cdvTable, 1) == false)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        cdvTable.Text = "";
                    }
                    break;

                case MPGC.MP_STEP_DELETE:

                    break;
            }                       
            
            return true;            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvAttrType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmBASSetupAttributes_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                
                MPCF.InitListView(lisAttrList);
                MPCF.FieldClear(this);

                /*** #1017 System Attribute (2012.04.25 by JYPARK) ***/
                chkSysFlag.Enabled = MPGV.gsFactory == MPGV.gsCentralFactory ? true : false;
                chkSysFlag.Checked = false;
                /*** End of Add (2012.04.25) ***/
                
                /**  #1088 System Attribute (2012.11.13 by SSKIM) ***/
                txtSeparator.Enabled = false;
                /** End of Add (2012.11.13  ***/

                btnRefresh.PerformClick();
                
                b_load_flag = true;
            }
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisAttrList, txtFind.Text, true, false);
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisAttrList, txtFind.Text, 0, true, false);
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (BASLIST.ViewAttributeNameList(lisAttrList, '1', cdvAType.Text) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisAttrList.Items.Count);
                    if (lisAttrList.Items.Count > 0)
                    {
                        if (MPCF.Trim(txtAttrName.Text) == "")
                        {
                            lisAttrList.Items[0].Selected = true;
                        }
                        else
                        {
                            MPCF.FindListItem(lisAttrList, txtAttrName.Text, false);
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
            string sCond;
            
            sCond = "Attribute Type : " + cdvAType.Text;
            MPCF.ExportToExcel(lisAttrList, this.Text, sCond);
        }
        
        private void cdvAType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAType.Init();
            MPCF.InitListView(cdvAType.GetListView);
            cdvAType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvAType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);
            cdvAType.InsertEmptyRow(0, 1);
        }
        
        private void cdvAttrType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAttrType.Init();
            MPCF.InitListView(cdvAttrType.GetListView);
            cdvAttrType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvAttrType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAttrType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);
            cdvTable.InsertEmptyRow(0, 1);
        }
        
        private void cdvTable_ButtonPress(object sender, System.EventArgs e)
        {
            cdvTable.Init();
            MPCF.InitListView(cdvTable.GetListView);
            cdvTable.Columns.Add("Table", 150, HorizontalAlignment.Left);
            cdvTable.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvTable.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvTable.GetListView, '1');
            cdvTable.InsertEmptyRow(0, 1);
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
            if (Update_Attribute(MPGC.MP_STEP_CREATE) == false)
            {
                return;
            }
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
            if (Update_Attribute(MPGC.MP_STEP_UPDATE) == false)
            {
                return;
            }
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
            
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            if (Update_Attribute(MPGC.MP_STEP_DELETE) == false)
            {
                return;
            }
        }
        
        private void lisAttrList_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lisAttrList.SelectedItems.Count < 1)
            {
                return;
            }
            
            string sType;
            string sName;
            
            sType = MPCF.Trim(lisAttrList.SelectedItems[0].SubItems[2].Text);
            sName = MPCF.Trim(lisAttrList.SelectedItems[0].SubItems[1].Text);
            
            View_Attribute_Name(sType, sName);
        }
        
        private void cboControl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cdvAType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void cboTblType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTblType.SelectedIndex == 1 || cboTblType.SelectedIndex == 2)
                chkAllowBlankValue.Enabled = true;
            else
                chkAllowBlankValue.Enabled = false;
        }

        /**  #1088 System Attribute (2012.11.13 by SSKIM) ***/
        private void chkIsArray_CheckedChanged(object sender, EventArgs e)
        {
            txtSeparator.Enabled = chkIsArray.Checked;

            if (chkIsArray.Checked)
            {
                txtSeparator.Text = ";";  // Default => ;
            }
            else
            {
                txtSeparator.Text = "";
            }
        }

        private void cdvAttrType_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (chkSysFlag.Enabled == false) chkSysFlag.Checked = false;
        }

        private void txtAttrName_TextChanged(object sender, EventArgs e)
        {
            if (chkSysFlag.Enabled == false) chkSysFlag.Checked = false;
        }

        private void cdvAttrType_Leave(object sender, EventArgs e)
        {
            if (chkSysFlag.Enabled == false) Check_System_Flag(MPCF.Trim(cdvAttrType.Text), MPCF.Trim(txtAttrName.Text));
        }

        private void txtAttrName_Leave(object sender, EventArgs e)
        {
            if (chkSysFlag.Enabled == false) Check_System_Flag(MPCF.Trim(cdvAttrType.Text), MPCF.Trim(txtAttrName.Text));
        }



        /** End of Add (2012.11.13  ***/

        
    }
    
}
