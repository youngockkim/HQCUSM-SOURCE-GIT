
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.CliFrx;
using Miracom.UI.Controls;
using Miracom.TRSCore;

//#If _EDC = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCDeleteEDCDataHistory.vb
//   Description : Delete EDC Data History
//
//   MES Version : 4.1.0.0
//
//   Function List
//
//   Detail Description
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-08-16 : Created by H.K.KIM
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.EDCCore
{
    public class frmEDCDeleteLotDataHistory : Miracom.MESCore.TranForm06
    {
        
#region " Windows Form auto generated code "
        
        public frmEDCDeleteLotDataHistory()
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
        private Splitter splitter1;
        private Panel pnlLotHistory;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView SheetView1;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private System.Windows.Forms.Label lblTo;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer5 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer5 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.pnlLotHistory = new System.Windows.Forms.Panel();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.SheetView1 = new FarPoint.Win.Spread.SheetView();
            this.pnlTranInfo.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpTranTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.pnlLotHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranInfo
            // 
            this.pnlTranInfo.Controls.Add(this.spdData);
            this.pnlTranInfo.Controls.Add(this.splitter1);
            this.pnlTranInfo.Controls.Add(this.pnlLotHistory);
            this.pnlTranInfo.Size = new System.Drawing.Size(736, 410);
            // 
            // pnlComment
            // 
            this.pnlComment.Location = new System.Drawing.Point(3, 413);
            this.pnlComment.TabIndex = 2;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            // 
            // lblLotID
            // 
            this.lblLotID.AutoSize = true;
            this.lblLotID.Size = new System.Drawing.Size(42, 13);
            // 
            // lblLotDesc
            // 
            this.lblLotDesc.AutoSize = true;
            this.lblLotDesc.Size = new System.Drawing.Size(60, 13);
            // 
            // txtLotID
            // 
            this.txtLotID.TextChanged += new System.EventHandler(this.txtLotID_TextChanged);
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            // 
            // txtLotDesc
            // 
            this.txtLotDesc.MaxLength = 200;
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
            this.grpTranTop.Controls.Add(this.pnlPeriod);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.lblLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotID, 0);
            this.grpTranTop.Controls.SetChildIndex(this.txtLotDesc, 0);
            this.grpTranTop.Controls.SetChildIndex(this.pnlPeriod, 0);
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
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Delete EDC Data History";
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
            columnHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer4.Name = "columnHeaderRenderer4";
            columnHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer4.TextRotationAngle = 0D;
            rowHeaderRenderer4.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer4.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer4.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer4.Name = "rowHeaderRenderer4";
            rowHeaderRenderer4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer4.TextRotationAngle = 0D;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            columnHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer5.Name = "columnHeaderRenderer5";
            columnHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer5.TextRotationAngle = 0D;
            rowHeaderRenderer5.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer5.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer5.Name = "rowHeaderRenderer5";
            rowHeaderRenderer5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer5.TextRotationAngle = 0D;
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(467, 12);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 4;
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
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(149, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // pnlLotHistory
            // 
            this.pnlLotHistory.Controls.Add(this.spdHistory);
            this.pnlLotHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLotHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlLotHistory.Name = "pnlLotHistory";
            this.pnlLotHistory.Size = new System.Drawing.Size(736, 141);
            this.pnlLotHistory.TabIndex = 2;
            // 
            // spdHistory
            // 
            this.spdHistory.AccessibleDescription = "spdHistory, Sheet1";
            this.spdHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.HorizontalScrollBar.Name = "";
            this.spdHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdHistory.HorizontalScrollBar.TabIndex = 8;
            this.spdHistory.Location = new System.Drawing.Point(0, 0);
            this.spdHistory.Name = "spdHistory";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.Renderer = columnHeaderRenderer5;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = rowHeaderRenderer5;
            namedStyle6.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle7.BackColor = System.Drawing.SystemColors.Control;
            namedStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle7.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle7.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle7.Renderer = cornerRenderer2;
            namedStyle7.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle8.BackColor = System.Drawing.SystemColors.Window;
            namedStyle8.CellType = generalCellType2;
            namedStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            namedStyle8.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle8.Renderer = generalCellType2;
            this.spdHistory.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(736, 141);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 0;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdHistory.VerticalScrollBar.TabIndex = 9;
            this.spdHistory.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdHistory_SelectionChanged);
            this.spdHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdHistory.SetActiveViewport(0, -1, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 189;
            spdHistory_Sheet1.RowCount = 0;
            this.spdHistory_Sheet1.ActiveColumnIndex = -1;
            this.spdHistory_Sheet1.ActiveRowIndex = -1;
            this.spdHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Carrier";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Lot Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Owner Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Create Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Create Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Lot Priority";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Lot Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Lot Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Hold Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Hold Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Hold Prv Group";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Oper In Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Oper In Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Oper In Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Create Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Create Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Create Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Start Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Start Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Start Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Inventory Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Transit Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Unit Exist Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Inventory Unit";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Rework Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Rework Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Rework Count";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Rework Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Rework Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Rework Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Rework End Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Rework End Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Rework End Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Rework Return Clear Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Rework Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "NSTD Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "NSTD Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "NSTD Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "NSTD Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "NSTD Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Repair Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Repair Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Store Return Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Store Return Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "Store Return Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Start Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Start Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Start Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "End Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "End Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "End Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 63).Value = "Sample Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 64).Value = "Sample Wait Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 65).Value = "Sample Result";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 66).Value = "From To Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 67).Value = "From To Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 68).Value = "From To Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 69).Value = "From To Mat Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 70).Value = "From To Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 71).Value = "From To Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 72).Value = "From To Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 73).Value = "From To Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 74).Value = "From To Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 75).Value = "From To Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 76).Value = "From To Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 77).Value = "Ship Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 78).Value = "Ship Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 79).Value = "Original Due Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 80).Value = "Scheduled Due Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 81).Value = "Factory In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 82).Value = "Flow In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 83).Value = "Oper In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 84).Value = "Reserve Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 85).Value = "Port ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 86).Value = "Batch ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 87).Value = "Batch Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 88).Value = "Order ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 89).Value = "Add Order ID 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 90).Value = "Add Order ID 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 91).Value = "Add Order ID 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 92).Value = "Lot Location 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 93).Value = "Lot Location 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 94).Value = "Lot Location 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 95).Value = "Lot Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 96).Value = "Lot Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 97).Value = "Lot Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 98).Value = "Lot Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 99).Value = "Lot Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 100).Value = "Lot Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 101).Value = "Lot Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 102).Value = "Lot Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 103).Value = "Lot Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 104).Value = "Lot Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 105).Value = "Lot Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 106).Value = "Lot Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 107).Value = "Lot Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 108).Value = "Lot Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 109).Value = "Lot Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 110).Value = "Lot Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 111).Value = "Lot Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 112).Value = "Lot Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 113).Value = "Lot Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 114).Value = "Lot Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 115).Value = "Lot Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 116).Value = "Lot Delete Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 117).Value = "Bom Set ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 118).Value = "Bom Set Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 119).Value = "Bom Active Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 120).Value = "Bom Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 121).Value = "Critical Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 122).Value = "Critical Resource Group";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 123).Value = "Save Resource 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 124).Value = "Save Resource 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 125).Value = "Sub Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 126).Value = "Lot Group ID 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 127).Value = "Lot Group ID 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 128).Value = "Lot Group ID 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 129).Value = "Yield 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 130).Value = "Yield 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 131).Value = "Yield 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 132).Value = "Good Qty";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 133).Value = "Resv Field 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 134).Value = "Resv Field 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 135).Value = "Resv Field 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 136).Value = "Resv Field 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 137).Value = "Resv Field 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 138).Value = "Resv Flag 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 139).Value = "Resv Flag 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 140).Value = "Resv Flag 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 141).Value = "Resv Flag 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 142).Value = "Resv Flag 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 143).Value = "Old Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 144).Value = "Old Mat ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 145).Value = "Old Mat Version";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 146).Value = "Old Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 147).Value = "Old Flow Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 148).Value = "Old Oper";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 149).Value = "Old Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 150).Value = "Old Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 151).Value = "Old Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 152).Value = "Old Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 153).Value = "Old Lot Type";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 154).Value = "Old Owner Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 155).Value = "Old Create Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 156).Value = "Old Factory In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 157).Value = "Old Flow In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 158).Value = "Old Oper In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 159).Value = "Trans Cmf 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 160).Value = "Trans Cmf 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 161).Value = "Trans Cmf 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 162).Value = "Trans Cmf 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 163).Value = "Trans Cmf 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 164).Value = "Trans Cmf 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 165).Value = "Trans Cmf 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 166).Value = "Trans Cmf 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 167).Value = "Trans Cmf 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 168).Value = "Trans Cmf 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 169).Value = "Tran Cmf 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 170).Value = "Tran Cmf 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 171).Value = "Tran Cmf 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 172).Value = "Tran Cmf 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 173).Value = "Tran Cmf 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 174).Value = "Tran Cmf 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 175).Value = "Tran Cmf 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 176).Value = "Tran Cmf 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 177).Value = "Tran Cmf 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 178).Value = "Tran Cmf 20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 179).Value = "Tran User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 180).Value = "Tran Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 181).Value = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 182).Value = "Multi Tr Key";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 183).Value = "Multi Tr Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 184).Value = "Hist Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 185).Value = "Hist Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 186).Value = "Hist Delete User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 187).Value = "Hist Delete Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 188).Value = "Sys Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdHistory_Sheet1.Columns.Get(0).ForeColor = System.Drawing.Color.Black;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 44F;
            this.spdHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tran Code";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 81F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Factory";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Mat ID";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 122F;
            this.spdHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Flow";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Oper";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Qty 1";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Qty 2";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Qty 3";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Carrier";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Lot Type";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Owner Code";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 82F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Create Code";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Create Time";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Lot Priority";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 79F;
            this.spdHistory_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Lot Status";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 67F;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Lot Delete Time";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 116F;
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
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Hold Prv Group";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 83F;
            this.spdHistory_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Oper In Qty 1";
            this.spdHistory_Sheet1.Columns.Get(23).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Oper In Qty 2";
            this.spdHistory_Sheet1.Columns.Get(24).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Oper In Qty 3";
            this.spdHistory_Sheet1.Columns.Get(25).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Create Qty 1";
            this.spdHistory_Sheet1.Columns.Get(26).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Create Qty 2";
            this.spdHistory_Sheet1.Columns.Get(27).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Create Qty 3";
            this.spdHistory_Sheet1.Columns.Get(28).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Start Qty 1";
            this.spdHistory_Sheet1.Columns.Get(29).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Start Qty 2";
            this.spdHistory_Sheet1.Columns.Get(30).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Start Qty 3";
            this.spdHistory_Sheet1.Columns.Get(31).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Inventory Flag";
            this.spdHistory_Sheet1.Columns.Get(32).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 69F;
            this.spdHistory_Sheet1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Transit Flag";
            this.spdHistory_Sheet1.Columns.Get(33).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Unit Exist Flag";
            this.spdHistory_Sheet1.Columns.Get(34).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Inventory Unit";
            this.spdHistory_Sheet1.Columns.Get(35).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Rework Flag";
            this.spdHistory_Sheet1.Columns.Get(36).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "Rework Code";
            this.spdHistory_Sheet1.Columns.Get(37).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Rework Count";
            this.spdHistory_Sheet1.Columns.Get(38).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Rework Return Flow";
            this.spdHistory_Sheet1.Columns.Get(39).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Rework Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(40).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 135F;
            this.spdHistory_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Rework Return Oper";
            this.spdHistory_Sheet1.Columns.Get(41).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 134F;
            this.spdHistory_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "Rework End Flow";
            this.spdHistory_Sheet1.Columns.Get(42).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(43).Label = "Rework End Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(43).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(43).Width = 124F;
            this.spdHistory_Sheet1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(44).Label = "Rework End Oper";
            this.spdHistory_Sheet1.Columns.Get(44).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(44).Width = 108F;
            this.spdHistory_Sheet1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(45).Label = "Rework Return Clear Flag";
            this.spdHistory_Sheet1.Columns.Get(45).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(45).Width = 160F;
            this.spdHistory_Sheet1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(46).Label = "Rework Time";
            this.spdHistory_Sheet1.Columns.Get(46).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(46).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(47).Label = "NSTD Flag";
            this.spdHistory_Sheet1.Columns.Get(47).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(47).Width = 68F;
            this.spdHistory_Sheet1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(48).Label = "NSTD Return Flow";
            this.spdHistory_Sheet1.Columns.Get(48).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(48).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(49).Label = "NSTD Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(49).Width = 124F;
            this.spdHistory_Sheet1.Columns.Get(50).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(50).Label = "NSTD Return Oper";
            this.spdHistory_Sheet1.Columns.Get(50).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(50).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(51).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(51).Label = "NSTD Time";
            this.spdHistory_Sheet1.Columns.Get(51).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(51).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(52).Label = "Repair Flag";
            this.spdHistory_Sheet1.Columns.Get(52).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(52).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(52).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(53).Label = "Repair Return Oper";
            this.spdHistory_Sheet1.Columns.Get(53).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(53).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(53).Width = 113F;
            this.spdHistory_Sheet1.Columns.Get(54).Label = "Store Return Flow";
            this.spdHistory_Sheet1.Columns.Get(54).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(54).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(54).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(55).Label = "Store Return Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(55).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(55).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(55).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(56).Label = "Store Return Oper";
            this.spdHistory_Sheet1.Columns.Get(56).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(56).Width = 119F;
            this.spdHistory_Sheet1.Columns.Get(57).Label = "Start Flag";
            this.spdHistory_Sheet1.Columns.Get(57).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(57).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(58).Label = "Start Time";
            this.spdHistory_Sheet1.Columns.Get(58).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(58).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(58).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(59).Label = "Start Resource";
            this.spdHistory_Sheet1.Columns.Get(59).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(59).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(60).Label = "End Flag";
            this.spdHistory_Sheet1.Columns.Get(60).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(60).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(61).Label = "End Time";
            this.spdHistory_Sheet1.Columns.Get(61).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(61).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(62).Label = "End Resource";
            this.spdHistory_Sheet1.Columns.Get(62).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(62).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(63).Label = "Sample Flag";
            this.spdHistory_Sheet1.Columns.Get(63).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(63).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(63).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(64).Label = "Sample Wait Flag";
            this.spdHistory_Sheet1.Columns.Get(64).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(64).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(64).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(65).Label = "Sample Result";
            this.spdHistory_Sheet1.Columns.Get(65).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(65).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(65).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(66).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(66).Label = "From To Flag";
            this.spdHistory_Sheet1.Columns.Get(66).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(66).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(66).Width = 88F;
            this.spdHistory_Sheet1.Columns.Get(67).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(67).Label = "From To Lot ID";
            this.spdHistory_Sheet1.Columns.Get(67).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(67).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(67).Width = 102F;
            this.spdHistory_Sheet1.Columns.Get(68).Label = "From To Mat ID";
            this.spdHistory_Sheet1.Columns.Get(68).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(68).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(68).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(69).Label = "From To Mat Version";
            this.spdHistory_Sheet1.Columns.Get(69).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(69).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(69).Width = 107F;
            this.spdHistory_Sheet1.Columns.Get(70).Label = "From To Flow";
            this.spdHistory_Sheet1.Columns.Get(70).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(70).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(70).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(71).Label = "From To Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(71).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(71).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(71).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(72).Label = "From To Oper";
            this.spdHistory_Sheet1.Columns.Get(72).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(72).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(72).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(73).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(73).Label = "From To Qty 1";
            this.spdHistory_Sheet1.Columns.Get(73).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(73).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(73).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(74).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(74).Label = "From To Qty 2";
            this.spdHistory_Sheet1.Columns.Get(74).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(74).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(74).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(75).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(75).Label = "From To Qty 3";
            this.spdHistory_Sheet1.Columns.Get(75).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(75).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(75).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(76).Label = "From To Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(76).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(76).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(76).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(77).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(77).Label = "Ship Code";
            this.spdHistory_Sheet1.Columns.Get(77).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(77).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(77).Width = 107F;
            this.spdHistory_Sheet1.Columns.Get(78).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(78).Label = "Ship Time";
            this.spdHistory_Sheet1.Columns.Get(78).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(78).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(78).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(79).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(79).Label = "Original Due Time";
            this.spdHistory_Sheet1.Columns.Get(79).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(79).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(79).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(80).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(80).Label = "Scheduled Due Time";
            this.spdHistory_Sheet1.Columns.Get(80).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(80).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(80).Width = 133F;
            this.spdHistory_Sheet1.Columns.Get(81).Label = "Factory In Time";
            this.spdHistory_Sheet1.Columns.Get(81).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(81).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(82).Label = "Flow In Time";
            this.spdHistory_Sheet1.Columns.Get(82).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(82).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(83).Label = "Oper In Time";
            this.spdHistory_Sheet1.Columns.Get(83).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(83).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(84).Label = "Reserve Resource";
            this.spdHistory_Sheet1.Columns.Get(84).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(84).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(84).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(85).Label = "Port ID";
            this.spdHistory_Sheet1.Columns.Get(85).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(85).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(85).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(86).Label = "Batch ID";
            this.spdHistory_Sheet1.Columns.Get(86).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(86).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(86).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(87).Label = "Batch Seq";
            this.spdHistory_Sheet1.Columns.Get(87).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(87).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(87).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(88).Label = "Order ID";
            this.spdHistory_Sheet1.Columns.Get(88).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(88).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(88).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(89).Label = "Add Order ID 1";
            this.spdHistory_Sheet1.Columns.Get(89).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(89).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(89).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(90).Label = "Add Order ID 2";
            this.spdHistory_Sheet1.Columns.Get(90).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(90).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(90).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(91).Label = "Add Order ID 3";
            this.spdHistory_Sheet1.Columns.Get(91).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(91).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(91).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(92).Label = "Lot Location 1";
            this.spdHistory_Sheet1.Columns.Get(92).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(92).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(92).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(93).Label = "Lot Location 2";
            this.spdHistory_Sheet1.Columns.Get(93).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(93).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(93).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(94).Label = "Lot Location 3";
            this.spdHistory_Sheet1.Columns.Get(94).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(94).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(94).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(95).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(95).Label = "Lot Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(95).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(95).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(95).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(96).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(96).Label = "Lot Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(96).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(96).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(96).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(97).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(97).Label = "Lot Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(97).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(97).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(97).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(98).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(98).Label = "Lot Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(98).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(98).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(98).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(99).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(99).Label = "Lot Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(99).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(99).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(99).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(100).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(100).Label = "Lot Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(100).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(100).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(100).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(101).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(101).Label = "Lot Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(101).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(101).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(101).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(102).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(102).Label = "Lot Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(102).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(102).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(102).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(103).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(103).Label = "Lot Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(103).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(103).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(103).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(104).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(104).Label = "Lot Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(104).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(104).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(104).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(105).Label = "Lot Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(105).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(105).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(105).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(106).Label = "Lot Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(106).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(106).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(106).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(107).Label = "Lot Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(107).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(107).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(107).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(108).Label = "Lot Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(108).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(108).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(108).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(109).Label = "Lot Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(109).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(109).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(109).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(110).Label = "Lot Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(110).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(110).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(110).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(111).Label = "Lot Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(111).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(111).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(111).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(112).Label = "Lot Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(112).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(112).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(112).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(113).Label = "Lot Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(113).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(113).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(113).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(114).Label = "Lot Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(114).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(114).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(114).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(115).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(115).Label = "Lot Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(115).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(115).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(115).Width = 108F;
            this.spdHistory_Sheet1.Columns.Get(116).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(116).Label = "Lot Delete Code";
            this.spdHistory_Sheet1.Columns.Get(116).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(116).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(116).Width = 128F;
            this.spdHistory_Sheet1.Columns.Get(117).Label = "Bom Set ID";
            this.spdHistory_Sheet1.Columns.Get(117).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(117).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(117).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(118).Label = "Bom Set Version";
            this.spdHistory_Sheet1.Columns.Get(118).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(118).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(118).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(119).Label = "Bom Active Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(119).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(119).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(119).Width = 116F;
            this.spdHistory_Sheet1.Columns.Get(120).Label = "Bom Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(120).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(120).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(120).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(121).Label = "Critical Resource";
            this.spdHistory_Sheet1.Columns.Get(121).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(121).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(121).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(122).Label = "Critical Resource Group";
            this.spdHistory_Sheet1.Columns.Get(122).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(122).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(122).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(123).Label = "Save Resource 1";
            this.spdHistory_Sheet1.Columns.Get(123).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(123).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(123).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(124).Label = "Save Resource 2";
            this.spdHistory_Sheet1.Columns.Get(124).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(124).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(124).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(125).Label = "Sub Resource";
            this.spdHistory_Sheet1.Columns.Get(125).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(125).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(125).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(126).Label = "Lot Group ID 1";
            this.spdHistory_Sheet1.Columns.Get(126).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(126).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(126).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(127).Label = "Lot Group ID 2";
            this.spdHistory_Sheet1.Columns.Get(127).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(127).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(127).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(128).Label = "Lot Group ID 3";
            this.spdHistory_Sheet1.Columns.Get(128).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(128).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(128).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(129).Label = "Yield 1";
            this.spdHistory_Sheet1.Columns.Get(129).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(129).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(130).Label = "Yield 2";
            this.spdHistory_Sheet1.Columns.Get(130).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(130).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(131).Label = "Yield 3";
            this.spdHistory_Sheet1.Columns.Get(131).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(131).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(132).Label = "Good Qty";
            this.spdHistory_Sheet1.Columns.Get(132).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(132).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(133).Label = "Resv Field 1";
            this.spdHistory_Sheet1.Columns.Get(133).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(133).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(133).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(134).Label = "Resv Field 2";
            this.spdHistory_Sheet1.Columns.Get(134).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(134).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(134).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(135).Label = "Resv Field 3";
            this.spdHistory_Sheet1.Columns.Get(135).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(135).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(135).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(136).Label = "Resv Field 4";
            this.spdHistory_Sheet1.Columns.Get(136).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(136).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(136).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(137).Label = "Resv Field 5";
            this.spdHistory_Sheet1.Columns.Get(137).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(137).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(137).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(138).Label = "Resv Flag 1";
            this.spdHistory_Sheet1.Columns.Get(138).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(138).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(138).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(139).Label = "Resv Flag 2";
            this.spdHistory_Sheet1.Columns.Get(139).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(139).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(139).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(140).Label = "Resv Flag 3";
            this.spdHistory_Sheet1.Columns.Get(140).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(140).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(140).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(141).Label = "Resv Flag 4";
            this.spdHistory_Sheet1.Columns.Get(141).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(141).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(141).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(142).Label = "Resv Flag 5";
            this.spdHistory_Sheet1.Columns.Get(142).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(142).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(142).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(143).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(143).Label = "Old Factory";
            this.spdHistory_Sheet1.Columns.Get(143).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(143).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(143).Width = 95F;
            this.spdHistory_Sheet1.Columns.Get(144).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(144).Label = "Old Mat ID";
            this.spdHistory_Sheet1.Columns.Get(144).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(144).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(144).Width = 88F;
            this.spdHistory_Sheet1.Columns.Get(145).Label = "Old Mat Version";
            this.spdHistory_Sheet1.Columns.Get(145).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(145).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(145).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(146).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(146).Label = "Old Flow";
            this.spdHistory_Sheet1.Columns.Get(146).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(146).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(146).Width = 99F;
            this.spdHistory_Sheet1.Columns.Get(147).Label = "Old Flow Seq";
            this.spdHistory_Sheet1.Columns.Get(147).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(147).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(147).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(148).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(148).Label = "Old Oper";
            this.spdHistory_Sheet1.Columns.Get(148).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(148).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(149).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(149).Label = "Old Qty 1";
            this.spdHistory_Sheet1.Columns.Get(149).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(149).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(149).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(150).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(150).Label = "Old Qty 2";
            this.spdHistory_Sheet1.Columns.Get(150).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(150).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(150).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(151).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(151).Label = "Old Qty 3";
            this.spdHistory_Sheet1.Columns.Get(151).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(151).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(151).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(152).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(152).Label = "Old Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(152).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(152).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(152).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(153).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(153).Label = "Old Lot Type";
            this.spdHistory_Sheet1.Columns.Get(153).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(153).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(153).Width = 101F;
            this.spdHistory_Sheet1.Columns.Get(154).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(154).Label = "Old Owner Code";
            this.spdHistory_Sheet1.Columns.Get(154).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(154).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(154).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(155).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(155).Label = "Old Create Code";
            this.spdHistory_Sheet1.Columns.Get(155).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(155).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(155).Width = 114F;
            this.spdHistory_Sheet1.Columns.Get(156).Label = "Old Factory In Time";
            this.spdHistory_Sheet1.Columns.Get(156).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(156).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(156).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(157).Label = "Old Flow In Time";
            this.spdHistory_Sheet1.Columns.Get(157).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(157).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(157).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(158).Label = "Old Oper In Time";
            this.spdHistory_Sheet1.Columns.Get(158).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(158).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(158).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(159).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(159).Label = "Trans Cmf 1";
            this.spdHistory_Sheet1.Columns.Get(159).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(159).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(159).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(160).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(160).Label = "Trans Cmf 2";
            this.spdHistory_Sheet1.Columns.Get(160).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(160).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(160).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(161).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(161).Label = "Trans Cmf 3";
            this.spdHistory_Sheet1.Columns.Get(161).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(161).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(161).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(162).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(162).Label = "Trans Cmf 4";
            this.spdHistory_Sheet1.Columns.Get(162).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(162).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(162).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(163).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(163).Label = "Trans Cmf 5";
            this.spdHistory_Sheet1.Columns.Get(163).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(163).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(163).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(164).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(164).Label = "Trans Cmf 6";
            this.spdHistory_Sheet1.Columns.Get(164).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(164).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(164).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(165).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(165).Label = "Trans Cmf 7";
            this.spdHistory_Sheet1.Columns.Get(165).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(165).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(165).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(166).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(166).Label = "Trans Cmf 8";
            this.spdHistory_Sheet1.Columns.Get(166).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(166).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(166).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(167).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(167).Label = "Trans Cmf 9";
            this.spdHistory_Sheet1.Columns.Get(167).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(167).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(167).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(168).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(168).Label = "Trans Cmf 10";
            this.spdHistory_Sheet1.Columns.Get(168).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(168).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(168).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(169).Label = "Tran Cmf 11";
            this.spdHistory_Sheet1.Columns.Get(169).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(169).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(169).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(170).Label = "Tran Cmf 12";
            this.spdHistory_Sheet1.Columns.Get(170).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(170).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(170).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(171).Label = "Tran Cmf 13";
            this.spdHistory_Sheet1.Columns.Get(171).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(171).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(171).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(172).Label = "Tran Cmf 14";
            this.spdHistory_Sheet1.Columns.Get(172).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(172).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(172).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(173).Label = "Tran Cmf 15";
            this.spdHistory_Sheet1.Columns.Get(173).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(173).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(173).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(174).Label = "Tran Cmf 16";
            this.spdHistory_Sheet1.Columns.Get(174).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(174).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(174).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(175).Label = "Tran Cmf 17";
            this.spdHistory_Sheet1.Columns.Get(175).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(175).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(175).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(176).Label = "Tran Cmf 18";
            this.spdHistory_Sheet1.Columns.Get(176).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(176).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(176).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(177).Label = "Tran Cmf 19";
            this.spdHistory_Sheet1.Columns.Get(177).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(177).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(177).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(178).Label = "Tran Cmf 20";
            this.spdHistory_Sheet1.Columns.Get(178).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(178).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(178).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(179).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(179).Label = "Tran User ID";
            this.spdHistory_Sheet1.Columns.Get(179).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(179).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(179).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(180).Label = "Tran Comment";
            this.spdHistory_Sheet1.Columns.Get(180).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(180).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(180).Width = 86F;
            this.spdHistory_Sheet1.Columns.Get(181).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(181).Label = "Prev Active Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(181).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(181).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(181).Width = 131F;
            this.spdHistory_Sheet1.Columns.Get(182).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(182).Label = "Multi Tr Key";
            this.spdHistory_Sheet1.Columns.Get(182).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(182).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(182).Width = 92F;
            this.spdHistory_Sheet1.Columns.Get(183).Label = "Multi Tr Seq";
            this.spdHistory_Sheet1.Columns.Get(183).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(183).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.spdHistory_Sheet1.Columns.Get(183).Width = 74F;
            this.spdHistory_Sheet1.Columns.Get(184).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(184).Label = "Hist Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(184).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(184).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(184).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(185).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(185).Label = "Hist Delete Time";
            this.spdHistory_Sheet1.Columns.Get(185).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(185).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(185).Width = 125F;
            this.spdHistory_Sheet1.Columns.Get(186).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(186).Label = "Hist Delete User ID";
            this.spdHistory_Sheet1.Columns.Get(186).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(186).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(186).Width = 127F;
            this.spdHistory_Sheet1.Columns.Get(187).Label = "Hist Delete Comment";
            this.spdHistory_Sheet1.Columns.Get(187).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(187).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(187).Width = 116F;
            this.spdHistory_Sheet1.Columns.Get(188).Label = "Sys Tran Time";
            this.spdHistory_Sheet1.Columns.Get(188).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(188).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(188).Width = 125F;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHistory_Sheet1.RowHeader.Visible = false;
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 141);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(736, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 10;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 144);
            this.spdData.Name = "spdData";
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
            this.spdData.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.SheetView1});
            this.spdData.Size = new System.Drawing.Size(736, 266);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 11;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // SheetView1
            // 
            this.SheetView1.Reset();
            SheetView1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.SheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            SheetView1.ColumnCount = 50;
            SheetView1.ColumnHeader.RowCount = 2;
            SheetView1.RowCount = 0;
            this.SheetView1.ActiveColumnIndex = -1;
            this.SheetView1.ActiveRowIndex = -1;
            this.SheetView1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.SheetView1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.SheetView1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.SheetView1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.SheetView1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.SheetView1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.SheetView1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 1).Value = "Lot ID";
            this.SheetView1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 2).Value = "Col Seq";
            this.SheetView1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 3).Value = "TranTime";
            this.SheetView1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 4).Value = "Del Flag";
            this.SheetView1.ColumnHeader.Cells.Get(0, 5).RowSpan = 5;
            this.SheetView1.ColumnHeader.Cells.Get(0, 5).Value = "Factory";
            this.SheetView1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 6).Value = "Material";
            this.SheetView1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 7).Value = "Flow";
            this.SheetView1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 8).Value = "Oper";
            this.SheetView1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 9).Value = "Measure Resource ID";
            this.SheetView1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 10).Value = "Proc Flow";
            this.SheetView1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 11).Value = "Collection Set ID";
            this.SheetView1.ColumnHeader.Cells.Get(0, 12).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 12).Value = "Version";
            this.SheetView1.ColumnHeader.Cells.Get(0, 13).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 13).Value = "Character Seq";
            this.SheetView1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 14).Value = "Character";
            this.SheetView1.ColumnHeader.Cells.Get(0, 15).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 15).Value = "Character Desc";
            this.SheetView1.ColumnHeader.Cells.Get(0, 16).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 16).Value = "Spec";
            this.SheetView1.ColumnHeader.Cells.Get(0, 17).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 17).Value = "Unit Seq";
            this.SheetView1.ColumnHeader.Cells.Get(0, 18).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 18).Value = "Unit ID";
            this.SheetView1.ColumnHeader.Cells.Get(0, 19).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 19).Value = "Value Seq";
            this.SheetView1.ColumnHeader.Cells.Get(0, 20).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 20).Value = " Value Type";
            this.SheetView1.ColumnHeader.Cells.Get(0, 21).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 21).Value = " Value Count";
            this.SheetView1.ColumnHeader.Cells.Get(0, 22).ColumnSpan = 25;
            this.SheetView1.ColumnHeader.Cells.Get(0, 22).Value = "Value";
            this.SheetView1.ColumnHeader.Cells.Get(0, 47).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 47).Value = "Spec Out Mask";
            this.SheetView1.ColumnHeader.Cells.Get(0, 48).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 48).Value = "Update User ID";
            this.SheetView1.ColumnHeader.Cells.Get(0, 49).RowSpan = 2;
            this.SheetView1.ColumnHeader.Cells.Get(0, 49).Value = "Update Time";
            this.SheetView1.ColumnHeader.Cells.Get(1, 15).Value = "Character Desc";
            this.SheetView1.ColumnHeader.Cells.Get(1, 22).Value = "1";
            this.SheetView1.ColumnHeader.Cells.Get(1, 23).Value = "2";
            this.SheetView1.ColumnHeader.Cells.Get(1, 24).Value = "3";
            this.SheetView1.ColumnHeader.Cells.Get(1, 25).Value = "4";
            this.SheetView1.ColumnHeader.Cells.Get(1, 26).Value = "5";
            this.SheetView1.ColumnHeader.Cells.Get(1, 27).Value = "6";
            this.SheetView1.ColumnHeader.Cells.Get(1, 28).Value = "7";
            this.SheetView1.ColumnHeader.Cells.Get(1, 29).Value = "8";
            this.SheetView1.ColumnHeader.Cells.Get(1, 30).Value = "9";
            this.SheetView1.ColumnHeader.Cells.Get(1, 31).Value = "10";
            this.SheetView1.ColumnHeader.Cells.Get(1, 32).Value = "11";
            this.SheetView1.ColumnHeader.Cells.Get(1, 33).Value = "12";
            this.SheetView1.ColumnHeader.Cells.Get(1, 34).Value = "13";
            this.SheetView1.ColumnHeader.Cells.Get(1, 35).Value = "14";
            this.SheetView1.ColumnHeader.Cells.Get(1, 36).Value = "15";
            this.SheetView1.ColumnHeader.Cells.Get(1, 37).Value = "16";
            this.SheetView1.ColumnHeader.Cells.Get(1, 38).Value = "17";
            this.SheetView1.ColumnHeader.Cells.Get(1, 39).Value = "18";
            this.SheetView1.ColumnHeader.Cells.Get(1, 40).Value = "19";
            this.SheetView1.ColumnHeader.Cells.Get(1, 41).Value = "20";
            this.SheetView1.ColumnHeader.Cells.Get(1, 42).Value = "21";
            this.SheetView1.ColumnHeader.Cells.Get(1, 43).Value = "22";
            this.SheetView1.ColumnHeader.Cells.Get(1, 44).Value = "23";
            this.SheetView1.ColumnHeader.Cells.Get(1, 45).Value = "24";
            this.SheetView1.ColumnHeader.Cells.Get(1, 46).Value = "25";
            this.SheetView1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.SheetView1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.SheetView1.ColumnHeader.Rows.Get(0).Height = 16F;
            this.SheetView1.ColumnHeader.Rows.Get(1).Height = 16F;
            this.SheetView1.Columns.Get(0).CellType = checkBoxCellType1;
            this.SheetView1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.SheetView1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(0).Width = 30F;
            this.SheetView1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(1).Width = 0F;
            this.SheetView1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(2).Width = 50F;
            this.SheetView1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(3).Width = 0F;
            this.SheetView1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.SheetView1.Columns.Get(4).Locked = true;
            this.SheetView1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(4).Width = 30F;
            this.SheetView1.Columns.Get(5).Locked = true;
            this.SheetView1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(5).Width = 0F;
            this.SheetView1.Columns.Get(6).Locked = true;
            this.SheetView1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(6).Width = 0F;
            this.SheetView1.Columns.Get(7).Locked = true;
            this.SheetView1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(7).Width = 0F;
            this.SheetView1.Columns.Get(8).Locked = true;
            this.SheetView1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(8).Width = 0F;
            this.SheetView1.Columns.Get(9).Locked = true;
            this.SheetView1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(9).Width = 0F;
            this.SheetView1.Columns.Get(10).Locked = true;
            this.SheetView1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(10).Width = 0F;
            this.SheetView1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.SheetView1.Columns.Get(11).Locked = true;
            this.SheetView1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(11).Width = 100F;
            this.SheetView1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.SheetView1.Columns.Get(12).Locked = true;
            this.SheetView1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(12).Width = 45F;
            this.SheetView1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.SheetView1.Columns.Get(13).Locked = true;
            this.SheetView1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(13).Width = 58F;
            this.SheetView1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.SheetView1.Columns.Get(14).Locked = true;
            this.SheetView1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(14).Width = 100F;
            this.SheetView1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.SheetView1.Columns.Get(15).Label = "Character Desc";
            this.SheetView1.Columns.Get(15).Locked = true;
            this.SheetView1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(15).Width = 120F;
            this.SheetView1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.SheetView1.Columns.Get(16).Locked = true;
            this.SheetView1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(16).Width = 100F;
            this.SheetView1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.SheetView1.Columns.Get(17).Locked = true;
            this.SheetView1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(17).Width = 30F;
            this.SheetView1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.SheetView1.Columns.Get(18).Locked = true;
            this.SheetView1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(18).Width = 100F;
            this.SheetView1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.SheetView1.Columns.Get(19).Locked = true;
            this.SheetView1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(19).Width = 40F;
            this.SheetView1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.SheetView1.Columns.Get(20).Locked = true;
            this.SheetView1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(20).Width = 40F;
            this.SheetView1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(21).Locked = true;
            this.SheetView1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(21).Width = 40F;
            this.SheetView1.Columns.Get(22).CellType = textCellType1;
            this.SheetView1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(22).Label = "1";
            this.SheetView1.Columns.Get(22).Locked = true;
            this.SheetView1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(23).Label = "2";
            this.SheetView1.Columns.Get(23).Locked = true;
            this.SheetView1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(24).Label = "3";
            this.SheetView1.Columns.Get(24).Locked = true;
            this.SheetView1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(25).Label = "4";
            this.SheetView1.Columns.Get(25).Locked = true;
            this.SheetView1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(26).Label = "5";
            this.SheetView1.Columns.Get(26).Locked = true;
            this.SheetView1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(27).Label = "6";
            this.SheetView1.Columns.Get(27).Locked = true;
            this.SheetView1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(28).Label = "7";
            this.SheetView1.Columns.Get(28).Locked = true;
            this.SheetView1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(29).Label = "8";
            this.SheetView1.Columns.Get(29).Locked = true;
            this.SheetView1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(30).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(30).Label = "9";
            this.SheetView1.Columns.Get(30).Locked = true;
            this.SheetView1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(31).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(31).Label = "10";
            this.SheetView1.Columns.Get(31).Locked = true;
            this.SheetView1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(32).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(32).Label = "11";
            this.SheetView1.Columns.Get(32).Locked = true;
            this.SheetView1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(33).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(33).Label = "12";
            this.SheetView1.Columns.Get(33).Locked = true;
            this.SheetView1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(34).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(34).Label = "13";
            this.SheetView1.Columns.Get(34).Locked = true;
            this.SheetView1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(35).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(35).Label = "14";
            this.SheetView1.Columns.Get(35).Locked = true;
            this.SheetView1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(36).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(36).Label = "15";
            this.SheetView1.Columns.Get(36).Locked = true;
            this.SheetView1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(37).Label = "16";
            this.SheetView1.Columns.Get(37).Locked = true;
            this.SheetView1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(38).Label = "17";
            this.SheetView1.Columns.Get(38).Locked = true;
            this.SheetView1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(39).Label = "18";
            this.SheetView1.Columns.Get(39).Locked = true;
            this.SheetView1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(40).Label = "19";
            this.SheetView1.Columns.Get(40).Locked = true;
            this.SheetView1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(41).Label = "20";
            this.SheetView1.Columns.Get(41).Locked = true;
            this.SheetView1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(42).Label = "21";
            this.SheetView1.Columns.Get(42).Locked = true;
            this.SheetView1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(43).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(43).Label = "22";
            this.SheetView1.Columns.Get(43).Locked = true;
            this.SheetView1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(44).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(44).Label = "23";
            this.SheetView1.Columns.Get(44).Locked = true;
            this.SheetView1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(45).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(45).Label = "24";
            this.SheetView1.Columns.Get(45).Locked = true;
            this.SheetView1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(46).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.SheetView1.Columns.Get(46).Label = "25";
            this.SheetView1.Columns.Get(46).Locked = true;
            this.SheetView1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(47).CellType = textCellType2;
            this.SheetView1.Columns.Get(47).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.SheetView1.Columns.Get(47).Locked = true;
            this.SheetView1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(47).Width = 160F;
            this.SheetView1.Columns.Get(48).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.SheetView1.Columns.Get(48).Locked = true;
            this.SheetView1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(48).Width = 85F;
            this.SheetView1.Columns.Get(49).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.SheetView1.Columns.Get(49).Locked = true;
            this.SheetView1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.SheetView1.Columns.Get(49).Width = 110F;
            this.SheetView1.GrayAreaBackColor = System.Drawing.Color.White;
            this.SheetView1.RowHeader.Columns.Default.Resizable = false;
            this.SheetView1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.SheetView1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.SheetView1.RowHeader.Visible = false;
            this.SheetView1.Rows.Default.Height = 18F;
            this.SheetView1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.SheetView1.SheetCornerStyle.Parent = "CornerDefault";
            this.SheetView1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmEDCDeleteLotDataHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmEDCDeleteLotDataHistory";
            this.Text = "Delete Lot Data History";
            this.Activated += new System.EventHandler(this.frmEDCDeleteEDCDataHistory_Activated);
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
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.pnlLotHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SheetView1)).EndInit();
            this.ResumeLayout(false);

        }
        
