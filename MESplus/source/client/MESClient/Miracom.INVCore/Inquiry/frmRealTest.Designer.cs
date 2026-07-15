namespace Miracom.INVCore
{
    partial class frmRealTest
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblLotID;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Size = new System.Drawing.Size(742, 74);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtDesc);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblDesc);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Size = new System.Drawing.Size(742, 74);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 74);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 439);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Lot List By Operation";
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
            this.spdList.Size = new System.Drawing.Size(742, 436);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 1;
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
            spdList_Sheet1.ColumnCount = 79;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Slot No.";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Sub Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Material";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Mat Ver";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Carrier ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Owner Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Create Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Status";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Hold Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Hold Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Create Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Create Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Oper In Qty 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Oper In Qty 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Inventory Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Transit Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Tracking Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Inv Unit";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Rework Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Rework Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Rework Count";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Rework Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Rework Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Rework End Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Rework End Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Rework Return Clear Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Rework Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "NSTD Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "NSTD Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "NSTD Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "NSTD Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Start Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Start Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Start Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "End Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "End Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "End Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Sample Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Sample Wait Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Sample Result";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Reserve Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Location";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Lot CMF 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Lot CMF 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Lot CMF 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Lot CMF 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Lot CMF 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Lot CMF 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Lot CMF 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Lot CMF 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Lot CMF 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Lot CMF 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Lot CMF 11";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Lot CMF 12";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Lot CMF 13";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Lot CMF 14";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Lot CMF 15";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Lot CMF 16";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Lot CMF 17";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Lot CMF 18";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Lot CMF 19";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "Lot Cmf 20";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "Grade";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "Grade Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "Cell Grade";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "Lot Base";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "Lot Delete Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "Lot Delete Reason";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "Lot Delete Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "Last Tran Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "Last Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "Last Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Last Active Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Last Hist Seq";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 33F;
            this.spdList_Sheet1.Columns.Get(0).Label = "Slot No.";
            this.spdList_Sheet1.Columns.Get(0).Width = 42F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Sub Lot ID";
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
            this.spdList_Sheet1.Columns.Get(7).Label = "Qty 2";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 73F;
            numberCellType2.DecimalPlaces = 3;
            numberCellType2.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(8).CellType = numberCellType2;
            this.spdList_Sheet1.Columns.Get(8).Label = "Qty 3";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 73F;
            this.spdList_Sheet1.Columns.Get(9).Label = "Carrier ID";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 68F;
            this.spdList_Sheet1.Columns.Get(10).Label = "Owner Code";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 79F;
            this.spdList_Sheet1.Columns.Get(11).Label = "Create Code";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 79F;
            this.spdList_Sheet1.Columns.Get(12).Label = "Status";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 67F;
            this.spdList_Sheet1.Columns.Get(13).Label = "Hold Flag";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 66F;
            this.spdList_Sheet1.Columns.Get(14).Label = "Hold Code";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 70F;
            numberCellType3.DecimalPlaces = 3;
            numberCellType3.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(15).CellType = numberCellType3;
            this.spdList_Sheet1.Columns.Get(15).Label = "Create Qty 2";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 80F;
            numberCellType4.DecimalPlaces = 3;
            numberCellType4.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(16).CellType = numberCellType4;
            this.spdList_Sheet1.Columns.Get(16).Label = "Create Qty 3";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Width = 80F;
            numberCellType5.DecimalPlaces = 3;
            numberCellType5.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(17).CellType = numberCellType5;
            this.spdList_Sheet1.Columns.Get(17).Label = "Oper In Qty 2";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 84F;
            numberCellType6.DecimalPlaces = 3;
            numberCellType6.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(18).CellType = numberCellType6;
            this.spdList_Sheet1.Columns.Get(18).Label = "Oper In Qty 3";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Width = 84F;
            this.spdList_Sheet1.Columns.Get(19).Label = "Inventory Flag";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 68F;
            this.spdList_Sheet1.Columns.Get(20).Label = "Transit Flag";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 82F;
            this.spdList_Sheet1.Columns.Get(21).Label = "Tracking Flag";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 89F;
            this.spdList_Sheet1.Columns.Get(22).Label = "Inv Unit";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Label = "Rework Flag";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 79F;
            this.spdList_Sheet1.Columns.Get(24).Label = "Rework Code";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 85F;
            numberCellType7.DecimalPlaces = 0;
            numberCellType7.MaximumValue = 9999D;
            numberCellType7.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(25).CellType = numberCellType7;
            this.spdList_Sheet1.Columns.Get(25).Label = "Rework Count";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 87F;
            this.spdList_Sheet1.Columns.Get(26).Label = "Rework Return Flow";
            this.spdList_Sheet1.Columns.Get(26).Locked = true;
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 123F;
            this.spdList_Sheet1.Columns.Get(27).Label = "Rework Return Oper";
            this.spdList_Sheet1.Columns.Get(27).Locked = true;
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 123F;
            this.spdList_Sheet1.Columns.Get(28).Label = "Rework End Flow";
            this.spdList_Sheet1.Columns.Get(28).Locked = true;
            this.spdList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).Width = 117F;
            this.spdList_Sheet1.Columns.Get(29).Label = "Rework End Oper";
            this.spdList_Sheet1.Columns.Get(29).Locked = true;
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 113F;
            this.spdList_Sheet1.Columns.Get(30).Label = "Rework Return Clear Flag";
            this.spdList_Sheet1.Columns.Get(30).Locked = true;
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 154F;
            this.spdList_Sheet1.Columns.Get(31).Label = "Rework Time";
            this.spdList_Sheet1.Columns.Get(31).Locked = true;
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 120F;
            this.spdList_Sheet1.Columns.Get(32).Label = "NSTD Flag";
            this.spdList_Sheet1.Columns.Get(32).Locked = true;
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 62F;
            this.spdList_Sheet1.Columns.Get(33).Label = "NSTD Return Flow";
            this.spdList_Sheet1.Columns.Get(33).Locked = true;
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 118F;
            this.spdList_Sheet1.Columns.Get(34).Label = "NSTD Return Oper";
            this.spdList_Sheet1.Columns.Get(34).Locked = true;
            this.spdList_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(34).Width = 114F;
            this.spdList_Sheet1.Columns.Get(35).Label = "NSTD Time";
            this.spdList_Sheet1.Columns.Get(35).Locked = true;
            this.spdList_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(35).Width = 120F;
            this.spdList_Sheet1.Columns.Get(36).Label = "Start Flag";
            this.spdList_Sheet1.Columns.Get(36).Locked = true;
            this.spdList_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(36).Width = 66F;
            this.spdList_Sheet1.Columns.Get(37).CellType = textCellType1;
            this.spdList_Sheet1.Columns.Get(37).Label = "Start Time";
            this.spdList_Sheet1.Columns.Get(37).Locked = true;
            this.spdList_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(37).Width = 127F;
            this.spdList_Sheet1.Columns.Get(38).Label = "Start Resource ID";
            this.spdList_Sheet1.Columns.Get(38).Locked = true;
            this.spdList_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(38).Width = 110F;
            this.spdList_Sheet1.Columns.Get(39).Label = "End Flag";
            this.spdList_Sheet1.Columns.Get(39).Locked = true;
            this.spdList_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(40).Label = "End Time";
            this.spdList_Sheet1.Columns.Get(40).Locked = true;
            this.spdList_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(40).Width = 127F;
            this.spdList_Sheet1.Columns.Get(41).Label = "End Resource ID";
            this.spdList_Sheet1.Columns.Get(41).Locked = true;
            this.spdList_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(41).Width = 105F;
            this.spdList_Sheet1.Columns.Get(42).Label = "Sample Flag";
            this.spdList_Sheet1.Columns.Get(42).Locked = true;
            this.spdList_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(42).Width = 84F;
            this.spdList_Sheet1.Columns.Get(43).Label = "Sample Wait Flag";
            this.spdList_Sheet1.Columns.Get(43).Locked = true;
            this.spdList_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(43).Width = 109F;
            this.spdList_Sheet1.Columns.Get(44).Label = "Sample Result";
            this.spdList_Sheet1.Columns.Get(44).Locked = true;
            this.spdList_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(44).Width = 98F;
            this.spdList_Sheet1.Columns.Get(45).Label = "Reserve Resource ID";
            this.spdList_Sheet1.Columns.Get(45).Locked = true;
            this.spdList_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).Width = 94F;
            this.spdList_Sheet1.Columns.Get(46).Label = "Location";
            this.spdList_Sheet1.Columns.Get(46).Locked = true;
            this.spdList_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(46).Width = 69F;
            this.spdList_Sheet1.Columns.Get(47).Label = "Lot CMF 1";
            this.spdList_Sheet1.Columns.Get(47).Locked = true;
            this.spdList_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(47).Width = 79F;
            this.spdList_Sheet1.Columns.Get(48).Label = "Lot CMF 2";
            this.spdList_Sheet1.Columns.Get(48).Locked = true;
            this.spdList_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(48).Width = 79F;
            this.spdList_Sheet1.Columns.Get(49).Label = "Lot CMF 3";
            this.spdList_Sheet1.Columns.Get(49).Locked = true;
            this.spdList_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(49).Width = 79F;
            this.spdList_Sheet1.Columns.Get(50).Label = "Lot CMF 4";
            this.spdList_Sheet1.Columns.Get(50).Locked = true;
            this.spdList_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(50).Width = 79F;
            this.spdList_Sheet1.Columns.Get(51).Label = "Lot CMF 5";
            this.spdList_Sheet1.Columns.Get(51).Locked = true;
            this.spdList_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(51).Width = 79F;
            this.spdList_Sheet1.Columns.Get(52).Label = "Lot CMF 6";
            this.spdList_Sheet1.Columns.Get(52).Locked = true;
            this.spdList_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(52).Width = 79F;
            this.spdList_Sheet1.Columns.Get(53).Label = "Lot CMF 7";
            this.spdList_Sheet1.Columns.Get(53).Locked = true;
            this.spdList_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(53).Width = 79F;
            this.spdList_Sheet1.Columns.Get(54).Label = "Lot CMF 8";
            this.spdList_Sheet1.Columns.Get(54).Locked = true;
            this.spdList_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(54).Width = 79F;
            this.spdList_Sheet1.Columns.Get(55).Label = "Lot CMF 9";
            this.spdList_Sheet1.Columns.Get(55).Locked = true;
            this.spdList_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(55).Width = 79F;
            this.spdList_Sheet1.Columns.Get(56).Label = "Lot CMF 10";
            this.spdList_Sheet1.Columns.Get(56).Locked = true;
            this.spdList_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(56).Width = 79F;
            this.spdList_Sheet1.Columns.Get(57).Label = "Lot CMF 11";
            this.spdList_Sheet1.Columns.Get(57).Locked = true;
            this.spdList_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(57).Width = 80F;
            this.spdList_Sheet1.Columns.Get(58).Label = "Lot CMF 12";
            this.spdList_Sheet1.Columns.Get(58).Locked = true;
            this.spdList_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(58).Width = 80F;
            this.spdList_Sheet1.Columns.Get(59).Label = "Lot CMF 13";
            this.spdList_Sheet1.Columns.Get(59).Locked = true;
            this.spdList_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(59).Width = 80F;
            this.spdList_Sheet1.Columns.Get(60).Label = "Lot CMF 14";
            this.spdList_Sheet1.Columns.Get(60).Locked = true;
            this.spdList_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(60).Width = 80F;
            this.spdList_Sheet1.Columns.Get(61).Label = "Lot CMF 15";
            this.spdList_Sheet1.Columns.Get(61).Locked = true;
            this.spdList_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(61).Width = 80F;
            this.spdList_Sheet1.Columns.Get(62).Label = "Lot CMF 16";
            this.spdList_Sheet1.Columns.Get(62).Locked = true;
            this.spdList_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(62).Width = 80F;
            this.spdList_Sheet1.Columns.Get(63).Label = "Lot CMF 17";
            this.spdList_Sheet1.Columns.Get(63).Locked = true;
            this.spdList_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(63).Width = 80F;
            this.spdList_Sheet1.Columns.Get(64).Label = "Lot CMF 18";
            this.spdList_Sheet1.Columns.Get(64).Locked = true;
            this.spdList_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(64).Width = 80F;
            this.spdList_Sheet1.Columns.Get(65).Label = "Lot CMF 19";
            this.spdList_Sheet1.Columns.Get(65).Locked = true;
            this.spdList_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(65).Width = 80F;
            this.spdList_Sheet1.Columns.Get(66).Label = "Lot Cmf 20";
            this.spdList_Sheet1.Columns.Get(66).Locked = true;
            this.spdList_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(66).Width = 80F;
            this.spdList_Sheet1.Columns.Get(69).Label = "Cell Grade";
            this.spdList_Sheet1.Columns.Get(69).Width = 104F;
            this.spdList_Sheet1.Columns.Get(71).Label = "Lot Delete Flag";
            this.spdList_Sheet1.Columns.Get(71).Locked = true;
            this.spdList_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(71).Width = 101F;
            this.spdList_Sheet1.Columns.Get(72).Label = "Lot Delete Reason";
            this.spdList_Sheet1.Columns.Get(72).Locked = true;
            this.spdList_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(72).Width = 119F;
            this.spdList_Sheet1.Columns.Get(73).Label = "Lot Delete Time";
            this.spdList_Sheet1.Columns.Get(73).Locked = true;
            this.spdList_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(73).Width = 129F;
            this.spdList_Sheet1.Columns.Get(74).Label = "Last Tran Code";
            this.spdList_Sheet1.Columns.Get(74).Locked = true;
            this.spdList_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(74).Width = 104F;
            this.spdList_Sheet1.Columns.Get(75).Label = "Last Tran Time";
            this.spdList_Sheet1.Columns.Get(75).Locked = true;
            this.spdList_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(75).Width = 128F;
            this.spdList_Sheet1.Columns.Get(76).Label = "Last Comment";
            this.spdList_Sheet1.Columns.Get(76).Locked = true;
            this.spdList_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(76).Width = 220F;
            numberCellType8.DecimalPlaces = 0;
            numberCellType8.MaximumValue = 9999D;
            numberCellType8.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(77).CellType = numberCellType8;
            this.spdList_Sheet1.Columns.Get(77).Label = "Last Active Hist Seq";
            this.spdList_Sheet1.Columns.Get(77).Locked = true;
            this.spdList_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(77).Width = 130F;
            numberCellType9.DecimalPlaces = 0;
            numberCellType9.MaximumValue = 9999D;
            numberCellType9.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(78).CellType = numberCellType9;
            this.spdList_Sheet1.Columns.Get(78).Label = "Last Hist Seq";
            this.spdList_Sheet1.Columns.Get(78).Locked = true;
            this.spdList_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(78).Width = 91F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.RowHeader.Visible = false;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(119, 41);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(604, 20);
            this.txtDesc.TabIndex = 7;
            this.txtDesc.TabStop = false;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(119, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 5;
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(14, 44);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(100, 14);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Description";
            // 
            // lblLotID
            // 
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(14, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(100, 14);
            this.lblLotID.TabIndex = 4;
            this.lblLotID.Text = "Lot ID";
            // 
            // frmRealTest
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRealTest";
            this.Text = "View Sub Lot List";
            this.Activated += new System.EventHandler(this.frmRealTest_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}