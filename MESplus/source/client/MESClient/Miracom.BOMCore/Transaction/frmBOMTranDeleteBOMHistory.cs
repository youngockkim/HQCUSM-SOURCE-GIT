
//#If _BOM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBOMTranDeleteBOMHistory.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       -
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-19 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

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

namespace Miracom.BOMCore
{
    public class frmBOMTranDeleteBOMHistory : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmBOMTranDeleteBOMHistory()
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
        



        private System.Windows.Forms.Panel pnlMidTop;
        private System.Windows.Forms.Panel pnlMidMid;
        private System.Windows.Forms.GroupBox grpLotInfo;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            this.pnlMidTop = new System.Windows.Forms.Panel();
            this.grpLotInfo = new System.Windows.Forms.GroupBox();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.pnlMidMid = new System.Windows.Forms.Panel();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMidTop.SuspendLayout();
            this.grpLotInfo.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.pnlMidMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMidMid);
            this.pnlCenter.Controls.Add(this.pnlMidTop);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            this.pnlCenter.TabIndex = 1;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Delete BOM History";
            // 
            // pnlMidTop
            // 
            this.pnlMidTop.Controls.Add(this.grpLotInfo);
            this.pnlMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidTop.Location = new System.Drawing.Point(3, 3);
            this.pnlMidTop.Name = "pnlMidTop";
            this.pnlMidTop.Size = new System.Drawing.Size(736, 40);
            this.pnlMidTop.TabIndex = 0;
            // 
            // grpLotInfo
            // 
            this.grpLotInfo.Controls.Add(this.pnlPeriod);
            this.grpLotInfo.Controls.Add(this.txtLotID);
            this.grpLotInfo.Controls.Add(this.lblLotID);
            this.grpLotInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLotInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLotInfo.Location = new System.Drawing.Point(0, 0);
            this.grpLotInfo.Name = "grpLotInfo";
            this.grpLotInfo.Size = new System.Drawing.Size(736, 40);
            this.grpLotInfo.TabIndex = 0;
            this.grpLotInfo.TabStop = false;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(464, 12);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(55, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 0;
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
            this.dtpTo.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 12);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(200, 20);
            this.txtLotID.TabIndex = 0;
            this.txtLotID.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 16);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            this.lblLotID.TabIndex = 0;
            this.lblLotID.Text = "Lot ID";
            // 
            // pnlMidMid
            // 
            this.pnlMidMid.Controls.Add(this.spdHistory);
            this.pnlMidMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMidMid.Location = new System.Drawing.Point(3, 43);
            this.pnlMidMid.Name = "pnlMidMid";
            this.pnlMidMid.Size = new System.Drawing.Size(736, 470);
            this.pnlMidMid.TabIndex = 0;
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
            this.spdHistory.HorizontalScrollBar.TabIndex = 2;
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(736, 470);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 0;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistory.VerticalScrollBar.TabIndex = 3;
            this.spdHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdHistory.SetActiveViewport(0, 0, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 23;
            spdHistory_Sheet1.RowCount = 5;
            spdHistory_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Serial Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "BOM Set ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "BOM Set Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "BOM Hist Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Part Grp";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Alt Mat Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Mat Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Mat Unit";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Mat Att Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Serial ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Serial Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.General;
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "To Mat Att Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "To Serial ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Create User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Create Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Update User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Update Time";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 55F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 59F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Serial Seq";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 71F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "BOM Set ID";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "BOM Set Version";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "BOM Hist Type";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Part Grp";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Alt Mat Flag";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 81F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Mat ID";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 109F;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Mat Qty";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 71F;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Mat Unit";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 68F;
            this.spdHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Mat Att Qty";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 76F;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Serial ID";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 104F;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Serial Type";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Flow";
            this.spdHistory_Sheet1.Columns.Get(15).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Oper";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 62F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "To Mat Att Qty";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "To Serial ID";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 74F;
            this.spdHistory_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Create User ID";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Create Time";
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Update User ID";
            this.spdHistory_Sheet1.Columns.Get(21).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Update Time";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 119F;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(1).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(2).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(3).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(4).Height = 18F;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmBOMTranDeleteBOMHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBOMTranDeleteBOMHistory";
            this.Text = "Delete BOM History";
            this.Activated += new System.EventHandler(this.frmBOMTranDeleteBOMHistory_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMidTop.ResumeLayout(false);
            this.grpLotInfo.ResumeLayout(false);
            this.grpLotInfo.PerformLayout();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.pnlMidMid.ResumeLayout(false);
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
        
        #region " Function Definition"
        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        
        private bool CheckCondition(string FuncName)
        {
            
            try
            {
                switch (FuncName)
                {
                    case "VIEW":
                        
                        if (txtLotID.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            txtLotID.Focus();
                            return false;
                        }
                        if (dtpFrom.Value > dtpTo.Value)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(120));
                            dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                            return false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            
            return true;
            
        }
        // ViewLotHistoryForAssembly()
        //       - View Lot Status For Assembly
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sLotID As String
        //
        private bool ViewLotHistoryForAssembly()
        {

            int i;
            int iCol = 0;
            int iRow = 0;

            TRSNode in_node = new TRSNode("VIEW_LOT_HISTORY_FOR_ASSEMBLY_IN");
            TRSNode out_node = new TRSNode("VIEW_LOT_HISTORY_FOR_ASSEMBLY_OUT");

            MPCF.ClearList(spdHistory, true);

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
                in_node.AddInt("NEXT_BOM_HIST_SEQ", int.MaxValue);
                in_node.AddInt("NEXT_SEQ_NUM", 0);
                in_node.AddInt("NEXT_SERIAL_SEQ_NUM", 0);
                in_node.AddChar("INCLUDE_DEL_HIST", ' ');

                do
                {
                    if (MPCR.CallService("BOM", "BOM_View_Lot_History_For_Assembly", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {

                        FarPoint.Win.Spread.SheetView histList = spdHistory.Sheets[0];

                        iRow = histList.RowCount;
                        histList.RowCount++;

                        iCol = 0;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("BOM_HIST_SEQ"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("SEQ_NUM"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("SERIAL_SEQ_NUM"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("BOM_SET_ID"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("BOM_SET_VERSION"));

                        iCol++;
                        if (out_node.GetList(0)[i].GetChar("BOM_HIST_TYPE") == 'A')
                        {
                            histList.SetValue(iRow, iCol, "ASSEMBLY");

                            iCol++;
                        }
                        else if (out_node.GetList(0)[i].GetChar("BOM_HIST_TYPE") == 'D')
                        {
                            histList.SetValue(iRow, iCol, "DISASSEMBLE");

                            iCol++;
                        }
                        else if (out_node.GetList(0)[i].GetChar("BOM_HIST_TYPE") == 'R')
                        {
                            histList.SetValue(iRow, iCol, "REPLACE");

                            iCol++;
                        }
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("PART_GRP"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetChar("ALT_MAT_FLAG"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("MAT_ID"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetInt("MAT_VER"));

                        iCol++;
                        histList.SetValue(iRow, iCol, MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("MAT_QTY")));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("MAT_UNIT"));

                        iCol++;
                        histList.SetValue(iRow, iCol, MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("MAT_ATT_QTY")));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("SERIAL_ID"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetChar("SERIAL_TYPE"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("FLOW"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("OPER"));

                        iCol++;
                        histList.SetValue(iRow, iCol, MPCF.Format("#######,##0.###", out_node.GetList(0)[i].GetDouble("TO_MAT_ATT_QTY")));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("TO_SERIAL_ID"));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("CREATE_USER_ID"));

                        iCol++;
                        histList.SetValue(iRow, iCol, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("CREATE_TIME")));

                        iCol++;
                        histList.SetValue(iRow, iCol, out_node.GetList(0)[i].GetString("UPDATE_USER_ID"));

                        iCol++;
                        histList.SetValue(iRow, iCol, MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UPDATE_TIME")));

                        iCol++;


                    }

                    in_node.SetInt("NEXT_BOM_HIST_SEQ", out_node.GetInt("NEXT_BOM_HIST_SEQ"));
                    in_node.SetInt("NEXT_SEQ_NUM", out_node.GetInt("NEXT_SEQ_NUM"));
                    in_node.SetInt("NEXT_SERIAL_SEQ_NUM", out_node.GetInt("NEXT_SERIAL_SEQ_NUM"));

                } while (out_node.GetInt("NEXT_BOM_HIST_SEQ") > 0);

                MPCF.FitColumnHeader(spdHistory);
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        // Delete_BOM_History()
        //       -   Delete BOM History
        // Return Value
        //       -
        // Arguments
        //       -
        private bool Delete_BOM_History()
        {
            TRSNode in_node = new TRSNode("DELETE_BOM_HISTORY_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddInt("LAST_HIST_SEQ", MPCF.ToInt(spdHistory.Sheets[0].Cells[0, 0].Value));

                if (MPCR.CallService("BOM", "BOM_Delete_BOM_History", in_node, ref out_node) == false)
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
        
        private void frmBOMTranDeleteBOMHistory_Activated(object sender, System.EventArgs e)
        {
            if (b_load_flag == false)
            {
                MPCF.ClearList(spdHistory, true);
                MPCF.FitColumnHeader(spdHistory);
                
                dtpTo.Value = DateTime.Today;
                dtpFrom.Value = dtpTo.Value.AddMonths(- 1);
                
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewLotHistoryForAssembly();
                }
                
                b_load_flag = true;
            }
            
        }
        
        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && txtLotID.Text != "")
            {
                if (CheckCondition("VIEW") == false)
                {
                    return;
                }
                ViewLotHistoryForAssembly();
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
            
            if (Delete_BOM_History() == true)
            {
                ViewLotHistoryForAssembly();
            }
            
        }
        
    }
    //#End If ' _BOM
}