#endregion
        
#region " Variable Definition "
        
        private bool bLoadFlag;
        
#endregion
        
#region " Constant Definition "

        private const int COL_COL_SEQ = 2;
        private const int COL_DELETED = 4;
        private const int COL_COLSET_ID = 11;
        private const int COL_COLSET_VERSION = 12;
        private const int COL_CHAR_ID = 14;
        private const int COL_CHAR_DESC = 15;
        private const int COL_VALUE_COUNT = 21;
        private const int COL_SPEC_OUT_MASK = 47;
        private const int COL_UPDATE_TIME = 49;
        
        
#endregion
        
#region " Function Definition "
        
        // View_Lot()
        //       -  View Lot Information
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //
        private bool ViewLot(char c_step, string sLot_id)
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

            txtLotDesc.Text = MPCF.Trim(out_node.GetString("LOT_DESC"));
            
            return true;
            
        }
        
        // View_History()
        //       -   View Lot History
        // Return Value
        //       -
        // Arguments
        //       -
        private void ViewHistory()
        {
            
            string sFromTime;
            string sToTime;
            
            if (txtLotID.Text != "")
            {
                sFromTime = MPCF.FromDate(dtpFrom);
                sToTime = MPCF.ToDate(dtpTo);
                if (WIPLIST.ViewLotHistory(spdHistory, '1', txtLotID.Text, sFromTime, sToTime, 'Y', null, false, MPGC.MP_TRAN_CODE_LOTEDC) == false)
                {
                    return;
                }
                
            }
            
        }
        
        // Delete_LotData_History()
        //       -   Delete LotData History
        // Return Value
        //       -
        // Arguments
        //       -
        private bool Delete_LotData_History(char s_step)
        {
            TRSNode in_node = new TRSNode("DELETE_LOTDATA_HISTORY_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode col_seq_list;
            int i;
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = s_step;
                in_node.AddString("LOT_ID", MPCF.Trim(txtLotID.Text));
                in_node.AddInt("HIST_SEQ", MPCF.ToInt(MPCF.ToDbl(spdHistory.Sheets[0].Cells[spdHistory.Sheets[0].ActiveRowIndex, 0].Value)));
                in_node.AddString("COMMENT", MPCF.Trim(txtComment.Text));
                in_node.AddString("COL_SET_ID", MPCF.Trim(spdData.Sheets[0].Cells[0, COL_COLSET_ID].Value));
                in_node.AddInt("COL_SET_VERSION", MPCF.ToInt(spdData.Sheets[0].Cells[0, COL_COLSET_VERSION].Value));
                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (System.Convert.ToBoolean(spdData.ActiveSheet.GetValue(i, 0)) == true)
                    {
                        col_seq_list = in_node.AddNode("COL_SEQ_LIST");
                        col_seq_list.AddInt("COL_SEQ", MPCF.ToInt(spdData.Sheets[0].Cells[i, COL_COL_SEQ].Value));
                    }
                }              


                if (MPCR.CallService("EDC", "EDC_Delete_LotData_History", in_node, ref out_node) == false)
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
        
        private void txtLotID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)13)
            {
                MPCF.ClearList(spdHistory, true);
                MPCF.ClearList(spdData, true);
                txtLotDesc.Text = "";
                if (ViewLot('2', txtLotID.Text) == false)
                {
                    return;
                }
                ViewHistory();
            }
            
        }
        
        private void frmEDCDeleteEDCDataHistory_Activated(object sender, System.EventArgs e)
        {
            
            if (bLoadFlag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.ClearList(spdHistory, true);
                MPCF.ClearList(spdData, true);
                MPCR.SetLotCmfPrompt(spdHistory, 95);
                MPCF.FitLotHistoryDefaultColumnHeader(spdHistory);
                
                dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                dtpTo.Value = DateTime.Today;
                
                if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
                {
                    txtLotID.Text = MPGV.gsCurrentLot_ID;
                    ViewHistory();
                }
                
                bLoadFlag = true;
                
            }
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            char s_step;
            int i;
            if (spdHistory.Sheets[0].RowCount < 1)
            {
                return;
            }
            
            if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            s_step = '1';
            for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
            {
                if (System.Convert.ToBoolean(spdData.ActiveSheet.GetValue(i, 0)) == true)
                {
                    s_step = '2';
                }
            }
            
            if (Delete_LotData_History(s_step) == true)
            {
                ViewHistory();
                MPCF.ClearList(spdData, true);
                txtComment.Text = "";
            }
            
        }
        
        private void spdHistory_SelectionChanged(System.Object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
        {
            
            try
            {
                int iRow = 0;
                int i, i_col_seq, i_count;
                if (txtLotID.Text == "")
                {
                    return;
                }
                if (spdHistory.Sheets[0].ActiveRowIndex < 0)
                {
                    return;
                }
                MPCF.ClearList(spdData, true);
                iRow = spdHistory.Sheets[0].ActiveRowIndex;

                if (EDCLIST.ViewLotDataByLot(spdData, '1', txtLotID.Text, MPCF.ToInt(spdHistory.Sheets[0].GetValue(iRow, 0)), 'Y', null, false) == false)
                {
                    return;
                }
                if (spdData.ActiveSheet.RowCount > 0)
                {
                    i_col_seq = MPCF.ToInt(spdData.Sheets[0].GetValue(0, COL_COL_SEQ));
                    i = 1;
                    i_count = 1;
                    while (i < spdData.ActiveSheet.RowCount)
                    {
                        if (i_col_seq != MPCF.ToInt(spdData.Sheets[0].GetValue(i, COL_COL_SEQ)))
                        {
                            spdData.ActiveSheet.Cells[i - i_count, 0].RowSpan = i_count;
                            spdData.ActiveSheet.Cells[i - i_count, COL_COL_SEQ].RowSpan = i_count;
                            i_count = 1;
                            i_col_seq = MPCF.ToInt(spdData.Sheets[0].GetValue(i, COL_COL_SEQ));
                        }
                        else
                        {
                            i_count++;
                        }
                        i++;
                    }
                    spdData.ActiveSheet.Cells[i - i_count, 0].RowSpan = i_count;
                    spdData.ActiveSheet.Cells[i - i_count, COL_COL_SEQ].RowSpan = i_count;
                }
            
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void txtLotID_TextChanged(System.Object sender, System.EventArgs e)
        {
            
            MPCF.ClearList(spdHistory, true);
            MPCF.ClearList(spdData, true);
            txtLotDesc.Text = "";
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            MPCF.ClearList(spdHistory, true);
            MPCF.ClearList(spdData, true);
            txtLotDesc.Text = "";
            if (ViewLot('2', txtLotID.Text) == false)
            {
                return;
            }
            ViewHistory();
            
        }
        
    }
    
    //#End If
    
    
}
