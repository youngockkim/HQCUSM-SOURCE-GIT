
using Miracom.CliFrx;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using Miracom.UI.Controls;

using Miracom.TRSCore;


//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmQCMSetupAttachInspectionItem.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  ClearData() : Initalize form fields
//       -  CheckCondition() : Check the conditions before transaction
//       -  SetCmfItem() : Set Cmf Property to control
//       -  View_Inspection_Version_List() : View BOMSet Version
//       -  View_Insp_Item_List_By_InspSet() : View Material List by BOM Set
//       -  Update_Attach_Insp_Item() : Update Attach Inspection Item To Version
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-12-22 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _QCM = True Then

namespace Miracom.QCMCore
{
    public class frmQCMSetupAttachInspectionItem : Miracom.MESCore.SetupForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmQCMSetupAttachInspectionItem()
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
        private System.Windows.Forms.Panel pnlGrp;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.Panel pnlVersion;
        private System.Windows.Forms.Panel pnlInspItem;
        private FarPoint.Win.Spread.FpSpread spdVersion;
        private FarPoint.Win.Spread.SheetView spdVersion_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvInspSet;
        private System.Windows.Forms.Label lblInspSet;
        private FarPoint.Win.Spread.FpSpread spdInspItem;
        protected Button btnExcel;
        private FarPoint.Win.Spread.SheetView spdInspItem_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType3 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQCMSetupAttachInspectionItem));
            this.pnlGrp = new System.Windows.Forms.Panel();
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
            this.pnlGrp.SuspendLayout();
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
            this.btnCreate.Enabled = false;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.TabIndex = 3;
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
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Attach Inspection Item To Version";
            // 
            // pnlGrp
            // 
            this.pnlGrp.Controls.Add(this.grpOption);
            this.pnlGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrp.Location = new System.Drawing.Point(0, 0);
            this.pnlGrp.Name = "pnlGrp";
            this.pnlGrp.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlGrp.Size = new System.Drawing.Size(742, 47);
            this.pnlGrp.TabIndex = 0;
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
            this.pnlVersion.Padding = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.pnlVersion.Size = new System.Drawing.Size(742, 127);
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
            this.spdVersion.Size = new System.Drawing.Size(736, 122);
            this.spdVersion.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdVersion.TabIndex = 0;
            this.spdVersion.TabStop = false;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdVersion.TextTipAppearance = tipAppearance1;
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
            this.pnlInspItem.TabIndex = 2;
            // 
            // spdInspItem
            // 
            this.spdInspItem.AccessibleDescription = "spdInspItem, Sheet1, Row 0, Column 0, ";
            this.spdInspItem.BackColor = System.Drawing.SystemColors.Control;
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
            this.spdInspItem.TabIndex = 0;
            this.spdInspItem.TabStop = false;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdInspItem.TextTipAppearance = tipAppearance2;
            this.spdInspItem.TextTipDelay = 200;
            this.spdInspItem.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdInspItem.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdInspItem.VerticalScrollBar.Name = "";
            this.spdInspItem.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdInspItem.VerticalScrollBar.TabIndex = 3;
            this.spdInspItem.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdInspItem_EnterCell);
            this.spdInspItem.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdInspItem_ComboCloseUp);
            this.spdInspItem.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdInspItem_EditChange);
            this.spdInspItem.SetViewportLeftColumn(0, 0, 3);
            this.spdInspItem.SetActiveViewport(0, 0, -1);
            // 
            // spdInspItem_Sheet1
            // 
            this.spdInspItem_Sheet1.Reset();
            spdInspItem_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdInspItem_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdInspItem_Sheet1.ColumnCount = 17;
            spdInspItem_Sheet1.RowCount = 5;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Insp. Item";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Inspection Method";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Sampling Proc.";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Oper";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Item CMF1";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Item CMF2";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Item CMF3";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Item CMF4";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Item CMF5";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Item CMF6";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Item CMF7";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Item CMF8";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Item CMF9";
            this.spdInspItem_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Item CMF10";
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdInspItem_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdInspItem_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdInspItem_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdInspItem_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdInspItem_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(0).Width = 35F;
            this.spdInspItem_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.AliceBlue;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdInspItem_Sheet1.Columns.Get(1).CellType = comboBoxCellType1;
            this.spdInspItem_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdInspItem_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(1).Label = "Insp. Item";
            this.spdInspItem_Sheet1.Columns.Get(1).Locked = false;
            this.spdInspItem_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(1).Width = 120F;
            this.spdInspItem_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(2).Label = "Description";
            this.spdInspItem_Sheet1.Columns.Get(2).Locked = true;
            this.spdInspItem_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(2).Width = 150F;
            this.spdInspItem_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(3).Label = "Inspection Method";
            this.spdInspItem_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(3).Width = 121F;
            this.spdInspItem_Sheet1.Columns.Get(4).BackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(4).Label = "Sampling Proc.";
            this.spdInspItem_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(4).Width = 117F;
            this.spdInspItem_Sheet1.Columns.Get(5).BackColor = System.Drawing.Color.White;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdInspItem_Sheet1.Columns.Get(5).CellType = comboBoxCellType2;
            this.spdInspItem_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(5).Label = "Flow";
            this.spdInspItem_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(5).Visible = false;
            this.spdInspItem_Sheet1.Columns.Get(5).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.AliceBlue;
            comboBoxCellType3.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdInspItem_Sheet1.Columns.Get(6).CellType = comboBoxCellType3;
            this.spdInspItem_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(6).Label = "Oper";
            this.spdInspItem_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(6).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(7).Label = "Item CMF1";
            this.spdInspItem_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(7).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(8).Label = "Item CMF2";
            this.spdInspItem_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(8).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(9).Label = "Item CMF3";
            this.spdInspItem_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(9).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(10).Label = "Item CMF4";
            this.spdInspItem_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(10).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(11).Label = "Item CMF5";
            this.spdInspItem_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(11).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(12).Label = "Item CMF6";
            this.spdInspItem_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(12).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(13).Label = "Item CMF7";
            this.spdInspItem_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(13).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(14).Label = "Item CMF8";
            this.spdInspItem_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(14).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(15).Label = "Item CMF9";
            this.spdInspItem_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(15).Width = 80F;
            this.spdInspItem_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdInspItem_Sheet1.Columns.Get(16).Label = "Item CMF10";
            this.spdInspItem_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdInspItem_Sheet1.Columns.Get(16).Width = 80F;
            this.spdInspItem_Sheet1.FrozenColumnCount = 3;
            this.spdInspItem_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdInspItem_Sheet1.RowHeader.Columns.Default.Resizable = false;
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
            // frmQCMSetupAttachInspectionItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlInspItem);
            this.Controls.Add(this.pnlVersion);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmQCMSetupAttachInspectionItem";
            this.Tag = "QCM1004";
            this.Text = "Attach Inspection Item To Version Setup";
            this.Activated += new System.EventHandler(this.frmQCMSetupAttachInspectionItem_Activated);
            this.Load += new System.EventHandler(this.frmQCMSetupAttachInspectionItem_Load);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlVersion, 0);
            this.Controls.SetChildIndex(this.pnlInspItem, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
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

        private struct InspItem_tag
        {
            public string s_item;
            public string s_desc; 
        }
        List<InspItem_tag> ls_insp_item;

        #endregion
        
        #region " Function Definition"
        
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
            
            int i;
            
            try
            {
                
                if (ProcStep == '1')
                {
                    
                    for (i = 0; i <= spdInspItem.Sheets[0].RowCount - 1; i++)
                    {
                        spdInspItem.Sheets[0].SetValue(i, 0, false);
                    }
                    
                }
                else if (ProcStep == '2')
                {
                    
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
            
            int i;
            int j;
            int iSel = 0;
            
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    
                case "Update_Attach_Insp_Item":
                    
                    
                    if (cdvInspSet.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvInspSet.Focus();
                        return false;
                    }
                    
                    if (spdVersion.Sheets[0].RowCount == 0 || spdVersion.Sheets[0].SelectionCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(152));
                        return false;
                    }
                    
                    for (i = 0; i <= spdInspItem.Sheets[0].RowCount - 1; i++)
                    {
                        if (System.Convert.ToBoolean(spdInspItem.Sheets[0].GetValue(i, 0)) == true)
                        {
                            iSel++;
                        }
                    }
                    
                    if (iSel == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(165));
                        return false;
                    }
                    for (i = 0; i <= spdInspItem.Sheets[0].RowCount - 2; i++)
                    {
                        for (j = i + 1; j <= spdInspItem.Sheets[0].RowCount - 1; j++)
                        {
                            if (System.Convert.ToBoolean(spdInspItem.Sheets[0].GetValue(j, 0)) == true)
                            {
                                if ((MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 1)) != "") && 
                                    (MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 1)) == MPCF.Trim(spdInspItem.Sheets[0].GetValue(j, 1)) && 
                                     MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 3)) == MPCF.Trim(spdInspItem.Sheets[0].GetValue(j, 3)) && 
                                     MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 5)) == MPCF.Trim(spdInspItem.Sheets[0].GetValue(j, 5))))
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(166));
                                    spdInspItem.Sheets[0].SetActiveCell(j, 1);
                                    //spdInspItem.Sheets(0).ClearRange(j, 0, 1, 23, True)
                                    return false;
                                }
                            }
                        }
                    }
                    
                    for (i = 0; i <= spdInspItem.Sheets[0].RowCount - 1; i++)
                    {
                        
                        if (System.Convert.ToBoolean(spdInspItem.Sheets[0].GetValue(i, 0)) == true)
                        {
                            for (j = 0; j <= 15; j++)
                            {
                                if (spdInspItem.Sheets[0].Columns[j].BackColor.ToString() == "Color [AliceBlue]")
                                {
                                    if (spdInspItem.Sheets[0].Cells[i, j].Text == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                        spdInspItem.Sheets[0].SetActiveCell(i, j);
                                        return false;
                                    }
                                }
                            }
                            if (MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 3)) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(114));
                                spdInspItem.Sheets[0].SetActiveCell(i, 3);
                                return false;
                            }
                            //If RTrim(spdInspItem.Sheets(0).Cells(i, 4).Text) = "" Then
                            //    ShowMsgBox(GetMessage(108))
                            //    spdInspItem.Sheets(0).SetActiveCell(i, 4)
                            //    Return False
                            //End If
                            if (MPCF.Trim(spdInspItem.Sheets[0].Cells[i, 6].Text) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdInspItem.Sheets[0].SetActiveCell(i, 6);
                                return false;
                            }
                        }
                    }
                    
                    return true;
                    
