

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWipViewSubLotHistory.vb
//   Description : MES Cient Form View Sub Lot History Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-16 : Created by CM Koo
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
    public class frmWIPViewSubLotHistory : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewSubLotHistory()
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
        



        private System.Windows.Forms.CheckBox chkIncludeDelHistory;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtSubLotID;
        private System.Windows.Forms.Label lblSubLotID;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.txtSubLotID = new System.Windows.Forms.TextBox();
            this.lblSubLotID = new System.Windows.Forms.Label();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 68);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.txtSubLotID);
            this.grpOption.Controls.Add(this.lblSubLotID);
            this.grpOption.Controls.Add(this.chkIncludeDelHistory);
            this.grpOption.Size = new System.Drawing.Size(742, 68);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdHistory);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 68);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 445);
            this.pnlViewMid.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Sub Lot History";
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.AutoSize = true;
            this.chkIncludeDelHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(120, 43);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(136, 18);
            this.chkIncludeDelHistory.TabIndex = 6;
            this.chkIncludeDelHistory.Text = "Include Delete History";
            // 
            // txtSubLotID
            // 
            this.txtSubLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSubLotID.Location = new System.Drawing.Point(120, 16);
            this.txtSubLotID.MaxLength = 30;
            this.txtSubLotID.Name = "txtSubLotID";
            this.txtSubLotID.Size = new System.Drawing.Size(200, 20);
            this.txtSubLotID.TabIndex = 1;
            // 
            // lblSubLotID
            // 
            this.lblSubLotID.AutoSize = true;
            this.lblSubLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubLotID.Location = new System.Drawing.Point(15, 19);
            this.lblSubLotID.Name = "lblSubLotID";
            this.lblSubLotID.Size = new System.Drawing.Size(68, 13);
            this.lblSubLotID.TabIndex = 0;
            this.lblSubLotID.Text = "Sub Lot ID";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(475, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 25;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 27;
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.Location = new System.Drawing.Point(0, 3);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 26;
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
            this.dtpTo.TabIndex = 29;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(12, 9);
            this.lblTo.TabIndex = 28;
            this.lblTo.Text = "~";
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1, Row 0, Column 0, ";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdHistory.HorizontalScrollBar.TabIndex = 4;
            this.spdHistory.Location = new System.Drawing.Point(0, 3);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(742, 442);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 4;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistory.VerticalScrollBar.TabIndex = 5;
            this.spdHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdHistory.SetActiveViewport(0, 0, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 135;
            spdHistory_Sheet1.RowCount = 5;
            spdHistory_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Oper Desc";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Slot No.";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Crr ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Owner Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Create Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Sub Lot Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Sub Lot Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Sys Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Hold Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Hold Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Oper In Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Oper In Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Create Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Create Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Inventory Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Transit Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Tracking Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Inventory Unit";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Hold Prv Group ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Rework Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Rework Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Rework Count";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Rework Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Rework Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Rework Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Rework End Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Rework End Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Rework End Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Rework Return Clear Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Rework Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "NSTD Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "NSTD Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "NSTD Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "NSTD Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "NSTD Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Rep Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Rep Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Store Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Store Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Store Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Start Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Start Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Start Resource ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Start Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Start Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "End Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "End Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "End Resource ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Sample Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Sample Wait Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Sample Result";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Reserve Res ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Sub Lot Location";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Sub Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "Sub Lot Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "Sub Lot Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "Sub Lot Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "Sub Lot Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "Sub Lot Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "Sub Lot Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "Sub Lot Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "Sub Lot Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "Sub Lot Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "Sub Lot Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "Sub Lot Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Sub Lot Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Sub Lot Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 79).Value = "Sub Lot Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 80).Value = "Sub Lot Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 81).Value = "Sub Lot Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 82).Value = "Sub Lot Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 83).Value = "Sub Lot Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 84).Value = "Sub Lot Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 85).Value = "Sub Lot Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 86).Value = "Sub Lot Del Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 87).Value = "Sub Lot Del Reason";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 88).Value = "Sub Lot Del Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 89).Value = "Grade";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 90).Value = "Grade Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 91).Value = "Cell Grade";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 92).Value = "Lot Base";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 93).Value = "Lot Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 94).Value = "Old Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 95).Value = "Old Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 96).Value = "OLD Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 97).Value = "Old Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 98).Value = "OLD Flow Seq Num";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 99).Value = "Old Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 100).Value = "Old Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 101).Value = "Old Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 102).Value = "Old Crr ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 103).Value = "Old Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 104).Value = "Old Owner Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 105).Value = "Old Create Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 106).Value = "Trans Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 107).Value = "Trans Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 108).Value = "Trans Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 109).Value = "Trans Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 110).Value = "Trans Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 111).Value = "Trans Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 112).Value = "Trans Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 113).Value = "Trans Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 114).Value = "Trans Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 115).Value = "Trans Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 116).Value = "Trans Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 117).Value = "Trans Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 118).Value = "Trans Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 119).Value = "Trans Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 120).Value = "Trans Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 121).Value = "Trans Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 122).Value = "Trans Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 123).Value = "Trans Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 124).Value = "Trans Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 125).Value = "Trans Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 126).Value = "Tran User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 127).Value = "Tran Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 128).Value = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 129).Value = "Multi Tran Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 130).Value = "Multi Tran Key";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 131).Value = "Hist Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 132).Value = "Hist Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 133).Value = "Hist Delete User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 134).Value = "Hist Delete Comment";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 31F;
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.spdHistory_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 44F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Tran Code";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 74F;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Lot ID";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 81F;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Factory";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Mat ID";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 122F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Flow";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Oper";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Oper Desc";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Slot No.";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Qty 2";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Qty 3";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Crr ID";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Owner Code";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 82F;
            this.spdHistory_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Create Code";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Sub Lot Status";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 67F;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Sub Lot Type";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 48F;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Sys Tran Time";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Hold Flag";
            this.spdHistory_Sheet1.Columns.Get(20).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 62F;
            this.spdHistory_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Hold Code";
            this.spdHistory_Sheet1.Columns.Get(21).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 69F;
            this.spdHistory_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Oper In Qty 2";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 59F;
            this.spdHistory_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Oper In Qty 3";
            this.spdHistory_Sheet1.Columns.Get(23).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 63F;
            this.spdHistory_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Create Qty 2";
            this.spdHistory_Sheet1.Columns.Get(24).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Create Qty 3";
            this.spdHistory_Sheet1.Columns.Get(25).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Inventory Flag";
            this.spdHistory_Sheet1.Columns.Get(26).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 69F;
            this.spdHistory_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Transit Flag";
            this.spdHistory_Sheet1.Columns.Get(27).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Tracking Flag";
            this.spdHistory_Sheet1.Columns.Get(28).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Inventory Unit";
            this.spdHistory_Sheet1.Columns.Get(29).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Hold Prv Group ID";
            this.spdHistory_Sheet1.Columns.Get(30).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Rework Flag";
            this.spdHistory_Sheet1.Columns.Get(31).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Rework Code";
            this.spdHistory_Sheet1.Columns.Get(32).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Rework Count";
            this.spdHistory_Sheet1.Columns.Get(33).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Rework Return Flow";
            this.spdHistory_Sheet1.Columns.Get(34).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Rework Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(35).Width = 130F;
            this.spdHistory_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Rework Return Oper";
            this.spdHistory_Sheet1.Columns.Get(36).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Width = 134F;
            this.spdHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "Rework End Flow";
            this.spdHistory_Sheet1.Columns.Get(37).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Rework End Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(38).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 130F;
            this.spdHistory_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Rework End Oper";
            this.spdHistory_Sheet1.Columns.Get(39).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 108F;
            this.spdHistory_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Rework Return Clear Flag";
            this.spdHistory_Sheet1.Columns.Get(40).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 160F;
            this.spdHistory_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Rework Time";
            this.spdHistory_Sheet1.Columns.Get(41).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "NSTD Flag";
            this.spdHistory_Sheet1.Columns.Get(42).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 68F;
            this.spdHistory_Sheet1.Columns.Get(43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(43).Label = "NSTD Return Flow";
            this.spdHistory_Sheet1.Columns.Get(43).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(43).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(44).Label = "NSTD Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(44).Width = 130F;
            this.spdHistory_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(45).Label = "NSTD Return Oper";
            this.spdHistory_Sheet1.Columns.Get(45).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(45).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(46).Label = "NSTD Time";
            this.spdHistory_Sheet1.Columns.Get(46).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(46).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(47).Label = "Rep Flag";
            this.spdHistory_Sheet1.Columns.Get(47).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(48).Label = "Rep Return Oper";
            this.spdHistory_Sheet1.Columns.Get(48).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(48).Width = 65F;
            this.spdHistory_Sheet1.Columns.Get(49).Label = "Store Return Flow";
            this.spdHistory_Sheet1.Columns.Get(49).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(49).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(50).Label = "Store Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(50).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(50).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(51).Label = "Store Return Oper";
            this.spdHistory_Sheet1.Columns.Get(51).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(51).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(52).Label = "Start Flag";
            this.spdHistory_Sheet1.Columns.Get(52).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(53).Label = "Start Time";
            this.spdHistory_Sheet1.Columns.Get(53).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(53).Width = 88F;
            this.spdHistory_Sheet1.Columns.Get(54).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(54).Label = "Start Resource ID";
            this.spdHistory_Sheet1.Columns.Get(54).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(54).Width = 76F;
            this.spdHistory_Sheet1.Columns.Get(55).Label = "Start Qty 2";
            this.spdHistory_Sheet1.Columns.Get(55).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(56).Label = "Start Qty 3";
            this.spdHistory_Sheet1.Columns.Get(56).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(57).Label = "End Flag";
            this.spdHistory_Sheet1.Columns.Get(57).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(57).Width = 67F;
            this.spdHistory_Sheet1.Columns.Get(58).Label = "End Time";
            this.spdHistory_Sheet1.Columns.Get(58).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(58).Width = 94F;
            this.spdHistory_Sheet1.Columns.Get(59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(59).Label = "End Resource ID";
            this.spdHistory_Sheet1.Columns.Get(59).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(59).Width = 76F;
            this.spdHistory_Sheet1.Columns.Get(60).Label = "Sample Flag";
            this.spdHistory_Sheet1.Columns.Get(60).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(61).Label = "Sample Wait Flag";
            this.spdHistory_Sheet1.Columns.Get(61).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(62).Label = "Sample Result";
            this.spdHistory_Sheet1.Columns.Get(62).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(63).Label = "Reserve Res ID";
            this.spdHistory_Sheet1.Columns.Get(63).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(63).Width = 69F;
            this.spdHistory_Sheet1.Columns.Get(64).Label = "Sub Lot Location";
            this.spdHistory_Sheet1.Columns.Get(64).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(64).Width = 70F;
            this.spdHistory_Sheet1.Columns.Get(65).Label = "Sub Lot ID";
            this.spdHistory_Sheet1.Columns.Get(65).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(66).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(66).Label = "Sub Lot Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(66).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(66).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(67).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(67).Label = "Sub Lot Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(67).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(67).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(68).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(68).Label = "Sub Lot Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(68).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(68).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(69).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(69).Label = "Sub Lot Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(69).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(69).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(70).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(70).Label = "Sub Lot Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(70).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(70).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(71).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(71).Label = "Sub Lot Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(71).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(71).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(72).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(72).Label = "Sub Lot Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(72).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(72).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(73).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(73).Label = "Sub Lot Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(73).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(73).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(74).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(74).Label = "Sub Lot Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(74).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(74).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(75).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(75).Label = "Sub Lot Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(75).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(75).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(76).Label = "Sub Lot Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(76).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(76).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(77).Label = "Sub Lot Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(77).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(77).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(78).Label = "Sub Lot Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(78).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(78).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(79).Label = "Sub Lot Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(79).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(79).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(80).Label = "Sub Lot Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(80).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(80).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(81).Label = "Sub Lot Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(81).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(81).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(82).Label = "Sub Lot Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(82).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(82).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(83).Label = "Sub Lot Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(83).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(83).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(84).Label = "Sub Lot Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(84).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(84).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(85).Label = "Sub Lot Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(85).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(85).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(86).Label = "Sub Lot Del Flag";
            this.spdHistory_Sheet1.Columns.Get(86).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(87).Label = "Sub Lot Del Reason";
            this.spdHistory_Sheet1.Columns.Get(87).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(87).Width = 64F;
            this.spdHistory_Sheet1.Columns.Get(88).Label = "Sub Lot Del Time";
            this.spdHistory_Sheet1.Columns.Get(88).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(89).Label = "Grade";
            this.spdHistory_Sheet1.Columns.Get(89).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(90).Label = "Grade Code";
            this.spdHistory_Sheet1.Columns.Get(90).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(90).Width = 75F;
            this.spdHistory_Sheet1.Columns.Get(91).Label = "Cell Grade";
            this.spdHistory_Sheet1.Columns.Get(91).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(91).Width = 155F;
            this.spdHistory_Sheet1.Columns.Get(92).Label = "Lot Base";
            this.spdHistory_Sheet1.Columns.Get(92).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(93).Label = "Lot Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(93).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(94).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(94).Label = "Old Factory";
            this.spdHistory_Sheet1.Columns.Get(94).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(94).Width = 95F;
            this.spdHistory_Sheet1.Columns.Get(95).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(95).Label = "Old Mat ID";
            this.spdHistory_Sheet1.Columns.Get(95).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(95).Width = 88F;
            this.spdHistory_Sheet1.Columns.Get(96).Label = "OLD Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(96).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(97).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(97).Label = "Old Flow";
            this.spdHistory_Sheet1.Columns.Get(97).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(97).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(98).Label = "OLD Flow Seq Num";
            this.spdHistory_Sheet1.Columns.Get(98).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(99).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(99).Label = "Old Oper";
            this.spdHistory_Sheet1.Columns.Get(99).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(100).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(100).Label = "Old Qty 2";
            this.spdHistory_Sheet1.Columns.Get(100).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(100).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(101).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(101).Label = "Old Qty 3";
            this.spdHistory_Sheet1.Columns.Get(101).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(101).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(102).Label = "Old Crr ID";
            this.spdHistory_Sheet1.Columns.Get(102).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(102).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(103).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(103).Label = "Old Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(103).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(103).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(103).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(104).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(104).Label = "Old Owner Code";
            this.spdHistory_Sheet1.Columns.Get(104).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(104).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(104).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(105).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(105).Label = "Old Create Code";
            this.spdHistory_Sheet1.Columns.Get(105).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(105).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(105).Width = 114F;
            this.spdHistory_Sheet1.Columns.Get(106).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(106).Label = "Trans Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(106).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(106).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(106).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(107).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(107).Label = "Trans Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(107).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(107).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(107).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(108).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(108).Label = "Trans Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(108).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(108).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(108).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(109).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(109).Label = "Trans Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(109).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(109).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(109).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(110).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(110).Label = "Trans Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(110).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(110).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(110).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(111).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(111).Label = "Trans Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(111).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(111).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(111).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(112).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(112).Label = "Trans Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(112).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(112).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(112).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(113).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(113).Label = "Trans Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(113).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(113).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(113).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(114).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(114).Label = "Trans Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(114).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(114).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(114).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(115).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(115).Label = "Trans Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(115).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(115).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(115).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(116).Label = "Trans Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(116).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(116).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(116).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(117).Label = "Trans Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(117).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(117).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(117).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(118).Label = "Trans Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(118).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(118).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(118).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(119).Label = "Trans Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(119).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(119).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(119).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(120).Label = "Trans Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(120).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(120).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(120).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(121).Label = "Trans Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(121).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(121).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(121).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(122).Label = "Trans Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(122).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(122).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(122).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(123).Label = "Trans Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(123).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(123).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(123).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(124).Label = "Trans Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(124).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(124).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(124).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(125).Label = "Trans Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(125).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(125).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(125).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(126).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(126).Label = "Tran User ID";
            this.spdHistory_Sheet1.Columns.Get(126).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(126).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(126).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(127).Label = "Tran Comment";
            this.spdHistory_Sheet1.Columns.Get(127).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(127).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(127).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(128).Label = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(128).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(128).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(128).Width = 65F;
            this.spdHistory_Sheet1.Columns.Get(129).Label = "Multi Tran Seq";
            this.spdHistory_Sheet1.Columns.Get(129).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(129).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(129).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(130).Label = "Multi Tran Key";
            this.spdHistory_Sheet1.Columns.Get(130).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(130).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(130).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(131).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(131).Label = "Hist Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(131).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(131).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(131).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(132).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(132).Label = "Hist Delete Time";
            this.spdHistory_Sheet1.Columns.Get(132).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(132).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(132).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(133).Label = "Hist Delete User ID";
            this.spdHistory_Sheet1.Columns.Get(133).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(133).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(133).Width = 106F;
            this.spdHistory_Sheet1.Columns.Get(134).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(134).Label = "Hist Delete Comment";
            this.spdHistory_Sheet1.Columns.Get(134).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(134).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(134).Width = 127F;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmWIPViewSubLotHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewSubLotHistory";
            this.Text = "View Sublot History";
            this.Activated += new System.EventHandler(this.frmWIPViewSubLotHistory_Activated);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL_ICON = 0;
        private const int COL_HIST_SEQ = 1;
        private const int COL_TRAN_TIME = 2;
        private const int COL_TRAN_CODE = 3;
        private const int COL_MAT_ID = 4;
        private const int COL_FLOW = 5;
        private const int COL_OPER = 6;
        private const int COL_QTY_1 = 7;
        private const int COL_QTY_2 = 8;
        private const int COL_QTY_3 = 9;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        //private bool bIsLeftButton;
        
        private FarPoint.Win.Spread.CellType.GeneralCellType plusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType minusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType emptyCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType checkCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        
        private FarPoint.Win.Spread.CellType.GeneralCellType increaseCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType decreaseCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        
        private enum CELL_STATUS
        {
            PLUS = 1,
            MINUS = 2,
            EMPTY = 3,
            CHECK = 4
        }
        
        #endregion
        
        #region " Function Definition "
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //
        private bool CheckCondition(string FuncName)
        {

            switch (MPCF.Trim(FuncName))
            {
                case "VIEW":
                    
                    if (dtpFrom.Value > dtpTo.Value)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(120));
                        dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                        return false;
                    }
                    break;
                    
            }
            
            return true;
            
        }
        
        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtSubLotID.Text = MPGV.gsCurrentLot_ID;
                btnView_Click(btnView, null);
            }
        }
        

        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.txtSubLotID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
                
        private void frmWIPViewSubLotHistory_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory, true);
                MPCR.SetSubLotCmfPrompt(spdHistory, 65);
                MPCF.FitColumnHeader(spdHistory);
                MPCF.ClearList(spdHistory, true);
                dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                dtpTo.Value = DateTime.Today;
                txtSubLotID.Focus();
                
                ActiveFormNow();
                
                b_load_flag = true;
            }
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            string sFromTime;
            string sToTime;
            char sIncludeDelHist;

            MPCF.ClearList(spdHistory, true);
            MPCF.ClearList(spdHistory, true);
            
            if (txtSubLotID.Text != "")
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }
                sFromTime = MPCF.FromDate(dtpFrom);
                sToTime = MPCF.ToDate(dtpTo);
                sIncludeDelHist = chkIncludeDelHistory.Checked == true ? 'Y' : ' ';

                if (WIPLIST.ViewSublotHistory(spdHistory, '2', txtSubLotID.Text, sFromTime, sToTime, sIncludeDelHist, null, false, "") == false)
                {
                    return;
                }
                
                MPCF.FitColumnHeader(spdHistory);
                
                this.Text = MPCF.FindLanguage("Sub Lot History", 0) + " (" + txtSubLotID.Text + ")";
                this.lblFormTitle.Text = this.Text;
                
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));

            if (MPCF.ExportToExcel(spdHistory, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
            
        }
        
    }
    
}
