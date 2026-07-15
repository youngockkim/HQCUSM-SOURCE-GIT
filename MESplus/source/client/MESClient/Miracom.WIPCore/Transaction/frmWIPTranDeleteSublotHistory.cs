
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPTranDeleteSublotHistory.vb
//   Description : Delete Lot History Transaction
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_Lot() : View Lot Information
//       - View_Sublot_History() : View Lot History
//       - Delete_Sublot_History() : Delete Lot History
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-24 : Created by CM Koo
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
    public class frmWIPTranDeleteSublotHistory : Miracom.MESCore.TranForm06
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPTranDeleteSublotHistory()
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
        



        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            this.lblTo = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlTranInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.spdHistory);
            this.pnlTranInfo.Size = new System.Drawing.Size(736, 410);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 413);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Location = new System.Drawing.Point(15, 16);
            this.lblLotID.Size = new System.Drawing.Size(68, 13);
            this.lblLotID.Text = "Sub Lot ID";
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Location = new System.Drawing.Point(15, 40);
            this.lblLotDesc.Size = new System.Drawing.Size(36, 13);
            this.lblLotDesc.Text = "Lot ID";
            // 
            // txtLotID
            // 
            this.txtLotID.MaxLength = 30;
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
            this.txtLotDesc.Size = new System.Drawing.Size(594, 20);
            this.txtLotDesc.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 451);
            // 
            // grpTranTop
            // 
            this.grpTranTop.Controls.Add(this.lblTo);
            this.grpTranTop.Controls.Add(this.lblPeriod);
            this.grpTranTop.Controls.Add(this.dtpTo);
            this.grpTranTop.Controls.Add(this.dtpFrom);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.dtpFrom, 0);
            this.grpTranTop.Controls.SetChildIndex(this.dtpTo, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblPeriod, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblTo, 0);
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Delete Lot History";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(606, 16);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "~";
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(448, 16);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(37, 13);
            this.lblPeriod.TabIndex = 4;
            this.lblPeriod.Text = "Period";
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(624, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 7;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(512, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 5;
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
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(736, 410);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 5;
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
            // frmWIPTranDeleteSublotHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPTranDeleteSublotHistory";
            this.Text = "Delete Sublot History";
            this.Activated += new System.EventHandler(this.frmWIPTranDeleteSublotHistory_Activated);
            this.pnlTranInfo.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpTranTop.ResumeLayout(false);
            this.grpTranTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
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
        // View_Lot()
        //       -  View Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool View_Sublot_Info(char c_step, string sLot_id)
        {
            TRSNode in_node = new TRSNode("VIEW_SUBLOT_IN");
            TRSNode out_node = new TRSNode("VIEW_SUBLOT_OUT");

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = c_step;
            in_node.AddString("SUBLOT_ID", MPCF.Trim(sLot_id));

            if (MPCR.CallService("WIP", "WIP_View_Sublot", in_node, ref out_node) == false)
            {
                return false;
            }

            txtLotDesc.Text = out_node.GetString("LOT_ID");

            return true;

        }

        
        // View_Sublot_History()
        //       -   View Sublot History
        // Return Value
        //       -
        // Arguments
        //       -
        private void View_Sublot_History()
        {
            
            string sFromTime;
            string sToTime;
            
            if (txtLotID.Text != "")
            {
                sFromTime = MPCF.FromDate(dtpFrom);
                sToTime = MPCF.ToDate(dtpTo);

                if (WIPLIST.ViewSublotHistory(spdHistory, '1', txtLotID.Text, sFromTime, sToTime, ' ', null, false, "") == false)
                {
                    return;
                }
                
                MPCF.FitColumnHeader(spdHistory);
                
            }
            
        }
        
        // Delete_Sublot_History()
        //       -   Delete Lot History
        // Return Value
        //       -
        // Arguments
        //       -
        private bool Delete_Sublot_History()
        {
            TRSNode in_node = new TRSNode("DELETE_SUBLOT_HISTORY_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SUBLOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddInt("LAST_ACTIVE_HIST_SEQ", MPCF.ToInt(spdHistory.Sheets[0].Cells[0, 0].Value));

                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("WIP", "WIP_Delete_Sublot_History", in_node, ref out_node) == false)
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


        
        #endregion
        
        private void frmWIPTranDeleteSublotHistory_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {

                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory, true);
                MPCR.SetSubLotCmfPrompt(spdHistory, 65);
                MPCF.FitColumnHeader(spdHistory);
                
                
                dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                dtpTo.Value = DateTime.Today;
                
                if (txtLotID.Text != "")
                {
                    View_Sublot_History();
                }
                
                b_load_flag = true;
            }
            
            
        }
        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                MPCF.ClearList(spdHistory, true);
                if (View_Sublot_Info('2', txtLotID.Text) == false)
                {
                    return;
                }
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }
                View_Sublot_History();
            }
        }
        private void txtLotID_TextChanged(object sender, System.EventArgs e)
        {
            if (txtLotID.Text == "")
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory, true);
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            if (spdHistory.Sheets[0].RowCount < 1)
            {
                return;
            }
            
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            
            if (Delete_Sublot_History() == true)
            {
                txtComment.Text = "";
                View_Sublot_History();
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ClearList(spdHistory, true);
            if (View_Sublot_Info('2', txtLotID.Text) == false)
            {
                return;
            }
            View_Sublot_History();
            
        }
        
    }
    
}
