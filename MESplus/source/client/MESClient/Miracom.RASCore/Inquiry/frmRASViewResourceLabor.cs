
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
//   File Name   : frmRASSetupResourceLabor.vb
//   Description : Resource Labor Setup Form
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
//       - 2004-08-13 : Created by CM Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.RASCore
{
    public class frmRASViewResourceLabor : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewResourceLabor()
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
        private System.Windows.Forms.GroupBox grpRes;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Panel pnlMidMid;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvPosition;
        private System.Windows.Forms.Label lblPosition;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvShift;
        private System.Windows.Forms.Label lblShift;
        public System.Windows.Forms.Button btnExcel;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASViewResourceLabor));
            this.pnlMidTop = new System.Windows.Forms.Panel();
            this.grpRes = new System.Windows.Forms.GroupBox();
            this.cdvShift = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblShift = new System.Windows.Forms.Label();
            this.cdvPosition = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblPosition = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlMidMid = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMidTop.SuspendLayout();
            this.grpRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlMidMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Text = "View";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMidMid);
            this.pnlCenter.Controls.Add(this.pnlMidTop);
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Resource Labor";
            // 
            // pnlMidTop
            // 
            this.pnlMidTop.Controls.Add(this.grpRes);
            this.pnlMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidTop.Location = new System.Drawing.Point(3, 0);
            this.pnlMidTop.Name = "pnlMidTop";
            this.pnlMidTop.Size = new System.Drawing.Size(736, 71);
            this.pnlMidTop.TabIndex = 1;
            // 
            // grpRes
            // 
            this.grpRes.Controls.Add(this.cdvShift);
            this.grpRes.Controls.Add(this.lblShift);
            this.grpRes.Controls.Add(this.cdvPosition);
            this.grpRes.Controls.Add(this.lblPosition);
            this.grpRes.Controls.Add(this.dtpMonth);
            this.grpRes.Controls.Add(this.dtpYear);
            this.grpRes.Controls.Add(this.lblMonth);
            this.grpRes.Controls.Add(this.lblYear);
            this.grpRes.Controls.Add(this.cdvResID);
            this.grpRes.Controls.Add(this.lblDate);
            this.grpRes.Controls.Add(this.lblResID);
            this.grpRes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRes.Location = new System.Drawing.Point(0, 0);
            this.grpRes.Name = "grpRes";
            this.grpRes.Size = new System.Drawing.Size(736, 71);
            this.grpRes.TabIndex = 0;
            this.grpRes.TabStop = false;
            // 
            // cdvShift
            // 
            this.cdvShift.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvShift.BorderHotColor = System.Drawing.Color.Black;
            this.cdvShift.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvShift.BtnToolTipText = "";
            this.cdvShift.DescText = "";
            this.cdvShift.DisplaySubItemIndex = -1;
            this.cdvShift.DisplayText = "";
            this.cdvShift.Focusing = null;
            this.cdvShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvShift.Index = 0;
            this.cdvShift.IsViewBtnImage = false;
            this.cdvShift.Location = new System.Drawing.Point(458, 40);
            this.cdvShift.MaxLength = 20;
            this.cdvShift.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvShift.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvShift.Name = "cdvShift";
            this.cdvShift.ReadOnly = false;
            this.cdvShift.SearchSubItemIndex = 0;
            this.cdvShift.SelectedDescIndex = -1;
            this.cdvShift.SelectedSubItemIndex = -1;
            this.cdvShift.SelectionStart = 0;
            this.cdvShift.Size = new System.Drawing.Size(190, 20);
            this.cdvShift.SmallImageList = null;
            this.cdvShift.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvShift.TabIndex = 10;
            this.cdvShift.TextBoxToolTipText = "";
            this.cdvShift.TextBoxWidth = 190;
            this.cdvShift.VisibleButton = true;
            this.cdvShift.VisibleColumnHeader = false;
            this.cdvShift.VisibleDescription = false;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShift.Location = new System.Drawing.Point(352, 44);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(57, 13);
            this.lblShift.TabIndex = 9;
            this.lblShift.Text = "Work Shift";
            // 
            // cdvPosition
            // 
            this.cdvPosition.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvPosition.BorderHotColor = System.Drawing.Color.Black;
            this.cdvPosition.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvPosition.BtnToolTipText = "";
            this.cdvPosition.DescText = "";
            this.cdvPosition.DisplaySubItemIndex = -1;
            this.cdvPosition.DisplayText = "";
            this.cdvPosition.Focusing = null;
            this.cdvPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvPosition.Index = 0;
            this.cdvPosition.IsViewBtnImage = false;
            this.cdvPosition.Location = new System.Drawing.Point(458, 16);
            this.cdvPosition.MaxLength = 10;
            this.cdvPosition.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvPosition.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvPosition.Name = "cdvPosition";
            this.cdvPosition.ReadOnly = false;
            this.cdvPosition.SearchSubItemIndex = 0;
            this.cdvPosition.SelectedDescIndex = -1;
            this.cdvPosition.SelectedSubItemIndex = -1;
            this.cdvPosition.SelectionStart = 0;
            this.cdvPosition.Size = new System.Drawing.Size(190, 20);
            this.cdvPosition.SmallImageList = null;
            this.cdvPosition.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvPosition.TabIndex = 8;
            this.cdvPosition.TextBoxToolTipText = "";
            this.cdvPosition.TextBoxWidth = 190;
            this.cdvPosition.VisibleButton = true;
            this.cdvPosition.VisibleColumnHeader = false;
            this.cdvPosition.VisibleDescription = false;
            this.cdvPosition.ButtonPress += new System.EventHandler(this.cdvPosition_ButtonPress);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(352, 19);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(73, 13);
            this.lblPosition.TabIndex = 7;
            this.lblPosition.Text = "Work Position";
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MM";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(222, 16);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(42, 20);
            this.dtpMonth.TabIndex = 3;
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(120, 16);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(54, 20);
            this.dtpYear.TabIndex = 1;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMonth.Location = new System.Drawing.Point(270, 19);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(37, 13);
            this.lblMonth.TabIndex = 4;
            this.lblMonth.Text = "Month";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblYear.Location = new System.Drawing.Point(180, 19);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 13);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year /";
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
            this.cdvResID.Location = new System.Drawing.Point(120, 40);
            this.cdvResID.MaxLength = 20;
            this.cdvResID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvResID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectionStart = 0;
            this.cdvResID.Size = new System.Drawing.Size(190, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 6;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 190;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(15, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 42);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(67, 13);
            this.lblResID.TabIndex = 5;
            this.lblResID.Text = "Resource ID";
            // 
            // pnlMidMid
            // 
            this.pnlMidMid.Controls.Add(this.spdData);
            this.pnlMidMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMidMid.Location = new System.Drawing.Point(3, 71);
            this.pnlMidMid.Name = "pnlMidMid";
            this.pnlMidMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlMidMid.Size = new System.Drawing.Size(736, 442);
            this.pnlMidMid.TabIndex = 0;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "";
            this.spdData.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.EditModePermanent = true;
            this.spdData.EditModeReplace = true;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.Location = new System.Drawing.Point(0, 5);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(736, 437);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 8;
            spdData_Sheet1.RowCount = 5;
            spdData_Sheet1.RowHeader.ColumnCount = 0;
            this.spdData_Sheet1.Cells.Get(0, 0).Locked = false;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Day";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Res ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Work Position";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Work Shift";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Direct Labor Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Indirect Labor Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Direct Labor Min";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Indirect Labor Min";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdData_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdData_Sheet1.Columns.Get(0).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Label = "Day";
            this.spdData_Sheet1.Columns.Get(0).Locked = true;
            this.spdData_Sheet1.Columns.Get(0).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 50F;
            this.spdData_Sheet1.Columns.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Label = "Res ID";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 90F;
            this.spdData_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Label = "Work Position";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 80F;
            this.spdData_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Label = "Work Shift";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            textCellType1.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType1.MaxLength = 10;
            this.spdData_Sheet1.Columns.Get(4).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(4).Label = "Direct Labor Count";
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 110F;
            textCellType2.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType2.MaxLength = 10;
            this.spdData_Sheet1.Columns.Get(5).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(5).Label = "Indirect Labor Count";
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 110F;
            textCellType3.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType3.MaxLength = 10;
            this.spdData_Sheet1.Columns.Get(6).CellType = textCellType3;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(6).Label = "Direct Labor Min";
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 110F;
            textCellType4.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType4.MaxLength = 10;
            this.spdData_Sheet1.Columns.Get(7).CellType = textCellType4;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(7).Label = "Indirect Labor Min";
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 110F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.RowHeader.Visible = false;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(10, 6);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmRASViewResourceLabor
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASViewResourceLabor";
            this.Text = "View Resource Labor";
            this.Activated += new System.EventHandler(this.frmRASViewResourceLabor_Activated);
            this.Load += new System.EventHandler(this.frmRASViewResourceLabor_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMidTop.ResumeLayout(false);
            this.grpRes.ResumeLayout(false);
            this.grpRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlMidMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL_DATE = 0;
        private const int COL_RES_ID = 1;
        private const int COL_POSITION = 2;
        private const int COL_SHIFT = 3;
        private const int COL_DIRECT_COUNT = 4;
        private const int COL_INDIRECT_COUNT = 5;
        private const int COL_DIRECT_MIN = 6;
        private const int COL_INDIRECT_MIN = 7;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        // initControl()
        //       -   initial Controls
        // Return Value
        //       -
        // Arguments
        //       -
        private void initControl()
        {
            
            cdvShift.Init();
            MPCF.InitListView(cdvShift.GetListView);
            cdvShift.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvShift.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvShift.SelectedSubItemIndex = 0;
            int i;
            ListViewItem itmX;
            
            itmX = new ListViewItem("None", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itmX.SubItems.Add("A");
            cdvShift.GetListView.Items.Add(itmX);
            for (i = 1; i <= MPGV.gShiftInfor.iShiftCount; i++)
            {
                itmX = new ListViewItem("Shift " + i.ToString(), (int)SMALLICON_INDEX.IDX_CODE_DATA);
                itmX.SubItems.Add("A");
                cdvShift.GetListView.Items.Add(itmX);
            }
            itmX = new ListViewItem("All Shift", (int)SMALLICON_INDEX.IDX_CODE_DATA);
            itmX.SubItems.Add("A");
            cdvShift.GetListView.Items.Add(itmX);
            cdvShift.Text = "All Shift";
            cdvShift.ReadOnly = true;
            
        }
        
        private void CalTotal()
        {
            int i;
            int iNextStart;
            
            FarPoint.Win.Spread.SheetView with_1 = spdData.Sheets[0];
            i = 1;
            iNextStart = 0;
            while (i <= with_1.RowCount - 1)
            {
                if (with_1.Cells[i - 1, COL_DATE].Value != with_1.Cells[i, COL_DATE].Value)
                {
                    CalDayTotal(iNextStart, i - 1);
                    i++;
                    iNextStart = i;
                }
                
                i++;
            }
            
            if (iNextStart < i)
            {
                CalDayTotal(iNextStart, i - 1);
            }
            
            CalMonthTotal();
            
            
        }
        
        private void CalDayTotal(int iStart, int iEnd)
        {
            int i;
            int iDirectCount;
            int iIndirectCount;
            int iDirectMin;
            int iIndirectMin;
            string sDate;
            
            iDirectCount = 0;
            iIndirectCount = 0;
            iDirectMin = 0;
            iIndirectMin = 0;
            FarPoint.Win.Spread.SheetView with_1 = spdData.Sheets[0];
            for (i = iStart; i <= iEnd; i++)
            {
                iDirectCount += MPCF.ToInt(MPCF.ToDbl(with_1.Cells[i, COL_DIRECT_COUNT].Value));
                iIndirectCount += MPCF.ToInt(MPCF.ToDbl(with_1.Cells[i, COL_INDIRECT_COUNT].Value));
                iDirectMin += MPCF.ToInt(MPCF.ToDbl(with_1.Cells[i, COL_DIRECT_MIN].Value));
                iIndirectMin += MPCF.ToInt(MPCF.ToDbl(with_1.Cells[i, COL_INDIRECT_MIN].Value));
            }

            sDate = MPCF.Trim(with_1.Cells[iEnd, COL_DATE].Value);
            
            if (iEnd == with_1.RowCount - 1)
            {
                with_1.RowCount++;
                iEnd = with_1.RowCount - 1;
            }
            else
            {
                with_1.AddRows(iEnd + 1, 1);
                iEnd++;
            }
            
            with_1.Rows[iEnd].BackColor = Color.LightGoldenrodYellow;
            with_1.Rows[iEnd].Font = new Font(spdData.Font.Name, spdData.Font.Size, FontStyle.Bold);
            with_1.Cells[iEnd, COL_DATE].Value = sDate;
            with_1.Cells[iEnd, COL_DATE].Tag = "TOTAL";
            with_1.Cells[iEnd, COL_RES_ID].Value = sDate + " TOTAL";
            
            with_1.Cells[iEnd, COL_DIRECT_COUNT].Value = iDirectCount;
            with_1.Cells[iEnd, COL_INDIRECT_COUNT].Value = iIndirectCount;
            with_1.Cells[iEnd, COL_DIRECT_MIN].Value = iDirectMin;
            with_1.Cells[iEnd, COL_INDIRECT_MIN].Value = iIndirectMin;
            
            
        }
        
        private void CalMonthTotal()
        {
            int i;
            int iDirectCount;
            int iIndirectCount;
            int iDirectMin;
            int iIndirectMin;
            
            iDirectCount = 0;
            iIndirectCount = 0;
            iDirectMin = 0;
            iIndirectMin = 0;
            FarPoint.Win.Spread.SheetView with_1 = spdData.Sheets[0];
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (MPCF.Trim(with_1.Cells[i, COL_DATE].Tag) == "TOTAL")
                {
                    iDirectCount += MPCF.ToInt(MPCF.ToDbl(with_1.Cells[i, COL_DIRECT_COUNT].Value));
                    iIndirectCount += MPCF.ToInt(MPCF.ToDbl(with_1.Cells[i, COL_INDIRECT_COUNT].Value));
                    iDirectMin += MPCF.ToInt(MPCF.ToDbl(with_1.Cells[i, COL_DIRECT_MIN].Value));
                    iIndirectMin += MPCF.ToInt(MPCF.ToDbl(with_1.Cells[i, COL_INDIRECT_MIN].Value));
                }
            }
            
            with_1.RowCount++;
            i = with_1.RowCount - 1;
            
            with_1.Rows[i].BackColor = Color.LightGoldenrodYellow;
            with_1.Rows[i].Font = new Font(spdData.Font.Name, spdData.Font.Size, FontStyle.Bold);
            with_1.Cells[i, COL_DATE].ColumnSpan = 2;
            with_1.Cells[i, COL_DATE].Value = "MONTHLY TOTAL";
            
            with_1.Cells[i, COL_DIRECT_COUNT].Value = iDirectCount;
            with_1.Cells[i, COL_INDIRECT_COUNT].Value = iIndirectCount;
            with_1.Cells[i, COL_DIRECT_MIN].Value = iDirectMin;
            with_1.Cells[i, COL_INDIRECT_MIN].Value = iIndirectMin;
            
            
        }
        
        // View_Resource_Labor_List()
        //       -  View Resource Labor List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool View_Resource_Labor_List()
        {
            TRSNode in_node = new TRSNode("View_Resource_Labor_List_In");
            TRSNode out_node;
            
            int i;
            int iRow;

            MPCF.ClearList(spdData, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '2';
            in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
            in_node.AddString("WORK_POSITION", MPCF.Trim(cdvPosition.Text));

            if (cdvShift.Text == "None")
            {
                in_node.AddChar("WORK_SHIFT", ' ');
            }
            else if (cdvShift.Text == "All Shift")
            {
                in_node.AddChar("WORK_SHIFT", '*');
            }
            else
            {
                in_node.AddChar("WORK_SHIFT", System.Convert.ToChar(cdvShift.Text.Substring(6, 1)));
            }
            in_node.AddString("YEAR", dtpYear.Value.Year.ToString("0000"));
            in_node.AddString("MONTH", dtpMonth.Value.Month.ToString("00"));
            in_node.AddString("NEXT_RES_ID", "");
            in_node.AddString("NEXT_WORK_POSITION", "");
            in_node.AddChar("NEXT_WORK_SHIFT", ' ');
            in_node.AddString("NEXT_WORK_DATE", "");
                        
            do
            {
                out_node = new TRSNode("View_Resource_Labor_List_Out");

                if (MPCR.CallService("RAS", "RAS_View_Resource_Labor_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                   
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].RowCount++;
                    
                    spdData.Sheets[0].Cells[iRow, COL_DATE].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("WORK_DATE")).Substring(6);
                    spdData.Sheets[0].Cells[iRow, COL_RES_ID].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("RES_ID"));
                    spdData.Sheets[0].Cells[iRow, COL_POSITION].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("WORK_POSITION"));
                    spdData.Sheets[0].Cells[iRow, COL_SHIFT].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("WORK_SHIFT"));
                    spdData.Sheets[0].Cells[iRow, COL_DIRECT_COUNT].Value = out_node.GetList(0)[i].GetInt("DIRECT_LABOR_COUNT") == 0 ? "" : (MPCF.Trim(out_node.GetList(0)[i].GetInt("DIRECT_LABOR_COUNT")));
                    spdData.Sheets[0].Cells[iRow, COL_INDIRECT_COUNT].Value = out_node.GetList(0)[i].GetInt("INDIRECT_LABOR_COUNT") == 0 ? "" : (MPCF.Trim(out_node.GetList(0)[i].GetInt("INDIRECT_LABOR_COUNT")));
                    spdData.Sheets[0].Cells[iRow, COL_DIRECT_MIN].Value = out_node.GetList(0)[i].GetInt("DIRECT_LABOR_MIN") == 0 ? "" : (MPCF.Trim(out_node.GetList(0)[i].GetInt("DIRECT_LABOR_MIN")));
                    spdData.Sheets[0].Cells[iRow, COL_INDIRECT_MIN].Value = out_node.GetList(0)[i].GetInt("INDIRECT_LABOR_MIN") == 0 ? "" : (MPCF.Trim(out_node.GetList(0)[i].GetInt("INDIRECT_LABOR_MIN")));
                    
                }
                in_node.SetString("NEXT_RES_ID", out_node.GetString("NEXT_RES_ID"));
                in_node.SetString("NEXT_WORK_DATE", out_node.GetString("NEXT_WORK_DATE"));
                in_node.SetString("NEXT_WORK_POSITION", out_node.GetString("NEXT_WORK_POSITION"));
                in_node.SetChar("NEXT_WORK_SHIFT", out_node.GetChar("NEXT_WORK_SHIFT"));
                
                } while (in_node.GetString("NEXT_RES_ID") != "" || in_node.GetString("NEXT_WORK_DATE") != "" ||
                         in_node.GetChar("NEXT_WORK_POSITION") != ' ' || in_node.GetChar("NEXT_WORK_SHIFT") != ' ');
                        
            if (spdData.Sheets[0].RowCount > 0)
            {
                CalTotal();
            }
            
            MPCF.FitColumnHeader(spdData);
            
            return true;
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.dtpYear;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASViewResourceLabor_Load(object sender, System.EventArgs e)
        {
        }
        private void frmRASViewResourceLabor_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.ClearList(spdData, true);
                MPCF.FitColumnHeader(spdData);
                
                initControl();
                
                dtpYear.Value = DateTime.Today;
                dtpMonth.Value = DateTime.Today;
                
                b_load_flag = true;
            }
            
            
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            View_Resource_Labor_List();
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "Date : " + dtpYear.Value.Year.ToString("0000") + " Year,  " + dtpMonth.Value.Month.ToString("00") + " Month";
            if (cdvResID.Text != "")
            {
                sCond = sCond + "\r" + "Resource ID : " + MPCF.Trim(cdvResID.Text);
            }
            if (cdvPosition.Text != "")
            {
                sCond = sCond + "\r" + "Work Position : " + MPCF.Trim(cdvPosition.Text);
            }
            sCond = sCond + "\r" + "Work Shift : " + MPCF.Trim(cdvShift.Text);
            MPCF.ExportToExcel(spdData, this.Text, sCond);
            
        }
        
        private void cdvResID_ButtonPress(object sender, System.EventArgs e)
        {
            cdvResID.Init();
            MPCF.InitListView(cdvResID.GetListView);
            cdvResID.Columns.Add("Resource", 150, HorizontalAlignment.Left);
            cdvResID.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvResID.SelectedSubItemIndex = 0;
            RASLIST.ViewResourceList(cdvResID.GetListView, false);
        }
        
        private void cdvPosition_ButtonPress(object sender, System.EventArgs e)
        {
            cdvPosition.Init();
            MPCF.InitListView(cdvPosition.GetListView);
            cdvPosition.Columns.Add("Position", 150, HorizontalAlignment.Left);
            cdvPosition.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvPosition.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvPosition.GetListView, '1', MPGC.MP_RAS_WORK_POSITION);
        }
    }
    
}
