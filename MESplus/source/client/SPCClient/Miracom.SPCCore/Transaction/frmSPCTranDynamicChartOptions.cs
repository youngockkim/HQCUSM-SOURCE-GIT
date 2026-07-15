
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
using Infragistics.Win.UltraWinEditors;
using Miracom.TRSCore;
//#If _SPC = True Then

//-----------------------------------------------------------------------------
//
//   System      : SPCClient
//   File Name   : frmSPCTranDynamicChartOptions.vb
//   Description : Set Multi Chart Option
//
//   SPC Version : 1.0.0
//
//   Function List
//       - CheckCondition : Check the conditions before transaction
//       - View_Chart : View Chart Information
//       - SetChartEnable : Set Enable Property Chart ID Control
//       - SaveChartOption : Save Chart Option
//       - GetChartOption : Get Chart Option
//       - SetChartOptions : Set Chart Options
//       - CheckChartID : Check Chart ID is repeated
//
//   Detail Description
//       -
//
//   History
//       - 2005-05-09 : Created by H.K.Kim
//
//   Copyright(C) 1998-2004 MIRACOM,INC.
//   All rights reserved.
//
//-----------------------------------------------------------------------------

namespace Miracom.SPCCore
{
    public class frmSPCTranDynamicChartOptions : System.Windows.Forms.Form
    {
        
        #region " Windows Form auto generated code "
        
        public frmSPCTranDynamicChartOptions()
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
        



