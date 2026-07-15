
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
    public class frmWIPViewDataListByAttribute : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewDataListByAttribute()
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
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrValue;
        private System.Windows.Forms.Label lblAttrOper;
        private System.Windows.Forms.CheckBox chkTerminatedLot;
        private System.Windows.Forms.CheckBox chkZeroQtyLot;
        private FarPoint.Win.Spread.FpSpread spdList;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrName;
        private Label lblAttrName;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvAttrType;
        private Label lblAttrType;
        private Miracom.MESCore.Controls.udcFlowAndSeq cdvFlow;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private Miracom.MESCore.Controls.udcOperation cdvOperation;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvLotID;
        private Label lblLot;
        private FarPoint.Win.Spread.SheetView spdList_Sheet2;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
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
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType14 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType15 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType16 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType17 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType18 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType19 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType20 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType21 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType22 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.cdvAttrValue = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrOper = new System.Windows.Forms.Label();
            this.chkTerminatedLot = new System.Windows.Forms.CheckBox();
            this.chkZeroQtyLot = new System.Windows.Forms.CheckBox();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdList_Sheet2 = new FarPoint.Win.Spread.SheetView();
            this.cdvAttrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrType = new System.Windows.Forms.Label();
            this.cdvAttrName = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblAttrName = new System.Windows.Forms.Label();
            this.cdvFlow = new Miracom.MESCore.Controls.udcFlowAndSeq();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.cdvOperation = new Miracom.MESCore.Controls.udcOperation();
            this.cdvLotID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblLot = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotID)).BeginInit();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 92);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvLotID);
            this.grpOption.Controls.Add(this.lblLot);
            this.grpOption.Controls.Add(this.cdvOperation);
            this.grpOption.Controls.Add(this.cdvFlow);
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.cdvAttrName);
            this.grpOption.Controls.Add(this.lblAttrName);
            this.grpOption.Controls.Add(this.cdvAttrType);
            this.grpOption.Controls.Add(this.lblAttrType);
            this.grpOption.Controls.Add(this.chkZeroQtyLot);
            this.grpOption.Controls.Add(this.cdvAttrValue);
            this.grpOption.Controls.Add(this.chkTerminatedLot);
            this.grpOption.Controls.Add(this.lblAttrOper);
            this.grpOption.Size = new System.Drawing.Size(742, 92);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 92);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 421);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 0;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot List By Operation";
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
            // cdvAttrValue
            // 
            this.cdvAttrValue.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrValue.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrValue.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrValue.BtnToolTipText = "";
            this.cdvAttrValue.DescText = "";
            this.cdvAttrValue.DisplaySubItemIndex = -1;
            this.cdvAttrValue.DisplayText = "";
            this.cdvAttrValue.Focusing = null;
            this.cdvAttrValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrValue.Index = 0;
            this.cdvAttrValue.IsViewBtnImage = false;
            this.cdvAttrValue.Location = new System.Drawing.Point(107, 66);
            this.cdvAttrValue.MaxLength = 1000;
            this.cdvAttrValue.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrValue.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrValue.Name = "cdvAttrValue";
            this.cdvAttrValue.ReadOnly = false;
            this.cdvAttrValue.SearchSubItemIndex = 0;
            this.cdvAttrValue.SelectedDescIndex = -1;
            this.cdvAttrValue.SelectedSubItemIndex = -1;
            this.cdvAttrValue.SelectionStart = 0;
            this.cdvAttrValue.Size = new System.Drawing.Size(148, 20);
            this.cdvAttrValue.SmallImageList = null;
            this.cdvAttrValue.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrValue.TabIndex = 5;
            this.cdvAttrValue.TextBoxToolTipText = "";
            this.cdvAttrValue.TextBoxWidth = 148;
            this.cdvAttrValue.VisibleButton = false;
            this.cdvAttrValue.VisibleColumnHeader = false;
            this.cdvAttrValue.VisibleDescription = false;
            this.cdvAttrValue.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrValue_SelectedItemChanged);
            this.cdvAttrValue.ButtonPress += new System.EventHandler(this.cdvAttrValue_ButtonPress);
            // 
            // lblAttrOper
            // 
            this.lblAttrOper.AutoSize = true;
            this.lblAttrOper.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrOper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrOper.Location = new System.Drawing.Point(15, 69);
            this.lblAttrOper.Name = "lblAttrOper";
            this.lblAttrOper.Size = new System.Drawing.Size(91, 13);
            this.lblAttrOper.TabIndex = 4;
            this.lblAttrOper.Text = "Attribute Value";
            this.lblAttrOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkTerminatedLot
            // 
            this.chkTerminatedLot.AutoSize = true;
            this.chkTerminatedLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkTerminatedLot.Location = new System.Drawing.Point(562, 67);
            this.chkTerminatedLot.Name = "chkTerminatedLot";
            this.chkTerminatedLot.Size = new System.Drawing.Size(141, 18);
            this.chkTerminatedLot.TabIndex = 12;
            this.chkTerminatedLot.Text = "Include Terminated Lot";
            // 
            // chkZeroQtyLot
            // 
            this.chkZeroQtyLot.AutoSize = true;
            this.chkZeroQtyLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkZeroQtyLot.Location = new System.Drawing.Point(562, 43);
            this.chkZeroQtyLot.Name = "chkZeroQtyLot";
            this.chkZeroQtyLot.Size = new System.Drawing.Size(114, 18);
            this.chkZeroQtyLot.TabIndex = 11;
            this.chkZeroQtyLot.Text = "Zero Quantity Lot";
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "spdList, Sheet2, Row 0, Column 0, ";
            this.spdList.BackColor = System.Drawing.SystemColors.Control;
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 4;
            this.spdList.Location = new System.Drawing.Point(0, 3);
            this.spdList.Name = "spdList";
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
            this.spdList.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1,
            this.spdList_Sheet2});
            this.spdList.Size = new System.Drawing.Size(742, 418);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            this.spdList.TabStripPolicy = FarPoint.Win.Spread.TabStripPolicy.Never;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 5;
            spdList.ActiveSheetIndex = 1;
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 103;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Attr Value";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat Ver";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Qty 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Lot Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Owner Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Create Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Priority";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Lot Status";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Hold Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Hold Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Create Qty 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Create Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Create Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Oper In Qty 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Oper In Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Oper In Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Inventory Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Transit Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Unit Exist Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Inv Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Rework Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Rework Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Rework Count";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Rework Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Rework Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Rework End Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Rework End Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Rework Return Clear Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Rework Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "NSTD Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "NSTD Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "NSTD Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "NSTD Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Repair Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Repair Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Store Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Store Return Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Store Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Start Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Start Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Start Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "End Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "End Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "End Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Sample Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Sample Wait Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Sample Result";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "From To Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Ship Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Ship Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Original Due Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Scheduled Due Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Create Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Factory In Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Flow In Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Oper In Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Reserve Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Batch ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Batch Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "Order ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "Add Order ID 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "Add Order ID 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "Add Order ID 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "Lot Location";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "Lot CMF 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "Lot CMF 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "Lot CMF 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "Lot CMF 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "Lot CMF 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "Lot CMF 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Lot CMF 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Lot CMF 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 79).Value = "Lot CMF 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 80).Value = "Lot CMF 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 81).Value = "Lot CMF 11";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 82).Value = "Lot CMF 12";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 83).Value = "Lot CMF 13";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 84).Value = "Lot CMF 14";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 85).Value = "Lot CMF 15";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 86).Value = "Lot CMF 16";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 87).Value = "Lot CMF 17";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 88).Value = "Lot CMF 18";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 89).Value = "Lot CMF 19";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 90).Value = "Lot Cmf 20";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 91).Value = "BOM Set ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 92).Value = "BOM Set Version";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 93).Value = "BOM Act Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 94).Value = "BOM Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 95).Value = "Lot Delete Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 96).Value = "Lot Delete Reason";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 97).Value = "Lot Delete Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 98).Value = "Last Tran Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 99).Value = "Last Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 100).Value = "Last Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 101).Value = "Last Active Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 102).Value = "Last Hist Seq";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdList_Sheet1.Columns.Get(0).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 102F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Attr Value";
            this.spdList_Sheet1.Columns.Get(1).Width = 89F;
            this.spdList_Sheet1.Columns.Get(2).Label = "Material";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 103F;
            this.spdList_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Label = "Mat Ver";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Label = "Flow";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 82F;
            this.spdList_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Label = "Flow Seq";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Label = "Oper";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 66F;
            numberCellType1.DecimalPlaces = 3;
            numberCellType1.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(7).CellType = numberCellType1;
            this.spdList_Sheet1.Columns.Get(7).Label = "Qty 1";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 73F;
            numberCellType2.DecimalPlaces = 3;
            numberCellType2.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(8).CellType = numberCellType2;
            this.spdList_Sheet1.Columns.Get(8).Label = "Qty 2";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 73F;
            numberCellType3.DecimalPlaces = 3;
            numberCellType3.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(9).CellType = numberCellType3;
            this.spdList_Sheet1.Columns.Get(9).Label = "Qty 3";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 73F;
            this.spdList_Sheet1.Columns.Get(10).Label = "Lot Type";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Label = "Owner Code";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 79F;
            this.spdList_Sheet1.Columns.Get(12).Label = "Create Code";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 79F;
            this.spdList_Sheet1.Columns.Get(13).Label = "Priority";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Label = "Lot Status";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 72F;
            this.spdList_Sheet1.Columns.Get(15).Label = "Hold Flag";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 66F;
            this.spdList_Sheet1.Columns.Get(16).Label = "Hold Code";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Width = 70F;
            numberCellType4.DecimalPlaces = 3;
            numberCellType4.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(17).CellType = numberCellType4;
            this.spdList_Sheet1.Columns.Get(17).Label = "Create Qty 1";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 80F;
            numberCellType5.DecimalPlaces = 3;
            numberCellType5.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(18).CellType = numberCellType5;
            this.spdList_Sheet1.Columns.Get(18).Label = "Create Qty 2";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Width = 80F;
            numberCellType6.DecimalPlaces = 3;
            numberCellType6.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(19).CellType = numberCellType6;
            this.spdList_Sheet1.Columns.Get(19).Label = "Create Qty 3";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 80F;
            numberCellType7.DecimalPlaces = 3;
            numberCellType7.MaximumValue = 9999999.999D;
            numberCellType7.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(20).CellType = numberCellType7;
            this.spdList_Sheet1.Columns.Get(20).Label = "Oper In Qty 1";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 84F;
            numberCellType8.DecimalPlaces = 3;
            numberCellType8.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(21).CellType = numberCellType8;
            this.spdList_Sheet1.Columns.Get(21).Label = "Oper In Qty 2";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 84F;
            numberCellType9.DecimalPlaces = 3;
            numberCellType9.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(22).CellType = numberCellType9;
            this.spdList_Sheet1.Columns.Get(22).Label = "Oper In Qty 3";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 84F;
            this.spdList_Sheet1.Columns.Get(23).Label = "Inventory Flag";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 68F;
            this.spdList_Sheet1.Columns.Get(24).Label = "Transit Flag";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 82F;
            this.spdList_Sheet1.Columns.Get(25).Label = "Unit Exist Flag";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 89F;
            this.spdList_Sheet1.Columns.Get(26).Label = "Inv Unit";
            this.spdList_Sheet1.Columns.Get(26).Locked = true;
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Label = "Rework Flag";
            this.spdList_Sheet1.Columns.Get(27).Locked = true;
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 79F;
            this.spdList_Sheet1.Columns.Get(28).Label = "Rework Code";
            this.spdList_Sheet1.Columns.Get(28).Locked = true;
            this.spdList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).Width = 85F;
            numberCellType10.DecimalPlaces = 3;
            numberCellType10.MaximumValue = 9999D;
            numberCellType10.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(29).CellType = numberCellType10;
            this.spdList_Sheet1.Columns.Get(29).Label = "Rework Count";
            this.spdList_Sheet1.Columns.Get(29).Locked = true;
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 87F;
            this.spdList_Sheet1.Columns.Get(30).Label = "Rework Return Flow";
            this.spdList_Sheet1.Columns.Get(30).Locked = true;
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 123F;
            this.spdList_Sheet1.Columns.Get(31).Label = "Rework Return Oper";
            this.spdList_Sheet1.Columns.Get(31).Locked = true;
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 123F;
            this.spdList_Sheet1.Columns.Get(32).Label = "Rework End Flow";
            this.spdList_Sheet1.Columns.Get(32).Locked = true;
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 117F;
            this.spdList_Sheet1.Columns.Get(33).Label = "Rework End Oper";
            this.spdList_Sheet1.Columns.Get(33).Locked = true;
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 113F;
            this.spdList_Sheet1.Columns.Get(34).Label = "Rework Return Clear Flag";
            this.spdList_Sheet1.Columns.Get(34).Locked = true;
            this.spdList_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(34).Width = 154F;
            this.spdList_Sheet1.Columns.Get(35).Label = "Rework Time";
            this.spdList_Sheet1.Columns.Get(35).Locked = true;
            this.spdList_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(35).Width = 120F;
            this.spdList_Sheet1.Columns.Get(36).Label = "NSTD Flag";
            this.spdList_Sheet1.Columns.Get(36).Locked = true;
            this.spdList_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(36).Width = 62F;
            this.spdList_Sheet1.Columns.Get(37).Label = "NSTD Return Flow";
            this.spdList_Sheet1.Columns.Get(37).Locked = true;
            this.spdList_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(37).Width = 118F;
            this.spdList_Sheet1.Columns.Get(38).Label = "NSTD Return Oper";
            this.spdList_Sheet1.Columns.Get(38).Locked = true;
            this.spdList_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(38).Width = 114F;
            this.spdList_Sheet1.Columns.Get(39).Label = "NSTD Time";
            this.spdList_Sheet1.Columns.Get(39).Locked = true;
            this.spdList_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(39).Width = 120F;
            this.spdList_Sheet1.Columns.Get(40).Label = "Repair Flag";
            this.spdList_Sheet1.Columns.Get(40).Locked = true;
            this.spdList_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(40).Width = 76F;
            this.spdList_Sheet1.Columns.Get(41).Label = "Repair Oper";
            this.spdList_Sheet1.Columns.Get(41).Locked = true;
            this.spdList_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(41).Width = 77F;
            this.spdList_Sheet1.Columns.Get(42).Label = "Store Return Flow";
            this.spdList_Sheet1.Columns.Get(42).Locked = true;
            this.spdList_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(42).Width = 97F;
            this.spdList_Sheet1.Columns.Get(43).Label = "Store Return Flow Seq";
            this.spdList_Sheet1.Columns.Get(43).Locked = true;
            this.spdList_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(43).Width = 119F;
            this.spdList_Sheet1.Columns.Get(44).Label = "Store Return Oper";
            this.spdList_Sheet1.Columns.Get(44).Locked = true;
            this.spdList_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(44).Width = 103F;
            this.spdList_Sheet1.Columns.Get(45).Label = "Start Flag";
            this.spdList_Sheet1.Columns.Get(45).Locked = true;
            this.spdList_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).Width = 66F;
            this.spdList_Sheet1.Columns.Get(46).CellType = textCellType1;
            this.spdList_Sheet1.Columns.Get(46).Label = "Start Time";
            this.spdList_Sheet1.Columns.Get(46).Locked = true;
            this.spdList_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(46).Width = 127F;
            this.spdList_Sheet1.Columns.Get(47).Label = "Start Resource ID";
            this.spdList_Sheet1.Columns.Get(47).Locked = true;
            this.spdList_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(47).Width = 110F;
            this.spdList_Sheet1.Columns.Get(48).Label = "End Flag";
            this.spdList_Sheet1.Columns.Get(48).Locked = true;
            this.spdList_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(49).Label = "End Time";
            this.spdList_Sheet1.Columns.Get(49).Locked = true;
            this.spdList_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(49).Width = 127F;
            this.spdList_Sheet1.Columns.Get(50).Label = "End Resource ID";
            this.spdList_Sheet1.Columns.Get(50).Locked = true;
            this.spdList_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(50).Width = 105F;
            this.spdList_Sheet1.Columns.Get(51).Label = "Sample Flag";
            this.spdList_Sheet1.Columns.Get(51).Locked = true;
            this.spdList_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(51).Width = 84F;
            this.spdList_Sheet1.Columns.Get(52).Label = "Sample Wait Flag";
            this.spdList_Sheet1.Columns.Get(52).Locked = true;
            this.spdList_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(52).Width = 109F;
            this.spdList_Sheet1.Columns.Get(53).Label = "Sample Result";
            this.spdList_Sheet1.Columns.Get(53).Locked = true;
            this.spdList_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(53).Width = 98F;
            this.spdList_Sheet1.Columns.Get(54).Label = "From To Lot ID";
            this.spdList_Sheet1.Columns.Get(54).Locked = true;
            this.spdList_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(54).Width = 105F;
            this.spdList_Sheet1.Columns.Get(55).Label = "Ship Code";
            this.spdList_Sheet1.Columns.Get(55).Locked = true;
            this.spdList_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(55).Width = 69F;
            this.spdList_Sheet1.Columns.Get(56).Label = "Ship Time";
            this.spdList_Sheet1.Columns.Get(56).Locked = true;
            this.spdList_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(56).Width = 123F;
            this.spdList_Sheet1.Columns.Get(57).Label = "Original Due Time";
            this.spdList_Sheet1.Columns.Get(57).Locked = true;
            this.spdList_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(57).Width = 123F;
            this.spdList_Sheet1.Columns.Get(58).Label = "Scheduled Due Time";
            this.spdList_Sheet1.Columns.Get(58).Locked = true;
            this.spdList_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(58).Width = 136F;
            this.spdList_Sheet1.Columns.Get(59).Label = "Create Time";
            this.spdList_Sheet1.Columns.Get(59).Locked = true;
            this.spdList_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(59).Width = 123F;
            this.spdList_Sheet1.Columns.Get(60).Label = "Factory In Time";
            this.spdList_Sheet1.Columns.Get(60).Locked = true;
            this.spdList_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(60).Width = 123F;
            this.spdList_Sheet1.Columns.Get(61).Label = "Flow In Time";
            this.spdList_Sheet1.Columns.Get(61).Locked = true;
            this.spdList_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(61).Width = 123F;
            this.spdList_Sheet1.Columns.Get(62).Label = "Oper In Time";
            this.spdList_Sheet1.Columns.Get(62).Locked = true;
            this.spdList_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(62).Width = 123F;
            this.spdList_Sheet1.Columns.Get(63).Label = "Reserve Resource ID";
            this.spdList_Sheet1.Columns.Get(63).Locked = true;
            this.spdList_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(63).Width = 129F;
            this.spdList_Sheet1.Columns.Get(64).Label = "Batch ID";
            this.spdList_Sheet1.Columns.Get(64).Locked = true;
            this.spdList_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType11.DecimalPlaces = 3;
            numberCellType11.MaximumValue = 9999D;
            numberCellType11.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(65).CellType = numberCellType11;
            this.spdList_Sheet1.Columns.Get(65).Label = "Batch Seq";
            this.spdList_Sheet1.Columns.Get(65).Locked = true;
            this.spdList_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(65).Width = 72F;
            this.spdList_Sheet1.Columns.Get(66).Label = "Order ID";
            this.spdList_Sheet1.Columns.Get(66).Locked = true;
            this.spdList_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(66).Width = 100F;
            this.spdList_Sheet1.Columns.Get(67).Label = "Add Order ID 1";
            this.spdList_Sheet1.Columns.Get(67).Locked = true;
            this.spdList_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(67).Width = 100F;
            this.spdList_Sheet1.Columns.Get(68).Label = "Add Order ID 2";
            this.spdList_Sheet1.Columns.Get(68).Locked = true;
            this.spdList_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(68).Width = 100F;
            this.spdList_Sheet1.Columns.Get(69).Label = "Add Order ID 3";
            this.spdList_Sheet1.Columns.Get(69).Locked = true;
            this.spdList_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(69).Width = 100F;
            this.spdList_Sheet1.Columns.Get(70).Label = "Lot Location";
            this.spdList_Sheet1.Columns.Get(70).Locked = true;
            this.spdList_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(70).Width = 82F;
            this.spdList_Sheet1.Columns.Get(71).Label = "Lot CMF 1";
            this.spdList_Sheet1.Columns.Get(71).Locked = true;
            this.spdList_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(71).Width = 79F;
            this.spdList_Sheet1.Columns.Get(72).Label = "Lot CMF 2";
            this.spdList_Sheet1.Columns.Get(72).Locked = true;
            this.spdList_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(72).Width = 79F;
            this.spdList_Sheet1.Columns.Get(73).Label = "Lot CMF 3";
            this.spdList_Sheet1.Columns.Get(73).Locked = true;
            this.spdList_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(73).Width = 79F;
            this.spdList_Sheet1.Columns.Get(74).Label = "Lot CMF 4";
            this.spdList_Sheet1.Columns.Get(74).Locked = true;
            this.spdList_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(74).Width = 79F;
            this.spdList_Sheet1.Columns.Get(75).Label = "Lot CMF 5";
            this.spdList_Sheet1.Columns.Get(75).Locked = true;
            this.spdList_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(75).Width = 79F;
            this.spdList_Sheet1.Columns.Get(76).Label = "Lot CMF 6";
            this.spdList_Sheet1.Columns.Get(76).Locked = true;
            this.spdList_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(76).Width = 79F;
            this.spdList_Sheet1.Columns.Get(77).Label = "Lot CMF 7";
            this.spdList_Sheet1.Columns.Get(77).Locked = true;
            this.spdList_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(77).Width = 79F;
            this.spdList_Sheet1.Columns.Get(78).Label = "Lot CMF 8";
            this.spdList_Sheet1.Columns.Get(78).Locked = true;
            this.spdList_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(78).Width = 79F;
            this.spdList_Sheet1.Columns.Get(79).Label = "Lot CMF 9";
            this.spdList_Sheet1.Columns.Get(79).Locked = true;
            this.spdList_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(79).Width = 79F;
            this.spdList_Sheet1.Columns.Get(80).Label = "Lot CMF 10";
            this.spdList_Sheet1.Columns.Get(80).Locked = true;
            this.spdList_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(80).Width = 79F;
            this.spdList_Sheet1.Columns.Get(81).Label = "Lot CMF 11";
            this.spdList_Sheet1.Columns.Get(81).Locked = true;
            this.spdList_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(81).Width = 80F;
            this.spdList_Sheet1.Columns.Get(82).Label = "Lot CMF 12";
            this.spdList_Sheet1.Columns.Get(82).Locked = true;
            this.spdList_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(82).Width = 80F;
            this.spdList_Sheet1.Columns.Get(83).Label = "Lot CMF 13";
            this.spdList_Sheet1.Columns.Get(83).Locked = true;
            this.spdList_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(83).Width = 80F;
            this.spdList_Sheet1.Columns.Get(84).Label = "Lot CMF 14";
            this.spdList_Sheet1.Columns.Get(84).Locked = true;
            this.spdList_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(84).Width = 80F;
            this.spdList_Sheet1.Columns.Get(85).Label = "Lot CMF 15";
            this.spdList_Sheet1.Columns.Get(85).Locked = true;
            this.spdList_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(85).Width = 80F;
            this.spdList_Sheet1.Columns.Get(86).Label = "Lot CMF 16";
            this.spdList_Sheet1.Columns.Get(86).Locked = true;
            this.spdList_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(86).Width = 80F;
            this.spdList_Sheet1.Columns.Get(87).Label = "Lot CMF 17";
            this.spdList_Sheet1.Columns.Get(87).Locked = true;
            this.spdList_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(87).Width = 80F;
            this.spdList_Sheet1.Columns.Get(88).Label = "Lot CMF 18";
            this.spdList_Sheet1.Columns.Get(88).Locked = true;
            this.spdList_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(88).Width = 80F;
            this.spdList_Sheet1.Columns.Get(89).Label = "Lot CMF 19";
            this.spdList_Sheet1.Columns.Get(89).Locked = true;
            this.spdList_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(89).Width = 80F;
            this.spdList_Sheet1.Columns.Get(90).Label = "Lot Cmf 20";
            this.spdList_Sheet1.Columns.Get(90).Locked = true;
            this.spdList_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(90).Width = 80F;
            this.spdList_Sheet1.Columns.Get(91).Label = "BOM Set ID";
            this.spdList_Sheet1.Columns.Get(91).Locked = true;
            this.spdList_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(91).Width = 100F;
            this.spdList_Sheet1.Columns.Get(92).Label = "BOM Set Version";
            this.spdList_Sheet1.Columns.Get(92).Locked = true;
            this.spdList_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(92).Width = 100F;
            this.spdList_Sheet1.Columns.Get(93).Label = "BOM Act Hist Seq";
            this.spdList_Sheet1.Columns.Get(93).Locked = true;
            this.spdList_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(93).Width = 100F;
            this.spdList_Sheet1.Columns.Get(94).Label = "BOM Hist Seq";
            this.spdList_Sheet1.Columns.Get(94).Locked = true;
            this.spdList_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(94).Width = 100F;
            this.spdList_Sheet1.Columns.Get(95).Label = "Lot Delete Flag";
            this.spdList_Sheet1.Columns.Get(95).Locked = true;
            this.spdList_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(95).Width = 101F;
            this.spdList_Sheet1.Columns.Get(96).Label = "Lot Delete Reason";
            this.spdList_Sheet1.Columns.Get(96).Locked = true;
            this.spdList_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(96).Width = 119F;
            this.spdList_Sheet1.Columns.Get(97).Label = "Lot Delete Time";
            this.spdList_Sheet1.Columns.Get(97).Locked = true;
            this.spdList_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(97).Width = 129F;
            this.spdList_Sheet1.Columns.Get(98).Label = "Last Tran Code";
            this.spdList_Sheet1.Columns.Get(98).Locked = true;
            this.spdList_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(98).Width = 104F;
            this.spdList_Sheet1.Columns.Get(99).Label = "Last Tran Time";
            this.spdList_Sheet1.Columns.Get(99).Locked = true;
            this.spdList_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(99).Width = 128F;
            this.spdList_Sheet1.Columns.Get(100).Label = "Last Comment";
            this.spdList_Sheet1.Columns.Get(100).Locked = true;
            this.spdList_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(100).Width = 220F;
            numberCellType12.DecimalPlaces = 3;
            numberCellType12.MaximumValue = 9999D;
            numberCellType12.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(101).CellType = numberCellType12;
            this.spdList_Sheet1.Columns.Get(101).Label = "Last Active Hist Seq";
            this.spdList_Sheet1.Columns.Get(101).Locked = true;
            this.spdList_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(101).Width = 130F;
            numberCellType13.DecimalPlaces = 3;
            numberCellType13.MaximumValue = 9999D;
            numberCellType13.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(102).CellType = numberCellType13;
            this.spdList_Sheet1.Columns.Get(102).Label = "Last Hist Seq";
            this.spdList_Sheet1.Columns.Get(102).Locked = true;
            this.spdList_Sheet1.Columns.Get(102).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(102).Width = 91F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdList_Sheet2
            // 
            this.spdList_Sheet2.Reset();
            spdList_Sheet2.SheetName = "Sheet2";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet2.ColumnCount = 87;
            spdList_Sheet2.RowCount = 5;
            this.spdList_Sheet2.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet2.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet2.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet2.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet2.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 0).Value = "Slot No.";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 2).Value = "Sub Lot ID";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 3).Value = "Attr Value";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 4).Value = "Material";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 5).Value = "Mat Ver";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 6).Value = "Flow";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 7).Value = "Flow Seq";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 8).Value = "Oper";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 9).Value = "Qty 2";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 10).Value = "Qty 3";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 11).Value = "Carrier ID";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 12).Value = "Owner Code";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 13).Value = "Create Code";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 14).Value = "Status";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 15).Value = "Hold Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 16).Value = "Hold Code";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 17).Value = "Create Qty 2";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 18).Value = "Create Qty 3";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 19).Value = "Oper In Qty 2";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 20).Value = "Oper In Qty 3";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 21).Value = "Inventory Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 22).Value = "Transit Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 23).Value = "Tracking Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 24).Value = "Inv Unit";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 25).Value = "Rework Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 26).Value = "Rework Code";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 27).Value = "Rework Count";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 28).Value = "Rework Return Flow";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 29).Value = "Rework Return Oper";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 30).Value = "Rework End Flow";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 31).Value = "Rework End Oper";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 32).Value = "Rework Return Clear Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 33).Value = "Rework Time";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 34).Value = "NSTD Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 35).Value = "NSTD Return Flow";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 36).Value = "NSTD Return Oper";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 37).Value = "NSTD Time";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 38).Value = "Repair Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 39).Value = "Repair Oper";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 40).Value = "Store Return Flow";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 41).Value = "Store Return Flow Seq";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 42).Value = "Store Return Oper";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 43).Value = "Start Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 44).Value = "Start Time";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 45).Value = "Start Resource ID";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 46).Value = "End Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 47).Value = "End Time";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 48).Value = "End Resource ID";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 49).Value = "Sample Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 50).Value = "Sample Wait Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 51).Value = "Sample Result";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 52).Value = "Reserve Resource ID";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 53).Value = "Location";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 54).Value = "Lot CMF 1";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 55).Value = "Lot CMF 2";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 56).Value = "Lot CMF 3";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 57).Value = "Lot CMF 4";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 58).Value = "Lot CMF 5";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 59).Value = "Lot CMF 6";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 60).Value = "Lot CMF 7";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 61).Value = "Lot CMF 8";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 62).Value = "Lot CMF 9";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 63).Value = "Lot CMF 10";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 64).Value = "Lot CMF 11";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 65).Value = "Lot CMF 12";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 66).Value = "Lot CMF 13";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 67).Value = "Lot CMF 14";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 68).Value = "Lot CMF 15";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 69).Value = "Lot CMF 16";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 70).Value = "Lot CMF 17";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 71).Value = "Lot CMF 18";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 72).Value = "Lot CMF 19";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 73).Value = "Lot Cmf 20";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 74).Value = "Grade";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 75).Value = "Grade Code";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 76).Value = "Cell Grade";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 77).Value = "Cell Judge";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 78).Value = "Lot Base";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 79).Value = "Lot Delete Flag";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 80).Value = "Lot Delete Reason";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 81).Value = "Lot Delete Time";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 82).Value = "Last Tran Code";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 83).Value = "Last Tran Time";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 84).Value = "Last Comment";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 85).Value = "Last Active Hist Seq";
            this.spdList_Sheet2.ColumnHeader.Cells.Get(0, 86).Value = "Last Hist Seq";
            this.spdList_Sheet2.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet2.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet2.ColumnHeader.Rows.Get(0).Height = 33F;
            this.spdList_Sheet2.Columns.Get(0).Label = "Slot No.";
            this.spdList_Sheet2.Columns.Get(0).Width = 42F;
            this.spdList_Sheet2.Columns.Get(1).Label = "Lot ID";
            this.spdList_Sheet2.Columns.Get(1).Width = 101F;
            this.spdList_Sheet2.Columns.Get(2).Label = "Sub Lot ID";
            this.spdList_Sheet2.Columns.Get(2).Locked = true;
            this.spdList_Sheet2.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(2).Width = 101F;
            this.spdList_Sheet2.Columns.Get(3).Label = "Attr Value";
            this.spdList_Sheet2.Columns.Get(3).Width = 96F;
            this.spdList_Sheet2.Columns.Get(4).Label = "Material";
            this.spdList_Sheet2.Columns.Get(4).Locked = true;
            this.spdList_Sheet2.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(4).Width = 103F;
            this.spdList_Sheet2.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(5).Label = "Mat Ver";
            this.spdList_Sheet2.Columns.Get(5).Locked = true;
            this.spdList_Sheet2.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(6).Label = "Flow";
            this.spdList_Sheet2.Columns.Get(6).Locked = true;
            this.spdList_Sheet2.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(6).Width = 82F;
            this.spdList_Sheet2.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(7).Label = "Flow Seq";
            this.spdList_Sheet2.Columns.Get(7).Locked = true;
            this.spdList_Sheet2.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(8).Label = "Oper";
            this.spdList_Sheet2.Columns.Get(8).Locked = true;
            this.spdList_Sheet2.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(8).Width = 66F;
            numberCellType14.DecimalPlaces = 3;
            numberCellType14.MaximumValue = 9999D;
            numberCellType14.MinimumValue = 0D;
            this.spdList_Sheet2.Columns.Get(9).CellType = numberCellType14;
            this.spdList_Sheet2.Columns.Get(9).Label = "Qty 2";
            this.spdList_Sheet2.Columns.Get(9).Locked = true;
            this.spdList_Sheet2.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(9).Width = 73F;
            numberCellType15.DecimalPlaces = 3;
            numberCellType15.MaximumValue = 9999D;
            numberCellType15.MinimumValue = 0D;
            this.spdList_Sheet2.Columns.Get(10).CellType = numberCellType15;
            this.spdList_Sheet2.Columns.Get(10).Label = "Qty 3";
            this.spdList_Sheet2.Columns.Get(10).Locked = true;
            this.spdList_Sheet2.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(10).Width = 73F;
            this.spdList_Sheet2.Columns.Get(11).Label = "Carrier ID";
            this.spdList_Sheet2.Columns.Get(11).Locked = true;
            this.spdList_Sheet2.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(11).Width = 68F;
            this.spdList_Sheet2.Columns.Get(12).Label = "Owner Code";
            this.spdList_Sheet2.Columns.Get(12).Locked = true;
            this.spdList_Sheet2.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(12).Width = 79F;
            this.spdList_Sheet2.Columns.Get(13).Label = "Create Code";
            this.spdList_Sheet2.Columns.Get(13).Locked = true;
            this.spdList_Sheet2.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(13).Width = 79F;
            this.spdList_Sheet2.Columns.Get(14).Label = "Status";
            this.spdList_Sheet2.Columns.Get(14).Locked = true;
            this.spdList_Sheet2.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(14).Width = 67F;
            this.spdList_Sheet2.Columns.Get(15).Label = "Hold Flag";
            this.spdList_Sheet2.Columns.Get(15).Locked = true;
            this.spdList_Sheet2.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(15).Width = 66F;
            this.spdList_Sheet2.Columns.Get(16).Label = "Hold Code";
            this.spdList_Sheet2.Columns.Get(16).Locked = true;
            this.spdList_Sheet2.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(16).Width = 70F;
            numberCellType16.DecimalPlaces = 3;
            numberCellType16.MaximumValue = 9999D;
            numberCellType16.MinimumValue = 0D;
            this.spdList_Sheet2.Columns.Get(17).CellType = numberCellType16;
            this.spdList_Sheet2.Columns.Get(17).Label = "Create Qty 2";
            this.spdList_Sheet2.Columns.Get(17).Locked = true;
            this.spdList_Sheet2.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(17).Width = 80F;
            numberCellType17.DecimalPlaces = 3;
            numberCellType17.MaximumValue = 9999D;
            numberCellType17.MinimumValue = 0D;
            this.spdList_Sheet2.Columns.Get(18).CellType = numberCellType17;
            this.spdList_Sheet2.Columns.Get(18).Label = "Create Qty 3";
            this.spdList_Sheet2.Columns.Get(18).Locked = true;
            this.spdList_Sheet2.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(18).Width = 80F;
            numberCellType18.DecimalPlaces = 3;
            numberCellType18.MinimumValue = 0D;
            this.spdList_Sheet2.Columns.Get(19).CellType = numberCellType18;
            this.spdList_Sheet2.Columns.Get(19).Label = "Oper In Qty 2";
            this.spdList_Sheet2.Columns.Get(19).Locked = true;
            this.spdList_Sheet2.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(19).Width = 84F;
            numberCellType19.DecimalPlaces = 3;
            numberCellType19.MinimumValue = 0D;
            this.spdList_Sheet2.Columns.Get(20).CellType = numberCellType19;
            this.spdList_Sheet2.Columns.Get(20).Label = "Oper In Qty 3";
            this.spdList_Sheet2.Columns.Get(20).Locked = true;
            this.spdList_Sheet2.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(20).Width = 84F;
            this.spdList_Sheet2.Columns.Get(21).Label = "Inventory Flag";
            this.spdList_Sheet2.Columns.Get(21).Locked = true;
            this.spdList_Sheet2.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(21).Width = 68F;
            this.spdList_Sheet2.Columns.Get(22).Label = "Transit Flag";
            this.spdList_Sheet2.Columns.Get(22).Locked = true;
            this.spdList_Sheet2.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(22).Width = 82F;
            this.spdList_Sheet2.Columns.Get(23).Label = "Tracking Flag";
            this.spdList_Sheet2.Columns.Get(23).Locked = true;
            this.spdList_Sheet2.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(23).Width = 89F;
            this.spdList_Sheet2.Columns.Get(24).Label = "Inv Unit";
            this.spdList_Sheet2.Columns.Get(24).Locked = true;
            this.spdList_Sheet2.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(25).Label = "Rework Flag";
            this.spdList_Sheet2.Columns.Get(25).Locked = true;
            this.spdList_Sheet2.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(25).Width = 79F;
            this.spdList_Sheet2.Columns.Get(26).Label = "Rework Code";
            this.spdList_Sheet2.Columns.Get(26).Locked = true;
            this.spdList_Sheet2.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(26).Width = 85F;
            numberCellType20.DecimalPlaces = 0;
            numberCellType20.MaximumValue = 9999D;
            numberCellType20.MinimumValue = 0D;
            this.spdList_Sheet2.Columns.Get(27).CellType = numberCellType20;
            this.spdList_Sheet2.Columns.Get(27).Label = "Rework Count";
            this.spdList_Sheet2.Columns.Get(27).Locked = true;
            this.spdList_Sheet2.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(27).Width = 87F;
            this.spdList_Sheet2.Columns.Get(28).Label = "Rework Return Flow";
            this.spdList_Sheet2.Columns.Get(28).Locked = true;
            this.spdList_Sheet2.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(28).Width = 123F;
            this.spdList_Sheet2.Columns.Get(29).Label = "Rework Return Oper";
            this.spdList_Sheet2.Columns.Get(29).Locked = true;
            this.spdList_Sheet2.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(29).Width = 123F;
            this.spdList_Sheet2.Columns.Get(30).Label = "Rework End Flow";
            this.spdList_Sheet2.Columns.Get(30).Locked = true;
            this.spdList_Sheet2.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(30).Width = 117F;
            this.spdList_Sheet2.Columns.Get(31).Label = "Rework End Oper";
            this.spdList_Sheet2.Columns.Get(31).Locked = true;
            this.spdList_Sheet2.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(31).Width = 113F;
            this.spdList_Sheet2.Columns.Get(32).Label = "Rework Return Clear Flag";
            this.spdList_Sheet2.Columns.Get(32).Locked = true;
            this.spdList_Sheet2.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(32).Width = 154F;
            this.spdList_Sheet2.Columns.Get(33).Label = "Rework Time";
            this.spdList_Sheet2.Columns.Get(33).Locked = true;
            this.spdList_Sheet2.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(33).Width = 120F;
            this.spdList_Sheet2.Columns.Get(34).Label = "NSTD Flag";
            this.spdList_Sheet2.Columns.Get(34).Locked = true;
            this.spdList_Sheet2.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(34).Width = 62F;
            this.spdList_Sheet2.Columns.Get(35).Label = "NSTD Return Flow";
            this.spdList_Sheet2.Columns.Get(35).Locked = true;
            this.spdList_Sheet2.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(35).Width = 118F;
            this.spdList_Sheet2.Columns.Get(36).Label = "NSTD Return Oper";
            this.spdList_Sheet2.Columns.Get(36).Locked = true;
            this.spdList_Sheet2.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(36).Width = 114F;
            this.spdList_Sheet2.Columns.Get(37).Label = "NSTD Time";
            this.spdList_Sheet2.Columns.Get(37).Locked = true;
            this.spdList_Sheet2.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(37).Width = 120F;
            this.spdList_Sheet2.Columns.Get(38).Label = "Repair Flag";
            this.spdList_Sheet2.Columns.Get(38).Locked = true;
            this.spdList_Sheet2.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(39).Label = "Repair Oper";
            this.spdList_Sheet2.Columns.Get(39).Locked = true;
            this.spdList_Sheet2.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(40).Label = "Store Return Flow";
            this.spdList_Sheet2.Columns.Get(40).Locked = true;
            this.spdList_Sheet2.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(40).Width = 77F;
            this.spdList_Sheet2.Columns.Get(41).Label = "Store Return Flow Seq";
            this.spdList_Sheet2.Columns.Get(41).Locked = true;
            this.spdList_Sheet2.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(41).Width = 78F;
            this.spdList_Sheet2.Columns.Get(42).Label = "Store Return Oper";
            this.spdList_Sheet2.Columns.Get(42).Locked = true;
            this.spdList_Sheet2.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(42).Width = 81F;
            this.spdList_Sheet2.Columns.Get(43).Label = "Start Flag";
            this.spdList_Sheet2.Columns.Get(43).Locked = true;
            this.spdList_Sheet2.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(43).Width = 66F;
            this.spdList_Sheet2.Columns.Get(44).CellType = textCellType2;
            this.spdList_Sheet2.Columns.Get(44).Label = "Start Time";
            this.spdList_Sheet2.Columns.Get(44).Locked = true;
            this.spdList_Sheet2.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(44).Width = 127F;
            this.spdList_Sheet2.Columns.Get(45).Label = "Start Resource ID";
            this.spdList_Sheet2.Columns.Get(45).Locked = true;
            this.spdList_Sheet2.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(45).Width = 110F;
            this.spdList_Sheet2.Columns.Get(46).Label = "End Flag";
            this.spdList_Sheet2.Columns.Get(46).Locked = true;
            this.spdList_Sheet2.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(47).Label = "End Time";
            this.spdList_Sheet2.Columns.Get(47).Locked = true;
            this.spdList_Sheet2.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(47).Width = 127F;
            this.spdList_Sheet2.Columns.Get(48).Label = "End Resource ID";
            this.spdList_Sheet2.Columns.Get(48).Locked = true;
            this.spdList_Sheet2.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(48).Width = 105F;
            this.spdList_Sheet2.Columns.Get(49).Label = "Sample Flag";
            this.spdList_Sheet2.Columns.Get(49).Locked = true;
            this.spdList_Sheet2.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(49).Width = 84F;
            this.spdList_Sheet2.Columns.Get(50).Label = "Sample Wait Flag";
            this.spdList_Sheet2.Columns.Get(50).Locked = true;
            this.spdList_Sheet2.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(50).Width = 109F;
            this.spdList_Sheet2.Columns.Get(51).Label = "Sample Result";
            this.spdList_Sheet2.Columns.Get(51).Locked = true;
            this.spdList_Sheet2.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(51).Width = 98F;
            this.spdList_Sheet2.Columns.Get(52).Label = "Reserve Resource ID";
            this.spdList_Sheet2.Columns.Get(52).Locked = true;
            this.spdList_Sheet2.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(52).Width = 94F;
            this.spdList_Sheet2.Columns.Get(53).Label = "Location";
            this.spdList_Sheet2.Columns.Get(53).Locked = true;
            this.spdList_Sheet2.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(53).Width = 69F;
            this.spdList_Sheet2.Columns.Get(54).Label = "Lot CMF 1";
            this.spdList_Sheet2.Columns.Get(54).Locked = true;
            this.spdList_Sheet2.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(54).Width = 79F;
            this.spdList_Sheet2.Columns.Get(55).Label = "Lot CMF 2";
            this.spdList_Sheet2.Columns.Get(55).Locked = true;
            this.spdList_Sheet2.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(55).Width = 79F;
            this.spdList_Sheet2.Columns.Get(56).Label = "Lot CMF 3";
            this.spdList_Sheet2.Columns.Get(56).Locked = true;
            this.spdList_Sheet2.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(56).Width = 79F;
            this.spdList_Sheet2.Columns.Get(57).Label = "Lot CMF 4";
            this.spdList_Sheet2.Columns.Get(57).Locked = true;
            this.spdList_Sheet2.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(57).Width = 79F;
            this.spdList_Sheet2.Columns.Get(58).Label = "Lot CMF 5";
            this.spdList_Sheet2.Columns.Get(58).Locked = true;
            this.spdList_Sheet2.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(58).Width = 79F;
            this.spdList_Sheet2.Columns.Get(59).Label = "Lot CMF 6";
            this.spdList_Sheet2.Columns.Get(59).Locked = true;
            this.spdList_Sheet2.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(59).Width = 79F;
            this.spdList_Sheet2.Columns.Get(60).Label = "Lot CMF 7";
            this.spdList_Sheet2.Columns.Get(60).Locked = true;
            this.spdList_Sheet2.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(60).Width = 79F;
            this.spdList_Sheet2.Columns.Get(61).Label = "Lot CMF 8";
            this.spdList_Sheet2.Columns.Get(61).Locked = true;
            this.spdList_Sheet2.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(61).Width = 79F;
            this.spdList_Sheet2.Columns.Get(62).Label = "Lot CMF 9";
            this.spdList_Sheet2.Columns.Get(62).Locked = true;
            this.spdList_Sheet2.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(62).Width = 79F;
            this.spdList_Sheet2.Columns.Get(63).Label = "Lot CMF 10";
            this.spdList_Sheet2.Columns.Get(63).Locked = true;
            this.spdList_Sheet2.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(63).Width = 79F;
            this.spdList_Sheet2.Columns.Get(64).Label = "Lot CMF 11";
            this.spdList_Sheet2.Columns.Get(64).Locked = true;
            this.spdList_Sheet2.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(64).Width = 80F;
            this.spdList_Sheet2.Columns.Get(65).Label = "Lot CMF 12";
            this.spdList_Sheet2.Columns.Get(65).Locked = true;
            this.spdList_Sheet2.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(65).Width = 80F;
            this.spdList_Sheet2.Columns.Get(66).Label = "Lot CMF 13";
            this.spdList_Sheet2.Columns.Get(66).Locked = true;
            this.spdList_Sheet2.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(66).Width = 80F;
            this.spdList_Sheet2.Columns.Get(67).Label = "Lot CMF 14";
            this.spdList_Sheet2.Columns.Get(67).Locked = true;
            this.spdList_Sheet2.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(67).Width = 80F;
            this.spdList_Sheet2.Columns.Get(68).Label = "Lot CMF 15";
            this.spdList_Sheet2.Columns.Get(68).Locked = true;
            this.spdList_Sheet2.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(68).Width = 80F;
            this.spdList_Sheet2.Columns.Get(69).Label = "Lot CMF 16";
            this.spdList_Sheet2.Columns.Get(69).Locked = true;
            this.spdList_Sheet2.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(69).Width = 80F;
            this.spdList_Sheet2.Columns.Get(70).Label = "Lot CMF 17";
            this.spdList_Sheet2.Columns.Get(70).Locked = true;
            this.spdList_Sheet2.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(70).Width = 80F;
            this.spdList_Sheet2.Columns.Get(71).Label = "Lot CMF 18";
            this.spdList_Sheet2.Columns.Get(71).Locked = true;
            this.spdList_Sheet2.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(71).Width = 80F;
            this.spdList_Sheet2.Columns.Get(72).Label = "Lot CMF 19";
            this.spdList_Sheet2.Columns.Get(72).Locked = true;
            this.spdList_Sheet2.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(72).Width = 80F;
            this.spdList_Sheet2.Columns.Get(73).Label = "Lot Cmf 20";
            this.spdList_Sheet2.Columns.Get(73).Locked = true;
            this.spdList_Sheet2.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(73).Width = 80F;
            this.spdList_Sheet2.Columns.Get(76).Label = "Cell Grade";
            this.spdList_Sheet2.Columns.Get(76).Width = 104F;
            this.spdList_Sheet2.Columns.Get(77).Label = "Cell Judge";
            this.spdList_Sheet2.Columns.Get(77).Width = 104F;
            this.spdList_Sheet2.Columns.Get(79).Label = "Lot Delete Flag";
            this.spdList_Sheet2.Columns.Get(79).Locked = true;
            this.spdList_Sheet2.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(79).Width = 101F;
            this.spdList_Sheet2.Columns.Get(80).Label = "Lot Delete Reason";
            this.spdList_Sheet2.Columns.Get(80).Locked = true;
            this.spdList_Sheet2.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(80).Width = 119F;
            this.spdList_Sheet2.Columns.Get(81).Label = "Lot Delete Time";
            this.spdList_Sheet2.Columns.Get(81).Locked = true;
            this.spdList_Sheet2.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(81).Width = 129F;
            this.spdList_Sheet2.Columns.Get(82).Label = "Last Tran Code";
            this.spdList_Sheet2.Columns.Get(82).Locked = true;
            this.spdList_Sheet2.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(82).Width = 104F;
            this.spdList_Sheet2.Columns.Get(83).Label = "Last Tran Time";
            this.spdList_Sheet2.Columns.Get(83).Locked = true;
            this.spdList_Sheet2.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(83).Width = 128F;
            this.spdList_Sheet2.Columns.Get(84).Label = "Last Comment";
            this.spdList_Sheet2.Columns.Get(84).Locked = true;
            this.spdList_Sheet2.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(84).Width = 220F;
            numberCellType21.DecimalPlaces = 0;
            numberCellType21.MaximumValue = 9999D;
            numberCellType21.MinimumValue = 0D;
            this.spdList_Sheet2.Columns.Get(85).CellType = numberCellType21;
            this.spdList_Sheet2.Columns.Get(85).Label = "Last Active Hist Seq";
            this.spdList_Sheet2.Columns.Get(85).Locked = true;
            this.spdList_Sheet2.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(85).Width = 130F;
            numberCellType22.DecimalPlaces = 0;
            numberCellType22.MaximumValue = 9999D;
            numberCellType22.MinimumValue = 0D;
            this.spdList_Sheet2.Columns.Get(86).CellType = numberCellType22;
            this.spdList_Sheet2.Columns.Get(86).Label = "Last Hist Seq";
            this.spdList_Sheet2.Columns.Get(86).Locked = true;
            this.spdList_Sheet2.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet2.Columns.Get(86).Width = 91F;
            this.spdList_Sheet2.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet2.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet2.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet2.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet2.RowHeader.Visible = false;
            this.spdList_Sheet2.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet2.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet2.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // cdvAttrType
            // 
            this.cdvAttrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrType.BtnToolTipText = "";
            this.cdvAttrType.DescText = "";
            this.cdvAttrType.DisplaySubItemIndex = -1;
            this.cdvAttrType.DisplayText = "";
            this.cdvAttrType.Focusing = null;
            this.cdvAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrType.Index = 0;
            this.cdvAttrType.IsViewBtnImage = false;
            this.cdvAttrType.Location = new System.Drawing.Point(107, 13);
            this.cdvAttrType.MaxLength = 20;
            this.cdvAttrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrType.Name = "cdvAttrType";
            this.cdvAttrType.ReadOnly = false;
            this.cdvAttrType.SearchSubItemIndex = 0;
            this.cdvAttrType.SelectedDescIndex = -1;
            this.cdvAttrType.SelectedSubItemIndex = -1;
            this.cdvAttrType.SelectionStart = 0;
            this.cdvAttrType.Size = new System.Drawing.Size(148, 20);
            this.cdvAttrType.SmallImageList = null;
            this.cdvAttrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrType.TabIndex = 1;
            this.cdvAttrType.TextBoxToolTipText = "";
            this.cdvAttrType.TextBoxWidth = 148;
            this.cdvAttrType.VisibleButton = true;
            this.cdvAttrType.VisibleColumnHeader = false;
            this.cdvAttrType.VisibleDescription = false;
            this.cdvAttrType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrType_SelectedItemChanged);
            this.cdvAttrType.ButtonPress += new System.EventHandler(this.cdvAttrType_ButtonPress);
            // 
            // lblAttrType
            // 
            this.lblAttrType.AutoSize = true;
            this.lblAttrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrType.Location = new System.Drawing.Point(15, 16);
            this.lblAttrType.Name = "lblAttrType";
            this.lblAttrType.Size = new System.Drawing.Size(87, 13);
            this.lblAttrType.TabIndex = 0;
            this.lblAttrType.Text = "Attribute Type";
            this.lblAttrType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvAttrName
            // 
            this.cdvAttrName.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvAttrName.BorderHotColor = System.Drawing.Color.Black;
            this.cdvAttrName.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvAttrName.BtnToolTipText = "";
            this.cdvAttrName.DescText = "";
            this.cdvAttrName.DisplaySubItemIndex = -1;
            this.cdvAttrName.DisplayText = "";
            this.cdvAttrName.Focusing = null;
            this.cdvAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvAttrName.Index = 0;
            this.cdvAttrName.IsViewBtnImage = false;
            this.cdvAttrName.Location = new System.Drawing.Point(107, 39);
            this.cdvAttrName.MaxLength = 100;
            this.cdvAttrName.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvAttrName.Name = "cdvAttrName";
            this.cdvAttrName.ReadOnly = false;
            this.cdvAttrName.SearchSubItemIndex = 0;
            this.cdvAttrName.SelectedDescIndex = -1;
            this.cdvAttrName.SelectedSubItemIndex = -1;
            this.cdvAttrName.SelectionStart = 0;
            this.cdvAttrName.Size = new System.Drawing.Size(148, 20);
            this.cdvAttrName.SmallImageList = null;
            this.cdvAttrName.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvAttrName.TabIndex = 3;
            this.cdvAttrName.TextBoxToolTipText = "";
            this.cdvAttrName.TextBoxWidth = 148;
            this.cdvAttrName.VisibleButton = true;
            this.cdvAttrName.VisibleColumnHeader = false;
            this.cdvAttrName.VisibleDescription = false;
            this.cdvAttrName.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvAttrName_SelectedItemChanged);
            this.cdvAttrName.ButtonPress += new System.EventHandler(this.cdvAttrName_ButtonPress);
            // 
            // lblAttrName
            // 
            this.lblAttrName.AutoSize = true;
            this.lblAttrName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttrName.Location = new System.Drawing.Point(15, 42);
            this.lblAttrName.Name = "lblAttrName";
            this.lblAttrName.Size = new System.Drawing.Size(91, 13);
            this.lblAttrName.TabIndex = 2;
            this.lblAttrName.Text = "Attribute Name";
            this.lblAttrName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cdvFlow.LabelWidth = 70;
            this.cdvFlow.ListCond_ExtFactory = "";
            this.cdvFlow.ListCond_Step = '2';
            this.cdvFlow.Location = new System.Drawing.Point(273, 39);
            this.cdvFlow.Name = "cdvFlow";
            this.cdvFlow.SearchSubItemIndex = 0;
            this.cdvFlow.SelectedDescIndex = -1;
            this.cdvFlow.SelectedSubItemIndex = 0;
            this.cdvFlow.SequenceReadOnly = false;
            this.cdvFlow.Size = new System.Drawing.Size(249, 20);
            this.cdvFlow.TabIndex = 7;
            this.cdvFlow.VisibleColumnHeader = false;
            this.cdvFlow.VisibleDescription = false;
            this.cdvFlow.VisibleFlowButton = true;
            this.cdvFlow.VisibleSequenceButton = true;
            this.cdvFlow.WidthButton = 20;
            this.cdvFlow.WidthFlowAndSequence = 179;
            this.cdvFlow.WidthSequence = 50;
            this.cdvFlow.FlowSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFlow_SelectedItemChanged);
            this.cdvFlow.FlowButtonPress += new System.EventHandler(this.cdvFlow_FlowButtonPress);
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
            this.cdvMaterial.Location = new System.Drawing.Point(273, 12);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(249, 20);
            this.cdvMaterial.TabIndex = 6;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 70;
            this.cdvMaterial.WidthMaterialAndVersion = 179;
            this.cdvMaterial.WidthVersion = 50;
            this.cdvMaterial.MaterialSelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvMaterial_SelectedItemChanged);
            this.cdvMaterial.MaterialButtonPress += new System.EventHandler(this.cdvMaterial_MaterialButtonPress);
            // 
            // cdvOperation
            // 
            this.cdvOperation.AddEmptyRowToLast = false;
            this.cdvOperation.AddEmptyRowToTop = false;
            this.cdvOperation.ButtonWidth = 21;
            this.cdvOperation.DisplaySubItemIndex = 0;
            this.cdvOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvOperation.LabelText = "Operation";
            this.cdvOperation.LabelWidth = 70;
            this.cdvOperation.ListCond_ExtFactory = "";
            this.cdvOperation.ListCond_Step = '1';
            this.cdvOperation.Location = new System.Drawing.Point(273, 66);
            this.cdvOperation.Name = "cdvOperation";
            this.cdvOperation.ReadOnly = false;
            this.cdvOperation.SearchSubItemIndex = 0;
            this.cdvOperation.SelectedDescIndex = 1;
            this.cdvOperation.SelectedSubItemIndex = 0;
            this.cdvOperation.Size = new System.Drawing.Size(249, 20);
            this.cdvOperation.TabIndex = 8;
            this.cdvOperation.TextBoxWidth = 179;
            this.cdvOperation.VisibleButton = true;
            this.cdvOperation.VisibleColumnHeader = false;
            this.cdvOperation.VisibleDescription = false;
            this.cdvOperation.ButtonPress += new System.EventHandler(this.cdvOperation_ButtonPress);
            // 
            // cdvLotID
            // 
            this.cdvLotID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvLotID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvLotID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvLotID.BtnToolTipText = "";
            this.cdvLotID.DescText = "";
            this.cdvLotID.DisplaySubItemIndex = -1;
            this.cdvLotID.DisplayText = "";
            this.cdvLotID.Focusing = null;
            this.cdvLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvLotID.Index = 0;
            this.cdvLotID.IsViewBtnImage = false;
            this.cdvLotID.Location = new System.Drawing.Point(597, 12);
            this.cdvLotID.MaxLength = 25;
            this.cdvLotID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvLotID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvLotID.Name = "cdvLotID";
            this.cdvLotID.ReadOnly = false;
            this.cdvLotID.SearchSubItemIndex = 0;
            this.cdvLotID.SelectedDescIndex = -1;
            this.cdvLotID.SelectedSubItemIndex = -1;
            this.cdvLotID.SelectionStart = 0;
            this.cdvLotID.Size = new System.Drawing.Size(139, 20);
            this.cdvLotID.SmallImageList = null;
            this.cdvLotID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvLotID.TabIndex = 10;
            this.cdvLotID.TextBoxToolTipText = "";
            this.cdvLotID.TextBoxWidth = 139;
            this.cdvLotID.VisibleButton = true;
            this.cdvLotID.VisibleColumnHeader = false;
            this.cdvLotID.VisibleDescription = false;
            this.cdvLotID.ButtonPress += new System.EventHandler(this.cdvLotID_ButtonPress);
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.Location = new System.Drawing.Point(554, 16);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(36, 13);
            this.lblLot.TabIndex = 9;
            this.lblLot.Text = "Lot ID";
            this.lblLot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmWIPViewDataListByAttribute
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewDataListByAttribute";
            this.Text = "View Data List By Attribute";
            this.Activated += new System.EventHandler(this.frmWIPViewDataListByOperation_Activated);
            this.Load += new System.EventHandler(this.frmWIPViewDataListByOperation_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvAttrName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvLotID)).EndInit();
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


        // DisplayDataListByAttr()
        //       - View Data List By Attribute Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool DisplayDataListByAttr(Control control, int sheet_index, TRSNode data_out, int proc_step)
        {
            int iRow;
            int iCol;
            FarPoint.Win.Spread.SheetView sheet;

            try
            {
                sheet = ((FarPoint.Win.Spread.FpSpread)control).Sheets[sheet_index];
                iRow = sheet.RowCount;
                sheet.RowCount++;
                iCol = 0;

                if (sheet_index == 0)
                {
                    if (proc_step == 1)
                    {
                        sheet.Cells[iRow, iCol].Value = data_out.GetString("FACTORY");

                        iCol++;
                    }
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("ATTR_VALUE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("MAT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetInt("MAT_VER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetInt("FLOW_SEQ_NUM");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("QTY_1"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("LOT_TYPE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("OWNER_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("CREATE_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("LOT_PRIORITY");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_STATUS");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("HOLD_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("HOLD_CODE");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("CREATE_QTY_1"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("CREATE_QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("CREATE_QTY_3"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("OPER_IN_QTY_1"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("OPER_IN_QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("OPER_IN_QTY_3"));

                    iCol++;


                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("INV_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("TRANSIT_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("UNIT_EXIST_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("INV_UNIT");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("RWK_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", data_out.GetInt("RWK_COUNT"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_END_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_END_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("RWK_RET_CLEAR_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("RWK_TIME"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("NSTD_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("NSTD_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("NSTD_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("NSTD_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("REP_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("REP_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("STR_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetInt("STR_RET_FLOW_SEQ_NUM");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("STR_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("START_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("START_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("START_RES_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("END_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("END_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("END_RES_ID");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("SAMPLE_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("SAMPLE_WAIT_FLAG");

                    iCol++;
                    switch (data_out.GetChar("SAMPLE_RESULT"))
                    {
                        case 'Y':

                            sheet.Cells[iRow, iCol].Value = "Good";
                            break;
                        case 'N':

                            sheet.Cells[iRow, iCol].Value = "No Good";
                            break;
                        default:

                            sheet.Cells[iRow, iCol].Value = "";
                            break;
                    }
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("FROM_TO_LOT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("SHIP_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("SHIP_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("CREATE_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("FAC_IN_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("FLOW_IN_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("OPER_IN_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RESERVE_RES_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("BATCH_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("#######,##0", data_out.GetInt("BATCH_SEQ"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("ORDER_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("ADD_ORDER_ID_1");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("ADD_ORDER_ID_2");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("ADD_ORDER_ID_3");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_LOCATION");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_1");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_2");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_3");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_4");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_5");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_6");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_7");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_8");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_9");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_10");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_11");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_12");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_13");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_14");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_15");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_16");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_17");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_18");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_19");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_20");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetString("BOM_SET_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Trim(data_out.GetInt("BOM_SET_VERSION"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", data_out.GetInt("BOM_ACTIVE_HIST_SEQ"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", data_out.GetInt("BOM_HIST_SEQ"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("LOT_DEL_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_DEL_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("LOT_DEL_TIME"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LAST_TRAN_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("LAST_TRAN_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LAST_COMMENT");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", data_out.GetInt("LAST_ACTIVE_HIST_SEQ"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", data_out.GetInt("LAST_HIST_SEQ"));

                    iCol++;

                    if (data_out.GetChar("LOT_DEL_FLAG") == 'Y')
                    {
                        sheet.Rows[iRow].ForeColor = Color.Magenta;
                    }
                }
                else
                {
                    sheet.Cells[iRow, iCol].Value = data_out.GetInt("SLOT_NO");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("SUBLOT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("ATTR_VALUE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("MAT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetInt("MAT_VER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetInt("FLOW_SEQ_NUM");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("CRR_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("OWNER_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("CREATE_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("SUBLOT_STATUS");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("HOLD_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("HOLD_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("CREATE_QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("CREATE_QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("OPER_IN_QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", data_out.GetDouble("OPER_IN_QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("INV_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("TRANSIT_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("UNIT_EXIST_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("INV_UNIT");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("RWK_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", data_out.GetInt("RWK_COUNT"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_END_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RWK_END_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("RWK_RET_CLEAR_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("RWK_TIME"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("NSTD_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("NSTD_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("NSTD_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("NSTD_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("REP_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("REP_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("STR_RET_FLOW");
                    
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetInt("STR_RET_FLOW_SEQ_NUM");
                    
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("STR_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("START_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("START_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("START_RES_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("END_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("END_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("END_RES_ID");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("SAMPLE_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("SAMPLE_WAIT_FLAG");

                    iCol++;
                    switch (data_out.GetChar("SAMPLE_RESULT"))
                    {
                        case 'Y':

                            sheet.Cells[iRow, iCol].Value = "Good";
                            break;
                        case 'N':

                            sheet.Cells[iRow, iCol].Value = "No Good";
                            break;
                        default:

                            sheet.Cells[iRow, iCol].Value = "";
                            break;
                    }
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("RESERVE_RES_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_LOCATION");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_1");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_2");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_3");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_4");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_5");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_6");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_7");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_8");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_9");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_10");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_11");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_12");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_13");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_14");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_15");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_16");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_17");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_18");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_19");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_CMF_20");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("GRADE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("GRADE_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("CELL_GRADE");

                    //Add by J.S. 2009.02.18 for Add CELL_JUDGE
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("CELL_JUDGE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("LOT_BASE");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetChar("LOT_DEL_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LOT_DEL_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("LOT_DEL_TIME"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LAST_TRAN_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(data_out.GetString("LAST_TRAN_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = data_out.GetString("LAST_COMMENT");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", data_out.GetInt("LAST_ACTIVE_HIST_SEQ"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", data_out.GetInt("LAST_HIST_SEQ"));

                    iCol++;

                    if (data_out.GetChar("LOT_DEL_FLAG") == 'Y')
                    {
                        sheet.Rows[iRow].ForeColor = Color.Magenta;
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

                
        // View_Lot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_Lot_List()
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DATA_LIST_OUT");
            int i;

            //MPCF.ClearList(spdList, true);

            spdList.ActiveSheet.ClearRange(0, 0, spdList.ActiveSheet.RowCount, spdList.ActiveSheet.ColumnCount, true);
            MPCF.ClearList(spdList);

            if (spdList.ActiveSheet.DataSource != null)
            {
                spdList.ActiveSheet.DataSource = null;
                spdList.ActiveSheet.ColumnCount = 0;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("ATTR_TYPE", MPCF.Trim(cdvAttrType.Text));
            in_node.AddString("ATTR_NAME", MPCF.Trim(cdvAttrName.Text));
            in_node.AddString("ATTR_VALUE", MPCF.Trim(cdvAttrValue.Text).Replace('*', '%'));

            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FLOW", MPCF.Trim(cdvFlow.Text));
            in_node.AddString("OPER", MPCF.Trim(cdvOperation.Text));

            in_node.SetString("NEXT_LOT_ID", " ");

            if (MPCF.Trim(cdvLotID.Text) != "")
            {
                in_node.AddString("LOT_ID", MPCF.Trim(cdvLotID.Text).Replace('*', '%'));
            }
            else
            {
                in_node.AddString("LOT_ID", "%");
            }

            in_node.AddChar("ZERO_QTY_FLAG", chkZeroQtyLot.Checked == true ? 'Y' : ' ');
            in_node.AddChar("LOT_DEL_FLAG", chkTerminatedLot.Checked == true ? 'Y' : ' ');

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Data_List_By_Attribute", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    DisplayDataListByAttr(spdList, spdList.ActiveSheetIndex, out_node.GetList(0)[i], 0);
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

        private void frmWIPViewDataListByOperation_Activated(object sender, EventArgs e)
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

        private void frmWIPViewDataListByOperation_Load(object sender, EventArgs e)
        {
            cdvAttrType.Focus();
        }

        private void cdvMaterial_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvFlow.Text = "";
            cdvAttrValue.Text = "";
            
        }
        
        private void cdvFlow_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            cdvOperation.Text = "";
        }
        
        private void cdvOperation_ButtonPress(object sender, System.EventArgs e)
        {
            if (cdvMaterial.Text != "" && cdvFlow.Text != "")
            {
                cdvOperation.ListCond_Step = '3';
                cdvOperation.ListCond_MatID = cdvMaterial.Text;
                cdvOperation.ListCond_MatVersion = cdvMaterial.Version;
                cdvOperation.ListCond_Flow = cdvFlow.Text;
            }
            else
            {
                if (cdvFlow.Text != "")
                {
                    cdvOperation.ListCond_Step = '2';
                    cdvOperation.ListCond_Flow = cdvFlow.Text;
                }
                else
                {
                    cdvOperation.ListCond_Step = '1';
                }
            }
            
            //cdvAttrValue.Init();
            //MPCF.InitListView(cdvAttrValue.GetListView);
            //cdvAttrValue.Columns.Add("Oper", 50, HorizontalAlignment.Left);
            //cdvAttrValue.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            //cdvAttrValue.SelectedSubItemIndex = 0;

            //if (cdvMaterial.Text != "" && cdvFlow.Text != "")
            //{
            //    WIPLIST.ViewOperationList(cdvAttrValue.GetListView, '4', cdvMaterial.Text, cdvMaterial.Version, cdvFlow.Text, "", null, "");
            //}
            //else
            //{
            //    if (cdvFlow.Text == "")
            //    {
            //        if (cdvMaterial.Text == "")
            //        {
            //            WIPLIST.ViewOperationList(cdvAttrValue.GetListView, '1', "",0, "", "", null, "");
            //        }
            //        else
            //        {
            //            WIPLIST.ViewOperationList(cdvAttrValue.GetListView, '3', cdvMaterial.Text, cdvMaterial.Version, "", "", null, "");
            //        }
            //    }
            //    else
            //    {
            //        WIPLIST.ViewOperationList(cdvAttrValue.GetListView, '2', "", 0,cdvFlow.Text, "", null, "");
            //    }
            //}
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {

            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return;
            }

            if (MPCF.CheckValue(cdvAttrName, 1) == false)
            {
                return;
            }

            if (MPCF.CheckValue(cdvAttrValue, 1) == false)
            {
                return;
            }

            View_Lot_List();
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Operation : " + MPCF.Trim(cdvAttrValue.Text);

            if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
            
        }
        
        private void cdvAttType_ButtonPress(object sender, EventArgs e)
        {
            cdvAttrType.Init();
            MPCF.InitListView(cdvAttrType.GetListView);
            cdvAttrType.Columns.Add("Type", 150, HorizontalAlignment.Left);
            cdvAttrType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvAttrType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);
        }

        private void cdvAttType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvAttrName.Text = "";
            cdvAttrValue.Text = "";
            cdvAttrName.VisibleButton = true;
            cdvAttrValue.VisibleButton = true;

            switch (cdvAttrType.Text)
            {
                case "FACTORY":

                    break;
                case "MATERIAL":

                    break;
                case "FLOW":

                    break;
                case "OPER":

                    break;
                case "BOM":

                    break;
                case "RESOURCE":

                    break;
                case "CARRIER":

                    break;
                default:

                    cdvAttrName.VisibleButton = false;
                    cdvAttrValue.VisibleButton = false;
                    break;
            }
        }

        private void cdvAttrName_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvAttrValue.Text = "";
            cdvAttrValue.VisibleButton = false;
            cdvAttrValue.Focus();
        }

        private void cdvAttrName_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false) return;

            cdvAttrName.Init();
            MPCF.InitListView(cdvAttrName.GetListView);
            cdvAttrName.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrName.SelectedSubItemIndex = 1;
            cdvAttrName.DisplaySubItemIndex = 1;
            BASLIST.ViewAttributeNameList(cdvAttrName.GetListView, '1', cdvAttrType.Text);
        }

        private void cdvAttrType_ButtonPress(object sender, EventArgs e)
        {
            try
            {
                cdvAttrType.Init();
                MPCF.InitListView(cdvAttrType.GetListView);
                cdvAttrType.Columns.Add("Type", 150, HorizontalAlignment.Left);
                cdvAttrType.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                cdvAttrType.SelectedSubItemIndex = 0;
                BASLIST.ViewGCMDataList(cdvAttrType.GetListView, '1', MPGC.MP_ATTR_TYPE_TABLE);

                while (cdvAttrType.GetListView.Items.Count > 2)
                {
                    for (int iIndex = cdvAttrType.GetListView.Items.Count - 1; iIndex >= 0; iIndex--)
                    {
                        if (cdvAttrType.GetListView.Items[iIndex].Text != "LOT" &&
                           cdvAttrType.GetListView.Items[iIndex].Text != "SUBLOT")
                            cdvAttrType.GetListView.Items.RemoveAt(iIndex);
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void cdvAttrType_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvAttrName.Text = "";
            cdvAttrValue.Text = "";
            cdvAttrValue.VisibleButton = false;

            switch (cdvAttrType.Text)
            {
                case "LOT":
                    spdList.Sheets[1].ClearRange(0, 0, spdList.Sheets[1].RowCount, spdList.Sheets[1].ColumnCount, true);
                    spdList.Sheets[1].RowCount = 0;

                    if (spdList.Sheets[1].DataSource != null)
                    {
                        spdList.Sheets[1].DataSource = null;
                        spdList.Sheets[1].ColumnCount = 0;
                    }

                    lblLot.Text = "Lot ID";
                    spdList.ActiveSheetIndex = 0;
                    break;
                case "SUBLOT":
                    spdList.Sheets[0].ClearRange(0, 0, spdList.Sheets[0].RowCount, spdList.Sheets[0].ColumnCount, true);
                    spdList.Sheets[0].RowCount = 0;

                    if (spdList.Sheets[0].DataSource != null)
                    {
                        spdList.Sheets[0].DataSource = null;
                        spdList.Sheets[0].ColumnCount = 0;
                    }

                    lblLot.Text = "Sub Lot ID";
                    spdList.ActiveSheetIndex = 1;
                    break;
                default:
                    break;
            }
        }

        private void cdvAttrValue_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvAttrType.Text == "MATERIAL")
                if (e != null)
                    cdvAttrName.Text = e.SelectedItem.SubItems[0].Text + " : " + e.SelectedItem.SubItems[1].Text;

            btnView.PerformClick();
        }

        private void cdvAttrValue_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false)
            {
                return;
            }

            cdvAttrName.Init();
            MPCF.InitListView(cdvAttrName.GetListView);
            cdvAttrName.Columns.Add("Key", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrName.SelectedSubItemIndex = 0;

            switch (cdvAttrType.Text)
            {
                case "FACTORY":

                    WIPLIST.ViewFactoryList(cdvAttrName.GetListView, '1', null);
                    break;
                case "MATERIAL":

                    cdvAttrName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
                    WIPLIST.ViewMaterialList(cdvAttrName.GetListView, '1');
                    break;
                case "FLOW":

                    WIPLIST.ViewFlowList(cdvAttrName.GetListView, '1', "", 0, "", null, "");
                    break;
                case "OPER":

                    WIPLIST.ViewOperationList(cdvAttrName.GetListView, '1', "", 0, "", "", null, "");
                    break;
                case "BOM":

#if _BOM
                    BOMLIST.ViewBOMSetList(cdvAttrName.GetListView, '1', null, "", -1, -1, ' ', true);
#endif
                    break;
                case "RESOURCE":

                    RASLIST.ViewResourceList(cdvAttrName.GetListView, false);
                    break;
                case "CARRIER":

                    if (MPGO.RequireCarrierFilter() == true)
                    {
                        if (MPCF.Trim(cdvAttrName.Text) == "")
                        {
                            cdvAttrName.IsPopup = false;
                            MPCF.ShowMsgBox(MPCF.GetMessage(258));
                            cdvAttrName.Focus();
                            return;
                        }
                    }
                    RASLIST.ViewCarrierList(cdvAttrName.GetListView, '1', "", "", cdvAttrName.Text);
                    break;
            }
        }

        private void cdvMaterial_MaterialButtonPress(object sender, EventArgs e)
        {
            cdvMaterial.ListCond_StepMaterial = '1';
        }

        private void cdvLotID_ButtonPress(object sender, EventArgs e)
        {
            if (MPCF.CheckValue(cdvAttrType, 1) == false) return;

            cdvAttrName.Init();
            MPCF.InitListView(cdvAttrName.GetListView);
            cdvAttrName.Columns.Add("Attribute Name", 150, HorizontalAlignment.Left);
            cdvAttrName.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvAttrName.SelectedSubItemIndex = 1;
            cdvAttrName.DisplaySubItemIndex = 1;
            BASLIST.ViewAttributeNameList(cdvAttrName.GetListView, '1', cdvAttrType.Text);
        }

        private void cdvFlow_FlowButtonPress(object sender, EventArgs e)
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
    }
}
