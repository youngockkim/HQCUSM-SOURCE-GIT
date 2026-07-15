
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
    public class frmWIPViewTransitLotList : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewTransitLotList()
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
        


        //ì½”ë“œ ?¸ì§‘ê¸°ë? ?¬ìš©?˜ì—¬ ?˜ì •?˜ì? ë§ˆì‹­?œì˜¤.
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.RadioButton rbnWaitLot;
        private System.Windows.Forms.RadioButton rbnShipLot;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private Miracom.MESCore.Controls.udcMaterial cdvMaterial;
        private System.Windows.Forms.CheckBox chkIncludeDelLot;
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
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.rbnWaitLot = new System.Windows.Forms.RadioButton();
            this.rbnShipLot = new System.Windows.Forms.RadioButton();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.chkIncludeDelLot = new System.Windows.Forms.CheckBox();
            this.cdvMaterial = new Miracom.MESCore.Controls.udcMaterial();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 60);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvMaterial);
            this.grpOption.Controls.Add(this.chkIncludeDelLot);
            this.grpOption.Controls.Add(this.rbnShipLot);
            this.grpOption.Controls.Add(this.rbnWaitLot);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(742, 60);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 60);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 453);
            this.pnlViewMid.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Transit Lot List";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(424, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(308, 20);
            this.pnlPeriod.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(107, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(3, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(86, 13);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Transit Period";
            this.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(218, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(200, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // rbnWaitLot
            // 
            this.rbnWaitLot.AutoSize = true;
            this.rbnWaitLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnWaitLot.Location = new System.Drawing.Point(12, 40);
            this.rbnWaitLot.Name = "rbnWaitLot";
            this.rbnWaitLot.Size = new System.Drawing.Size(114, 18);
            this.rbnWaitLot.TabIndex = 1;
            this.rbnWaitLot.Text = "Wait Receive Lot";
            // 
            // rbnShipLot
            // 
            this.rbnShipLot.AutoSize = true;
            this.rbnShipLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnShipLot.Location = new System.Drawing.Point(200, 40);
            this.rbnShipLot.Name = "rbnShipLot";
            this.rbnShipLot.Size = new System.Drawing.Size(90, 18);
            this.rbnShipLot.TabIndex = 2;
            this.rbnShipLot.Text = "Shipping Lot";
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
            this.spdList.Size = new System.Drawing.Size(742, 450);
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
            spdList_Sheet1.ColumnCount = 103;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Factory";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
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
            this.spdList_Sheet1.Columns.Get(0).Label = "Factory";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 80F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 101F;
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
            numberCellType10.DecimalPlaces = 0;
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
            this.spdList_Sheet1.Columns.Get(40).Width = 96F;
            this.spdList_Sheet1.Columns.Get(41).Label = "Repair Oper";
            this.spdList_Sheet1.Columns.Get(41).Locked = true;
            this.spdList_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(41).Width = 96F;
            this.spdList_Sheet1.Columns.Get(42).Label = "Store Return Flow";
            this.spdList_Sheet1.Columns.Get(42).Locked = true;
            this.spdList_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(42).Width = 116F;
            this.spdList_Sheet1.Columns.Get(43).Label = "Store Return Flow Seq";
            this.spdList_Sheet1.Columns.Get(43).Locked = true;
            this.spdList_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(43).Width = 116F;
            this.spdList_Sheet1.Columns.Get(44).Label = "Store Return Oper";
            this.spdList_Sheet1.Columns.Get(44).Locked = true;
            this.spdList_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(44).Width = 116F;
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
            numberCellType11.DecimalPlaces = 0;
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
            numberCellType12.DecimalPlaces = 0;
            numberCellType12.MaximumValue = 9999D;
            numberCellType12.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(101).CellType = numberCellType12;
            this.spdList_Sheet1.Columns.Get(101).Label = "Last Active Hist Seq";
            this.spdList_Sheet1.Columns.Get(101).Locked = true;
            this.spdList_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(101).Width = 130F;
            numberCellType13.DecimalPlaces = 0;
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
            // chkIncludeDelLot
            // 
            this.chkIncludeDelLot.AutoSize = true;
            this.chkIncludeDelLot.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDelLot.Location = new System.Drawing.Point(424, 40);
            this.chkIncludeDelLot.Name = "chkIncludeDelLot";
            this.chkIncludeDelLot.Size = new System.Drawing.Size(119, 18);
            this.chkIncludeDelLot.TabIndex = 4;
            this.chkIncludeDelLot.Text = "Include Delete Lot";
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
            // frmWIPViewTransitLotList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewTransitLotList";
            this.Text = "View Transit Lot List";
            this.Activated += new System.EventHandler(this.frmWIPViewTransitLotList_Activated);
            this.Load += new System.EventHandler(this.frmWIPViewTransitLotList_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
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
        
        private bool View_Transit_Lot_List()
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_LIST_OUT");
            int i;

            MPCF.ClearList(spdList, true);

            MPCR.SetInMsg(in_node);

            if (rbnWaitLot.Checked == true)
            {
                in_node.ProcStep = '1';
            }
            else
            {
                in_node.ProcStep = '2';
            }

            in_node.AddString("MAT_ID", MPCF.Trim(cdvMaterial.Text));
            in_node.AddInt("MAT_VER", cdvMaterial.Version);
            in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));

            if (this.chkIncludeDelLot.Checked == true)
            {
                in_node.AddChar("LOT_DEL_FLAG", 'Y');
            }

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Transit_Lot_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    WIPLIST.DisplayLotListDetail(spdList, out_node.GetList(0)[i], 1);
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
        
        private void frmWIPViewTransitLotList_Load(object sender, System.EventArgs e)
        {
            
            dtpFrom.Value = dtpTo.Value.AddDays(- 7);
            
        }
        
        private void frmWIPViewTransitLotList_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);
                
                rbnWaitLot.Checked = true;
                rbnShipLot.Checked = false;
                b_load_flag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            View_Transit_Lot_List();
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Material : " + MPCF.Trim(cdvMaterial.Text) + "\r";
            sCond = sCond + "Version : " + MPCF.Trim(cdvMaterial.Version) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));

            if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
            
        }
    
    }
    
}
