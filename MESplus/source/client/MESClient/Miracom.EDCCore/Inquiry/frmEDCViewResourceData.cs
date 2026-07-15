
using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

using Miracom.MsgHandler;
using System.Data;
using Miracom.MESCore;
using Miracom.UI.Controls;
using Miracom.CliFrx;
using Miracom.TRSCore;

//#If _EDC = True Then
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmEDCViewResourceData.vb
//   Description : View Resource Data Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition() : Check the conditions before transaction
//       - ViewResourceHist() : View Resource History
//       - SetStatusField() : Set Status Field
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-07-08 : Created by W.Y. Choi
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.EDCCore
{
    public class frmEDCViewResourceData : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmEDCViewResourceData()
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
        



        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvEventID;
        private System.Windows.Forms.Label lblEvent;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvResID;
        private System.Windows.Forms.Label lblResID;
        private System.Windows.Forms.Panel pnlResourceData;
        private FarPoint.Win.Spread.FpSpread spdResHistory;
        private FarPoint.Win.Spread.SheetView spdResHistory_Sheet1;
        private System.Windows.Forms.CheckBox chkIncludeDelHistory;
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private FarPoint.Win.Spread.FpSpread spdData;
        private Splitter splitter1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvSubResource;
        private Label lblSubResID;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.cdvEventID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEvent = new System.Windows.Forms.Label();
            this.cdvResID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblResID = new System.Windows.Forms.Label();
            this.pnlResourceData = new System.Windows.Forms.Panel();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.spdResHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdResHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.pnlPeriod = new System.Windows.Forms.Panel();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cdvSubResource = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSubResID = new System.Windows.Forms.Label();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).BeginInit();
            this.pnlResourceData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResHistory_Sheet1)).BeginInit();
            this.pnlPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResource)).BeginInit();
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
            this.pnlViewTop.Size = new System.Drawing.Size(742, 94);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.cdvSubResource);
            this.grpOption.Controls.Add(this.lblSubResID);
            this.grpOption.Controls.Add(this.pnlPeriod);
            this.grpOption.Controls.Add(this.chkIncludeDelHistory);
            this.grpOption.Controls.Add(this.cdvEventID);
            this.grpOption.Controls.Add(this.cdvResID);
            this.grpOption.Controls.Add(this.lblEvent);
            this.grpOption.Controls.Add(this.lblResID);
            this.grpOption.Size = new System.Drawing.Size(742, 94);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.splitter1);
            this.pnlViewMid.Controls.Add(this.pnlResourceData);
            this.pnlViewMid.Controls.Add(this.spdResHistory);
            this.pnlViewMid.Location = new System.Drawing.Point(0, 94);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(742, 415);
            this.pnlViewMid.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 509);
            this.pnlBottom.Size = new System.Drawing.Size(742, 37);
            this.pnlBottom.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 509);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Resource Data";
            // 
            // cdvEventID
            // 
            this.cdvEventID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvEventID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvEventID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvEventID.BtnToolTipText = "";
            this.cdvEventID.ButtonWidth = 20;
            this.cdvEventID.DescText = "";
            this.cdvEventID.DisplaySubItemIndex = -1;
            this.cdvEventID.DisplayText = "";
            this.cdvEventID.Focusing = null;
            this.cdvEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvEventID.Index = 0;
            this.cdvEventID.IsViewBtnImage = false;
            this.cdvEventID.Location = new System.Drawing.Point(120, 62);
            this.cdvEventID.MaxLength = 12;
            this.cdvEventID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvEventID.MultiSelect = false;
            this.cdvEventID.Name = "cdvEventID";
            this.cdvEventID.ReadOnly = false;
            this.cdvEventID.SameWidthHeightOfButton = false;
            this.cdvEventID.SearchSubItemIndex = 0;
            this.cdvEventID.SelectedDescIndex = -1;
            this.cdvEventID.SelectedDescToQueryText = "";
            this.cdvEventID.SelectedSubItemIndex = -1;
            this.cdvEventID.SelectedValueToQueryText = "";
            this.cdvEventID.SelectionStart = 0;
            this.cdvEventID.Size = new System.Drawing.Size(200, 20);
            this.cdvEventID.SmallImageList = null;
            this.cdvEventID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvEventID.TabIndex = 5;
            this.cdvEventID.TextBoxToolTipText = "";
            this.cdvEventID.TextBoxWidth = 200;
            this.cdvEventID.VisibleButton = true;
            this.cdvEventID.VisibleColumnHeader = false;
            this.cdvEventID.VisibleDescription = false;
            this.cdvEventID.ButtonPress += new System.EventHandler(this.cdvEventID_ButtonPress);
            this.cdvEventID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvEventID_TextBoxKeyPress);
            this.cdvEventID.TextBoxTextChanged += new System.EventHandler(this.cdvEventID_TextBoxTextChanged);
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(15, 65);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(49, 13);
            this.lblEvent.TabIndex = 4;
            this.lblEvent.Text = "Event ID";
            // 
            // cdvResID
            // 
            this.cdvResID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvResID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvResID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvResID.BtnToolTipText = "";
            this.cdvResID.ButtonWidth = 20;
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
            this.cdvResID.MultiSelect = false;
            this.cdvResID.Name = "cdvResID";
            this.cdvResID.ReadOnly = false;
            this.cdvResID.SameWidthHeightOfButton = false;
            this.cdvResID.SearchSubItemIndex = 0;
            this.cdvResID.SelectedDescIndex = -1;
            this.cdvResID.SelectedDescToQueryText = "";
            this.cdvResID.SelectedSubItemIndex = -1;
            this.cdvResID.SelectedValueToQueryText = "";
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
            this.cdvResID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvResID_KeyPress);
            this.cdvResID.TextBoxTextChanged += new System.EventHandler(this.cdvResID_TextBoxTextChanged);
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
            // pnlResourceData
            // 
            this.pnlResourceData.Controls.Add(this.spdData);
            this.pnlResourceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResourceData.Location = new System.Drawing.Point(0, 163);
            this.pnlResourceData.Name = "pnlResourceData";
            this.pnlResourceData.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlResourceData.Size = new System.Drawing.Size(742, 252);
            this.pnlResourceData.TabIndex = 1;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.SystemColors.Control;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(0, 3);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(742, 249);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TabStop = false;
            this.spdData.TabStripRatio = 0.501972386587771D;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdData.VerticalScrollBar.TabIndex = 3;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 43;
            spdData_Sheet1.ColumnHeader.RowCount = 2;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Factory";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Resource";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Del Flag";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Collection Set ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Version";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Character Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Character";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Character Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Spec";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Unit Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Unit ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Value Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Value Type";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Value Count";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).ColumnSpan = 25;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Value";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 40).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Spec Out Mask";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 41).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Update User ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 42).RowSpan = 2;
            this.spdData_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Update Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 0).Value = "Factory";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 1).Value = "Resource";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 2).Value = "Hist Seq";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 3).Value = "Event ID";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 4).Value = "Tran Time";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 8).Value = "Character Desc";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 15).Value = "1";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 16).Value = "2";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 17).Value = "3";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 18).Value = "4";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 19).Value = "5";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 20).Value = "6";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 21).Value = "7";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 22).Value = "8";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 23).Value = "9";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 24).Value = "10";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 25).Value = "11";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 26).Value = "12";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 27).Value = "13";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 28).Value = "14";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 29).Value = "15";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 30).Value = "16";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 31).Value = "17";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 32).Value = "18";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 33).Value = "19";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 34).Value = "20";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 35).Value = "21";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 36).Value = "22";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 37).Value = "23";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 38).Value = "24";
            this.spdData_Sheet1.ColumnHeader.Cells.Get(1, 39).Value = "25";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnHeader.Rows.Get(0).Height = 17F;
            this.spdData_Sheet1.ColumnHeader.Rows.Get(1).Height = 18F;
            this.spdData_Sheet1.Columns.Get(0).Label = "Factory";
            this.spdData_Sheet1.Columns.Get(0).Width = 0F;
            this.spdData_Sheet1.Columns.Get(1).Label = "Resource";
            this.spdData_Sheet1.Columns.Get(1).Width = 0F;
            this.spdData_Sheet1.Columns.Get(2).Label = "Hist Seq";
            this.spdData_Sheet1.Columns.Get(2).Width = 0F;
            this.spdData_Sheet1.Columns.Get(3).Label = "Event ID";
            this.spdData_Sheet1.Columns.Get(3).Locked = true;
            this.spdData_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(3).Width = 30F;
            this.spdData_Sheet1.Columns.Get(4).Label = "Tran Time";
            this.spdData_Sheet1.Columns.Get(4).Locked = true;
            this.spdData_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(4).Width = 100F;
            this.spdData_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Locked = true;
            this.spdData_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(5).Width = 45F;
            this.spdData_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Locked = true;
            this.spdData_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(6).Width = 58F;
            this.spdData_Sheet1.Columns.Get(7).Locked = true;
            this.spdData_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(7).Width = 100F;
            this.spdData_Sheet1.Columns.Get(8).Label = "Character Desc";
            this.spdData_Sheet1.Columns.Get(8).Locked = true;
            this.spdData_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(8).Width = 120F;
            this.spdData_Sheet1.Columns.Get(9).Locked = true;
            this.spdData_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(9).Width = 100F;
            this.spdData_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Locked = true;
            this.spdData_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(10).Width = 30F;
            this.spdData_Sheet1.Columns.Get(11).Locked = true;
            this.spdData_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(11).Width = 100F;
            this.spdData_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Locked = true;
            this.spdData_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(12).Width = 40F;
            this.spdData_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Locked = true;
            this.spdData_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(13).Width = 40F;
            this.spdData_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(14).Locked = true;
            this.spdData_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(14).Width = 40F;
            this.spdData_Sheet1.Columns.Get(15).Label = "1";
            this.spdData_Sheet1.Columns.Get(15).Locked = true;
            this.spdData_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(16).Label = "2";
            this.spdData_Sheet1.Columns.Get(16).Locked = true;
            this.spdData_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(17).Label = "3";
            this.spdData_Sheet1.Columns.Get(17).Locked = true;
            this.spdData_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(18).Label = "4";
            this.spdData_Sheet1.Columns.Get(18).Locked = true;
            this.spdData_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(19).Label = "5";
            this.spdData_Sheet1.Columns.Get(19).Locked = true;
            this.spdData_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(20).Label = "6";
            this.spdData_Sheet1.Columns.Get(20).Locked = true;
            this.spdData_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(21).Label = "7";
            this.spdData_Sheet1.Columns.Get(21).Locked = true;
            this.spdData_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(22).Label = "8";
            this.spdData_Sheet1.Columns.Get(22).Locked = true;
            this.spdData_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(23).Label = "9";
            this.spdData_Sheet1.Columns.Get(23).Locked = true;
            this.spdData_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(24).Label = "10";
            this.spdData_Sheet1.Columns.Get(24).Locked = true;
            this.spdData_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(25).Label = "11";
            this.spdData_Sheet1.Columns.Get(25).Locked = true;
            this.spdData_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdData_Sheet1.Columns.Get(26).Label = "12";
            this.spdData_Sheet1.Columns.Get(26).Locked = true;
            this.spdData_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(27).Label = "13";
            this.spdData_Sheet1.Columns.Get(27).Locked = true;
            this.spdData_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(28).Label = "14";
            this.spdData_Sheet1.Columns.Get(28).Locked = true;
            this.spdData_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(29).Label = "15";
            this.spdData_Sheet1.Columns.Get(29).Locked = true;
            this.spdData_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(30).Label = "16";
            this.spdData_Sheet1.Columns.Get(30).Locked = true;
            this.spdData_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(31).Label = "17";
            this.spdData_Sheet1.Columns.Get(31).Locked = true;
            this.spdData_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(32).Label = "18";
            this.spdData_Sheet1.Columns.Get(32).Locked = true;
            this.spdData_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(33).Label = "19";
            this.spdData_Sheet1.Columns.Get(33).Locked = true;
            this.spdData_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(34).Label = "20";
            this.spdData_Sheet1.Columns.Get(34).Locked = true;
            this.spdData_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(35).Label = "21";
            this.spdData_Sheet1.Columns.Get(35).Locked = true;
            this.spdData_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(36).Label = "22";
            this.spdData_Sheet1.Columns.Get(36).Locked = true;
            this.spdData_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdData_Sheet1.Columns.Get(37).Label = "23";
            this.spdData_Sheet1.Columns.Get(37).Locked = true;
            this.spdData_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(38).Label = "24";
            this.spdData_Sheet1.Columns.Get(38).Locked = true;
            this.spdData_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(39).Label = "25";
            this.spdData_Sheet1.Columns.Get(39).Locked = true;
            this.spdData_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(40).Locked = true;
            this.spdData_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(40).Width = 160F;
            this.spdData_Sheet1.Columns.Get(41).Locked = true;
            this.spdData_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(41).Width = 85F;
            this.spdData_Sheet1.Columns.Get(42).Locked = true;
            this.spdData_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdData_Sheet1.Columns.Get(42).Width = 110F;
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.RowMode;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.Rows.Default.Height = 18F;
            this.spdData_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // spdResHistory
            // 
            this.spdResHistory.AccessibleDescription = "spdResHistory, Sheet1";
            this.spdResHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdResHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.spdResHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdResHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResHistory.HorizontalScrollBar.Name = "";
            this.spdResHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdResHistory.HorizontalScrollBar.TabIndex = 4;
            this.spdResHistory.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResHistory.Location = new System.Drawing.Point(0, 3);
            this.spdResHistory.Name = "spdResHistory";
            this.spdResHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdResHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdResHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdResHistory_Sheet1});
            this.spdResHistory.Size = new System.Drawing.Size(742, 160);
            this.spdResHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdResHistory.TabIndex = 0;
            this.spdResHistory.TabStop = false;
            this.spdResHistory.TextTipDelay = 200;
            this.spdResHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdResHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdResHistory.VerticalScrollBar.Name = "";
            this.spdResHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdResHistory.VerticalScrollBar.TabIndex = 5;
            this.spdResHistory.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdResHistory.SelectionChanged += new FarPoint.Win.Spread.SelectionChangedEventHandler(this.spdResHistory_SelectionChanged);
            this.spdResHistory.SetViewportLeftColumn(0, 0, 3);
            this.spdResHistory.SetActiveViewport(0, -1, -1);
            // 
            // spdResHistory_Sheet1
            // 
            this.spdResHistory_Sheet1.Reset();
            spdResHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdResHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdResHistory_Sheet1.ColumnCount = 43;
            spdResHistory_Sheet1.RowCount = 0;
            this.spdResHistory_Sheet1.ActiveColumnIndex = -1;
            this.spdResHistory_Sheet1.ActiveRowIndex = -1;
            this.spdResHistory_Sheet1.AlternatingRows.Get(1).BackColor = System.Drawing.Color.WhiteSmoke;
            this.spdResHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdResHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdResHistory_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Numbers;
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tran Time";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Event";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Up/Down";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Primary Status";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "New Status 1";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "New Status 2";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "New Status 3";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "New Status 4";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "New Status 5";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "New Status 6";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "New Status 7";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "New Status 8";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "New Status 9";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "New Status 10";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Tran Cmf 1";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Tran Cmf 2";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Tran Cmf 3";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Tran Cmf 4";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Tran Cmf 5";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Tran Cmf 6";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Tran Cmf 7";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Tran Cmf 8";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Tran Cmf 9";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Tran Cmf 10";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Tran Cmf 11";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Tran Cmf 12";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Tran Cmf 13";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Tran Cmf 14";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Tran Cmf 15";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Tran Cmf 16";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Tran Cmf 17";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Tran Cmf 18";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Tran Cmf 19";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Tran Cmf 20";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Process Mode";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Control Mode";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "User Name";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Comment";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Hist Delete Flag";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Hist Delete Time";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Hist Delete User Name";
            this.spdResHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Hist Delete Comment";
            this.spdResHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdResHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdResHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdResHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(0).Width = 30F;
            this.spdResHistory_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(1).Label = "Tran Time";
            this.spdResHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(1).Width = 140F;
            this.spdResHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(2).Label = "Event";
            this.spdResHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(2).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(4).Label = "Primary Status";
            this.spdResHistory_Sheet1.Columns.Get(4).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(5).Label = "New Status 1";
            this.spdResHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(5).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(6).Label = "New Status 2";
            this.spdResHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(6).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(7).Label = "New Status 3";
            this.spdResHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(7).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(8).Label = "New Status 4";
            this.spdResHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(8).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(9).Label = "New Status 5";
            this.spdResHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(9).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(10).Label = "New Status 6";
            this.spdResHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(10).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(11).Label = "New Status 7";
            this.spdResHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(11).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(12).Label = "New Status 8";
            this.spdResHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(12).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(13).Label = "New Status 9";
            this.spdResHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(13).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(14).Label = "New Status 10";
            this.spdResHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(14).Width = 100F;
            this.spdResHistory_Sheet1.Columns.Get(15).Label = "Tran Cmf 1";
            this.spdResHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(15).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(16).Label = "Tran Cmf 2";
            this.spdResHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(16).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(17).Label = "Tran Cmf 3";
            this.spdResHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(17).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(18).Label = "Tran Cmf 4";
            this.spdResHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(18).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(19).Label = "Tran Cmf 5";
            this.spdResHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(19).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(20).Label = "Tran Cmf 6";
            this.spdResHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(20).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(21).Label = "Tran Cmf 7";
            this.spdResHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(21).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(22).Label = "Tran Cmf 8";
            this.spdResHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(22).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(23).Label = "Tran Cmf 9";
            this.spdResHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(23).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(24).Label = "Tran Cmf 10";
            this.spdResHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(24).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(25).Label = "Tran Cmf 11";
            this.spdResHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(25).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(26).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(26).Label = "Tran Cmf 12";
            this.spdResHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(26).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(27).Label = "Tran Cmf 13";
            this.spdResHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(27).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(28).Label = "Tran Cmf 14";
            this.spdResHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(28).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(29).Label = "Tran Cmf 15";
            this.spdResHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(29).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(30).Label = "Tran Cmf 16";
            this.spdResHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(30).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(31).Label = "Tran Cmf 17";
            this.spdResHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(31).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(32).Label = "Tran Cmf 18";
            this.spdResHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(32).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(33).Label = "Tran Cmf 19";
            this.spdResHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(33).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(34).Label = "Tran Cmf 20";
            this.spdResHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(34).Width = 110F;
            this.spdResHistory_Sheet1.Columns.Get(35).Label = "Process Mode";
            this.spdResHistory_Sheet1.Columns.Get(35).Width = 95F;
            this.spdResHistory_Sheet1.Columns.Get(36).Label = "Control Mode";
            this.spdResHistory_Sheet1.Columns.Get(36).Width = 95F;
            this.spdResHistory_Sheet1.Columns.Get(37).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(37).Label = "User Name";
            this.spdResHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(37).Width = 85F;
            this.spdResHistory_Sheet1.Columns.Get(38).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(38).Label = "Comment";
            this.spdResHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(38).Width = 150F;
            this.spdResHistory_Sheet1.Columns.Get(39).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(39).Label = "Hist Delete Flag";
            this.spdResHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(39).Width = 92F;
            this.spdResHistory_Sheet1.Columns.Get(40).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(40).Label = "Hist Delete Time";
            this.spdResHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(40).Width = 95F;
            this.spdResHistory_Sheet1.Columns.Get(41).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(41).Label = "Hist Delete User Name";
            this.spdResHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(41).Width = 125F;
            this.spdResHistory_Sheet1.Columns.Get(42).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdResHistory_Sheet1.Columns.Get(42).Label = "Hist Delete Comment";
            this.spdResHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.Columns.Get(42).Width = 116F;
            this.spdResHistory_Sheet1.DefaultStyle.Locked = false;
            this.spdResHistory_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdResHistory_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdResHistory_Sheet1.FrozenColumnCount = 3;
            this.spdResHistory_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdResHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdResHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdResHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdResHistory_Sheet1.RowHeader.Visible = false;
            this.spdResHistory_Sheet1.Rows.Default.Height = 18F;
            this.spdResHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdResHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdResHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdResHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdResHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.AutoSize = true;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(484, 43);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(130, 17);
            this.chkIncludeDelHistory.TabIndex = 7;
            this.chkIncludeDelHistory.Text = "Include Delete History";
            this.chkIncludeDelHistory.CheckedChanged += new System.EventHandler(this.chkIncludeDelHistory_CheckedChanged);
            // 
            // pnlPeriod
            // 
            this.pnlPeriod.Controls.Add(this.dtpFrom);
            this.pnlPeriod.Controls.Add(this.lblPeriod);
            this.pnlPeriod.Controls.Add(this.dtpTo);
            this.pnlPeriod.Controls.Add(this.lblTo);
            this.pnlPeriod.Location = new System.Drawing.Point(484, 16);
            this.pnlPeriod.Name = "pnlPeriod";
            this.pnlPeriod.Size = new System.Drawing.Size(242, 20);
            this.pnlPeriod.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(56, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(85, 20);
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
            this.dtpTo.Location = new System.Drawing.Point(157, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(85, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(144, 6);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "~";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 163);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(742, 4);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // cdvSubResource
            // 
            this.cdvSubResource.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSubResource.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSubResource.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSubResource.BtnToolTipText = "";
            this.cdvSubResource.ButtonWidth = 20;
            this.cdvSubResource.DescText = "";
            this.cdvSubResource.DisplaySubItemIndex = -1;
            this.cdvSubResource.DisplayText = "";
            this.cdvSubResource.Focusing = null;
            this.cdvSubResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSubResource.Index = 0;
            this.cdvSubResource.IsViewBtnImage = false;
            this.cdvSubResource.Location = new System.Drawing.Point(120, 39);
            this.cdvSubResource.MaxLength = 20;
            this.cdvSubResource.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSubResource.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSubResource.MultiSelect = false;
            this.cdvSubResource.Name = "cdvSubResource";
            this.cdvSubResource.ReadOnly = false;
            this.cdvSubResource.SameWidthHeightOfButton = false;
            this.cdvSubResource.SearchSubItemIndex = 0;
            this.cdvSubResource.SelectedDescIndex = -1;
            this.cdvSubResource.SelectedDescToQueryText = "";
            this.cdvSubResource.SelectedSubItemIndex = -1;
            this.cdvSubResource.SelectedValueToQueryText = "";
            this.cdvSubResource.SelectionStart = 0;
            this.cdvSubResource.Size = new System.Drawing.Size(200, 20);
            this.cdvSubResource.SmallImageList = null;
            this.cdvSubResource.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSubResource.TabIndex = 3;
            this.cdvSubResource.TextBoxToolTipText = "";
            this.cdvSubResource.TextBoxWidth = 200;
            this.cdvSubResource.VisibleButton = true;
            this.cdvSubResource.VisibleColumnHeader = false;
            this.cdvSubResource.VisibleDescription = false;
            this.cdvSubResource.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSubResource_SelectedItemChanged);
            this.cdvSubResource.ButtonPress += new System.EventHandler(this.cdvSubResource_ButtonPress);
            this.cdvSubResource.TextBoxTextChanged += new System.EventHandler(this.cdvSubResource_TextBoxTextChanged);
            // 
            // lblSubResID
            // 
            this.lblSubResID.AutoSize = true;
            this.lblSubResID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSubResID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubResID.Location = new System.Drawing.Point(15, 42);
            this.lblSubResID.Name = "lblSubResID";
            this.lblSubResID.Size = new System.Drawing.Size(89, 13);
            this.lblSubResID.TabIndex = 2;
            this.lblSubResID.Text = "Sub Resource ID";
            // 
            // frmEDCViewResourceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmEDCViewResourceData";
            this.Text = "View Resource Data";
            this.Activated += new System.EventHandler(this.frmEDCViewResourceData_Activated);
            this.Load += new System.EventHandler(this.frmEDCViewResourceData_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvEventID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvResID)).EndInit();
            this.pnlResourceData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdResHistory_Sheet1)).EndInit();
            this.pnlPeriod.ResumeLayout(false);
            this.pnlPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSubResource)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const int HIST_SEQ_COL = 0;
        private const int EVENT_ID = 2;
        
        #endregion
        
        #region " Variable Definition"
        
        //int iLastSeq = 3;
        bool LoadFlag;
        
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
        
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            
            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    
                case "ViewResHist":
                    
                    
                    //Resource History Validation
                    if (cdvResID.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvResID.Focus();
                        return false;
                    }
                    
                    if (dtpFrom.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        dtpFrom.Focus();
                        return false;
                    }
                    
                    if (dtpTo.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        dtpTo.Focus();
                        return false;
                    }

                    if (MPCF.ToInt(MPCF.ToStandardTime(dtpFrom.Value, MPGC.MP_CONVERT_DATETIME_FORMAT)) > MPCF.ToInt(MPCF.ToStandardTime(dtpTo.Value, MPGC.MP_CONVERT_DATETIME_FORMAT)))
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(160));
                        dtpFrom.Focus();
                        return false;
                    }
                    break;
                    
                case "ViewResourceData":
                    
                    
                    //Resource Data Validation
                    if (cdvResID.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cdvResID.Focus();
                        return false;
                    }
                    
                    if (spdResHistory.Sheets[0].RowCount == 0 || spdResHistory.Sheets[0].SelectionCount == 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(161));
                        spdResHistory.Focus();
                        return false;
                    }
                    break;
                    
            }
            
            return true;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
            return false;
        }
        
    }

        private bool View_SubResource_History()
        {
            FarPoint.Win.Spread.SheetView sheetX;
            int i;
            int iRow;

            TRSNode in_node = new TRSNode("VIEW_SUB_RESOURCE_HISTORY_IN");
            TRSNode out_node = new TRSNode("VIEW_SUB_RESOURCE_HISTORY_OUT");

            try
            {
                MPCF.ClearList(spdResHistory, true);

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '2';
                in_node.AddString("RES_ID", cdvResID.Text);
                in_node.AddString("SUBRES_ID", cdvSubResource.Text);
                in_node.AddInt("NEXT_HIST_SEQ", int.MaxValue);
                in_node.AddString("FROM_TIME", MPCF.FromDate(dtpFrom));
                in_node.AddString("TO_TIME", MPCF.ToDate(dtpTo));
                in_node.AddString("EVENT_ID", cdvEventID.Text);
                in_node.AddChar("INCLUDE_DEL_HIST", chkIncludeDelHistory.Checked == true ? 'Y' : ' ');

                do
                {
                    if (MPCR.CallService("RAS", "RAS_View_Sub_Resource_History", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        sheetX = spdResHistory.ActiveSheet;
                        iRow = sheetX.RowCount;
                        sheetX.RowCount++;

                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG")) == "Y")
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Magenta;
                        }
                        else
                        {
                            sheetX.Cells[iRow, 0, iRow, sheetX.ColumnCount - 1].ForeColor = Color.Black;
                        }

                        sheetX.Cells[iRow, 0].Value = MPCF.Trim(out_node.GetList(0)[i].GetInt("HIST_SEQ"));
                        sheetX.Cells[iRow, 1].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_TIME")));
                        sheetX.Cells[iRow, 2].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("EVENT_ID"));
                        if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "D")
                        {
                            sheetX.Cells[iRow, 3].Value = "DOWN";
                        }
                        else if (MPCF.Trim(out_node.GetList(0)[i].GetChar("NEW_UP_DOWN_FLAG")) == "U")
                        {
                            sheetX.Cells[iRow, 3].Value = "UP";
                        }
                        sheetX.Cells[iRow, 4].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_PRI_STS"));
                        sheetX.Cells[iRow, 5].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_1"));
                        sheetX.Cells[iRow, 6].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_2"));
                        sheetX.Cells[iRow, 7].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_3"));
                        sheetX.Cells[iRow, 8].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_4"));
                        sheetX.Cells[iRow, 9].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_5"));
                        sheetX.Cells[iRow, 10].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_6"));
                        sheetX.Cells[iRow, 11].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_7"));
                        sheetX.Cells[iRow, 12].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_8"));
                        sheetX.Cells[iRow, 13].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_9"));
                        sheetX.Cells[iRow, 14].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("NEW_STS_10"));
                        sheetX.Cells[iRow, 15].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_1"));
                        sheetX.Cells[iRow, 16].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_2"));
                        sheetX.Cells[iRow, 17].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_3"));
                        sheetX.Cells[iRow, 18].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_4"));
                        sheetX.Cells[iRow, 19].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_5"));
                        sheetX.Cells[iRow, 20].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_6"));
                        sheetX.Cells[iRow, 21].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_7"));
                        sheetX.Cells[iRow, 22].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_8"));
                        sheetX.Cells[iRow, 23].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_9"));
                        sheetX.Cells[iRow, 24].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_10"));
                        sheetX.Cells[iRow, 25].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_11"));
                        sheetX.Cells[iRow, 26].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_12"));
                        sheetX.Cells[iRow, 27].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_13"));
                        sheetX.Cells[iRow, 28].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_14"));
                        sheetX.Cells[iRow, 29].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_15"));
                        sheetX.Cells[iRow, 30].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_16"));
                        sheetX.Cells[iRow, 31].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_17"));
                        sheetX.Cells[iRow, 32].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_18"));
                        sheetX.Cells[iRow, 33].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_19"));
                        sheetX.Cells[iRow, 34].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_CMF_20"));
                        sheetX.Cells[iRow, 35].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_USER_ID"));
                        sheetX.Cells[iRow, 36].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("TRAN_COMMENT"));
                        sheetX.Cells[iRow, 37].Value = MPCF.Trim(out_node.GetList(0)[i].GetChar("HIST_DEL_FLAG"));
                        sheetX.Cells[iRow, 38].Value = MPCF.MakeDateFormat(MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_TIME")));
                        sheetX.Cells[iRow, 39].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_USER_ID"));
                        sheetX.Cells[iRow, 40].Value = MPCF.Trim(out_node.GetList(0)[i].GetString("HIST_DEL_COMMENT"));
                    }

                    in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                } while (in_node.GetInt("NEXT_HIST_SEQ") > 0);

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }
    //
    // ViewResourceHist()
    //       - View Resource History
    // Return Value
    //       - Boolean : True or False
    // Arguments
    //       - Optional ByVal c_step As String = "1"
    //       - ByVal sColSetId As String
    
    private bool ViewResHist(string sResId, char c_step)
    {
        
        string sFromTime;
        string sToTime;
        char sIncludeDeleteHistory;
        
        sFromTime = MPCF.FromDate(dtpFrom);
        sToTime = MPCF.ToDate(dtpTo);
        sIncludeDeleteHistory = chkIncludeDelHistory.Checked == true ? 'Y' : ' ';
        
        MPCF.ClearList(spdData, true);
        
        if (RASLIST.ViewResourceHistory(spdResHistory, '2', cdvResID.Text, sIncludeDeleteHistory, cdvEventID.Text, sFromTime, sToTime, null, false) == false)
        {
            return false;
        }

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
    
    private void frmEDCViewResourceData_Load(object sender, System.EventArgs e)
    {
        
        try
        {
            
            MPCF.FieldClear(this);
            
            dtpFrom.Value = DateTime.Now.AddMonths(- 1);
            dtpTo.Value = DateTime.Now;
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
        
    }
    
    private void frmEDCViewResourceData_Activated(object sender, System.EventArgs e)
    {
        
        if (LoadFlag == false)
        {
            
            MPCF.FieldClear(this, cdvResID, null, null, null, null, false);
            MPCF.FieldClear(this, cdvEventID, null, null, null, null, false);
            MPCF.ClearList(spdResHistory, true);
            MPCF.ClearList(spdData, true);
        
            LoadFlag = true;
        }
        
    }
    
    private void cdvResID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        
        if (e.KeyChar == (char)13)
        {
            btnView_Click(sender, e);
        }
        
    }
    
    private void cdvResID_ButtonPress(object sender, System.EventArgs e)
    {
        cdvResID.Init();
        cdvResID.Columns.Add("Resource", 50, HorizontalAlignment.Left);
        cdvResID.Columns.Add("Description", 100, HorizontalAlignment.Left);
        cdvResID.SelectedSubItemIndex = 0;
        if (RASLIST.ViewResourceList(cdvResID.GetListView, false) == false)
        {
            return;
        }
        
    }
    
    //Private Sub chkIncludeOldStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    
    //    If Trim(cdvEventID.Text) = "" Then
    //        SetupHeader()
    //    Else
    //        SetStatusField()
    //    End If
    
    //End Sub
    
    private void btnView_Click(System.Object sender, System.EventArgs e)
    {
        
        if (CheckCondition("ViewResHist", MPGC.MP_STEP_CREATE) == false)
        {
            return;
        }
        if (MPCF.Trim(cdvSubResource.Text) == "")
        {
            if (ViewResHist(cdvResID.Text, '5') == false)
            {
                return;
            }
        }
        else
        {
            View_SubResource_History();
        }
    }
    
    private void cdvEventID_ButtonPress(object sender, System.EventArgs e)
    {
        
        cdvEventID.Init();
        cdvEventID.Columns.Add("Event ID", 50, HorizontalAlignment.Left);
        cdvEventID.Columns.Add("Description", 100, HorizontalAlignment.Left);
        cdvEventID.SelectedSubItemIndex = 0;
        if (cdvResID.Text != "")
        {
            if (MPCF.Trim(cdvSubResource.Text) == "")
            {
                if (RASLIST.ViewResEventList(cdvEventID.GetListView, '1', cdvResID.Text, null, "") == false)
                {
                    return;
                }
            }
            else
            {
                if (RASLIST.ViewSubResEventList(cdvEventID.GetListView, '1', cdvResID.Text, cdvSubResource.Text, null, "") == false)
                {
                    return;
                }
            }
        }
        else
        {
            cdvEventID.Text = "";
            cdvEventID.GetListView.Clear();
        }
        
    }
    
    private void spdResHistory_SelectionChanged(object sender, FarPoint.Win.Spread.SelectionChangedEventArgs e)
    {
        
        try
        {
            int iRow = 0;
            char sDelFlag;
            
            if (cdvResID.Text == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                cdvResID.Focus();
                return;
            }
            
            if (spdResHistory.Sheets[0].ActiveRowIndex < 0)
            {
                return;
            }
            
            sDelFlag = chkIncludeDelHistory.Checked == true ? 'Y' : ' ';
            iRow = spdResHistory.Sheets[0].ActiveRowIndex;
            
            EDCLIST.ViewResourceData(spdData, '1', cdvResID.Text, cdvSubResource.Text, MPCF.Trim(spdResHistory.Sheets[0].GetValue(iRow, EVENT_ID)), MPCF.ToInt(spdResHistory.Sheets[0].GetValue(iRow, HIST_SEQ_COL)), sDelFlag, null, false);
            
        }
        catch (Exception ex)
        {
            MPCF.ShowMsgBox(ex.Message);
        }
        
    }
    
    private void btnExcel_Click(System.Object sender, System.EventArgs e)
    {
        string sCond;

        sCond = "Resource ID : " + MPCF.Trim(cdvResID.Text) + "\r";
        sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));
        MPCF.ExportToExcel(spdData, this.Text, sCond);
    }
    
    
    private void chkIncludeDelHistory_CheckedChanged(System.Object sender, System.EventArgs e)
    {
        btnView_Click(sender, e);
    }
    
    private void cdvResID_TextBoxTextChanged(object sender, System.EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
    }
    
    private void cdvEventID_TextBoxKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            btnView_Click(sender,e);
        }
    }
    
    private void cdvEventID_TextBoxTextChanged(object sender, System.EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
    }

    private void cdvSubResource_ButtonPress(object sender, EventArgs e)
    {
        cdvSubResource.Init();
        MPCF.InitListView(cdvSubResource.GetListView);
        cdvSubResource.Columns.Add("Resource", 50, HorizontalAlignment.Left);
        cdvSubResource.Columns.Add("Desc", 100, HorizontalAlignment.Left);
        cdvSubResource.SelectedSubItemIndex = 0;

        RASLIST.ViewSubResourceList(cdvSubResource.GetListView, '5', cdvResID.Text);
    }
  
    private void cdvSubResource_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
    }

    private void cdvSubResource_TextBoxTextChanged(object sender, EventArgs e)
    {
        MPCF.ClearList(spdResHistory, true);
        MPCF.ClearList(spdData, true);
    }

}

//#End If


}
