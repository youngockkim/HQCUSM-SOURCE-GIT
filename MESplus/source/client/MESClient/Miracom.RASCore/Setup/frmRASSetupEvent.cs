
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
//   File Name   : frmRASSetupEvent.vb
//   Description : Event Setup Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData : Intialize Form Field
//       - CheckCondition : Check the conditions before transaction
//       - Update_Event : Create/Update/Delete Event
//       - View_Event_List :View Event list
//       - View_Event : View Event Information
//
//   Detail Description
//       - Update_Event
//         ProcStep="C" - Create New Event
//         ProcStep="U" - Update Event
//         ProcStep="D" - Delete Event
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-09 : Created by Daniel Kim
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.RASCore
{
    public class frmRASSetupEvent : Miracom.MESCore.SetupForm02
    {
        
        #region " Windows Form auto generated code "
        
        public frmRASSetupEvent()
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
        



        private System.Windows.Forms.GroupBox grpGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup10;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup9;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup8;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup7;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup6;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup5;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup4;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup3;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup2;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup1;
        private System.Windows.Forms.Panel pnlTab;
        private Miracom.UI.Controls.MCListView.MCListView lisEvent;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.TabControl tabEvent;
        private System.Windows.Forms.GroupBox grpTop;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblChangeUpDownFlag;
        private System.Windows.Forms.Label lblCheckUpDown;
        private System.Windows.Forms.Label lblCheckUpDownFlag;
        private System.Windows.Forms.CheckBox chkSystemFlag;
        private System.Windows.Forms.ComboBox cboCheckUpDownFlag;
        private System.Windows.Forms.ComboBox cboChangeUpDown;
        private System.Windows.Forms.ComboBox cboChangeUpDownFlag;
        private System.Windows.Forms.ComboBox cboCheckUpDown;
        private System.Windows.Forms.Label lblEventGrp7;
        private System.Windows.Forms.Label lblEventGrp6;
        private System.Windows.Forms.Label lblEventGrp5;
        private System.Windows.Forms.Label lblEventGrp4;
        private System.Windows.Forms.Label lblEventGrp3;
        private System.Windows.Forms.Label lblEventGrp2;
        private System.Windows.Forms.Label lblEventGrp1;
        private System.Windows.Forms.Label lblEventGrp10;
        private System.Windows.Forms.Label lblEventGrp9;
        private System.Windows.Forms.Label lblEventGrp8;
        private System.Windows.Forms.Label lblChangeUpDown;
        private System.Windows.Forms.GroupBox grpEDC;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvColSetID;
        private System.Windows.Forms.Label lblEDCSet;
        private System.Windows.Forms.TabPage tbpEvent;
        private System.Windows.Forms.TabPage tbpOption;
        private System.Windows.Forms.TabPage tbpGroup;
        private System.Windows.Forms.GroupBox grpChart;
        private System.Windows.Forms.Label lblChartID;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartID;
        private System.Windows.Forms.ComboBox cboChart;
        private System.Windows.Forms.Label lblChartFlag;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private FarPoint.Win.Spread.FpSpread spdEvent;
        private FarPoint.Win.Spread.SheetView spdEvent_Sheet1;
        private Miracom.UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(FarPoint.Win.ComplexBorderSideStyle.None));
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType1 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType1 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType2 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType3 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType2 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.lisEvent = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlTab = new System.Windows.Forms.Panel();
            this.tabEvent = new System.Windows.Forms.TabControl();
            this.tbpEvent = new System.Windows.Forms.TabPage();
            this.spdEvent = new FarPoint.Win.Spread.FpSpread();
            this.spdEvent_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.cboChangeUpDown = new System.Windows.Forms.ComboBox();
            this.cboChangeUpDownFlag = new System.Windows.Forms.ComboBox();
            this.cboCheckUpDown = new System.Windows.Forms.ComboBox();
            this.cboCheckUpDownFlag = new System.Windows.Forms.ComboBox();
            this.lblChangeUpDown = new System.Windows.Forms.Label();
            this.lblChangeUpDownFlag = new System.Windows.Forms.Label();
            this.lblCheckUpDown = new System.Windows.Forms.Label();
            this.lblCheckUpDownFlag = new System.Windows.Forms.Label();
            this.tbpOption = new System.Windows.Forms.TabPage();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.cboChart = new System.Windows.Forms.ComboBox();
            this.lblChartFlag = new System.Windows.Forms.Label();
            this.cdvChartID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartID = new System.Windows.Forms.Label();
            this.grpEDC = new System.Windows.Forms.GroupBox();
            this.cdvColSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblEDCSet = new System.Windows.Forms.Label();
            this.tbpGroup = new System.Windows.Forms.TabPage();
            this.grpGroup = new System.Windows.Forms.GroupBox();
            this.lblEventGrp10 = new System.Windows.Forms.Label();
            this.lblEventGrp9 = new System.Windows.Forms.Label();
            this.lblEventGrp8 = new System.Windows.Forms.Label();
            this.lblEventGrp7 = new System.Windows.Forms.Label();
            this.lblEventGrp6 = new System.Windows.Forms.Label();
            this.lblEventGrp5 = new System.Windows.Forms.Label();
            this.lblEventGrp4 = new System.Windows.Forms.Label();
            this.lblEventGrp3 = new System.Windows.Forms.Label();
            this.lblEventGrp2 = new System.Windows.Forms.Label();
            this.lblEventGrp1 = new System.Windows.Forms.Label();
            this.cdvGroup10 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.cdvGroup1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.grpTop = new System.Windows.Forms.GroupBox();
            this.chkSystemFlag = new System.Windows.Forms.CheckBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.tabEvent.SuspendLayout();
            this.tbpEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEvent_Sheet1)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.tbpOption.SuspendLayout();
            this.grpInfo.SuspendLayout();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).BeginInit();
            this.grpEDC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvColSetID)).BeginInit();
            this.tbpGroup.SuspendLayout();
            this.grpGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).BeginInit();
            this.grpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 5;
            // 
            // btnExcel
            // 
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlTab);
            this.pnlRight.Controls.Add(this.grpTop);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisEvent);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 506);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(372, 8);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.TabIndex = 2;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "Event Setup";
            // 
            // lisEvent
            // 
            this.lisEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisEvent.EnableSort = true;
            this.lisEvent.EnableSortIcon = true;
            this.lisEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisEvent.FullRowSelect = true;
            this.lisEvent.Location = new System.Drawing.Point(3, 3);
            this.lisEvent.MultiSelect = false;
            this.lisEvent.Name = "lisEvent";
            this.lisEvent.Size = new System.Drawing.Size(229, 500);
            this.lisEvent.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lisEvent.TabIndex = 0;
            this.lisEvent.UseCompatibleStateImageBehavior = false;
            this.lisEvent.View = System.Windows.Forms.View.Details;
            this.lisEvent.SelectedIndexChanged += new System.EventHandler(this.lisEvent_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Event";
            this.ColumnHeader1.Width = 80;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 150;
            // 
            // pnlTab
            // 
            this.pnlTab.Controls.Add(this.tabEvent);
            this.pnlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTab.Location = new System.Drawing.Point(3, 71);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTab.Size = new System.Drawing.Size(500, 432);
            this.pnlTab.TabIndex = 1;
            // 
            // tabEvent
            // 
            this.tabEvent.Controls.Add(this.tbpEvent);
            this.tabEvent.Controls.Add(this.tbpOption);
            this.tabEvent.Controls.Add(this.tbpGroup);
            this.tabEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEvent.ItemSize = new System.Drawing.Size(60, 18);
            this.tabEvent.Location = new System.Drawing.Point(0, 5);
            this.tabEvent.Name = "tabEvent";
            this.tabEvent.SelectedIndex = 0;
            this.tabEvent.Size = new System.Drawing.Size(500, 427);
            this.tabEvent.TabIndex = 1;
            // 
            // tbpEvent
            // 
            this.tbpEvent.Controls.Add(this.spdEvent);
            this.tbpEvent.Controls.Add(this.pnlStatus);
            this.tbpEvent.Location = new System.Drawing.Point(4, 22);
            this.tbpEvent.Name = "tbpEvent";
            this.tbpEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tbpEvent.Size = new System.Drawing.Size(492, 401);
            this.tbpEvent.TabIndex = 0;
            this.tbpEvent.Text = "Event Action";
            // 
            // spdEvent
            // 
            this.spdEvent.AccessibleDescription = "";
            this.spdEvent.ButtonDrawMode = FarPoint.Win.Spread.ButtonDrawModes.CurrentRow;
            this.spdEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdEvent.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.spdEvent.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEvent.HorizontalScrollBar.Name = "";
            this.spdEvent.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdEvent.HorizontalScrollBar.TabIndex = 2;
            this.spdEvent.Location = new System.Drawing.Point(3, 67);
            this.spdEvent.Name = "spdEvent";
            this.spdEvent.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdEvent.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdEvent.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdEvent_Sheet1});
            this.spdEvent.Size = new System.Drawing.Size(486, 331);
            this.spdEvent.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdEvent.TabIndex = 2;
            this.spdEvent.TabStop = false;
            this.spdEvent.TextTipDelay = 200;
            this.spdEvent.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdEvent.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdEvent.VerticalScrollBar.Name = "";
            this.spdEvent.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdEvent.VerticalScrollBar.TabIndex = 3;
            this.spdEvent.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdEvent_ButtonClicked);
            this.spdEvent.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdEvent_ComboCloseUp);
            this.spdEvent.ComboSelChange += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdEvent_ComboSelChange);
            // 
            // spdEvent_Sheet1
            // 
            this.spdEvent_Sheet1.Reset();
            spdEvent_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdEvent_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdEvent_Sheet1.ColumnCount = 7;
            spdEvent_Sheet1.RowCount = 11;
            this.spdEvent_Sheet1.Cells.Get(0, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(0, 5).Border = complexBorder1;
            this.spdEvent_Sheet1.Cells.Get(0, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(1, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(1, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(2, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(2, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(3, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(3, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(4, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(4, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(5, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(5, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(6, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(6, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(7, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(7, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(8, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(8, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(9, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(9, 6).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(10, 2).Locked = true;
            this.spdEvent_Sheet1.Cells.Get(10, 6).Locked = true;
            this.spdEvent_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdEvent_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Check Flag";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 1).ColumnSpan = 2;
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Check Status";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Change Flag";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Change Status";
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 2;
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Validation Table";
            this.spdEvent_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdEvent_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            comboBoxCellType1.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType1.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.Index;
            comboBoxCellType1.Items = new string[] {
        "",
        "= (Equal)",
        "! (Not Equal)",
        "N (Not Check)",
        "> (Greater than)",
        "< (Less than)",
        "T (Table)"};
            this.spdEvent_Sheet1.Columns.Get(0).CellType = comboBoxCellType1;
            this.spdEvent_Sheet1.Columns.Get(0).Label = "Check Flag";
            this.spdEvent_Sheet1.Columns.Get(0).Width = 85F;
            this.spdEvent_Sheet1.Columns.Get(1).CellType = textCellType1;
            this.spdEvent_Sheet1.Columns.Get(1).Label = "Check Status";
            this.spdEvent_Sheet1.Columns.Get(1).Locked = false;
            this.spdEvent_Sheet1.Columns.Get(1).Width = 72F;
            buttonCellType1.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType1.Text = "...";
            this.spdEvent_Sheet1.Columns.Get(2).CellType = buttonCellType1;
            this.spdEvent_Sheet1.Columns.Get(2).Width = 21F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.EditorValue = FarPoint.Win.Spread.CellType.EditorValue.Index;
            comboBoxCellType2.Items = new string[] {
        "",
        "Y (Change)",
        "+ (Increase)",
        "- (Decrease)",
        "N (Not Change)",
        "O (Override)",
        "T (Time)"};
            this.spdEvent_Sheet1.Columns.Get(3).CellType = comboBoxCellType2;
            this.spdEvent_Sheet1.Columns.Get(3).Label = "Change Flag";
            this.spdEvent_Sheet1.Columns.Get(3).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(3).Width = 90F;
            textCellType2.MaxLength = 30;
            this.spdEvent_Sheet1.Columns.Get(4).CellType = textCellType2;
            this.spdEvent_Sheet1.Columns.Get(4).Label = "Change Status";
            this.spdEvent_Sheet1.Columns.Get(4).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(4).Width = 81F;
            textCellType3.MaxLength = 20;
            this.spdEvent_Sheet1.Columns.Get(5).CellType = textCellType3;
            this.spdEvent_Sheet1.Columns.Get(5).Label = "Validation Table";
            this.spdEvent_Sheet1.Columns.Get(5).Locked = true;
            this.spdEvent_Sheet1.Columns.Get(5).Width = 72F;
            buttonCellType2.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType2.Text = "...";
            this.spdEvent_Sheet1.Columns.Get(6).CellType = buttonCellType2;
            this.spdEvent_Sheet1.Columns.Get(6).Width = 21F;
            this.spdEvent_Sheet1.GrayAreaBackColor = System.Drawing.SystemColors.Window;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(0, 0).Value = "P";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(1, 0).Value = "1";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(2, 0).Value = "2";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(3, 0).Value = "3";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(4, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(4, 0).Value = "4";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(5, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(5, 0).Value = "5";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(6, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(6, 0).Value = "6";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(7, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(7, 0).Value = "7";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(8, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(8, 0).Value = "8";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(9, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(9, 0).Value = "9";
            this.spdEvent_Sheet1.RowHeader.Cells.Get(10, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdEvent_Sheet1.RowHeader.Cells.Get(10, 0).Value = "10";
            this.spdEvent_Sheet1.RowHeader.Columns.Default.Resizable = true;
            this.spdEvent_Sheet1.RowHeader.Columns.Get(0).Width = 23F;
            this.spdEvent_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdEvent_Sheet1.Rows.Get(0).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(0).Label = "P";
            this.spdEvent_Sheet1.Rows.Get(1).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(1).Label = "1";
            this.spdEvent_Sheet1.Rows.Get(2).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(2).Label = "2";
            this.spdEvent_Sheet1.Rows.Get(3).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(3).Label = "3";
            this.spdEvent_Sheet1.Rows.Get(4).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(4).Label = "4";
            this.spdEvent_Sheet1.Rows.Get(5).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(5).Label = "5";
            this.spdEvent_Sheet1.Rows.Get(6).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(6).Label = "6";
            this.spdEvent_Sheet1.Rows.Get(7).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(7).Label = "7";
            this.spdEvent_Sheet1.Rows.Get(8).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(8).Label = "8";
            this.spdEvent_Sheet1.Rows.Get(9).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(9).Label = "9";
            this.spdEvent_Sheet1.Rows.Get(10).Height = 18F;
            this.spdEvent_Sheet1.Rows.Get(10).Label = "10";
            this.spdEvent_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdEvent_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdEvent_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.cboChangeUpDown);
            this.pnlStatus.Controls.Add(this.cboChangeUpDownFlag);
            this.pnlStatus.Controls.Add(this.cboCheckUpDown);
            this.pnlStatus.Controls.Add(this.cboCheckUpDownFlag);
            this.pnlStatus.Controls.Add(this.lblChangeUpDown);
            this.pnlStatus.Controls.Add(this.lblChangeUpDownFlag);
            this.pnlStatus.Controls.Add(this.lblCheckUpDown);
            this.pnlStatus.Controls.Add(this.lblCheckUpDownFlag);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(3, 3);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(486, 64);
            this.pnlStatus.TabIndex = 0;
            // 
            // cboChangeUpDown
            // 
            this.cboChangeUpDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChangeUpDown.Items.AddRange(new object[] {
            "",
            "UP",
            "DOWN"});
            this.cboChangeUpDown.Location = new System.Drawing.Point(376, 36);
            this.cboChangeUpDown.MaxLength = 1;
            this.cboChangeUpDown.Name = "cboChangeUpDown";
            this.cboChangeUpDown.Size = new System.Drawing.Size(108, 21);
            this.cboChangeUpDown.TabIndex = 7;
            // 
            // cboChangeUpDownFlag
            // 
            this.cboChangeUpDownFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChangeUpDownFlag.Items.AddRange(new object[] {
            "Y (Change)",
            "N (Not Change)"});
            this.cboChangeUpDownFlag.Location = new System.Drawing.Point(144, 36);
            this.cboChangeUpDownFlag.MaxLength = 1;
            this.cboChangeUpDownFlag.Name = "cboChangeUpDownFlag";
            this.cboChangeUpDownFlag.Size = new System.Drawing.Size(108, 21);
            this.cboChangeUpDownFlag.TabIndex = 5;
            this.cboChangeUpDownFlag.SelectedIndexChanged += new System.EventHandler(this.cboChangeUpDownFlag_SelectedIndexChanged);
            // 
            // cboCheckUpDown
            // 
            this.cboCheckUpDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckUpDown.Items.AddRange(new object[] {
            "",
            "UP",
            "DOWN"});
            this.cboCheckUpDown.Location = new System.Drawing.Point(376, 8);
            this.cboCheckUpDown.MaxLength = 1;
            this.cboCheckUpDown.Name = "cboCheckUpDown";
            this.cboCheckUpDown.Size = new System.Drawing.Size(108, 21);
            this.cboCheckUpDown.TabIndex = 3;
            // 
            // cboCheckUpDownFlag
            // 
            this.cboCheckUpDownFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCheckUpDownFlag.Items.AddRange(new object[] {
            "= (Equal)",
            "! (Not Equal)",
            "N (Not Check)"});
            this.cboCheckUpDownFlag.Location = new System.Drawing.Point(144, 8);
            this.cboCheckUpDownFlag.MaxLength = 1;
            this.cboCheckUpDownFlag.Name = "cboCheckUpDownFlag";
            this.cboCheckUpDownFlag.Size = new System.Drawing.Size(108, 21);
            this.cboCheckUpDownFlag.TabIndex = 1;
            this.cboCheckUpDownFlag.SelectedIndexChanged += new System.EventHandler(this.cboCheckUpDownFlag_SelectedIndexChanged);
            // 
            // lblChangeUpDown
            // 
            this.lblChangeUpDown.AutoSize = true;
            this.lblChangeUpDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChangeUpDown.Location = new System.Drawing.Point(268, 40);
            this.lblChangeUpDown.Name = "lblChangeUpDown";
            this.lblChangeUpDown.Size = new System.Drawing.Size(94, 13);
            this.lblChangeUpDown.TabIndex = 6;
            this.lblChangeUpDown.Text = "Change Up/Down";
            // 
            // lblChangeUpDownFlag
            // 
            this.lblChangeUpDownFlag.AutoSize = true;
            this.lblChangeUpDownFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChangeUpDownFlag.Location = new System.Drawing.Point(8, 40);
            this.lblChangeUpDownFlag.Name = "lblChangeUpDownFlag";
            this.lblChangeUpDownFlag.Size = new System.Drawing.Size(117, 13);
            this.lblChangeUpDownFlag.TabIndex = 4;
            this.lblChangeUpDownFlag.Text = "Change Up/Down Flag";
            // 
            // lblCheckUpDown
            // 
            this.lblCheckUpDown.AutoSize = true;
            this.lblCheckUpDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCheckUpDown.Location = new System.Drawing.Point(268, 12);
            this.lblCheckUpDown.Name = "lblCheckUpDown";
            this.lblCheckUpDown.Size = new System.Drawing.Size(88, 13);
            this.lblCheckUpDown.TabIndex = 2;
            this.lblCheckUpDown.Text = "Check Up/Down";
            // 
            // lblCheckUpDownFlag
            // 
            this.lblCheckUpDownFlag.AutoSize = true;
            this.lblCheckUpDownFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCheckUpDownFlag.Location = new System.Drawing.Point(8, 12);
            this.lblCheckUpDownFlag.Name = "lblCheckUpDownFlag";
            this.lblCheckUpDownFlag.Size = new System.Drawing.Size(111, 13);
            this.lblCheckUpDownFlag.TabIndex = 0;
            this.lblCheckUpDownFlag.Text = "Check Up/Down Flag";
            // 
            // tbpOption
            // 
            this.tbpOption.Controls.Add(this.grpInfo);
            this.tbpOption.Controls.Add(this.grpChart);
            this.tbpOption.Controls.Add(this.grpEDC);
            this.tbpOption.Location = new System.Drawing.Point(4, 22);
            this.tbpOption.Name = "tbpOption";
            this.tbpOption.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpOption.Size = new System.Drawing.Size(492, 401);
            this.tbpOption.TabIndex = 1;
            this.tbpOption.Text = "Option";
            this.tbpOption.Visible = false;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.txtUpdateTime);
            this.grpInfo.Controls.Add(this.txtCreateTime);
            this.grpInfo.Controls.Add(this.txtUpdateUser);
            this.grpInfo.Controls.Add(this.lblUpdate);
            this.grpInfo.Controls.Add(this.txtCreateUser);
            this.grpInfo.Controls.Add(this.lblCreate);
            this.grpInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpInfo.Location = new System.Drawing.Point(3, 120);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(486, 70);
            this.grpInfo.TabIndex = 4;
            this.grpInfo.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(303, 40);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(176, 20);
            this.txtUpdateTime.TabIndex = 5;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(303, 16);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(176, 20);
            this.txtCreateTime.TabIndex = 2;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 40);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 4;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(15, 43);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 3;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 16);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 1;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(15, 19);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 0;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.cboChart);
            this.grpChart.Controls.Add(this.lblChartFlag);
            this.grpChart.Controls.Add(this.cdvChartID);
            this.grpChart.Controls.Add(this.lblChartID);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(3, 52);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(486, 68);
            this.grpChart.TabIndex = 3;
            this.grpChart.TabStop = false;
            this.grpChart.Text = "SPC";
            // 
            // cboChart
            // 
            this.cboChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChart.Items.AddRange(new object[] {
            "",
            "Chart",
            "Chart Set"});
            this.cboChart.Location = new System.Drawing.Point(120, 16);
            this.cboChart.MaxLength = 1;
            this.cboChart.Name = "cboChart";
            this.cboChart.Size = new System.Drawing.Size(108, 21);
            this.cboChart.TabIndex = 1;
            this.cboChart.SelectedIndexChanged += new System.EventHandler(this.cboChart_SelectedIndexChanged);
            // 
            // lblChartFlag
            // 
            this.lblChartFlag.AutoSize = true;
            this.lblChartFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartFlag.Location = new System.Drawing.Point(15, 19);
            this.lblChartFlag.Name = "lblChartFlag";
            this.lblChartFlag.Size = new System.Drawing.Size(55, 13);
            this.lblChartFlag.TabIndex = 0;
            this.lblChartFlag.Text = "Chart Flag";
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
            this.cdvChartID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cdvChartID.Index = 0;
            this.cdvChartID.IsViewBtnImage = false;
            this.cdvChartID.Location = new System.Drawing.Point(120, 40);
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
            this.cdvChartID.ButtonPress += new System.EventHandler(this.cdvChartID_ButtonPress);
            // 
            // lblChartID
            // 
            this.lblChartID.AutoSize = true;
            this.lblChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartID.Location = new System.Drawing.Point(15, 43);
            this.lblChartID.Name = "lblChartID";
            this.lblChartID.Size = new System.Drawing.Size(46, 13);
            this.lblChartID.TabIndex = 2;
            this.lblChartID.Text = "Chart ID";
            // 
            // grpEDC
            // 
            this.grpEDC.Controls.Add(this.cdvColSetID);
            this.grpEDC.Controls.Add(this.lblEDCSet);
            this.grpEDC.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEDC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpEDC.Location = new System.Drawing.Point(3, 5);
            this.grpEDC.Name = "grpEDC";
            this.grpEDC.Size = new System.Drawing.Size(486, 47);
            this.grpEDC.TabIndex = 1;
            this.grpEDC.TabStop = false;
            this.grpEDC.Text = "EDC";
            // 
            // cdvColSetID
            // 
            this.cdvColSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvColSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvColSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvColSetID.BtnToolTipText = "";
            this.cdvColSetID.DescText = "";
            this.cdvColSetID.DisplaySubItemIndex = -1;
            this.cdvColSetID.DisplayText = "";
            this.cdvColSetID.Focusing = null;
            this.cdvColSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvColSetID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cdvColSetID.Index = 0;
            this.cdvColSetID.IsViewBtnImage = false;
            this.cdvColSetID.Location = new System.Drawing.Point(120, 16);
            this.cdvColSetID.MaxLength = 25;
            this.cdvColSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvColSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvColSetID.Name = "cdvColSetID";
            this.cdvColSetID.ReadOnly = false;
            this.cdvColSetID.SearchSubItemIndex = 0;
            this.cdvColSetID.SelectedDescIndex = -1;
            this.cdvColSetID.SelectedSubItemIndex = -1;
            this.cdvColSetID.SelectionStart = 0;
            this.cdvColSetID.Size = new System.Drawing.Size(200, 20);
            this.cdvColSetID.SmallImageList = null;
            this.cdvColSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvColSetID.TabIndex = 1;
            this.cdvColSetID.TextBoxToolTipText = "";
            this.cdvColSetID.TextBoxWidth = 200;
            this.cdvColSetID.VisibleButton = true;
            this.cdvColSetID.VisibleColumnHeader = false;
            this.cdvColSetID.VisibleDescription = false;
            this.cdvColSetID.ButtonPress += new System.EventHandler(this.cdvColSetID_ButtonPress);
            // 
            // lblEDCSet
            // 
            this.lblEDCSet.AutoSize = true;
            this.lblEDCSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEDCSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEDCSet.Location = new System.Drawing.Point(15, 19);
            this.lblEDCSet.Name = "lblEDCSet";
            this.lblEDCSet.Size = new System.Drawing.Size(55, 13);
            this.lblEDCSet.TabIndex = 0;
            this.lblEDCSet.Text = "Col Set ID";
            // 
            // tbpGroup
            // 
            this.tbpGroup.Controls.Add(this.grpGroup);
            this.tbpGroup.Location = new System.Drawing.Point(4, 22);
            this.tbpGroup.Name = "tbpGroup";
            this.tbpGroup.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tbpGroup.Size = new System.Drawing.Size(492, 401);
            this.tbpGroup.TabIndex = 2;
            this.tbpGroup.Text = "Group Setup";
            this.tbpGroup.Visible = false;
            // 
            // grpGroup
            // 
            this.grpGroup.Controls.Add(this.lblEventGrp10);
            this.grpGroup.Controls.Add(this.lblEventGrp9);
            this.grpGroup.Controls.Add(this.lblEventGrp8);
            this.grpGroup.Controls.Add(this.lblEventGrp7);
            this.grpGroup.Controls.Add(this.lblEventGrp6);
            this.grpGroup.Controls.Add(this.lblEventGrp5);
            this.grpGroup.Controls.Add(this.lblEventGrp4);
            this.grpGroup.Controls.Add(this.lblEventGrp3);
            this.grpGroup.Controls.Add(this.lblEventGrp2);
            this.grpGroup.Controls.Add(this.lblEventGrp1);
            this.grpGroup.Controls.Add(this.cdvGroup10);
            this.grpGroup.Controls.Add(this.cdvGroup9);
            this.grpGroup.Controls.Add(this.cdvGroup8);
            this.grpGroup.Controls.Add(this.cdvGroup7);
            this.grpGroup.Controls.Add(this.cdvGroup6);
            this.grpGroup.Controls.Add(this.cdvGroup5);
            this.grpGroup.Controls.Add(this.cdvGroup4);
            this.grpGroup.Controls.Add(this.cdvGroup3);
            this.grpGroup.Controls.Add(this.cdvGroup2);
            this.grpGroup.Controls.Add(this.cdvGroup1);
            this.grpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpGroup.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpGroup.Location = new System.Drawing.Point(3, 5);
            this.grpGroup.Name = "grpGroup";
            this.grpGroup.Size = new System.Drawing.Size(486, 393);
            this.grpGroup.TabIndex = 0;
            this.grpGroup.TabStop = false;
            this.grpGroup.Text = "Event Group(1~10)";
            // 
            // lblEventGrp10
            // 
            this.lblEventGrp10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp10.Location = new System.Drawing.Point(15, 235);
            this.lblEventGrp10.Name = "lblEventGrp10";
            this.lblEventGrp10.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp10.TabIndex = 18;
            // 
            // lblEventGrp9
            // 
            this.lblEventGrp9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp9.Location = new System.Drawing.Point(15, 211);
            this.lblEventGrp9.Name = "lblEventGrp9";
            this.lblEventGrp9.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp9.TabIndex = 16;
            // 
            // lblEventGrp8
            // 
            this.lblEventGrp8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp8.Location = new System.Drawing.Point(15, 187);
            this.lblEventGrp8.Name = "lblEventGrp8";
            this.lblEventGrp8.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp8.TabIndex = 14;
            // 
            // lblEventGrp7
            // 
            this.lblEventGrp7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp7.Location = new System.Drawing.Point(15, 163);
            this.lblEventGrp7.Name = "lblEventGrp7";
            this.lblEventGrp7.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp7.TabIndex = 12;
            // 
            // lblEventGrp6
            // 
            this.lblEventGrp6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp6.Location = new System.Drawing.Point(15, 139);
            this.lblEventGrp6.Name = "lblEventGrp6";
            this.lblEventGrp6.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp6.TabIndex = 10;
            // 
            // lblEventGrp5
            // 
            this.lblEventGrp5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp5.Location = new System.Drawing.Point(15, 115);
            this.lblEventGrp5.Name = "lblEventGrp5";
            this.lblEventGrp5.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp5.TabIndex = 8;
            // 
            // lblEventGrp4
            // 
            this.lblEventGrp4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp4.Location = new System.Drawing.Point(15, 91);
            this.lblEventGrp4.Name = "lblEventGrp4";
            this.lblEventGrp4.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp4.TabIndex = 6;
            // 
            // lblEventGrp3
            // 
            this.lblEventGrp3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp3.Location = new System.Drawing.Point(15, 67);
            this.lblEventGrp3.Name = "lblEventGrp3";
            this.lblEventGrp3.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp3.TabIndex = 4;
            // 
            // lblEventGrp2
            // 
            this.lblEventGrp2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp2.Location = new System.Drawing.Point(15, 43);
            this.lblEventGrp2.Name = "lblEventGrp2";
            this.lblEventGrp2.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp2.TabIndex = 2;
            // 
            // lblEventGrp1
            // 
            this.lblEventGrp1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEventGrp1.Location = new System.Drawing.Point(15, 19);
            this.lblEventGrp1.Name = "lblEventGrp1";
            this.lblEventGrp1.Size = new System.Drawing.Size(150, 14);
            this.lblEventGrp1.TabIndex = 0;
            // 
            // cdvGroup10
            // 
            this.cdvGroup10.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup10.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup10.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup10.BtnToolTipText = "";
            this.cdvGroup10.DescText = "";
            this.cdvGroup10.DisplaySubItemIndex = -1;
            this.cdvGroup10.DisplayText = "";
            this.cdvGroup10.Focusing = null;
            this.cdvGroup10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup10.Index = 0;
            this.cdvGroup10.IsViewBtnImage = false;
            this.cdvGroup10.Location = new System.Drawing.Point(172, 232);
            this.cdvGroup10.MaxLength = 30;
            this.cdvGroup10.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup10.Name = "cdvGroup10";
            this.cdvGroup10.ReadOnly = false;
            this.cdvGroup10.SearchSubItemIndex = 0;
            this.cdvGroup10.SelectedDescIndex = -1;
            this.cdvGroup10.SelectedSubItemIndex = -1;
            this.cdvGroup10.SelectionStart = 0;
            this.cdvGroup10.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup10.SmallImageList = null;
            this.cdvGroup10.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup10.TabIndex = 19;
            this.cdvGroup10.TextBoxToolTipText = "";
            this.cdvGroup10.TextBoxWidth = 200;
            this.cdvGroup10.VisibleButton = true;
            this.cdvGroup10.VisibleColumnHeader = false;
            this.cdvGroup10.VisibleDescription = false;
            this.cdvGroup10.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup9
            // 
            this.cdvGroup9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup9.BtnToolTipText = "";
            this.cdvGroup9.DescText = "";
            this.cdvGroup9.DisplaySubItemIndex = -1;
            this.cdvGroup9.DisplayText = "";
            this.cdvGroup9.Focusing = null;
            this.cdvGroup9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup9.Index = 0;
            this.cdvGroup9.IsViewBtnImage = false;
            this.cdvGroup9.Location = new System.Drawing.Point(172, 208);
            this.cdvGroup9.MaxLength = 30;
            this.cdvGroup9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup9.Name = "cdvGroup9";
            this.cdvGroup9.ReadOnly = false;
            this.cdvGroup9.SearchSubItemIndex = 0;
            this.cdvGroup9.SelectedDescIndex = -1;
            this.cdvGroup9.SelectedSubItemIndex = -1;
            this.cdvGroup9.SelectionStart = 0;
            this.cdvGroup9.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup9.SmallImageList = null;
            this.cdvGroup9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup9.TabIndex = 17;
            this.cdvGroup9.TextBoxToolTipText = "";
            this.cdvGroup9.TextBoxWidth = 200;
            this.cdvGroup9.VisibleButton = true;
            this.cdvGroup9.VisibleColumnHeader = false;
            this.cdvGroup9.VisibleDescription = false;
            this.cdvGroup9.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup8
            // 
            this.cdvGroup8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup8.BtnToolTipText = "";
            this.cdvGroup8.DescText = "";
            this.cdvGroup8.DisplaySubItemIndex = -1;
            this.cdvGroup8.DisplayText = "";
            this.cdvGroup8.Focusing = null;
            this.cdvGroup8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup8.Index = 0;
            this.cdvGroup8.IsViewBtnImage = false;
            this.cdvGroup8.Location = new System.Drawing.Point(172, 184);
            this.cdvGroup8.MaxLength = 30;
            this.cdvGroup8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup8.Name = "cdvGroup8";
            this.cdvGroup8.ReadOnly = false;
            this.cdvGroup8.SearchSubItemIndex = 0;
            this.cdvGroup8.SelectedDescIndex = -1;
            this.cdvGroup8.SelectedSubItemIndex = -1;
            this.cdvGroup8.SelectionStart = 0;
            this.cdvGroup8.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup8.SmallImageList = null;
            this.cdvGroup8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup8.TabIndex = 15;
            this.cdvGroup8.TextBoxToolTipText = "";
            this.cdvGroup8.TextBoxWidth = 200;
            this.cdvGroup8.VisibleButton = true;
            this.cdvGroup8.VisibleColumnHeader = false;
            this.cdvGroup8.VisibleDescription = false;
            this.cdvGroup8.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup7
            // 
            this.cdvGroup7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup7.BtnToolTipText = "";
            this.cdvGroup7.DescText = "";
            this.cdvGroup7.DisplaySubItemIndex = -1;
            this.cdvGroup7.DisplayText = "";
            this.cdvGroup7.Focusing = null;
            this.cdvGroup7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup7.Index = 0;
            this.cdvGroup7.IsViewBtnImage = false;
            this.cdvGroup7.Location = new System.Drawing.Point(172, 160);
            this.cdvGroup7.MaxLength = 30;
            this.cdvGroup7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup7.Name = "cdvGroup7";
            this.cdvGroup7.ReadOnly = false;
            this.cdvGroup7.SearchSubItemIndex = 0;
            this.cdvGroup7.SelectedDescIndex = -1;
            this.cdvGroup7.SelectedSubItemIndex = -1;
            this.cdvGroup7.SelectionStart = 0;
            this.cdvGroup7.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup7.SmallImageList = null;
            this.cdvGroup7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup7.TabIndex = 13;
            this.cdvGroup7.TextBoxToolTipText = "";
            this.cdvGroup7.TextBoxWidth = 200;
            this.cdvGroup7.VisibleButton = true;
            this.cdvGroup7.VisibleColumnHeader = false;
            this.cdvGroup7.VisibleDescription = false;
            this.cdvGroup7.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup6
            // 
            this.cdvGroup6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup6.BtnToolTipText = "";
            this.cdvGroup6.DescText = "";
            this.cdvGroup6.DisplaySubItemIndex = -1;
            this.cdvGroup6.DisplayText = "";
            this.cdvGroup6.Focusing = null;
            this.cdvGroup6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup6.Index = 0;
            this.cdvGroup6.IsViewBtnImage = false;
            this.cdvGroup6.Location = new System.Drawing.Point(172, 136);
            this.cdvGroup6.MaxLength = 30;
            this.cdvGroup6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup6.Name = "cdvGroup6";
            this.cdvGroup6.ReadOnly = false;
            this.cdvGroup6.SearchSubItemIndex = 0;
            this.cdvGroup6.SelectedDescIndex = -1;
            this.cdvGroup6.SelectedSubItemIndex = -1;
            this.cdvGroup6.SelectionStart = 0;
            this.cdvGroup6.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup6.SmallImageList = null;
            this.cdvGroup6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup6.TabIndex = 11;
            this.cdvGroup6.TextBoxToolTipText = "";
            this.cdvGroup6.TextBoxWidth = 200;
            this.cdvGroup6.VisibleButton = true;
            this.cdvGroup6.VisibleColumnHeader = false;
            this.cdvGroup6.VisibleDescription = false;
            this.cdvGroup6.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup5
            // 
            this.cdvGroup5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup5.BtnToolTipText = "";
            this.cdvGroup5.DescText = "";
            this.cdvGroup5.DisplaySubItemIndex = -1;
            this.cdvGroup5.DisplayText = "";
            this.cdvGroup5.Focusing = null;
            this.cdvGroup5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup5.Index = 0;
            this.cdvGroup5.IsViewBtnImage = false;
            this.cdvGroup5.Location = new System.Drawing.Point(172, 112);
            this.cdvGroup5.MaxLength = 30;
            this.cdvGroup5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup5.Name = "cdvGroup5";
            this.cdvGroup5.ReadOnly = false;
            this.cdvGroup5.SearchSubItemIndex = 0;
            this.cdvGroup5.SelectedDescIndex = -1;
            this.cdvGroup5.SelectedSubItemIndex = -1;
            this.cdvGroup5.SelectionStart = 0;
            this.cdvGroup5.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup5.SmallImageList = null;
            this.cdvGroup5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup5.TabIndex = 9;
            this.cdvGroup5.TextBoxToolTipText = "";
            this.cdvGroup5.TextBoxWidth = 200;
            this.cdvGroup5.VisibleButton = true;
            this.cdvGroup5.VisibleColumnHeader = false;
            this.cdvGroup5.VisibleDescription = false;
            this.cdvGroup5.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup4
            // 
            this.cdvGroup4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup4.BtnToolTipText = "";
            this.cdvGroup4.DescText = "";
            this.cdvGroup4.DisplaySubItemIndex = -1;
            this.cdvGroup4.DisplayText = "";
            this.cdvGroup4.Focusing = null;
            this.cdvGroup4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup4.Index = 0;
            this.cdvGroup4.IsViewBtnImage = false;
            this.cdvGroup4.Location = new System.Drawing.Point(172, 88);
            this.cdvGroup4.MaxLength = 30;
            this.cdvGroup4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup4.Name = "cdvGroup4";
            this.cdvGroup4.ReadOnly = false;
            this.cdvGroup4.SearchSubItemIndex = 0;
            this.cdvGroup4.SelectedDescIndex = -1;
            this.cdvGroup4.SelectedSubItemIndex = -1;
            this.cdvGroup4.SelectionStart = 0;
            this.cdvGroup4.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup4.SmallImageList = null;
            this.cdvGroup4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup4.TabIndex = 7;
            this.cdvGroup4.TextBoxToolTipText = "";
            this.cdvGroup4.TextBoxWidth = 200;
            this.cdvGroup4.VisibleButton = true;
            this.cdvGroup4.VisibleColumnHeader = false;
            this.cdvGroup4.VisibleDescription = false;
            this.cdvGroup4.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup3
            // 
            this.cdvGroup3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup3.BtnToolTipText = "";
            this.cdvGroup3.DescText = "";
            this.cdvGroup3.DisplaySubItemIndex = -1;
            this.cdvGroup3.DisplayText = "";
            this.cdvGroup3.Focusing = null;
            this.cdvGroup3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup3.Index = 0;
            this.cdvGroup3.IsViewBtnImage = false;
            this.cdvGroup3.Location = new System.Drawing.Point(172, 64);
            this.cdvGroup3.MaxLength = 30;
            this.cdvGroup3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup3.Name = "cdvGroup3";
            this.cdvGroup3.ReadOnly = false;
            this.cdvGroup3.SearchSubItemIndex = 0;
            this.cdvGroup3.SelectedDescIndex = -1;
            this.cdvGroup3.SelectedSubItemIndex = -1;
            this.cdvGroup3.SelectionStart = 0;
            this.cdvGroup3.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup3.SmallImageList = null;
            this.cdvGroup3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup3.TabIndex = 5;
            this.cdvGroup3.TextBoxToolTipText = "";
            this.cdvGroup3.TextBoxWidth = 200;
            this.cdvGroup3.VisibleButton = true;
            this.cdvGroup3.VisibleColumnHeader = false;
            this.cdvGroup3.VisibleDescription = false;
            this.cdvGroup3.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup2
            // 
            this.cdvGroup2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup2.BtnToolTipText = "";
            this.cdvGroup2.DescText = "";
            this.cdvGroup2.DisplaySubItemIndex = -1;
            this.cdvGroup2.DisplayText = "";
            this.cdvGroup2.Focusing = null;
            this.cdvGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup2.Index = 0;
            this.cdvGroup2.IsViewBtnImage = false;
            this.cdvGroup2.Location = new System.Drawing.Point(172, 40);
            this.cdvGroup2.MaxLength = 30;
            this.cdvGroup2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup2.Name = "cdvGroup2";
            this.cdvGroup2.ReadOnly = false;
            this.cdvGroup2.SearchSubItemIndex = 0;
            this.cdvGroup2.SelectedDescIndex = -1;
            this.cdvGroup2.SelectedSubItemIndex = -1;
            this.cdvGroup2.SelectionStart = 0;
            this.cdvGroup2.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup2.SmallImageList = null;
            this.cdvGroup2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup2.TabIndex = 3;
            this.cdvGroup2.TextBoxToolTipText = "";
            this.cdvGroup2.TextBoxWidth = 200;
            this.cdvGroup2.VisibleButton = true;
            this.cdvGroup2.VisibleColumnHeader = false;
            this.cdvGroup2.VisibleDescription = false;
            this.cdvGroup2.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // cdvGroup1
            // 
            this.cdvGroup1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup1.BtnToolTipText = "";
            this.cdvGroup1.DescText = "";
            this.cdvGroup1.DisplaySubItemIndex = -1;
            this.cdvGroup1.DisplayText = "";
            this.cdvGroup1.Focusing = null;
            this.cdvGroup1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup1.Index = 0;
            this.cdvGroup1.IsViewBtnImage = false;
            this.cdvGroup1.Location = new System.Drawing.Point(172, 16);
            this.cdvGroup1.MaxLength = 30;
            this.cdvGroup1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup1.Name = "cdvGroup1";
            this.cdvGroup1.ReadOnly = false;
            this.cdvGroup1.SearchSubItemIndex = 0;
            this.cdvGroup1.SelectedDescIndex = -1;
            this.cdvGroup1.SelectedSubItemIndex = -1;
            this.cdvGroup1.SelectionStart = 0;
            this.cdvGroup1.Size = new System.Drawing.Size(200, 20);
            this.cdvGroup1.SmallImageList = null;
            this.cdvGroup1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup1.TabIndex = 1;
            this.cdvGroup1.TextBoxToolTipText = "";
            this.cdvGroup1.TextBoxWidth = 200;
            this.cdvGroup1.VisibleButton = true;
            this.cdvGroup1.VisibleColumnHeader = false;
            this.cdvGroup1.VisibleDescription = false;
            this.cdvGroup1.ButtonPress += new System.EventHandler(this.cdvGrpCmf_ButtonPress);
            // 
            // grpTop
            // 
            this.grpTop.Controls.Add(this.chkSystemFlag);
            this.grpTop.Controls.Add(this.lblDesc);
            this.grpTop.Controls.Add(this.lblEvent);
            this.grpTop.Controls.Add(this.txtDesc);
            this.grpTop.Controls.Add(this.txtEvent);
            this.grpTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpTop.Location = new System.Drawing.Point(3, 0);
            this.grpTop.Name = "grpTop";
            this.grpTop.Size = new System.Drawing.Size(500, 71);
            this.grpTop.TabIndex = 0;
            this.grpTop.TabStop = false;
            // 
            // chkSystemFlag
            // 
            this.chkSystemFlag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSystemFlag.AutoSize = true;
            this.chkSystemFlag.Enabled = false;
            this.chkSystemFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSystemFlag.Location = new System.Drawing.Point(385, 16);
            this.chkSystemFlag.Name = "chkSystemFlag";
            this.chkSystemFlag.Size = new System.Drawing.Size(89, 18);
            this.chkSystemFlag.TabIndex = 4;
            this.chkSystemFlag.Text = "System Flag";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(15, 19);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(40, 13);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Event";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(354, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(120, 16);
            this.txtEvent.MaxLength = 12;
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(200, 20);
            this.txtEvent.TabIndex = 1;
            this.txtEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEvent_KeyPress);
            this.txtEvent.LostFocus += new System.EventHandler(this.txtEvent_LostFocus);
            // 
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableList.Location = new System.Drawing.Point(168, 17);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "cdvTableList";
            this.cdvTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 0;
            this.cdvTableList.TabStop = false;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.Visible = false;
            this.cdvTableList.VisibleColumnHeader = false;
            this.cdvTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableList_SelectedItemChanged);
            // 
            // frmRASSetupEvent
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Name = "frmRASSetupEvent";
            this.Text = "Event Setup";
            this.Activated += new System.EventHandler(this.frmRASSetupEvent_Activated);
            this.Load += new System.EventHandler(this.frmRASSetupEvent_Load);
            this.pnlFind.ResumeLayout(false);
            this.pnlFind.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTab.ResumeLayout(false);
            this.tabEvent.ResumeLayout(false);
            this.tbpEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdEvent_Sheet1)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.tbpOption.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpChart.ResumeLayout(false);
            this.grpChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartID)).EndInit();
            this.grpEDC.ResumeLayout(false);
            this.grpEDC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvColSetID)).EndInit();
            this.tbpGroup.ResumeLayout(false);
            this.grpGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup1)).EndInit();
            this.grpTop.ResumeLayout(false);
            this.grpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region "Const Definition"
        private const string NOT_CHECK = "N (Not Check)";
        private const string EQUAL = "= (Equal)";
        private const string NOT_EQUAL = "! (Not Equal)";
        private const string GREATER = "> (Greater than)";
        private const string LESS = "< (Less than)";
        private const string TABLE = "T (Table)";
        private const string CHANGE = "Y (Change)";
        private const string NOT_CHANGE = "N (Not Change)";
        private const string INCREASE = "+ (Increase)";
        private const string DECREASE = "- (Decrease)";
        private const string OVERRIDE = "O (Override)";
        private const string TIME = "T (Time)";
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
        
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            int i;

            switch (MPCF.Trim(FuncName))
            {
                case "Update_Event":
                    
                    if (ProcStep != MPGC.MP_STEP_DELETE)
                    {
                        if (MPCF.CheckValue(txtEvent, 1) == false)
                        {
                            return false;
                        }
                        if (cboCheckUpDownFlag.Text != NOT_CHECK && cboCheckUpDownFlag.Text != "")
                        {
                            if (cboCheckUpDown.Text == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                cboCheckUpDown.Focus();
                                return false;
                            }
                        }
                        if (cboChangeUpDownFlag.Text == CHANGE)
                        {
                            if (cboChangeUpDown.Text == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                cboChangeUpDown.Focus();
                                return false;
                            }
                        }
                        for (i = 0; i <= 10; i++)
                        {
                            if (spdEvent.Sheets[0].Cells[i, 0].Text != "" && spdEvent.Sheets[0].Cells[i, 0].Text != NOT_CHECK)
                            {
                                if (spdEvent.Sheets[0].Cells[i, 1].Text == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdEvent.Sheets[0].SetActiveCell(i, 1);
                                    return false;
                                }
                            }
                        }
                        for (i = 0; i <= 10; i++)
                        {
                            if (spdEvent.Sheets[0].Cells[i, 0].Text != "" && spdEvent.Sheets[0].Cells[i, 3].Text == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdEvent.Sheets[0].SetActiveCell(i, 3);
                                return false;
                            }
                        }
                        for (i = 0; i <= 10; i++)
                        {
                            if (spdEvent.Sheets[0].Cells[i, 3].Text != "" && spdEvent.Sheets[0].Cells[i, 3].Text != NOT_CHANGE && spdEvent.Sheets[0].Cells[i, 3].Text != OVERRIDE && spdEvent.Sheets[0].Cells[i, 3].Text != TIME && spdEvent.Sheets[0].Cells[i, 3].Text != CHANGE)
                            {
                                if (spdEvent.Sheets[0].Cells[i, 4].Text == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdEvent.Sheets[0].SetActiveCell(i, 4);
                                    return false;
                                }
                            }
                        }
                        for (i = 0; i <= 10; i++)
                        {
                            if (spdEvent.Sheets[0].Cells[i, 0].Text == GREATER || spdEvent.Sheets[0].Cells[i, 0].Text == LESS)
                            {
                                if (MPCF.CheckNumeric(spdEvent.Sheets[0].Cells[i, 1].Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    spdEvent.Sheets[0].SetActiveCell(i, 1);
                                    return false;
                                }
                            }
                        }
                        for (i = 0; i <= 10; i++)
                        {
                            if (spdEvent.Sheets[0].Cells[i, 3].Text == INCREASE || spdEvent.Sheets[0].Cells[i, 3].Text == DECREASE)
                            {
                                if (MPCF.CheckNumeric(spdEvent.Sheets[0].Cells[i, 4].Text) == false)
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                                    spdEvent.Sheets[0].SetActiveCell(i, 4);
                                    return false;
                                }
                            }
                        }
                        
                        //For i = 0 To 10
                        //If spdEvent.Sheets(0).Cells(i, 0).Text = TABLE And spdEvent.Sheets(0).Cells(i, 5).Text.Trim = "" Then
                        //ShowMsgBox(GetMessage(108))
                        //spdEvent.Sheets(0).SetActiveCell(i, 5)
                        //Return False
                        //End If
                        //Next
                        
                        if (MPCR.CheckGRPCMFValue("lblEventGrp", "cdvGroup", grpGroup) == false)
                        {
                            return false;
                        }
                    }
                    break;
            }
            
            return true;
        }
        
        private void SetGroupCmfItem()
        {
            string[] sGrpTableName = new string[10];
            
            sGrpTableName[0] = MPGC.MP_GCM_EVN_GRP_1;
            sGrpTableName[1] = MPGC.MP_GCM_EVN_GRP_2;
            sGrpTableName[2] = MPGC.MP_GCM_EVN_GRP_3;
            sGrpTableName[3] = MPGC.MP_GCM_EVN_GRP_4;
            sGrpTableName[4] = MPGC.MP_GCM_EVN_GRP_5;
            sGrpTableName[5] = MPGC.MP_GCM_EVN_GRP_6;
            sGrpTableName[6] = MPGC.MP_GCM_EVN_GRP_7;
            sGrpTableName[7] = MPGC.MP_GCM_EVN_GRP_8;
            sGrpTableName[8] = MPGC.MP_GCM_EVN_GRP_9;
            sGrpTableName[9] = MPGC.MP_GCM_EVN_GRP_10;
            
            MPCR.SetGRPItem(MPGC.MP_GRP_EVENT, "lblEventGrp", "cdvGroup", grpGroup, sGrpTableName);
            
        }
        
        //
        // Update_Event
        //       - Create and Update and Delete Event
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool Update_Event(char ProcStep)
        {
            TRSNode in_node = new TRSNode("Update_Event_In");
            TRSNode out_node = new TRSNode("Cmn_Out");
            
            ListViewItem itm;
            int idx;
            
            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("EVENT_ID", MPCF.Trim(txtEvent.Text));
                in_node.AddString("EVENT_DESC", MPCF.Trim(txtDesc.Text));

                in_node.AddString("EVENT_GRP_1", MPCF.Trim(cdvGroup1.Text));
                in_node.AddString("EVENT_GRP_2", MPCF.Trim(cdvGroup2.Text));
                in_node.AddString("EVENT_GRP_3", MPCF.Trim(cdvGroup3.Text));
                in_node.AddString("EVENT_GRP_4", MPCF.Trim(cdvGroup4.Text));
                in_node.AddString("EVENT_GRP_5", MPCF.Trim(cdvGroup5.Text));
                in_node.AddString("EVENT_GRP_6", MPCF.Trim(cdvGroup6.Text));
                in_node.AddString("EVENT_GRP_7", MPCF.Trim(cdvGroup7.Text));
                in_node.AddString("EVENT_GRP_8", MPCF.Trim(cdvGroup8.Text));
                in_node.AddString("EVENT_GRP_9", MPCF.Trim(cdvGroup9.Text));
                in_node.AddString("EVENT_GRP_10", MPCF.Trim(cdvGroup10.Text));
                in_node.AddChar("SYSTEM_FLAG", (chkSystemFlag.Checked == true ? 'Y' : ' '));

                if (cboCheckUpDownFlag.Text == "")
                {
                    in_node.AddChar("CHK_UP_DOWN_FLAG", 'N');
                    in_node.AddChar("CHK_UP_DOWN", ' ');

                }
                else
                {
                    in_node.AddChar("CHK_UP_DOWN_FLAG", MPCF.ToChar(cboCheckUpDownFlag.Text));
                    in_node.AddChar("CHK_UP_DOWN", MPCF.ToChar(cboCheckUpDown.Text));

                }
                if (cboChangeUpDownFlag.Text == "")
                {
                    in_node.AddChar("CHG_UP_DOWN_FLAG", 'N');
                    in_node.AddChar("CHG_UP_DOWN", ' ');

                }
                else
                {
                    in_node.AddChar("CHG_UP_DOWN_FLAG", MPCF.ToChar(cboChangeUpDownFlag.Text));
                    in_node.AddChar("CHG_UP_DOWN", MPCF.ToChar(cboChangeUpDown.Text));

                }

                in_node.AddChar("CHK_PRI_STS_FLAG", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(0, 0))));
                in_node.AddString("CHK_PRI_STS", MPCF.Trim(spdEvent.Sheets[0].GetText(0, 1)));
                in_node.AddChar("CHG_PRI_STS_FLAG", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(0, 3))));
                in_node.AddString("CHG_PRI_STS", MPCF.Trim(spdEvent.Sheets[0].GetText(0, 4)));
                in_node.AddString("TBL_PRI_STS", MPCF.Trim(spdEvent.Sheets[0].GetText(0, 5)));
                in_node.AddChar("CHK_FLAG_1", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(1, 0))));
                in_node.AddChar("CHK_FLAG_2", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(2, 0))));
                in_node.AddChar("CHK_FLAG_3", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(3, 0))));
                in_node.AddChar("CHK_FLAG_4", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(4, 0))));
                in_node.AddChar("CHK_FLAG_5", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(5, 0))));
                in_node.AddChar("CHK_FLAG_6", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(6, 0))));
                in_node.AddChar("CHK_FLAG_7", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(7, 0))));
                in_node.AddChar("CHK_FLAG_8", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(8, 0))));
                in_node.AddChar("CHK_FLAG_9", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(9, 0))));
                in_node.AddChar("CHK_FLAG_10", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(10, 0))));
                in_node.AddString("CHK_STS_1", MPCF.Trim(spdEvent.Sheets[0].GetText(1, 1)));
                in_node.AddString("CHK_STS_2", MPCF.Trim(spdEvent.Sheets[0].GetText(2, 1)));
                in_node.AddString("CHK_STS_3", MPCF.Trim(spdEvent.Sheets[0].GetText(3, 1)));
                in_node.AddString("CHK_STS_4", MPCF.Trim(spdEvent.Sheets[0].GetText(4, 1)));
                in_node.AddString("CHK_STS_5", MPCF.Trim(spdEvent.Sheets[0].GetText(5, 1)));
                in_node.AddString("CHK_STS_6", MPCF.Trim(spdEvent.Sheets[0].GetText(6, 1)));
                in_node.AddString("CHK_STS_7", MPCF.Trim(spdEvent.Sheets[0].GetText(7, 1)));
                in_node.AddString("CHK_STS_8", MPCF.Trim(spdEvent.Sheets[0].GetText(8, 1)));
                in_node.AddString("CHK_STS_9", MPCF.Trim(spdEvent.Sheets[0].GetText(9, 1)));
                in_node.AddString("CHK_STS_10", MPCF.Trim(spdEvent.Sheets[0].GetText(10, 1)));
                in_node.AddChar("CHG_FLAG_1", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(1, 3))));
                in_node.AddChar("CHG_FLAG_2", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(2, 3))));
                in_node.AddChar("CHG_FLAG_3", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(3, 3))));
                in_node.AddChar("CHG_FLAG_4", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(4, 3))));
                in_node.AddChar("CHG_FLAG_5", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(5, 3))));
                in_node.AddChar("CHG_FLAG_6", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(6, 3))));
                in_node.AddChar("CHG_FLAG_7", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(7, 3))));
                in_node.AddChar("CHG_FLAG_8", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(8, 3))));
                in_node.AddChar("CHG_FLAG_9", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(9, 3))));
                in_node.AddChar("CHG_FLAG_10", MPCF.ToChar(MPCF.Trim(spdEvent.Sheets[0].GetText(10, 3))));
                in_node.AddString("CHG_STS_1", MPCF.Trim(spdEvent.Sheets[0].GetText(1, 4)));
                in_node.AddString("CHG_STS_2", MPCF.Trim(spdEvent.Sheets[0].GetText(2, 4)));
                in_node.AddString("CHG_STS_3", MPCF.Trim(spdEvent.Sheets[0].GetText(3, 4)));
                in_node.AddString("CHG_STS_4", MPCF.Trim(spdEvent.Sheets[0].GetText(4, 4)));
                in_node.AddString("CHG_STS_5", MPCF.Trim(spdEvent.Sheets[0].GetText(5, 4)));
                in_node.AddString("CHG_STS_6", MPCF.Trim(spdEvent.Sheets[0].GetText(6, 4)));
                in_node.AddString("CHG_STS_7", MPCF.Trim(spdEvent.Sheets[0].GetText(7, 4)));
                in_node.AddString("CHG_STS_8", MPCF.Trim(spdEvent.Sheets[0].GetText(8, 4)));
                in_node.AddString("CHG_STS_9", MPCF.Trim(spdEvent.Sheets[0].GetText(9, 4)));
                in_node.AddString("CHG_STS_10", MPCF.Trim(spdEvent.Sheets[0].GetText(10, 4)));
                in_node.AddString("TBL_1", MPCF.Trim(spdEvent.Sheets[0].GetValue(1, 5)));
                in_node.AddString("TBL_2", MPCF.Trim(spdEvent.Sheets[0].GetValue(2, 5)));
                in_node.AddString("TBL_3", MPCF.Trim(spdEvent.Sheets[0].GetValue(3, 5)));
                in_node.AddString("TBL_4", MPCF.Trim(spdEvent.Sheets[0].GetValue(4, 5)));
                in_node.AddString("TBL_5", MPCF.Trim(spdEvent.Sheets[0].GetValue(5, 5)));
                in_node.AddString("TBL_6", MPCF.Trim(spdEvent.Sheets[0].GetValue(6, 5)));
                in_node.AddString("TBL_7", MPCF.Trim(spdEvent.Sheets[0].GetValue(7, 5)));
                in_node.AddString("TBL_8", MPCF.Trim(spdEvent.Sheets[0].GetValue(8, 5)));
                in_node.AddString("TBL_9", MPCF.Trim(spdEvent.Sheets[0].GetValue(9, 5)));
                in_node.AddString("TBL_10", MPCF.Trim(spdEvent.Sheets[0].GetValue(10, 5)));

                
                if (cboChart.Text == "Chart")
                {
                    in_node.AddChar("CHART_FLAG", 'C');
                    in_node.AddString("CHART_ID", MPCF.Trim(cdvChartID.Text));

                }
                else if (cboChart.Text == "Chart Set")
                {
                    in_node.AddChar("CHART_FLAG", 'S');
                    in_node.AddString("CHART_ID", MPCF.Trim(cdvChartID.Text));

                }
                else
                {
                    in_node.AddChar("CHART_FLAG", ' ');
                    in_node.AddString("CHART_ID", "");
                }

                in_node.AddString("COL_SET_ID", cdvColSetID.Text);

                if (MPCR.CallService("RAS", "RAS_Update_Event", in_node, ref out_node) == false)
                {
                    return false;
                }
                
                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisEvent.Items.Add(txtEvent.Text, (int)SMALLICON_INDEX.IDX_EVENT);
                        itm.SubItems.Add(txtDesc.Text);
                        itm.Selected = true;
                        lisEvent.Sorting = SortOrder.Ascending;
                        lisEvent.Sort();
                        itm.EnsureVisible();
                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisEvent, MPCF.Trim(txtEvent.Text), false) == true)
                        {
                            lisEvent.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisEvent, MPCF.Trim(txtEvent.Text), false);
                        if (idx != - 1)
                        {
                            lisEvent.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisEvent.Items.Count);
                }
                MPCR.ShowSuccessMsg(out_node);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
            return true;
            
        }
        
        //
        // View_Event
        //       - View Event
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool View_Event(char ProcStep)
        {
            TRSNode in_node = new TRSNode("View_Event_In");
            TRSNode out_node = new TRSNode("View_Event_Out");
            
            int i;

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = ProcStep;
            in_node.AddString("EVENT_ID", txtEvent.Text);

            if (MPCR.CallService("RAS", "RAS_View_Event", in_node, ref out_node) == false)
            {
                return false;
            }

            txtEvent.Text = out_node.GetString("EVENT_ID");
            txtDesc.Text = out_node.GetString("EVENT_DESC");
            cdvGroup1.Text = out_node.GetString("EVENT_GRP_1");
            cdvGroup2.Text = out_node.GetString("EVENT_GRP_2");
            cdvGroup3.Text = out_node.GetString("EVENT_GRP_3");
            cdvGroup4.Text = out_node.GetString("EVENT_GRP_4");
            cdvGroup5.Text = out_node.GetString("EVENT_GRP_5");
            cdvGroup6.Text = out_node.GetString("EVENT_GRP_6");
            cdvGroup7.Text = out_node.GetString("EVENT_GRP_7");
            cdvGroup8.Text = out_node.GetString("EVENT_GRP_8");
            cdvGroup9.Text = out_node.GetString("EVENT_GRP_9");
            cdvGroup10.Text = out_node.GetString("EVENT_GRP_10");

            if (out_node.GetChar("SYSTEM_FLAG") == 'Y')
            {
                chkSystemFlag.Checked = true;
            }
            else
            {
                chkSystemFlag.Checked = false;
            }
            if (MPCF.Trim(out_node.GetChar("CHK_UP_DOWN_FLAG")) == "=")
            {
                cboCheckUpDownFlag.Text = EQUAL;
            }
            else if (MPCF.Trim(out_node.GetChar("CHK_UP_DOWN_FLAG")) == "!")
            {
                cboCheckUpDownFlag.Text = NOT_EQUAL;
            }
            else if (MPCF.Trim(out_node.GetChar("CHK_UP_DOWN_FLAG")) == "N")
            {
                cboCheckUpDownFlag.Text = NOT_CHECK;
            }
            if (MPCF.Trim(out_node.GetChar("CHK_UP_DOWN")) == "U")
            {
                cboCheckUpDown.Text = "Up";
            }
            else if (MPCF.Trim(out_node.GetChar("CHK_UP_DOWN")) == "D")
            {
                cboCheckUpDown.Text = "Down";
            }
            if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "U")
            {
                cboChangeUpDown.Text = "UP";
            }
            else if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN")) == "D")
            {
                cboChangeUpDown.Text = "DOWN";
            }
            if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN_FLAG")) == "Y")
            {
                cboChangeUpDownFlag.Text = CHANGE;
            }
            else if (MPCF.Trim(out_node.GetChar("CHG_UP_DOWN_FLAG")) == "N")
            {
                cboChangeUpDownFlag.Text = NOT_CHANGE;
            }
            spdEvent.Sheets[0].SetText(0, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_PRI_STS_FLAG"))));
            spdEvent.Sheets[0].SetText(0, 1, MPCF.Trim(out_node.GetString("CHK_PRI_STS")));
            spdEvent.Sheets[0].SetText(0, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_PRI_STS_FLAG"))));
            spdEvent.Sheets[0].SetText(0, 4, MPCF.Trim(out_node.GetString("CHG_PRI_STS")));
            spdEvent.Sheets[0].SetText(0, 5, MPCF.Trim(out_node.GetString("TBL_PRI_STS")));
            spdEvent.Sheets[0].SetText(1, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_1"))));
            spdEvent.Sheets[0].SetText(2, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_2"))));
            spdEvent.Sheets[0].SetText(3, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_3"))));
            spdEvent.Sheets[0].SetText(4, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_4"))));
            spdEvent.Sheets[0].SetText(5, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_5"))));
            spdEvent.Sheets[0].SetText(6, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_6"))));
            spdEvent.Sheets[0].SetText(7, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_7"))));
            spdEvent.Sheets[0].SetText(8, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_8"))));
            spdEvent.Sheets[0].SetText(9, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_9"))));
            spdEvent.Sheets[0].SetText(10, 0, MakeCheckFlag(MPCF.Trim(out_node.GetChar("CHK_FLAG_10"))));
            spdEvent.Sheets[0].SetText(1, 1, MPCF.Trim(out_node.GetString("CHK_STS_1")));
            spdEvent.Sheets[0].SetText(2, 1, MPCF.Trim(out_node.GetString("CHK_STS_2")));
            spdEvent.Sheets[0].SetText(3, 1, MPCF.Trim(out_node.GetString("CHK_STS_3")));
            spdEvent.Sheets[0].SetText(4, 1, MPCF.Trim(out_node.GetString("CHK_STS_4")));
            spdEvent.Sheets[0].SetText(5, 1, MPCF.Trim(out_node.GetString("CHK_STS_5")));
            spdEvent.Sheets[0].SetText(6, 1, MPCF.Trim(out_node.GetString("CHK_STS_6")));
            spdEvent.Sheets[0].SetText(7, 1, MPCF.Trim(out_node.GetString("CHK_STS_7")));
            spdEvent.Sheets[0].SetText(8, 1, MPCF.Trim(out_node.GetString("CHK_STS_8")));
            spdEvent.Sheets[0].SetText(9, 1, MPCF.Trim(out_node.GetString("CHK_STS_9")));
            spdEvent.Sheets[0].SetText(10, 1, MPCF.Trim(out_node.GetString("CHK_STS_10")));
            spdEvent.Sheets[0].SetText(1, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_1"))));
            spdEvent.Sheets[0].SetText(2, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_2"))));
            spdEvent.Sheets[0].SetText(3, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_3"))));
            spdEvent.Sheets[0].SetText(4, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_4"))));
            spdEvent.Sheets[0].SetText(5, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_5"))));
            spdEvent.Sheets[0].SetText(6, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_6"))));
            spdEvent.Sheets[0].SetText(7, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_7"))));
            spdEvent.Sheets[0].SetText(8, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_8"))));
            spdEvent.Sheets[0].SetText(9, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_9"))));
            spdEvent.Sheets[0].SetText(10, 3, MakeChangeFlag(MPCF.Trim(out_node.GetChar("CHG_FLAG_10"))));
            spdEvent.Sheets[0].SetText(1, 4, MPCF.Trim(out_node.GetString("CHG_STS_1")));
            spdEvent.Sheets[0].SetText(2, 4, MPCF.Trim(out_node.GetString("CHG_STS_2")));
            spdEvent.Sheets[0].SetText(3, 4, MPCF.Trim(out_node.GetString("CHG_STS_3")));
            spdEvent.Sheets[0].SetText(4, 4, MPCF.Trim(out_node.GetString("CHG_STS_4")));
            spdEvent.Sheets[0].SetText(5, 4, MPCF.Trim(out_node.GetString("CHG_STS_5")));
            spdEvent.Sheets[0].SetText(6, 4, MPCF.Trim(out_node.GetString("CHG_STS_6")));
            spdEvent.Sheets[0].SetText(7, 4, MPCF.Trim(out_node.GetString("CHG_STS_7")));
            spdEvent.Sheets[0].SetText(8, 4, MPCF.Trim(out_node.GetString("CHG_STS_8")));
            spdEvent.Sheets[0].SetText(9, 4, MPCF.Trim(out_node.GetString("CHG_STS_9")));
            spdEvent.Sheets[0].SetText(10, 4, MPCF.Trim(out_node.GetString("CHG_STS_10")));
            spdEvent.Sheets[0].SetValue(1, 5, MPCF.Trim(out_node.GetString("TBL_1")));
            spdEvent.Sheets[0].SetValue(2, 5, MPCF.Trim(out_node.GetString("TBL_2")));
            spdEvent.Sheets[0].SetValue(3, 5, MPCF.Trim(out_node.GetString("TBL_3")));
            spdEvent.Sheets[0].SetValue(4, 5, MPCF.Trim(out_node.GetString("TBL_4")));
            spdEvent.Sheets[0].SetValue(5, 5, MPCF.Trim(out_node.GetString("TBL_5")));
            spdEvent.Sheets[0].SetValue(6, 5, MPCF.Trim(out_node.GetString("TBL_6")));
            spdEvent.Sheets[0].SetValue(7, 5, MPCF.Trim(out_node.GetString("TBL_7")));
            spdEvent.Sheets[0].SetValue(8, 5, MPCF.Trim(out_node.GetString("TBL_8")));
            spdEvent.Sheets[0].SetValue(9, 5, MPCF.Trim(out_node.GetString("TBL_9")));
            spdEvent.Sheets[0].SetValue(10, 5, MPCF.Trim(out_node.GetString("TBL_10")));
            
            if (MPCF.Trim(out_node.GetChar("CHART_FLAG")) == "C")
            {
                cboChart.SelectedIndex = 1;
            }
            else if (MPCF.Trim(out_node.GetChar("CHART_FLAG")) == "S")
            {
                cboChart.SelectedIndex = 2;
            }
            else
            {
                cboChart.SelectedIndex = 0;
            }
            cdvChartID.Text = MPCF.Trim(out_node.GetString("CHART_ID"));
            cdvColSetID.Text = MPCF.Trim(out_node.GetString("COL_SET_ID"));
            
            txtCreateUser.Text = MPCF.Trim(out_node.GetString("CREATE_USER_ID"));
            txtUpdateUser.Text = MPCF.Trim(out_node.GetString("UPDATE_USER_ID"));
            txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
            txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
            
            for (i = 0; i <= 10; i++)
            {
                if (spdEvent.Sheets[0].Cells[i, 0].Text != "")
                {
                    spdEvent.Sheets[0].Cells[i, 3].Locked = false;
                }
                else
                {
                    spdEvent.Sheets[0].Cells[i, 3].Text = "";
                    spdEvent.Sheets[0].Cells[i, 3].Locked = true;
                }
                if (spdEvent.Sheets[0].Cells[i, 0].Text == "" || spdEvent.Sheets[0].Cells[i, 0].Text == NOT_CHECK)
                {
                    spdEvent.Sheets[0].Cells[i, 1].Locked = true;
                }
                else
                {
                    if (spdEvent.Sheets[0].Cells[i, 0].Text == TABLE)
                    {
                        spdEvent.Sheets[0].Cells[i, 2].Locked = false;
                        spdEvent.Sheets[0].Cells[i, 1].Locked = true;
                    }
                    else
                    {
                        spdEvent.Sheets[0].Cells[i, 2].Locked = true;
                        spdEvent.Sheets[0].Cells[i, 1].Locked = false;
                    }
                }
                spdEvent.Sheets[0].Cells[i, 5].Locked = true;
                spdEvent.Sheets[0].Cells[i, 6].Locked = true;
                if (spdEvent.Sheets[0].Cells[i, 3].Text == "" || spdEvent.Sheets[0].Cells[i, 3].Text == NOT_CHANGE || spdEvent.Sheets[0].Cells[i, 3].Text == TIME)
                {
                    spdEvent.Sheets[0].Cells[i, 4].Locked = true;
                }
                else
                {
                    if (spdEvent.Sheets[0].Cells[i, 3].Text == OVERRIDE)
                    {
                        spdEvent.Sheets[0].Cells[i, 5].Locked = false;
                        spdEvent.Sheets[0].Cells[i, 6].Locked = false;
                    }
                    spdEvent.Sheets[0].Cells[i, 4].Locked = false;
                }
            }
            return true;
            
        }
        
        //
        // MakeCheckFlag()
        //       -  Make CheckFlag to right format
        // Return Value
        //       - String
        // Arguments
        //       - ByVal s As String
        //
        private string MakeCheckFlag(string s)
        {
            string returnValue = string.Empty;
            if (s == "=")
            {
                returnValue = EQUAL;
                return returnValue;
            }
            else if (s == "!")
            {
                returnValue = NOT_EQUAL;
                return returnValue;
            }
            else if (s == "N")
            {
                returnValue = NOT_CHECK;
                return returnValue;
            }
            else if (s == ">")
            {
                returnValue = GREATER;
                return returnValue;
            }
            else if (s == "<")
            {
                returnValue = LESS;
                return returnValue;
            }
            else if (s == "T")
            {
                returnValue = TABLE;
                return returnValue;
            }
            return returnValue;
        }
        
        //
        // MakeChangeFlag()
        //       -  Make ChangeFlag to right format
        // Return Value
        //       - String
        // Arguments
        //       - ByVal s As String
        //
        private string MakeChangeFlag(string s)
        {
            string returnValue = string.Empty;
            if (s == "Y")
            {
                returnValue = CHANGE;
                return returnValue;
            }
            else if (s == "+")
            {
                returnValue = INCREASE;
                return returnValue;
            }
            else if (s == "-")
            {
                returnValue = DECREASE;
                return returnValue;
            }
            else if (s == "N")
            {
                returnValue = NOT_CHANGE;
                return returnValue;
            }
            else if (s == "O")
            {
                returnValue = OVERRIDE;
                return returnValue;
            }
            else if (s == "T")
            {
                returnValue = TIME;
                return returnValue;
            }
            return returnValue;
        }
        
        //
        // Refresh_Eventlist()
        //       -  Refresh Resource List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool Refresh_Eventlist()
        {
            
            return RASLIST.ViewEventList(lisEvent, '1', "", null, "");
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.lisEvent;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        private void frmRASSetupEvent_Activated(object sender, System.EventArgs e)
        {
            if (LoadFlag == false)
            {
                
                lblDataCount.Text = "";
                SetGroupCmfItem();
                
                if (cdvColSetID.DisplaySubItemIndex != cdvColSetID.SelectedSubItemIndex)
                {
                    cdvColSetID_ButtonPress(null, null);
                }
                if (cdvChartID.DisplaySubItemIndex != cdvChartID.SelectedSubItemIndex)
                {
                    cdvChartID_ButtonPress(null, null);
                }
                
                if (RASLIST.ViewEventList(lisEvent, '1', "", null, "") == true)
                {
                    lblDataCount.Text = MPCF.Trim(lisEvent.Items.Count);
                    if (lisEvent.Items.Count > 0)
                    {
                        lisEvent.Items[0].Selected = true;
                    }
                }
                
                LoadFlag = true;
            }
            
        }
        
        private void frmRASSetupEvent_Load(object sender, System.EventArgs e)
        {
            
            if (MPGV.gsSPCType == "2")
            {
//                this.grpChart.Visible = true;
//                this.grpEDC.Visible = false;
            }
            else
            {
                this.grpChart.Visible = false;
                this.grpEDC.Visible = true;
            }
            
            MPCF.InitListView(lisEvent);
            if (MPGV.gsFactory == MPGV.gsCentralFactory)
            {
                chkSystemFlag.Enabled = true;
            }
            else
            {
                chkSystemFlag.Enabled = false;
            }
            
        }
        
        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Event", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Event(MPGC.MP_STEP_CREATE) == false)
                    {
                        return;
                    }
                    btnRefresh.PerformClick();
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition("Update_Event", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Event(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (chkSystemFlag.Checked == true)
                {
                    return;
                }
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                if (CheckCondition("Update_Event", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Event(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    MPCF.FieldClear(this.pnlRight);
                    spdEvent.Sheets[0].ClearRange(0, 0, 11, 6, true);
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void txtEvent_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)58)
            {
                e.Handled = true;
            }
            
        }
        
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                lblDataCount.Text = "";
                if (Refresh_Eventlist() == false)
                {
                    return;
                }
                lblDataCount.Text = MPCF.Trim(lisEvent.Items.Count);
                if (lisEvent.Items.Count > 0)
                {
                    MPCF.FindListItem(lisEvent, txtEvent.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            
        }
        
        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.ExportToExcel(lisEvent, this.Text, "");
            
        }
        
        private void lisEvent_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MPCF.FieldClear(this.pnlRight);
            spdEvent.Sheets[0].ClearRange(0, 0, 11, 6, true);
            
            if (lisEvent.SelectedItems.Count > 0)
            {
                txtEvent.Text = lisEvent.SelectedItems[0].Text;
                View_Event('1');
            }
            
        }
        
        private void spdEvent_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            string TempStr;
            
            TempStr = spdEvent.Sheets[0].Cells[e.Row, e.Column].Text;
            //If TempStr.Trim <> "" And (e.Column = 0 Or e.Column = 2) Then
            //    spdEvent.Sheets(0).SetValue(e.Row, e.Column, TempStr.Chars(0))
            //End If
            
        }
        
        private void spdEvent_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            cdvTableList.Init();
            cdvTableList.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvTableList.GetListView);
            cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
            cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
            BASLIST.ViewGCMTableList(cdvTableList.GetListView, '1');
            if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
            {
                return;
            }
            
        }
        
        private void cdvTableList_SelectedItemChanged(object sender, Miracom.UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            
            spdEvent.Sheets[0].Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
            
        }
        
        private void cdvGrpCmf_ButtonPress(System.Object sender, System.EventArgs e)
        {
            
            MPCR.ProcGRPCMFButtonPress(sender);
            
        }
        
        private void cboCheckUpDownFlag_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            if (cboCheckUpDownFlag.SelectedIndex == 2)
            {
                cboCheckUpDown.Enabled = false;
                cboCheckUpDown.Text = "";
            }
            else
            {
                cboCheckUpDown.Enabled = true;
            }
            
        }
        
        private void cboChangeUpDownFlag_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            if (cboChangeUpDownFlag.SelectedIndex == 1)
            {
                cboChangeUpDown.Enabled = false;
                cboChangeUpDown.Text = "";
            }
            else
            {
                cboChangeUpDown.Enabled = true;
            }
            
        }
        
        private void spdEvent_ComboSelChange(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            
            if (e.Column == 0)
            {
                spdEvent.Sheets[0].Cells[e.Row, 1].Text = "";
                spdEvent.Sheets[0].Cells[e.Row, 4].Text = "";
                spdEvent.Sheets[0].Cells[e.Row, 5].Text = "";
                if (spdEvent.Sheets[0].Cells[e.Row, 0].Text == "" || spdEvent.Sheets[0].Cells[e.Row, 0].Text == NOT_CHECK)
                {
                    spdEvent.Sheets[0].Cells[e.Row, 1].Locked = true;
                }
                else
                {
                    if (spdEvent.Sheets[0].Cells[e.Row, 0].Text == TABLE)
                    {
                        spdEvent.Sheets[0].Cells[e.Row, 2].Locked = false;
                        spdEvent.Sheets[0].Cells[e.Row, 1].Locked = true;
                        spdEvent.Sheets[0].Cells[e.Row, 6].Locked = false;
                        spdEvent.Sheets[0].Cells[e.Row, 5].Locked = true;
                    }
                    else
                    {
                        spdEvent.Sheets[0].Cells[e.Row, 2].Locked = true;
                        spdEvent.Sheets[0].Cells[e.Row, 1].Locked = false;
                        spdEvent.Sheets[0].Cells[e.Row, 6].Locked = true;
                        spdEvent.Sheets[0].Cells[e.Row, 5].Locked = false;
                    }
                }
                if (spdEvent.Sheets[0].Cells[e.Row, 0].Text != "")
                {
                    spdEvent.Sheets[0].Cells[e.Row, 3].Locked = false;
                }
                else
                {
                    spdEvent.Sheets[0].Cells[e.Row, 3].Text = "";
                    spdEvent.Sheets[0].Cells[e.Row, 3].Locked = true;
                }
            }
            if (e.Column == 3)
            {
                spdEvent.Sheets[0].Cells[e.Row, 4].Text = "";
                spdEvent.Sheets[0].Cells[e.Row, 5].Text = "";
                if (spdEvent.Sheets[0].Cells[e.Row, 3].Text == "" || spdEvent.Sheets[0].Cells[e.Row, 3].Text == NOT_CHANGE || spdEvent.Sheets[0].Cells[e.Row, 3].Text == TIME)
                {
                    spdEvent.Sheets[0].Cells[e.Row, 4].Locked = true;
                    spdEvent.Sheets[0].Cells[e.Row, 5].Locked = true;
                    spdEvent.Sheets[0].Cells[e.Row, 6].Locked = true;
                }
                else
                {
                    spdEvent.Sheets[0].Cells[e.Row, 4].Locked = false;
                    if (spdEvent.Sheets[0].Cells[e.Row, 3].Text == OVERRIDE)
                    {
                        spdEvent.Sheets[0].Cells[e.Row, 5].Locked = false;
                        spdEvent.Sheets[0].Cells[e.Row, 6].Locked = false;
                    }
                    else
                    {
                        spdEvent.Sheets[0].Cells[e.Row, 5].Locked = true;
                        spdEvent.Sheets[0].Cells[e.Row, 6].Locked = true;
                    }
                }
            }
            
        }
        
        private void cdvColSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            cdvColSetID.Init();
            cdvColSetID.Columns.Add("Collection Set", 50, HorizontalAlignment.Left);
            cdvColSetID.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvColSetID.SelectedSubItemIndex = 0;
            #if _EDC
            if (EDCLIST.ViewEDCColSetList(cdvColSetID.GetListView, '3', null, "", -1, -1, 'R', false) == false)
            {
                return;
            }
            #endif
        }
        
        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemNextPartial(lisEvent, txtFind.Text, true, false);
            
        }
        
        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {

            MPCF.FindListItemPartial(lisEvent, txtFind.Text, 0, true, false);
            
        }
        
        private void txtEvent_LostFocus(object sender, System.EventArgs e)
        {
            if (MPGV.gsFactory != MPGV.gsCentralFactory)
            {
                if (lisEvent.SelectedItems.Count > 0)
                {
                    if (txtEvent.Text != "")
                    {
                        if (MPCF.Trim(lisEvent.SelectedItems[0].Text) != txtEvent.Text)
                        {
                            chkSystemFlag.Checked = false;
                        }
                    }
                }
                else if (txtEvent.Text != "")
                {
                    chkSystemFlag.Checked = false;
                }
            }
        }
        
        private void cdvChartID_ButtonPress(object sender, System.EventArgs e)
        {
            try
            {
                if (MPGV.gsSPCType != "2")
                {
                    return;
                }
////
//                if (cboChart.Text == "")
//                {
//                    return;
//                }
                
//                cdvChartID.Init();
//                modCommonFunction.InitListView(cdvChartID.GetListView);
//                cdvChartID.SelectedSubItemIndex = 0;
//                cdvChartID.SmallImageList = modGlobalVariable.gimlSmallIcon;
//                cdvChartID.Columns.Add("Chart", 50, HorizontalAlignment.Left);
//                if (cboChart.Text == "Chart")
//                {
//                    cdvChartID.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
//                    cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
//                    #if _SPC
//                    if (modSPCListRoutine.ViewChartList(cdvChartID.GetListView, '2', "", "", "", "", "R", "", "", "", -1, -1, null, "") == false)
//                    {
//                        return;
//                    }
//                    #endif
//                }
//                else if (cboChart.Text == "Chart Set")
//                {
//                    cdvChartID.Columns.Add("Desc", 100, HorizontalAlignment.Left);
//                    #if _SPC
//                    if (modSPCListRoutine.ViewChartSetList(cdvChartID.GetListView, '1', "", "", "", "R", "", -1, -1, "") == false)
//                    {
//                        return;
//                    }
//                    #endif
//                }
//                cdvChartID.AddEmptyRow(1);
////
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
        private void cboChart_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                cdvChartID.Text = "";
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
    }
    
}
