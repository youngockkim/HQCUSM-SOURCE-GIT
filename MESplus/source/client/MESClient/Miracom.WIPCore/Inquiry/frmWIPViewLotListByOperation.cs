
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPViewLotListByOperation.vb
//   Description : MES Cient Form View Lot List By Operation
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - SetTableName() : Set Operation Group Table Name
//       - initCodeView() : initial CodeView Control
//       - SetOperGroupPrompt() : Set Group Property to control
//       - View_Lot_List() : View Lot List By Operation Condition
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-07 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.TRSCore;

namespace Miracom.WIPCore
{
    public class frmWIPViewLotListByOperation : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewLotListByOperation()
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
        



        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvOperation;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.CheckBox chkTerminatedLot;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroupType;
        private System.Windows.Forms.CheckBox chkZeroQtyLot;
        private System.Windows.Forms.Label lblOperGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup1;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType3 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType4 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType5 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType6 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType7 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType10 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType11 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType12 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType13 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.cdvOperation = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblOperation = new System.Windows.Forms.Label();
            this.chkTerminatedLot = new System.Windows.Forms.CheckBox();
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroupType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.chkZeroQtyLot = new System.Windows.Forms.CheckBox();
            this.lblOperGroup = new System.Windows.Forms.Label();
            this.cdvGroup1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroupType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 95);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvFlow);
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.lblOperGroup);
            this.grpOption.Controls.Add(this.chkZeroQtyLot);
            this.grpOption.Controls.Add(this.cdvGroup);
            this.grpOption.Controls.Add(this.cdvGroupType);
            this.grpOption.Controls.Add(this.cdvOperation);
            this.grpOption.Controls.Add(this.chkTerminatedLot);
            this.grpOption.Controls.Add(this.lblOperation);
            this.grpOption.Size = new System.Drawing.Size(742, 95);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 95);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 418);
            this.pnlViewMid.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot List By Operation";
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
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.Index = 0;
            this.cdvOperation.IsViewBtnImage = false;
            this.cdvOperation.Location = new System.Drawing.Point(120, 64);
            this.cdvOperation.MaxLength = 10;
            this.cdvOperation.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = -1;
            this.cdvOperation.SelectedSubItemIndex = -1;
            this.cdvOperation.SelectionStart = 0;
            this.cdvOperation.Size = new System.Drawing.Size(192, 20);
            this.cdvOperation.SmallImageList = null;
            this.cdvOperation.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvOperation.TabIndex = 3;
            this.cdvOperation.TextBoxToolTipText = "";
            this.cdvOperation.TextBoxWidth = 192;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperation.Location = new System.Drawing.Point(12, 67);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(62, 13);
            this.lblOperation.TabIndex = 2;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkTerminatedLot
            // 
            this.chkTerminatedLot.AutoSize = true;
            this.chkTerminatedLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTerminatedLot.Location = new System.Drawing.Point(562, 65);
            this.chkTerminatedLot.Name = "chkTerminatedLot";
            this.chkTerminatedLot.Size = new System.Drawing.Size(141, 18);
            this.chkTerminatedLot.TabIndex = 8;
            this.chkTerminatedLot.Text = "Include Terminated Lot";
            // 
            // cdvGroup
            // 
            this.cdvGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup.BtnToolTipText = "";
            this.cdvGroup.DescText = "";
            this.cdvGroup.DisplaySubItemIndex = -1;
            this.cdvGroup.DisplayText = "";
            this.cdvGroup.Focusing = null;
            this.cdvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup.Index = 0;
            this.cdvGroup.IsViewBtnImage = false;
            this.cdvGroup.Location = new System.Drawing.Point(340, 64);
            this.cdvGroup.MaxLength = 30;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = true;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedSubItemIndex = -1;
            this.cdvGroup.SelectionStart = 0;
            this.cdvGroup.Size = new System.Drawing.Size(192, 20);
            this.cdvGroup.SmallImageList = null;
            this.cdvGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup.TabIndex = 6;
            this.cdvGroup.TextBoxToolTipText = "";
            this.cdvGroup.TextBoxWidth = 192;
            this.cdvGroup.VisibleButton = true;
            this.cdvGroup.VisibleColumnHeader = false;
            this.cdvGroup.VisibleDescription = false;
            this.cdvGroup.ButtonPress += new System.EventHandler(this.cdvGroup1_ButtonPress);
            // 
            // cdvGroupType
            // 
            this.cdvGroupType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroupType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroupType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroupType.BtnToolTipText = "";
            this.cdvGroupType.DescText = "";
            this.cdvGroupType.DisplaySubItemIndex = -1;
            this.cdvGroupType.DisplayText = "";
            this.cdvGroupType.Focusing = null;
            this.cdvGroupType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroupType.Index = 0;
            this.cdvGroupType.IsViewBtnImage = false;
            this.cdvGroupType.Location = new System.Drawing.Point(340, 40);
            this.cdvGroupType.MaxLength = 30;
            this.cdvGroupType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroupType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroupType.Name = "cdvGroupType";
            this.cdvGroupType.ReadOnly = true;
            this.cdvGroupType.SearchSubItemIndex = 0;
            this.cdvGroupType.SelectedDescIndex = -1;
            this.cdvGroupType.SelectedSubItemIndex = -1;
            this.cdvGroupType.SelectionStart = 0;
            this.cdvGroupType.Size = new System.Drawing.Size(192, 20);
            this.cdvGroupType.SmallImageList = null;
            this.cdvGroupType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroupType.TabIndex = 5;
            this.cdvGroupType.TextBoxToolTipText = "";
            this.cdvGroupType.TextBoxWidth = 192;
            this.cdvGroupType.VisibleButton = true;
            this.cdvGroupType.VisibleColumnHeader = false;
            this.cdvGroupType.VisibleDescription = false;
            this.cdvGroupType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGroupType_SelectedItemChanged);
            this.cdvGroupType.ButtonPress += new System.EventHandler(this.cdvGroupType_ButtonPress);
            // 
            // chkZeroQtyLot
            // 
            this.chkZeroQtyLot.AutoSize = true;
            this.chkZeroQtyLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkZeroQtyLot.Location = new System.Drawing.Point(562, 41);
            this.chkZeroQtyLot.Name = "chkZeroQtyLot";
            this.chkZeroQtyLot.Size = new System.Drawing.Size(114, 18);
            this.chkZeroQtyLot.TabIndex = 7;
            this.chkZeroQtyLot.Text = "Zero Quantity Lot";
            // 
            // lblOperGroup
            // 
            this.lblOperGroup.AutoSize = true;
            this.lblOperGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOperGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperGroup.Location = new System.Drawing.Point(342, 19);
            this.lblOperGroup.Name = "lblOperGroup";
            this.lblOperGroup.Size = new System.Drawing.Size(85, 13);
            this.lblOperGroup.TabIndex = 4;
            this.lblOperGroup.Text = "Operation Group";
            this.lblOperGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvGroup1
            // 
            this.cdvGroup1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup1.BtnToolTipText = "";
            this.cdvGroup1.DescText = "";
            this.cdvGroup1.DisplaySubItemIndex = -1;
            this.cdvGroup1.DisplayText = "";
            this.cdvGroup1.Focusing = null;
            this.cdvGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup1.Index = 0;
            this.cdvGroup1.IsViewBtnImage = false;
            this.cdvGroup1.Location = new System.Drawing.Point(340, 64);
            this.cdvGroup1.MaxLength = 30;
            this.cdvGroup1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = true;
            this.cdvGroup1.SearchSubItemIndex = 0;
            this.cdvGroup1.SelectedDescIndex = -1;
            this.cdvGroup1.SelectedSubItemIndex = -1;
            this.cdvGroup1.SelectionStart = 0;
            this.cdvGroup1.Size = new System.Drawing.Size(192, 20);
            this.cdvGroup1.SmallImageList = null;
            this.cdvGroup1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup1.TabIndex = 8;
            this.cdvGroup1.TextBoxToolTipText = "";
            this.cdvGroup1.TextBoxWidth = 192;
            this.cdvGroup1.VisibleButton = true;
            this.cdvGroup1.VisibleColumnHeader = false;
            this.cdvGroup1.VisibleDescription = false;
            this.cdvGroup1.ButtonPress += new System.EventHandler(this.cdvGroup1_ButtonPress);
            // 
            // cdvMaterial
            // 
            this.cdvMaterial.AddEmptyRowToLast = false;
            this.cdvMaterial.AddEmptyRowToTop = false;
            this.cdvMaterial.CodeViewBackColor = System.Drawing.SystemColors.Window;
            this.cdvMaterial.DisplaySubItemIndex = 0;
            this.cdvMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelBackColor = System.Drawing.SystemColors.Control;
            this.cdvMaterial.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvMaterial.LabelText = "Material";
            this.cdvMaterial.ListCond_ExtFactory = "";
            this.cdvMaterial.ListCond_StepMaterial = '1';
            this.cdvMaterial.ListCond_StepVersion = '1';
            this.cdvMaterial.Location = new System.Drawing.Point(12, 14);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(300, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 108;
            this.cdvMaterial.WidthMaterialAndVersion = 192;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            // 
            // cdvFlow
            // 
            this.cdvFlow.AddEmptyRowToLast = false;
            this.cdvFlow.AddEmptyRowToTop = false;
            this.cdvFlow.DisplaySubItemIndex = 0;
            this.cdvFlow.FlowReadOnly = false;
            this.cdvFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFlow.LabelText = "Flow";
            this.cdvFlow.LabelWidth = 108;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(12, 39);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(300, 20);
            this.cdvFlow.TabIndex = 1;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 192;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_ButtonPress);
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet1, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 2;
            this.spdList.Location = new System.Drawing.Point(0, 3);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 415);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 3;
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 102;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Mat Ver";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Qty 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Lot Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Owner Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Create Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Priority";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Lot Status";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Hold Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Hold Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Create Qty 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Create Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Create Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Oper In Qty 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Oper In Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Oper In Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Inventory Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Transit Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Unit Exist Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Inv Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Rework Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Rework Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Rework Count";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Rework Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Rework Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Rework End Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Rework End Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Rework Return Clear Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Rework Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "NSTD Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "NSTD Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "NSTD Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "NSTD Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Repair Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Repair Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Store Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Store Return Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Store Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Start Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Start Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Start Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "End Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "End Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "End Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Sample Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Sample Wait Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Sample Result";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "From To Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Ship Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Ship Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Original Due Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Scheduled Due Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Create Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Factory In Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Flow In Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Oper In Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Reserve Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Batch ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Batch Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Order ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "Add Order ID 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "Add Order ID 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "Add Order ID 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "Lot Location";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "Lot CMF 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "Lot CMF 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "Lot CMF 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "Lot CMF 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "Lot CMF 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "Lot CMF 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "Lot CMF 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Lot CMF 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Lot CMF 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 79).Value = "Lot CMF 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 80).Value = "Lot CMF 11";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 81).Value = "Lot CMF 12";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 82).Value = "Lot CMF 13";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 83).Value = "Lot CMF 14";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 84).Value = "Lot CMF 15";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 85).Value = "Lot CMF 16";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 86).Value = "Lot CMF 17";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 87).Value = "Lot CMF 18";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 88).Value = "Lot CMF 19";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 89).Value = "Lot Cmf 20";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 90).Value = "BOM Set ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 91).Value = "BOM Set Version";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 92).Value = "BOM Act Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 93).Value = "BOM Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 94).Value = "Lot Delete Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 95).Value = "Lot Delete Reason";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 96).Value = "Lot Delete Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 97).Value = "Last Tran Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 98).Value = "Last Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 99).Value = "Last Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 100).Value = "Last Active Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 101).Value = "Last Hist Seq";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdList_Sheet1.Columns.Get(0).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 101F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Material";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 103F;
            this.spdList_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Label = "Mat Ver";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Label = "Flow";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 82F;
            this.spdList_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Label = "Flow Seq";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Label = "Oper";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 66F;
            numberCellType1.DecimalPlaces = 3;
            numberCellType1.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(6).CellType = numberCellType1;
            this.spdList_Sheet1.Columns.Get(6).Label = "Qty 1";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 73F;
            numberCellType2.DecimalPlaces = 3;
            numberCellType2.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(7).CellType = numberCellType2;
            this.spdList_Sheet1.Columns.Get(7).Label = "Qty 2";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 73F;
            numberCellType3.DecimalPlaces = 3;
            numberCellType3.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(8).CellType = numberCellType3;
            this.spdList_Sheet1.Columns.Get(8).Label = "Qty 3";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 73F;
            this.spdList_Sheet1.Columns.Get(9).Label = "Lot Type";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Label = "Owner Code";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 79F;
            this.spdList_Sheet1.Columns.Get(11).Label = "Create Code";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 79F;
            this.spdList_Sheet1.Columns.Get(12).Label = "Priority";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Label = "Lot Status";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 72F;
            this.spdList_Sheet1.Columns.Get(14).Label = "Hold Flag";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 66F;
            this.spdList_Sheet1.Columns.Get(15).Label = "Hold Code";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 70F;
            numberCellType4.DecimalPlaces = 3;
            numberCellType4.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(16).CellType = numberCellType4;
            this.spdList_Sheet1.Columns.Get(16).Label = "Create Qty 1";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Width = 80F;
            numberCellType5.DecimalPlaces = 3;
            numberCellType5.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(17).CellType = numberCellType5;
            this.spdList_Sheet1.Columns.Get(17).Label = "Create Qty 2";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 80F;
            numberCellType6.DecimalPlaces = 3;
            numberCellType6.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(18).CellType = numberCellType6;
            this.spdList_Sheet1.Columns.Get(18).Label = "Create Qty 3";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Width = 80F;
            numberCellType7.DecimalPlaces = 3;
            numberCellType7.MaximumValue = 9999999.999D;
            numberCellType7.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(19).CellType = numberCellType7;
            this.spdList_Sheet1.Columns.Get(19).Label = "Oper In Qty 1";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 84F;
            numberCellType8.DecimalPlaces = 3;
            numberCellType8.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(20).CellType = numberCellType8;
            this.spdList_Sheet1.Columns.Get(20).Label = "Oper In Qty 2";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 84F;
            numberCellType9.DecimalPlaces = 3;
            numberCellType9.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(21).CellType = numberCellType9;
            this.spdList_Sheet1.Columns.Get(21).Label = "Oper In Qty 3";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 84F;
            this.spdList_Sheet1.Columns.Get(22).Label = "Inventory Flag";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 68F;
            this.spdList_Sheet1.Columns.Get(23).Label = "Transit Flag";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 82F;
            this.spdList_Sheet1.Columns.Get(24).Label = "Unit Exist Flag";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 89F;
            this.spdList_Sheet1.Columns.Get(25).Label = "Inv Unit";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Label = "Rework Flag";
            this.spdList_Sheet1.Columns.Get(26).Locked = true;
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 79F;
            this.spdList_Sheet1.Columns.Get(27).Label = "Rework Code";
            this.spdList_Sheet1.Columns.Get(27).Locked = true;
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 85F;
            numberCellType10.DecimalPlaces = 0;
            numberCellType10.MaximumValue = 9999D;
            numberCellType10.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(28).CellType = numberCellType10;
            this.spdList_Sheet1.Columns.Get(28).Label = "Rework Count";
            this.spdList_Sheet1.Columns.Get(28).Locked = true;
            this.spdList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).Width = 87F;
            this.spdList_Sheet1.Columns.Get(29).Label = "Rework Return Flow";
            this.spdList_Sheet1.Columns.Get(29).Locked = true;
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 123F;
            this.spdList_Sheet1.Columns.Get(30).Label = "Rework Return Oper";
            this.spdList_Sheet1.Columns.Get(30).Locked = true;
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 123F;
            this.spdList_Sheet1.Columns.Get(31).Label = "Rework End Flow";
            this.spdList_Sheet1.Columns.Get(31).Locked = true;
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 117F;
            this.spdList_Sheet1.Columns.Get(32).Label = "Rework End Oper";
            this.spdList_Sheet1.Columns.Get(32).Locked = true;
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 113F;
            this.spdList_Sheet1.Columns.Get(33).Label = "Rework Return Clear Flag";
            this.spdList_Sheet1.Columns.Get(33).Locked = true;
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 154F;
            this.spdList_Sheet1.Columns.Get(34).Label = "Rework Time";
            this.spdList_Sheet1.Columns.Get(34).Locked = true;
            this.spdList_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(34).Width = 120F;
            this.spdList_Sheet1.Columns.Get(35).Label = "NSTD Flag";
            this.spdList_Sheet1.Columns.Get(35).Locked = true;
            this.spdList_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(35).Width = 62F;
            this.spdList_Sheet1.Columns.Get(36).Label = "NSTD Return Flow";
            this.spdList_Sheet1.Columns.Get(36).Locked = true;
            this.spdList_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(36).Width = 118F;
            this.spdList_Sheet1.Columns.Get(37).Label = "NSTD Return Oper";
            this.spdList_Sheet1.Columns.Get(37).Locked = true;
            this.spdList_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(37).Width = 114F;
            this.spdList_Sheet1.Columns.Get(38).Label = "NSTD Time";
            this.spdList_Sheet1.Columns.Get(38).Locked = true;
            this.spdList_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(38).Width = 120F;
            this.spdList_Sheet1.Columns.Get(39).Label = "Repair Flag";
            this.spdList_Sheet1.Columns.Get(39).Locked = true;
            this.spdList_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(39).Width = 82F;
            this.spdList_Sheet1.Columns.Get(40).Label = "Repair Oper";
            this.spdList_Sheet1.Columns.Get(40).Locked = true;
            this.spdList_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(40).Width = 87F;
            this.spdList_Sheet1.Columns.Get(41).Label = "Store Return Flow";
            this.spdList_Sheet1.Columns.Get(41).Locked = true;
            this.spdList_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(41).Width = 129F;
            this.spdList_Sheet1.Columns.Get(42).Label = "Store Return Flow Seq";
            this.spdList_Sheet1.Columns.Get(42).Locked = true;
            this.spdList_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(42).Width = 129F;
            this.spdList_Sheet1.Columns.Get(43).Label = "Store Return Oper";
            this.spdList_Sheet1.Columns.Get(43).Locked = true;
            this.spdList_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(43).Width = 129F;
            this.spdList_Sheet1.Columns.Get(44).Label = "Start Flag";
            this.spdList_Sheet1.Columns.Get(44).Locked = true;
            this.spdList_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(44).Width = 66F;
            this.spdList_Sheet1.Columns.Get(45).CellType = textCellType1;
            this.spdList_Sheet1.Columns.Get(45).Label = "Start Time";
            this.spdList_Sheet1.Columns.Get(45).Locked = true;
            this.spdList_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).Width = 127F;
            this.spdList_Sheet1.Columns.Get(46).Label = "Start Resource ID";
            this.spdList_Sheet1.Columns.Get(46).Locked = true;
            this.spdList_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(46).Width = 110F;
            this.spdList_Sheet1.Columns.Get(47).Label = "End Flag";
            this.spdList_Sheet1.Columns.Get(47).Locked = true;
            this.spdList_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(48).Label = "End Time";
            this.spdList_Sheet1.Columns.Get(48).Locked = true;
            this.spdList_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(48).Width = 127F;
            this.spdList_Sheet1.Columns.Get(49).Label = "End Resource ID";
            this.spdList_Sheet1.Columns.Get(49).Locked = true;
            this.spdList_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(49).Width = 105F;
            this.spdList_Sheet1.Columns.Get(50).Label = "Sample Flag";
            this.spdList_Sheet1.Columns.Get(50).Locked = true;
            this.spdList_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(50).Width = 84F;
            this.spdList_Sheet1.Columns.Get(51).Label = "Sample Wait Flag";
            this.spdList_Sheet1.Columns.Get(51).Locked = true;
            this.spdList_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(51).Width = 109F;
            this.spdList_Sheet1.Columns.Get(52).Label = "Sample Result";
            this.spdList_Sheet1.Columns.Get(52).Locked = true;
            this.spdList_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(52).Width = 98F;
            this.spdList_Sheet1.Columns.Get(53).Label = "From To Lot ID";
            this.spdList_Sheet1.Columns.Get(53).Locked = true;
            this.spdList_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(53).Width = 105F;
            this.spdList_Sheet1.Columns.Get(54).Label = "Ship Code";
            this.spdList_Sheet1.Columns.Get(54).Locked = true;
            this.spdList_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(54).Width = 69F;
            this.spdList_Sheet1.Columns.Get(55).Label = "Ship Time";
            this.spdList_Sheet1.Columns.Get(55).Locked = true;
            this.spdList_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(55).Width = 123F;
            this.spdList_Sheet1.Columns.Get(56).Label = "Original Due Time";
            this.spdList_Sheet1.Columns.Get(56).Locked = true;
            this.spdList_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(56).Width = 123F;
            this.spdList_Sheet1.Columns.Get(57).Label = "Scheduled Due Time";
            this.spdList_Sheet1.Columns.Get(57).Locked = true;
            this.spdList_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(57).Width = 136F;
            this.spdList_Sheet1.Columns.Get(58).Label = "Create Time";
            this.spdList_Sheet1.Columns.Get(58).Locked = true;
            this.spdList_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(58).Width = 123F;
            this.spdList_Sheet1.Columns.Get(59).Label = "Factory In Time";
            this.spdList_Sheet1.Columns.Get(59).Locked = true;
            this.spdList_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(59).Width = 123F;
            this.spdList_Sheet1.Columns.Get(60).Label = "Flow In Time";
            this.spdList_Sheet1.Columns.Get(60).Locked = true;
            this.spdList_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(60).Width = 123F;
            this.spdList_Sheet1.Columns.Get(61).Label = "Oper In Time";
            this.spdList_Sheet1.Columns.Get(61).Locked = true;
            this.spdList_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(61).Width = 123F;
            this.spdList_Sheet1.Columns.Get(62).Label = "Reserve Resource ID";
            this.spdList_Sheet1.Columns.Get(62).Locked = true;
            this.spdList_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(62).Width = 129F;
            this.spdList_Sheet1.Columns.Get(63).Label = "Batch ID";
            this.spdList_Sheet1.Columns.Get(63).Locked = true;
            this.spdList_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType11.DecimalPlaces = 0;
            numberCellType11.MaximumValue = 9999D;
            numberCellType11.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(64).CellType = numberCellType11;
            this.spdList_Sheet1.Columns.Get(64).Label = "Batch Seq";
            this.spdList_Sheet1.Columns.Get(64).Locked = true;
            this.spdList_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(64).Width = 72F;
            this.spdList_Sheet1.Columns.Get(65).Label = "Order ID";
            this.spdList_Sheet1.Columns.Get(65).Locked = true;
            this.spdList_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(65).Width = 100F;
            this.spdList_Sheet1.Columns.Get(66).Label = "Add Order ID 1";
            this.spdList_Sheet1.Columns.Get(66).Locked = true;
            this.spdList_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(66).Width = 100F;
            this.spdList_Sheet1.Columns.Get(67).Label = "Add Order ID 2";
            this.spdList_Sheet1.Columns.Get(67).Locked = true;
            this.spdList_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(67).Width = 100F;
            this.spdList_Sheet1.Columns.Get(68).Label = "Add Order ID 3";
            this.spdList_Sheet1.Columns.Get(68).Locked = true;
            this.spdList_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(68).Width = 100F;
            this.spdList_Sheet1.Columns.Get(69).Label = "Lot Location";
            this.spdList_Sheet1.Columns.Get(69).Locked = true;
            this.spdList_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(69).Width = 82F;
            this.spdList_Sheet1.Columns.Get(70).Label = "Lot CMF 1";
            this.spdList_Sheet1.Columns.Get(70).Locked = true;
            this.spdList_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(70).Width = 79F;
            this.spdList_Sheet1.Columns.Get(71).Label = "Lot CMF 2";
            this.spdList_Sheet1.Columns.Get(71).Locked = true;
            this.spdList_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(71).Width = 79F;
            this.spdList_Sheet1.Columns.Get(72).Label = "Lot CMF 3";
            this.spdList_Sheet1.Columns.Get(72).Locked = true;
            this.spdList_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(72).Width = 79F;
            this.spdList_Sheet1.Columns.Get(73).Label = "Lot CMF 4";
            this.spdList_Sheet1.Columns.Get(73).Locked = true;
            this.spdList_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(73).Width = 79F;
            this.spdList_Sheet1.Columns.Get(74).Label = "Lot CMF 5";
            this.spdList_Sheet1.Columns.Get(74).Locked = true;
            this.spdList_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(74).Width = 79F;
            this.spdList_Sheet1.Columns.Get(75).Label = "Lot CMF 6";
            this.spdList_Sheet1.Columns.Get(75).Locked = true;
            this.spdList_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(75).Width = 79F;
            this.spdList_Sheet1.Columns.Get(76).Label = "Lot CMF 7";
            this.spdList_Sheet1.Columns.Get(76).Locked = true;
            this.spdList_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(76).Width = 79F;
            this.spdList_Sheet1.Columns.Get(77).Label = "Lot CMF 8";
            this.spdList_Sheet1.Columns.Get(77).Locked = true;
            this.spdList_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(77).Width = 79F;
            this.spdList_Sheet1.Columns.Get(78).Label = "Lot CMF 9";
            this.spdList_Sheet1.Columns.Get(78).Locked = true;
            this.spdList_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(78).Width = 79F;
            this.spdList_Sheet1.Columns.Get(79).Label = "Lot CMF 10";
            this.spdList_Sheet1.Columns.Get(79).Locked = true;
            this.spdList_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(79).Width = 79F;
            this.spdList_Sheet1.Columns.Get(80).Label = "Lot CMF 11";
            this.spdList_Sheet1.Columns.Get(80).Locked = true;
            this.spdList_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(80).Width = 80F;
            this.spdList_Sheet1.Columns.Get(81).Label = "Lot CMF 12";
            this.spdList_Sheet1.Columns.Get(81).Locked = true;
            this.spdList_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(81).Width = 80F;
            this.spdList_Sheet1.Columns.Get(82).Label = "Lot CMF 13";
            this.spdList_Sheet1.Columns.Get(82).Locked = true;
            this.spdList_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(82).Width = 80F;
            this.spdList_Sheet1.Columns.Get(83).Label = "Lot CMF 14";
            this.spdList_Sheet1.Columns.Get(83).Locked = true;
            this.spdList_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(83).Width = 80F;
            this.spdList_Sheet1.Columns.Get(84).Label = "Lot CMF 15";
            this.spdList_Sheet1.Columns.Get(84).Locked = true;
            this.spdList_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(84).Width = 80F;
            this.spdList_Sheet1.Columns.Get(85).Label = "Lot CMF 16";
            this.spdList_Sheet1.Columns.Get(85).Locked = true;
            this.spdList_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(85).Width = 80F;
            this.spdList_Sheet1.Columns.Get(86).Label = "Lot CMF 17";
            this.spdList_Sheet1.Columns.Get(86).Locked = true;
            this.spdList_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(86).Width = 80F;
            this.spdList_Sheet1.Columns.Get(87).Label = "Lot CMF 18";
            this.spdList_Sheet1.Columns.Get(87).Locked = true;
            this.spdList_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(87).Width = 80F;
            this.spdList_Sheet1.Columns.Get(88).Label = "Lot CMF 19";
            this.spdList_Sheet1.Columns.Get(88).Locked = true;
            this.spdList_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(88).Width = 80F;
            this.spdList_Sheet1.Columns.Get(89).Label = "Lot Cmf 20";
            this.spdList_Sheet1.Columns.Get(89).Locked = true;
            this.spdList_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(89).Width = 80F;
            this.spdList_Sheet1.Columns.Get(90).Label = "BOM Set ID";
            this.spdList_Sheet1.Columns.Get(90).Locked = true;
            this.spdList_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(90).Width = 100F;
            this.spdList_Sheet1.Columns.Get(91).Label = "BOM Set Version";
            this.spdList_Sheet1.Columns.Get(91).Locked = true;
            this.spdList_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(91).Width = 100F;
            this.spdList_Sheet1.Columns.Get(92).Label = "BOM Act Hist Seq";
            this.spdList_Sheet1.Columns.Get(92).Locked = true;
            this.spdList_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(92).Width = 100F;
            this.spdList_Sheet1.Columns.Get(93).Label = "BOM Hist Seq";
            this.spdList_Sheet1.Columns.Get(93).Locked = true;
            this.spdList_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(93).Width = 100F;
            this.spdList_Sheet1.Columns.Get(94).Label = "Lot Delete Flag";
            this.spdList_Sheet1.Columns.Get(94).Locked = true;
            this.spdList_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(94).Width = 101F;
            this.spdList_Sheet1.Columns.Get(95).Label = "Lot Delete Reason";
            this.spdList_Sheet1.Columns.Get(95).Locked = true;
            this.spdList_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(95).Width = 119F;
            this.spdList_Sheet1.Columns.Get(96).Label = "Lot Delete Time";
            this.spdList_Sheet1.Columns.Get(96).Locked = true;
            this.spdList_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(96).Width = 129F;
            this.spdList_Sheet1.Columns.Get(97).Label = "Last Tran Code";
            this.spdList_Sheet1.Columns.Get(97).Locked = true;
            this.spdList_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(97).Width = 104F;
            this.spdList_Sheet1.Columns.Get(98).Label = "Last Tran Time";
            this.spdList_Sheet1.Columns.Get(98).Locked = true;
            this.spdList_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(98).Width = 128F;
            this.spdList_Sheet1.Columns.Get(99).Label = "Last Comment";
            this.spdList_Sheet1.Columns.Get(99).Locked = true;
            this.spdList_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(99).Width = 220F;
            numberCellType12.DecimalPlaces = 0;
            numberCellType12.MaximumValue = 9999D;
            numberCellType12.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(100).CellType = numberCellType12;
            this.spdList_Sheet1.Columns.Get(100).Label = "Last Active Hist Seq";
            this.spdList_Sheet1.Columns.Get(100).Locked = true;
            this.spdList_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(100).Width = 130F;
            numberCellType13.DecimalPlaces = 0;
            numberCellType13.MaximumValue = 9999D;
            numberCellType13.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(101).CellType = numberCellType13;
            this.spdList_Sheet1.Columns.Get(101).Label = "Last Hist Seq";
            this.spdList_Sheet1.Columns.Get(101).Locked = true;
            this.spdList_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(101).Width = 91F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPViewLotListByOperation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewLotListByOperation";
            this.Text = "View Lot List By Operation";
            this.Activated += new System.EventHandler(this.frmWIPViewLotListByOperation_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroupType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        private string[] sGroupTableName = new string[10];
        
        #endregion
        
        #region " Function Definition "
        
        // SetTableName()
        //       - Set Operation Group Table Name
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private void SetTableName()
        {
            sGroupTableName[0] = MPGC.MP_GCM_OPER_GRP_1;
            sGroupTableName[1] = MPGC.MP_GCM_OPER_GRP_2;
            sGroupTableName[2] = MPGC.MP_GCM_OPER_GRP_3;
            sGroupTableName[3] = MPGC.MP_GCM_OPER_GRP_4;
            sGroupTableName[4] = MPGC.MP_GCM_OPER_GRP_5;
            sGroupTableName[5] = MPGC.MP_GCM_OPER_GRP_6;
            sGroupTableName[6] = MPGC.MP_GCM_OPER_GRP_7;
            sGroupTableName[7] = MPGC.MP_GCM_OPER_GRP_8;
            sGroupTableName[8] = MPGC.MP_GCM_OPER_GRP_9;
            sGroupTableName[9] = MPGC.MP_GCM_OPER_GRP_10;
        }
        
        // SetOperGroupPrompt()
        //       - Set Group Property to control
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool SetOperGroupPrompt(Miracom.UI.Controls.MCCodeView.MCCodeView cdvList)
        {
            TRSNode out_node = new TRSNode("VIEW_FACTORY_CMF_ITEM_OUT");
            ListViewItem itmx = null;
            int i;

            try
            {
                cdvList.Items.Clear();

                if (WIPLIST.ViewFactoryCmfData('1', MPGC.MP_GRP_OPERATION, ref out_node, "", true) == false)
                {
                    return false;
                }
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    if (out_node.GetList(0)[i].GetString("PROMPT") != "")
                    {
                        itmx = new ListViewItem(out_node.GetList(0)[i].GetString("PROMPT"), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                        if (out_node.GetList(0)[i].GetString("TABLE_NAME") == "")
                        {
                            itmx.SubItems.Add(sGroupTableName[i]);
                        }
                        else
                        {
                            itmx.SubItems.Add(out_node.GetList(0)[i].GetString("TABLE_NAME"));
                        }
                        cdvList.Items.Add(itmx);
                    }
                }

                cdvList.AddEmptyRow(1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        
        // View_Lot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_Lot_List()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
            int i;

            MPCF.ClearList(spdList, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));
            in_node.AddString("GRP_1", MPCF.Trim(cdvGroup.Text));
            in_node.AddString("TABLE_NAME_1", MPCF.Trim(cdvGroupType.Text));
            in_node.AddChar("ZERO_QTY_FLAG", chkZeroQtyLot.Checked == true ? 'Y' : ' ');
            in_node.AddChar("LOT_DEL_FLAG", chkTerminatedLot.Checked == true ? 'Y' : ' ');

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Lot_List_By_Operation", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    WIPLIST.DisplayLotListDetail(spdList, out_node.GetList(0)[i], 0);
                }

                in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
            } while (in_node.GetString("NEXT_LOT_ID") != "");

            MPCF.FitColumnHeader(spdList);
            return true;
        }

        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvMaterial;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmWIPViewLotListByOperation_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);
                
                SetTableName();
                b_load_flag = true;
            }
            
        }
        
        private void cdvGroupType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvGroupType.Init();
            MPCF.InitListView(cdvGroupType.GetListView);
            cdvGroupType.Columns.Add("Group", 50, HorizontalAlignment.Left);
            cdvGroupType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvGroupType.SelectedSubItemIndex = 1;
            cdvGroupType.DisplaySubItemIndex = 0;
            cdvGroupType.ReadOnly = true;
            SetOperGroupPrompt((Miracom.UI.Controls.MCCodeView.MCCodeView)sender);
        }
        
        private void cdvGroup1_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                if (cdvGroupType.Text == "")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    cdvGroupType.Focus();
                    cdvGroup.IsPopup = false;
                    return;
                }
                
                cdvGroup.Init();
                MPCF.InitListView(cdvGroup.GetListView);
                cdvGroup.Columns.Add("Group", 50, HorizontalAlignment.Left);
                cdvGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvGroup.SelectedSubItemIndex = 0;
                if (BASLIST.ViewGCMDataList(cdvGroup.GetListView, '1', cdvGroupType.Text) == false)
                {
                    return;
                }
                cdvGroup.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void cdvMaterial_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvFlow.Text = "";
            cdvOperation.Text = "";
            
        }
        
        private void cdvFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvOperation.Text = "";
            
        }
        
        private void cdvFlow_ButtonPress(object sender, System.EventArgs e)
        {
            
            if (cdvMaterial.Text == "")
            {
                cdvFlow.ListCond_Step = '1';
            }
            else
            {
                cdvFlow.ListCond_Step = '2';
                cdvFlow.ListCond_MatID = cdvMaterial.Text;
                cdvFlow.ListCond_MatVersion = cdvMaterial.Version;
            }
            
        }
        
        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {
            cdvOperation.Init();
            MPCF.InitListView(cdvOperation.GetListView);
            cdvOperation.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            cdvOperation.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvOperation.SelectedSubItemIndex = 0;
            if (cdvMaterial.Text != "" && cdvFlow.Text != "")
            {
                WIPLIST.ViewOperationList(cdvOperation.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "");
            }
            else
            {
                if (cdvFlow.Text == "")
                {
                    if (cdvMaterial.Text == "")
                    {
                        WIPLIST.ViewOperationList(cdvOperation.GetListView, '1', "",0, "", "", null, "");
                    }
                    else
                    {
                        WIPLIST.ViewOperationList(cdvOperation.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, "", "", null, "");
                    }
                }
                else
                {
                    WIPLIST.ViewOperationList(cdvOperation.GetListView, '2', "", 0,cdvFlow.Text, "", null, "");
                }
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (MPCF.Trim(cdvOperation.Text) == "" && MPCF.Trim(cdvGroupType.Text) == "" && MPCF.Trim(cdvGroup.Text) == "")
            {
                if (MPCF.CheckValue(cdvOperation, 1) == false)
                {
                    return;
                }
            }

            View_Lot_List();
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Operation : " + MPCF.Trim(cdvOperation.Text);

            if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
            
        }
        
        
        private void cdvGroupType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvGroup.DisplayText = "";
            cdvGroup.Text = "";
        }
        
    }
    
}
