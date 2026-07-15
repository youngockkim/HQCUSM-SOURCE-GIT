
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBBSMain.vb
//   Description : MES Cient Form View Resource List Main
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-12 : Created by CM Koo
//       - 2012.04.25 : Modified by DM KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _RAS = True Then

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;


using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.TRSCore;

//this.components = new System.ComponentModel.Container();
//System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBBSMain));

namespace Miracom.MESCore
{
    public class frmBBSMain : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmBBSMain()
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

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlMid;
        private Miracom.UI.Controls.MCListView.MCListView lisMsgList;
        private TextBox txtMsg;
        private ColumnHeader colTitle;
        private ColumnHeader colUserID;
        private ColumnHeader colResourceID;
        private ColumnHeader colOperation;
        private ColumnHeader colType;
        private Button btnSearch;
        private SaveFileDialog saveFileDialog;
        private GroupBox grpModification;
        private Button btnDelete;
        private Button btnModify;
        private Button btnNew;
        private Button btnClose;
        private GroupBox grpFilter;
        private TextBox txtTitle;
        private Label lblTitle;
        private TextBox txtLotID;
        private Label lblLotID;
        private Label lblOperation;
        private UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private UI.Controls.MCCodeView.MCCodeView cdvType;
        private Label lblType;
        private UI.Controls.MCCodeView.MCCodeView cdvResID;
        private Label lblResID;
        private Label lblTo;
        private Label lblPeriod;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private GroupBox grpSaveFile;
        private Button btnSave;
        private UI.Controls.MCListView.MCListView lisFile;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label lblPopupCycle;
        private ComboBox cboPopupCycle;
        private UI.Controls.MCCodeView.MCCodeView cdvAreaID;
        private Label lblAreaID;
        private UI.Controls.MCCodeView.MCCodeView cdvUserID;
        private Label lblUser;
        private UI.Controls.MCCodeView.MCCodeView cdvMaterial;
        private Label lblMaterial;
        private Label lblApplyShift;
        private ComboBox cboApplyShift;
        private ColumnHeader colUpdateUser;
        private ColumnHeader colUpdateTime;
        private ColumnHeader colResourceGroup;
        private ColumnHeader colArea;
        private ColumnHeader colSubarea;
        private ColumnHeader colSecGroup;
        private ColumnHeader colPrivilegeGroup;
        private ColumnHeader colMaterial;
        private ColumnHeader colFlow;
        private ColumnHeader colLotID;
        private ColumnHeader colApplyTimeFromTo;
        private ColumnHeader colShift;
        private ColumnHeader colPopupCycle;
        private ColumnHeader colRcvFactory;
        private ColumnHeader ColSeq;
        private UI.Controls.MCCodeView.MCCodeView cdvUpdateUser;
        private Label lblUpdateUser;
        private Button btnCheckMine;
        private CheckBox chkIncDelMsg;
        private ColumnHeader colAckFlag;
        private ColumnHeader colSysFlag;
        private ColumnHeader colDelFlag;
        private System.Windows.Forms.Splitter Splitter1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBBSMain));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.chkIncDelMsg = new System.Windows.Forms.CheckBox();
            this.cdvUpdateUser = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.lblApplyShift = new System.Windows.Forms.Label();
            this.cboApplyShift = new System.Windows.Forms.ComboBox();
            this.cdvMaterial = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.cdvUserID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblUser = new System.Windows.Forms.Label();
            this.cdvAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.lblPopupCycle = new System.Windows.Forms.Label();
            this.cboPopupCycle = new System.Windows.Forms.ComboBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblOperation = new System.Windows.Forms.Label();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.grpModification = new System.Windows.Forms.GroupBox();
            this.btnCheckMine = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpSaveFile = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lisFile = new Miracom.UI.Controls.MCListView.MCListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.Splitter1 = new System.Windows.Forms.Splitter();
            this.lisMsgList = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColSeq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResourceID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResourceGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubarea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSecGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrivilegeGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFlow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLotID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApplyTimeFromTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShift = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPopupCycle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRcvFactory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAckFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSysFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colDelFlag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBottom.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUpdateUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.grpModification.SuspendLayout();
            this.grpSaveFile.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.grpFilter);
            this.pnlBottom.Controls.Add(this.grpModification);
            this.pnlBottom.Controls.Add(this.grpSaveFile);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.chkIncDelMsg);
            this.grpFilter.Controls.Add(this.cdvUpdateUser);
            this.grpFilter.Controls.Add(this.lblUpdateUser);
            this.grpFilter.Controls.Add(this.lblApplyShift);
            this.grpFilter.Controls.Add(this.cboApplyShift);
            this.grpFilter.Controls.Add(this.cdvMaterial);
            this.grpFilter.Controls.Add(this.lblMaterial);
            this.grpFilter.Controls.Add(this.cdvUserID);
            this.grpFilter.Controls.Add(this.lblUser);
            this.grpFilter.Controls.Add(this.cdvAreaID);
            this.grpFilter.Controls.Add(this.lblAreaID);
            this.grpFilter.Controls.Add(this.lblPopupCycle);
            this.grpFilter.Controls.Add(this.cboPopupCycle);
            this.grpFilter.Controls.Add(this.txtTitle);
            this.grpFilter.Controls.Add(this.lblTitle);
            this.grpFilter.Controls.Add(this.txtLotID);
            this.grpFilter.Controls.Add(this.lblLotID);
            this.grpFilter.Controls.Add(this.btnSearch);
            this.grpFilter.Controls.Add(this.lblOperation);
            this.grpFilter.Controls.Add(this.cdvOperation);
            this.grpFilter.Controls.Add(this.cdvType);
            this.grpFilter.Controls.Add(this.lblType);
            this.grpFilter.Controls.Add(this.cdvResID);
            this.grpFilter.Controls.Add(this.lblResID);
            this.grpFilter.Controls.Add(this.lblTo);
            this.grpFilter.Controls.Add(this.lblPeriod);
            this.grpFilter.Controls.Add(this.dtpTo);
            this.grpFilter.Controls.Add(this.dtpFrom);
            resources.ApplyResources(this.grpFilter, "grpFilter");
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.TabStop = false;
            // 
            // chkIncDelMsg
            // 
            resources.ApplyResources(this.chkIncDelMsg, "chkIncDelMsg");
            this.chkIncDelMsg.Name = "chkIncDelMsg";
            this.chkIncDelMsg.UseVisualStyleBackColor = true;
            // 
            // cdvUpdateUser
            // 
            this.cdvUpdateUser.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUpdateUser.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUpdateUser.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUpdateUser.BtnToolTipText = "";
            this.cdvUpdateUser.DescText = "";
            this.cdvUpdateUser.DisplaySubItemIndex = -1;
            this.cdvUpdateUser.DisplayText = "";
            this.cdvUpdateUser.Focusing = null;
            resources.ApplyResources(this.cdvUpdateUser, "cdvUpdateUser");
            this.cdvUpdateUser.Index = 0;
            this.cdvUpdateUser.IsViewBtnImage = false;
            this.cdvUpdateUser.MaxLength = 20;
            this.cdvUpdateUser.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUpdateUser.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUpdateUser.Name = "cdvUpdateUser";
            this.cdvUpdateUser.ReadOnly = false;
            this.cdvUpdateUser.SearchSubItemIndex = 0;
            this.cdvUpdateUser.SelectedDescIndex = -1;
            this.cdvUpdateUser.SelectedSubItemIndex = -1;
            this.cdvUpdateUser.SelectionStart = 0;
            this.cdvUpdateUser.SmallImageList = null;
            this.cdvUpdateUser.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUpdateUser.TextBoxToolTipText = "";
            this.cdvUpdateUser.TextBoxWidth = 130;
            this.cdvUpdateUser.VisibleButton = true;
            this.cdvUpdateUser.VisibleColumnHeader = false;
            this.cdvUpdateUser.VisibleDescription = false;
            this.cdvUpdateUser.ButtonPress += new System.EventHandler(this.cdvUpdateUser_ButtonPress);
            // 
            // lblUpdateUser
            // 
            resources.ApplyResources(this.lblUpdateUser, "lblUpdateUser");
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUpdateUser.Name = "lblUpdateUser";
            // 
            // lblApplyShift
            // 
            resources.ApplyResources(this.lblApplyShift, "lblApplyShift");
            this.lblApplyShift.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblApplyShift.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblApplyShift.Name = "lblApplyShift";
            // 
            // cboApplyShift
            // 
            this.cboApplyShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApplyShift.Items.AddRange(new object[] {
            resources.GetString("cboApplyShift.Items"),
            resources.GetString("cboApplyShift.Items1"),
            resources.GetString("cboApplyShift.Items2"),
            resources.GetString("cboApplyShift.Items3"),
            resources.GetString("cboApplyShift.Items4"),
            resources.GetString("cboApplyShift.Items5")});
            resources.ApplyResources(this.cboApplyShift, "cboApplyShift");
            this.cboApplyShift.Name = "cboApplyShift";
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvMaterial.BorderHotColor = System.Drawing.Color.Black;
            this.cdvMaterial.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvMaterial.BtnToolTipText = "";
            this.cdvMaterial.DescText = "";
            this.cdvMaterial.DisplaySubItemIndex = -1;
            this.cdvMaterial.DisplayText = "";
            this.cdvMaterial.Focusing = null;
            resources.ApplyResources(this.cdvMaterial, "cdvMaterial");
            this.cdvMaterial.Index = 0;
            this.cdvMaterial.IsViewBtnImage = false;
            this.cdvMaterial.MaxLength = 1;
            this.cdvMaterial.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.ReadOnly = false;
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = -1;
            this.cdvMaterial.SelectionStart = 0;
            this.cdvMaterial.SmallImageList = null;
            this.cdvMaterial.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvMaterial.TextBoxToolTipText = "";
            this.cdvMaterial.TextBoxWidth = 130;
            this.cdvMaterial.VisibleButton = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.ButtonPress += new System.EventHandler(this.cdvMaterial_ButtonPress);
            // 
            // lblMaterial
            // 
            resources.ApplyResources(this.lblMaterial, "lblMaterial");
            this.lblMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaterial.Name = "lblMaterial";
            // 
            // cdvUserID
            // 
            this.cdvUserID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvUserID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvUserID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvUserID.BtnToolTipText = "";
            this.cdvUserID.DescText = "";
            this.cdvUserID.DisplaySubItemIndex = -1;
            this.cdvUserID.DisplayText = "";
            this.cdvUserID.Focusing = null;
            resources.ApplyResources(this.cdvUserID, "cdvUserID");
            this.cdvUserID.Index = 0;
            this.cdvUserID.IsViewBtnImage = false;
            this.cdvUserID.MaxLength = 20;
            this.cdvUserID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvUserID.Name = "cdvUserID";
            this.cdvUserID.ReadOnly = false;
            this.cdvUserID.SearchSubItemIndex = 0;
            this.cdvUserID.SelectedDescIndex = -1;
            this.cdvUserID.SelectedSubItemIndex = -1;
            this.cdvUserID.SelectionStart = 0;
            this.cdvUserID.SmallImageList = null;
            this.cdvUserID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvUserID.TextBoxToolTipText = "";
            this.cdvUserID.TextBoxWidth = 130;
            this.cdvUserID.VisibleButton = true;
            this.cdvUserID.VisibleColumnHeader = false;
            this.cdvUserID.VisibleDescription = false;
            this.cdvUserID.ButtonPress += new System.EventHandler(this.cdvUserID_ButtonPress);
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUser.Name = "lblUser";
            // 
            // cdvAreaID
            // 
            this.cdvAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAreaID.BtnToolTipText = "";
            this.cdvAreaID.DescText = "";
            this.cdvAreaID.DisplaySubItemIndex = -1;
            this.cdvAreaID.DisplayText = "";
            this.cdvAreaID.Focusing = null;
            resources.ApplyResources(this.cdvAreaID, "cdvAreaID");
            this.cdvAreaID.Index = 0;
            this.cdvAreaID.IsViewBtnImage = false;
            this.cdvAreaID.MaxLength = 20;
            this.cdvAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.Name = "cdvAreaID";
            this.cdvAreaID.ReadOnly = false;
            this.cdvAreaID.SearchSubItemIndex = 0;
            this.cdvAreaID.SelectedDescIndex = -1;
            this.cdvAreaID.SelectedSubItemIndex = -1;
            this.cdvAreaID.SelectionStart = 0;
            this.cdvAreaID.SmallImageList = null;
            this.cdvAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAreaID.TextBoxToolTipText = "";
            this.cdvAreaID.TextBoxWidth = 130;
            this.cdvAreaID.VisibleButton = true;
            this.cdvAreaID.VisibleColumnHeader = false;
            this.cdvAreaID.VisibleDescription = false;
            this.cdvAreaID.ButtonPress += new System.EventHandler(this.cdvAreaID_ButtonPress);
            // 
            // lblAreaID
            // 
            resources.ApplyResources(this.lblAreaID, "lblAreaID");
            this.lblAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAreaID.Name = "lblAreaID";
            // 
            // lblPopupCycle
            // 
            resources.ApplyResources(this.lblPopupCycle, "lblPopupCycle");
            this.lblPopupCycle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPopupCycle.Name = "lblPopupCycle";
            // 
            // cboPopupCycle
            // 
            this.cboPopupCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPopupCycle.Items.AddRange(new object[] {
            resources.GetString("cboPopupCycle.Items"),
            resources.GetString("cboPopupCycle.Items1"),
            resources.GetString("cboPopupCycle.Items2")});
            resources.ApplyResources(this.cboPopupCycle, "cboPopupCycle");
            this.cboPopupCycle.Name = "cboPopupCycle";
            // 
            // txtTitle
            // 
            resources.ApplyResources(this.txtTitle, "txtTitle");
            this.txtTitle.Name = "txtTitle";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTitle.Name = "lblTitle";
            // 
            // txtLotID
            // 
            resources.ApplyResources(this.txtLotID, "txtLotID");
            this.txtLotID.Name = "txtLotID";
            // 
            // lblLotID
            // 
            resources.ApplyResources(this.lblLotID, "lblLotID");
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Name = "lblLotID";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblOperation
            // 
            resources.ApplyResources(this.lblOperation, "lblOperation");
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Name = "lblOperation";
            // 
            // cdvOperation
            // 
            this.cdvOperation.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvOperation.BorderHotColor = System.Drawing.Color.Black;
            this.cdvOperation.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvOperation.BtnToolTipText = "";
            this.cdvOperation.DescText = "";
            this.cdvOperation.DisplaySubItemIndex = -1;
            this.cdvOperation.DisplayText = "";
            this.cdvOperation.Focusing = null;
            resources.ApplyResources(this.cdvOperation, "cdvOperation");
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 130;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
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
            resources.ApplyResources(this.cdvType, "cdvType");
            this.cdvType.Index = 0;
            this.cdvType.IsViewBtnImage = false;
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = false;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 130;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblType.Name = "lblType";
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            resources.ApplyResources(this.cdvResID, "cdvResID");
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 130;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            resources.ApplyResources(this.lblResID, "lblResID");
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Name = "lblResID";
            // 
            // lblTo
            // 
            resources.ApplyResources(this.lblTo, "lblTo");
            this.lblTo.Name = "lblTo";
            // 
            // lblPeriod
            // 
            resources.ApplyResources(this.lblPeriod, "lblPeriod");
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Name = "lblPeriod";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpTo, "dtpTo");
            this.dtpTo.Name = "dtpTo";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpFrom, "dtpFrom");
            this.dtpFrom.Name = "dtpFrom";
            // 
            // grpModification
            // 
            this.grpModification.Controls.Add(this.btnCheckMine);
            this.grpModification.Controls.Add(this.btnDelete);
            this.grpModification.Controls.Add(this.btnModify);
            this.grpModification.Controls.Add(this.btnNew);
            this.grpModification.Controls.Add(this.btnClose);
            resources.ApplyResources(this.grpModification, "grpModification");
            this.grpModification.Name = "grpModification";
            this.grpModification.TabStop = false;
            // 
            // btnCheckMine
            // 
            resources.ApplyResources(this.btnCheckMine, "btnCheckMine");
            this.btnCheckMine.Name = "btnCheckMine";
            this.btnCheckMine.Click += new System.EventHandler(this.btnCheckMine_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            resources.ApplyResources(this.btnModify, "btnModify");
            this.btnModify.Name = "btnModify";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpSaveFile
            // 
            this.grpSaveFile.Controls.Add(this.btnSave);
            this.grpSaveFile.Controls.Add(this.lisFile);
            resources.ApplyResources(this.grpSaveFile, "grpSaveFile");
            this.grpSaveFile.Name = "grpSaveFile";
            this.grpSaveFile.TabStop = false;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lisFile
            // 
            this.lisFile.AllowColumnReorder = true;
            this.lisFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            resources.ApplyResources(this.lisFile, "lisFile");
            this.lisFile.EnableSort = true;
            this.lisFile.EnableSortIcon = true;
            this.lisFile.FullRowSelect = true;
            this.lisFile.MultiSelect = false;
            this.lisFile.Name = "lisFile";
            this.lisFile.UseCompatibleStateImageBehavior = false;
            this.lisFile.View = System.Windows.Forms.View.Details;
            this.lisFile.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lisFile_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblFormTitle);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Name = "pnlTop";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.lblFormTitle, "lblFormTitle");
            this.lblFormTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.DoubleClick += new System.EventHandler(this.lblFormTitle_DoubleClick);
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.txtMsg);
            this.pnlMid.Controls.Add(this.Splitter1);
            this.pnlMid.Controls.Add(this.lisMsgList);
            resources.ApplyResources(this.pnlMid, "pnlMid");
            this.pnlMid.Name = "pnlMid";
            // 
            // txtMsg
            // 
            resources.ApplyResources(this.txtMsg, "txtMsg");
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsg_KeyPress);
            // 
            // Splitter1
            // 
            this.Splitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.Splitter1, "Splitter1");
            this.Splitter1.Name = "Splitter1";
            this.Splitter1.TabStop = false;
            // 
            // lisMsgList
            // 
            this.lisMsgList.AllowColumnReorder = true;
            this.lisMsgList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColSeq,
            this.colTitle,
            this.colUpdateUser,
            this.colUpdateTime,
            this.colType,
            this.colResourceID,
            this.colResourceGroup,
            this.colArea,
            this.colSubarea,
            this.colUserID,
            this.colSecGroup,
            this.colPrivilegeGroup,
            this.colMaterial,
            this.colFlow,
            this.colOperation,
            this.colLotID,
            this.colApplyTimeFromTo,
            this.colShift,
            this.colPopupCycle,
            this.colRcvFactory,
            this.colAckFlag,
            this.colSysFlag,
            this.colDelFlag});
            resources.ApplyResources(this.lisMsgList, "lisMsgList");
            this.lisMsgList.EnableSort = true;
            this.lisMsgList.EnableSortIcon = true;
            this.lisMsgList.FullRowSelect = true;
            this.lisMsgList.MultiSelect = false;
            this.lisMsgList.Name = "lisMsgList";
            this.lisMsgList.UseCompatibleStateImageBehavior = false;
            this.lisMsgList.View = System.Windows.Forms.View.Details;
            this.lisMsgList.SelectedIndexChanged += new System.EventHandler(this.lisMsgList_SelectedIndexChanged);
            // 
            // ColSeq
            // 
            resources.ApplyResources(this.ColSeq, "ColSeq");
            // 
            // colTitle
            // 
            resources.ApplyResources(this.colTitle, "colTitle");
            // 
            // colUpdateUser
            // 
            resources.ApplyResources(this.colUpdateUser, "colUpdateUser");
            // 
            // colUpdateTime
            // 
            resources.ApplyResources(this.colUpdateTime, "colUpdateTime");
            // 
            // colType
            // 
            resources.ApplyResources(this.colType, "colType");
            // 
            // colResourceID
            // 
            resources.ApplyResources(this.colResourceID, "colResourceID");
            // 
            // colResourceGroup
            // 
            resources.ApplyResources(this.colResourceGroup, "colResourceGroup");
            // 
            // colArea
            // 
            resources.ApplyResources(this.colArea, "colArea");
            // 
            // colSubarea
            // 
            resources.ApplyResources(this.colSubarea, "colSubarea");
            // 
            // colUserID
            // 
            resources.ApplyResources(this.colUserID, "colUserID");
            // 
            // colSecGroup
            // 
            resources.ApplyResources(this.colSecGroup, "colSecGroup");
            // 
            // colPrivilegeGroup
            // 
            resources.ApplyResources(this.colPrivilegeGroup, "colPrivilegeGroup");
            // 
            // colMaterial
            // 
            resources.ApplyResources(this.colMaterial, "colMaterial");
            // 
            // colFlow
            // 
            resources.ApplyResources(this.colFlow, "colFlow");
            // 
            // colOperation
            // 
            resources.ApplyResources(this.colOperation, "colOperation");
            // 
            // colLotID
            // 
            resources.ApplyResources(this.colLotID, "colLotID");
            // 
            // colApplyTimeFromTo
            // 
            resources.ApplyResources(this.colApplyTimeFromTo, "colApplyTimeFromTo");
            // 
            // colShift
            // 
            resources.ApplyResources(this.colShift, "colShift");
            // 
            // colPopupCycle
            // 
            resources.ApplyResources(this.colPopupCycle, "colPopupCycle");
            // 
            // colRcvFactory
            // 
            resources.ApplyResources(this.colRcvFactory, "colRcvFactory");
            // 
            // colAckFlag
            // 
            resources.ApplyResources(this.colAckFlag, "colAckFlag");
            // 
            // colSysFlag
            // 
            resources.ApplyResources(this.colSysFlag, "colSysFlag");
            // 
            // colDelFlag
            // 
            resources.ApplyResources(this.colDelFlag, "colDelFlag");
            // 
            // frmBBSMain
            // 
            this.AcceptButton = this.btnSearch;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.KeyPreview = true;
            this.Name = "frmBBSMain";
            this.Activated += new System.EventHandler(this.frmBBSMain_Activated);
            this.Load += new System.EventHandler(this.frmBBSMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBBSMain_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmBBSMain_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmBBSMain_KeyUp);
            this.Resize += new System.EventHandler(this.frmBBSMain_Resize);
            this.pnlBottom.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUpdateUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.grpModification.ResumeLayout(false);
            this.grpSaveFile.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.pnlMid.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool mb_load_flag;
        private string msMainMenuID;
        private string msSubMenuID;
        
        #endregion
        
        #region " Function Definition "
        
        // View_BBS_Msg_List()
        //       - View BBS Msg List
        // Return Value
        //       -
        // Arguments
        //        -
        private bool ViewBBSMsgList()
        {
            TRSNode in_node = new TRSNode("VIEW_BBS_MSG_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BBS_MSG_LIST_OUT");

            int i;
            string sFromTime;
            string sToTime;
            ListViewItem itmX;

            int iCnt;
            int iIconIndex;
            List<TRSNode> msgList;


            MPCF.InitListView(lisMsgList);
            MPCF.InitListView(lisFile);

            txtMsg.Text = "";
            btnModify.Enabled = false;
            btnDelete.Enabled = false;
            iCnt = 0;

            sFromTime = MPCF.FromDate(dtpFrom);
            sToTime = MPCF.ToDate(dtpTo);

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddInt("NEXT_SEQ", 0);

                in_node.AddString("MAIN_MENU_ID", msMainMenuID);
                in_node.AddString("SUB_MENU_ID", msSubMenuID);

                in_node.AddString("FROM_TIME", sFromTime);
                in_node.AddString("TO_TIME", sToTime);
                in_node.AddString("RES_ID", MPCF.RTrim(cdvResID.Text));
                in_node.AddString("OPER", MPCF.RTrim(cdvOperation.Text));
                in_node.AddString("LOT_ID", MPCF.RTrim(txtLotID.Text));
                in_node.AddString("MSG_TITLE", MPCF.RTrim(txtTitle.Text));
                in_node.AddString("MSG_TYPE", MPCF.RTrim(cdvType.Text));

                /* Added by DM KIM 2012.04.25 New Condition Start */
                if (MPCF.Trim(cboPopupCycle.Text) != "")
                {
                    in_node.AddChar("POPUP_CYCLE", MPCF.ToChar(cboPopupCycle.Text.Substring(0, 1))); /* E : Every Time, O : Once And Done */
                }
                in_node.AddString("AREA_ID", MPCF.Trim(cdvAreaID.Text));
                in_node.AddString("RCV_USER_ID", MPCF.Trim(cdvUserID.Text));
                in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
                in_node.AddString("UPDATE_USER_ID", MPCF.Trim(cdvUpdateUser.Text));

                if (MPCF.Trim(cboApplyShift.Text) != "")
                {
                    in_node.AddChar("APPLY_SHIFT", MPCF.ToChar(cboApplyShift.Text.Substring(0, 1)));
                }

                in_node.AddChar("INCLUDE_ACK_MSG_FLAG", 'Y');
                in_node.AddChar("INCLUDE_DEL_FLAG", (chkIncDelMsg.Checked == true ? 'Y' : ' '));
                /* Added by DM KIM 2012.04.25 New Condition End */

                do
                {
                    if (MPCR.CallService("BAS", "BAS_View_BBS_Msg_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    msgList = out_node.GetList("MSG_LIST");

                    for (i = 0; i < msgList.Count; i++)
                    {
                        /* Modified by DM KIM 2012.04.25 Message Type에 따른 아이콘 변경 및 Field 추가 */
                        iIconIndex = (int)SMALLICON_INDEX.IDX_MESSAGE;
                        switch (msgList[i].GetString("MSG_TYPE"))
                        {
                            case MPGC.MP_BBS_MSG_TYPE_INFO:
                                iIconIndex = (int)SMALLICON_INDEX.IDX_ALARM_INFO;
                                break;
                            case MPGC.MP_BBS_MSG_TYPE_ERROR:
                                iIconIndex = (int)SMALLICON_INDEX.IDX_ALARM_ERROR;
                                break;
                            case MPGC.MP_BBS_MSG_TYPE_WARN:
                                iIconIndex = (int)SMALLICON_INDEX.IDX_ALARM_WARN;
                                break;
                        }

                        iCnt++;
                        itmX = new ListViewItem(iCnt.ToString(), iIconIndex);

                        if (msgList[i].GetChar("PRIORITY") == '0')
                        {
                            itmX.ForeColor = Color.Red;
                        }
                        if (msgList[i].GetChar("DELETE_FLAG") == 'Y')
                        {
                            itmX.ForeColor = Color.Magenta;
                        }

                        itmX.Tag = msgList[i].GetInt("BBS_SEQ");
                        itmX.SubItems.Add(msgList[i].GetString("MSG_TITLE"));
                        itmX.SubItems.Add(msgList[i].GetString("UPDATE_USER_ID"));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(msgList[i].GetString("UPDATE_TIME"), DATE_TIME_FORMAT.DATETIME));
                        itmX.SubItems.Add(msgList[i].GetString("MSG_TYPE"));
                        itmX.SubItems.Add(msgList[i].GetString("RES_ID"));
                        itmX.SubItems.Add(msgList[i].GetString("RESG_ID"));
                        itmX.SubItems.Add(msgList[i].GetString("AREA_ID"));
                        itmX.SubItems.Add(msgList[i].GetString("SUB_AREA_ID"));
                        itmX.SubItems.Add(msgList[i].GetString("RCV_USER_ID"));
                        itmX.SubItems.Add(msgList[i].GetString("SEC_GRP_ID"));
                        itmX.SubItems.Add(msgList[i].GetString("PRV_GRP_ID"));
                        itmX.SubItems.Add(msgList[i].GetString("MAT_ID"));
                        itmX.SubItems.Add(msgList[i].GetString("FLOW"));
                        itmX.SubItems.Add(msgList[i].GetString("OPER"));
                        itmX.SubItems.Add(msgList[i].GetString("LOT_ID"));
                        itmX.SubItems.Add(MPCF.MakeDateFormat(msgList[i].GetString("APPLY_START_TIME"), DATE_TIME_FORMAT.DATETIME) + " ~ " +
                                          MPCF.MakeDateFormat(msgList[i].GetString("APPLY_END_TIME"), DATE_TIME_FORMAT.DATETIME));
                        itmX.SubItems.Add(MPCF.Trim(msgList[i].GetChar("APPLY_SHIFT")));
                        itmX.SubItems.Add(MPCF.Trim(msgList[i].GetChar("POPUP_CYCLE")));
                        itmX.SubItems.Add(MPCF.Trim(msgList[i].GetString("RCV_FACTORY")));
                        itmX.SubItems.Add(MPCF.Trim(msgList[i].GetChar("ACK_FLAG")));
                        itmX.SubItems.Add(MPCF.Trim(msgList[i].GetChar("SYS_MSG_FLAG")));
                        itmX.SubItems.Add(MPCF.Trim(msgList[i].GetChar("DELETE_FLAG")));
                        lisMsgList.Items.Add(itmX);
                    }
                    in_node.SetInt("NEXT_SEQ", out_node.GetInt("NEXT_SEQ"));
                } while (in_node.GetInt("NEXT_SEQ") > 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            return true;
        }
        
        // View_BBS_Msg()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool ViewBBSMsg(int iBBSSeq)
        {
            int i;
            string sCreateUserID;

            TRSNode in_node = new TRSNode("VIEW_BBS_MSG_IN");
            TRSNode out_node = new TRSNode("VIEW_BBS_MSG_OUT");

            txtMsg.Text = "";

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddInt("BBS_SEQ",iBBSSeq );
            in_node.AddString("MAIN_MENU_ID", msMainMenuID);
            in_node.AddString("SUB_MENU_ID", msSubMenuID);

            if (MPCR.CallService("BAS", "BAS_View_BBS_Msg", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                txtMsg.Text += out_node.GetList(0)[i].GetString("MSG_TEXT");
            }

            sCreateUserID = MPCF.RTrim(out_node.GetString("CREATE_USER_ID"));

            //Admin Group은 수정 삭제 허용
            if (MPGV.gsUserGroup == "ADMIN_GROUP")
            {
                btnModify.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                //생성한 사람이 수정 삭제 가능
                if (sCreateUserID == MPGV.gsUserID)
                {
                    btnModify.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnModify.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }

            return true;
        }

        // Delete_BBS_Msg()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool DeleteBBSMsg(int iBBSSeq)
        {
            TRSNode in_node = new TRSNode("UPDATE_BBS_MSG_IN");
            TRSNode out_node = new TRSNode("UPDATE_BBS_MSG_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = MPGC.MP_STEP_DELETE;
            in_node.AddInt("BBS_SEQ", iBBSSeq);
            in_node.AddString("MAIN_MENU_ID", msMainMenuID);
            in_node.AddString("SUB_MENU_ID", msSubMenuID);

            if (MPCR.CallService("BAS", "BAS_Update_BBS_Msg", in_node, ref out_node) == false)
            {
                return false;
            }

            return true;
        }

        // SetMenuID()
        //       - Setting Main menu ID & Sub Menu ID at "frmMIDMain"
        // Return Value
        //       -
        // Arguments
        //        -
        public void SetMenuID(string sMainMenuID, string sSubMenuID, int iWidth, int iHeight)
        {
            msMainMenuID = sMainMenuID;
            msSubMenuID = sSubMenuID;

            this.Text = MPCF.FindLanguage("Bulletin Board", 0) + "(" + msMainMenuID + "-" + msSubMenuID + ")";
            this.lblFormTitle.Text = this.Text;

            cdvResID.Text = "";
            cdvOperation.Text = "";
            txtLotID.Text = "";
            txtTitle.Text = "";
            cdvType.Text = "";
            
            if (this.Width + 4 > iWidth)
            {
                this.Left = 0;
                this.Width = iWidth - 4;
            }
            if (this.Height + 4 > iHeight)
            {
                this.Top = 0;
                this.Height = iHeight - 4;
            }
            
            if (mb_load_flag == true)
            {
                ViewBBSMsgList();
            }
            else
            {
                this.Top = 0;
                this.Left = 0;
                this.Width = iWidth - 4;
                this.Height = iHeight - 4;
            }
        }
        
        // View_BBS_File_List()
        //       - View BBS File List
        // Return Value
        //       -
        // Arguments
        //        -
        private bool ViewBBSFileList(int iBBSSeq)
        {
            TRSNode in_node = new TRSNode("VIEW_BBS_FILE_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BBS_FILE_LIST_OUT");

            int i;
            ListViewItem itmX;

            MPCF.InitListView(lisFile);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAIN_MENU_ID", msMainMenuID);
            in_node.AddString("SUB_MENU_ID", msSubMenuID);
            in_node.AddInt("BBS_SEQ", iBBSSeq);


            if (MPCR.CallService("BAS", "BAS_View_BBS_File_List", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < out_node.GetList(0).Count; i++)
            {
                itmX = new ListViewItem((i+1).ToString(), (int)SMALLICON_INDEX.IDX_MESSAGE);
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("ORG_FILE_NAME"));
                itmX.SubItems.Add(out_node.GetList(0)[i].GetString("SAVE_FILE_NAME"));

                lisFile.Items.Add(itmX);
            }

            return true;
        }

        // Upload_BBS_File()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool DownloadBBSFile(int iBBSSeq, string s_save_file_name, string s_file_name)
        {
            TRSNode in_node = new TRSNode("DOWNLOAD_BBS_FILE_IN");
            TRSNode out_node = new TRSNode("DOWNLOADE_BBS_FILE_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MAIN_MENU_ID", msMainMenuID);
            in_node.AddString("SUB_MENU_ID", msSubMenuID);
            in_node.AddInt("BBS_SEQ", iBBSSeq);

            in_node.AddString("SAVE_FILE_NAME", s_save_file_name);


            if (MPCR.CallService("BAS", "BAS_Download_BBS_File", in_node, ref out_node) == false)
            {
                return false;
            }

            byte[] bt_buffer;
            if ((bt_buffer = out_node.GetBlob(MPGC.MP_BIN_DATA_1)) != null)
            {
                try
                {
                    FileStream fs = File.Open(s_file_name, FileMode.Create);
                    BinaryWriter writer = new BinaryWriter(fs);
                    writer.Write(bt_buffer, 0, bt_buffer.Length);
                    writer.Close();
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return false;
                }
            }

            return true;
        }

        public virtual Control GetFisrtFocusItem()
        {
            try
            {
                return this.lisMsgList;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
        }

        #endregion
        
        private void frmBBSMain_Load(object sender, System.EventArgs e)
        {
            MPGV.gIBaseFormEvent.Form_Load(this, e);

            //참조
            dtpFrom.Value = DateTime.Today.AddDays(-7);
            dtpTo.Value = DateTime.Today;
        }
        
        private void frmBBSMain_Activated(object sender, System.EventArgs e)
        {
            if (mb_load_flag == false)
            {
                ViewBBSMsgList();
                mb_load_flag = true;
            }
        }
        
        private void frmBBSMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is ListView)
                {
                    ListView lisList;
                    if (e.Control == true && e.KeyCode == Keys.C)
                    {
                        lisList = (ListView) this.ActiveControl;
                        if (lisList.SelectedItems.Count < 1)
                        {
                            Clipboard.SetDataObject("", true);
                        }
                        else
                        {
                            Clipboard.SetDataObject(lisList.SelectedItems[0].SubItems[2].Text, true);
                        }
                    }
                }
            }
        }
        
        private void frmBBSMain_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is TextBox)
                {
                    if (e.KeyValue != 13 && e.KeyValue != 8 || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                    {
                        if (MPCF.CheckMaxLength(this.ActiveControl, 0) == false)
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        
        private void frmBBSMain_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(this.ActiveControl == null))
            {
                if (this.ActiveControl is TextBox || this.ActiveControl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                {
                    if (e.KeyChar == (char)58)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        
        private void frmBBSMain_Resize(object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                if (this.MdiParent != null)
                {
                    pnlTop.Visible = true;
                }
                else
                {
                    pnlTop.Visible = false;
                }
            }
            else
            {
                pnlTop.Visible = false;
            }
        }
        
        private void lblFormTitle_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
       
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("ResID", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResID.GetListView, false);
            cdvResID.InsertEmptyRow(0, 1);
        }

        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Operation", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;
            WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "", 0, "", "", null, "");
            cdvOperation.InsertEmptyRow(0, 1);

        }

        private void cdvType_ButtonPress(object sender, EventArgs e)
        {
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Code", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvType.GetListView, '1', "BBS_MSG_TYPE");
            cdvType.InsertEmptyRow(0, 1);

        }

        private void cdvAreaID_ButtonPress(object sender, EventArgs e)
        {
            cdvAreaID.Init();
            MPCF.InitListView(cdvAreaID.GetListView);
            cdvAreaID.Columns.Add("AreaID", 50, HorizontalAlignment.Left);
            cdvAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAreaID.SelectedSubItemIndex = 0;
            if (BASLIST.ViewGCMDataList(cdvAreaID.GetListView, '1', MPGC.MP_RAS_AREA_CODE) == false)
            {
                return;
            }
            cdvAreaID.InsertEmptyRow(0, 1);
        }

        private void cdvMaterial_ButtonPress(object sender, EventArgs e)
        {
            cdvMaterial.Init();
            MPCF.InitListView(cdvMaterial.GetListView);
            cdvMaterial.Columns.Add("Material", 50, HorizontalAlignment.Left);
            cdvMaterial.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvMaterial.SelectedSubItemIndex = 0;
            WIPLIST.ViewMaterialList(cdvMaterial.GetListView, '1');
            cdvMaterial.InsertEmptyRow(0, 1);
        }

        private void cdvUserID_ButtonPress(object sender, EventArgs e)
        {
            cdvUserID.Init();
            MPCF.InitListView(cdvUserID.GetListView);
            cdvUserID.Columns.Add("UserID", 100, HorizontalAlignment.Left);
            cdvUserID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUserID.SelectedSubItemIndex = 0;
            SECLIST.ViewSECUserList(cdvUserID.GetListView);
            cdvUserID.InsertEmptyRow(0, 1);
        }

        private void cdvUpdateUser_ButtonPress(object sender, EventArgs e)
        {
            cdvUpdateUser.Init();
            MPCF.InitListView(cdvUpdateUser.GetListView);
            cdvUpdateUser.Columns.Add("UserID", 100, HorizontalAlignment.Left);
            cdvUpdateUser.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvUpdateUser.SelectedSubItemIndex = 0;
            SECLIST.ViewSECUserList(cdvUpdateUser.GetListView);
            cdvUpdateUser.InsertEmptyRow(0, 1);
        }

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
            ViewBBSMsgList();
        }

        private void btnNew_Click(System.Object sender, System.EventArgs e)
        {
            frmBBSNew f = new frmBBSNew();
            f.bModifyFlag = false;
            f.sCurrentMainMenuID = msMainMenuID;
            f.sCurrentSubMenuID = msSubMenuID;
            f.cTranType = MPGC.MP_STEP_CREATE;

            if (f.ShowDialog(this) == DialogResult.OK)
            {
                f.Dispose();
            }
            else
            {
                f.Dispose();
                return;
            }

            //항상 new된 data를 가지고 오기 위해서 날짜를 변경한다.
            dtpTo.Value = DateTime.Today;
            btnSearch.PerformClick();
        }

        private void btnModify_Click(System.Object sender, System.EventArgs e)
        {
           int iBBSSeq;

           if (lisMsgList.SelectedItems.Count < 1)
            {
                return;
            }

            iBBSSeq = MPCF.ToInt(lisMsgList.SelectedItems[0].Tag);

            frmBBSNew f = new frmBBSNew();
            f.bModifyFlag = true;
            f.sCurrentMainMenuID = msMainMenuID;
            f.sCurrentSubMenuID = msSubMenuID;
            f.iBBSSeq = iBBSSeq;
            f.cTranType = MPGC.MP_STEP_UPDATE;
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                f.Dispose();
            }
            else
            {
                f.Dispose();
                return;
            }

            btnSearch.PerformClick();
            //검색
            MPCF.FindListItem(lisMsgList, iBBSSeq.ToString(), false);

        }

        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            int iBBSSeq;

            if (lisMsgList.SelectedItems.Count < 1)
            {
                return;
            }

            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            iBBSSeq = MPCF.ToInt(lisMsgList.SelectedItems[0].Tag);

            if (DeleteBBSMsg(iBBSSeq) == false)
            {
                return;
            }

            btnSearch.PerformClick();
        }

        private void btnCheckMine_Click(object sender, EventArgs e)
        {
            MPCR.PopupInformNote(null, MPGV.gsUserID, "", "", "", "", "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int iBBSSeq;
              
            if (lisFile.SelectedItems.Count < 1)
            {
                return;
            }

            iBBSSeq = MPCF.ToInt(lisMsgList.SelectedItems[0].Tag);

            saveFileDialog.Filter = "All File | *.*";
            saveFileDialog.FileName = lisFile.SelectedItems[0].SubItems[1].Text;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (DownloadBBSFile(iBBSSeq, lisFile.SelectedItems[0].SubItems[2].Text, saveFileDialog.FileName) == false)
                {
                    return;
                }
            }
        }

        private void txtMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lisFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int iBBSSeq;
            string file_name;

            if (lisFile.SelectedItems.Count < 1)
            {
                return;
            }

            iBBSSeq = MPCF.ToInt(lisMsgList.SelectedItems[0].Tag);
            file_name = Environment.GetEnvironmentVariable("TEMP")+"\\" + lisFile.SelectedItems[0].SubItems[1].Text;

            if (DownloadBBSFile(iBBSSeq, lisFile.SelectedItems[0].SubItems[2].Text, file_name) == false)
            {
                return;
            }

            Process process = new Process();
            process.StartInfo.FileName = file_name;
            process.Start();

        }

        private void lisMsgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int iBBSSeq;

                if (lisMsgList.SelectedItems.Count < 1)
                {
                    return;
                }

                iBBSSeq = MPCF.ToInt(lisMsgList.SelectedItems[0].Tag);

                ViewBBSMsg(iBBSSeq);
                ViewBBSFileList(iBBSSeq);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }

}
