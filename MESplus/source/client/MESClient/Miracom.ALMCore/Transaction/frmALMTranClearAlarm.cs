using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;

using Miracom.TRSCore;

//#If _ALM = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmALMTranClearAlarm.vb
//   Description :
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Alarm_History_List : View Lot Alarm History List
//       - Clear_Alarm() : Clear Lot Alarm History
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
    public class frmALMTranClearAlarm : Miracom.MESCore.TranForm11
    {
        
        #region " Windows Form auto generated code "
        
        public frmALMTranClearAlarm()
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
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtSourceID1;
        private System.Windows.Forms.Label lblSourceID1;
        protected System.Windows.Forms.Panel pnlComment;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.TextBox txtComment;
        protected System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.ColumnHeader ColumnHeader5;
        private System.Windows.Forms.ColumnHeader ColumnHeader6;
        private System.Windows.Forms.ColumnHeader ColumnHeader7;
        private System.Windows.Forms.ColumnHeader ColumnHeader8;
        private System.Windows.Forms.ColumnHeader ColumnHeader9;
        private System.Windows.Forms.ColumnHeader ColumnHeader10;
        private System.Windows.Forms.ColumnHeader ColumnHeader11;
        private System.Windows.Forms.ColumnHeader ColumnHeader12;
        private System.Windows.Forms.ColumnHeader ColumnHeader13;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.CheckBox chkIncludeCleared;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
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
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType2 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            this.txtSourceID1 = new System.Windows.Forms.TextBox();
            this.lblSourceID1 = new System.Windows.Forms.Label();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.pnlList = new System.Windows.Forms.Panel();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkIncludeCleared = new System.Windows.Forms.CheckBox();
            this.pnlTranTop.SuspendLayout();
            this.pnlTranCenter.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTranTop
            // 
            this.pnlTranTop.Size = new System.Drawing.Size(742, 68);
            // 
            // pnlTranCenter
            // 
            this.pnlTranCenter.Controls.Add(this.pnlList);
            this.pnlTranCenter.Controls.Add(this.pnlComment);
            this.pnlTranCenter.Location = new System.Drawing.Point(0, 68);
            this.pnlTranCenter.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlTranCenter.Size = new System.Drawing.Size(742, 445);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkIncludeCleared);
            this.grpOption.Controls.Add(this.txtSourceID1);
            this.grpOption.Controls.Add(this.lblSourceID1);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Size = new System.Drawing.Size(736, 68);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Clear";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Clear Lot Alarm";
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
            columnHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer2.Name = "columnHeaderRenderer2";
            columnHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer2.TextRotationAngle = 0D;
            rowHeaderRenderer2.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer2.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer2.Name = "rowHeaderRenderer2";
            rowHeaderRenderer2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer2.TextRotationAngle = 0D;
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
            // 
            // txtSourceID1
            // 
            this.txtSourceID1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSourceID1.Location = new System.Drawing.Point(119, 15);
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
            this.lblSourceID1.Location = new System.Drawing.Point(15, 19);
            this.lblSourceID1.Name = "lblSourceID1";
            this.lblSourceID1.Size = new System.Drawing.Size(64, 13);
            this.lblSourceID1.TabIndex = 0;
            this.lblSourceID1.Text = "Source ID 1";
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(470, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(257, 20);
            this.pnlPeriod.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(55, 0);
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
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.Location = new System.Drawing.Point(466, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.grpComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(0, 408);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlComment.Size = new System.Drawing.Size(742, 37);
            this.pnlComment.TabIndex = 0;
            // 
            // grpComment
            // 
            this.grpComment.Controls.Add(this.txtComment);
            this.grpComment.Controls.Add(this.lblComment);
            this.grpComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpComment.Location = new System.Drawing.Point(3, 0);
            this.grpComment.Name = "grpComment";
            this.grpComment.Size = new System.Drawing.Size(736, 37);
            this.grpComment.TabIndex = 0;
            this.grpComment.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(120, 12);
            this.txtComment.MaxLength = 400;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(604, 20);
            this.txtComment.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(15, 14);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 0;
            this.lblComment.Text = "Comment";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.spdList);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(0, 3);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(742, 405);
            this.pnlList.TabIndex = 1;
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
            this.spdList.HorizontalScrollBar.TabIndex = 48;
            this.spdList.Location = new System.Drawing.Point(0, 0);
            this.spdList.Name = "spdList";
            namedStyle1.BackColor = System.Drawing.SystemColors.Control;
            namedStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle1.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Renderer = columnHeaderRenderer3;
            namedStyle1.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle2.BackColor = System.Drawing.SystemColors.Control;
            namedStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle2.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Renderer = rowHeaderRenderer3;
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
            this.spdList.Size = new System.Drawing.Size(742, 405);
            this.spdList.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdList.TabIndex = 0;
            this.spdList.TabStop = false;
            this.spdList.TextTipDelay = 200;
            this.spdList.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdList.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.VerticalScrollBar.Name = "";
            this.spdList.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdList.VerticalScrollBar.TabIndex = 49;
            this.spdList.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdList.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdList_CellClick);
            this.spdList.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdList_CellDoubleClick);
            this.spdList.SetViewportLeftColumn(0, 0, 2);
            this.spdList.SetActiveViewport(0, 0, -1);
            // 
            // spdList_Sheet1
            // 
            this.spdList_Sheet1.Reset();
            spdList_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdList_Sheet1.ColumnCount = 26;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).CellType = checkBoxCellType1;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Alarm ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Alarm Type";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Resource";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Res Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Lot ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Lot Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Alarm Level";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Alarm Subject";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Alarm Message";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Area";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Sub Area";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Ack Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Ack Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Ack User";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Clear Flag";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Clear Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Clear User";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Clear Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Source ID 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Source Desc 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Source ID 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Source Desc 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Source ID 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Source Desc 3";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            checkBoxCellType2.BackgroundImage = new FarPoint.Win.Picture(null, FarPoint.Win.RenderStyle.Normal, System.Drawing.Color.Empty, 0, FarPoint.Win.HorizontalAlignment.Left, FarPoint.Win.VerticalAlignment.Center);
            this.spdList_Sheet1.Columns.Get(0).CellType = checkBoxCellType2;
            this.spdList_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 20F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Alarm ID";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 101F;
            this.spdList_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 103F;
            this.spdList_Sheet1.Columns.Get(3).Label = "Alarm Type";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 70F;
            this.spdList_Sheet1.Columns.Get(4).Label = "Resource";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 82F;
            this.spdList_Sheet1.Columns.Get(5).Label = "Res Hist Seq";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 72F;
            this.spdList_Sheet1.Columns.Get(6).Label = "Lot ID";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 73F;
            this.spdList_Sheet1.Columns.Get(7).Label = "Lot Hist Seq";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 72F;
            this.spdList_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Label = "Alarm Level";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 73F;
            this.spdList_Sheet1.Columns.Get(9).Label = "Alarm Subject";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 100F;
            this.spdList_Sheet1.Columns.Get(10).Label = "Alarm Message";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 150F;
            this.spdList_Sheet1.Columns.Get(11).Label = "Area";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Label = "Sub Area";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Label = "Ack Flag";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Label = "Ack Time";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Label = "Ack User";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Label = "Clear Flag";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Label = "Clear Time";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 82F;
            this.spdList_Sheet1.Columns.Get(18).Label = "Clear User";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Label = "Clear Comment";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 122F;
            this.spdList_Sheet1.Columns.Get(20).Label = "Source ID 1";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 73F;
            this.spdList_Sheet1.Columns.Get(21).Label = "Source Desc 1";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 93F;
            this.spdList_Sheet1.Columns.Get(22).Label = "Source ID 2";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 73F;
            this.spdList_Sheet1.Columns.Get(23).Label = "Source Desc 2";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 93F;
            this.spdList_Sheet1.Columns.Get(24).Label = "Source ID 3";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 73F;
            this.spdList_Sheet1.Columns.Get(25).Label = "Source Desc 3";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 93F;
            this.spdList_Sheet1.FrozenColumnCount = 2;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Alarm Level";
            this.ColumnHeader1.Width = 70;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Alarm Type";
            this.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ColumnHeader2.Width = 70;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Resource";
            this.ColumnHeader4.Width = 80;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Lot ID";
            this.ColumnHeader5.Width = 80;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Create Time";
            this.ColumnHeader6.Width = 80;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Alarm Message";
            this.ColumnHeader7.Width = 150;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Source ID 1";
            this.ColumnHeader8.Width = 80;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Source Desc 1";
            this.ColumnHeader9.Width = 80;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Source ID 2";
            this.ColumnHeader10.Width = 80;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "Source Desc 2";
            this.ColumnHeader11.Width = 80;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Source ID 3";
            this.ColumnHeader12.Width = 80;
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Source Desc 3";
            this.ColumnHeader13.Width = 80;
            // 
            // chkIncludeCleared
            // 
            this.chkIncludeCleared.AutoSize = true;
            this.chkIncludeCleared.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkIncludeCleared.Location = new System.Drawing.Point(119, 43);
            this.chkIncludeCleared.Name = "chkIncludeCleared";
            this.chkIncludeCleared.Size = new System.Drawing.Size(135, 18);
            this.chkIncludeCleared.TabIndex = 2;
            this.chkIncludeCleared.Text = "Include Cleared Alarm";
            // 
            // frmALMTranClearAlarm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmALMTranClearAlarm";
            this.Text = "Clear Alarm";
            this.Activated += new System.EventHandler(this.frmALMTranClearAlarm_Activated);
            this.Load += new System.EventHandler(this.frmALMTranClearAlarm_Load);
            this.pnlTranTop.ResumeLayout(false);
            this.pnlTranCenter.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            this.pnlList.ResumeLayout(false);
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
                    
                case "Process":
                    int iRow;
                    for (iRow = 0; iRow < spdList.ActiveSheet.RowCount; iRow++)
                    {
                        if (spdList.ActiveSheet.Cells[iRow, 0].Value != null && (bool)spdList.ActiveSheet.Cells[iRow, 0].Value == true)
                        {
                            return true;
                        }
                    }
                    return false;
                    
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
            in_node.AddChar("CLEAR_FLAG", (chkIncludeCleared.Checked == true ? ' ' : 'N'));

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

                    iCol = 1;
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

                }

                in_node.SetString("NEXT_SOURCE_ID_1", out_node.GetString("NEXT_SOURCE_ID_1"));
                in_node.SetString("NEXT_TO_TIME",  out_node.GetString("NEXT_TO_TIME"));

            } while (in_node.GetString("NEXT_TO_TIME") != "" ||
                     in_node.GetString("NEXT_SOURCE_ID_1") != "");

            MPCF.FitColumnHeader(spdList);
            return true;
        }
        
        // Clear_Alarm()
        //       -   Clear Lot Alarm History
        // Return Value
        //       -
        // Arguments
        //       -
        private bool Clear_Alarm()
        {
            TRSNode in_node = new TRSNode("CLEAR_ALARM_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode list_node;
            int iRow;

            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                for (iRow = 0; iRow < spdList.ActiveSheet.RowCount; iRow++)
                {
                    if (spdList.ActiveSheet.Cells[iRow, 0].Value != null && (bool)spdList.ActiveSheet.Cells[iRow, 0].Value == true)
                    {
                        if (MPCF.Trim(spdList.Sheets[0].Cells[iRow, 12].Value) == "Y")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(196));
                            continue;
                        }

                        list_node = in_node.AddNode("ALARM_LIST");
                        list_node.AddString("SOURCE_ID_1", MPCF.Trim(spdList.Sheets[0].Cells[iRow, 20].Value));
                        list_node.AddString("ALARM_ID", MPCF.Trim(spdList.Sheets[0].Cells[iRow, 1].Value));
                        list_node.AddString("TRAN_TIME", MPCF.DestroyDateFormat(MPCF.Trim(spdList.Sheets[0].Cells[iRow, 2].Value)));
                        list_node.AddString("RES_ID", MPCF.Trim(spdList.Sheets[0].Cells[iRow, 4].Value));

                        list_node.AddString("CLEAR_COMMENT", MPCF.Trim(txtComment.Text));
                    }
                }

                if (MPCR.CallService("ALM", "ALM_Clear_Alarm", in_node, ref out_node) == false)
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
                return this.txtSourceID1;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmALMTranClearAlarm_Load(object sender, System.EventArgs e)
        {
            
            dtpFrom.Value = dtpTo.Value.AddDays(- 7);
            
        }
        
        private void frmALMTranClearAlarm_Activated(object sender, System.EventArgs e)
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
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            
            if (spdList.Sheets[0].RowCount < 1)
            {
                return;
            }

            if (CheckCondition("Process") == true)
            {
                if (Clear_Alarm() == true)
                {
                    txtComment.Text = "";
                    View_Alarm_History_List();
                }
            }            
        }

        private void spdList_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (spdList.ActiveSheet.Cells[e.Row, 0].Value == null)
            {
                spdList.ActiveSheet.Cells[e.Row, 0].Value = true;
            }
            else
            {
                spdList.ActiveSheet.Cells[e.Row, 0].Value = !((bool)spdList.ActiveSheet.Cells[e.Row, 0].Value);
            }
        }

        private void spdList_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (e.ColumnHeader == true && e.Column == 0)
            {
                if (spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Value == null)
                {
                    spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Value = true;

                    for(int iRow = 0; iRow < spdList.ActiveSheet.RowCount; iRow++)
                    {
                        spdList.ActiveSheet.Cells[iRow, 0].Value = true;
                    }
                }
                else
                {
                    spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Value = !((bool)spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Value);

                    for(int iRow = 0; iRow < spdList.ActiveSheet.RowCount; iRow++)
                    {
                        spdList.ActiveSheet.Cells[iRow, 0].Value = (bool)spdList.ActiveSheet.ColumnHeader.Cells[0, 0].Value;
                    }
                }
            }
        }
        
    }
    //#End If
}
