//-----------------------------------------------------------------------------
//
//   System      : MES
//   File Name   : frmBASSetupGeneralCodeTable.vb
//   Description : General Code Table Definition Form
//
//   MES Version : 4.1.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition : Check the Conditions before Transaction
//       - View_Table() : View General Code Table definition
//       - View_Table_List() : View all table list which is included in one factory
//       - Update_Table() : Create/Update/Delete General code Table definition
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
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Text;

using Miracom.CliFrx;
using Miracom.MsgHandler;
using Miracom.MESCore;
using Miracom.TRSCore;


namespace Miracom.BASCore
{
    public class frmBASSetupGeneralCodeTable : Miracom.MESCore.SetupForm02
    {

        #region " Windows Form auto generated code "

        public frmBASSetupGeneralCodeTable()
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




        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private Miracom.UI.Controls.MCListView.MCListView lisTable;
        private System.Windows.Forms.GroupBox grbTable;
        private System.Windows.Forms.Panel pnlRightBottom;
        private System.Windows.Forms.TextBox txtUpdateTime;
        private System.Windows.Forms.TextBox txtCreateTime;
        private System.Windows.Forms.TextBox txtUpdateUser;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtCreateUser;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.CheckBox chkSysFlag;
        private System.Windows.Forms.ComboBox cboTblType;
        private System.Windows.Forms.Label lblTblType;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblToFlow;
        private System.Windows.Forms.TextBox txtToTable;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFromFactory;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvFromTable;
        private System.Windows.Forms.GroupBox grpCopyTable;
        private System.Windows.Forms.TabControl tabTable;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblFromTable;
        private System.Windows.Forms.Label lblFromFactory;
        private System.Windows.Forms.GroupBox grbGeneral;
        private System.Windows.Forms.Panel pnlGeneralFill;
        private FarPoint.Win.Spread.FpSpread spdTable;
        private FarPoint.Win.Spread.SheetView spdTable_Sheet1;
        private System.Windows.Forms.CheckBox chkCentral;
        private System.Windows.Forms.TabPage tbpGeneral;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvTblGroup;
        private Label lblTblGroup;
        private GroupBox grpTblGroup;
        private Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup;
        private Label lblGroup;
        private CheckBox chkSecFlag;
        private CheckBox chkUseSql;
        private TabControl tabData;
        private TabPage tbpField;
        private TabPage tbpQuery;
        private Panel pnlSQLTest;
        private RichTextBox txtQuery;
        private Button btnSQLTest;
        private Splitter splSQL;
        private FarPoint.Win.Spread.FpSpread spdData;
        private FarPoint.Win.Spread.SheetView spdData_Sheet1;
        private Label lblQueryDesc;
        private UI.Controls.MCCodeView.MCSPCodeView cdvTableList;
        private TabPage tabExport;
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
        private SaveFileDialog sfdFile;
        private CheckBox chkMigration;
        private CheckBox chkIncludeData;
        private Label lblQueryComment;
        private Button btnHistory;
        private System.Windows.Forms.TabPage tbpCopy;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer1 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer1 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer2 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer2 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.CellType.ColumnHeaderRenderer columnHeaderRenderer3 = new FarPoint.Win.Spread.CellType.ColumnHeaderRenderer();
            FarPoint.Win.Spread.CellType.RowHeaderRenderer rowHeaderRenderer3 = new FarPoint.Win.Spread.CellType.RowHeaderRenderer();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle5 = new FarPoint.Win.Spread.NamedStyle("HeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle6 = new FarPoint.Win.Spread.NamedStyle("RowHeaderDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle7 = new FarPoint.Win.Spread.NamedStyle("CornerDefault");
            FarPoint.Win.Spread.CellType.CornerRenderer cornerRenderer2 = new FarPoint.Win.Spread.CellType.CornerRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle8 = new FarPoint.Win.Spread.NamedStyle("DataAreaDefault");
            FarPoint.Win.Spread.CellType.GeneralCellType generalCellType2 = new FarPoint.Win.Spread.CellType.GeneralCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.TextCellType textCellType4 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType2 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType2 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType5 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType3 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.CellType.TextCellType textCellType6 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.lisTable = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbTable = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.pnlRightBottom = new System.Windows.Forms.Panel();
            this.tabTable = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pnlGeneralFill = new System.Windows.Forms.Panel();
            this.tabData = new System.Windows.Forms.TabControl();
            this.tbpField = new System.Windows.Forms.TabPage();
            this.spdTable = new FarPoint.Win.Spread.FpSpread();
            this.spdTable_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.tbpQuery = new System.Windows.Forms.TabPage();
            this.spdData = new FarPoint.Win.Spread.FpSpread();
            this.spdData_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.splSQL = new System.Windows.Forms.Splitter();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.pnlSQLTest = new System.Windows.Forms.Panel();
            this.lblQueryComment = new System.Windows.Forms.Label();
            this.lblQueryDesc = new System.Windows.Forms.Label();
            this.btnSQLTest = new System.Windows.Forms.Button();
            this.grbGeneral = new System.Windows.Forms.GroupBox();
            this.chkUseSql = new System.Windows.Forms.CheckBox();
            this.chkSecFlag = new System.Windows.Forms.CheckBox();
            this.cdvTblGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblTblGroup = new System.Windows.Forms.Label();
            this.chkCentral = new System.Windows.Forms.CheckBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.lblCreate = new System.Windows.Forms.Label();
            this.chkSysFlag = new System.Windows.Forms.CheckBox();
            this.cboTblType = new System.Windows.Forms.ComboBox();
            this.lblTblType = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.tbpCopy = new System.Windows.Forms.TabPage();
            this.grpCopyTable = new System.Windows.Forms.GroupBox();
            this.cdvFromTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFromTable = new System.Windows.Forms.Label();
            this.cdvFromFactory = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblFromFactory = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblToFlow = new System.Windows.Forms.Label();
            this.txtToTable = new System.Windows.Forms.TextBox();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.grbExportCenter = new System.Windows.Forms.GroupBox();
            this.txtExport = new System.Windows.Forms.RichTextBox();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.grpExport = new System.Windows.Forms.GroupBox();
            this.chkIncludeData = new System.Windows.Forms.CheckBox();
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
            this.cdvTableList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grbTable.SuspendLayout();
            this.pnlRightBottom.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.pnlGeneralFill.SuspendLayout();
            this.tabData.SuspendLayout();
            this.tbpField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTable_Sheet1)).BeginInit();
            this.tbpQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).BeginInit();
            this.pnlSQLTest.SuspendLayout();
            this.grbGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTblGroup)).BeginInit();
            this.tbpCopy.SuspendLayout();
            this.grpCopyTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromFactory)).BeginInit();
            this.tabExport.SuspendLayout();
            this.grbExportCenter.SuspendLayout();
            this.grpExport.SuspendLayout();
            this.grpTblGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).BeginInit();
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
            this.pnlRight.Controls.Add(this.pnlRightBottom);
            this.pnlRight.Controls.Add(this.grbTable);
            this.pnlRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
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
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            this.pnlBottom.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnUpdate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnCreate, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlFind, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnHistory, 0);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "General Code Table Setup";
            columnHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer1.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer1.Name = "columnHeaderRenderer1";
            columnHeaderRenderer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer1.TextRotationAngle = 0D;
            rowHeaderRenderer1.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
            columnHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            columnHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            columnHeaderRenderer3.Name = "columnHeaderRenderer3";
            columnHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            columnHeaderRenderer3.TextRotationAngle = 0D;
            rowHeaderRenderer3.BackColor = System.Drawing.SystemColors.Control;
            rowHeaderRenderer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            rowHeaderRenderer3.ForeColor = System.Drawing.SystemColors.ControlText;
            rowHeaderRenderer3.Name = "rowHeaderRenderer3";
            rowHeaderRenderer3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            rowHeaderRenderer3.TextRotationAngle = 0D;
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
            // grbTable
            // 
            this.grbTable.Controls.Add(this.txtDesc);
            this.grbTable.Controls.Add(this.lblDesc);
            this.grbTable.Controls.Add(this.txtTable);
            this.grbTable.Controls.Add(this.lblTable);
            this.grbTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbTable.Location = new System.Drawing.Point(3, 0);
            this.grbTable.Name = "grbTable";
            this.grbTable.Size = new System.Drawing.Size(500, 71);
            this.grbTable.TabIndex = 0;
            this.grbTable.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(120, 40);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(364, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(15, 43);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(120, 16);
            this.txtTable.MaxLength = 20;
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(200, 20);
            this.txtTable.TabIndex = 1;
            this.txtTable.LostFocus += new System.EventHandler(this.txtTable_LostFocus);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.Location = new System.Drawing.Point(15, 19);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(75, 13);
            this.lblTable.TabIndex = 0;
            this.lblTable.Text = "Table Name";
            this.lblTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRightBottom
            // 
            this.pnlRightBottom.Controls.Add(this.tabTable);
            this.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightBottom.Location = new System.Drawing.Point(3, 71);
            this.pnlRightBottom.Name = "pnlRightBottom";
            this.pnlRightBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlRightBottom.Size = new System.Drawing.Size(500, 439);
            this.pnlRightBottom.TabIndex = 1;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.tbpGeneral);
            this.tabTable.Controls.Add(this.tbpCopy);
            this.tabTable.Controls.Add(this.tabExport);
            this.tabTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTable.ItemSize = new System.Drawing.Size(60, 18);
            this.tabTable.Location = new System.Drawing.Point(0, 5);
            this.tabTable.Name = "tabTable";
            this.tabTable.SelectedIndex = 0;
            this.tabTable.Size = new System.Drawing.Size(500, 434);
            this.tabTable.TabIndex = 0;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pnlGeneralFill);
            this.tbpGeneral.Controls.Add(this.grbGeneral);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpGeneral.Size = new System.Drawing.Size(492, 408);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            // 
            // pnlGeneralFill
            // 
            this.pnlGeneralFill.Controls.Add(this.tabData);
            this.pnlGeneralFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeneralFill.Location = new System.Drawing.Point(3, 158);
            this.pnlGeneralFill.Name = "pnlGeneralFill";
            this.pnlGeneralFill.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.pnlGeneralFill.Size = new System.Drawing.Size(486, 247);
            this.pnlGeneralFill.TabIndex = 1;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.tbpField);
            this.tabData.Controls.Add(this.tbpQuery);
            this.tabData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabData.Location = new System.Drawing.Point(0, 3);
            this.tabData.Name = "tabData";
            this.tabData.SelectedIndex = 0;
            this.tabData.Size = new System.Drawing.Size(486, 244);
            this.tabData.TabIndex = 1;
            // 
            // tbpField
            // 
            this.tbpField.Controls.Add(this.spdTable);
            this.tbpField.Location = new System.Drawing.Point(4, 22);
            this.tbpField.Name = "tbpField";
            this.tbpField.Padding = new System.Windows.Forms.Padding(3);
            this.tbpField.Size = new System.Drawing.Size(478, 218);
            this.tbpField.TabIndex = 0;
            this.tbpField.Text = "Field Prompt";
            // 
            // spdTable
            // 
            this.spdTable.AccessibleDescription = "spdTable, Sheet1, Row 0, Column 0, ";
            this.spdTable.BackColor = System.Drawing.SystemColors.Control;
            this.spdTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdTable.EditModePermanent = true;
            this.spdTable.EditModeReplace = true;
            this.spdTable.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spdTable.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdTable.HorizontalScrollBar.Name = "";
            this.spdTable.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdTable.HorizontalScrollBar.TabIndex = 12;
            this.spdTable.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdTable.Location = new System.Drawing.Point(3, 3);
            this.spdTable.Name = "spdTable";
            namedStyle5.BackColor = System.Drawing.SystemColors.Control;
            namedStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle5.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle5.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle5.Renderer = columnHeaderRenderer3;
            namedStyle5.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            namedStyle6.BackColor = System.Drawing.SystemColors.Control;
            namedStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            namedStyle6.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            namedStyle6.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle6.Renderer = rowHeaderRenderer3;
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
            this.spdTable.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle5,
            namedStyle6,
            namedStyle7,
            namedStyle8});
            this.spdTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spdTable.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdTable.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdTable.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdTable_Sheet1});
            this.spdTable.Size = new System.Drawing.Size(472, 212);
            this.spdTable.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdTable.TabIndex = 0;
            this.spdTable.TabStop = false;
            this.spdTable.TextTipDelay = 200;
            this.spdTable.TextTipPolicy = FarPoint.Win.Spread.TextTipPolicy.Floating;
            this.spdTable.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdTable.VerticalScrollBar.Name = "";
            this.spdTable.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdTable.VerticalScrollBar.TabIndex = 13;
            this.spdTable.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdTable.Change += new FarPoint.Win.Spread.ChangeEventHandler(this.spdTable_Change);
            this.spdTable.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdTable_ButtonClicked);
            this.spdTable.ComboCloseUp += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdTable_ComboCloseUp);
            // 
            // spdTable_Sheet1
            // 
            this.spdTable_Sheet1.Reset();
            spdTable_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdTable_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdTable_Sheet1.ColumnCount = 7;
            spdTable_Sheet1.RowCount = 20;
            this.spdTable_Sheet1.Cells.Get(0, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(0, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(0, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTable_Sheet1.Cells.Get(0, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(0, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(0, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(0, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(1, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(1, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(1, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(1, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(1, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(1, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(1, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(2, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(2, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(2, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(2, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(2, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(2, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(2, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(3, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(3, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(3, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(3, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(3, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(3, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(3, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(4, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(4, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(4, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(4, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(4, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(4, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(4, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(5, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(5, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(5, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(5, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(5, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(5, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(5, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(6, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(6, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(6, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(6, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(6, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(6, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(6, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(7, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(7, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(7, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(7, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(7, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(7, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(7, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(8, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(8, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(8, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(8, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(8, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(8, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(8, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(9, 0).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(9, 1).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(9, 2).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(9, 3).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(9, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(9, 5).BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.spdTable_Sheet1.Cells.Get(9, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(10, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(10, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(11, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(11, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(12, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(12, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(13, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(13, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(14, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(14, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(15, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(15, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(16, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(16, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(17, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(17, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(18, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(18, 5).Locked = true;
            this.spdTable_Sheet1.Cells.Get(19, 3).Locked = true;
            this.spdTable_Sheet1.Cells.Get(19, 5).Locked = true;
            this.spdTable_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTable_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdTable_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTable_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prompt";
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Format";
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Size";
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 3).ColumnSpan = 2;
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 3).Locked = false;
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "GCM Table";
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 5).ColumnSpan = 2;
            this.spdTable_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "GCM Column";
            this.spdTable_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTable_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdTable_Sheet1.ColumnHeader.Rows.Get(0).Height = 18F;
            textCellType4.MaxLength = 20;
            this.spdTable_Sheet1.Columns.Get(0).CellType = textCellType4;
            this.spdTable_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTable_Sheet1.Columns.Get(0).Label = "Prompt";
            this.spdTable_Sheet1.Columns.Get(0).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTable_Sheet1.Columns.Get(0).Width = 203F;
            comboBoxCellType2.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType2.Items = new string[] {
        "Ascii",
        "Number",
        "Float",
        "Table"};
            this.spdTable_Sheet1.Columns.Get(1).CellType = comboBoxCellType2;
            this.spdTable_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTable_Sheet1.Columns.Get(1).Label = "Format";
            this.spdTable_Sheet1.Columns.Get(1).Locked = false;
            this.spdTable_Sheet1.Columns.Get(1).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTable_Sheet1.Columns.Get(1).Width = 100F;
            numberCellType2.DecimalPlaces = 0;
            numberCellType2.MaximumValue = 4000D;
            numberCellType2.MinimumValue = 0D;
            this.spdTable_Sheet1.Columns.Get(2).CellType = numberCellType2;
            this.spdTable_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            this.spdTable_Sheet1.Columns.Get(2).Label = "Size";
            this.spdTable_Sheet1.Columns.Get(2).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTable_Sheet1.Columns.Get(2).Width = 89F;
            textCellType5.MaxLength = 20;
            this.spdTable_Sheet1.Columns.Get(3).CellType = textCellType5;
            this.spdTable_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTable_Sheet1.Columns.Get(3).Label = "GCM Table";
            this.spdTable_Sheet1.Columns.Get(3).Locked = false;
            this.spdTable_Sheet1.Columns.Get(3).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTable_Sheet1.Columns.Get(3).Width = 120F;
            buttonCellType3.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType3.Text = "...";
            this.spdTable_Sheet1.Columns.Get(4).CellType = buttonCellType3;
            this.spdTable_Sheet1.Columns.Get(4).Width = 23F;
            textCellType6.MaxLength = 20;
            this.spdTable_Sheet1.Columns.Get(5).CellType = textCellType6;
            this.spdTable_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.General;
            this.spdTable_Sheet1.Columns.Get(5).Label = "GCM Column";
            this.spdTable_Sheet1.Columns.Get(5).VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdTable_Sheet1.Columns.Get(5).Width = 120F;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.Text = "...";
            this.spdTable_Sheet1.Columns.Get(6).CellType = buttonCellType4;
            this.spdTable_Sheet1.Columns.Get(6).Width = 23F;
            this.spdTable_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            this.spdTable_Sheet1.RowHeader.Cells.Get(0, 0).Value = "Key 1";
            this.spdTable_Sheet1.RowHeader.Cells.Get(1, 0).Value = "Key 2";
            this.spdTable_Sheet1.RowHeader.Cells.Get(2, 0).Value = "Key 3";
            this.spdTable_Sheet1.RowHeader.Cells.Get(3, 0).Value = "Key 4";
            this.spdTable_Sheet1.RowHeader.Cells.Get(4, 0).Value = "Key 5";
            this.spdTable_Sheet1.RowHeader.Cells.Get(5, 0).Value = "Key 6";
            this.spdTable_Sheet1.RowHeader.Cells.Get(6, 0).Value = "Key 7";
            this.spdTable_Sheet1.RowHeader.Cells.Get(7, 0).Value = "Key 8";
            this.spdTable_Sheet1.RowHeader.Cells.Get(8, 0).Value = "Key 9";
            this.spdTable_Sheet1.RowHeader.Cells.Get(9, 0).Value = "Key 10";
            this.spdTable_Sheet1.RowHeader.Cells.Get(10, 0).Value = "Data 1";
            this.spdTable_Sheet1.RowHeader.Cells.Get(11, 0).Value = "Data 2";
            this.spdTable_Sheet1.RowHeader.Cells.Get(12, 0).Value = "Data 3";
            this.spdTable_Sheet1.RowHeader.Cells.Get(13, 0).Value = "Data 4";
            this.spdTable_Sheet1.RowHeader.Cells.Get(14, 0).Value = "Data 5";
            this.spdTable_Sheet1.RowHeader.Cells.Get(15, 0).Value = "Data 6";
            this.spdTable_Sheet1.RowHeader.Cells.Get(16, 0).Value = "Data 7";
            this.spdTable_Sheet1.RowHeader.Cells.Get(17, 0).Value = "Data 8";
            this.spdTable_Sheet1.RowHeader.Cells.Get(18, 0).Value = "Data 9";
            this.spdTable_Sheet1.RowHeader.Cells.Get(19, 0).Value = "Data 10";
            this.spdTable_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdTable_Sheet1.RowHeader.Columns.Get(0).Width = 59F;
            this.spdTable_Sheet1.RowHeader.DefaultStyle.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left;
            this.spdTable_Sheet1.RowHeader.DefaultStyle.Locked = false;
            this.spdTable_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTable_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdTable_Sheet1.Rows.Get(0).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(0).Label = "Key 1";
            this.spdTable_Sheet1.Rows.Get(1).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(1).Label = "Key 2";
            this.spdTable_Sheet1.Rows.Get(2).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(2).Label = "Key 3";
            this.spdTable_Sheet1.Rows.Get(3).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(3).Label = "Key 4";
            this.spdTable_Sheet1.Rows.Get(4).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(4).Label = "Key 5";
            this.spdTable_Sheet1.Rows.Get(5).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(5).Label = "Key 6";
            this.spdTable_Sheet1.Rows.Get(6).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(6).Label = "Key 7";
            this.spdTable_Sheet1.Rows.Get(7).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(7).Label = "Key 8";
            this.spdTable_Sheet1.Rows.Get(8).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(8).Label = "Key 9";
            this.spdTable_Sheet1.Rows.Get(9).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(9).Label = "Key 10";
            this.spdTable_Sheet1.Rows.Get(10).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(10).Label = "Data 1";
            this.spdTable_Sheet1.Rows.Get(11).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(11).Label = "Data 2";
            this.spdTable_Sheet1.Rows.Get(12).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(12).Label = "Data 3";
            this.spdTable_Sheet1.Rows.Get(13).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(13).Label = "Data 4";
            this.spdTable_Sheet1.Rows.Get(14).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(14).Label = "Data 5";
            this.spdTable_Sheet1.Rows.Get(15).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(15).Label = "Data 6";
            this.spdTable_Sheet1.Rows.Get(16).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(16).Label = "Data 7";
            this.spdTable_Sheet1.Rows.Get(17).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(17).Label = "Data 8";
            this.spdTable_Sheet1.Rows.Get(18).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(18).Label = "Data 9";
            this.spdTable_Sheet1.Rows.Get(19).Height = 18F;
            this.spdTable_Sheet1.Rows.Get(19).Label = "Data 10";
            this.spdTable_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdTable_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdTable_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // tbpQuery
            // 
            this.tbpQuery.Controls.Add(this.spdData);
            this.tbpQuery.Controls.Add(this.splSQL);
            this.tbpQuery.Controls.Add(this.txtQuery);
            this.tbpQuery.Controls.Add(this.pnlSQLTest);
            this.tbpQuery.Location = new System.Drawing.Point(4, 22);
            this.tbpQuery.Name = "tbpQuery";
            this.tbpQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tbpQuery.Size = new System.Drawing.Size(478, 218);
            this.tbpQuery.TabIndex = 1;
            this.tbpQuery.Text = "SQL Query";
            // 
            // spdData
            // 
            this.spdData.AccessibleDescription = "spdData, Sheet1, Row 0, Column 0, ";
            this.spdData.BackColor = System.Drawing.Color.Transparent;
            this.spdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdData.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdData.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdData.HorizontalScrollBar.Name = "";
            this.spdData.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdData.HorizontalScrollBar.TabIndex = 2;
            this.spdData.Location = new System.Drawing.Point(3, 65);
            this.spdData.Name = "spdData";
            this.spdData.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Both;
            this.spdData.ScrollTipPolicy = FarPoint.Win.Spread.ScrollTipPolicy.Both;
            this.spdData.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdData_Sheet1});
            this.spdData.Size = new System.Drawing.Size(472, 104);
            this.spdData.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdData.TabIndex = 4;
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
            // splSQL
            // 
            this.splSQL.Dock = System.Windows.Forms.DockStyle.Top;
            this.splSQL.Location = new System.Drawing.Point(3, 62);
            this.splSQL.Name = "splSQL";
            this.splSQL.Size = new System.Drawing.Size(472, 3);
            this.splSQL.TabIndex = 3;
            this.splSQL.TabStop = false;
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtQuery.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.txtQuery.Location = new System.Drawing.Point(3, 3);
            this.txtQuery.MaxLength = 15000;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(472, 59);
            this.txtQuery.TabIndex = 2;
            this.txtQuery.Text = "";
            this.txtQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuery_KeyPress);
            this.txtQuery.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQuery_KeyUp);
            // 
            // pnlSQLTest
            // 
            this.pnlSQLTest.Controls.Add(this.lblQueryComment);
            this.pnlSQLTest.Controls.Add(this.lblQueryDesc);
            this.pnlSQLTest.Controls.Add(this.btnSQLTest);
            this.pnlSQLTest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSQLTest.Location = new System.Drawing.Point(3, 169);
            this.pnlSQLTest.Name = "pnlSQLTest";
            this.pnlSQLTest.Size = new System.Drawing.Size(472, 46);
            this.pnlSQLTest.TabIndex = 1;
            // 
            // lblQueryComment
            // 
            this.lblQueryComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQueryComment.AutoSize = true;
            this.lblQueryComment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQueryComment.Location = new System.Drawing.Point(277, 3);
            this.lblQueryComment.Name = "lblQueryComment";
            this.lblQueryComment.Size = new System.Drawing.Size(192, 13);
            this.lblQueryComment.TabIndex = 21;
            this.lblQueryComment.Text = "It displays up to 10 rows of query result.";
            // 
            // lblQueryDesc
            // 
            this.lblQueryDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblQueryDesc.Location = new System.Drawing.Point(8, 3);
            this.lblQueryDesc.Name = "lblQueryDesc";
            this.lblQueryDesc.Size = new System.Drawing.Size(358, 46);
            this.lblQueryDesc.TabIndex = 20;
            this.lblQueryDesc.Text = "Where Clause Information :\r\n$FACTORY - Current factory name to be inputted as an " +
    "argument\r\n$1, $2, $3 ...- Argument to be inputted when using a query\r\n";
            // 
            // btnSQLTest
            // 
            this.btnSQLTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSQLTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSQLTest.Location = new System.Drawing.Point(379, 19);
            this.btnSQLTest.Name = "btnSQLTest";
            this.btnSQLTest.Size = new System.Drawing.Size(88, 26);
            this.btnSQLTest.TabIndex = 1;
            this.btnSQLTest.Text = "SQL Test";
            this.btnSQLTest.Click += new System.EventHandler(this.btnSQLTest_Click);
            // 
            // grbGeneral
            // 
            this.grbGeneral.Controls.Add(this.chkUseSql);
            this.grbGeneral.Controls.Add(this.chkSecFlag);
            this.grbGeneral.Controls.Add(this.cdvTblGroup);
            this.grbGeneral.Controls.Add(this.lblTblGroup);
            this.grbGeneral.Controls.Add(this.chkCentral);
            this.grbGeneral.Controls.Add(this.txtUpdateTime);
            this.grbGeneral.Controls.Add(this.txtCreateTime);
            this.grbGeneral.Controls.Add(this.txtUpdateUser);
            this.grbGeneral.Controls.Add(this.lblUpdate);
            this.grbGeneral.Controls.Add(this.txtCreateUser);
            this.grbGeneral.Controls.Add(this.lblCreate);
            this.grbGeneral.Controls.Add(this.chkSysFlag);
            this.grbGeneral.Controls.Add(this.cboTblType);
            this.grbGeneral.Controls.Add(this.lblTblType);
            this.grbGeneral.Controls.Add(this.txtPwd);
            this.grbGeneral.Controls.Add(this.lblPwd);
            this.grbGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbGeneral.Location = new System.Drawing.Point(3, 0);
            this.grbGeneral.Name = "grbGeneral";
            this.grbGeneral.Size = new System.Drawing.Size(486, 158);
            this.grbGeneral.TabIndex = 0;
            this.grbGeneral.TabStop = false;
            // 
            // chkUseSql
            // 
            this.chkUseSql.AutoSize = true;
            this.chkUseSql.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkUseSql.Location = new System.Drawing.Point(312, 90);
            this.chkUseSql.Name = "chkUseSql";
            this.chkUseSql.Size = new System.Drawing.Size(132, 18);
            this.chkUseSql.TabIndex = 15;
            this.chkUseSql.Text = "Use SQL Query Data";
            this.chkUseSql.CheckedChanged += new System.EventHandler(this.chkUseSql_CheckedChanged);
            // 
            // chkSecFlag
            // 
            this.chkSecFlag.AutoSize = true;
            this.chkSecFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSecFlag.Location = new System.Drawing.Point(312, 68);
            this.chkSecFlag.Name = "chkSecFlag";
            this.chkSecFlag.Size = new System.Drawing.Size(134, 18);
            this.chkSecFlag.TabIndex = 8;
            this.chkSecFlag.Text = "Check Security Table";
            // 
            // cdvTblGroup
            // 
            this.cdvTblGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTblGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTblGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTblGroup.BtnToolTipText = "";
            this.cdvTblGroup.ButtonWidth = 20;
            this.cdvTblGroup.DescText = "";
            this.cdvTblGroup.DisplaySubItemIndex = -1;
            this.cdvTblGroup.DisplayText = "";
            this.cdvTblGroup.Focusing = null;
            this.cdvTblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTblGroup.Index = 0;
            this.cdvTblGroup.IsViewBtnImage = false;
            this.cdvTblGroup.Location = new System.Drawing.Point(120, 16);
            this.cdvTblGroup.MaxLength = 20;
            this.cdvTblGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvTblGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvTblGroup.MultiSelect = false;
            this.cdvTblGroup.Name = "cdvTblGroup";
            this.cdvTblGroup.ReadOnly = true;
            this.cdvTblGroup.SameWidthHeightOfButton = false;
            this.cdvTblGroup.SearchSubItemIndex = 0;
            this.cdvTblGroup.SelectedDescIndex = -1;
            this.cdvTblGroup.SelectedDescToQueryText = "";
            this.cdvTblGroup.SelectedSubItemIndex = -1;
            this.cdvTblGroup.SelectedValueToQueryText = "";
            this.cdvTblGroup.SelectionStart = 0;
            this.cdvTblGroup.Size = new System.Drawing.Size(177, 20);
            this.cdvTblGroup.SmallImageList = null;
            this.cdvTblGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTblGroup.TabIndex = 1;
            this.cdvTblGroup.TextBoxToolTipText = "";
            this.cdvTblGroup.TextBoxWidth = 177;
            this.cdvTblGroup.VisibleButton = true;
            this.cdvTblGroup.VisibleColumnHeader = false;
            this.cdvTblGroup.VisibleDescription = false;
            this.cdvTblGroup.ButtonPress += new System.EventHandler(this.cdvTblGroup_ButtonPress);
            // 
            // lblTblGroup
            // 
            this.lblTblGroup.AutoSize = true;
            this.lblTblGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTblGroup.Location = new System.Drawing.Point(15, 19);
            this.lblTblGroup.Name = "lblTblGroup";
            this.lblTblGroup.Size = new System.Drawing.Size(66, 13);
            this.lblTblGroup.TabIndex = 0;
            this.lblTblGroup.Text = "Table Group";
            this.lblTblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkCentral
            // 
            this.chkCentral.AutoSize = true;
            this.chkCentral.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkCentral.Location = new System.Drawing.Point(312, 19);
            this.chkCentral.Name = "chkCentral";
            this.chkCentral.Size = new System.Drawing.Size(88, 18);
            this.chkCentral.TabIndex = 2;
            this.chkCentral.Text = "Central Flag";
            this.chkCentral.CheckedChanged += new System.EventHandler(this.chkCentral_CheckedChanged);
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(305, 133);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(174, 20);
            this.txtUpdateTime.TabIndex = 14;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(305, 109);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(174, 20);
            this.txtCreateTime.TabIndex = 11;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(120, 133);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(177, 20);
            this.txtUpdateUser.TabIndex = 13;
            this.txtUpdateUser.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdate.Location = new System.Drawing.Point(15, 136);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(95, 13);
            this.lblUpdate.TabIndex = 12;
            this.lblUpdate.Text = "Update User/Time";
            this.lblUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(120, 109);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(177, 20);
            this.txtCreateUser.TabIndex = 10;
            this.txtCreateUser.TabStop = false;
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreate.Location = new System.Drawing.Point(15, 112);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(91, 13);
            this.lblCreate.TabIndex = 9;
            this.lblCreate.Text = "Create User/Time";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSysFlag
            // 
            this.chkSysFlag.AutoSize = true;
            this.chkSysFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSysFlag.Location = new System.Drawing.Point(312, 43);
            this.chkSysFlag.Name = "chkSysFlag";
            this.chkSysFlag.Size = new System.Drawing.Size(119, 18);
            this.chkSysFlag.TabIndex = 5;
            this.chkSysFlag.Text = "System Table Flag";
            // 
            // cboTblType
            // 
            this.cboTblType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTblType.Items.AddRange(new object[] {
            "General Table",
            "Extended Table",
            "Large Data Table"});
            this.cboTblType.Location = new System.Drawing.Point(120, 40);
            this.cboTblType.Name = "cboTblType";
            this.cboTblType.Size = new System.Drawing.Size(177, 21);
            this.cboTblType.TabIndex = 4;
            this.cboTblType.SelectedIndexChanged += new System.EventHandler(this.cboTblType_SelectedIndexChanged);
            // 
            // lblTblType
            // 
            this.lblTblType.AutoSize = true;
            this.lblTblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTblType.Location = new System.Drawing.Point(15, 43);
            this.lblTblType.Name = "lblTblType";
            this.lblTblType.Size = new System.Drawing.Size(61, 13);
            this.lblTblType.TabIndex = 3;
            this.lblTblType.Text = "Table Type";
            this.lblTblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPwd
            // 
            this.txtPwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPwd.Location = new System.Drawing.Point(120, 65);
            this.txtPwd.MaxLength = 20;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(177, 20);
            this.txtPwd.TabIndex = 7;
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPwd.Location = new System.Drawing.Point(15, 68);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(53, 13);
            this.lblPwd.TabIndex = 6;
            this.lblPwd.Text = "Password";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbpCopy
            // 
            this.tbpCopy.Controls.Add(this.grpCopyTable);
            this.tbpCopy.Location = new System.Drawing.Point(4, 22);
            this.tbpCopy.Name = "tbpCopy";
            this.tbpCopy.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tbpCopy.Size = new System.Drawing.Size(492, 408);
            this.tbpCopy.TabIndex = 1;
            this.tbpCopy.Text = "Copy Table";
            // 
            // grpCopyTable
            // 
            this.grpCopyTable.Controls.Add(this.cdvFromTable);
            this.grpCopyTable.Controls.Add(this.lblFromTable);
            this.grpCopyTable.Controls.Add(this.cdvFromFactory);
            this.grpCopyTable.Controls.Add(this.lblFromFactory);
            this.grpCopyTable.Controls.Add(this.btnCopy);
            this.grpCopyTable.Controls.Add(this.lblToFlow);
            this.grpCopyTable.Controls.Add(this.txtToTable);
            this.grpCopyTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCopyTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCopyTable.Location = new System.Drawing.Point(3, 0);
            this.grpCopyTable.Name = "grpCopyTable";
            this.grpCopyTable.Size = new System.Drawing.Size(486, 99);
            this.grpCopyTable.TabIndex = 0;
            this.grpCopyTable.TabStop = false;
            // 
            // cdvFromTable
            // 
            this.cdvFromTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFromTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFromTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFromTable.BtnToolTipText = "";
            this.cdvFromTable.ButtonWidth = 20;
            this.cdvFromTable.DescText = "";
            this.cdvFromTable.DisplaySubItemIndex = 0;
            this.cdvFromTable.DisplayText = "";
            this.cdvFromTable.Focusing = null;
            this.cdvFromTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFromTable.Index = 0;
            this.cdvFromTable.IsViewBtnImage = false;
            this.cdvFromTable.Location = new System.Drawing.Point(120, 42);
            this.cdvFromTable.MaxLength = 20;
            this.cdvFromTable.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFromTable.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFromTable.MultiSelect = false;
            this.cdvFromTable.Name = "cdvFromTable";
            this.cdvFromTable.ReadOnly = false;
            this.cdvFromTable.SameWidthHeightOfButton = false;
            this.cdvFromTable.SearchSubItemIndex = 0;
            this.cdvFromTable.SelectedDescIndex = -1;
            this.cdvFromTable.SelectedDescToQueryText = "";
            this.cdvFromTable.SelectedSubItemIndex = 0;
            this.cdvFromTable.SelectedValueToQueryText = "";
            this.cdvFromTable.SelectionStart = 0;
            this.cdvFromTable.Size = new System.Drawing.Size(177, 20);
            this.cdvFromTable.SmallImageList = null;
            this.cdvFromTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFromTable.TabIndex = 1;
            this.cdvFromTable.TextBoxToolTipText = "";
            this.cdvFromTable.TextBoxWidth = 177;
            this.cdvFromTable.VisibleButton = true;
            this.cdvFromTable.VisibleColumnHeader = false;
            this.cdvFromTable.VisibleDescription = false;
            this.cdvFromTable.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFromTable_SelectedItemChanged);
            this.cdvFromTable.ButtonPress += new System.EventHandler(this.cdvFromTable_ButtonPress);
            // 
            // lblFromTable
            // 
            this.lblFromTable.AutoSize = true;
            this.lblFromTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromTable.Location = new System.Drawing.Point(15, 45);
            this.lblFromTable.Name = "lblFromTable";
            this.lblFromTable.Size = new System.Drawing.Size(60, 13);
            this.lblFromTable.TabIndex = 2;
            this.lblFromTable.Text = "From Table";
            this.lblFromTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdvFromFactory
            // 
            this.cdvFromFactory.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvFromFactory.BorderHotColor = System.Drawing.Color.Black;
            this.cdvFromFactory.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvFromFactory.BtnToolTipText = "";
            this.cdvFromFactory.ButtonWidth = 20;
            this.cdvFromFactory.DescText = "";
            this.cdvFromFactory.DisplaySubItemIndex = 0;
            this.cdvFromFactory.DisplayText = "";
            this.cdvFromFactory.Focusing = null;
            this.cdvFromFactory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvFromFactory.Index = 0;
            this.cdvFromFactory.IsViewBtnImage = false;
            this.cdvFromFactory.Location = new System.Drawing.Point(120, 16);
            this.cdvFromFactory.MaxLength = 10;
            this.cdvFromFactory.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvFromFactory.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvFromFactory.MultiSelect = false;
            this.cdvFromFactory.Name = "cdvFromFactory";
            this.cdvFromFactory.ReadOnly = false;
            this.cdvFromFactory.SameWidthHeightOfButton = false;
            this.cdvFromFactory.SearchSubItemIndex = 0;
            this.cdvFromFactory.SelectedDescIndex = -1;
            this.cdvFromFactory.SelectedDescToQueryText = "";
            this.cdvFromFactory.SelectedSubItemIndex = 0;
            this.cdvFromFactory.SelectedValueToQueryText = "";
            this.cdvFromFactory.SelectionStart = 0;
            this.cdvFromFactory.Size = new System.Drawing.Size(177, 20);
            this.cdvFromFactory.SmallImageList = null;
            this.cdvFromFactory.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvFromFactory.TabIndex = 0;
            this.cdvFromFactory.TextBoxToolTipText = "";
            this.cdvFromFactory.TextBoxWidth = 177;
            this.cdvFromFactory.VisibleButton = true;
            this.cdvFromFactory.VisibleColumnHeader = false;
            this.cdvFromFactory.VisibleDescription = false;
            this.cdvFromFactory.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvFromFactory_SelectedItemChanged);
            this.cdvFromFactory.ButtonPress += new System.EventHandler(this.cdvFromFactory_ButtonPress);
            // 
            // lblFromFactory
            // 
            this.lblFromFactory.AutoSize = true;
            this.lblFromFactory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFromFactory.Location = new System.Drawing.Point(15, 19);
            this.lblFromFactory.Name = "lblFromFactory";
            this.lblFromFactory.Size = new System.Drawing.Size(68, 13);
            this.lblFromFactory.TabIndex = 0;
            this.lblFromFactory.Text = "From Factory";
            this.lblFromFactory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(318, 67);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 23);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblToFlow
            // 
            this.lblToFlow.AutoSize = true;
            this.lblToFlow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblToFlow.Location = new System.Drawing.Point(15, 71);
            this.lblToFlow.Name = "lblToFlow";
            this.lblToFlow.Size = new System.Drawing.Size(50, 13);
            this.lblToFlow.TabIndex = 4;
            this.lblToFlow.Text = "To Table";
            this.lblToFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToTable
            // 
            this.txtToTable.Location = new System.Drawing.Point(120, 68);
            this.txtToTable.MaxLength = 20;
            this.txtToTable.Name = "txtToTable";
            this.txtToTable.Size = new System.Drawing.Size(177, 20);
            this.txtToTable.TabIndex = 2;
            // 
            // tabExport
            // 
            this.tabExport.BackColor = System.Drawing.SystemColors.Control;
            this.tabExport.Controls.Add(this.grbExportCenter);
            this.tabExport.Controls.Add(this.grpExport);
            this.tabExport.Location = new System.Drawing.Point(4, 22);
            this.tabExport.Name = "tabExport";
            this.tabExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabExport.Size = new System.Drawing.Size(492, 408);
            this.tabExport.TabIndex = 2;
            this.tabExport.Text = "Export";
            // 
            // grbExportCenter
            // 
            this.grbExportCenter.Controls.Add(this.txtExport);
            this.grbExportCenter.Controls.Add(this.progressBarExport);
            this.grbExportCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbExportCenter.Location = new System.Drawing.Point(3, 103);
            this.grbExportCenter.Name = "grbExportCenter";
            this.grbExportCenter.Size = new System.Drawing.Size(486, 302);
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
            this.txtExport.Size = new System.Drawing.Size(480, 260);
            this.txtExport.TabIndex = 10;
            this.txtExport.Text = "";
            this.txtExport.WordWrap = false;
            // 
            // progressBarExport
            // 
            this.progressBarExport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarExport.Location = new System.Drawing.Point(3, 276);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(480, 23);
            this.progressBarExport.TabIndex = 11;
            // 
            // grpExport
            // 
            this.grpExport.Controls.Add(this.chkIncludeData);
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
            // chkIncludeData
            // 
            this.chkIncludeData.AutoSize = true;
            this.chkIncludeData.Location = new System.Drawing.Point(391, 19);
            this.chkIncludeData.Name = "chkIncludeData";
            this.chkIncludeData.Size = new System.Drawing.Size(87, 17);
            this.chkIncludeData.TabIndex = 3;
            this.chkIncludeData.Text = "Include Data";
            this.chkIncludeData.UseVisualStyleBackColor = true;
            // 
            // chkMigration
            // 
            this.chkMigration.AutoSize = true;
            this.chkMigration.Location = new System.Drawing.Point(281, 19);
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
            this.txtExpFile.TabIndex = 5;
            // 
            // btnExpFile
            // 
            this.btnExpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpFile.Location = new System.Drawing.Point(456, 40);
            this.btnExpFile.Name = "btnExpFile";
            this.btnExpFile.Size = new System.Drawing.Size(21, 21);
            this.btnExpFile.TabIndex = 6;
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
            this.lblExpFile.TabIndex = 4;
            this.lblExpFile.Text = "Export File";
            // 
            // btnExpCopy
            // 
            this.btnExpCopy.Location = new System.Drawing.Point(287, 68);
            this.btnExpCopy.Name = "btnExpCopy";
            this.btnExpCopy.Size = new System.Drawing.Size(75, 23);
            this.btnExpCopy.TabIndex = 9;
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
            this.btnExpStop.TabIndex = 8;
            this.btnExpStop.Text = "Stop";
            this.btnExpStop.Click += new System.EventHandler(this.btnExpStop_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(113, 68);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 7;
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
            this.cdvGroup.ButtonPress += new System.EventHandler(this.cdvTblGroup_ButtonPress);
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
            // cdvTableList
            // 
            this.cdvTableList.BackColor = System.Drawing.SystemColors.Control;
            this.cdvTableList.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTableList.Location = new System.Drawing.Point(0, 0);
            this.cdvTableList.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTableList.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTableList.Name = "MCSPCodeView";
            this.cdvTableList.Size = new System.Drawing.Size(20, 20);
            this.cdvTableList.SmallImageList = null;
            this.cdvTableList.TabIndex = 0;
            this.cdvTableList.ViewPosition = new System.Drawing.Point(0, 0);
            this.cdvTableList.VisibleColumnHeader = false;
            this.cdvTableList.SelectedItemChanged += new Miracom.UI.MCSSCodeViewSelChangedHandler(this.cdvTableList_SelectedItemChanged);
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(238, 7);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(88, 26);
            this.btnHistory.TabIndex = 5;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // frmBASSetupGeneralCodeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmBASSetupGeneralCodeTable";
            this.Text = "General Code Table Setup";
            this.Activated += new System.EventHandler(this.frmBASSetupGeneralCodeTable_Activated);
            this.Load += new System.EventHandler(this.frmBASSetupGeneralCodeTable_Load);
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
            this.grbTable.ResumeLayout(false);
            this.grbTable.PerformLayout();
            this.pnlRightBottom.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.pnlGeneralFill.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tbpField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdTable_Sheet1)).EndInit();
            this.tbpQuery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdData_Sheet1)).EndInit();
            this.pnlSQLTest.ResumeLayout(false);
            this.pnlSQLTest.PerformLayout();
            this.grbGeneral.ResumeLayout(false);
            this.grbGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTblGroup)).EndInit();
            this.tbpCopy.ResumeLayout(false);
            this.grpCopyTable.ResumeLayout(false);
            this.grpCopyTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvFromFactory)).EndInit();
            this.tabExport.ResumeLayout(false);
            this.grbExportCenter.ResumeLayout(false);
            this.grpExport.ResumeLayout(false);
            this.grpExport.PerformLayout();
            this.grpTblGroup.ResumeLayout(false);
            this.grpTblGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTableList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "

        private const string GCM_TBL_DAT = "MGCMTBLDAT";
        private const string GCM_TBL_LAG = "MGCMLAGDAT";

        #endregion

        #region " Variable Definition "

        private bool b_load_flag;
        private bool b_export_stop = false;
        #endregion

        #region " Function Definition "

        //
        // ClearData()
        //       - Initialize form fields
        // Return Value
        //       -
        // Arguments
        //       - Optional ByVal ProcStep As String ("1", "2", "3")
        //
        private void ClearData(char ProcStep)
        {
            try
            {
                if (ProcStep == '1')
                {
                    txtTable.Text = "";
                    txtDesc.Text = "";
                    txtPwd.Text = "";
                    cboTblType.SelectedIndex = -1;
                    txtCreateUser.Text = "";
                    txtCreateTime.Text = "";
                    txtUpdateUser.Text = "";
                    txtUpdateTime.Text = "";
                    chkSysFlag.Checked = false;
                    chkCentral.Checked = false;
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    //spdTable.ActiveSheet.ClearRange(0, 0, 20, 3, true);
                    spdTable.ActiveSheet.ClearRange(0, 0, 20, 7, true);
                    /*** End of Modification (2012.04.04) ***/
                }
                else if (ProcStep == '2')
                {
                    lisTable.Items.Clear();
                }
                else if (ProcStep == '3')
                {
                    txtCreateUser.Text = "";
                    txtCreateTime.Text = "";
                    txtUpdateUser.Text = "";
                    txtUpdateTime.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }

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
            int iCount = 0;
            switch (FuncName)
            {
                case "UPDATE_TABLE":

                    if (txtTable.Text == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        txtTable.Select();
                        return false;
                    }

                    // Table type Validation Added by ICBAE 20100429
                    if (MPCF.Trim(cboTblType.Text) == "")
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                        cboTblType.Focus();
                        return false;
                    }

                    switch (ProcStep)
                    {
                        case MPGC.MP_STEP_CREATE:
                            if (MPCF.Trim(spdTable.ActiveSheet.Cells[0, 0].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdTable.Select();
                                return false;
                            }
                            if (MPCF.Trim(spdTable.ActiveSheet.Cells[0, 1].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdTable.Select();
                                return false;
                            }
                            for (i = 0; i <= spdTable.ActiveSheet.RowCount - 1; i++)
                            {
                                if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) != "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 1].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdTable.Select();
                                    return false;
                                }
                                else if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) != "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 2].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdTable.Select();
                                    return false;
                                }
                                else if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) == "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 1].Value) != "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdTable.Select();
                                    return false;
                                }
                                else if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) == "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 2].Value) != "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdTable.Select();
                                    return false;
                                }
                                else if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) != "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 1].Value) != "")
                                {
                                    if (chkUseSql.Checked == false)
                                    {
                                        if (cboTblType.Text.Substring(0, 1) == "L")
                                        {
                                            if (i < 10)
                                            {
                                                if (MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) <= 0 || MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) > 100)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(310));
                                                    spdTable.Select();
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                if (MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) <= 0 || MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) > 1000)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(311));
                                                    spdTable.Select();
                                                    return false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (i < 10)
                                            {
                                                if (MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) <= 0 || MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) > 30)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(130));
                                                    spdTable.Select();
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                if (MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) <= 0 || MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) > 50)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(131));
                                                    spdTable.Select();
                                                    return false;
                                                }
                                            }
                                        }
                                    }
                                }

                                if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) != "")
                                {
                                    iCount += 1;
                                }

                                /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                                if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 1].Value) == "Table")
                                {
                                    if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 3].Value) == "" || MPCF.Trim(spdTable.ActiveSheet.Cells[i, 5].Value) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                        spdTable.Select();
                                        return false;
                                    }
                                }
                                /*** End of Add (2012.04.04) ***/
                            }
                            if (MPCF.Trim(txtQuery.Text) != "")
                            {
                                string sSqlQuery = MPCF.Trim(txtQuery.Text);
                                txtQuery.Text = sSqlQuery;

                                sSqlQuery = sSqlQuery.ToUpper();
                                if (sSqlQuery.Substring(0, 6) != "SELECT")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(362));
                                    return false;
                                }

                                //iStart = sSqlQuery.IndexOf("SELECT") + 6;
                                //iEnd = sSqlQuery.IndexOf("FROM");
                                //if (iStart > 0 && iEnd > 0)
                                //{
                                //    iFieldCount = sSqlQuery.Substring(iStart, iEnd - iStart).Split(',').Length;

                                //    if (iCount != iFieldCount)
                                //    {
                                //        MPCF.ShowMsgBox(MPCF.GetMessage(277));
                                //        return false;
                                //    }
                                //}
                            }
                            break;


                        case MPGC.MP_STEP_UPDATE:

                            if (MPCF.Trim(spdTable.ActiveSheet.Cells[0, 0].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdTable.Select();
                                return false;
                            }
                            if (MPCF.Trim(spdTable.ActiveSheet.Cells[0, 1].Value) == "")
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                spdTable.Select();
                                return false;
                            }
                            for (i = 0; i <= spdTable.ActiveSheet.RowCount - 1; i++)
                            {
                                if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) != "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 1].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdTable.Select();
                                    return false;
                                }
                                else if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) != "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 2].Value) == "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdTable.Select();
                                    return false;
                                }
                                else if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) == "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 1].Value) != "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdTable.Select();
                                    return false;
                                }
                                else if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) == "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 2].Value) != "")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                    spdTable.Select();
                                    return false;
                                }
                                else if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) != "" && MPCF.Trim(spdTable.ActiveSheet.Cells[i, 1].Value) != "")
                                {
                                    if (chkUseSql.Checked == false)
                                    {
                                        if (cboTblType.Text.Substring(0, 1) == "L")
                                        {
                                            if (i < 10)
                                            {
                                                if (MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) <= 0 || MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) > 100)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(310));
                                                    spdTable.Select();
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                if (MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) <= 0 || MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) > 1000)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(311));
                                                    spdTable.Select();
                                                    return false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (i < 10)
                                            {
                                                if (MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) <= 0 || MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) > 30)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(130));
                                                    spdTable.Select();
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                if (MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) <= 0 || MPCF.ToDbl(spdTable.ActiveSheet.Cells[i, 2].Value) > 50)
                                                {
                                                    MPCF.ShowMsgBox(MPCF.GetMessage(131));
                                                    spdTable.Select();
                                                    return false;
                                                }
                                            }
                                        }
                                    }
                                }

                                if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) != "")
                                {
                                    iCount += 1;
                                }

                                /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                                if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 1].Value) == "Table")
                                {
                                    if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 3].Value) == "" || MPCF.Trim(spdTable.ActiveSheet.Cells[i, 5].Value) == "")
                                    {
                                        MPCF.ShowMsgBox(MPCF.GetMessage(108));
                                        spdTable.Select();
                                        return false;
                                    }
                                }
                                /*** End of Add (2012.04.04) ***/
                            }
                            if (MPCF.Trim(txtQuery.Text) != "")
                            {
                                string sSqlQuery = MPCF.Trim(txtQuery.Text);
                                txtQuery.Text = sSqlQuery;

                                sSqlQuery = sSqlQuery.ToUpper();
                                if (sSqlQuery.Substring(0, 6) != "SELECT")
                                {
                                    MPCF.ShowMsgBox(MPCF.GetMessage(362));
                                    return false;
                                }

                                //iStart = sSqlQuery.IndexOf("SELECT") + 6;
                                //iEnd = sSqlQuery.IndexOf("FROM");
                                //if (iStart > 0 && iEnd > 0)
                                //{
                                //    iFieldCount = sSqlQuery.Substring(iStart, iEnd - iStart).Split(',').Length;

                                //    if (iCount != iFieldCount)
                                //    {
                                //        MPCF.ShowMsgBox(MPCF.GetMessage(277));
                                //        return false;
                                //    }
                                //}
                            }
                            break;

                        case MPGC.MP_STEP_DELETE:

                            break;

                    }
                    break;

                case "COPY_TABLE":

                    if (ProcStep == MPGC.MP_STEP_COPY)
                    {
                        if (cdvFromTable.Text == "")
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(108));
                            tabTable.SelectedIndex = 1;
                            cdvFromTable.Focus();
                            return false;
                        }
                        if (MPCF.CheckValue(txtToTable, 1) == false)
                        {
                            tabTable.SelectedIndex = 1;
                            return false;
                        }
                    }
                    else
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(129));
                        return false;
                    }
                    break;
                case "VIEW_TABLE":

                    break;

            }
            return true;
        }

        //
        // View_Table()
        //       - View General Code Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        private bool View_Table()
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_OUT");

            try
            {
                spdTable.SuspendLayout();
                ClearData('1');

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("TABLE_NAME", lisTable.SelectedItems[0].Text);

                if (MPCR.CallService("BAS", "BAS_View_Table", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtTable.Text = out_node.GetString("TABLE_NAME");
                txtDesc.Text = out_node.GetString("TABLE_DESC");

                if (out_node.GetChar("SYS_TBL_FLAG") == 'Y')
                {
                    chkSysFlag.Checked = true;
                }
                else
                {
                    chkSysFlag.Checked = false;
                }

                if (out_node.GetChar("CENTRAL_FLAG") == 'Y')
                {
                    chkCentral.Checked = true;
                }
                else
                {
                    chkCentral.Checked = false;
                }

                if (out_node.GetChar("SEC_CHK_FLAG") == 'Y')
                {
                    chkSecFlag.Checked = true;
                }
                else
                {
                    chkSecFlag.Checked = false;
                }

                if (out_node.GetChar("USE_SQL_FLAG") == 'Y')
                {
                    chkUseSql.Checked = true;
                    txtQuery.ReadOnly = false;
                    txtQuery.BackColor = System.Drawing.SystemColors.Window;
                    MPCR.ChangeControlEnabled(this, btnSQLTest, true);
                }
                else
                {
                    chkUseSql.Checked = false;
                    txtQuery.ReadOnly = true;
                    txtQuery.BackColor = System.Drawing.SystemColors.Control;
                    btnSQLTest.Enabled = false;
                }

                switch (out_node.GetChar("TABLE_TYPE"))
                {
                    case ' ': cboTblType.SelectedIndex = 0; break;
                    case 'E': cboTblType.SelectedIndex = 1; break;
                    case 'L': cboTblType.SelectedIndex = 2; break;
                }

                cdvTblGroup.Text = out_node.GetString("TABLE_GROUP");

                /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                spdTable.ActiveSheet.Cells[0, 3, spdTable.ActiveSheet.RowCount - 1, 3].Value = "";
                spdTable.ActiveSheet.Cells[0, 5, spdTable.ActiveSheet.RowCount - 1, 5].Value = "";
                spdTable.ActiveSheet.Cells[0, 2, spdTable.ActiveSheet.RowCount - 1, 2].Locked = false;
                /*** End of Add (2012.04.04) ***/

                spdTable.ActiveSheet.SetValue(0, 0, out_node.GetString("KEY_1_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[0, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[0, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(0, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_1_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[0, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[0, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[0, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[0, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[0, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[0, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(0, 2, out_node.GetInt("KEY_1_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(0, 3, out_node.GetString("KEY_1_TBL"));
                    spdTable.ActiveSheet.SetValue(0, 5, out_node.GetString("KEY_1_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(1, 0, out_node.GetString("KEY_2_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[1, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[1, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(1, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_2_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[1, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[1, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[1, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[1, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[1, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[1, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(1, 2, out_node.GetInt("KEY_2_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(1, 3, out_node.GetString("KEY_2_TBL"));
                    spdTable.ActiveSheet.SetValue(1, 5, out_node.GetString("KEY_2_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(2, 0, out_node.GetString("KEY_3_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[2, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[2, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(2, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_3_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[2, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[2, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[2, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[2, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[2, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[2, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(2, 2, out_node.GetInt("KEY_3_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(2, 3, out_node.GetString("KEY_3_TBL"));
                    spdTable.ActiveSheet.SetValue(2, 5, out_node.GetString("KEY_3_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(3, 0, out_node.GetString("KEY_4_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[3, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[3, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(3, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_4_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[3, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[3, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[3, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[3, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[3, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[3, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(3, 2, out_node.GetInt("KEY_4_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(3, 3, out_node.GetString("KEY_4_TBL"));
                    spdTable.ActiveSheet.SetValue(3, 5, out_node.GetString("KEY_4_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(4, 0, out_node.GetString("KEY_5_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[4, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[4, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(4, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_5_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[4, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[4, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[4, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[4, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[4, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[4, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(4, 2, out_node.GetInt("KEY_5_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(4, 3, out_node.GetString("KEY_5_TBL"));
                    spdTable.ActiveSheet.SetValue(4, 5, out_node.GetString("KEY_5_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(5, 0, out_node.GetString("KEY_6_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[5, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[5, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(5, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_6_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[5, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[5, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[5, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[5, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[5, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[5, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(5, 2, out_node.GetInt("KEY_6_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(5, 3, out_node.GetString("KEY_6_TBL"));
                    spdTable.ActiveSheet.SetValue(5, 5, out_node.GetString("KEY_6_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(6, 0, out_node.GetString("KEY_7_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[6, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[6, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(6, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_7_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[6, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[6, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[6, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[6, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[6, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[6, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(6, 2, out_node.GetInt("KEY_7_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(6, 3, out_node.GetString("KEY_7_TBL"));
                    spdTable.ActiveSheet.SetValue(6, 5, out_node.GetString("KEY_7_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(7, 0, out_node.GetString("KEY_8_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[7, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[7, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(7, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_8_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[7, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[7, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[7, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[7, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[7, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[7, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(7, 2, out_node.GetInt("KEY_8_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(7, 3, out_node.GetString("KEY_8_TBL"));
                    spdTable.ActiveSheet.SetValue(7, 5, out_node.GetString("KEY_8_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(8, 0, out_node.GetString("KEY_9_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[8, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[8, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(8, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_9_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[8, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[8, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[8, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[8, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[8, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[8, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(8, 2, out_node.GetInt("KEY_9_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(8, 3, out_node.GetString("KEY_9_TBL"));
                    spdTable.ActiveSheet.SetValue(8, 5, out_node.GetString("KEY_9_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(9, 0, out_node.GetString("KEY_10_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[9, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[9, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(9, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("KEY_10_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[9, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[9, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[9, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[9, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[9, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[9, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(9, 2, out_node.GetInt("KEY_10_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(9, 3, out_node.GetString("KEY_10_TBL"));
                    spdTable.ActiveSheet.SetValue(9, 5, out_node.GetString("KEY_10_COL"));
                    /*** End of Add (2012.04.04) ***/
                }



                spdTable.ActiveSheet.SetValue(10, 0, out_node.GetString("DATA_1_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[10, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[10, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(10, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_1_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[10, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[10, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[10, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[10, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[10, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[10, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(10, 2, out_node.GetInt("DATA_1_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(10, 3, out_node.GetString("DATA_1_TBL"));
                    spdTable.ActiveSheet.SetValue(10, 5, out_node.GetString("DATA_1_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(11, 0, out_node.GetString("DATA_2_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[11, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[11, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(11, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_2_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[11, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[11, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[11, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[11, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[11, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[11, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(11, 2, out_node.GetInt("DATA_2_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(11, 3, out_node.GetString("DATA_2_TBL"));
                    spdTable.ActiveSheet.SetValue(11, 5, out_node.GetString("DATA_2_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(12, 0, out_node.GetString("DATA_3_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[12, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[12, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(12, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_3_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[12, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[12, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[12, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[12, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[12, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[12, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(12, 2, out_node.GetInt("DATA_3_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(12, 3, out_node.GetString("DATA_3_TBL"));
                    spdTable.ActiveSheet.SetValue(12, 5, out_node.GetString("DATA_3_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(13, 0, out_node.GetString("DATA_4_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[13, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[13, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(13, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_4_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[13, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[13, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[13, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[13, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[13, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[13, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(13, 2, out_node.GetInt("DATA_4_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(13, 3, out_node.GetString("DATA_4_TBL"));
                    spdTable.ActiveSheet.SetValue(13, 5, out_node.GetString("DATA_4_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(14, 0, out_node.GetString("DATA_5_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[14, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[14, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(14, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_5_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[14, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[14, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[14, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[14, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[14, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[14, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(14, 2, out_node.GetInt("DATA_5_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(14, 3, out_node.GetString("DATA_5_TBL"));
                    spdTable.ActiveSheet.SetValue(14, 5, out_node.GetString("DATA_5_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(15, 0, out_node.GetString("DATA_6_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[15, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[15, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(15, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_6_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[15, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[15, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[15, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[15, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[15, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[15, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(15, 2, out_node.GetInt("DATA_6_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(15, 3, out_node.GetString("DATA_6_TBL"));
                    spdTable.ActiveSheet.SetValue(15, 5, out_node.GetString("DATA_6_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(16, 0, out_node.GetString("DATA_7_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[16, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[16, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(16, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_7_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[16, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[16, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[16, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[16, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[16, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[16, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(16, 2, out_node.GetInt("DATA_7_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(16, 3, out_node.GetString("DATA_7_TBL"));
                    spdTable.ActiveSheet.SetValue(16, 5, out_node.GetString("DATA_7_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(17, 0, out_node.GetString("DATA_8_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[17, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[17, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(17, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_8_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[17, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[17, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[17, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[17, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[17, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[17, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(17, 2, out_node.GetInt("DATA_8_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(17, 3, out_node.GetString("DATA_8_TBL"));
                    spdTable.ActiveSheet.SetValue(17, 5, out_node.GetString("DATA_8_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(18, 0, out_node.GetString("DATA_9_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[18, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[18, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(18, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_9_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[18, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[18, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[18, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[18, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[18, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[18, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(18, 2, out_node.GetInt("DATA_9_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(18, 3, out_node.GetString("DATA_9_TBL"));
                    spdTable.ActiveSheet.SetValue(18, 5, out_node.GetString("DATA_9_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                spdTable.ActiveSheet.SetValue(19, 0, out_node.GetString("DATA_10_PRT"));
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[19, 0].Value) == "")
                {
                    spdTable.ActiveSheet.Cells[19, 1].Value = "";
                    spdTable.ActiveSheet.SetValue(19, 2, "");
                }
                else
                {
                    switch (out_node.GetChar("DATA_10_FMT"))
                    {
                        case 'A':

                            spdTable.ActiveSheet.Cells[19, 1].Value = "Ascii";
                            break;
                        case 'N':

                            spdTable.ActiveSheet.Cells[19, 1].Value = "Number";
                            break;
                        case 'F':

                            spdTable.ActiveSheet.Cells[19, 1].Value = "Float";
                            break;
                        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                        case 'T':

                            spdTable.ActiveSheet.Cells[19, 1].Value = "Table";
                            spdTable.ActiveSheet.Cells[19, 2].Locked = true;
                            break;
                        /*** End of Add (2012.04.04) ***/
                        default:

                            spdTable.ActiveSheet.Cells[19, 1].Value = "";
                            break;
                    }
                    spdTable.ActiveSheet.SetValue(19, 2, out_node.GetInt("DATA_10_SIZE"));
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(19, 3, out_node.GetString("DATA_10_TBL"));
                    spdTable.ActiveSheet.SetValue(19, 5, out_node.GetString("DATA_10_COL"));
                    /*** End of Add (2012.04.04) ***/
                }

                txtQuery.Text = out_node.GetString("SQL_1") + out_node.GetString("SQL_2") + out_node.GetString("SQL_3")
                                + out_node.GetString("SQL_4") + out_node.GetString("SQL_5");
                ChangeSyntaxColor();

                txtPwd.Text = out_node.GetString("TABLE_PASSWORD");
                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));

                txtExpTable.Text = out_node.GetString("TABLE_NAME");
                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
            finally
            {
                spdTable.ResumeLayout();
            }
        }

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        //
        // View_Table_Prompt()
        //       - View General Code Prompt Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - string sTableName  : GCM Table Name
        //       - string sKey        : GCM Table Column Name
        //       - int iRow           : FpSpread Sheet Row Position
        //
        private bool View_Table_Prompt(string sTableName, string sKey, int iRow)
        {
            TRSNode in_node = new TRSNode("VIEW_TABLE_IN");
            TRSNode out_node = new TRSNode("VIEW_TABLE_OUT");

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

                spdTable.ActiveSheet.SetValue(iRow, 0, out_node.GetString(sKey + "_PRT"));
                spdTable.ActiveSheet.SetValue(iRow, 2, out_node.GetInt(sKey + "_SIZE"));

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }
        }
        /*** End of Add (2012.04.04) ***/

        //
        // Update_Table()
        //       - Create/Update/Delete General Code Table Definition
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("1" - Create, "2" - Update, "3" - Delete)
        //
        private bool Update_Table(char ProcStep)
        {
            ListViewItem itm;
            int idx;

            TRSNode in_node = new TRSNode("UPDATE_TABLE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("TABLE_NAME", MPCF.Trim(txtTable.Text));
                in_node.AddString("TABLE_DESC", MPCF.Trim(txtDesc.Text));
                in_node.AddChar("SYS_TBL_FLAG", (chkSysFlag.Checked ? 'Y' : ' '));
                in_node.AddChar("CENTRAL_FLAG", (chkCentral.Checked ? 'Y' : ' '));
                switch (cboTblType.Text.Substring(0, 1))
                {
                    case "G": in_node.AddChar("TABLE_TYPE", ' '); break;
                    case "E": in_node.AddChar("TABLE_TYPE", 'E'); break;
                    case "L": in_node.AddChar("TABLE_TYPE", 'L'); break;
                }
                in_node.AddString("TABLE_GROUP", MPCF.Trim(cdvTblGroup.Text));
                in_node.AddChar("SEC_CHK_FLAG", (chkSecFlag.Checked ? 'Y' : ' '));
                in_node.AddChar("USE_SQL_FLAG", (chkUseSql.Checked ? 'Y' : ' '));

                in_node.AddString("KEY_1_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[0, 0].Value));
                in_node.AddString("KEY_2_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[1, 0].Value));
                in_node.AddString("KEY_3_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[2, 0].Value));
                in_node.AddString("KEY_4_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[3, 0].Value));
                in_node.AddString("KEY_5_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[4, 0].Value));
                in_node.AddString("KEY_6_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[5, 0].Value));
                in_node.AddString("KEY_7_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[6, 0].Value));
                in_node.AddString("KEY_8_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[7, 0].Value));
                in_node.AddString("KEY_9_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[8, 0].Value));
                in_node.AddString("KEY_10_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[9, 0].Value));

                in_node.AddChar("KEY_1_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[0, 1].Value));
                in_node.AddChar("KEY_2_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[1, 1].Value));
                in_node.AddChar("KEY_3_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[2, 1].Value));
                in_node.AddChar("KEY_4_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[3, 1].Value));
                in_node.AddChar("KEY_5_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[4, 1].Value));
                in_node.AddChar("KEY_6_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[5, 1].Value));
                in_node.AddChar("KEY_7_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[6, 1].Value));
                in_node.AddChar("KEY_8_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[7, 1].Value));
                in_node.AddChar("KEY_9_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[8, 1].Value));
                in_node.AddChar("KEY_10_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[9, 1].Value));

                in_node.AddInt("KEY_1_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[0, 2].Value));
                in_node.AddInt("KEY_2_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[1, 2].Value));
                in_node.AddInt("KEY_3_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[2, 2].Value));
                in_node.AddInt("KEY_4_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[3, 2].Value));
                in_node.AddInt("KEY_5_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[4, 2].Value));
                in_node.AddInt("KEY_6_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[5, 2].Value));
                in_node.AddInt("KEY_7_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[6, 2].Value));
                in_node.AddInt("KEY_8_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[7, 2].Value));
                in_node.AddInt("KEY_9_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[8, 2].Value));
                in_node.AddInt("KEY_10_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[9, 2].Value));


                in_node.AddString("DATA_1_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[10, 0].Value));
                in_node.AddString("DATA_2_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[11, 0].Value));
                in_node.AddString("DATA_3_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[12, 0].Value));
                in_node.AddString("DATA_4_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[13, 0].Value));
                in_node.AddString("DATA_5_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[14, 0].Value));
                in_node.AddString("DATA_6_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[15, 0].Value));
                in_node.AddString("DATA_7_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[16, 0].Value));
                in_node.AddString("DATA_8_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[17, 0].Value));
                in_node.AddString("DATA_9_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[18, 0].Value));
                in_node.AddString("DATA_10_PRT", MPCF.Trim(spdTable.ActiveSheet.Cells[19, 0].Value));

                in_node.AddChar("DATA_1_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[10, 1].Value));
                in_node.AddChar("DATA_2_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[11, 1].Value));
                in_node.AddChar("DATA_3_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[12, 1].Value));
                in_node.AddChar("DATA_4_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[13, 1].Value));
                in_node.AddChar("DATA_5_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[14, 1].Value));
                in_node.AddChar("DATA_6_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[15, 1].Value));
                in_node.AddChar("DATA_7_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[16, 1].Value));
                in_node.AddChar("DATA_8_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[17, 1].Value));
                in_node.AddChar("DATA_9_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[18, 1].Value));
                in_node.AddChar("DATA_10_FMT", MPCF.ToChar(spdTable.ActiveSheet.Cells[19, 1].Value));

                in_node.AddInt("DATA_1_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[10, 2].Value));
                in_node.AddInt("DATA_2_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[11, 2].Value));
                in_node.AddInt("DATA_3_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[12, 2].Value));
                in_node.AddInt("DATA_4_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[13, 2].Value));
                in_node.AddInt("DATA_5_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[14, 2].Value));
                in_node.AddInt("DATA_6_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[15, 2].Value));
                in_node.AddInt("DATA_7_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[16, 2].Value));
                in_node.AddInt("DATA_8_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[17, 2].Value));
                in_node.AddInt("DATA_9_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[18, 2].Value));
                in_node.AddInt("DATA_10_SIZE", MPCF.ToInt(spdTable.ActiveSheet.Cells[19, 2].Value));

                /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[0, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_1_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[0, 3].Value));
                    in_node.AddString("KEY_1_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[0, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[1, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_2_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[1, 3].Value));
                    in_node.AddString("KEY_2_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[1, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[2, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_3_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[2, 3].Value));
                    in_node.AddString("KEY_3_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[2, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[3, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_4_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[3, 3].Value));
                    in_node.AddString("KEY_4_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[3, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[4, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_5_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[4, 3].Value));
                    in_node.AddString("KEY_5_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[4, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[5, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_6_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[5, 3].Value));
                    in_node.AddString("KEY_6_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[5, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[6, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_7_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[6, 3].Value));
                    in_node.AddString("KEY_7_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[6, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[7, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_8_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[7, 3].Value));
                    in_node.AddString("KEY_8_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[7, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[8, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_9_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[8, 3].Value));
                    in_node.AddString("KEY_9_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[8, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[9, 1].Value) == "Table")
                {
                    in_node.AddString("KEY_10_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[9, 3].Value));
                    in_node.AddString("KEY_10_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[9, 5].Value));
                }

                if (MPCF.Trim(spdTable.ActiveSheet.Cells[10, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_1_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[10, 3].Value));
                    in_node.AddString("DATA_1_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[10, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[11, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_2_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[11, 3].Value));
                    in_node.AddString("DATA_2_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[11, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[12, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_3_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[12, 3].Value));
                    in_node.AddString("DATA_3_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[12, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[13, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_4_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[13, 3].Value));
                    in_node.AddString("DATA_4_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[13, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[14, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_5_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[14, 3].Value));
                    in_node.AddString("DATA_5_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[14, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[15, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_6_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[15, 3].Value));
                    in_node.AddString("DATA_6_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[15, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[16, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_7_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[16, 3].Value));
                    in_node.AddString("DATA_7_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[16, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[17, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_8_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[17, 3].Value));
                    in_node.AddString("DATA_8_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[17, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[18, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_9_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[18, 3].Value));
                    in_node.AddString("DATA_9_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[18, 5].Value));
                }
                if (MPCF.Trim(spdTable.ActiveSheet.Cells[19, 1].Value) == "Table")
                {
                    in_node.AddString("DATA_10_TBL", MPCF.Trim(spdTable.ActiveSheet.Cells[19, 3].Value));
                    in_node.AddString("DATA_10_COL", MPCF.Trim(spdTable.ActiveSheet.Cells[19, 5].Value));
                }
                /*** End of Add (2012.04.04) ***/

                in_node.AddString("TABLE_PASSWORD", MPCF.Trim(txtPwd.Text).ToUpper(), true);

                {
                    int i;
                    string[] s_statements;
                    StringBuilder sb = new StringBuilder();

                    s_statements = txtQuery.Text.Split(new char[] { '\n', '\r' });

                    for (i = 0; i < s_statements.Length; i++)
                    {
                        sb.Append(s_statements[i].Trim());
                        sb.Append(" \n");
                    }
                    txtQuery.Text = sb.ToString();
                }
                in_node.AddString("SQL", MPCF.Trim(txtQuery.Text));
                
                if (MPCR.CallService("BAS", "BAS_Update_Table", in_node, ref out_node) == false)
                {
                    return false;
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    if (ProcStep == MPGC.MP_STEP_CREATE)
                    {
                        itm = lisTable.Items.Add(MPCF.Trim(txtTable.Text), (int)SMALLICON_INDEX.IDX_CODE_TABLE);
                        itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                        lisTable.Sorting = SortOrder.Ascending;
                        lisTable.Sort();
                        itm.Selected = true;
                        itm.EnsureVisible();

                    }
                    else if (ProcStep == MPGC.MP_STEP_UPDATE)
                    {
                        if (MPCF.FindListItem(lisTable, MPCF.Trim(txtTable.Text), false) == true)
                        {
                            lisTable.SelectedItems[0].SubItems[1].Text = MPCF.Trim(txtDesc.Text);
                        }
                    }
                    else if (ProcStep == MPGC.MP_STEP_DELETE)
                    {
                        idx = MPCF.FindListItemIndex(lisTable, MPCF.Trim(txtTable.Text), false);
                        if (idx != -1)
                        {
                            lisTable.Items[idx].Remove();
                        }
                    }
                    lblDataCount.Text = MPCF.Trim(lisTable.Items.Count);
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


        //
        // Copy_Table()
        //       - Copy General Code Table Definition & Code Data
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String ("C" - Copy)
        //
        private bool Copy_Table(char ProcStep)
        {
            TRSNode in_node = new TRSNode("COPY_TABLE_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            ListViewItem itm = new ListViewItem();

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.AddString("FROM_FACTORY", cdvFromFactory.Text);
                in_node.AddString("FROM_TABLE_NAME", cdvFromTable.Text);
                in_node.AddString("TABLE_NAME", txtToTable.Text);

                if (MPCR.CallService("BAS", "BAS_Copy_Table", in_node, ref out_node) == false)
                {
                    return false;
                }
                else
                {
                    MPCR.ShowSuccessMsg(out_node);
                }

                if (MPGV.gbListAutoRefresh == false)
                {
                    itm = lisTable.Items.Add(MPCF.Trim(txtToTable.Text), (int)SMALLICON_INDEX.IDX_CODE_TABLE);
                    itm.SubItems.Add(MPCF.Trim(txtDesc.Text));
                    itm.Selected = true;
                    lisTable.Sorting = SortOrder.Ascending;
                    lisTable.Sort();
                    itm.EnsureVisible();
                    lblDataCount.Text = MPCF.Trim(lisTable.Items.Count);
                }

                return true;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

        }

        private string[,] strData = null;

        private bool ViewQueryResult(string sQuery)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            FarPoint.Win.Spread.CellType.ComboBoxCellType cboColumn;
            int i;

            MPCF.ClearList(spdData);

            try
            {

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                sQuery = "SELECT * FROM ( " + sQuery + " ) WHERE ROWNUM < 11";
                byte[] bsq = System.Text.Encoding.UTF8.GetBytes(sQuery);
                in_node.AddBlob(MPGC.MP_BIN_DATA_1, bsq);

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    MPCR.FillDataView(spdData, out_node);

                    cboColumn = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
                    cboColumn.Items = new string[out_node.GetList(0).Count + 1];
                    strData = new string[out_node.GetList(0).Count + 1, 3];
                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        cboColumn.Items[i] = out_node.GetList(0)[i].GetString("NAME");
                        strData[i, 0] = out_node.GetList(0)[i].GetString("NAME");
                        strData[i, 1] = out_node.GetList(0)[i].GetString("TYPE");
                        strData[i, 2] = out_node.GetList(0)[i].GetInt("SIZE").ToString();

                    }
                    cboColumn.Items[i] = "";
                    //spdTable.ActiveSheet.ClearRange(0, 0, spdTable.ActiveSheet.RowCount, spdTable.ActiveSheet.ColumnCount, true);
                    spdTable.ActiveSheet.Columns[0].CellType = cboColumn;

                    in_node.SetInt("NEXT_ROW", out_node.GetInt("NEXT_ROW"));
                } while (out_node.GetInt("NEXT_ROW") > 0);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

            return true;
        }

        private bool GetQueryArgument()
        {
            int i, i_count, j;
            string[] sWord = null;
            string[] sArgu = null;
            string sQuery;
            bool b_exist_flag = false;
            frmBASSubSetupTable form = new frmBASSubSetupTable();

            sQuery = txtQuery.Text;
            sQuery = sQuery.Replace("$FACTORY", "'" + MPGV.gsFactory + "'");

            sWord = sQuery.Split(new Char[] { ' ', '\n', '\r' });

            i_count = 0;
            for (i = 0; i < sWord.Length; i++)
            {
                if (sWord[i].IndexOf("$") >= 0)
                {
                    i_count++;
                }
            }
            sArgu = new string[i_count];
            i_count = 0;
            for (i = 0; i < sWord.Length; i++)
            {
                b_exist_flag = false;
                if (sWord[i].IndexOf("$") >= 0)
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

            if (i_count > 0)
            {
                form.ViewQueryArgument(sArgu, i_count);
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    if (form.IsDisposed == false) form.Dispose();
                    return false;
                }

                for (i = 0; i < form.ArgValue.Length / 2; i++)
                {
                    sQuery = sQuery.Replace(form.ArgValue[i, 0], "'" + form.ArgValue[i, 1] + "'");

                }
            }

            ViewQueryResult(sQuery);

            return true;
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
                    if (MPCF.IsSQLSyntax(MPCF.ToUpper(txtQuery.Text.Substring(iStart, iLen - iStart))) == true ||
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

        private string GetGCMData(string table, string d_table)
        {
            TRSNode in_node = new TRSNode("SQL_IN");
            TRSNode out_node = new TRSNode("SQL_OUT");

            string Query = null;
            string data;
            int i, j;
            string temp = null;
            string cmt = null;
            string proc = null;
            StringBuilder script = null;

            Query = "SELECT * FROM " + d_table + " WHERE FACTORY = '" + MPGV.gsFactory + "' AND TABLE_NAME = '" + table + "'";
            cmt = " " + d_table + " Table(TABLE_NAME) : " + table;

            script = new StringBuilder();
            progressBarExport.Value = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", Query);

                progressBarExport.Maximum = out_node.GetList("ROWS").Count;

                #region 컬럼명 셋팅
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
                    proc += "       SELECT DISTINCT FACTORY FROM " + d_table + "\r\n";
                    proc += "       WHERE TABLE_NAME = '";
                    proc += table + "'\r\n";
                    proc += "       )\r\n";
                    proc += "   LOOP\r\n";
                }
                script.Append(proc);

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                    {
                        return "";
                    }

                    if (chkMigration.Checked == false)
                        temp = "INSERT INTO " + d_table + "(";
                    else
                        temp = "   INSERT INTO " + d_table + "(";

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
                        return "No Data";
                    }

                    //Request Reply Timeout 발생시 옵션에서 TimeOut시간을 늘려주어야함
                    #region Data값 받기
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

                        if (b_export_stop) //Stop 처리
                        {
                            txtExport.Focus();
                            txtExport.AppendText("<User Stop>..." + "\r\n");
                            b_export_stop = false;
                            return "";
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

                progressBarExport.Increment(1);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
            progressBarExport.Value = 0;
            return script.ToString();
        }

        #endregion

        private void frmBASSetupGeneralCodeTable_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    cdvGroup_SelectedItemChanged(null, null);

                    b_load_flag = true;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void frmBASSetupGeneralCodeTable_Load(object sender, System.EventArgs e)
        {
            try
            {

                if (MPGV.gsFactory == MPGV.gsCentralFactory)
                {
                    chkSysFlag.Enabled = true;
                    chkCentral.Enabled = true;
                }
                else
                {
                    chkSysFlag.Enabled = false;
                    chkCentral.Enabled = false;
                }

                MPCF.InitListView(lisTable);

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void cboTblType_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            int i = 0;

            try
            {
                if (cboTblType.SelectedIndex == 0)
                {
                    for (i = 2; i <= 9; i++)
                    {
                        spdTable.ActiveSheet.RowHeader.Rows[i].Visible = false;
                    }
                }
                else
                {
                    for (i = 2; i <= 9; i++)
                    {
                        spdTable.ActiveSheet.RowHeader.Rows[i].Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnCreate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("UPDATE_TABLE", MPGC.MP_STEP_CREATE) == true)
                {
                    if (Update_Table(MPGC.MP_STEP_CREATE) == false)
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

        private void btnUpdate_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (CheckCondition("UPDATE_TABLE", MPGC.MP_STEP_UPDATE) == true)
                {
                    if (Update_Table(MPGC.MP_STEP_UPDATE) == false)
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
                if (MPCF.ShowMsgBox(MPCF.GetMessage(54), MessageBoxButtons.YesNo, 2) != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }

                if (CheckCondition("UPDATE_TABLE", MPGC.MP_STEP_DELETE) == true)
                {
                    if (Update_Table(MPGC.MP_STEP_DELETE) == false)
                    {
                        return;
                    }
                    ClearData('1');
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

        private void lisTable_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            FarPoint.Win.Spread.CellType.TextCellType txtColumn = new FarPoint.Win.Spread.CellType.TextCellType();

            try
            {
                if (lisTable.SelectedItems.Count > 0)
                {
                    View_Table();
                    MPCF.ClearList(spdData);
                    spdTable.ActiveSheet.Columns[0].CellType = txtColumn;
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                cdvGroup_SelectedItemChanged(null, null);

                if (lisTable.Items.Count > 0)
                {
                    MPCF.FindListItem(lisTable, txtTable.Text, false);
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void spdTable_Change(System.Object sender, FarPoint.Win.Spread.ChangeEventArgs e)
        {
            try
            {
                if (e.Column != 0)
                {
                    return;
                }

                if (MPCF.Trim(spdTable.ActiveSheet.Cells[e.Row, e.Column].Value) == "")
                {
                    spdTable.ActiveSheet.SetValue(e.Row, 1, "");
                    spdTable.ActiveSheet.SetValue(e.Row, 2, "");
                    /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                    spdTable.ActiveSheet.SetValue(e.Row, 3, "");
                    spdTable.ActiveSheet.SetValue(e.Row, 5, "");
                    /*** End of Add (2012.04.04) ***/
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

        private void cdvFromTable_SelectedItemChanged(System.Object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            txtToTable.Text = cdvFromTable.Text;
        }

        private void btnCopy_Click(System.Object sender, System.EventArgs e)
        {
            if (CheckCondition("COPY_TABLE", MPGC.MP_STEP_COPY) == true)
            {
                if (Copy_Table(MPGC.MP_STEP_COPY) == true)
                {
                    txtToTable.Text = "";
                    if (MPGV.gbListAutoRefresh == true)
                    {
                        if (BASLIST.ViewGCMTableList(lisTable, '1', false) == false)
                        {
                            return;
                        }
                        lblDataCount.Text = MPCF.Trim(lisTable.Items.Count);
                        if (lisTable.Items.Count > 0)
                        {
                            MPCF.FindListItem(lisTable, txtToTable.Text, false);
                        }
                    }
                }
            }
        }

        private void cdvFromTable_ButtonPress(object sender, System.EventArgs e)
        {
            cdvFromTable.Init();
            MPCF.InitListView(cdvFromTable.GetListView);
            cdvFromTable.Columns.Add("Table Name", 100, HorizontalAlignment.Left);
            cdvFromTable.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvFromTable.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMTableList(cdvFromTable.GetListView, '1', ' ', "", -1, null, ((cdvFromFactory.Text == "") ? MPGV.gsFactory : (MPCF.Trim(cdvFromFactory.Text))), false, -1, -1, false, false, false);
        }

        private void cdvFromFactory_ButtonPress(object sender, System.EventArgs e)
        {
            cdvFromFactory.Init();
            MPCF.InitListView(cdvFromFactory.GetListView);
            cdvFromFactory.Columns.Add("Factory", 100, HorizontalAlignment.Left);
            cdvFromFactory.Columns.Add("Desc", 200, HorizontalAlignment.Left);
            cdvFromFactory.SelectedSubItemIndex = 0;
            WIPLIST.ViewFactoryList(cdvFromFactory.GetListView, '1', null);
        }

        private void btnNext_Click(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisTable, txtFind.Text, true, false);
        }

        private void txtFind_TextChanged(System.Object sender, System.EventArgs e)
        {
            MPCF.FindListItemPartial(lisTable, txtFind.Text, 0, true, false);
        }

        private void txtTable_LostFocus(object sender, System.EventArgs e)
        {
            if (MPGV.gsFactory != MPGV.gsCentralFactory)
            {
                if (lisTable.SelectedItems.Count > 0)
                {
                    if (txtTable.Text != "")
                    {
                        if (MPCF.Trim(lisTable.SelectedItems[0].Text) != txtTable.Text)
                        {
                            chkSysFlag.Checked = false;
                        }
                    }
                }
                else if (txtTable.Text != "")
                {
                    chkSysFlag.Checked = false;
                }
            }

        }

        private void cdvFromFactory_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            cdvFromTable.Text = "";
            txtToTable.Text = "";
        }

        private void chkCentral_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCentral.Checked == true)
            {
                chkSysFlag.Checked = false;
                chkSysFlag.Enabled = false;
            }
            else
            {
                chkSysFlag.Enabled = true;
            }
        }

        private void cdvTblGroup_ButtonPress(object sender, EventArgs e)
        {
            Miracom.UI.Controls.MCCodeView.MCCodeView code_view = (Miracom.UI.Controls.MCCodeView.MCCodeView)sender;

            code_view.Init();
            MPCF.InitListView(code_view.GetListView);
            code_view.Columns.Add("Group", 50, HorizontalAlignment.Left);
            code_view.Columns.Add("Desc", 100, HorizontalAlignment.Left);
            code_view.SelectedSubItemIndex = 0;
            BASLIST.ViewGCMDataList(code_view.GetListView, '1', MPGC.MP_GCM_TABLE_GROUP);
            code_view.InsertEmptyRow(0, 1);
        }

        private void cdvGroup_SelectedItemChanged(object sender, Miracom.UI.MCCodeViewSelChanged_EventArgs e)
        {
            lblDataCount.Text = "";
            if (BASLIST.ViewGCMTableList(lisTable, '1', ' ', MPCF.Trim(cdvGroup.Text), false) == true)
            {
                MPCF.FitColumnHeader(lisTable);
                lblDataCount.Text = MPCF.Trim(lisTable.Items.Count);
            }
            else
            {
                return;
            }
        }

        private void btnSQLTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.Trim(txtQuery.Text) == "")
                {
                    return;
                }

                string sSqlQuery = MPCF.Trim(txtQuery.Text);
                txtQuery.Text = sSqlQuery;

                if (sSqlQuery.Length < 6 || sSqlQuery.ToUpper().Substring(0, 6) != "SELECT")
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(362));
                    return;
                }

                int iStart = 0;
                int iFactory;

                while ((iFactory = sSqlQuery.ToUpper().IndexOf("$FACTORY", iStart)) >= 0)
                {
                    if (sSqlQuery.Substring(iFactory, 8) != "$FACTORY")
                    {
                        sSqlQuery = sSqlQuery.Replace(sSqlQuery.Substring(iFactory, 8), "$FACTORY");
                        txtQuery.Text = sSqlQuery;
                    }

                    iStart = iFactory + 8;
                }

                ChangeSyntaxColor();
                if (txtQuery.Text.IndexOf("$") > 0)
                {
                    if (GetQueryArgument() == false)
                    {
                        return;
                    }
                }
                else
                {
                    ViewQueryResult(txtQuery.Text);
                }
                spdTable.ActiveSheet.Columns[0].Locked = false;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void spdTable_ComboCloseUp(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            int i;
            try
            {
                if (e.Column == 0 && MPCF.Trim(e.EditingControl.Text) != "")
                {
                    for (i = 0; i < spdTable.ActiveSheet.RowCount; i++)
                    {
                        if (MPCF.Trim(spdTable.ActiveSheet.Cells[i, 0].Value) == MPCF.Trim(e.EditingControl.Text))
                        {
                            if (i != e.Row)
                            {
                                MPCF.ShowMsgBox(MPCF.GetMessage(276));
                                spdTable.ActiveSheet.Cells[e.Row, 0].Text = "";

                                return;
                            }
                        }
                    }
                    for (i = 0; i < strData.Length / 3; i++)
                    {
                        if (MPCF.Trim(e.EditingControl.Text) == MPCF.Trim(strData[i, 0]))
                        {
                            if (MPCF.Trim(strData[i, 1]) == "STR" || MPCF.Trim(strData[i, 1]) == "CHR")
                            {
                                spdTable.ActiveSheet.Cells[e.Row, 1].Value = "Ascii";
                            }
                            else if (MPCF.Trim(strData[i, 1]) == "INT" || MPCF.Trim(strData[i, 1]) == "LNG")
                            {
                                spdTable.ActiveSheet.Cells[e.Row, 1].Value = "Number";
                            }
                            else if (MPCF.Trim(strData[i, 1]) == "DBL")
                            {
                                spdTable.ActiveSheet.Cells[e.Row, 1].Value = "Float";
                            }
                            spdTable.ActiveSheet.Cells[e.Row, 2].Value = MPCF.ToInt(strData[i, 2]);

                            break;
                        }
                    }
                }

                /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
                if (chkUseSql.Checked == false)
                {
                    if (e.Column == 1 && MPCF.Trim(e.EditingControl.Text) == "Table")
                        spdTable.ActiveSheet.Cells[e.Row, 2].Locked = true;
                    else
                        spdTable.ActiveSheet.Cells[e.Row, 2].Locked = false;
                }
                if (e.Column == 1 && MPCF.Trim(e.EditingControl.Text) != "Table")
                {
                    spdTable.ActiveSheet.Cells[e.Row, 3].Value = "";
                    spdTable.ActiveSheet.Cells[e.Row, 5].Value = "";
                }
                /*** End of Add (2012.04.04) ***/

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            int iSel;
            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;
            if (e.KeyChar == ' ' || e.KeyChar == '\b')
            {

                for (i = txtQuery.SelectionStart - 1; i >= 0; i--)
                {
                    if (txtQuery.Text[i] == ' ' || i == 0)
                    {
                        if (MPCF.IsSQLSyntax(MPCF.ToUpper(txtQuery.Text.Substring(i, txtQuery.SelectionStart - i))) == true ||
                    txtQuery.Text.Substring(i, txtQuery.SelectionStart - i).IndexOf("$") > 0)
                        {
                            iSel = txtQuery.SelectionStart;
                            txtQuery.SelectionStart = i;
                            txtQuery.SelectionLength = iSel - i;
                            txtQuery.SelectionColor = System.Drawing.Color.Blue;
                            txtQuery.SelectionStart = iSel;
                            txtQuery.SelectionLength = 0;
                            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;

                            break;
                        }
                        else
                        {
                            iSel = txtQuery.SelectionStart;
                            txtQuery.SelectionStart = i;
                            txtQuery.SelectionLength = iSel - i;
                            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;
                            txtQuery.SelectionStart = iSel;
                            txtQuery.SelectionLength = 0;
                            txtQuery.SelectionColor = System.Drawing.SystemColors.ControlText;

                            break;
                        }
                    }
                }
            }

        }

        private void chkUseSql_CheckedChanged(object sender, EventArgs e)
        {
            FarPoint.Win.Spread.CellType.TextCellType txtColumn = new FarPoint.Win.Spread.CellType.TextCellType();
            if (chkUseSql.Checked == true)
            {
                spdTable.ActiveSheet.ClearRange(0, 0, spdTable.ActiveSheet.RowCount, spdTable.ActiveSheet.ColumnCount, true);
                spdTable.ActiveSheet.Columns[0].Locked = true;
                spdTable.ActiveSheet.Columns[1].Locked = true;
                spdTable.ActiveSheet.Columns[2].Locked = true;
                txtQuery.ReadOnly = false;
                txtQuery.BackColor = System.Drawing.SystemColors.Window;
                MPCR.ChangeControlEnabled(this, btnSQLTest, true);
            }
            else
            {
                spdTable.ActiveSheet.Columns[0].Locked = false;
                spdTable.ActiveSheet.Columns[1].Locked = false;
                spdTable.ActiveSheet.Columns[2].Locked = false;
                txtQuery.ReadOnly = true;
                txtQuery.BackColor = System.Drawing.SystemColors.Control;
                btnSQLTest.Enabled = false;
                spdTable.ActiveSheet.Columns[0].CellType = txtColumn;
            }

        }

        private void txtQuery_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    ChangeSyntaxColor();
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        /*** #753 GCM Reference (2012.04.04 by JYPARK) ***/
        private void spdTable_ButtonClicked(object sender, FarPoint.Win.Spread.EditorNotifyEventArgs e)
        {
            if (e.Column == 4 || e.Column == 6)
                if (MPCF.Trim(spdTable.ActiveSheet.GetValue(e.Row, 1)) != "Table") return;

            if (e.Column == 4)
            {
                cdvTableList.Init();
                cdvTableList.ViewPosition = Control.MousePosition;
                MPCF.InitListView(cdvTableList.GetListView);
                cdvTableList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
                cdvTableList.Columns.Add("Table Desc", 50, HorizontalAlignment.Left);
                BASLIST.ViewGCMTableList(cdvTableList.GetListView, '1', true);
                cdvTableList.InsertEmptyRow(0, 1);
                if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                {
                    return;
                }
            }
            else if (e.Column == 6)
            {
                string s_table_name = MPCF.Trim(spdTable.ActiveSheet.Cells[e.Row, 3].Value);
                if (s_table_name != "")
                {
                    cdvTableList.Init();
                    cdvTableList.ViewPosition = Control.MousePosition;
                    MPCF.InitListView(cdvTableList.GetListView);
                    cdvTableList.Columns.Add("Code", 50, HorizontalAlignment.Left);
                    cdvTableList.Columns.Add("Desc", 50, HorizontalAlignment.Left);
                    BASLIST.ViewGCMTablePromptList(cdvTableList.GetListView, s_table_name, true, true);
                    cdvTableList.InsertEmptyRow(0, 1);
                    if (cdvTableList.ShowPopupList(e.Row, e.Column) == false)
                    {
                        return;
                    }
                }
            }
        }

        private void cdvTableList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            string sTableName = "";
            string sKey = "";
            if (MPCF.Trim(spdTable.ActiveSheet.Cells[e.Row, e.Col - 1].Value) != e.SelectedItem.SubItems[0].Text)
            {
                spdTable.ActiveSheet.Cells[e.Row, e.Col - 1].Value = e.SelectedItem.SubItems[0].Text;
                if (e.Col == 4)
                {
                    if (MPCF.Trim(spdTable.ActiveSheet.Cells[e.Row, e.Col - 1].Value) != "")
                    {
                        spdTable.ActiveSheet.Cells[e.Row, 5].Locked = true;
                        spdTable.ActiveSheet.Cells[e.Row, 5].Value = "KEY_1";

                        sTableName = MPCF.Trim(spdTable.ActiveSheet.Cells[e.Row, 3].Value);
                        sKey = MPCF.Trim(spdTable.ActiveSheet.Cells[e.Row, 5].Value);
                        if (sTableName != "" && sKey != "")
                        {
                            spdTable.ActiveSheet.SetValue(e.Row, 2, "");
                            View_Table_Prompt(sTableName, sKey, e.Row);
                        }
                    }
                    else
                    {
                        spdTable.ActiveSheet.Cells[e.Row, 5].Locked = false;
                    }
                }
                else if (e.Col == 6)
                {
                    sTableName = MPCF.Trim(spdTable.ActiveSheet.Cells[e.Row, 3].Value);
                    sKey = MPCF.Trim(spdTable.ActiveSheet.Cells[e.Row, 5].Value);
                    if (sTableName != "" && sKey != "")
                    {
                        spdTable.ActiveSheet.SetValue(e.Row, 2, "");
                        View_Table_Prompt(sTableName, sKey, e.Row);
                    }
                }
            }
        }
        /*** End of Add (2012.04.04) ***/
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
            string s_tblData = null;
            StringBuilder script = null;

            Query = "SELECT * FROM MGCMTBLDEF WHERE FACTORY = '" + MPGV.gsFactory + "' AND TABLE_NAME = '" + txtExpTable.Text + "'";
            cmt = "MGCMTBLDEF Table(TABLE_NAME) : " + txtExpTable.Text;

            script = new StringBuilder();
            progressBarExport.Value = 0;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("SQL", Query);

                do
                {
                    if (MPCR.CallService("BAS", "BAS_SQL_Query", in_node, ref out_node) == false)
                    {
                        return;
                    }

                    progressBarExport.Maximum = out_node.GetList("ROWS").Count;

                    #region 컬럼명 셋팅
                    if (chkMigration.Checked == false)
                        temp = "INSERT INTO MGCMTBLDEF(";
                    else
                    {
                        temp =  "BEGIN\r\n";
                        temp += "   FOR REC IN (\r\n";
                        temp += "       SELECT DISTINCT FACTORY FROM MWIPFACDEF\r\n";
                        temp += "       MINUS\r\n";
                        temp += "       SELECT DISTINCT FACTORY FROM MGCMTBLDEF\r\n";
                        temp += "       WHERE TABLE_NAME = '";
                        temp += txtExpTable.Text + "'\r\n";
                        temp += "       )\r\n";
                        temp += "   LOOP\r\n";
                        temp += "   INSERT INTO MGCMTBLDEF(";
                    }

                    for (i = 0; i < out_node.GetList(0).Count; i++)
                    {
                        temp += out_node.GetList(0)[i].GetString("NAME");
                        if (i < out_node.GetList(0).Count - 1) temp += ", ";
                    }
                    temp += ") VALUES(";
                    script.Append("/* Start [" + cmt + "] */\r\n");
                    script.Append(temp);
                    #endregion

                    if (out_node.GetList("ROWS").Count <= 0)
                    {
                        txtExport.Text = "No Data";
                        return;
                    }

                    //Request Reply Timeout 발생시 옵션에서 TimeOut시간을 늘려주어야함
                    #region Data값 받기
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
                                if (i == 0 && j == 0 && chkMigration.Checked == true)
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

                        if (b_export_stop) //Stop 처리
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
                
                progressBarExport.Increment(1);

                if (chkIncludeData.Checked == true)
                {
                    if (out_node.GetList("ROWS")[0].GetList("COLS")[5].GetString("DATA") == "L")
                        s_tblData = GetGCMData(txtExpTable.Text, GCM_TBL_LAG);
                    else
                        s_tblData = GetGCMData(txtExpTable.Text, GCM_TBL_DAT);

                    script.Append(s_tblData);
                }

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

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (MPCF.CheckValue(txtTable, 1) == false)
                {
                    return;
                }

                Form f = MPCF.GetChildForm(MPGV.gfrmMDI, "frmBASViewGeneralCodeTableHistory");
                
                if (f == null)
                {
                    f = new frmBASViewGeneralCodeTableHistory();
                    f.MdiParent = MPGV.gfrmMDI;
                }
                ((frmBASViewGeneralCodeTableHistory)f).TableName = txtTable.Text;
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
