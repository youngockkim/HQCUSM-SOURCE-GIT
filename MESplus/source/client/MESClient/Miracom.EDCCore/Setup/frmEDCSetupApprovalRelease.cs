
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

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCSetupApprovalRelease.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  CheckCondition() : Check the conditions before transaction
//       -  View_Col_Set_Version_List() : View Collection Set Version
//       -  View_Attach_Character_List() : View Character List by Collection Set
//       -  Update_Attach_Character() : Create/Update/Delete Character
//       -  Update_Col_Set_Version() : Approval & Release Update
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-25 : Created by W.Y. Choi
//       - 2008-01-14 : Modified by LAVERWON : 
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.EDCCore
{
    public class frmEDCSetupApprovalRelease : Miracom.MESCore.SetupForm01
    {
        
#if _EDC
        
#region " Windows Form auto generated code "
        
        public frmEDCSetupApprovalRelease()
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
        private System.Windows.Forms.GroupBox grpOption;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCollectionSet;
        private System.Windows.Forms.Label lblCollectionSet;
        private System.Windows.Forms.Panel pnlVersion;
        private FarPoint.Win.Spread.FpSpread spdVersion;
        private Splitter spCenter;
        private FpSpread spdCharacter;
        private SheetView spdCharacter_Sheet1;
        private Panel pnlCharacter;
        public Button btnExcel;
        protected Button btnRefresh;
        private FarPoint.Win.Spread.SheetView spdVersion_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEDCSetupApprovalRelease));
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvCollectionSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCollectionSet = new System.Windows.Forms.Label();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.spdVersion = new FarPoint.Win.Spread.FpSpread();
            this.spdVersion_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spCenter = new System.Windows.Forms.Splitter();
            this.spdCharacter = new FarPoint.Win.Spread.FpSpread();
            this.spdCharacter_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlCharacter = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrp.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).BeginInit();
            this.pnlVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter_Sheet1)).BeginInit();
            this.pnlCharacter.SuspendLayout();
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
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 516);
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.pnlBottom.Size = new System.Drawing.Size(742, 37);
            this.pnlBottom.TabIndex = 3;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRefresh, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlCharacter);
            this.pnlCenter.Controls.Add(this.spCenter);
            this.pnlCenter.Controls.Add(this.pnlVersion);
            this.pnlCenter.Location = new System.Drawing.Point(0, 47);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 469);
            this.pnlCenter.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Approval And Release Collection Set Version";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
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
            this.grpOption.Controls.Add(this.cdvCollectionSet);
            this.grpOption.Controls.Add(this.lblCollectionSet);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 47);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // cdvCollectionSet
            // 
            this.cdvCollectionSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvCollectionSet.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCollectionSet.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCollectionSet.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCollectionSet.BtnToolTipText = "";
            this.cdvCollectionSet.DescText = "";
            this.cdvCollectionSet.DisplaySubItemIndex = 0;
            this.cdvCollectionSet.DisplayText = "";
            this.cdvCollectionSet.Focusing = null;
            this.cdvCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCollectionSet.Index = 0;
            this.cdvCollectionSet.IsViewBtnImage = false;
            this.cdvCollectionSet.Location = new System.Drawing.Point(120, 16);
            this.cdvCollectionSet.MaxLength = 25;
            this.cdvCollectionSet.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCollectionSet.Name = "cdvCollectionSet";
            this.cdvCollectionSet.ReadOnly = false;
            this.cdvCollectionSet.SearchSubItemIndex = 0;
            this.cdvCollectionSet.SelectedDescIndex = 1;
            this.cdvCollectionSet.SelectedSubItemIndex = 0;
            this.cdvCollectionSet.SelectionStart = 0;
            this.cdvCollectionSet.Size = new System.Drawing.Size(607, 20);
            this.cdvCollectionSet.SmallImageList = null;
            this.cdvCollectionSet.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCollectionSet.TabIndex = 1;
            this.cdvCollectionSet.TextBoxToolTipText = "";
            this.cdvCollectionSet.TextBoxWidth = 200;
            this.cdvCollectionSet.VisibleButton = true;
            this.cdvCollectionSet.VisibleColumnHeader = false;
            this.cdvCollectionSet.VisibleDescription = true;
            this.cdvCollectionSet.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCollectionSet_SelectedItemChanged);
            this.cdvCollectionSet.ButtonPress += new System.EventHandler(this.cdvCollectionSet_ButtonPress);
            this.cdvCollectionSet.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCollectionSet_TextBoxKeyPress);
            this.cdvCollectionSet.TextBoxTextChanged += new System.EventHandler(this.cdvCollectionSet_TextBoxTextChanged);
            // 
            // lblCollectionSet
            // 
            this.lblCollectionSet.AutoSize = true;
            this.lblCollectionSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectionSet.Location = new System.Drawing.Point(15, 19);
            this.lblCollectionSet.Name = "lblCollectionSet";
            this.lblCollectionSet.Size = new System.Drawing.Size(86, 13);
            this.lblCollectionSet.TabIndex = 0;
            this.lblCollectionSet.Text = "Collection Set";
            // 
            // pnlVersion
            // 
            this.pnlVersion.Controls.Add(this.spdVersion);
            this.pnlVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlVersion.Location = new System.Drawing.Point(3, 3);
            this.pnlVersion.Name = "pnlVersion";
            this.pnlVersion.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlVersion.Size = new System.Drawing.Size(736, 133);
            this.pnlVersion.TabIndex = 1;
            // 
            // spdVersion
            // 
            this.spdVersion.AccessibleDescription = "spdVersion, Sheet1, Row 0, Column 0, ";
            this.spdVersion.BackColor = System.Drawing.SystemColors.Control;
            this.spdVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdVersion.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdVersion.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.HorizontalScrollBar.Name = "";
            this.spdVersion.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdVersion.HorizontalScrollBar.TabIndex = 2;
            this.spdVersion.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdVersion.Location = new System.Drawing.Point(3, 3);
            this.spdVersion.Name = "spdVersion";
            this.spdVersion.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdVersion.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdVersion.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdVersion.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdVersion_Sheet1});
            this.spdVersion.Size = new System.Drawing.Size(730, 130);
            this.spdVersion.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdVersion.TabIndex = 0;
            this.spdVersion.TabStop = false;
            this.spdVersion.TextTipDelay = 200;
            this.spdVersion.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdVersion.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.VerticalScrollBar.Name = "";
            this.spdVersion.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdVersion.VerticalScrollBar.TabIndex = 3;
            this.spdVersion.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdVersion.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdVersion_SelectionChanged);
            this.spdVersion.SetViewportLeftColumn(0, 0, 1);
            this.spdVersion.SetActiveViewport(0, -1, -1);
            // 
            // spdVersion_Sheet1
            // 
            this.spdVersion_Sheet1.Reset();
            spdVersion_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdVersion_Sheet1.ColumnCount = 9;
            spdVersion_Sheet1.RowCount = 0;
            this.spdVersion_Sheet1.ActiveColumnIndex = -1;
            this.spdVersion_Sheet1.ActiveRowIndex = -1;
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
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Release";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "User ID";
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Release Time";
            this.spdVersion_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdVersion_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdVersion_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(0).Label = "Version";
            this.spdVersion_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(0).Width = 45F;
            this.spdVersion_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(1).Label = "Apply Start Time";
            this.spdVersion_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(1).Width = 110F;
            this.spdVersion_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(2).Label = "Apply End Time";
            this.spdVersion_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(2).Width = 110F;
            this.spdVersion_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(3).Label = "Approval";
            this.spdVersion_Sheet1.Columns.Get(3).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(3).Width = 55F;
            this.spdVersion_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(4).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(4).Width = 80F;
            this.spdVersion_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(5).Label = "Approval Time";
            this.spdVersion_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(5).Width = 110F;
            this.spdVersion_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdVersion_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Label = "Release";
            this.spdVersion_Sheet1.Columns.Get(6).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Width = 50F;
            this.spdVersion_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(7).Label = "User ID";
            this.spdVersion_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(7).Width = 80F;
            this.spdVersion_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdVersion_Sheet1.Columns.Get(8).Label = "Release Time";
            this.spdVersion_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(8).Width = 110F;
            this.spdVersion_Sheet1.FrozenColumnCount = 1;
            this.spdVersion_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdVersion_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdVersion_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdVersion_Sheet1.RowHeader.Visible = false;
            this.spdVersion_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdVersion_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdVersion_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdVersion_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdVersion_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdVersion_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spCenter
            // 
            this.spCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.spCenter.Location = new System.Drawing.Point(3, 136);
            this.spCenter.Name = "spCenter";
            this.spCenter.Size = new System.Drawing.Size(736, 4);
            this.spCenter.TabIndex = 0;
            this.spCenter.TabStop = false;
            // 
            // spdCharacter
            // 
            this.spdCharacter.AccessibleDescription = "spdCharacter, Sheet1, Row 0, Column 0, ";
            this.spdCharacter.BackColor = System.Drawing.SystemColors.Control;
            this.spdCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCharacter.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdCharacter.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCharacter.HorizontalScrollBar.Name = "";
            this.spdCharacter.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCharacter.HorizontalScrollBar.TabIndex = 4;
            this.spdCharacter.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCharacter.Location = new System.Drawing.Point(0, 0);
            this.spdCharacter.Name = "spdCharacter";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer1;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer1;
            namedStyle2.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle3.BackColor = System.Drawing.SystemColors.Control;
            namedStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = cornerRenderer1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle4.BackColor = System.Drawing.SystemColors.Window;
            namedStyle4.CellType = generalCellType1;
            namedStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle4.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle4.Renderer = generalCellType1;
            this.spdCharacter.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdCharacter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdCharacter.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdCharacter.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdCharacter.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.Rows;
            this.spdCharacter.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCharacter_Sheet1});
            this.spdCharacter.Size = new System.Drawing.Size(736, 329);
            this.spdCharacter.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCharacter.TabIndex = 1;
            this.spdCharacter.TabStop = false;
            this.spdCharacter.TextTipDelay = 200;
            this.spdCharacter.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdCharacter.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCharacter.VerticalScrollBar.Name = "";
            this.spdCharacter.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCharacter.VerticalScrollBar.TabIndex = 5;
            this.spdCharacter.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCharacter.SetViewportLeftColumn(0, 0, 2);
            this.spdCharacter.SetActiveViewport(0, -1, -1);
            // 
            // spdCharacter_Sheet1
            // 
            this.spdCharacter_Sheet1.Reset();
            spdCharacter_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCharacter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCharacter_Sheet1.ColumnCount = 24;
            spdCharacter_Sheet1.RowCount = 0;
            this.spdCharacter_Sheet1.ActiveColumnIndex = -1;
            this.spdCharacter_Sheet1.ActiveRowIndex = -1;
            this.spdCharacter_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdCharacter_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCharacter_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Character";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Description";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Unit Count";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Value Count";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Display Precision";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Value Table";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Default Value";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Option Input";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Blank Save";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Default Unit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Default Unit Ovr.";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Unit Table";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Spec. Type";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Spec. Out Count";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Target Value";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Upper Spec. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Lower Spec. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Upper Warn. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lower Warn. Limit";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Spec. Information";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Spec. Out Alarm Code";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Warn. Out Alarm Code";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Derived Parameter Flag";
            this.spdCharacter_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Derived Parameter";
            this.spdCharacter_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCharacter_Sheet1.ColumnHeader.Rows.Get(0).Height = 32F;
            this.spdCharacter_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(0).Label = "Character";
            this.spdCharacter_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(0).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(1).Label = "Description";
            this.spdCharacter_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(1).Width = 120F;
            this.spdCharacter_Sheet1.Columns.Get(2).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(2).Label = "Unit Count";
            this.spdCharacter_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(2).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(3).Label = "Value Count";
            this.spdCharacter_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(3).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(4).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(4).Label = "Display Precision";
            this.spdCharacter_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(4).Width = 55F;
            this.spdCharacter_Sheet1.Columns.Get(5).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(5).Label = "Value Table";
            this.spdCharacter_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(5).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(6).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(6).Label = "Default Value";
            this.spdCharacter_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(6).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(7).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(7).Label = "Option Input";
            this.spdCharacter_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(7).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(8).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(8).Label = "Blank Save";
            this.spdCharacter_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(8).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(9).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(9).Label = "Default Unit";
            this.spdCharacter_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(9).Width = 45F;
            this.spdCharacter_Sheet1.Columns.Get(10).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(10).Label = "Default Unit Ovr.";
            this.spdCharacter_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(10).Width = 55F;
            this.spdCharacter_Sheet1.Columns.Get(11).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(11).Label = "Unit Table";
            this.spdCharacter_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(11).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(12).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(12).Label = "Spec. Type";
            this.spdCharacter_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(12).Width = 40F;
            this.spdCharacter_Sheet1.Columns.Get(13).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(13).Label = "Spec. Out Count";
            this.spdCharacter_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(14).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(14).Label = "Target Value";
            this.spdCharacter_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(14).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(15).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(15).Label = "Upper Spec. Limit";
            this.spdCharacter_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(15).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(16).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(16).Label = "Lower Spec. Limit";
            this.spdCharacter_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(16).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(17).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(17).Label = "Upper Warn. Limit";
            this.spdCharacter_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(17).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(18).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdCharacter_Sheet1.Columns.Get(18).Label = "Lower Warn. Limit";
            this.spdCharacter_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(18).Width = 100F;
            this.spdCharacter_Sheet1.Columns.Get(19).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(19).Label = "Spec. Information";
            this.spdCharacter_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(19).Width = 200F;
            this.spdCharacter_Sheet1.Columns.Get(20).Label = "Spec. Out Alarm Code";
            this.spdCharacter_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(20).Width = 80F;
            this.spdCharacter_Sheet1.Columns.Get(21).Label = "Warn. Out Alarm Code";
            this.spdCharacter_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(21).Width = 80F;
            this.spdCharacter_Sheet1.Columns.Get(22).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(22).Label = "Derived Parameter Flag";
            this.spdCharacter_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(22).Width = 80F;
            this.spdCharacter_Sheet1.Columns.Get(23).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdCharacter_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdCharacter_Sheet1.Columns.Get(23).Label = "Derived Parameter";
            this.spdCharacter_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCharacter_Sheet1.Columns.Get(23).Width = 200F;
            this.spdCharacter_Sheet1.FrozenColumnCount = 2;
            this.spdCharacter_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdCharacter_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCharacter_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCharacter_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCharacter_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCharacter_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlCharacter
            // 
            this.pnlCharacter.Controls.Add(this.spdCharacter);
            this.pnlCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacter.Location = new System.Drawing.Point(3, 140);
            this.pnlCharacter.Name = "pnlCharacter";
            this.pnlCharacter.Size = new System.Drawing.Size(736, 329);
            this.pnlCharacter.TabIndex = 2;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(42, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmEDCSetupApprovalRelease
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmEDCSetupApprovalRelease";
            this.Text = "Approval And Release Collection Set Version";
            this.Activated += new System.EventHandler(this.frmEDCSetupApprovalRelease_Activated);
            this.Load += new System.EventHandler(this.frmEDCSetupApprovalRelease_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCollectionSet)).EndInit();
            this.pnlVersion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCharacter_Sheet1)).EndInit();
            this.pnlCharacter.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Constant Defintion"
        
        //spdCharacter
        private const int CHAR_ID = 0;
        private const int UNIT_COUNT = 2;
        
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
    
        private bool CheckCondition(string FuncName, char ProcStep)
        {

            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_Col_Set_Version":
                        if (cdvCollectionSet.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvCollectionSet.Focus();
                            return false;
                        }
                        
                        if (spdVersion.Sheets[0].RowCount == 0 || spdVersion.Sheets[0].SelectionCount == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(152));
                            return false;
                        }
                        
                        if (spdCharacter.Sheets[0].RowCount <= 0)
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
                
                    case "View_Col_Set_Version_List":
                        
                        if (cdvCollectionSet.Text != "")
                        {
                            return true;
                        }
                        
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;

                    case "View_Attach_Character_List":

                        if (cdvCollectionSet.Text != "")
                        {
                            if (MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 0)) != "")
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
                
            //Update_Col_Set_Version()
            //      - Approval & Release Update
            //Return Value
            //      - Boolean : True or False
            //Arguments
            //      - ByVal ProcStep As String (MP_STEP_CREATE - Create, MP_STEP_UPDATE - Update, MP_STEP_DELETE - Delete)
            
            private bool Update_Col_Set_Version(char ProcStep)
            {
                TRSNode in_node = new TRSNode("UPDATE_COL_SET_VERSION_IN");
                TRSNode out_node = new TRSNode("CMN_OUT");
                
                try
                {
                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = ProcStep;
                    in_node.AddString("COL_SET_ID", cdvCollectionSet.Text);
                    in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 0)));
                    in_node.AddString("APPLY_START_TIME", MPCF.DestroyDateFormat(MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 1))));
                    in_node.AddString("APPLY_END_TIME", MPCF.DestroyDateFormat(MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 2))));

                    
                    if (ProcStep == MPGC.MP_STEP_APPROVAL)
                    {
                        in_node.AddChar("APPROVAL_FLAG", 'Y');
                    }
                    
                    if (ProcStep == MPGC.MP_STEP_RELEASE)
                    {
                        in_node.AddChar("RELEASE_FLAG", 'Y');
                        in_node.AddChar("APPROVAL_FLAG", MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 3)) == "V" ? 'Y' : ' ');                        
                    }
                    
                    if (ProcStep == MPGC.MP_STEP_CANCEL_APPROVAL)
                    {
                        in_node.AddChar("APPROVAL_FLAG", ' ');
                    }

                    if (MPCR.CallService("EDC", "EDC_Approval_And_Release_to_Version", in_node, ref out_node) == false)
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
                    return this.cdvCollectionSet;
                    
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return null;
                }
                
            }
                
