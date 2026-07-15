
using Miracom.CliFrx;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using FarPoint.Win.Spread;
using Miracom.UI.Controls;

using Miracom.TRSCore;

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmQCMSetupApprovalRelease.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  CheckCondition() : Check the conditions before transaction
//       -  View_Inspection_Version_List() : View Inspection Set Version
//       -  View_Attach_Insp_Item_List() : View Inspection Item List by Inspection Set
//       -  Update_Inspection_Version() : Approval & Release Update
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-12-21 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//#If _QCM = True Then

namespace Miracom.QCMCore
{
    public class frmQCMSetupApprovalRelease : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMSetupApprovalRelease()
        {
            
            //???∏Ï∂ú?Ä Windows Form ?îÏûê?¥ÎÑà???ÑÏöî?©Îãà??
            InitializeComponent();
            
            //InitializeComponent()Î•??∏Ï∂ú???§Ïùå??Ï¥àÍ∏∞???ëÏóÖ??Ï∂îÍ??òÏã≠?úÏò§.
            
        }
        
        //Form?Ä DisposeÎ•??¨Ï†ï?òÌïò??Íµ¨ÏÑ± ?îÏÜå Î™©Î°ù???ïÎ¶¨?©Îãà??
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
        
        //Windows Form ?îÏûê?¥ÎÑà???ÑÏöî?©Îãà??
        private System.ComponentModel.Container components = null;
        
