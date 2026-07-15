
using Miracom.CliFrx;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Diagnostics;
using Miracom.MsgHandler;
using Miracom.Stat;
using Miracom.MESCore;
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCAttachUserToChart.vb
//   Description :
//
//   MES Version : 1.0.0
//
//   Function List
//       - CheckCondition() : Check the Conditions before Transaction
//       - Attach_User() : Create/Update/Delete Chart
//
//
//   Detail Description
//       -
//       -
//
//   History
//       - 2005-06-08 : Created by H.K.Kim
//
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------
namespace Miracom.SPCCore
{
    public class frmSPCAttachUserToChart : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCAttachUserToChart()
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
        



        public System.Windows.Forms.Panel pnlBottom;
        public System.Windows.Forms.Button btnClose;
        internal Miracom.UI.Controls.MCListView.MCListView lisChart;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.Panel pnlUserMid;
        internal System.Windows.Forms.Button btnDel;
        internal System.Windows.Forms.Button btnAdd;
        internal Miracom.UI.Controls.MCListView.MCListView lisAttachUser;
        internal System.Windows.Forms.ColumnHeader ColumnHeader7;
        internal System.Windows.Forms.ColumnHeader ColumnHeader8;
        internal System.Windows.Forms.ColumnHeader ColumnHeader9;
        internal System.Windows.Forms.ColumnHeader ColumnHeader10;
        internal System.Windows.Forms.ColumnHeader ColumnHeader6;
        internal System.Windows.Forms.ColumnHeader ColumnHeader5;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal Miracom.UI.Controls.MCListView.MCListView lisUserlist;
        internal System.Windows.Forms.Panel pnlGroup;
        internal System.Windows.Forms.Label lblUserList;
        internal System.Windows.Forms.ColumnHeader ColumnHeader11;
        internal System.Windows.Forms.ColumnHeader ColumnHeader12;
        internal System.Windows.Forms.ColumnHeader ColumnHeader13;
        internal System.Windows.Forms.ColumnHeader ColumnHeader14;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvGroup;
        internal System.Windows.Forms.Label lblGroup;
        internal System.Windows.Forms.GroupBox grpRight;
        internal System.Windows.Forms.Panel pnlCenter;
        internal System.Windows.Forms.TabControl tabUser;
        internal System.Windows.Forms.TabPage tbpChart;
        internal System.Windows.Forms.TabPage tbpUser;
        internal System.Windows.Forms.Splitter splChart;
        public System.Windows.Forms.Panel pnlChartLeft;
        internal System.Windows.Forms.Panel pnlChartRight;
        internal System.Windows.Forms.Panel pnlUserMidRight;
        internal System.Windows.Forms.Panel pnlUserMidLeft;
        public System.Windows.Forms.Panel pnlUserLeft;
        internal Miracom.UI.Controls.MCListView.MCListView lisUser;
        internal System.Windows.Forms.ColumnHeader ColumnHeader15;
        internal System.Windows.Forms.ColumnHeader ColumnHeader16;
        internal System.Windows.Forms.Label lblAttachUser;
        internal System.Windows.Forms.Splitter splUser;
        internal System.Windows.Forms.Label lblChart;
        internal System.Windows.Forms.Label lblAttachChart;
        internal System.Windows.Forms.ColumnHeader ColumnHeader17;
        internal System.Windows.Forms.ColumnHeader ColumnHeader18;
        internal System.Windows.Forms.ColumnHeader ColumnHeader21;
        internal System.Windows.Forms.ColumnHeader ColumnHeader22;
        internal System.Windows.Forms.Panel pnlUserRight;
        internal System.Windows.Forms.GroupBox grpChart;
        internal System.Windows.Forms.Panel pnlChartMid;
        internal System.Windows.Forms.Panel pnlChartMidRight;
        internal Miracom.UI.Controls.MCListView.MCListView lisChartlist;
        internal System.Windows.Forms.Button btnDel1;
        internal System.Windows.Forms.Button btnAdd1;
        internal System.Windows.Forms.Panel pnlChartMidLeft;
        internal Miracom.UI.Controls.MCListView.MCListView lisAttachChart;
        internal System.Windows.Forms.Panel pnlSecGrp;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvSecGrp;
        internal System.Windows.Forms.Label lblSecGrp;
        internal System.Windows.Forms.Panel pnlUserAttach;
        internal System.Windows.Forms.Panel pnlChartAttach;
        internal System.Windows.Forms.Panel pnlFilter;
        internal System.Windows.Forms.GroupBox grpFilter;
        public System.Windows.Forms.Button btnView;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtFilter;
        internal System.Windows.Forms.RadioButton rbnAll;
        internal System.Windows.Forms.RadioButton rbnFilter;
        internal System.Windows.Forms.Panel pnlFilter1;
        internal System.Windows.Forms.GroupBox grpFilter1;
        public System.Windows.Forms.Button btnView1;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtFilter1;
        internal System.Windows.Forms.RadioButton rbnAll1;
        internal System.Windows.Forms.RadioButton rbnFilter1;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartSetID;
        internal System.Windows.Forms.Label lblChartSet;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChartSetID1;
        internal System.Windows.Forms.Label lblChartSet1;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlChartLeft = new System.Windows.Forms.Panel();
            this.lisChart = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.cdvChartSetID = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartSet = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.txtFilter = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.rbnAll = new System.Windows.Forms.RadioButton();
            this.rbnFilter = new System.Windows.Forms.RadioButton();
            this.pnlChartRight = new System.Windows.Forms.Panel();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.pnlUserMid = new System.Windows.Forms.Panel();
            this.pnlUserMidRight = new System.Windows.Forms.Panel();
            this.lisUserlist = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlGroup = new System.Windows.Forms.Panel();
            this.cdvGroup = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblUserList = new System.Windows.Forms.Label();
            this.pnlUserAttach = new System.Windows.Forms.Panel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlUserMidLeft = new System.Windows.Forms.Panel();
            this.lisAttachUser = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAttachUser = new System.Windows.Forms.Label();
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.tabUser = new System.Windows.Forms.TabControl();
            this.tbpChart = new System.Windows.Forms.TabPage();
            this.splChart = new System.Windows.Forms.Splitter();
            this.tbpUser = new System.Windows.Forms.TabPage();
            this.pnlUserRight = new System.Windows.Forms.Panel();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.pnlChartMid = new System.Windows.Forms.Panel();
            this.pnlChartMidRight = new System.Windows.Forms.Panel();
            this.lisChartlist = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFilter1 = new System.Windows.Forms.Panel();
            this.grpFilter1 = new System.Windows.Forms.GroupBox();
            this.cdvChartSetID1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChartSet1 = new System.Windows.Forms.Label();
            this.btnView1 = new System.Windows.Forms.Button();
            this.txtFilter1 = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.rbnAll1 = new System.Windows.Forms.RadioButton();
            this.rbnFilter1 = new System.Windows.Forms.RadioButton();
            this.lblChart = new System.Windows.Forms.Label();
            this.pnlChartAttach = new System.Windows.Forms.Panel();
            this.btnDel1 = new System.Windows.Forms.Button();
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.pnlChartMidLeft = new System.Windows.Forms.Panel();
            this.lisAttachChart = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAttachChart = new System.Windows.Forms.Label();
            this.splUser = new System.Windows.Forms.Splitter();
            this.pnlUserLeft = new System.Windows.Forms.Panel();
            this.lisUser = new Miracom.UI.Controls.MCListView.MCListView();
            this.ColumnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSecGrp = new System.Windows.Forms.Panel();
            this.cdvSecGrp = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblSecGrp = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlChartLeft.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).BeginInit();
            this.pnlChartRight.SuspendLayout();
            this.grpRight.SuspendLayout();
            this.pnlUserMid.SuspendLayout();
            this.pnlUserMidRight.SuspendLayout();
            this.pnlGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).BeginInit();
            this.pnlUserAttach.SuspendLayout();
            this.pnlUserMidLeft.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.tbpChart.SuspendLayout();
            this.tbpUser.SuspendLayout();
            this.pnlUserRight.SuspendLayout();
            this.grpChart.SuspendLayout();
            this.pnlChartMid.SuspendLayout();
            this.pnlChartMidRight.SuspendLayout();
            this.pnlFilter1.SuspendLayout();
            this.grpFilter1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter1)).BeginInit();
            this.pnlChartAttach.SuspendLayout();
            this.pnlChartMidLeft.SuspendLayout();
            this.pnlUserLeft.SuspendLayout();
            this.pnlSecGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSecGrp)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 506);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlBottom.Size = new System.Drawing.Size(742, 40);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(650, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlChartLeft
            // 
            this.pnlChartLeft.Controls.Add(this.lisChart);
            this.pnlChartLeft.Controls.Add(this.pnlFilter);
            this.pnlChartLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlChartLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlChartLeft.Name = "pnlChartLeft";
            this.pnlChartLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlChartLeft.Size = new System.Drawing.Size(224, 477);
            this.pnlChartLeft.TabIndex = 0;
            // 
            // lisChart
            // 
            this.lisChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lisChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisChart.EnableSort = true;
            this.lisChart.EnableSortIcon = true;
            this.lisChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisChart.FullRowSelect = true;
            this.lisChart.Location = new System.Drawing.Point(3, 66);
            this.lisChart.MultiSelect = false;
            this.lisChart.Name = "lisChart";
            this.lisChart.Size = new System.Drawing.Size(221, 408);
            this.lisChart.TabIndex = 0;
            this.lisChart.TabStop = false;
            this.lisChart.UseCompatibleStateImageBehavior = false;
            this.lisChart.View = System.Windows.Forms.View.Details;
            this.lisChart.SelectedIndexChanged += new System.EventHandler(this.lisChart_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Chart";
            this.ColumnHeader1.Width = 100;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Description";
            this.ColumnHeader2.Width = 300;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.grpFilter);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(3, 3);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.pnlFilter.Size = new System.Drawing.Size(221, 63);
            this.pnlFilter.TabIndex = 5;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.cdvChartSetID);
            this.grpFilter.Controls.Add(this.lblChartSet);
            this.grpFilter.Controls.Add(this.btnView);
            this.grpFilter.Controls.Add(this.txtFilter);
            this.grpFilter.Controls.Add(this.rbnAll);
            this.grpFilter.Controls.Add(this.rbnFilter);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(221, 61);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            // 
            // cdvChartSetID
            // 
            this.cdvChartSetID.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartSetID.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartSetID.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartSetID.BtnToolTipText = "";
            this.cdvChartSetID.DescText = "";
            this.cdvChartSetID.DisplaySubItemIndex = -1;
            this.cdvChartSetID.DisplayText = "";
            this.cdvChartSetID.Focusing = null;
            this.cdvChartSetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartSetID.Index = 0;
            this.cdvChartSetID.IsViewBtnImage = false;
            this.cdvChartSetID.Location = new System.Drawing.Point(87, 38);
            this.cdvChartSetID.MaxLength = 30;
            this.cdvChartSetID.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID.Name = "cdvChartSetID";
            this.cdvChartSetID.ReadOnly = false;
            this.cdvChartSetID.SearchSubItemIndex = 0;
            this.cdvChartSetID.SelectedDescIndex = -1;
            this.cdvChartSetID.SelectedSubItemIndex = -1;
            this.cdvChartSetID.SelectionStart = 0;
            this.cdvChartSetID.Size = new System.Drawing.Size(130, 20);
            this.cdvChartSetID.SmallImageList = null;
            this.cdvChartSetID.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartSetID.TabIndex = 5;
            this.cdvChartSetID.TextBoxToolTipText = "";
            this.cdvChartSetID.TextBoxWidth = 130;
            this.cdvChartSetID.VisibleButton = true;
            this.cdvChartSetID.VisibleColumnHeader = false;
            this.cdvChartSetID.VisibleDescription = false;
            this.cdvChartSetID.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartSetID_SelectedItemChanged);
            this.cdvChartSetID.ButtonPress += new System.EventHandler(this.cdvChartSetID_ButtonPress);
            this.cdvChartSetID.TextBoxTextChanged += new System.EventHandler(this.cdvChartSetID_TextBoxTextChanged);
            // 
            // lblChartSet
            // 
            this.lblChartSet.AutoSize = true;
            this.lblChartSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartSet.Location = new System.Drawing.Point(8, 41);
            this.lblChartSet.Name = "lblChartSet";
            this.lblChartSet.Size = new System.Drawing.Size(65, 13);
            this.lblChartSet.TabIndex = 4;
            this.lblChartSet.Text = "Chart Set ID";
            // 
            // btnView
            // 
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView.Location = new System.Drawing.Point(181, 13);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(36, 20);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(26, 13);
            this.txtFilter.MaxLength = 30;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(98, 20);
            this.txtFilter.TabIndex = 1;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // rbnAll
            // 
            this.rbnAll.AutoSize = true;
            this.rbnAll.Location = new System.Drawing.Point(131, 16);
            this.rbnAll.Name = "rbnAll";
            this.rbnAll.Size = new System.Drawing.Size(36, 17);
            this.rbnAll.TabIndex = 2;
            this.rbnAll.Text = "All";
            // 
            // rbnFilter
            // 
            this.rbnFilter.AutoSize = true;
            this.rbnFilter.Location = new System.Drawing.Point(8, 16);
            this.rbnFilter.Name = "rbnFilter";
            this.rbnFilter.Size = new System.Drawing.Size(14, 13);
            this.rbnFilter.TabIndex = 0;
            // 
            // pnlChartRight
            // 
            this.pnlChartRight.Controls.Add(this.grpRight);
            this.pnlChartRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartRight.Location = new System.Drawing.Point(224, 0);
            this.pnlChartRight.Name = "pnlChartRight";
            this.pnlChartRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlChartRight.Size = new System.Drawing.Size(504, 477);
            this.pnlChartRight.TabIndex = 2;
            this.pnlChartRight.Resize += new System.EventHandler(this.pnlRight_Resize);
            // 
            // grpRight
            // 
            this.grpRight.Controls.Add(this.pnlUserMid);
            this.grpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpRight.Location = new System.Drawing.Point(3, 0);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(498, 477);
            this.grpRight.TabIndex = 0;
            this.grpRight.TabStop = false;
            // 
            // pnlUserMid
            // 
            this.pnlUserMid.Controls.Add(this.pnlUserMidRight);
            this.pnlUserMid.Controls.Add(this.pnlUserAttach);
            this.pnlUserMid.Controls.Add(this.pnlUserMidLeft);
            this.pnlUserMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserMid.Location = new System.Drawing.Point(3, 16);
            this.pnlUserMid.Name = "pnlUserMid";
            this.pnlUserMid.Size = new System.Drawing.Size(492, 458);
            this.pnlUserMid.TabIndex = 0;
            // 
            // pnlUserMidRight
            // 
            this.pnlUserMidRight.Controls.Add(this.lisUserlist);
            this.pnlUserMidRight.Controls.Add(this.pnlGroup);
            this.pnlUserMidRight.Controls.Add(this.lblUserList);
            this.pnlUserMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlUserMidRight.Location = new System.Drawing.Point(268, 0);
            this.pnlUserMidRight.Name = "pnlUserMidRight";
            this.pnlUserMidRight.Size = new System.Drawing.Size(224, 458);
            this.pnlUserMidRight.TabIndex = 19;
            // 
            // lisUserlist
            // 
            this.lisUserlist.AllowDrop = true;
            this.lisUserlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader11,
            this.ColumnHeader12,
            this.ColumnHeader13,
            this.ColumnHeader14});
            this.lisUserlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisUserlist.EnableSort = true;
            this.lisUserlist.EnableSortIcon = true;
            this.lisUserlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisUserlist.FullRowSelect = true;
            this.lisUserlist.Location = new System.Drawing.Point(0, 48);
            this.lisUserlist.Name = "lisUserlist";
            this.lisUserlist.Size = new System.Drawing.Size(224, 410);
            this.lisUserlist.TabIndex = 2;
            this.lisUserlist.TabStop = false;
            this.lisUserlist.UseCompatibleStateImageBehavior = false;
            this.lisUserlist.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader11
            // 
            this.ColumnHeader11.Text = "User";
            this.ColumnHeader11.Width = 80;
            // 
            // ColumnHeader12
            // 
            this.ColumnHeader12.Text = "Desc";
            this.ColumnHeader12.Width = 100;
            // 
            // ColumnHeader13
            // 
            this.ColumnHeader13.Text = "Group";
            this.ColumnHeader13.Width = 100;
            // 
            // ColumnHeader14
            // 
            this.ColumnHeader14.Text = "Email";
            this.ColumnHeader14.Width = 100;
            // 
            // pnlGroup
            // 
            this.pnlGroup.Controls.Add(this.cdvGroup);
            this.pnlGroup.Controls.Add(this.lblGroup);
            this.pnlGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGroup.Location = new System.Drawing.Point(0, 14);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.Size = new System.Drawing.Size(224, 34);
            this.pnlGroup.TabIndex = 1;
            // 
            // cdvGroup
            // 
            this.cdvGroup.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvGroup.BorderHotColor = System.Drawing.Color.Black;
            this.cdvGroup.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvGroup.BtnToolTipText = "";
            this.cdvGroup.DescText = "";
            this.cdvGroup.DisplaySubItemIndex = -1;
            this.cdvGroup.DisplayText = "";
            this.cdvGroup.Focusing = null;
            this.cdvGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvGroup.Index = 0;
            this.cdvGroup.IsViewBtnImage = false;
            this.cdvGroup.Location = new System.Drawing.Point(93, 7);
            this.cdvGroup.MaxLength = 20;
            this.cdvGroup.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvGroup.Name = "cdvGroup";
            this.cdvGroup.ReadOnly = true;
            this.cdvGroup.SearchSubItemIndex = 0;
            this.cdvGroup.SelectedDescIndex = -1;
            this.cdvGroup.SelectedSubItemIndex = -1;
            this.cdvGroup.SelectionStart = 0;
            this.cdvGroup.Size = new System.Drawing.Size(130, 20);
            this.cdvGroup.SmallImageList = null;
            this.cdvGroup.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvGroup.TabIndex = 1;
            this.cdvGroup.TextBoxToolTipText = "";
            this.cdvGroup.TextBoxWidth = 130;
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
            this.lblGroup.Location = new System.Drawing.Point(4, 10);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(77, 13);
            this.lblGroup.TabIndex = 0;
            this.lblGroup.Text = "Security Group";
            // 
            // lblUserList
            // 
            this.lblUserList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUserList.Location = new System.Drawing.Point(0, 0);
            this.lblUserList.Name = "lblUserList";
            this.lblUserList.Size = new System.Drawing.Size(224, 14);
            this.lblUserList.TabIndex = 0;
            this.lblUserList.Text = " All User List";
            // 
            // pnlUserAttach
            // 
            this.pnlUserAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserAttach.Controls.Add(this.btnDel);
            this.pnlUserAttach.Controls.Add(this.btnAdd);
            this.pnlUserAttach.Location = new System.Drawing.Point(229, 180);
            this.pnlUserAttach.Name = "pnlUserAttach";
            this.pnlUserAttach.Size = new System.Drawing.Size(35, 79);
            this.pnlUserAttach.TabIndex = 0;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(5, 42);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(24, 24);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = ">";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(5, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "<";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlUserMidLeft
            // 
            this.pnlUserMidLeft.Controls.Add(this.lisAttachUser);
            this.pnlUserMidLeft.Controls.Add(this.lblAttachUser);
            this.pnlUserMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUserMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlUserMidLeft.Name = "pnlUserMidLeft";
            this.pnlUserMidLeft.Size = new System.Drawing.Size(224, 458);
            this.pnlUserMidLeft.TabIndex = 16;
            // 
            // lisAttachUser
            // 
            this.lisAttachUser.AllowDrop = true;
            this.lisAttachUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader9,
            this.ColumnHeader10});
            this.lisAttachUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachUser.EnableSort = true;
            this.lisAttachUser.EnableSortIcon = true;
            this.lisAttachUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachUser.FullRowSelect = true;
            this.lisAttachUser.Location = new System.Drawing.Point(0, 14);
            this.lisAttachUser.Name = "lisAttachUser";
            this.lisAttachUser.Size = new System.Drawing.Size(224, 444);
            this.lisAttachUser.TabIndex = 1;
            this.lisAttachUser.TabStop = false;
            this.lisAttachUser.UseCompatibleStateImageBehavior = false;
            this.lisAttachUser.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "User";
            this.ColumnHeader7.Width = 80;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "Desc";
            this.ColumnHeader8.Width = 100;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "Group";
            this.ColumnHeader9.Width = 100;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "Email";
            this.ColumnHeader10.Width = 100;
            // 
            // lblAttachUser
            // 
            this.lblAttachUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttachUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachUser.Location = new System.Drawing.Point(0, 0);
            this.lblAttachUser.Name = "lblAttachUser";
            this.lblAttachUser.Size = new System.Drawing.Size(224, 14);
            this.lblAttachUser.TabIndex = 0;
            this.lblAttachUser.Text = "Attached User List";
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "Email";
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "Group";
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Desc";
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "User";
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.tabUser);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 0);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pnlCenter.Size = new System.Drawing.Size(742, 506);
            this.pnlCenter.TabIndex = 0;
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.tbpChart);
            this.tabUser.Controls.Add(this.tbpUser);
            this.tabUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUser.ItemSize = new System.Drawing.Size(60, 18);
            this.tabUser.Location = new System.Drawing.Point(3, 3);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(736, 503);
            this.tabUser.TabIndex = 0;
            // 
            // tbpChart
            // 
            this.tbpChart.Controls.Add(this.splChart);
            this.tbpChart.Controls.Add(this.pnlChartRight);
            this.tbpChart.Controls.Add(this.pnlChartLeft);
            this.tbpChart.Location = new System.Drawing.Point(4, 22);
            this.tbpChart.Name = "tbpChart";
            this.tbpChart.Size = new System.Drawing.Size(728, 477);
            this.tbpChart.TabIndex = 0;
            this.tbpChart.Text = "Chart";
            // 
            // splChart
            // 
            this.splChart.Location = new System.Drawing.Point(224, 0);
            this.splChart.Name = "splChart";
            this.splChart.Size = new System.Drawing.Size(3, 477);
            this.splChart.TabIndex = 1;
            this.splChart.TabStop = false;
            // 
            // tbpUser
            // 
            this.tbpUser.Controls.Add(this.pnlUserRight);
            this.tbpUser.Controls.Add(this.splUser);
            this.tbpUser.Controls.Add(this.pnlUserLeft);
            this.tbpUser.Location = new System.Drawing.Point(4, 22);
            this.tbpUser.Name = "tbpUser";
            this.tbpUser.Size = new System.Drawing.Size(728, 477);
            this.tbpUser.TabIndex = 1;
            this.tbpUser.Text = "User";
            // 
            // pnlUserRight
            // 
            this.pnlUserRight.Controls.Add(this.grpChart);
            this.pnlUserRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUserRight.Location = new System.Drawing.Point(227, 0);
            this.pnlUserRight.Name = "pnlUserRight";
            this.pnlUserRight.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlUserRight.Size = new System.Drawing.Size(501, 477);
            this.pnlUserRight.TabIndex = 5;
            this.pnlUserRight.Resize += new System.EventHandler(this.pnlUserRight_Resize);
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.pnlChartMid);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(3, 0);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(495, 477);
            this.grpChart.TabIndex = 0;
            this.grpChart.TabStop = false;
            // 
            // pnlChartMid
            // 
            this.pnlChartMid.Controls.Add(this.pnlChartMidRight);
            this.pnlChartMid.Controls.Add(this.pnlChartAttach);
            this.pnlChartMid.Controls.Add(this.pnlChartMidLeft);
            this.pnlChartMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartMid.Location = new System.Drawing.Point(3, 16);
            this.pnlChartMid.Name = "pnlChartMid";
            this.pnlChartMid.Size = new System.Drawing.Size(489, 458);
            this.pnlChartMid.TabIndex = 0;
            // 
            // pnlChartMidRight
            // 
            this.pnlChartMidRight.Controls.Add(this.lisChartlist);
            this.pnlChartMidRight.Controls.Add(this.pnlFilter1);
            this.pnlChartMidRight.Controls.Add(this.lblChart);
            this.pnlChartMidRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlChartMidRight.Location = new System.Drawing.Point(265, 0);
            this.pnlChartMidRight.Name = "pnlChartMidRight";
            this.pnlChartMidRight.Size = new System.Drawing.Size(224, 458);
            this.pnlChartMidRight.TabIndex = 19;
            // 
            // lisChartlist
            // 
            this.lisChartlist.AllowDrop = true;
            this.lisChartlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader17,
            this.ColumnHeader18});
            this.lisChartlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisChartlist.EnableSort = true;
            this.lisChartlist.EnableSortIcon = true;
            this.lisChartlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisChartlist.FullRowSelect = true;
            this.lisChartlist.Location = new System.Drawing.Point(0, 75);
            this.lisChartlist.Name = "lisChartlist";
            this.lisChartlist.Size = new System.Drawing.Size(224, 383);
            this.lisChartlist.TabIndex = 2;
            this.lisChartlist.TabStop = false;
            this.lisChartlist.UseCompatibleStateImageBehavior = false;
            this.lisChartlist.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader17
            // 
            this.ColumnHeader17.Text = "Chart";
            this.ColumnHeader17.Width = 100;
            // 
            // ColumnHeader18
            // 
            this.ColumnHeader18.Text = "Desc";
            this.ColumnHeader18.Width = 150;
            // 
            // pnlFilter1
            // 
            this.pnlFilter1.Controls.Add(this.grpFilter1);
            this.pnlFilter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter1.Location = new System.Drawing.Point(0, 12);
            this.pnlFilter1.Name = "pnlFilter1";
            this.pnlFilter1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.pnlFilter1.Size = new System.Drawing.Size(224, 63);
            this.pnlFilter1.TabIndex = 6;
            // 
            // grpFilter1
            // 
            this.grpFilter1.Controls.Add(this.cdvChartSetID1);
            this.grpFilter1.Controls.Add(this.lblChartSet1);
            this.grpFilter1.Controls.Add(this.btnView1);
            this.grpFilter1.Controls.Add(this.txtFilter1);
            this.grpFilter1.Controls.Add(this.rbnAll1);
            this.grpFilter1.Controls.Add(this.rbnFilter1);
            this.grpFilter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilter1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFilter1.Location = new System.Drawing.Point(0, 0);
            this.grpFilter1.Name = "grpFilter1";
            this.grpFilter1.Size = new System.Drawing.Size(224, 61);
            this.grpFilter1.TabIndex = 0;
            this.grpFilter1.TabStop = false;
            // 
            // cdvChartSetID1
            // 
            this.cdvChartSetID1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChartSetID1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChartSetID1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChartSetID1.BtnToolTipText = "";
            this.cdvChartSetID1.DescText = "";
            this.cdvChartSetID1.DisplaySubItemIndex = -1;
            this.cdvChartSetID1.DisplayText = "";
            this.cdvChartSetID1.Focusing = null;
            this.cdvChartSetID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChartSetID1.Index = 0;
            this.cdvChartSetID1.IsViewBtnImage = false;
            this.cdvChartSetID1.Location = new System.Drawing.Point(87, 38);
            this.cdvChartSetID1.MaxLength = 30;
            this.cdvChartSetID1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChartSetID1.Name = "cdvChartSetID1";
            this.cdvChartSetID1.ReadOnly = false;
            this.cdvChartSetID1.SearchSubItemIndex = 0;
            this.cdvChartSetID1.SelectedDescIndex = -1;
            this.cdvChartSetID1.SelectedSubItemIndex = -1;
            this.cdvChartSetID1.SelectionStart = 0;
            this.cdvChartSetID1.Size = new System.Drawing.Size(130, 20);
            this.cdvChartSetID1.SmallImageList = null;
            this.cdvChartSetID1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChartSetID1.TabIndex = 36;
            this.cdvChartSetID1.TextBoxToolTipText = "";
            this.cdvChartSetID1.TextBoxWidth = 130;
            this.cdvChartSetID1.VisibleButton = true;
            this.cdvChartSetID1.VisibleColumnHeader = false;
            this.cdvChartSetID1.VisibleDescription = false;
            this.cdvChartSetID1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChartSetID1_SelectedItemChanged);
            this.cdvChartSetID1.ButtonPress += new System.EventHandler(this.cdvChartSetID_ButtonPress);
            this.cdvChartSetID1.TextBoxTextChanged += new System.EventHandler(this.cdvChartSetID1_TextBoxTextChanged);
            // 
            // lblChartSet1
            // 
            this.lblChartSet1.AutoSize = true;
            this.lblChartSet1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChartSet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartSet1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChartSet1.Location = new System.Drawing.Point(8, 41);
            this.lblChartSet1.Name = "lblChartSet1";
            this.lblChartSet1.Size = new System.Drawing.Size(65, 13);
            this.lblChartSet1.TabIndex = 35;
            this.lblChartSet1.Text = "Chart Set ID";
            // 
            // btnView1
            // 
            this.btnView1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnView1.Location = new System.Drawing.Point(181, 13);
            this.btnView1.Name = "btnView1";
            this.btnView1.Size = new System.Drawing.Size(36, 20);
            this.btnView1.TabIndex = 8;
            this.btnView1.Text = "View";
            this.btnView1.Click += new System.EventHandler(this.btnView1_Click);
            // 
            // txtFilter1
            // 
            this.txtFilter1.Location = new System.Drawing.Point(26, 13);
            this.txtFilter1.MaxLength = 30;
            this.txtFilter1.Name = "txtFilter1";
            this.txtFilter1.Size = new System.Drawing.Size(98, 20);
            this.txtFilter1.TabIndex = 7;
            this.txtFilter1.TextChanged += new System.EventHandler(this.txtFilter1_TextChanged);
            // 
            // rbnAll1
            // 
            this.rbnAll1.AutoSize = true;
            this.rbnAll1.Location = new System.Drawing.Point(131, 16);
            this.rbnAll1.Name = "rbnAll1";
            this.rbnAll1.Size = new System.Drawing.Size(36, 17);
            this.rbnAll1.TabIndex = 6;
            this.rbnAll1.Text = "All";
            // 
            // rbnFilter1
            // 
            this.rbnFilter1.AutoSize = true;
            this.rbnFilter1.Location = new System.Drawing.Point(8, 16);
            this.rbnFilter1.Name = "rbnFilter1";
            this.rbnFilter1.Size = new System.Drawing.Size(14, 13);
            this.rbnFilter1.TabIndex = 5;
            // 
            // lblChart
            // 
            this.lblChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart.Location = new System.Drawing.Point(0, 0);
            this.lblChart.Name = "lblChart";
            this.lblChart.Size = new System.Drawing.Size(224, 12);
            this.lblChart.TabIndex = 0;
            this.lblChart.Text = " All Chart List";
            // 
            // pnlChartAttach
            // 
            this.pnlChartAttach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChartAttach.Controls.Add(this.btnDel1);
            this.pnlChartAttach.Controls.Add(this.btnAdd1);
            this.pnlChartAttach.Location = new System.Drawing.Point(229, 180);
            this.pnlChartAttach.Name = "pnlChartAttach";
            this.pnlChartAttach.Size = new System.Drawing.Size(32, 79);
            this.pnlChartAttach.TabIndex = 0;
            // 
            // btnDel1
            // 
            this.btnDel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel1.Location = new System.Drawing.Point(4, 42);
            this.btnDel1.Name = "btnDel1";
            this.btnDel1.Size = new System.Drawing.Size(24, 24);
            this.btnDel1.TabIndex = 1;
            this.btnDel1.Text = ">";
            this.btnDel1.Click += new System.EventHandler(this.btnDel1_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd1.Location = new System.Drawing.Point(4, 13);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(24, 24);
            this.btnAdd1.TabIndex = 0;
            this.btnAdd1.Text = "<";
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // pnlChartMidLeft
            // 
            this.pnlChartMidLeft.Controls.Add(this.lisAttachChart);
            this.pnlChartMidLeft.Controls.Add(this.lblAttachChart);
            this.pnlChartMidLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlChartMidLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlChartMidLeft.Name = "pnlChartMidLeft";
            this.pnlChartMidLeft.Size = new System.Drawing.Size(224, 458);
            this.pnlChartMidLeft.TabIndex = 16;
            // 
            // lisAttachChart
            // 
            this.lisAttachChart.AllowDrop = true;
            this.lisAttachChart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader21,
            this.ColumnHeader22});
            this.lisAttachChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisAttachChart.EnableSort = true;
            this.lisAttachChart.EnableSortIcon = true;
            this.lisAttachChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisAttachChart.FullRowSelect = true;
            this.lisAttachChart.Location = new System.Drawing.Point(0, 14);
            this.lisAttachChart.Name = "lisAttachChart";
            this.lisAttachChart.Size = new System.Drawing.Size(224, 444);
            this.lisAttachChart.TabIndex = 1;
            this.lisAttachChart.TabStop = false;
            this.lisAttachChart.UseCompatibleStateImageBehavior = false;
            this.lisAttachChart.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader21
            // 
            this.ColumnHeader21.Text = "Chart";
            this.ColumnHeader21.Width = 100;
            // 
            // ColumnHeader22
            // 
            this.ColumnHeader22.Text = "Desc";
            this.ColumnHeader22.Width = 150;
            // 
            // lblAttachChart
            // 
            this.lblAttachChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttachChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblAttachChart.Location = new System.Drawing.Point(0, 0);
            this.lblAttachChart.Name = "lblAttachChart";
            this.lblAttachChart.Size = new System.Drawing.Size(224, 14);
            this.lblAttachChart.TabIndex = 0;
            this.lblAttachChart.Text = "Attached Chart List";
            // 
            // splUser
            // 
            this.splUser.Location = new System.Drawing.Point(224, 0);
            this.splUser.Name = "splUser";
            this.splUser.Size = new System.Drawing.Size(3, 477);
            this.splUser.TabIndex = 4;
            this.splUser.TabStop = false;
            // 
            // pnlUserLeft
            // 
            this.pnlUserLeft.Controls.Add(this.lisUser);
            this.pnlUserLeft.Controls.Add(this.pnlSecGrp);
            this.pnlUserLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlUserLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlUserLeft.Name = "pnlUserLeft";
            this.pnlUserLeft.Padding = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pnlUserLeft.Size = new System.Drawing.Size(224, 477);
            this.pnlUserLeft.TabIndex = 1;
            // 
            // lisUser
            // 
            this.lisUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader15,
            this.ColumnHeader16});
            this.lisUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisUser.EnableSort = true;
            this.lisUser.EnableSortIcon = true;
            this.lisUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lisUser.FullRowSelect = true;
            this.lisUser.Location = new System.Drawing.Point(3, 37);
            this.lisUser.MultiSelect = false;
            this.lisUser.Name = "lisUser";
            this.lisUser.Size = new System.Drawing.Size(221, 437);
            this.lisUser.TabIndex = 0;
            this.lisUser.TabStop = false;
            this.lisUser.UseCompatibleStateImageBehavior = false;
            this.lisUser.View = System.Windows.Forms.View.Details;
            this.lisUser.SelectedIndexChanged += new System.EventHandler(this.lisUser_SelectedIndexChanged);
            // 
            // ColumnHeader15
            // 
            this.ColumnHeader15.Text = "User";
            this.ColumnHeader15.Width = 100;
            // 
            // ColumnHeader16
            // 
            this.ColumnHeader16.Text = "Description";
            this.ColumnHeader16.Width = 300;
            // 
            // pnlSecGrp
            // 
            this.pnlSecGrp.Controls.Add(this.cdvSecGrp);
            this.pnlSecGrp.Controls.Add(this.lblSecGrp);
            this.pnlSecGrp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSecGrp.Location = new System.Drawing.Point(3, 3);
            this.pnlSecGrp.Name = "pnlSecGrp";
            this.pnlSecGrp.Size = new System.Drawing.Size(221, 34);
            this.pnlSecGrp.TabIndex = 2;
            // 
            // cdvSecGrp
            // 
            this.cdvSecGrp.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvSecGrp.BorderHotColor = System.Drawing.Color.Black;
            this.cdvSecGrp.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvSecGrp.BtnToolTipText = "";
            this.cdvSecGrp.DescText = "";
            this.cdvSecGrp.DisplaySubItemIndex = -1;
            this.cdvSecGrp.DisplayText = "";
            this.cdvSecGrp.Focusing = null;
            this.cdvSecGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvSecGrp.Index = 0;
            this.cdvSecGrp.IsViewBtnImage = false;
            this.cdvSecGrp.Location = new System.Drawing.Point(93, 7);
            this.cdvSecGrp.MaxLength = 20;
            this.cdvSecGrp.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvSecGrp.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvSecGrp.Name = "cdvSecGrp";
            this.cdvSecGrp.ReadOnly = true;
            this.cdvSecGrp.SearchSubItemIndex = 0;
            this.cdvSecGrp.SelectedDescIndex = -1;
            this.cdvSecGrp.SelectedSubItemIndex = -1;
            this.cdvSecGrp.SelectionStart = 0;
            this.cdvSecGrp.Size = new System.Drawing.Size(123, 20);
            this.cdvSecGrp.SmallImageList = null;
            this.cdvSecGrp.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvSecGrp.TabIndex = 1;
            this.cdvSecGrp.TextBoxToolTipText = "";
            this.cdvSecGrp.TextBoxWidth = 123;
            this.cdvSecGrp.VisibleButton = true;
            this.cdvSecGrp.VisibleColumnHeader = false;
            this.cdvSecGrp.VisibleDescription = false;
            this.cdvSecGrp.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvSecGrp_SelectedItemChanged);
            this.cdvSecGrp.ButtonPress += new System.EventHandler(this.cdvSecGrp_ButtonPress);
            // 
            // lblSecGrp
            // 
            this.lblSecGrp.AutoSize = true;
            this.lblSecGrp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSecGrp.Location = new System.Drawing.Point(4, 10);
            this.lblSecGrp.Name = "lblSecGrp";
            this.lblSecGrp.Size = new System.Drawing.Size(77, 13);
            this.lblSecGrp.TabIndex = 0;
            this.lblSecGrp.Text = "Security Group";
            // 
            // frmSPCAttachUserToChart
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(742, 546);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(750, 580);
            this.Name = "frmSPCAttachUserToChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Attach User to Chart";
            this.Load += new System.EventHandler(this.frmSPCAttachUserToChart_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlChartLeft.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter)).EndInit();
            this.pnlChartRight.ResumeLayout(false);
            this.grpRight.ResumeLayout(false);
            this.pnlUserMid.ResumeLayout(false);
            this.pnlUserMidRight.ResumeLayout(false);
            this.pnlGroup.ResumeLayout(false);
            this.pnlGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvGroup)).EndInit();
            this.pnlUserAttach.ResumeLayout(false);
            this.pnlUserMidLeft.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.tbpChart.ResumeLayout(false);
            this.tbpUser.ResumeLayout(false);
            this.pnlUserRight.ResumeLayout(false);
            this.grpChart.ResumeLayout(false);
            this.pnlChartMid.ResumeLayout(false);
            this.pnlChartMidRight.ResumeLayout(false);
            this.pnlFilter1.ResumeLayout(false);
            this.grpFilter1.ResumeLayout(false);
            this.grpFilter1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChartSetID1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter1)).EndInit();
            this.pnlChartAttach.ResumeLayout(false);
            this.pnlChartMidLeft.ResumeLayout(false);
            this.pnlUserLeft.ResumeLayout(false);
            this.pnlSecGrp.ResumeLayout(false);
            this.pnlSecGrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvSecGrp)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion
        
        #region " Function Implementations"
        
        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - boolean : True / False
        // Arguments
        //       - ByVal c_step As String : Process Step
        //
        private bool CheckCondition(string c_step)
        {
            
            try
            {
                switch (c_step)
                {
                    case "USER_ATTACH":
                        
                        if (lisChart.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisChart.Items.Count > 0)
                            {
                                lisChart.Items[0].Selected = true;
                                lisChart.Focus();
                            }
                            return false;
                        }
                        if (lisUserlist.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisUserlist.Items.Count > 0)
                            {
                                lisUserlist.Items[0].Selected = true;
                                lisUserlist.Focus();
                            }
                            return false;
                        }
                        break;
                    case "USER_DETACH":
                        
                        if (lisChart.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisChart.Items.Count > 0)
                            {
                                lisChart.Items[0].Selected = true;
                                lisChart.Focus();
                            }
                            return false;
                        }
                        if (lisAttachUser.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisAttachUser.Items.Count > 0)
                            {
                                lisAttachUser.Items[0].Selected = true;
                                lisAttachUser.Focus();
                            }
                            return false;
                        }
                        break;
                    case "CHART_ATTACH":
                        
                        if (lisUser.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisUser.Items.Count > 0)
                            {
                                lisUser.Items[0].Selected = true;
                                lisUser.Focus();
                            }
                            return false;
                        }
                        if (lisChartlist.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisChartlist.Items.Count > 0)
                            {
                                lisChartlist.Items[0].Selected = true;
                                lisChartlist.Focus();
                            }
                            return false;
                        }
                        break;
                    case "CHART_DETACH":
                        
                        if (lisUser.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisUser.Items.Count > 0)
                            {
                                lisUser.Items[0].Selected = true;
                                lisUser.Focus();
                            }
                            return false;
                        }
                        if (lisAttachChart.SelectedItems.Count <= 0)
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(109));
                            if (lisAttachChart.Items.Count > 0)
                            {
                                lisAttachChart.Items[0].Selected = true;
                                lisAttachChart.Focus();
                            }
                            return false;
                        }
                        break;
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // Attach_User()
        //       - Create/Update/Delete Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal c_step As String : Process Step
        //       - ByVal sUser As String : User
        //       - ByVal sChart As String : Chart
        //       -       out_node as ref TRSNode : out node
        //
        private bool Attach_User(char c_step, string sUser, string sChart, ref TRSNode out_node)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("Attach_User_In");
                //TRSNode out_node = new TRSNode("Cmn_Out");

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = c_step;
                in_node.AddString("CHART_ID", MPCF.Trim(sChart));
                in_node.AddString("USER_ID", MPCF.Trim(sUser), true);

                if (MPCR.CallService("SPC", "SPC_Update_Chart_User", in_node, ref out_node) == false)
                {
                    return false;
                }
                //MPCR.ShowSuccessMsg(out_node);
                                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.Attach_User()\n" + ex.Message);
                return false;
            }
            
        }
        
        public virtual Control GetFisrtFocusItem()
        {
            
            try
            {
                return this.tabUser;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox(ex.Message);
                return null;
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCAttachUserToChart_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                
                MPCF.InitListView(lisChart);
                MPCF.InitListView(lisAttachUser);
                MPCF.InitListView(lisUserlist);
                MPCF.InitListView(lisUser);
                MPCF.InitListView(lisAttachChart);
                MPCF.InitListView(lisChartlist);
                
                rbnFilter.Checked = true;
                txtFilter.Text = modSPCFunctions.GetFilterKey();
                
                rbnFilter1.Checked = true;
                txtFilter1.Text = modSPCFunctions.GetFilterKey();
                
                if (SECLIST.ViewSECUserList(lisUserlist, '1', -1, null, "", "") == false)
                {
                    return;
                }
                
                if (SECLIST.ViewSECUserList(lisUser, '1', -1, null, "", "") == true)
                {
                    if (lisUser.Items.Count > 0)
                    {
                        lisUser.Items[0].Selected = true;
                    }
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.frmSPCAttachUserToChart_Load()\n" + ex.Message);
            }
            
        }
        
        private void cdvGroup_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvGroup.Init();
                MPCF.InitListView(cdvGroup.GetListView);
                cdvGroup.Columns.Add("UserGroup", 100, HorizontalAlignment.Left);
                cdvGroup.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvGroup.SelectedSubItemIndex = 0;
                if (SECLIST.ViewSecGroupList(cdvGroup.GetListView, '1', null, "") == false)
                {
                    return;
                }
                cdvGroup.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.cdvGroup_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvGroup_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (cdvGroup.Text == "")
                {
                    if (SECLIST.ViewSECUserList(lisUserlist, '1', -1, null, "", "") == false)
                    {
                        return;
                    }
                    if (lisUserlist.Items.Count > 0)
                    {
                        lisUserlist.Items[0].Selected = true;
                    }
                }
                else
                {
                    if (SECLIST.ViewSECUserList(lisUserlist, '2', -1, null, "", cdvGroup.Text) == false)
                    {
                        return;
                    }
                    if (lisUserlist.Items.Count > 0)
                    {
                        lisUserlist.Items[0].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.cdvGroup_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void lisChart_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(lisAttachUser, true);
                if (lisChart.SelectedItems.Count > 0)
                {
                    SPCLIST.ViewSPCAttachUserList(lisAttachUser, '1', lisChart.SelectedItems[0].Text, "");
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.lisChart_SelectedIndexChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                string sUser;
                string sChart;
                string[] sSelect = null;
                int i;
                int j;
                int iIdx = 0;
                int iSuccessCount = 0;
                sSelect = new string[lisUserlist.SelectedItems.Count];
                
                MPCF.SelectClear(lisAttachUser);
                if (CheckCondition("USER_ATTACH") == false)
                {
                    return;
                }
                for (i = 0; i <= lisUserlist.SelectedItems.Count - 1; i++)
                {
                    sUser = lisUserlist.SelectedItems[i].Text;
                    sChart = lisChart.SelectedItems[0].Text;
                    if (MPCF.FindListItem(lisAttachUser, sUser, false) == false)
                    {
                        if (Attach_User(MPGC.MP_STEP_CREATE, sUser, sChart, ref out_node) == true)
                        {
                            iSuccessCount++;
                            sSelect[i] = sUser;
                        }
                        else
                        {
                            for (j = 0; j <= sSelect.Length - 1; j++)
                            {
                                MPCF.FindListItem(lisAttachUser, sSelect[j], false);
                            }
                            MPCF.SelectClear(lisUserlist);
                            //return;
                        }
                    }
                    else
                    {
                        sSelect[i] = sUser;
                        iIdx = lisUserlist.SelectedItems[i].Index;
                    }
                }

                if (iSuccessCount > 0)
                {
                    MPCR.ShowSuccessMsg(out_node);
                }
                else
                {
                    return;
                }

                if (SPCLIST.ViewSPCAttachUserList(lisAttachUser, '1', lisChart.SelectedItems[0].Text, "") == false)
                {
                    return;
                }
                MPCF.SelectClear(lisUserlist);
                if (sSelect.Length == 1)
                {
                    if (iIdx < lisUserlist.Items.Count - 1)
                    {
                        lisUserlist.Items[iIdx + 1].Selected = true;
                    }
                }
                for (i = 0; i <= sSelect.Length - 1; i++)
                {
                    MPCF.FindListItem(lisAttachUser, sSelect[i], false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.btnAdd_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnDel_Click(System.Object sender, System.EventArgs e)
        {
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                string sUser;
                string sChart;
                int iIdx = 0;
                int i;
                int iCount;
                int iSuccessCount = 0;
                
                if (CheckCondition("USER_DETACH") == false)
                {
                    return;
                }
                iCount = lisAttachUser.SelectedItems.Count;
                MPCF.SelectClear(lisUserlist);
                for (i = lisAttachUser.SelectedItems.Count - 1; i >= 0; i--)
                {
                    sUser = lisAttachUser.SelectedItems[i].Text;
                    sChart = lisChart.SelectedItems[0].Text;
                    
                    if (Attach_User(MPGC.MP_STEP_DELETE, sUser, sChart, ref out_node) == true)
                    {
                        iSuccessCount++;
                        iIdx = lisAttachUser.SelectedItems[i].Index;
                        lisAttachUser.Items.RemoveAt(iIdx);
                        MPCF.FindListItem(lisUserlist, sUser, false);
                    }
                }
                if (iSuccessCount > 0)
                {
                    MPCR.ShowSuccessMsg(out_node);
                }
                else
                {
                    return;
                }

                if (iCount == 1)
                {
                    if (iIdx < lisAttachUser.Items.Count)
                    {
                        lisAttachUser.Items[iIdx].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.btnDel_Click()\n" + ex.Message);
            }
            
        }
        
        private void pnlRight_Resize(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldAdjust(pnlUserMid, pnlUserMidLeft, pnlUserMidRight, pnlUserAttach, 40);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.pnlRight_Resize()\n" + ex.Message);
            }
            
        }
        
        private void cdvSecGrp_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                cdvSecGrp.Init();
                MPCF.InitListView(cdvSecGrp.GetListView);
                cdvSecGrp.Columns.Add("UserGroup", 100, HorizontalAlignment.Left);
                cdvSecGrp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvSecGrp.SelectedSubItemIndex = 0;
                if (SECLIST.ViewSecGroupList(cdvSecGrp.GetListView, '1', null, "") == false)
                {
                    return;
                }
                cdvSecGrp.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.cdvSecGrp_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvSecGrp_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (cdvSecGrp.Text == "")
                {
                    if (SECLIST.ViewSECUserList(lisUser, '1', -1, null, "", "") == false)
                    {
                        return;
                    }
                    if (lisUser.Items.Count > 0)
                    {
                        lisUser.Items[0].Selected = true;
                    }
                }
                else
                {
                    if (SECLIST.ViewSECUserList(lisUser, '2', -1, null, "", cdvSecGrp.Text) == false)
                    {
                        return;
                    }
                    if (lisUser.Items.Count > 0)
                    {
                        lisUser.Items[0].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.cdvSecGrp_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void lisUser_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.ClearList(lisAttachChart, true);
                if (lisUser.SelectedItems.Count > 0)
                {
                    SPCLIST.ViewSPCAttachUserList(lisAttachChart, '2', lisUser.SelectedItems[0].Text, "");
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.lisUser_SelectedIndexChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnAdd1_Click(System.Object sender, System.EventArgs e)
        {
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                string sUser;
                string sChart;
                string[] sSelect = null;
                int i;
                int j;
                int iIdx = 0;
                int iSuccessCount = 0;
                sSelect = new string[lisChartlist.SelectedItems.Count];
                
                MPCF.SelectClear(lisAttachChart);
                if (CheckCondition("CHART_ATTACH") == false)
                {
                    return;
                }
                for (i = 0; i <= lisChartlist.SelectedItems.Count - 1; i++)
                {
                    sChart = lisChartlist.SelectedItems[i].Text;
                    sUser = lisUser.SelectedItems[0].Text;
                    if (MPCF.FindListItem(lisAttachChart, sChart, false) == false)
                    {
                        if (Attach_User(MPGC.MP_STEP_CREATE, sUser, sChart, ref out_node) == true)
                        {
                            iSuccessCount++;
                            sSelect[i] = sChart;
                        }
                        else
                        {
                            for (j = 0; j <= sSelect.Length - 1; j++)
                            {
                                MPCF.FindListItem(lisAttachChart, sSelect[j], false);
                            }
                            MPCF.SelectClear(lisChartlist);
                        }
                    }
                    else
                    {
                        sSelect[i] = sChart;
                        iIdx = lisChartlist.SelectedItems[i].Index;
                    }
                }

                if (iSuccessCount > 0)
                {
                    MPCR.ShowSuccessMsg(out_node);
                }
                else
                {
                    return;
                }

                if (SPCLIST.ViewSPCAttachUserList(lisAttachChart, '2', lisUser.SelectedItems[0].Text, "") == false)
                {
                    return;
                }
                MPCF.SelectClear(lisChartlist);
                if (sSelect.Length == 1)
                {
                    if (iIdx < lisChartlist.Items.Count - 1)
                    {
                        lisChartlist.Items[iIdx + 1].Selected = true;
                    }
                }
                for (i = 0; i <= sSelect.Length - 1; i++)
                {
                    MPCF.FindListItem(lisAttachChart, sSelect[i], false);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.btnAdd1_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnDel1_Click(System.Object sender, System.EventArgs e)
        {
            TRSNode out_node = new TRSNode("Cmn_Out");

            try
            {
                string sUser;
                string sChart;
                int iIdx = 0;
                int i;
                int iCount;
                int iSuccessCount = 0;
                
                if (CheckCondition("CHART_DETACH") == false)
                {
                    return;
                }
                iCount = lisAttachChart.SelectedItems.Count;
                MPCF.SelectClear(lisChartlist);
                for (i = lisAttachChart.SelectedItems.Count - 1; i >= 0; i--)
                {
                    sChart = lisAttachChart.SelectedItems[i].Text;
                    sUser = lisUser.SelectedItems[0].Text;
                    
                    if (Attach_User(MPGC.MP_STEP_DELETE, sUser, sChart, ref out_node) == true)
                    {
                        iSuccessCount++;
                        iIdx = lisAttachChart.SelectedItems[i].Index;
                        lisAttachChart.Items.RemoveAt(iIdx);
                        MPCF.FindListItem(lisChartlist, sChart, false);
                    }
                }

                if (iSuccessCount > 0)
                {
                    MPCR.ShowSuccessMsg(out_node);
                }
                else
                {
                    return;
                }

                if (iCount == 1)
                {
                    if (iIdx < lisAttachChart.Items.Count)
                    {
                        lisAttachChart.Items[iIdx].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.btnDel1_Click()\n" + ex.Message);
            }
            
        }
        
        private void pnlUserRight_Resize(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.FieldAdjust(pnlChartMid, pnlChartMidLeft, pnlChartMidRight, pnlChartAttach, 40);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.pnlUserRight_Resize()\n" + ex.Message);
            }
            
        }
        
        private void btnView_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                modSPCFunctions.SaveFilterKey(MPCF.Trim(txtFilter.Text));
                cdvChartSetID.Text = "";
                
                if (rbnFilter.Checked == true && MPCF.Trim(txtFilter.Text) == "")
                {
                    lisChart.Items.Clear();
                    return;
                }
                if (SPCLIST.ViewChartList(lisChart, '1', "",0, "", "", "", ' ', ' ', (rbnAll.Checked == true ? "" : (MPCF.Trim(txtFilter.Text))), "", -1, -1, null, "") == true)
                {
                    if (lisChart.Items.Count > 0)
                    {
                        lisChart.Items[0].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.btnView_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnView1_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                modSPCFunctions.SaveFilterKey(MPCF.Trim(txtFilter1.Text));
                cdvChartSetID1.Text = "";
                
                if (rbnFilter1.Checked == true && MPCF.Trim(txtFilter1.Text) == "")
                {
                    lisChartlist.Items.Clear();
                    return;
                }
                if (SPCLIST.ViewChartList(lisChartlist, '1', "", 0, "", "", "", ' ', ' ', (rbnAll1.Checked == true ? "" : (MPCF.Trim(txtFilter1.Text))), "", -1, -1, null, "") == true)
                {
                    if (lisChartlist.Items.Count > 0)
                    {
                        lisChartlist.Items[0].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.btnView1_Click()\n" + ex.Message);
            }
            
        }
        
        private void txtFilter_TextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                rbnFilter.Checked = true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.txtFilter_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void txtFilter1_TextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                rbnFilter1.Checked = true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.txtFilter1_TextChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_ButtonPress(object sender, System.EventArgs e)
        {
            
            Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
            try
            {
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
                cdvTemp.Init();
                MPCF.InitListView(cdvTemp.GetListView);
                cdvTemp.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTemp.SelectedSubItemIndex = 0;
                SPCLIST.ViewChartSetList(cdvTemp.GetListView, '1', "", 0,"", "", ' ', "", -1, -1, "");
                cdvTemp.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.cdvChartSetID_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (cdvChartSetID.Text != "")
                {
                    if (SPCLIST.ViewSPCAttachChartList(lisChart, '1', cdvChartSetID.Text, "") == false)
                    {
                        return;
                    }
                    if (lisChart.Items.Count > 0)
                    {
                        lisChart.Items[0].Selected = true;
                    }
                }
                else
                {
                    MPCF.InitListView(this.lisAttachUser);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.cdvChartSetID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID1_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                if (cdvChartSetID1.Text != "")
                {
                    if (SPCLIST.ViewSPCAttachChartList(lisChartlist, '1', cdvChartSetID1.Text, "") == false)
                    {
                        return;
                    }
                    if (lisChartlist.Items.Count > 0)
                    {
                        lisChartlist.Items[0].Selected = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.cdvChartSetID_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(this.lisChart);
                MPCF.InitListView(this.lisAttachUser);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.cdvChartSetID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        private void cdvChartSetID1_TextBoxTextChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                MPCF.InitListView(this.lisChartlist);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCAttachUserToChart.cdvChartSetID_TextBoxTextChanged()\n" + ex.Message);
            }
            
        }
        
        #endregion
        
    }
    
    //#End If
    
}
