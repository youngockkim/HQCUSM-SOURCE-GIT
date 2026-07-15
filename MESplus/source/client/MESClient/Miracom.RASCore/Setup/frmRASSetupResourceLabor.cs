
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
    public class frmRASSetupResourceLabor : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupResourceLabor()
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
        private System.Windows.Forms.GroupBox grpRes;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Label lblDate;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        protected Button btnExcel;
        protected System.Windows.Forms.Button btnView;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType1 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASSetupResourceLabor));
            this.pnlMidTop = new System.Windows.Forms.Panel();
            this.grpRes = new System.Windows.Forms.GroupBox();
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
            this.btnView = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMidTop.SuspendLayout();
            this.grpRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlMidMid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Update";
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExcel);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
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
            this.lblFormTitle.Text = "Resource Labor Setup";
            // 
            // pnlMidTop
            // 
            this.pnlMidTop.Controls.Add(this.grpRes);
            this.pnlMidTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMidTop.Location = new System.Drawing.Point(3, 0);
            this.pnlMidTop.Name = "pnlMidTop";
            this.pnlMidTop.Size = new System.Drawing.Size(736, 46);
            this.pnlMidTop.TabIndex = 0;
            // 
            // grpRes
            // 
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
            this.grpRes.Size = new System.Drawing.Size(736, 46);
            this.grpRes.TabIndex = 0;
            this.grpRes.TabStop = false;
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "MM";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(560, 16);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.ShowUpDown = true;
            this.dtpMonth.Size = new System.Drawing.Size(42, 20);
            this.dtpMonth.TabIndex = 5;
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(458, 16);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.ShowUpDown = true;
            this.dtpYear.Size = new System.Drawing.Size(54, 20);
            this.dtpYear.TabIndex = 3;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMonth.Location = new System.Drawing.Point(608, 19);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(37, 13);
            this.lblMonth.TabIndex = 6;
            this.lblMonth.Text = "Month";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblYear.Location = new System.Drawing.Point(518, 19);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(37, 13);
            this.lblYear.TabIndex = 4;
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
            this.cdvResID.Size = new System.Drawing.Size(190, 20);
            this.cdvResID.SmallImageList = null;
            this.cdvResID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvResID.TabIndex = 1;
            this.cdvResID.TextBoxToolTipText = "";
            this.cdvResID.TextBoxWidth = 190;
            this.cdvResID.VisibleButton = true;
            this.cdvResID.VisibleColumnHeader = false;
            this.cdvResID.VisibleDescription = false;
            this.cdvResID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvResID_SelectedItemChanged);
            this.cdvResID.ButtonPress += new System.EventHandler(this.cdvResID_ButtonPress);
            this.cdvResID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResID_TextBoxKeyPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(352, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // lblResID
            // 
            this.lblResID.AutoSize = true;
            this.lblResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResID.Location = new System.Drawing.Point(15, 19);
            this.lblResID.Name = "lblResID";
            this.lblResID.Size = new System.Drawing.Size(78, 13);
            this.lblResID.TabIndex = 0;
            this.lblResID.Text = "Resource ID";
            // 
            // pnlMidMid
            // 
            this.pnlMidMid.Controls.Add(this.spdData);
            this.pnlMidMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMidMid.Location = new System.Drawing.Point(3, 46);
            this.pnlMidMid.Name = "pnlMidMid";
            this.pnlMidMid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlMidMid.Size = new System.Drawing.Size(736, 467);
            this.pnlMidMid.TabIndex = 1;
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
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdData.Location = new System.Drawing.Point(0, 5);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(736, 462);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.EditChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_EditChange);
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
            this.spdData_Sheet1.AutoCalculation = false;
            this.spdData_Sheet1.Cells.Get(0, 1).Locked = false;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Sel";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Day";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Work Position";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Work Shift";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Direct Labor Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Indirect Labor Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Direct Labor Min";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Indirect Labor Min";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.Columns.Get(0).BackColor = System.Drawing.Color.White;
            checkBoxCellType1.TextAlign = FarPoint.Win.ButtonTextAlign.TextLeftPictRight;
            this.spdData_Sheet1.Columns.Get(0).CellType = checkBoxCellType1;
            this.spdData_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Label = "Sel";
            this.spdData_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(0).Width = 40F;
            this.spdData_Sheet1.Columns.Get(1).BackColor = System.Drawing.SystemColors.Control;
            this.spdData_Sheet1.Columns.Get(1).Border = bevelBorder1;
            this.spdData_Sheet1.Columns.Get(1).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdData_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Label = "Day";
            this.spdData_Sheet1.Columns.Get(1).Locked = true;
            this.spdData_Sheet1.Columns.Get(1).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Always;
            this.spdData_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(1).Width = 50F;
            this.spdData_Sheet1.Columns.Get(2).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Label = "Work Position";
            this.spdData_Sheet1.Columns.Get(2).Locked = true;
            this.spdData_Sheet1.Columns.Get(2).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdData_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(2).Width = 110F;
            this.spdData_Sheet1.Columns.Get(3).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Label = "Work Shift";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).MergePolicy = FarPoint.Win.Spread.Model.MergePolicy.Restricted;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 80F;
            textCellType1.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType1.MaxLength = 3;
            this.spdData_Sheet1.Columns.Get(4).CellType = textCellType1;
            this.spdData_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(4).Label = "Direct Labor Count";
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 110F;
            textCellType2.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType2.MaxLength = 3;
            this.spdData_Sheet1.Columns.Get(5).CellType = textCellType2;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(5).Label = "Indirect Labor Count";
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 110F;
            textCellType3.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType3.MaxLength = 6;
            this.spdData_Sheet1.Columns.Get(6).CellType = textCellType3;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(6).Label = "Direct Labor Min";
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 110F;
            textCellType4.CharacterSet = FarPoint.Win.Spread.CellType.CharacterSet.Numeric;
            textCellType4.MaxLength = 6;
            this.spdData_Sheet1.Columns.Get(7).CellType = textCellType4;
            this.spdData_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(7).Label = "Indirect Labor Min";
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
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(12, 9);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 22;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmRASSetupResourceLabor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASSetupResourceLabor";
            this.Text = "Resource Labor Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupResourceLabor_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMidTop.ResumeLayout(false);
            this.grpRes.ResumeLayout(false);
            this.grpRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlMidMid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int COL_SEL = 0;
        private const int COL_DATE = 1;
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
        
        // CheckCondition()
        //       -   Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : create/update/delete Function name
        private bool CheckCondition()
        {
            int i;

            if (MPCF.CheckValue(cdvResID, 1) == false)
            {
                return false;
            }
            
            FarPoint.Win.Spread.SheetView with_1 = spdData.Sheets[0];
            if (with_1.RowCount < 1)
            {
                return false;
            }
            
            for (i = 0; i <= with_1.RowCount - 1; i++)
            {
                if (with_1.Cells[i, COL_SEL].Value != null &&
                    Convert.ToBoolean(with_1.Cells[i, COL_SEL].Value) == true)
                {
                    break;
                }
            }
            
            if (i == with_1.RowCount)
            {
                return false;
            }
            
            return true;
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
            TRSNode out_node = new TRSNode("View_Resource_Labor_List_Out");
            int i;
            int iRow;
            
            MPCF.ClearList(spdData, true);

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
             in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
             in_node.AddString("YEAR", dtpYear.Value.Year.ToString("0000"));
             in_node.AddString("MONTH", dtpMonth.Value.Month.ToString("00"));
             in_node.AddString("NEXT_WORK_DATE", "");
             in_node.AddString("NEXT_WORK_POSITION", "");
             in_node.AddChar("NEXT_WORK_SHIFT", ' ');
            
            do
            {
                if (MPCR.CallService("RAS", "RAS_View_Resource_Labor_List", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                for (i = 0; i < out_node.GetList(0).Count; i++)
                {
                    iRow = spdData.Sheets[0].RowCount;
                    spdData.Sheets[0].RowCount++;
                    
                    spdData.Sheets[0].Cells[iRow, COL_DATE].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("WORK_DATE")).Substring(6);
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
                     in_node.GetString("NEXT_WORK_POSITION") != "" || in_node.GetChar("NEXT_WORK_SHIFT") != ' ');
                        
            return true;
            
        }
        
        // Update_Resource_Labor()
        //       - Update Resource Labor
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        private bool Update_Resource_Labor()
        {
            TRSNode in_node = new TRSNode("Update_Resource_Labor_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            TRSNode list;
           
            int i;
            
            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';
            in_node.AddString("RES_ID", MPCF.Trim(cdvResID.Text));
                        
            for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
            {
                if (spdData.ActiveSheet.Cells[i, COL_SEL].Value != null && Convert.ToBoolean(spdData.ActiveSheet.Cells[i, COL_SEL].Value) == true)
                {
                    list = in_node.AddNode("DATA_LIST");

                    list.AddString("WORK_POSITION", MPCF.Trim(spdData.ActiveSheet.Cells[i, COL_POSITION].Value));
                    list.AddString("WORK_DATE", dtpYear.Value.Year.ToString("0000") + 
                                                dtpMonth.Value.Month.ToString("00") + 
                                                MPCF.Trim(spdData.ActiveSheet.Cells[i, COL_DATE].Value));
                    list.AddChar("WORK_SHIFT", MPCF.ToChar(MPCF.Trim(spdData.ActiveSheet.Cells[i, COL_SHIFT].Value)));
                    list.AddInt("DIRECT_LABOR_COUNT", MPCF.ToInt(MPCF.ToDbl(spdData.ActiveSheet.Cells[i, COL_DIRECT_COUNT].Value)));
                    list.AddInt("INDIRECT_LABOR_COUNT", MPCF.ToInt(MPCF.ToDbl(spdData.ActiveSheet.Cells[i, COL_INDIRECT_COUNT].Value)));
                    list.AddInt("DIRECT_LABOR_MIN", MPCF.ToInt(MPCF.ToDbl(spdData.ActiveSheet.Cells[i, COL_DIRECT_MIN].Value)));
                    list.AddInt("INDIRECT_LABOR_MIN", MPCF.ToInt(MPCF.ToDbl(spdData.ActiveSheet.Cells[i, COL_INDIRECT_MIN].Value)));
                }
            }
            
            if (MPCR.CallService("RAS", "RAS_Update_Resource_Labor", in_node, ref out_node) == false)
            {
                return false;
            }

            for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
            {
                if (spdData.ActiveSheet.Cells[i, COL_SEL].Value != null && Convert.ToBoolean(spdData.ActiveSheet.Cells[i, COL_SEL].Value) == true)
                {
                    spdData.ActiveSheet.Cells[i, COL_SEL].Value = false;
                }
            }

            MPCR.ShowSuccessMsg(out_node);
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
        
        private void frmRASSetupResourceLabor_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                
                MPCF.FieldClear(this);
                MPCF.ClearList(spdData, true);
                
                dtpYear.Value = DateTime.Today;
                dtpMonth.Value = DateTime.Today;
                
                b_load_flag = true;
            }
            
            
        }
        
        private void cdvResID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvResID.Text != "")
            {
                View_Resource_Labor_List();
            }
        }
        
        private void cdvResID_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                View_Resource_Labor_List();
            }
        }
        
        private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            if (cdvResID.Text == "")
            {
                MPCF.ClearList(spdData, true);
            }
        }
        
        private void spdData_EditChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column >= COL_DIRECT_COUNT && e.Column <= COL_INDIRECT_MIN)
            {
                spdData.Sheets[0].Cells[e.Row, COL_SEL].Value = true;
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition() == false)
            {
                return;
            }
            if (Update_Resource_Labor() == false)
            {
                return;
            }
            
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            View_Resource_Labor_List();
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond = string.Empty;


                sCond = "Resoucre : " + cdvResID.Text;


                MPCF.ExportToExcel(spdData, this.Text, sCond);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
    
}
