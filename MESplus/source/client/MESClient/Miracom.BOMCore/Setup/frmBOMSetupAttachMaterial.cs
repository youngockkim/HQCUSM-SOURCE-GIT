
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using FarPoint.Win.Spread;
using FarPoint.Win.Spread.CellType;
using Miracom.UI.Controls;
using Miracom.CliFrx;

using Miracom.TRSCore;

//'#If _BOM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBOMSetupAttachMaterial.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -  CheckCondition() : Check the conditions before transaction
//       -  View_BOMSet_Version_List() : View BOMSet Version
//       -  View_Material_List_By_BOMSet() : View Material List by BOM Set
//       -  Update_Attach_Material() : UpdateMaterial
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-22 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.BOMCore
{
    public class frmBOMSetupAttachMaterial : Miracom.MESCore.SetupForm01
    {

        #region " Windows Form auto generated code "

        public frmBOMSetupAttachMaterial()
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
        private System.Windows.Forms.Panel pnlVersion;
        private FarPoint.Win.Spread.FpSpread spdVersion;
        private FarPoint.Win.Spread.SheetView spdVersion_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvBOMSet;
        private System.Windows.Forms.Label lblBOMSet;
        private FarPoint.Win.Spread.FpSpread spdMaterial;
        private FarPoint.Win.Spread.SheetView spdMaterial_Sheet1;
        public Button btnExcel;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType3 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType4 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType5 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType6 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBOMSetupAttachMaterial));
            this.pnlGrp = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.cdvBOMSet = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblBOMSet = new System.Windows.Forms.Label();
            this.pnlVersion = new System.Windows.Forms.Panel();
            this.spdVersion = new FarPoint.Win.Spread.FpSpread();
            this.spdVersion_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdMaterial = new FarPoint.Win.Spread.FpSpread();
            this.spdMaterial_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlGrp.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSet)).BeginInit();
            this.pnlVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMaterial_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(374, 6);
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(558, 6);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(468, 6);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(650, 6);
            // 
            // pnlBottom
            // 
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
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.spdMaterial);
            this.pnlCenter.Location = new System.Drawing.Point(0, 177);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 339);
            this.pnlCenter.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Attach Material to Version";
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
            this.grpOption.Controls.Add(this.cdvBOMSet);
            this.grpOption.Controls.Add(this.lblBOMSet);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 47);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
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
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdVersion.TextTipAppearance = tipAppearance2;
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
            this.spdVersion_Sheet1.Columns.Get(6).Width = 84F;
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
            this.spdMaterial.Size = new System.Drawing.Size(736, 336);
            this.spdMaterial.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdMaterial.TabIndex = 0;
            this.spdMaterial.TabStop = false;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdMaterial.TextTipAppearance = tipAppearance1;
            this.spdMaterial.TextTipDelay = 200;
            this.spdMaterial.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdMaterial.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdMaterial.VerticalScrollBar.Name = "";
            this.spdMaterial.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdMaterial.VerticalScrollBar.TabIndex = 3;
            this.spdMaterial.EditModeOff += new System.EventHandler(this.spdMaterial_EditModeOff);
            this.spdMaterial.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdMaterial_ButtonClicked);
            this.spdMaterial.SetViewportLeftColumn(0, 0, 3);
            this.spdMaterial.SetActiveViewport(0, 0, -1);
            // 
            // spdMaterial_Sheet1
            // 
            this.spdMaterial_Sheet1.Reset();
            spdMaterial_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdMaterial_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdMaterial_Sheet1.ColumnCount = 29;
            spdMaterial_Sheet1.RowCount = 5;
            this.spdMaterial_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMaterial_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdMaterial_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMaterial_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Mat ID";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Version";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Description";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Mat Qty";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Part Grp";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Alt mat Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Mat Unit";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Opt Input Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Auto Input Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = " Serial Input Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = " Serial Type";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Chk Serial Flag";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 15).ColumnSpan = 2;
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Flow";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 17).ColumnSpan = 2;
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Oper";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Part CMF1";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Part CMF2";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Part CMF3";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Part CMF4";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Part CMF5";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Part CMF6";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Part CMF7";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Part CMF8";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Part CMF9";
            this.spdMaterial_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Part CMF10";
            this.spdMaterial_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdMaterial_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdMaterial_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdMaterial_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdMaterial_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdMaterial_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdMaterial_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(0).Width = 35F;
            this.spdMaterial_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.AliceBlue;
            this.spdMaterial_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdMaterial_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(1).Label = "Mat ID";
            this.spdMaterial_Sheet1.Columns.Get(1).Locked = false;
            this.spdMaterial_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(1).Width = 80F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdMaterial_Sheet1.Columns.Get(2).CellType = buttonCellType1;
            this.spdMaterial_Sheet1.Columns.Get(2).Width = 25F;
            this.spdMaterial_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.AliceBlue;
            this.spdMaterial_Sheet1.Columns.Get(3).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdMaterial_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(3).Label = "Version";
            this.spdMaterial_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(3).Width = 40F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdMaterial_Sheet1.Columns.Get(4).CellType = buttonCellType2;
            this.spdMaterial_Sheet1.Columns.Get(4).Width = 25F;
            this.spdMaterial_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(5).Label = "Description";
            this.spdMaterial_Sheet1.Columns.Get(5).Locked = true;
            this.spdMaterial_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(5).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(6).BackColor = System.Drawing.Color.AliceBlue;
            this.spdMaterial_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdMaterial_Sheet1.Columns.Get(6).Label = "Mat Qty";
            this.spdMaterial_Sheet1.Columns.Get(6).Locked = false;
            this.spdMaterial_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(6).Width = 71F;
            this.spdMaterial_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(7).Label = "Part Grp";
            this.spdMaterial_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(7).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(8).CellType = checkBoxCellType2;
            this.spdMaterial_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(8).Label = "Alt mat Flag";
            this.spdMaterial_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(8).Width = 82F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            this.spdMaterial_Sheet1.Columns.Get(9).CellType = comboBoxCellType1;
            this.spdMaterial_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(9).Label = "Mat Unit";
            this.spdMaterial_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(9).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(10).CellType = checkBoxCellType3;
            this.spdMaterial_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(10).Label = "Opt Input Flag";
            this.spdMaterial_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(10).Width = 92F;
            this.spdMaterial_Sheet1.Columns.Get(11).CellType = checkBoxCellType4;
            this.spdMaterial_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(11).Label = "Auto Input Flag";
            this.spdMaterial_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(11).Width = 97F;
            this.spdMaterial_Sheet1.Columns.Get(12).CellType = checkBoxCellType5;
            this.spdMaterial_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(12).Label = " Serial Input Flag";
            this.spdMaterial_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(12).Width = 106F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "Lot ID",
        "Material",
        "Sub Component"};
            this.spdMaterial_Sheet1.Columns.Get(13).CellType = comboBoxCellType2;
            this.spdMaterial_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(13).Label = " Serial Type";
            this.spdMaterial_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(13).Width = 121F;
            this.spdMaterial_Sheet1.Columns.Get(14).CellType = checkBoxCellType6;
            this.spdMaterial_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(14).Label = "Chk Serial Flag";
            this.spdMaterial_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(14).Width = 99F;
            this.spdMaterial_Sheet1.Columns.Get(15).BackColor = System.Drawing.Color.AliceBlue;
            this.spdMaterial_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(15).Label = "Flow";
            this.spdMaterial_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(15).Width = 100F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdMaterial_Sheet1.Columns.Get(16).CellType = buttonCellType3;
            this.spdMaterial_Sheet1.Columns.Get(16).Width = 25F;
            this.spdMaterial_Sheet1.Columns.Get(17).BackColor = System.Drawing.Color.AliceBlue;
            this.spdMaterial_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(17).Label = "Oper";
            this.spdMaterial_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(17).Width = 80F;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.Text = "...";
            this.spdMaterial_Sheet1.Columns.Get(18).CellType = buttonCellType4;
            this.spdMaterial_Sheet1.Columns.Get(18).Width = 25F;
            this.spdMaterial_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(19).Label = "Part CMF1";
            this.spdMaterial_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(19).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(20).Label = "Part CMF2";
            this.spdMaterial_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(20).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(21).Label = "Part CMF3";
            this.spdMaterial_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(21).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(22).Label = "Part CMF4";
            this.spdMaterial_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(22).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(23).Label = "Part CMF5";
            this.spdMaterial_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(23).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(24).Label = "Part CMF6";
            this.spdMaterial_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(24).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(25).Label = "Part CMF7";
            this.spdMaterial_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(25).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(26).Label = "Part CMF8";
            this.spdMaterial_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(26).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(27).Label = "Part CMF9";
            this.spdMaterial_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(27).Width = 80F;
            this.spdMaterial_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdMaterial_Sheet1.Columns.Get(28).Label = "Part CMF10";
            this.spdMaterial_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdMaterial_Sheet1.Columns.Get(28).Width = 80F;
            this.spdMaterial_Sheet1.FrozenColumnCount = 3;
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
            // cdvDataList
            // 
            this.cdvDataList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvDataList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cdvDataList.Location = new System.Drawing.Point(349, 12);
            this.cdvDataList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Name = "cdvTableList";
            this.cdvDataList.Size = new System.Drawing.Size(20, 20);
            this.cdvDataList.SmallImageList = null;
            this.cdvDataList.TabIndex = 0;
            this.cdvDataList.TabStop = false;
            this.cdvDataList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDataList.Visible = false;
            this.cdvDataList.VisibleColumnHeader = false;
            this.cdvDataList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvDataList_SelectedItemChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 7);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmBOMSetupAttachMaterial
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Controls.Add(this.pnlVersion);
            this.Controls.Add(this.pnlGrp);
            this.Name = "frmBOMSetupAttachMaterial";
            this.Text = "Attach Material Setup";
            this.Activated += new System.EventHandler(this.frmBOMSetupAttachMaterial_Activated);
            this.Load += new System.EventHandler(this.frmBOMSetupAttachMaterial_Load);
            this.Controls.SetChildIndex(this.pnlGrp, 0);
            this.Controls.SetChildIndex(this.pnlVersion, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlCenter, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlGrp.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvBOMSet)).EndInit();
            this.pnlVersion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdVersion_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdMaterial_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
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
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //

        private void ClearData(char ProcStep)
        {

            int i;

            try
            {

                if (ProcStep == '1')
                {

                    for (i = 0; i < spdMaterial.ActiveSheet.RowCount; i++)
                    {
                        spdMaterial.ActiveSheet.SetValue(i, 0, false);
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
                if (MPCF.Trim(FuncName) == "Update_Attach_Material")
                {
                    if (cdvBOMSet.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvBOMSet.Focus();
                        return false;
                    }

                    if (spdVersion.ActiveSheet.RowCount == 0 || spdVersion.ActiveSheet.SelectionCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(152));
                        return false;
                    }

                    for (i = 0; i < spdMaterial.ActiveSheet.RowCount; i++)
                    {
                        if (spdMaterial.ActiveSheet.GetValue(i, 0) != null)
                        {
                            if (Convert.ToBoolean(spdMaterial.ActiveSheet.GetValue(i, 0)) == true)
                            {
                                iSel++;
                            }
                        }
                    }

                    if (iSel == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(165));
                        return false;
                    }

                    for (i = 0; i < spdMaterial.ActiveSheet.RowCount - 1; i++)
                    {
                        for (j = i + 1; j < spdMaterial.ActiveSheet.RowCount; j++)
                        {
                            if (spdMaterial.ActiveSheet.GetValue(j, 0) != null)
                            {
                                if (Convert.ToBoolean(spdMaterial.ActiveSheet.GetValue(j, 0)) == true)
                                {
                                    if ((MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 1)) != "") &&
                                        (MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 1)) == MPCF.Trim(spdMaterial.ActiveSheet.GetValue(j, 1)) &&
                                        MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 15)) == MPCF.Trim(spdMaterial.ActiveSheet.GetValue(j, 13)) &&
                                        MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 17)) == MPCF.Trim(spdMaterial.ActiveSheet.GetValue(j, 15))))
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(166));
                                        /* 2013.06.12. Aiden. ÇÊ¼ö ÀÔ·ÂÇ×¸ñ¿¡ °ªÀÌ ¾ø´Â °æ¿ì ÇØ´ç Cell ·Î ÀÚµ¿ ÀÌµ¿ÇÏµµ·Ï º¯°æ */
                                        spdMaterial.ActiveSheet.SetActiveCell(j, 1);
                                        spdMaterial.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                                        spdMaterial.Focus();
                                        return false;
                                    }
                                }
                            }//end if
                        }//end for
                    }//end for

                    for (i = 0; i < spdMaterial.ActiveSheet.RowCount; i++)
                    {
                        if (spdMaterial.ActiveSheet.GetValue(i, 0) != null)
                        {
                            if (Convert.ToBoolean(spdMaterial.ActiveSheet.GetValue(i, 0)) == true)
                            {
                                for (j = 0; j <= 28; j++)
                                {
                                    if (spdMaterial.ActiveSheet.Columns[j].BackColor == Color.AliceBlue)
                                    {
                                        if (spdMaterial.ActiveSheet.Cells[i, j].Text == "")
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                            /* 2013.06.12. Aiden. ÇÊ¼ö ÀÔ·ÂÇ×¸ñ¿¡ °ªÀÌ ¾ø´Â °æ¿ì ÇØ´ç Cell ·Î ÀÚµ¿ ÀÌµ¿ÇÏµµ·Ï º¯°æ */
                                            spdMaterial.ActiveSheet.SetActiveCell(i, j);
                                            spdMaterial.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                                            spdMaterial.Focus();
                                            return false;
                                        }
                                    }
                                }
                                if (MPCF.CheckNumeric(MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 6))) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(110));
                                    /* 2013.06.12. Aiden. ÇÊ¼ö ÀÔ·ÂÇ×¸ñ¿¡ °ªÀÌ ¾ø´Â °æ¿ì ÇØ´ç Cell ·Î ÀÚµ¿ ÀÌµ¿ÇÏµµ·Ï º¯°æ */
                                    spdMaterial.ActiveSheet.SetActiveCell(i, 6);
                                    spdMaterial.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                                    spdMaterial.Focus();
                                    return false;
                                }
                                if (MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 6)) == "0")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(114));
                                    /* 2013.06.12. Aiden. ÇÊ¼ö ÀÔ·ÂÇ×¸ñ¿¡ °ªÀÌ ¾ø´Â °æ¿ì ÇØ´ç Cell ·Î ÀÚµ¿ ÀÌµ¿ÇÏµµ·Ï º¯°æ */
                                    spdMaterial.ActiveSheet.SetActiveCell(i, 6);
                                    spdMaterial.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                                    spdMaterial.Focus();
                                    return false;
                                }
                                if (MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 9)) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    /* 2013.06.12. Aiden. ÇÊ¼ö ÀÔ·ÂÇ×¸ñ¿¡ °ªÀÌ ¾ø´Â °æ¿ì ÇØ´ç Cell ·Î ÀÚµ¿ ÀÌµ¿ÇÏµµ·Ï º¯°æ */
                                    spdMaterial.ActiveSheet.SetActiveCell(i, 9);
                                    spdMaterial.ShowActiveCell(VerticalPosition.Center, HorizontalPosition.Center);
                                    spdMaterial.Focus();
                                    return false;
                                }
                            }//end if
                        }//end if
                    }//end for
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

            TRSNode in_node = new TRSNode("VIEW_BOMSET_VERSION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_BOMSET_VERSION_LIST_OUT");


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

                    spdVersion.ActiveSheet.RowCount = out_node.GetList(0).Count;

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
        
        // View_Material_By_BOMSet_List()
        //       - View Material List by BOMSet Set
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal sBOMSetId As String                        : ColSet
        //        - ByVal sBOMSetVersion As String                : ColSetVersion
        //        -

        public bool View_Material_List_By_BOMSet(string sBOMSetId, string sBOMSetVersion)
        {

            int i;
            int LastRow = 0;
            TRSNode in_node = new TRSNode("VIEW_ATTACH_MATERIAL_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ATTACH_MATERIAL_LIST_OUT");

            try
            {
                MPCF.ClearList(spdMaterial, true);

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

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        LastRow = spdMaterial.ActiveSheet.RowCount;
                        spdMaterial.ActiveSheet.RowCount = spdMaterial.ActiveSheet.RowCount + 1;
                        FarPoint.Win.Spread.SheetView with_1 = spdMaterial.Sheets[0];

                        with_1.SetValue(LastRow, 1, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_ID")));
                        with_1.SetValue(LastRow, 3, out_node.GetList(0)[i].GetInt("MAT_VER"));
                        with_1.SetValue(LastRow, 5, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_DESC")));
                        with_1.SetValue(LastRow, 6, MPCF.Format("##########,##0.######", out_node.GetList(0)[i].GetDouble("MAT_QTY")));
                        with_1.SetValue(LastRow, 7, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_GRP")));
                        with_1.SetValue(LastRow, 8, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("ALT_MAT_FLAG")) == "Y") ? true : false));
                        with_1.SetValue(LastRow, 9, MPCF.Trim(out_node.GetList(0)[i].GetString("MAT_UNIT")));
                        with_1.SetValue(LastRow, 10, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("OPT_INPUT_FLAG")) == "Y") ? true : false));
                        with_1.SetValue(LastRow, 11, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("AUTO_INPUT_FLAG")) == "Y") ? true : false));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("AUTO_INPUT_FLAG")) == "Y")
                        {
                            with_1.Cells[LastRow, 12].Locked = true;
                            with_1.Cells[LastRow, 13].Locked = true;
                            with_1.Cells[LastRow, 14].Locked = true;

                            with_1.Cells[LastRow, 12, LastRow, 14].BackColor = Color.Gainsboro;
                        }

                        with_1.SetValue(LastRow, 12, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_INPUT_FLAG")) == "Y") ? true : false));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")) == "L")
                        {
                            with_1.SetValue(LastRow, 13, "Lot ID");
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")) == "M")
                        {
                            with_1.SetValue(LastRow, 13, "Material");
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("SERIAL_TYPE")) == "S")
                        {
                            with_1.SetValue(LastRow, 13, "Sub Component");
                        }
                        with_1.SetValue(LastRow, 14, ((MPCF.Trim(out_node.GetList(0)[i].GetChar("CHK_SERIAL_FLAG")) == "Y") ? true : false));
                        with_1.SetValue(LastRow, 15, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));
                        with_1.SetTag(LastRow, 15, MPCF.Trim(out_node.GetList(0)[i].GetString("FLOW")));
                        with_1.SetValue(LastRow, 17, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                        with_1.SetTag(LastRow, 17, MPCF.Trim(out_node.GetList(0)[i].GetString("OPER")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_1")) != "")
                            with_1.SetValue(LastRow, 19, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_1")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_2")) != "")
                            with_1.SetValue(LastRow, 20, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_2")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_3")) != "")
                            with_1.SetValue(LastRow, 21, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_3")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_4")) != "")
                            with_1.SetValue(LastRow, 22, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_4")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_5")) != "")
                            with_1.SetValue(LastRow, 23, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_5")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_6")) != "")
                            with_1.SetValue(LastRow, 24, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_6")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_7")) != "")
                            with_1.SetValue(LastRow, 25, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_7")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_8")) != "")
                            with_1.SetValue(LastRow, 26, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_8")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_9")) != "")
                            with_1.SetValue(LastRow, 27, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_9")));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_10")) != "")
                            with_1.SetValue(LastRow, 28, MPCF.Trim(out_node.GetList(0)[i].GetString("PART_CMF_10")));

                    }

                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));

                } while (out_node.GetInt("NEXT_SEQ_NUM") != 0);

                spdMaterial.ActiveSheet.RowCount++;

                MPCF.FitColumnHeader(spdMaterial);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
        
        //Update_Attach_Material()
        //      - Update Material
        //Return Value
        //      - Boolean : True or False
        //Arguments
        //      - ByVal ProcStep As String (MP_STEP_CREATE - Create, MP_STEP_UPDATE - Update, MP_STEP_DELETE - Delete)

        private bool Update_Attach_Material(char ProcStep)
        {

            int i = 0;
            int iSeq = 0;

            TRSNode in_node = new TRSNode("UPDATE_ATTACH_MATERIAL_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("BOM_SET_ID", cdvBOMSet.Text);
                in_node.AddInt("BOM_SET_VERSION", MPCF.ToInt(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRow.Index, 0)));

                for (i = 0; i < spdMaterial.ActiveSheet.RowCount; i++)
                {
                    iSeq++;
                    if (spdMaterial.ActiveSheet.GetValue(i, 0) != null)
                    {
                        if (Convert.ToBoolean(spdMaterial.ActiveSheet.GetValue(i, 0)) == true)
                        {
                            node = in_node.AddNode("MAT_LIST");

                            node.AddString("MAT_ID", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 1)));
                            node.AddInt("SEQ_NUM", iSeq);
                            node.AddInt("MAT_VER", MPCF.ToInt(spdMaterial.ActiveSheet.GetValue(i, 3)));
                            node.AddDouble("MAT_QTY", MPCF.ToDbl(spdMaterial.ActiveSheet.GetValue(i, 6)));
                            node.AddString("PART_GRP", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 7)));
                            node.AddChar("ALT_MAT_FLAG", (System.Convert.ToBoolean(spdMaterial.ActiveSheet.GetValue(i, 8)) == true) ? 'Y' : ' ');
                            node.AddString("MAT_UNIT", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 9)));
                            node.AddChar("OPT_INPUT_FLAG", (System.Convert.ToBoolean(spdMaterial.ActiveSheet.GetValue(i, 10)) == true) ? 'Y' : ' ');
                            node.AddChar("AUTO_INPUT_FLAG", (System.Convert.ToBoolean(spdMaterial.ActiveSheet.GetValue(i, 11)) == true) ? 'Y' : ' ');
                            node.AddChar("SERIAL_INPUT_FLAG", (System.Convert.ToBoolean(spdMaterial.ActiveSheet.GetValue(i, 12)) == true) ? 'Y' : ' ');
                            node.AddChar("SERIAL_TYPE", MPCF.ToChar(MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 13))));
                            node.AddChar("CHK_SERIAL_FLAG", (System.Convert.ToBoolean(spdMaterial.ActiveSheet.GetValue(i, 14)) == true) ? 'Y' : ' ');
                            /* 2013.06.12. Aiden. Flow, Oper ¿¡ ´ëÇØ ¼ö±â ÀÔ·ÂÀÌ °¡´ÉÇÏµµ·Ï º¯°æ */
                            node.AddString("FLOW", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 15)));
                            node.AddString("OPER", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 17)));
                            node.AddString("PART_CMF_1", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 19)));
                            node.AddString("PART_CMF_2", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 20)));
                            node.AddString("PART_CMF_3", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 21)));
                            node.AddString("PART_CMF_4", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 22)));
                            node.AddString("PART_CMF_5", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 23)));
                            node.AddString("PART_CMF_6", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 24)));
                            node.AddString("PART_CMF_7", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 25)));
                            node.AddString("PART_CMF_8", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 26)));
                            node.AddString("PART_CMF_9", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 27)));
                            node.AddString("PART_CMF_10", MPCF.Trim(spdMaterial.ActiveSheet.GetValue(i, 28)));
                        }
                    }
                }


                if (MPCR.CallService("BOM", "BOM_Update_Attach_Material", in_node, ref out_node) == false)
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
            FarPoint.Win.Spread.CellType.ComboBoxCellType cCell;


            try
            {
                cCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                ViewBASDataSpdCboList(cCell, '1', MPGC.MP_WIP_UNIT_TABLE);
                spdMaterial.ActiveSheet.Columns[9].CellType = cCell;

                for (i = 19; i <= 28; i++)
                {
                    spdMaterial.ActiveSheet.ColumnHeader.Columns[i].Visible = false;
                }
                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_CMF_PART, ref out_node, "", true) == false)
                {
                    return;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        spdMaterial.ActiveSheet.ColumnHeader.Columns[19 + i].Visible = true;
                        spdMaterial.ActiveSheet.ColumnHeader.Cells[0, 19 + i].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT"));

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("OPT")) == "Y")
                        {
                            spdMaterial.ActiveSheet.Columns[19 + i].BackColor = Color.AliceBlue;
                            //spdMaterial.ActiveSheet.ColumnHeader.Columns(14 + i).Font = New Font(spdMaterial.Font.Name, spdMaterial.Font.Size, FontStyle.Bold)
                        }
                        spdMaterial.ActiveSheet.ColumnHeader.Columns[19 + i].Tag = MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME"));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")) != "")
                        {
                            cCell = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                            if (spdMaterial.ActiveSheet.Columns[19 + i].Locked == false)
                            {
                                ViewBASDataSpdCboList(cCell, '1', MPCF.Trim(out_node.GetList(0)[i].GetString("TABLE_NAME")));
                                spdMaterial.ActiveSheet.Columns[19 + i].CellType = cCell;
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


        // ViewBASDataSpdCboList()
        //       - View General Code Data list
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal Form_control As Control                : Listê°€ ?¤ì–´ê°?control
        //        - ByVal c_step As String                        : ?•ìž¥ Process Step
        //        - ByVal table_name As String                : BAS??Table_name
        //

        public object ViewBASDataSpdCboList(FarPoint.Win.Spread.CellType.ComboBoxCellType cCell, char c_step, string table_name)
        {

            int i;
            string[] strData = null;
            List<string> sList = new List<string>();

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("TABLE_NAME", MPCF.Trim(table_name));
            in_node.AddString("NEXT_KEY_1", "");
            in_node.AddString("NEXT_KEY_2", "");

            do
            {
                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    sList.Add(MPCF.Trim(out_node.GetList(0)[i].GetString("KEY_1")));
                }

                in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
            } while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "");

            strData = new string[sList.Count];
            for (i = 0; i < sList.Count; i++)
            {
                strData[i] = sList[i];
            }
            cCell.Items = strData;

            return true;

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

        private void frmBOMSetupAttachMaterial_Load(object sender, System.EventArgs e)
        {
            try
            {
                MPCF.FieldClear(this);

                MPCF.ClearList(spdMaterial, true);
                MPCF.ClearList(spdVersion, true);
                MPCF.FitColumnHeader(spdVersion);
                MPCF.FitColumnHeader(spdMaterial);

                MPCF.ClearList(spdVersion);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void frmBOMSetupAttachMaterial_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {

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

                if (CheckCondition("View_BOMSet_Version_List", MPGC.MP_STEP_CREATE) == true)
                {
                    if (View_BOMSet_Version_List(MPCF.Trim(cdvBOMSet.Text), '1') == false)
                    {
                        return;
                    }

                    MPCR.ChangeControlEnabled(this, btnCreate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);
                }

                MPCF.ClearList(spdMaterial);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void spdVersion_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            int j;

            try
            {

                MPCF.ClearList(spdMaterial, true);

                if (CheckCondition("View_Material_List_By_BOMSet", MPGC.MP_STEP_CREATE) == false)
                {
                    return;
                }


                if (MPCF.Trim(spdVersion.ActiveSheet.GetValue(e.Range.Row, 3)) != "" || MPCF.Trim(spdVersion.ActiveSheet.GetValue(e.Range.Row, 6)) != "")
                {
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;

                    for (j = 0; j < spdMaterial.ActiveSheet.ColumnCount; j++)
                    {
                        spdMaterial.ActiveSheet.Columns[j].Locked = true;
                    }

                }
                else
                {
                    MPCR.ChangeControlEnabled(this, btnUpdate, true);
                    MPCR.ChangeControlEnabled(this, btnDelete, true);

                    for (j = 0; j < spdMaterial.ActiveSheet.ColumnCount; j++)
                    {
                        spdMaterial.ActiveSheet.Columns[j].Locked = false;
                    }
                }

                SetCmfItem();
                View_Material_List_By_BOMSet(cdvBOMSet.Text, MPCF.Trim(spdVersion.ActiveSheet.GetValue(e.Range.Row, 0)));

                ClearData('1');
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
                if (CheckCondition("Update_Attach_Material", MPGC.MP_STEP_DELETE) == true)
                {

                    if (Update_Attach_Material(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    if (CheckCondition("View_Material_List_By_BOMSet", MPGC.MP_STEP_CREATE) == true)
                    {
                        View_Material_List_By_BOMSet(cdvBOMSet.Text, MPCF.Trim(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRowIndex, 0)));
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
                if (CheckCondition("Update_Attach_Material", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Attach_Material(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    if (CheckCondition("View_Material_List_By_BOMSet", MPGC.MP_STEP_CREATE) == true)
                    {
                        View_Material_List_By_BOMSet(cdvBOMSet.Text, MPCF.Trim(spdVersion.ActiveSheet.GetValue(spdVersion.ActiveSheet.ActiveRowIndex, 0)));
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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

        private void spdMaterial_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            try
            {
                switch (e.Column)
                {
                    case 11:


                        if (spdMaterial.ActiveSheet.Cells[e.Row, e.Column].Value != null &&
                            Convert.ToBoolean(spdMaterial.ActiveSheet.Cells[e.Row, e.Column].Value) == true)
                        {
                            spdMaterial.ActiveSheet.Cells[e.Row, 12].Value = false;
                            spdMaterial.ActiveSheet.Cells[e.Row, 12].Locked = true;
                            spdMaterial.ActiveSheet.Cells[e.Row, 13].Value = "";
                            spdMaterial.ActiveSheet.Cells[e.Row, 13].Locked = true;
                            spdMaterial.ActiveSheet.Cells[e.Row, 14].Value = false;
                            spdMaterial.ActiveSheet.Cells[e.Row, 14].Locked = true;

                            spdMaterial.ActiveSheet.Cells[e.Row, 12, e.Row, 14].BackColor = Color.Gainsboro;
                        }
                        else
                        {
                            spdMaterial.ActiveSheet.Cells[e.Row, 12].Locked = false;
                            spdMaterial.ActiveSheet.Cells[e.Row, 13].Locked = false;
                            spdMaterial.ActiveSheet.Cells[e.Row, 14].Locked = false;

                            spdMaterial.ActiveSheet.Cells[e.Row, 12, e.Row, 14].BackColor = Color.White;
                        }
                        break;

                    case 2:

                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("Material", 50, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Version", 40, HorizontalAlignment.Center);
                        cdvDataList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if (WIPLIST.ViewMaterialList(cdvDataList.GetListView, '1') == false)
                        {
                            return;
                        }

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;

                    case 4:

                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("Version", 50, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if(WIPLIST.ViewMaterialVersionList(cdvDataList.GetListView, '1', spdMaterial.ActiveSheet.Cells[e.Row, 1].Text) == false)
                        {
                            return;
                        }

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;

                    case 16:

                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("Flow", 50, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if(WIPLIST.ViewFlowList(cdvDataList.GetListView, '1', "", 0, "", null, "") == false)
                        {
                            return;
                        }

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;

                    case 18:

                        cdvDataList.Init();
                        cdvDataList.ViewPosition = Control.MousePosition;
                        MPCF.InitListView(cdvDataList.GetListView);
                        cdvDataList.Columns.Add("Operarion", 50, HorizontalAlignment.Left);
                        cdvDataList.Columns.Add("Description", 50, HorizontalAlignment.Left);
                        cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
                        if(WIPLIST.ViewOperationList(cdvDataList.GetListView, '1', "", 0, "", "", null, "") == false)
                        {
                            return;
                        }

                        if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
                        {
                            return;
                        }
                        break;

                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void cdvDataList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            switch (e.Col)
            {
                case 1:

                    spdMaterial.ActiveSheet.Cells[e.Row, e.Col].Value = e.SelectedItem.SubItems[0].Text;
                    spdMaterial.ActiveSheet.Cells[e.Row, e.Col + 2].Value = e.SelectedItem.SubItems[1].Text;
                    spdMaterial.ActiveSheet.Cells[e.Row, e.Col + 4].Value = e.SelectedItem.SubItems[2].Text;
                    break;
                case 3:
                    spdMaterial.ActiveSheet.Cells[e.Row, e.Col].Value = e.SelectedItem.SubItems[0].Text;
                    break;
                case 15:
                    spdMaterial.ActiveSheet.Cells[e.Row, e.Col].Value = e.SelectedItem.SubItems[0].Text;
                    break;
                case 17:
                    spdMaterial.ActiveSheet.Cells[e.Row, e.Col].Value = e.SelectedItem.SubItems[0].Text;
                    break;
            }
        }
        
        private void cdvBOMSet_ButtonPress(object sender, System.EventArgs e)
        {
            //Initialize ListView
            cdvBOMSet.Init();
            MPCF.InitListView(cdvBOMSet.GetListView);
            cdvBOMSet.Columns.Add("bom Set", 50, HorizontalAlignment.Left);
            cdvBOMSet.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvBOMSet.SelectedSubItemIndex = 0;
            if (BOMLIST.ViewBOMSetList(cdvBOMSet.GetListView, '1', null, "", -1, -1, ' ', false) == false)
            {
                return;
            }
        }

        private void spdMaterial_EditModeOff(object sender, EventArgs e)
        {
            int i_row;
            try
            {
                i_row = spdMaterial.ActiveSheet.ActiveRowIndex;

                spdMaterial.ActiveSheet.SetValue(i_row, 0, true);

                if (i_row == spdMaterial.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdMaterial.ActiveSheet.Cells[i_row, 1].Value) != "")
                    {
                        spdMaterial.ActiveSheet.RowCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
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
