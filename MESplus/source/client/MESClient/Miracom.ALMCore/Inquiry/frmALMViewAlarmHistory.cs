
using System.Data;
using System.Collections;

using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Drawing;
using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;

//#If _ALM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmALMViewAlarmHistory.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Alarm_History_List : View Lot Alarm History List
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2005-07-27 : Created by HS Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.ALMCore
{
    public class frmALMViewAlarmHistory : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmALMViewAlarmHistory()
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
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.TextBox txtSourceID1;
        private System.Windows.Forms.Label lblSourceID1;
        private TextBox txtLotID;
        private Label lblLotID;
        private Label lblAlarmClearType;
        private ComboBox cboAlarmClearType;
        private TextBox txtAlarmID;
        private Label lblAlarmID;
        private Label lblAlarmType;
        private ComboBox cboAlarmType;
        private TextBox txtResID;
        private Label lblResID;
        private System.Windows.Forms.Label lblTo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.txtSourceID1 = new System.Windows.Forms.TextBox();
            this.lblSourceID1 = new System.Windows.Forms.Label();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.cboAlarmClearType = new System.Windows.Forms.ComboBox();
            this.lblAlarmClearType = new System.Windows.Forms.Label();
            this.txtResID = new System.Windows.Forms.TextBox();
            this.lblResID = new System.Windows.Forms.Label();
            this.lblAlarmType = new System.Windows.Forms.Label();
            this.cboAlarmType = new System.Windows.Forms.ComboBox();
            this.txtAlarmID = new System.Windows.Forms.TextBox();
            this.lblAlarmID = new System.Windows.Forms.Label();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 118);
            this.pnlViewTop.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtAlarmID);
            this.grpOption.Controls.Add(this.lblAlarmID);
            this.grpOption.Controls.Add(this.lblAlarmType);
            this.grpOption.Controls.Add(this.cboAlarmType);
            this.grpOption.Controls.Add(this.txtResID);
            this.grpOption.Controls.Add(this.lblResID);
            this.grpOption.Controls.Add(this.lblAlarmClearType);
            this.grpOption.Controls.Add(this.cboAlarmClearType);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Controls.Add(this.txtSourceID1);
            this.grpOption.Controls.Add(this.lblSourceID1);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(742, 118);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 118);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 395);
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
            this.lblFormTitle.Text = "View Lot Alarm History";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Location = new System.Drawing.Point(475, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 8;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(153, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(60, 0);
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
            // txtSourceID1
            // 
            this.txtSourceID1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSourceID1.Location = new System.Drawing.Point(119, 16);
            this.txtSourceID1.MaxLength = 30;
            this.txtSourceID1.Name = "txtSourceID1";
            this.txtSourceID1.Size = new System.Drawing.Size(200, 20);
            this.txtSourceID1.TabIndex = 1;
            // 
            // lblSourceID1
            // 
            this.lblSourceID1.AutoSize = true;
            this.lblSourceID1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSourceID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceID1.Location = new System.Drawing.Point(15, 20);
            this.lblSourceID1.Name = "lblSourceID1";
            this.lblSourceID1.Size = new System.Drawing.Size(64, 13);
            this.lblSourceID1.TabIndex = 0;
            this.lblSourceID1.Text = "Source ID 1";
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
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 392);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
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
            spdList_Sheet1.ColumnCount = 28;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Alarm ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Alarm Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Resource";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Res Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Lot Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Alarm Level";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Alarm Subject";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Alarm Message";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Comments";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "PDF File Name";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Image File Name";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Area";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Sub Area";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Ack Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Ack Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Ack User";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Clear Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Clear Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Clear User";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Clear Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Source ID 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Source Desc 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Source ID 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Source Desc 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Source ID 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Source Desc 3";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdList_Sheet1.Columns.Get(0).Label = "Alarm ID";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 101F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 103F;
            this.spdList_Sheet1.Columns.Get(2).Label = "Alarm Type";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 70F;
            this.spdList_Sheet1.Columns.Get(3).Label = "Resource";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 82F;
            this.spdList_Sheet1.Columns.Get(4).Label = "Res Hist Seq";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 72F;
            this.spdList_Sheet1.Columns.Get(5).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 73F;
            this.spdList_Sheet1.Columns.Get(6).Label = "Lot Hist Seq";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 72F;
            this.spdList_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Label = "Alarm Level";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 73F;
            this.spdList_Sheet1.Columns.Get(8).Label = "Alarm Subject";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 150F;
            this.spdList_Sheet1.Columns.Get(9).Label = "Alarm Message";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 200F;
            this.spdList_Sheet1.Columns.Get(10).Label = "Comments";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 200F;
            this.spdList_Sheet1.Columns.Get(11).Label = "PDF File Name";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Visible = false;
            this.spdList_Sheet1.Columns.Get(11).Width = 120F;
            this.spdList_Sheet1.Columns.Get(12).Label = "Image File Name";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 120F;
            this.spdList_Sheet1.Columns.Get(13).Label = "Area";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Label = "Sub Area";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Label = "Ack Flag";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Label = "Ack Time";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Label = "Ack User";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Label = "Clear Flag";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Label = "Clear Time";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 82F;
            this.spdList_Sheet1.Columns.Get(20).Label = "Clear User";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Label = "Clear Comment";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 122F;
            this.spdList_Sheet1.Columns.Get(22).Label = "Source ID 1";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 73F;
            this.spdList_Sheet1.Columns.Get(23).Label = "Source Desc 1";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 93F;
            this.spdList_Sheet1.Columns.Get(24).Label = "Source ID 2";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 73F;
            this.spdList_Sheet1.Columns.Get(25).Label = "Source Desc 2";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 93F;
            this.spdList_Sheet1.Columns.Get(26).Label = "Source ID 3";
            this.spdList_Sheet1.Columns.Get(26).Locked = true;
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 73F;
            this.spdList_Sheet1.Columns.Get(27).Label = "Source Desc 3";
            this.spdList_Sheet1.Columns.Get(27).Locked = true;
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 93F;
            this.spdList_Sheet1.FrozenColumnCount = 2;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(119, 40);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 3;
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 44);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(36, 13);
            this.lblLotID.TabIndex = 2;
            this.lblLotID.Text = "Lot ID";
            // 
            // cboAlarmClearType
            // 
            this.cboAlarmClearType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlarmClearType.DropDownWidth = 200;
            this.cboAlarmClearType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboAlarmClearType.FormattingEnabled = true;
            this.cboAlarmClearType.Items.AddRange(new object[] {
            "",
            "Y : Only for cleared alarm history",
            "N : Only for no clear alarm history"});
            this.cboAlarmClearType.Location = new System.Drawing.Point(581, 40);
            this.cboAlarmClearType.Name = "cboAlarmClearType";
            this.cboAlarmClearType.Size = new System.Drawing.Size(151, 21);
            this.cboAlarmClearType.TabIndex = 10;
            // 
            // lblAlarmClearType
            // 
            this.lblAlarmClearType.AutoSize = true;
            this.lblAlarmClearType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmClearType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmClearType.Location = new System.Drawing.Point(475, 44);
            this.lblAlarmClearType.Name = "lblAlarmClearType";
            this.lblAlarmClearType.Size = new System.Drawing.Size(87, 13);
            this.lblAlarmClearType.TabIndex = 9;
            this.lblAlarmClearType.Text = "Alarm Clear Type";
            // 
            // txtResID
            // 
            this.txtResID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtResID.Location = new System.Drawing.Point(119, 64);
            this.txtResID.MaxLength = 20;
            this.txtResID.Name = "txtResID";
            this.txtResID.Size = new System.Drawing.Size(200, 20);
            this.txtResID.TabIndex = 5;
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 68);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(40, 13);
            this.lblResID.TabIndex = 4;
            this.lblResID.Text = "Res ID";
            // 
            // lblAlarmType
            // 
            this.lblAlarmType.AutoSize = true;
            this.lblAlarmType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmType.Location = new System.Drawing.Point(475, 68);
            this.lblAlarmType.Name = "lblAlarmType";
            this.lblAlarmType.Size = new System.Drawing.Size(60, 13);
            this.lblAlarmType.TabIndex = 11;
            this.lblAlarmType.Text = "Alarm Type";
            // 
            // cboAlarmType
            // 
            this.cboAlarmType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlarmType.DropDownWidth = 200;
            this.cboAlarmType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboAlarmType.FormattingEnabled = true;
            this.cboAlarmType.Items.AddRange(new object[] {
            "",
            "N : Normal alarm",
            "R : Resource alarm",
            "A : Auto gathered alarm by resource"});
            this.cboAlarmType.Location = new System.Drawing.Point(581, 64);
            this.cboAlarmType.Name = "cboAlarmType";
            this.cboAlarmType.Size = new System.Drawing.Size(151, 21);
            this.cboAlarmType.TabIndex = 12;
            // 
            // txtAlarmID
            // 
            this.txtAlarmID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtAlarmID.Location = new System.Drawing.Point(119, 88);
            this.txtAlarmID.MaxLength = 20;
            this.txtAlarmID.Name = "txtAlarmID";
            this.txtAlarmID.Size = new System.Drawing.Size(200, 20);
            this.txtAlarmID.TabIndex = 7;
            // 
            // lblAlarmID
            // 
            this.lblAlarmID.AutoSize = true;
            this.lblAlarmID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAlarmID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmID.Location = new System.Drawing.Point(15, 92);
            this.lblAlarmID.Name = "lblAlarmID";
            this.lblAlarmID.Size = new System.Drawing.Size(47, 13);
            this.lblAlarmID.TabIndex = 6;
            this.lblAlarmID.Text = "Alarm ID";
            // 
            // frmALMViewAlarmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmALMViewAlarmHistory";
            this.Text = "View Alarm History";
            this.Activated += new System.EventHandler(this.frmALMViewAlarmHistory_Activated);
            this.Load += new System.EventHandler(this.frmALMViewAlarmHistory_Load);
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
        
        //
        // View_Alarm_History_List
        //       - View Lot Alarm History List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool View_Alarm_History_List()
        {
            TRSNode in_node = new TRSNode("VIEW_ALARM_HISTORY_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_ALARM_HISTORY_LIST_OUT");

            int i;
            int iRow;
            int iCol;
            string sAlarmLevel;
            string sAlarmType;
            string sComment;
            
            MPCF.ClearList(spdList, true);
            
            if (txtSourceID1.Text != "")
            {
                in_node.ProcStep = '1';
            }
            else
            {
                in_node.ProcStep = '2';
            }

            MPCR.SetInMsg(in_node);
            in_node.AddString("SOURCE_ID_1", MPCF.Trim(txtSourceID1.Text));
            in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
            in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
            in_node.AddString("RES_ID", MPCF.Trim(txtResID.Text));
            in_node.AddString("ALARM_ID", MPCF.Trim(txtAlarmID.Text));
            in_node.AddChar("CLEAR_FLAG", MPCF.ToChar(cboAlarmClearType.Text));
            in_node.AddChar("ALARM_TYPE", MPCF.ToChar(cboAlarmType.Text));
            
            do
            {
                if (MPCR.CallService("ALM", "ALM_View_Alarm_History_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {                    
                    FarPoint.Win.Spread.SheetView with_1 = spdList.Sheets[0];
                    iRow = with_1.RowCount;
                    with_1.RowCount++;
                    
                    iCol = 0;
                    
                    if (out_node.GetList(0)[i].GetChar("CLEAR_FLAG") == 'Y')
                    {
                        with_1.Cells[iRow, iCol, iRow, with_1.ColumnCount - 1].ForeColor = Color.Magenta;
                    }
                    else
                    {
                        with_1.Cells[iRow, iCol, iRow, with_1.ColumnCount - 1].ForeColor = Color.Black;
                    }

                    if (out_node.GetList(0)[i].GetChar("ALARM_LEVEL_FLAG") == MPGC.MP_ALM_LEVEL_ERROR)
                    {
                        sAlarmLevel = "Error";
                    }
                    else if (out_node.GetList(0)[i].GetChar("ALARM_LEVEL_FLAG") == MPGC.MP_ALM_LEVEL_WARN)
                    {
                        sAlarmLevel = "Warning";
                    }
                    else
                    {
                        sAlarmLevel = "Info";
                    }

                    if (out_node.GetList(0)[i].GetChar("ALARM_TYPE") == MPGC.MP_ALM_NORMAL)
                    {
                        sAlarmType = "Normal";
                    }
                    else
                    {
                        sAlarmType = "Resource";
                    }

                    sComment = "";
                    if (out_node.GetList(0)[i].GetString("ALARM_COMMENT_1") != "")
                    {
                        sComment += out_node.GetList(0)[i].GetString("ALARM_COMMENT_1");
                    }
                    if (out_node.GetList(0)[i].GetString("ALARM_COMMENT_2") != "")
                    {
                        if (sComment.Length > 0)
                        {
                            sComment += "\n";
                        }
                        sComment += out_node.GetList(0)[i].GetString("ALARM_COMMENT_2");
                    }
                    if (out_node.GetList(0)[i].GetString("ALARM_COMMENT_3") != "")
                    {
                        if (sComment.Length > 0)
                        {
                            sComment += "\n";
                        }
                        sComment += out_node.GetList(0)[i].GetString("ALARM_COMMENT_3");
                    }
                    if (out_node.GetList(0)[i].GetString("ALARM_COMMENT_4") != "")
                    {
                        if (sComment.Length > 0)
                        {
                            sComment += "\n";
                        }
                        sComment += out_node.GetList(0)[i].GetString("ALARM_COMMENT_4");
                    }
                    if (out_node.GetList(0)[i].GetString("ALARM_COMMENT_5") != "")
                    {
                        if (sComment.Length > 0)
                        {
                            sComment += "\n";
                        }
                        sComment += out_node.GetList(0)[i].GetString("ALARM_COMMENT_5");
                    }

                    
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ALARM_ID");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("TRAN_TIME"));

                    iCol++;
                    with_1.Cells[iRow, iCol].Value = sAlarmType;
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("RES_ID");

                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("RES_HIST_SEQ");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("LOT_ID");

                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetInt("LOT_HIST_SEQ");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = sAlarmLevel;

                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ALARM_SUBJECT");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ALARM_MSG");

                    iCol++;
                    with_1.Cells[iRow, iCol].Value = sComment;

                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("PDF_FILE_NAME");

                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("IMAGE_FILE_NAME");

                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("AREA_ID");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SUB_AREA_ID");
                    
                    iCol++;
                    
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("ACK_FLAG");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("ACK_TIME"));
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("ACK_USER_ID");
                    
                    iCol++;
                    
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetChar("CLEAR_FLAG");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CLEAR_TIME"));
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CLEAR_USER_ID");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("CLEAR_COMMENT");
                    
                    iCol++;
                    
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SOURCE_ID_1");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SOURCE_DESC_1");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SOURCE_ID_2");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SOURCE_DESC_2");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SOURCE_ID_3");
                    
                    iCol++;
                    with_1.Cells[iRow, iCol].Value = out_node.GetList(0)[i].GetString("SOURCE_DESC_3");
                    
                    iCol++;

                    with_1.Rows[iRow].Height = with_1.GetPreferredRowHeight(iRow);
                }

                in_node.SetString("NEXT_SOURCE_ID_1", out_node.GetString("NEXT_SOURCE_ID_1"));
                in_node.SetString("NEXT_TO_TIME", out_node.GetString("NEXT_TO_TIME"));

            } while (in_node.GetString("NEXT_TO_TIME") != "" || in_node.GetString("NEXT_SOURCE_ID_1") != "");
            
            MPCF.FitColumnHeader(spdList);
            return true;
        }
        
        public virtual Control GetFisrtFocusItem()
        {            
            try
            {
                return this.txtSourceID1;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }            
        }
        
        #endregion
        
        private void frmALMViewAlarmHistory_Load(object sender, System.EventArgs e)
        {            
            dtpFrom.Value = dtpTo.Value.AddDays(- 7);            
        }
        
        private void frmALMViewAlarmHistory_Activated(object sender, System.EventArgs e)
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
            
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            View_Alarm_History_List();            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
             
            sCond = "Lot ID : " + MPCF.Trim(txtSourceID1.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            MPCF.ExportToExcel(spdList, this.Text, sCond);            
        }
        
    }
    //#End If
}
