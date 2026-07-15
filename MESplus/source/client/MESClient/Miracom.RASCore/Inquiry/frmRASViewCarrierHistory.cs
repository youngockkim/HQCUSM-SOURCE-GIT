
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

//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmRASViewCarrierHistory.vb
//   Description : View Tool History Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - CheckCondition()      : Check the conditions before transaction
//       - ClearData()           : Clear Fields and Initialize Sheet
//       - InitCodeView()        : Initialize MCCodeView
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2006-04-19 : Created by Aiden Koo
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.RASCore
{
    public class frmRASViewCarrierHistory : Miracom.MESCore.TranForm01
    {
#if _CRR
        
        #region " Windows Form auto generated code "
        
        public frmRASViewCarrierHistory()
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
        private System.Windows.Forms.Label lblCrrID;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblCrrType;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrType;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrID;
        private FarPoint.Win.Spread.FpSpread spdHistory;
        private FarPoint.Win.Spread.SheetView spdHistory_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvCrrGroup;
        private Label lblCrrGroup;
        private Label lblOr;
        public System.Windows.Forms.Button btnExcel;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.BevelBorder bevelBorder1 = new FarPoint.Win.BevelBorder(FarPoint.Win.BevelBorderType.Raised);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRASViewCarrierHistory));
            this.pnlMainBody = new System.Windows.Forms.Panel();
            this.spdHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlMainHeader = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.lblOr = new System.Windows.Forms.Label();
            this.cdvCrrGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrGroup = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cdvCrrType = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrType = new System.Windows.Forms.Label();
            this.cdvCrrID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblCrrID = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMainBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).BeginInit();
            this.pnlMainHeader.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).BeginInit();
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
            // 
            // pnlMainBody
            // 
            this.pnlMainBody.Controls.Add(this.spdHistory);
            this.pnlMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainBody.Location = new System.Drawing.Point(0, 66);
            this.pnlMainBody.Name = "pnlMainBody";
            this.pnlMainBody.Padding = new System.Windows.Forms.Padding(3);
            this.pnlMainBody.Size = new System.Drawing.Size(742, 447);
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
            this.spdHistory.HorizontalScrollBar.TabIndex = 4;
            this.spdHistory.Location = new System.Drawing.Point(3, 3);
            this.spdHistory.Name = "spdHistory";
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
            this.spdHistory.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdHistory.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdHistory.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHistory_Sheet1});
            this.spdHistory.Size = new System.Drawing.Size(736, 441);
            this.spdHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHistory.TabIndex = 0;
            this.spdHistory.TabStop = false;
            this.spdHistory.TextTipDelay = 200;
            this.spdHistory.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHistory.VerticalScrollBar.Name = "";
            this.spdHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdHistory.VerticalScrollBar.TabIndex = 5;
            this.spdHistory.SetViewportLeftColumn(0, 0, 4);
            this.spdHistory.SetActiveViewport(0, 0, -1);
            // 
            // spdHistory_Sheet1
            // 
            this.spdHistory_Sheet1.Reset();
            spdHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHistory_Sheet1.ColumnCount = 52;
            spdHistory_Sheet1.RowCount = 5;
            spdHistory_Sheet1.RowHeader.ColumnCount = 0;
            this.spdHistory_Sheet1.ActiveSkin = FarPoint.Win.Spread.DefaultSkins.Classic;
            this.spdHistory_Sheet1.Cells.Get(0, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(0, 25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(0, 25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(1, 25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(1, 25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(2, 25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(2, 25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(3, 25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(3, 25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Cells.Get(4, 25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Cells.Get(4, 25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.ColumnFooter.Columns.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooter.Rows.Default.VisualStyles = FarPoint.Win.VisualStyles.Auto;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "HeaderDefault";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Carrier ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Tran Code";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Carrier Status";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Sys Tran Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Tran User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Usage Count";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Clean Count";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Factory";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Location 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Location 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Location 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Location 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Location 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 15).Value = "Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 16).Value = "Sub Resource";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 17).Value = "Port ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 18).Value = "Need Clean Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 19).Value = "Fin Clean Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 20).Value = "Clean Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 21).Value = "Lot ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 22).Value = "Lot Hist Seq";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 23).Value = "Qty 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 24).Value = "Qty 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 25).Value = "Qty 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 26).Value = "Slot Table";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 27).Value = "Move Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 28).Value = "Empty Flag";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 29).Value = "Stock In Time";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 30).Value = "Tran CMF 1";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 31).Value = "Tran CMF 2";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 32).Value = "Tran CMF 3";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 33).Value = "Tran CMF 4";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 34).Value = "Tran CMF 5";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 35).Value = "Tran CMF 6";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 36).Value = "Tran CMF 7";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 37).Value = "Tran CMF 8";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 38).Value = "Tran CMF 9";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 39).Value = "Tran CMF 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 40).Value = "Tran CMF 11";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 41).Value = "Tran CMF 12";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 42).Value = "Tran CMF 13";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 43).Value = "Tran CMF 14";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 44).Value = "Tran CMF 15";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 45).Value = "Tran CMF 16";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 46).Value = "Tran CMF 17";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 47).Value = "Tran CMF 18";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 48).Value = "Tran CMF 19";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 49).Value = "Tran CMF 10";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 50).Value = "User ID";
            this.spdHistory_Sheet1.ColumnHeader.Cells.Get(0, 51).Value = "Comment";
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
            this.spdHistory_Sheet1.Columns.Get(1).Label = "Carrier ID";
            this.spdHistory_Sheet1.Columns.Get(1).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(1).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(2).Label = "Tran Time";
            this.spdHistory_Sheet1.Columns.Get(2).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(2).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(3).Label = "Tran Code";
            this.spdHistory_Sheet1.Columns.Get(3).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(3).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(4).Label = "Carrier Status";
            this.spdHistory_Sheet1.Columns.Get(4).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(4).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(4).Width = 80F;
            this.spdHistory_Sheet1.Columns.Get(5).Label = "Sys Tran Time";
            this.spdHistory_Sheet1.Columns.Get(5).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(5).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(6).Label = "Tran User ID";
            this.spdHistory_Sheet1.Columns.Get(6).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(6).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(6).Width = 120F;
            this.spdHistory_Sheet1.Columns.Get(7).Label = "Usage Count";
            this.spdHistory_Sheet1.Columns.Get(7).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(7).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(7).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(8).Label = "Clean Count";
            this.spdHistory_Sheet1.Columns.Get(8).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(8).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(8).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(9).Label = "Factory";
            this.spdHistory_Sheet1.Columns.Get(9).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(9).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(10).Label = "Location 1";
            this.spdHistory_Sheet1.Columns.Get(10).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(10).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(10).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(11).Label = "Location 2";
            this.spdHistory_Sheet1.Columns.Get(11).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(11).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(11).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(12).Label = "Location 3";
            this.spdHistory_Sheet1.Columns.Get(12).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(12).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(12).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(13).Label = "Location 4";
            this.spdHistory_Sheet1.Columns.Get(13).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(13).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(13).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(14).Label = "Location 5";
            this.spdHistory_Sheet1.Columns.Get(14).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(14).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(14).Width = 117F;
            this.spdHistory_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(15).Label = "Resource";
            this.spdHistory_Sheet1.Columns.Get(15).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(15).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(15).Width = 113F;
            this.spdHistory_Sheet1.Columns.Get(16).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(16).Label = "Sub Resource";
            this.spdHistory_Sheet1.Columns.Get(16).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(16).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(16).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(17).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(17).Label = "Port ID";
            this.spdHistory_Sheet1.Columns.Get(17).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(17).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(17).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(18).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Label = "Need Clean Flag";
            this.spdHistory_Sheet1.Columns.Get(18).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(18).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(18).Width = 100F;
            this.spdHistory_Sheet1.Columns.Get(19).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Label = "Fin Clean Flag";
            this.spdHistory_Sheet1.Columns.Get(19).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(19).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(19).Width = 112F;
            this.spdHistory_Sheet1.Columns.Get(20).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Label = "Clean Time";
            this.spdHistory_Sheet1.Columns.Get(20).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(20).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(20).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(21).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdHistory_Sheet1.Columns.Get(21).Label = "Lot ID";
            this.spdHistory_Sheet1.Columns.Get(21).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(21).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(21).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(22).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Label = "Lot Hist Seq";
            this.spdHistory_Sheet1.Columns.Get(22).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(22).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(22).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(23).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(23).Label = "Qty 1";
            this.spdHistory_Sheet1.Columns.Get(23).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(23).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(23).Width = 85F;
            this.spdHistory_Sheet1.Columns.Get(24).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(24).Label = "Qty 2";
            this.spdHistory_Sheet1.Columns.Get(24).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(24).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(24).Width = 110F;
            this.spdHistory_Sheet1.Columns.Get(25).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdHistory_Sheet1.Columns.Get(25).Label = "Qty 3";
            this.spdHistory_Sheet1.Columns.Get(25).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(25).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(25).Width = 93F;
            this.spdHistory_Sheet1.Columns.Get(26).Label = "Slot Table";
            this.spdHistory_Sheet1.Columns.Get(26).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(26).Width = 97F;
            this.spdHistory_Sheet1.Columns.Get(27).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Label = "Move Flag";
            this.spdHistory_Sheet1.Columns.Get(27).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(27).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(27).Width = 111F;
            this.spdHistory_Sheet1.Columns.Get(28).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Label = "Empty Flag";
            this.spdHistory_Sheet1.Columns.Get(28).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(28).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(28).Width = 105F;
            this.spdHistory_Sheet1.Columns.Get(29).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Label = "Stock In Time";
            this.spdHistory_Sheet1.Columns.Get(29).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(29).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(29).Width = 98F;
            this.spdHistory_Sheet1.Columns.Get(30).Label = "Tran CMF 1";
            this.spdHistory_Sheet1.Columns.Get(30).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(30).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(30).Width = 84F;
            this.spdHistory_Sheet1.Columns.Get(31).Label = "Tran CMF 2";
            this.spdHistory_Sheet1.Columns.Get(31).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(31).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(31).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(32).Label = "Tran CMF 3";
            this.spdHistory_Sheet1.Columns.Get(32).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(32).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(32).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(33).Label = "Tran CMF 4";
            this.spdHistory_Sheet1.Columns.Get(33).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(33).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(33).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(34).Label = "Tran CMF 5";
            this.spdHistory_Sheet1.Columns.Get(34).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(34).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(34).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(35).Label = "Tran CMF 6";
            this.spdHistory_Sheet1.Columns.Get(35).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(35).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(35).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(36).Label = "Tran CMF 7";
            this.spdHistory_Sheet1.Columns.Get(36).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(36).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(36).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(37).Label = "Tran CMF 8";
            this.spdHistory_Sheet1.Columns.Get(37).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(37).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(37).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(38).Label = "Tran CMF 9";
            this.spdHistory_Sheet1.Columns.Get(38).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(38).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(38).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(39).Label = "Tran CMF 10";
            this.spdHistory_Sheet1.Columns.Get(39).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(39).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(39).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(40).Label = "Tran CMF 11";
            this.spdHistory_Sheet1.Columns.Get(40).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(40).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(40).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(41).Label = "Tran CMF 12";
            this.spdHistory_Sheet1.Columns.Get(41).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(41).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(41).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(42).Label = "Tran CMF 13";
            this.spdHistory_Sheet1.Columns.Get(42).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(42).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(42).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(43).Label = "Tran CMF 14";
            this.spdHistory_Sheet1.Columns.Get(43).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(43).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(43).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(44).Label = "Tran CMF 15";
            this.spdHistory_Sheet1.Columns.Get(44).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(44).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(44).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(45).Label = "Tran CMF 16";
            this.spdHistory_Sheet1.Columns.Get(45).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(45).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(45).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(46).Label = "Tran CMF 17";
            this.spdHistory_Sheet1.Columns.Get(46).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(46).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(46).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(47).Label = "Tran CMF 18";
            this.spdHistory_Sheet1.Columns.Get(47).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(47).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(47).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(48).Label = "Tran CMF 19";
            this.spdHistory_Sheet1.Columns.Get(48).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(48).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(48).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(49).Label = "Tran CMF 10";
            this.spdHistory_Sheet1.Columns.Get(49).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(49).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(49).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(50).Label = "User ID";
            this.spdHistory_Sheet1.Columns.Get(50).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(50).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(50).Width = 90F;
            this.spdHistory_Sheet1.Columns.Get(51).Label = "Comment";
            this.spdHistory_Sheet1.Columns.Get(51).Locked = true;
            this.spdHistory_Sheet1.Columns.Get(51).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdHistory_Sheet1.Columns.Get(51).Width = 90F;
            this.spdHistory_Sheet1.FrozenColumnCount = 4;
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
            this.pnlMainHeader.Size = new System.Drawing.Size(742, 66);
            this.pnlMainHeader.TabIndex = 0;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.lblOr);
            this.grpOption.Controls.Add(this.cdvCrrGroup);
            this.grpOption.Controls.Add(this.lblCrrGroup);
            this.grpOption.Controls.Add(this.lblTo);
            this.grpOption.Controls.Add(this.lblPeriod);
            this.grpOption.Controls.Add(this.dtpTo);
            this.grpOption.Controls.Add(this.dtpFrom);
            this.grpOption.Controls.Add(this.cdvCrrType);
            this.grpOption.Controls.Add(this.lblCrrType);
            this.grpOption.Controls.Add(this.cdvCrrID);
            this.grpOption.Controls.Add(this.lblCrrID);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(736, 66);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // lblOr
            // 
            this.lblOr.AutoSize = true;
            this.lblOr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblOr.Location = new System.Drawing.Point(358, 17);
            this.lblOr.Name = "lblOr";
            this.lblOr.Size = new System.Drawing.Size(23, 13);
            this.lblOr.TabIndex = 2;
            this.lblOr.Text = "OR";
            this.lblOr.Visible = false;
            // 
            // cdvCrrGroup
            // 
            this.cdvCrrGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrGroup.BtnToolTipText = "";
            this.cdvCrrGroup.DescText = "";
            this.cdvCrrGroup.DisplaySubItemIndex = -1;
            this.cdvCrrGroup.DisplayText = "";
            this.cdvCrrGroup.Focusing = null;
            this.cdvCrrGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrGroup.Index = 0;
            this.cdvCrrGroup.IsViewBtnImage = false;
            this.cdvCrrGroup.Location = new System.Drawing.Point(125, 14);
            this.cdvCrrGroup.MaxLength = 20;
            this.cdvCrrGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrGroup.Name = "cdvCrrGroup";
            this.cdvCrrGroup.ReadOnly = false;
            this.cdvCrrGroup.SearchSubItemIndex = 0;
            this.cdvCrrGroup.SelectedDescIndex = -1;
            this.cdvCrrGroup.SelectedSubItemIndex = -1;
            this.cdvCrrGroup.SelectionStart = 0;
            this.cdvCrrGroup.Size = new System.Drawing.Size(200, 20);
            this.cdvCrrGroup.SmallImageList = null;
            this.cdvCrrGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrGroup.TabIndex = 1;
            this.cdvCrrGroup.TextBoxToolTipText = "";
            this.cdvCrrGroup.TextBoxWidth = 200;
            this.cdvCrrGroup.VisibleButton = true;
            this.cdvCrrGroup.VisibleColumnHeader = false;
            this.cdvCrrGroup.VisibleDescription = false;
            this.cdvCrrGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrGroup_SelectedItemChanged);
            this.cdvCrrGroup.ButtonPress += new System.EventHandler(this.cdvCrrGroup_ButtonPress);
            // 
            // lblCrrGroup
            // 
            this.lblCrrGroup.AutoSize = true;
            this.lblCrrGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrGroup.Location = new System.Drawing.Point(16, 17);
            this.lblCrrGroup.Name = "lblCrrGroup";
            this.lblCrrGroup.Size = new System.Drawing.Size(69, 13);
            this.lblCrrGroup.TabIndex = 0;
            this.lblCrrGroup.Text = "Carrier Group";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(618, 42);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(14, 13);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "~";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPeriod.Location = new System.Drawing.Point(417, 42);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(37, 13);
            this.lblPeriod.TabIndex = 7;
            this.lblPeriod.Text = "Period";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(634, 38);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(90, 20);
            this.dtpTo.TabIndex = 10;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(523, 38);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(90, 20);
            this.dtpFrom.TabIndex = 8;
            // 
            // cdvCrrType
            // 
            this.cdvCrrType.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrType.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrType.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrType.BtnToolTipText = "";
            this.cdvCrrType.DescText = "";
            this.cdvCrrType.DisplaySubItemIndex = -1;
            this.cdvCrrType.DisplayText = "";
            this.cdvCrrType.Focusing = null;
            this.cdvCrrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrType.Index = 0;
            this.cdvCrrType.IsViewBtnImage = false;
            this.cdvCrrType.Location = new System.Drawing.Point(523, 14);
            this.cdvCrrType.MaxLength = 10;
            this.cdvCrrType.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrType.Name = "cdvCrrType";
            this.cdvCrrType.ReadOnly = false;
            this.cdvCrrType.SearchSubItemIndex = 0;
            this.cdvCrrType.SelectedDescIndex = -1;
            this.cdvCrrType.SelectedSubItemIndex = -1;
            this.cdvCrrType.SelectionStart = 0;
            this.cdvCrrType.Size = new System.Drawing.Size(200, 20);
            this.cdvCrrType.SmallImageList = null;
            this.cdvCrrType.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrType.TabIndex = 4;
            this.cdvCrrType.TextBoxToolTipText = "";
            this.cdvCrrType.TextBoxWidth = 200;
            this.cdvCrrType.VisibleButton = true;
            this.cdvCrrType.VisibleColumnHeader = false;
            this.cdvCrrType.VisibleDescription = false;
            this.cdvCrrType.ButtonPress += new System.EventHandler(this.cdvCrrType_ButtonPress);
            // 
            // lblCrrType
            // 
            this.lblCrrType.AutoSize = true;
            this.lblCrrType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrType.Location = new System.Drawing.Point(417, 17);
            this.lblCrrType.Name = "lblCrrType";
            this.lblCrrType.Size = new System.Drawing.Size(64, 13);
            this.lblCrrType.TabIndex = 3;
            this.lblCrrType.Text = "Carrier Type";
            // 
            // cdvCrrID
            // 
            this.cdvCrrID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvCrrID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvCrrID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvCrrID.BtnToolTipText = "";
            this.cdvCrrID.DescText = "";
            this.cdvCrrID.DisplaySubItemIndex = -1;
            this.cdvCrrID.DisplayText = "";
            this.cdvCrrID.Focusing = null;
            this.cdvCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvCrrID.Index = 0;
            this.cdvCrrID.IsViewBtnImage = false;
            this.cdvCrrID.Location = new System.Drawing.Point(125, 38);
            this.cdvCrrID.MaxLength = 20;
            this.cdvCrrID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvCrrID.Name = "cdvCrrID";
            this.cdvCrrID.ReadOnly = false;
            this.cdvCrrID.SearchSubItemIndex = 0;
            this.cdvCrrID.SelectedDescIndex = -1;
            this.cdvCrrID.SelectedSubItemIndex = -1;
            this.cdvCrrID.SelectionStart = 0;
            this.cdvCrrID.Size = new System.Drawing.Size(200, 20);
            this.cdvCrrID.SmallImageList = null;
            this.cdvCrrID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvCrrID.TabIndex = 6;
            this.cdvCrrID.TextBoxToolTipText = "";
            this.cdvCrrID.TextBoxWidth = 200;
            this.cdvCrrID.VisibleButton = true;
            this.cdvCrrID.VisibleColumnHeader = false;
            this.cdvCrrID.VisibleDescription = false;
            this.cdvCrrID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvCrrID_SelectedItemChanged);
            this.cdvCrrID.ButtonPress += new System.EventHandler(this.cdvCrrID_ButtonPress);
            this.cdvCrrID.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvCrrID_TextBoxKeyPress);
            // 
            // lblCrrID
            // 
            this.lblCrrID.AutoSize = true;
            this.lblCrrID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCrrID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrrID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCrrID.Location = new System.Drawing.Point(16, 41);
            this.lblCrrID.Name = "lblCrrID";
            this.lblCrrID.Size = new System.Drawing.Size(61, 13);
            this.lblCrrID.TabIndex = 5;
            this.lblCrrID.Text = "Carrier ID";
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
            // frmRASViewCarrierHistory
            // 
            this.AcceptButton = this.btnProcess;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmRASViewCarrierHistory";
            this.Text = "View Carrier History";
            this.Activated += new System.EventHandler(this.frmRASViewCarrierHistory_Activated);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlMainBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHistory_Sheet1)).EndInit();
            this.pnlMainHeader.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvCrrID)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition"
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;
        
        #endregion
        
        #region " Function Definition "
        
        // ClearData()
        //       - Initalize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String
        //
        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    MPCF.FieldClear(this);

                    MPCF.ClearList(spdHistory, true);
                    MPCF.FitColumnHeader(spdHistory);
                    
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        //
        // ViewCarrierHistoryLocal()
        //       - View Carrier History
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void ViewCarrierHistoryLocal()
        {
            
            if (CheckCondition("View_Carrier_History") == true)
            {
                
                if (RASLIST.ViewCarrierHistory(spdHistory, '1', cdvCrrID.Text, MPCF.FromDate(dtpFrom), MPCF.ToDate(dtpTo), null, false) == false)
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

            if (MPCF.CheckValue(cdvCrrID, 1) == false)
            {
                return false;
            }

            switch (MPCF.Trim(FuncName))
            {
                case "View_Carrier_History":
                    
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
                return this.cdvCrrID;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASViewCarrierHistory_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                ClearData('1');
                dtpFrom.Value = DateTime.Today.AddMonths(- 1);
                dtpTo.Value = DateTime.Today;
                b_load_flag = true;
                if (MPGO.RequireCarrierFilter() == true)
                {
                    lblOr.Visible = true;
                }
                if (MPCF.Trim(MPGV.gsCurrentCrrID) != "")
                {
                    cdvCrrID.Text = MPGV.gsCurrentCrrID;
                    cdvCrrID_SelectedItemChanged(null, null);
                    MPGV.gsCurrentCrrID = "";
                }
            }
        }
        
        private void btnProcess_Click(System.Object sender, System.EventArgs e)
        {
            ViewCarrierHistoryLocal();
        }
        
        private void cdvCrrID_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnProcess_Click(null, null);
        }
        
        private void cdvCrrID_TextBoxKeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (cdvCrrID.Text != "")
                {
                    btnProcess_Click(null, null);
                }
            }
            
        }
        
        private void cdvCrrID_ButtonPress(System.Object sender, System.EventArgs e)
        {
            if (MPCF.Trim(cdvCrrGroup.Text) == "" && MPCF.Trim(cdvCrrType.Text) == "")
            {
                if (MPGO.RequireCarrierFilter() == true)
                {
                    if (MPCF.Trim(cdvCrrID.Text) == "")
                    {
                        cdvCrrID.IsPopup = false;
                        MPCF.ShowMsgBox(MPCF.GetMessage(258));
                        cdvCrrID.Focus();
                        return;
                    }
                }
            }
            
            cdvCrrID.Init();
            MPCF.InitListView(cdvCrrID.GetListView);
            cdvCrrID.Columns.Add("Carrier ID", 50, HorizontalAlignment.Left);
            cdvCrrID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrID.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierList(cdvCrrID.GetListView, '1', cdvCrrGroup.Text, cdvCrrType.Text, cdvCrrID.Text);
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            
            sCond = "Carrier Type : " + MPCF.Trim(cdvCrrType.Text) + "\r";
            sCond = sCond + "Carrier ID : " + MPCF.Trim(cdvCrrID.Text) + "\r";
            sCond = sCond + "Date : " + MPCF.MakeDateFormat(MPCF.FromDate(dtpFrom)) + " ~ " + MPCF.MakeDateFormat(MPCF.ToDate(dtpTo));

            MPCF.ExportToExcel(spdHistory, this.Text, sCond);
            
        }
        
        private void cdvCrrType_ButtonPress(object sender, System.EventArgs e)
        {
            cdvCrrType.Init();
            MPCF.InitListView(cdvCrrType.GetListView);
            cdvCrrType.Columns.Add("Carrier Type", 50, HorizontalAlignment.Left);
            cdvCrrType.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrType.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(cdvCrrType.GetListView, '1', MPGC.MP_RAS_CRR_TYPE1);
        }

        private void cdvCrrGroup_ButtonPress(object sender, EventArgs e)
        {
            cdvCrrGroup.Init();
            MPCF.InitListView(cdvCrrGroup.GetListView);
            cdvCrrGroup.Columns.Add("Carrier Group", 50, HorizontalAlignment.Left);
            cdvCrrGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            cdvCrrGroup.SelectedSubItemIndex = 0;
            RASLIST.ViewCarrierGroupList(cdvCrrGroup.GetListView);
            cdvCrrGroup.InsertEmptyRow(0, 1);
        }

        private void cdvCrrGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            if (MPCF.Trim(cdvCrrGroup.Text) != "")
            {
                cdvCrrID.Text = "";
            }
        }

#endif
    }
    
}
