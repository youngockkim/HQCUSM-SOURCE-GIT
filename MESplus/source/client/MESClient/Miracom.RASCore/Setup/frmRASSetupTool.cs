
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
//   File Name   : frmRASSetupTool.vb
//   Description : Resource Setup Form
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
//#If _TOOL = True Then

namespace Miracom.RASCore
{
    public class frmRASSetupTool : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupTool()
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
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Panel pnlType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAreaID;
        private System.Windows.Forms.Label lblAreaID;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.GroupBox grpCMF;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private Miracom.UI.Controls.MCListView.MCListView lisTool;
        private System.Windows.Forms.TextBox txtTool;
        private System.Windows.Forms.Label lblTool;
        private System.Windows.Forms.TabControl tabTool;
        private System.Windows.Forms.Label lblToolGroup;
        private System.Windows.Forms.GroupBox grpTool;
        private System.Windows.Forms.Label lblToolSetID;
        private System.Windows.Forms.Label lblToolSetLoc;
        private System.Windows.Forms.Label lblSubAreaID;
        private System.Windows.Forms.Label lblToolLoc;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.TextBox txtToolSetID;
        private System.Windows.Forms.TextBox txtToolSetLoc;
        private System.Windows.Forms.TextBox txtToolLoc;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblSubLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Label lblToolStatus;
        private System.Windows.Forms.Label lblSubResID;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.Label lblOper;
        private System.Windows.Forms.TextBox txtVender;
        private System.Windows.Forms.Label lblVender;
        private System.Windows.Forms.TextBox txtVenderToolID;
        private System.Windows.Forms.Label lblVenderToolID;
        private System.Windows.Forms.TextBox txtCellCountX;
        private System.Windows.Forms.TextBox txtCellCountY;
        private System.Windows.Forms.Label lblCellCountY;
        private System.Windows.Forms.TextBox txtCellCountZ;
        private System.Windows.Forms.Label lblCellCountZ;
        private System.Windows.Forms.TextBox txtCellSizeZ;
        private System.Windows.Forms.Label lblCellSizeZ;
        private System.Windows.Forms.TextBox txtCellSizeY;
        private System.Windows.Forms.Label lblCellSizeY;
        private System.Windows.Forms.TextBox txtCellSizeX;
        private System.Windows.Forms.Label lblDeleteFlag;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubAreaID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolGradeID;
        private System.Windows.Forms.Label lblCellCountX;
        private System.Windows.Forms.Label lblCellSizeX;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
        private FarPoint.Win.Spread.FpSpread spdData;
        protected FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.Button btnScrap;
        private System.Windows.Forms.TextBox txtToolStatus;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.TextBox txtSubLotID;
        private System.Windows.Forms.TextBox txtResID;
        private System.Windows.Forms.TextBox txtSubResID;
        private System.Windows.Forms.TextBox txtFlow;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.TextBox txtDeleteFlag;
        private System.Windows.Forms.TextBox txtToolComment;
        private System.Windows.Forms.Label lblToolComment;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private CheckBox chkIncludeScrap;
        private TabPage tbpAttribute;
        private BASCore.udcAttributeStatus udcAttributeStatus;
        private System.Windows.Forms.Button btnRegenerate;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.grpTool = new System.Windows.Forms.GroupBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblTool = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtTool = new System.Windows.Forms.TextBox();
            this.pnlType = new System.Windows.Forms.Panel();
            this.chkIncludeScrap = new System.Windows.Forms.CheckBox();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblType = new System.Windows.Forms.Label();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.tabTool = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.txtToolComment = new System.Windows.Forms.TextBox();
            this.lblToolComment = new System.Windows.Forms.Label();
            this.txtDeleteFlag = new System.Windows.Forms.TextBox();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.txtFlow = new System.Windows.Forms.TextBox();
            this.txtSubResID = new System.Windows.Forms.TextBox();
            this.txtResID = new System.Windows.Forms.TextBox();
            this.txtSubLotID = new System.Windows.Forms.TextBox();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.txtToolStatus = new System.Windows.Forms.TextBox();
            this.lblCellSizeX = new System.Windows.Forms.Label();
            this.lblCellCountX = new System.Windows.Forms.Label();
            this.lblDeleteFlag = new System.Windows.Forms.Label();
            this.txtCellSizeZ = new System.Windows.Forms.TextBox();
            this.lblCellSizeZ = new System.Windows.Forms.Label();
            this.txtCellSizeY = new System.Windows.Forms.TextBox();
            this.lblCellSizeY = new System.Windows.Forms.Label();
            this.txtCellSizeX = new System.Windows.Forms.TextBox();
            this.txtCellCountZ = new System.Windows.Forms.TextBox();
            this.lblCellCountZ = new System.Windows.Forms.Label();
            this.txtCellCountY = new System.Windows.Forms.TextBox();
            this.lblCellCountY = new System.Windows.Forms.Label();
            this.txtCellCountX = new System.Windows.Forms.TextBox();
            this.txtVenderToolID = new System.Windows.Forms.TextBox();
            this.lblVenderToolID = new System.Windows.Forms.Label();
            this.txtVender = new System.Windows.Forms.TextBox();
            this.lblVender = new System.Windows.Forms.Label();
            this.lblOper = new System.Windows.Forms.Label();
            this.lblFlow = new System.Windows.Forms.Label();
            this.lblSubResID = new System.Windows.Forms.Label();
            this.txtToolLoc = new System.Windows.Forms.TextBox();
            this.txtToolSetLoc = new System.Windows.Forms.TextBox();
            this.txtToolSetID = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblToolLoc = new System.Windows.Forms.Label();
            this.cdvToolGradeID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubAreaID = new System.Windows.Forms.Label();
            this.lblToolSetLoc = new System.Windows.Forms.Label();
            this.cdvToolGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblSubLotID = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.lblToolStatus = new System.Windows.Forms.Label();
            this.cdvSubAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvAreaID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToolSetID = new System.Windows.Forms.Label();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.lblToolGroup = new System.Windows.Forms.Label();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpAttribute = new System.Windows.Forms.TabPage();
            this.udcAttributeStatus = new Miracom.BASCore.udcAttributeStatus();
            this.lisTool = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnScrap = new System.Windows.Forms.Button();
            this.btnRegenerate = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTool.SuspendLayout();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            this.pnlGeneral.SuspendLayout();
            this.tabTool.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolGradeID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).BeginInit();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.tbpAttribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 5;
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
            this.pnlRight.Controls.Add(this.grpTool);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisTool);
            this.pnlLeft.Controls.Add(this.pnlType);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(282, 7);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Return";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(374, 7);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRegenerate);
            this.pnlBottom.Controls.Add(this.btnScrap);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnScrap, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRegenerate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Tool Setup";
            // 
            // grpTool
            // 
            this.grpTool.Controls.Add(this.lblDesc);
            this.grpTool.Controls.Add(this.lblTool);
            this.grpTool.Controls.Add(this.txtDesc);
            this.grpTool.Controls.Add(this.txtTool);
            this.grpTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTool.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTool.Location = new System.Drawing.Point(3, 0);
            this.grpTool.Name = "grpTool";
            this.grpTool.Size = new System.Drawing.Size(500, 71);
            this.grpTool.TabIndex = 0;
            this.grpTool.TabStop = false;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(16, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Description";
            // 
            // lblTool
            // 
            this.lblTool.AutoSize = true;
            this.lblTool.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTool.Location = new System.Drawing.Point(15, 19);
            this.lblTool.Name = "lblTool";
            this.lblTool.Size = new System.Drawing.Size(32, 13);
            this.lblTool.TabIndex = 0;
            this.lblTool.Text = "Tool";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(142, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(348, 20);
            this.txtDesc.TabIndex = 4;
            // 
            // txtTool
            // 
            this.txtTool.Location = new System.Drawing.Point(142, 16);
            this.txtTool.MaxLength = 30;
            this.txtTool.Name = "txtTool";
            this.txtTool.Size = new System.Drawing.Size(200, 20);
            this.txtTool.TabIndex = 1;
            this.txtTool.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTool_KeyPress);
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.chkIncludeScrap);
            this.pnlType.Controls.Add(this.cdvType);
            this.pnlType.Controls.Add(this.lblType);
            this.pnlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlType.Location = new System.Drawing.Point(3, 0);
            this.pnlType.Name = "pnlType";
            this.pnlType.Size = new System.Drawing.Size(229, 56);
            this.pnlType.TabIndex = 0;
            // 
            // chkIncludeScrap
            // 
            this.chkIncludeScrap.AutoSize = true;
            this.chkIncludeScrap.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncludeScrap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeScrap.Location = new System.Drawing.Point(6, 34);
            this.chkIncludeScrap.Name = "chkIncludeScrap";
            this.chkIncludeScrap.Size = new System.Drawing.Size(139, 18);
            this.chkIncludeScrap.TabIndex = 2;
            this.chkIncludeScrap.Text = "Include Scraped Tools";
            this.chkIncludeScrap.UseVisualStyleBackColor = true;
            this.chkIncludeScrap.CheckedChanged += new System.EventHandler(this.chkIncludeScrap_CheckedChanged);
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
            this.cdvType.TabIndex = 1;
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
            this.lblType.Size = new System.Drawing.Size(55, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Tool Type";
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.Controls.Add(this.tabTool);
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneral.Location = new System.Drawing.Point(3, 71);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlGeneral.Size = new System.Drawing.Size(500, 432);
            this.pnlGeneral.TabIndex = 1;
            // 
            // tabTool
            // 
            this.tabTool.Controls.Add(this.tbpGeneral);
            this.tabTool.Controls.Add(this.tbpCMF);
            this.tabTool.Controls.Add(this.tbpAttribute);
            this.tabTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTool.ItemSize = new System.Drawing.Size(60, 18);
            this.tabTool.Location = new System.Drawing.Point(0, 5);
            this.tabTool.Name = "tabTool";
            this.tabTool.SelectedIndex = 0;
            this.tabTool.Size = new System.Drawing.Size(500, 427);
            this.tabTool.TabIndex = 0;
            this.tabTool.TabStop = false;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 401);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.cdvMaterial);
            this.grpGeneral.Controls.Add(this.txtToolComment);
            this.grpGeneral.Controls.Add(this.lblToolComment);
            this.grpGeneral.Controls.Add(this.txtDeleteFlag);
            this.grpGeneral.Controls.Add(this.txtOper);
            this.grpGeneral.Controls.Add(this.txtFlow);
            this.grpGeneral.Controls.Add(this.txtSubResID);
            this.grpGeneral.Controls.Add(this.txtResID);
            this.grpGeneral.Controls.Add(this.txtSubLotID);
            this.grpGeneral.Controls.Add(this.txtLotID);
            this.grpGeneral.Controls.Add(this.txtToolStatus);
            this.grpGeneral.Controls.Add(this.lblCellSizeX);
            this.grpGeneral.Controls.Add(this.lblCellCountX);
            this.grpGeneral.Controls.Add(this.lblDeleteFlag);
            this.grpGeneral.Controls.Add(this.txtCellSizeZ);
            this.grpGeneral.Controls.Add(this.lblCellSizeZ);
            this.grpGeneral.Controls.Add(this.txtCellSizeY);
            this.grpGeneral.Controls.Add(this.lblCellSizeY);
            this.grpGeneral.Controls.Add(this.txtCellSizeX);
            this.grpGeneral.Controls.Add(this.txtCellCountZ);
            this.grpGeneral.Controls.Add(this.lblCellCountZ);
            this.grpGeneral.Controls.Add(this.txtCellCountY);
            this.grpGeneral.Controls.Add(this.lblCellCountY);
            this.grpGeneral.Controls.Add(this.txtCellCountX);
            this.grpGeneral.Controls.Add(this.txtVenderToolID);
            this.grpGeneral.Controls.Add(this.lblVenderToolID);
            this.grpGeneral.Controls.Add(this.txtVender);
            this.grpGeneral.Controls.Add(this.lblVender);
            this.grpGeneral.Controls.Add(this.lblOper);
            this.grpGeneral.Controls.Add(this.lblFlow);
            this.grpGeneral.Controls.Add(this.lblSubResID);
            this.grpGeneral.Controls.Add(this.txtToolLoc);
            this.grpGeneral.Controls.Add(this.txtToolSetLoc);
            this.grpGeneral.Controls.Add(this.txtToolSetID);
            this.grpGeneral.Controls.Add(this.lblGrade);
            this.grpGeneral.Controls.Add(this.lblToolLoc);
            this.grpGeneral.Controls.Add(this.cdvToolGradeID);
            this.grpGeneral.Controls.Add(this.lblSubAreaID);
            this.grpGeneral.Controls.Add(this.lblToolSetLoc);
            this.grpGeneral.Controls.Add(this.cdvToolGroup);
            this.grpGeneral.Controls.Add(this.lblResID);
            this.grpGeneral.Controls.Add(this.lblSubLotID);
            this.grpGeneral.Controls.Add(this.lblLotID);
            this.grpGeneral.Controls.Add(this.lblToolStatus);
            this.grpGeneral.Controls.Add(this.cdvSubAreaID);
            this.grpGeneral.Controls.Add(this.cdvAreaID);
            this.grpGeneral.Controls.Add(this.lblToolSetID);
            this.grpGeneral.Controls.Add(this.lblAreaID);
            this.grpGeneral.Controls.Add(this.lblToolGroup);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(486, 398);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 208);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = true;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(224, 20);
            this.cdvMaterial.TabIndex = 32;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = true;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = false;
            this.cdvMaterial.VisibleVersionButton = false;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 108;
            this.cdvMaterial.WidthMaterialAndVersion = 116;
            this.cdvMaterial.WidthVersion = 40;
            // 
            // txtToolComment
            // 
            this.txtToolComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToolComment.Location = new System.Drawing.Point(119, 304);
            this.txtToolComment.MaxLength = 400;
            this.txtToolComment.Multiline = true;
            this.txtToolComment.Name = "txtToolComment";
            this.txtToolComment.Size = new System.Drawing.Size(356, 88);
            this.txtToolComment.TabIndex = 48;
            // 
            // lblToolComment
            // 
            this.lblToolComment.AutoSize = true;
            this.lblToolComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolComment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolComment.Location = new System.Drawing.Point(11, 308);
            this.lblToolComment.Name = "lblToolComment";
            this.lblToolComment.Size = new System.Drawing.Size(75, 13);
            this.lblToolComment.TabIndex = 47;
            this.lblToolComment.Text = "Tool Comment";
            // 
            // txtDeleteFlag
            // 
            this.txtDeleteFlag.Location = new System.Drawing.Point(120, 280);
            this.txtDeleteFlag.MaxLength = 1;
            this.txtDeleteFlag.Name = "txtDeleteFlag";
            this.txtDeleteFlag.ReadOnly = true;
            this.txtDeleteFlag.Size = new System.Drawing.Size(116, 20);
            this.txtDeleteFlag.TabIndex = 44;
            this.txtDeleteFlag.TabStop = false;
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(120, 256);
            this.txtOper.MaxLength = 10;
            this.txtOper.Name = "txtOper";
            this.txtOper.ReadOnly = true;
            this.txtOper.Size = new System.Drawing.Size(116, 20);
            this.txtOper.TabIndex = 40;
            this.txtOper.TabStop = false;
            // 
            // txtFlow
            // 
            this.txtFlow.Location = new System.Drawing.Point(120, 232);
            this.txtFlow.MaxLength = 20;
            this.txtFlow.Name = "txtFlow";
            this.txtFlow.ReadOnly = true;
            this.txtFlow.Size = new System.Drawing.Size(116, 20);
            this.txtFlow.TabIndex = 36;
            this.txtFlow.TabStop = false;
            // 
            // txtSubResID
            // 
            this.txtSubResID.Location = new System.Drawing.Point(120, 184);
            this.txtSubResID.MaxLength = 20;
            this.txtSubResID.Name = "txtSubResID";
            this.txtSubResID.ReadOnly = true;
            this.txtSubResID.Size = new System.Drawing.Size(116, 20);
            this.txtSubResID.TabIndex = 29;
            this.txtSubResID.TabStop = false;
            // 
            // txtResID
            // 
            this.txtResID.Location = new System.Drawing.Point(120, 160);
            this.txtResID.MaxLength = 20;
            this.txtResID.Name = "txtResID";
            this.txtResID.ReadOnly = true;
            this.txtResID.Size = new System.Drawing.Size(116, 20);
            this.txtResID.TabIndex = 25;
            this.txtResID.TabStop = false;
            // 
            // txtSubLotID
            // 
            this.txtSubLotID.Location = new System.Drawing.Point(120, 136);
            this.txtSubLotID.MaxLength = 30;
            this.txtSubLotID.Name = "txtSubLotID";
            this.txtSubLotID.ReadOnly = true;
            this.txtSubLotID.Size = new System.Drawing.Size(116, 20);
            this.txtSubLotID.TabIndex = 21;
            this.txtSubLotID.TabStop = false;
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(120, 112);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(116, 20);
            this.txtLotID.TabIndex = 17;
            this.txtLotID.TabStop = false;
            // 
            // txtToolStatus
            // 
            this.txtToolStatus.Location = new System.Drawing.Point(120, 88);
            this.txtToolStatus.MaxLength = 10;
            this.txtToolStatus.Name = "txtToolStatus";
            this.txtToolStatus.ReadOnly = true;
            this.txtToolStatus.Size = new System.Drawing.Size(116, 20);
            this.txtToolStatus.TabIndex = 13;
            this.txtToolStatus.TabStop = false;
            // 
            // lblCellSizeX
            // 
            this.lblCellSizeX.AutoSize = true;
            this.lblCellSizeX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellSizeX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellSizeX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellSizeX.Location = new System.Drawing.Point(254, 235);
            this.lblCellSizeX.Name = "lblCellSizeX";
            this.lblCellSizeX.Size = new System.Drawing.Size(57, 13);
            this.lblCellSizeX.TabIndex = 37;
            this.lblCellSizeX.Text = "Cell Size X";
            // 
            // lblCellCountX
            // 
            this.lblCellCountX.AutoSize = true;
            this.lblCellCountX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellCountX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellCountX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellCountX.Location = new System.Drawing.Point(254, 163);
            this.lblCellCountX.Name = "lblCellCountX";
            this.lblCellCountX.Size = new System.Drawing.Size(65, 13);
            this.lblCellCountX.TabIndex = 26;
            this.lblCellCountX.Text = "Cell Count X";
            // 
            // lblDeleteFlag
            // 
            this.lblDeleteFlag.AutoSize = true;
            this.lblDeleteFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDeleteFlag.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDeleteFlag.Location = new System.Drawing.Point(12, 283);
            this.lblDeleteFlag.Name = "lblDeleteFlag";
            this.lblDeleteFlag.Size = new System.Drawing.Size(61, 13);
            this.lblDeleteFlag.TabIndex = 43;
            this.lblDeleteFlag.Text = "Delete Flag";
            // 
            // txtCellSizeZ
            // 
            this.txtCellSizeZ.Location = new System.Drawing.Point(360, 280);
            this.txtCellSizeZ.MaxLength = 10;
            this.txtCellSizeZ.Name = "txtCellSizeZ";
            this.txtCellSizeZ.Size = new System.Drawing.Size(116, 20);
            this.txtCellSizeZ.TabIndex = 46;
            this.txtCellSizeZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // lblCellSizeZ
            // 
            this.lblCellSizeZ.AutoSize = true;
            this.lblCellSizeZ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellSizeZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellSizeZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellSizeZ.Location = new System.Drawing.Point(254, 283);
            this.lblCellSizeZ.Name = "lblCellSizeZ";
            this.lblCellSizeZ.Size = new System.Drawing.Size(57, 13);
            this.lblCellSizeZ.TabIndex = 45;
            this.lblCellSizeZ.Text = "Cell Size Z";
            // 
            // txtCellSizeY
            // 
            this.txtCellSizeY.Location = new System.Drawing.Point(360, 256);
            this.txtCellSizeY.MaxLength = 10;
            this.txtCellSizeY.Name = "txtCellSizeY";
            this.txtCellSizeY.Size = new System.Drawing.Size(116, 20);
            this.txtCellSizeY.TabIndex = 42;
            this.txtCellSizeY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // lblCellSizeY
            // 
            this.lblCellSizeY.AutoSize = true;
            this.lblCellSizeY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellSizeY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellSizeY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellSizeY.Location = new System.Drawing.Point(254, 259);
            this.lblCellSizeY.Name = "lblCellSizeY";
            this.lblCellSizeY.Size = new System.Drawing.Size(57, 13);
            this.lblCellSizeY.TabIndex = 41;
            this.lblCellSizeY.Text = "Cell Size Y";
            // 
            // txtCellSizeX
            // 
            this.txtCellSizeX.Location = new System.Drawing.Point(360, 232);
            this.txtCellSizeX.MaxLength = 10;
            this.txtCellSizeX.Name = "txtCellSizeX";
            this.txtCellSizeX.Size = new System.Drawing.Size(116, 20);
            this.txtCellSizeX.TabIndex = 38;
            this.txtCellSizeX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // txtCellCountZ
            // 
            this.txtCellCountZ.Location = new System.Drawing.Point(360, 208);
            this.txtCellCountZ.MaxLength = 10;
            this.txtCellCountZ.Name = "txtCellCountZ";
            this.txtCellCountZ.Size = new System.Drawing.Size(116, 20);
            this.txtCellCountZ.TabIndex = 34;
            this.txtCellCountZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // lblCellCountZ
            // 
            this.lblCellCountZ.AutoSize = true;
            this.lblCellCountZ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellCountZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellCountZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellCountZ.Location = new System.Drawing.Point(254, 211);
            this.lblCellCountZ.Name = "lblCellCountZ";
            this.lblCellCountZ.Size = new System.Drawing.Size(65, 13);
            this.lblCellCountZ.TabIndex = 33;
            this.lblCellCountZ.Text = "Cell Count Z";
            // 
            // txtCellCountY
            // 
            this.txtCellCountY.Location = new System.Drawing.Point(360, 184);
            this.txtCellCountY.MaxLength = 10;
            this.txtCellCountY.Name = "txtCellCountY";
            this.txtCellCountY.Size = new System.Drawing.Size(116, 20);
            this.txtCellCountY.TabIndex = 31;
            this.txtCellCountY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // lblCellCountY
            // 
            this.lblCellCountY.AutoSize = true;
            this.lblCellCountY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellCountY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellCountY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellCountY.Location = new System.Drawing.Point(254, 187);
            this.lblCellCountY.Name = "lblCellCountY";
            this.lblCellCountY.Size = new System.Drawing.Size(65, 13);
            this.lblCellCountY.TabIndex = 30;
            this.lblCellCountY.Text = "Cell Count Y";
            // 
            // txtCellCountX
            // 
            this.txtCellCountX.Location = new System.Drawing.Point(360, 160);
            this.txtCellCountX.MaxLength = 10;
            this.txtCellCountX.Name = "txtCellCountX";
            this.txtCellCountX.Size = new System.Drawing.Size(116, 20);
            this.txtCellCountX.TabIndex = 27;
            this.txtCellCountX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCount_KeyPress);
            // 
            // txtVenderToolID
            // 
            this.txtVenderToolID.Location = new System.Drawing.Point(360, 112);
            this.txtVenderToolID.MaxLength = 30;
            this.txtVenderToolID.Name = "txtVenderToolID";
            this.txtVenderToolID.Size = new System.Drawing.Size(116, 20);
            this.txtVenderToolID.TabIndex = 19;
            // 
            // lblVenderToolID
            // 
            this.lblVenderToolID.AutoSize = true;
            this.lblVenderToolID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVenderToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVenderToolID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVenderToolID.Location = new System.Drawing.Point(254, 115);
            this.lblVenderToolID.Name = "lblVenderToolID";
            this.lblVenderToolID.Size = new System.Drawing.Size(79, 13);
            this.lblVenderToolID.TabIndex = 18;
            this.lblVenderToolID.Text = "Vendor Tool ID";
            // 
            // txtVender
            // 
            this.txtVender.Location = new System.Drawing.Point(360, 88);
            this.txtVender.MaxLength = 20;
            this.txtVender.Name = "txtVender";
            this.txtVender.Size = new System.Drawing.Size(116, 20);
            this.txtVender.TabIndex = 15;
            // 
            // lblVender
            // 
            this.lblVender.AutoSize = true;
            this.lblVender.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVender.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVender.Location = new System.Drawing.Point(254, 91);
            this.lblVender.Name = "lblVender";
            this.lblVender.Size = new System.Drawing.Size(41, 13);
            this.lblVender.TabIndex = 14;
            this.lblVender.Text = "Vendor";
            // 
            // lblOper
            // 
            this.lblOper.AutoSize = true;
            this.lblOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOper.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOper.Location = new System.Drawing.Point(12, 259);
            this.lblOper.Name = "lblOper";
            this.lblOper.Size = new System.Drawing.Size(53, 13);
            this.lblOper.TabIndex = 39;
            this.lblOper.Text = "Operation";
            // 
            // lblFlow
            // 
            this.lblFlow.AutoSize = true;
            this.lblFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFlow.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFlow.Location = new System.Drawing.Point(12, 235);
            this.lblFlow.Name = "lblFlow";
            this.lblFlow.Size = new System.Drawing.Size(29, 13);
            this.lblFlow.TabIndex = 35;
            this.lblFlow.Text = "Flow";
            // 
            // lblSubResID
            // 
            this.lblSubResID.AutoSize = true;
            this.lblSubResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubResID.Location = new System.Drawing.Point(12, 187);
            this.lblSubResID.Name = "lblSubResID";
            this.lblSubResID.Size = new System.Drawing.Size(75, 13);
            this.lblSubResID.TabIndex = 28;
            this.lblSubResID.Text = "Sub Resource";
            // 
            // txtToolLoc
            // 
            this.txtToolLoc.Location = new System.Drawing.Point(360, 64);
            this.txtToolLoc.MaxLength = 20;
            this.txtToolLoc.Name = "txtToolLoc";
            this.txtToolLoc.Size = new System.Drawing.Size(116, 20);
            this.txtToolLoc.TabIndex = 11;
            // 
            // txtToolSetLoc
            // 
            this.txtToolSetLoc.Location = new System.Drawing.Point(120, 64);
            this.txtToolSetLoc.MaxLength = 20;
            this.txtToolSetLoc.Name = "txtToolSetLoc";
            this.txtToolSetLoc.Size = new System.Drawing.Size(116, 20);
            this.txtToolSetLoc.TabIndex = 9;
            // 
            // txtToolSetID
            // 
            this.txtToolSetID.Location = new System.Drawing.Point(120, 40);
            this.txtToolSetID.MaxLength = 20;
            this.txtToolSetID.Name = "txtToolSetID";
            this.txtToolSetID.Size = new System.Drawing.Size(116, 20);
            this.txtToolSetID.TabIndex = 5;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGrade.Location = new System.Drawing.Point(254, 139);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(36, 13);
            this.lblGrade.TabIndex = 22;
            this.lblGrade.Text = "Grade";
            // 
            // lblToolLoc
            // 
            this.lblToolLoc.AutoSize = true;
            this.lblToolLoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolLoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolLoc.Location = new System.Drawing.Point(252, 67);
            this.lblToolLoc.Name = "lblToolLoc";
            this.lblToolLoc.Size = new System.Drawing.Size(72, 13);
            this.lblToolLoc.TabIndex = 10;
            this.lblToolLoc.Text = "Tool Location";
            // 
            // cdvToolGradeID
            // 
            this.cdvToolGradeID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolGradeID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolGradeID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolGradeID.BtnToolTipText = "";
            this.cdvToolGradeID.DescText = "";
            this.cdvToolGradeID.DisplaySubItemIndex = -1;
            this.cdvToolGradeID.DisplayText = "";
            this.cdvToolGradeID.Focusing = null;
            this.cdvToolGradeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolGradeID.Index = 0;
            this.cdvToolGradeID.IsViewBtnImage = false;
            this.cdvToolGradeID.Location = new System.Drawing.Point(360, 136);
            this.cdvToolGradeID.MaxLength = 1;
            this.cdvToolGradeID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolGradeID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolGradeID.Name = "cdvToolGradeID";
            this.cdvToolGradeID.ReadOnly = false;
            this.cdvToolGradeID.SearchSubItemIndex = 0;
            this.cdvToolGradeID.SelectedDescIndex = -1;
            this.cdvToolGradeID.SelectedSubItemIndex = -1;
            this.cdvToolGradeID.SelectionStart = 0;
            this.cdvToolGradeID.Size = new System.Drawing.Size(116, 20);
            this.cdvToolGradeID.SmallImageList = null;
            this.cdvToolGradeID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolGradeID.TabIndex = 23;
            this.cdvToolGradeID.TextBoxToolTipText = "";
            this.cdvToolGradeID.TextBoxWidth = 116;
            this.cdvToolGradeID.VisibleButton = true;
            this.cdvToolGradeID.VisibleColumnHeader = false;
            this.cdvToolGradeID.VisibleDescription = false;
            this.cdvToolGradeID.ButtonPress += new System.EventHandler(this.cdvToolGradeID_ButtonPress);
            // 
            // lblSubAreaID
            // 
            this.lblSubAreaID.AutoSize = true;
            this.lblSubAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubAreaID.Location = new System.Drawing.Point(252, 43);
            this.lblSubAreaID.Name = "lblSubAreaID";
            this.lblSubAreaID.Size = new System.Drawing.Size(65, 13);
            this.lblSubAreaID.TabIndex = 6;
            this.lblSubAreaID.Text = "Sub Area ID";
            // 
            // lblToolSetLoc
            // 
            this.lblToolSetLoc.AutoSize = true;
            this.lblToolSetLoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolSetLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolSetLoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolSetLoc.Location = new System.Drawing.Point(12, 67);
            this.lblToolSetLoc.Name = "lblToolSetLoc";
            this.lblToolSetLoc.Size = new System.Drawing.Size(91, 13);
            this.lblToolSetLoc.TabIndex = 8;
            this.lblToolSetLoc.Text = "Tool Set Location";
            // 
            // cdvToolGroup
            // 
            this.cdvToolGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolGroup.BtnToolTipText = "";
            this.cdvToolGroup.DescText = "";
            this.cdvToolGroup.DisplaySubItemIndex = -1;
            this.cdvToolGroup.DisplayText = "";
            this.cdvToolGroup.Focusing = null;
            this.cdvToolGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolGroup.Index = 0;
            this.cdvToolGroup.IsViewBtnImage = false;
            this.cdvToolGroup.Location = new System.Drawing.Point(120, 16);
            this.cdvToolGroup.MaxLength = 20;
            this.cdvToolGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolGroup.Name = "cdvToolGroup";
            this.cdvToolGroup.ReadOnly = false;
            this.cdvToolGroup.SearchSubItemIndex = 0;
            this.cdvToolGroup.SelectedDescIndex = -1;
            this.cdvToolGroup.SelectedSubItemIndex = -1;
            this.cdvToolGroup.SelectionStart = 0;
            this.cdvToolGroup.Size = new System.Drawing.Size(116, 20);
            this.cdvToolGroup.SmallImageList = null;
            this.cdvToolGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolGroup.TabIndex = 1;
            this.cdvToolGroup.TextBoxToolTipText = "";
            this.cdvToolGroup.TextBoxWidth = 116;
            this.cdvToolGroup.VisibleButton = true;
            this.cdvToolGroup.VisibleColumnHeader = false;
            this.cdvToolGroup.VisibleDescription = false;
            this.cdvToolGroup.ButtonPress += new System.EventHandler(this.cdvToolGroup_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResID.Location = new System.Drawing.Point(12, 163);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(53, 13);
            this.lblResID.TabIndex = 24;
            this.lblResID.Text = "Resource";
            // 
            // lblSubLotID
            // 
            this.lblSubLotID.AutoSize = true;
            this.lblSubLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubLotID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubLotID.Location = new System.Drawing.Point(12, 139);
            this.lblSubLotID.Name = "lblSubLotID";
            this.lblSubLotID.Size = new System.Drawing.Size(58, 13);
            this.lblSubLotID.TabIndex = 20;
            this.lblSubLotID.Text = "Sub Lot ID";
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLotID.Location = new System.Drawing.Point(12, 115);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 16;
            this.lblLotID.Text = "Lot ID";
            // 
            // lblToolStatus
            // 
            this.lblToolStatus.AutoSize = true;
            this.lblToolStatus.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolStatus.Location = new System.Drawing.Point(12, 91);
            this.lblToolStatus.Name = "lblToolStatus";
            this.lblToolStatus.Size = new System.Drawing.Size(61, 13);
            this.lblToolStatus.TabIndex = 12;
            this.lblToolStatus.Text = "Tool Status";
            // 
            // cdvSubAreaID
            // 
            this.cdvSubAreaID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubAreaID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubAreaID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubAreaID.BtnToolTipText = "";
            this.cdvSubAreaID.DescText = "";
            this.cdvSubAreaID.DisplaySubItemIndex = -1;
            this.cdvSubAreaID.DisplayText = "";
            this.cdvSubAreaID.Focusing = null;
            this.cdvSubAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubAreaID.Index = 0;
            this.cdvSubAreaID.IsViewBtnImage = false;
            this.cdvSubAreaID.Location = new System.Drawing.Point(360, 40);
            this.cdvSubAreaID.MaxLength = 20;
            this.cdvSubAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubAreaID.Name = "cdvSubAreaID";
            this.cdvSubAreaID.ReadOnly = false;
            this.cdvSubAreaID.SearchSubItemIndex = 0;
            this.cdvSubAreaID.SelectedDescIndex = -1;
            this.cdvSubAreaID.SelectedSubItemIndex = -1;
            this.cdvSubAreaID.SelectionStart = 0;
            this.cdvSubAreaID.Size = new System.Drawing.Size(116, 20);
            this.cdvSubAreaID.SmallImageList = null;
            this.cdvSubAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubAreaID.TabIndex = 7;
            this.cdvSubAreaID.TextBoxToolTipText = "";
            this.cdvSubAreaID.TextBoxWidth = 116;
            this.cdvSubAreaID.VisibleButton = true;
            this.cdvSubAreaID.VisibleColumnHeader = false;
            this.cdvSubAreaID.VisibleDescription = false;
            this.cdvSubAreaID.ButtonPress += new System.EventHandler(this.cdvSubAreaID_ButtonPress);
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
            this.cdvAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAreaID.Index = 0;
            this.cdvAreaID.IsViewBtnImage = false;
            this.cdvAreaID.Location = new System.Drawing.Point(360, 16);
            this.cdvAreaID.MaxLength = 20;
            this.cdvAreaID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAreaID.Name = "cdvAreaID";
            this.cdvAreaID.ReadOnly = false;
            this.cdvAreaID.SearchSubItemIndex = 0;
            this.cdvAreaID.SelectedDescIndex = -1;
            this.cdvAreaID.SelectedSubItemIndex = -1;
            this.cdvAreaID.SelectionStart = 0;
            this.cdvAreaID.Size = new System.Drawing.Size(116, 20);
            this.cdvAreaID.SmallImageList = null;
            this.cdvAreaID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAreaID.TabIndex = 3;
            this.cdvAreaID.TextBoxToolTipText = "";
            this.cdvAreaID.TextBoxWidth = 116;
            this.cdvAreaID.VisibleButton = true;
            this.cdvAreaID.VisibleColumnHeader = false;
            this.cdvAreaID.VisibleDescription = false;
            this.cdvAreaID.ButtonPress += new System.EventHandler(this.cdvAreaID_ButtonPress);
            // 
            // lblToolSetID
            // 
            this.lblToolSetID.AutoSize = true;
            this.lblToolSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolSetID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolSetID.Location = new System.Drawing.Point(12, 43);
            this.lblToolSetID.Name = "lblToolSetID";
            this.lblToolSetID.Size = new System.Drawing.Size(61, 13);
            this.lblToolSetID.TabIndex = 4;
            this.lblToolSetID.Text = "Tool Set ID";
            // 
            // lblAreaID
            // 
            this.lblAreaID.AutoSize = true;
            this.lblAreaID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreaID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAreaID.Location = new System.Drawing.Point(252, 19);
            this.lblAreaID.Name = "lblAreaID";
            this.lblAreaID.Size = new System.Drawing.Size(43, 13);
            this.lblAreaID.TabIndex = 2;
            this.lblAreaID.Text = "Area ID";
            // 
            // lblToolGroup
            // 
            this.lblToolGroup.AutoSize = true;
            this.lblToolGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolGroup.Location = new System.Drawing.Point(12, 19);
            this.lblToolGroup.Name = "lblToolGroup";
            this.lblToolGroup.Size = new System.Drawing.Size(60, 13);
            this.lblToolGroup.TabIndex = 0;
            this.lblToolGroup.Text = "Tool Group";
            // 
            // tbpCMF
            // 
            this.tbpCMF.Controls.Add(this.grpCMF);
            this.tbpCMF.Location = new System.Drawing.Point(4, 22);
            this.tbpCMF.Name = "tbpCMF";
            this.tbpCMF.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCMF.Size = new System.Drawing.Size(492, 401);
            this.tbpCMF.TabIndex = 2;
            this.tbpCMF.Text = "Type Defined Field";
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.spdData);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.Location = new System.Drawing.Point(3, 0);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(486, 398);
            this.grpCMF.TabIndex = 0;
            this.grpCMF.TabStop = false;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, LotInfo, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdData.Location = new System.Drawing.Point(3, 16);
            this.spdData.MoveActiveOnFocus = false;
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Vertical;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(480, 379);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdData_CellClick);
            this.spdData.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdData_CellDoubleClick);
            this.spdData.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_ButtonClicked);
            this.spdData.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_EditChange);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 3;
            spdData_Sheet1.RowCount = 5;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Value";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 190F;
            this.spdData_Sheet1.Columns.Get(1).Label = "Value";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 240F;
            this.spdData_Sheet1.Columns.Get(2).Border = bevelBorder1;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdData_Sheet1.Columns.Get(2).CellType = buttonCellType1;
            this.spdData_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdData_Sheet1.Columns.Get(2).Width = 25F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpAttribute
            // 
            this.tbpAttribute.Controls.Add(this.udcAttributeStatus);
            this.tbpAttribute.Location = new System.Drawing.Point(4, 22);
            this.tbpAttribute.Name = "tbpAttribute";
            this.tbpAttribute.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAttribute.Size = new System.Drawing.Size(492, 401);
            this.tbpAttribute.TabIndex = 4;
            this.tbpAttribute.Text = "Attribute";
            // 
            // udcAttributeStatus
            // 
            this.udcAttributeStatus.AttributeFactory = "";
            this.udcAttributeStatus.AttributeKey = this.txtOper.Text;
            this.udcAttributeStatus.AttributeLayout = Miracom.BASCore.udcAttributeStatus.udcAttributeStatusLayout.VIEW_AND_UPDATE;
            this.udcAttributeStatus.AttributeName = "";
            this.udcAttributeStatus.AttributeType = "TOOL";
            this.udcAttributeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.udcAttributeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.udcAttributeStatus.FromSequence = 0;
            this.udcAttributeStatus.Location = new System.Drawing.Point(3, 3);
            this.udcAttributeStatus.Name = "udcAttributeStatus";
            this.udcAttributeStatus.Size = new System.Drawing.Size(486, 395);
            this.udcAttributeStatus.TabIndex = 1;
            this.udcAttributeStatus.ToSequence = 2147483647;
            // 
            // lisTool
            // 
            this.lisTool.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisTool.EnableSort = true;
            this.lisTool.EnableSortIcon = true;
            this.lisTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisTool.FullRowSelect = true;
            this.lisTool.Location = new System.Drawing.Point(3, 56);
            this.lisTool.MultiSelect = false;
            this.lisTool.Name = "lisTool";
            this.lisTool.Size = new System.Drawing.Size(229, 447);
            this.lisTool.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lisTool.TabIndex = 1;
            this.lisTool.UseCompatibleStateImageBehavior = false;
            this.lisTool.View = System.Windows.Forms.View.Details;
            this.lisTool.SelectedIndexChanged += new System.EventHandler(this.lisTool_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Tool";
            this.ColumnHeader1.Width = 80;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvTableList.Location = new System.Drawing.Point(163, 17);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "cdvTableList";
            this.cdvTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 0;
            this.cdvTableList.TabStop = false;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.Visible = false;
            this.cdvTableList.VisibleColumnHeader = false;
            this.cdvTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableList_SelectedItemChanged);
            // 
            // btnScrap
            // 
            this.btnScrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnScrap.Location = new System.Drawing.Point(466, 7);
            this.btnScrap.Name = "btnScrap";
            this.btnScrap.Size = new System.Drawing.Size(88, 26);
            this.btnScrap.TabIndex = 2;
            this.btnScrap.Text = "Scrap";
            this.btnScrap.Click += new System.EventHandler(this.btnScrap_Click);
            // 
            // btnRegenerate
            // 
            this.btnRegenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegenerate.Location = new System.Drawing.Point(558, 8);
            this.btnRegenerate.Name = "btnRegenerate";
            this.btnRegenerate.Size = new System.Drawing.Size(88, 26);
            this.btnRegenerate.TabIndex = 7;
            this.btnRegenerate.Text = "Regenerate";
            this.btnRegenerate.Visible = false;
            this.btnRegenerate.Click += new System.EventHandler(this.btnRegenerate_Click);
            // 
            // frmRASSetupTool
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupTool";
            this.Text = "Tool Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupTool_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupTool_Load);
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
            this.grpTool.ResumeLayout(false);
            this.grpTool.PerformLayout();
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            this.pnlGeneral.ResumeLayout(false);
            this.tabTool.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolGradeID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubAreaID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAreaID)).EndInit();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.tbpAttribute.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable definition "
        bool b_load_flag;
        int iRow;
        int iCol;
        string priTxt;

        public struct TypeList
        {
            public string prompt;
            public string format;
            public int size;
            public string table_name;
            public string setup_flag;
            public string event_flag;
            public string opt;
            public string crt_value;
        }
        
        public struct ToolTypeArr
        {
            public string tool_type;
            public string system_flag;
            public TypeList[] typelist;
        }
        
        ToolTypeArr ToolTypeInfo;
        
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
            int i;
            
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_Tool":

                        if (MPCF.CheckValue(cdvType, 1) == false)
                        {
                            return false;
                        }

                        if (MPCF.CheckValue(txtTool, 1) == false)
                        {
                            return false;
                        }
                        
                        if (ProcStep == MPGC.MP_STEP_CREATE || ProcStep == MPGC.MP_STEP_UPDATE)
                        {
                            //Tool Type Validation
                            for (i = 0; i < 30; i++)
                            {
                                if (MPCF.Trim(ToolTypeInfo.typelist[i].prompt) != "")
                                {
                                    if (MPCF.Trim(ToolTypeInfo.typelist[i].setup_flag) == "Y" && MPCF.Trim(ToolTypeInfo.typelist[i].opt) == "Y")
                                    {
                                        if ((MPCF.Trim(spdData.ActiveSheet.Cells[i, 1].Value) == "") || 
                                            (MPCF.Trim(spdData.ActiveSheet.Cells[i, 1].Value) == "0.00"))
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            tabTool.SelectedTab = tbpCMF;
                                            spdData.ActiveSheet.SetActiveCell(i, 1);
                                            spdData.EditModePermanent = true;
                                            spdData.EditMode = true;
                                            return false;
                                        }
                                    }
                                }
                            }
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
        // Refresh_Toollist()
        //       -  Refresh Resource List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Tool_List()
        {
            string SelectedItem;
            
            try
            {
                SelectedItem = MPCF.Trim(txtTool.Text);
                MPCF.FieldClear(this.pnlRight);
                MPCF.InitListView(lisTool);
                lblDataCount.Text = "";

                if (RASLIST.ViewToolList(lisTool, '2', cdvType.Text, (chkIncludeScrap.Checked == true ? ' ' : 'N'), false, null) == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisTool.Items.Count);
                }
                
                if (lisTool.Items.Count > 0 && SelectedItem != "")
                {
                    MPCF.FindListItem(lisTool, SelectedItem, false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return true;
            
        }
        
        //
        // View_Tool_Type()
        //       -  View Tool Type Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Tool_Type()
        {
            TRSNode in_node = new TRSNode("View_Tool_Type_In");
            TRSNode out_node = new TRSNode("View_Tool_Type_Out");
            int i;
            FarPoint.Win.Spread.Cell sheetData = null;
            FarPoint.Win.Spread.CellType.ButtonCellType sheetBtn = null;
            FarPoint.Win.Spread.CellType.TextCellType sheettxt = null;
            
            try
            {
                
                ToolTypeInfo.tool_type = "";
                
                spdData.ActiveSheet.RowCount = 30;
                spdData.ActiveSheet.ClearRange(0, 0, 30, 3, true);
                spdData.ActiveSheet.SetActiveCell(0, 0);
                spdData.ActiveSheet.Cells[0, 0, 29, 2].Font = new Font(spdData.Font, FontStyle.Regular);

                //lblDataCount.Text = "";
                //MPCF.InitListView(lisTool);
                //if (RASLIST.ViewToolList(lisTool, '2', cdvType.Text, (chkIncludeScrap.Checked == true ? ' ' : 'N'), false, null) == true)
                //{
                //    lblDataCount.Text = MPCF.Trim(lisTool.Items.Count);
                //}

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref out_node) == false)
                {
                    return false;
                }

                ToolTypeInfo.tool_type = out_node.GetString("TOOL_TYPE");
                ToolTypeInfo.system_flag = out_node.GetChar("SYSTEM_FLAG").ToString();

                
                for (i = 0; i < 30; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) == "")
                    {
                        spdData.ActiveSheet.Rows[i].Height = 0;
                        spdData.ActiveSheet.Cells[i, 1].Value = "";
                        spdData.ActiveSheet.Cells[i, 1].Locked = true;
                        spdData.ActiveSheet.Cells[i, 2].Locked = true;
                    }
                    else
                    {
                        spdData.ActiveSheet.Rows[i].Height = 20;
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SETUP_FLAG")) == "Y")
                        {
                            spdData.ActiveSheet.Cells[i, 1].Locked = false;
                            spdData.ActiveSheet.Cells.Get(i, 1).BackColor = Color.White;

                            if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OPT")) == "Y")
                            {
                                spdData.ActiveSheet.Cells[i, 0].Font = new Font(spdData.Font, FontStyle.Bold);
                            }
                            else
                            {
                                spdData.ActiveSheet.Cells[i, 0].Font = new Font(spdData.Font, FontStyle.Regular);
                            }
                        }
                        else
                        {
                            spdData.ActiveSheet.Cells[i, 1].Locked = true;
                            spdData.ActiveSheet.Cells.Get(i, 1).BackColor = Color.WhiteSmoke;
                        }

                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")) != "" && MPCF.Trim(out_node.GetList(0)[i].GetChar("SETUP_FLAG")) == "Y")
                        {
                            //sheetData = New FarPoint.Win.Spread.Cell
                            sheetData = spdData.ActiveSheet.Cells[i, 1];
                            sheetData.ColumnSpan = 1;
                            
                            sheetBtn = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            sheetBtn.Text = "...";
                            spdData.ActiveSheet.Cells[i, 2].CellType = sheetBtn;

                            spdData.ActiveSheet.Cells[i, 1].Locked = true;
                            spdData.ActiveSheet.Cells[i, 2].Locked = false;
                            
                        }
                        else
                        {
                            //sheetData = New FarPoint.Win.Spread.Cell
                            sheetData = spdData.ActiveSheet.Cells[i, 1];
                            sheetData.ColumnSpan = 2;
                            
                            spdData.ActiveSheet.Cells[i, 2].Locked = true;
                        }
                        
                        sheettxt = new FarPoint.Win.Spread.CellType.TextCellType();
                        sheettxt.MaxLength = out_node.GetList(0)[i].GetInt("SIZE");
                        spdData.ActiveSheet.Cells[i, 1].CellType = sheettxt;
                        spdData.ActiveSheet.Cells[i, 1].Value = "";
                        spdData.ActiveSheet.Cells[i, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT"));
                        spdData.ActiveSheet.Cells[i, 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("CRT_VALUE"));
                    }
                    
                    ToolTypeInfo.typelist[i].prompt = out_node.GetList(0)[i].GetString("PROMPT");
                    ToolTypeInfo.typelist[i].format = out_node.GetList(0)[i].GetChar("FORMAT").ToString();
                    ToolTypeInfo.typelist[i].size = out_node.GetList(0)[i].GetInt("SIZE");
                    ToolTypeInfo.typelist[i].table_name = out_node.GetList(0)[i].GetString("TABLE_NAME");
                    ToolTypeInfo.typelist[i].setup_flag = out_node.GetList(0)[i].GetChar("SETUP_FLAG").ToString();
                    ToolTypeInfo.typelist[i].event_flag = out_node.GetList(0)[i].GetChar("EVENT_FLAG").ToString();
                    ToolTypeInfo.typelist[i].opt = out_node.GetList(0)[i].GetChar("OPT").ToString();
                    ToolTypeInfo.typelist[i].crt_value = out_node.GetList(0)[i].GetString("CRT_VALUE");
                }

                spdData.Visible = true;

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //
        // View_Resource()
        //       -  View Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Tool()
        {
            TRSNode in_node = new TRSNode("View_Sub_Resource_In");
            TRSNode out_node = new TRSNode("View_Sub_Resource_Out");
            int i;
            
            try
            {
                MPCF.FieldClear(this.pnlRight);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));
                in_node.AddString("TOOL_ID", lisTool.SelectedItems[0].Text);

                if (MPCR.CallService("RAS", "RAS_View_Tool", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtTool.Text = out_node.GetString("TOOL_ID");
                txtDesc.Text = out_node.GetString("TOOL_DESC");

                cdvToolGroup.Text = out_node.GetString("TOOL_GRP");
                txtToolSetID.Text = out_node.GetString("TOOL_SET_ID");
                txtToolSetLoc.Text = out_node.GetString("TOOL_SET_LOCATION");
                txtToolStatus.Text = out_node.GetString("TOOL_STATUS");
                txtLotID.Text = out_node.GetString("LOT_ID");
                txtSubLotID.Text = out_node.GetString("SUBLOT_ID");
                txtResID.Text = out_node.GetString("RES_ID");
                txtSubResID.Text = out_node.GetString("SUBRES_ID");
                cdvMaterial.Text = out_node.GetString("MAT_ID");
                cdvMaterial.Version = out_node.GetInt("MAT_VER");
                txtFlow.Text = out_node.GetString("FLOW");
                txtOper.Text = out_node.GetString("OPER");
                txtDeleteFlag.Text = out_node.GetChar("DELETE_FLAG").ToString();
                cdvAreaID.Text = out_node.GetString("AREA_ID");
                cdvSubAreaID.Text = out_node.GetString("SUB_AREA_ID");
                txtToolLoc.Text = out_node.GetString("TOOL_LOCATION");
                txtVender.Text = out_node.GetString("VENDOR_ID");
                txtVenderToolID.Text = out_node.GetString("VENDOR_TOOL_ID");
                txtCellCountX.Text = out_node.GetInt("CELL_COUNT_X").ToString();
                txtCellCountY.Text = out_node.GetInt("CELL_COUNT_Y").ToString();
                txtCellCountZ.Text = out_node.GetInt("CELL_COUNT_Z").ToString();
                txtCellSizeX.Text = out_node.GetInt("CELL_SIZE_X").ToString();
                txtCellSizeY.Text = out_node.GetInt("CELL_SIZE_Y").ToString();
                txtCellSizeZ.Text = out_node.GetInt("CELL_SIZE_Z").ToString();
                cdvToolGradeID.Text = out_node.GetChar("GRADE").ToString();
                txtToolComment.Text = out_node.GetString("TOOL_COMMENT");

                
                if (out_node.GetChar("DELETE_FLAG") == 'R')
                {
                    btnRegenerate.Visible = true;
                    btnDelete.Visible = false;
                }
                else
                {
                    btnRegenerate.Visible = false;
                    btnDelete.Visible = true;
                }

                if (MPCF.Trim(cdvType.Text) != MPCF.Trim(ToolTypeInfo.tool_type))
                {
                    if (View_Tool_Type() == false)
                    {
                        return false;
                    }
                }
                
                for (i = 0; i < 30; i++)
                {
                    if (MPCF.Trim(ToolTypeInfo.typelist[i].prompt) != "")
                    {
                        spdData.ActiveSheet.Cells[i, 1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_STS"));
                    }
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
        // Update_Tool()
        //       -  Update Resource
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //        - ByVal c_step As String     : ?뺤옣 Process Step
        //
        private bool Update_Tool(char c_step)
        {
            TRSNode in_node = new TRSNode("Update_Tool_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode list;
            ListViewItem item;
            int i;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));
                in_node.AddString("TOOL_ID", MPCF.Trim(txtTool.Text));
                in_node.AddString("TOOL_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddString("TOOL_GRP", MPCF.Trim(cdvToolGroup.Text));
                in_node.AddString("TOOL_SET_ID", MPCF.Trim(txtToolSetID.Text));
                in_node.AddString("TOOL_SET_LOCATION", MPCF.Trim(txtToolSetLoc.Text));
                in_node.AddString("AREA_ID", MPCF.Trim(cdvAreaID.Text));
                in_node.AddString("SUB_AREA_ID", MPCF.Trim(cdvSubAreaID.Text));
                in_node.AddString("TOOL_LOCATION", MPCF.Trim(txtToolLoc.Text));
                in_node.AddString("VENDOR_ID", MPCF.Trim(txtVender.Text));
                in_node.AddString("VENDOR_TOOL_ID", MPCF.Trim(txtVenderToolID.Text));

                
                if (MPCF.CheckNumeric(txtCellCountX.Text) == true)
                {
                    in_node.AddInt("CELL_COUNT_X", MPCF.ToInt(txtCellCountX.Text));

                }
                else
                {
                    in_node.AddInt("CELL_COUNT_X", 0);

                }
                
                if (MPCF.CheckNumeric(txtCellCountY.Text) == true)
                {
                    in_node.AddInt("CELL_COUNT_Y", MPCF.ToInt(txtCellCountY.Text));

                }
                else
                {
                    in_node.AddInt("CELL_COUNT_Y", 0);
                }
                
                if (MPCF.CheckNumeric(txtCellCountZ.Text) == true)
                {
                    in_node.AddInt("CELL_COUNT_Z", MPCF.ToInt(txtCellCountZ.Text));

                }
                else
                {
                    in_node.AddInt("CELL_COUNT_Z", 0);
                }
                
                if (MPCF.CheckNumeric(txtCellSizeX.Text) == true)
                {
                    in_node.AddInt("CELL_SIZE_X", MPCF.ToInt(txtCellSizeX.Text));

                }
                else
                {
                    in_node.AddInt("CELL_SIZE_X", 0);
                }
                
                if (MPCF.CheckNumeric(txtCellSizeY.Text) == true)
                {
                    in_node.AddInt("CELL_SIZE_Y", MPCF.ToInt(txtCellSizeY.Text));

                }
                else
                {
                    in_node.AddInt("CELL_SIZE_Y", 0);

                }                
                if (MPCF.CheckNumeric(txtCellSizeZ.Text) == true)
                {
                    in_node.AddInt("CELL_SIZE_Z", MPCF.ToInt(txtCellSizeZ.Text));
                }
                else
                {
                    in_node.AddInt("CELL_SIZE_Z", 0);

                }
                
                in_node.AddChar("GRADE", MPCF.ToChar(MPCF.Trim(cdvToolGradeID.Text)));
                in_node.AddString("TOOL_COMMENT", MPCF.Trim(txtToolComment.Text));

                
                for (i = 0; i < 30; i++)
                {
                    list = in_node.AddNode("STS_LIST");
                    list.AddString("TOOL_STS", MPCF.Trim(spdData.ActiveSheet.Cells[i, 1].Value));
                }
                
                if (MPCR.CallService("RAS", "RAS_Update_Tool", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (c_step == MPGC.MP_STEP_CREATE)
                    {
                        item = lisTool.Items.Add(txtTool.Text, (int)SMALLICON_INDEX.IDX_TOOL);
                        item.SubItems.Add(txtDesc.Text);
                        item.Selected = true;
                        lisTool.Sorting = SortOrder.Ascending;
                        lisTool.Sort();
                        item.EnsureVisible();
                    }
                    else if (c_step == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisTool, MPCF.Trim(txtTool.Text), false) == true)
                        {
                            lisTool.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_SCRAP)
                    {
                        if (MPCF.FindListItem(lisTool, MPCF.Trim(txtTool.Text), false) == true)
                        {
                            lisTool.SelectedItems[0].Remove();
                            MPCF.FieldClear(pnlRight);
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_RETURN)
                    {
                        if (MPCF.FindListItem(lisTool, MPCF.Trim(txtTool.Text), false) == true)
                        {
                            lisTool.SelectedItems[0].ImageIndex =  (int)SMALLICON_INDEX.IDX_TOOL_RETURN;
                        }
                    }
                    else if (c_step == MPGC.MP_STEP_REGENERATE)
                    {
                        if (MPCF.FindListItem(lisTool, MPCF.Trim(txtTool.Text), false) == true)
                        {
                            lisTool.SelectedItems[0].ImageIndex =  (int)SMALLICON_INDEX.IDX_TOOL;
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisTool.Items.Count);
                }
                MPCR.ShowSuccessMsg(out_node);
                
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
        
        private void frmRASSetupTool_Load(object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this);
            MPCF.InitListView(lisTool);
            spdData.Visible = false;
            ToolTypeInfo.typelist = new TypeList[31];
        }
        
        private void frmRASSetupTool_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (b_load_flag == false)
                {
                    lblDataCount.Text = "";
                    if (lisTool.Items.Count > 0)
                    {
                        lisTool.Items[0].Selected = true;
                    }
                    
                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvType_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            cdvType.Init();
            MPCF.InitListView(cdvType.GetListView);
            cdvType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvType.SelectedSubItemIndex = 0;
            
            RASLIST.ViewToolTypeList(cdvType.GetListView, '1', 'N', 'N', null);
            
        }
        
        private void cdvType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                MPCF.FieldClear(this.pnlRight);

                lblDataCount.Text = "";
                MPCF.InitListView(lisTool);

                if (View_Tool_Type() == true)
                {
                    View_Tool_List();
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
                if (CheckCondition("Update_Tool", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Tool(MPGC.MP_STEP_CREATE) == false)
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
                if (btnUpdate.Text == MPCF.FindLanguage("Update", 1))
                {
                    if (CheckCondition("Update_Tool", MPGC.MP_STEP_UPDATE) == true)
                    {
                        if (Update_Tool(MPGC.MP_STEP_UPDATE) == false)
                        {
                            return;
                        }
                        
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            btnRefresh.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnScrap_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 1) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Tool", MPGC.MP_STEP_SCRAP) == true)
                {
                    if (Update_Tool(MPGC.MP_STEP_SCRAP) == true)
                    {
                        if (chkIncludeScrap.Checked)
                        {
                            MPCF.FieldClear(this.pnlRight, txtTool);
                        }
                        else
                        {
                            MPCF.FieldClear(this.pnlRight);
                        }
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            btnRefresh.PerformClick();
                        }
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
                if (MPCF.ShowMsgBox(MPCF.GetMessage(275), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Tool", MPGC.MP_STEP_RETURN) == true)
                {
                    if (Update_Tool(MPGC.MP_STEP_RETURN) == true)
                    {
                        if (chkIncludeScrap.Checked)
                        {
                            MPCF.FieldClear(this.pnlRight, txtTool);
                        }
                        else
                        {
                            MPCF.FieldClear(this.pnlRight);
                        }
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            btnRefresh.PerformClick();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnRegenerate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Tool", MPGC.MP_STEP_REGENERATE) == true)
                {
                    if (Update_Tool(MPGC.MP_STEP_REGENERATE) == true)
                    {
                        if (MPGV.gbListAutoRefresh == true)
                        {
                            btnRefresh.PerformClick();
                        }
                        else
                        {
                            MPCF.FieldClear(this.pnlRight);
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

            MPCF.ExportToExcel(lisTool, this.Text, "");
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (View_Tool_List() == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvAreaID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvAreaID.Init();
            MPCF.InitListView(cdvAreaID.GetListView);
            cdvAreaID.Columns.Add("AreaID", 50, HorizontalAlignment.Left);
            cdvAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvAreaID.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAreaID.GetListView, '1', MPGC.MP_RAS_AREA_CODE);
        }
        
        private void cdvSubAreaID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            //Modify by J.S. 2008.12.23 만약 area가 먼저 선택된경우 종속된 subarea만 보이게 한다.
            if (MPCF.RTrim(cdvAreaID.Text) == "")
            {
                cdvSubAreaID.Init();
                MPCF.InitListView(cdvSubAreaID.GetListView);
                cdvSubAreaID.Columns.Add("SubAreaID", 50, HorizontalAlignment.Left);
                cdvSubAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSubAreaID.SelectedSubItemIndex = 0;

                BASLIST.ViewGCMDataList(cdvSubAreaID.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE);
            }
            else
            {
                cdvSubAreaID.Init();
                MPCF.InitListView(cdvSubAreaID.GetListView);
                cdvSubAreaID.Columns.Add("SubAreaID", 50, HorizontalAlignment.Left);
                cdvSubAreaID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSubAreaID.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList_AREA(cdvSubAreaID.GetListView, '1', MPGC.MP_RAS_SUBAREA_CODE, -1, null, "", false, -1, -1, null, cdvAreaID.Text) == false)
                {
                    return;
                }
            }
            
        }
        
        private void cdvToolGroup_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvToolGroup.Init();
            MPCF.InitListView(cdvToolGroup.GetListView);
            cdvToolGroup.Columns.Add("Tool Group ID", 50, HorizontalAlignment.Left);
            cdvToolGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolGroup.SelectedSubItemIndex = 0;
            
            BASLIST.ViewGCMDataList(cdvToolGroup.GetListView, '1', MPGC.MP_RAS_TOOL_GRP);
            
        }
        
        private void cdvToolGradeID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvToolGradeID.Init();
            MPCF.InitListView(cdvToolGradeID.GetListView);
            cdvToolGradeID.Columns.Add("Grade ID", 50, HorizontalAlignment.Left);
            cdvToolGradeID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolGradeID.SelectedSubItemIndex = 0;
            
            BASLIST.ViewGCMDataList(cdvToolGradeID.GetListView, '1', MPGC.MP_RAS_TOOL_GRADE);
            
        }
        
        private void lisTool_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (lisTool.SelectedItems.Count > 0)
            {
                MPCF.FieldClear(this.pnlRight);
                spdData.ActiveSheet.ClearRange(0, 1, 30, 3, true);
                spdData.ActiveSheet.SetActiveCell(0, 0);

                txtTool.Text = lisTool.SelectedItems[0].Text;
                View_Tool();

                udcAttributeStatus.AttributeKey = txtTool.Text;
                udcAttributeStatus.View();
            }
        }
        
        private void cdvTableList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdData.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
        }
        
        private void spdData_ButtonClicked(System.Object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            
            if (e.Column != 2)
            {
                return;
            }

            if (MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, 0].Value) != "")
            {
                if (MPCF.Trim(ToolTypeInfo.typelist[e.Row].table_name) != "")
                {
                    cdvTableList.Init();
                    cdvTableList.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvTableList.GetListView);
                    cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                    cdvTableList.Columns.Add("Table Desc", 100, HorizontalAlignment.Left);
                    BASLIST.ViewGCMDataList(cdvTableList.GetListView, '1', ToolTypeInfo.typelist[e.Row].table_name);
                    cdvTableList.InsertEmptyRow(0, 1);
                }
            }
            if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
            {
                return;
            }
            
        }
        
        private void txtCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                {
                    e.Handled = true;
                }
            }
        }
        
        private void spdData_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            iRow = e.Row;
            iCol = e.Column;
            priTxt = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, iCol].Value);
        }
        
        private void spdData_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            iRow = e.Row;
            iCol = e.Column;
            priTxt = MPCF.Trim(spdData.ActiveSheet.Cells[iRow, iCol].Value);
        }
        
        private void spdData_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            
            int i;
            string editTxt;
            
            try
            {
                for (i = 0; i < 30; i++)
                {
                    editTxt = "";
                    if (ToolTypeInfo.typelist[i].prompt == MPCF.Trim(spdData.ActiveSheet.Cells[iRow, 0].Value))
                    {
                        if (MPCF.Trim(ToolTypeInfo.typelist[i].format) != "A")
                        {
                            editTxt = MPCF.Trim(e.EditingControl.Text);
                            if (editTxt != "")
                            {
                                if (MPCF.CheckNumeric(editTxt) == false)
                                {
                                    spdData.ActiveSheet.Cells[iRow, iCol].Value = priTxt;
                                    break;
                                }
                                if (ToolTypeInfo.typelist[i].format != "F")
                                {
                                    if (editTxt.IndexOf(".") >= 0)
                                    {
                                        spdData.ActiveSheet.Cells[iRow, iCol].Value = priTxt;
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
                return;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisTool, txtFind.Text, true, false);
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisTool, txtFind.Text, 0, true, false);
        }
        
        private void txtTool_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (tabTool.SelectedTab == tbpAttribute)
            {
                udcAttributeStatus.ClearValue();
            }

            if (MPCF.CheckValue(cdvType, 1) == false)
            {
                e.Handled = true;
                return;
            }

            if (lisTool.SelectedItems.Count > 0)
            {
                MPCF.FieldClear(pnlRight, txtTool);
                View_Tool_Type();
                lisTool.SelectedItems.Clear();
            }
        }

        private void chkIncludeScrap_CheckedChanged(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }
    }

    //#End If
}