//                    case "View_Inspection_Version_List":
//                    
//                    if (cdvInspSet.Text != "")
//                    {
//                        return true;
//                        }
                        
//                        modCommonFunction.ShowMsgBox(modLanguageFunction.GetMessage(108));
//                        return false;
//                        case "View_Insp_Item_List_By_InspSet":
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

            TRSNode in_node = new TRSNode("VIEW_INSPECTION_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_VERSION_LIST_OUT");
            
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

                        with_1.SetValue(LastRow, 0, out_node.GetList(0)[i].GetInt("INSP_SET_VERSION"));
                        with_1.SetValue(LastRow, 1, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_START_TIME")));
                        with_1.SetValue(LastRow, 2, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPLY_END_TIME")));
                        with_1.SetValue(LastRow, 3, ((out_node.GetList(0)[i].GetChar("APPROVAL_FLAG") == 'Y') ? "V" : ""));
                        with_1.SetValue(LastRow, 4, out_node.GetList(0)[i].GetString("APPROVAL_USER_ID"));
                        with_1.SetValue(LastRow, 5, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("APPROVAL_TIME")));
                        with_1.SetValue(LastRow, 6, ((out_node.GetList(0)[i].GetChar("RELEASE_FLAG") == 'Y') ? "V" : ""));
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
        
        
        // View_Insp_Item_List_By_InspSet()
        //       - View Inspection Item List by Inspection Set
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal sInspSetId As String                        : ColSet
        //        - ByVal sInspSetVersion As String                : ColSetVersion
        //        -
        
        public bool View_Insp_Item_List_By_InspSet(string sInspSetId, string sInspSetVersion)
        {
            
            int i;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_ATTACH_INSP_ITEM_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_INSP_ITEM_LIST_OUT");

            try
            {
                MPCF.ClearList(spdInspItem, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INSP_SET_ID", sInspSetId);
                in_node.AddInt("INSP_SET_VERSION", MPCF.ToInt(sInspSetVersion));
                in_node.AddInt("NEXT_SEQ_NUM", 0);
                
                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Attach_Insp_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        LastRow = spdInspItem.Sheets[0].RowCount;
                        spdInspItem.Sheets[0].RowCount = spdInspItem.Sheets[0].RowCount + 1;
                        FarPoint.Win.Spread.SheetView with_1 = spdInspItem.Sheets[0];
                        
                        with_1.SetValue(LastRow, 1, out_node.GetList(0)[i].GetString("INSP_ITEM"));
                        with_1.SetValue(LastRow, 2, out_node.GetList(0)[i].GetString("INSP_ITEM_DESC"));
                        with_1.SetValue(LastRow, 3, out_node.GetList(0)[i].GetString("INSP_METHOD"));
                        with_1.SetValue(LastRow, 4, out_node.GetList(0)[i].GetString("SAMPLE_PROC"));
                        with_1.SetValue(LastRow, 5, out_node.GetList(0)[i].GetString("FLOW"));
                        with_1.SetValue(LastRow, 6, out_node.GetList(0)[i].GetString("OPER"));
                        with_1.SetValue(LastRow, 7, out_node.GetList(0)[i].GetString("ITEM_CMF_1"));
                        with_1.SetValue(LastRow, 8, out_node.GetList(0)[i].GetString("ITEM_CMF_2"));
                        with_1.SetValue(LastRow, 9, out_node.GetList(0)[i].GetString("ITEM_CMF_3"));
                        with_1.SetValue(LastRow, 10, out_node.GetList(0)[i].GetString("ITEM_CMF_4"));
                        with_1.SetValue(LastRow, 11, out_node.GetList(0)[i].GetString("ITEM_CMF_5"));
                        with_1.SetValue(LastRow, 12, out_node.GetList(0)[i].GetString("ITEM_CMF_6"));
                        with_1.SetValue(LastRow, 13, out_node.GetList(0)[i].GetString("ITEM_CMF_7"));
                        with_1.SetValue(LastRow, 14, out_node.GetList(0)[i].GetString("ITEM_CMF_8"));
                        with_1.SetValue(LastRow, 15, out_node.GetList(0)[i].GetString("ITEM_CMF_9"));
                        with_1.SetValue(LastRow, 16, out_node.GetList(0)[i].GetString("ITEM_CMF_10"));
                        
                    }

                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

                } while (out_node.GetInt("NEXT_SEQ_NUM") != 0);
                
                spdInspItem.Sheets[0].RowCount++;
                
                MPCF.FitColumnHeader(spdInspItem);
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
        }
        
        //Update_Attach_Insp_Item()
        //      - Update Attach Inspection Item
        //Return Value
        //      - Boolean : True or False
        //Arguments
        //      - ByVal ProcStep As String (MP_STEP_CREATE - Create, MP_STEP_UPDATE - Update, MP_STEP_DELETE - Delete)
        
        private bool Update_Attach_Insp_Item(char ProcStep)
        {
            
            int i = 0;
            int iSeq = 0;
            TRSNode in_node = new TRSNode("UPDATE_ATTACH_INSP_ITEM_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("INSP_SET_ID", cdvInspSet.Text);
                in_node.AddInt("INSP_SET_VERSION", MPCF.ToInt(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRow.Index, 0)));

                for (i = 0; i <= spdInspItem.Sheets[0].RowCount - 1; i++)
                {
                    iSeq++;
                    if (System.Convert.ToBoolean(spdInspItem.Sheets[0].GetValue(i, 0)) == true)
                    {
                        node = in_node.AddNode("ITEM_LIST");

                        node.AddString("INSP_ITEM", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 1)));
                        node.AddInt("SEQ_NUM", iSeq);
                        node.AddString("INSP_METHOD", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 3)));
                        node.AddString("SAMPLE_PROC", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 4)));
                        node.AddString("FLOW", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 5)));
                        node.AddString("OPER", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 6)));
                        node.AddString("ITEM_CMF_1", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 7)));
                        node.AddString("ITEM_CMF_2", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 8)));
                        node.AddString("ITEM_CMF_3", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 9)));
                        node.AddString("ITEM_CMF_4", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 10)));
                        node.AddString("ITEM_CMF_5", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 11)));
                        node.AddString("ITEM_CMF_6", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 12)));
                        node.AddString("ITEM_CMF_7", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 13)));
                        node.AddString("ITEM_CMF_8", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 14)));
                        node.AddString("ITEM_CMF_9", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 15)));
                        node.AddString("ITEM_CMF_10", MPCF.Trim(spdInspItem.Sheets[0].GetValue(i, 16)));
                    }
                }

                if (MPCR.CallService("QCM", "QCM_Update_Attach_Insp_Item", in_node, ref out_node) == false)
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
        
        public bool View_Flow_List(char c_step)
        {
            
            int i;
            string[] sFlow = null;
            List<string> sList = new List<string>();
            FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;

            TRSNode in_node = new TRSNode("VIEW_FLOW_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_FLOW_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("NEXT_FLOW", "");
            
            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Flow_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    sList.Add( out_node.GetList(0)[i].GetString("FLOW"));
                }

                in_node.SetString("NEXT_FLOW", out_node.GetString("NEXT_FLOW"));

            } while (in_node.GetString("NEXT_FLOW") != "");

            sFlow = new string[sList.Count];
            for (i = 0; i < sList.Count; i++)
            {
                sFlow[i] = sList[i];
            }
            cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            cboCellType.Items = sFlow;
            spdInspItem.Sheets[0].Columns.Get(5).CellType = cboCellType;
            
            return true;
            
        }
        
        public bool View_Operation_List(char c_step, string sInspItemerial, int iMatVer, string sFlow)
        {
            try
            {
                int i;
                string[] sOper = null;
                List<string> sList = new List<string>();
                FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;

                TRSNode in_node = new TRSNode("VIEW_OPERATION_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_OPERATION_LIST_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("MAT_ID", MPCF.Trim(sInspItemerial));
                in_node.AddInt("MAT_VER", iMatVer);
                in_node.AddString("FLOW", MPCF.Trim(sFlow));
                in_node.AddString("NEXT_OPER", "");
                
                do
                {
                    if (MPCR.CallService("WIP", "WIP_View_Operation_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("OPER"));
                    }

                    in_node.SetString("NEXT_OPER", out_node.GetString("NEXT_OPER"));

                } while (in_node.GetString("NEXT_OPER") != "");

                sOper = new string[sList.Count];
                for (i = 0; i < sList.Count; i++)
                {
                    sOper[i] = sList[i];
                }
                cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cboCellType.Items = sOper;
                spdInspItem.Sheets[0].Columns.Get(6).CellType = cboCellType;

                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        public bool View_Inspection_Item_List(char c_step, string sMethod)
        {
            try
            {
                int i;
                string[] sdata;
                List<string> sList = new List<string>();
                InspItem_tag iit;
                FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;

                TRSNode in_node = new TRSNode("VIEW_INSPECTION_ITEM_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_INSPECTION_ITEM_LIST_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("INSP_METHOD", sMethod);
                in_node.AddString("NEXT_INSP_ITEM", "");
                
                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Inspection_Item_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("INSP_ITEM"));

                        iit.s_item = out_node.GetList(0)[i].GetString("INSP_ITEM");
                        iit.s_desc = out_node.GetList(0)[i].GetString("INSP_ITEM_DESC");
                        ls_insp_item.Add(iit);
                    }
                    
                    in_node.SetString("NEXT_INSP_ITEM", out_node.GetString("NEXT_INSP_ITEM"));

                } while (out_node.GetString("NEXT_INSP_ITEM") != "");

                sdata = new string[sList.Count];
                for (i = 0; i < sList.Count; i++)
                {
                    sdata[i] = sList[i];
                }
                cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cboCellType.Items = sdata;
                spdInspItem.Sheets[0].Columns.Get(1).CellType = cboCellType;
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        public bool View_Sampling_Procedure_List(char c_step, string sType)
        {
            try
            {
                int i;
                string[] sProc = null;
                List<string> sList = new List<string>();
                FarPoint.Win.Spread.CellType.ComboBoxCellType cboCellType;
                
                TRSNode in_node = new TRSNode("VIEW_SAMPLING_PROCEDURE_LIST_IN");
                TRSNode out_node = new TRSNode("VIEW_SAMPLING_PROCEDURE_LIST_OUT");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("SAMPLE_PROC_TYPE", sType);
                in_node.AddString("NEXT_SAMPLE_PROC", "");
                
                do
                {
                    if (MPCR.CallService("QCM", "QCM_View_Sampling_Procedure_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sList.Add(out_node.GetList(0)[i].GetString("SAMPLE_PROC"));
                    }
                    
                    in_node.SetString("NEXT_SAMPLE_PROC", out_node.GetString("NEXT_SAMPLE_PROC"));

                } while (in_node.GetString("NEXT_SAMPLE_PROC") != "");

                sProc = new string[sList.Count];
                for (i = 0; i < sList.Count; i++)
                {
                    sProc[i] = sList[i];
                }
                cboCellType = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                cboCellType.Items = sProc;
                spdInspItem.Sheets[0].Columns.Get(4).CellType = cboCellType;

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
        // View_Inspection_Item()
        //       - View Inspection Item Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        //-----------------------------------------------------------------------------
        private bool View_Inspection_Item(int i_row)
        {

            TRSNode in_node = new TRSNode("VIEW_INSPECTION_ITEM_IN");
            TRSNode out_node = new TRSNode("VIEW_INSPECTION_ITEM_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("INSP_ITEM", spdInspItem.Sheets[0].Cells[i_row, 1].Text);

                if (MPCR.CallService("QCM", "QCM_View_Inspection_Item", in_node, ref out_node) == false)
                {
                    return false;
                }

                //General
                spdInspItem.Sheets[0].SetValue(i_row, 2, out_node.GetString("INSP_ITEM_DESC"));
                spdInspItem.Sheets[0].SetValue(i_row, 3, out_node.GetString("INSP_METHOD"));
                spdInspItem.Sheets[0].SetValue(i_row, 4, out_node.GetString("SAMPLE_PROC"));

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[7].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 7, out_node.GetString("ITEM_CMF_1")); 
                }

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[8].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 8, out_node.GetString("ITEM_CMF_2"));
                }

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[9].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 9, out_node.GetString("ITEM_CMF_3"));
                }

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[10].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 10, out_node.GetString("ITEM_CMF_4"));
                }

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[11].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 11, out_node.GetString("ITEM_CMF_5"));
                }

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[12].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 12, out_node.GetString("ITEM_CMF_6"));
                }

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[13].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 13, out_node.GetString("ITEM_CMF_7"));
                }

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[14].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 14, out_node.GetString("ITEM_CMF_8"));
                }

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[15].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 15, out_node.GetString("ITEM_CMF_9"));
                }

                if (spdInspItem.Sheets[0].ColumnHeader.Columns[16].Visible == true)
                {
                    spdInspItem.Sheets[0].SetValue(i_row, 16, out_node.GetString("ITEM_CMF_10"));
                }

                MPCF.FitColumnHeader(spdInspItem);

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
                for (i = 7; i <= 16; i++)
                {
                    spdInspItem.Sheets[0].ColumnHeader.Columns[i].Visible = false;
                }
                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_INSP_ITEM, ref out_node, "", true) == false)
                {
                    return;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("PROMPT") != "")
                    {
                        spdInspItem.Sheets[0].ColumnHeader.Columns[7 + i].Visible = true;
                        spdInspItem.Sheets[0].ColumnHeader.Cells[0, 7 + i].Text = out_node.GetList(0)[i].GetString("PROMPT");
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
        
        private void frmQCMSetupAttachInspectionItem_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this);

                MPCF.ClearList(spdInspItem, true);
                MPCF.ClearList(spdVersion, true);
                MPCF.FitColumnHeader(spdVersion);
                MPCF.FitColumnHeader(spdInspItem);
                
                ls_insp_item = new List<InspItem_tag>();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmQCMSetupAttachInspectionItem_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (bLoadFlag == false)
                {
                    View_Inspection_Item_List('2', "");
                    View_Flow_List('1');
                    View_Operation_List('1', "", 0, "");
                    //View_Sampling_Procedure_List('1', "");

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
                
                if (CheckCondition("View_Inspection_Version_List", MPGC.MP_STEP_CREATE) == true)
                {
                    if (View_Inspection_Version_List(MPCF.Trim(cdvInspSet.Text), '1') == false)
                    {
                        return;
                    }
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }
                
                MPCF.ClearList(spdInspItem);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void spdVersion_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            int i;
            int j;
            
            try
            {

                MPCF.ClearList(spdInspItem, true);
                
                if (CheckCondition("View_Insp_Item_List_By_InspSet", MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }
                
                View_Insp_Item_List_By_InspSet(cdvInspSet.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 0)));
                SetCmfItem();
                
                for (i = 0; i <= spdInspItem.Sheets[0].RowCount - 1; i++)
                {
                    for (j = 0; j <= spdInspItem.Sheets[0].ColumnCount - 1; j++)
                    {
                        spdInspItem.Sheets[0].Cells.Get(i, j).Locked = true;
                    }
                }
                if (MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 3)) != "" || 
                    MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 6)) != "")
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);

                    for (i = 0; i <= spdInspItem.Sheets[0].RowCount - 1; i++)
                    {
                        for (j = 0; j <= spdInspItem.Sheets[0].ColumnCount - 1; j++)
                        {
                            if (j != 2)
                            {
                                spdInspItem.Sheets[0].Cells.Get(i, j).Locked = false;
                            }
                        }
                    }
                }
                ClearData('1');
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdInspItem_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            try
            {
                
                if (e.Row == spdInspItem.Sheets[0].RowCount - 1)
                {
                    if (e.Column > 0)
                    {
                        if (MPCF.Trim(spdInspItem.Sheets[0].Cells[e.Row, 1].Text) != "")
                        {
                            spdInspItem.Sheets[0].RowCount++;
                        }
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
                if (CheckCondition("Update_Attach_Insp_Item", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Attach_Insp_Item(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    if (CheckCondition("View_Insp_Item_List_By_InspSet", MPGC.MP_STEP_CREATE) == true)
                    {
                        View_Insp_Item_List_By_InspSet(cdvInspSet.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 0)));
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
                if (CheckCondition("Update_Attach_Insp_Item", MPGC.MP_STEP_DELETE) == true)
                {
                    
                    if (Update_Attach_Insp_Item(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    
                    if (CheckCondition("View_Insp_Item_List_By_InspSet", MPGC.MP_STEP_CREATE) == true)
                    {
                        View_Insp_Item_List_By_InspSet(cdvInspSet.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 0)));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
        
        private void spdInspItem_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            spdInspItem.Sheets[0].SetValue(e.Row, 0, true);
        }
        
        private void spdInspItem_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            int i;
            ComboBoxCellType cCell = new ComboBoxCellType();
            
            try
            {
                
                if (e.Column == 1 && e.EditingControl.Text != "")
                {
                    for (i = 0; i < ls_insp_item.Count; i++)
                    {
                        if (e.EditingControl.Text == ls_insp_item[i].s_item)
                        {
                            //spdInspItem.Sheets[0].SetValue(e.Row, 2, ls_insp_item[i].s_desc);

                            View_Inspection_Item(e.Row);

                            break;
                            //spdCharacter.Sheets(0).SetValue(e.Row, SPEC_TYPE, "Both")
                            //spdCharacter.Sheets(0).SetValue(e.Row, R_SPEC_TYPE, "Both")
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
