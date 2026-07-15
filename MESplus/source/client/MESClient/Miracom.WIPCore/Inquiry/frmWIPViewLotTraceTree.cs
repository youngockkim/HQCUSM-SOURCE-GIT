
//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmWIPViewLotTraceTree.vb
//   Description : MES Cient Form View Lot Trace Class
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - View_Lot_Trace_Tree() : View Lot Trace History
//       - SetData() : Set Trace Data into spdLotHistory
//       - FindLot() : Find Lot Id Node
//       - AddLot() : Add New Lot id into spdLotList
//       - FindNodeCount() : Count only Child Node of Parent Node
//       - FindNodeCount() : Count All Child Node of Parent Node
//       - GetNextDepthChar() : Get Level Character
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2006-12-26 : Created by James Kwon
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

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


namespace Miracom.WIPCore
{
    public class frmWIPViewLotTraceTree : Miracom.MESCore.ViewForm01
    {
        
        #region " Windows Form auto generated code "
        
        public frmWIPViewLotTraceTree()
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

        private System.ComponentModel.IContainer components;

        
        



        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.RadioButton rbnPtoC;
        private System.Windows.Forms.RadioButton rbnCtoP;
        private System.Windows.Forms.Splitter sptInfo;
        private System.Windows.Forms.ImageList imlSPIcons;
        private System.Windows.Forms.ContextMenu ctxLotTrace;
        private System.Windows.Forms.MenuItem mnuPtoC;
        private System.Windows.Forms.MenuItem mnuCtoP;
        private System.Windows.Forms.MenuItem mnuLotStatus;
        private System.Windows.Forms.TabControl tabTree;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.TabPage TabPage3;
        private FarPoint.Win.Spread.FpSpread spdTree;
        private FarPoint.Win.Spread.SheetView spdTree_Sheet1;
        private System.Windows.Forms.CheckBox chkOperDesc;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtView;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ListView lisTemp;
        private System.Windows.Forms.ListView lisLotList;
        private System.Windows.Forms.TextBox txtSMCount;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button cmdZoom;
        private System.Windows.Forms.TextBox txtZoom;
        private System.Windows.Forms.ListView lisLast;
        private FarPoint.Win.Spread.FpSpread spdLotHistory;
        private FarPoint.Win.Spread.SheetView spdLotHistory_Sheet1;
        private FarPoint.Win.Spread.FpSpread spdLotStatus;
        private FarPoint.Win.Spread.SheetView spdLotStatus_Sheet1;
        private System.Windows.Forms.ColumnHeader LOT_ID;
        private System.Windows.Forms.ColumnHeader HIST_SEQ;
        private System.Windows.Forms.ColumnHeader SM_Flag;
        private System.Windows.Forms.ColumnHeader Lot_Level;
        private System.Windows.Forms.CheckBox chkSM;
        private System.Windows.Forms.MenuItem mnuLotHistory;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer4 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer4 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWIPViewLotTraceTree));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer1 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle4 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType1 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance2 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance3 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.lblLotID = new System.Windows.Forms.Label();
            this.rbnPtoC = new System.Windows.Forms.RadioButton();
            this.rbnCtoP = new System.Windows.Forms.RadioButton();
            this.sptInfo = new System.Windows.Forms.Splitter();
            this.imlSPIcons = new System.Windows.Forms.ImageList(this.components);
            this.ctxLotTrace = new System.Windows.Forms.ContextMenu();
            this.mnuPtoC = new System.Windows.Forms.MenuItem();
            this.mnuCtoP = new System.Windows.Forms.MenuItem();
            this.mnuLotStatus = new System.Windows.Forms.MenuItem();
            this.mnuLotHistory = new System.Windows.Forms.MenuItem();
            this.tabTree = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.spdTree = new FarPoint.Win.Spread.FpSpread();
            this.spdTree_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.spdLotHistory = new FarPoint.Win.Spread.FpSpread();
            this.spdLotHistory_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.spdLotStatus = new FarPoint.Win.Spread.FpSpread();
            this.spdLotStatus_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.lisLast = new System.Windows.Forms.ListView();
            this.lisTemp = new System.Windows.Forms.ListView();
            this.chkOperDesc = new System.Windows.Forms.CheckBox();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtView = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.lisLotList = new System.Windows.Forms.ListView();
            this.LOT_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HIST_SEQ = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SM_Flag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Lot_Level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSMCount = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cmdZoom = new System.Windows.Forms.Button();
            this.txtZoom = new System.Windows.Forms.TextBox();
            this.chkSM = new System.Windows.Forms.CheckBox();
            this.pnlViewTop.SuspendLayout();
            this.grpOption.SuspendLayout();
            this.pnlViewMid.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.tabTree.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTree_Sheet1)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotHistory_Sheet1)).BeginInit();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotStatus_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.TabIndex = 2;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlViewTop
            // 
            this.pnlViewTop.Location = new System.Drawing.Point(2, 0);
            this.pnlViewTop.Size = new System.Drawing.Size(738, 69);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkSM);
            this.grpOption.Controls.Add(this.txtSMCount);
            this.grpOption.Controls.Add(this.Label3);
            this.grpOption.Controls.Add(this.txtView);
            this.grpOption.Controls.Add(this.Label2);
            this.grpOption.Controls.Add(this.txtOper);
            this.grpOption.Controls.Add(this.Label1);
            this.grpOption.Controls.Add(this.chkOperDesc);
            this.grpOption.Controls.Add(this.rbnCtoP);
            this.grpOption.Controls.Add(this.rbnPtoC);
            this.grpOption.Controls.Add(this.txtLotID);
            this.grpOption.Controls.Add(this.lblLotID);
            this.grpOption.Size = new System.Drawing.Size(738, 69);
            // 
            // pnlViewMid
            // 
            this.pnlViewMid.Controls.Add(this.tabTree);
            this.pnlViewMid.Controls.Add(this.sptInfo);
            this.pnlViewMid.Location = new System.Drawing.Point(2, 69);
            this.pnlViewMid.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlViewMid.Size = new System.Drawing.Size(738, 444);
            this.pnlViewMid.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lisTemp);
            this.pnlBottom.Controls.Add(this.lisLast);
            this.pnlBottom.Controls.Add(this.txtZoom);
            this.pnlBottom.Controls.Add(this.cmdZoom);
            this.pnlBottom.Controls.Add(this.lisLotList);
            this.pnlBottom.Controls.SetChildIndex(this.lisLotList, 0);
            this.pnlBottom.Controls.SetChildIndex(this.cmdZoom, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.txtZoom, 0);
            this.pnlBottom.Controls.SetChildIndex(this.lisLast, 0);
            this.pnlBottom.Controls.SetChildIndex(this.lisTemp, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            // 
            // pnlTop
            // 
            this.pnlTop.Padding = new System.Windows.Forms.Padding(1);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Location = new System.Drawing.Point(1, 1);
            this.lblFormTitle.Size = new System.Drawing.Size(740, 0);
            this.lblFormTitle.Text = "View Lot Trace";
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
            // 
            // txtLotID
            // 
            this.txtLotID.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtLotID.Location = new System.Drawing.Point(120, 16);
            this.txtLotID.MaxLength = 25;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(189, 20);
            this.txtLotID.TabIndex = 2;
            // 
            // lblLotID
            // 
            this.lblLotID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblLotID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotID.Location = new System.Drawing.Point(15, 19);
            this.lblLotID.Name = "lblLotID";
            this.lblLotID.Size = new System.Drawing.Size(100, 14);
            this.lblLotID.TabIndex = 1;
            this.lblLotID.Text = "Lot ID";
            // 
            // rbnPtoC
            // 
            this.rbnPtoC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnPtoC.Location = new System.Drawing.Point(328, 19);
            this.rbnPtoC.Name = "rbnPtoC";
            this.rbnPtoC.Size = new System.Drawing.Size(128, 14);
            this.rbnPtoC.TabIndex = 5;
            this.rbnPtoC.TabStop = true;
            this.rbnPtoC.Text = "Parent -> Child";
            // 
            // rbnCtoP
            // 
            this.rbnCtoP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbnCtoP.Location = new System.Drawing.Point(328, 43);
            this.rbnCtoP.Name = "rbnCtoP";
            this.rbnCtoP.Size = new System.Drawing.Size(128, 14);
            this.rbnCtoP.TabIndex = 6;
            this.rbnCtoP.TabStop = true;
            this.rbnCtoP.Text = "Child -> Parent";
            // 
            // sptInfo
            // 
            this.sptInfo.Location = new System.Drawing.Point(0, 2);
            this.sptInfo.Name = "sptInfo";
            this.sptInfo.Size = new System.Drawing.Size(4, 442);
            this.sptInfo.TabIndex = 1;
            this.sptInfo.TabStop = false;
            // 
            // imlSPIcons
            // 
            this.imlSPIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSPIcons.ImageStream")));
            this.imlSPIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSPIcons.Images.SetKeyName(0, "");
            this.imlSPIcons.Images.SetKeyName(1, "");
            this.imlSPIcons.Images.SetKeyName(2, "");
            this.imlSPIcons.Images.SetKeyName(3, "");
            // 
            // ctxLotTrace
            // 
            this.ctxLotTrace.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuPtoC,
            this.mnuCtoP,
            this.mnuLotStatus,
            this.mnuLotHistory});
            // 
            // mnuPtoC
            // 
            this.mnuPtoC.Index = 0;
            this.mnuPtoC.Text = "Parent -> Child";
            this.mnuPtoC.Click += new System.EventHandler(this.mnuPtoC_Click);
            // 
            // mnuCtoP
            // 
            this.mnuCtoP.Index = 1;
            this.mnuCtoP.Text = "Child -> Parent";
            this.mnuCtoP.Click += new System.EventHandler(this.mnuCtoP_Click);
            // 
            // mnuLotStatus
            // 
            this.mnuLotStatus.Index = 2;
            this.mnuLotStatus.Tag = "WIP3001";
            this.mnuLotStatus.Text = "View Lot Status";
            this.mnuLotStatus.Click += new System.EventHandler(this.mnuSubMenu_Click);
            // 
            // mnuLotHistory
            // 
            this.mnuLotHistory.Index = 3;
            this.mnuLotHistory.Tag = "WIP3002";
            this.mnuLotHistory.Text = "View Lot History";
            this.mnuLotHistory.Click += new System.EventHandler(this.mnuSubMenu_Click);
            // 
            // tabTree
            // 
            this.tabTree.Controls.Add(this.TabPage1);
            this.tabTree.Controls.Add(this.TabPage2);
            this.tabTree.Controls.Add(this.TabPage3);
            this.tabTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTree.Location = new System.Drawing.Point(4, 2);
            this.tabTree.Name = "tabTree";
            this.tabTree.SelectedIndex = 0;
            this.tabTree.Size = new System.Drawing.Size(734, 442);
            this.tabTree.TabIndex = 2;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.spdTree);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(726, 416);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Trace Tree";
            // 
            // spdTree
            // 
            this.spdTree.AccessibleDescription = "spdTree, Sheet1, Row 0, Column 0, ";
            this.spdTree.BackColor = System.Drawing.SystemColors.Control;
            this.spdTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdTree.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdTree.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdTree.HorizontalScrollBar.Name = "";
            this.spdTree.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdTree.HorizontalScrollBar.TabIndex = 2;
            this.spdTree.Location = new System.Drawing.Point(3, 3);
            this.spdTree.Name = "spdTree";
            this.spdTree.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdTree_Sheet1});
            this.spdTree.Size = new System.Drawing.Size(720, 410);
            this.spdTree.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdTree.TabIndex = 0;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdTree.TextTipAppearance = tipAppearance1;
            this.spdTree.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdTree.VerticalScrollBar.Name = "";
            this.spdTree.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdTree.VerticalScrollBar.TabIndex = 3;
            this.spdTree.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdTree_CellClick);
            this.spdTree.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(this.spdTree_CellDoubleClick);
            this.spdTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spdTree_MouseDown);
            // 
            // spdTree_Sheet1
            // 
            this.spdTree_Sheet1.Reset();
            spdTree_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdTree_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.spdTree_Sheet1.AllowNoteEdit = false;
            this.spdTree_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTree_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdTree_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTree_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdTree_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTree_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdTree_Sheet1.ColumnHeader.Visible = false;
            this.spdTree_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdTree_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdTree_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTree_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdTree_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTree_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdTree_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.None);
            this.spdTree_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.spdLotHistory);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(726, 416);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Split/Merge History";
            // 
            // spdLotHistory
            // 
            this.spdLotHistory.AccessibleDescription = "spdLotHistory, Sheet1, Row 0, Column 0, ";
            this.spdLotHistory.BackColor = System.Drawing.SystemColors.Control;
            this.spdLotHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotHistory.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLotHistory.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotHistory.HorizontalScrollBar.Name = "";
            this.spdLotHistory.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdLotHistory.HorizontalScrollBar.TabIndex = 8;
            this.spdLotHistory.Location = new System.Drawing.Point(3, 3);
            this.spdLotHistory.Name = "spdLotHistory";
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
            this.spdLotHistory.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3,
            namedStyle4});
            this.spdLotHistory.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdLotHistory.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotHistory_Sheet1});
            this.spdLotHistory.Size = new System.Drawing.Size(720, 410);
            this.spdLotHistory.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLotHistory.TabIndex = 0;
            tipAppearance2.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdLotHistory.TextTipAppearance = tipAppearance2;
            this.spdLotHistory.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotHistory.VerticalScrollBar.Name = "";
            this.spdLotHistory.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdLotHistory.VerticalScrollBar.TabIndex = 9;
            this.spdLotHistory.SetViewportLeftColumn(0, 0, 3);
            // 
            // spdLotHistory_Sheet1
            // 
            this.spdLotHistory_Sheet1.Reset();
            spdLotHistory_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotHistory_Sheet1.ColumnCount = 15;
            this.spdLotHistory_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotHistory_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotHistory_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotHistory_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "OPER";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "OPER DESC";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "SM Flag";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Lot ID";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "SM Lot ID";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "SM QTY";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Tran Time";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "In Qty";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Out Qty";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Yield";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "User Name";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 11).Value = "Resource";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 12).Value = "Flow";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 13).Value = "Create Code";
            this.spdLotHistory_Sheet1.ColumnHeader.Cells.Get(0, 14).Value = "Owner Code";
            this.spdLotHistory_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotHistory_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotHistory_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdLotHistory_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotHistory_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotHistory_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLotHistory_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotHistory_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLotHistory_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.spdLotStatus);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new System.Drawing.Size(726, 416);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Split/Merge Status";
            // 
            // spdLotStatus
            // 
            this.spdLotStatus.AccessibleDescription = "spdLotStatus, Sheet1, Row 0, Column 0, ";
            this.spdLotStatus.BackColor = System.Drawing.SystemColors.Control;
            this.spdLotStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdLotStatus.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdLotStatus.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotStatus.HorizontalScrollBar.Name = "";
            this.spdLotStatus.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdLotStatus.HorizontalScrollBar.TabIndex = 6;
            this.spdLotStatus.Location = new System.Drawing.Point(0, 0);
            this.spdLotStatus.Name = "spdLotStatus";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.Renderer = columnHeaderRenderer4;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = rowHeaderRenderer4;
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
            this.spdLotStatus.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdLotStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdLotStatus.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdLotStatus_Sheet1});
            this.spdLotStatus.Size = new System.Drawing.Size(726, 416);
            this.spdLotStatus.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdLotStatus.TabIndex = 0;
            tipAppearance3.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            tipAppearance3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.spdLotStatus.TextTipAppearance = tipAppearance3;
            this.spdLotStatus.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdLotStatus.VerticalScrollBar.Name = "";
            this.spdLotStatus.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdLotStatus.VerticalScrollBar.TabIndex = 7;
            // 
            // spdLotStatus_Sheet1
            // 
            this.spdLotStatus_Sheet1.Reset();
            spdLotStatus_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdLotStatus_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdLotStatus_Sheet1.ColumnCount = 11;
            this.spdLotStatus_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotStatus_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotStatus_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotStatus_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Lot ID";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Factory";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Flow";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Oper";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Oper Desc";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Oper In Time";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "In Qty";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 7).Value = "Create Code";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 8).Value = "Owner Code";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 9).Value = "Lot Status";
            this.spdLotStatus_Sheet1.ColumnHeader.Cells.Get(0, 10).Value = "Resource";
            this.spdLotStatus_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotStatus_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdLotStatus_Sheet1.OperationMode = FarPoint.Win.Spread.OperationMode.ReadOnly;
            this.spdLotStatus_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdLotStatus_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotStatus_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdLotStatus_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdLotStatus_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdLotStatus_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // lisLast
            // 
            this.lisLast.Location = new System.Drawing.Point(289, 5);
            this.lisLast.Name = "lisLast";
            this.lisLast.Size = new System.Drawing.Size(71, 29);
            this.lisLast.TabIndex = 8;
            this.lisLast.UseCompatibleStateImageBehavior = false;
            this.lisLast.Visible = false;
            // 
            // lisTemp
            // 
            this.lisTemp.Location = new System.Drawing.Point(135, 4);
            this.lisTemp.Name = "lisTemp";
            this.lisTemp.Size = new System.Drawing.Size(71, 29);
            this.lisTemp.TabIndex = 6;
            this.lisTemp.UseCompatibleStateImageBehavior = false;
            this.lisTemp.Visible = false;
            // 
            // chkOperDesc
            // 
            this.chkOperDesc.AutoSize = true;
            this.chkOperDesc.Location = new System.Drawing.Point(440, 18);
            this.chkOperDesc.Name = "chkOperDesc";
            this.chkOperDesc.Size = new System.Drawing.Size(80, 17);
            this.chkOperDesc.TabIndex = 7;
            this.chkOperDesc.Text = "Oper Name";
            // 
            // txtOper
            // 
            this.txtOper.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtOper.Location = new System.Drawing.Point(120, 40);
            this.txtOper.MaxLength = 25;
            this.txtOper.Name = "txtOper";
            this.txtOper.Size = new System.Drawing.Size(189, 20);
            this.txtOper.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(15, 43);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 14);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "From Oper";
            // 
            // txtView
            // 
            this.txtView.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtView.Location = new System.Drawing.Point(591, 40);
            this.txtView.MaxLength = 25;
            this.txtView.Name = "txtView";
            this.txtView.Size = new System.Drawing.Size(135, 20);
            this.txtView.TabIndex = 12;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(528, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(51, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "View Info";
            // 
            // lisLotList
            // 
            this.lisLotList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LOT_ID,
            this.HIST_SEQ,
            this.SM_Flag,
            this.Lot_Level});
            this.lisLotList.Location = new System.Drawing.Point(212, 4);
            this.lisLotList.Name = "lisLotList";
            this.lisLotList.Size = new System.Drawing.Size(71, 29);
            this.lisLotList.TabIndex = 7;
            this.lisLotList.UseCompatibleStateImageBehavior = false;
            this.lisLotList.Visible = false;
            // 
            // LOT_ID
            // 
            this.LOT_ID.Text = "Lot ID";
            // 
            // HIST_SEQ
            // 
            this.HIST_SEQ.Text = "Hist Seq";
            // 
            // SM_Flag
            // 
            this.SM_Flag.Text = "SM Flag";
            // 
            // Lot_Level
            // 
            this.Lot_Level.Text = "Lot Level";
            // 
            // txtSMCount
            // 
            this.txtSMCount.Enabled = false;
            this.txtSMCount.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtSMCount.Location = new System.Drawing.Point(591, 16);
            this.txtSMCount.MaxLength = 25;
            this.txtSMCount.Name = "txtSMCount";
            this.txtSMCount.Size = new System.Drawing.Size(135, 20);
            this.txtSMCount.TabIndex = 10;
            this.txtSMCount.Text = "0 / 0";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(528, 19);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(62, 13);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "Split/Merge";
            // 
            // cmdZoom
            // 
            this.cmdZoom.Location = new System.Drawing.Point(463, 8);
            this.cmdZoom.Name = "cmdZoom";
            this.cmdZoom.Size = new System.Drawing.Size(87, 26);
            this.cmdZoom.TabIndex = 1;
            this.cmdZoom.Text = "Zoom";
            this.cmdZoom.Click += new System.EventHandler(this.cmdZoom_Click);
            // 
            // txtZoom
            // 
            this.txtZoom.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtZoom.Location = new System.Drawing.Point(424, 12);
            this.txtZoom.MaxLength = 25;
            this.txtZoom.Name = "txtZoom";
            this.txtZoom.Size = new System.Drawing.Size(33, 20);
            this.txtZoom.TabIndex = 0;
            this.txtZoom.Text = "100";
            // 
            // chkSM
            // 
            this.chkSM.AutoSize = true;
            this.chkSM.Location = new System.Drawing.Point(440, 42);
            this.chkSM.Name = "chkSM";
            this.chkSM.Size = new System.Drawing.Size(81, 17);
            this.chkSM.TabIndex = 8;
            this.chkSM.Text = "Split/Merge";
            // 
            // frmWIPViewLotTraceTree
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmWIPViewLotTraceTree";
            this.Text = "View Lot Trace For Tree";
            this.Activated += new System.EventHandler(this.frmWIPViewLotTraceTree_Activated);
            this.Load += new System.EventHandler(this.frmWIPViewLotTraceTree_Load);
            this.pnlViewTop.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.pnlViewMid.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.tabTree.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTree_Sheet1)).EndInit();
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotHistory_Sheet1)).EndInit();
            this.TabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdLotStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdLotStatus_Sheet1)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Constant Definition "
        
        private const long XL_NOTRUNNING = 429;
        
        private const int SS_BORDER_TYPE_LEFT = 1;
        private const int SS_BORDER_TYPE_RIGHT = 2;
        private const int SS_BORDER_TYPE_TOP = 4;
        private const int SS_BORDER_TYPE_BOTTOM = 8;
        private const int SS_BORDER_TYPE_OUTLINE = 16;
        
        private const int SS_BORDER_STYLE_SOLID = 1;
        
        private const int SS_CELL_H_ALIGN_LEFT = 0;
        private const int SS_CELL_H_ALIGN_RIGHT = 1;
        private const int SS_CELL_H_ALIGN_CENTER = 2;
        
        #endregion
        
        #region " Variable Definition "
        
        private bool b_load_flag;

        private long SplitCount;
        private long MergeCount;
        
        private FarPoint.Win.Spread.CellType.GeneralCellType plusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType minusCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType emptyCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        private FarPoint.Win.Spread.CellType.GeneralCellType checkCellType = new FarPoint.Win.Spread.CellType.GeneralCellType();
        
        private enum CELL_STATUS
        {
            PLUS = 1,
            MINUS = 2,
            EMPTY = 3,
            CHECK = 4
        }
        
        private enum OWNER_RBUTTON
        {
            TRACE_SPD = 1,
            OPER_SPD = 2
        }
        
        private OWNER_RBUTTON iOwnerRightButton;
        
        #endregion
        
        #region " Function Definition "
        
        // View_Lot_Trace_Tree()
        //       - View Lot Trace History
        // Return Value
        //       - Boolean : True / False
        // Arguments
        //       - ByVal sLotID As String : Trace Lot id
        //       - ByVal sOper As String : Start Operation
        //       - ByVal sFromToFlag As String : From To Flag of Lot Id
        //       - ByVal OperDescFlag As Boolean : Operation Display Option
        //
        private bool View_Lot_Trace_Tree(string sLotID, string sOper, char sFromToFlag, bool OperDescFlag, bool SMFlag)
        {
            int i;
            int j;
            
            ListViewItem itemX = new ListViewItem();
            ListViewItem itmFound = new ListViewItem();
            ListViewItem itmFound1 = new ListViewItem();
            
            int LotLevel;
            int LotRaw;
            bool FinFlag;
            bool ReCus;
            string FindLot;
            string FindLot1;
            int FindQty1;
            int MergePos;
            int LeftStart;
            int TopStart;
            string TmpStr;
            int LotCount;
            int LoopCount = 0;
            int sCnt;
            bool ContiFlag = false;
            
            // Create a new bevel border
            FarPoint.Win.LineBorder TreeLineLeft = new FarPoint.Win.LineBorder(Color.Cyan, 1, true, false, false, false);
            FarPoint.Win.LineBorder TreeLineRight = new FarPoint.Win.LineBorder(Color.Cyan, 1, false, false, true, false);
            FarPoint.Win.LineBorder TreeLineTop = new FarPoint.Win.LineBorder(Color.Cyan, 1, false, true, false, false);
            FarPoint.Win.LineBorder TreeLineTopLeft = new FarPoint.Win.LineBorder(Color.Cyan, 1, true, true, false, false);
            FarPoint.Win.LineBorder TreeLineTopRight = new FarPoint.Win.LineBorder(Color.Cyan, 1, false, true, true, false);
            FarPoint.Win.LineBorder TreeLineTopLeftRight = new FarPoint.Win.LineBorder(Color.Cyan, 1, true, true, true, false);
            FarPoint.Win.LineBorder TreeLineBottom = new FarPoint.Win.LineBorder(Color.Cyan, 1, false, false, false, true);
            FarPoint.Win.LineBorder TreeLineBottomRight = new FarPoint.Win.LineBorder(Color.Cyan, 1, false, false, true, true);
            FarPoint.Win.LineBorder TreeLineAll = new FarPoint.Win.LineBorder(Color.Cyan, 1, true, true, true, true);
            
            try
            {
                if (tabTree.SelectedIndex == 0)
                {
                    TRSNode in_node = new TRSNode("VIEW_LOT_TRACE_IN");
                    TRSNode out_node = new TRSNode("VIEW_LOT_TRACE_OUT");

                    MPCF.ClearList(spdTree, true);
                    MPCF.ClearList(spdLotHistory, true);
                    MPCF.ClearList(spdLotStatus, true);

                    MPCF.ClearList(lisTemp, true);
                    MPCF.ClearList(lisLotList, true);
                    MPCF.ClearList(lisLast, true);

                    //Add by J.S. 2011.10.12 초기화 필요
                    SplitCount = 0;
                    MergeCount = 0;

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                    in_node.AddString("FROM_OPER", MPCF.Trim(sOper));

                    if (sFromToFlag == 'F')   // Lot의 전체 Split현황을 조회시 History Sequence를 오름차순으로 조회한다.
                    {
                        in_node.AddChar("DIRECT_OPT", 'F');
                        in_node.AddInt("HIST_SEQ", 0);
                    }
                    else                     // Lot의 전체 Merge현황을 조회시 History Sequence를 내림차순으로 조회한다.
                    {
                        in_node.AddChar("DIRECT_OPT", 'B');
                        in_node.AddInt("HIST_SEQ", int.MaxValue);
                    }

                    in_node.AddChar("SM_FLAG", SMFlag == true ? 'Y' : 'N');
                    
                    LotLevel = 1;
                    LotRaw = 0;
                    FinFlag = true;
                    
                    LeftStart = 0;
                    //RightStart = 0;
                    MergePos = 0;
                    ReCus = false;
                    
                    spdTree.Sheets[0].ColumnCount = 256;

                    spdTree.Sheets[0].AddRows(spdTree.Sheets[0].RowCount, 2);

                    // Lot Trace 현황을 조회하기 위하여 여러번의 통신을 통하여 진행을 한다.
                    // Column 단위로 하나의 Lot에 대하여 추적을 하며 이때 Split나 Merge된 Lot정보를 저장한다.
                    // 저장되어진 Split/Merge 가 존재하지 않을때까지 반복 하여 Data를 조회 한다.
                    // Merge/Split Lot의 정보는 Display되어질 위치 정보를 가지고 있다.
                    do
                    {
                        if (MPCR.CallService("WIP", "WIP_View_Lot_Trace_Tree", in_node, ref out_node) == false)
                        {
                            return false;
                        }
                        
                        if(out_node.GetList("LIST").Count == 0)
                        {
                            break;
                        }

                        //return true;

                        TopStart = LotRaw;
                        if (ReCus == false)
                        {
                            for (i = 1; i <= out_node.GetList("LIST").Count; i++)
                            {
                                TRSNode with_1 = (TRSNode)out_node.GetList("LIST")[i-1];

                                FindLot = MPCF.Trim(with_1.GetString("LOT_ID"));
                                
                                // lisLotList의 값은 Lot Trace시 Trace되어진 Lot ID의 값을 가지고 있으며 이 값은 중복을 허용하지 않는다.
                                // 화면의 두번째 Tab에서 이 List를 사용하여 Trace하는 Lot와 관계된 전체 Lot에 대한 정보를 Display하는 용도로 사용된다.
                                itmFound = lisLotList.FindItemWithText(FindLot);
                                if (itmFound == null)
                                {
                                    itemX = ((ListView) lisLotList).Items.Add(MPCF.Trim(FindLot), (int)SMALLICON_INDEX.IDX_LOT);

                                    itemX.SubItems.Add(with_1.GetInt("HIST_SEQ").ToString());
                                    itemX.SubItems.Add(with_1.GetChar("SM_FLAG").ToString());
                                    itemX.SubItems.Add(LotLevel.ToString());
                                }
                                
                                spdTree.Sheets[0].AddRows(spdTree.Sheets[0].RowCount, 2);
                                spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3].Value = MPCF.Trim(with_1.GetDouble("LOT_QTY"));
                                spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].Value = MPCF.Trim(with_1.GetString("LOT_ID"));

                                //return false;

                                /* Trace 정보를 표시 할때 공정 정보를 공정 Code로 보일 것인지 공정 Desc로 보일 것이지 정의 */
                                if (OperDescFlag == true)
                                {
                                    spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 2].Value = MPCF.Trim(with_1.GetString("OPER_DESC"));
                                }
                                else
                                {
                                    spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 2].Value = MPCF.Trim(with_1.GetString("OPER"));
                                }

                                /* Lot이 Split 된경우 */
                                if (MPCF.Trim(with_1.GetChar("SM_FLAG")) == "S")
                                {
                                    spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].BackColor = Color.Yellow;
                                    SplitCount++;
                                }
                                /* Lot이 Merge 된경우 */
                                else if (MPCF.Trim(with_1.GetChar("SM_FLAG")) == "M")
                                {
                                    spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].BackColor = Color.Magenta;
                                    MergeCount++;
                                }
                                /* Trace 하는 Lot Number가 바뀐 경우 */
                                else if (MPCF.Trim(with_1.GetChar("SM_FLAG")) == "N")
                                {
                                    spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].BackColor = Color.Green;
                                }

                                //Lot Number의 테두리를 그린다.
                                spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].Border = TreeLineAll;

                                //Lot들의 연결선을 그리기 위하여 선택 상자의 하단을 그린다.
                                spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 2].Border = TreeLineBottom;

                                //각 Column Size, 속성을 지정한다.
                                spdTree.Sheets[0].Columns[(LotLevel - 1) * 3].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                                spdTree.Sheets[0].SetColumnWidth((LotLevel - 1) * 3, 30);
                                
                                spdTree.Sheets[0].Columns[(LotLevel - 1) * 3 + 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                                spdTree.Sheets[0].SetColumnWidth((LotLevel - 1) * 3 + 1, 100);
                                
                                spdTree.Sheets[0].Columns[(LotLevel - 1) * 3 + 2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                                spdTree.Sheets[0].SetColumnWidth((LotLevel - 1) * 3 + 2, 30);
                                
                                LotRaw = LotRaw + 2;
                            }

                            //아래로 Line을 그리기 위하여 Line을 그린다.
                            if (out_node.GetList("LIST").Count == 1)
                            {
                                spdTree.Sheets[0].Cells[TopStart, (LotLevel - 1) * 3 + 2].Border = TreeLineBottom;
                            }
                            else
                            {
                                spdTree.Sheets[0].Cells[TopStart + 1, (LotLevel - 1) * 3 + 3, LotRaw - 2, (LotLevel - 1) * 3 + 3].Border = TreeLineLeft;
                            }
                        }
                        else
                        {
                            ReCus = false;

                            TRSNode with_2 = (TRSNode)out_node.GetList("LIST")[0];

                            spdTree.Sheets[0].AddRows(spdTree.Sheets[0].RowCount, 2);

                            spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3].Value = MPCF.Trim(with_2.GetDouble("LOT_QTY"));
                            spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].Value = MPCF.Trim(with_2.GetString("LOT_ID"));
                            if (OperDescFlag == true)
                            {
                                spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 2].Value = MPCF.Trim(with_2.GetString("OPER_DESC"));
                            }
                            else
                            {
                                spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 2].Value = MPCF.Trim(with_2.GetString("OPER"));
                            }

                            if (MPCF.Trim(with_2.GetChar("SM_FLAG")) == "S")
                            {
                                spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].BackColor = Color.Yellow;
                                SplitCount++;
                            }
                            else if (MPCF.Trim(with_2.GetChar("SM_FLAG")) == "M")
                            {
                                spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].BackColor = Color.Magenta;
                                MergeCount++;
                            }
                            else if (MPCF.Trim(with_2.GetChar("SM_FLAG")) == "N")
                            {
                                spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].BackColor = Color.Green;
                            }
                            
                            //Lot Number에 Box를 그린다
                            spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 1].Border = TreeLineAll;
                            
                            //Lot의 Transaction이 존재 하는 경우 Lot ID의 옆으로 Line을 그린다.
                            //spdTree.Sheets[0].Cells[LotRaw, (LotLevel - 1) * 3 + 2].Column.Border = TreeLineBottom;
                            
                            //Column의 내용을 정열 한다.
                            //spdTree.Sheets[0].Cells[- 1, (LotLevel - 1) * 3].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                            spdTree.Sheets[0].Columns[(LotLevel - 1) * 3].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
                            spdTree.Sheets[0].SetColumnWidth((LotLevel - 1) * 3, 30);
                            
                            //spdTree.Sheets[0].Cells[- 1, (LotLevel - 1) * 3 + 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                            spdTree.Sheets[0].Columns[(LotLevel - 1) * 3 + 1].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                            spdTree.Sheets[0].SetColumnWidth((LotLevel - 1) * 3 + 1, 100);
                            
                            //spdTree.Sheets[0].Cells[- 1, (LotLevel - 1) * 3 + 2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                            spdTree.Sheets[0].Columns[(LotLevel - 1) * 3 + 2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
                            spdTree.Sheets[0].SetColumnWidth((LotLevel - 1) * 3 + 2, 30);

                            LotRaw = LotRaw + 2;

                            //spdTree.Sheets[0].Cells[TopStart, (LotLevel - 1) * 3 + 2, LotRaw - 2, (LotLevel - 1) * 3 + 2].Border = TreeLineRight;
                            //아래로 Line을 그리기 위하여 Line을 그린다.
                            spdTree.Sheets[0].Cells[TopStart, (LotLevel - 1) * 3 + 2].Border = TreeLineBottom;
                        }

                        //Split/Merge Lot의 정보를 Mother Lot과 연결한다.
                        if (LeftStart > 0)
                        {
                            if (TopStart <= 0)
                            {
                                spdTree.Sheets[0].Cells[1, LeftStart, 1, (LotLevel - 1) * 3 + 2].Border = TreeLineTop;
                            }
                            else
                            {
                                spdTree.Sheets[0].Cells[TopStart - 1, LeftStart].Border = TreeLineTopLeft;
                                spdTree.Sheets[0].Cells[TopStart - 1, LeftStart + 1, TopStart - 1, (LotLevel - 1) * 3 + 2].Border = TreeLineTop;
                                spdTree.Sheets[0].Cells[TopStart - 1, (LotLevel - 1) * 3 + 2].Border = TreeLineTopRight;
                                spdTree.Sheets[0].Cells[TopStart, (LotLevel - 1) * 3 + 3].Border = TreeLineLeft;

                                for(sCnt = (LeftStart + 2); sCnt <= (LotLevel - 1) * 3; )
                                {
                                    if(spdTree.Sheets[0].Cells[TopStart, sCnt].Text.Trim() != "")
                                    {
                                        spdTree.Sheets[0].Cells[TopStart - 1, sCnt+1].Border = TreeLineTopLeft;
                                    }

                                    sCnt += 3;
                                }
                            }
                        }
                        
                        LotLevel++;
                        
                        if (LotLevel > 84)
                        {
                            spdTree.Sheets[0].ColumnCount = LotLevel * 3;
                        }

                        //Split/Merge 정보를 저장한다. 만일 Lot가 이미 Trace된 경우에는 추가 하지 않는다.
                        if (ReCus == false)
                        {
                            j = - 1;
                            for (i = 0; i <= out_node.GetList("M_LIST").Count - 1; i++)
                            {
                                TRSNode with_3 = (TRSNode)out_node.GetList("M_LIST")[i];

                                if (j < 0)
                                {
                                    // Split/Merge Child Lot 의 정보을 List View에 저장 한다.
                                    // Split/Merge 정보를 화면에 Display하기 위한 Level를 저장 한다. 우측 방향의 위치 지정
                                    // Split/Merge Child Lot 정보를 List View에 저장 한다.
                                    itemX = ((ListView)lisTemp).Items.Add(MPCF.Trim(LotLevel), (int)SMALLICON_INDEX.IDX_LOT);   // Lot Display시 Column을 결정 한다.

                                    //Lot Display되어지는 Raw를 저장 한다.
                                    itemX.SubItems.Add(Convert.ToString(MergePos + with_3.GetInt("MERGE_SEQ") * 2 - 1));        // Lot Display시 Raw을 결정 한다.
                                    itemX.SubItems.Add("0");                                                                    // 예비 Column 현재 사용하지 않음
                                    itemX.SubItems.Add(MPCF.Trim(with_3.GetString("LOT_ID")));                                  // Split/Merge Child Lot ID
                                    j = with_3.GetInt("MERGE_SEQ");
                                }
                                else
                                {
                                    // Lot에 동시에 여러 Lot가 Merge 된 경우 LOT ID만 저장한다..
                                    if (j == with_3.GetInt("MERGE_SEQ"))        // Lot의 동일 공정에서 여러번 Split/Merge된 경우 하나의 Row에 추가 한다.
                                    {
                                        itemX.SubItems.Add(MPCF.Trim(with_3.GetString("LOT_ID")));
                                    }
                                    else
                                    {
                                        // Split/Merge Child Lot 의 정보을 List View에 저장 한다.
                                        // Split/Merge 정보를 화면에 Display하기 위한 Level를 저장 한다. 우측 방향의 위치 지정
                                        itemX = ((ListView)lisTemp).Items.Add(MPCF.Trim(LotLevel), (int)SMALLICON_INDEX.IDX_LOT);

                                        //Lot Display되어지는 Raw를 저장 한다.
                                        itemX.SubItems.Add(MPCF.Trim(MergePos + MPCF.ToInt(with_3.GetInt("MERGE_SEQ")) * 2));
                                        itemX.SubItems.Add("0"); // 사용하지 않음
                                        itemX.SubItems.Add(MPCF.Trim(with_3.GetString("LOT_ID"))); //Split/Merge Child Lot ID
                                        j = with_3.GetInt("MERGE_SEQ");
                                    }
                                }
                            }
                        }
                        
                        // Split/Merge Child Lot 에 대하여 Trace를 하기 위하여 Buffer로 사용 되고 있는 lisTemp의 Control에서 Lot를 
                        // 가져 온다
                        in_node.SetString("NEXT_LOT_ID", "");
                        FinFlag = true;
                        if (lisTemp.Items.Count > 0)
                        {
                            do
                            {
                                //Split/Merge Child Lot 정보를 Display시 처음 Row를 결정 한다.
                                LotRaw = MPCF.ToInt(lisTemp.Items[lisTemp.Items.Count - 1].SubItems[1].Text);

                                // 한 공정에서 Split/Merge의 Child 정보를 조회한다.


                                // Split/Merge 의 정보를 Trace하기 위한 Lot ID를 가져 와 NEXT_LOT_ID에 값을 넣고 그 값을 lisTemp에서 삭제 하고 Server를 호출 한다.
                                in_node.SetString("NEXT_LOT_ID", lisTemp.Items[lisTemp.Items.Count - 1].SubItems[lisTemp.Items[lisTemp.Items.Count - 1].SubItems.Count - 1].Text);
                                lisTemp.Items[lisTemp.Items.Count - 1].SubItems.RemoveAt(lisTemp.Items[lisTemp.Items.Count - 1].SubItems.Count - 1);
                                
                                MergePos = MPCF.ToInt(lisTemp.Items[lisTemp.Items.Count - 1].SubItems[1].Text);
                                LeftStart = (MPCF.ToInt(lisTemp.Items[lisTemp.Items.Count - 1].Text) - 2) * 3 + 3;

                                // 하나의 row에서 Split/Merge Child Lot정보가 없는 경우 row을 삭제 한다.
                                if ((lisTemp.Items[lisTemp.Items.Count - 1].SubItems.Count - 1) == 2)
                                {
                                    lisTemp.Items.RemoveAt(lisTemp.Items.Count - 1);
                                }
                                
                                FindLot = MPCF.Trim(in_node.GetString("NEXT_LOT_ID"));

                                // Trace하려는 Lot이 이미 Trace되어진 Lot의 경우 ReCus의 값을 true로 셋팅하여 화면에만 Display하고
                                // Trace는 진행하지 않는다.
                                if (sFromToFlag == 'F') 
                                {
                                    itmFound = lisLotList.FindItemWithText(FindLot);
                                    if (itmFound == null)
                                    {
                                        ReCus = false;
                                    }
                                    else
                                    {
                                        ReCus = true;
                                    }
                                }

                                if (lisTemp.Items.Count == 0)
                                {
                                    break;
                                }
                            } while (in_node.GetString("NEXT_LOT_ID") == "");

                            if (in_node.GetString("NEXT_LOT_ID") != "")
                            {
                                FinFlag = false;
                            }
                        }
                        
                        if (sFromToFlag == 'F') //Forward
                        {
                            FindLot1 = MPCF.Trim(out_node.GetList("LIST")[out_node.GetList("LIST").Count - 1].GetString("LOT_ID"));

                            FindQty1 = (int)out_node.GetList("LIST")[out_node.GetList("LIST").Count - 1].GetDouble("LOT_QTY");
                            //if (FindQty1 == 0)
                            //{
                            //    FindQty1 = (int)out_node.GetList("LIST")[out_node.GetList("LIST").Count - 2].GetDouble("LOT_QTY");
                            //}
                            itmFound1 = lisLast.FindItemWithText(FindLot1);
                            if (itmFound1 == null)
                            {
                                // Trace의 최종 Lot정보를 lisLast에 저장을 하여 Lot Trace이후 Lot의 마지막 정보를 Display 한다.
                                itemX = ((ListView) lisLast).Items.Add(MPCF.Trim(FindLot1), (int)SMALLICON_INDEX.IDX_LOT); 
                                itemX.SubItems.Add(FindQty1.ToString());
                            }
                        }
                        else
                        {
                            for (i = out_node.GetList("LIST").Count - 1; i >= 0; i--)
                            {
                                if (MPCF.Trim(out_node.GetList("LIST")[i].GetChar("SM_FLAG")) != "S")
                                {
                                    FindLot1 = MPCF.Trim(out_node.GetList("LIST")[i].GetString("LOT_ID"));
                                    FindQty1 = (int)out_node.GetList("LIST")[i].GetDouble("LOT_QTY");
                                    
                                    itmFound1 = lisLast.FindItemWithText(FindLot1);
                                    if (itmFound1 == null)
                                    {
                                        // Trace의 최종 Lot정보를 lisLast에 저장을 하여 Lot Trace이후 Lot의 마지막 정보를 Display 한다.
                                        itemX = ((ListView)lisLast).Items.Add(MPCF.Trim(FindLot1), (int)SMALLICON_INDEX.IDX_LOT); 
                                        itemX.SubItems.Add(FindQty1.ToString());
                                    }
                                    
                                    break;
                                }
                            }
                        }
                        
                        LoopCount++;
                        if (LoopCount > 0 && LoopCount % 50 == 0)
                        {
                            if (ContiFlag == false)
                            {
                                if (MPCF.ShowMsgBox(MPCF.GetMessage(245), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                                {
                                    return false;
                                }
                                ContiFlag = true;
                            }
                        }

                        if (lisLast.Items.Count > 0)
                        {
                            TRSNode trace_item;
                            for (i = 0; i < lisLast.Items.Count; i++)
                            {
                                trace_item = in_node.AddNode("T_LIST");

                                trace_item.AddString("LOT_ID", lisLast.Items[i].SubItems[0].Text);
                            }
                        }

                    } while (FinFlag == false);
                    
                    if (sFromToFlag == 'F')
                    {
                        TmpStr = SplitCount.ToString();
                    }
                    else
                    {
                        TmpStr = SplitCount.ToString() + " / " + MergeCount.ToString();
                    }
                    txtSMCount.Text = TmpStr;
                    
                }
                else if (tabTree.SelectedIndex == 1)
                {
                    TRSNode in_node = new TRSNode("VIEW_LOT_TRACE_HISTORY_IN");
                    TRSNode out_node = new TRSNode("VIEW_LOT_TRACE_HISTORY_OUT");

                    MPCF.ClearList(spdLotHistory, true);

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '1';
                    in_node.AddString("LOT_ID", MPCF.Trim(sLotID));
                    in_node.AddString("FROM_OPER", MPCF.Trim(sOper));

                    in_node.AddChar("FB_FLAG", sFromToFlag);
                    
                    for (i = 0; i <= lisLotList.Items.Count - 1; i++)
                    {
                        TRSNode list_item = in_node.AddNode("LIST");

                        list_item.AddString("LOT_ID", MPCF.Trim(lisLotList.Items[i].Text));
                        list_item.AddInt("HIST_SEQ", MPCF.ToInt(MPCF.Trim(lisLotList.Items[i].SubItems[1].Text)));
                        list_item.AddChar("SM_FLAG", MPCF.ToChar(lisLotList.Items[i].SubItems[2].Text));
                        list_item.AddChar("T_LEVEL", MPCF.ToChar(MPCF.Trim(lisLotList.Items[i].SubItems[3].Text)));
                    }
                    
                    LotCount = 0;
                    
                    do
                    {
                        if (MPCR.CallService("WIP", "WIP_View_Lot_Trace_History", in_node, ref out_node) == false)
                        {
                            return false;
                        }
                        
                        for (i = 1; i <= out_node.GetList("LIST").Count; i++)
                        {
                            TRSNode with_4 = out_node.GetList("LIST")[i - 1];
                            spdLotHistory.Sheets[0].AddRows(spdLotHistory.Sheets[0].RowCount, 1);
                            spdLotHistory.Sheets[0].Cells[LotCount, 0].Value = MPCF.Trim(with_4.GetString("OPER"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 1].Value = MPCF.Trim(with_4.GetString("OPER_DESC"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 2].Value = MPCF.Trim(with_4.GetChar("SM_FLAG"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 3].Value = MPCF.Trim(with_4.GetString("LOT_ID"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 4].Value = MPCF.Trim(with_4.GetString("SM_LOT_ID"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 5].Value = MPCF.Trim(with_4.GetDouble("SM_QTY"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 6].Value = string.Format(MPCF.Trim(with_4.GetString("TRANS_TIME")), "####/##/## ##:##:##");
                            spdLotHistory.Sheets[0].Cells[LotCount, 7].Value = MPCF.Trim(with_4.GetDouble("IN_QTY"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 8].Value = MPCF.Trim(with_4.GetDouble("OUT_QTY"));
                            if (MPCF.Trim(with_4.GetChar("SM_FLAG")) == "")
                            {
                                if (with_4.GetDouble("IN_QTY") > 0)
                                    spdLotHistory.Sheets[0].Cells[LotCount, 9].Value = Math.Round(with_4.GetDouble("OUT_QTY") / with_4.GetDouble("IN_QTY") * 100, 2);
                                else
                                    spdLotHistory.Sheets[0].Cells[LotCount, 9].Value = 0;
                            }
                            spdLotHistory.Sheets[0].Cells[LotCount, 10].Value = MPCF.Trim(with_4.GetString("USER_NAME"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 11].Value = MPCF.Trim(with_4.GetString("EQUIP_ID"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 12].Value = MPCF.Trim(with_4.GetString("FLOW"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 13].Value = MPCF.Trim(with_4.GetString("CREATE_CODE"));
                            spdLotHistory.Sheets[0].Cells[LotCount, 14].Value = MPCF.Trim(with_4.GetString("OWNER"));
                            
                            LotCount++;
                        }
                        
                        in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                        in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    } while (out_node.GetString("NEXT_LOT_ID") != "");

                    //Add by J.S. 2011.10.12 for good view
                    MPCF.FitColumnHeader(spdLotHistory);
                }
                else if (tabTree.SelectedIndex == 2)
                {
                    TRSNode in_node = new TRSNode("VIEW_LOT_TRACE_HISTORY_IN");
                    TRSNode out_node = new TRSNode("VIEW_LOT_TRACE_HISTORY_OUT");

                    MPCF.ClearList(spdLotStatus, true);

                    MPCR.SetInMsg(in_node);
                    in_node.ProcStep = '2';
                    in_node.AddChar("FB_FLAG", sFromToFlag);
                    
                    for (i = 0; i <= lisLast.Items.Count - 1; i++)
                    {
                        TRSNode list_item = in_node.AddNode("LIST");

                        list_item.AddString("LOT_ID", MPCF.Trim(lisLast.Items[i].Text));
                        list_item.AddInt("HIST_SEQ", int.MaxValue);
                    }
                    
                    LotCount = 0;
                    
                    do
                    {
                        if (MPCR.CallService("WIP", "WIP_View_Lot_Trace_History", in_node, ref out_node) == false)
                        {
                            return false;
                        }
                        
                        for (i = 1; i <= out_node.GetList("LIST").Count; i++)
                        {
                            TRSNode with_5 = out_node.GetList("LIST")[i - 1];
                            spdLotStatus.Sheets[0].AddRows(spdLotStatus.Sheets[0].RowCount, 1);
                            spdLotStatus.Sheets[0].Cells[LotCount, 0].Value = MPCF.Trim(with_5.GetString("LOT_ID"));
                            spdLotStatus.Sheets[0].Cells[LotCount, 1].Value = MPCF.Trim(with_5.GetString("FACTORY"));
                            spdLotStatus.Sheets[0].Cells[LotCount, 2].Value = MPCF.Trim(with_5.GetString("FLOW"));
                            spdLotStatus.Sheets[0].Cells[LotCount, 3].Value = MPCF.Trim(with_5.GetString("OPER"));
                            spdLotStatus.Sheets[0].Cells[LotCount, 4].Value = MPCF.Trim(with_5.GetString("OPER_DESC"));
                            if (MPCF.Trim(with_5.GetString("OPER_IN_TIME")) != "")
                            {
                                spdLotStatus.Sheets[0].Cells[LotCount, 5].Value = string.Format(MPCF.Trim(with_5.GetString("OPER_IN_TIME")), "####/##/## ##:##:##");
                            }
                            spdLotStatus.Sheets[0].Cells[LotCount, 6].Value = MPCF.Trim(with_5.GetDouble("IN_QTY"));
                            spdLotStatus.Sheets[0].Cells[LotCount, 7].Value = MPCF.Trim(with_5.GetString("CREATE_CODE"));
                            spdLotStatus.Sheets[0].Cells[LotCount, 8].Value = MPCF.Trim(with_5.GetString("OWNER"));
                            spdLotStatus.Sheets[0].Cells[LotCount, 9].Value = MPCF.Trim(with_5.GetString("LOT_STATUS"));
                            spdLotStatus.Sheets[0].Cells[LotCount, 10].Value = MPCF.Trim(with_5.GetString("EQUIP_ID"));
                            
                            LotCount++;
                        }
                        
                        in_node.SetString("NEXT_LOT_ID", out_node.GetString("NEXT_LOT_ID"));
                        in_node.SetInt("NEXT_HIST_SEQ", out_node.GetInt("NEXT_HIST_SEQ"));
                    } while (out_node.GetString("NEXT_LOT_ID") != "");
                }

                //Add by J.S. 2011.10.12 for good view
                MPCF.FitColumnHeader(spdLotStatus);

                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        
        public void ActiveFormNow()
        {
            if (MPCF.Trim(MPGV.gsCurrentLot_ID) != "")
            {
                txtLotID.Text = MPGV.gsCurrentLot_ID;
                btnView_Click(btnView, null);
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
        
        private void frmWIPViewLotTraceTree_Load(object sender, System.EventArgs e)
        {
            int i;
            
            plusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.PLUS) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            minusCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.MINUS) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            emptyCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.EMPTY) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Center, FarPoint.Win.VerticalAlignment.Center);
            checkCellType.BackgroundImage = new FarPoint.Win.Picture(imlSPIcons.Images[MPCF.ToInt(CELL_STATUS.CHECK) - 1], FarPoint.Win.RenderStyle.Normal, Color.White, FarPoint.Win.HorizontalAlignment.Right, FarPoint.Win.VerticalAlignment.Center);
            
            MPCF.InitListView(lisTemp);
            MPCF.InitListView(lisLotList);
            MPCF.InitListView(lisLast);
            
            lisTemp.Columns.Add(new ColumnHeader());
            lisTemp.Columns[0].Text = "Level";
            lisTemp.Columns[0].Width = 500;
            lisTemp.Columns.Add(new ColumnHeader());
            lisTemp.Columns[1].Text = "Seq";
            lisTemp.Columns[1].Width = 500;
            lisTemp.Columns.Add(new ColumnHeader());
            lisTemp.Columns[2].Text = "Step";
            lisTemp.Columns[2].Width = 500;
            for (i = 3; i <= 500 - 1; i++)
            {
                lisTemp.Columns.Add(new ColumnHeader());
                lisTemp.Columns[i].Text = i.ToString();
                lisTemp.Columns[i].Width = 500;
            }
            
            txtZoom.Text = "100";
        }
        
        private void frmWIPViewLotTraceTree_Activated(object sender, System.EventArgs e)
        {
            
            if (b_load_flag == false)
            {
                MPCF.FieldClear(this);
                MPCF.ClearList(spdTree, true);
                MPCF.ClearList(spdLotHistory, true);
                MPCF.ClearList(spdLotStatus, true);

                MPCF.ClearList(lisTemp, true);
                MPCF.ClearList(lisLotList, true);
                MPCF.ClearList(lisLast, true);
                rbnPtoC.Checked = false;
                rbnCtoP.Checked = true;

                ActiveFormNow();
                
                b_load_flag = true;
            }
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            if (txtLotID.Text != "")
            {
                txtZoom.Text = "100";

                if (View_Lot_Trace_Tree(txtLotID.Text, txtOper.Text, (rbnCtoP.Checked == true ? 'B' : 'F'), chkOperDesc.Checked, chkSM.Checked) == false)
                {
                    return;
                }
            }
            
        }
        
        private void mnuCtoP_Click(object sender, System.EventArgs e)
        {
            FarPoint.Win.Spread.SheetView spd = null;
            try
            {
                rbnCtoP.Checked = true;
                if (iOwnerRightButton == OWNER_RBUTTON.TRACE_SPD)
                {
                    spd = spdTree.ActiveSheet;
                }
                else if (iOwnerRightButton == OWNER_RBUTTON.OPER_SPD)
                {
                    spd = spdTree.ActiveSheet;
                }

                if (spd.RowCount < 1) return;

                txtLotID.Text = MPCF.Trim(spd.Cells[spd.ActiveRowIndex, spd.ActiveColumnIndex].Value);
                btnView_Click(btnView, e);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void mnuPtoC_Click(object sender, System.EventArgs e)
        {
            FarPoint.Win.Spread.SheetView spd = null;
            
            try
            {
                rbnPtoC.Checked = true;
                if (iOwnerRightButton == OWNER_RBUTTON.TRACE_SPD)
                {
                    spd = spdTree.Sheets[0];
                }
                else if (iOwnerRightButton == OWNER_RBUTTON.OPER_SPD)
                {
                    spd = spdTree.Sheets[0];
                }

                if (spd.RowCount < 1) return;

                txtLotID.Text = MPCF.Trim(spd.Cells[spd.ActiveRowIndex, spd.ActiveColumnIndex].Value);
                btnView_Click(btnView, e);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void mnuSubMenu_Click(System.Object sender, System.EventArgs e)
        {
            FarPoint.Win.Spread.SheetView spd = null;
            string s_func_name;
            
            try
            {
                if (((MenuItem)sender).Tag == null) return;
                if (MPCF.Trim(((MenuItem)sender).Tag) == "") return;
                
                if (iOwnerRightButton == OWNER_RBUTTON.TRACE_SPD)
                {
                    spd = spdTree.Sheets[0];
                }
                else if (iOwnerRightButton == OWNER_RBUTTON.OPER_SPD)
                {
                    spd = spdTree.Sheets[0];
                }

                if (spd.RowCount < 1) return;

                MPGV.gsCurrentLot_ID = MPCF.Trim(spd.Cells[spd.ActiveRowIndex, spd.ActiveColumnIndex].Value);

                s_func_name = MPCF.Trim(((MenuItem)sender).Tag);
                MPGV.gIMdiForm.ActiveMenu(s_func_name);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            string sCond;
            bool SaveFlag;
            
            try
            {
                sCond = "Lot ID : " + txtLotID.Text + "\r";
                sCond = sCond + "Direction : ";
                if (rbnCtoP.Checked == true)
                {
                    sCond = sCond + "Child -> Parent";
                }
                else
                {
                    sCond = sCond + "Parent -> Child";
                }
                
                if (tabTree.SelectedIndex == 0)
                {
                    if (spdTree.ActiveSheet.ColumnCount > 256)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(246));
                        return;
                    }
                    
                    // Export Excel file and set result to SaveFlag
                    SaveFlag = spdTree.SaveExcel(System.Windows.Forms.Application.StartupPath + "\\" + txtLotID.Text + ".XLS");
                    
                    // Display result to user based on T/F value of x
                    if (SaveFlag == true)
                    {
                        Excel.Application xlApp = new Excel.Application();
                        xlApp = new Excel.Application();

                        xlApp.Visible = true; //?묒? ?쒖떆
                        xlApp.Workbooks.Open(System.Windows.Forms.Application.StartupPath + "\\" + txtLotID.Text + ".XLS", 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                    }
                }
                else if (tabTree.SelectedIndex == 1)
                {
                    if (MPCF.ExportToExcel(spdLotHistory, this.Text, sCond, true, true, true, -1, -1) == false)
                    {
                        return;
                    }
                }
                else if (tabTree.SelectedIndex == 2)
                {
                    if (MPCF.ExportToExcel(spdLotStatus, this.Text, sCond, true, true, true, -1, -1) == false)
                    {
                        return;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cmdZoom_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (tabTree.SelectedIndex != 0)
                {
                    return;
                }

                if (MPCF.Trim(txtZoom.Text) == "")
                {
                    txtZoom.Text = "100";
                }
                
                spdTree.ActiveSheet.ZoomFactor = (float)(MPCF.ToDbl(txtZoom.Text) / 100);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdTree_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            try
            {
                txtView.Text = spdTree.ActiveSheet.Cells[e.Row, e.Column].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdTree_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            string tmplot;
            frmWIPViewLotTraceTreeSub SubForm = new frmWIPViewLotTraceTreeSub();
            int IC;
            int IR;
            
            try
            {
                IC = spdTree.Sheets[0].ActiveColumnIndex;
                IR = spdTree.Sheets[0].ActiveRowIndex;
                tmplot = MPCF.Trim(spdTree.Sheets[0].Cells[IR, IC].Text);
                
                if (tmplot != "")
                {
                    if (IC % 3 == 1)
                    {
                        SubForm.tmplot = tmplot;
                        SubForm.OperDesc = chkOperDesc.Checked;
                        SubForm.smFlag = chkSM.Checked == true ? 'Y' : 'N';
                        SubForm.ShowDialog(this);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void spdTree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                iOwnerRightButton = OWNER_RBUTTON.TRACE_SPD;
                ctxLotTrace.Show(spdTree, new System.Drawing.Point(e.X, e.Y));
            }
        }
    }
}
