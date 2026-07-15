
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
//   File Name   : frmRASViewTool.vb
//   Description : View Resource Status Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  View_Tool_Type()              : View Tool Type information
//       -  View_Tool()              : View Tool information
//       -  SetGroupCmfItem()        : Set Group / Cmf Property to control
//       -  InitControl()            : Initial Group/Cmf Control
//       -  SetCmfItem()             : Set Cmf Property to control
//       -  SetGRPItem()             : Set Group  Property to control
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by Jerome
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _TOOL = True Then

namespace Miracom.RASCore
{
    public class frmRASViewTool : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewTool()
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
        



        private System.Windows.Forms.Panel pnlGrp;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.ContextMenu ctxCopyMenu;
        private System.Windows.Forms.MenuItem ctxCopy;
        private System.Windows.Forms.GroupBox grpTool;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolID;
        private System.Windows.Forms.Label lblToolID;
        private System.Windows.Forms.Label lblToolType;
        private System.Windows.Forms.TabControl tabTool;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.TextBox txtDeleteFlag;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.TextBox txtFlow;
        private System.Windows.Forms.TextBox txtSubResID;
        private System.Windows.Forms.TextBox txtResID;
        private System.Windows.Forms.TextBox txtSubLotID;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.TextBox txtToolStatus;
        private System.Windows.Forms.Label lblCellSizeX;
        private System.Windows.Forms.Label lblCellCountX;
        private System.Windows.Forms.Label lblDeleteFlag;
        private System.Windows.Forms.TextBox txtCellSizeZ;
        private System.Windows.Forms.Label lblCellSizeZ;
        private System.Windows.Forms.TextBox txtCellSizeY;
        private System.Windows.Forms.Label lblCellSizeY;
        private System.Windows.Forms.TextBox txtCellSizeX;
        private System.Windows.Forms.TextBox txtCellCountZ;
        private System.Windows.Forms.Label lblCellCountZ;
        private System.Windows.Forms.TextBox txtCellCountY;
        private System.Windows.Forms.Label lblCellCountY;
        private System.Windows.Forms.TextBox txtCellCountX;
        private System.Windows.Forms.TextBox txtVenderToolID;
        private System.Windows.Forms.Label lblVenderToolID;
        private System.Windows.Forms.TextBox txtVender;
        private System.Windows.Forms.Label lblVender;
        private System.Windows.Forms.Label lblOper;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.Label lblSubResID;
        private System.Windows.Forms.TextBox txtToolLoc;
        private System.Windows.Forms.TextBox txtToolSetLoc;
        private System.Windows.Forms.TextBox txtToolSetID;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblToolLoc;
        private System.Windows.Forms.Label lblSubAreaID;
        private System.Windows.Forms.Label lblToolSetLoc;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblSubLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Label lblToolStatus;
        private System.Windows.Forms.Label lblToolSetID;
        private System.Windows.Forms.Label lblAreaID;
        private System.Windows.Forms.Label lblToolGroup;
        private System.Windows.Forms.TabPage tbpCMF;
        private System.Windows.Forms.GroupBox grpCMF;
        protected FarPoint.Win.Spread.FpSpread spdData;
        protected FarPoint.Win.Spread.SheetView spdData_LotInfo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvType;
        private System.Windows.Forms.TextBox txtToolGroup;
        private System.Windows.Forms.TextBox txtAreaID;
        private System.Windows.Forms.TextBox txtSubAreaID;
        private System.Windows.Forms.TextBox txtToolGradeID;
        private System.Windows.Forms.TextBox txtToolComment;
        private System.Windows.Forms.Label lblToolComment;
        private System.Windows.Forms.TextBox txtLastActiveHistSeq;
        private System.Windows.Forms.TextBox txtLastHistSeq;
        private System.Windows.Forms.Label lblUpdateTime;
        private System.Windows.Forms.Label lblCreateUserID;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtUpdateUserID;
        private System.Windows.Forms.Label lblUpdateUserID;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblCreateTime;
        private System.Windows.Forms.TextBox txtCreateUserID;
        private System.Windows.Forms.TextBox txtLastTranTime;
        private System.Windows.Forms.Label lblLastTranTime;
        private System.Windows.Forms.TextBox txtLastToolEventID;
        private System.Windows.Forms.Label lblLastToolEventID;
        private System.Windows.Forms.Label lblLastActiveHistSeq;
        private System.Windows.Forms.Label lblLastHistSeq;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Button btnHistory;
        private System.Windows.Forms.TextBox txtDesc;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.grpTool = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cdvType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToolType = new System.Windows.Forms.Label();
            this.cdvToolID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblToolID = new System.Windows.Forms.Label();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabTool = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.txtLastActiveHistSeq = new System.Windows.Forms.TextBox();
            this.txtLastHistSeq = new System.Windows.Forms.TextBox();
            this.lblUpdateTime = new System.Windows.Forms.Label();
            this.lblCreateUserID = new System.Windows.Forms.Label();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUserID = new System.Windows.Forms.TextBox();
            this.lblUpdateUserID = new System.Windows.Forms.Label();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblCreateTime = new System.Windows.Forms.Label();
            this.txtCreateUserID = new System.Windows.Forms.TextBox();
            this.txtLastTranTime = new System.Windows.Forms.TextBox();
            this.lblLastTranTime = new System.Windows.Forms.Label();
            this.txtLastToolEventID = new System.Windows.Forms.TextBox();
            this.lblLastToolEventID = new System.Windows.Forms.Label();
            this.lblLastActiveHistSeq = new System.Windows.Forms.Label();
            this.lblLastHistSeq = new System.Windows.Forms.Label();
            this.txtToolComment = new System.Windows.Forms.TextBox();
            this.lblToolComment = new System.Windows.Forms.Label();
            this.txtToolGradeID = new System.Windows.Forms.TextBox();
            this.txtSubAreaID = new System.Windows.Forms.TextBox();
            this.txtAreaID = new System.Windows.Forms.TextBox();
            this.txtToolGroup = new System.Windows.Forms.TextBox();
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
            this.lblSubAreaID = new System.Windows.Forms.Label();
            this.lblToolSetLoc = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblSubLotID = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.lblToolStatus = new System.Windows.Forms.Label();
            this.lblToolSetID = new System.Windows.Forms.Label();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.lblToolGroup = new System.Windows.Forms.Label();
            this.tbpCMF = new System.Windows.Forms.TabPage();
            this.grpCMF = new System.Windows.Forms.GroupBox();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_LotInfo = new FarPoint.Win.Spread.SheetView();
            this.ctxCopyMenu = new System.Windows.Forms.ContextMenu();
            this.ctxCopy = new System.Windows.Forms.MenuItem();
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrp.SuspendLayout();
            this.grpTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).BeginInit();
            this.pnlTab.SuspendLayout();
            this.tabTool.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.tbpCMF.SuspendLayout();
            this.grpCMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_LotInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(461, 7);
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnHistory);
            this.pnlBottom.TabIndex = 2;
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnHistory, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 546);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Tool";
            // 
            // pnlGrp
            // 
            this.pnlGrp.Controls.Add(this.grpTool);
            this.pnlGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrp.Location = new System.Drawing.Point(0, 0);
            this.pnlGrp.Name = "pnlGrp";
            this.pnlGrp.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlGrp.Size = new System.Drawing.Size(742, 92);
            this.pnlGrp.TabIndex = 0;
            // 
            // grpTool
            // 
            this.grpTool.Controls.Add(this.txtDesc);
            this.grpTool.Controls.Add(this.cdvType);
            this.grpTool.Controls.Add(this.lblToolType);
            this.grpTool.Controls.Add(this.cdvToolID);
            this.grpTool.Controls.Add(this.lblDesc);
            this.grpTool.Controls.Add(this.lblToolID);
            this.grpTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTool.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTool.Location = new System.Drawing.Point(3, 0);
            this.grpTool.Name = "grpTool";
            this.grpTool.Size = new System.Drawing.Size(736, 92);
            this.grpTool.TabIndex = 0;
            this.grpTool.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 64);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(611, 20);
            this.txtDesc.TabIndex = 5;
            this.txtDesc.TabStop = false;
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
            this.cdvType.Location = new System.Drawing.Point(120, 16);
            this.cdvType.MaxLength = 20;
            this.cdvType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvType.Name = "cdvType";
            this.cdvType.ReadOnly = false;
            this.cdvType.SearchSubItemIndex = 0;
            this.cdvType.SelectedDescIndex = -1;
            this.cdvType.SelectedSubItemIndex = -1;
            this.cdvType.SelectionStart = 0;
            this.cdvType.Size = new System.Drawing.Size(200, 20);
            this.cdvType.SmallImageList = null;
            this.cdvType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvType.TabIndex = 1;
            this.cdvType.TextBoxToolTipText = "";
            this.cdvType.TextBoxWidth = 200;
            this.cdvType.VisibleButton = true;
            this.cdvType.VisibleColumnHeader = false;
            this.cdvType.VisibleDescription = false;
            this.cdvType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvType_SelectedItemChanged);
            this.cdvType.ButtonPress += new System.EventHandler(this.cdvType_ButtonPress);
            this.cdvType.TextBoxTextChanged += new System.EventHandler(this.cdvType_TextBoxTextChanged);
            // 
            // lblToolType
            // 
            this.lblToolType.AutoSize = true;
            this.lblToolType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolType.Location = new System.Drawing.Point(15, 19);
            this.lblToolType.Name = "lblToolType";
            this.lblToolType.Size = new System.Drawing.Size(64, 13);
            this.lblToolType.TabIndex = 0;
            this.lblToolType.Text = "Tool Type";
            // 
            // cdvToolID
            // 
            this.cdvToolID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolID.BtnToolTipText = "";
            this.cdvToolID.DescText = "";
            this.cdvToolID.DisplaySubItemIndex = -1;
            this.cdvToolID.DisplayText = "";
            this.cdvToolID.Focusing = null;
            this.cdvToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolID.Index = 0;
            this.cdvToolID.IsViewBtnImage = false;
            this.cdvToolID.Location = new System.Drawing.Point(120, 40);
            this.cdvToolID.MaxLength = 30;
            this.cdvToolID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.Name = "cdvToolID";
            this.cdvToolID.ReadOnly = false;
            this.cdvToolID.SearchSubItemIndex = 0;
            this.cdvToolID.SelectedDescIndex = -1;
            this.cdvToolID.SelectedSubItemIndex = -1;
            this.cdvToolID.SelectionStart = 0;
            this.cdvToolID.Size = new System.Drawing.Size(200, 20);
            this.cdvToolID.SmallImageList = null;
            this.cdvToolID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolID.TabIndex = 3;
            this.cdvToolID.TextBoxToolTipText = "";
            this.cdvToolID.TextBoxWidth = 200;
            this.cdvToolID.VisibleButton = true;
            this.cdvToolID.VisibleColumnHeader = false;
            this.cdvToolID.VisibleDescription = false;
            this.cdvToolID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToolID_SelectedItemChanged);
            this.cdvToolID.ButtonPress += new System.EventHandler(this.cdvToolID_ButtonPress);
            this.cdvToolID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvToolID_TextBoxKeyPress);
            this.cdvToolID.TextBoxTextChanged += new System.EventHandler(this.cdvToolID_TextBoxTextChanged);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 67);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // lblToolID
            // 
            this.lblToolID.AutoSize = true;
            this.lblToolID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolID.Location = new System.Drawing.Point(15, 43);
            this.lblToolID.Name = "lblToolID";
            this.lblToolID.Size = new System.Drawing.Size(32, 13);
            this.lblToolID.TabIndex = 2;
            this.lblToolID.Text = "Tool";
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabTool);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(0, 92);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnlTab.Size = new System.Drawing.Size(742, 414);
            this.pnlTab.TabIndex = 1;
            // 
            // tabTool
            // 
            this.tabTool.Controls.Add(this.tbpGeneral);
            this.tabTool.Controls.Add(this.tbpCMF);
            this.tabTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTool.ItemSize = new System.Drawing.Size(60, 18);
            this.tabTool.Location = new System.Drawing.Point(3, 5);
            this.tabTool.Name = "tabTool";
            this.tabTool.SelectedIndex = 0;
            this.tabTool.Size = new System.Drawing.Size(736, 406);
            this.tabTool.TabIndex = 0;
            this.tabTool.TabStop = false;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.grpGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(728, 380);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.cdvMaterial);
            this.grpGeneral.Controls.Add(this.txtLastActiveHistSeq);
            this.grpGeneral.Controls.Add(this.txtLastHistSeq);
            this.grpGeneral.Controls.Add(this.lblUpdateTime);
            this.grpGeneral.Controls.Add(this.lblCreateUserID);
            this.grpGeneral.Controls.Add(this.txtUpdateTime);
            this.grpGeneral.Controls.Add(this.txtUpdateUserID);
            this.grpGeneral.Controls.Add(this.lblUpdateUserID);
            this.grpGeneral.Controls.Add(this.txtCreateTime);
            this.grpGeneral.Controls.Add(this.lblCreateTime);
            this.grpGeneral.Controls.Add(this.txtCreateUserID);
            this.grpGeneral.Controls.Add(this.txtLastTranTime);
            this.grpGeneral.Controls.Add(this.lblLastTranTime);
            this.grpGeneral.Controls.Add(this.txtLastToolEventID);
            this.grpGeneral.Controls.Add(this.lblLastToolEventID);
            this.grpGeneral.Controls.Add(this.lblLastActiveHistSeq);
            this.grpGeneral.Controls.Add(this.lblLastHistSeq);
            this.grpGeneral.Controls.Add(this.txtToolComment);
            this.grpGeneral.Controls.Add(this.lblToolComment);
            this.grpGeneral.Controls.Add(this.txtToolGradeID);
            this.grpGeneral.Controls.Add(this.txtSubAreaID);
            this.grpGeneral.Controls.Add(this.txtAreaID);
            this.grpGeneral.Controls.Add(this.txtToolGroup);
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
            this.grpGeneral.Controls.Add(this.lblSubAreaID);
            this.grpGeneral.Controls.Add(this.lblToolSetLoc);
            this.grpGeneral.Controls.Add(this.lblResID);
            this.grpGeneral.Controls.Add(this.lblSubLotID);
            this.grpGeneral.Controls.Add(this.lblLotID);
            this.grpGeneral.Controls.Add(this.lblToolStatus);
            this.grpGeneral.Controls.Add(this.lblToolSetID);
            this.grpGeneral.Controls.Add(this.lblAreaID);
            this.grpGeneral.Controls.Add(this.lblToolGroup);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGeneral.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpGeneral.Location = new System.Drawing.Point(3, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(722, 377);
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
            this.cdvMaterial.Location = new System.Drawing.Point(12, 207);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = true;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(224, 20);
            this.cdvMaterial.TabIndex = 16;
            this.cdvMaterial.TabStop = false;
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
            // txtLastActiveHistSeq
            // 
            this.txtLastActiveHistSeq.Location = new System.Drawing.Point(598, 40);
            this.txtLastActiveHistSeq.MaxLength = 10;
            this.txtLastActiveHistSeq.Name = "txtLastActiveHistSeq";
            this.txtLastActiveHistSeq.ReadOnly = true;
            this.txtLastActiveHistSeq.Size = new System.Drawing.Size(116, 20);
            this.txtLastActiveHistSeq.TabIndex = 50;
            this.txtLastActiveHistSeq.TabStop = false;
            // 
            // txtLastHistSeq
            // 
            this.txtLastHistSeq.Location = new System.Drawing.Point(598, 16);
            this.txtLastHistSeq.MaxLength = 10;
            this.txtLastHistSeq.Name = "txtLastHistSeq";
            this.txtLastHistSeq.ReadOnly = true;
            this.txtLastHistSeq.Size = new System.Drawing.Size(116, 20);
            this.txtLastHistSeq.TabIndex = 48;
            this.txtLastHistSeq.TabStop = false;
            // 
            // lblUpdateTime
            // 
            this.lblUpdateTime.AutoSize = true;
            this.lblUpdateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateTime.Location = new System.Drawing.Point(490, 211);
            this.lblUpdateTime.Name = "lblUpdateTime";
            this.lblUpdateTime.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateTime.TabIndex = 61;
            this.lblUpdateTime.Text = "Update Time";
            // 
            // lblCreateUserID
            // 
            this.lblCreateUserID.AutoSize = true;
            this.lblCreateUserID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateUserID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUserID.Location = new System.Drawing.Point(490, 139);
            this.lblCreateUserID.Name = "lblCreateUserID";
            this.lblCreateUserID.Size = new System.Drawing.Size(63, 13);
            this.lblCreateUserID.TabIndex = 55;
            this.lblCreateUserID.Text = "Create User";
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(598, 208);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(116, 20);
            this.txtUpdateTime.TabIndex = 62;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtUpdateUserID
            // 
            this.txtUpdateUserID.Location = new System.Drawing.Point(598, 184);
            this.txtUpdateUserID.MaxLength = 20;
            this.txtUpdateUserID.Name = "txtUpdateUserID";
            this.txtUpdateUserID.ReadOnly = true;
            this.txtUpdateUserID.Size = new System.Drawing.Size(116, 20);
            this.txtUpdateUserID.TabIndex = 60;
            this.txtUpdateUserID.TabStop = false;
            // 
            // lblUpdateUserID
            // 
            this.lblUpdateUserID.AutoSize = true;
            this.lblUpdateUserID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateUserID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUserID.Location = new System.Drawing.Point(490, 187);
            this.lblUpdateUserID.Name = "lblUpdateUserID";
            this.lblUpdateUserID.Size = new System.Drawing.Size(67, 13);
            this.lblUpdateUserID.TabIndex = 59;
            this.lblUpdateUserID.Text = "Update User";
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(598, 160);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(116, 20);
            this.txtCreateTime.TabIndex = 58;
            this.txtCreateTime.TabStop = false;
            // 
            // lblCreateTime
            // 
            this.lblCreateTime.AutoSize = true;
            this.lblCreateTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateTime.Location = new System.Drawing.Point(490, 163);
            this.lblCreateTime.Name = "lblCreateTime";
            this.lblCreateTime.Size = new System.Drawing.Size(64, 13);
            this.lblCreateTime.TabIndex = 57;
            this.lblCreateTime.Text = "Create Time";
            // 
            // txtCreateUserID
            // 
            this.txtCreateUserID.Location = new System.Drawing.Point(598, 136);
            this.txtCreateUserID.MaxLength = 20;
            this.txtCreateUserID.Name = "txtCreateUserID";
            this.txtCreateUserID.ReadOnly = true;
            this.txtCreateUserID.Size = new System.Drawing.Size(116, 20);
            this.txtCreateUserID.TabIndex = 56;
            this.txtCreateUserID.TabStop = false;
            // 
            // txtLastTranTime
            // 
            this.txtLastTranTime.Location = new System.Drawing.Point(598, 88);
            this.txtLastTranTime.MaxLength = 30;
            this.txtLastTranTime.Name = "txtLastTranTime";
            this.txtLastTranTime.ReadOnly = true;
            this.txtLastTranTime.Size = new System.Drawing.Size(116, 20);
            this.txtLastTranTime.TabIndex = 54;
            this.txtLastTranTime.TabStop = false;
            // 
            // lblLastTranTime
            // 
            this.lblLastTranTime.AutoSize = true;
            this.lblLastTranTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastTranTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastTranTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastTranTime.Location = new System.Drawing.Point(490, 91);
            this.lblLastTranTime.Name = "lblLastTranTime";
            this.lblLastTranTime.Size = new System.Drawing.Size(78, 13);
            this.lblLastTranTime.TabIndex = 53;
            this.lblLastTranTime.Text = "Last Tran Time";
            // 
            // txtLastToolEventID
            // 
            this.txtLastToolEventID.Location = new System.Drawing.Point(598, 64);
            this.txtLastToolEventID.MaxLength = 12;
            this.txtLastToolEventID.Name = "txtLastToolEventID";
            this.txtLastToolEventID.ReadOnly = true;
            this.txtLastToolEventID.Size = new System.Drawing.Size(116, 20);
            this.txtLastToolEventID.TabIndex = 52;
            this.txtLastToolEventID.TabStop = false;
            // 
            // lblLastToolEventID
            // 
            this.lblLastToolEventID.AutoSize = true;
            this.lblLastToolEventID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastToolEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastToolEventID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastToolEventID.Location = new System.Drawing.Point(490, 67);
            this.lblLastToolEventID.Name = "lblLastToolEventID";
            this.lblLastToolEventID.Size = new System.Drawing.Size(82, 13);
            this.lblLastToolEventID.TabIndex = 51;
            this.lblLastToolEventID.Text = "Last Tool Event";
            // 
            // lblLastActiveHistSeq
            // 
            this.lblLastActiveHistSeq.AutoSize = true;
            this.lblLastActiveHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastActiveHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastActiveHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastActiveHistSeq.Location = new System.Drawing.Point(490, 43);
            this.lblLastActiveHistSeq.Name = "lblLastActiveHistSeq";
            this.lblLastActiveHistSeq.Size = new System.Drawing.Size(103, 13);
            this.lblLastActiveHistSeq.TabIndex = 49;
            this.lblLastActiveHistSeq.Text = "Last Active Hist Seq";
            // 
            // lblLastHistSeq
            // 
            this.lblLastHistSeq.AutoSize = true;
            this.lblLastHistSeq.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLastHistSeq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastHistSeq.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLastHistSeq.Location = new System.Drawing.Point(490, 19);
            this.lblLastHistSeq.Name = "lblLastHistSeq";
            this.lblLastHistSeq.Size = new System.Drawing.Size(70, 13);
            this.lblLastHistSeq.TabIndex = 47;
            this.lblLastHistSeq.Text = "Last Hist Seq";
            // 
            // txtToolComment
            // 
            this.txtToolComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToolComment.Location = new System.Drawing.Point(120, 304);
            this.txtToolComment.MaxLength = 400;
            this.txtToolComment.Multiline = true;
            this.txtToolComment.Name = "txtToolComment";
            this.txtToolComment.ReadOnly = true;
            this.txtToolComment.Size = new System.Drawing.Size(592, 70);
            this.txtToolComment.TabIndex = 64;
            this.txtToolComment.TabStop = false;
            // 
            // lblToolComment
            // 
            this.lblToolComment.AutoSize = true;
            this.lblToolComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolComment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblToolComment.Location = new System.Drawing.Point(12, 307);
            this.lblToolComment.Name = "lblToolComment";
            this.lblToolComment.Size = new System.Drawing.Size(75, 13);
            this.lblToolComment.TabIndex = 63;
            this.lblToolComment.Text = "Tool Comment";
            // 
            // txtToolGradeID
            // 
            this.txtToolGradeID.Location = new System.Drawing.Point(360, 280);
            this.txtToolGradeID.MaxLength = 1;
            this.txtToolGradeID.Name = "txtToolGradeID";
            this.txtToolGradeID.ReadOnly = true;
            this.txtToolGradeID.Size = new System.Drawing.Size(116, 20);
            this.txtToolGradeID.TabIndex = 46;
            this.txtToolGradeID.TabStop = false;
            // 
            // txtSubAreaID
            // 
            this.txtSubAreaID.Location = new System.Drawing.Point(360, 40);
            this.txtSubAreaID.MaxLength = 20;
            this.txtSubAreaID.Name = "txtSubAreaID";
            this.txtSubAreaID.ReadOnly = true;
            this.txtSubAreaID.Size = new System.Drawing.Size(116, 20);
            this.txtSubAreaID.TabIndex = 26;
            this.txtSubAreaID.TabStop = false;
            // 
            // txtAreaID
            // 
            this.txtAreaID.Location = new System.Drawing.Point(360, 16);
            this.txtAreaID.MaxLength = 20;
            this.txtAreaID.Name = "txtAreaID";
            this.txtAreaID.ReadOnly = true;
            this.txtAreaID.Size = new System.Drawing.Size(116, 20);
            this.txtAreaID.TabIndex = 24;
            this.txtAreaID.TabStop = false;
            // 
            // txtToolGroup
            // 
            this.txtToolGroup.Location = new System.Drawing.Point(120, 16);
            this.txtToolGroup.MaxLength = 20;
            this.txtToolGroup.Name = "txtToolGroup";
            this.txtToolGroup.ReadOnly = true;
            this.txtToolGroup.Size = new System.Drawing.Size(116, 20);
            this.txtToolGroup.TabIndex = 1;
            this.txtToolGroup.TabStop = false;
            // 
            // txtDeleteFlag
            // 
            this.txtDeleteFlag.Location = new System.Drawing.Point(120, 280);
            this.txtDeleteFlag.MaxLength = 1;
            this.txtDeleteFlag.Name = "txtDeleteFlag";
            this.txtDeleteFlag.ReadOnly = true;
            this.txtDeleteFlag.Size = new System.Drawing.Size(116, 20);
            this.txtDeleteFlag.TabIndex = 22;
            this.txtDeleteFlag.TabStop = false;
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(120, 256);
            this.txtOper.MaxLength = 10;
            this.txtOper.Name = "txtOper";
            this.txtOper.ReadOnly = true;
            this.txtOper.Size = new System.Drawing.Size(116, 20);
            this.txtOper.TabIndex = 20;
            this.txtOper.TabStop = false;
            // 
            // txtFlow
            // 
            this.txtFlow.Location = new System.Drawing.Point(120, 232);
            this.txtFlow.MaxLength = 20;
            this.txtFlow.Name = "txtFlow";
            this.txtFlow.ReadOnly = true;
            this.txtFlow.Size = new System.Drawing.Size(116, 20);
            this.txtFlow.TabIndex = 18;
            this.txtFlow.TabStop = false;
            // 
            // txtSubResID
            // 
            this.txtSubResID.Location = new System.Drawing.Point(120, 184);
            this.txtSubResID.MaxLength = 20;
            this.txtSubResID.Name = "txtSubResID";
            this.txtSubResID.ReadOnly = true;
            this.txtSubResID.Size = new System.Drawing.Size(116, 20);
            this.txtSubResID.TabIndex = 15;
            this.txtSubResID.TabStop = false;
            // 
            // txtResID
            // 
            this.txtResID.Location = new System.Drawing.Point(120, 160);
            this.txtResID.MaxLength = 20;
            this.txtResID.Name = "txtResID";
            this.txtResID.ReadOnly = true;
            this.txtResID.Size = new System.Drawing.Size(116, 20);
            this.txtResID.TabIndex = 13;
            this.txtResID.TabStop = false;
            // 
            // txtSubLotID
            // 
            this.txtSubLotID.Location = new System.Drawing.Point(120, 136);
            this.txtSubLotID.MaxLength = 30;
            this.txtSubLotID.Name = "txtSubLotID";
            this.txtSubLotID.ReadOnly = true;
            this.txtSubLotID.Size = new System.Drawing.Size(116, 20);
            this.txtSubLotID.TabIndex = 11;
            this.txtSubLotID.TabStop = false;
            // 
            // txtLotID
            // 
            this.txtLotID.Location = new System.Drawing.Point(120, 112);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(116, 20);
            this.txtLotID.TabIndex = 9;
            this.txtLotID.TabStop = false;
            // 
            // txtToolStatus
            // 
            this.txtToolStatus.Location = new System.Drawing.Point(120, 88);
            this.txtToolStatus.MaxLength = 10;
            this.txtToolStatus.Name = "txtToolStatus";
            this.txtToolStatus.ReadOnly = true;
            this.txtToolStatus.Size = new System.Drawing.Size(116, 20);
            this.txtToolStatus.TabIndex = 7;
            this.txtToolStatus.TabStop = false;
            // 
            // lblCellSizeX
            // 
            this.lblCellSizeX.AutoSize = true;
            this.lblCellSizeX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellSizeX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellSizeX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellSizeX.Location = new System.Drawing.Point(252, 211);
            this.lblCellSizeX.Name = "lblCellSizeX";
            this.lblCellSizeX.Size = new System.Drawing.Size(57, 13);
            this.lblCellSizeX.TabIndex = 39;
            this.lblCellSizeX.Text = "Cell Size X";
            // 
            // lblCellCountX
            // 
            this.lblCellCountX.AutoSize = true;
            this.lblCellCountX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellCountX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellCountX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellCountX.Location = new System.Drawing.Point(252, 139);
            this.lblCellCountX.Name = "lblCellCountX";
            this.lblCellCountX.Size = new System.Drawing.Size(65, 13);
            this.lblCellCountX.TabIndex = 33;
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
            this.lblDeleteFlag.TabIndex = 21;
            this.lblDeleteFlag.Text = "Delete Flag";
            // 
            // txtCellSizeZ
            // 
            this.txtCellSizeZ.Location = new System.Drawing.Point(360, 256);
            this.txtCellSizeZ.MaxLength = 10;
            this.txtCellSizeZ.Name = "txtCellSizeZ";
            this.txtCellSizeZ.ReadOnly = true;
            this.txtCellSizeZ.Size = new System.Drawing.Size(116, 20);
            this.txtCellSizeZ.TabIndex = 44;
            this.txtCellSizeZ.TabStop = false;
            // 
            // lblCellSizeZ
            // 
            this.lblCellSizeZ.AutoSize = true;
            this.lblCellSizeZ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellSizeZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellSizeZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellSizeZ.Location = new System.Drawing.Point(252, 259);
            this.lblCellSizeZ.Name = "lblCellSizeZ";
            this.lblCellSizeZ.Size = new System.Drawing.Size(57, 13);
            this.lblCellSizeZ.TabIndex = 43;
            this.lblCellSizeZ.Text = "Cell Size Z";
            // 
            // txtCellSizeY
            // 
            this.txtCellSizeY.Location = new System.Drawing.Point(360, 232);
            this.txtCellSizeY.MaxLength = 10;
            this.txtCellSizeY.Name = "txtCellSizeY";
            this.txtCellSizeY.ReadOnly = true;
            this.txtCellSizeY.Size = new System.Drawing.Size(116, 20);
            this.txtCellSizeY.TabIndex = 42;
            this.txtCellSizeY.TabStop = false;
            // 
            // lblCellSizeY
            // 
            this.lblCellSizeY.AutoSize = true;
            this.lblCellSizeY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellSizeY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellSizeY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellSizeY.Location = new System.Drawing.Point(252, 235);
            this.lblCellSizeY.Name = "lblCellSizeY";
            this.lblCellSizeY.Size = new System.Drawing.Size(57, 13);
            this.lblCellSizeY.TabIndex = 41;
            this.lblCellSizeY.Text = "Cell Size Y";
            // 
            // txtCellSizeX
            // 
            this.txtCellSizeX.Location = new System.Drawing.Point(360, 208);
            this.txtCellSizeX.MaxLength = 10;
            this.txtCellSizeX.Name = "txtCellSizeX";
            this.txtCellSizeX.ReadOnly = true;
            this.txtCellSizeX.Size = new System.Drawing.Size(116, 20);
            this.txtCellSizeX.TabIndex = 40;
            this.txtCellSizeX.TabStop = false;
            // 
            // txtCellCountZ
            // 
            this.txtCellCountZ.Location = new System.Drawing.Point(360, 184);
            this.txtCellCountZ.MaxLength = 10;
            this.txtCellCountZ.Name = "txtCellCountZ";
            this.txtCellCountZ.ReadOnly = true;
            this.txtCellCountZ.Size = new System.Drawing.Size(116, 20);
            this.txtCellCountZ.TabIndex = 38;
            this.txtCellCountZ.TabStop = false;
            // 
            // lblCellCountZ
            // 
            this.lblCellCountZ.AutoSize = true;
            this.lblCellCountZ.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellCountZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellCountZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellCountZ.Location = new System.Drawing.Point(252, 187);
            this.lblCellCountZ.Name = "lblCellCountZ";
            this.lblCellCountZ.Size = new System.Drawing.Size(65, 13);
            this.lblCellCountZ.TabIndex = 37;
            this.lblCellCountZ.Text = "Cell Count Z";
            // 
            // txtCellCountY
            // 
            this.txtCellCountY.Location = new System.Drawing.Point(360, 160);
            this.txtCellCountY.MaxLength = 10;
            this.txtCellCountY.Name = "txtCellCountY";
            this.txtCellCountY.ReadOnly = true;
            this.txtCellCountY.Size = new System.Drawing.Size(116, 20);
            this.txtCellCountY.TabIndex = 36;
            this.txtCellCountY.TabStop = false;
            // 
            // lblCellCountY
            // 
            this.lblCellCountY.AutoSize = true;
            this.lblCellCountY.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCellCountY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCellCountY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCellCountY.Location = new System.Drawing.Point(252, 163);
            this.lblCellCountY.Name = "lblCellCountY";
            this.lblCellCountY.Size = new System.Drawing.Size(65, 13);
            this.lblCellCountY.TabIndex = 35;
            this.lblCellCountY.Text = "Cell Count Y";
            // 
            // txtCellCountX
            // 
            this.txtCellCountX.Location = new System.Drawing.Point(360, 136);
            this.txtCellCountX.MaxLength = 10;
            this.txtCellCountX.Name = "txtCellCountX";
            this.txtCellCountX.ReadOnly = true;
            this.txtCellCountX.Size = new System.Drawing.Size(116, 20);
            this.txtCellCountX.TabIndex = 34;
            this.txtCellCountX.TabStop = false;
            // 
            // txtVenderToolID
            // 
            this.txtVenderToolID.Location = new System.Drawing.Point(360, 112);
            this.txtVenderToolID.MaxLength = 30;
            this.txtVenderToolID.Name = "txtVenderToolID";
            this.txtVenderToolID.ReadOnly = true;
            this.txtVenderToolID.Size = new System.Drawing.Size(116, 20);
            this.txtVenderToolID.TabIndex = 32;
            this.txtVenderToolID.TabStop = false;
            // 
            // lblVenderToolID
            // 
            this.lblVenderToolID.AutoSize = true;
            this.lblVenderToolID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVenderToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVenderToolID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVenderToolID.Location = new System.Drawing.Point(252, 115);
            this.lblVenderToolID.Name = "lblVenderToolID";
            this.lblVenderToolID.Size = new System.Drawing.Size(79, 13);
            this.lblVenderToolID.TabIndex = 31;
            this.lblVenderToolID.Text = "Vendor Tool ID";
            // 
            // txtVender
            // 
            this.txtVender.Location = new System.Drawing.Point(360, 88);
            this.txtVender.MaxLength = 20;
            this.txtVender.Name = "txtVender";
            this.txtVender.ReadOnly = true;
            this.txtVender.Size = new System.Drawing.Size(116, 20);
            this.txtVender.TabIndex = 30;
            this.txtVender.TabStop = false;
            // 
            // lblVender
            // 
            this.lblVender.AutoSize = true;
            this.lblVender.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVender.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVender.Location = new System.Drawing.Point(252, 91);
            this.lblVender.Name = "lblVender";
            this.lblVender.Size = new System.Drawing.Size(41, 13);
            this.lblVender.TabIndex = 29;
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
            this.lblOper.TabIndex = 19;
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
            this.lblFlow.TabIndex = 17;
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
            this.lblSubResID.TabIndex = 14;
            this.lblSubResID.Text = "Sub Resource";
            // 
            // txtToolLoc
            // 
            this.txtToolLoc.Location = new System.Drawing.Point(360, 64);
            this.txtToolLoc.MaxLength = 20;
            this.txtToolLoc.Name = "txtToolLoc";
            this.txtToolLoc.ReadOnly = true;
            this.txtToolLoc.Size = new System.Drawing.Size(116, 20);
            this.txtToolLoc.TabIndex = 28;
            this.txtToolLoc.TabStop = false;
            // 
            // txtToolSetLoc
            // 
            this.txtToolSetLoc.Location = new System.Drawing.Point(120, 64);
            this.txtToolSetLoc.MaxLength = 20;
            this.txtToolSetLoc.Name = "txtToolSetLoc";
            this.txtToolSetLoc.ReadOnly = true;
            this.txtToolSetLoc.Size = new System.Drawing.Size(116, 20);
            this.txtToolSetLoc.TabIndex = 5;
            this.txtToolSetLoc.TabStop = false;
            // 
            // txtToolSetID
            // 
            this.txtToolSetID.Location = new System.Drawing.Point(120, 40);
            this.txtToolSetID.MaxLength = 20;
            this.txtToolSetID.Name = "txtToolSetID";
            this.txtToolSetID.ReadOnly = true;
            this.txtToolSetID.Size = new System.Drawing.Size(116, 20);
            this.txtToolSetID.TabIndex = 3;
            this.txtToolSetID.TabStop = false;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGrade.Location = new System.Drawing.Point(252, 283);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(36, 13);
            this.lblGrade.TabIndex = 45;
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
            this.lblToolLoc.TabIndex = 27;
            this.lblToolLoc.Text = "Tool Location";
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
            this.lblSubAreaID.TabIndex = 25;
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
            this.lblToolSetLoc.TabIndex = 4;
            this.lblToolSetLoc.Text = "Tool Set Location";
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResID.Location = new System.Drawing.Point(12, 163);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(53, 13);
            this.lblResID.TabIndex = 12;
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
            this.lblSubLotID.TabIndex = 10;
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
            this.lblLotID.TabIndex = 8;
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
            this.lblToolStatus.TabIndex = 6;
            this.lblToolStatus.Text = "Tool Status";
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
            this.lblToolSetID.TabIndex = 2;
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
            this.lblAreaID.TabIndex = 23;
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
            this.tbpCMF.Size = new System.Drawing.Size(728, 380);
            this.tbpCMF.TabIndex = 2;
            this.tbpCMF.Text = "Type Defined Field";
            this.tbpCMF.Visible = false;
            // 
            // grpCMF
            // 
            this.grpCMF.Controls.Add(this.spdData);
            this.grpCMF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCMF.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCMF.Location = new System.Drawing.Point(3, 0);
            this.grpCMF.Name = "grpCMF";
            this.grpCMF.Size = new System.Drawing.Size(722, 377);
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
            this.spdData_LotInfo});
            this.spdData.Size = new System.Drawing.Size(716, 358);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            // 
            // spdData_LotInfo
            // 
            this.spdData_LotInfo.Reset();
            spdData_LotInfo.SheetName = "LotInfo";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_LotInfo.ColumnCount = 2;
            spdData_LotInfo.RowCount = 3;
            this.spdData_LotInfo.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_LotInfo.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_LotInfo.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_LotInfo.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_LotInfo.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdData_LotInfo.ColumnHeader.Cells.Get(0, 1).Value = "Value";
            this.spdData_LotInfo.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_LotInfo.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_LotInfo.Columns.Get(0).Label = "Prompt";
            this.spdData_LotInfo.Columns.Get(0).Locked = true;
            this.spdData_LotInfo.Columns.Get(0).Width = 290F;
            this.spdData_LotInfo.Columns.Get(1).Label = "Value";
            this.spdData_LotInfo.Columns.Get(1).Locked = true;
            this.spdData_LotInfo.Columns.Get(1).Width = 400F;
            this.spdData_LotInfo.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_LotInfo.RowHeader.Columns.Default.Resizable = false;
            this.spdData_LotInfo.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_LotInfo.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_LotInfo.RowHeader.Visible = false;
            this.spdData_LotInfo.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_LotInfo.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_LotInfo.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ctxCopyMenu
            // 
            this.ctxCopyMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctxCopy});
            // 
            // ctxCopy
            // 
            this.ctxCopy.Index = 0;
            this.ctxCopy.Text = "Copy";
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(555, 7);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(88, 26);
            this.btnHistory.TabIndex = 1;
            this.btnHistory.Text = "History";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // frmRASViewTool
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmRASViewTool";
            this.Text = "View Tool";
            this.Activated += new System.EventHandler(this.frmRASViewTool_Activated);
            this.Load += new System.EventHandler(this.frmRASViewTool_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlTab, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
            this.grpTool.ResumeLayout(false);
            this.grpTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).EndInit();
            this.pnlTab.ResumeLayout(false);
            this.tabTool.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tbpCMF.ResumeLayout(false);
            this.grpCMF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_LotInfo)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition "
        private bool b_load_flag;
        #endregion
        
        #region " Function Definition "
        
        // View_Tool_Type()
        //       -  View Tool Type Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        
        private bool View_Tool_Type()
        {
            TRSNode in_node = new TRSNode("View_Tool_Type_In");
            TRSNode out_node = new TRSNode("View_Tool_Type_Out");
              
            int i;
            
            try
            {
                spdData.Sheets[0].RowCount = 30;
                spdData.Sheets[0].ClearRange(0, 0, 30, 3, true);
                spdData.Sheets[0].SetActiveCell(0, 0);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                for (i = 0; i < 30; i++)
                {
                    if (out_node.GetList(0)[i].GetString("PROMPT") == "")
                    {
                        spdData.Sheets[0].Rows[i].Height = 0;
                    }
                    else
                    {
                        spdData.Sheets[0].Rows[i].Height = 20;
                        spdData.Sheets[0].Cells[i, 0].Value = out_node.GetList(0)[i].GetString("PROMPT");
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
        
        // View_Tool()
        //       -  View Tool
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        
        private bool View_Tool()
        {
            TRSNode in_node = new TRSNode("View_Tool_In");
            TRSNode out_node = new TRSNode("View_Tool_Out");
            int i;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));
                in_node.AddString("TOOL_ID", cdvToolID.Text);

                if (MPCR.CallService("RAS", "RAS_View_Tool", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = out_node.GetString("TOOL_DESC");

                txtToolGroup.Text = out_node.GetString("TOOL_GRP");
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
                txtAreaID.Text = out_node.GetString("AREA_ID");
                txtSubAreaID.Text = out_node.GetString("SUB_AREA_ID");
                txtToolLoc.Text = out_node.GetString("TOOL_LOCATION");
                txtVender.Text = out_node.GetString("VENDOR_ID");
                txtVenderToolID.Text = out_node.GetString("VENDOR_TOOL_ID");
                txtCellCountX.Text = out_node.GetInt("CELL_COUNT_X").ToString();
                txtCellCountY.Text = out_node.GetInt("CELL_COUNT_Y").ToString();
                txtCellCountZ.Text = out_node.GetInt("CELL_COUNT_Z").ToString();
                txtCellSizeX.Text = out_node.GetInt("CELL_SIZE_X").ToString();
                txtCellSizeY.Text = out_node.GetInt("CELL_SIZE_Y").ToString();
                txtCellSizeZ.Text = out_node.GetInt("CELL_SIZE_Z").ToString();
                txtToolGradeID.Text = out_node.GetChar("GRADE").ToString();
                txtToolComment.Text = out_node.GetString("TOOL_COMMENT");

                txtLastHistSeq.Text = out_node.GetInt("LAST_HIST_SEQ").ToString();
                txtLastActiveHistSeq.Text = out_node.GetInt("LAST_ACTIVE_HIST_SEQ").ToString();
                txtLastToolEventID.Text = out_node.GetString("LAST_TOOL_EVENT_ID");
                txtLastTranTime.Text = MPCF.MakeDateFormat(out_node.GetString("LAST_TRAN_TIME"));

                txtCreateUserID.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUserID.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                TRSNode in_type_node = new TRSNode("View_Tool_Type_In");
                TRSNode out_type_node = new TRSNode("View_Tool_Type_Out");

                MPCR.SetInMsg(in_type_node);
                in_type_node.ProcStep = '1';
                in_type_node.AddString("TOOL_TYPE", MPCF.Trim(cdvType.Text));

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_type_node, ref out_type_node) == false)
                {
                    return false;
                }
                                
                for (i = 0; i < 30; i++)
                {
                    if (out_type_node.GetList(0)[i].GetString("PROMPT") != "")
                    {
                        spdData.Sheets[0].SetValue(i, 0, MPCF.Trim(out_type_node.GetList(0)[i].GetString("PROMPT")));
                    }
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    spdData.Sheets[0].SetValue(i, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("TOOL_STS")));
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        private bool CheckCondition(string FuncName)
        {

            if (MPCF.CheckValue(cdvType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvToolID, 1) == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "View_Tool":
                    
                    break;
                    //Do Nothing
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
        
        private void frmRASViewTool_Load(object sender, System.EventArgs e)
        {
        }
        
        private void frmRASViewTool_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdData);
                b_load_flag = true;
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
                
                if (cdvType.Text == "")
                {
                    return;
                }
                
                cdvToolID.Text = "";
                
                if (View_Tool_Type() == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvToolID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvToolID.Text != "")
            {
                if (CheckCondition("View_Tool") == true)
                {
                    View_Tool();
                }
            }
        }
        
        private void cdvToolID_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvType, 1) == false)
            {
                return;
            }
            
            cdvToolID.Init();
            MPCF.InitListView(cdvToolID.GetListView);
            cdvToolID.Columns.Add("Tool ID", 50, HorizontalAlignment.Left);
            cdvToolID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolID.SelectedSubItemIndex = 0;
            cdvToolID.DisplaySubItemIndex = 0;
            
            RASLIST.ViewToolList(cdvToolID.GetListView, '2', cdvType.Text, ' ', false, null);
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("View_Tool") == true)
            {
                if (View_Tool() == false)
                {
                    return;
                }
            }
            
        }
        
        private void cdvType_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this, cdvType, null, null, null, null, false);
            MPCF.ClearList(spdData, true);
        }
        
        private void cdvToolID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this, cdvType, cdvToolID, null, null, null, false);
            spdData.Sheets[0].ClearRange(0, 1, 30, 5, true);
        }
        
        private void cdvToolID_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (MPCF.CheckValue(cdvType, 1) == false)
            {
                e.Handled = true;
                return;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (cdvType.Text == "" || cdvToolID.Text == "")
                return;

            MPGV.gsCurrentToolType = cdvType.Text;
            MPGV.gsCurrentToolID = cdvToolID.Text;

            try
            {
                Form f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmRASViewToolHistory");
                if (f != null)
                {
                    f.BringToFront();
                    f.Show();
                }
                else
                {
                    f = new frmRASViewToolHistory();
                    f.MdiParent = MPGV.gfrmMDI;
                    f.BringToFront();
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
    //#End If
}
