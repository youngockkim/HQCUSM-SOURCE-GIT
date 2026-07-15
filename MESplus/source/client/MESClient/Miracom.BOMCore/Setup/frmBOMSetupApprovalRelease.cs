
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using FarPoint.Win.Spread;
using Miracom.UI.Controls;
using Miracom.CliFrx;

using Miracom.TRSCore;
//'#If _BOM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBOMSetupApprovalRelease.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  CheckCondition() : Check the conditions before transaction
//       -  View_BOMSet_Version_List() : View BOM Set Version
//       -  View_Attach_Material_List() : View Material List by BOM Set
//       -  Update_Attach_Material() : Create/Update/Delete Material
//       -  Update_BOMSet_Version() : Approval & Release Update
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-21 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.BOMCore
{
    public class frmBOMSetupApprovalRelease : Miracom.MESCore.SetupForm01
    {

        #region " Windows Form auto generated code "

        public frmBOMSetupApprovalRelease()
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




        private System.Windows.Forms.GroupBox grpOption;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvBOMSet;
        private System.Windows.Forms.Label lblBOMSet;
        private System.Windows.Forms.Panel pnlVersion;
        private FarPoint.Win.Spread.FpSpread spdVersion;
        private FarPoint.Win.Spread.SheetView spdVersion_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdMaterial;
        private FarPoint.Win.Spread.SheetView spdMaterial_Sheet1;
        public Button btnExcel;
        private System.Windows.Forms.Panel pnlBomSetID;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBOMSetupApprovalRelease));
            this.pnlBomSetID = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvBOMSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblBOMSet = new System.Windows.Forms.Label();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.spdVersion = new FarPoint.Win.Spread.FpSpread();
            this.spdVersion_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdMaterial = new FarPoint.Win.Spread.FpSpread();
            this.spdMaterial_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBomSetID.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSet)).BeginInit();
            this.pnlVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMaterial_Sheet1)).BeginInit();
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 3;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.spdMaterial);
            this.pnlCenter.Location = new System.Drawing.Point(0, 177);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 336);
            this.pnlCenter.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Approval And Release BOM Set Version";
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
            this.grpOption.Controls.Add(this.cdvBOMSet);
            this.grpOption.Controls.Add(this.lblBOMSet);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 47);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            this.grpOption.Tag = "";
            // 
            // cdvBOMSet
            // 
            this.cdvBOMSet.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvBOMSet.BorderHotColor = System.Drawing.Color.Black;
            this.cdvBOMSet.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvBOMSet.BtnToolTipText = "";
            this.cdvBOMSet.DescText = "";
            this.cdvBOMSet.DisplaySubItemIndex = -1;
            this.cdvBOMSet.DisplayText = "";
            this.cdvBOMSet.Focusing = null;
            this.cdvBOMSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvBOMSet.Index = 0;
            this.cdvBOMSet.IsViewBtnImage = false;
            this.cdvBOMSet.Location = new System.Drawing.Point(120, 16);
            this.cdvBOMSet.MaxLength = 25;
            this.cdvBOMSet.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvBOMSet.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvBOMSet.Name = "cdvBOMSet";
            this.cdvBOMSet.ReadOnly = false;
            this.cdvBOMSet.SearchSubItemIndex = 0;
            this.cdvBOMSet.SelectedDescIndex = -1;
            this.cdvBOMSet.SelectedSubItemIndex = -1;
            this.cdvBOMSet.SelectionStart = 0;
            this.cdvBOMSet.Size = new System.Drawing.Size(200, 20);
            this.cdvBOMSet.SmallImageList = null;
            this.cdvBOMSet.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvBOMSet.TabIndex = 0;
            this.cdvBOMSet.TextBoxToolTipText = "";
            this.cdvBOMSet.TextBoxWidth = 200;
            this.cdvBOMSet.VisibleButton = true;
            this.cdvBOMSet.VisibleColumnHeader = false;
            this.cdvBOMSet.VisibleDescription = false;
            this.cdvBOMSet.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvBOMSet_SelectedItemChanged);
            this.cdvBOMSet.ButtonPress += new System.EventHandler(this.cdvBOMSet_ButtonPress);
            this.cdvBOMSet.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvBOMSet_TextBoxKeyPress);
            this.cdvBOMSet.TextBoxTextChanged += new System.EventHandler(this.cdvBOMSet_TextBoxTextChanged);
            // 
            // lblBOMSet
            // 
            this.lblBOMSet.AutoSize = true;
            this.lblBOMSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBOMSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMSet.Location = new System.Drawing.Point(15, 19);
            this.lblBOMSet.Name = "lblBOMSet";
            this.lblBOMSet.Size = new System.Drawing.Size(78, 13);
            this.lblBOMSet.TabIndex = 0;
            this.lblBOMSet.Text = "BOM Set ID ";
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
            this.spdVersion.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
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
            this.spdVersion.TabIndex = 0;
            this.spdVersion.TabStop = false;
            this.spdVersion.TextTipDelay = 200;
            this.spdVersion.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdVersion.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdVersion.VerticalScrollBar.Name = "";
            this.spdVersion.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
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
            this.spdVersion_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Release_bom";
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
            this.spdVersion_Sheet1.Columns.Get(6).Label = "Release_bom";
            this.spdVersion_Sheet1.Columns.Get(6).Locked = true;
            this.spdVersion_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdVersion_Sheet1.Columns.Get(6).Width = 87F;
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
            this.spdVersion_Sheet1.RowHeader.Visible = false;
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
            // spdMaterial
            // 
            this.spdMaterial.AccessibleDescription = "spdMaterial, Sheet1, Row 0, Column 0, ";
            this.spdMaterial.BackColor = System.Drawing.SystemColors.Control;
            this.spdMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdMaterial.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdMaterial.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMaterial.HorizontalScrollBar.Name = "";
            this.spdMaterial.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdMaterial.HorizontalScrollBar.TabIndex = 2;
            this.spdMaterial.Location = new System.Drawing.Point(3, 3);
            this.spdMaterial.Name = "spdMaterial";
            this.spdMaterial.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdMaterial.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdMaterial.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdMaterial_Sheet1});
            this.spdMaterial.Size = new System.Drawing.Size(736, 333);
            this.spdMaterial.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMaterial.TabIndex = 0;
            this.spdMaterial.TabStop = false;
            this.spdMaterial.TextTipDelay = 200;
            this.spdMaterial.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMaterial.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMaterial.VerticalScrollBar.Name = "";
            this.spdMaterial.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdMaterial.VerticalScrollBar.TabIndex = 3;
            this.spdMaterial.SetViewportLeftColumn(0, 0, 2);
            this.spdMaterial.SetActiveViewport(0, 0, -1);
            // 
            // spdMaterial_Sheet1
            // 
            this.spdMaterial_Sheet1.Reset();
            spdMaterial_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMaterial_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMaterial_Sheet1.ColumnCount = 24;
            spdMaterial_Sheet1.RowCount = 5;
            this.spdMaterial_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdMaterial_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMaterial_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMaterial_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMaterial_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Mat ID";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Version";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat Qty";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Part Grp";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Alt mat Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Mat Unit";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Opt Input Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Auto Input Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = " Serial Input Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = " Serial Type";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Chk Serial Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Flow";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Oper";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Part CMF1";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Part CMF2";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Part CMF3";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Part CMF4";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Part CMF5";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Part CMF6";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Part CMF7";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Part CMF8";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Part CMF9";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Part CMF10";
            this.spdMaterial_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMaterial_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMaterial_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdMaterial_Sheet1.Columns.Get(0).CellType = textCellType1;
            this.spdMaterial_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(0).Label = "Mat ID";
            this.spdMaterial_Sheet1.Columns.Get(0).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(0).Width = 96F;
            this.spdMaterial_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(1).Label = "Version";
            this.spdMaterial_Sheet1.Columns.Get(1).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(1).Width = 45F;
            this.spdMaterial_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(2).Label = "Description";
            this.spdMaterial_Sheet1.Columns.Get(2).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(2).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMaterial_Sheet1.Columns.Get(3).Label = "Mat Qty";
            this.spdMaterial_Sheet1.Columns.Get(3).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(3).Width = 64F;
            this.spdMaterial_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(4).Label = "Part Grp";
            this.spdMaterial_Sheet1.Columns.Get(4).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(4).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(5).Label = "Alt mat Flag";
            this.spdMaterial_Sheet1.Columns.Get(5).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(5).Width = 76F;
            this.spdMaterial_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(6).Label = "Mat Unit";
            this.spdMaterial_Sheet1.Columns.Get(6).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(6).Width = 71F;
            this.spdMaterial_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(7).Label = "Opt Input Flag";
            this.spdMaterial_Sheet1.Columns.Get(7).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(7).Width = 90F;
            this.spdMaterial_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(8).Label = "Auto Input Flag";
            this.spdMaterial_Sheet1.Columns.Get(8).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(8).Width = 95F;
            this.spdMaterial_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(9).Label = " Serial Input Flag";
            this.spdMaterial_Sheet1.Columns.Get(9).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(9).Width = 104F;
            this.spdMaterial_Sheet1.Columns.Get(10).CellType = textCellType2;
            this.spdMaterial_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(10).Label = " Serial Type";
            this.spdMaterial_Sheet1.Columns.Get(10).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(10).Width = 106F;
            this.spdMaterial_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(11).Label = "Chk Serial Flag";
            this.spdMaterial_Sheet1.Columns.Get(11).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(11).Width = 98F;
            this.spdMaterial_Sheet1.Columns.Get(12).Label = "Flow";
            this.spdMaterial_Sheet1.Columns.Get(12).Width = 107F;
            this.spdMaterial_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(13).Label = "Oper";
            this.spdMaterial_Sheet1.Columns.Get(13).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(13).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(14).Label = "Part CMF1";
            this.spdMaterial_Sheet1.Columns.Get(14).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(14).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(15).Label = "Part CMF2";
            this.spdMaterial_Sheet1.Columns.Get(15).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(15).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(16).Label = "Part CMF3";
            this.spdMaterial_Sheet1.Columns.Get(16).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(16).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(17).Label = "Part CMF4";
            this.spdMaterial_Sheet1.Columns.Get(17).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(17).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(18).Label = "Part CMF5";
            this.spdMaterial_Sheet1.Columns.Get(18).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(18).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(19).Label = "Part CMF6";
            this.spdMaterial_Sheet1.Columns.Get(19).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(19).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(20).Label = "Part CMF7";
            this.spdMaterial_Sheet1.Columns.Get(20).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(20).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(21).Label = "Part CMF8";
            this.spdMaterial_Sheet1.Columns.Get(21).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(21).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(22).Label = "Part CMF9";
            this.spdMaterial_Sheet1.Columns.Get(22).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(22).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(23).Label = "Part CMF10";
            this.spdMaterial_Sheet1.Columns.Get(23).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(23).Width = 80F;
            this.spdMaterial_Sheet1.FrozenColumnCount = 2;
            this.spdMaterial_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdMaterial_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdMaterial_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMaterial_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdMaterial_Sheet1.Rows.Get(0).Height = 18F;
            this.spdMaterial_Sheet1.Rows.Get(1).Height = 18F;
            this.spdMaterial_Sheet1.Rows.Get(2).Height = 18F;
            this.spdMaterial_Sheet1.Rows.Get(3).Height = 18F;
            this.spdMaterial_Sheet1.Rows.Get(4).Height = 18F;
            this.spdMaterial_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdMaterial_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMaterial_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdMaterial_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdMaterial_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmBOMSetupApprovalRelease
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlVersion);
            this.Controls.Add(this.pnlBomSetID);
            this.Name = "frmBOMSetupApprovalRelease";
            this.Text = "Approval And Release Setup";
            this.Activated += new System.EventHandler(this.frmBOMSetupApprovalRelease_Activated);
            this.Load += new System.EventHandler(this.frmBOMSetupApprovalRelease_Load);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlBomSetID, 0);
            this.Controls.SetChildIndex(this.pnlVersion, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBomSetID.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSet)).EndInit();
            this.pnlVersion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMaterial_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Variable Definition"

        bool b_load_flag;

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
                    case "Update_BOMSet_Version":


                        if (cdvBOMSet.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            cdvBOMSet.Focus();
                            return false;
                        }

                        if (spdVersion.Sheets[0].RowCount == 0 || spdVersion.Sheets[0].SelectionCount == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(152));
                            return false;
                        }

                        if (spdMaterial.Sheets[0].RowCount <= 0)
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

                    case "View_BOMSet_Version_List":

                        if (cdvBOMSet.Text != "")
                        {
                            return true;
                        }

                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        return false;

                    //                        case "View_Attach_Material_List":
                    //                        
                    //                        if (cdvBOMSet.Text != "")
                    //                        {
                    //                            if (spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRow.Index, 0) != "")
                    //                            {
                    //                                return true;
                    //                                }
                    //                                }

                    //                                modCommonFunction.ShowMsgBox(modLanguageFunction.GetMessage(108));
                    //                                return false;

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // View_BOMSet_Version_List()
        //       - View BOM Set Version
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - Optional ByVal c_step As String = "1"
        //       - ByVal sColSetId As String

        private bool View_BOMSet_Version_List(string sBOMSetId, char c_step)
        {

            int i;
            int LastRow = 0;

            TRSNode in_node = new TRSNode("VIEW_BOM_SET_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BOM_SET_VERSION_LIST_OUT");


            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("BOM_SET_ID", sBOMSetId);
                in_node.AddInt("NEXT_BOM_SET_VERSION", int.MaxValue);

                do
                {
                    if (MPCR.CallService("BOM", "BOM_View_BOMSet_Version_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    spdVersion.Sheets[0].RowCount = out_node.GetList(0).Count;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        FarPoint.Win.Spread.SheetView with_1 = spdVersion.Sheets[0];

                        with_1.SetValue(LastRow, 0, out_node.GetList(0)[i].GetInt("BOM_SET_VERSION"));
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

                    in_node.SetInt("NEXT_BOM_SET_VERSION", out_node.GetInt("NEXT_BOM_SET_VERSION"));

                } while (in_node.GetInt("NEXT_BOM_SET_VERSION") > 0);

                MPCF.FitColumnHeader(spdVersion);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }


        }



        // View_Attach_Material_List()
        //       - View Material List by BOM Set
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal sColSetId As String                        : ColSet
        //        - ByVal sColSetVersion As String                : ColSetVersion
        //        -

        public bool View_Attach_Material_List(string sBOMSetId, string sBOMSetVersion)
        {

            int i;
            int LastRow = 0;


            TRSNode in_node = new TRSNode("VIEW_ATTACH_MATERIAL_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_MATERIAL_LIST_OUT");
            try
            {



                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';//c_step;
                in_node.AddString("BOM_SET_ID", sBOMSetId);
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(sBOMSetVersion));
                in_node.AddInt("NEXT_SEQ_NUM", 0);

                do
                {
                    if (MPCR.CallService("BOM", "BOM_View_Attach_Material_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }
                    spdMaterial.Sheets[0].RowCount = out_node.GetList(0).Count;

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        FarPoint.Win.Spread.SheetView with_1 = spdMaterial.Sheets[0];

                        with_1.SetValue(LastRow, 0, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")));
                        with_1.SetValue(LastRow, 1, out_node.GetList(0)[i].GetInt("MAT_VER"));
                        with_1.SetValue(LastRow, 2, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_DESC")));
                        with_1.SetValue(LastRow, 3,out_node.GetList(0)[i].GetDouble("MAT_QTY"));
                        with_1.SetValue(LastRow, 4, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_GRP")));
                        with_1.SetValue(LastRow, 5, MPCF.Trim(out_node.GetList(0)[i].GetChar("ALT_MAT_FLAG")));
                        with_1.SetValue(LastRow, 6, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_UNIT")));
                        with_1.SetValue(LastRow, 7, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("OPT_INPUT_FLAG")) == "Y") ? 'Y' : ' '));
                        with_1.SetValue(LastRow, 8, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("AUTO_INPUT_FLAG")) == "Y") ? 'Y' : ' '));
                        with_1.SetValue(LastRow, 9, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_INPUT_FLAG")) == "Y") ? 'Y' : ' '));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")) == "L")
                        {
                            with_1.SetValue(LastRow, 10, "Lot ID");
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")) == "M")
                        {
                            with_1.SetValue(LastRow, 10, "Material");
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")) == "S")
                        {
                            with_1.SetValue(LastRow, 10, "Sub Component");
                        }
                        with_1.SetValue(LastRow, 11, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_SERIAL_FLAG")) == "Y") ? 'Y' : ' '));
                        with_1.SetValue(LastRow, 12, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));
                        with_1.SetValue(LastRow, 13, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                        with_1.SetValue(LastRow, 14, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_1")));
                        with_1.SetValue(LastRow, 15, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_2")));
                        with_1.SetValue(LastRow, 16, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_3")));
                        with_1.SetValue(LastRow, 17, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_4")));
                        with_1.SetValue(LastRow, 18, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_5")));
                        with_1.SetValue(LastRow, 19, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_6")));
                        with_1.SetValue(LastRow, 20, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_7")));
                        with_1.SetValue(LastRow, 21, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_8")));
                        with_1.SetValue(LastRow, 22, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_9")));
                        with_1.SetValue(LastRow, 23, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_10")));


                        LastRow++;

                    }

                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

                } while (out_node.GetInt("NEXT_SEQ_NUM") != 0);

                MPCF.FitColumnHeader(spdMaterial);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }


        //Update_BOMSet_Version()
        //      - Approval & Release Update
        //Return Value
        //      - Boolean : True or False
        //Arguments
        //      - ByVal ProcStep As String (MP_STEP_CREATE - Create, MP_STEP_UPDATE - Update, MP_STEP_DELETE - Delete)

        private bool Update_BOMSet_Version(char ProcStep)
        {

            TRSNode in_node = new TRSNode("UPDATE_BOMSET_VERSION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BOM_SET_ID", cdvBOMSet.Text);
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 0)));
                in_node.AddString("APPLY_START_TIME", MPCF.DestroyDateFormat(MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 1))));
                in_node.AddString("APPLY_END_TIME", MPCF.DestroyDateFormat(MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 2))));


                if (ProcStep == MPGC.MP_STEP_APPROVAL)
                {
                    in_node.AddChar("APPROVAL_FLAG", 'Y');
                }

                if (ProcStep == MPGC.MP_STEP_RELEASE)
                {
                    in_node.AddChar("RELEASE_FLAG", 'Y');
                    in_node.AddChar("APPROVAL_FLAG", (MPCF.Trim(spdVersion.Sheets[0].GetValue(spdVersion.Sheets[0].ActiveRowIndex, 3)) == "V" ? 'Y' : ' '));
                }

                if (ProcStep == MPGC.MP_STEP_CANCEL_APPROVAL)
                {
                    in_node.AddChar("APPROVAL_FLAG", ' ');
                }

                if (MPCR.CallService("BOM", "BOM_Approval_And_Release_to_Version", in_node, ref out_node) == false)
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
            TRSNode out_node = new TRSNode("CMN_OUT");
            int i;

            try
            {
                for (i = 14; i <= 23; i++)
                {
                    spdMaterial.Sheets[0].ColumnHeader.Columns[i].Visible = false;
                }
                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_PART, ref out_node, "", true) == false)
                {
                    return;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        spdMaterial.Sheets[0].ColumnHeader.Columns[14 + i].Visible = true;
                        spdMaterial.Sheets[0].ColumnHeader.Cells[0, 14 + i].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT"));
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
                return this.cdvBOMSet;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmBOMSetupApprovalRelease_Load(object sender, System.EventArgs e)
        {
            try
            {

                MPCF.FieldClear(this);

                MPCF.ClearList(spdVersion, true);
                MPCF.ClearList(spdMaterial, true);
                MPCF.FitColumnHeader(spdVersion);
                MPCF.FitColumnHeader(spdMaterial);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void frmBOMSetupApprovalRelease_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    SetCmfItem();
                    b_load_flag = true;
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvBOMSet_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            try
            {
                MPCF.ClearList(spdVersion, true);
                if (CheckCondition("View_BOMSet_Version_List", MPGC.MP_STEP_CREATE) == true)
                {
                    if (View_BOMSet_Version_List(MPCF.Trim(cdvBOMSet.Text), '1') == false)
                    {
                        return;
                    }
                }

                MPCR.ChangeControlEnabled(this, btnCreate, true);
                MPCR.ChangeControlEnabled(this, btnUpdate, true);
                MPCR.ChangeControlEnabled(this, btnDelete, true);

                MPCF.ClearList(spdMaterial);

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

                if (CheckCondition("View_Attach_Material_List", MPGC.MP_STEP_CREATE) == true)
                {
                    View_Attach_Material_List(cdvBOMSet.Text, MPCF.Trim(spdVersion.Sheets[0].GetValue(e.Range.Row, 0)));
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void Release_Click(System.Object sender, System.EventArgs e)
        {

            if (CheckCondition("Update_BOMSet_Version", MPGC.MP_STEP_RELEASE) == true)
            {

                if (Update_BOMSet_Version(MPGC.MP_STEP_RELEASE) == false)
                {
                    return;
                }
                if (View_BOMSet_Version_List(MPCF.Trim(cdvBOMSet.Text), '1') == false)
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

            if (CheckCondition("Update_BOMSet_Version", MPGC.MP_STEP_APPROVAL) == true)
            {

                if (Update_BOMSet_Version(MPGC.MP_STEP_APPROVAL) == false)
                {
                    return;
                }
                if (View_BOMSet_Version_List(MPCF.Trim(cdvBOMSet.Text), '1') == false)
                {
                    return;
                }
                btnCreate.Enabled = false;
                btnDelete.Enabled = true;

            }

        }

        private void Cancel_Approval_Click(System.Object sender, System.EventArgs e)
        {

            if (CheckCondition("Update_BOMSet_Version", MPGC.MP_STEP_CANCEL_APPROVAL) == true)
            {

                if (Update_BOMSet_Version(MPGC.MP_STEP_CANCEL_APPROVAL) == true)
                {
                    if (View_BOMSet_Version_List(MPCF.Trim(cdvBOMSet.Text), '1') == false)
                    {
                        return;
                    }
                    btnCreate.Enabled = true;
                    btnDelete.Enabled = false;
                }
            }

        }

        private void cdvBOMSet_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            MPCF.ClearList(spdVersion, true);
            MPCF.ClearList(spdMaterial, true);
        }

        private void cdvBOMSet_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvBOMSet.Text != "")
                {
                    cdvBOMSet_SelectedItemChanged(sender, null);
                }
            }
        }

        private void cdvBOMSet_ButtonPress(object sender, System.EventArgs e)
        {
            cdvBOMSet.Init();
            cdvBOMSet.Columns.Add("BOM Set", 50, HorizontalAlignment.Left);
            cdvBOMSet.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvBOMSet.SelectedSubItemIndex = 0;
            if (BOMLIST.ViewBOMSetList(cdvBOMSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
            {
                return;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string sCond;

            try
            {
                sCond = "BOM Set : " + MPCF.Trim(cdvBOMSet.Text);
                MPCF.ExportToExcel(spdMaterial, this.Text, sCond);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
    //'#End If ' _BOM
}
