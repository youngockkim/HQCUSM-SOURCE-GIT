using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using FarPoint.Win.Spread;
using System.Globalization;
using System.Drawing;
using System.IO;
using System.Text;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;


//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupGeneralCodeData.vb
//   Description : General Code Data Transaction Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the conditions before transaction
//       - Update_Data_List() : Create/Update/Delete General code list
//       - View_Data_List() :View General code list which is included in one general code table
//       - Make_Column_Header() : Find Table definition and design general code data sheet
//       - View_Table_List() : View all table list which is included in one factory
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2004-06-07 : Created by SKJIN
//
//
//   Copyright(C) 1998-2005 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

//Imports

namespace Miracom.BASCore
{
    public class frmBASSetupGeneralCodeData : Miracom.MESCore.SetupForm02
    {

        #region " Windows Form auto generated code "

        public frmBASSetupGeneralCodeData()
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
        private Miracom.UI.Controls.MCListView.MCListView lisTable;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.Panel pnlDataListFill;
        private GroupBox grpTblGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup;
        private Label lblGroup;
        protected Button btnTblExcel;
        private TabControl tabCtrl;
        private TabPage tabData;
        private TabPage tabExport;
        private Panel pnlDataListBottom;
        private GroupBox grbTable;
        private Button btnSelect;
        private TextBox txtPwd;
        private Label lblPwd;
        private FpSpread spdData;
        private SheetView spdData_Sheet1;
        private Panel pnlSql;
        private Splitter splSQL;
        private FpSpread spdQuery;
        private SheetView spdQuery_Sheet1;
        private RichTextBox txtQuery;
        private Panel pnlSQLTest;
        private Button btnSQLTest;
        private SaveFileDialog sfdFile;
        private GroupBox grpExport;
        private TextBox txtExpFile;
        private Button btnExpFile;
        private Label lblExpFile;
        private Button btnExpCopy;
        private TextBox txtExpTable;
        private Label lblExpTable;
        private Button btnExpStop;
        private Button btnExport;
        private GroupBox grbExportCenter;
        private RichTextBox txtExport;
        private ProgressBar progressBarExport;
        private CheckBox chkMigration;
        private Panel pnlDataFilter;
        private TextBox txtFilterKey2;
        private Label lblKey2;
        private TextBox txtFilterKey1;
        private Label lblKey1;
        private Button btnView;
        private Button btnHistory;
        private UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer3 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer4 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBASSetupGeneralCodeData));
            this.lisTable = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlDataListFill = new System.Windows.Forms.Panel();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabData = new System.Windows.Forms.TabPage();
            this.pnlSql = new System.Windows.Forms.Panel();
            this.spdQuery = new FarPoint.Win.Spread.FpSpread();
            this.spdQuery_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.pnlSQLTest = new System.Windows.Forms.Panel();
            this.btnSQLTest = new System.Windows.Forms.Button();
            this.splSQL = new System.Windows.Forms.Splitter();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.pnlDataListBottom = new System.Windows.Forms.Panel();
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.grbExportCenter = new System.Windows.Forms.GroupBox();
            this.txtExport = new System.Windows.Forms.RichTextBox();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.chkMigration = new System.Windows.Forms.CheckBox();
            this.txtExpFile = new System.Windows.Forms.TextBox();
            this.btnExpFile = new System.Windows.Forms.Button();
            this.lblExpFile = new System.Windows.Forms.Label();
            this.btnExpCopy = new System.Windows.Forms.Button();
            this.txtExpTable = new System.Windows.Forms.TextBox();
            this.lblExpTable = new System.Windows.Forms.Label();
            this.btnExpStop = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.grpTblGroup = new System.Windows.Forms.GroupBox();
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup = new System.Windows.Forms.Label();
            this.btnTblExcel = new System.Windows.Forms.Button();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.pnlDataFilter = new System.Windows.Forms.Panel();
            this.txtFilterKey2 = new System.Windows.Forms.TextBox();
            this.lblKey2 = new System.Windows.Forms.Label();
            this.txtFilterKey1 = new System.Windows.Forms.TextBox();
            this.lblKey1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlDataListFill.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabData.SuspendLayout();
            this.pnlSql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery_Sheet1)).BeginInit();
            this.pnlSQLTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.pnlDataListBottom.SuspendLayout();
            this.grbTable.SuspendLayout();
            this.tabExport.SuspendLayout();
            this.grbExportCenter.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.grpTblGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            this.pnlDataFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFind
            // 
            this.pnlFind.TabIndex = 4;
            // 
            // lblDataCount
            // 
            this.lblDataCount.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNext
            // 
            this.btnNext.TabIndex = 2;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtFind
            // 
            this.txtFind.TabIndex = 1;
            this.txtFind.TextChanged += new System.EventHandler(this.txtFind_TextChanged);
            // 
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            this.splMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.pnlDataFilter);
            this.pnlRight.Controls.Add(this.pnlDataListFill);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisTable);
            this.pnlLeft.Controls.Add(this.grpTblGroup);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnHistory);
            this.pnlBottom.Controls.Add(this.btnView);
            this.pnlBottom.Controls.Add(this.btnTblExcel);
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnTblExcel, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnView, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnHistory, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "General Code Data Setup";
            // 
            // lisTable
            // 
            this.lisTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisTable.EnableSort = true;
            this.lisTable.EnableSortIcon = true;
            this.lisTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisTable.FullRowSelect = true;
            this.lisTable.HideSelection = false;
            this.lisTable.Location = new System.Drawing.Point(3, 39);
            this.lisTable.MultiSelect = false;
            this.lisTable.Name = "lisTable";
            this.lisTable.Size = new System.Drawing.Size(229, 471);
            this.lisTable.TabIndex = 0;
            this.lisTable.UseCompatibleStateImageBehavior = false;
            this.lisTable.View = System.Windows.Forms.View.Details;
            this.lisTable.SelectedIndexChanged += new System.EventHandler(this.lisTable_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Table Name";
            this.ColumnHeader1.Width = 120;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 240;
            // 
            // pnlDataListFill
            // 
            this.pnlDataListFill.Controls.Add(this.tabCtrl);
            this.pnlDataListFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataListFill.Location = new System.Drawing.Point(3, 3);
            this.pnlDataListFill.Name = "pnlDataListFill";
            this.pnlDataListFill.Size = new System.Drawing.Size(500, 507);
            this.pnlDataListFill.TabIndex = 0;
            // 
            // tabCtrl
            // 
            this.tabCtrl.Controls.Add(this.tabData);
            this.tabCtrl.Controls.Add(this.tabExport);
            this.tabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(500, 507);
            this.tabCtrl.TabIndex = 0;
            // 
            // tabData
            // 
            this.tabData.BackColor = System.Drawing.SystemColors.Control;
            this.tabData.Controls.Add(this.pnlSql);
            this.tabData.Controls.Add(this.spdData);
            this.tabData.Controls.Add(this.pnlDataListBottom);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(492, 481);
            this.tabData.TabIndex = 0;
            this.tabData.Text = "Data";
            // 
            // pnlSql
            // 
            this.pnlSql.Controls.Add(this.spdQuery);
            this.pnlSql.Controls.Add(this.txtQuery);
            this.pnlSql.Controls.Add(this.pnlSQLTest);
            this.pnlSql.Controls.Add(this.splSQL);
            this.pnlSql.Location = new System.Drawing.Point(157, 215);
            this.pnlSql.Name = "pnlSql";
            this.pnlSql.Size = new System.Drawing.Size(311, 194);
            this.pnlSql.TabIndex = 6;
            this.pnlSql.Visible = false;
            // 
            // spdQuery
            // 
            this.spdQuery.AccessibleDescription = "spdQuery, Sheet1";
            this.spdQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdQuery.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdQuery.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQuery.HorizontalScrollBar.Name = "";
            this.spdQuery.HorizontalScrollBar.Renderer = defaultScrollBarRenderer3;
            this.spdQuery.HorizontalScrollBar.TabIndex = 0;
            this.spdQuery.Location = new System.Drawing.Point(0, 62);
            this.spdQuery.Name = "spdQuery";
            this.spdQuery.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdQuery.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdQuery.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdQuery_Sheet1});
            this.spdQuery.Size = new System.Drawing.Size(311, 98);
            this.spdQuery.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdQuery.TabIndex = 2;
            this.spdQuery.TextTipDelay = 200;
            this.spdQuery.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdQuery.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdQuery.VerticalScrollBar.Name = "";
            this.spdQuery.VerticalScrollBar.Renderer = defaultScrollBarRenderer4;
            this.spdQuery.VerticalScrollBar.TabIndex = 1;
            this.spdQuery.SetActiveViewport(0, -1, -1);
            // 
            // spdQuery_Sheet1
            // 
            this.spdQuery_Sheet1.Reset();
            spdQuery_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdQuery_Sheet1.ColumnCount = 0;
            spdQuery_Sheet1.RowCount = 0;
            this.spdQuery_Sheet1.ActiveColumnIndex = -1;
            this.spdQuery_Sheet1.ActiveRowIndex = -1;
            this.spdQuery_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdQuery_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdQuery_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdQuery_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdQuery_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdQuery_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdQuery_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdQuery_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtQuery.Location = new System.Drawing.Point(0, 3);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ReadOnly = true;
            this.txtQuery.Size = new System.Drawing.Size(311, 59);
            this.txtQuery.TabIndex = 1;
            this.txtQuery.Text = "";
            // 
            // pnlSQLTest
            // 
            this.pnlSQLTest.Controls.Add(this.btnSQLTest);
            this.pnlSQLTest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSQLTest.Location = new System.Drawing.Point(0, 160);
            this.pnlSQLTest.Name = "pnlSQLTest";
            this.pnlSQLTest.Size = new System.Drawing.Size(311, 34);
            this.pnlSQLTest.TabIndex = 3;
            // 
            // btnSQLTest
            // 
            this.btnSQLTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSQLTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSQLTest.Location = new System.Drawing.Point(217, 4);
            this.btnSQLTest.Name = "btnSQLTest";
            this.btnSQLTest.Size = new System.Drawing.Size(88, 26);
            this.btnSQLTest.TabIndex = 1;
            this.btnSQLTest.Text = "SQL Test";
            this.btnSQLTest.Click += new System.EventHandler(this.btnSQLTest_Click);
            // 
            // splSQL
            // 
            this.splSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.splSQL.Location = new System.Drawing.Point(0, 0);
            this.splSQL.Name = "splSQL";
            this.splSQL.Size = new System.Drawing.Size(311, 3);
            this.splSQL.TabIndex = 0;
            this.splSQL.TabStop = false;
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "";
            this.spdData.AllowDragFill = true;
            this.spdData.ClipboardOptions = FarPoint.Win.Spread.ClipboardOptions.NoHeaders;
            this.spdData.ClipboardPasteToFill = true;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdData.HorizontalScrollBar.TabIndex = 4;
            this.spdData.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.Location = new System.Drawing.Point(3, 3);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(486, 427);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 0;
            this.spdData.TextTipDelay = 200;
            this.spdData.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdData.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.VerticalScrollBar.Name = "";
            this.spdData.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdData.VerticalScrollBar.TabIndex = 5;
            this.spdData.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdData.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdData.ClipboardChanged += new System.EventHandler(this.spdData_ClipboardChanged);
            this.spdData.EditModeOff += new System.EventHandler(this.spdData_EditModeOff);
            this.spdData.ClipboardPasting += new FarPoint.Win.Spread.ClipboardPastingEventHandler(this.fpSpread_ClipboardPasting);
            this.spdData.EnterCell += new FarPoint.Win.Spread.EnterCellEventHandler(this.spdData_EnterCell);
            this.spdData.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdData_ButtonClicked);
            this.spdData.ClipboardChanging += new System.EventHandler(this.spdData_ClipboardChanging);
            this.spdData.AutoFilteredColumn += new FarPoint.Win.Spread.AutoFilteredColumnEventHandler(this.spdData_AutoFilteredColumn);
            this.spdData.SetActiveViewport(0, -1, -1);
            // 
            // spdData_Sheet1
            // 
            this.spdData_Sheet1.Reset();
            spdData_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdData_Sheet1.ColumnCount = 0;
            spdData_Sheet1.RowCount = 0;
            this.spdData_Sheet1.ActiveColumnIndex = -1;
            this.spdData_Sheet1.ActiveRowIndex = -1;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdData_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdData_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdData_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdData_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdData_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdData_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // pnlDataListBottom
            // 
            this.pnlDataListBottom.Controls.Add(this.grbTable);
            this.pnlDataListBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDataListBottom.Location = new System.Drawing.Point(3, 430);
            this.pnlDataListBottom.Name = "pnlDataListBottom";
            this.pnlDataListBottom.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pnlDataListBottom.Size = new System.Drawing.Size(486, 48);
            this.pnlDataListBottom.TabIndex = 4;
            // 
            // grbTable
            // 
            this.grbTable.Controls.Add(this.btnSelect);
            this.grbTable.Controls.Add(this.txtPwd);
            this.grbTable.Controls.Add(this.lblPwd);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Location = new System.Drawing.Point(0, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(483, 48);
            this.grbTable.TabIndex = 2;
            this.grbTable.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelect.Location = new System.Drawing.Point(10, 14);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 26);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select All Rows";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPwd.Location = new System.Drawing.Point(302, 16);
            this.txtPwd.MaxLength = 20;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(177, 20);
            this.txtPwd.TabIndex = 2;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPwd.Location = new System.Drawing.Point(190, 19);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 13);
            this.lblPwd.TabIndex = 1;
            this.lblPwd.Text = "Password";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabExport
            // 
            this.tabExport.BackColor = System.Drawing.SystemColors.Control;
            this.tabExport.Controls.Add(this.grbExportCenter);
            this.tabExport.Controls.Add(this.grpExport);
            this.tabExport.Location = new System.Drawing.Point(4, 22);
            this.tabExport.Name = "tabExport";
            this.tabExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExport.Size = new System.Drawing.Size(492, 481);
            this.tabExport.TabIndex = 1;
            this.tabExport.Text = "Export";
            // 
            // grbExportCenter
            // 
            this.grbExportCenter.Controls.Add(this.txtExport);
            this.grbExportCenter.Controls.Add(this.progressBarExport);
            this.grbExportCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbExportCenter.Location = new System.Drawing.Point(3, 103);
            this.grbExportCenter.Name = "grbExportCenter";
            this.grbExportCenter.Size = new System.Drawing.Size(486, 375);
            this.grbExportCenter.TabIndex = 7;
            this.grbExportCenter.TabStop = false;
            // 
            // txtExport
            // 
            this.txtExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExport.Location = new System.Drawing.Point(3, 16);
            this.txtExport.Name = "txtExport";
            this.txtExport.ReadOnly = true;
            this.txtExport.Size = new System.Drawing.Size(480, 333);
            this.txtExport.TabIndex = 9;
            this.txtExport.Text = "";
            this.txtExport.WordWrap = false;
            // 
            // progressBarExport
            // 
            this.progressBarExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarExport.Location = new System.Drawing.Point(3, 349);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(480, 23);
            this.progressBarExport.TabIndex = 10;
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.chkMigration);
            this.grpExport.Controls.Add(this.txtExpFile);
            this.grpExport.Controls.Add(this.btnExpFile);
            this.grpExport.Controls.Add(this.lblExpFile);
            this.grpExport.Controls.Add(this.btnExpCopy);
            this.grpExport.Controls.Add(this.txtExpTable);
            this.grpExport.Controls.Add(this.lblExpTable);
            this.grpExport.Controls.Add(this.btnExpStop);
            this.grpExport.Controls.Add(this.btnExport);
            this.grpExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpExport.Location = new System.Drawing.Point(3, 3);
            this.grpExport.Name = "grpExport";
            this.grpExport.Size = new System.Drawing.Size(486, 100);
            this.grpExport.TabIndex = 6;
            this.grpExport.TabStop = false;
            this.grpExport.Text = "DB Insert Script Create";
            // 
            // chkMigration
            // 
            this.chkMigration.AutoSize = true;
            this.chkMigration.Location = new System.Drawing.Point(288, 19);
            this.chkMigration.Name = "chkMigration";
            this.chkMigration.Size = new System.Drawing.Size(99, 17);
            this.chkMigration.TabIndex = 2;
            this.chkMigration.Text = "Migration Script";
            this.chkMigration.UseVisualStyleBackColor = true;
            // 
            // txtExpFile
            // 
            this.txtExpFile.Location = new System.Drawing.Point(113, 41);
            this.txtExpFile.MaxLength = 1000;
            this.txtExpFile.Name = "txtExpFile";
            this.txtExpFile.ReadOnly = true;
            this.txtExpFile.Size = new System.Drawing.Size(343, 20);
            this.txtExpFile.TabIndex = 4;
            // 
            // btnExpFile
            // 
            this.btnExpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpFile.Location = new System.Drawing.Point(456, 40);
            this.btnExpFile.Name = "btnExpFile";
            this.btnExpFile.Size = new System.Drawing.Size(21, 21);
            this.btnExpFile.TabIndex = 5;
            this.btnExpFile.Text = "...";
            this.btnExpFile.Click += new System.EventHandler(this.btnExpFile_Click);
            // 
            // lblExpFile
            // 
            this.lblExpFile.AutoSize = true;
            this.lblExpFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpFile.Location = new System.Drawing.Point(15, 45);
            this.lblExpFile.Name = "lblExpFile";
            this.lblExpFile.Size = new System.Drawing.Size(56, 13);
            this.lblExpFile.TabIndex = 3;
            this.lblExpFile.Text = "Export File";
            // 
            // btnExpCopy
            // 
            this.btnExpCopy.Location = new System.Drawing.Point(287, 68);
            this.btnExpCopy.Name = "btnExpCopy";
            this.btnExpCopy.Size = new System.Drawing.Size(75, 23);
            this.btnExpCopy.TabIndex = 8;
            this.btnExpCopy.Text = "Clip Copy";
            this.btnExpCopy.Click += new System.EventHandler(this.btnExpCopy_Click);
            // 
            // txtExpTable
            // 
            this.txtExpTable.Location = new System.Drawing.Point(113, 17);
            this.txtExpTable.MaxLength = 1000;
            this.txtExpTable.Name = "txtExpTable";
            this.txtExpTable.Size = new System.Drawing.Size(150, 20);
            this.txtExpTable.TabIndex = 1;
            // 
            // lblExpTable
            // 
            this.lblExpTable.AutoSize = true;
            this.lblExpTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblExpTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpTable.Location = new System.Drawing.Point(16, 21);
            this.lblExpTable.Name = "lblExpTable";
            this.lblExpTable.Size = new System.Drawing.Size(65, 13);
            this.lblExpTable.TabIndex = 0;
            this.lblExpTable.Text = "Table Name";
            // 
            // btnExpStop
            // 
            this.btnExpStop.Location = new System.Drawing.Point(200, 68);
            this.btnExpStop.Name = "btnExpStop";
            this.btnExpStop.Size = new System.Drawing.Size(75, 23);
            this.btnExpStop.TabIndex = 7;
            this.btnExpStop.Text = "Stop";
            this.btnExpStop.Click += new System.EventHandler(this.btnExpStop_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(113, 68);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grpTblGroup
            // 
            this.grpTblGroup.Controls.Add(this.cdvGroup);
            this.grpTblGroup.Controls.Add(this.lblGroup);
            this.grpTblGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTblGroup.Location = new System.Drawing.Point(3, 3);
            this.grpTblGroup.Name = "grpTblGroup";
            this.grpTblGroup.Size = new System.Drawing.Size(229, 36);
            this.grpTblGroup.TabIndex = 0;
            this.grpTblGroup.TabStop = false;
            // 
            // cdvGroup
            // 
            this.cdvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cdvGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup.BtnToolTipText = "";
            this.cdvGroup.ButtonWidth = 20;
            this.cdvGroup.DescText = "";
            this.cdvGroup.DisplaySubItemIndex = -1;
            this.cdvGroup.DisplayText = "";
            this.cdvGroup.Focusing = null;
            this.cdvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup.Index = 0;
            this.cdvGroup.IsViewBtnImage = false;
            this.cdvGroup.Location = new System.Drawing.Point(83, 11);
            this.cdvGroup.MaxLength = 20;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MultiSelect = false;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = false;
            this.cdvGroup.SameWidthHeightOfButton = false;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedDescToQueryText = "";
            this.cdvGroup.SelectedSubItemIndex = -1;
            this.cdvGroup.SelectedValueToQueryText = "";
            this.cdvGroup.SelectionStart = 0;
            this.cdvGroup.Size = new System.Drawing.Size(142, 20);
            this.cdvGroup.SmallImageList = null;
            this.cdvGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup.TabIndex = 0;
            this.cdvGroup.TextBoxToolTipText = "";
            this.cdvGroup.TextBoxWidth = 142;
            this.cdvGroup.VisibleButton = true;
            this.cdvGroup.VisibleColumnHeader = false;
            this.cdvGroup.VisibleDescription = false;
            this.cdvGroup.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvGroup_SelectedItemChanged);
            this.cdvGroup.ButtonPress += new System.EventHandler(this.cdvGroup_ButtonPress);
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblGroup.Location = new System.Drawing.Point(6, 13);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(66, 13);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Table Group";
            this.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTblExcel
            // 
            this.btnTblExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTblExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnTblExcel.Image")));
            this.btnTblExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTblExcel.Location = new System.Drawing.Point(243, 8);
            this.btnTblExcel.Name = "btnTblExcel";
            this.btnTblExcel.Size = new System.Drawing.Size(24, 24);
            this.btnTblExcel.TabIndex = 6;
            this.btnTblExcel.Click += new System.EventHandler(this.btnTblExcel_Click);
            // 
            // cdvDataList
            // 
            this.cdvDataList.BackColor = System.Drawing.SystemColors.Control;
            this.cdvDataList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvDataList.Location = new System.Drawing.Point(0, 0);
            this.cdvDataList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvDataList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvDataList.Name = "MCSPCodeView";
            this.cdvDataList.Size = new System.Drawing.Size(20, 20);
            this.cdvDataList.SmallImageList = null;
            this.cdvDataList.TabIndex = 0;
            this.cdvDataList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvDataList.VisibleColumnHeader = false;
            this.cdvDataList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvDataList_SelectedItemChanged);
            // 
            // pnlDataFilter
            // 
            this.pnlDataFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataFilter.Controls.Add(this.txtFilterKey2);
            this.pnlDataFilter.Controls.Add(this.lblKey2);
            this.pnlDataFilter.Controls.Add(this.txtFilterKey1);
            this.pnlDataFilter.Controls.Add(this.lblKey1);
            this.pnlDataFilter.Location = new System.Drawing.Point(115, 2);
            this.pnlDataFilter.Name = "pnlDataFilter";
            this.pnlDataFilter.Size = new System.Drawing.Size(388, 20);
            this.pnlDataFilter.TabIndex = 1;
            this.pnlDataFilter.Visible = false;
            // 
            // txtFilterKey2
            // 
            this.txtFilterKey2.Location = new System.Drawing.Point(284, 0);
            this.txtFilterKey2.Name = "txtFilterKey2";
            this.txtFilterKey2.Size = new System.Drawing.Size(100, 20);
            this.txtFilterKey2.TabIndex = 3;
            this.txtFilterKey2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterKey_KeyPress);
            // 
            // lblKey2
            // 
            this.lblKey2.AutoSize = true;
            this.lblKey2.Location = new System.Drawing.Point(204, 4);
            this.lblKey2.Name = "lblKey2";
            this.lblKey2.Size = new System.Drawing.Size(31, 13);
            this.lblKey2.TabIndex = 2;
            this.lblKey2.Text = "Key2";
            // 
            // txtFilterKey1
            // 
            this.txtFilterKey1.Location = new System.Drawing.Point(84, 0);
            this.txtFilterKey1.Name = "txtFilterKey1";
            this.txtFilterKey1.Size = new System.Drawing.Size(100, 20);
            this.txtFilterKey1.TabIndex = 1;
            this.txtFilterKey1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterKey_KeyPress);
            // 
            // lblKey1
            // 
            this.lblKey1.AutoSize = true;
            this.lblKey1.Location = new System.Drawing.Point(4, 4);
            this.lblKey1.Name = "lblKey1";
            this.lblKey1.Size = new System.Drawing.Size(31, 13);
            this.lblKey1.TabIndex = 0;
            this.lblKey1.Text = "Key1";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(273, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(88, 26);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(376, 7);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(88, 26);
            this.btnHistory.TabIndex = 6;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // frmBASSetupGeneralCodeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASSetupGeneralCodeData";
            this.Text = "General Code Data Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupGeneralCodeData_Activated);
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
            this.pnlDataListFill.ResumeLayout(false);
            this.tabCtrl.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.pnlSql.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdQuery_Sheet1)).EndInit();
            this.pnlSQLTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.pnlDataListBottom.ResumeLayout(false);
            this.grbTable.ResumeLayout(false);
            this.grbTable.PerformLayout();
            this.tabExport.ResumeLayout(false);
            this.grbExportCenter.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.grpTblGroup.ResumeLayout(false);
            this.grpTblGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            this.pnlDataFilter.ResumeLayout(false);
            this.pnlDataFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        private const int CHECK_COL = 0;
        private const int KEY_1_COL = 1;
        private const int KEY_1_BTN = 2;
        private const int KEY_2_COL = 3;
        private const int KEY_2_BTN = 4;
        private const int KEY_3_COL = 5;
        private const int KEY_3_BTN = 6;
        private const int KEY_4_COL = 7;
        private const int KEY_4_BTN = 8;
        private const int KEY_5_COL = 9;
        private const int KEY_5_BTN = 10;
        private const int KEY_6_COL = 11;
        private const int KEY_6_BTN = 12;
        private const int KEY_7_COL = 13;
        private const int KEY_7_BTN = 14;
        private const int KEY_8_COL = 15;
        private const int KEY_8_BTN = 16;
        private const int KEY_9_COL = 17;
        private const int KEY_9_BTN = 18;
        private const int KEY_10_COL = 19;
        private const int KEY_10_BTN = 20;
        private const int DATA_1_COL = 21;
        private const int DATA_1_BTN = 22;
        private const int DATA_2_COL = 23;
        private const int DATA_2_BTN = 24;
        private const int DATA_3_COL = 25;
        private const int DATA_3_BTN = 26;
        private const int DATA_4_COL = 27;
        private const int DATA_4_BTN = 28;
        private const int DATA_5_COL = 29;
        private const int DATA_5_BTN = 30;
        private const int DATA_6_COL = 31;
        private const int DATA_6_BTN = 32;
        private const int DATA_7_COL = 33;
        private const int DATA_7_BTN = 34;
        private const int DATA_8_COL = 35;
        private const int DATA_8_BTN = 36;
        private const int DATA_9_COL = 37;
        private const int DATA_9_BTN = 38;
        private const int DATA_10_COL = 39;
        private const int DATA_10_BTN = 40;

        private const string COLUMN_DATA = "DATA";
        private const string COLUMN_KEY = "KEY";
        /*** End of Modification (2012.04.04) ***/

        private const int MAX_DATA_COUNT = 1000;

        private const string GCM_TBL_DAT = "MGCMTBLDAT";
        private const string GCM_TBL_LAG = "MGCMLAGDAT";

        #endregion

        #region " Variable Definition "

        private struct Format
        {
            public string Col_Fmt;
            public int Col_Size;
        };
        private bool b_export_stop = false;

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        private Format[] FormatTbl = new Format[41];

        private bool b_load_flag;
        private int i_last_filtered_column;
        private string s_last_filtered_string;

        private float[] d_prev_col_size = new float[40];

        private int i_last_selected_idx;
        private int i_last_selected_desc_idx;
        /*** End of Modification (2012.04.04) ***/
        private bool b_reload_data_flag;
        private TRSNode TABLE;

        #endregion

        #region " Function Definition "

        //
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {
            int i = 0;
            int j = 0;
            int iChkCnt = 0;

            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "Update_Data_List":


                        for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                        {
                            if (spdData.ActiveSheet.Cells[i, CHECK_COL].Value != null)
                            {
                                if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, CHECK_COL].Value) == true)
                                {

                                    iChkCnt++;

                                    if (MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                        spdData.ActiveSheet.SetActiveCell(i, KEY_1_COL);
                                        spdData.Select();
                                        return false;
                                    }

                                    for (j = i + 1; j < spdData.ActiveSheet.RowCount; j++)
                                    {
                                        if (spdData.ActiveSheet.Cells[j, CHECK_COL].Value != null)
                                        {
                                            if (Convert.ToBoolean(spdData.ActiveSheet.Cells[j, CHECK_COL].Value) == true)
                                            {
                                                if (spdData.ActiveSheet.Cells[i, KEY_1_COL].Value == spdData.ActiveSheet.Cells[j, KEY_1_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_2_COL].Value == spdData.ActiveSheet.Cells[j, KEY_2_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_3_COL].Value == spdData.ActiveSheet.Cells[j, KEY_3_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_4_COL].Value == spdData.ActiveSheet.Cells[j, KEY_4_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_5_COL].Value == spdData.ActiveSheet.Cells[j, KEY_5_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_6_COL].Value == spdData.ActiveSheet.Cells[j, KEY_6_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_7_COL].Value == spdData.ActiveSheet.Cells[j, KEY_7_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_8_COL].Value == spdData.ActiveSheet.Cells[j, KEY_8_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_9_COL].Value == spdData.ActiveSheet.Cells[j, KEY_9_COL].Value &&
                                                    spdData.ActiveSheet.Cells[i, KEY_10_COL].Value == spdData.ActiveSheet.Cells[j, KEY_10_COL].Value)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(111));
                                                    spdData.ActiveSheet.SetActiveCell(i, KEY_1_COL);
                                                    spdData.Select();
                                                    return false;
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }

                        if (iChkCnt == 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(133));
                            spdData.Select();
                            return false;
                        }
                        else if (iChkCnt > MAX_DATA_COUNT)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(134));
                            spdData.Select();
                            return false;
                        }

                        switch (MPCF.ToChar(MPCF.Trim(ProcStep)))
                        {
                            case MPGC.MP_STEP_UPDATE:

                                break;

                            case MPGC.MP_STEP_DELETE:

                                break;

                        }
                        break;
                    case "VIEW_TABLE":

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

        //
        // Make_Column_Header()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool MakeColumnHeader()
        {
            FarPoint.Win.Spread.CellType.TextCellType text_type;
            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            FarPoint.Win.Spread.CellType.ButtonCellType button_type;
            /*** End of Add (2012.04.04) ***/
            int i;

            try
            {
                if (TABLE.GetString("TABLE_PASSWORD") == "")
                {
                    txtPwd.Enabled = false;
                }
                else
                {
                    txtPwd.Enabled = true;
                }

                /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                if (spdData.ActiveSheet.Columns.Count > 0)
                {
                    spdData.ActiveSheet.Columns.Add(0, 1);
                }
                else
                {
                    spdData.ActiveSheet.ColumnCount = 41;
                }

                for (i = 1; i <= 40; i++)
                {
                    //spdData.ActiveSheet.ColumnHeader.Columns[i].Visible = false;
                    spdData.ActiveSheet.ColumnHeader.Columns[i].Width = 0;
                    spdData.ActiveSheet.ColumnHeader.Columns[i].Resizable = false;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, i].Value = "";

                    FormatTbl[i].Col_Fmt = "";
                    FormatTbl[i].Col_Size = 0;
                }

                                
                spdData.ActiveSheet.ColumnHeader.Cells[0, 0].Value = "Sel";
                spdData.ActiveSheet.Columns.Get(0).CellType = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
                spdData.ActiveSheet.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
                spdData.ActiveSheet.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
                spdData.ActiveSheet.Columns.Get(0).Width = 30;


                if (TABLE.GetString("KEY_1_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 100;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Value = " " + TABLE.GetString("KEY_1_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_COL].Visible = true;

                    spdData.ActiveSheet.Columns[KEY_1_COL].Locked = true;
                    spdData.ActiveSheet.Columns[KEY_1_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[KEY_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[KEY_1_COL].CellType = text_type;

                    FormatTbl[KEY_1_COL].Col_Fmt = TABLE.GetChar("KEY_1_FMT").ToString();
                    FormatTbl[KEY_1_COL].Col_Size = TABLE.GetInt("KEY_1_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].Tag = COLUMN_KEY;
                    if (TABLE.GetString("KEY_1_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[KEY_1_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_1_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[KEY_1_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_1_TBL"), TABLE.GetString("KEY_1_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_1_COL].ColumnSpan = 2;
                        spdData.ActiveSheet.Columns[KEY_1_BTN].Locked = true;
                    }
                }

                if (TABLE.GetString("KEY_2_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 100;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Value = " " + TABLE.GetString("KEY_2_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_COL].Visible = true;

                    spdData.ActiveSheet.Columns[KEY_2_COL].Locked = true;
                    spdData.ActiveSheet.Columns[KEY_2_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[KEY_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[KEY_2_COL].CellType = text_type;

                    FormatTbl[KEY_2_COL].Col_Fmt = TABLE.GetChar("KEY_2_FMT").ToString();
                    FormatTbl[KEY_2_COL].Col_Size = TABLE.GetInt("KEY_2_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].Tag = COLUMN_KEY;
                    if (TABLE.GetString("KEY_2_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[KEY_2_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_2_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[KEY_2_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_2_TBL"), TABLE.GetString("KEY_2_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_2_COL].ColumnSpan = 2;
                        spdData.ActiveSheet.Columns[KEY_2_BTN].Locked = true;
                    }
                }
                
                if (TABLE.GetChar("TABLE_TYPE") == 'E' || TABLE.GetChar("TABLE_TYPE") == 'L')
                {
                    if (TABLE.GetString("KEY_3_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].Value = " " + TABLE.GetString("KEY_3_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_3_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_3_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_3_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_3_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_3_COL].CellType = text_type;

                        FormatTbl[KEY_3_COL].Col_Fmt = TABLE.GetChar("KEY_3_FMT").ToString();
                        FormatTbl[KEY_3_COL].Col_Size = TABLE.GetInt("KEY_3_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_3_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_3_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_3_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_3_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_3_TBL"), TABLE.GetString("KEY_3_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_3_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_3_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_4_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].Value = " " + TABLE.GetString("KEY_4_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_4_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_4_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_4_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_4_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_4_COL].CellType = text_type;

                        FormatTbl[KEY_4_COL].Col_Fmt = TABLE.GetChar("KEY_4_FMT").ToString();
                        FormatTbl[KEY_4_COL].Col_Size = TABLE.GetInt("KEY_4_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_4_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_4_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_4_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_4_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_4_TBL"), TABLE.GetString("KEY_4_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_4_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_4_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_5_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].Value = " " + TABLE.GetString("KEY_5_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_5_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_5_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_5_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_5_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_5_COL].CellType = text_type;

                        FormatTbl[KEY_5_COL].Col_Fmt = TABLE.GetChar("KEY_5_FMT").ToString();
                        FormatTbl[KEY_5_COL].Col_Size = TABLE.GetInt("KEY_5_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_5_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_5_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_5_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_5_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_5_TBL"), TABLE.GetString("KEY_5_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_5_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_5_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_6_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].Value = " " + TABLE.GetString("KEY_6_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_6_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_6_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_6_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_6_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_6_COL].CellType = text_type;

                        FormatTbl[KEY_6_COL].Col_Fmt = TABLE.GetChar("KEY_6_FMT").ToString();
                        FormatTbl[KEY_6_COL].Col_Size = TABLE.GetInt("KEY_6_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_6_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_6_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_6_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_6_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_6_TBL"), TABLE.GetString("KEY_6_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_6_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_6_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_7_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].Value = " " + TABLE.GetString("KEY_7_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_7_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_7_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_7_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_7_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_7_COL].CellType = text_type;

                        FormatTbl[KEY_7_COL].Col_Fmt = TABLE.GetChar("KEY_7_FMT").ToString();
                        FormatTbl[KEY_7_COL].Col_Size = TABLE.GetInt("KEY_7_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_7_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_7_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_7_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_7_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_7_TBL"), TABLE.GetString("KEY_7_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_7_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_7_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_8_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].Value = " " + TABLE.GetString("KEY_8_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_8_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_8_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_8_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_8_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_8_COL].CellType = text_type;

                        FormatTbl[KEY_8_COL].Col_Fmt = TABLE.GetChar("KEY_8_FMT").ToString();
                        FormatTbl[KEY_8_COL].Col_Size = TABLE.GetInt("KEY_8_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_8_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_8_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_8_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_8_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_8_TBL"), TABLE.GetString("KEY_8_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_8_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_8_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_9_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].Value = " " + TABLE.GetString("KEY_9_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_9_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_9_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_9_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_9_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_9_COL].CellType = text_type;

                        FormatTbl[KEY_9_COL].Col_Fmt = TABLE.GetChar("KEY_9_FMT").ToString();
                        FormatTbl[KEY_9_COL].Col_Size = TABLE.GetInt("KEY_9_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_9_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_9_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_9_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_9_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_9_TBL"), TABLE.GetString("KEY_9_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_9_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_9_BTN].Locked = true;
                        }
                    }
                    if (TABLE.GetString("KEY_10_PRT") != "")
                    {
                        text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                        //text_type.WordWrap = true;
                        text_type.MaxLength = 100;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].CellType = text_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].Value = " " + TABLE.GetString("KEY_10_PRT") + " ";
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_10_COL].Width = 180;
                        spdData.ActiveSheet.ColumnHeader.Columns[KEY_10_COL].Visible = true;

                        spdData.ActiveSheet.Columns[KEY_10_COL].Locked = true;
                        spdData.ActiveSheet.Columns[KEY_10_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                        spdData.ActiveSheet.Columns[KEY_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                        spdData.ActiveSheet.Columns[KEY_10_COL].CellType = text_type;

                        FormatTbl[KEY_10_COL].Col_Fmt = TABLE.GetChar("KEY_10_FMT").ToString();
                        FormatTbl[KEY_10_COL].Col_Size = TABLE.GetInt("KEY_10_SIZE");

                        spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].Tag = COLUMN_KEY;
                        if (TABLE.GetString("KEY_10_TBL") != "")
                        {
                            button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                            button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                            button_type.Text = "...";
                            spdData.ActiveSheet.Columns[KEY_10_BTN].Width = 20;
                            spdData.ActiveSheet.ColumnHeader.Columns[KEY_10_BTN].Visible = true;
                            spdData.ActiveSheet.Columns[KEY_10_BTN].CellType = button_type;
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("KEY_10_TBL"), TABLE.GetString("KEY_10_COL"));
                            spdData.ActiveSheet.ColumnHeader.Cells[0, KEY_10_COL].ColumnSpan = 2;
                            spdData.ActiveSheet.Columns[KEY_10_BTN].Locked = true;
                        }
                    }
                }

                if (TABLE.GetString("DATA_1_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Value = " " + TABLE.GetString("DATA_1_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_1_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_1_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_1_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_1_COL].CellType = text_type;

                    FormatTbl[DATA_1_COL].Col_Fmt = TABLE.GetChar("DATA_1_FMT").ToString();
                    FormatTbl[DATA_1_COL].Col_Size = TABLE.GetInt("DATA_1_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_1_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_1_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_1_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_1_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_1_TBL"), TABLE.GetString("DATA_1_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_1_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_2_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].Value = " " + TABLE.GetString("DATA_2_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_2_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_2_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_2_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_2_COL].CellType = text_type;

                    FormatTbl[DATA_2_COL].Col_Fmt = TABLE.GetChar("DATA_2_FMT").ToString();
                    FormatTbl[DATA_2_COL].Col_Size = TABLE.GetInt("DATA_2_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_2_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_2_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_2_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_2_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_2_TBL"), TABLE.GetString("DATA_2_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_2_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_3_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].Value = " " + TABLE.GetString("DATA_3_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_3_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_3_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_3_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_3_COL].CellType = text_type;

                    FormatTbl[DATA_3_COL].Col_Fmt = TABLE.GetChar("DATA_3_FMT").ToString();
                    FormatTbl[DATA_3_COL].Col_Size = TABLE.GetInt("DATA_3_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_3_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_3_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_3_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_3_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_3_TBL"), TABLE.GetString("DATA_3_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_3_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_4_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].Value = " " + TABLE.GetString("DATA_4_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_4_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_4_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_4_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_4_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_4_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_4_COL].CellType = text_type;

                    FormatTbl[DATA_4_COL].Col_Fmt = TABLE.GetChar("DATA_4_FMT").ToString();
                    FormatTbl[DATA_4_COL].Col_Size = TABLE.GetInt("DATA_4_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_4_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_4_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_4_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_4_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_4_TBL"), TABLE.GetString("DATA_4_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_4_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_5_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].Value = " " + TABLE.GetString("DATA_5_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_5_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_5_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_5_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_5_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_5_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_5_COL].CellType = text_type;

                    FormatTbl[DATA_5_COL].Col_Fmt = TABLE.GetChar("DATA_5_FMT").ToString();
                    FormatTbl[DATA_5_COL].Col_Size = TABLE.GetInt("DATA_5_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_5_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_5_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_5_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_5_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_5_TBL"), TABLE.GetString("DATA_5_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_5_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_6_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].Value = " " + TABLE.GetString("DATA_6_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_6_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_6_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_6_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_6_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_6_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_6_COL].CellType = text_type;

                    FormatTbl[DATA_6_COL].Col_Fmt = TABLE.GetChar("DATA_6_FMT").ToString();
                    FormatTbl[DATA_6_COL].Col_Size = TABLE.GetInt("DATA_6_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_6_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_6_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_6_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_6_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_6_TBL"), TABLE.GetString("DATA_6_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_6_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_7_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].Value = " " + TABLE.GetString("DATA_7_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_7_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_7_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_7_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_7_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_7_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_7_COL].CellType = text_type;

                    FormatTbl[DATA_7_COL].Col_Fmt = TABLE.GetChar("DATA_7_FMT").ToString();
                    FormatTbl[DATA_7_COL].Col_Size = TABLE.GetInt("DATA_7_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_7_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_7_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_7_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_7_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_7_TBL"), TABLE.GetString("DATA_7_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_7_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_8_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].Value = " " + TABLE.GetString("DATA_8_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_8_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_8_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_8_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_8_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_8_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_8_COL].CellType = text_type;

                    FormatTbl[DATA_8_COL].Col_Fmt = TABLE.GetChar("DATA_8_FMT").ToString();
                    FormatTbl[DATA_8_COL].Col_Size = TABLE.GetInt("DATA_8_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_8_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_8_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_8_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_8_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_8_TBL"), TABLE.GetString("DATA_8_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_8_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_9_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].Value = " " + TABLE.GetString("DATA_9_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_9_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_9_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_9_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_9_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_9_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_9_COL].CellType = text_type;

                    FormatTbl[DATA_9_COL].Col_Fmt = TABLE.GetChar("DATA_9_FMT").ToString();
                    FormatTbl[DATA_9_COL].Col_Size = TABLE.GetInt("DATA_9_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_9_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_9_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_9_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_9_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_9_TBL"), TABLE.GetString("DATA_9_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_9_COL].ColumnSpan = 2;
                    }
                }
                if (TABLE.GetString("DATA_10_PRT") != "")
                {
                    text_type = new FarPoint.Win.Spread.CellType.TextCellType();
                    //text_type.WordWrap = true;
                    text_type.MaxLength = 1000;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].CellType = text_type;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].Value = " " + TABLE.GetString("DATA_10_PRT") + " ";
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_10_COL].Width = 180;
                    spdData.ActiveSheet.ColumnHeader.Columns[DATA_10_COL].Visible = true;

                    spdData.ActiveSheet.Columns[DATA_10_COL].Locked = false;
                    spdData.ActiveSheet.Columns[DATA_10_COL].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdData.ActiveSheet.Columns[DATA_10_COL].VerticalAlignment = CellVerticalAlignment.Center;

                    spdData.ActiveSheet.Columns[DATA_10_COL].CellType = text_type;

                    FormatTbl[DATA_10_COL].Col_Fmt = TABLE.GetChar("DATA_10_FMT").ToString();
                    FormatTbl[DATA_10_COL].Col_Size = TABLE.GetInt("DATA_10_SIZE");

                    spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].Tag = COLUMN_DATA;
                    if (TABLE.GetString("DATA_10_TBL") != "")
                    {
                        button_type = new FarPoint.Win.Spread.CellType.ButtonCellType();
                        button_type.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
                        button_type.Text = "...";
                        spdData.ActiveSheet.Columns[DATA_10_BTN].Width = 20;
                        spdData.ActiveSheet.ColumnHeader.Columns[DATA_10_BTN].Visible = true;
                        spdData.ActiveSheet.Columns[DATA_10_BTN].CellType = button_type;
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_BTN].Tag = String.Format("{0}:{1}", TABLE.GetString("DATA_10_TBL"), TABLE.GetString("DATA_10_COL"));
                        spdData.ActiveSheet.ColumnHeader.Cells[0, DATA_10_COL].ColumnSpan = 2;
                    }
                }

                if (AutoCalWidth() == false)
                {
                    return false;
                }

                spdData.ActiveSheet.ColumnHeader.Rows[0].Height = spdData.ActiveSheet.ColumnHeader.Rows[0].GetPreferredHeight();
                spdData.ActiveSheet.SetColumnAllowAutoSort(1, 40, true);
                spdData.ActiveSheet.SetColumnAllowFilter(1, 40, true);

                spdData.ActiveSheet.RowCount++;
                for (i = 1; i <= 40; i++)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_DATA)
                    {
                        spdData.ActiveSheet.Columns[i].BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        spdData.ActiveSheet.Columns[i].BackColor = System.Drawing.Color.Lavender;
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                        spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                    }
                }
                /*** End of Modification (2012.04.04) ***/

                btnSelect.Text = MPCF.FindLanguage("Select All Rows", 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private void SetColumnSQL(int i_col, string s_col_prt)
        {
            spdQuery.ActiveSheet.ColumnHeader.Cells[0, i_col].Value = " " + s_col_prt + " ";
            spdQuery.ActiveSheet.Columns[i_col].Width = 180;
            spdQuery.ActiveSheet.Columns[i_col].Resizable = true;
        }

        private bool MakeColumnHeaderSQL()
        {
            int i;

            try
            {
                if (spdQuery.ActiveSheet.RowCount < 1)
                {
                    return true;
                }

                for (i = 0; i < 20; i++)
                {
                    spdQuery.ActiveSheet.ColumnHeader.Cells[0, i].Value = "";
                    spdQuery.ActiveSheet.ColumnHeader.Cells[0, i].HorizontalAlignment = CellHorizontalAlignment.Center;
                    spdQuery.ActiveSheet.ColumnHeader.Cells[0, i].VerticalAlignment = CellVerticalAlignment.Center;

                    spdQuery.ActiveSheet.Columns[i].Width = 0;
                    spdQuery.ActiveSheet.Columns[i].Locked = true;
                    spdQuery.ActiveSheet.Columns[i].Resizable = false;
                    spdQuery.ActiveSheet.Columns[i].HorizontalAlignment = CellHorizontalAlignment.Left;
                    spdQuery.ActiveSheet.Columns[i].VerticalAlignment = CellVerticalAlignment.Center;
                }

                if (TABLE.GetString("KEY_1_PRT") != "")
                    SetColumnSQL(0, TABLE.GetString("KEY_1_PRT"));
                if (TABLE.GetString("KEY_2_PRT") != "")
                    SetColumnSQL(1, TABLE.GetString("KEY_2_PRT"));
                if (TABLE.GetString("KEY_3_PRT") != "")
                    SetColumnSQL(2, TABLE.GetString("KEY_3_PRT"));
                if (TABLE.GetString("KEY_4_PRT") != "")
                    SetColumnSQL(3, TABLE.GetString("KEY_4_PRT"));
                if (TABLE.GetString("KEY_5_PRT") != "")
                    SetColumnSQL(4, TABLE.GetString("KEY_5_PRT"));
                if (TABLE.GetString("KEY_6_PRT") != "")
                    SetColumnSQL(5, TABLE.GetString("KEY_6_PRT"));
                if (TABLE.GetString("KEY_7_PRT") != "")
                    SetColumnSQL(6, TABLE.GetString("KEY_7_PRT"));
                if (TABLE.GetString("KEY_8_PRT") != "")
                    SetColumnSQL(7, TABLE.GetString("KEY_8_PRT"));
                if (TABLE.GetString("KEY_9_PRT") != "")
                    SetColumnSQL(8, TABLE.GetString("KEY_9_PRT"));
                if (TABLE.GetString("KEY_10_PRT") != "")
                    SetColumnSQL(9, TABLE.GetString("KEY_10_PRT"));

                if (TABLE.GetString("DATA_1_PRT") != "")
                    SetColumnSQL(10, TABLE.GetString("DATA_1_PRT"));
                if (TABLE.GetString("DATA_2_PRT") != "")
                    SetColumnSQL(11, TABLE.GetString("DATA_2_PRT"));
                if (TABLE.GetString("DATA_3_PRT") != "")
                    SetColumnSQL(12, TABLE.GetString("DATA_3_PRT"));
                if (TABLE.GetString("DATA_4_PRT") != "")
                    SetColumnSQL(13, TABLE.GetString("DATA_4_PRT"));
                if (TABLE.GetString("DATA_5_PRT") != "")
                    SetColumnSQL(14, TABLE.GetString("DATA_5_PRT"));
                if (TABLE.GetString("DATA_6_PRT") != "")
                    SetColumnSQL(15, TABLE.GetString("DATA_6_PRT"));
                if (TABLE.GetString("DATA_7_PRT") != "")
                    SetColumnSQL(16, TABLE.GetString("DATA_7_PRT"));
                if (TABLE.GetString("DATA_8_PRT") != "")
                    SetColumnSQL(17, TABLE.GetString("DATA_8_PRT"));
                if (TABLE.GetString("DATA_9_PRT") != "")
                    SetColumnSQL(18, TABLE.GetString("DATA_9_PRT"));
                if (TABLE.GetString("DATA_10_PRT") != "")
                    SetColumnSQL(19, TABLE.GetString("DATA_10_PRT"));

                MPCF.FitColumnHeader(spdQuery, true);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // AutoCalWidth()
        //       - Auto Calculation Spread Column Width
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool AutoCalWidth()
        {
            int i = 0;
            int iSpreadWidth = 0;
            int iColumnWidth = 0;
            int iColumnCount = 0;

            float iColumnHeaderWidth = 0;
            float iRowHeaderWidth = 0;

            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            if (b_reload_data_flag == true)
            {
                for (i = 0; i < 40; i++)
                {
                    spdData.ActiveSheet.ColumnHeader.Columns[i + 1].Width = d_prev_col_size[i];
                    spdData.ActiveSheet.ColumnHeader.Columns[i + 1].Resizable = true;
                }
            }
            else
            {
                if (spdData.ActiveSheet.ColumnHeader.Columns.Count > 0)
                    iColumnHeaderWidth = spdData.ActiveSheet.ColumnHeader.Columns[0].Width;

                if (spdData.ActiveSheet.RowHeader.Columns.Count > 0)
                    iRowHeaderWidth = spdData.ActiveSheet.RowHeader.Columns[0].Width;

                iSpreadWidth = (int)(spdData.Width - iColumnHeaderWidth - iRowHeaderWidth - 25);

                if (iSpreadWidth <= 0)
                {
                    return false;
                }
                for (i = 1; i < spdData.ActiveSheet.ColumnCount; i++)
                {
                    if (spdData.ActiveSheet.ColumnHeader.Columns[i].Width > 0)
                    {
                        iColumnCount++;
                    }
                }

                if (iColumnCount > 0)
                    iColumnWidth = iSpreadWidth / iColumnCount;
                else
                    iColumnCount = iSpreadWidth;

                if (iColumnWidth < 120)
                {
                    iColumnWidth = 120;
                }
                for (i = 1; i < spdData.ActiveSheet.ColumnCount; i++)
                {
                    if (spdData.ActiveSheet.ColumnHeader.Columns[i].Width > 0)
                    {
                        if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_KEY ||
                            MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_DATA)
                        {
                            spdData.ActiveSheet.ColumnHeader.Columns[i].Width = iColumnWidth;
                            spdData.ActiveSheet.ColumnHeader.Columns[i].Resizable = true;
                        }
                    }
                }
            }
            /*** End of Modification (2012.04.04) ***/

            return true;

        }

        private DataTable FillDataTable(DataTable dt, TRSNode out_node)
        {
            int c;
            int r;
            DataColumn dc;
            DataRow dr;
            List<TRSNode> data_list;

            /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
            data_list = out_node.GetList("DATA_LIST");
            if (dt == null)
            {
                if (data_list.Count < 1) return null;
                dt = new DataTable("DataTable");
                for (c = 0; c < 40; c++)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "";

                    dt.Columns.Add(dc);
                }
            }

            for (r = 0; r < data_list.Count; r++)
            {
                dr = dt.NewRow();

                dr[0] = data_list[r].GetString("KEY_1");
                dr[1] = "";
                dr[2] = data_list[r].GetString("KEY_2");
                dr[3] = "";
                dr[4] = data_list[r].GetString("KEY_3");
                dr[5] = "";
                dr[6] = data_list[r].GetString("KEY_4");
                dr[7] = "";
                dr[8] = data_list[r].GetString("KEY_5");
                dr[9] = "";
                dr[10] = data_list[r].GetString("KEY_6");
                dr[11] = "";
                dr[12] = data_list[r].GetString("KEY_7");
                dr[13] = "";
                dr[14] = data_list[r].GetString("KEY_8");
                dr[15] = "";
                dr[16] = data_list[r].GetString("KEY_9");
                dr[17] = "";
                dr[18] = data_list[r].GetString("KEY_10");
                dr[19] = "";

                dr[20] = data_list[r].GetString("DATA_1");
                dr[21] = "";
                dr[22] = data_list[r].GetString("DATA_2");
                dr[23] = "";
                dr[24] = data_list[r].GetString("DATA_3");
                dr[25] = "";
                dr[26] = data_list[r].GetString("DATA_4");
                dr[27] = "";
                dr[28] = data_list[r].GetString("DATA_5");
                dr[29] = "";
                dr[30] = data_list[r].GetString("DATA_6");
                dr[31] = "";
                dr[32] = data_list[r].GetString("DATA_7");
                dr[33] = "";
                dr[34] = data_list[r].GetString("DATA_8");
                dr[35] = "";
                dr[36] = data_list[r].GetString("DATA_9");
                dr[37] = "";
                dr[38] = data_list[r].GetString("DATA_10");
                dr[39] = "";

                dt.Rows.Add(dr);
            }
            /*** End of Modification (2012.04.04) ***/

            return dt;
        }

        private DataTable FillDataTableSQL(DataTable dt, TRSNode out_node)
        {
            int c;
            int r;
            DataColumn dc;
            DataRow dr;
            List<TRSNode> data_list;

            data_list = out_node.GetList("DATA_LIST");
            if (dt == null)
            {
                if (data_list.Count < 1) return null;
                dt = new DataTable("DataTable");
                for (c = 0; c < 20; c++)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "";

                    dt.Columns.Add(dc);
                }
            }

            for (r = 0; r < data_list.Count; r++)
            {
                dr = dt.NewRow();

                dr[0] = data_list[r].GetString("KEY_1");
                dr[1] = data_list[r].GetString("KEY_2");
                dr[2] = data_list[r].GetString("KEY_3");
                dr[3] = data_list[r].GetString("KEY_4");
                dr[4] = data_list[r].GetString("KEY_5");
                dr[5] = data_list[r].GetString("KEY_6");
                dr[6] = data_list[r].GetString("KEY_7");
                dr[7] = data_list[r].GetString("KEY_8");
                dr[8] = data_list[r].GetString("KEY_9");
                dr[9] = data_list[r].GetString("KEY_10");

                dr[10] = data_list[r].GetString("DATA_1");
                dr[11] = data_list[r].GetString("DATA_2");
                dr[12] = data_list[r].GetString("DATA_3");
                dr[13] = data_list[r].GetString("DATA_4");
                dr[14] = data_list[r].GetString("DATA_5");
                dr[15] = data_list[r].GetString("DATA_6");
                dr[16] = data_list[r].GetString("DATA_7");
                dr[17] = data_list[r].GetString("DATA_8");
                dr[18] = data_list[r].GetString("DATA_9");
                dr[19] = data_list[r].GetString("DATA_10");

                dt.Rows.Add(dr);
            }

            return dt;
        }
        
        //
        // View_Data_List()
        //       - View All General Code Data list which is included in one General Code Table
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool ViewDataList(string[] sArgu)
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            DataTable dt = null;
            ArrayList a_list = new ArrayList();
            FarPoint.Win.Spread.FpSpread spd;
            int i;

            try
            {
                if (b_reload_data_flag == true)
                {
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    for (i = 0; i < 40; i++)
                    {
                        d_prev_col_size[i] = spdData.ActiveSheet.ColumnHeader.Columns[i + 1].Width;
                    }
                    /*** End of Modification (2012.04.04) ***/
                }

                if (pnlSql.Visible == true)
                {
                    spd = spdQuery;
                }
                else
                {
                    spd = spdData;
                }

                MPCF.ClearList(spd);
                spd.SuspendLayout();
                spd.ActiveSheet.ColumnCount = 0;
                spd.ResumeLayout();

                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", lisTable.SelectedItems[0].Text);

                /* 2013.06.12. Aiden. 10000 °³ ÀÌ»óÀÇ Data °¡ Á¸ÀçÇÏ´Â °æ¿ì Filter ¸¦ ÅëÇØ Data List ¸¦ °¡Á®¿Àµµ·Ï º¯°æ */
                if (MPCF.Trim(txtFilterKey1.Text) != "")
                {
                    in_node.AddString("KEY_1", MPCF.Trim(txtFilterKey1.Text) + "%");
                }
                if (MPCF.Trim(txtFilterKey2.Text) != "")
                {
                    in_node.AddString("KEY_2", MPCF.Trim(txtFilterKey2.Text) + "%");
                }

                if (sArgu != null)
                {
                    for (i = 0; i < sArgu.Length; i++)
                    {
                        TRSNode node = in_node.AddNode("ARGU_LIST");
                        node.AddString("ARGUMENT", sArgu[i]);
                    }
                }

                spd.SuspendLayout();

                do
                {
                    out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                    if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    a_list.Add(out_node);

                    in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                    in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                    in_node.SetString("NEXT_KEY_3", out_node.GetString("NEXT_KEY_3"));
                    in_node.SetString("NEXT_KEY_4", out_node.GetString("NEXT_KEY_4"));
                    in_node.SetString("NEXT_KEY_5", out_node.GetString("NEXT_KEY_5"));
                    in_node.SetString("NEXT_KEY_6", out_node.GetString("NEXT_KEY_6"));
                    in_node.SetString("NEXT_KEY_7", out_node.GetString("NEXT_KEY_7"));
                    in_node.SetString("NEXT_KEY_8", out_node.GetString("NEXT_KEY_8"));
                    in_node.SetString("NEXT_KEY_9", out_node.GetString("NEXT_KEY_9"));
                    in_node.SetString("NEXT_KEY_10", out_node.GetString("NEXT_KEY_10"));
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));


                } while (in_node.GetString("NEXT_KEY_1") != "" ||
                         in_node.GetString("NEXT_KEY_2") != "" ||
                         in_node.GetString("NEXT_KEY_3") != "" ||
                         in_node.GetString("NEXT_KEY_4") != "" ||
                         in_node.GetString("NEXT_KEY_5") != "" ||
                         in_node.GetString("NEXT_KEY_6") != "" ||
                         in_node.GetString("NEXT_KEY_7") != "" ||
                         in_node.GetString("NEXT_KEY_8") != "" ||
                         in_node.GetString("NEXT_KEY_9") != "" ||
                         in_node.GetString("NEXT_KEY_10") != "" ||
                         in_node.GetInt("NEXT_ROW") > 0);

                foreach (object obj in a_list)
                {
                    out_node = null;
                    out_node = (TRSNode)obj;

                    if (pnlSql.Visible == true)
                    {
                        dt = FillDataTableSQL(dt, out_node);
                    }
                    else
                    {
                        dt = FillDataTable(dt, out_node);
                    }
                }

                spd.DataSource = dt;
                if (pnlSql.Visible == true)
                {
                    MakeColumnHeaderSQL();
                }
                else
                {
                    MakeColumnHeader();
                }
                spd.ResumeLayout();

                txtExpTable.Text = lisTable.SelectedItems[0].Text;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // Update_Data_List()
        //       - Create/Update/Delete General Code Data List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool UpdateDataList(char ProcStep)
        {
            int i = 0;
            TRSNode in_node = new TRSNode("UPDATE_DATA_LIST_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.AddString("TABLE_NAME", lisTable.SelectedItems[0].Text);
                in_node.AddString("TABLE_PASSWORD", MPCF.Trim(txtPwd.Text).ToUpper(), true);

                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (spdData.ActiveSheet.Cells[i, 0].Value == null) continue;
                    if (Convert.ToBoolean(spdData.ActiveSheet.Cells[i, 0].Value) == false) continue;

                    node = in_node.AddNode("DATA_LIST");

                    node.AddString("KEY_1", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_1_COL].Value));
                    node.AddString("KEY_2", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_2_COL].Value));
                    node.AddString("KEY_3", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_3_COL].Value));
                    node.AddString("KEY_4", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_4_COL].Value));
                    node.AddString("KEY_5", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_5_COL].Value));
                    node.AddString("KEY_6", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_6_COL].Value));
                    node.AddString("KEY_7", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_7_COL].Value));
                    node.AddString("KEY_8", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_8_COL].Value));
                    node.AddString("KEY_9", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_9_COL].Value));
                    node.AddString("KEY_10", MPCF.Trim(spdData.ActiveSheet.Cells[i, KEY_10_COL].Value));

                    node.AddString("DATA_1", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_1_COL].Value));
                    node.AddString("DATA_2", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_2_COL].Value));
                    node.AddString("DATA_3", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_3_COL].Value));
                    node.AddString("DATA_4", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_4_COL].Value));
                    node.AddString("DATA_5", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_5_COL].Value));
                    node.AddString("DATA_6", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_6_COL].Value));
                    node.AddString("DATA_7", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_7_COL].Value));
                    node.AddString("DATA_8", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_8_COL].Value));
                    node.AddString("DATA_9", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_9_COL].Value));
                    node.AddString("DATA_10", MPCF.Trim(spdData.ActiveSheet.Cells[i, DATA_10_COL].Value));
                }

                if (MPCR.CallService("BAS", "BAS_Update_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                MPCR.ShowSuccessMsg(out_node);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        private bool ViewTable()
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");

            try
            {
                if (TABLE == null)
                {
                    TABLE = new TRSNode("VIEW_TABLE_OUT");
                }

                TABLE.Init();

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", lisTable.SelectedItems[0].Text);

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref TABLE) == false)
                {
                    return false;
                }

                if (TABLE.GetChar("USE_SQL_FLAG") == 'Y')
                {
                    MPCF.ClearList(spdQuery);

                    pnlDataListFill.Visible = false;
                    pnlDataListBottom.Visible = false;
                    pnlRight.Controls.Add(pnlSql);
                    pnlSql.Dock = DockStyle.Fill;
                    pnlSql.Visible = true;

                    txtQuery.Text = TABLE.GetString("SQL_1") + TABLE.GetString("SQL_2") + TABLE.GetString("SQL_3")
                                    + TABLE.GetString("SQL_4") + TABLE.GetString("SQL_5");
                    ChangeSyntaxColor();
                }
                else
                {
                    pnlDataListFill.Visible = true;
                    pnlDataListBottom.Visible = true;
                    pnlSql.Visible = false;

                    /* 2013.06.12. Aiden. 10000 °³ ÀÌ»óÀÇ Data °¡ Á¸ÀçÇÏ´Â °æ¿ì Filter ¸¦ ÅëÇØ Data List ¸¦ °¡Á®¿Àµµ·Ï º¯°æ */
                    if (IsBigDataList(TABLE.GetString("TABLE_NAME"), TABLE.GetChar("TABLE_TYPE")) == true)
                    {
                        pnlDataFilter.Visible = true;
                        btnView.Visible = true;

                        lblKey1.Visible = false;
                        txtFilterKey1.Visible = false;
                        lblKey2.Visible = false;
                        txtFilterKey2.Visible = false;

                        if (TABLE.GetString("KEY_1_PRT") != "")
                        {
                            lblKey1.Text = TABLE.GetString("KEY_1_PRT");
                            lblKey1.Visible = true;
                            txtFilterKey1.Visible = true;
                        }
                        if (TABLE.GetString("KEY_2_PRT") != "")
                        {
                            lblKey2.Text = TABLE.GetString("KEY_2_PRT");
                            lblKey2.Visible = true;
                            txtFilterKey2.Visible = true;
                        }

                        MPCF.ClearList(spdData);
                        MakeColumnHeader();
                    }
                    else
                    {
                        pnlDataFilter.Visible = false;
                        btnView.Visible = false;

                        txtFilterKey1.Text = "";
                        txtFilterKey2.Text = "";

                        ViewDataList(null);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        private bool GetQueryArgument()
        {
            int i, i_count, j;
            string[] sWord = null;
            string[] sArgu = null;
            bool b_exist_flag = false;
            frmBASSubSetupTable form = new frmBASSubSetupTable();

            sWord = txtQuery.Text.Split(new Char[] { ' ', '\n', '\r' });
            i_count = 0;
            for (i = 0; i < sWord.Length; i++)
            {
                if (sWord[i].IndexOf("$") >= 0)
                {
                    if (MPCF.Trim(sWord[i]).ToUpper().Contains("$FACTORY") == false)
                    {
                        i_count++;
                    }
                }
            }
            if (i_count > 0)
            {
                sArgu = new string[i_count];
            }

            i_count = 0;
            for (i = 0; i < sWord.Length; i++)
            {
                if (sWord[i].IndexOf("$") >= 0)
                {
                    b_exist_flag = false;
                    if (MPCF.Trim(sWord[i]).ToUpper().Contains("$FACTORY") == false)
                    {
                        for (j = 0; j < sArgu.Length; j++)
                        {
                            if (sArgu[j] == sWord[i])
                            {
                                b_exist_flag = true;
                            }
                        }
                        if (b_exist_flag == false)
                        {
                            sArgu[i_count] = sWord[i];
                            i_count++;
                        }
                    }
                }
            }
            if (i_count > 0)
            {
                form.ViewQueryArgument(sArgu, i_count);
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    if (form.IsDisposed == false) form.Dispose();
                    return false;
                }
                sArgu = new string[i_count];
                for (i = 0; i < sArgu.Length; i++)
                {
                    //Modify by J.S. 2008.12.24 '´Â ¼­¹ö¿¡¼­ ºÙÀÓ.
                    sArgu[i] = form.ArgValue[i, 1];
                }
            }

            ViewDataList(sArgu);
            return true;
        }

        private bool IsSQLSyntax(string sQuery)
        {
            for (int i = 0; i < MPGV.SqlSyntax.Length; i++)
            {
                if (MPCF.Trim(MPGV.SqlSyntax[i]) == MPCF.Trim(sQuery))
                {
                    return true;
                }
            }
            return false;
        }

        private void ChangeSyntaxColor()
        {
            int iStart;
            int iLen = 0;
            iStart = 0;
            if (MPCF.Trim(txtQuery.Text) == "")
            {
                return;
            }
            txtQuery.SelectionStart = 0;
            txtQuery.SelectionLength = txtQuery.Text.Length;
            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;

            while (iLen < txtQuery.Text.Length)
            {
                if (txtQuery.Text[iLen] == ' ')
                {
                    if (IsSQLSyntax(MPCF.ToUpper(txtQuery.Text.Substring(iStart, iLen - iStart))) == true ||
                        txtQuery.Text.Substring(iStart, iLen - iStart).IndexOf("$") > 0)
                    {
                        txtQuery.SelectionStart = iStart;
                        txtQuery.SelectionLength = iLen - iStart;
                        txtQuery.SelectionColor = System.Drawing.Color.Blue;
                        txtQuery.SelectionStart = iLen;
                        txtQuery.SelectionLength = 0;
                        txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;
                    }
                    iStart = iLen;
                }

                iLen++;
            }
        }

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        //
        // Check_GCM_Table()
        //       - Check GCM Table
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - string sTableName      : GCM Table Name
        //       - out string sQuery      : SQL Query (out)
        //       - out string dTable      : Script Export Table(2012.05.15 modify by leejy)
        //
        private bool CheckGCMTable(string sTableName, out string sQuery, out string dTable)
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_OUT");

            sQuery = String.Empty;
            dTable = String.Empty;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", sTableName);
                in_node.AddChar("INCLUDE_CENTRAL_TABLE_FLAG", 'Y');

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (out_node.GetChar("USE_SQL_FLAG") == 'Y')
                {
                    sQuery = out_node.GetString("SQL_1") + out_node.GetString("SQL_2") + out_node.GetString("SQL_3")
                             + out_node.GetString("SQL_4") + out_node.GetString("SQL_5");
                }

                if (out_node.GetChar("TABLE_TYPE") == 'L')
                    dTable = GCM_TBL_LAG;
                else
                    dTable = GCM_TBL_DAT;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }

        //
        // GetQueryArgument()
        //       - Get Query Argument (by query)
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool GetQueryArgument(string sQuery, out string[] sArgu)
        {
            int i, j, i_count;
            string[] sWord = null;
            bool b_exist_flag = false;

            sArgu = null;

            if (MPCF.Trim(sQuery) != "")
            {
                frmBASSubSetupTable form = new frmBASSubSetupTable();

                sWord = sQuery.Split(new Char[] { ' ', '\n', '\r' });
                i_count = 0;
                for (i = 0; i < sWord.Length; i++)
                {
                    if (sWord[i].IndexOf("$") >= 0)
                    {
                        if (MPCF.Trim(sWord[i]).ToUpper().Contains("$FACTORY") == false)
                        {
                            i_count++;
                        }
                    }
                }
                if (i_count > 0)
                {
                    sArgu = new string[i_count];
                }

                i_count = 0;
                for (i = 0; i < sWord.Length; i++)
                {
                    if (sWord[i].IndexOf("$") >= 0)
                    {
                        b_exist_flag = false;
                        if (MPCF.Trim(sWord[i]).ToUpper().Contains("$FACTORY") == false)
                        {
                            for (j = 0; j < sArgu.Length; j++)
                            {
                                if (sArgu[j] == sWord[i])
                                {
                                    b_exist_flag = true;
                                }
                            }
                            if (b_exist_flag == false)
                            {
                                sArgu[i_count] = sWord[i];
                                i_count++;
                            }
                        }
                    }
                }
                if (i_count > 0)
                {
                    form.ViewQueryArgument(sArgu, i_count);
                    if (form.ShowDialog(this) != DialogResult.OK)
                    {
                        if (form.IsDisposed == false) form.Dispose();
                        return false;
                    }
                    sArgu = new string[i_count];
                    for (i = 0; i < sArgu.Length; i++)
                    {
                        sArgu[i] = form.ArgValue[i, 1];
                    }
                }
            }

            return true;
        }

        //
        // ViewGCMDataListExt()
        //       - View General Code Data list Extension (ListView Add "KEY_2" Column, use in this screen only)
        // Return Value
        //       - boolean : True / False
        // Arguments
        //
        private bool ViewGCMDataListExt(ListView lisList, string table_name, string[] Argu)
        {
            ListViewItem itmX;
            int i;
            int j;
            string s_col_name;
            ArrayList a_list;
            List<TRSNode> data_list;

            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            a_list = new ArrayList();

            MPCF.InitListView(lisList);

            if (lisList is Miracom.UI.Controls.MCCodeView.MCCodeDropList)
            {
                ((Miracom.UI.Controls.MCCodeView.MCCodeDropList)lisList).GCMTableName = table_name;
            }

            MPCR.SetInMsg(in_node);
            in_node.ProcStep = '1';

            in_node.AddString("TABLE_NAME", table_name);
            in_node.AddString("NEXT_KEY_1", "");
            in_node.AddString("NEXT_KEY_2", "");

            if (Argu != null)
            {
                for (i = 0; i < Argu.Length; i++)
                {
                    TRSNode node = in_node.AddNode("ARGU_LIST");
                    node.AddString("ARGUMENT", Argu[i]);
                }
            }

            do
            {
                out_node = new TRSNode("VIEW_DATA_LIST_OUT");

                if (MPCR.CallService("BAS", "BAS_View_Data_List", in_node, ref out_node) == false)
                {
                    return false;
                }

                a_list.Add(out_node);

                in_node.SetString("NEXT_KEY_1", out_node.GetString("NEXT_KEY_1"));
                in_node.SetString("NEXT_KEY_2", out_node.GetString("NEXT_KEY_2"));
                in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));

            } while (in_node.GetString("NEXT_KEY_1") != "" || in_node.GetString("NEXT_KEY_2") != "" || in_node.GetInt("NEXT_ROW") > 0);

            foreach (object obj in a_list)
            {
                out_node = null;
                out_node = (TRSNode)obj;

                data_list = out_node.GetList("DATA_LIST");
                for (i = 0; i < data_list.Count; i++)
                {
                    s_col_name = lisList.Columns[0].Text;

                    itmX = new ListViewItem();
                    itmX.Text = data_list[i].GetString(s_col_name);
                    itmX.ImageIndex = (int)SMALLICON_INDEX.IDX_CODE_DATA;
                    for (j = 1; j < lisList.Columns.Count; j++)
                    {
                        s_col_name = lisList.Columns[j].Text;
                        itmX.SubItems.Add(data_list[i].GetString(s_col_name));
                    }
                    lisList.Items.Add(itmX);
                }
            }

            return true;
        }
        /*** End of Add (2012.04.04) ***/

        /* 2013.06.12. Aiden. 10000 °³ ÀÌ»óÀÇ Data °¡ Á¸ÀçÇÏ´Â °æ¿ì Filter ¸¦ ÅëÇØ Data List ¸¦ °¡Á®¿Àµµ·Ï º¯°æ */
        private bool IsBigDataList(string s_table_name, char c_table_type)
        {
            StringBuilder sb = new StringBuilder();
            int i_count;

            sb.Append("SELECT COUNT(*) AS DCOUNT FROM ");

            if (c_table_type == 'L')
            {
                sb.Append("MGCMLAGDAT ");
            }
            else
            {
                sb.Append("MGCMTBLDAT ");
            }

            sb.Append("WHERE FACTORY = '" + MPGV.gsFactory + "' AND TABLE_NAME = '" + s_table_name + "'");

            i_count = MPCR.GetDataCountBySQL(sb.ToString());
            if (i_count > 10000)
            {
                return true;
            }

            return false;
        }

        public virtual Control GetFisrtFocusItem()
        {

            try
            {
                return this.lisTable;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }

        }

        #endregion

        private void frmBASSetupGeneralCodeData_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    MPCF.InitListView(lisTable);

                    btnRefresh.PerformClick();

                    i_last_filtered_column = -1;
                    s_last_filtered_string = null;
                    b_reload_data_flag = false;

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            string sTableName = "";

            try
            {
                if (lisTable.SelectedItems.Count > 0)
                {
                    sTableName = lisTable.SelectedItems[0].Text;
                }

                lblDataCount.Text = "";
                if (BASLIST.ViewGCMTableList(lisTable, '1', ' ', MPCF.Trim(cdvGroup.Text), false) == false)
                {
                    return;
                }

                MPCF.FitColumnHeader(lisTable);
                lblDataCount.Text = lisTable.Items.Count.ToString();

                if (lisTable.Items.Count > 0)
                {
                    if (sTableName == "")
                    {
                        lisTable.Items[0].Selected = true;
                    }
                    else
                    {
                        MPCF.FindListItem(lisTable, sTableName, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnExcel_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.ExportToExcel(lisTable, this.Text, "");
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisTable, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisTable, txtFind.Text, 0, true, false);
        }

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {
            int ActiveRow = 0;

            try
            {
                if (CheckCondition("Update_Data_List", '1') == true)
                {
                    ActiveRow = spdData.Sheets[0].ActiveRowIndex;

                    if (UpdateDataList(MPGC.MP_STEP_UPDATE) == false)
                    {
                        return;
                    }

                    b_reload_data_flag = true;
                    ViewDataList(null);

                    //Modify by J.S. 2012.02.14 refreshÈÄ ÀÌÀü ÆíÁýÀ§Ä¡·Î ÀÌµ¿
                    spdData.Sheets[0].ActiveColumnIndex = 0;
                    spdData.Sheets[0].ActiveRowIndex = ActiveRow;
                    spdData.ShowActiveCell(FarPoint.Win.Spread.VerticalPosition.Top, FarPoint.Win.Spread.HorizontalPosition.Left);
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
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (CheckCondition("Update_Data_List", '2') == true)
                {
                    if (UpdateDataList(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }

                    b_reload_data_flag = true;
                    ViewDataList(null);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisTable_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (lisTable.SelectedItems.Count > 0)
                {
                    b_reload_data_flag = false;
                    ViewTable();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_EnterCell(object sender, FarPoint.Win.Spread.EnterCellEventArgs e)
        {
            try
            {
                if (lisTable.SelectedItems.Count == 0)
                {
                    return;
                }
                if (spdData.ActiveSheet.Columns[KEY_1_COL].Visible == false)
                {
                    return;
                }
                if (e.Row == spdData.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, KEY_1_COL].Value) != "")
                    {
                        spdData.ActiveSheet.RowCount++;
                        int i = 0;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        for (i = 1; i <= 20; i++)
                        {
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                        }
                        /*** End of Modification (2012.04.04) ***/
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_EditModeOff(object sender, EventArgs e)
        {
            string sValue;
            int i_col;
            int i_row;

            try
            {
                i_col = spdData.ActiveSheet.ActiveColumnIndex;
                i_row = spdData.ActiveSheet.ActiveRowIndex;

                if (i_col < 1) return;

                spdData.ActiveSheet.SetValue(i_row, 0, true);

                sValue = MPCF.Trim(spdData.ActiveSheet.Cells[i_row, i_col].Value);

                if (MPCF.ByteLen(sValue) > FormatTbl[i_col].Col_Size)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(153));
                    spdData.ActiveSheet.SetValue(i_row, i_col, "");
                    spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                    return;
                }

                switch (FormatTbl[i_col].Col_Fmt)
                {
                    case "F":

                        if (MPCF.CheckNumeric(sValue) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(139));
                            spdData.ActiveSheet.SetValue(i_row, i_col, "");
                            spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                            return;
                        }
                        break;

                    case "N":

                        if (MPCF.CheckNumeric(sValue) == false)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(139));
                            spdData.ActiveSheet.SetValue(i_row, i_col, "");
                            spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                            return;
                        }
                        if (sValue.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) >= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(140));
                            spdData.ActiveSheet.SetValue(i_row, i_col, "");
                            spdData.ActiveSheet.SetActiveCell(i_row, i_col);
                            return;
                        }
                        break;
                }

                //Add 1 Row
                if (spdData.ActiveSheet.Columns[KEY_1_COL].Visible == false)
                {
                    return;
                }

                if (i_row == spdData.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.Cells[i_row, KEY_1_COL].Value) != "")
                    {
                        spdData.ActiveSheet.RowCount++;
                        int i = 0;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        for (i = 1; i <= 20; i++)
                        {
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                        }
                        /*** End of Modification (2012.04.04) ***/
                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdData_AutoFilteredColumn(object sender, AutoFilteredColumnEventArgs e)
        {
            int i;

            if (e.Column != i_last_filtered_column || e.FilterString != s_last_filtered_string)
            {
                for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                {
                    if (spdData.ActiveSheet.RowFilter.IsRowFilteredOut(i) == true)
                    {
                        spdData.ActiveSheet.SetValue(i, 0, false);
                    }
                }

                i_last_filtered_column = e.Column;
                s_last_filtered_string = e.FilterString;
            }
        }

        private void btnSelect_Click(System.Object sender, System.EventArgs e)
        {
            int i = 0;

            try
            {
                if (btnSelect.Text == MPCF.FindLanguage("Select All Rows", 1))
                {
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdData.ActiveSheet.Cells[i, 1].Value) != "")
                        {
                            if (spdData.ActiveSheet.RowFilter.IsRowFilteredOut(i) == true)
                            {
                                spdData.ActiveSheet.SetValue(i, 0, false);
                            }
                            else
                            {
                                spdData.ActiveSheet.SetValue(i, 0, true);
                            }
                        }
                    }
                    btnSelect.Text = MPCF.FindLanguage("Deselect All Rows", 1);
                }
                else if (btnSelect.Text == MPCF.FindLanguage("Deselect All Rows", 1))
                {
                    for (i = 0; i < spdData.ActiveSheet.RowCount; i++)
                    {
                        spdData.ActiveSheet.SetValue(i, 0, false);
                    }
                    btnSelect.Text = MPCF.FindLanguage("Select All Rows", 1);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvGroup_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView code_view = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            code_view.Init();
            MPCF.InitListView(code_view.GetListView);
            code_view.Columns.Add("Type", 50, HorizontalAlignment.Left);
            code_view.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            code_view.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(code_view.GetListView, '1', MPGC.MP_GCM_TABLE_GROUP);
        }

        private void cdvGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnSQLTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(txtQuery.Text) == "")
                {
                    return;
                }
                if (txtQuery.Text.IndexOf("$") > 0)
                {
                    if (GetQueryArgument() == false)
                    {
                        return;
                    }
                }
                else
                {
                    ViewDataList(null);
                }


            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnTblExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sCond;

                sCond = "Table Name : " + lisTable.SelectedItems[0].Text;
                // Updated By 140319 YJJUNG For Query-Type GCM Export
                if (pnlSql.Visible == false)
                {

                    //MPCF.ExportToExcel(spdData, this.Text, sCond);
                    //GCM @Article Export시 문제 발생. FarSpread API 사용. 
                    MPCF.ExportExcel(spdData, this.Text, true, sCond);
                }
                else
                {
                    MPCF.ExportToExcel(spdQuery, this.Text, sCond);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        private void spdData_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            ListView lisTmp = new ListView();
            string[] sTmp = null;
            string[] sArgu = null;
            string sQuery = "";
            string dTable = null;
            i_last_selected_idx = 0;
            i_last_selected_desc_idx = -1;

            try
            {
                if (e.Column == KEY_1_BTN || e.Column == KEY_2_BTN || e.Column == KEY_3_BTN || e.Column == KEY_4_BTN || e.Column == KEY_5_BTN ||
                    e.Column == KEY_6_BTN || e.Column == KEY_7_BTN || e.Column == KEY_8_BTN || e.Column == KEY_9_BTN || e.Column == KEY_10_BTN ||
                    e.Column == DATA_1_BTN || e.Column == DATA_2_BTN || e.Column == DATA_3_BTN || e.Column == DATA_4_BTN || e.Column == DATA_5_BTN ||
                    e.Column == DATA_6_BTN || e.Column == DATA_7_BTN || e.Column == DATA_8_BTN || e.Column == DATA_9_BTN || e.Column == DATA_10_BTN)
                {
                    if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag) == "") return;

                    sTmp = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).Split(':');
                    lisTmp.Columns.Add("COLUMN");
                    lisTmp.Columns.Add("PROMPT");

                    cdvDataList.Init();
                    cdvDataList.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvDataList.GetListView);

                    if (CheckGCMTable(sTmp[0], out sQuery, out dTable))
                    {
                        if (sTmp.Length == 3)
                        {
                            int iPos = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).LastIndexOf(":");
                            spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).Remove(iPos) + ":" + sQuery;
                        }
                        else
                        {
                            if (MPCF.Trim(sQuery) != "")
                                spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag += ":" + sQuery;
                        }
                        sTmp = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Column].Tag).Split(':');
                    }
                    if (sTmp.Length == 3)
                    {
                        if (GetQueryArgument(sQuery, out sArgu) == false)
                        {
                            return;
                        }

                        BASLIST.ViewGCMTablePromptList(lisTmp, sTmp[0], true, true);
                        for (int i = 0; i < lisTmp.Items.Count; i++)
                        {
                            if (lisTmp.Items[i].Text == sTmp[1])
                                i_last_selected_idx = i;

                            if (lisTmp.Items[i].Text == "DATA_1")
                                i_last_selected_desc_idx = i;

                            cdvDataList.Columns.Add(lisTmp.Items[i].Text, 50, HorizontalAlignment.Left);
                        }
                    }
                    else
                    {
                        BASLIST.ViewGCMTablePromptList(lisTmp, sTmp[0], true, true);
                        for (int i = 0; i < lisTmp.Items.Count; i++)
                        {
                            if (lisTmp.Items[i].Text == sTmp[1])
                                i_last_selected_idx = i;

                            if (lisTmp.Items[i].Text == "DATA_1")
                                i_last_selected_desc_idx = i;

                            cdvDataList.Columns.Add(lisTmp.Items[i].Text, 50, HorizontalAlignment.Left);
                        }
                    }
                    ViewGCMDataListExt(cdvDataList.GetListView, sTmp[0], sArgu);
                    if (cdvDataList.Items.Count > 0)
                    {
                        cdvDataList.InsertEmptyRow(0, 1);
                        if (cdvDataList.ShowPopupList(e.Row, e.Column) == false)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cdvDataList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            try
            {
                if (MPCF.Trim(spdData.ActiveSheet.Cells[e.Row, e.Col - 1].Value) != e.SelectedItem.SubItems[i_last_selected_idx].Text)
                {
                    spdData.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[i_last_selected_idx].Text;
                    if (e.SelectedItem.SubItems.Count > 1)
                    {
                        int iDescCol = -1;
                        for (int i = e.Col; i < spdData.ActiveSheet.ColumnCount; i++)
                        {
                            if (MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i].Tag) == COLUMN_DATA &&
                                spdData.ActiveSheet.Columns[i].Visible == true &&
                                i < spdData.ActiveSheet.ColumnCount - 1)
                            {
                                // 2 column has same reference GCM table, fill description
                                string[] sTmp1 = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, e.Col].Tag).Split(':');
                                string[] sTmp2 = MPCF.Trim(spdData.ActiveSheet.ColumnHeader.Cells[0, i + 1].Tag).Split(':');

                                if (sTmp1[0] == sTmp2[0] && sTmp1[1] != sTmp2[1] && i_last_selected_desc_idx >= 0)
                                {
                                    iDescCol = i;
                                    spdData.ActiveSheet.Cells[e.Row, iDescCol].Value = e.SelectedItem.SubItems[i_last_selected_desc_idx].Text;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        /*** End of Modification (2012.04.04) ***/

        private void btnExpFile_Click(object sender, EventArgs e)
        {
            sfdFile.Filter = "SQL | *.sql";
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                txtExpFile.Text = sfdFile.FileName;
                txtExport.Text = "";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            string Query = null;
            string data;
            txtExport.Text = "";
            int i, j;
            string temp = null;
            string cmt = null;
            string proc = null;
            string sQuery = null;
            string dTable = null;
            StringBuilder script = null;

            if (CheckGCMTable(txtExpTable.Text, out sQuery, out dTable) == false)
                return;

            Query = "SELECT * FROM " + dTable + " WHERE FACTORY = '" + MPGV.gsFactory + "' AND TABLE_NAME = '" + txtExpTable.Text + "'";
            cmt = " " + dTable + " Table(TABLE_NAME) : " + txtExpTable.Text;

            script = new StringBuilder();
            progressBarExport.Value = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", Query);

                progressBarExport.Maximum = out_node.GetList("ROWS").Count;

                #region ÄÃ·³¸í ¼ÂÆÃ
                if (chkMigration.Checked == false)
                {
                    proc = "/* Start [" + cmt + "] */\r\n";
                }
                else
                {
                    proc = "/* Start [" + cmt + "] */\r\n";
                    proc += "BEGIN\r\n";
                    proc += "   FOR REC IN (\r\n";
                    proc += "       SELECT DISTINCT FACTORY FROM MWIPFACDEF\r\n";
                    proc += "       MINUS\r\n";
                    proc += "       SELECT DISTINCT FACTORY FROM " + dTable + "\r\n";
                    proc += "       WHERE TABLE_NAME = '";
                    proc += txtExpTable.Text + "'\r\n";
                    proc += "       )\r\n";
                    proc += "   LOOP\r\n";
                }
                script.Append(proc);

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    if (chkMigration.Checked == false)
                        temp = "INSERT INTO " + dTable + "(";
                    else
                        temp = "   INSERT INTO " + dTable + "(";

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        temp += out_node.GetList(0)[i].GetString("NAME");
                        if (i < out_node.GetList(0).Count - 1) temp += ", ";
                    }
                    temp += ") VALUES(";
                    script.Append(temp);
                    #endregion

                    if (out_node.GetList("ROWS").Count <= 0)
                    {
                        txtExport.Text = "No Data";
                        return;
                    }

                    //Request Reply Timeout ¹ß»ý½Ã ¿É¼Ç¿¡¼­ TimeOut½Ã°£À» ´Ã·ÁÁÖ¾î¾ßÇÔ
                    #region Data°ª ¹Þ±â
                    for (i = 0; i < out_node.GetList("ROWS").Count; i++)
                    {
                        for (j = 0; j < out_node.GetList("COLUMNS").Count; j++)
                        {
                            if (out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA") == "")
                            {
                                script.Append("' ");
                                if (j < out_node.GetList(0).Count - 1) script.Append("', ");
                                else script.Append("'");
                            }
                            else
                            {
                                if (j == 0 && chkMigration.Checked == true)
                                {
                                    data = "REC.FACTORY";
                                    script.Append(data + ",");
                                }
                                else
                                {
                                    script.Append("'");
                                    if (out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA").Contains("'"))
                                    {
                                        data = out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA").Replace("'", "''");
                                    }
                                    else
                                    {
                                        data = out_node.GetList("ROWS")[i].GetList("COLS")[j].GetString("DATA");
                                    }
                                    script.Append(data);
                                    if (j < out_node.GetList(0).Count - 1) script.Append("', ");
                                    else script.Append("'");
                                }
                            }
                        }
                        script.Append(");\r\n");
                        progressBarExport.Increment(1);

                        if (b_export_stop) //Stop Ã³¸®
                        {
                            txtExport.Focus();
                            txtExport.AppendText("<User Stop>..." + "\r\n");
                            b_export_stop = false;
                            return;
                        }
                        if (i < out_node.GetList("ROWS").Count - 1) script.Append(temp);
                        if (i >= out_node.GetList("ROWS").Count - 1)
                        {
                            if (chkMigration.Checked == false)
                                script.Append("/* End [" + cmt + "] */\r\n\r\n");
                            else
                            {
                                script.Append("   END LOOP;\r\n");
                                script.Append("END;\r\n");
                                script.Append("/\r\n");
                                script.Append("/* End [" + cmt + "] */\r\n\r\n");
                            }
                        }
                    }
                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (out_node.GetInt("NEXT_ROW") > 0);
                    #endregion

                txtExport.Text = script.ToString();
                txtExport.Select(0, txtExport.Text.Length);
                txtExport.SelectionFont = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
                progressBarExport.Increment(1);

                if (txtExpFile.Text != "")
                {
                    StreamWriter write = new StreamWriter(txtExpFile.Text, false, Encoding.GetEncoding("EUC-KR"));
                    write.Write(script);
                    write.Close();
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            progressBarExport.Value = 0;
            return;
        }

        private void btnExpStop_Click(object sender, EventArgs e)
        {
            b_export_stop = true;
        }

        private void btnExpCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(txtExport.Text) != "")
                {
                    Clipboard.SetText(txtExport.Text);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /* 2013.06.12. Aiden. 10000 °³ ÀÌ»óÀÇ Data °¡ Á¸ÀçÇÏ´Â °æ¿ì Filter ¸¦ ÅëÇØ Data List ¸¦ °¡Á®¿Àµµ·Ï º¯°æ */
        private void btnView_Click(object sender, EventArgs e)
        {
            if (MPCF.Trim(txtFilterKey1.Text) == "" && MPCF.Trim(txtFilterKey2.Text) == "")
            {
                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                txtFilterKey1.Focus();
                return;
            }

            ViewDataList(null);
        }

        private void fpSpread_ClipboardPasting(object sender, FarPoint.Win.Spread.ClipboardPastingEventArgs e)
        {
            try
            {
                e.Handled = true;

                string clipboardText;
                string[] clipboardRows, clipboardCols = new string[] { };
                int iActiveRowIndex, iActiveColumnIndex;
                int iClipboardRowLength = 0;
                int iValueCol = 0;
                int iMaxValueCol = 0;
                bool bFoundValueCol;

                if (!Clipboard.ContainsData(DataFormats.Text)) return;

                iActiveRowIndex = spdData.ActiveSheet.ActiveRowIndex;
                iActiveColumnIndex = spdData.ActiveSheet.ActiveColumnIndex;

                clipboardText = Clipboard.GetText(TextDataFormat.UnicodeText) as string;
                clipboardText = clipboardText.Replace("\r\n", Convert.ToChar(13).ToString());
                clipboardRows = clipboardText.Split(new Char[] { Convert.ToChar(13) });

                if (clipboardRows.Length > 1)
                    iClipboardRowLength = clipboardRows.Length - 1;
                else
                    iClipboardRowLength = clipboardRows.Length;

                for (int i_row = 0; i_row < iClipboardRowLength; i_row++)
                {
                    if (spdData.ActiveSheet.RowCount - 1 < i_row + iActiveRowIndex)
                    {
                        spdData.ActiveSheet.RowCount++;
                        for (int i = 1; i <= 20; i++)
                        {
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].BackColor = System.Drawing.Color.WhiteSmoke;
                            spdData.ActiveSheet.Cells[spdData.ActiveSheet.RowCount - 1, i].Locked = false;
                        }
                    }

                    clipboardCols = clipboardRows[i_row].Split(new Char[] { Convert.ToChar(9) });
                    iValueCol = iActiveColumnIndex;

                    for (int i_col = 0; i_col < clipboardCols.Length; i_col++)
                    {   
                        spdData.ActiveSheet.Cells[iActiveRowIndex + i_row, iValueCol].Value = clipboardCols[i_col];

                        if (iValueCol > iMaxValueCol) iMaxValueCol = iValueCol;
                        if (i_col + 1 >= clipboardCols.Length) break;

                        bFoundValueCol = false;
                        for (int i = iValueCol + 1; i < spdData.ActiveSheet.ColumnCount; i++)
                        {
                            if (spdData.ActiveSheet.ColumnHeader.Columns[i].Width > 0.0005)
                            {
                                switch (i)
                                {
                                    case KEY_1_COL:
                                    case KEY_2_COL:
                                    case KEY_3_COL:
                                    case KEY_4_COL:
                                    case KEY_5_COL:
                                    case KEY_6_COL:
                                    case KEY_7_COL:
                                    case KEY_8_COL:
                                    case KEY_9_COL:
                                    case KEY_10_COL:
                                    case DATA_1_COL:
                                    case DATA_2_COL:
                                    case DATA_3_COL:
                                    case DATA_4_COL:
                                    case DATA_5_COL:
                                    case DATA_6_COL:
                                    case DATA_7_COL:
                                    case DATA_8_COL:
                                    case DATA_9_COL:
                                    case DATA_10_COL:
                                        iValueCol = i;
                                        bFoundValueCol = true;
                                        break;
                                }
                            }

                            if (bFoundValueCol == true) break;
                        }

                        if (bFoundValueCol == false) break;
                    }
                  
                    spdData.ActiveSheet.Cells[iActiveRowIndex + i_row, 0].Value = 1;            // Check Box Check
                    spdData.ActiveSheet.SetActiveCell(iActiveRowIndex + i_row, iActiveColumnIndex);
                } //end for

                spdData.ActiveSheet.SetActiveCell(iActiveRowIndex, iActiveColumnIndex);

                spdData.ActiveSheet.ClearSelection();
                spdData.ActiveSheet.AddSelection(iActiveRowIndex, iActiveColumnIndex, iClipboardRowLength, iMaxValueCol - iActiveColumnIndex + 1);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private bool mb_from_spread_clipboard;
        private void spdData_ClipboardChanging(object sender, EventArgs e)
        {
            mb_from_spread_clipboard = true;
        }

        private void spdData_ClipboardChanged(object sender, EventArgs e)
        {
            if (mb_from_spread_clipboard == false) return;

            mb_from_spread_clipboard = false;

            Clipboard.Clear();
            if (spdData.ActiveSheet.SelectionCount < 1) return;

            int i;
            int i_row;
            int i_col;
            FarPoint.Win.Spread.Model.CellRange[] cr;
            StringBuilder sb = new StringBuilder();
            string s_data;

            cr = spdData.ActiveSheet.GetSelections();

            for (i = 0; i < cr.Length; i++)
            {
                for (i_row = cr[i].Row; i_row < cr[i].Row + cr[i].RowCount; i_row++)
                {
                    s_data = "";

                    for (i_col = cr[i].Column; i_col < cr[i].Column + cr[i].ColumnCount; i_col++)
                    {
                        if (spdData.ActiveSheet.ColumnHeader.Columns[i_col].Width > 0.0005)
                        {
                            switch (i_col)
                            {
                                case KEY_1_COL:
                                case KEY_2_COL:
                                case KEY_3_COL:
                                case KEY_4_COL:
                                case KEY_5_COL:
                                case KEY_6_COL:
                                case KEY_7_COL:
                                case KEY_8_COL:
                                case KEY_9_COL:
                                case KEY_10_COL:
                                case DATA_1_COL:
                                case DATA_2_COL:
                                case DATA_3_COL:
                                case DATA_4_COL:
                                case DATA_5_COL:
                                case DATA_6_COL:
                                case DATA_7_COL:
                                case DATA_8_COL:
                                case DATA_9_COL:
                                case DATA_10_COL:
                                    if (i_col > cr[i].Column) s_data += "\t";
                                    s_data += MPCF.Trim(spdData.ActiveSheet.Cells[i_row, i_col].Value);
                                    break;
                            }
                        }
                    }

                    s_data += "\r\n";
                    sb.Append(s_data);
                }
            }

            Clipboard.SetDataObject(sb.ToString());
        }

        private void txtFilterKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnView.PerformClick();
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (lisTable.SelectedItems.Count < 1) return;
                if (String.IsNullOrEmpty(lisTable.SelectedItems[0].Text) == true) return;

                Form f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmBASViewGeneralCodeDataHistory");

                if (f == null)
                {
                    f = new frmBASViewGeneralCodeDataHistory();
                    f.MdiParent = MPGV.gfrmMDI;
                }
                ((frmBASViewGeneralCodeDataHistory)f).TableName = lisTable.SelectedItems[0].Text;
                f.BringToFront();
                f.Show();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }



    }
}
