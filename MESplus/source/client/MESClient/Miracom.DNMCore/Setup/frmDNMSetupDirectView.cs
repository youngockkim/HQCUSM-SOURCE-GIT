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
//   File Name   : frmDNMSetupDirectView.cs
//   Description : Direct View Query Setup
//
//   MES Version : 5.3.0.0
//
//   Function List
//       - ClearData() : Intialize Form Field
//       - CheckCondition() : Check the conditions before transaction
//       - UpdateDirectView() : Create/Update/Delete General code list
//       - ViewDirectView() :View General code list which is included in one general code table
//       - ViewDirectViewist() : View all table list which is included in one factory
//
//   Detail Description
//       -
//
//   History
//       - **** Do Not Modify in Site!!! ****
//       - 2014-05-27 : Created by Kelly Jung
//
//
//   Copyright(C) 1998-2014 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------


namespace Miracom.DNMCore
{
    public class frmDNMSetupDirectView : Miracom.MESCore.SetupForm02
    {

        #region " Windows Form auto generated code "

        public frmDNMSetupDirectView()
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
        private ListView lisView;
        private GroupBox grpSQL;
        private GroupBox grpGeneral;
        private Label label1;
        private TextBox txtDesc;
        private TextBox txtViewID;
        private Label lblViewID;
        private Label lblCreateUser;
        private Label lblUpdateUser;
        private TextBox txtCreateUser;
        private TextBox txtUpdateTime;
        private TextBox txtCreateTime;
        private TextBox txtUpdateUser;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private TabControl tabDirectView;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox grpHeader;
        private FpSpread spdHeader;
        private SheetView spdHeader_Sheet1;
        private SplitContainer sptHeader;
        private GroupBox grpColumns;
        private ListView lisColumns;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private Panel pnlColumn;
        private Button btnReplace;
        private Button btnAdd;
        private GroupBox grtTable;
        private UI.Controls.MCCodeView.MCCodeView cdvTable;
        private Label lblTable;
        private Button btnAll;
        private Panel plnHeader;
        private Button btnGenName;
        private Button btnCheckAllHeader;
        private Button btnClear;
        private TabPage tabPage3;
        private FpSpread spdCondition;
        private SheetView spdCondition_Sheet1;
        private Panel panel3;
        private Button btnDeleteRow;
        private Panel panel4;
        private CheckBox chkBgColor;
        private CheckBox chkIcon;
        private GroupBox grpContents;
        private Panel panel1;
        private RichTextBox txtQuery;
        private Panel panel2;
        private CheckBox chkDictionary;
        private CheckBox chkSample;
        private RichTextBox txtSample;
        private Panel pnlDictionary;
        private GroupBox grpBGColor;
        private FpSpread spdColors;
        private SheetView spdColors_Sheet1;
        private GroupBox grpIcon;
        private FpSpread spdIcons;
        private SheetView spdIcons_Sheet1;
        private TabPage tabPage4;
        private TextBox txtToViewID;
        private Label label2;
        private Button btnCopy;
        private Button btnCopyClipboard;
        private Button btnConvert;
        private UI.Controls.MCCodeView.MCSPCodeView cdvDataList;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDNMSetupDirectView));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer2 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer5 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer6 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ImageCellType imageCellType7 = new FarPoint.Win.Spread.CellType.ImageCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer7 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer8 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.ImageCellType imageCellType8 = new FarPoint.Win.Spread.CellType.ImageCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer9 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer10 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType10 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType11 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.CheckBoxCellType checkBoxCellType12 = new FarPoint.Win.Spread.CellType.CheckBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType7 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ComboBoxCellType comboBoxCellType8 = new FarPoint.Win.Spread.CellType.ComboBoxCellType();
            FarPoint.Win.Spread.CellType.ButtonCellType buttonCellType4 = new FarPoint.Win.Spread.CellType.ButtonCellType();
            this.cdvDataList = new Miracom.UI.Controls.MCCodeView.MCSPCodeView();
            this.lisView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpSQL = new System.Windows.Forms.GroupBox();
            this.lblCreateUser = new System.Windows.Forms.Label();
            this.lblUpdateUser = new System.Windows.Forms.Label();
            this.txtCreateUser = new System.Windows.Forms.TextBox();
            this.txtUpdateTime = new System.Windows.Forms.TextBox();
            this.txtCreateTime = new System.Windows.Forms.TextBox();
            this.txtUpdateUser = new System.Windows.Forms.TextBox();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtViewID = new System.Windows.Forms.TextBox();
            this.lblViewID = new System.Windows.Forms.Label();
            this.tabDirectView = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpContents = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtQuery = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCopyClipboard = new System.Windows.Forms.Button();
            this.chkDictionary = new System.Windows.Forms.CheckBox();
            this.chkSample = new System.Windows.Forms.CheckBox();
            this.txtSample = new System.Windows.Forms.RichTextBox();
            this.pnlDictionary = new System.Windows.Forms.Panel();
            this.grpBGColor = new System.Windows.Forms.GroupBox();
            this.spdColors = new FarPoint.Win.Spread.FpSpread();
            this.spdColors_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.grpIcon = new System.Windows.Forms.GroupBox();
            this.spdIcons = new FarPoint.Win.Spread.FpSpread();
            this.spdIcons_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkBgColor = new System.Windows.Forms.CheckBox();
            this.chkIcon = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sptHeader = new System.Windows.Forms.SplitContainer();
            this.grpHeader = new System.Windows.Forms.GroupBox();
            this.spdHeader = new FarPoint.Win.Spread.FpSpread();
            this.spdHeader_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.plnHeader = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCheckAllHeader = new System.Windows.Forms.Button();
            this.btnGenName = new System.Windows.Forms.Button();
            this.grpColumns = new System.Windows.Forms.GroupBox();
            this.lisColumns = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlColumn = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grtTable = new System.Windows.Forms.GroupBox();
            this.lblTable = new System.Windows.Forms.Label();
            this.cdvTable = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.spdCondition = new FarPoint.Win.Spread.FpSpread();
            this.spdCondition_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtToViewID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.pnlFind.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).BeginInit();
            this.grpSQL.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.tabDirectView.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpContents.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlDictionary.SuspendLayout();
            this.grpBGColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdColors_Sheet1)).BeginInit();
            this.grpIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdIcons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdIcons_Sheet1)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptHeader)).BeginInit();
            this.sptHeader.Panel1.SuspendLayout();
            this.sptHeader.Panel2.SuspendLayout();
            this.sptHeader.SuspendLayout();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHeader_Sheet1)).BeginInit();
            this.plnHeader.SuspendLayout();
            this.grpColumns.SuspendLayout();
            this.pnlColumn.SuspendLayout();
            this.grtTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTable)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spdCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCondition_Sheet1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
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
            // splMain
            // 
            this.splMain.Size = new System.Drawing.Size(4, 513);
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tabDirectView);
            this.pnlRight.Controls.Add(this.grpGeneral);
            this.pnlRight.Size = new System.Drawing.Size(506, 513);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lisView);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(232, 513);
            // 
            // btnCreate
            // 
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
            this.pnlBottom.Location = new System.Drawing.Point(0, 513);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Size = new System.Drawing.Size(742, 513);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Text = "General Code Data Setup";
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
            // lisView
            // 
            this.lisView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lisView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisView.Location = new System.Drawing.Point(0, 0);
            this.lisView.Name = "lisView";
            this.lisView.Size = new System.Drawing.Size(232, 513);
            this.lisView.TabIndex = 0;
            this.lisView.UseCompatibleStateImageBehavior = false;
            this.lisView.View = System.Windows.Forms.View.Details;
            this.lisView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lisView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "View ID";
            this.columnHeader1.Width = 96;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 172;
            // 
            // grpSQL
            // 
            this.grpSQL.Controls.Add(this.lblCreateUser);
            this.grpSQL.Controls.Add(this.lblUpdateUser);
            this.grpSQL.Controls.Add(this.txtCreateUser);
            this.grpSQL.Controls.Add(this.txtUpdateTime);
            this.grpSQL.Controls.Add(this.txtCreateTime);
            this.grpSQL.Controls.Add(this.txtUpdateUser);
            this.grpSQL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpSQL.Location = new System.Drawing.Point(3, 335);
            this.grpSQL.Name = "grpSQL";
            this.grpSQL.Size = new System.Drawing.Size(492, 78);
            this.grpSQL.TabIndex = 1;
            this.grpSQL.TabStop = false;
            this.grpSQL.Text = "Create/Update Infomation";
            // 
            // lblCreateUser
            // 
            this.lblCreateUser.AutoSize = true;
            this.lblCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCreateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreateUser.Location = new System.Drawing.Point(15, 26);
            this.lblCreateUser.Name = "lblCreateUser";
            this.lblCreateUser.Size = new System.Drawing.Size(91, 13);
            this.lblCreateUser.TabIndex = 43;
            this.lblCreateUser.Text = "Create User/Time";
            // 
            // lblUpdateUser
            // 
            this.lblUpdateUser.AutoSize = true;
            this.lblUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUpdateUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUpdateUser.Location = new System.Drawing.Point(15, 53);
            this.lblUpdateUser.Name = "lblUpdateUser";
            this.lblUpdateUser.Size = new System.Drawing.Size(95, 13);
            this.lblUpdateUser.TabIndex = 46;
            this.lblUpdateUser.Text = "Update User/Time";
            // 
            // txtCreateUser
            // 
            this.txtCreateUser.Location = new System.Drawing.Point(118, 23);
            this.txtCreateUser.MaxLength = 20;
            this.txtCreateUser.Name = "txtCreateUser";
            this.txtCreateUser.ReadOnly = true;
            this.txtCreateUser.Size = new System.Drawing.Size(129, 20);
            this.txtCreateUser.TabIndex = 44;
            this.txtCreateUser.TabStop = false;
            // 
            // txtUpdateTime
            // 
            this.txtUpdateTime.Location = new System.Drawing.Point(253, 50);
            this.txtUpdateTime.MaxLength = 30;
            this.txtUpdateTime.Name = "txtUpdateTime";
            this.txtUpdateTime.ReadOnly = true;
            this.txtUpdateTime.Size = new System.Drawing.Size(223, 20);
            this.txtUpdateTime.TabIndex = 48;
            this.txtUpdateTime.TabStop = false;
            // 
            // txtCreateTime
            // 
            this.txtCreateTime.Location = new System.Drawing.Point(253, 23);
            this.txtCreateTime.MaxLength = 30;
            this.txtCreateTime.Name = "txtCreateTime";
            this.txtCreateTime.ReadOnly = true;
            this.txtCreateTime.Size = new System.Drawing.Size(223, 20);
            this.txtCreateTime.TabIndex = 45;
            this.txtCreateTime.TabStop = false;
            // 
            // txtUpdateUser
            // 
            this.txtUpdateUser.Location = new System.Drawing.Point(118, 50);
            this.txtUpdateUser.MaxLength = 20;
            this.txtUpdateUser.Name = "txtUpdateUser";
            this.txtUpdateUser.ReadOnly = true;
            this.txtUpdateUser.Size = new System.Drawing.Size(129, 20);
            this.txtUpdateUser.TabIndex = 47;
            this.txtUpdateUser.TabStop = false;
            // 
            // grpGeneral
            // 
            this.grpGeneral.Controls.Add(this.label1);
            this.grpGeneral.Controls.Add(this.txtDesc);
            this.grpGeneral.Controls.Add(this.txtViewID);
            this.grpGeneral.Controls.Add(this.lblViewID);
            this.grpGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGeneral.Location = new System.Drawing.Point(0, 0);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(506, 71);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Description";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(79, 42);
            this.txtDesc.MaxLength = 200;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(400, 20);
            this.txtDesc.TabIndex = 2;
            // 
            // txtViewID
            // 
            this.txtViewID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtViewID.Location = new System.Drawing.Point(79, 19);
            this.txtViewID.MaxLength = 30;
            this.txtViewID.Name = "txtViewID";
            this.txtViewID.Size = new System.Drawing.Size(206, 20);
            this.txtViewID.TabIndex = 1;
            // 
            // lblViewID
            // 
            this.lblViewID.AutoSize = true;
            this.lblViewID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblViewID.Location = new System.Drawing.Point(16, 23);
            this.lblViewID.Name = "lblViewID";
            this.lblViewID.Size = new System.Drawing.Size(44, 13);
            this.lblViewID.TabIndex = 21;
            this.lblViewID.Text = "View ID";
            // 
            // tabDirectView
            // 
            this.tabDirectView.Controls.Add(this.tabPage1);
            this.tabDirectView.Controls.Add(this.tabPage2);
            this.tabDirectView.Controls.Add(this.tabPage3);
            this.tabDirectView.Controls.Add(this.tabPage4);
            this.tabDirectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDirectView.Location = new System.Drawing.Point(0, 71);
            this.tabDirectView.Name = "tabDirectView";
            this.tabDirectView.SelectedIndex = 0;
            this.tabDirectView.Size = new System.Drawing.Size(506, 442);
            this.tabDirectView.TabIndex = 3;
            this.tabDirectView.SelectedIndexChanged += new System.EventHandler(this.tabDirectView_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.grpContents);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.grpSQL);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(498, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Query Setup";
            // 
            // grpContents
            // 
            this.grpContents.Controls.Add(this.panel1);
            this.grpContents.Controls.Add(this.pnlDictionary);
            this.grpContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpContents.Location = new System.Drawing.Point(3, 3);
            this.grpContents.Name = "grpContents";
            this.grpContents.Size = new System.Drawing.Size(492, 300);
            this.grpContents.TabIndex = 2;
            this.grpContents.TabStop = false;
            this.grpContents.Text = "Contents";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtQuery);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtSample);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 281);
            this.panel1.TabIndex = 2;
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(392, 242);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnConvert);
            this.panel2.Controls.Add(this.btnCopyClipboard);
            this.panel2.Controls.Add(this.chkDictionary);
            this.panel2.Controls.Add(this.chkSample);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 39);
            this.panel2.TabIndex = 0;
            // 
            // btnCopyClipboard
            // 
            this.btnCopyClipboard.Location = new System.Drawing.Point(250, 6);
            this.btnCopyClipboard.Name = "btnCopyClipboard";
            this.btnCopyClipboard.Size = new System.Drawing.Size(109, 26);
            this.btnCopyClipboard.TabIndex = 3;
            this.btnCopyClipboard.Text = "Copy to Clipboard";
            this.btnCopyClipboard.UseVisualStyleBackColor = true;
            this.btnCopyClipboard.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // chkDictionary
            // 
            this.chkDictionary.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDictionary.Location = new System.Drawing.Point(7, 6);
            this.chkDictionary.Name = "chkDictionary";
            this.chkDictionary.Size = new System.Drawing.Size(125, 26);
            this.chkDictionary.TabIndex = 2;
            this.chkDictionary.Text = "Display Icon && Color";
            this.chkDictionary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDictionary.UseVisualStyleBackColor = true;
            this.chkDictionary.CheckedChanged += new System.EventHandler(this.chkDictionary_CheckedChanged);
            // 
            // chkSample
            // 
            this.chkSample.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSample.Location = new System.Drawing.Point(136, 6);
            this.chkSample.Name = "chkSample";
            this.chkSample.Size = new System.Drawing.Size(109, 26);
            this.chkSample.TabIndex = 1;
            this.chkSample.Text = "Display Sample";
            this.chkSample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSample.UseVisualStyleBackColor = true;
            this.chkSample.CheckedChanged += new System.EventHandler(this.chkSample_CheckedChanged);
            // 
            // txtSample
            // 
            this.txtSample.BackColor = System.Drawing.SystemColors.Control;
            this.txtSample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSample.Location = new System.Drawing.Point(0, 0);
            this.txtSample.Name = "txtSample";
            this.txtSample.ReadOnly = true;
            this.txtSample.Size = new System.Drawing.Size(392, 281);
            this.txtSample.TabIndex = 1;
            this.txtSample.Text = resources.GetString("txtSample.Text");
            // 
            // pnlDictionary
            // 
            this.pnlDictionary.Controls.Add(this.grpBGColor);
            this.pnlDictionary.Controls.Add(this.grpIcon);
            this.pnlDictionary.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDictionary.Location = new System.Drawing.Point(395, 16);
            this.pnlDictionary.Name = "pnlDictionary";
            this.pnlDictionary.Size = new System.Drawing.Size(94, 281);
            this.pnlDictionary.TabIndex = 1;
            // 
            // grpBGColor
            // 
            this.grpBGColor.Controls.Add(this.spdColors);
            this.grpBGColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBGColor.Location = new System.Drawing.Point(194, 0);
            this.grpBGColor.Name = "grpBGColor";
            this.grpBGColor.Size = new System.Drawing.Size(0, 281);
            this.grpBGColor.TabIndex = 1;
            this.grpBGColor.TabStop = false;
            this.grpBGColor.Text = "Colors";
            // 
            // spdColors
            // 
            this.spdColors.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.spdColors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdColors.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdColors.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdColors.HorizontalScrollBar.Name = "";
            this.spdColors.HorizontalScrollBar.Renderer = defaultScrollBarRenderer5;
            this.spdColors.HorizontalScrollBar.TabIndex = 0;
            this.spdColors.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdColors.Location = new System.Drawing.Point(3, 16);
            this.spdColors.Name = "spdColors";
            this.spdColors.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdColors.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdColors_Sheet1});
            this.spdColors.Size = new System.Drawing.Size(0, 262);
            this.spdColors.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdColors.TabIndex = 2;
            this.spdColors.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdColors.VerticalScrollBar.Name = "";
            this.spdColors.VerticalScrollBar.Renderer = defaultScrollBarRenderer6;
            this.spdColors.VerticalScrollBar.TabIndex = 15;
            this.spdColors.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdColors.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdColors_Sheet1
            // 
            this.spdColors_Sheet1.Reset();
            spdColors_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdColors_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdColors_Sheet1.ColumnCount = 2;
            spdColors_Sheet1.RowCount = 1;
            this.spdColors_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdColors_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdColors_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdColors_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdColors_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Color";
            this.spdColors_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Name";
            this.spdColors_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdColors_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            imageCellType7.Style = FarPoint.Win.RenderStyle.Normal;
            imageCellType7.TransparencyColor = System.Drawing.Color.Empty;
            imageCellType7.TransparencyTolerance = 0;
            this.spdColors_Sheet1.Columns.Get(0).CellType = imageCellType7;
            this.spdColors_Sheet1.Columns.Get(0).Label = "Color";
            this.spdColors_Sheet1.Columns.Get(0).Width = 33F;
            this.spdColors_Sheet1.Columns.Get(1).Label = "Name";
            this.spdColors_Sheet1.Columns.Get(1).Width = 96F;
            this.spdColors_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdColors_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdColors_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdColors_Sheet1.RowHeader.Visible = false;
            this.spdColors_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdColors_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdColors_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // grpIcon
            // 
            this.grpIcon.Controls.Add(this.spdIcons);
            this.grpIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpIcon.Location = new System.Drawing.Point(0, 0);
            this.grpIcon.Name = "grpIcon";
            this.grpIcon.Size = new System.Drawing.Size(194, 281);
            this.grpIcon.TabIndex = 0;
            this.grpIcon.TabStop = false;
            this.grpIcon.Text = "Icons";
            // 
            // spdIcons
            // 
            this.spdIcons.AccessibleDescription = "fpSpread1, Sheet1, Row 0, Column 0, ";
            this.spdIcons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdIcons.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdIcons.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdIcons.HorizontalScrollBar.Name = "";
            this.spdIcons.HorizontalScrollBar.Renderer = defaultScrollBarRenderer7;
            this.spdIcons.HorizontalScrollBar.TabIndex = 0;
            this.spdIcons.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.spdIcons.Location = new System.Drawing.Point(3, 16);
            this.spdIcons.Name = "spdIcons";
            this.spdIcons.ScrollBarTrackPolicy = FarPoint.Win.Spread.ScrollBarTrackPolicy.Vertical;
            this.spdIcons.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdIcons_Sheet1});
            this.spdIcons.Size = new System.Drawing.Size(188, 262);
            this.spdIcons.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdIcons.TabIndex = 1;
            this.spdIcons.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdIcons.VerticalScrollBar.Name = "";
            this.spdIcons.VerticalScrollBar.Renderer = defaultScrollBarRenderer8;
            this.spdIcons.VerticalScrollBar.TabIndex = 13;
            this.spdIcons.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdIcons.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // spdIcons_Sheet1
            // 
            this.spdIcons_Sheet1.Reset();
            spdIcons_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdIcons_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdIcons_Sheet1.ColumnCount = 2;
            spdIcons_Sheet1.RowCount = 1;
            this.spdIcons_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdIcons_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdIcons_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdIcons_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdIcons_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Icon";
            this.spdIcons_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Name";
            this.spdIcons_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdIcons_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            imageCellType8.Style = FarPoint.Win.RenderStyle.Normal;
            imageCellType8.TransparencyColor = System.Drawing.Color.Empty;
            imageCellType8.TransparencyTolerance = 0;
            this.spdIcons_Sheet1.Columns.Get(0).CellType = imageCellType8;
            this.spdIcons_Sheet1.Columns.Get(0).Label = "Icon";
            this.spdIcons_Sheet1.Columns.Get(0).Width = 33F;
            this.spdIcons_Sheet1.Columns.Get(1).Label = "Name";
            this.spdIcons_Sheet1.Columns.Get(1).Width = 96F;
            this.spdIcons_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdIcons_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdIcons_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdIcons_Sheet1.RowHeader.Visible = false;
            this.spdIcons_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdIcons_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdIcons_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkBgColor);
            this.panel4.Controls.Add(this.chkIcon);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 303);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(492, 32);
            this.panel4.TabIndex = 3;
            // 
            // chkBgColor
            // 
            this.chkBgColor.AutoSize = true;
            this.chkBgColor.Location = new System.Drawing.Point(98, 7);
            this.chkBgColor.Name = "chkBgColor";
            this.chkBgColor.Size = new System.Drawing.Size(85, 17);
            this.chkBgColor.TabIndex = 1;
            this.chkBgColor.Text = "Use BgColor";
            this.chkBgColor.UseVisualStyleBackColor = true;
            // 
            // chkIcon
            // 
            this.chkIcon.AutoSize = true;
            this.chkIcon.Location = new System.Drawing.Point(12, 7);
            this.chkIcon.Name = "chkIcon";
            this.chkIcon.Size = new System.Drawing.Size(69, 17);
            this.chkIcon.TabIndex = 0;
            this.chkIcon.Text = "Use Icon";
            this.chkIcon.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.sptHeader);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(498, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Header Setup";
            // 
            // sptHeader
            // 
            this.sptHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptHeader.Location = new System.Drawing.Point(3, 3);
            this.sptHeader.Name = "sptHeader";
            // 
            // sptHeader.Panel1
            // 
            this.sptHeader.Panel1.Controls.Add(this.grpHeader);
            // 
            // sptHeader.Panel2
            // 
            this.sptHeader.Panel2.Controls.Add(this.grpColumns);
            this.sptHeader.Panel2.Controls.Add(this.pnlColumn);
            this.sptHeader.Panel2.Controls.Add(this.grtTable);
            this.sptHeader.Size = new System.Drawing.Size(492, 403);
            this.sptHeader.SplitterDistance = 228;
            this.sptHeader.TabIndex = 4;
            // 
            // grpHeader
            // 
            this.grpHeader.Controls.Add(this.spdHeader);
            this.grpHeader.Controls.Add(this.plnHeader);
            this.grpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHeader.Location = new System.Drawing.Point(0, 0);
            this.grpHeader.Name = "grpHeader";
            this.grpHeader.Size = new System.Drawing.Size(228, 403);
            this.grpHeader.TabIndex = 3;
            this.grpHeader.TabStop = false;
            this.grpHeader.Text = "Headers";
            // 
            // spdHeader
            // 
            this.spdHeader.AccessibleDescription = "spdHeader, Sheet1, Row 0, Column 0, ";
            this.spdHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdHeader.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdHeader.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHeader.HorizontalScrollBar.Name = "";
            this.spdHeader.HorizontalScrollBar.Renderer = defaultScrollBarRenderer9;
            this.spdHeader.HorizontalScrollBar.TabIndex = 8;
            this.spdHeader.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHeader.Location = new System.Drawing.Point(3, 16);
            this.spdHeader.Name = "spdHeader";
            this.spdHeader.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdHeader_Sheet1});
            this.spdHeader.Size = new System.Drawing.Size(222, 319);
            this.spdHeader.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdHeader.TabIndex = 0;
            this.spdHeader.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdHeader.VerticalScrollBar.Name = "";
            this.spdHeader.VerticalScrollBar.Renderer = defaultScrollBarRenderer10;
            this.spdHeader.VerticalScrollBar.TabIndex = 9;
            this.spdHeader.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdHeader.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdHeader.EditModeOff += new System.EventHandler(this.spdHeader_EditModeOff);
            // 
            // spdHeader_Sheet1
            // 
            this.spdHeader_Sheet1.Reset();
            spdHeader_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdHeader_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdHeader_Sheet1.ColumnCount = 4;
            spdHeader_Sheet1.RowCount = 1;
            this.spdHeader_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHeader_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdHeader_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHeader_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdHeader_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdHeader_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Header";
            this.spdHeader_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Display";
            this.spdHeader_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Description";
            this.spdHeader_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHeader_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdHeader_Sheet1.Columns.Get(0).CellType = checkBoxCellType10;
            this.spdHeader_Sheet1.Columns.Get(0).Label = "Header";
            this.spdHeader_Sheet1.Columns.Get(0).Width = 22F;
            this.spdHeader_Sheet1.Columns.Get(1).Width = 152F;
            this.spdHeader_Sheet1.Columns.Get(2).Label = "Display";
            this.spdHeader_Sheet1.Columns.Get(2).Width = 103F;
            this.spdHeader_Sheet1.Columns.Get(3).Label = "Description";
            this.spdHeader_Sheet1.Columns.Get(3).Width = 259F;
            this.spdHeader_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdHeader_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHeader_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdHeader_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdHeader_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdHeader_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // plnHeader
            // 
            this.plnHeader.Controls.Add(this.btnClear);
            this.plnHeader.Controls.Add(this.btnCheckAllHeader);
            this.plnHeader.Controls.Add(this.btnGenName);
            this.plnHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plnHeader.Location = new System.Drawing.Point(3, 335);
            this.plnHeader.Name = "plnHeader";
            this.plnHeader.Size = new System.Drawing.Size(222, 65);
            this.plnHeader.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(130, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 26);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCheckAllHeader
            // 
            this.btnCheckAllHeader.Location = new System.Drawing.Point(5, 5);
            this.btnCheckAllHeader.Name = "btnCheckAllHeader";
            this.btnCheckAllHeader.Size = new System.Drawing.Size(91, 26);
            this.btnCheckAllHeader.TabIndex = 6;
            this.btnCheckAllHeader.Text = "Check All";
            this.btnCheckAllHeader.UseVisualStyleBackColor = true;
            this.btnCheckAllHeader.Click += new System.EventHandler(this.btnCheckAllHeader_Click);
            // 
            // btnGenName
            // 
            this.btnGenName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenName.Location = new System.Drawing.Point(5, 35);
            this.btnGenName.Name = "btnGenName";
            this.btnGenName.Size = new System.Drawing.Size(212, 26);
            this.btnGenName.TabIndex = 5;
            this.btnGenName.Text = "Generate Display Header ( For English)";
            this.btnGenName.UseVisualStyleBackColor = true;
            this.btnGenName.Click += new System.EventHandler(this.btnGenName_Click);
            // 
            // grpColumns
            // 
            this.grpColumns.Controls.Add(this.lisColumns);
            this.grpColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpColumns.Location = new System.Drawing.Point(0, 55);
            this.grpColumns.Name = "grpColumns";
            this.grpColumns.Size = new System.Drawing.Size(260, 308);
            this.grpColumns.TabIndex = 1;
            this.grpColumns.TabStop = false;
            this.grpColumns.Text = "Columns";
            // 
            // lisColumns
            // 
            this.lisColumns.CheckBoxes = true;
            this.lisColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lisColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisColumns.Location = new System.Drawing.Point(3, 16);
            this.lisColumns.Name = "lisColumns";
            this.lisColumns.Size = new System.Drawing.Size(254, 289);
            this.lisColumns.TabIndex = 0;
            this.lisColumns.UseCompatibleStateImageBehavior = false;
            this.lisColumns.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Column";
            this.columnHeader3.Width = 137;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type/Size";
            this.columnHeader4.Width = 69;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Description";
            // 
            // pnlColumn
            // 
            this.pnlColumn.Controls.Add(this.btnAll);
            this.pnlColumn.Controls.Add(this.btnReplace);
            this.pnlColumn.Controls.Add(this.btnAdd);
            this.pnlColumn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlColumn.Location = new System.Drawing.Point(0, 363);
            this.pnlColumn.Name = "pnlColumn";
            this.pnlColumn.Size = new System.Drawing.Size(260, 40);
            this.pnlColumn.TabIndex = 4;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(5, 7);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(72, 26);
            this.btnAll.TabIndex = 4;
            this.btnAll.Text = "Check All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplace.Location = new System.Drawing.Point(78, 7);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(88, 26);
            this.btnReplace.TabIndex = 2;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(169, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 26);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grtTable
            // 
            this.grtTable.Controls.Add(this.lblTable);
            this.grtTable.Controls.Add(this.cdvTable);
            this.grtTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grtTable.Location = new System.Drawing.Point(0, 0);
            this.grtTable.Name = "grtTable";
            this.grtTable.Size = new System.Drawing.Size(260, 55);
            this.grtTable.TabIndex = 0;
            this.grtTable.TabStop = false;
            this.grtTable.Text = "Table";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTable.Location = new System.Drawing.Point(11, 22);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(65, 13);
            this.lblTable.TabIndex = 22;
            this.lblTable.Text = "Table Name";
            // 
            // cdvTable
            // 
            this.cdvTable.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTable.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTable.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvTable.BtnToolTipText = "";
            this.cdvTable.ButtonWidth = 20;
            this.cdvTable.DescText = "";
            this.cdvTable.DisplaySubItemIndex = -1;
            this.cdvTable.DisplayText = "";
            this.cdvTable.Focusing = null;
            this.cdvTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvTable.Index = 0;
            this.cdvTable.IsViewBtnImage = false;
            this.cdvTable.Location = new System.Drawing.Point(108, 19);
            this.cdvTable.MaxLength = 10;
            this.cdvTable.MCViewStyle.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvTable.MCViewStyle.BorderHotColor = System.Drawing.Color.Black;
            this.cdvTable.MultiSelect = false;
            this.cdvTable.Name = "cdvTable";
            this.cdvTable.ReadOnly = false;
            this.cdvTable.SameWidthHeightOfButton = false;
            this.cdvTable.SearchSubItemIndex = 0;
            this.cdvTable.SelectedDescIndex = -1;
            this.cdvTable.SelectedDescToQueryText = "";
            this.cdvTable.SelectedSubItemIndex = -1;
            this.cdvTable.SelectedValueToQueryText = "";
            this.cdvTable.SelectionStart = 0;
            this.cdvTable.Size = new System.Drawing.Size(136, 21);
            this.cdvTable.SmallImageList = null;
            this.cdvTable.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvTable.TabIndex = 2;
            this.cdvTable.TextBoxToolTipText = "";
            this.cdvTable.TextBoxWidth = 136;
            this.cdvTable.VisibleButton = true;
            this.cdvTable.VisibleColumnHeader = false;
            this.cdvTable.VisibleDescription = false;
            this.cdvTable.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvTable_SelectedItemChanged);
            this.cdvTable.ButtonPress += new System.EventHandler(this.cdvTable_ButtonPress);
            this.cdvTable.TextBoxKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cdvTable_TextBoxKeyPress);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.spdCondition);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(498, 409);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Conditions";
            // 
            // spdCondition
            // 
            this.spdCondition.AccessibleDescription = "spdCondition, Sheet1, Row 0, Column 0, ";
            this.spdCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spdCondition.FocusRenderer = defaultFocusIndicatorRenderer2;
            this.spdCondition.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCondition.HorizontalScrollBar.Name = "";
            this.spdCondition.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.spdCondition.HorizontalScrollBar.TabIndex = 0;
            this.spdCondition.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCondition.Location = new System.Drawing.Point(0, 0);
            this.spdCondition.Name = "spdCondition";
            this.spdCondition.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.spdCondition_Sheet1});
            this.spdCondition.Size = new System.Drawing.Size(498, 366);
            this.spdCondition.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.spdCondition.TabIndex = 1;
            this.spdCondition.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.spdCondition.VerticalScrollBar.Name = "";
            this.spdCondition.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.spdCondition.VerticalScrollBar.TabIndex = 15;
            this.spdCondition.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.spdCondition.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.spdCondition.EditModeOff += new System.EventHandler(this.spdCondition_EditModeOff);
            this.spdCondition.ButtonClicked += new FarPoint.Win.Spread.EditorNotifyEventHandler(this.spdCondition_ButtonClicked);
            // 
            // spdCondition_Sheet1
            // 
            this.spdCondition_Sheet1.Reset();
            spdCondition_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.spdCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            spdCondition_Sheet1.ColumnCount = 8;
            spdCondition_Sheet1.RowCount = 1;
            this.spdCondition_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCondition_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.spdCondition_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCondition_Sheet1.ColumnFooterSheetCornerStyle.Parent = "CornerDefault";
            this.spdCondition_Sheet1.ColumnHeader.Cells.Get(0, 0).ColumnSpan = 2;
            this.spdCondition_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Condition Name";
            this.spdCondition_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Description";
            this.spdCondition_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Required";
            this.spdCondition_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Data Type";
            this.spdCondition_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Input Type";
            this.spdCondition_Sheet1.ColumnHeader.Cells.Get(0, 6).ColumnSpan = 2;
            this.spdCondition_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Table Name";
            this.spdCondition_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCondition_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.spdCondition_Sheet1.Columns.Get(0).CellType = checkBoxCellType11;
            this.spdCondition_Sheet1.Columns.Get(0).Label = "Condition Name";
            this.spdCondition_Sheet1.Columns.Get(0).Width = 22F;
            this.spdCondition_Sheet1.Columns.Get(1).Width = 103F;
            this.spdCondition_Sheet1.Columns.Get(2).Label = "Description";
            this.spdCondition_Sheet1.Columns.Get(2).Width = 134F;
            this.spdCondition_Sheet1.Columns.Get(3).CellType = checkBoxCellType12;
            this.spdCondition_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.spdCondition_Sheet1.Columns.Get(3).Label = "Required";
            this.spdCondition_Sheet1.Columns.Get(3).Width = 54F;
            comboBoxCellType7.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType7.Items = new string[] {
        "String",
        "Number"};
            this.spdCondition_Sheet1.Columns.Get(4).CellType = comboBoxCellType7;
            this.spdCondition_Sheet1.Columns.Get(4).Label = "Data Type";
            this.spdCondition_Sheet1.Columns.Get(4).Width = 91F;
            comboBoxCellType8.ButtonAlign = FarPoint.Win.ButtonAlign.Right;
            comboBoxCellType8.Items = new string[] {
        "GCM Table",
        "Direct View",
        "TextBox"};
            this.spdCondition_Sheet1.Columns.Get(5).CellType = comboBoxCellType8;
            this.spdCondition_Sheet1.Columns.Get(5).Label = "Input Type";
            this.spdCondition_Sheet1.Columns.Get(5).Width = 90F;
            this.spdCondition_Sheet1.Columns.Get(6).Label = "Table Name";
            this.spdCondition_Sheet1.Columns.Get(6).Width = 112F;
            buttonCellType4.ButtonColor2 = System.Drawing.SystemColors.ButtonFace;
            buttonCellType4.Text = "...";
            this.spdCondition_Sheet1.Columns.Get(7).CellType = buttonCellType4;
            this.spdCondition_Sheet1.Columns.Get(7).Width = 23F;
            this.spdCondition_Sheet1.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCondition_Sheet1.DefaultStyle.Parent = "DataAreaDefault";
            this.spdCondition_Sheet1.DefaultStyle.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.spdCondition_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.spdCondition_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCondition_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.spdCondition_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.spdCondition_Sheet1.SheetCornerStyle.Parent = "CornerDefault";
            this.spdCondition_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDeleteRow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 366);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(498, 43);
            this.panel3.TabIndex = 2;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRow.Location = new System.Drawing.Point(402, 8);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(88, 26);
            this.btnDeleteRow.TabIndex = 0;
            this.btnDeleteRow.Text = "Delete Row";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.btnCopy);
            this.tabPage4.Controls.Add(this.txtToViewID);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(498, 409);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Copy";
            // 
            // btnCopy
            // 
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCopy.Location = new System.Drawing.Point(287, 6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(88, 26);
            this.btnCopy.TabIndex = 27;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtToViewID
            // 
            this.txtToViewID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtToViewID.Location = new System.Drawing.Point(75, 8);
            this.txtToViewID.MaxLength = 30;
            this.txtToViewID.Name = "txtToViewID";
            this.txtToViewID.Size = new System.Drawing.Size(206, 20);
            this.txtToViewID.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "To View ID";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(364, 6);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(132, 26);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert Query( :->$ )";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // frmDNMSetupDirectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(742, 553);
            this.Name = "frmDNMSetupDirectView";
            this.Text = "Direct View Setup";
            this.Activated += new System.EventHandler(this.frmDNMSetupDirectView_Activated);
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
            ((System.ComponentModel.ISupportInitialize)(this.cdvDataList)).EndInit();
            this.grpSQL.ResumeLayout(false);
            this.grpSQL.PerformLayout();
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.tabDirectView.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpContents.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlDictionary.ResumeLayout(false);
            this.grpBGColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdColors_Sheet1)).EndInit();
            this.grpIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdIcons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdIcons_Sheet1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.sptHeader.Panel1.ResumeLayout(false);
            this.sptHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptHeader)).EndInit();
            this.sptHeader.ResumeLayout(false);
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdHeader_Sheet1)).EndInit();
            this.plnHeader.ResumeLayout(false);
            this.grpColumns.ResumeLayout(false);
            this.pnlColumn.ResumeLayout(false);
            this.grtTable.ResumeLayout(false);
            this.grtTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvTable)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spdCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spdCondition_Sheet1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region " Constant Definition "

       

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
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition(string FuncName, char ProcStep)
        {

            try
            {
                switch (MPCF.Trim(FuncName))
                {
                    case "UPDATE_VIEW":

                        break;
                    case "VIEW_VIEW":

                        break;

                    case "COPY_DIRECT_VIEW":

                        if (MPCF.CheckValue(txtViewID, 1) == false)
                            return false;

                        if (MPCF.CheckValue(txtToViewID, 1) == false)
                            return false;

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
        // ViewDirectViewList()
        //       - View Direct View List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDirectViewList()
        {
            TRSNode in_node = new TRSNode("VIEW_DATA_LIST_IN");
            TRSNode out_node;

            ListViewItem itemX;
            int i;

            try
            {
                MPCF.ClearList(lisView);
                
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                
                do
                {
                    out_node = new TRSNode("VIEW_DIRECT_VIEW_LIST_OUT");

                    if (MPCR.CallService("DNM", "DNM_View_Direct_View_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("LIST").Count; i++)
                    {
                        itemX = new ListViewItem(out_node.GetList("LIST")[i].GetString("VIEW_ID"), (int)SMALLICON_INDEX.IDX_INQUIRY);
                        itemX.SubItems.Add(out_node.GetList("LIST")[i].GetString("VIEW_DESC"));
                        
                        lisView.Items.Add(itemX);
                    }
                    
                    in_node.SetString("NEXT_VIEW_ID", out_node.GetString("NEXT_VIEW_ID"));

                } while (in_node.GetString("NEXT_VIEW_ID") != "");

                //MPCF.FitColumnHeader(lisView);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
        //
        // ViewDirectViewHeaderList()
        //       - View Direct View Header List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDirectViewHeaderList()
        {
            TRSNode in_node = new TRSNode("VIEW_DIRECT_VIEW_HEADER_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DIRECT_VIEW_HEADER_LIST_OUT");

            ListViewItem itemX;
            int i;
            int iIndex;

            try
            {
                spdHeader.ActiveSheet.RowCount = 0;


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("VIEW_ID", txtViewID.Text);

                do
                {

                    if (MPCR.CallService("DNM", "DNM_View_Direct_View_Header_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("LIST").Count; i++)
                    {
                        spdHeader.ActiveSheet.RowCount++;
                        spdHeader.ActiveSheet.Cells[i, 0].Value = false;
                        spdHeader.ActiveSheet.Cells[i, 1].Text = out_node.GetList("LIST")[i].GetString("COL_NAME");
                        spdHeader.ActiveSheet.Cells[i, 2].Text = out_node.GetList("LIST")[i].GetString("DISPLAY_NAME");
                        spdHeader.ActiveSheet.Cells[i, 3].Text = out_node.GetList("LIST")[i].GetString("COL_DESC");
                    }

                    in_node.SetString("NEXT_VIEW_ID", out_node.GetString("NEXT_VIEW_ID"));

                } while (in_node.GetString("NEXT_VIEW_ID") != "");

                spdHeader.ActiveSheet.RowCount++;
                spdHeader.ActiveSheet.Cells[spdHeader.ActiveSheet.RowCount - 1, 0].Value = false;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }

        //
        // UpdateDirectViewHeader()
        //       - Create/Update/Delete Direct View
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool UpdateDirectViewHeader(char ProcStep)
        {
            int i = 0;
            TRSNode in_node = new TRSNode("UPDATE_DIRECT_VIEW_HEADER_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.SetString("VIEW_ID", txtViewID.Text);

                for (i = 0; i < spdHeader.ActiveSheet.RowCount-1; i++)
                {
                    if ((bool)spdHeader.ActiveSheet.Cells[i, 0].Value != true )
                        continue;

                    node = in_node.AddNode("LIST");
                    node.SetString("COL_NAME", spdHeader.ActiveSheet.Cells[i,1].Text);
                    node.SetString("DISPLAY_NAME", spdHeader.ActiveSheet.Cells[i, 2].Text);
                    node.SetString("COL_DESC", spdHeader.ActiveSheet.Cells[i, 3].Text);
                    
                }

                if (MPCR.CallService("DNM", "DNM_Multi_Update_Direct_View_Header", in_node, ref out_node) == false)
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

        //
        // UpdateDirectView()
        //       - Create/Update/Delete Direct View
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool UpdateDirectView(char ProcStep)
        {
            int i = 0;
            TRSNode in_node = new TRSNode("UPDATE_DIRECT_VIEW_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;

                in_node.SetString("VIEW_ID", txtViewID.Text);
                in_node.SetString("VIEW_DESC", txtDesc.Text);
                in_node.SetString("SQL_1", txtQuery.Text);

                in_node.SetString("TO_VIEW_ID", txtToViewID.Text);

                if (txtQuery.Text.Length > 7000)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(278));
                    return false;
                }

                if (txtQuery.Text.Length > 3000)
                {
                    in_node.SetString("SQL_1", txtQuery.Text.Substring(0,3000));
                    in_node.SetString("SQL_2", txtQuery.Text.Substring(3000,txtQuery.Text.Length-3000));
                }
                else
                    in_node.SetString("SQL_1", txtQuery.Text);


                //icon, bgcolor flag 추가
                in_node.SetChar("USE_ICON_FLAG", chkIcon.Checked ? 'Y' : 'N');
                in_node.SetChar("USE_BGCOLOR_FLAG", chkBgColor.Checked ? 'Y' : 'N');

                if (MPCR.CallService("DNM", "DNM_Update_Direct_View", in_node, ref out_node) == false)
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

        //
        // ViewDirectView()
        //       - Single View Direct View
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDirectView()
        {
            TRSNode in_node = new TRSNode("VIEW_DIRECT_VIEW_IN");
            TRSNode out_node = new TRSNode("VIEW_DIRECT_VIEW_OUT");

            try
            {
                
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';

                in_node.SetString("VIEW_ID", txtViewID.Text);

                if (MPCR.CallService("DNM", "DNM_View_Direct_View", in_node, ref out_node) == false)
                {
                    return false;
                }

                txtDesc.Text = out_node.GetString("VIEW_DESC");
                txtQuery.Text = out_node.GetString("SQL_1")+out_node.GetString("SQL_2")+out_node.GetString("SQL_3")+
                    out_node.GetString("SQL_4")+out_node.GetString("SQL_5")+out_node.GetString("SQL_6")+
                    out_node.GetString("SQL_7")+out_node.GetString("SQL_8")+out_node.GetString("SQL_9")+
                    out_node.GetString("SQL_10");
                //icon, bgcolor flag 추가
                chkIcon.Checked = out_node.GetChar("USE_ICON_FLAG") == 'Y' ? true : false;
                chkBgColor.Checked = out_node.GetChar("USE_BGCOLOR_FLAG") == 'Y' ? true : false;
                txtCreateTime.Text = MPCF.MakeDateFormat(out_node.GetString("CREATE_TIME"));
                txtCreateUser.Text = out_node.GetString("CREATE_USER_ID");
                txtUpdateTime.Text = MPCF.MakeDateFormat(out_node.GetString("UPDATE_TIME"));
                txtUpdateUser.Text = out_node.GetString("UPDATE_USER_ID");
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;
        }
        private void DisplayDictionary()
        {
            int i;
            ImageList iTemp = MPGV.gIMdiForm.GetSmallIconList();



            spdIcons.ActiveSheet.RowCount = 0;
            spdIcons.ActiveSheet.RowCount = 101;
            spdIcons.ActiveSheet.Cells[0, 1].Text = "FACTORY";
            spdIcons.ActiveSheet.Cells[1, 1].Text = "SHIP_FACTORY";
            spdIcons.ActiveSheet.Cells[2, 1].Text = "TRANSACTION";
            spdIcons.ActiveSheet.Cells[3, 1].Text = "SETUP";
            spdIcons.ActiveSheet.Cells[4, 1].Text = "EVENT";
            spdIcons.ActiveSheet.Cells[5, 1].Text = "CODE_TABLE";
            spdIcons.ActiveSheet.Cells[6, 1].Text = "CODE_DATA";
            spdIcons.ActiveSheet.Cells[7, 1].Text = "MATERIAL";
            spdIcons.ActiveSheet.Cells[8, 1].Text = "FLOW";
            spdIcons.ActiveSheet.Cells[9, 1].Text = "REWORK_FLOW";
            spdIcons.ActiveSheet.Cells[10, 1].Text = "OPER";
            spdIcons.ActiveSheet.Cells[11, 1].Text = "MFO";
            spdIcons.ActiveSheet.Cells[12, 1].Text = "SEC_GROUP";
            spdIcons.ActiveSheet.Cells[13, 1].Text = "USER";
            spdIcons.ActiveSheet.Cells[14, 1].Text = "RESOURCE";
            spdIcons.ActiveSheet.Cells[15, 1].Text = "RESOURCE_PROC";
            spdIcons.ActiveSheet.Cells[16, 1].Text = "RESOURCE_DOWN";
            spdIcons.ActiveSheet.Cells[17, 1].Text = "RESOURCE_GROUP";
            spdIcons.ActiveSheet.Cells[18, 1].Text = "SUB_EQUIP";
            spdIcons.ActiveSheet.Cells[19, 1].Text = "STATUS";
            spdIcons.ActiveSheet.Cells[20, 1].Text = "CHARACTER";
            spdIcons.ActiveSheet.Cells[21, 1].Text = "COL_SET";
            spdIcons.ActiveSheet.Cells[22, 1].Text = "COL_SET_VERSION";
            spdIcons.ActiveSheet.Cells[23, 1].Text = "COL_SET_DELETE";
            spdIcons.ActiveSheet.Cells[24, 1].Text = "COL_SET_AUTO";
            spdIcons.ActiveSheet.Cells[25, 1].Text = "CARRIER";
            spdIcons.ActiveSheet.Cells[26, 1].Text = "CARRIER_EMPTY";
            spdIcons.ActiveSheet.Cells[27, 1].Text = "CARRIER_FULL";
            spdIcons.ActiveSheet.Cells[28, 1].Text = "LOT";
            spdIcons.ActiveSheet.Cells[29, 1].Text = "LOT_CHECK";
            spdIcons.ActiveSheet.Cells[30, 1].Text = "LOT_HOLD";
            spdIcons.ActiveSheet.Cells[31, 1].Text = "LOT_HOLD_CHECK";
            spdIcons.ActiveSheet.Cells[32, 1].Text = "LOT_RELEASE";
            spdIcons.ActiveSheet.Cells[33, 1].Text = "LOT_REWORK";
            spdIcons.ActiveSheet.Cells[34, 1].Text = "LOT_REWORK_CHECK";
            spdIcons.ActiveSheet.Cells[35, 1].Text = "LOT_ALTER";
            spdIcons.ActiveSheet.Cells[36, 1].Text = "LOT_ALTER_CHECK";
            spdIcons.ActiveSheet.Cells[37, 1].Text = "LOT_START";
            spdIcons.ActiveSheet.Cells[38, 1].Text = "LOT_START_CHECK";
            spdIcons.ActiveSheet.Cells[39, 1].Text = "CHART";
            spdIcons.ActiveSheet.Cells[40, 1].Text = "CHART_LINE";
            spdIcons.ActiveSheet.Cells[41, 1].Text = "LOG_SHEET";
            spdIcons.ActiveSheet.Cells[42, 1].Text = "AREA";
            spdIcons.ActiveSheet.Cells[43, 1].Text = "SUB_AREA";
            spdIcons.ActiveSheet.Cells[44, 1].Text = "FUNCTION_GROUP";
            spdIcons.ActiveSheet.Cells[45, 1].Text = "FUNCTION";
            spdIcons.ActiveSheet.Cells[46, 1].Text = "MESSAGE_GROUP";
            spdIcons.ActiveSheet.Cells[47, 1].Text = "MESSAGE";
            spdIcons.ActiveSheet.Cells[48, 1].Text = "PRIORITY";
            spdIcons.ActiveSheet.Cells[49, 1].Text = "BOM";
            spdIcons.ActiveSheet.Cells[50, 1].Text = "PORT";
            spdIcons.ActiveSheet.Cells[51, 1].Text = "ORDER";
            spdIcons.ActiveSheet.Cells[52, 1].Text = "ORDER_DELETE";
            spdIcons.ActiveSheet.Cells[53, 1].Text = "PART";
            spdIcons.ActiveSheet.Cells[54, 1].Text = "INQUIRY";
            spdIcons.ActiveSheet.Cells[55, 1].Text = "SUB_LOT";
            spdIcons.ActiveSheet.Cells[56, 1].Text = "HISTORY";
            spdIcons.ActiveSheet.Cells[57, 1].Text = "HISTORY_DELETE";
            spdIcons.ActiveSheet.Cells[58, 1].Text = "ALARM";
            spdIcons.ActiveSheet.Cells[59, 1].Text = "DEPARTMENT";
            spdIcons.ActiveSheet.Cells[60, 1].Text = "CALENDAR";
            spdIcons.ActiveSheet.Cells[61, 1].Text = "KEY";
            spdIcons.ActiveSheet.Cells[62, 1].Text = "CUSTOMER";
            spdIcons.ActiveSheet.Cells[63, 1].Text = "CATEGORY";
            spdIcons.ActiveSheet.Cells[64, 1].Text = "YEAR";
            spdIcons.ActiveSheet.Cells[65, 1].Text = "MONTH";
            spdIcons.ActiveSheet.Cells[66, 1].Text = "PM";
            spdIcons.ActiveSheet.Cells[67, 1].Text = "POLICY";
            spdIcons.ActiveSheet.Cells[68, 1].Text = "OPTION";
            spdIcons.ActiveSheet.Cells[69, 1].Text = "SLOT_EMPTY";
            spdIcons.ActiveSheet.Cells[70, 1].Text = "SLOT_FULL";
            spdIcons.ActiveSheet.Cells[71, 1].Text = "SLOT_FULL_NEW";
            spdIcons.ActiveSheet.Cells[72, 1].Text = "SLOT_COMBINE";
            spdIcons.ActiveSheet.Cells[73, 1].Text = "RECIPE";
            spdIcons.ActiveSheet.Cells[74, 1].Text = "STOCKER";
            spdIcons.ActiveSheet.Cells[75, 1].Text = "PRIVILEGE";
            spdIcons.ActiveSheet.Cells[76, 1].Text = "PRIVILEGE_GROUP";
            spdIcons.ActiveSheet.Cells[77, 1].Text = "LABEL";
            spdIcons.ActiveSheet.Cells[78, 1].Text = "TOOL";
            spdIcons.ActiveSheet.Cells[79, 1].Text = "TOOL_EVENT";
            spdIcons.ActiveSheet.Cells[80, 1].Text = "TOOL_TYPE";
            spdIcons.ActiveSheet.Cells[81, 1].Text = "ALARM_ERROR";
            spdIcons.ActiveSheet.Cells[82, 1].Text = "ALARM_WARN";
            spdIcons.ActiveSheet.Cells[83, 1].Text = "ALARM_INFO";
            spdIcons.ActiveSheet.Cells[84, 1].Text = "TOOL_SCRAP";
            spdIcons.ActiveSheet.Cells[85, 1].Text = "REPAIR_LOT";
            spdIcons.ActiveSheet.Cells[86, 1].Text = "DISPATCHER";
            spdIcons.ActiveSheet.Cells[87, 1].Text = "TOOL_RETURN";
            spdIcons.ActiveSheet.Cells[88, 1].Text = "EQ_TYPE";
            spdIcons.ActiveSheet.Cells[89, 1].Text = "RCP_MGR_DIR";
            spdIcons.ActiveSheet.Cells[90, 1].Text = "MODULE_DIR";
            spdIcons.ActiveSheet.Cells[91, 1].Text = "MODULE";
            spdIcons.ActiveSheet.Cells[92, 1].Text = "RCP_HOLD";
            spdIcons.ActiveSheet.Cells[93, 1].Text = "VERSION";
            spdIcons.ActiveSheet.Cells[94, 1].Text = "VERSION_REQUEST";
            spdIcons.ActiveSheet.Cells[95, 1].Text = "VERSION_APPROVAL";
            spdIcons.ActiveSheet.Cells[96, 1].Text = "VERSION_ACTIVATE";
            spdIcons.ActiveSheet.Cells[97, 1].Text = "WHITE_IMAGE";
            spdIcons.ActiveSheet.Cells[98, 1].Text = "PRIVILEGE_SERVICE";
            spdIcons.ActiveSheet.Cells[99, 1].Text = "SUB_RES_DOWN";
            spdIcons.ActiveSheet.Cells[100, 1].Text = "PORT_DOWN";
            TPDR.initImage();
            for (i = 0; i < spdIcons.ActiveSheet.RowCount; i++)
            {
                spdIcons.ActiveSheet.Cells[i, 0].Value = iTemp.Images[TPDR.gTRSImage.GetInt(spdIcons.ActiveSheet.Cells[i, 1].Text)];
                spdIcons.ActiveSheet.Rows[i].VerticalAlignment = CellVerticalAlignment.Center;
            }
            spdColors.ActiveSheet.RowCount = 0;
            spdColors.ActiveSheet.RowCount = 174;

            spdColors.ActiveSheet.Cells[0, 1].Text = "ActiveBorder";
            spdColors.ActiveSheet.Cells[1, 1].Text = "ActiveCaption";
            spdColors.ActiveSheet.Cells[2, 1].Text = "ActiveCaptionText";
            spdColors.ActiveSheet.Cells[3, 1].Text = "AppWorkspace";
            spdColors.ActiveSheet.Cells[4, 1].Text = "Control";
            spdColors.ActiveSheet.Cells[5, 1].Text = "ControlDark";
            spdColors.ActiveSheet.Cells[6, 1].Text = "ControlDarkDark";
            spdColors.ActiveSheet.Cells[7, 1].Text = "ControlLight";
            spdColors.ActiveSheet.Cells[8, 1].Text = "ControlLightLight";
            spdColors.ActiveSheet.Cells[9, 1].Text = "ControlText";
            spdColors.ActiveSheet.Cells[10, 1].Text = "Desktop";
            spdColors.ActiveSheet.Cells[11, 1].Text = "GrayText";
            spdColors.ActiveSheet.Cells[12, 1].Text = "Highlight";
            spdColors.ActiveSheet.Cells[13, 1].Text = "HighlightText";
            spdColors.ActiveSheet.Cells[14, 1].Text = "HotTrack";
            spdColors.ActiveSheet.Cells[15, 1].Text = "InactiveBorder";
            spdColors.ActiveSheet.Cells[16, 1].Text = "InactiveCaption";
            spdColors.ActiveSheet.Cells[17, 1].Text = "InactiveCaptionText";
            spdColors.ActiveSheet.Cells[18, 1].Text = "Info";
            spdColors.ActiveSheet.Cells[19, 1].Text = "InfoText";
            spdColors.ActiveSheet.Cells[20, 1].Text = "Menu";
            spdColors.ActiveSheet.Cells[21, 1].Text = "MenuText";
            spdColors.ActiveSheet.Cells[22, 1].Text = "ScrollBar";
            spdColors.ActiveSheet.Cells[23, 1].Text = "Window";
            spdColors.ActiveSheet.Cells[24, 1].Text = "WindowFrame";
            spdColors.ActiveSheet.Cells[25, 1].Text = "WindowText";
            spdColors.ActiveSheet.Cells[26, 1].Text = "Transparent";
            spdColors.ActiveSheet.Cells[27, 1].Text = "AliceBlue";
            spdColors.ActiveSheet.Cells[28, 1].Text = "AntiqueWhite";
            spdColors.ActiveSheet.Cells[29, 1].Text = "Aqua";
            spdColors.ActiveSheet.Cells[30, 1].Text = "Aquamarine";
            spdColors.ActiveSheet.Cells[31, 1].Text = "Azure";
            spdColors.ActiveSheet.Cells[32, 1].Text = "Beige";
            spdColors.ActiveSheet.Cells[33, 1].Text = "Bisque";
            spdColors.ActiveSheet.Cells[34, 1].Text = "Black";
            spdColors.ActiveSheet.Cells[35, 1].Text = "BlanchedAlmond";
            spdColors.ActiveSheet.Cells[36, 1].Text = "Blue";
            spdColors.ActiveSheet.Cells[37, 1].Text = "BlueViolet";
            spdColors.ActiveSheet.Cells[38, 1].Text = "Brown";
            spdColors.ActiveSheet.Cells[39, 1].Text = "BurlyWood";
            spdColors.ActiveSheet.Cells[40, 1].Text = "CadetBlue";
            spdColors.ActiveSheet.Cells[41, 1].Text = "Chartreuse";
            spdColors.ActiveSheet.Cells[42, 1].Text = "Chocolate";
            spdColors.ActiveSheet.Cells[43, 1].Text = "Coral";
            spdColors.ActiveSheet.Cells[44, 1].Text = "CornflowerBlue";
            spdColors.ActiveSheet.Cells[45, 1].Text = "Cornsilk";
            spdColors.ActiveSheet.Cells[46, 1].Text = "Crimson";
            spdColors.ActiveSheet.Cells[47, 1].Text = "Cyan";
            spdColors.ActiveSheet.Cells[48, 1].Text = "DarkBlue";
            spdColors.ActiveSheet.Cells[49, 1].Text = "DarkCyan";
            spdColors.ActiveSheet.Cells[50, 1].Text = "DarkGoldenrod";
            spdColors.ActiveSheet.Cells[51, 1].Text = "DarkGray";
            spdColors.ActiveSheet.Cells[52, 1].Text = "DarkGreen";
            spdColors.ActiveSheet.Cells[53, 1].Text = "DarkKhaki";
            spdColors.ActiveSheet.Cells[54, 1].Text = "DarkMagenta";
            spdColors.ActiveSheet.Cells[55, 1].Text = "DarkOliveGreen";
            spdColors.ActiveSheet.Cells[56, 1].Text = "DarkOrange";
            spdColors.ActiveSheet.Cells[57, 1].Text = "DarkOrchid";
            spdColors.ActiveSheet.Cells[58, 1].Text = "DarkRed";
            spdColors.ActiveSheet.Cells[59, 1].Text = "DarkSalmon";
            spdColors.ActiveSheet.Cells[60, 1].Text = "DarkSeaGreen";
            spdColors.ActiveSheet.Cells[61, 1].Text = "DarkSlateBlue";
            spdColors.ActiveSheet.Cells[62, 1].Text = "DarkSlateGray";
            spdColors.ActiveSheet.Cells[63, 1].Text = "DarkTurquoise";
            spdColors.ActiveSheet.Cells[64, 1].Text = "DarkViolet";
            spdColors.ActiveSheet.Cells[65, 1].Text = "DeepPink";
            spdColors.ActiveSheet.Cells[66, 1].Text = "DeepSkyBlue";
            spdColors.ActiveSheet.Cells[67, 1].Text = "DimGray";
            spdColors.ActiveSheet.Cells[68, 1].Text = "DodgerBlue";
            spdColors.ActiveSheet.Cells[69, 1].Text = "Firebrick";
            spdColors.ActiveSheet.Cells[70, 1].Text = "FloralWhite";
            spdColors.ActiveSheet.Cells[71, 1].Text = "ForestGreen";
            spdColors.ActiveSheet.Cells[72, 1].Text = "Fuchsia";
            spdColors.ActiveSheet.Cells[73, 1].Text = "Gainsboro";
            spdColors.ActiveSheet.Cells[74, 1].Text = "GhostWhite";
            spdColors.ActiveSheet.Cells[75, 1].Text = "Gold";
            spdColors.ActiveSheet.Cells[76, 1].Text = "Goldenrod";
            spdColors.ActiveSheet.Cells[77, 1].Text = "Gray";
            spdColors.ActiveSheet.Cells[78, 1].Text = "Green";
            spdColors.ActiveSheet.Cells[79, 1].Text = "GreenYellow";
            spdColors.ActiveSheet.Cells[80, 1].Text = "Honeydew";
            spdColors.ActiveSheet.Cells[81, 1].Text = "HotPink";
            spdColors.ActiveSheet.Cells[82, 1].Text = "IndianRed";
            spdColors.ActiveSheet.Cells[83, 1].Text = "Indigo";
            spdColors.ActiveSheet.Cells[84, 1].Text = "Ivory";
            spdColors.ActiveSheet.Cells[85, 1].Text = "Khaki";
            spdColors.ActiveSheet.Cells[86, 1].Text = "Lavender";
            spdColors.ActiveSheet.Cells[87, 1].Text = "LavenderBlush";
            spdColors.ActiveSheet.Cells[88, 1].Text = "LawnGreen";
            spdColors.ActiveSheet.Cells[89, 1].Text = "LemonChiffon";
            spdColors.ActiveSheet.Cells[90, 1].Text = "LightBlue";
            spdColors.ActiveSheet.Cells[91, 1].Text = "LightCoral";
            spdColors.ActiveSheet.Cells[92, 1].Text = "LightCyan";
            spdColors.ActiveSheet.Cells[93, 1].Text = "LightGoldenrodYellow";
            spdColors.ActiveSheet.Cells[94, 1].Text = "LightGray";
            spdColors.ActiveSheet.Cells[95, 1].Text = "LightGreen";
            spdColors.ActiveSheet.Cells[96, 1].Text = "LightPink";
            spdColors.ActiveSheet.Cells[97, 1].Text = "LightSalmon";
            spdColors.ActiveSheet.Cells[98, 1].Text = "LightSeaGreen";
            spdColors.ActiveSheet.Cells[99, 1].Text = "LightSkyBlue";
            spdColors.ActiveSheet.Cells[100, 1].Text = "LightSlateGray";
            spdColors.ActiveSheet.Cells[101, 1].Text = "LightSteelBlue";
            spdColors.ActiveSheet.Cells[102, 1].Text = "LightYellow";
            spdColors.ActiveSheet.Cells[103, 1].Text = "Lime";
            spdColors.ActiveSheet.Cells[104, 1].Text = "LimeGreen";
            spdColors.ActiveSheet.Cells[105, 1].Text = "Linen";
            spdColors.ActiveSheet.Cells[106, 1].Text = "Magenta";
            spdColors.ActiveSheet.Cells[107, 1].Text = "Maroon";
            spdColors.ActiveSheet.Cells[108, 1].Text = "MediumAquamarine";
            spdColors.ActiveSheet.Cells[109, 1].Text = "MediumBlue";
            spdColors.ActiveSheet.Cells[110, 1].Text = "MediumOrchid";
            spdColors.ActiveSheet.Cells[111, 1].Text = "MediumPurple";
            spdColors.ActiveSheet.Cells[112, 1].Text = "MediumSeaGreen";
            spdColors.ActiveSheet.Cells[113, 1].Text = "MediumSlateBlue";
            spdColors.ActiveSheet.Cells[114, 1].Text = "MediumSpringGreen";
            spdColors.ActiveSheet.Cells[115, 1].Text = "MediumTurquoise";
            spdColors.ActiveSheet.Cells[116, 1].Text = "MediumVioletRed";
            spdColors.ActiveSheet.Cells[117, 1].Text = "MidnightBlue";
            spdColors.ActiveSheet.Cells[118, 1].Text = "MintCream";
            spdColors.ActiveSheet.Cells[119, 1].Text = "MistyRose";
            spdColors.ActiveSheet.Cells[120, 1].Text = "Moccasin";
            spdColors.ActiveSheet.Cells[121, 1].Text = "NavajoWhite";
            spdColors.ActiveSheet.Cells[122, 1].Text = "Navy";
            spdColors.ActiveSheet.Cells[123, 1].Text = "OldLace";
            spdColors.ActiveSheet.Cells[124, 1].Text = "Olive";
            spdColors.ActiveSheet.Cells[125, 1].Text = "OliveDrab";
            spdColors.ActiveSheet.Cells[126, 1].Text = "Orange";
            spdColors.ActiveSheet.Cells[127, 1].Text = "OrangeRed";
            spdColors.ActiveSheet.Cells[128, 1].Text = "Orchid";
            spdColors.ActiveSheet.Cells[129, 1].Text = "PaleGoldenrod";
            spdColors.ActiveSheet.Cells[130, 1].Text = "PaleGreen";
            spdColors.ActiveSheet.Cells[131, 1].Text = "PaleTurquoise";
            spdColors.ActiveSheet.Cells[132, 1].Text = "PaleVioletRed";
            spdColors.ActiveSheet.Cells[133, 1].Text = "PapayaWhip";
            spdColors.ActiveSheet.Cells[134, 1].Text = "PeachPuff";
            spdColors.ActiveSheet.Cells[135, 1].Text = "Peru";
            spdColors.ActiveSheet.Cells[136, 1].Text = "Pink";
            spdColors.ActiveSheet.Cells[137, 1].Text = "Plum";
            spdColors.ActiveSheet.Cells[138, 1].Text = "PowderBlue";
            spdColors.ActiveSheet.Cells[139, 1].Text = "Purple";
            spdColors.ActiveSheet.Cells[140, 1].Text = "Red";
            spdColors.ActiveSheet.Cells[141, 1].Text = "RosyBrown";
            spdColors.ActiveSheet.Cells[142, 1].Text = "RoyalBlue";
            spdColors.ActiveSheet.Cells[143, 1].Text = "SaddleBrown";
            spdColors.ActiveSheet.Cells[144, 1].Text = "Salmon";
            spdColors.ActiveSheet.Cells[145, 1].Text = "SandyBrown";
            spdColors.ActiveSheet.Cells[146, 1].Text = "SeaGreen";
            spdColors.ActiveSheet.Cells[147, 1].Text = "SeaShell";
            spdColors.ActiveSheet.Cells[148, 1].Text = "Sienna";
            spdColors.ActiveSheet.Cells[149, 1].Text = "Silver";
            spdColors.ActiveSheet.Cells[150, 1].Text = "SkyBlue";
            spdColors.ActiveSheet.Cells[151, 1].Text = "SlateBlue";
            spdColors.ActiveSheet.Cells[152, 1].Text = "SlateGray";
            spdColors.ActiveSheet.Cells[153, 1].Text = "Snow";
            spdColors.ActiveSheet.Cells[154, 1].Text = "SpringGreen";
            spdColors.ActiveSheet.Cells[155, 1].Text = "SteelBlue";
            spdColors.ActiveSheet.Cells[156, 1].Text = "Tan";
            spdColors.ActiveSheet.Cells[157, 1].Text = "Teal";
            spdColors.ActiveSheet.Cells[158, 1].Text = "Thistle";
            spdColors.ActiveSheet.Cells[159, 1].Text = "Tomato";
            spdColors.ActiveSheet.Cells[160, 1].Text = "Turquoise";
            spdColors.ActiveSheet.Cells[161, 1].Text = "Violet";
            spdColors.ActiveSheet.Cells[162, 1].Text = "Wheat";
            spdColors.ActiveSheet.Cells[163, 1].Text = "White";
            spdColors.ActiveSheet.Cells[164, 1].Text = "WhiteSmoke";
            spdColors.ActiveSheet.Cells[165, 1].Text = "Yellow";
            spdColors.ActiveSheet.Cells[166, 1].Text = "YellowGreen";
            spdColors.ActiveSheet.Cells[167, 1].Text = "ButtonFace";
            spdColors.ActiveSheet.Cells[168, 1].Text = "ButtonHighlight";
            spdColors.ActiveSheet.Cells[169, 1].Text = "ButtonShadow";
            spdColors.ActiveSheet.Cells[170, 1].Text = "GradientActiveCaption";
            spdColors.ActiveSheet.Cells[171, 1].Text = "GradientInactiveCaption";
            spdColors.ActiveSheet.Cells[172, 1].Text = "MenuBar";
            spdColors.ActiveSheet.Cells[173, 1].Text = "MenuHighlight";
            for (i = 0; i < spdColors.ActiveSheet.RowCount; i++)
            {
                spdColors.ActiveSheet.Cells[i,0].BackColor = Color.FromName(spdColors.ActiveSheet.Cells[i, 1].Text);
                spdColors.ActiveSheet.Rows[i].VerticalAlignment = CellVerticalAlignment.Center;
            }
            MPCF.FitColumnHeader(spdColors);
            MPCF.FitColumnHeader(spdIcons);
            return;
        }


        //
        // ViewDirectViewConditionList()
        //       - View Direct View Condition List
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool ViewDirectViewConditionList()
        {
            TRSNode in_node = new TRSNode("VIEW_DIRECT_VIEW_CONDITION_LIST_IN");
            TRSNode out_node = new TRSNode("VIEW_DIRECT_VIEW_CONDITION_LIST_OUT");

            int i;

            try
            {
                spdCondition.ActiveSheet.RowCount = 0;


                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.SetString("VIEW_ID", txtViewID.Text);

                do
                {

                    if (MPCR.CallService("DNM", "DNM_View_Direct_View_Condition_List", in_node, ref out_node) == false)
                    {
                        return false;
                    }

                    for (i = 0; i < out_node.GetList("LIST").Count; i++)
                    {
                        spdCondition.ActiveSheet.RowCount++;
                        spdCondition.ActiveSheet.Cells[i, 0].Value = false;
                        spdCondition.ActiveSheet.Cells[i, 1].Text = out_node.GetList("LIST")[i].GetString("COND_NAME");
                        spdCondition.ActiveSheet.Cells[i, 2].Text = out_node.GetList("LIST")[i].GetString("COND_DESC");

                        if(out_node.GetList("LIST")[i].GetChar("REQ_FLAG")=='Y')
                            spdCondition.ActiveSheet.Cells[i, 3].Value = true;
                        else
                            spdCondition.ActiveSheet.Cells[i, 3].Value = false;

                        spdCondition.ActiveSheet.Cells[i, 4].Text = out_node.GetList("LIST")[i].GetString("DATA_TYPE");
                        spdCondition.ActiveSheet.Cells[i, 5].Text = out_node.GetList("LIST")[i].GetString("INPUT_TYPE");
                        spdCondition.ActiveSheet.Cells[i, 6].Text = out_node.GetList("LIST")[i].GetString("DATA_TBL");
                    }

                    in_node.SetInt("NEXT_COND_SEQ", out_node.GetInt("NEXT_COND_SEQ"));

                } while (in_node.GetInt("NEXT_COND_SEQ") != 0);

                spdCondition.ActiveSheet.RowCount++;
                spdCondition.ActiveSheet.Cells[spdCondition.ActiveSheet.RowCount - 1, 0].Value = false;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return false;
            }

            return true;

        }
        //
        // UpdateDirectViewCondition()
        //       - Create/Update/Delete Direct View
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal ProcStep As String : Process Step
        //
        private bool UpdateDirectViewCondition(char ProcStep)
        {
            int i = 0;
            TRSNode in_node = new TRSNode("UPDATE_DIRECT_VIEW_CONDITION_IN");
            TRSNode out_node = new TRSNode("CMN_OUT");
            TRSNode node;

            try
            {
                MPCR.SetInMsg(in_node);
                in_node.ProcStep = ProcStep;
                in_node.SetString("VIEW_ID", txtViewID.Text);

                for (i = 0; i < spdCondition.ActiveSheet.RowCount - 1; i++)
                {

                    node = in_node.AddNode("LIST");
                    node.SetInt("COND_SEQ", i+1);
                    node.SetString("COND_NAME", spdCondition.ActiveSheet.Cells[i, 1].Text);
                    node.SetString("COND_DESC", spdCondition.ActiveSheet.Cells[i, 2].Text);
                    if (spdCondition.ActiveSheet.Cells[i, 3].Value != null)
                    {
                        if ((bool)spdCondition.ActiveSheet.Cells[i, 3].Value == true)
                            node.SetChar("REQ_FLAG", 'Y');
                        else
                            node.SetChar("REQ_FLAG", 'N');
                    }
                    else
                        node.SetChar("REQ_FLAG", 'N');

                    node.SetString("DATA_TYPE", spdCondition.ActiveSheet.Cells[i, 4].Text);
                    node.SetString("INPUT_TYPE", spdCondition.ActiveSheet.Cells[i, 5].Text);
                    node.SetString("DATA_TBL", spdCondition.ActiveSheet.Cells[i, 6].Text);

                }

                if (MPCR.CallService("DNM", "DNM_Multi_Update_Direct_View_Condition", in_node, ref out_node) == false)
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

        

        #endregion

        private void  frmDNMSetupDirectView_Activated(object sender, System.EventArgs e)
        {
            try
            {
                if (b_load_flag == false)
                {
                    pnlDictionary.Width = 0;
                    MPCF.InitListView(lisView);
                    ViewDirectViewList();
                    DisplayDictionary();
                    b_load_flag = true;
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
                if (tabDirectView.SelectedIndex == 0)
                {
                    if (CheckCondition("UPDATE_DIRECT_VIEW", '1') == true)
                    {
                        if (UpdateDirectView(MPGC.MP_STEP_UPDATE) == false)
                        {
                            return;
                        }


                        ViewDirectViewList();

                    }
                }
                else if (tabDirectView.SelectedIndex == 1)
                {
                    if (CheckCondition("DELETE_DIRECT_VIEW_HEADER", '1') == true)
                    {
                        if (UpdateDirectViewHeader(MPGC.MP_STEP_UPDATE) == false)
                        {
                            return;
                        }


                        ViewDirectViewHeaderList();

                    }
                }
                else
                {
                    if (CheckCondition("DELETE_DIRECT_VIEW_CONDITION", '1') == true)
                    {
                        if (UpdateDirectViewCondition(MPGC.MP_STEP_UPDATE) == false)
                        {
                            return;
                        }


                        ViewDirectViewConditionList();

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
                if (tabDirectView.SelectedIndex == 0)
                {
                    if (CheckCondition("DELETE_DIRECT_VIEW", '1') == true)
                    {
                        if (UpdateDirectView(MPGC.MP_STEP_DELETE) == false)
                        {
                            return;
                        }


                        ViewDirectViewList();
                    }
                }
                else if (tabDirectView.SelectedIndex == 1)
                {
                    if (CheckCondition("DELETE_DIRECT_VIEW_HEADER", '1') == true)
                    {
                        if (UpdateDirectViewHeader(MPGC.MP_STEP_DELETE) == false)
                        {
                            return;
                        }


                        ViewDirectViewHeaderList();

                    }
                }
                else
                {
                    if (CheckCondition("DELETE_DIRECT_VIEW_CONDITION", '1') == true)
                    {
                        if (UpdateDirectViewCondition(MPGC.MP_STEP_DELETE) == false)
                        {
                            return;
                        }


                        ViewDirectViewConditionList();

                    }
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

                MPCF.ExportToExcel(lisView, this.Text, null);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabDirectView.SelectedIndex == 0)
                {
                    if (CheckCondition("UPDATE_DIRECT_VIEW", '1') == true)
                    {
                        if (UpdateDirectView(MPGC.MP_STEP_CREATE) == false)
                        {
                            return;
                        }


                        ViewDirectViewList();

                    }
                }
                else if (tabDirectView.SelectedIndex == 1)
                {
                    if (CheckCondition("UPDATE_DIRECT_VIEW_HEADER", '1') == true)
                    {
                        if (UpdateDirectViewHeader(MPGC.MP_STEP_CREATE) == false)
                        {
                            return;
                        }


                        ViewDirectViewHeaderList();

                    }
                }
                else
                {
                    if (CheckCondition("UPDATE_DIRECT_VIEW_CONDITION", '1') == true)
                    {
                        if (UpdateDirectViewCondition(MPGC.MP_STEP_CREATE) == false)
                        {
                            return;
                        }


                        ViewDirectViewConditionList();

                    }
                }

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void lisView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected != true)
                return;

            txtViewID.Text = e.Item.Text;
            ViewDirectView();
            ViewDirectViewHeaderList();
            ViewDirectViewConditionList();
        }

        private void spdHeader_EditModeOff(object sender, EventArgs e)
        {
            int i_col;
            int i_row;
            int i = 0;

            try
            {
                i_col = spdHeader.ActiveSheet.ActiveColumnIndex;
                i_row = spdHeader.ActiveSheet.ActiveRowIndex;

                if (i_col < 1) return;

                spdHeader.ActiveSheet.SetValue(i_row, 0, true);

                if (i_row == spdHeader.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdHeader.ActiveSheet.Cells[i_row, 1].Value) != "")
                    {
                        spdHeader.ActiveSheet.RowCount++;
                        spdHeader.ActiveSheet.Cells[spdHeader.ActiveSheet.RowCount - 1, 0].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void tabDirectView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabDirectView.SelectedIndex == 0)
            {
                btnCreate.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else if (tabDirectView.SelectedIndex == 1)
            {
                btnCreate.Enabled = true;
                btnUpdate.Enabled = false;
            }
            else if (tabDirectView.SelectedIndex == 2)
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }

        private void cdvTable_ButtonPress(object sender, EventArgs e)
        {
            cdvTable.Init();
            MPCF.InitListView(cdvTable.GetListView);
            cdvTable.Columns.Add("Table", 50, HorizontalAlignment.Left);
            cdvTable.Columns.Add("Description", 100, HorizontalAlignment.Left);
            cdvTable.SelectedSubItemIndex = 0;

            BASLIST.ViewGCMDataList(cdvTable.GetListView, '1', "@DB_TABLE_LIST");
        }

        private void cdvTable_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            string[] sTemp = new string[1];

            lisColumns.Columns.Clear();
            MPCF.InitListView(lisColumns);
            lisColumns.Columns.Add("Column", 80, HorizontalAlignment.Left);
            lisColumns.Columns.Add("Type", 80, HorizontalAlignment.Left);
            lisColumns.Columns.Add("Description", 200, HorizontalAlignment.Left);
            sTemp[0] = cdvTable.Text;
            BASLIST.ViewGCMDataList(lisColumns, '1', "@COLUMN_LIST",(int)SMALLICON_INDEX.IDX_MESSAGE,null,MPGV.gsFactory,false,0,0,null,sTemp);
            MPCF.FitColumnHeader(lisColumns);
        }
        private void cdvTable_TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
                cdvTable_SelectedItemChanged(null, null);
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            int iRow;

            bool bCheck=false;

            try
            {
                spdHeader.ActiveSheet.RowCount = 0;
                spdHeader.ActiveSheet.RowCount++;

                for (i = 0; i < lisColumns.Items.Count; i++)
                {
                    if (lisColumns.Items[i].Checked != true)
                        continue;

                    bCheck = false;

                    for (j = 0; j < spdHeader.ActiveSheet.RowCount; j++)
                    {
                        if (lisColumns.Items[i].Text == spdHeader.ActiveSheet.Cells[j, 1].Text)
                        {
                            bCheck = true;
                            break;
                        }
                    }

                    if (bCheck == true)
                        continue;

                    iRow = spdHeader.ActiveSheet.RowCount-1;
                    spdHeader.ActiveSheet.RowCount++;
                    spdHeader.ActiveSheet.Cells[iRow, 0].Value = false;
                    spdHeader.ActiveSheet.Cells[iRow, 1].Text = lisColumns.Items[i].Text;
                    spdHeader.ActiveSheet.Cells[iRow, 3].Text = lisColumns.Items[i].SubItems[2].Text;


                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            int iRow;

            bool bCheck = false;

            try
            {
                for (i = 0; i < lisColumns.Items.Count; i++)
                {
                    if (lisColumns.Items[i].Checked != true)
                        continue;

                    bCheck = false;

                    for (j = 0; j < spdHeader.ActiveSheet.RowCount; j++)
                    {
                        if (lisColumns.Items[i].Text == spdHeader.ActiveSheet.Cells[j, 1].Text)
                        {
                            bCheck = true;
                            break;
                        }
                    }

                    if (bCheck == true)
                        continue;

                    iRow = spdHeader.ActiveSheet.RowCount-1;
                    spdHeader.ActiveSheet.RowCount++;
                    spdHeader.ActiveSheet.Cells[iRow, 0].Value = false;
                    spdHeader.ActiveSheet.Cells[iRow, 1].Text = lisColumns.Items[i].Text;
                    spdHeader.ActiveSheet.Cells[iRow, 3].Text = lisColumns.Items[i].SubItems[2].Text;


                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            int i;
            if (lisColumns.Items[0].Checked == true)
            {
                for (i = 0; i < lisColumns.Items.Count; i++)
                    lisColumns.Items[i].Checked = false;
            }
            else
            {
                for (i = 0; i < lisColumns.Items.Count; i++)
                    lisColumns.Items[i].Checked = true;
            }
        }

        private void btnGenName_Click(object sender, EventArgs e)
        {
            int i;
            int j;
            int iPos;
            int iTotal;
            string sTemp;
            string sTarget;
            bool bSpace;
            for (i = 0; i < spdHeader.ActiveSheet.RowCount - 1; i++)
            {
                if (MPCF.Trim(spdHeader.ActiveSheet.Cells[i, 2].Text) != "")
                    continue;

                sTemp = MPCF.Trim(spdHeader.ActiveSheet.Cells[i, 1].Text);

                sTemp = sTemp.Replace("_", " ");

                sTemp = MPCF.ToLower(sTemp);

                iTotal = sTemp.Length;

                sTarget = MPCF.ToUpper(sTemp.Substring(0, 1));
                bSpace = false;
                for (j = 1; j < iTotal; j++)
                {
                    if (sTemp.Substring(j, 1) == " ")
                    {
                        sTarget = sTarget + " ";
                        bSpace = true;
                        continue;
                    }

                    if (bSpace == true)
                    {
                        sTarget = sTarget + MPCF.ToUpper(sTemp.Substring(j, 1));
                        bSpace = false;
                    }
                    else
                        sTarget = sTarget + sTemp.Substring(j, 1);
                }
                sTarget = sTarget.Replace(" Id ", " ID ");
                if (sTarget.Length > 3)
                {
                    if (sTarget.Substring(sTarget.Length - 3, 3) == " Id")
                        sTarget = sTarget.Substring(0, sTarget.Length - 3) + " ID";
                }
                spdHeader.ActiveSheet.Cells[i, 2].Text = sTarget;
            }
        }

        private void btnCheckAllHeader_Click(object sender, EventArgs e)
        {
            int i;
            if ((bool)spdHeader.ActiveSheet.Cells[0, 0].Value == false)
            {
                for (i = 0; i < spdHeader.ActiveSheet.RowCount - 1; i++)
                    spdHeader.ActiveSheet.Cells[i, 0].Value = true;
            }
            else
            {
                for (i = 0; i < spdHeader.ActiveSheet.RowCount - 1; i++)
                    spdHeader.ActiveSheet.Cells[i, 0].Value = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            spdHeader.ActiveSheet.RowCount = 0;
            spdHeader.ActiveSheet.RowCount++;
        }
            

        private void chkSample_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSample.Checked)
                txtSample.BringToFront();
            else
                txtSample.SendToBack();
        }

        private void chkDictionary_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDictionary.Checked)
                pnlDictionary.Width = 400;
            else
                pnlDictionary.Width = 0;
        }

        private void spdCondition_EditModeOff(object sender, EventArgs e)
        {
            int i_col;
            int i_row;

            try
            {
                i_col = spdCondition.ActiveSheet.ActiveColumnIndex;
                i_row = spdCondition.ActiveSheet.ActiveRowIndex;

                if (i_col < 1) return;

                spdCondition.ActiveSheet.SetValue(i_row, 0, true);

                if (i_row == spdCondition.ActiveSheet.RowCount - 1)
                {
                    if (MPCF.Trim(spdCondition.ActiveSheet.Cells[i_row, 1].Value) != "")
                    {
                        spdCondition.ActiveSheet.RowCount++;
                        spdCondition.ActiveSheet.Cells[spdCondition.ActiveSheet.RowCount - 1, 0].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void spdCondition_ButtonClicked(object sender, EditorNotifyEventArgs e)
        {
            if (e.Column != 7)
                return;

            cdvDataList.Init();
            cdvDataList.ViewPosition = Control.MousePosition;
            MPCF.InitListView(cdvDataList.GetListView);
            cdvDataList.Columns.Add("Table Name", 50, HorizontalAlignment.Left);
            cdvDataList.Columns.Add("Description", 50, HorizontalAlignment.Left);
            cdvDataList.VisibleColumnHeader = MPGO.DisplayColHeadCodeView();
            if (BASLIST.ViewGCMTableList(cdvDataList.GetListView, '1') == false)
            {
                return;
            }

            if (cdvDataList.ShowPopupList(e.Row, e.Column - 1) == false)
            {
                return;
            }
        }

        private void cdvDataList_SelectedItemChanged(object sender, UI.MCSSCodeViewSelChanged_EventArgs e)
        {
            spdCondition.ActiveSheet.Cells[e.Row, e.Col].Value = e.SelectedItem.SubItems[0].Text;
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            int i;

            try
            {
                for(i=spdCondition.ActiveSheet.RowCount-1;i>=0;i--)
                {

                    if ((bool)spdCondition.ActiveSheet.Cells[i, 0].Value != true)
                        continue;

                    spdCondition.ActiveSheet.Rows[i].Remove();
                }
                return;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewDirectViewList();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MPCF.ExportToExcel(lisView, "Direct View List", null);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MPCF.FindListItemNextPartial(lisView, txtFind.Text, true, false);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckCondition("COPY_DIRECT_VIEW", '1') == true)
                {
                    if (UpdateDirectView(MPGC.MP_STEP_COPY) == false)
                    {
                        return;
                    }

                    ViewDirectViewList();

                }
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                string sQuery = this.txtQuery.Text;

                sQuery = sQuery.Replace("''", "♩♩");
                sQuery = sQuery.Replace("' '", "♩ ♩");
                sQuery = sQuery.Replace("'%'", "♩%♩");
                sQuery = sQuery.Replace("'$", ":").Replace("'", "");
                sQuery = sQuery.Replace("♩♩", "''");
                sQuery = sQuery.Replace("♩ ♩", "' '");
                sQuery = sQuery.Replace("♩%♩", "'%'");
                sQuery = sQuery + Environment.NewLine + ";";

                Clipboard.SetText(sQuery, TextDataFormat.Text);
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                string sQuery = this.txtQuery.Text + " ";                
                string sFindWord = string.Empty;
                string sConvertWord = string.Empty;
                int idxTxt = 0;


                sQuery = this.txtQuery.Text + " ";
                sQuery = sQuery.Replace(";", " ");

                for (int i = 0; i < 1000; i++)
                {
                    idxTxt = sQuery.IndexOf(":");
                    if (idxTxt < 0) { break; }

                    sFindWord = sQuery.Substring(idxTxt, sQuery.Substring(idxTxt, sQuery.Length - idxTxt).IndexOf(" "));
                    sFindWord = sFindWord.Replace("\n", "");
                    sConvertWord = sFindWord.Replace(":", "'$");
                    sConvertWord = sConvertWord + "'";

                    sQuery = sQuery.Replace(sFindWord, sConvertWord);
                }

                this.txtQuery.Text = sQuery;
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
            }
        }
        
    }
}
