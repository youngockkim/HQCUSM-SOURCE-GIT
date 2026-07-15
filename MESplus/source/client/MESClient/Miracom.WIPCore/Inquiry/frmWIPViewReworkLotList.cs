
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
    public class frmWIPViewReworkLotList : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewReworkLotList()
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
        



        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
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
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 46);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(742, 46);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 46);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 467);
            this.pnlViewMid.TabIndex = 2;
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
            this.lblFormTitle.Text = "View Rework Lot List";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer1.Name = "rowHeaderRenderer1";
            rowHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer1.TextRotationAngle = 0D;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(475, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(167, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
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
            this.cdvMaterial.Location = new System.Drawing.Point(12, 15);
            this.cdvMaterial.MaterialEnabled = true;
            this.cdvMaterial.MaterialReadOnly = false;
            this.cdvMaterial.Name = "cdvMaterial";
            this.cdvMaterial.SearchSubItemIndex = 0;
            this.cdvMaterial.SelectedDescIndex = -1;
            this.cdvMaterial.SelectedSubItemIndex = 0;
            this.cdvMaterial.Size = new System.Drawing.Size(326, 20);
            this.cdvMaterial.TabIndex = 0;
            this.cdvMaterial.VersionEnabled = true;
            this.cdvMaterial.VersionReadOnly = false;
            this.cdvMaterial.VisibleColumnHeader = false;
            this.cdvMaterial.VisibleDescription = false;
            this.cdvMaterial.VisibleMaterialButton = true;
            this.cdvMaterial.VisibleVersionButton = true;
            this.cdvMaterial.WidthButton = 20;
            this.cdvMaterial.WidthLabel = 108;
            this.cdvMaterial.WidthMaterialAndVersion = 218;
            this.cdvMaterial.WidthVersion = 50;
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
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 464);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 5;
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 105;
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
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Rework Depth";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Rework Stop Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Rework Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Rework Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Rework End Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Rework End Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Return Option";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Local Rework Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Rework Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "NSTD Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "NSTD Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "NSTD Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "NSTD Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Repair Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Repair Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Store Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Store Return Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Store Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Start Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Start Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Start Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "End Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "End Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "End Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Sample Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Sample Wait Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Sample Result";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "From To Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Ship Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Ship Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Original Due Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Scheduled Due Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Create Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Factory In Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Flow In Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Oper In Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Reserve Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "Batch ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "Batch Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "Order ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "Add Order ID 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "Add Order ID 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "Add Order ID 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "Lot Location";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "Lot CMF 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "Lot CMF 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "Lot CMF 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "Lot CMF 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Lot CMF 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Lot CMF 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 79).Value = "Lot CMF 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 80).Value = "Lot CMF 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 81).Value = "Lot CMF 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 82).Value = "Lot CMF 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 83).Value = "Lot CMF 11";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 84).Value = "Lot CMF 12";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 85).Value = "Lot CMF 13";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 86).Value = "Lot CMF 14";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 87).Value = "Lot CMF 15";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 88).Value = "Lot CMF 16";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 89).Value = "Lot CMF 17";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 90).Value = "Lot CMF 18";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 91).Value = "Lot CMF 19";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 92).Value = "Lot Cmf 20";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 93).Value = "BOM Set ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 94).Value = "BOM Set Version";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 95).Value = "BOM Act Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 96).Value = "BOM Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 97).Value = "Lot Delete Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 98).Value = "Lot Delete Reason";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 99).Value = "Lot Delete Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 100).Value = "Last Tran Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 101).Value = "Last Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 102).Value = "Last Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 103).Value = "Last Active Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 104).Value = "Last Hist Seq";
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
            this.spdList_Sheet1.Columns.Get(29).Label = "Rework Depth";
            this.spdList_Sheet1.Columns.Get(29).Locked = true;
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 90F;
            this.spdList_Sheet1.Columns.Get(30).Label = "Rework Stop Oper";
            this.spdList_Sheet1.Columns.Get(30).Locked = true;
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 100F;
            this.spdList_Sheet1.Columns.Get(31).Label = "Rework Return Flow";
            this.spdList_Sheet1.Columns.Get(31).Locked = true;
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 123F;
            this.spdList_Sheet1.Columns.Get(32).Label = "Rework Return Oper";
            this.spdList_Sheet1.Columns.Get(32).Locked = true;
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 123F;
            this.spdList_Sheet1.Columns.Get(33).Label = "Rework End Flow";
            this.spdList_Sheet1.Columns.Get(33).Locked = true;
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 117F;
            this.spdList_Sheet1.Columns.Get(34).Label = "Rework End Oper";
            this.spdList_Sheet1.Columns.Get(34).Locked = true;
            this.spdList_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(34).Width = 113F;
            this.spdList_Sheet1.Columns.Get(35).Label = "Return Option";
            this.spdList_Sheet1.Columns.Get(35).Locked = true;
            this.spdList_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(35).Width = 154F;
            this.spdList_Sheet1.Columns.Get(36).Label = "Local Rework Flag";
            this.spdList_Sheet1.Columns.Get(36).Locked = true;
            this.spdList_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(36).Width = 100F;
            this.spdList_Sheet1.Columns.Get(37).Label = "Rework Time";
            this.spdList_Sheet1.Columns.Get(37).Locked = true;
            this.spdList_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(37).Width = 120F;
            this.spdList_Sheet1.Columns.Get(38).Label = "NSTD Flag";
            this.spdList_Sheet1.Columns.Get(38).Locked = true;
            this.spdList_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(38).Width = 62F;
            this.spdList_Sheet1.Columns.Get(39).Label = "NSTD Return Flow";
            this.spdList_Sheet1.Columns.Get(39).Locked = true;
            this.spdList_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(39).Width = 118F;
            this.spdList_Sheet1.Columns.Get(40).Label = "NSTD Return Oper";
            this.spdList_Sheet1.Columns.Get(40).Locked = true;
            this.spdList_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(40).Width = 114F;
            this.spdList_Sheet1.Columns.Get(41).Label = "NSTD Time";
            this.spdList_Sheet1.Columns.Get(41).Locked = true;
            this.spdList_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(41).Width = 120F;
            this.spdList_Sheet1.Columns.Get(42).Label = "Repair Flag";
            this.spdList_Sheet1.Columns.Get(42).Locked = true;
            this.spdList_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(42).Width = 82F;
            this.spdList_Sheet1.Columns.Get(43).Label = "Repair Oper";
            this.spdList_Sheet1.Columns.Get(43).Locked = true;
            this.spdList_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(43).Width = 87F;
            this.spdList_Sheet1.Columns.Get(44).Label = "Store Return Flow";
            this.spdList_Sheet1.Columns.Get(44).Locked = true;
            this.spdList_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(44).Width = 129F;
            this.spdList_Sheet1.Columns.Get(45).Label = "Store Return Flow Seq";
            this.spdList_Sheet1.Columns.Get(45).Locked = true;
            this.spdList_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).Width = 129F;
            this.spdList_Sheet1.Columns.Get(46).Label = "Store Return Oper";
            this.spdList_Sheet1.Columns.Get(46).Locked = true;
            this.spdList_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(46).Width = 129F;
            this.spdList_Sheet1.Columns.Get(47).Label = "Start Flag";
            this.spdList_Sheet1.Columns.Get(47).Locked = true;
            this.spdList_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(47).Width = 66F;
            this.spdList_Sheet1.Columns.Get(48).CellType = textCellType1;
            this.spdList_Sheet1.Columns.Get(48).Label = "Start Time";
            this.spdList_Sheet1.Columns.Get(48).Locked = true;
            this.spdList_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(48).Width = 127F;
            this.spdList_Sheet1.Columns.Get(49).Label = "Start Resource ID";
            this.spdList_Sheet1.Columns.Get(49).Locked = true;
            this.spdList_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(49).Width = 110F;
            this.spdList_Sheet1.Columns.Get(50).Label = "End Flag";
            this.spdList_Sheet1.Columns.Get(50).Locked = true;
            this.spdList_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(51).Label = "End Time";
            this.spdList_Sheet1.Columns.Get(51).Locked = true;
            this.spdList_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(51).Width = 127F;
            this.spdList_Sheet1.Columns.Get(52).Label = "End Resource ID";
            this.spdList_Sheet1.Columns.Get(52).Locked = true;
            this.spdList_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(52).Width = 105F;
            this.spdList_Sheet1.Columns.Get(53).Label = "Sample Flag";
            this.spdList_Sheet1.Columns.Get(53).Locked = true;
            this.spdList_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(53).Width = 84F;
            this.spdList_Sheet1.Columns.Get(54).Label = "Sample Wait Flag";
            this.spdList_Sheet1.Columns.Get(54).Locked = true;
            this.spdList_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(54).Width = 109F;
            this.spdList_Sheet1.Columns.Get(55).Label = "Sample Result";
            this.spdList_Sheet1.Columns.Get(55).Locked = true;
            this.spdList_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(55).Width = 98F;
            this.spdList_Sheet1.Columns.Get(56).Label = "From To Lot ID";
            this.spdList_Sheet1.Columns.Get(56).Locked = true;
            this.spdList_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(56).Width = 105F;
            this.spdList_Sheet1.Columns.Get(57).Label = "Ship Code";
            this.spdList_Sheet1.Columns.Get(57).Locked = true;
            this.spdList_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(57).Width = 69F;
            this.spdList_Sheet1.Columns.Get(58).Label = "Ship Time";
            this.spdList_Sheet1.Columns.Get(58).Locked = true;
            this.spdList_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(58).Width = 123F;
            this.spdList_Sheet1.Columns.Get(59).Label = "Original Due Time";
            this.spdList_Sheet1.Columns.Get(59).Locked = true;
            this.spdList_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(59).Width = 123F;
            this.spdList_Sheet1.Columns.Get(60).Label = "Scheduled Due Time";
            this.spdList_Sheet1.Columns.Get(60).Locked = true;
            this.spdList_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(60).Width = 136F;
            this.spdList_Sheet1.Columns.Get(61).Label = "Create Time";
            this.spdList_Sheet1.Columns.Get(61).Locked = true;
            this.spdList_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(61).Width = 123F;
            this.spdList_Sheet1.Columns.Get(62).Label = "Factory In Time";
            this.spdList_Sheet1.Columns.Get(62).Locked = true;
            this.spdList_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(62).Width = 123F;
            this.spdList_Sheet1.Columns.Get(63).Label = "Flow In Time";
            this.spdList_Sheet1.Columns.Get(63).Locked = true;
            this.spdList_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(63).Width = 123F;
            this.spdList_Sheet1.Columns.Get(64).Label = "Oper In Time";
            this.spdList_Sheet1.Columns.Get(64).Locked = true;
            this.spdList_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(64).Width = 123F;
            this.spdList_Sheet1.Columns.Get(65).Label = "Reserve Resource ID";
            this.spdList_Sheet1.Columns.Get(65).Locked = true;
            this.spdList_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(65).Width = 129F;
            this.spdList_Sheet1.Columns.Get(66).Label = "Batch ID";
            this.spdList_Sheet1.Columns.Get(66).Locked = true;
            this.spdList_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            numberCellType11.DecimalPlaces = 0;
            numberCellType11.MaximumValue = 9999D;
            numberCellType11.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(67).CellType = numberCellType11;
            this.spdList_Sheet1.Columns.Get(67).Label = "Batch Seq";
            this.spdList_Sheet1.Columns.Get(67).Locked = true;
            this.spdList_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(67).Width = 72F;
            this.spdList_Sheet1.Columns.Get(68).Label = "Order ID";
            this.spdList_Sheet1.Columns.Get(68).Locked = true;
            this.spdList_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(68).Width = 100F;
            this.spdList_Sheet1.Columns.Get(69).Label = "Add Order ID 1";
            this.spdList_Sheet1.Columns.Get(69).Locked = true;
            this.spdList_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(69).Width = 100F;
            this.spdList_Sheet1.Columns.Get(70).Label = "Add Order ID 2";
            this.spdList_Sheet1.Columns.Get(70).Locked = true;
            this.spdList_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(70).Width = 100F;
            this.spdList_Sheet1.Columns.Get(71).Label = "Add Order ID 3";
            this.spdList_Sheet1.Columns.Get(71).Locked = true;
            this.spdList_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(71).Width = 100F;
            this.spdList_Sheet1.Columns.Get(72).Label = "Lot Location";
            this.spdList_Sheet1.Columns.Get(72).Locked = true;
            this.spdList_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(72).Width = 82F;
            this.spdList_Sheet1.Columns.Get(73).Label = "Lot CMF 1";
            this.spdList_Sheet1.Columns.Get(73).Locked = true;
            this.spdList_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(73).Width = 79F;
            this.spdList_Sheet1.Columns.Get(74).Label = "Lot CMF 2";
            this.spdList_Sheet1.Columns.Get(74).Locked = true;
            this.spdList_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(74).Width = 79F;
            this.spdList_Sheet1.Columns.Get(75).Label = "Lot CMF 3";
            this.spdList_Sheet1.Columns.Get(75).Locked = true;
            this.spdList_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(75).Width = 79F;
            this.spdList_Sheet1.Columns.Get(76).Label = "Lot CMF 4";
            this.spdList_Sheet1.Columns.Get(76).Locked = true;
            this.spdList_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(76).Width = 79F;
            this.spdList_Sheet1.Columns.Get(77).Label = "Lot CMF 5";
            this.spdList_Sheet1.Columns.Get(77).Locked = true;
            this.spdList_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(77).Width = 79F;
            this.spdList_Sheet1.Columns.Get(78).Label = "Lot CMF 6";
            this.spdList_Sheet1.Columns.Get(78).Locked = true;
            this.spdList_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(78).Width = 79F;
            this.spdList_Sheet1.Columns.Get(79).Label = "Lot CMF 7";
            this.spdList_Sheet1.Columns.Get(79).Locked = true;
            this.spdList_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(79).Width = 79F;
            this.spdList_Sheet1.Columns.Get(80).Label = "Lot CMF 8";
            this.spdList_Sheet1.Columns.Get(80).Locked = true;
            this.spdList_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(80).Width = 79F;
            this.spdList_Sheet1.Columns.Get(81).Label = "Lot CMF 9";
            this.spdList_Sheet1.Columns.Get(81).Locked = true;
            this.spdList_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(81).Width = 79F;
            this.spdList_Sheet1.Columns.Get(82).Label = "Lot CMF 10";
            this.spdList_Sheet1.Columns.Get(82).Locked = true;
            this.spdList_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(82).Width = 79F;
            this.spdList_Sheet1.Columns.Get(83).Label = "Lot CMF 11";
            this.spdList_Sheet1.Columns.Get(83).Locked = true;
            this.spdList_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(83).Width = 80F;
            this.spdList_Sheet1.Columns.Get(84).Label = "Lot CMF 12";
            this.spdList_Sheet1.Columns.Get(84).Locked = true;
            this.spdList_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(84).Width = 80F;
            this.spdList_Sheet1.Columns.Get(85).Label = "Lot CMF 13";
            this.spdList_Sheet1.Columns.Get(85).Locked = true;
            this.spdList_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(85).Width = 80F;
            this.spdList_Sheet1.Columns.Get(86).Label = "Lot CMF 14";
            this.spdList_Sheet1.Columns.Get(86).Locked = true;
            this.spdList_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(86).Width = 80F;
            this.spdList_Sheet1.Columns.Get(87).Label = "Lot CMF 15";
            this.spdList_Sheet1.Columns.Get(87).Locked = true;
            this.spdList_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(87).Width = 80F;
            this.spdList_Sheet1.Columns.Get(88).Label = "Lot CMF 16";
            this.spdList_Sheet1.Columns.Get(88).Locked = true;
            this.spdList_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(88).Width = 80F;
            this.spdList_Sheet1.Columns.Get(89).Label = "Lot CMF 17";
            this.spdList_Sheet1.Columns.Get(89).Locked = true;
            this.spdList_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(89).Width = 80F;
            this.spdList_Sheet1.Columns.Get(90).Label = "Lot CMF 18";
            this.spdList_Sheet1.Columns.Get(90).Locked = true;
            this.spdList_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(90).Width = 80F;
            this.spdList_Sheet1.Columns.Get(91).Label = "Lot CMF 19";
            this.spdList_Sheet1.Columns.Get(91).Locked = true;
            this.spdList_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(91).Width = 80F;
            this.spdList_Sheet1.Columns.Get(92).Label = "Lot Cmf 20";
            this.spdList_Sheet1.Columns.Get(92).Locked = true;
            this.spdList_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(92).Width = 80F;
            this.spdList_Sheet1.Columns.Get(93).Label = "BOM Set ID";
            this.spdList_Sheet1.Columns.Get(93).Locked = true;
            this.spdList_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(93).Width = 100F;
            this.spdList_Sheet1.Columns.Get(94).Label = "BOM Set Version";
            this.spdList_Sheet1.Columns.Get(94).Locked = true;
            this.spdList_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(94).Width = 100F;
            this.spdList_Sheet1.Columns.Get(95).Label = "BOM Act Hist Seq";
            this.spdList_Sheet1.Columns.Get(95).Locked = true;
            this.spdList_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(95).Width = 100F;
            this.spdList_Sheet1.Columns.Get(96).Label = "BOM Hist Seq";
            this.spdList_Sheet1.Columns.Get(96).Locked = true;
            this.spdList_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(96).Width = 100F;
            this.spdList_Sheet1.Columns.Get(97).Label = "Lot Delete Flag";
            this.spdList_Sheet1.Columns.Get(97).Locked = true;
            this.spdList_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(97).Width = 101F;
            this.spdList_Sheet1.Columns.Get(98).Label = "Lot Delete Reason";
            this.spdList_Sheet1.Columns.Get(98).Locked = true;
            this.spdList_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(98).Width = 119F;
            this.spdList_Sheet1.Columns.Get(99).Label = "Lot Delete Time";
            this.spdList_Sheet1.Columns.Get(99).Locked = true;
            this.spdList_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(99).Width = 129F;
            this.spdList_Sheet1.Columns.Get(100).Label = "Last Tran Code";
            this.spdList_Sheet1.Columns.Get(100).Locked = true;
            this.spdList_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(100).Width = 104F;
            this.spdList_Sheet1.Columns.Get(101).Label = "Last Tran Time";
            this.spdList_Sheet1.Columns.Get(101).Locked = true;
            this.spdList_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(101).Width = 128F;
            this.spdList_Sheet1.Columns.Get(102).Label = "Last Comment";
            this.spdList_Sheet1.Columns.Get(102).Locked = true;
            this.spdList_Sheet1.Columns.Get(102).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(102).Width = 220F;
            numberCellType12.DecimalPlaces = 0;
            numberCellType12.MaximumValue = 9999D;
            numberCellType12.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(103).CellType = numberCellType12;
            this.spdList_Sheet1.Columns.Get(103).Label = "Last Active Hist Seq";
            this.spdList_Sheet1.Columns.Get(103).Locked = true;
            this.spdList_Sheet1.Columns.Get(103).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(103).Width = 130F;
            numberCellType13.DecimalPlaces = 0;
            numberCellType13.MaximumValue = 9999D;
            numberCellType13.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(104).CellType = numberCellType13;
            this.spdList_Sheet1.Columns.Get(104).Label = "Last Hist Seq";
            this.spdList_Sheet1.Columns.Get(104).Locked = true;
            this.spdList_Sheet1.Columns.Get(104).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(104).Width = 91F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPViewReworkLotList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewReworkLotList";
            this.Text = "View Rework Lot List";
            this.Activated += new System.EventHandler(this.frmWIPViewReworkLotList_Activated);
            this.Load += new System.EventHandler(this.frmWIPViewReworkLotList_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        private bool View_Rework_Lot_List()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
            int i;
            int iRow;
            int iCol;

            MPCF.ClearList(spdList, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Rework_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdList.ActiveSheet.RowCount;
                    spdList.ActiveSheet.RowCount++;

                    iCol = 0;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_1"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_TYPE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OWNER_CODE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_CODE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_PRIORITY");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_STATUS");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("HOLD_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("HOLD_CODE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_1"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_1"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_2"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_3"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("INV_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("TRANSIT_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("UNIT_EXIST_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("INV_UNIT");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("RWK_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_CODE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("RWK_COUNT");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("RWK_DEPTH");
                    
                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_STOP_OPER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_RET_FLOW");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_RET_OPER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_END_FLOW");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_END_OPER");

                    iCol++;
                    switch (out_node.GetList(0)[i].GetChar("RWK_RET_CLEAR_FLAG"))
                    {
                        case 'Y':
                            spdList.ActiveSheet.Cells[iRow, iCol].Value = "Clear Rework";
                            break;
                        case 'A':
                            spdList.ActiveSheet.Cells[iRow, iCol].Value = "Clear Rework and Move to Next Operation";
                            break;
                        case 'B':
                            spdList.ActiveSheet.Cells[iRow, iCol].Value = "Keep Rework and Move to Next Operation";
                            break;
                        default:
                            if (out_node.GetList(0)[i].GetChar("RWK_FLAG") == 'Y')
                            {
                                spdList.ActiveSheet.Cells[iRow, iCol].Value = "Keep Rework";
                            }
                            else
                            {
                                spdList.ActiveSheet.Cells[iRow, iCol].Value = "";
                            }
                            break;
                    }

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOCAL_REWORK_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RWK_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("NSTD_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("NSTD_RET_FLOW");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("NSTD_RET_OPER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("NSTD_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("REP_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("REP_OPER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("STR_RET_FLOW");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("STR_RET_FLOW_SEQ_NUM");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("STR_RET_OPER");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("START_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("START_RES_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("END_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("END_RES_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SAMPLE_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SAMPLE_WAIT_FLAG");

                    iCol++;
                    switch (out_node.GetList(0)[i].GetChar("SAMPLE_RESULT"))
                    {
                        case 'Y':

                            spdList.ActiveSheet.Cells[iRow, iCol].Value = "Good";
                            break;
                        case 'N':

                            spdList.ActiveSheet.Cells[iRow, iCol].Value = "No Good";
                            break;
                        default:

                            spdList.ActiveSheet.Cells[iRow, iCol].Value = "";
                            break;
                    }
                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FROM_TO_LOT_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SHIP_CODE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SHIP_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ORG_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SCH_DUE_TIME"), DATE_TIME_FORMAT.DATE);

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FAC_IN_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("FLOW_IN_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("OPER_IN_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RESERVE_RES_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("BATCH_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("#######,##0", out_node.GetList(0)[i].GetInt("BATCH_SEQ"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ORDER_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ADD_ORDER_ID_1");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ADD_ORDER_ID_2");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ADD_ORDER_ID_3");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_LOCATION");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_1");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_2");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_3");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_4");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_5");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_6");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_7");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_8");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_9");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_10");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_11");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_12");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_13");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_14");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_15");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_16");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_17");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_18");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_19");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_CMF_20");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("BOM_SET_ID");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("BOM_SET_VERSION"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_ACTIVE_HIST_SEQ"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("BOM_HIST_SEQ"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_DEL_CODE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LOT_DEL_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LAST_TRAN_CODE");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LAST_COMMENT");

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ"));

                    iCol++;
                    spdList.ActiveSheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ"));

                    iCol++;
                    if (out_node.GetList(0)[i].GetChar("LOT_DEL_FLAG") == 'Y')
                    {
                        spdList.ActiveSheet.Rows[iRow].ForeColor = Color.Magenta;
                    }
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
        
        private void frmWIPViewReworkLotList_Load(object sender, System.EventArgs e)
        {
            
            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = dtpTo.Value.AddMonths(- 1);
            
        }
        
        private void frmWIPViewReworkLotList_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);
                
                b_load_flag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            View_Rework_Lot_List();
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Material : " + MPCF.Trim(cdvMaterial.Text) + "\r";
            sCond = sCond + "Version : " + MPCF.Trim(cdvMaterial.Version) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            MPCF.ExportToExcel(spdList, this.Text, sCond);
            
        }
        
    }
    
}
