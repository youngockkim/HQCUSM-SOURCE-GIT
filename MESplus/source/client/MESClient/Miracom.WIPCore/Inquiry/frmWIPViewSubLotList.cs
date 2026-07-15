
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
//       - View_SubLot_List() : View Lot List By Operation Condition
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
    public class frmWIPViewSubLotList : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewSubLotList()
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
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblDesc;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.Label lblLotID;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
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
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType8 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType9 = new FarPoint.Win.Spread.CellType.NumberCellType();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
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
            this.pnlViewMid.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
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
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(14, 44);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Description";
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(14, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 4;
            this.lblLotID.Text = "Lot ID";
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
            this.spdList.HorizontalScrollBar.TabIndex = 6;
            this.spdList.Location = new System.Drawing.Point(0, 3);
            this.spdList.Name = "spdList";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer2;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer2;
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
            this.spdList.Size = new System.Drawing.Size(742, 436);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 3;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 7;
            this.spdList.SetViewportLeftColumn(0, 0, 2);
            this.spdList.SetActiveViewport(0, 0, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 85;
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
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Repair Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Repair Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Store Return Flow";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Store Return Flow Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Store Return Oper";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Start Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Start Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Start Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "End Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "End Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "End Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Sample Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Sample Wait Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Sample Result";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Reserve Resource ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Location";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Lot CMF 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Lot CMF 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Lot CMF 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Lot CMF 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Lot CMF 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Lot CMF 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Lot CMF 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Lot CMF 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Lot CMF 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Lot CMF 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Lot CMF 11";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Lot CMF 12";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Lot CMF 13";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Lot CMF 14";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "Lot CMF 15";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "Lot CMF 16";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "Lot CMF 17";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "Lot CMF 18";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "Lot CMF 19";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "Lot Cmf 20";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "Grade";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "Grade Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "Cell Grade";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "Cell Judge";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "Lot Base";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Lot Delete Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Lot Delete Reason";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 79).Value = "Lot Delete Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 80).Value = "Last Tran Code";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 81).Value = "Last Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 82).Value = "Last Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 83).Value = "Last Active Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 84).Value = "Last Hist Seq";
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
            this.spdList_Sheet1.Columns.Get(36).Label = "Repair Flag";
            this.spdList_Sheet1.Columns.Get(36).Locked = true;
            this.spdList_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(36).Width = 61F;
            this.spdList_Sheet1.Columns.Get(37).Label = "Repair Return Oper";
            this.spdList_Sheet1.Columns.Get(37).Locked = true;
            this.spdList_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(37).Width = 88F;
            this.spdList_Sheet1.Columns.Get(38).Label = "Store Return Flow";
            this.spdList_Sheet1.Columns.Get(38).Locked = true;
            this.spdList_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(38).Width = 88F;
            this.spdList_Sheet1.Columns.Get(39).Label = "Store Return Flow Seq";
            this.spdList_Sheet1.Columns.Get(39).Locked = true;
            this.spdList_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(39).Width = 88F;
            this.spdList_Sheet1.Columns.Get(40).Label = "Store Return Oper";
            this.spdList_Sheet1.Columns.Get(40).Locked = true;
            this.spdList_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(40).Width = 88F;
            this.spdList_Sheet1.Columns.Get(41).Label = "Start Flag";
            this.spdList_Sheet1.Columns.Get(41).Locked = true;
            this.spdList_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(41).Width = 66F;
            this.spdList_Sheet1.Columns.Get(42).CellType = textCellType1;
            this.spdList_Sheet1.Columns.Get(42).Label = "Start Time";
            this.spdList_Sheet1.Columns.Get(42).Locked = true;
            this.spdList_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(42).Width = 127F;
            this.spdList_Sheet1.Columns.Get(43).Label = "Start Resource ID";
            this.spdList_Sheet1.Columns.Get(43).Locked = true;
            this.spdList_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(43).Width = 110F;
            this.spdList_Sheet1.Columns.Get(44).Label = "End Flag";
            this.spdList_Sheet1.Columns.Get(44).Locked = true;
            this.spdList_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).Label = "End Time";
            this.spdList_Sheet1.Columns.Get(45).Locked = true;
            this.spdList_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(45).Width = 127F;
            this.spdList_Sheet1.Columns.Get(46).Label = "End Resource ID";
            this.spdList_Sheet1.Columns.Get(46).Locked = true;
            this.spdList_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(46).Width = 105F;
            this.spdList_Sheet1.Columns.Get(47).Label = "Sample Flag";
            this.spdList_Sheet1.Columns.Get(47).Locked = true;
            this.spdList_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(47).Width = 84F;
            this.spdList_Sheet1.Columns.Get(48).Label = "Sample Wait Flag";
            this.spdList_Sheet1.Columns.Get(48).Locked = true;
            this.spdList_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(48).Width = 109F;
            this.spdList_Sheet1.Columns.Get(49).Label = "Sample Result";
            this.spdList_Sheet1.Columns.Get(49).Locked = true;
            this.spdList_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(49).Width = 98F;
            this.spdList_Sheet1.Columns.Get(50).Label = "Reserve Resource ID";
            this.spdList_Sheet1.Columns.Get(50).Locked = true;
            this.spdList_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(50).Width = 94F;
            this.spdList_Sheet1.Columns.Get(51).Label = "Location";
            this.spdList_Sheet1.Columns.Get(51).Locked = true;
            this.spdList_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(51).Width = 69F;
            this.spdList_Sheet1.Columns.Get(52).Label = "Lot CMF 1";
            this.spdList_Sheet1.Columns.Get(52).Locked = true;
            this.spdList_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(52).Width = 79F;
            this.spdList_Sheet1.Columns.Get(53).Label = "Lot CMF 2";
            this.spdList_Sheet1.Columns.Get(53).Locked = true;
            this.spdList_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(53).Width = 79F;
            this.spdList_Sheet1.Columns.Get(54).Label = "Lot CMF 3";
            this.spdList_Sheet1.Columns.Get(54).Locked = true;
            this.spdList_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(54).Width = 79F;
            this.spdList_Sheet1.Columns.Get(55).Label = "Lot CMF 4";
            this.spdList_Sheet1.Columns.Get(55).Locked = true;
            this.spdList_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(55).Width = 79F;
            this.spdList_Sheet1.Columns.Get(56).Label = "Lot CMF 5";
            this.spdList_Sheet1.Columns.Get(56).Locked = true;
            this.spdList_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(56).Width = 79F;
            this.spdList_Sheet1.Columns.Get(57).Label = "Lot CMF 6";
            this.spdList_Sheet1.Columns.Get(57).Locked = true;
            this.spdList_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(57).Width = 79F;
            this.spdList_Sheet1.Columns.Get(58).Label = "Lot CMF 7";
            this.spdList_Sheet1.Columns.Get(58).Locked = true;
            this.spdList_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(58).Width = 79F;
            this.spdList_Sheet1.Columns.Get(59).Label = "Lot CMF 8";
            this.spdList_Sheet1.Columns.Get(59).Locked = true;
            this.spdList_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(59).Width = 79F;
            this.spdList_Sheet1.Columns.Get(60).Label = "Lot CMF 9";
            this.spdList_Sheet1.Columns.Get(60).Locked = true;
            this.spdList_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(60).Width = 79F;
            this.spdList_Sheet1.Columns.Get(61).Label = "Lot CMF 10";
            this.spdList_Sheet1.Columns.Get(61).Locked = true;
            this.spdList_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(61).Width = 79F;
            this.spdList_Sheet1.Columns.Get(62).Label = "Lot CMF 11";
            this.spdList_Sheet1.Columns.Get(62).Locked = true;
            this.spdList_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(62).Width = 80F;
            this.spdList_Sheet1.Columns.Get(63).Label = "Lot CMF 12";
            this.spdList_Sheet1.Columns.Get(63).Locked = true;
            this.spdList_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(63).Width = 80F;
            this.spdList_Sheet1.Columns.Get(64).Label = "Lot CMF 13";
            this.spdList_Sheet1.Columns.Get(64).Locked = true;
            this.spdList_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(64).Width = 80F;
            this.spdList_Sheet1.Columns.Get(65).Label = "Lot CMF 14";
            this.spdList_Sheet1.Columns.Get(65).Locked = true;
            this.spdList_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(65).Width = 80F;
            this.spdList_Sheet1.Columns.Get(66).Label = "Lot CMF 15";
            this.spdList_Sheet1.Columns.Get(66).Locked = true;
            this.spdList_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(66).Width = 80F;
            this.spdList_Sheet1.Columns.Get(67).Label = "Lot CMF 16";
            this.spdList_Sheet1.Columns.Get(67).Locked = true;
            this.spdList_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(67).Width = 80F;
            this.spdList_Sheet1.Columns.Get(68).Label = "Lot CMF 17";
            this.spdList_Sheet1.Columns.Get(68).Locked = true;
            this.spdList_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(68).Width = 80F;
            this.spdList_Sheet1.Columns.Get(69).Label = "Lot CMF 18";
            this.spdList_Sheet1.Columns.Get(69).Locked = true;
            this.spdList_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(69).Width = 80F;
            this.spdList_Sheet1.Columns.Get(70).Label = "Lot CMF 19";
            this.spdList_Sheet1.Columns.Get(70).Locked = true;
            this.spdList_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(70).Width = 80F;
            this.spdList_Sheet1.Columns.Get(71).Label = "Lot Cmf 20";
            this.spdList_Sheet1.Columns.Get(71).Locked = true;
            this.spdList_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(71).Width = 80F;
            this.spdList_Sheet1.Columns.Get(74).Label = "Cell Grade";
            this.spdList_Sheet1.Columns.Get(74).Width = 104F;
            this.spdList_Sheet1.Columns.Get(75).Label = "Cell Judge";
            this.spdList_Sheet1.Columns.Get(75).Width = 105F;
            this.spdList_Sheet1.Columns.Get(77).Label = "Lot Delete Flag";
            this.spdList_Sheet1.Columns.Get(77).Locked = true;
            this.spdList_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(77).Width = 101F;
            this.spdList_Sheet1.Columns.Get(78).Label = "Lot Delete Reason";
            this.spdList_Sheet1.Columns.Get(78).Locked = true;
            this.spdList_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(78).Width = 119F;
            this.spdList_Sheet1.Columns.Get(79).Label = "Lot Delete Time";
            this.spdList_Sheet1.Columns.Get(79).Locked = true;
            this.spdList_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(79).Width = 129F;
            this.spdList_Sheet1.Columns.Get(80).Label = "Last Tran Code";
            this.spdList_Sheet1.Columns.Get(80).Locked = true;
            this.spdList_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(80).Width = 104F;
            this.spdList_Sheet1.Columns.Get(81).Label = "Last Tran Time";
            this.spdList_Sheet1.Columns.Get(81).Locked = true;
            this.spdList_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(81).Width = 128F;
            this.spdList_Sheet1.Columns.Get(82).Label = "Last Comment";
            this.spdList_Sheet1.Columns.Get(82).Locked = true;
            this.spdList_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(82).Width = 220F;
            numberCellType8.DecimalPlaces = 0;
            numberCellType8.MaximumValue = 9999D;
            numberCellType8.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(83).CellType = numberCellType8;
            this.spdList_Sheet1.Columns.Get(83).Label = "Last Active Hist Seq";
            this.spdList_Sheet1.Columns.Get(83).Locked = true;
            this.spdList_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(83).Width = 130F;
            numberCellType9.DecimalPlaces = 0;
            numberCellType9.MaximumValue = 9999D;
            numberCellType9.MinimumValue = 0D;
            this.spdList_Sheet1.Columns.Get(84).CellType = numberCellType9;
            this.spdList_Sheet1.Columns.Get(84).Label = "Last Hist Seq";
            this.spdList_Sheet1.Columns.Get(84).Locked = true;
            this.spdList_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(84).Width = 91F;
            this.spdList_Sheet1.FrozenColumnCount = 2;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.RowHeader.Visible = false;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPViewSubLotList
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewSubLotList";
            this.Text = "View Sublot List";
            this.Activated += new System.EventHandler(this.frmWIPViewSubLotList_Activated);
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
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        private string[] sGroupTableName = new string[10];
        
        #endregion
        
        #region " Function Definition "


        private bool View_Lot(char c_step, string sLot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_LOT_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;

            in_node.AddString("LOT_ID", MPCF.Trim(sLot_id));

            if (MPCR.CallService("WIP", "WIP_View_Lot", in_node, ref out_node) == false)
            {
                return false;
            }

            txtDesc.Text = out_node.GetString("LOT_DESC");

            return true;
        }



        // View_SubLot_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_SubLot_List()
        {
            TRSNode in_node = new TRSNode("VIEW_SUBLOT_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_LIST_OUT");
            int i;

            int iRow;
            int iCol;
            FarPoint.Win.Spread.SheetView sheet = new FarPoint.Win.Spread.SheetView();

            MPCF.ClearList(spdList, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));

            do
            {
                if (MPCR.CallService("WIP", "WIP_View_Sublot_List_Detail", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {

                    sheet = spdList.Sheets[0];
                    iRow = sheet.RowCount;
                    sheet.RowCount++;

                    iCol = 0;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("SLOT_NO");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("MAT_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("MAT_VER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("FLOW_SEQ_NUM");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CRR_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("OWNER_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CREATE_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_STATUS");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("HOLD_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("HOLD_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("CREATE_QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_2"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0.###", out_node.GetList(0)[i].GetDouble("OPER_IN_QTY_3"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("INV_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("TRANSIT_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("UNIT_EXIST_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("INV_UNIT");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("RWK_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("RWK_COUNT"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_END_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RWK_END_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("RWK_RET_CLEAR_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("RWK_TIME"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("NSTD_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("NSTD_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("NSTD_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("NSTD_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("REP_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("REP_RET_OPER");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("STR_RET_FLOW");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("STR_RET_FLOW_SEQ_NUM");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("STR_RET_OPER");
                    
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("START_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("START_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("START_RES_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("END_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("END_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("END_RES_ID");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SAMPLE_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SAMPLE_WAIT_FLAG");

                    iCol++;
                    switch (out_node.GetList(0)[i].GetChar("SAMPLE_RESULT"))
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
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RESERVE_RES_ID");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_LOCATION");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_1");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_2");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_3");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_4");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_5");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_6");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_7");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_8");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_9");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_10");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_11");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_12");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_13");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_14");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_15");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_16");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_17");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_18");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_19");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_CMF_20");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("GRADE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("GRADE_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CELL_GRADE");

                    //Add by J.S. 2009.02.18 for Add CELL_JUDGE
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CELL_JUDGE");
                    
                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("LOT_BASE");

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("SUBLOT_DEL_FLAG");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUBLOT_DEL_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("SUBLOT_DEL_TIME"));

                    iCol++;

                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LAST_TRAN_CODE");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("LAST_TRAN_TIME"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LAST_COMMENT");

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_ACTIVE_HIST_SEQ"));

                    iCol++;
                    sheet.Cells[iRow, iCol].Value = MPCF.Format("########,##0", out_node.GetList(0)[i].GetInt("LAST_HIST_SEQ"));

                    iCol++;

                    if (out_node.GetList(0)[i].GetChar("SUBLOT_DEL_FLAG") == 'Y')
                    {
                        sheet.Rows[iRow].ForeColor = Color.Magenta;
                    }

                }

                in_node.SetInt("NEXT_CRR_SEQ", out_node.GetInt("NEXT_CRR_SEQ"));
                in_node.SetInt("NEXT_SLOT_NO", out_node.GetInt("NEXT_SLOT_NO"));
            } while (in_node.GetInt("NEXT_CRR_SEQ") > 0 || in_node.GetInt("NEXT_SLOT_NO") > 0);

            MPCF.FitColumnHeader(spdList);
            return true;
        }

        
        
        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                btnView_Click(btnView, null);
            }
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtLotID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion

        private void frmWIPViewSubLotList_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);

                ActiveFormNow();
                
                b_load_flag = true;
            }
        }
        
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {

            if (MPCF.CheckValue(txtLotID, 1) == false)
            {
                return;
            }
            
            //Add by J.S. 2009.02.18 for 설명 보여 주기 위해 추가
            if (View_Lot('2', txtLotID.Text) == false)
            {
                return;
            }

            View_SubLot_List();
            this.Text = MPCF.FindLanguage("Sub Lot List", 0) + " (" + txtLotID.Text + ")";
            this.lblFormTitle.Text = this.Text;
            
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Lot ID : " + MPCF.Trim(txtLotID.Text);

            if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
            
        }
    }
    
}
