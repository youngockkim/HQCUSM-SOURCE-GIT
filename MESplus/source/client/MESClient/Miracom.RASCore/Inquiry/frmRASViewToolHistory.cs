
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
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASViewToolHistory.vb
//   Description : View Tool History Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_Tool_Type() : View Tool Type Information and find available Prompt
//       - ViewToolHistory_Local() : View Tool History (Local)
//       - CheckCondition()      : Check the conditions before transaction
//       - ClearData()           : Clear Fields and Initialize Sheet
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-21 : Created by Daniel Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
//#If _TOOL = True Then


namespace Miracom.RASCore
{
    public class frmRASViewToolHistory : Miracom.MESCore.TranForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASViewToolHistory()
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
        



        private System.Windows.Forms.Panel pnlMainBody;
        private System.Windows.Forms.Panel pnlMainHeader;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.Label lblToolType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolID;
        private System.Windows.Forms.Label lblEventID;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvToolType;
        public System.Windows.Forms.Button btnExcel;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private System.Windows.Forms.CheckBox chkIncludeDelHistory;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASViewToolHistory));
            this.pnlMainBody = new System.Windows.Forms.Panel();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlMainHeader = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.chkIncludeDelHistory = new System.Windows.Forms.CheckBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cdvToolType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblToolType = new System.Windows.Forms.Label();
            this.cdvToolID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEventID = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMainBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.pnlMainHeader.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).BeginInit();
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
            this.pnlBottom.TabIndex = 0;
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnProcess, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlMainBody);
            this.pnlCenter.Controls.Add(this.pnlMainHeader);
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "View Tool History";
            // 
            // pnlMainBody
            // 
            this.pnlMainBody.Controls.Add(this.spdHistory);
            this.pnlMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainBody.Location = new System.Drawing.Point(0, 71);
            this.pnlMainBody.Name = "pnlMainBody";
            this.pnlMainBody.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMainBody.Size = new System.Drawing.Size(742, 442);
            this.pnlMainBody.TabIndex = 1;
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
            this.spdHistory.Location = new System.Drawing.Point(3, 3);
            this.spdHistory.Name = "spdHistory";
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(736, 436);
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
            spdHistory_Sheet1.ColumnCount = 63;
            spdHistory_Sheet1.RowCount = 5;
            spdHistory_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistory_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic;
            this.spdHistory_Sheet1.Cells.Get(0, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Tool Event";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Tool Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Tool Group";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Tool Set ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Tool Set Location";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Sub Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Resource ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Sub Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Material";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Mat Ver";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Flow";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Operation";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Area ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Sub Area ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Tool Location";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Vendor";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Vendor Tool ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Cell Count [X,Y,Z]";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Cell Size [X,Y,Z]";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Grade";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Tool_Status_1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Tool_Status_2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Tool_Status_3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Tool_Status_4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Tool_Status_5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Tool_Status_6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Tool_Status_7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Tool_Status_8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Tool_Status_9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Tool_Status_10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Tool_Status_11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Tool_Status_12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Tool_Status_13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Tool_Status_14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Tool_Status_15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Tool_Status_16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Tool_Status_17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Tool_Status_18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Tool_Status_19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Tool_Status_20";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Tool_Status_21";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Tool_Status_22";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Tool_Status_23";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Tool_Status_24";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Tool_Status_25";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Tool_Status_26";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Tool_Status_27";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "Tool_Status_28";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Tool_Status_29";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 52).Value = "Tool_Status_30";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 53).Value = "Defect Collect Count";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 54).Value = "Defect Clean Count";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 55).Value = "Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 56).Value = "User Name";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 57).Value = "Comment";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 58).Value = "Previous Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 59).Value = "Hist Delete Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 60).Value = "Hist Delete Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 61).Value = "Hist Delete User Name";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 62).Value = "Hist Delete Comment";
            this.spdHistory_Sheet1.ColumnHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Columns.Get(0).BackColor = System.Drawing.SystemColors.Control;
            this.spdHistory_Sheet1.Columns.Get(0).Border = bevelBorder1;
            this.spdHistory_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Label = "Seq";
            this.spdHistory_Sheet1.Columns.Get(0).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(0).Width = 50F;
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Tool Event";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Tool Status";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Tool Group";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Tool Set ID";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Tool Set Location";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Lot ID";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 113F;
            this.spdHistory_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Sub Lot ID";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Resource ID";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(9).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Sub Resource";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 112F;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Material";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 123F;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Mat Ver";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Flow";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Operation";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Area ID";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Sub Area ID";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Tool Location";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Vendor";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Vendor Tool ID";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Cell Count [X,Y,Z]";
            this.spdHistory_Sheet1.Columns.Get(20).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 105F;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Cell Size [X,Y,Z]";
            this.spdHistory_Sheet1.Columns.Get(21).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Grade";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Tool_Status_1";
            this.spdHistory_Sheet1.Columns.Get(23).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Tool_Status_2";
            this.spdHistory_Sheet1.Columns.Get(24).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Tool_Status_3";
            this.spdHistory_Sheet1.Columns.Get(25).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Tool_Status_4";
            this.spdHistory_Sheet1.Columns.Get(26).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Tool_Status_5";
            this.spdHistory_Sheet1.Columns.Get(27).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Tool_Status_6";
            this.spdHistory_Sheet1.Columns.Get(28).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Tool_Status_7";
            this.spdHistory_Sheet1.Columns.Get(29).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Tool_Status_8";
            this.spdHistory_Sheet1.Columns.Get(30).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Tool_Status_9";
            this.spdHistory_Sheet1.Columns.Get(31).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Tool_Status_10";
            this.spdHistory_Sheet1.Columns.Get(32).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Tool_Status_11";
            this.spdHistory_Sheet1.Columns.Get(33).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Tool_Status_12";
            this.spdHistory_Sheet1.Columns.Get(34).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Tool_Status_13";
            this.spdHistory_Sheet1.Columns.Get(35).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(35).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Tool_Status_14";
            this.spdHistory_Sheet1.Columns.Get(36).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(36).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "Tool_Status_15";
            this.spdHistory_Sheet1.Columns.Get(37).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Tool_Status_16";
            this.spdHistory_Sheet1.Columns.Get(38).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Tool_Status_17";
            this.spdHistory_Sheet1.Columns.Get(39).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Tool_Status_18";
            this.spdHistory_Sheet1.Columns.Get(40).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Tool_Status_19";
            this.spdHistory_Sheet1.Columns.Get(41).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "Tool_Status_20";
            this.spdHistory_Sheet1.Columns.Get(42).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(43).Label = "Tool_Status_21";
            this.spdHistory_Sheet1.Columns.Get(43).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(43).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(44).Label = "Tool_Status_22";
            this.spdHistory_Sheet1.Columns.Get(44).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(44).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(45).Label = "Tool_Status_23";
            this.spdHistory_Sheet1.Columns.Get(45).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(45).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(46).Label = "Tool_Status_24";
            this.spdHistory_Sheet1.Columns.Get(46).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(46).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(47).Label = "Tool_Status_25";
            this.spdHistory_Sheet1.Columns.Get(47).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(47).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(48).Label = "Tool_Status_26";
            this.spdHistory_Sheet1.Columns.Get(48).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(48).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(49).Label = "Tool_Status_27";
            this.spdHistory_Sheet1.Columns.Get(49).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(49).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(50).Label = "Tool_Status_28";
            this.spdHistory_Sheet1.Columns.Get(50).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(50).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(51).Label = "Tool_Status_29";
            this.spdHistory_Sheet1.Columns.Get(51).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(51).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(52).Label = "Tool_Status_30";
            this.spdHistory_Sheet1.Columns.Get(52).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(52).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(53).Label = "Defect Collect Count";
            this.spdHistory_Sheet1.Columns.Get(53).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(53).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(54).Label = "Defect Clean Count";
            this.spdHistory_Sheet1.Columns.Get(54).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(54).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(55).Label = "Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(55).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(55).Width = 81F;
            this.spdHistory_Sheet1.Columns.Get(56).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(56).Label = "User Name";
            this.spdHistory_Sheet1.Columns.Get(56).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(56).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(56).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(57).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(57).Label = "Comment";
            this.spdHistory_Sheet1.Columns.Get(57).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(57).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(57).Width = 228F;
            this.spdHistory_Sheet1.Columns.Get(58).Label = "Previous Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(58).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(58).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(59).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(59).Label = "Hist Delete Flag";
            this.spdHistory_Sheet1.Columns.Get(59).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(59).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(59).Width = 105F;
            this.spdHistory_Sheet1.Columns.Get(60).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(60).Label = "Hist Delete Time";
            this.spdHistory_Sheet1.Columns.Get(60).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(60).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(60).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(61).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(61).Label = "Hist Delete User Name";
            this.spdHistory_Sheet1.Columns.Get(61).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(61).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(61).Width = 139F;
            this.spdHistory_Sheet1.Columns.Get(62).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(62).Label = "Hist Delete Comment";
            this.spdHistory_Sheet1.Columns.Get(62).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(62).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(62).Width = 144F;
            this.spdHistory_Sheet1.FrozenColumnCount = 3;
            this.spdHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHistory_Sheet1.RowHeader.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.RowHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.RowHeader.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.Rows.Get(0).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(1).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(2).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(3).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(4).Height = 18F;
            this.spdHistory_Sheet1.Rows.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Rows.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.SelectionPolicy = FarPoint.Win.Spread.Model.SelectionPolicy.Single;
            this.spdHistory_Sheet1.SelectionUnit = FarPoint.Win.Spread.Model.SelectionUnit.Row;
            this.spdHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.SheetCornerStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlMainHeader
            // 
            this.pnlMainHeader.Controls.Add(this.grpOption);
            this.pnlMainHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlMainHeader.Name = "pnlMainHeader";
            this.pnlMainHeader.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlMainHeader.Size = new System.Drawing.Size(742, 71);
            this.pnlMainHeader.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkIncludeDelHistory);
            this.grpOption.Controls.Add(this.lblTo);
            this.grpOption.Controls.Add(this.lblPeriod);
            this.grpOption.Controls.Add(this.dtpTo);
            this.grpOption.Controls.Add(this.dtpFrom);
            this.grpOption.Controls.Add(this.cdvToolType);
            this.grpOption.Controls.Add(this.lblToolType);
            this.grpOption.Controls.Add(this.cdvToolID);
            this.grpOption.Controls.Add(this.lblEventID);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 71);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // chkIncludeDelHistory
            // 
            this.chkIncludeDelHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludeDelHistory.AutoSize = true;
            this.chkIncludeDelHistory.Location = new System.Drawing.Point(463, 42);
            this.chkIncludeDelHistory.Name = "chkIncludeDelHistory";
            this.chkIncludeDelHistory.Size = new System.Drawing.Size(136, 17);
            this.chkIncludeDelHistory.TabIndex = 8;
            this.chkIncludeDelHistory.Text = "Include Deleted History";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(616, 18);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "~";
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(458, 18);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(37, 13);
            this.lblPeriod.TabIndex = 4;
            this.lblPeriod.Text = "Period";
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(634, 16);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 7;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(522, 15);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 5;
            // 
            // cdvToolType
            // 
            this.cdvToolType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolType.BtnToolTipText = "";
            this.cdvToolType.DescText = "";
            this.cdvToolType.DisplaySubItemIndex = -1;
            this.cdvToolType.DisplayText = "";
            this.cdvToolType.Focusing = null;
            this.cdvToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolType.Index = 0;
            this.cdvToolType.IsViewBtnImage = false;
            this.cdvToolType.Location = new System.Drawing.Point(120, 16);
            this.cdvToolType.MaxLength = 20;
            this.cdvToolType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolType.Name = "cdvToolType";
            this.cdvToolType.ReadOnly = true;
            this.cdvToolType.SearchSubItemIndex = 0;
            this.cdvToolType.SelectedDescIndex = -1;
            this.cdvToolType.SelectedSubItemIndex = -1;
            this.cdvToolType.SelectionStart = 0;
            this.cdvToolType.Size = new System.Drawing.Size(200, 20);
            this.cdvToolType.SmallImageList = null;
            this.cdvToolType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolType.TabIndex = 1;
            this.cdvToolType.TextBoxToolTipText = "";
            this.cdvToolType.TextBoxWidth = 200;
            this.cdvToolType.VisibleButton = true;
            this.cdvToolType.VisibleColumnHeader = false;
            this.cdvToolType.VisibleDescription = false;
            this.cdvToolType.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToolType_SelectedItemChanged);
            this.cdvToolType.ButtonPress += new System.EventHandler(this.cdvToolType_ButtonPress);
            // 
            // lblToolType
            // 
            this.lblToolType.AutoSize = true;
            this.lblToolType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToolType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToolType.Location = new System.Drawing.Point(15, 19);
            this.lblToolType.Name = "lblToolType";
            this.lblToolType.Size = new System.Drawing.Size(64, 13);
            this.lblToolType.TabIndex = 0;
            this.lblToolType.Text = "Tool Type";
            // 
            // cdvToolID
            // 
            this.cdvToolID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvToolID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvToolID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvToolID.BtnToolTipText = "";
            this.cdvToolID.DescText = "";
            this.cdvToolID.DisplaySubItemIndex = -1;
            this.cdvToolID.DisplayText = "";
            this.cdvToolID.Focusing = null;
            this.cdvToolID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvToolID.Index = 0;
            this.cdvToolID.IsViewBtnImage = false;
            this.cdvToolID.Location = new System.Drawing.Point(120, 40);
            this.cdvToolID.MaxLength = 30;
            this.cdvToolID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvToolID.Name = "cdvToolID";
            this.cdvToolID.ReadOnly = false;
            this.cdvToolID.SearchSubItemIndex = 0;
            this.cdvToolID.SelectedDescIndex = -1;
            this.cdvToolID.SelectedSubItemIndex = -1;
            this.cdvToolID.SelectionStart = 0;
            this.cdvToolID.Size = new System.Drawing.Size(200, 20);
            this.cdvToolID.SmallImageList = null;
            this.cdvToolID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvToolID.TabIndex = 3;
            this.cdvToolID.TextBoxToolTipText = "";
            this.cdvToolID.TextBoxWidth = 200;
            this.cdvToolID.VisibleButton = true;
            this.cdvToolID.VisibleColumnHeader = false;
            this.cdvToolID.VisibleDescription = false;
            this.cdvToolID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvToolID_SelectedItemChanged);
            this.cdvToolID.ButtonPress += new System.EventHandler(this.cdvToolID_ButtonPress);
            this.cdvToolID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvToolID_TextBoxKeyPress);
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEventID.Location = new System.Drawing.Point(15, 43);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(32, 13);
            this.lblEventID.TabIndex = 2;
            this.lblEventID.Text = "Tool";
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcel.Location = new System.Drawing.Point(16, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(24, 24);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // frmRASViewToolHistory
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASViewToolHistory";
            this.Text = "View Tool History";
            this.Activated += new System.EventHandler(this.frmRASViewToolHistory_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMainBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.pnlMainHeader.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvToolID)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition"
        private const int COL_HIST_SEQ = 0;
        private const int COL_TOOL_EVENT_ID = 1;
        private const int COL_TOOL_STS_1 = 23;
        private const int COL_TOOL_STS_30 = 52;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        public bool LoadFlag
        {
            get
            {
                return b_load_flag;
            }
            set
            {
                b_load_flag = value;
            }
        }
        
        #endregion
        
        #region " Function Definition "
        
        //
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String
        //
        private void ClearData(char ProcStep)
        {
            int i;
            
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this);
                    
                    MPCF.ClearList(spdHistory, true);
                    MPCF.FitColumnHeader(spdHistory);
                    
                    for (i = COL_TOOL_STS_1; i <= COL_TOOL_STS_30; i++)
                    {
                        spdHistory.Sheets[0].Columns[i].Visible = false;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, i].Text = "";
                    }
                    
                }
                else if (ProcStep == '2')
                {
                    cdvToolID.Text = "";
                    MPCF.ClearList(spdHistory, true);
                    MPCF.FitColumnHeader(spdHistory);
                    
                    for (i = COL_TOOL_STS_1; i <= COL_TOOL_STS_30; i++)
                    {
                        spdHistory.Sheets[0].Columns[i].Visible = false;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, i].Text = "";
                    }
                    
                }
                else if (ProcStep == '3')
                {
                    MPCF.ClearList(spdHistory, true);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private bool View_Tool_Type()
        {
            TRSNode in_node = new TRSNode("View_Tool_Type_In");
            TRSNode out_node = new TRSNode("View_Tool_Type_Out");
              
            int i;
            int iCoL;
            
            try
            {
                ClearData('2');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TOOL_TYPE", cdvToolType.Text);

                if (MPCR.CallService("RAS", "RAS_View_Tool_Type", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                iCoL = COL_TOOL_STS_1;
                for (i = 0; i < 30; i++)
                {
                    if (MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT")) != "")
                    {
                        spdHistory.Sheets[0].Columns[iCoL].Visible = true;
                        spdHistory.Sheets[0].ColumnHeader.Cells[0, iCoL].Text = MPCF.Trim(out_node.GetList(0)[i].GetString("PROMPT"));
                    }
                    iCoL++;
                }
                
                MPCF.FitColumnHeader(spdHistory);
                
                return true;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        //
        // ViewToolHistory_Local()
        //       - View Tool History (Local)
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void ViewToolHistory_Local()
        {
            
            if (CheckCondition("View_Tool_History") == true)
            {
                if (spdHistory.Sheets[0].RowCount > 0)
                {
                    ClearData('3');
                }
                
                if (RASLIST.ViewToolHistory(spdHistory, '1', cdvToolID.Text, cdvToolType.Text, "", MPCF.FromDate(dtpFrom), MPCF.ToDate(dtpTo), (chkIncludeDelHistory.Checked == true ? 'Y' : ' '), null, false) == false)
                {
                    return;
                }
                
                MPCF.FitColumnHeader(spdHistory);
            }
            
        }
        
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

            if (MPCF.CheckValue(cdvToolType, 1) == false)
            {
                return false;
            }
            if (MPCF.CheckValue(cdvToolID, 1) == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "View_Tool_History":
                    
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
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.cdvToolType;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASViewToolHistory_Activated(object sender, System.EventArgs e)
        {
            
            if (LoadFlag == false)
            {
                ClearData('1');
                dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                dtpTo.Value = DateTime.Today;
                LoadFlag = true;

                if (MPCF.Trim(MPGV.gsCurrentToolID) != "")
                {
                    cdvToolType.Text = MPGV.gsCurrentToolType;
                    cdvToolType_SelectedItemChanged(null, null);
                    cdvToolID.Text = MPGV.gsCurrentToolID;
                    cdvToolID_SelectedItemChanged(null, null);
                    MPGV.gsCurrentToolType = "";
                    MPGV.gsCurrentToolID = "";
                }
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            ViewToolHistory_Local();
        }
        
        private void cdvToolID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            ClearData('3');
            btnProcess_Click(null, null);
        }
        
        private void cdvToolID_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            if (MPCF.CheckValue(cdvToolType, 1) == false)
            {
                e.Handled = true;
                return;
            }
            
            if (((System.Windows.Forms.KeyPressEventArgs) e).KeyChar == (char)13)
            {
                btnProcess_Click(null, null);
            }
            else
            {
                ClearData('3');
            }
            
        }
        
        private void cdvToolID_ButtonPress(object sender, System.EventArgs e)
        {
            if (MPCF.CheckValue(cdvToolType, 1) == false)
            {
                return;
            }
            cdvToolID.Init();
            MPCF.InitListView(cdvToolID.GetListView);
            cdvToolID.Columns.Add("Tool ID", 50, HorizontalAlignment.Left);
            cdvToolID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolID.SelectedSubItemIndex = 0;
            RASLIST.ViewToolList(cdvToolID.GetListView, '2', cdvToolType.Text, ' ', false, null);
            cdvToolID.AddEmptyRow(1);
        }
        
        private void cdvToolType_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (cdvToolType.Text != "")
            {
                View_Tool_Type();
            }
        }
        
        private void cdvToolType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvToolType.Init();
            MPCF.InitListView(cdvToolType.GetListView);
            cdvToolType.Columns.Add("Tool Type", 50, HorizontalAlignment.Left);
            cdvToolType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvToolType.SelectedSubItemIndex = 0;
            RASLIST.ViewToolTypeList(cdvToolType.GetListView, '1', 'N', 'N', null);
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "Tool Type : " + MPCF.Trim(cdvToolType.Text) + "\r";
            sCond = sCond + "Tool ID : " + MPCF.Trim(cdvToolID.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));

            MPCF.ExportToExcel(spdHistory, this.Text, sCond);
            
        }
    }
    
    //#End If
}
