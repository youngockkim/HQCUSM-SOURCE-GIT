
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
using FarPoint.Win.Spread;
using Miracom.TRSCore;

//#If _RCP = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRCPSetupApprovalRelease.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  ClearData() : Initalize form fields
//       -  CheckCondition() : Check the conditions before transaction
//       -  View_Recipe_Version_List() : View Recipe Version List
//       -  View_Para_Version_List() : View Parameter List by Recipe
//       -  View_Recipe_Version() : View Recipe Version Definition
//       -  Approval_Release_Recipe_Version() : Approval & Release Update
//       -  initCodeView() : initial CodeView Control
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-06-28 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RCPCore
{
    public class frmRCPSetupApprovalRelease : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRCPSetupApprovalRelease()
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
        



        private System.Windows.Forms.Panel pnlBomSetID;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.Panel pnlVersion;
        private FarPoint.Win.Spread.FpSpread spdVersion;
        private FarPoint.Win.Spread.SheetView spdVersion_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Panel pnlPrarmeter;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvRecipe;
        private System.Windows.Forms.Label lblRecipe;
        private System.Windows.Forms.GroupBox grbParameter;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtProcTime;
        private System.Windows.Forms.Label lblProcTime;
        private System.Windows.Forms.CheckBox chkModify;
        private System.Windows.Forms.TextBox txtColSetID;
        private System.Windows.Forms.TextBox txtReticleID;
        private System.Windows.Forms.TextBox txtCoatPPID;
        private System.Windows.Forms.TextBox txtPPId;
        private System.Windows.Forms.Label lblColSetID;
        private System.Windows.Forms.Label lblReticleID;
        private System.Windows.Forms.Label lblCoatPPId;
        private System.Windows.Forms.Label lblPPId;
        private System.Windows.Forms.GroupBox grpApplyTime;
        private System.Windows.Forms.Label lblFromTo;
        private System.Windows.Forms.GroupBox grpUpdateInfo;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private FarPoint.Win.Spread.FpSpread spdParameter;
        private FarPoint.Win.Spread.SheetView spdParameter_Sheet1;
        private System.Windows.Forms.GroupBox grbGeneral;
        private System.Windows.Forms.TextBox txtApplyEndTime;
        private System.Windows.Forms.TextBox txtApplyStartTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlBomSetID = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvRecipe = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblRecipe = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.spdVersion = new FarPoint.Win.Spread.FpSpread();
            this.spdVersion_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlPrarmeter = new System.Windows.Forms.Panel();
            this.grbParameter = new System.Windows.Forms.GroupBox();
            this.spdParameter = new FarPoint.Win.Spread.FpSpread();
            this.spdParameter_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grbGeneral = new System.Windows.Forms.GroupBox();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtProcTime = new System.Windows.Forms.TextBox();
            this.lblProcTime = new System.Windows.Forms.Label();
            this.chkModify = new System.Windows.Forms.CheckBox();
            this.txtColSetID = new System.Windows.Forms.TextBox();
            this.txtReticleID = new System.Windows.Forms.TextBox();
            this.txtCoatPPID = new System.Windows.Forms.TextBox();
            this.txtPPId = new System.Windows.Forms.TextBox();
            this.lblColSetID = new System.Windows.Forms.Label();
            this.lblReticleID = new System.Windows.Forms.Label();
            this.lblCoatPPId = new System.Windows.Forms.Label();
            this.lblPPId = new System.Windows.Forms.Label();
            this.grpApplyTime = new System.Windows.Forms.GroupBox();
            this.txtApplyEndTime = new System.Windows.Forms.TextBox();
            this.txtApplyStartTime = new System.Windows.Forms.TextBox();
            this.lblFromTo = new System.Windows.Forms.Label();
            this.grpUpdateInfo = new System.Windows.Forms.GroupBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBomSetID.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).BeginInit();
            this.pnlPrarmeter.SuspendLayout();
            this.grbParameter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter_Sheet1)).BeginInit();
            this.grbGeneral.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.grpApplyTime.SuspendLayout();
            this.grpUpdateInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(467, 7);
            this.btnCreate.Text = "Approval";
            this.btnCreate.Click += new System.EventHandler(this.Approval_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Text = "App. Cancel";
            this.btnDelete.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(558, 7);
            this.btnUpdate.Text = "Release";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 3;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Enabled = false;
            this.pnlCenter.Size = new System.Drawing.Size(742, 546);
            this.pnlCenter.Visible = false;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Approval and Release Recipe Version";
            // 
            // pnlBomSetID
            // 
            this.pnlBomSetID.Controls.Add(this.grpOption);
            this.pnlBomSetID.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBomSetID.Location = new System.Drawing.Point(0, 0);
            this.pnlBomSetID.Name = "pnlBomSetID";
            this.pnlBomSetID.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlBomSetID.Size = new System.Drawing.Size(742, 47);
            this.pnlBomSetID.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvRecipe);
            this.grpOption.Controls.Add(this.lblRecipe);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.lblResID);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 47);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            this.grpOption.Tag = "";
            // 
            // cdvRecipe
            // 
            this.cdvRecipe.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvRecipe.BorderHotColor = System.Drawing.Color.Black;
            this.cdvRecipe.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvRecipe.BtnToolTipText = "";
            this.cdvRecipe.ButtonWidth = 20;
            this.cdvRecipe.DescText = "";
            this.cdvRecipe.DisplaySubItemIndex = -1;
            this.cdvRecipe.DisplayText = "";
            this.cdvRecipe.Focusing = null;
            this.cdvRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvRecipe.Index = 0;
            this.cdvRecipe.IsViewBtnImage = false;
            this.cdvRecipe.Location = new System.Drawing.Point(476, 16);
            this.cdvRecipe.MaxLength = 25;
            this.cdvRecipe.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvRecipe.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvRecipe.MultiSelect = false;
            this.cdvRecipe.Name = "cdvRecipe";
            this.cdvRecipe.ReadOnly = false;
            this.cdvRecipe.SameWidthHeightOfButton = false;
            this.cdvRecipe.SearchSubItemIndex = 0;
            this.cdvRecipe.SelectedDescIndex = -1;
            this.cdvRecipe.SelectedDescToQueryText = "";
            this.cdvRecipe.SelectedSubItemIndex = -1;
            this.cdvRecipe.SelectedValueToQueryText = "";
            this.cdvRecipe.SelectionStart = 0;
            this.cdvRecipe.Size = new System.Drawing.Size(200, 20);
            this.cdvRecipe.SmallImageList = null;
            this.cdvRecipe.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvRecipe.TabIndex = 3;
            this.cdvRecipe.TextBoxToolTipText = "";
            this.cdvRecipe.TextBoxWidth = 200;
            this.cdvRecipe.VisibleButton = true;
            this.cdvRecipe.VisibleColumnHeader = false;
            this.cdvRecipe.VisibleDescription = false;
            this.cdvRecipe.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvRecipe_SelectedItemChanged);
            this.cdvRecipe.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvRecipe_TextBoxKeyPress);
            this.cdvRecipe.TextBoxTextChanged += new System.EventHandler(this.cdvRecipe_TextBoxTextChanged);
            // 
            // lblRecipe
            // 
            this.lblRecipe.AutoSize = true;
            this.lblRecipe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipe.Location = new System.Drawing.Point(372, 19);
            this.lblRecipe.Name = "lblRecipe";
            this.lblRecipe.Size = new System.Drawing.Size(47, 13);
            this.lblRecipe.TabIndex = 2;
            this.lblRecipe.Text = "Recipe";
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.ButtonWidth = 20;
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(120, 16);
            this.cdvResID.MaxLength = 25;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MultiSelect = false;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SameWidthHeightOfButton = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedDescToQueryText = "";
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectedValueToQueryText = "";
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResId_TextBoxKeyPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResId_TextBoxTextChanged);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(61, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource";
            // 
            // pnlVersion
            // 
            this.pnlVersion.Controls.Add(this.spdVersion);
            this.pnlVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVersion.Location = new System.Drawing.Point(0, 47);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.pnlVersion.Size = new System.Drawing.Size(742, 130);
            this.pnlVersion.TabIndex = 1;
            // 
            // spdVersion
            // 
            this.spdVersion.AccessibleDescription = "";
            this.spdVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdVersion.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdVersion.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.HorizontalScrollBar.Name = "";
            this.spdVersion.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdVersion.HorizontalScrollBar.TabIndex = 2;
            this.spdVersion.Location = new System.Drawing.Point(3, 5);
            this.spdVersion.Name = "spdVersion";
            this.spdVersion.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdVersion.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdVersion.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdVersion.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdVersion_Sheet1});
            this.spdVersion.Size = new System.Drawing.Size(736, 125);
            this.spdVersion.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdVersion.TabIndex = 1;
            this.spdVersion.TabStop = false;
            this.spdVersion.TextTipDelay = 200;
            this.spdVersion.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdVersion.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.VerticalScrollBar.Name = "";
            this.spdVersion.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdVersion.VerticalScrollBar.TabIndex = 3;
            this.spdVersion.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdVersion_SelectionChanged);
            this.spdVersion.SetViewportLeftColumn(0, 0, 1);
            this.spdVersion.SetActiveViewport(0, 0, -1);
            // 
            // spdVersion_Sheet1
            // 
            this.spdVersion_Sheet1.Reset();
            spdVersion_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdVersion_Sheet1.ColumnCount = 9;
            spdVersion_Sheet1.RowCount = 5;
            this.spdVersion_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdVersion_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdVersion_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Version";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Apply Start Time";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Apply End Time";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Approval";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "User ID";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Approval Time";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Release_Recipe";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "User ID";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Release Time";
            this.spdVersion_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdVersion_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdVersion_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(0).Label = "Version";
            this.spdVersion_Sheet1.Columns.Get(0).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(0).Width = 50F;
            this.spdVersion_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(1).Label = "Apply Start Time";
            this.spdVersion_Sheet1.Columns.Get(1).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(1).Width = 120F;
            this.spdVersion_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(2).Label = "Apply End Time";
            this.spdVersion_Sheet1.Columns.Get(2).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(2).Width = 120F;
            this.spdVersion_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(3).Label = "Approval";
            this.spdVersion_Sheet1.Columns.Get(3).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(4).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(4).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(4).Width = 80F;
            this.spdVersion_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(5).Label = "Approval Time";
            this.spdVersion_Sheet1.Columns.Get(5).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(5).Width = 120F;
            this.spdVersion_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Label = "Release_Recipe";
            this.spdVersion_Sheet1.Columns.Get(6).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Width = 99F;
            this.spdVersion_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(7).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(7).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(7).Width = 80F;
            this.spdVersion_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(8).Label = "Release Time";
            this.spdVersion_Sheet1.Columns.Get(8).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(8).Width = 120F;
            this.spdVersion_Sheet1.FrozenColumnCount = 1;
            this.spdVersion_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdVersion_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdVersion_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdVersion_Sheet1.Rows.Get(0).Height = 18F;
            this.spdVersion_Sheet1.Rows.Get(1).Height = 18F;
            this.spdVersion_Sheet1.Rows.Get(2).Height = 18F;
            this.spdVersion_Sheet1.Rows.Get(3).Height = 18F;
            this.spdVersion_Sheet1.Rows.Get(4).Height = 18F;
            this.spdVersion_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdVersion_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdVersion_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlPrarmeter
            // 
            this.pnlPrarmeter.Controls.Add(this.grbParameter);
            this.pnlPrarmeter.Controls.Add(this.grbGeneral);
            this.pnlPrarmeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrarmeter.Location = new System.Drawing.Point(0, 177);
            this.pnlPrarmeter.Name = "pnlPrarmeter";
            this.pnlPrarmeter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pnlPrarmeter.Size = new System.Drawing.Size(742, 329);
            this.pnlPrarmeter.TabIndex = 2;
            // 
            // grbParameter
            // 
            this.grbParameter.Controls.Add(this.spdParameter);
            this.grbParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbParameter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbParameter.Location = new System.Drawing.Point(362, 0);
            this.grbParameter.Name = "grbParameter";
            this.grbParameter.Size = new System.Drawing.Size(377, 326);
            this.grbParameter.TabIndex = 0;
            this.grbParameter.TabStop = false;
            this.grbParameter.Text = "Parameter";
            // 
            // spdParameter
            // 
            this.spdParameter.AccessibleDescription = "";
            this.spdParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdParameter.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdParameter.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdParameter.HorizontalScrollBar.Name = "";
            this.spdParameter.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdParameter.HorizontalScrollBar.TabIndex = 4;
            this.spdParameter.Location = new System.Drawing.Point(3, 16);
            this.spdParameter.Name = "spdParameter";
            this.spdParameter.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdParameter.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdParameter.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdParameter_Sheet1});
            this.spdParameter.Size = new System.Drawing.Size(371, 307);
            this.spdParameter.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdParameter.TabIndex = 0;
            this.spdParameter.TabStop = false;
            this.spdParameter.TextTipDelay = 200;
            this.spdParameter.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdParameter.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdParameter.VerticalScrollBar.Name = "";
            this.spdParameter.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdParameter.VerticalScrollBar.TabIndex = 5;
            this.spdParameter.SetViewportLeftColumn(0, 0, 2);
            this.spdParameter.SetActiveViewport(0, 0, -1);
            // 
            // spdParameter_Sheet1
            // 
            this.spdParameter_Sheet1.Reset();
            spdParameter_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdParameter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdParameter_Sheet1.ColumnCount = 8;
            spdParameter_Sheet1.RowCount = 5;
            this.spdParameter_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdParameter_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdParameter_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Parameter ID";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Value";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Description";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Modify Flag";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Min Value";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Max Value";
            this.spdParameter_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Unit";
            this.spdParameter_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdParameter_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdParameter_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdParameter_Sheet1.Columns.Get(0).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(0).Width = 38F;
            this.spdParameter_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdParameter_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdParameter_Sheet1.Columns.Get(1).Label = "Parameter ID";
            this.spdParameter_Sheet1.Columns.Get(1).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(1).Width = 96F;
            this.spdParameter_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdParameter_Sheet1.Columns.Get(2).Label = "Value";
            this.spdParameter_Sheet1.Columns.Get(2).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(2).Width = 100F;
            this.spdParameter_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdParameter_Sheet1.Columns.Get(3).Label = "Description";
            this.spdParameter_Sheet1.Columns.Get(3).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(3).Width = 100F;
            this.spdParameter_Sheet1.Columns.Get(4).CellType = textCellType2;
            this.spdParameter_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.spdParameter_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(4).Label = "Modify Flag";
            this.spdParameter_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(4).Width = 76F;
            this.spdParameter_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdParameter_Sheet1.Columns.Get(5).Label = "Min Value";
            this.spdParameter_Sheet1.Columns.Get(5).Width = 100F;
            this.spdParameter_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdParameter_Sheet1.Columns.Get(6).Label = "Max Value";
            this.spdParameter_Sheet1.Columns.Get(6).Width = 100F;
            this.spdParameter_Sheet1.Columns.Get(7).CellType = textCellType3;
            this.spdParameter_Sheet1.Columns.Get(7).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdParameter_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdParameter_Sheet1.Columns.Get(7).Label = "Unit";
            this.spdParameter_Sheet1.Columns.Get(7).Locked = true;
            this.spdParameter_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdParameter_Sheet1.Columns.Get(7).Width = 100F;
            this.spdParameter_Sheet1.FrozenColumnCount = 2;
            this.spdParameter_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdParameter_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdParameter_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdParameter_Sheet1.Rows.Get(0).Height = 18F;
            this.spdParameter_Sheet1.Rows.Get(1).Height = 18F;
            this.spdParameter_Sheet1.Rows.Get(2).Height = 18F;
            this.spdParameter_Sheet1.Rows.Get(3).Height = 18F;
            this.spdParameter_Sheet1.Rows.Get(4).Height = 18F;
            this.spdParameter_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdParameter_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdParameter_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdParameter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grbGeneral
            // 
            this.grbGeneral.Controls.Add(this.grpInfo);
            this.grbGeneral.Controls.Add(this.grpApplyTime);
            this.grbGeneral.Controls.Add(this.grpUpdateInfo);
            this.grbGeneral.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbGeneral.Location = new System.Drawing.Point(3, 0);
            this.grbGeneral.Name = "grbGeneral";
            this.grbGeneral.Size = new System.Drawing.Size(359, 326);
            this.grbGeneral.TabIndex = 0;
            this.grbGeneral.TabStop = false;
            this.grbGeneral.Text = "General";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtProcTime);
            this.grpInfo.Controls.Add(this.lblProcTime);
            this.grpInfo.Controls.Add(this.chkModify);
            this.grpInfo.Controls.Add(this.txtColSetID);
            this.grpInfo.Controls.Add(this.txtReticleID);
            this.grpInfo.Controls.Add(this.txtCoatPPID);
            this.grpInfo.Controls.Add(this.txtPPId);
            this.grpInfo.Controls.Add(this.lblColSetID);
            this.grpInfo.Controls.Add(this.lblReticleID);
            this.grpInfo.Controls.Add(this.lblCoatPPId);
            this.grpInfo.Controls.Add(this.lblPPId);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInfo.Location = new System.Drawing.Point(3, 16);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(353, 166);
            this.grpInfo.TabIndex = 0;
            this.grpInfo.TabStop = false;
            // 
            // txtProcTime
            // 
            this.txtProcTime.Location = new System.Drawing.Point(121, 112);
            this.txtProcTime.MaxLength = 8;
            this.txtProcTime.Name = "txtProcTime";
            this.txtProcTime.ReadOnly = true;
            this.txtProcTime.Size = new System.Drawing.Size(162, 20);
            this.txtProcTime.TabIndex = 9;
            this.txtProcTime.TabStop = false;
            // 
            // lblProcTime
            // 
            this.lblProcTime.AutoSize = true;
            this.lblProcTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblProcTime.Location = new System.Drawing.Point(15, 115);
            this.lblProcTime.Name = "lblProcTime";
            this.lblProcTime.Size = new System.Drawing.Size(55, 13);
            this.lblProcTime.TabIndex = 8;
            this.lblProcTime.Text = "Proc Time";
            // 
            // chkModify
            // 
            this.chkModify.AutoSize = true;
            this.chkModify.Enabled = false;
            this.chkModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkModify.Location = new System.Drawing.Point(15, 142);
            this.chkModify.Name = "chkModify";
            this.chkModify.Size = new System.Drawing.Size(86, 18);
            this.chkModify.TabIndex = 10;
            this.chkModify.TabStop = false;
            this.chkModify.Text = "Modify Flag";
            // 
            // txtColSetID
            // 
            this.txtColSetID.Location = new System.Drawing.Point(121, 87);
            this.txtColSetID.MaxLength = 25;
            this.txtColSetID.Name = "txtColSetID";
            this.txtColSetID.ReadOnly = true;
            this.txtColSetID.Size = new System.Drawing.Size(162, 20);
            this.txtColSetID.TabIndex = 7;
            this.txtColSetID.TabStop = false;
            // 
            // txtReticleID
            // 
            this.txtReticleID.Location = new System.Drawing.Point(121, 63);
            this.txtReticleID.MaxLength = 50;
            this.txtReticleID.Name = "txtReticleID";
            this.txtReticleID.ReadOnly = true;
            this.txtReticleID.Size = new System.Drawing.Size(162, 20);
            this.txtReticleID.TabIndex = 5;
            this.txtReticleID.TabStop = false;
            // 
            // txtCoatPPID
            // 
            this.txtCoatPPID.Location = new System.Drawing.Point(121, 39);
            this.txtCoatPPID.MaxLength = 25;
            this.txtCoatPPID.Name = "txtCoatPPID";
            this.txtCoatPPID.ReadOnly = true;
            this.txtCoatPPID.Size = new System.Drawing.Size(162, 20);
            this.txtCoatPPID.TabIndex = 3;
            this.txtCoatPPID.TabStop = false;
            // 
            // txtPPId
            // 
            this.txtPPId.Location = new System.Drawing.Point(121, 15);
            this.txtPPId.MaxLength = 25;
            this.txtPPId.Name = "txtPPId";
            this.txtPPId.ReadOnly = true;
            this.txtPPId.Size = new System.Drawing.Size(162, 20);
            this.txtPPId.TabIndex = 1;
            this.txtPPId.TabStop = false;
            // 
            // lblColSetID
            // 
            this.lblColSetID.AutoSize = true;
            this.lblColSetID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblColSetID.Location = new System.Drawing.Point(15, 91);
            this.lblColSetID.Name = "lblColSetID";
            this.lblColSetID.Size = new System.Drawing.Size(55, 13);
            this.lblColSetID.TabIndex = 6;
            this.lblColSetID.Text = "Col Set ID";
            // 
            // lblReticleID
            // 
            this.lblReticleID.AutoSize = true;
            this.lblReticleID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblReticleID.Location = new System.Drawing.Point(15, 67);
            this.lblReticleID.Name = "lblReticleID";
            this.lblReticleID.Size = new System.Drawing.Size(54, 13);
            this.lblReticleID.TabIndex = 4;
            this.lblReticleID.Text = "Reticle ID";
            // 
            // lblCoatPPId
            // 
            this.lblCoatPPId.AutoSize = true;
            this.lblCoatPPId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCoatPPId.Location = new System.Drawing.Point(15, 43);
            this.lblCoatPPId.Name = "lblCoatPPId";
            this.lblCoatPPId.Size = new System.Drawing.Size(60, 13);
            this.lblCoatPPId.TabIndex = 2;
            this.lblCoatPPId.Text = "Coat PP ID";
            // 
            // lblPPId
            // 
            this.lblPPId.AutoSize = true;
            this.lblPPId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPPId.Location = new System.Drawing.Point(15, 19);
            this.lblPPId.Name = "lblPPId";
            this.lblPPId.Size = new System.Drawing.Size(35, 13);
            this.lblPPId.TabIndex = 0;
            this.lblPPId.Text = "PP ID";
            // 
            // grpApplyTime
            // 
            this.grpApplyTime.Controls.Add(this.txtApplyEndTime);
            this.grpApplyTime.Controls.Add(this.txtApplyStartTime);
            this.grpApplyTime.Controls.Add(this.lblFromTo);
            this.grpApplyTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpApplyTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpApplyTime.Location = new System.Drawing.Point(3, 182);
            this.grpApplyTime.Name = "grpApplyTime";
            this.grpApplyTime.Size = new System.Drawing.Size(353, 71);
            this.grpApplyTime.TabIndex = 1;
            this.grpApplyTime.TabStop = false;
            this.grpApplyTime.Text = "Apply Time";
            // 
            // txtApplyEndTime
            // 
            this.txtApplyEndTime.Location = new System.Drawing.Point(232, 30);
            this.txtApplyEndTime.MaxLength = 20;
            this.txtApplyEndTime.Name = "txtApplyEndTime";
            this.txtApplyEndTime.ReadOnly = true;
            this.txtApplyEndTime.Size = new System.Drawing.Size(115, 20);
            this.txtApplyEndTime.TabIndex = 2;
            this.txtApplyEndTime.TabStop = false;
            // 
            // txtApplyStartTime
            // 
            this.txtApplyStartTime.Location = new System.Drawing.Point(79, 30);
            this.txtApplyStartTime.MaxLength = 20;
            this.txtApplyStartTime.Name = "txtApplyStartTime";
            this.txtApplyStartTime.ReadOnly = true;
            this.txtApplyStartTime.Size = new System.Drawing.Size(115, 20);
            this.txtApplyStartTime.TabIndex = 0;
            this.txtApplyStartTime.TabStop = false;
            // 
            // lblFromTo
            // 
            this.lblFromTo.AutoSize = true;
            this.lblFromTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromTo.Location = new System.Drawing.Point(207, 35);
            this.lblFromTo.Name = "lblFromTo";
            this.lblFromTo.Size = new System.Drawing.Size(14, 13);
            this.lblFromTo.TabIndex = 1;
            this.lblFromTo.Text = "~";
            this.lblFromTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpUpdateInfo
            // 
            this.grpUpdateInfo.Controls.Add(this.txtUpdateUser);
            this.grpUpdateInfo.Controls.Add(this.txtUpdateTime);
            this.grpUpdateInfo.Controls.Add(this.txtCreateTime);
            this.grpUpdateInfo.Controls.Add(this.lblUpdate);
            this.grpUpdateInfo.Controls.Add(this.txtCreateUser);
            this.grpUpdateInfo.Controls.Add(this.lblCreate);
            this.grpUpdateInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpUpdateInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUpdateInfo.Location = new System.Drawing.Point(3, 253);
            this.grpUpdateInfo.Name = "grpUpdateInfo";
            this.grpUpdateInfo.Size = new System.Drawing.Size(353, 70);
            this.grpUpdateInfo.TabIndex = 2;
            this.grpUpdateInfo.TabStop = false;
            this.grpUpdateInfo.Text = "Update Information";
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(105, 20);
            this.txtUpdateUser.TabIndex = 6;
            this.txtUpdateUser.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(232, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(115, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(232, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(115, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
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
            this.txtCreateUser.Size = new System.Drawing.Size(105, 20);
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
            // frmRCPSetupApprovalRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlPrarmeter);
            this.Controls.Add(this.pnlVersion);
            this.Controls.Add(this.pnlBomSetID);
            this.Name = "frmRCPSetupApprovalRelease";
            this.Text = "Approval And Release Setup";
            this.Activated += new System.EventHandler(this.frmRCPSetupApprovalRelease_Activated);
            this.Load += new System.EventHandler(this.frmRCPSetupApprovalRelease_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlBomSetID, 0);
            this.Controls.SetChildIndex(this.pnlVersion, 0);
            this.Controls.SetChildIndex(this.pnlPrarmeter, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBomSetID.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlVersion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).EndInit();
            this.pnlPrarmeter.ResumeLayout(false);
            this.grbParameter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdParameter_Sheet1)).EndInit();
            this.grbGeneral.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpApplyTime.ResumeLayout(false);
            this.grpApplyTime.PerformLayout();
            this.grpUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.PerformLayout();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        bool b_load_flag;
        
        #endregion
        
        #region " Function Definition"
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2")
        //
        private void ClearData(char ProcStep)
        {
            try
            {
                
                if (ProcStep == '1')
                {
                    MPCF.ClearList(spdVersion, true);
                    MPCF.ClearList(spdParameter, true);
                    MPCF.FieldClear(grbGeneral);
                }
                else if (ProcStep == '2')
                {
                    MPCF.ClearList(spdParameter, true);
                    MPCF.FieldClear(grbGeneral);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Approval_Release_Recipe_Version":
                        
                        
                        if (cdvResID.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvResID.Focus();
                            return false;
                        }
                        
                        if (cdvRecipe.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvRecipe.Focus();
                            return false;
                        }
                        
                        if (spdVersion.Sheets[0].RowCount == 0 || spdVersion.Sheets[0].SelectionCount == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(152));
                            return false;
                        }

                        switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                        {
                            case MPGC.MP_STEP_APPROVAL:


                                if (MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 3)) == "")
                                {
                                    return true;
                                }
                                break;
                                
                            case MPGC.MP_STEP_RELEASE:


                                if (MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 6)) == "")
                                {
                                    return true;
                                }
                                break;
                                
                            case MPGC.MP_STEP_CANCEL_APPROVAL:
                                
                                return true;
                                
                        }
                        break;
                        
                    case "View_Recipe_Version_List":
                        
                        if (cdvResID.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvResID.Focus();
                            return false;
                        }
                        
                        if (cdvRecipe.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvRecipe.Focus();
                            return false;
                        }
                        
                        return true;

                    case "View_Para_Version_List":

                        if (cdvResID.Text != "" && cdvRecipe.Text != "")
                        {
                            if (MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRow.Index, 0)) != "")
                            {
                                return true;
                            }
                        }

                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;
                                
                    }
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return false;
                }
                
                return false;
            }
                

                //
                // View_Recipe_Version_List()
                //       - View Recipe Version
                // Return Value
                //       - Boolean : True or False
                // Arguments
                //       - ByVal sResId As String                     : Resource
                //       - ByVal sRecipe As String                   : Recipe
                //       - Optional ByVal c_step As String = "1"   : Step
                
                private bool View_Recipe_Version_List(string sResId, string sRecipe, char c_step)
                {
                    
                    int i;
                    int LastRow = 0;

                    TRSNode in_node = new TRSNode("VIEW_RECIPE_VERSION_LIST_IN");
                    TRSNode out_node = new TRSNode("VIEW_RECIPE_VERSION_LIST_OUT");            
                    
                    try
                    {
                        MPCR.SetInMsg(in_node);
                        in_node.ProcStep = c_step;
                        in_node.AddString("RES_ID", sResId);
                        in_node.AddString("RECIPE", sRecipe);
                        in_node.AddInt("NEXT_RECIPE_VERSION", 0);
                        
                        do
                        {
                            if (MPCR.CallService("RCP", "RCP_View_Recipe_Version_List", in_node, ref out_node) == false)
                            {
                                return false;
                            }

                            spdVersion.Sheets[0].RowCount = out_node.GetList(0).Count;

                            for (i = 0; i < out_node.GetList(0).Count; i++)
                            {
                                FarPoint.Win.Spread.SheetView with_1 = spdVersion.Sheets[0];

                                with_1.SetValue(LastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetInt("RECIPE_VERSION")));
                                with_1.SetValue(LastRow, 1, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_START_TIME"))));
                                with_1.SetValue(LastRow, 2, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPLY_END_TIME"))));
                                with_1.SetValue(LastRow, 3, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("APPROVAL_FLAG")) == "Y") ? "V" : ""));
                                with_1.SetValue(LastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("APPROVAL_USER_ID")));
                                with_1.SetValue(LastRow, 5, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("APPROVAL_TIME"))));
                                with_1.SetValue(LastRow, 6, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("RELEASE_FLAG")) == "Y") ? "V" : ""));
                                with_1.SetValue(LastRow, 7, MPCF.Trim(out_node.GetList(0)[i].GetString("RELEASE_USER_ID")));
                                with_1.SetValue(LastRow, 8, MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("RELEASE_TIME"))));
                                
                                LastRow++;
                            }
                            
                            in_node.SetInt("NEXT_RECIPE_VERSION", out_node.GetInt("NEXT_RECIPE_VERSION"));
                            
                        } while (in_node.GetInt("NEXT_RECIPE_VERSION") > 0);
                        
                        MPCF.FitColumnHeader(spdVersion);
                        
                        return true;
                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                        return false;
                    }
                    
                    
                }
                
                
                // View_Para_Version_List()
                //       - View Parameter List by Recipe
                // Return Value
                //       - boolean : True / False
                // Arguments
                //       - ByVal sResId As String                    : Resource
                //        - ByVal sRecipe As String                    : Recipe
                //        - ByVal sResipeVersion As String            : Recipe Version
                
                public bool View_Para_Version_List(string sResId, string sRecipe, string sResipeVersion)
                {
                    
                    int i;
                    int LastRow = 0;

                    TRSNode in_node = new TRSNode("VIEW_PARA_VERSION_LIST_IN");
                    TRSNode out_node = new TRSNode("VIEW_PARA_VERSION_LIST_OUT");

                    try
                    {
                        MPCR.SetInMsg(in_node);
                        in_node.ProcStep = '1';
                        in_node.AddString("RES_ID", sResId);
                        in_node.AddString("RECIPE", sRecipe);
                        in_node.AddInt("RECIPE_VERSION", MPCF.ToInt(sResipeVersion));

                        if (MPCR.CallService("RCP", "RCP_View_Para_Version_List", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        // New Version
                        spdParameter.Sheets[0].RowCount = out_node.GetList("URCP_PARA_LIST").Count;
                        for (i = 0; i < out_node.GetList("URCP_PARA_LIST").Count; i++)
                        {

                            FarPoint.Win.Spread.SheetView with_1 = spdParameter.Sheets[0];

                            with_1.SetValue(LastRow, 0, MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetInt("PARA_SEQ")));
                            with_1.SetValue(LastRow, 1, MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("PARA_ID")));
                            with_1.SetValue(LastRow, 2, MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("PARA_VALUE")));
                            with_1.SetValue(LastRow, 3, MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("PARA_DESC")));
                            with_1.SetValue(LastRow, 4, ((MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetChar("MODIFY_FLAG")) == "Y") ? "V" : " "));
                            with_1.SetValue(LastRow, 5, MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetDouble("CUS_MIN_VAL")));
                            with_1.SetValue(LastRow, 6, MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetDouble("CUS_MAX_VAL")));
                            with_1.SetValue(LastRow, 7, MPCF.Trim(out_node.GetList("URCP_PARA_LIST")[i].GetString("CUS_UNIT")));

                            LastRow++;

                        }

                        // Original Version
                        /*
                        spdParameter.Sheets[0].RowCount = out_node.GetList(0).Count;
                        for (i = 0; i < out_node.GetList(0).Count; i++)
                        {
                            
                            FarPoint.Win.Spread.SheetView with_1 = spdParameter.Sheets[0];

                            with_1.SetValue(LastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetInt("PARA_SEQ")));
                            with_1.SetValue(LastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("PARA_ID")));
                            with_1.SetValue(LastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("PARA_VALUE")));
                            with_1.SetValue(LastRow, 3, MPCF.Trim(out_node.GetList(0)[i].GetString("PARA_DESC")));
                            with_1.SetValue(LastRow, 4, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("MODIFY_FLAG")) == "Y") ? "V" : " "));
                                                        
                            LastRow++;
                            
                        }
                        */

                        MPCF.FitColumnHeader(spdParameter);
                        
                        return true;
                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                        return false;
                    }
                    
                }
                
                //
                // View_Recipe_Version()
                //       - View Recipe Version Definition
                // Return Value
                //       - Boolean : True or False
                // Arguments
                //       - ByVal sResId As String                    : Resource
                //        - ByVal sRecipe As String                    : Recipe
                //        - ByVal sResipeVersion As String            : Recipe Version
                
                private bool View_Recipe_Version(string sResId, string sRecipe, string sResipeVersion)
                {
                    TRSNode in_node = new TRSNode("VIEW_RECIPE_VERSION_IN");
                    TRSNode out_node = new TRSNode("VIEW_RECIPE_VERSION_OUT");

                    try
                    {
                        MPCF.FieldClear(grbGeneral);
                        MPCR.SetInMsg(in_node);
                        in_node.ProcStep = '1';
                        in_node.AddString("RES_ID", sResId);
                        in_node.AddString("RECIPE", sRecipe);
                        in_node.AddInt("RECIPE_VERSION", MPCF.ToInt(sResipeVersion));

                        if (MPCR.CallService("RCP", "RCP_View_Recipe_Version", in_node, ref out_node) == false)
                        {
                            return false;
                        }

                        txtPPId.Text = out_node.GetString("PP_ID");
                        txtCoatPPID.Text = out_node.GetString("COAT_PP_ID");
                        txtReticleID.Text = out_node.GetString("RETICLE_ID");
                        txtColSetID.Text = out_node.GetString("COL_SET_ID");
                        txtProcTime.Text = out_node.GetString("PROC_TIME").Substring(0, 2) + ":"
                                           + out_node.GetString("PROC_TIME").Substring(2, 2) + ":"
                                           + out_node.GetString("PROC_TIME").Substring(4, 2);
                        
                        if (MPCF.Trim(out_node.GetChar("modify_flag")) == "Y")
                        {
                            chkModify.Checked = true;
                        }
                        else
                        {
                            chkModify.Checked = false;
                        }

                        txtApplyStartTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPLY_START_TIME"));
                        txtApplyEndTime.Text = MPCF.MakeDateFormat(out_node.GetString("APPLY_END_TIME"));

                        txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
                        txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                        txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
                        txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                        return true;
                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                        return false;
                    }
                }
                
                //Approval_Release_Recipe_Version()
                //      - Approval & Release Update
                //Return Value
                //      - Boolean : True or False
                //Arguments
                //      - ByVal ProcStep As String (MP_STEP_CREATE - Create, MP_STEP_UPDATE - Update, MP_STEP_DELETE - Delete)
                
                private bool Approval_Release_Recipe_Version(char ProcStep)
                {
                    TRSNode in_node = new TRSNode("APPROVAL_RELEASE_RECIPE_VERSION_IN");
                    TRSNode out_node = new TRSNode("CMN_OUT");                    

                    try
                    {
                        MPCR.SetInMsg(in_node);
                        in_node.ProcStep = '1';

                        in_node.AddString("RES_ID", cdvResID.Text);
                        in_node.AddString("RECIPE", cdvRecipe.Text);
                        in_node.AddInt("RECIPE_VERSION", MPCF.ToInt(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 0)));
                        
                        if (ProcStep == MPGC.MP_STEP_APPROVAL)
                        {
                            in_node.AddChar("APPROVAL_FLAG", 'Y');
                        }
                        
                        if (ProcStep == MPGC.MP_STEP_RELEASE)
                        {
                            in_node.AddChar("RELEASE_FLAG", 'Y');
                            //Approval_Release_Recipe_Version_In._C.approval_flag = IIf(spdVersion.Sheets(0).GetValue(spdVersion.Sheets(0).ActiveRowIndex, 3) = "V", "Y", "")
                        }
                        
                        if (ProcStep == MPGC.MP_STEP_CANCEL_APPROVAL)
                        {
                            in_node.AddChar("APPROVAL_FLAG", ' ');
                        }

                        if (MPCR.CallService("RCP", "RCP_Approval_Release_Recipe_Version", in_node, ref out_node) == false)
                        {
                            return false;
                        }
                        MPCR.ShowSuccessMsg(out_node);
                        
                        return true;
                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                        return false;
                    }
                    
                }
                
                public virtual Control GetFisrtFocusItem()
                {
                    
                    try
                    {
                        return this.cdvResID;
                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                        return null;
                    }
                    
                }
                
                #endregion
                
                private void frmRCPSetupApprovalRelease_Load(object sender, System.EventArgs e)
                {
                    try
                    {

                        MPCF.FieldClear(this);
                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                }
                
                private void frmRCPSetupApprovalRelease_Activated(object sender, System.EventArgs e)
                {
                    try
                    {
                        if (b_load_flag == false)
                        {

                            MPCF.ClearList(spdVersion, true);
                            MPCF.ClearList(spdParameter, true);
                            MPCF.FitColumnHeader(spdVersion);
                            MPCF.FitColumnHeader(spdParameter);

                            b_load_flag = true;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                    
                }
                
                private void cdvResID_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
                {
                    try
                    {
                        if (cdvResID.Text != "")
                        {
                            
                            cdvRecipe.Init();
                            MPCF.InitListView(cdvRecipe.GetListView);
                            cdvRecipe.Columns.Add("Resource", 150, HorizontalAlignment.Left);
                            cdvRecipe.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                            cdvRecipe.SelectedSubItemIndex = 0;
                            if (RCPLIST.ViewRecipeList(cdvRecipe.GetListView, '1', cdvResID.Text, "", null, "", -1, -1) == false)
                            {
                                return;
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                    
                }
                
                private void cdvRecipe_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
                {
                    try
                    {
                        ClearData('2');
                        if (CheckCondition("View_Recipe_Version_List", MPGC.MP_STEP_CREATE) == true)
                        {
                            if (View_Recipe_Version_List(MPCF.Trim(cdvResID.Text), MPCF.Trim(cdvRecipe.Text), '1') == false)
                            {
                                return;
                            }
                        }

                        MPCR.ChangeControlEnabled(this, btnCreate, true);
                        MPCR.ChangeControlEnabled(this, btnUpdate, true);
                        MPCR.ChangeControlEnabled(this, btnDelete, true);;
                        
                        MPCF.ClearList(spdParameter);
                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                    
                }
                
                private void spdVersion_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
                {
                    try
                    {
                        if (MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 3)) != "")
                        {
                            btnCreate.Enabled = false; //App
                            // Release
                            MPCR.ChangeControlEnabled(this, btnUpdate, true);
                        }
                        else
                        {
                            //App
                            MPCR.ChangeControlEnabled(this, btnCreate, true);
                            btnUpdate.Enabled = false;  //Release
                        }

                        if (MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 6)) != "")
                        {
                            btnCreate.Enabled = false;
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;
                        }
                        else
                        {
                            MPCR.ChangeControlEnabled(this, btnUpdate, true);
                        }
                        
                        if (CheckCondition("View_Para_Version_List", MPGC.MP_STEP_CREATE) == true)
                        {
                            View_Recipe_Version(cdvResID.Text, cdvRecipe.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 0)));
                            View_Para_Version_List(cdvResID.Text, cdvRecipe.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 0)));
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MPCF.ShowMsgBox(ex.Message);
                    }
                    
                }

 

                //Release
                private void btnUpdate_Click(object sender, EventArgs e)
                {
                    if (CheckCondition("Approval_Release_Recipe_Version", MPGC.MP_STEP_RELEASE) == true)
                    {

                        if (Approval_Release_Recipe_Version(MPGC.MP_STEP_RELEASE) == false)
                        {
                            return;
                        }
                        if (View_Recipe_Version_List(MPCF.Trim(cdvResID.Text), MPCF.Trim(cdvRecipe.Text), '1') == false)
                        {
                            return;
                        }
                        btnCreate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnUpdate.Enabled = false;

                    }

                }

                
                private void Approval_Click(System.Object sender, System.EventArgs e)
                {
                    
                    if (CheckCondition("Approval_Release_Recipe_Version", MPGC.MP_STEP_APPROVAL) == true)
                    {
                        
                        if (Approval_Release_Recipe_Version(MPGC.MP_STEP_APPROVAL) == false)
                        {
                            return;
                        }
                        if (View_Recipe_Version_List(MPCF.Trim(cdvResID.Text), MPCF.Trim(cdvRecipe.Text), '1') == false)
                        {
                            return;
                        }
                        btnCreate.Enabled = false;

                        MPCR.ChangeControlEnabled(this, btnDelete, true);
                        
                    }
                    
                }
                
                private void cdvResId_TextBoxTextChanged(object sender, System.EventArgs e)
                {
                    ClearData('1');
                    cdvRecipe.Text = "";
                }
                
                private void cdvResId_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
                {
                    if (e.KeyChar == (char)13)
                    {
                        if (cdvResID.Text != "")
                        {
                            cdvResID_SelectedItemChanged(sender, null);
                        }
                    }
                }
                
                private void cdvRecipe_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
                {
                    if (e.KeyChar == (char)13)
                    {
                        if (cdvRecipe.Text != "")
                        {
                            cdvRecipe_SelectedItemChanged(sender, null);
                        }
                    }
                }
                
                private void cdvRecipe_TextBoxTextChanged(object sender, System.EventArgs e)
                {
                    ClearData('1');
                }
                
                private void cdvResID_ButtonPress(object sender, System.EventArgs e)
                {
                    cdvResID.Init();
                    MPCF.InitListView(cdvResID.GetListView);
                    cdvResID.Columns.Add("Resource", 150, HorizontalAlignment.Left);
                    cdvResID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    cdvResID.SelectedSubItemIndex = 0;
                    #if _RAS
                    //RASLIST.ViewResourceList(cdvResID.GetListView, false);
                    RASLIST.ViewResourceListForRecipe(cdvResID.GetListView, '7');
                    #endif
                }

    }
    //#End If
}
