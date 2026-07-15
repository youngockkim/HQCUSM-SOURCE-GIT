
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
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASViewResourceDownHistory.vb
//   Description : MES Cient Form View Resource Down History
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
//       - 2004-08-12 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------



namespace Miracom.RASCore
{
    public class frmRASViewResourceDownHistory : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewResourceDownHistory()
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
        private System.Windows.Forms.Label lblTo;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private FarPoint.Win.Spread.FpSpread spdList;
        private FarPoint.Win.Spread.SheetView spdList_Sheet1;
        private System.Windows.Forms.CheckBox chkOnlyDownHistory;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEventID;
        private System.Windows.Forms.Label lblEvent;
        public System.Windows.Forms.Button btnUpdate;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.chkOnlyDownHistory = new System.Windows.Forms.CheckBox();
            this.cdvEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.spdList = new FarPoint.Win.Spread.FpSpread();
            this.spdList_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(446, 8);
            this.btnView.TabIndex = 0;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvEventID);
            this.grpOption.Controls.Add(this.lblEvent);
            this.grpOption.Controls.Add(this.chkOnlyDownHistory);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.lblResID);
            this.grpOption.Controls.Add(this.pnlPeriod);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.spdList);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Resource Down History";
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
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.DescText = "";
            this.cdvResID.DisplaySubItemIndex = -1;
            this.cdvResID.DisplayText = "";
            this.cdvResID.Focusing = null;
            this.cdvResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvResID.Index = 0;
            this.cdvResID.IsViewBtnImage = false;
            this.cdvResID.Location = new System.Drawing.Point(120, 16);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(200, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 200;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            this.lblResID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkOnlyDownHistory
            // 
            this.chkOnlyDownHistory.AutoSize = true;
            this.chkOnlyDownHistory.Location = new System.Drawing.Point(470, 43);
            this.chkOnlyDownHistory.Name = "chkOnlyDownHistory";
            this.chkOnlyDownHistory.Size = new System.Drawing.Size(113, 17);
            this.chkOnlyDownHistory.TabIndex = 5;
            this.chkOnlyDownHistory.Text = "Only Down History";
            // 
            // cdvEventID
            // 
            this.cdvEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEventID.BtnToolTipText = "";
            this.cdvEventID.DescText = "";
            this.cdvEventID.DisplaySubItemIndex = -1;
            this.cdvEventID.DisplayText = "";
            this.cdvEventID.Focusing = null;
            this.cdvEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEventID.Index = 0;
            this.cdvEventID.IsViewBtnImage = false;
            this.cdvEventID.Location = new System.Drawing.Point(120, 40);
            this.cdvEventID.MaxLength = 12;
            this.cdvEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.Name = "cdvEventID";
            this.cdvEventID.ReadOnly = false;
            this.cdvEventID.SearchSubItemIndex = 0;
            this.cdvEventID.SelectedDescIndex = -1;
            this.cdvEventID.SelectedSubItemIndex = -1;
            this.cdvEventID.SelectionStart = 0;
            this.cdvEventID.Size = new System.Drawing.Size(200, 20);
            this.cdvEventID.SmallImageList = null;
            this.cdvEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEventID.TabIndex = 3;
            this.cdvEventID.TextBoxToolTipText = "";
            this.cdvEventID.TextBoxWidth = 200;
            this.cdvEventID.VisibleButton = true;
            this.cdvEventID.VisibleColumnHeader = false;
            this.cdvEventID.VisibleDescription = false;
            this.cdvEventID.ButtonPress += new System.EventHandler(this.cdvEventID_ButtonPress);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(16, 44);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(49, 13);
            this.lblEvent.TabIndex = 2;
            this.lblEvent.Text = "Event ID";
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spdList
            // 
            this.spdList.AccessibleDescription = "";
            this.spdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdList.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdList.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdList.HorizontalScrollBar.Name = "";
            this.spdList.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdList.HorizontalScrollBar.TabIndex = 2;
            this.spdList.Location = new System.Drawing.Point(0, 5);
            this.spdList.Name = "spdList";
            this.spdList.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdList.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdList.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdList_Sheet1});
            this.spdList.Size = new System.Drawing.Size(742, 437);
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
            spdList_Sheet1.ColumnCount = 45;
            spdList_Sheet1.RowCount = 5;
            this.spdList_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Res ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Down Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Down Event ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Down Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Down Sys Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Down Pri Sts";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Down New Sts 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Down New Sts 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Down New Sts 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Down New Sts 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Down New Sts 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Down New Sts 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Down New Sts 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Down New Sts 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Down New Sts 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Down New Sts 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Down Tran User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Down Tran Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Down Interval";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Up Hist Seq";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Up Event ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Up Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Up Sys Tran Time";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Up Pri Sts";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Up New Sts 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Up New Sts 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Up New Sts 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Up New Sts 4";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Up New Sts 5";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Up New Sts 6";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Up New Sts 7";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Up New Sts 8";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Up New Sts 9";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Up New Sts 10";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Up Tran User ID";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Up Tran Comment";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "User ID 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "User Time 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "User Comment 1";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "User ID 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "User Time 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "User Comment 2";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "User ID 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "User Time 3";
            this.spdList_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "User Comment 3";
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdList_Sheet1.Columns.Get(0).Label = "Res ID";
            this.spdList_Sheet1.Columns.Get(0).Locked = true;
            this.spdList_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdList_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(0).Width = 70F;
            this.spdList_Sheet1.Columns.Get(1).Label = "Down Hist Seq";
            this.spdList_Sheet1.Columns.Get(1).Locked = true;
            this.spdList_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(1).Width = 90F;
            this.spdList_Sheet1.Columns.Get(2).Label = "Down Event ID";
            this.spdList_Sheet1.Columns.Get(2).Locked = true;
            this.spdList_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(2).Width = 100F;
            this.spdList_Sheet1.Columns.Get(3).Label = "Down Tran Time";
            this.spdList_Sheet1.Columns.Get(3).Locked = true;
            this.spdList_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(3).Width = 125F;
            this.spdList_Sheet1.Columns.Get(4).Label = "Down Sys Tran Time";
            this.spdList_Sheet1.Columns.Get(4).Locked = true;
            this.spdList_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(4).Width = 125F;
            this.spdList_Sheet1.Columns.Get(5).Label = "Down Pri Sts";
            this.spdList_Sheet1.Columns.Get(5).Locked = true;
            this.spdList_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(5).Width = 100F;
            this.spdList_Sheet1.Columns.Get(6).Label = "Down New Sts 1";
            this.spdList_Sheet1.Columns.Get(6).Locked = true;
            this.spdList_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(6).Width = 100F;
            this.spdList_Sheet1.Columns.Get(7).Label = "Down New Sts 2";
            this.spdList_Sheet1.Columns.Get(7).Locked = true;
            this.spdList_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(7).Width = 100F;
            this.spdList_Sheet1.Columns.Get(8).Label = "Down New Sts 3";
            this.spdList_Sheet1.Columns.Get(8).Locked = true;
            this.spdList_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(8).Width = 100F;
            this.spdList_Sheet1.Columns.Get(9).Label = "Down New Sts 4";
            this.spdList_Sheet1.Columns.Get(9).Locked = true;
            this.spdList_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(9).Width = 100F;
            this.spdList_Sheet1.Columns.Get(10).Label = "Down New Sts 5";
            this.spdList_Sheet1.Columns.Get(10).Locked = true;
            this.spdList_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(10).Width = 100F;
            this.spdList_Sheet1.Columns.Get(11).Label = "Down New Sts 6";
            this.spdList_Sheet1.Columns.Get(11).Locked = true;
            this.spdList_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(11).Width = 100F;
            this.spdList_Sheet1.Columns.Get(12).Label = "Down New Sts 7";
            this.spdList_Sheet1.Columns.Get(12).Locked = true;
            this.spdList_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(12).Width = 100F;
            this.spdList_Sheet1.Columns.Get(13).Label = "Down New Sts 8";
            this.spdList_Sheet1.Columns.Get(13).Locked = true;
            this.spdList_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(13).Width = 100F;
            this.spdList_Sheet1.Columns.Get(14).Label = "Down New Sts 9";
            this.spdList_Sheet1.Columns.Get(14).Locked = true;
            this.spdList_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(14).Width = 100F;
            this.spdList_Sheet1.Columns.Get(15).Label = "Down New Sts 10";
            this.spdList_Sheet1.Columns.Get(15).Locked = true;
            this.spdList_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(15).Width = 100F;
            this.spdList_Sheet1.Columns.Get(16).Label = "Down Tran User ID";
            this.spdList_Sheet1.Columns.Get(16).Locked = true;
            this.spdList_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(16).Width = 110F;
            this.spdList_Sheet1.Columns.Get(17).Label = "Down Tran Comment";
            this.spdList_Sheet1.Columns.Get(17).Locked = true;
            this.spdList_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(17).Width = 240F;
            this.spdList_Sheet1.Columns.Get(18).Label = "Down Interval";
            this.spdList_Sheet1.Columns.Get(18).Locked = true;
            this.spdList_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(18).Width = 90F;
            this.spdList_Sheet1.Columns.Get(19).Label = "Up Hist Seq";
            this.spdList_Sheet1.Columns.Get(19).Locked = true;
            this.spdList_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(19).Width = 90F;
            this.spdList_Sheet1.Columns.Get(20).Label = "Up Event ID";
            this.spdList_Sheet1.Columns.Get(20).Locked = true;
            this.spdList_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(20).Width = 100F;
            this.spdList_Sheet1.Columns.Get(21).Label = "Up Tran Time";
            this.spdList_Sheet1.Columns.Get(21).Locked = true;
            this.spdList_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(21).Width = 125F;
            this.spdList_Sheet1.Columns.Get(22).Label = "Up Sys Tran Time";
            this.spdList_Sheet1.Columns.Get(22).Locked = true;
            this.spdList_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(22).Width = 125F;
            this.spdList_Sheet1.Columns.Get(23).Label = "Up Pri Sts";
            this.spdList_Sheet1.Columns.Get(23).Locked = true;
            this.spdList_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(23).Width = 100F;
            this.spdList_Sheet1.Columns.Get(24).Label = "Up New Sts 1";
            this.spdList_Sheet1.Columns.Get(24).Locked = true;
            this.spdList_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(24).Width = 100F;
            this.spdList_Sheet1.Columns.Get(25).Label = "Up New Sts 2";
            this.spdList_Sheet1.Columns.Get(25).Locked = true;
            this.spdList_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(25).Width = 100F;
            this.spdList_Sheet1.Columns.Get(26).Label = "Up New Sts 3";
            this.spdList_Sheet1.Columns.Get(26).Locked = true;
            this.spdList_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(26).Width = 100F;
            this.spdList_Sheet1.Columns.Get(27).Label = "Up New Sts 4";
            this.spdList_Sheet1.Columns.Get(27).Locked = true;
            this.spdList_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(27).Width = 100F;
            this.spdList_Sheet1.Columns.Get(28).Label = "Up New Sts 5";
            this.spdList_Sheet1.Columns.Get(28).Locked = true;
            this.spdList_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(28).Width = 100F;
            this.spdList_Sheet1.Columns.Get(29).Label = "Up New Sts 6";
            this.spdList_Sheet1.Columns.Get(29).Locked = true;
            this.spdList_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(29).Width = 100F;
            this.spdList_Sheet1.Columns.Get(30).Label = "Up New Sts 7";
            this.spdList_Sheet1.Columns.Get(30).Locked = true;
            this.spdList_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(30).Width = 100F;
            this.spdList_Sheet1.Columns.Get(31).Label = "Up New Sts 8";
            this.spdList_Sheet1.Columns.Get(31).Locked = true;
            this.spdList_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(31).Width = 100F;
            this.spdList_Sheet1.Columns.Get(32).Label = "Up New Sts 9";
            this.spdList_Sheet1.Columns.Get(32).Locked = true;
            this.spdList_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(32).Width = 100F;
            this.spdList_Sheet1.Columns.Get(33).Label = "Up New Sts 10";
            this.spdList_Sheet1.Columns.Get(33).Locked = true;
            this.spdList_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(33).Width = 100F;
            this.spdList_Sheet1.Columns.Get(34).Label = "Up Tran User ID";
            this.spdList_Sheet1.Columns.Get(34).Locked = true;
            this.spdList_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(34).Width = 110F;
            this.spdList_Sheet1.Columns.Get(35).Label = "Up Tran Comment";
            this.spdList_Sheet1.Columns.Get(35).Locked = true;
            this.spdList_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(35).Width = 240F;
            this.spdList_Sheet1.Columns.Get(36).Label = "User ID 1";
            this.spdList_Sheet1.Columns.Get(36).Locked = true;
            this.spdList_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(36).Width = 100F;
            this.spdList_Sheet1.Columns.Get(37).Label = "User Time 1";
            this.spdList_Sheet1.Columns.Get(37).Locked = true;
            this.spdList_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(37).Width = 125F;
            this.spdList_Sheet1.Columns.Get(38).Label = "User Comment 1";
            this.spdList_Sheet1.Columns.Get(38).Locked = true;
            this.spdList_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(38).Width = 240F;
            this.spdList_Sheet1.Columns.Get(39).Label = "User ID 2";
            this.spdList_Sheet1.Columns.Get(39).Locked = true;
            this.spdList_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(39).Width = 100F;
            this.spdList_Sheet1.Columns.Get(40).Label = "User Time 2";
            this.spdList_Sheet1.Columns.Get(40).Locked = true;
            this.spdList_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(40).Width = 125F;
            this.spdList_Sheet1.Columns.Get(41).Label = "User Comment 2";
            this.spdList_Sheet1.Columns.Get(41).Locked = true;
            this.spdList_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(41).Width = 240F;
            this.spdList_Sheet1.Columns.Get(42).Label = "User ID 3";
            this.spdList_Sheet1.Columns.Get(42).Locked = true;
            this.spdList_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(42).Width = 100F;
            this.spdList_Sheet1.Columns.Get(43).Label = "User Time 3";
            this.spdList_Sheet1.Columns.Get(43).Locked = true;
            this.spdList_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(43).Width = 125F;
            this.spdList_Sheet1.Columns.Get(44).Label = "User Comment 3";
            this.spdList_Sheet1.Columns.Get(44).Locked = true;
            this.spdList_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdList_Sheet1.Columns.Get(44).Width = 240F;
            this.spdList_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdList_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdList_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdList_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdList_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdList_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdList_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdList_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdList_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUpdate.Location = new System.Drawing.Point(538, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(108, 26);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Trouble Resource";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmRASViewResourceDownHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASViewResourceDownHistory";
            this.Text = "View Resource Down History";
            this.Activated += new System.EventHandler(this.frmRASViewResourceDownHistory_Activated);
            this.Load += new System.EventHandler(this.frmRASViewResourceDownHistory_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdList_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL_RES_ID = 0;
        private const int COL_DOWN_HIST_SEQ = 1;
        private const int COL_DOWN_EVENT_ID = 2;
        private const int COL_DOWN_TRAN_TIME = 3;
        private const int COL_DOWN_SYS_TRAN_TIME = 4;
        private const int COL_DOWN_PRI_STS = 5;
        private const int COL_DOWN_NEW_STS_1 = 6;
        private const int COL_DOWN_NEW_STS_2 = 7;
        private const int COL_DOWN_NEW_STS_3 = 8;
        private const int COL_DOWN_NEW_STS_4 = 9;
        private const int COL_DOWN_NEW_STS_5 = 10;
        private const int COL_DOWN_NEW_STS_6 = 11;
        private const int COL_DOWN_NEW_STS_7 = 12;
        private const int COL_DOWN_NEW_STS_8 = 13;
        private const int COL_DOWN_NEW_STS_9 = 14;
        private const int COL_DOWN_NEW_STS_10 = 15;
        private const int COL_DOWN_TRAN_USER_ID = 16;
        private const int COL_DOWN_TRAN_COMMENT = 17;
        private const int COL_DOWN_INTERVAL = 18;
        private const int COL_UP_HIST_SEQ = 19;
        private const int COL_UP_EVENT_ID = 20;
        private const int COL_UP_TRAN_TIME = 21;
        private const int COL_UP_SYS_TRAN_TIME = 22;
        private const int COL_UP_PRI_STS = 23;
        private const int COL_UP_NEW_STS_1 = 24;
        private const int COL_UP_NEW_STS_2 = 25;
        private const int COL_UP_NEW_STS_3 = 26;
        private const int COL_UP_NEW_STS_4 = 27;
        private const int COL_UP_NEW_STS_5 = 28;
        private const int COL_UP_NEW_STS_6 = 29;
        private const int COL_UP_NEW_STS_7 = 30;
        private const int COL_UP_NEW_STS_8 = 31;
        private const int COL_UP_NEW_STS_9 = 32;
        private const int COL_UP_NEW_STS_10 = 33;
        private const int COL_UP_TRAN_USER_ID = 34;
        private const int COL_UP_TRAN_COMMENT = 35;
        private const int COL_USER_ID_1 = 36;
        private const int COL_USER_TIME_1 = 37;
        private const int COL_USER_COMMENT_1 = 38;
        private const int COL_USER_ID_2 = 39;
        private const int COL_USER_TIME_2 = 40;
        private const int COL_USER_COMMENT_2 = 41;
        private const int COL_USER_ID_3 = 42;
        private const int COL_USER_TIME_3 = 43;
        private const int COL_USER_COMMENT_3 = 44;
        
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
        
        // View_Resource_Down_History_List()
        //       - View Lot List By Operation Condition
        // Return Value
        //       -
        // Arguments
        //        -
        //
        private bool View_Resource_Down_History_List()
        {
            TRSNode in_node = new TRSNode("View_Resource_Down_History_In");
            TRSNode out_node;
            int i;
            int iRow;
            
            MPCF.ClearList(spdList, true);

            MPCR.SetInMsg(in_node);
            in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
            in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
            in_node.AddString("EVENT_ID", MPCF.Trim(cdvEventID.Text));
            in_node.AddChar("ONLYDOWNHISTORY", (chkOnlyDownHistory.Checked== true ? 'Y' : ' '));
            in_node.AddString("NEXT_RES_ID", MPCF.Trim(cdvResID.Text));
            in_node.AddInt("NEXT_DOWN_HIST_SEQ", int.MaxValue);

            
            if (in_node.GetString("NEXT_RES_ID") == "")
            {
                in_node.ProcStep = '1';

            }
            else
            {
                in_node.ProcStep = '2';
            }
            
            do
            {
                out_node = new TRSNode("View_Resource_Down_History_Out");

                if (MPCR.CallService("RAS", "RAS_View_Resource_Down_History_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                  iRow = spdList.Sheets[0].RowCount;
                    spdList.Sheets[0].RowCount++;
                    
                    spdList.Sheets[0].Cells[iRow, COL_RES_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_HIST_SEQ].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("DOWN_HIST_SEQ"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_EVENT_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_EVENT_ID"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_TRAN_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("DOWN_TRAN_TIME"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_SYS_TRAN_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("DOWN_SYS_TRAN_TIME"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_PRI_STS].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_PRI_STS"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_1"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_2"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_3"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_4"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_5"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_6"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_7"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_8"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_9"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_NEW_STS_10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_NEW_STS_10"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_TRAN_USER_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_TRAN_USER_ID"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_TRAN_COMMENT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("DOWN_TRAN_COMMENT"));
                    spdList.Sheets[0].Cells[iRow, COL_DOWN_INTERVAL].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("DOWN_INTERVAL"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_HIST_SEQ].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("UP_HIST_SEQ"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_EVENT_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_EVENT_ID"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_TRAN_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UP_TRAN_TIME"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_SYS_TRAN_TIME].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("UP_SYS_TRAN_TIME"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_PRI_STS].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_PRI_STS"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_1"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_2"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_3"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_4"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_5"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_6"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_7"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_8"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_9"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_NEW_STS_10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_NEW_STS_10"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_TRAN_USER_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_TRAN_USER_ID"));
                    spdList.Sheets[0].Cells[iRow, COL_UP_TRAN_COMMENT].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("UP_TRAN_COMMENT"));
                    spdList.Sheets[0].Cells[iRow, COL_USER_ID_1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("USER_ID_1"));
                    spdList.Sheets[0].Cells[iRow, COL_USER_TIME_1].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("USER_TIME_1"));
                    spdList.Sheets[0].Cells[iRow, COL_USER_COMMENT_1].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("USER_COMMENT_1"));
                    spdList.Sheets[0].Cells[iRow, COL_USER_ID_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("USER_ID_2"));
                    spdList.Sheets[0].Cells[iRow, COL_USER_TIME_2].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("USER_TIME_2"));
                    spdList.Sheets[0].Cells[iRow, COL_USER_COMMENT_2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("USER_COMMENT_2"));
                    spdList.Sheets[0].Cells[iRow, COL_USER_ID_3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("USER_ID_3"));
                    spdList.Sheets[0].Cells[iRow, COL_USER_TIME_3].Value = MPCF.MakeDateFormat(out_node.GetList(0)[i].GetString("USER_TIME_3"));
                    spdList.Sheets[0].Cells[iRow, COL_USER_COMMENT_3].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("USER_COMMENT_3"));
                    
                }
                in_node.SetInt("NEXT_DOWN_HIST_SEQ", out_node.GetInt("NEXT_DOWN_HIST_SEQ"));
                in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));

            } while (in_node.GetInt("NEXT_DOWN_HIST_SEQ") != 0 || in_node.GetString("NEXT_RES_ID") != "");
            
            MPCF.FitColumnHeader(spdList);
            
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvResID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASViewResourceDownHistory_Load(object sender, System.EventArgs e)
        {
            
        }
        
        private void frmRASViewResourceDownHistory_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdList, true);
                MPCF.FitColumnHeader(spdList);
                
                dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                dtpTo.Value = DateTime.Today;
                cdvResID.Focus();
                b_load_flag = true;
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("VIEW") == false)
            {
                return;
            }
            if (View_Resource_Down_History_List() == false)
            {
                return;
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;

            sCond = "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) +" ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
            if (cdvResID.Text != "")
            {
                sCond = sCond + "\r" + "Resource ID : " + cdvResID.Text;
            }
            if (cdvEventID.Text != "")
            {
                sCond = sCond + "\r" + "Event ID : " + cdvEventID.Text;
            }

            if (MPCF.ExportToExcel(spdList, this.Text, sCond, true, true, true, -1, -1) == false)
            {
                return;
            }
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            Form SForm;
            string sResID;
            
            try
            {
                if (spdList.Sheets[0].RowCount < 1)
                {
                    return;
                }
                if (spdList.Sheets[0].ActiveRowIndex < 0)
                {
                    return;
                }
                sResID = MPCF.Trim(spdList.Sheets[0].Cells[spdList.Sheets[0].ActiveRowIndex, 0].Value);

                SForm = MPCF.GetChildForm(MPGV.gfrmMDI, "frmRASTranTroubleResource");

                if (SForm == null)
                {
                    SForm = new frmRASTranTroubleResource();
                    SForm.MdiParent = MPGV.gfrmMDI;
                    ((frmRASTranTroubleResource)SForm).txtResID.Text = sResID;
                    SForm.Show();
                }
                else
                {
                    ((frmRASTranTroubleResource) SForm).b_load_flag = false;
                    ((frmRASTranTroubleResource) SForm).txtResID.Text = sResID;
                    SForm.Activate();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message, "GetTroubleResourceForm()", 0, 1);
            }
            
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResID.GetListView, false);
        }
        
        private void cdvEventID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvEventID.Init();
            MPCF.InitListView(cdvEventID.GetListView);
            cdvEventID.Columns.Add("Event", 50, HorizontalAlignment.Left);
            cdvEventID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvEventID.SelectedSubItemIndex = 0;
            RASLIST.ViewEventList(cdvEventID.GetListView, '1', "", null, "");
        }
    }
    
}
