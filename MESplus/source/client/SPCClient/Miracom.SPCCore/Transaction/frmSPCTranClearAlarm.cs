
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCTranClearAlarm.vb
//   Description : Clear Alarm
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition : Check the conditions before transaction
//       - Clear_Alarm : Clear Alarm
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCTranClearAlarm : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranClearAlarm()
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
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnView;
        internal System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.GroupBox grpTop;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccToDate;
        internal System.Windows.Forms.Label lblA;
        internal Infragistics.Win.UltraWinSchedule.UltraCalendarCombo uccFromDate;
        internal System.Windows.Forms.Label lblPeriod;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        internal System.Windows.Forms.Label lblChartID;
        internal System.Windows.Forms.Panel pnlMid;
        internal FarPoint.Win.Spread.FpSpread spdData;
        internal FarPoint.Win.Spread.SheetView spdData_Sheet1;
        internal System.Windows.Forms.Panel pnlComment;
        protected System.Windows.Forms.GroupBox grpComment;
        protected System.Windows.Forms.Label lblComment;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtComment;
        internal System.Windows.Forms.Button btnFiltering;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartSetID;
        internal System.Windows.Forms.Label lblChartSet;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranClearAlarm));
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton2 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.cdvChartSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartSet = new System.Windows.Forms.Label();
            this.btnFiltering = new System.Windows.Forms.Button();
            this.uccToDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblA = new System.Windows.Forms.Label();
            this.uccFromDate = new Infragistics.Win.UltraWinSchedule.UltraCalendarCombo();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.pnlMid = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.grpComment = new System.Windows.Forms.GroupBox();
            this.txtComment = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblComment = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFromDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            this.pnlMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.pnlComment.SuspendLayout();
            this.grpComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(466, 8);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClear.Location = new System.Drawing.Point(558, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 26);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(650, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpTop);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTop.Size = new System.Drawing.Size(742, 73);
            this.pnlTop.TabIndex = 0;
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.cdvChartSetID);
            this.grpTop.Controls.Add(this.lblChartSet);
            this.grpTop.Controls.Add(this.btnFiltering);
            this.grpTop.Controls.Add(this.uccToDate);
            this.grpTop.Controls.Add(this.lblA);
            this.grpTop.Controls.Add(this.uccFromDate);
            this.grpTop.Controls.Add(this.lblPeriod);
            this.grpTop.Controls.Add(this.cdvChartID);
            this.grpTop.Controls.Add(this.lblChartID);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(736, 73);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // cdvChartSetID
            // 
            this.cdvChartSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartSetID.BtnToolTipText = "";
            this.cdvChartSetID.DescText = "";
            this.cdvChartSetID.DisplaySubItemIndex = -1;
            this.cdvChartSetID.DisplayText = "";
            this.cdvChartSetID.Focusing = null;
            this.cdvChartSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartSetID.Index = 0;
            this.cdvChartSetID.IsViewBtnImage = false;
            this.cdvChartSetID.Location = new System.Drawing.Point(120, 17);
            this.cdvChartSetID.MaxLength = 30;
            this.cdvChartSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.Name = "cdvChartSetID";
            this.cdvChartSetID.ReadOnly = false;
            this.cdvChartSetID.SearchSubItemIndex = 0;
            this.cdvChartSetID.SelectedDescIndex = -1;
            this.cdvChartSetID.SelectedSubItemIndex = -1;
            this.cdvChartSetID.SelectionStart = 0;
            this.cdvChartSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvChartSetID.SmallImageList = null;
            this.cdvChartSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartSetID.TabIndex = 1;
            this.cdvChartSetID.TextBoxToolTipText = "";
            this.cdvChartSetID.TextBoxWidth = 200;
            this.cdvChartSetID.VisibleButton = true;
            this.cdvChartSetID.VisibleColumnHeader = false;
            this.cdvChartSetID.VisibleDescription = false;
            this.cdvChartSetID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartSetID_SelectedItemChanged);
            this.cdvChartSetID.ButtonPress += new System.EventHandler(this.cdvChartSetID_ButtonPress);
            this.cdvChartSetID.TextBoxTextChanged += new System.EventHandler(this.cdvChartSetID_TextBoxTextChanged);
            // 
            // lblChartSet
            // 
            this.lblChartSet.AutoSize = true;
            this.lblChartSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartSet.Location = new System.Drawing.Point(15, 20);
            this.lblChartSet.Name = "lblChartSet";
            this.lblChartSet.Size = new System.Drawing.Size(65, 13);
            this.lblChartSet.TabIndex = 0;
            this.lblChartSet.Text = "Chart Set ID";
            // 
            // btnFiltering
            // 
            this.btnFiltering.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering.Image")));
            this.btnFiltering.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering.Location = new System.Drawing.Point(324, 40);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering.TabIndex = 4;
            this.btnFiltering.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // uccToDate
            // 
            this.uccToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccToDate.DateButtons.Add(dateButton1);
            this.uccToDate.Location = new System.Drawing.Point(629, 17);
            this.uccToDate.Name = "uccToDate";
            this.uccToDate.NonAutoSizeHeight = 21;
            this.uccToDate.Size = new System.Drawing.Size(88, 21);
            this.uccToDate.TabIndex = 8;
            this.uccToDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // lblA
            // 
            this.lblA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblA.Location = new System.Drawing.Point(613, 20);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(12, 14);
            this.lblA.TabIndex = 7;
            this.lblA.Text = "~";
            // 
            // uccFromDate
            // 
            this.uccFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uccFromDate.DateButtons.Add(dateButton2);
            this.uccFromDate.Location = new System.Drawing.Point(521, 17);
            this.uccFromDate.Name = "uccFromDate";
            this.uccFromDate.NonAutoSizeHeight = 21;
            this.uccFromDate.Size = new System.Drawing.Size(88, 21);
            this.uccFromDate.TabIndex = 6;
            this.uccFromDate.Value = new System.DateTime(2005, 5, 9, 0, 0, 0, 0);
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPeriod.Location = new System.Drawing.Point(453, 20);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(43, 13);
            this.lblPeriod.TabIndex = 5;
            this.lblPeriod.Text = "Period";
            // 
            // cdvChartID
            // 
            this.cdvChartID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartID.BtnToolTipText = "";
            this.cdvChartID.DescText = "";
            this.cdvChartID.DisplaySubItemIndex = -1;
            this.cdvChartID.DisplayText = "";
            this.cdvChartID.Focusing = null;
            this.cdvChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartID.Index = 0;
            this.cdvChartID.IsViewBtnImage = false;
            this.cdvChartID.Location = new System.Drawing.Point(120, 42);
            this.cdvChartID.MaxLength = 25;
            this.cdvChartID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartID.Name = "cdvChartID";
            this.cdvChartID.ReadOnly = false;
            this.cdvChartID.SearchSubItemIndex = 0;
            this.cdvChartID.SelectedDescIndex = -1;
            this.cdvChartID.SelectedSubItemIndex = -1;
            this.cdvChartID.SelectionStart = 0;
            this.cdvChartID.Size = new System.Drawing.Size(200, 20);
            this.cdvChartID.SmallImageList = null;
            this.cdvChartID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartID.TabIndex = 3;
            this.cdvChartID.TextBoxToolTipText = "";
            this.cdvChartID.TextBoxWidth = 200;
            this.cdvChartID.VisibleButton = true;
            this.cdvChartID.VisibleColumnHeader = false;
            this.cdvChartID.VisibleDescription = false;
            this.cdvChartID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartID_SelectedItemChanged);
            this.cdvChartID.ButtonPress += new System.EventHandler(this.cdvChartID_ButtonPress);
            this.cdvChartID.TextBoxTextChanged += new System.EventHandler(this.cdvChartID_TextBoxTextChanged);
            // 
            // lblChartID
            // 
            this.lblChartID.AutoSize = true;
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 45);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(46, 13);
            this.lblChartID.TabIndex = 2;
            this.lblChartID.Text = "Chart ID";
            // 
            // pnlMid
            // 
            this.pnlMid.Controls.Add(this.spdData);
            this.pnlMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMid.Location = new System.Drawing.Point(0, 73);
            this.pnlMid.Name = "pnlMid";
            this.pnlMid.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlMid.Size = new System.Drawing.Size(742, 396);
            this.pnlMid.TabIndex = 2;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.Location = new System.Drawing.Point(3, 3);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(736, 393);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 28;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Chart ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Alarm ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Tran Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "X/R";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "OOC Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Alarm Level";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Alarm Message";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Ack Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Ack Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Ack User";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Clear Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Clear Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Clear User";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Clear Comment";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "L/R";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Lot ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Mat ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Mat Ver";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Flow";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Oper";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Proc Oper";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Res ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Proc Res ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Event ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Character";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Unit Seq";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(0).Label = "Chart ID";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 100F;
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Label = "Seq";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 30F;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(2).Label = "Alarm ID";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 80F;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(3).Label = "Tran Time";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 140F;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Label = "X/R";
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 30F;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Label = "OOC Type";
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(6).Label = "Alarm Level";
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 70F;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(7).Label = "Alarm Message";
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 200F;
            this.spdData_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Label = "Ack Flag";
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 55F;
            this.spdData_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Label = "Ack Time";
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Width = 140F;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Label = "Ack User";
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 85F;
            this.spdData_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Label = "Clear Flag";
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 64F;
            this.spdData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(12).Label = "Clear Time";
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Width = 140F;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(13).Label = "Clear User";
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 90F;
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(14).Label = "Clear Comment";
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Width = 200F;
            this.spdData_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Label = "L/R";
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(15).Width = 30F;
            this.spdData_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(16).Label = "Lot ID";
            this.spdData_Sheet1.Columns.Get(16).Locked = true;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Width = 100F;
            this.spdData_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(17).Label = "Mat ID";
            this.spdData_Sheet1.Columns.Get(17).Locked = true;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).Width = 100F;
            this.spdData_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).Label = "Mat Ver";
            this.spdData_Sheet1.Columns.Get(18).Locked = true;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).Width = 50F;
            this.spdData_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(19).Label = "Flow";
            this.spdData_Sheet1.Columns.Get(19).Locked = true;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).Width = 70F;
            this.spdData_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(20).Label = "Oper";
            this.spdData_Sheet1.Columns.Get(20).Locked = true;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).Width = 80F;
            this.spdData_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(21).Label = "Proc Oper";
            this.spdData_Sheet1.Columns.Get(21).Locked = true;
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(21).Width = 80F;
            this.spdData_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(22).Label = "Res ID";
            this.spdData_Sheet1.Columns.Get(22).Locked = true;
            this.spdData_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).Width = 70F;
            this.spdData_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(23).Label = "Proc Res ID";
            this.spdData_Sheet1.Columns.Get(23).Locked = true;
            this.spdData_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(23).Width = 70F;
            this.spdData_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(24).Label = "Event ID";
            this.spdData_Sheet1.Columns.Get(24).Locked = true;
            this.spdData_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(24).Width = 100F;
            this.spdData_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(25).Label = "Character";
            this.spdData_Sheet1.Columns.Get(25).Locked = true;
            this.spdData_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(25).Width = 100F;
            this.spdData_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(26).Label = "Unit ID";
            this.spdData_Sheet1.Columns.Get(26).Locked = true;
            this.spdData_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(26).Width = 100F;
            this.spdData_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(27).Label = "Unit Seq";
            this.spdData_Sheet1.Columns.Get(27).Locked = true;
            this.spdData_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(27).Width = 58F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.grpComment);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(0, 469);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlComment.Size = new System.Drawing.Size(742, 37);
            this.pnlComment.TabIndex = 1;
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
            this.grpComment.TabIndex = 1;
            this.grpComment.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(120, 11);
            this.txtComment.MaxLength = 200;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(604, 20);
            this.txtComment.TabIndex = 2;
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
            // frmSPCTranClearAlarm
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlMid);
            this.Controls.Add(this.pnlComment);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCTranClearAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clear Alarm";
            this.Load += new System.EventHandler(this.frmSPCTranClearAlarm_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uccFromDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            this.pnlMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.pnlComment.ResumeLayout(false);
            this.grpComment.ResumeLayout(false);
            this.grpComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool CheckCondition()
        {
            
            try
            {
                if (this.uccFromDate.Value == null)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccFromDate.Focus();
                    return false;
                }
                
                if (this.uccToDate.Value == null)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                    uccToDate.Focus();
                    return false;
                }
                
                if (((DateTime)uccFromDate.Value) >= ((DateTime)uccToDate.Value))
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(214));
                    return false;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Clear_Alarm()
        //       - Clear Alarm Message
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool Clear_Alarm()
        {
            TRSNode in_node = new TRSNode("Clear_Alarm_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(spdData.Sheets[0].Cells[spdData.Sheets[0].ActiveRowIndex, 0].Value));
                in_node.AddInt("HIST_SEQ", (int)spdData.Sheets[0].Cells[spdData.Sheets[0].ActiveRowIndex, 1].Value);
                in_node.AddString("CLEAR_COMMENT", MPCF.Trim(txtComment.Text));

                if (MPCR.CallService("SPC", "SPC_Clear_Alarm", in_node, ref out_node) == false)
                {
                    return false;
                }
                MPCR.ShowSuccessMsg(out_node);
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.Clear_Alarm()\n" + ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvChartID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        private void ChartInfo()
        {
            
            try
            {
                btnView.PerformClick();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.ChartInfo()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void frmSPCTranClearAlarm_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                uccFromDate.Value = DateTime.Today.AddMonths(- 1);
                uccToDate.Value = DateTime.Today;
                
                cdvChartID.Text = modSPCFunctions.GetFilterKey();
                
                if (MPCF.Trim(MPGV.gsChartID) != "")
                {
                    cdvChartID.Text = MPGV.gsChartID;
                    ChartInfo();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.frmSPCTranClearAlarm_Load()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartID.Init();
                MPCF.InitListView(cdvChartID.GetListView);
                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartID.SelectedSubItemIndex = 0;
                if (cdvChartSetID.Text != "")
                {
                    SPCLIST.ViewSPCAttachChartList(cdvChartID.GetListView, '1', cdvChartSetID.Text, "");
                }
                else
                {
                    SPCLIST.ViewChartList(cdvChartID.GetListView, '2', "", 0,"", "", "", ' ', ' ', MPCF.Trim(cdvChartID.Text), "", -1, -1, null, "");
                }
                cdvChartID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.cdvChartID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                MPCF.FieldClear(this.grpTop, cdvChartID, cdvChartSetID, null, null, null, false);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.cdvChartID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnView_Click(object sender, System.EventArgs e)
        {
            
            char c_step;
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                if (cdvChartID.Text != "")
                {
                    c_step = '2';
                }
                else if (cdvChartID.Text == "" && cdvChartSetID.Text != "")
                {
                    c_step = '3';
                }
                else
                {
                    c_step = '1';
                }
                SPCLIST.ViewSPCAlarmHistory(spdData, c_step, MPCF.Trim(cdvChartID.Text), MPCF.DateFromString(uccFromDate), MPCF.DateToString(uccToDate), 'Y', cdvChartSetID.Text);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnClear_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (spdData.Sheets[0].RowCount < 1)
                {
                    return;
                }
                
                if (spdData.Sheets[0].ActiveRow == null)
                {
                    return;
                }
                
                if (Clear_Alarm() == true)
                {
                    txtComment.Text = "";
                    btnView.PerformClick();
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.btnClear_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.cdvChartID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                form.StartPosition = FormStartPosition.CenterParent;
                if (cdvChartSetID.Text != "")
                {
                    form.cdvChartSetID.Text = cdvChartSetID.Text;
                    form.cdvChartSetID.Enabled = false;
                }
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.lisChart.SelectedItems.Count > 0)
                    {
                        cdvChartID.Text = form.lisChart.SelectedItems[0].SubItems[1].Text;
                        ChartInfo();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranClearAlarm.btnFiltering_Click()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvChartSetID.Init();
                MPCF.InitListView(cdvChartSetID.GetListView);
                cdvChartSetID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvChartSetID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvChartSetID.SelectedSubItemIndex = 0;
                SPCLIST.ViewChartSetList(cdvChartSetID.GetListView, '1', "", 0, "", "", ' ', "", -1, -1, "");
                cdvChartSetID.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartSetID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                cdvChartID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartSetID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(spdData, true);
                cdvChartID.Text = "";
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.cdvChartSetID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    
    //#End If
    
}