#endregion
                
        private void frmEDCSetupApprovalRelease_Load(object sender, System.EventArgs e)
        {
            
            try
            {                
                MPCF.FieldClear(this);
                
                MPCF.ClearList(spdVersion, true);
                MPCF.ClearList(spdCharacter, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void frmEDCSetupApprovalRelease_Activated(object sender, System.EventArgs e)
        {
            
            try
            {
                if (LoadFlag == false)
                {
                    if (EDCLIST.ViewEDCColSetList(cdvCollectionSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
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
        
        private void cdvCollectionSet_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                //Initialize ListView
                cdvCollectionSet.Init();
                MPCF.InitListView(cdvCollectionSet.GetListView);
                cdvCollectionSet.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
                cdvCollectionSet.Columns.Add("Description", 100, HorizontalAlignment.Left);
                cdvCollectionSet.SelectedSubItemIndex = 0;
                
                if (EDCLIST.ViewEDCColSetList(cdvCollectionSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCollectionSet_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdVersion, true);
                if (CheckCondition("View_Col_Set_Version_List", MPGC.MP_STEP_CREATE) == true)
                {
                    if (EDCLIST.ViewEDCColSetVersionList(spdVersion, MPCF.Trim(cdvCollectionSet.Text), '2') == false)
                    {
                        return;
                    }

                    MPCF.FitColumnHeader(spdVersion);
                }

                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);

                MPCF.ClearList(spdCharacter);
                
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
                if ((MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 3)) != ""))
                {
                    btnCreate.Enabled = false;

                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnCreate, true);

                    btnDelete.Enabled = false;
                    
                }

                if ((MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 6)) != ""))
                {
                    btnCreate.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                }
                
                if (CheckCondition("View_Attach_Character_List", MPGC.MP_STEP_CREATE) == true)
                {
                    EDCLIST.ViewAttachCharacterListToVersion(spdCharacter, cdvCollectionSet.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 0)), 'N');

                    MPCF.FitColumnHeader(spdCharacter);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void Release_Click(System.Object sender, System.EventArgs e)
        {
          
            try
            {
                if (CheckCondition("Update_Col_Set_Version", MPGC.MP_STEP_RELEASE) == true)
                {

                    if (Update_Col_Set_Version(MPGC.MP_STEP_RELEASE) == false)
                    {
                        return;
                    }
                    if (EDCLIST.ViewEDCColSetVersionList(spdVersion, MPCF.Trim(cdvCollectionSet.Text), '2') == false)
                    {
                        return;
                    }

                    MPCF.FitColumnHeader(spdVersion);

                    btnCreate.Enabled = false;
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void Approval_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("Update_Col_Set_Version", MPGC.MP_STEP_APPROVAL) == true)
                {

                    if (Update_Col_Set_Version(MPGC.MP_STEP_APPROVAL) == false)
                    {
                        return;
                    }
                    if (EDCLIST.ViewEDCColSetVersionList(spdVersion, MPCF.Trim(cdvCollectionSet.Text), '2') == false)
                    {
                        return;
                    }

                    MPCF.FitColumnHeader(spdVersion);

                    btnCreate.Enabled = false;

                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void Cancel_Approval_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("Update_Col_Set_Version", MPGC.MP_STEP_CANCEL_APPROVAL) == true)
                {

                    if (Update_Col_Set_Version(MPGC.MP_STEP_CANCEL_APPROVAL) == true)
                    {
                        if (EDCLIST.ViewEDCColSetVersionList(spdVersion, MPCF.Trim(cdvCollectionSet.Text), '2') == false)
                        {
                            return;
                        }

                        MPCF.FitColumnHeader(spdVersion);

                        MPCR.ChangeControlEnabled(this, btnCreate, true);
                        btnDelete.Enabled = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCollectionSet_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == (char)13)
                {
                    if (cdvCollectionSet.Text != "")
                    {
                        cdvCollectionSet_SelectedItemChanged(sender, null);
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvCollectionSet_TextBoxTextChanged(object sender, System.EventArgs e)
        {

            try
            {
                MPCF.ClearList(spdVersion, true);
                MPCF.ClearList(spdCharacter, true);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                sCond = "Collection Set : " + cdvCollectionSet.Text;

                MPCF.ExportToExcel(spdCharacter, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdVersion, true);
                if (CheckCondition("View_Col_Set_Version_List", MPGC.MP_STEP_CREATE) == true)
                {
                    if (EDCLIST.ViewEDCColSetVersionList(spdVersion, MPCF.Trim(cdvCollectionSet.Text), '2') == false)
                    {
                        return;
                    }

                    MPCF.FitColumnHeader(spdVersion);
                }

                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);

                MPCF.ClearList(spdCharacter);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

#endif // _EDC
    }        
}