        internal System.Windows.Forms.Panel pnlBottom;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.GroupBox grpChart;
        internal System.Windows.Forms.Panel pnlTop;
        internal System.Windows.Forms.Panel pnlOption;
        internal System.Windows.Forms.GroupBox grpOption;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewRuleCheck;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewRChart;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewSpecLimit;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewDate;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewLotID;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor txtMaxLotCount;
        internal System.Windows.Forms.Label lblMaxLotCount;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewCZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewBZone;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkViewAZone;
        internal System.Windows.Forms.GroupBox grpChartID;
        internal System.Windows.Forms.Panel pnlChart9;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart9;
        internal System.Windows.Forms.Label lblChart9;
        internal System.Windows.Forms.Panel pnlChart8;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart8;
        internal System.Windows.Forms.Label lblChart8;
        internal System.Windows.Forms.Panel pnlChart7;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart7;
        internal System.Windows.Forms.Label lblChart7;
        internal System.Windows.Forms.Panel pnlChart6;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart6;
        internal System.Windows.Forms.Label lblChart6;
        internal System.Windows.Forms.Panel pnlChart5;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart5;
        internal System.Windows.Forms.Label lblChart5;
        internal System.Windows.Forms.Panel pnlChart4;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart4;
        internal System.Windows.Forms.Label lblChart4;
        internal System.Windows.Forms.Panel pnlChart3;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart3;
        internal System.Windows.Forms.Label lblChart3;
        internal System.Windows.Forms.Panel pnlChart2;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart2;
        internal System.Windows.Forms.Label lblChart2;
        internal System.Windows.Forms.Panel pnlChart1;
        internal Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart1;
        internal System.Windows.Forms.Label lblChart1;
        internal System.Windows.Forms.RadioButton rbn2;
        internal System.Windows.Forms.RadioButton rbn9;
        internal System.Windows.Forms.RadioButton rbn4;
        internal System.Windows.Forms.RadioButton rbn6;
        internal System.Windows.Forms.PictureBox pbxCell_2;
        internal System.Windows.Forms.PictureBox pbxCell_4;
        internal System.Windows.Forms.PictureBox pbxCell_6;
        internal System.Windows.Forms.PictureBox pbxCell_9;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkSimpleChart;
        internal Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAutoCalControlLimit;
        internal System.Windows.Forms.Button btnFiltering1;
        internal System.Windows.Forms.Button btnFiltering6;
        internal System.Windows.Forms.Button btnFiltering5;
        internal System.Windows.Forms.Button btnFiltering4;
        internal System.Windows.Forms.Button btnFiltering3;
        internal System.Windows.Forms.Button btnFiltering2;
        internal System.Windows.Forms.Button btnFiltering8;
        internal System.Windows.Forms.Button btnFiltering7;
        internal System.Windows.Forms.Button btnFiltering9;
        [System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSPCTranDynamicChartOptions));
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.pbxCell_9 = new System.Windows.Forms.PictureBox();
            this.pbxCell_6 = new System.Windows.Forms.PictureBox();
            this.pbxCell_4 = new System.Windows.Forms.PictureBox();
            this.pbxCell_2 = new System.Windows.Forms.PictureBox();
            this.rbn6 = new System.Windows.Forms.RadioButton();
            this.rbn4 = new System.Windows.Forms.RadioButton();
            this.rbn9 = new System.Windows.Forms.RadioButton();
            this.rbn2 = new System.Windows.Forms.RadioButton();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpChartID = new System.Windows.Forms.GroupBox();
            this.pnlChart9 = new System.Windows.Forms.Panel();
            this.btnFiltering9 = new System.Windows.Forms.Button();
            this.cdvChart9 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChart9 = new System.Windows.Forms.Label();
            this.pnlChart8 = new System.Windows.Forms.Panel();
            this.btnFiltering8 = new System.Windows.Forms.Button();
            this.cdvChart8 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChart8 = new System.Windows.Forms.Label();
            this.pnlChart7 = new System.Windows.Forms.Panel();
            this.btnFiltering7 = new System.Windows.Forms.Button();
            this.cdvChart7 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChart7 = new System.Windows.Forms.Label();
            this.pnlChart6 = new System.Windows.Forms.Panel();
            this.btnFiltering6 = new System.Windows.Forms.Button();
            this.cdvChart6 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChart6 = new System.Windows.Forms.Label();
            this.pnlChart5 = new System.Windows.Forms.Panel();
            this.btnFiltering5 = new System.Windows.Forms.Button();
            this.cdvChart5 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChart5 = new System.Windows.Forms.Label();
            this.pnlChart4 = new System.Windows.Forms.Panel();
            this.btnFiltering4 = new System.Windows.Forms.Button();
            this.cdvChart4 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChart4 = new System.Windows.Forms.Label();
            this.pnlChart3 = new System.Windows.Forms.Panel();
            this.btnFiltering3 = new System.Windows.Forms.Button();
            this.cdvChart3 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChart3 = new System.Windows.Forms.Label();
            this.pnlChart2 = new System.Windows.Forms.Panel();
            this.btnFiltering2 = new System.Windows.Forms.Button();
            this.cdvChart2 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChart2 = new System.Windows.Forms.Label();
            this.pnlChart1 = new System.Windows.Forms.Panel();
            this.btnFiltering1 = new System.Windows.Forms.Button();
            this.cdvChart1 = new Miracom.UI.Controls.MCCodeView.MCCodeView();
            this.lblChart1 = new System.Windows.Forms.Label();
            this.pnlOption = new System.Windows.Forms.Panel();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.chkAutoCalControlLimit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkSimpleChart = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewRuleCheck = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewRChart = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewSpecLimit = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewDate = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewLotID = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.txtMaxLotCount = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblMaxLotCount = new System.Windows.Forms.Label();
            this.chkViewCZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewBZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkViewAZone = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.pnlBottom.SuspendLayout();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCell_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCell_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCell_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCell_2)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.grpChartID.SuspendLayout();
            this.pnlChart9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart9)).BeginInit();
            this.pnlChart8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart8)).BeginInit();
            this.pnlChart7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart7)).BeginInit();
            this.pnlChart6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart6)).BeginInit();
            this.pnlChart5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart5)).BeginInit();
            this.pnlChart4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart4)).BeginInit();
            this.pnlChart3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart3)).BeginInit();
            this.pnlChart2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart2)).BeginInit();
            this.pnlChart1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart1)).BeginInit();
            this.pnlOption.SuspendLayout();
            this.grpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLotCount)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 426);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(568, 40);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOK.Location = new System.Drawing.Point(384, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 26);
            this.btnOK.TabIndex = 0;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(476, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpChart
            // 
            this.grpChart.Controls.Add(this.pbxCell_9);
            this.grpChart.Controls.Add(this.pbxCell_6);
            this.grpChart.Controls.Add(this.pbxCell_4);
            this.grpChart.Controls.Add(this.pbxCell_2);
            this.grpChart.Controls.Add(this.rbn6);
            this.grpChart.Controls.Add(this.rbn4);
            this.grpChart.Controls.Add(this.rbn9);
            this.grpChart.Controls.Add(this.rbn2);
            this.grpChart.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpChart.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChart.Location = new System.Drawing.Point(3, 0);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(233, 300);
            this.grpChart.TabIndex = 0;
            this.grpChart.TabStop = false;
            this.grpChart.Text = "Select Chart Count";
            // 
            // pbxCell_9
            // 
            this.pbxCell_9.Image = ((System.Drawing.Image)(resources.GetObject("pbxCell_9.Image")));
            this.pbxCell_9.Location = new System.Drawing.Point(52, 212);
            this.pbxCell_9.Name = "pbxCell_9";
            this.pbxCell_9.Size = new System.Drawing.Size(40, 40);
            this.pbxCell_9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCell_9.TabIndex = 7;
            this.pbxCell_9.TabStop = false;
            // 
            // pbxCell_6
            // 
            this.pbxCell_6.Image = ((System.Drawing.Image)(resources.GetObject("pbxCell_6.Image")));
            this.pbxCell_6.Location = new System.Drawing.Point(52, 152);
            this.pbxCell_6.Name = "pbxCell_6";
            this.pbxCell_6.Size = new System.Drawing.Size(40, 40);
            this.pbxCell_6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCell_6.TabIndex = 6;
            this.pbxCell_6.TabStop = false;
            // 
            // pbxCell_4
            // 
            this.pbxCell_4.Image = ((System.Drawing.Image)(resources.GetObject("pbxCell_4.Image")));
            this.pbxCell_4.Location = new System.Drawing.Point(52, 92);
            this.pbxCell_4.Name = "pbxCell_4";
            this.pbxCell_4.Size = new System.Drawing.Size(40, 40);
            this.pbxCell_4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCell_4.TabIndex = 5;
            this.pbxCell_4.TabStop = false;
            // 
            // pbxCell_2
            // 
            this.pbxCell_2.Image = ((System.Drawing.Image)(resources.GetObject("pbxCell_2.Image")));
            this.pbxCell_2.Location = new System.Drawing.Point(52, 32);
            this.pbxCell_2.Name = "pbxCell_2";
            this.pbxCell_2.Size = new System.Drawing.Size(40, 40);
            this.pbxCell_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCell_2.TabIndex = 4;
            this.pbxCell_2.TabStop = false;
            // 
            // rbn6
            // 
            this.rbn6.Location = new System.Drawing.Point(24, 152);
            this.rbn6.Name = "rbn6";
            this.rbn6.Size = new System.Drawing.Size(20, 24);
            this.rbn6.TabIndex = 2;
            this.rbn6.CheckedChanged += new System.EventHandler(this.rbnCount_CheckedChanged);
            // 
            // rbn4
            // 
            this.rbn4.Location = new System.Drawing.Point(24, 92);
            this.rbn4.Name = "rbn4";
            this.rbn4.Size = new System.Drawing.Size(20, 24);
            this.rbn4.TabIndex = 1;
            this.rbn4.CheckedChanged += new System.EventHandler(this.rbnCount_CheckedChanged);
            // 
            // rbn9
            // 
            this.rbn9.Location = new System.Drawing.Point(24, 212);
            this.rbn9.Name = "rbn9";
            this.rbn9.Size = new System.Drawing.Size(20, 24);
            this.rbn9.TabIndex = 3;
            this.rbn9.CheckedChanged += new System.EventHandler(this.rbnCount_CheckedChanged);
            // 
            // rbn2
            // 
            this.rbn2.Location = new System.Drawing.Point(24, 32);
            this.rbn2.Name = "rbn2";
            this.rbn2.Size = new System.Drawing.Size(20, 24);
            this.rbn2.TabIndex = 0;
            this.rbn2.CheckedChanged += new System.EventHandler(this.rbnCount_CheckedChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpChartID);
            this.pnlTop.Controls.Add(this.grpChart);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlTop.Size = new System.Drawing.Size(568, 300);
            this.pnlTop.TabIndex = 0;
            // 
            // grpChartID
            // 
            this.grpChartID.Controls.Add(this.pnlChart9);
            this.grpChartID.Controls.Add(this.pnlChart8);
            this.grpChartID.Controls.Add(this.pnlChart7);
            this.grpChartID.Controls.Add(this.pnlChart6);
            this.grpChartID.Controls.Add(this.pnlChart5);
            this.grpChartID.Controls.Add(this.pnlChart4);
            this.grpChartID.Controls.Add(this.pnlChart3);
            this.grpChartID.Controls.Add(this.pnlChart2);
            this.grpChartID.Controls.Add(this.pnlChart1);
            this.grpChartID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChartID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpChartID.Location = new System.Drawing.Point(236, 0);
            this.grpChartID.Name = "grpChartID";
            this.grpChartID.Size = new System.Drawing.Size(329, 300);
            this.grpChartID.TabIndex = 1;
            this.grpChartID.TabStop = false;
            this.grpChartID.Text = "Select Chart ID";
            // 
            // pnlChart9
            // 
            this.pnlChart9.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChart9.Controls.Add(this.btnFiltering9);
            this.pnlChart9.Controls.Add(this.cdvChart9);
            this.pnlChart9.Controls.Add(this.lblChart9);
            this.pnlChart9.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart9.Location = new System.Drawing.Point(3, 256);
            this.pnlChart9.Name = "pnlChart9";
            this.pnlChart9.Size = new System.Drawing.Size(323, 30);
            this.pnlChart9.TabIndex = 10;
            // 
            // btnFiltering9
            // 
            this.btnFiltering9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering9.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering9.Image")));
            this.btnFiltering9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering9.Location = new System.Drawing.Point(296, 4);
            this.btnFiltering9.Name = "btnFiltering9";
            this.btnFiltering9.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering9.TabIndex = 29;
            this.btnFiltering9.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cdvChart9
            // 
            this.cdvChart9.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart9.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart9.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChart9.BtnToolTipText = "";
            this.cdvChart9.DescText = "";
            this.cdvChart9.DisplaySubItemIndex = -1;
            this.cdvChart9.DisplayText = "";
            this.cdvChart9.Focusing = null;
            this.cdvChart9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart9.Index = 0;
            this.cdvChart9.IsViewBtnImage = false;
            this.cdvChart9.Location = new System.Drawing.Point(112, 10);
            this.cdvChart9.MaxLength = 30;
            this.cdvChart9.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChart9.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChart9.Name = "cdvChart9";
            this.cdvChart9.ReadOnly = false;
            this.cdvChart9.SearchSubItemIndex = 0;
            this.cdvChart9.SelectedDescIndex = -1;
            this.cdvChart9.SelectedSubItemIndex = -1;
            this.cdvChart9.SelectionStart = 0;
            this.cdvChart9.Size = new System.Drawing.Size(180, 20);
            this.cdvChart9.SmallImageList = null;
            this.cdvChart9.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChart9.TabIndex = 0;
            this.cdvChart9.TextBoxToolTipText = "";
            this.cdvChart9.TextBoxWidth = 180;
            this.cdvChart9.VisibleButton = true;
            this.cdvChart9.VisibleColumnHeader = false;
            this.cdvChart9.VisibleDescription = false;
            this.cdvChart9.ButtonPress += new System.EventHandler(this.cdvChart_ButtonPress);
            this.cdvChart9.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // lblChart9
            // 
            this.lblChart9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChart9.Location = new System.Drawing.Point(10, 13);
            this.lblChart9.Name = "lblChart9";
            this.lblChart9.Size = new System.Drawing.Size(97, 14);
            this.lblChart9.TabIndex = 2;
            this.lblChart9.Text = "Chart ID";
            // 
            // pnlChart8
            // 
            this.pnlChart8.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChart8.Controls.Add(this.btnFiltering8);
            this.pnlChart8.Controls.Add(this.cdvChart8);
            this.pnlChart8.Controls.Add(this.lblChart8);
            this.pnlChart8.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart8.Location = new System.Drawing.Point(3, 226);
            this.pnlChart8.Name = "pnlChart8";
            this.pnlChart8.Size = new System.Drawing.Size(323, 30);
            this.pnlChart8.TabIndex = 9;
            // 
            // btnFiltering8
            // 
            this.btnFiltering8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering8.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering8.Image")));
            this.btnFiltering8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering8.Location = new System.Drawing.Point(296, 4);
            this.btnFiltering8.Name = "btnFiltering8";
            this.btnFiltering8.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering8.TabIndex = 28;
            this.btnFiltering8.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cdvChart8
            // 
            this.cdvChart8.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart8.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart8.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChart8.BtnToolTipText = "";
            this.cdvChart8.DescText = "";
            this.cdvChart8.DisplaySubItemIndex = -1;
            this.cdvChart8.DisplayText = "";
            this.cdvChart8.Focusing = null;
            this.cdvChart8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart8.Index = 0;
            this.cdvChart8.IsViewBtnImage = false;
            this.cdvChart8.Location = new System.Drawing.Point(112, 10);
            this.cdvChart8.MaxLength = 30;
            this.cdvChart8.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChart8.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChart8.Name = "cdvChart8";
            this.cdvChart8.ReadOnly = false;
            this.cdvChart8.SearchSubItemIndex = 0;
            this.cdvChart8.SelectedDescIndex = -1;
            this.cdvChart8.SelectedSubItemIndex = -1;
            this.cdvChart8.SelectionStart = 0;
            this.cdvChart8.Size = new System.Drawing.Size(180, 20);
            this.cdvChart8.SmallImageList = null;
            this.cdvChart8.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChart8.TabIndex = 0;
            this.cdvChart8.TextBoxToolTipText = "";
            this.cdvChart8.TextBoxWidth = 180;
            this.cdvChart8.VisibleButton = true;
            this.cdvChart8.VisibleColumnHeader = false;
            this.cdvChart8.VisibleDescription = false;
            this.cdvChart8.ButtonPress += new System.EventHandler(this.cdvChart_ButtonPress);
            this.cdvChart8.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // lblChart8
            // 
            this.lblChart8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChart8.Location = new System.Drawing.Point(10, 13);
            this.lblChart8.Name = "lblChart8";
            this.lblChart8.Size = new System.Drawing.Size(97, 14);
            this.lblChart8.TabIndex = 2;
            this.lblChart8.Text = "Chart ID";
            // 
            // pnlChart7
            // 
            this.pnlChart7.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChart7.Controls.Add(this.btnFiltering7);
            this.pnlChart7.Controls.Add(this.cdvChart7);
            this.pnlChart7.Controls.Add(this.lblChart7);
            this.pnlChart7.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart7.Location = new System.Drawing.Point(3, 196);
            this.pnlChart7.Name = "pnlChart7";
            this.pnlChart7.Size = new System.Drawing.Size(323, 30);
            this.pnlChart7.TabIndex = 8;
            // 
            // btnFiltering7
            // 
            this.btnFiltering7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering7.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering7.Image")));
            this.btnFiltering7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering7.Location = new System.Drawing.Point(296, 4);
            this.btnFiltering7.Name = "btnFiltering7";
            this.btnFiltering7.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering7.TabIndex = 28;
            this.btnFiltering7.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cdvChart7
            // 
            this.cdvChart7.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart7.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart7.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChart7.BtnToolTipText = "";
            this.cdvChart7.DescText = "";
            this.cdvChart7.DisplaySubItemIndex = -1;
            this.cdvChart7.DisplayText = "";
            this.cdvChart7.Focusing = null;
            this.cdvChart7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart7.Index = 0;
            this.cdvChart7.IsViewBtnImage = false;
            this.cdvChart7.Location = new System.Drawing.Point(112, 10);
            this.cdvChart7.MaxLength = 30;
            this.cdvChart7.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChart7.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChart7.Name = "cdvChart7";
            this.cdvChart7.ReadOnly = false;
            this.cdvChart7.SearchSubItemIndex = 0;
            this.cdvChart7.SelectedDescIndex = -1;
            this.cdvChart7.SelectedSubItemIndex = -1;
            this.cdvChart7.SelectionStart = 0;
            this.cdvChart7.Size = new System.Drawing.Size(180, 20);
            this.cdvChart7.SmallImageList = null;
            this.cdvChart7.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChart7.TabIndex = 0;
            this.cdvChart7.TextBoxToolTipText = "";
            this.cdvChart7.TextBoxWidth = 180;
            this.cdvChart7.VisibleButton = true;
            this.cdvChart7.VisibleColumnHeader = false;
            this.cdvChart7.VisibleDescription = false;
            this.cdvChart7.ButtonPress += new System.EventHandler(this.cdvChart_ButtonPress);
            this.cdvChart7.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // lblChart7
            // 
            this.lblChart7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChart7.Location = new System.Drawing.Point(10, 13);
            this.lblChart7.Name = "lblChart7";
            this.lblChart7.Size = new System.Drawing.Size(97, 14);
            this.lblChart7.TabIndex = 2;
            this.lblChart7.Text = "Chart ID";
            // 
            // pnlChart6
            // 
            this.pnlChart6.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChart6.Controls.Add(this.btnFiltering6);
            this.pnlChart6.Controls.Add(this.cdvChart6);
            this.pnlChart6.Controls.Add(this.lblChart6);
            this.pnlChart6.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart6.Location = new System.Drawing.Point(3, 166);
            this.pnlChart6.Name = "pnlChart6";
            this.pnlChart6.Size = new System.Drawing.Size(323, 30);
            this.pnlChart6.TabIndex = 7;
            // 
            // btnFiltering6
            // 
            this.btnFiltering6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering6.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering6.Image")));
            this.btnFiltering6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering6.Location = new System.Drawing.Point(296, 4);
            this.btnFiltering6.Name = "btnFiltering6";
            this.btnFiltering6.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering6.TabIndex = 28;
            this.btnFiltering6.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cdvChart6
            // 
            this.cdvChart6.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart6.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart6.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChart6.BtnToolTipText = "";
            this.cdvChart6.DescText = "";
            this.cdvChart6.DisplaySubItemIndex = -1;
            this.cdvChart6.DisplayText = "";
            this.cdvChart6.Focusing = null;
            this.cdvChart6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart6.Index = 0;
            this.cdvChart6.IsViewBtnImage = false;
            this.cdvChart6.Location = new System.Drawing.Point(112, 10);
            this.cdvChart6.MaxLength = 30;
            this.cdvChart6.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChart6.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChart6.Name = "cdvChart6";
            this.cdvChart6.ReadOnly = false;
            this.cdvChart6.SearchSubItemIndex = 0;
            this.cdvChart6.SelectedDescIndex = -1;
            this.cdvChart6.SelectedSubItemIndex = -1;
            this.cdvChart6.SelectionStart = 0;
            this.cdvChart6.Size = new System.Drawing.Size(180, 20);
            this.cdvChart6.SmallImageList = null;
            this.cdvChart6.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChart6.TabIndex = 0;
            this.cdvChart6.TextBoxToolTipText = "";
            this.cdvChart6.TextBoxWidth = 180;
            this.cdvChart6.VisibleButton = true;
            this.cdvChart6.VisibleColumnHeader = false;
            this.cdvChart6.VisibleDescription = false;
            this.cdvChart6.ButtonPress += new System.EventHandler(this.cdvChart_ButtonPress);
            this.cdvChart6.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // lblChart6
            // 
            this.lblChart6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChart6.Location = new System.Drawing.Point(10, 13);
            this.lblChart6.Name = "lblChart6";
            this.lblChart6.Size = new System.Drawing.Size(97, 14);
            this.lblChart6.TabIndex = 2;
            this.lblChart6.Text = "Chart ID";
            // 
            // pnlChart5
            // 
            this.pnlChart5.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChart5.Controls.Add(this.btnFiltering5);
            this.pnlChart5.Controls.Add(this.cdvChart5);
            this.pnlChart5.Controls.Add(this.lblChart5);
            this.pnlChart5.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart5.Location = new System.Drawing.Point(3, 136);
            this.pnlChart5.Name = "pnlChart5";
            this.pnlChart5.Size = new System.Drawing.Size(323, 30);
            this.pnlChart5.TabIndex = 6;
            // 
            // btnFiltering5
            // 
            this.btnFiltering5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering5.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering5.Image")));
            this.btnFiltering5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering5.Location = new System.Drawing.Point(296, 4);
            this.btnFiltering5.Name = "btnFiltering5";
            this.btnFiltering5.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering5.TabIndex = 28;
            this.btnFiltering5.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cdvChart5
            // 
            this.cdvChart5.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart5.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart5.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChart5.BtnToolTipText = "";
            this.cdvChart5.DescText = "";
            this.cdvChart5.DisplaySubItemIndex = -1;
            this.cdvChart5.DisplayText = "";
            this.cdvChart5.Focusing = null;
            this.cdvChart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart5.Index = 0;
            this.cdvChart5.IsViewBtnImage = false;
            this.cdvChart5.Location = new System.Drawing.Point(112, 10);
            this.cdvChart5.MaxLength = 30;
            this.cdvChart5.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChart5.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChart5.Name = "cdvChart5";
            this.cdvChart5.ReadOnly = false;
            this.cdvChart5.SearchSubItemIndex = 0;
            this.cdvChart5.SelectedDescIndex = -1;
            this.cdvChart5.SelectedSubItemIndex = -1;
            this.cdvChart5.SelectionStart = 0;
            this.cdvChart5.Size = new System.Drawing.Size(180, 20);
            this.cdvChart5.SmallImageList = null;
            this.cdvChart5.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChart5.TabIndex = 0;
            this.cdvChart5.TextBoxToolTipText = "";
            this.cdvChart5.TextBoxWidth = 180;
            this.cdvChart5.VisibleButton = true;
            this.cdvChart5.VisibleColumnHeader = false;
            this.cdvChart5.VisibleDescription = false;
            this.cdvChart5.ButtonPress += new System.EventHandler(this.cdvChart_ButtonPress);
            this.cdvChart5.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // lblChart5
            // 
            this.lblChart5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChart5.Location = new System.Drawing.Point(10, 13);
            this.lblChart5.Name = "lblChart5";
            this.lblChart5.Size = new System.Drawing.Size(97, 14);
            this.lblChart5.TabIndex = 2;
            this.lblChart5.Text = "Chart ID";
            // 
            // pnlChart4
            // 
            this.pnlChart4.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChart4.Controls.Add(this.btnFiltering4);
            this.pnlChart4.Controls.Add(this.cdvChart4);
            this.pnlChart4.Controls.Add(this.lblChart4);
            this.pnlChart4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart4.Location = new System.Drawing.Point(3, 106);
            this.pnlChart4.Name = "pnlChart4";
            this.pnlChart4.Size = new System.Drawing.Size(323, 30);
            this.pnlChart4.TabIndex = 5;
            // 
            // btnFiltering4
            // 
            this.btnFiltering4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering4.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering4.Image")));
            this.btnFiltering4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering4.Location = new System.Drawing.Point(296, 4);
            this.btnFiltering4.Name = "btnFiltering4";
            this.btnFiltering4.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering4.TabIndex = 28;
            this.btnFiltering4.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cdvChart4
            // 
            this.cdvChart4.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart4.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart4.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChart4.BtnToolTipText = "";
            this.cdvChart4.DescText = "";
            this.cdvChart4.DisplaySubItemIndex = -1;
            this.cdvChart4.DisplayText = "";
            this.cdvChart4.Focusing = null;
            this.cdvChart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart4.Index = 0;
            this.cdvChart4.IsViewBtnImage = false;
            this.cdvChart4.Location = new System.Drawing.Point(112, 10);
            this.cdvChart4.MaxLength = 30;
            this.cdvChart4.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChart4.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChart4.Name = "cdvChart4";
            this.cdvChart4.ReadOnly = false;
            this.cdvChart4.SearchSubItemIndex = 0;
            this.cdvChart4.SelectedDescIndex = -1;
            this.cdvChart4.SelectedSubItemIndex = -1;
            this.cdvChart4.SelectionStart = 0;
            this.cdvChart4.Size = new System.Drawing.Size(180, 20);
            this.cdvChart4.SmallImageList = null;
            this.cdvChart4.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChart4.TabIndex = 0;
            this.cdvChart4.TextBoxToolTipText = "";
            this.cdvChart4.TextBoxWidth = 180;
            this.cdvChart4.VisibleButton = true;
            this.cdvChart4.VisibleColumnHeader = false;
            this.cdvChart4.VisibleDescription = false;
            this.cdvChart4.ButtonPress += new System.EventHandler(this.cdvChart_ButtonPress);
            this.cdvChart4.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // lblChart4
            // 
            this.lblChart4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChart4.Location = new System.Drawing.Point(10, 13);
            this.lblChart4.Name = "lblChart4";
            this.lblChart4.Size = new System.Drawing.Size(97, 14);
            this.lblChart4.TabIndex = 2;
            this.lblChart4.Text = "Chart ID";
            // 
            // pnlChart3
            // 
            this.pnlChart3.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChart3.Controls.Add(this.btnFiltering3);
            this.pnlChart3.Controls.Add(this.cdvChart3);
            this.pnlChart3.Controls.Add(this.lblChart3);
            this.pnlChart3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart3.Location = new System.Drawing.Point(3, 76);
            this.pnlChart3.Name = "pnlChart3";
            this.pnlChart3.Size = new System.Drawing.Size(323, 30);
            this.pnlChart3.TabIndex = 4;
            // 
            // btnFiltering3
            // 
            this.btnFiltering3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering3.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering3.Image")));
            this.btnFiltering3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering3.Location = new System.Drawing.Point(296, 4);
            this.btnFiltering3.Name = "btnFiltering3";
            this.btnFiltering3.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering3.TabIndex = 28;
            this.btnFiltering3.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cdvChart3
            // 
            this.cdvChart3.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart3.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart3.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChart3.BtnToolTipText = "";
            this.cdvChart3.DescText = "";
            this.cdvChart3.DisplaySubItemIndex = -1;
            this.cdvChart3.DisplayText = "";
            this.cdvChart3.Focusing = null;
            this.cdvChart3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart3.Index = 0;
            this.cdvChart3.IsViewBtnImage = false;
            this.cdvChart3.Location = new System.Drawing.Point(112, 10);
            this.cdvChart3.MaxLength = 30;
            this.cdvChart3.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChart3.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChart3.Name = "cdvChart3";
            this.cdvChart3.ReadOnly = false;
            this.cdvChart3.SearchSubItemIndex = 0;
            this.cdvChart3.SelectedDescIndex = -1;
            this.cdvChart3.SelectedSubItemIndex = -1;
            this.cdvChart3.SelectionStart = 0;
            this.cdvChart3.Size = new System.Drawing.Size(180, 20);
            this.cdvChart3.SmallImageList = null;
            this.cdvChart3.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChart3.TabIndex = 0;
            this.cdvChart3.TextBoxToolTipText = "";
            this.cdvChart3.TextBoxWidth = 180;
            this.cdvChart3.VisibleButton = true;
            this.cdvChart3.VisibleColumnHeader = false;
            this.cdvChart3.VisibleDescription = false;
            this.cdvChart3.ButtonPress += new System.EventHandler(this.cdvChart_ButtonPress);
            this.cdvChart3.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // lblChart3
            // 
            this.lblChart3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChart3.Location = new System.Drawing.Point(10, 13);
            this.lblChart3.Name = "lblChart3";
            this.lblChart3.Size = new System.Drawing.Size(97, 14);
            this.lblChart3.TabIndex = 2;
            this.lblChart3.Text = "Chart ID";
            // 
            // pnlChart2
            // 
            this.pnlChart2.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChart2.Controls.Add(this.btnFiltering2);
            this.pnlChart2.Controls.Add(this.cdvChart2);
            this.pnlChart2.Controls.Add(this.lblChart2);
            this.pnlChart2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart2.Location = new System.Drawing.Point(3, 46);
            this.pnlChart2.Name = "pnlChart2";
            this.pnlChart2.Size = new System.Drawing.Size(323, 30);
            this.pnlChart2.TabIndex = 3;
            // 
            // btnFiltering2
            // 
            this.btnFiltering2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering2.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering2.Image")));
            this.btnFiltering2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering2.Location = new System.Drawing.Point(296, 4);
            this.btnFiltering2.Name = "btnFiltering2";
            this.btnFiltering2.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering2.TabIndex = 28;
            this.btnFiltering2.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cdvChart2
            // 
            this.cdvChart2.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart2.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart2.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChart2.BtnToolTipText = "";
            this.cdvChart2.DescText = "";
            this.cdvChart2.DisplaySubItemIndex = -1;
            this.cdvChart2.DisplayText = "";
            this.cdvChart2.Focusing = null;
            this.cdvChart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart2.Index = 0;
            this.cdvChart2.IsViewBtnImage = false;
            this.cdvChart2.Location = new System.Drawing.Point(112, 10);
            this.cdvChart2.MaxLength = 30;
            this.cdvChart2.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChart2.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChart2.Name = "cdvChart2";
            this.cdvChart2.ReadOnly = false;
            this.cdvChart2.SearchSubItemIndex = 0;
            this.cdvChart2.SelectedDescIndex = -1;
            this.cdvChart2.SelectedSubItemIndex = -1;
            this.cdvChart2.SelectionStart = 0;
            this.cdvChart2.Size = new System.Drawing.Size(180, 20);
            this.cdvChart2.SmallImageList = null;
            this.cdvChart2.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChart2.TabIndex = 0;
            this.cdvChart2.TextBoxToolTipText = "";
            this.cdvChart2.TextBoxWidth = 180;
            this.cdvChart2.VisibleButton = true;
            this.cdvChart2.VisibleColumnHeader = false;
            this.cdvChart2.VisibleDescription = false;
            this.cdvChart2.ButtonPress += new System.EventHandler(this.cdvChart_ButtonPress);
            this.cdvChart2.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // lblChart2
            // 
            this.lblChart2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChart2.Location = new System.Drawing.Point(10, 13);
            this.lblChart2.Name = "lblChart2";
            this.lblChart2.Size = new System.Drawing.Size(97, 14);
            this.lblChart2.TabIndex = 2;
            this.lblChart2.Text = "Chart ID";
            // 
            // pnlChart1
            // 
            this.pnlChart1.BackColor = System.Drawing.SystemColors.Control;
            this.pnlChart1.Controls.Add(this.btnFiltering1);
            this.pnlChart1.Controls.Add(this.cdvChart1);
            this.pnlChart1.Controls.Add(this.lblChart1);
            this.pnlChart1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChart1.Location = new System.Drawing.Point(3, 16);
            this.pnlChart1.Name = "pnlChart1";
            this.pnlChart1.Size = new System.Drawing.Size(323, 30);
            this.pnlChart1.TabIndex = 2;
            // 
            // btnFiltering1
            // 
            this.btnFiltering1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFiltering1.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltering1.Image")));
            this.btnFiltering1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFiltering1.Location = new System.Drawing.Point(296, 4);
            this.btnFiltering1.Name = "btnFiltering1";
            this.btnFiltering1.Size = new System.Drawing.Size(24, 24);
            this.btnFiltering1.TabIndex = 28;
            this.btnFiltering1.Click += new System.EventHandler(this.btnFiltering_Click);
            // 
            // cdvChart1
            // 
            this.cdvChart1.BorderColor = System.Drawing.Color.DarkGray;
            this.cdvChart1.BorderHotColor = System.Drawing.Color.Black;
            this.cdvChart1.BtnFlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cdvChart1.BtnToolTipText = "";
            this.cdvChart1.DescText = "";
            this.cdvChart1.DisplaySubItemIndex = -1;
            this.cdvChart1.DisplayText = "";
            this.cdvChart1.Focusing = null;
            this.cdvChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdvChart1.Index = 0;
            this.cdvChart1.IsViewBtnImage = false;
            this.cdvChart1.Location = new System.Drawing.Point(112, 10);
            this.cdvChart1.MaxLength = 30;
            this.cdvChart1.MCViewStyle.BorderColor = System.Drawing.SystemColors.Control;
            this.cdvChart1.MCViewStyle.BorderHotColor = System.Drawing.SystemColors.Control;
            this.cdvChart1.Name = "cdvChart1";
            this.cdvChart1.ReadOnly = false;
            this.cdvChart1.SearchSubItemIndex = 0;
            this.cdvChart1.SelectedDescIndex = -1;
            this.cdvChart1.SelectedSubItemIndex = -1;
            this.cdvChart1.SelectionStart = 0;
            this.cdvChart1.Size = new System.Drawing.Size(180, 20);
            this.cdvChart1.SmallImageList = null;
            this.cdvChart1.StyleBorder = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cdvChart1.TabIndex = 0;
            this.cdvChart1.TextBoxToolTipText = "";
            this.cdvChart1.TextBoxWidth = 180;
            this.cdvChart1.VisibleButton = true;
            this.cdvChart1.VisibleColumnHeader = false;
            this.cdvChart1.VisibleDescription = false;
            this.cdvChart1.ButtonPress += new System.EventHandler(this.cdvChart_ButtonPress);
            this.cdvChart1.SelectedItemChanged += new Miracom.UI.MCCodeViewSelChangedHandler(this.cdvChart_SelectedItemChanged);
            // 
            // lblChart1
            // 
            this.lblChart1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblChart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChart1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblChart1.Location = new System.Drawing.Point(10, 13);
            this.lblChart1.Name = "lblChart1";
            this.lblChart1.Size = new System.Drawing.Size(97, 14);
            this.lblChart1.TabIndex = 2;
            this.lblChart1.Text = "Chart ID";
            // 
            // pnlOption
            // 
            this.pnlOption.Controls.Add(this.grpOption);
            this.pnlOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOption.Location = new System.Drawing.Point(0, 300);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlOption.Size = new System.Drawing.Size(568, 126);
            this.pnlOption.TabIndex = 1;
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkAutoCalControlLimit);
            this.grpOption.Controls.Add(this.chkSimpleChart);
            this.grpOption.Controls.Add(this.chkViewRuleCheck);
            this.grpOption.Controls.Add(this.chkViewRChart);
            this.grpOption.Controls.Add(this.chkViewSpecLimit);
            this.grpOption.Controls.Add(this.chkViewDate);
            this.grpOption.Controls.Add(this.chkViewLotID);
            this.grpOption.Controls.Add(this.txtMaxLotCount);
            this.grpOption.Controls.Add(this.lblMaxLotCount);
            this.grpOption.Controls.Add(this.chkViewCZone);
            this.grpOption.Controls.Add(this.chkViewBZone);
            this.grpOption.Controls.Add(this.chkViewAZone);
            this.grpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOption.Location = new System.Drawing.Point(3, 0);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(562, 126);
            this.grpOption.TabIndex = 0;
            this.grpOption.TabStop = false;
            // 
            // chkAutoCalControlLimit
            // 
            this.chkAutoCalControlLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoCalControlLimit.Location = new System.Drawing.Point(272, 56);
            this.chkAutoCalControlLimit.Name = "chkAutoCalControlLimit";
            this.chkAutoCalControlLimit.Size = new System.Drawing.Size(172, 14);
            this.chkAutoCalControlLimit.TabIndex = 5;
            this.chkAutoCalControlLimit.Text = "Auto Calculation Control Limit";
            this.chkAutoCalControlLimit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkSimpleChart
            // 
            this.chkSimpleChart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSimpleChart.Location = new System.Drawing.Point(148, 96);
            this.chkSimpleChart.Name = "chkSimpleChart";
            this.chkSimpleChart.Size = new System.Drawing.Size(112, 14);
            this.chkSimpleChart.TabIndex = 10;
            this.chkSimpleChart.Text = "Simple Chart";
            this.chkSimpleChart.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewRuleCheck
            // 
            this.chkViewRuleCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewRuleCheck.Location = new System.Drawing.Point(148, 56);
            this.chkViewRuleCheck.Name = "chkViewRuleCheck";
            this.chkViewRuleCheck.Size = new System.Drawing.Size(112, 14);
            this.chkViewRuleCheck.TabIndex = 4;
            this.chkViewRuleCheck.Text = "View Rule Check";
            this.chkViewRuleCheck.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewRChart
            // 
            this.chkViewRChart.Checked = true;
            this.chkViewRChart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewRChart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewRChart.Location = new System.Drawing.Point(148, 76);
            this.chkViewRChart.Name = "chkViewRChart";
            this.chkViewRChart.Size = new System.Drawing.Size(112, 14);
            this.chkViewRChart.TabIndex = 7;
            this.chkViewRChart.Text = "View R-Chart";
            this.chkViewRChart.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewSpecLimit
            // 
            this.chkViewSpecLimit.Checked = true;
            this.chkViewSpecLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewSpecLimit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewSpecLimit.Location = new System.Drawing.Point(16, 96);
            this.chkViewSpecLimit.Name = "chkViewSpecLimit";
            this.chkViewSpecLimit.Size = new System.Drawing.Size(112, 14);
            this.chkViewSpecLimit.TabIndex = 9;
            this.chkViewSpecLimit.Text = "View Spec Limit";
            this.chkViewSpecLimit.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewDate
            // 
            this.chkViewDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewDate.Location = new System.Drawing.Point(16, 76);
            this.chkViewDate.Name = "chkViewDate";
            this.chkViewDate.Size = new System.Drawing.Size(112, 14);
            this.chkViewDate.TabIndex = 6;
            this.chkViewDate.Text = "View Date";
            this.chkViewDate.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewLotID
            // 
            this.chkViewLotID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewLotID.Location = new System.Drawing.Point(16, 56);
            this.chkViewLotID.Name = "chkViewLotID";
            this.chkViewLotID.Size = new System.Drawing.Size(112, 14);
            this.chkViewLotID.TabIndex = 3;
            this.chkViewLotID.Text = "View XAxis Label";
            this.chkViewLotID.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // txtMaxLotCount
            // 
            this.txtMaxLotCount.Location = new System.Drawing.Point(356, 73);
            this.txtMaxLotCount.MaxLength = 2;
            this.txtMaxLotCount.Name = "txtMaxLotCount";
            this.txtMaxLotCount.Size = new System.Drawing.Size(54, 20);
            this.txtMaxLotCount.TabIndex = 8;
            this.txtMaxLotCount.Text = "30";
            this.txtMaxLotCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxLotCount_KeyPress);
            // 
            // lblMaxLotCount
            // 
            this.lblMaxLotCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxLotCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxLotCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxLotCount.Location = new System.Drawing.Point(272, 76);
            this.lblMaxLotCount.Name = "lblMaxLotCount";
            this.lblMaxLotCount.Size = new System.Drawing.Size(112, 14);
            this.lblMaxLotCount.TabIndex = 10;
            this.lblMaxLotCount.Text = "Max Point Count :";
            // 
            // chkViewCZone
            // 
            this.chkViewCZone.Checked = true;
            this.chkViewCZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewCZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewCZone.Location = new System.Drawing.Point(200, 23);
            this.chkViewCZone.Name = "chkViewCZone";
            this.chkViewCZone.Size = new System.Drawing.Size(72, 14);
            this.chkViewCZone.TabIndex = 2;
            this.chkViewCZone.Text = "C Zone";
            this.chkViewCZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewBZone
            // 
            this.chkViewBZone.Checked = true;
            this.chkViewBZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewBZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewBZone.Location = new System.Drawing.Point(108, 23);
            this.chkViewBZone.Name = "chkViewBZone";
            this.chkViewBZone.Size = new System.Drawing.Size(72, 14);
            this.chkViewBZone.TabIndex = 1;
            this.chkViewBZone.Text = "B Zone";
            this.chkViewBZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkViewAZone
            // 
            this.chkViewAZone.Checked = true;
            this.chkViewAZone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViewAZone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViewAZone.Location = new System.Drawing.Point(16, 23);
            this.chkViewAZone.Name = "chkViewAZone";
            this.chkViewAZone.Size = new System.Drawing.Size(72, 14);
            this.chkViewAZone.TabIndex = 0;
            this.chkViewAZone.Text = "A Zone";
            this.chkViewAZone.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            // 
            // frmSPCTranDynamicChartOptions
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(568, 466);
            this.Controls.Add(this.pnlOption);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSPCTranDynamicChartOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multi Chart Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSPCTranDynamicChartOptions_FormClosed);
            this.Load += new System.EventHandler(this.frmSPCTranDynamicChartOptions_Load);
            this.pnlBottom.ResumeLayout(false);
            this.grpChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCell_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCell_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCell_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCell_2)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.grpChartID.ResumeLayout(false);
            this.pnlChart9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart9)).EndInit();
            this.pnlChart8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart8)).EndInit();
            this.pnlChart7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart7)).EndInit();
            this.pnlChart6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart6)).EndInit();
            this.pnlChart5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart5)).EndInit();
            this.pnlChart4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart4)).EndInit();
            this.pnlChart3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart3)).EndInit();
            this.pnlChart2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart2)).EndInit();
            this.pnlChart1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cdvChart1)).EndInit();
            this.pnlOption.ResumeLayout(false);
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLotCount)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion

        #region " Variable Definition " 

        private ArrayList DisabledFormControls = new ArrayList();

        #endregion

        #region " Function Implementations"

        // CheckCondition()
        //       - Check the conditions before transaction
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal FuncName As String : Function Name
        //       - Optional ByVal ProcStep As String : Process Step
        //
        private bool CheckCondition()
        {
            
            try
            {
                if (rbn2.Checked == true)
                {
                    
                    if (CheckChartID(cdvChart1) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart2) == false)
                    {
                        return false;
                    }
                }
                else if (rbn4.Checked == true)
                {
                    
                    if (CheckChartID(cdvChart1) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart2) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart3) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart4) == false)
                    {
                        return false;
                    }
                }
                else if (rbn6.Checked == true)
                {
                    
                    if (CheckChartID(cdvChart1) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart2) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart3) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart4) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart5) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart6) == false)
                    {
                        return false;
                    }
                }
                else if (rbn9.Checked == true)
                {
                    
                    if (CheckChartID(cdvChart1) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart2) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart3) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart4) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart5) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart6) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart7) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart8) == false)
                    {
                        return false;
                    }
                    if (CheckChartID(cdvChart9) == false)
                    {
                        return false;
                    }
                }
                if (View_Chart(cdvChart1.Text, false) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart2.Text, false) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart3.Text, false) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart4.Text, false) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart5.Text, false) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart6.Text, false) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart7.Text, false) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart8.Text, false) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart9.Text, false) == false)
                {
                    return false;
                }
                if (MPCF.CheckNumeric(txtMaxLotCount.Text) == false)
                {
                    MPCF.ShowMsgBox(MPCF.GetMessage(116));
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                    return false;
                }
                else
                {
                    if (MPCF.ToInt(txtMaxLotCount.Text) <= 0)
                    {
                        MPCF.ShowMsgBox(MPCF.GetMessage(116));
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return false;
                    }
                    if (MPCF.ToInt(txtMaxLotCount.Text) > 100)
                    {
                        if (MPGV.gcLanguage == '2')
                        {
                            MPCF.ShowMsgBox(MPCF.GetErrorMsgParse(236, "\'100\' ") + MPCF.GetMessage(236));
                        }
                        else
                        {
                            MPCF.ShowMsgBox(MPCF.GetMessage(236) + " \'100\'");
                        }
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                        return false;
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.CheckCondition()\n" + ex.Message);
                return false;
            }
            
        }
        
        // SetChartEnable()
        //       - Set Enable Property Chart ID Control
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void SetChartEnable()
        {
            
            try
            {
                if (rbn2.Checked == true)
                {
                    lblChart3.Font = new System.Drawing.Font(lblChart3.Font, System.Drawing.FontStyle.Regular);
                    cdvChart3.Enabled = false;
                    cdvChart3.Text = "";
                    btnFiltering3.Enabled = false;
                    lblChart4.Font = new System.Drawing.Font(lblChart4.Font, System.Drawing.FontStyle.Regular);
                    cdvChart4.Enabled = false;
                    cdvChart4.Text = "";
                    btnFiltering4.Enabled = false;
                    lblChart5.Font = new System.Drawing.Font(lblChart5.Font, System.Drawing.FontStyle.Regular);
                    cdvChart5.Enabled = false;
                    cdvChart5.Text = "";
                    btnFiltering5.Enabled = false;
                    lblChart6.Font = new System.Drawing.Font(lblChart6.Font, System.Drawing.FontStyle.Regular);
                    cdvChart6.Enabled = false;
                    cdvChart6.Text = "";
                    btnFiltering6.Enabled = false;
                    lblChart7.Font = new System.Drawing.Font(lblChart7.Font, System.Drawing.FontStyle.Regular);
                    cdvChart7.Enabled = false;
                    cdvChart7.Text = "";
                    btnFiltering7.Enabled = false;
                    lblChart8.Font = new System.Drawing.Font(lblChart8.Font, System.Drawing.FontStyle.Regular);
                    cdvChart8.Enabled = false;
                    cdvChart8.Text = "";
                    btnFiltering8.Enabled = false;
                    lblChart9.Font = new System.Drawing.Font(lblChart9.Font, System.Drawing.FontStyle.Regular);
                    cdvChart9.Enabled = false;
                    cdvChart9.Text = "";
                    btnFiltering9.Enabled = false;
                }
                else if (rbn4.Checked == true)
                {
                    lblChart3.Font = new System.Drawing.Font(lblChart3.Font, System.Drawing.FontStyle.Bold);
                    cdvChart3.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering3, true);
                    lblChart4.Font = new System.Drawing.Font(lblChart4.Font, System.Drawing.FontStyle.Bold);
                    cdvChart4.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering4, true);
                    lblChart5.Font = new System.Drawing.Font(lblChart5.Font, System.Drawing.FontStyle.Regular);
                    cdvChart5.Enabled = false;
                    cdvChart5.Text = "";
                    btnFiltering5.Enabled = false;
                    lblChart6.Font = new System.Drawing.Font(lblChart6.Font, System.Drawing.FontStyle.Regular);
                    cdvChart6.Enabled = false;
                    cdvChart6.Text = "";
                    btnFiltering6.Enabled = false;
                    lblChart7.Font = new System.Drawing.Font(lblChart7.Font, System.Drawing.FontStyle.Regular);
                    cdvChart7.Enabled = false;
                    cdvChart7.Text = "";
                    btnFiltering7.Enabled = false;
                    lblChart8.Font = new System.Drawing.Font(lblChart8.Font, System.Drawing.FontStyle.Regular);
                    cdvChart8.Enabled = false;
                    cdvChart8.Text = "";
                    btnFiltering8.Enabled = false;
                    lblChart9.Font = new System.Drawing.Font(lblChart9.Font, System.Drawing.FontStyle.Regular);
                    cdvChart9.Enabled = false;
                    cdvChart9.Text = "";
                    btnFiltering9.Enabled = false;
                }
                else if (rbn6.Checked == true)
                {
                    lblChart3.Font = new System.Drawing.Font(lblChart3.Font, System.Drawing.FontStyle.Bold);
                    cdvChart3.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering3, true);
                    lblChart4.Font = new System.Drawing.Font(lblChart4.Font, System.Drawing.FontStyle.Bold);
                    cdvChart4.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering4, true);
                    lblChart5.Font = new System.Drawing.Font(lblChart5.Font, System.Drawing.FontStyle.Bold);
                    cdvChart5.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering5, true);
                    lblChart6.Font = new System.Drawing.Font(lblChart6.Font, System.Drawing.FontStyle.Bold);
                    cdvChart6.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering6, true);
                    lblChart7.Font = new System.Drawing.Font(lblChart7.Font, System.Drawing.FontStyle.Regular);
                    cdvChart7.Enabled = false;
                    cdvChart7.Text = "";
                    btnFiltering7.Enabled = false;
                    lblChart8.Font = new System.Drawing.Font(lblChart8.Font, System.Drawing.FontStyle.Regular);
                    cdvChart8.Enabled = false;
                    cdvChart8.Text = "";
                    btnFiltering8.Enabled = false;
                    lblChart9.Font = new System.Drawing.Font(lblChart9.Font, System.Drawing.FontStyle.Regular);
                    cdvChart9.Enabled = false;
                    cdvChart9.Text = "";
                    btnFiltering9.Enabled = false;
                }
                else if (rbn9.Checked == true)
                {
                    lblChart3.Font = new System.Drawing.Font(lblChart3.Font, System.Drawing.FontStyle.Bold);
                    cdvChart3.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering3, true);
                    lblChart4.Font = new System.Drawing.Font(lblChart4.Font, System.Drawing.FontStyle.Bold);
                    cdvChart4.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering4, true);
                    lblChart5.Font = new System.Drawing.Font(lblChart5.Font, System.Drawing.FontStyle.Bold);
                    cdvChart5.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering5, true);
                    lblChart6.Font = new System.Drawing.Font(lblChart6.Font, System.Drawing.FontStyle.Bold);
                    cdvChart6.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering6, true);
                    lblChart7.Font = new System.Drawing.Font(lblChart7.Font, System.Drawing.FontStyle.Bold);
                    cdvChart7.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering7, true);
                    lblChart8.Font = new System.Drawing.Font(lblChart8.Font, System.Drawing.FontStyle.Bold);
                    cdvChart8.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering8, true);
                    lblChart9.Font = new System.Drawing.Font(lblChart9.Font, System.Drawing.FontStyle.Bold);
                    cdvChart9.Enabled = true;
                    MPCR.ChangeControlEnabled(this, btnFiltering9, true);
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.SetChartEnable()\n" + ex.Message);
            }
            
        }
        
        // SaveChartOption()
        //       - Save Chart Option
        // Return Value
        //       -
        // Arguments
        //       -
        //
        private void SaveChartOption()
        {
            
            try
            {
                int iChartCount = 0;
                if (rbn2.Checked == true)
                {
                    iChartCount = 2;
                }
                else if (rbn4.Checked == true)
                {
                    iChartCount = 4;
                }
                else if (rbn6.Checked == true)
                {
                    iChartCount = 6;
                }
                else if (rbn9.Checked == true)
                {
                    iChartCount = 9;
                }
                
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartCount", iChartCount.ToString());
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartID1", cdvChart1.Text);
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartID2", cdvChart2.Text);
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartID3", cdvChart3.Text);
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartID4", cdvChart4.Text);
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartID5", cdvChart5.Text);
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartID6", cdvChart6.Text);
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartID7", cdvChart7.Text);
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartID8", cdvChart8.Text);
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "ChartID9", cdvChart9.Text);
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsViewAZone", (chkViewAZone.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsViewBZone", (chkViewBZone.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsViewCZone", (chkViewCZone.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsViewLotID", (chkViewLotID.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsViewDate", (chkViewDate.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsViewSpecLimit", (chkViewSpecLimit.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsViewRuleCheck", (chkViewRuleCheck.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsViewRChart", (chkViewRChart.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsSimpleChart", (chkSimpleChart.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "IsAutoCalControlLimit", (chkAutoCalControlLimit.Checked == true ? "Y" : ""));
                MPCF.SaveRegSetting(Application.ProductName, "MultiOption", "MaxLotCount", txtMaxLotCount.Text);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.SaveChartOption()\n" + ex.Message);
            }
            
        }
        
        // GetChartOption()
        //       - Get Chart Option
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       -
        //
        public bool GetChartOption()
        {
            
            try
            {
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartCount", "") == "")
                {
                    return false;
                }
                else
                {
                    if (MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartCount", "")) == 2)
                    {
                        rbn2.Checked = true;
                    }
                    else if (MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartCount", "")) == 4)
                    {
                        rbn4.Checked = true;
                    }
                    else if (MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartCount", "")) == 6)
                    {
                        rbn6.Checked = true;
                    }
                    else if (MPCF.ToInt(MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartCount", "")) == 9)
                    {
                        rbn9.Checked = true;
                    }
                }
                cdvChart1.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID1", "");
                cdvChart2.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID2", "");
                cdvChart3.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID3", "");
                cdvChart4.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID4", "");
                cdvChart5.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID5", "");
                cdvChart6.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID6", "");
                cdvChart7.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID7", "");
                cdvChart8.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID8", "");
                cdvChart9.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "ChartID9", "");
                if (View_Chart(cdvChart1.Text, true) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart2.Text, true) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart3.Text, true) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart4.Text, true) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart5.Text, true) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart6.Text, true) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart7.Text, true) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart8.Text, true) == false)
                {
                    return false;
                }
                if (View_Chart(cdvChart9.Text, true) == false)
                {
                    return false;
                }
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewAZone", "") == "Y")
                {
                    chkViewAZone.Checked = true;
                }
                else
                {
                    chkViewAZone.Checked = false;
                }
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewBZone", "") == "Y")
                {
                    chkViewBZone.Checked = true;
                }
                else
                {
                    chkViewBZone.Checked = false;
                }
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewCZone", "") == "Y")
                {
                    chkViewCZone.Checked = true;
                }
                else
                {
                    chkViewCZone.Checked = false;
                }
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewLotID", "") == "Y")
                {
                    chkViewLotID.Checked = true;
                }
                else
                {
                    chkViewLotID.Checked = false;
                }
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewDate", "") == "Y")
                {
                    chkViewDate.Checked = true;
                }
                else
                {
                    chkViewDate.Checked = false;
                }
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewSpecLimit", "") == "Y")
                {
                    chkViewSpecLimit.Checked = true;
                }
                else
                {
                    chkViewSpecLimit.Checked = false;
                }
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewRuleCheck", "") == "Y")
                {
                    chkViewRuleCheck.Checked = true;
                }
                else
                {
                    chkViewRuleCheck.Checked = false;
                }
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsViewRChart", "") == "Y")
                {
                    chkViewRChart.Checked = true;
                }
                else
                {
                    chkViewRChart.Checked = false;
                }
                
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsSimpleChart", "") == "Y")
                {
                    chkSimpleChart.Checked = true;
                }
                else
                {
                    chkSimpleChart.Checked = false;
                }
                
                if (MPCF.GetRegSetting(Application.ProductName, "MultiOption", "IsAutoCalControlLimit", "") == "Y")
                {
                    chkAutoCalControlLimit.Checked = true;
                }
                else
                {
                    chkAutoCalControlLimit.Checked = false;
                }
                
                txtMaxLotCount.Text = MPCF.GetRegSetting(Application.ProductName, "MultiOption", "MaxLotCount", "");
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.GetChartOption()\n" + ex.Message);
                return false;
            }
            
        }
        
        // View_Chart()
        //       - View Chart
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByVal sChartID As String : Chart ID
        //       - Optional ByVal bIgnore As Boolean = True : Ignore Error Flag
        //
        private bool View_Chart(string sChartID, bool bIgnore)
        {
            
            try
            {
                TRSNode in_node = new TRSNode("View_Chart_In");
                TRSNode out_node = new TRSNode("View_Chart_Out");
                
                if (sChartID == "")
                {
                    return true;
                }

                MPCR.SetInMsg(in_node);
                in_node.ProcStep = '1';
                in_node.AddString("CHART_ID", MPCF.Trim(sChartID));

                if (MPCR.CallService("SPC", "SPC_View_Chart", in_node, ref out_node) == false)
                {
                    return false;
                }
                                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.View_Chart()\n" + ex.Message);
                return false;
            }
            
        }
        
        // CheckChartID()
        //       - Check ChartID
        // Return Value
        //       - Boolean : True or False
        // Arguments
        //       - ByRef cdvChart As Miracom.UI.Controls.MCCodeView.MCCodeView
        //
        private bool CheckChartID(Miracom.UI.Controls.MCCodeView.MCCodeView cdvChart)
        {
            
            try
            {
                Control ctrl1;
                Control ctrl2;
                foreach (Control tempLoopVar_ctrl1 in grpChartID.Controls)
                {
                    ctrl1 = tempLoopVar_ctrl1;
                    if (ctrl1 is Panel)
                    {
                        foreach (Control tempLoopVar_ctrl2 in ctrl1.Controls)
                        {
                            ctrl2 = tempLoopVar_ctrl2;
                            if (ctrl2 is Miracom.UI.Controls.MCCodeView.MCCodeView)
                            {
                                if (cdvChart.Text != "")
                                {
                                    if (cdvChart.Name != ctrl2.Name)
                                    {
                                        if (cdvChart.Text == ((Miracom.UI.Controls.MCCodeView.MCCodeView) ctrl2).Text)
                                        {
                                            MPCF.ShowMsgBox(MPCF.GetMessage(220));
                                            cdvChart.Focus();
                                            cdvChart.Text = "";
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                return true;
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.CheckChartID()\n" + ex.Message);
                return false;
            }
            
        }
        
        #endregion
        
        #region " Event Implematations"
        
        private void cdvChart_ButtonPress(object sender, System.EventArgs e)
        {
            
            try
            {
                Miracom.UI.Controls.MCCodeView.MCCodeView cdvTemp;
                cdvTemp = (Miracom.UI.Controls.MCCodeView.MCCodeView) sender;
                
                cdvTemp.Init();
                MPCF.InitListView(cdvTemp.GetListView);
                cdvTemp.Columns.Add("Chart", 50, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("GraphType", 50, HorizontalAlignment.Left);
                cdvTemp.Columns.Add("Desc", 100, HorizontalAlignment.Left);
                cdvTemp.SelectedSubItemIndex = 0;
                SPCLIST.ViewChartList(cdvTemp.GetListView, '2', "", 0,"", "", "", ' ', ' ', "", "", -1, -1, null, "");
                cdvTemp.AddEmptyRow(1);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.cdvChart_ButtonPress()\n" + ex.Message);
            }
            
        }
        
        private void rbnCount_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                SetChartEnable();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.rbnCount_CheckedChanged()\n" + ex.Message);
            }
            
        }
        
        private void txtMaxLotCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            
            try
            {
                if (e.KeyChar != (char)13 && e.KeyChar != (char)8)
                {
                    if (e.KeyChar < (char)48 || e.KeyChar > (char)57)
                    {
                        e.Handled = true;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.txtMaxLotCount_KeyPress()\n" + ex.Message);
            }
            
        }
        
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                //this.Dispose();
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.btnClose_Click()\n" + ex.Message);
            }
            
        }
        
        private void btnOK_Click(System.Object sender, System.EventArgs e)
        {
            
            try
            {
                if (CheckCondition() == false)
                {
                    return;
                }
                SaveChartOption();

                this.Close();

                try
                {
                    Form form = MPCF.GetChildForm(MPGV.gfrmMDI, "frmSPCTranDynamicMultiChart");
                    if (form == null)
                    {
                        form = new frmSPCTranDynamicMultiChart();
                        form.MdiParent = MPGV.gfrmMDI;
                        form.Show();
                        form.Activate();
                    }
                    else
                    {
                        form.Activate();
                    }
                }
                catch (Exception ex)
                {
                    MPCF.ShowMsgBox(ex.Message);
                    return;
                }                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.btnOK_Click()\n" + ex.Message);
            }
            
        }
        
        private void frmSPCTranDynamicChartOptions_Load(object sender, System.EventArgs e)
        {
            
            try
            {
                MPGV.gIBaseFormEvent.Form_Load(this, e);
                MPCF.SetTextboxStyle(this.Controls);
                rbn2.Checked = true;
                GetChartOption();
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.frmSPCTranDynamicChartOptions_Load()\n" + ex.Message);
            }
            
        }
        
        private void cdvChart_SelectedItemChanged(object sender, UI.MCCodeViewSelChanged_EventArgs e)
        {
            
            try
            {
                
                CheckChartID((Miracom.UI.Controls.MCCodeView.MCCodeView) sender);
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.cdvChart_SelectedItemChanged()\n" + ex.Message);
            }
            
        }
        
        private void btnFiltering_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                frmSPCViewChartList form = new frmSPCViewChartList();
                Control ctl;
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (form.lisChart.SelectedItems.Count > 0)
                    {
                        foreach (Control tempLoopVar_ctl in ((Control) sender).Parent.Controls)
                        {
                            ctl = tempLoopVar_ctl;
                            if (ctl is Miracom.UI.Controls.MCCodeView.MCCodeView)
                            {
                                if (((Miracom.UI.Controls.MCCodeView.MCCodeView) ctl).Enabled == true)
                                {
                                    ((Miracom.UI.Controls.MCCodeView.MCCodeView) ctl).Text = form.lisChart.SelectedItems[0].SubItems[1].Text;
                                    CheckChartID((Miracom.UI.Controls.MCCodeView.MCCodeView) ctl);
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCViewSpecHistory.btnFiltering_Click()\n" + ex.Message);
            }
            
        }
        
        #endregion

        private void frmSPCTranDynamicChartOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            try
            {

                //this.Dispose();

                //MPCF.FlushMemory();

                //MPGV.gfrmMDI.ActiveMdiChild.Activate();

                //Form[] f = MPGV.gfrmMDI.MdiChildren;

            }
            catch (Exception ex)
            {
                MPCF.ShowMsgBox("frmSPCTranDynamicChartOptions.frmSPCTranDynamicChartOptions_FormClosed()\n" + ex.Message);
            }

        }
        
    }
    
    
    //#End If
    
}