        //Ï∞∏Í≥†: ?§Ïùå ?ÑÎ°ú?úÏ???Windows Form ?îÏûê?¥ÎÑà???ÑÏöî?©Îãà??
        //Windows Form ?îÏûê?¥ÎÑàÎ•??¨Ïö©?òÏó¨ ?òÏ†ï?????àÏäµ?àÎã§.
        //ÏΩîÎìú ?∏ÏßëÍ∏∞Î? ?¨Ïö©?òÏó¨ ?òÏ†ï?òÏ? ÎßàÏã≠?úÏò§.
        private System.Windows.Forms.Panel pnlInspSet;
        private System.Windows.Forms.GroupBox grpOption;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspSet;
        private System.Windows.Forms.Label lblInspSet;
        private System.Windows.Forms.Panel pnlVersion;
        private FarPoint.Win.Spread.FpSpread spdVersion;
        private FarPoint.Win.Spread.SheetView spdVersion_Sheet1;
        private System.Windows.Forms.Panel pnlInspItem;
        private FarPoint.Win.Spread.FpSpread spdInspItem;
        protected Button btnExcel;
        private FarPoint.Win.Spread.SheetView spdInspItem_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQCMSetupApprovalRelease));
            this.pnlInspSet = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvInspSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblInspSet = new System.Windows.Forms.Label();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.spdVersion = new FarPoint.Win.Spread.FpSpread();
            this.spdVersion_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlInspItem = new System.Windows.Forms.Panel();
            this.spdInspItem = new FarPoint.Win.Spread.FpSpread();
            this.spdInspItem_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlInspSet.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspSet)).BeginInit();
            this.pnlVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).BeginInit();
            this.pnlInspItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Text = "Approval";
            this.btnCreate.Click += new System.EventHandler(this.Approval_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Text = "App. Cancel";
            this.btnDelete.Click += new System.EventHandler(this.Cancel_Approval_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Text = "Release";
            this.btnUpdate.Click += new System.EventHandler(this.Release_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.TabIndex = 4;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Enabled = false;
            this.pnlCenter.Size = new System.Drawing.Size(742, 546);
            this.pnlCenter.Visible = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Location = new System.Drawing.Point(0, 174);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Approval and Release Inspection Set Version";
            // 
            // pnlInspSet
            // 
            this.pnlInspSet.Controls.Add(this.grpOption);
            this.pnlInspSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInspSet.Location = new System.Drawing.Point(0, 0);
            this.pnlInspSet.Name = "pnlInspSet";
            this.pnlInspSet.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlInspSet.Size = new System.Drawing.Size(742, 47);
            this.pnlInspSet.TabIndex = 1;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvInspSet);
            this.grpOption.Controls.Add(this.lblInspSet);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 47);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            this.grpOption.Tag = "";
            // 
            // cdvInspSet
            // 
            this.cdvInspSet.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvInspSet.BorderHotColor = System.Drawing.Color.Black;
            this.cdvInspSet.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvInspSet.BtnToolTipText = "";
            this.cdvInspSet.DescText = "";
            this.cdvInspSet.DisplaySubItemIndex = -1;
            this.cdvInspSet.DisplayText = "";
            this.cdvInspSet.Focusing = null;
            this.cdvInspSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvInspSet.Index = 0;
            this.cdvInspSet.IsViewBtnImage = false;
            this.cdvInspSet.Location = new System.Drawing.Point(120, 16);
            this.cdvInspSet.MaxLength = 25;
            this.cdvInspSet.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvInspSet.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvInspSet.Name = "cdvInspSet";
            this.cdvInspSet.ReadOnly = false;
            this.cdvInspSet.SearchSubItemIndex = 0;
            this.cdvInspSet.SelectedDescIndex = -1;
            this.cdvInspSet.SelectedSubItemIndex = -1;
            this.cdvInspSet.SelectionStart = 0;
            this.cdvInspSet.Size = new System.Drawing.Size(200, 20);
            this.cdvInspSet.SmallImageList = null;
            this.cdvInspSet.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvInspSet.TabIndex = 1;
            this.cdvInspSet.TextBoxToolTipText = "";
            this.cdvInspSet.TextBoxWidth = 200;
            this.cdvInspSet.VisibleButton = true;
            this.cdvInspSet.VisibleColumnHeader = false;
            this.cdvInspSet.VisibleDescription = false;
            this.cdvInspSet.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvInspSet_SelectedItemChanged);
            this.cdvInspSet.ButtonPress += new System.EventHandler(this.cdvInspSet_ButtonPress);
            this.cdvInspSet.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvInspSet_TextBoxKeyPress);
            this.cdvInspSet.TextBoxTextChanged += new System.EventHandler(this.cdvInspSet_TextBoxTextChanged);
            // 
            // lblInspSet
            // 
            this.lblInspSet.AutoSize = true;
            this.lblInspSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInspSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInspSet.Location = new System.Drawing.Point(15, 19);
            this.lblInspSet.Name = "lblInspSet";
            this.lblInspSet.Size = new System.Drawing.Size(79, 13);
            this.lblInspSet.TabIndex = 0;
            this.lblInspSet.Text = "Insp. Set ID ";
            // 
            // pnlVersion
            // 
            this.pnlVersion.Controls.Add(this.spdVersion);
            this.pnlVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVersion.Location = new System.Drawing.Point(0, 47);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlVersion.Size = new System.Drawing.Size(742, 127);
            this.pnlVersion.TabIndex = 2;
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
            this.spdVersion.Location = new System.Drawing.Point(3, 3);
            this.spdVersion.Name = "spdVersion";
            this.spdVersion.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdVersion.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdVersion.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdVersion.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdVersion_Sheet1});
            this.spdVersion.Size = new System.Drawing.Size(736, 124);
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
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Release Insp. Set";
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
            this.spdVersion_Sheet1.Columns.Get(6).Label = "Release Insp. Set";
            this.spdVersion_Sheet1.Columns.Get(6).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Width = 111F;
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
            this.spdVersion_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlInspItem
            // 
            this.pnlInspItem.Controls.Add(this.spdInspItem);
            this.pnlInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInspItem.Location = new System.Drawing.Point(0, 174);
            this.pnlInspItem.Name = "pnlInspItem";
            this.pnlInspItem.Padding = new System.Windows.Forms.Padding(3);
            this.pnlInspItem.Size = new System.Drawing.Size(742, 332);
            this.pnlInspItem.TabIndex = 3;
            // 
            // spdInspItem
            // 
            this.spdInspItem.AccessibleDescription = "";
            this.spdInspItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdInspItem.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdInspItem.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInspItem.HorizontalScrollBar.Name = "";
            this.spdInspItem.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdInspItem.HorizontalScrollBar.TabIndex = 2;
            this.spdInspItem.Location = new System.Drawing.Point(3, 3);
            this.spdInspItem.Name = "spdInspItem";
            this.spdInspItem.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdInspItem.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdInspItem.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdInspItem_Sheet1});
            this.spdInspItem.Size = new System.Drawing.Size(736, 326);
            this.spdInspItem.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdInspItem.TabIndex = 1;
            this.spdInspItem.TabStop = false;
            this.spdInspItem.TextTipDelay = 200;
            this.spdInspItem.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdInspItem.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInspItem.VerticalScrollBar.Name = "";
            this.spdInspItem.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdInspItem.VerticalScrollBar.TabIndex = 3;
            this.spdInspItem.SetViewportLeftColumn(0, 0, 3);
            this.spdInspItem.SetActiveViewport(0, 0, -1);
            // 
            // spdInspItem_Sheet1
            // 
            this.spdInspItem_Sheet1.Reset();
            spdInspItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdInspItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdInspItem_Sheet1.ColumnCount = 16;
            spdInspItem_Sheet1.RowCount = 5;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Insp. Item";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Inspection Method";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Sampling Proc.";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Oper";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Item CMF1";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Item CMF2";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Item CMF3";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Item CMF4";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Item CMF5";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Item CMF6";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Item CMF7";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Item CMF8";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Item CMF9";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Item CMF10";
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdInspItem_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(0).Label = "Insp. Item";
            this.spdInspItem_Sheet1.Columns.Get(0).Locked = false;
            this.spdInspItem_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(0).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(1).Label = "Description";
            this.spdInspItem_Sheet1.Columns.Get(1).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(1).Width = 100F;
            this.spdInspItem_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(2).Label = "Inspection Method";
            this.spdInspItem_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(2).Width = 121F;
            this.spdInspItem_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(3).Label = "Sampling Proc.";
            this.spdInspItem_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(3).Width = 99F;
            this.spdInspItem_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(4).Label = "Flow";
            this.spdInspItem_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(4).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(4).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(5).Label = "Oper";
            this.spdInspItem_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(5).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(6).Label = "Item CMF1";
            this.spdInspItem_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(6).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(7).Label = "Item CMF2";
            this.spdInspItem_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(7).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(8).Label = "Item CMF3";
            this.spdInspItem_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(8).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(9).Label = "Item CMF4";
            this.spdInspItem_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(9).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(10).Label = "Item CMF5";
            this.spdInspItem_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(10).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(11).Label = "Item CMF6";
            this.spdInspItem_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(11).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(12).Label = "Item CMF7";
            this.spdInspItem_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(12).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(13).Label = "Item CMF8";
            this.spdInspItem_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(13).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(14).Label = "Item CMF9";
            this.spdInspItem_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(14).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(15).Label = "Item CMF10";
            this.spdInspItem_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(15).Width = 80F;
            this.spdInspItem_Sheet1.FrozenColumnCount = 3;
            this.spdInspItem_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdInspItem_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdInspItem_Sheet1.Rows.Get(0).Height = 18F;
            this.spdInspItem_Sheet1.Rows.Get(1).Height = 18F;
            this.spdInspItem_Sheet1.Rows.Get(2).Height = 18F;
            this.spdInspItem_Sheet1.Rows.Get(3).Height = 18F;
            this.spdInspItem_Sheet1.Rows.Get(4).Height = 18F;
            this.spdInspItem_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdInspItem_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdInspItem_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdInspItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmQCMSetupApprovalRelease
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlInspItem);
            this.Controls.Add(this.pnlVersion);
            this.Controls.Add(this.pnlInspSet);
            this.Name = "frmQCMSetupApprovalRelease";
            this.Tag = "QCM1005";
            this.Text = "Approval and Release Inspection Set Version Setup";
            this.Activated += new System.EventHandler(this.frmQCMSetupApprovalRelease_Activated);
            this.Load += new System.EventHandler(this.frmQCMSetupApprovalRelease_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlInspSet, 0);
            this.Controls.SetChildIndex(this.pnlVersion, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlInspItem, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlInspSet.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvInspSet)).EndInit();
            this.pnlVersion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).EndInit();
            this.pnlInspItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdInspItem_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Variable Definition"
        
        bool bLoadFlag;
        
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
        
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_Inspection_Version":
                        
                        
                        if (cdvInspSet.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvInspSet.Focus();
                            return false;
                        }
                        
                        if (spdVersion.Sheets[0].RowCount == 0 | spdVersion.Sheets[0].SelectionCount == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(152));
                            return false;
                        }
                        
                        if (spdInspItem.Sheets[0].RowCount <= 0)
                        {
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
                        
                    case "View_Inspection_Version_List":
                        
                        if (cdvInspSet.Text != "")
                        {
                            return true;
                        }
                        
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;
                        
//                        case "View_Attach_Insp_Item_List":
//                        
//                        if (cdvInspSet.Text != "")
//                        {
//                            if (spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRow.Index, 0) != "")
//                            {
//                                return true;
//                                }
//                                }
                                
//                                modCommonFunction.ShowMsgBox(modLanguageFunction.GetMessage(108));
//                                return false;
                   
                    case "View_Attach_Insp_Item_List":
                        return true;
                
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
        // View_Inspection_Version_List()
        //       - View BOM Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - Optional ByVal c_step As String = "1"
        //       - ByVal sColSetId As String
        
        private bool View_Inspection_Version_List(string sInspSetId, char c_step)
        {
            
            int i;
            int LastRow = 0;
            
            TRSNode in_node = new TRSNode("VIEW_INSP_SET_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_INSP_SET_VERSION_LIST_OUT");
            
            
            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("INSP_SET_ID", sInspSetId);
                in_node.AddInt("NEXT_INSP_SET_VERSION", 0);
                
                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Inspection_Version_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    spdVersion.Sheets[0].RowCount = out_node.GetList(0).Count;
                    
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        FarPoint.Win.Spread.SheetView with_1 = spdVersion.Sheets[0];

                        //Modify by J.S. 2009.04.09
                        with_1.SetValue(LastRow, 0, out_node.GetList(0)[i].GetInt("INSP_SET_VERSION").ToString());
                        with_1.SetValue(LastRow, 1, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_START_TIME")));
                        with_1.SetValue(LastRow, 2, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_END_TIME")));
                        with_1.SetValue(LastRow, 3, ((out_node.GetList(0)[i].GetChar("APPROVAL_FLAG") == 'Y') ? 'V' : ' '));
                        with_1.SetValue(LastRow, 4, out_node.GetList(0)[i].GetString("APPROVAL_USER_ID"));
                        with_1.SetValue(LastRow, 5, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPROVAL_TIME")));
                        with_1.SetValue(LastRow, 6, ((out_node.GetList(0)[i].GetChar("RELEASE_FLAG") == 'Y') ? 'V' : ' '));
                        with_1.SetValue(LastRow, 7, out_node.GetList(0)[i].GetString("RELEASE_USER_ID"));
                        with_1.SetValue(LastRow, 8, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RELEASE_TIME")));
                        
                        LastRow++;
                    }
                    
                    in_node.SetInt("NEXT_INSP_SET_VERSION", out_node.GetInt("NEXT_INSP_SET_VERSION"));


                } while (in_node.GetInt("NEXT_INSP_SET_VERSION") > 0);
                
                MPCF.FitColumnHeader(spdVersion);
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            
        }
        
        
        // View_Attach_Insp_Item_List()
        //       - View Material List by BOM Set
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal sColSetId As String                        : ColSet
        //        - ByVal sColSetVersion As String                : ColSetVersion
        //        -
        
        public bool View_Attach_Insp_Item_List(string sInspSetId, string sBOMSetVersion)
        {
            
            int i;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_ATTACH_INSP_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_INSP_ITEM_LIST_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INSP_SET_ID", sInspSetId);
                in_node.AddInt("INSP_SET_VERSION", MPCF.ToInt(sBOMSetVersion));
                in_node.AddInt("NEXT_SEQ_NUM", 0);
                
                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Attach_Insp_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    spdInspItem.Sheets[0].RowCount = out_node.GetList(0).Count;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        
                        FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];
                        
                        with_1.SetValue(LastRow, 0, out_node.GetList(0)[i].GetString("INSP_ITEM"));
                        with_1.SetValue(LastRow, 1, out_node.GetList(0)[i].GetString("INSP_ITEM_DESC"));
                        with_1.SetValue(LastRow, 2, out_node.GetList(0)[i].GetString("INSP_METHOD"));
                        with_1.SetValue(LastRow, 3, out_node.GetList(0)[i].GetString("SAMPLE_PROC"));
                        with_1.SetValue(LastRow, 4, out_node.GetList(0)[i].GetString("FLOW"));
                        with_1.SetValue(LastRow, 5, out_node.GetList(0)[i].GetString("OPER"));
                        with_1.SetValue(LastRow, 6, out_node.GetList(0)[i].GetString("ITEM_CMF_1"));
                        with_1.SetValue(LastRow, 7, out_node.GetList(0)[i].GetString("ITEM_CMF_2"));
                        with_1.SetValue(LastRow, 8, out_node.GetList(0)[i].GetString("ITEM_CMF_3"));
                        with_1.SetValue(LastRow, 9, out_node.GetList(0)[i].GetString("ITEM_CMF_4"));
                        with_1.SetValue(LastRow, 10, out_node.GetList(0)[i].GetString("ITEM_CMF_5"));
                        with_1.SetValue(LastRow, 11, out_node.GetList(0)[i].GetString("ITEM_CMF_6"));
                        with_1.SetValue(LastRow, 12, out_node.GetList(0)[i].GetString("ITEM_CMF_7"));
                        with_1.SetValue(LastRow, 13, out_node.GetList(0)[i].GetString("ITEM_CMF_8"));
                        with_1.SetValue(LastRow, 14, out_node.GetList(0)[i].GetString("ITEM_CMF_9"));
                        with_1.SetValue(LastRow, 15, out_node.GetList(0)[i].GetString("ITEM_CMF_10"));
                        
                        LastRow++;                    
                    }
                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

                } while (in_node.GetInt("NEXT_SEQ_NUM") > 0);
                
                MPCF.FitColumnHeader(spdInspItem);
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //Update_Inspection_Version()
        //      - Approval & Release Update
        //Return Value
        //      - Boolean : True or False
        //Arguments
        //      - ByVal ProcStep As String (MP_STEP_CREATE - Create, MP_STEP_UPDATE - Update, MP_STEP_DELETE - Delete)
        
        private bool Update_Inspection_Version(char ProcStep)
        {
            TRSNode in_node = new TRSNode("UPDATE_INSPECTION_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("INSP_SET_ID", cdvInspSet.Text);
                in_node.AddInt("INSP_SET_VERSION", MPCF.ToInt(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 0)));
                in_node.AddString("APPLY_START_TIME", MPCF.DestroyDateFormat(MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 1))));
                in_node.AddString("APPLY_END_TIME", MPCF.DestroyDateFormat(MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 2))));
                                                
                if (ProcStep == MPGC.MP_STEP_APPROVAL)
                {
                    in_node.AddChar("APPROVAL_FLAG",'Y');
                }
                
                if (ProcStep == MPGC.MP_STEP_RELEASE)
                {
                    in_node.AddChar("RELEASE_FLAG", 'Y');
                    in_node.AddChar("APPROVAL_FLAG", (MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 3))== "V") ? 'Y' : ' ');
                }
                
                if (ProcStep == MPGC.MP_STEP_CANCEL_APPROVAL)
                {
                    in_node.AddChar("APPROVAL_FLAG", ' ');
                }

                if (MPCR.CallService("QCM", "QCM_Approval_And_Release_to_Version", in_node, ref out_node) == false)
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
        
        // SetCmfItem()
        //       - Set Cmf Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        private void SetCmfItem()
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            int i;
            //int j;

            try
            {
                for (i = 6; i <= 15; i++)
                {
                    spdInspItem.Sheets[0].ColumnHeader.Columns[i].Visible = false;
                }
                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_INSP_ITEM, ref out_node, "", true) == false)
                {
                    return;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        spdInspItem.Sheets[0].ColumnHeader.Columns[6 + i].Visible = true;
                        spdInspItem.Sheets[0].ColumnHeader.Cells[0, 6 + i].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT"));
                    }
                }
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
                return this.cdvInspSet;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmQCMSetupApprovalRelease_Load(object sender, System.EventArgs e)
        {
            try
            {
                
                MPCF.FieldClear(this);

                MPCF.ClearList(spdVersion, true);
                MPCF.ClearList(spdInspItem, true);
                MPCF.FitColumnHeader(spdVersion);
                MPCF.FitColumnHeader(spdInspItem);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void frmQCMSetupApprovalRelease_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (bLoadFlag == false)
                {
                    SetCmfItem();

                    bLoadFlag = true;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvInspSet_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdVersion, true);
                if (CheckCondition("View_Inspection_Version_List", MPGC.MP_STEP_CREATE) == true)
                {
                    if (View_Inspection_Version_List(MPCF.Trim(cdvInspSet.Text), '1') == false)
                    {
                        return;
                    }
                }

                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);
                
                MPCF.ClearList(spdInspItem);
                
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
                    btnCreate.Enabled = false;
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnCreate, true);
                    btnDelete.Enabled = false;
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
                
                if (CheckCondition("View_Attach_Insp_Item_List", MPGC.MP_STEP_CREATE) == true)
                {
                    View_Attach_Insp_Item_List(cdvInspSet.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 0)));
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void Release_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition("Update_Inspection_Version", MPGC.MP_STEP_RELEASE) == true)
            {
                
                if (Update_Inspection_Version(MPGC.MP_STEP_RELEASE) == false)
                {
                    return;
                }
                if (View_Inspection_Version_List(MPCF.Trim(cdvInspSet.Text), '1') == false)
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
            
            if (CheckCondition("Update_Inspection_Version", MPGC.MP_STEP_APPROVAL) == true)
            {
                
                if (Update_Inspection_Version(MPGC.MP_STEP_APPROVAL) == false)
                {
                    return;
                }
                if (View_Inspection_Version_List(MPCF.Trim(cdvInspSet.Text), '1') == false)
                {
                    return;
                }
                btnCreate.Enabled = false;
                MPCR.ChangeControlEnabled(this, btnDelete, true);
                
            }
            
        }
        
        private void Cancel_Approval_Click(System.Object sender, System.EventArgs e)
        {
            
            if (CheckCondition("Update_Inspection_Version", MPGC.MP_STEP_CANCEL_APPROVAL) == true)
            {
                
                if (Update_Inspection_Version(MPGC.MP_STEP_CANCEL_APPROVAL) == true)
                {
                    if (View_Inspection_Version_List(MPCF.Trim(cdvInspSet.Text), '1') == false)
                    {
                        return;
                    }
                    MPCR.ChangeControlEnabled(this, btnCreate, true);
                    btnDelete.Enabled = false;
                }
            }
            
        }
        
        private void cdvInspSet_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdVersion, true);
            MPCF.ClearList(spdInspItem, true);
        }
        
        private void cdvInspSet_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvInspSet.Text != "")
                {
                    cdvInspSet_SelectedItemChanged(sender, null);
                }
            }
        }
        
        private void cdvInspSet_ButtonPress(System.Object sender, System.EventArgs e)
        {
            cdvInspSet.Init();
            cdvInspSet.Columns.Add("BOM Set", 50, HorizontalAlignment.Left);
            cdvInspSet.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvInspSet.SelectedSubItemIndex = 0;
            if (QCMLIST.ViewInspectionSetList(cdvInspSet.GetListView, '1', "", "", null, "") == false)
            {
                return;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                sCond = "Inspection Set ID : " + cdvInspSet.Text;

                MPCF.ExportToExcel(spdInspItem, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

    }
    //#End If
        
}
